using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DNATagger {
    class SequenceTag {
        public String label = "Undefinied Region";
        private int start = 0;
        private int end = 0;
        public Brush color;




        public SequenceTag(String label, int start, int end, Brush color){
            this.label = label;
            this.start = start;
            this.end = end;
            this.color = color;
        }



        public int getStart(){ 
            return this.start;
        }



        public int getEnd(){
            return this.end;
        }
    }
}
