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

        public int zoom {
            get { return (int)Math.Pow(3, zoomRegler.Value - 1); }
            set { zoomRegler.Value = value; }
        }
        public WindowMain()
        {
            InitializeComponent();
        }



        public int maxTrackLength() {
            /*
            int max = 0;
            foreach (DNASequence track in tracks)
            {
                if (track.getLength() > max) max = track.getLength();
            }
            return max;
            */
            return 0;
        }



        private void addSequence(DNASequence seq){
            seq.window = this;
            sequences.Add(seq);
            panelEditor.Controls.Add(seq);
            sequenceSelector.Items.Add(seq);
            arrangeSequences();
        }



        private void dropTrack(DNASequence track){
            /*
            this.trackSelector.Items.Remove(track);
            tracks.Remove(track);
            panelEditor.Controls.Remove(track);
            refreshEditor();
            */
        }



        public void selectSequence(DNASequence seq){
            sequenceSelector.SelectedItem = seq;
            foreach (DNASequence seqi in sequences) seqi.unhighlight();
            seq.highlight();
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



        public void hideLetters(){ 

        }



        public void showLetters() {

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



        private void OnClickCanvas(object sender, MouseEventArgs e)
        {
            Console.WriteLine("X: " + e.X + ", Y: " +e.Y);
            refreshEditor();
        }



        private void OnResize(object sender, EventArgs e)
        {
            refreshEditor();
        }



        private void OnChangeViewOptions(object sender, EventArgs e) {
            refreshEditor();
        }



        private void OnDeleteTrack(object sender, EventArgs e) {

        }



        private void OnSwitchLetterVisibility(object sender, EventArgs e) {
            /*if (showNucleotideLettersToolStripMenuItem.Checked) showLetters();
            else hideLetters();
            Invalidate(); */
        }



        private void OnChangeZoom(object sender, EventArgs e) {
            /*
             * if (zoomRegler.Value == 1 && showNucleotideLettersToolStripMenuItem.Checked) showLetters();
            else hideLetters();
            foreach (DNASequence track in tracks) track.adjustToZoom();
            refreshEditor();
            */
        }


        private void OnAddTag(object sender, EventArgs e) {
            /*if (trackSelector.SelectedItem == null) return;
            DNASequence track = (DNASequence)trackSelector.SelectedItem;
            track.addTag("TestTag", 0, 100, Color.Green);
            */
        }
        #endregion
    }
}
