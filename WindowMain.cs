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
        private WindowAddSequence seqAddingDialogue;
        public String savePath;
        public String notes = "";
        public delegate void ControlCloser();





        public WindowMain() {
            InitializeComponent();
        }


        //<summary> Diese Funktion wird als Delegat an das Tag-Adding Formular übergeben. Sie ermöglicht das schließen des Formulars über das Hauptfenster.</summary>
        public void OnCloseTagAddingDlg() {
            if (tagAddingDialogue != null)
                tagAddingDialogue.Dispose();
            tagAddingDialogue = null;
        }



        /**<summary> Diese Funktion wird als Delegat an das Sequenz-Adding Formular übergeben. Sie ermöglicht das schließen des Formulars über das Hauptfenster.</summary>*/
        public void OnCloseSeqAddingDlg() {
            if (seqAddingDialogue != null)
                seqAddingDialogue.Dispose();
            seqAddingDialogue = null;
        }



        /**<summary>Dieser Faktor wird zum skalieren der Sequenz- und Tags-Balken im Editor verwendet. Er wird über den Schieberegeler eingestellt.</summary>*/
        public double zoom {
            get { return Math.Pow(2, zoomRegler.Value); }
        }
        


        /**<summary>Die aktuell vom User ausgewählte Nukleotid-Sequenz</summary>*/
        public DNASequence selectedSequence{ 
            get { 
                DNASequence seq = (DNASequence)sequenceSelector.SelectedItem;
                return seq;
            }
            set {
                if (value == selectedSequence) return;
                if (selectedSequence != null) selectedSequence.unhighlight();
                saveNotes(); //Muss vor dem Ändern des selectedItem geschehen
                sequenceSelector.SelectedItem = value;
            }
        }



        /**<summary>Der aktuell vom User ausgewählte Sequenz-Tag</summary>*/
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
            seq.adjustToZoom();
            arrangeSequences();
        }



        private void dropSequence(DNASequence seq) {
            if (seq == selectedSequence) sequenceSelector.Text = "";
            this.sequenceSelector.Items.Remove(seq);
            sequences.Remove(seq);
            panelEditor.Controls.Remove(seq);
            seq.Dispose();
            arrangeSequences();
            refreshNoteBox();
            refreshEditor();
        }



        private void dropTag(SequenceTag tag){
            if (tag == selectedTag) tagSelector.Text = "";
            tag.sequence.dropTag(tag);
            panelEditor.Controls.Remove(tag);
            refreshTagSelector();
            refreshNoteBox();
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



        public int displayableLetters { 
            get{
                return (int)(LetterViewBox.Width / 7) -2;
            }
        }



        private void selectSavePath(){
            saveFileDialog.Filter = "DNATagger Project File|*.dnat";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "") savePath = saveFileDialog.FileName;
        }


        /**<summary> Asks the user to save the currently loaded project. If there are no sequences loaded the user will not be asked.</summary> */
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
            sequenceSelector.Text = "";
            tagSelector.Text = "";
            refreshNoteBox();
        }
        #endregion



        #region Graphische Darstellungen

        public void refreshEditor() {
            arrangeSequences();
            panelEditor.Invalidate();
        }



        public void arrangeSequences(){
            int y = 0;
            foreach (DNASequence seq in sequences){
                seq.Location = new Point(0, y);
                y += seq.Height + seq.Font.Height * 2;
            }
        }



        public String inDepthView{ 
            set{ LetterViewBox.Text = value; }
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



        public void refreshPosLabels(){
            if (selectedTag != null) {
                lengthLabel.Text = "Length: " + selectedTag.getLength();
                startLabel.Visible = true;
                startLabel.Text = "Start: " + selectedTag.startPos;
                endLabel.Visible = true;
                endLabel.Text = "End: " + selectedTag.endPos;
                notizBoxLabel.Text = "Annotations for Tag: " + selectedTag.header;
                return;
            }
            if (selectedSequence != null) {
                lengthLabel.Text = "Length: " + selectedSequence.getLengthTotal();
                startLabel.Visible = false;
                endLabel.Visible = false;
                return;
            }
            lengthLabel.Text = "Length:";
            startLabel.Visible = false;
            endLabel.Visible = false;
        }

        #endregion



        #region Event Management

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
            if (tagAddingDialogue == null) tagAddingDialogue = new WindowAddTag(selectedSequence, new ControlCloser(OnCloseTagAddingDlg));
            tagAddingDialogue.Show();
            tagAddingDialogue.Focus();
        }



        private void OnAddSeq(object sender, EventArgs e) {
            if (seqAddingDialogue == null) seqAddingDialogue = new WindowAddSequence(this, new ControlCloser(OnCloseSeqAddingDlg));
            seqAddingDialogue.Show();
            seqAddingDialogue.Focus();
        }



        private void OnChangeSelectedSequence(object sender, EventArgs e) {
            if (selectedSequence != null) selectedSequence.highlight();
            refreshNoteBox();
            refreshPosLabels();
            refreshTagSelector();
            refreshEditor();
        }



        private void OnChangeSelectedTag(object sender, EventArgs e) {
            if (selectedTag != null) selectedTag.highlight();
            refreshNoteBox();
            refreshPosLabels();
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



        private void OnChangeLetterViewerVisibility(object sender, EventArgs e) {
            if (showInDepthMenuItem.Checked){
                groupBoxCanvas.Height -= groupBoxLetterViewer.Height;
                groupBoxLetterViewer.Visible = true;
            }
            else{
                groupBoxLetterViewer.Visible = false;
                groupBoxCanvas.Height += groupBoxLetterViewer.Height;
            }
        }



        private void OnNewProject(object sender, EventArgs e) {
            checkSafetySave();
            clearProject();
        }



        private void OnDropSequence(object sender, EventArgs e) {
            if (selectedSequence == null) return;
            if (MessageBox.Show("Really delete selected sequence?", "Delete sequence?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) dropSequence(selectedSequence);
        }



        private void OnDropTag(object sender, EventArgs e) {
            if (selectedTag == null) return;
            if (MessageBox.Show("Really delete selected sequence-tag?", "Delete tag?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) dropTag(selectedTag);
        }

        #endregion
    }
}
