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
        private int zoom;




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
            if (tracks.Count > 0) track.Location = new Point(0, tracks.Last().Location.Y + tracks.Last().Height + track.Font.Height * 2);
            this.tracks.Add(track);
            this.trackSelector.Items.Add(track);
            canvasPanel.Controls.Add(track);
        }



        private void dropTrack(SequenceTrack track){
            this.trackSelector.Items.Remove(track);
            tracks.Remove(track);
            refreshEditor();
        }

        #endregion

        #region Graphische Darstellungen

        public void refreshEditor() {
            canvasPanel.Invalidate();
            foreach (Control ctrl in canvasPanel.Controls) ctrl.Invalidate();
        }



        /*private void drawTracks(){
            calculateBarPositions();
            foreach (SequenceTrackAlt track in tracks) {
                track.draw(canvasPanel, font, (showNucleotideLettersToolStripMenuItem.Checked && zoom == 1));
            }
            /*
            int y = 10;
            int scrollOffset = scrollbarCanvasX.Value * (int)font.Size;

            foreach (SequenceTrack track in tracks){
                track.setScreenPosition(y, track.getTagRows() * font.Height + 2 * font.Height);
                if (showAntisenseStrandToolStripMenuItem.Checked) track.setScreenPosition(y, track.getScreenHeight() + font.Height);
                drawTrack(track, y);
                y += track.getScreenHeight() + 2*font.Height;
            } 
        }*/


        /*
        private void calculateBarPositions(){
            int y = 10;
            int scrollOffset = scrollbarCanvasX.Value * (int)font.Size;
            int descriptorWidth = (int)canvas.MeasureString("Antisense", font).Width + 2 * letterWidth;
            foreach (SequenceTrackAlt track in tracks) {
                track.headerBar.setPosition(0, y, (int)canvas.MeasureString(track.getHeader(), font).Width + 2 * letterWidth, font.Height);
                track.senseHeaderBar.setPosition(0, y + font.Height, descriptorWidth, font.Height);
                int x = descriptorWidth;
                foreach (DNASequenceAlt seq in track.getSequences()){
                    seq.senseBar.setPosition(x + letterWidth * (seq.getOffSetSense() - scrollbarCanvasX.Value), y + font.Height, letterWidth * seq.getLengthSense(), font.Height);
                    if (showAntisenseStrandToolStripMenuItem.Checked) seq.antisenseBar.setPosition(x + letterWidth * (seq.getOffSetSense() - scrollbarCanvasX.Value), y + 2 * font.Height, letterWidth * seq.getLengthAntisense(), font.Height);
                    else seq.antisenseBar.hide();
                    x += seq.getLengthTotal() * letterWidth;
                }
                if (showAntisenseStrandToolStripMenuItem.Checked){
                    track.antisenseHeaderBar.setPosition(0, y + 2* font.Height, descriptorWidth, font.Height);
                    track.backgroundBar.setPosition(0, y, canvasPanel.Width, font.Height*3);
                    y += font.Height * 5;
                }
                else{
                    track.antisenseHeaderBar.hide();
                    track.backgroundBar.setPosition(0, y, canvasPanel.Width, font.Height * 2);
                    y += font.Height * 4;
                }
            }
        }*/


        /*
        private void drawTrack(SequenceTrack track, int y){
            canvas.FillRectangle(Brushes.DimGray, 0, y, canvasPanel.Width, track.getScreenHeight());
            foreach (DNASequence seq in track.getSequences()) {
                drawSequence(seq, y + font.Height);
                if (showAntisenseStrandToolStripMenuItem.Checked) drawSequenceAntiSense(seq, y + font.Height*2);
            }

            this.drawBar(Brushes.Blue, -(int)font.Size/2, y, (int)canvas.MeasureString(track.getHeader(), font).Width + 2 * letterWidth);
            canvas.DrawString(track.getHeader(), font, Brushes.White, letterWidth, y);
            this.drawBar(Brushes.LightBlue, -letterWidth/2, y + font.Height, descriptorWidth);
            canvas.DrawString("Sense", font, Brushes.Black, letterWidth, y + font.Height);
            if (showAntisenseStrandToolStripMenuItem.Checked) {
                this.drawBar(Brushes.LightBlue, -letterWidth / 2, y + 2*font.Height, descriptorWidth);
                canvas.DrawString("Antisense", font, Brushes.Black, letterWidth, y + 2*font.Height);
            }
            if (track == this.trackSelector.SelectedItem) canvas.DrawRectangle(marker, 0, y, canvasPanel.Width, track.getScreenHeight());
        }



        private void drawSequence(DNASequence seq, int y){
            int x = (seq.getOffsetTrack() - scrollbarCanvasX.Value) * letterWidth - letterWidth/2 + descriptorWidth;
            drawBar(seq.color, x, y, (int)(seq.getLengthTotal() + 0.5) * letterWidth);
            if (showNucleotideLettersToolStripMenuItem.Checked){
                for (int i = 1; i <= seq.getLengthTotal(); i++) {
                    canvas.DrawString(seq.getBase(i + seq.getOffSetSense()).ToString(), font, Brushes.Black, x, y);
                    x += letterWidth;
                }
            }
        }



        private void drawSequenceAntiSense(DNASequence seq, int y) {
            int x = (seq.getOffsetTrack() - scrollbarCanvasX.Value) * letterWidth - letterWidth / 2 + descriptorWidth;
            drawBar(seq.color, x, y, (int)(seq.getLengthTotal() + 0.5) * letterWidth);
            if (showNucleotideLettersToolStripMenuItem.Checked) {
                for (int i = 1; i <= seq.getLengthTotal(); i++) {
                    canvas.DrawString(seq.getBaseAntisense(i + seq.getOffSetAntisense()).ToString(), font, Brushes.Black, x, y);
                    x += letterWidth;
                }
            }
        }



        public void drawBar(Brush brush, int x, int y, int len){
            int letterWidth = (int)font.Size;
            if (x > canvasPanel.Width) return;
            if (x + len < -4) return;
            int beginVisible = x;
            if (x < -4) beginVisible = -4;
            int endVisible = x + len;
            if (endVisible > canvasPanel.Width) endVisible = canvasPanel.Width + 4;
            int lengthVisible = endVisible - beginVisible;

            canvas.FillRectangle(brush, beginVisible, y, lengthVisible, font.Height);
            canvas.DrawRectangle(Pens.Black, beginVisible, y, lengthVisible, font.Height);
        } */

        #endregion



        #region Event Management

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }



        private void OnAddTestSequence(object sender, EventArgs e)
        {
            addTrack(new SequenceTrack(new DNASequence(">Testsequenz\nACGT", src : "System Test")));
            refreshEditor();
        }



        private void OnOpenFasta(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Fasta File|*.fasta";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            List<DNASequence> readSeqs = FileHandler.readFasta(openFileDialog.FileName);
            addTrack(new SequenceTrack(readSeqs));
            refreshEditor();
        }



        private void OnDrawCanvas(object sender, PaintEventArgs e)
        {
            //drawTracks();
        }



        private void OnClickCanvas(object sender, MouseEventArgs e)
        {
            Console.WriteLine("X: " + e.X + ", Y: " +e.Y);
            foreach (SequenceTrack track in tracks){
                //if (track.isOnTrack(e.Y)) trackSelector.SelectedItem = track;
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

        #endregion
    }
}
