﻿using System;
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
        private int screenTop = 0;
        private int screenHeight = 0;




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
            seq.setTrack(this);
            this.sequences.Add(seq);
        }



        public void setScreenPosition(int y, int height){
            this.screenTop = y;
            this.screenHeight = height;
        }


        /**Returns true if the given y coordinate is over this track on the editor screen
         * 
         */
        public bool isOnTrack(int y){
            if (y < this.screenTop || y > this.screenTop + this.screenHeight) return false;
            return true;
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



        public int getScreenHeight(){
            return this.screenHeight;
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



        public override String ToString(){
            return this.header;
        }
    }
}