using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNATagger {
    public partial class WindowAddSequence : Form {

        private WindowMain prj;
        private WindowMain.ControlCloser controlCloser;





        public WindowAddSequence(WindowMain prj, WindowMain.ControlCloser controlCloser) {
            InitializeComponent();
            this.prj = prj;
            this.controlCloser = controlCloser;
        }



        private void readFastaTextBox(){
            StringBuilder fastaBlock = new StringBuilder();
            String[] lines = fastaTextBox.Text.Split('\n');
            for (int i = 0; i < lines.Length; i++) {
                if (lines[i].Length == 0) continue;
                if (lines[i].ToCharArray()[0] == '>') {
                    if (fastaBlock.Length > 0) {
                        DNASequence seqi = new DNASequence(fastaBlock.ToString());
                        seqi.notes = "Loaded from fasta text input by user";
                        prj.addSequence(seqi);
                        fastaBlock.Clear();
                    }
                    fastaBlock.Append(lines[i] + "\n");
                }
                else fastaBlock.Append(lines[i]);
            }
            DNASequence seq = new DNASequence(fastaBlock.ToString());
            seq.notes = "Loaded from fasta text input by user";
            prj.addSequence(seq);
            Close();
        }



        private void readFastaFile(){
            if (pathTextBox.Text != "" && pathTextBox.Text != "path") {
                List<DNASequence> readSeqs = FileHandler.readFasta(openFileDialog.FileName);
                foreach (DNASequence seq in readSeqs) {
                    prj.addSequence(seq);
                }
            }
            Close();
        }



        private void OnClose(object sender, FormClosingEventArgs e) {
            Dispose();
            controlCloser();
        }



        private void OnSelectFile(object sender, EventArgs e) {
            openFileDialog.Filter = "Fasta File|*.fasta|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            pathTextBox.Text = openFileDialog.FileName;
            if (fastaTextBox.Text == "") readFastaFile();
        }



        private void OnConfirm(object sender, EventArgs e) {
            if (fastaTextBox.Text != "") readFastaTextBox();
            else readFastaFile();
        }
    }
}
