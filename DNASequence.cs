using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DNATagger
{
    class DNASequence
    {
        private String header;
        private String src;
        private char[] sense;
        private char[] antisense;
        public Bar senseBar = new Bar(Brushes.Beige);
        public Bar antisenseBar = new Bar(Brushes.Beige);
        private int offSetSense = 0;
        private int offSetAntiSense = 0;
        private int offsetTrack = 0;
        private List<SequenceTag> tags = new List<SequenceTag>();
        private SequenceTrack track;

        //Zum Ausmustern
        private int screenTop;
        private int screenBottom;
        private int screenStart;
        private int screenEnd;
        public Brush color = Brushes.Beige;






        public DNASequence(String fasta, String src = "unknown") {
            String[] fastaParts = fasta.Split('\n');
            if (fastaParts.Length == 2)
            {
                this.header = fastaParts[0];
                this.sense = fastaParts[1].ToCharArray();
            }
            else
            {
                this.header = "Unnamed DNA Sequence";
                this.sense = fasta.ToCharArray();
            }
            this.src = src;
            this.createAntisense();
        }



        private void createAntisense() {
            this.antisense = new char[this.sense.Length];
            for (int i = 0; i < this.sense.Length; i++)
            {
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



        public void addTag(String label, int start, int end, Brush color) {
            this.tags.Add(new SequenceTag(label, start, end, color));
        }



        public void draw(System.Windows.Forms.Panel canvas, Font font, bool showLetters) {
            senseBar.draw(canvas);
            antisenseBar.draw(canvas);
            foreach (SequenceTag tag in tags) tag.bar.draw(canvas);
        }


        public void setScreenPosition(int start, int top, int end, int bottom){
            this.screenStart = start;
            this.screenTop = top;
            this.screenEnd = end;
            this.screenBottom = bottom;
        }



        public void setTrack(SequenceTrack track){
            this.track = track;
        }



        public SequenceTrack getTrack() {
            return this.track;
        }



        public bool isOnSequence(int x , int y){
            if (x < this.screenStart || x > this.screenEnd || y < this.screenTop || y > this.screenBottom) return false;
            return true;
        }



        public void setOffsetTrack(int to){
            this.offsetTrack = to;
        }



        public String getSource() {
            return this.src;
        }



        public String getHeader() {
            return this.header;
        }



        public char getBase(int pos) {
            if (pos <= 0 || pos > this.sense.Length) {
                Console.WriteLine("Error: Baseindex out of Bounds");
                return ' ';
            }
            return this.sense[pos - 1];
        }



        public char getBaseAntisense(int pos) {
            if (pos <= 0 || pos > this.sense.Length)
            {
                Console.WriteLine("Error: Baseindex out of Bounds");
                return ' ';
            }
            return this.antisense[pos - 1];
        }



        public int getLengthSense() {
            return this.sense.Length;
        }



        public int getLengthAntisense() {
            return this.antisense.Length;
        }



        public int getLengthTotal() {
            int up = this.sense.Length + this.offSetSense;
            int lo = this.antisense.Length + this.offSetAntiSense;
            if (up >= lo) return up;
            else return lo;
        }



        public int getOffSetSense() {
            return this.offSetSense;
        }



        public int getOffSetAntisense() {
            return this.offSetAntiSense;
        }



        public int getOffsetTrack(){
            return this.offsetTrack;
        }



        public int getTagRows(){ // Hier muss noch erweitert werden für Tags!!!!
            int h = 0;

            return h;
        }



        public static Boolean isValidDNASequence(String seq) {
            return true;
        }



        public override String ToString() {
            return this.header;
        }
    }
}
