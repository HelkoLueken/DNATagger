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
        List<SequenceTrack> tracks = new List<SequenceTrack>();

        public int zoom{ 
            get{ return (int)Math.Pow(3, zoomRegler.Value - 1); }
            set{ zoomRegler.Value = value; }
        }



        #region Datenverwaltung
        public WindowMain()
        {
            InitializeComponent();
        }



        public int maxTrackLength() {
            int max = 0;
            foreach (SequenceTrack track in tracks)
            {
                if (track.getLength() > max) max = track.getLength();
            }
            return max;
        }



        private void addTrack(SequenceTrack track){
            track.window = this;
            this.tracks.Add(track);
            panelEditor.Controls.Add(track);
            this.trackSelector.Items.Add(track);
            arrangeTracks();
        }



        private void dropTrack(SequenceTrack track){
            this.trackSelector.Items.Remove(track);
            tracks.Remove(track);
            panelEditor.Controls.Remove(track);
            refreshEditor();
        }



        public void select(SequenceTrack track){
            trackSelector.SelectedItem = track;
        }

        #endregion



        #region Graphische Darstellungen

        public void refreshEditor() {
            arrangeTracks();
            panelEditor.Invalidate();
            foreach (Control ctrl in panelEditor.Controls) ctrl.Invalidate();
        }



        public void arrangeTracks(){
            int y = 0;
            foreach (SequenceTrack track in tracks){
                track.Location = new Point(0, y);
                y += track.Height + track.Font.Height * 2;
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
            addTrack(new SequenceTrack(new DNASequence(">Testsequenz\nACGT", src : "System Test")));
            refreshEditor();
        }



        private void OnOpenFasta(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Fasta File|*.fasta|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            List<DNASequence> readSeqs = FileHandler.readFasta(openFileDialog.FileName);
            addTrack(new SequenceTrack(readSeqs));
            refreshEditor();
        }



        private void OnClickCanvas(object sender, MouseEventArgs e)
        {
            Console.WriteLine("X: " + e.X + ", Y: " +e.Y);
            foreach (SequenceTrack track in tracks){
                
            }
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
            if (MessageBox.Show("Are you sure you want to delete this track and all contained nucleotide sequences?", "Delete Track", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                dropTrack((SequenceTrack)trackSelector.SelectedItem);
        }



        private void OnSwitchLetterVisibility(object sender, EventArgs e) {
            if (showNucleotideLettersToolStripMenuItem.Checked) showLetters();
            else hideLetters();
            Invalidate();
        }



        private void OnChangeZoom(object sender, EventArgs e) {
            if (zoomRegler.Value == 1 && showNucleotideLettersToolStripMenuItem.Checked) showLetters();
            else hideLetters();
            foreach (SequenceTrack track in tracks) track.adjustToZoom();
            refreshEditor();
        }

        #endregion

        private void OnAddTag(object sender, EventArgs e) {
            if (trackSelector.SelectedItem == null) return;
            SequenceTrack track = (SequenceTrack)trackSelector.SelectedItem;
            track.addTag("TestTag", 0, 100, Color.Green);
        }
    }
}
