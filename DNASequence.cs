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
    public partial class DNASequence : UserControl {

        private static int letterWidth = 24; //Pixelbreite pro Basenlänge
        private char[] sense;
        private char[] antisense;
        private int offsetSense = 0;
        private int offsetAntisense = 0;
        private String _src;
        private SequenceTrack _track;
        private bool ShowLetters = true;
        //private List<SequenceTag> = new List<SequenceTag>();

        public SequenceTrack track{ 
            get{ return _track; }
            set{ _track = value; }
        }


        public String header {
            get { return this.Name; }
            set {
                this.Name = value;
                headerLabel.Text = value;
            }
        }

        public String src{ 
            get{ return _src; }
            set{ _src = value; }
        }

        public bool showLetters{ 
            get{ return ShowLetters; }
            set { ShowLetters = value; }
        }



        public DNASequence(String fasta, String src = "unknown") {
            InitializeComponent();
            String[] fastaParts = fasta.Split('\n');
            if (fastaParts.Length == 2) {
                header = fastaParts[0];
                sense = fastaParts[1].ToCharArray();
            }
            else {
                header = "Unnamed DNA Sequence";
                sense = fasta.ToCharArray();
            }
            this.src = src;
            createAntisense();
            Width = this.getLengthTotal() * letterWidth;
        }



        private void createAntisense() {
            this.antisense = new char[this.sense.Length];
            for (int i = 0; i < this.sense.Length; i++) {
                if (this.sense[i] == 'A') this.antisense[i] = 'T';
                if (this.sense[i] == 'C') this.antisense[i] = 'G';
                if (this.sense[i] == 'G') this.antisense[i] = 'C';
                if (this.sense[i] == 'T') this.antisense[i] = 'A';
                if (this.sense[i] == 'R') this.antisense[i] = 'Y';
                if (this.sense[i] == 'Y') this.antisense[i] = 'R';
                if (this.sense[i] == 'S') this.antisense[i] = 'S';
                if (this.sense[i] == 'W') this.antisense[i] = 'W';
                if (this.sense[i] == 'K') this.antisense[i] = 'M';
                if (this.sense[i] == 'M') this.antisense[i] = 'K';
                if (this.sense[i] == 'B') this.antisense[i] = 'V';
                if (this.sense[i] == 'V') this.antisense[i] = 'B';
                if (this.sense[i] == 'D') this.antisense[i] = 'H';
                if (this.sense[i] == 'H') this.antisense[i] = 'T';
                if (this.sense[i] == 'N') this.antisense[i] = 'N';
                if (this.antisense[i] == 0) this.antisense[i] = '?';
            }
        }



        public void adjustToZoom(int zoom){
            Width = letterWidth * getLengthSense() / zoom;
        }




        public char getBase(int pos) {
            if (pos <= 0 || pos > this.sense.Length) {
                Console.WriteLine("Error: Baseindex out of Bounds");
                return ' ';
            }
            return this.sense[pos - 1];
        }



        public char getBaseAntisense(int pos) {
            if (pos <= 0 || pos > this.sense.Length) {
                Console.WriteLine("Error: Baseindex out of Bounds");
                return ' ';
            }
            return this.antisense[pos - 1];
        }



        public override String ToString() {
            return this.header;
        }



        public int getLengthSense() {
            return this.sense.Length;
        }



        public int getLengthAntisense() {
            return this.antisense.Length;
        }



        public int getLengthTotal() {
            int up = this.sense.Length + this.offsetSense;
            int lo = this.antisense.Length + this.offsetAntisense;
            if (up >= lo) return up;
            else return lo;
        }

        private void OnClick(object sender, MouseEventArgs e) {
            SequenceTrack trk = (SequenceTrack)Parent.Parent;
            trk.select();
        }
    }
}

