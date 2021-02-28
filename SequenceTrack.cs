using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DNATagger
{
    class SequenceTrack
    {
        private List<DNASequence> sequences = new List<DNASequence>();
        private String header = "Sequence Track";




        public SequenceTrack(List<DNASequence> seqs) {
            foreach(DNASequence seq in seqs){
                addSequence(seq);
            }
            this.header = seqs.ElementAt(0).getSource();
        }

        public SequenceTrack(DNASequence seq) {
            addSequence(seq);
            this.header = seq.getHeader();
        }



        public void addSequence(DNASequence seq){
            seq.setOffset(this.getLength());
            this.sequences.Add(seq);
        }



        public void setHeader(String to) {
            this.header = to;
        }



        public String getHeader() {
            return this.header;
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



        public int getTagRows(){
            int max = 0;
            foreach(DNASequence seq in sequences){
                if (seq.getTagRows() >= max) max = seq.getTagRows();
            }
            return max;
        }
    }
}
