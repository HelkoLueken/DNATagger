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
    public partial class SequenceTrack : UserControl {

        private List<DNASequence> sequences = new List<DNASequence>();
        private String header{ 
            get{ return this.headerLabel.Text; }
            set{ this.headerLabel.Text = value; }
        }




        public SequenceTrack(List<DNASequence> seqs) {
            InitializeComponent();
            foreach (DNASequence seq in seqs) {
                addSequence(seq);
            }
            this.header = seqs.ElementAt(0).src;
        }

        public SequenceTrack(DNASequence seq) {
            InitializeComponent();
            addSequence(seq);
            this.header = seq.header;
        }



        public void addSequence(DNASequence seq) {
            seq.track = this;
            seq.Location = new Point(getEndPosition(), 0);
            this.sequences.Add(seq);
            this.barContainer.Controls.Add(seq);
        }



        public int getEndPosition(){
            int pos = 0;
            foreach (DNASequence seq in sequences) pos += seq.Width;
            return pos;
        }



        public DNASequence getSequence(int i) {
            return this.sequences.ElementAt(i);
        }



        public List<DNASequence> getSequences() {
            return this.sequences;
        }



        public int getLength() {
            int len = 0;
            foreach (DNASequence seq in sequences) {
                len += seq.getLengthTotal();
            }
            return len;
        }



        public override String ToString() {
            return this.header;
        }

        private void OnDraw(object sender, PaintEventArgs e) {
            Width = Parent.Width;
            barContainer.Width = Width;
        }
    }
}
