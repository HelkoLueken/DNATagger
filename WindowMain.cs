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
        static Font font = new Font("Consolas", 14);
        static int letterWidth = (int)font.Size;
        static int descriptorWidth;
        Brush brush = Brushes.Black;
        static Graphics canvas;





        public WindowMain()
        {
            InitializeComponent();
            canvas = canvasMain.CreateGraphics();
            descriptorWidth = (int)canvas.MeasureString("Antisense", font).Width + 2 * letterWidth;
        }



        public void refreshEditor() {
            canvasMain.Invalidate();
        }



        public void updateScrollbars() {
            int newBound = 4 + maxTrackLength() - ((canvasMain.Width - (int)canvas.MeasureString("Antisense", font).Width) / letterWidth);
            if (newBound > 0) scrollbarCanvasX.Maximum = newBound;
        }



        public int maxTrackLength() {
            int max = 0;
            foreach (SequenceTrack track in tracks)
            {
                if (track.getLength() > max) max = track.getLength();
            }
            return max;
        }



        #region Graphische Darstellungen
        private void drawTracks(){
            int y = 10;
            int scrollOffset = scrollbarCanvasX.Value * (int)font.Size;

            foreach (SequenceTrack track in tracks){
                drawTrack(track, y);
                y += font.Height * track.getTagRows() + 4*font.Height;
                if (showAntisenseStrandToolStripMenuItem.Checked) y += font.Height;
            }
        }



        private void drawTrack(SequenceTrack track, int y){
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
            if (x > canvasMain.Width) return;
            if (x + len < -4) return;
            int beginVisible = x;
            if (x < -4) beginVisible = -4;
            int endVisible = x + len;
            if (endVisible > canvasMain.Width) endVisible = canvasMain.Width + 4;
            int lengthVisible = endVisible - beginVisible;

            canvas.FillRectangle(brush, beginVisible, y, lengthVisible, font.Height);
            canvas.DrawRectangle(Pens.Black, beginVisible, y, lengthVisible, font.Height);
        }

        #endregion



        #region Event Management

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }



        private void OnAddTestSequence(object sender, EventArgs e)
        {
            this.tracks.Add(new SequenceTrack(new DNASequence(">Testsequenz\nACGT", src : "System Test")));
            refreshEditor();
            updateScrollbars();
        }



        private void OnOpenFasta(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Fasta File|*.fasta";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            List<DNASequence> readSeqs = FileHandler.readFasta(openFileDialog.FileName);
            this.tracks.Add(new SequenceTrack(readSeqs));
            refreshEditor();
            updateScrollbars();
        }



        private void OnDrawCanvas(object sender, PaintEventArgs e)
        {
            drawTracks();
        }



        private void OnClickCanvas(object sender, MouseEventArgs e)
        {
            Console.WriteLine("X: " + e.X + ", Y: " +e.Y);
        }

        private void OnResize(object sender, EventArgs e)
        {
            canvas.Dispose();
            canvas = canvasMain.CreateGraphics();
            refreshEditor();
            updateScrollbars();
        }

        private void OnScroll(object sender, EventArgs e)
        {
            //drawSequences();
            //refreshEditor();
        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            drawTracks();
            refreshEditor();
        }



        private void OnChangeViewOptions(object sender, EventArgs e) {
            refreshEditor();
        }

        #endregion
    }
}
