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



        #region Graphische Darstellungen
        private void drawSequences(Graphics canvas)
        {
            int atSequence = 0;
            int X = 50;
            int Y = 100;
            foreach (DNASequence seq in sequences)
            {
                canvas.DrawString(seq.getHeader() + " : ", font, brush, X, Y + atSequence*20);
                canvas.DrawString(seq.getSequence(), font, brush, X + 10 + (int)canvas.MeasureString(seq.getHeader() + " : \t", font).Width, Y + atSequence * 20);
                atSequence++;
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
        }



        private void OnOpenFasta(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Fasta File|*.fasta";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            List<DNASequence> readSeqs = FileHandler.readFasta(openFileDialog.FileName);
            sequences.AddRange(readSeqs);
            refreshEditor();
        }



        private void OnScroll(object sender, ScrollEventArgs e)
        {
            canvasMain.Invalidate();
        }


        private void OnDrawCanvas(object sender, PaintEventArgs e)
        {
            drawSequences(e.Graphics);
        }
        #endregion
    }
}
