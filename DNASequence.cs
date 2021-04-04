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

        private char[] sense;
        private char[] antisense;
        private int offsetSense = 0;
        private int offsetAntisense = 0;
        private String _src;
        private WindowMain _window = new WindowMain();
        





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
            sequencePanel.Width = getLengthTotal();
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



        public void highlight() {
            BackColor = Color.LightGray;
            headerLabel.BackColor = Color.Yellow;
            headerLabel.ForeColor = Color.Black;
            markerPrim.Visible = true;
            markerSek.Visible = true;
            markerBetween.Visible = true;
        }



        public void unhighlight(){
            BackColor = Color.DimGray;
            headerLabel.BackColor = Color.Blue;
            headerLabel.ForeColor = Color.White;
            markerPrim.Visible = false;
            markerSek.Visible = false;
            markerBetween.Visible = false;
        }



        public String header {
            get { return this.Name; }
            set {
                this.Name = value;
                headerLabel.Text = value;
            }
        }

        public String src {
            get { return _src; }
            set { _src = value; }
        }

        public WindowMain window {
            get { return this._window; }
            set { this._window = value; }
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



        private void OnDraw(object sender, PaintEventArgs e) {
            Width = Parent.Width - 4;
        }



        private void OnClick(object sender, MouseEventArgs e) {
            window.selectSequence(this);
        }








        #region ALT

        private List<ALT_SequenceTag> tags = new List<ALT_SequenceTag>();

       






        /*public void addSequence(ALT_DNASequence seq) {
            seq.track = this;
            this.sequences.Add(seq);
            this.scrollContainer.Controls.Add(seq);
            adjustToZoom();
            arrangeBars();
        }*/



        public void addTag(String header, int fromPos, int toPos, Color color) {
            ALT_SequenceTag tag = new ALT_SequenceTag(header, fromPos, toPos, color);
            tags.Add(tag);
            scrollContainer.Controls.Add(tag);
            tag.Location = new Point((int)Font.Size * tag.startPosition, tagLabel.Location.Y - scrollContainer.Location.Y);
            tag.Width = tag.getLength() * (int) Font.Size;
            tag.track = this;
            adjustToZoom();
            arrangeBars();
        }



        public void adjustToZoom(){
            /*foreach (ALT_DNASequence seq in sequences) seq.Width = (int)Font.Size * seq.getLengthTotal() / window.zoom;
            foreach (ALT_SequenceTag tag in tags) tag.Width = (int)Font.Size * tag.getLength() / window.zoom;
            arrangeBars();*/
        }




        public void arrangeBars(){
            /*int lastEnd = 0;
            foreach (ALT_DNASequence seq in sequences) {
                seq.Location = new Point(lastEnd, 0);
                lastEnd = seq.Location.X + seq.Width - scrollContainer.AutoScrollOffset.X;
            } */
        }




        



        




        public void setFirstMarker(int xPos){
            window.selectSequence(this);
            markerSek.Visible = false;
            markerBetween.Visible = false;
            markerPrim.Location = new Point(xPos, 0);
        }



        public void setSecondMarker(int xPos){
            if (BackColor == Color.DimGray) return; //Wenn nicht auch auf diesem Track die Maus runtergedrücktwurde, dieser Track also ausgewählt ist
            if (xPos > markerPrim.Location.X) markerSek.Location = new Point(xPos, 0);
            else {
                markerSek.Location = new Point(markerPrim.Location.X, 0);
                markerPrim.Location = new Point(xPos, 0);
            }
            markerBetween.Location = new Point(markerPrim.Location.X, 0);
            markerBetween.Width = markerSek.Location.X - markerPrim.Location.X;
            markerSek.Visible = true;
            markerBetween.Visible = true;
            Invalidate();
        }



        private int getMarkerStartBase(){ 
            int startBase = 0;



            return startBase;
        }



        private void OnChangeBarContainerSize(object sender, EventArgs e) {
            arrangeBars();
        }

        private void OnMouseUpOverBG(object sender, MouseEventArgs e) {
            setSecondMarker(e.X - scrollContainer.Location.X);
        }

        private void OnMouseDownOverBG(object sender, MouseEventArgs e) {
            setFirstMarker(e.X - scrollContainer.Location.X);
        }

        private void OnMouseDownOverBarContainer(object sender, MouseEventArgs e) {
            setFirstMarker(e.X);
        }

        private void OnMouseUpOverBarContainer(object sender, MouseEventArgs e) {
            setSecondMarker(e.X);
        }

        private void SequencePanel_Paint(object sender, PaintEventArgs e) {

        }

        #endregion
    }
}
