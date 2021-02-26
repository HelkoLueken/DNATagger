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
        List<DNASequence> sequences = new List<DNASequence>();
        Font font = new Font("Consolas", 14);
        Brush brush = Brushes.Black;





        public WindowMain()
        {
            InitializeComponent();
        }



        public void refreshEditor() {
            canvasMain.Invalidate();
        }



        public void updateScrollbars() {
            int maxBases = 0;
            foreach (DNASequence seq in sequences) {
                if (seq.getLength() > maxBases) maxBases = seq.getLength();
            }
            int newBound = maxBases - ((canvasMain.Width - 100) / (int)font.Size);
            if (newBound > 0) scrollbarCanvasX.Maximum = newBound;
        }



        #region Graphische Darstellungen
        private void drawSequences()
        {
            Graphics canvas = canvasMain.CreateGraphics();
            int X = 50;
            int Y = 100;
            int letterWidth = (int)font.Size;
            int offset = scrollbarCanvasX.Value * letterWidth;

            foreach (DNASequence seq in sequences)
            {
                canvas.DrawString(seq.getHeader() + " : ", font, brush, X, Y);
                Y += 20;
                canvas.FillRectangle(Brushes.LightBlue, X - letterWidth / 2 - offset, Y, (seq.getLength() + 1) * letterWidth, font.Height);
                canvas.DrawRectangle(Pens.Black, X - letterWidth / 2 - offset, Y, (seq.getLength() + 1) * letterWidth, font.Height);
                for (int i = 1; i <= seq.getLength(); i++)
                {
                    canvas.DrawString(seq.getBase(i).ToString(), font, brush, X + (i-1) * letterWidth - offset, Y);
                }
                Y += 40;
            }
        }
        #endregion



        #region Event Management

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }



        private void OnAddTestSequence(object sender, EventArgs e)
        {
            this.sequences.Add(new DNASequence(">Testsequenz\nACGT"));
            refreshEditor();
            updateScrollbars();
        }



        private void OnOpenFasta(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Fasta File|*.fasta";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            List<DNASequence> readSeqs = FileHandler.readFasta(openFileDialog.FileName);
            sequences.AddRange(readSeqs);
            refreshEditor();
            updateScrollbars();
        }



        private void OnDrawCanvas(object sender, PaintEventArgs e)
        {
            drawSequences();
        }
        #endregion



        private void OnClickCanvas(object sender, MouseEventArgs e)
        {
            Console.WriteLine("X: " + e.X + ", Y: " +e.Y);
        }

        private void OnResize(object sender, EventArgs e)
        {
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
            drawSequences();
            refreshEditor();
        }
    }
}
