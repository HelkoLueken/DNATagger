using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DNATagger
{
    public partial class WindowMain : Form
    {
        #region Datenverwaltung

        private List<DNASequence> sequences = new List<DNASequence>();
        private WindowAddTag tagAddingDialogue;
        public String savePath;
        public String notes = "Here you can write notes regarding your project, such as URLs to cited papers.\n" +
            "If you select a sequence or sequence-tag this box will display another set of notes, specifically for them.\n" +
            "You can deselect any sequence or tag by clicking the background of the editor.";
        public delegate void ControlCloser();





        public WindowMain() {
            InitializeComponent();
            notizBox.Text = notes;
            notizBoxLabel.Text = "Project Info";
        }


        /**@author Helko
         * Diese Funktion wird als Delegat an ein untergordnetes Dialogfenster übergeben.
         * Sie ermiöglicht den Dialogen sich selbst über das Parent Window zu schließen.
         */
        public void OnCloseMyControl() {
            if (tagAddingDialogue != null)
                tagAddingDialogue.Dispose();
            tagAddingDialogue = null;
        }



        /**@author Helko
         * <summary>Dieser Faktor wird zum skalieren der Sequenz- und Tags-Balken im Editor verwendet. Er wird über den Schieberegeler eingestellt.
         * Die werte liegen zwischen 2^-5 und 2^5</summary>
         */
        public double zoom {
            get { return Math.Pow(2, zoomRegler.Value); }
        }
        



        public DNASequence selectedSequence{ 
            get { 
                DNASequence seq = (DNASequence)sequenceSelector.SelectedItem;
                return seq;
            }
            set {
                if (value == selectedSequence) return;
                saveNotes(); //Muss vor dem Ändern des selectedItem geschehen
                if (selectedSequence != null) selectedSequence.unhighlight();
                sequenceSelector.SelectedItem = value;
            }
        }



        public SequenceTag selectedTag {
            get {
                SequenceTag tag = (SequenceTag)tagSelector.SelectedItem;
                return tag;
            }
            set {
                if (value == selectedTag) return;
                saveNotes(); //Muss vor dem Ändern des selectedItem geschehen
                if (selectedTag != null) selectedTag.unhighlight();
                selectedSequence = value.sequence;
                tagSelector.SelectedItem = value;
            }
        }



        private void unselectSequence(){
            if (selectedSequence != null) selectedSequence.unhighlight();
            sequenceSelector.SelectedItem = null;
        }



        public void unselectTag(){
            if (selectedTag != null) selectedTag.unhighlight();
            tagSelector.SelectedItem = null;
        }



        public void addSequence(DNASequence seq){
            seq.window = this;
            sequences.Add(seq);
            panelEditor.Controls.Add(seq);
            sequenceSelector.Items.Add(seq);
            arrangeSequences();
        }



        private void dropSequence(DNASequence seq) {
            this.sequenceSelector.Items.Remove(seq);
            sequences.Remove(seq);
            panelEditor.Controls.Remove(seq);
            arrangeSequences();
            refreshEditor();
        }



        public void saveNotes() {
            if (selectedTag != null && tagSelector.Text != "") {
                selectedTag.notes = notizBox.Text;
                return;
            }
            if (selectedSequence != null) selectedSequence.notes = notizBox.Text;
            else notes = notizBox.Text;
        }



        public void refreshTagSelector() {
            tagSelector.Items.Clear();
            tagSelector.Text = "";
            if (selectedSequence != null) foreach (SequenceTag tag in selectedSequence.getTags()) tagSelector.Items.Add(tag);
        }



        public List<DNASequence> getSequences(){
            return sequences;
        }



        private void selectSavePath(){
            saveFileDialog.Filter = "DNATagger Project File|*.dnat";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "") savePath = saveFileDialog.FileName;
        }


        /**<summary> Asks the user to save the currently loaded project. If there are no sequences loaded the user will not be asked.</summary>
         */
        private void checkSafetySave(){ 
            if (sequences.Count > 0){
                if (MessageBox.Show("Save current project?", "Save project?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) save();
            }
        }



        public void save(){
            saveNotes();
            if (savePath == null || savePath == "") selectSavePath();
            FileHandler.saveProject(this);
        }



        private void clearProject(){
            notes = "";
            for (int i = sequences.Count - 1; i >= 0; i--) dropSequence(sequences.ElementAt(i)); //foreach funktioniert nicht, weil gelöscht wird
            savePath = "";
        }
        #endregion



        #region Graphische Darstellungen

        public void refreshEditor() {
            arrangeSequences();
            panelEditor.Invalidate();
            foreach (Control ctrl in panelEditor.Controls) ctrl.Invalidate();
        }



        public void arrangeSequences(){
            int y = 0;
            foreach (DNASequence seq in sequences){
                seq.Location = new Point(0, y);
                y += seq.Height + seq.Font.Height * 2;
            }
        }



        private void refreshNoteBox() {
            if (selectedTag != null) {
                notizBox.Text = selectedTag.notes;
                notizBoxLabel.Text = "Annotations for Tag: " + selectedTag.header;
                return;
            }
            if (selectedSequence != null) {
                notizBox.Text = selectedSequence.notes;
                notizBoxLabel.Text = "Annotations for Sequence: " + selectedSequence.header;
                return;
            }
            notizBoxLabel.Text = "Project Info";
            notizBox.Text = notes;
        }

        #endregion



        #region Event Management

        private void OnAddTestSequence(object sender, EventArgs e)
        {  
            addSequence(new DNASequence(">Testsequenz\nACGT", src : "System Test"));
            refreshEditor(); 
        }



        private void OnOpenFasta(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Fasta File|*.fasta|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            List<DNASequence> readSeqs = FileHandler.readFasta(openFileDialog.FileName);
            foreach (DNASequence seq in readSeqs){
                addSequence(seq);
            }
            refreshEditor();
        }



        private void OnResize(object sender, EventArgs e)
        {
            refreshEditor();
        }



        private void OnChangeZoom(object sender, EventArgs e) {
            foreach (DNASequence seq in sequences) seq.adjustToZoom();
            refreshEditor();
        }


        private void OnAddTag(object sender, EventArgs e) {
            if (sequenceSelector.SelectedItem == null || selectedSequence == null) return;
            if (tagAddingDialogue == null) tagAddingDialogue = new WindowAddTag(selectedSequence, new ControlCloser(OnCloseMyControl));
            tagAddingDialogue.Show();
            tagAddingDialogue.Focus();
        }



        private void OnChangeSelectedSequence(object sender, EventArgs e) {
            if (selectedSequence != null) selectedSequence.highlight();
            refreshNoteBox();
            refreshTagSelector();
            refreshEditor();
        }



        private void OnChangeSelectedTag(object sender, EventArgs e) {
            if (selectedTag != null) selectedTag.highlight();
            refreshNoteBox();
            refreshEditor();
        }



        private void OnSave(object sender, EventArgs e) {
            save();
        }



        private void OnClickLink(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }



        private void OnSaveAs(object sender, EventArgs e) {
            saveNotes();
            selectSavePath();
            FileHandler.saveProject(this);
        }



        private void OnLoadProject(object sender, EventArgs e) {
            checkSafetySave();
            clearProject();
            openFileDialog.Filter = "DNATagger Project File|*.dnat";
            openFileDialog.ShowDialog();
            savePath = openFileDialog.FileName;
            FileHandler.loadProject(this);
        }



        private void OnClosing(object sender, FormClosingEventArgs e) {
            checkSafetySave();
        }


        private void OnClickEditorBG(object sender, MouseEventArgs e) {
            unselectSequence();
        }
        #endregion
    }
}
