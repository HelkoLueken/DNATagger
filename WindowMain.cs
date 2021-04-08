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

        List<DNASequence> sequences = new List<DNASequence>();
        WindowAddTag tagAddingDialogue;
        public String notes = "Here you can write notes regarding your project.\nYou will only see these after loading the project.\nBy selecting Sequences or Tags you can add notes to them as well";


        public delegate void ControlCloser();
        public void OnCloseMyControl() {
            if (tagAddingDialogue != null)
                tagAddingDialogue.Dispose();
            tagAddingDialogue = null;
        }

        public double zoom {
            get { return Math.Pow(2, zoomRegler.Value); }
        }
        public WindowMain()
        {
            InitializeComponent();
            notizBox.Text = notes;
            notizBoxLabel.Text = "Project Info";
        }



        public DNASequence selectedSequence{ 
            get { DNASequence seq = (DNASequence)sequenceSelector.SelectedItem; return seq; }
            set { saveNotes(); sequenceSelector.SelectedItem = value; }
        }



        public SequenceTag selectedTag {
            get { SequenceTag tag = (SequenceTag)tagSelector.SelectedItem; return tag; }
            set { 
                saveNotes();
                if (selectedTag != null) selectedTag.unhighlight();
                selectedSequence = value.sequence;
                tagSelector.SelectedItem = value;
            }
        }



        private void addSequence(DNASequence seq){
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
            if (sequenceSelector.SelectedItem == null) return;
            if (selectedSequence == null) return;
            if (tagAddingDialogue == null) tagAddingDialogue = new WindowAddTag(selectedSequence, new ControlCloser(OnCloseMyControl));
            tagAddingDialogue.Show();
            tagAddingDialogue.Focus();
        }
        #endregion


        private void OnChangeSelectedSequence(object sender, EventArgs e) {
            foreach (DNASequence seqi in sequences) seqi.unhighlight();
            DNASequence seq = (DNASequence)sequenceSelector.SelectedItem;
            seq.highlight();
            notizBox.Text = selectedSequence.notes;
            notizBoxLabel.Text = "Annotations for Sequence: " + selectedSequence.header;
            refreshTagSelector();
            refreshEditor();
        }



        public void refreshTagSelector(){
            tagSelector.Items.Clear();
            tagSelector.Text = "";
            foreach (SequenceTag tag in selectedSequence.getTags()) tagSelector.Items.Add(tag);
        }



        private void OnChangeSelectedTag(object sender, EventArgs e) {
            notizBox.Text = selectedTag.notes;
            notizBoxLabel.Text = "Annotations for Tag: " + selectedTag.header;
            selectedTag.highlight();
            refreshEditor();
        }



        public void saveNotes(){
            if (tagSelector.Text != "") {
                selectedTag.notes = notizBox.Text;
                return;
            }
            if (sequenceSelector.Text != "") selectedSequence.notes = notizBox.Text;
            else notes = notizBox.Text;
        }

        private void OnSave(object sender, EventArgs e) {
            saveNotes();
        }

        private void OnClickLink(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
