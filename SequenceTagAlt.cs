using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DNATagger {
    class SequenceTagAlt {
        public String label = "Undefinied Region";
        private int start = 0;
        private int end = 0;
        public Bar bar;




        public SequenceTagAlt(String label, int start, int end, Brush color){
            this.label = label;
            this.start = start;
            this.end = end;
            this.bar = new Bar (color);
        }



        public int getStart(){ 
            return this.start;
        }



        public int getEnd(){
            return this.end;
        }
    }
}
