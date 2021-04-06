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
        private List<SequenceTag> tags = new List<SequenceTag>();






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



        public void adjustToZoom() {
            sequencePanel.Width = (int)(getLengthTotal() * window.zoom);
            foreach (SequenceTag tag in tags){
                tag.Location = new Point((int)(window.zoom * tag.startPos), tag.Location.Y);
                tag.Width = (int)(window.zoom * tag.getLength());
            }
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
            set { this._window = value; adjustToZoom(); }
        }

        public override String ToString() {
            return this.header;
        }
        public int selectedStart =>  markerPrim.Location.X / (int)window.zoom;

        public int selectedEnd{ 
            get { return markerSek.Location.X / (int)window.zoom; }
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
            window.selectedSequence = this;
        }



        public void addTag(SequenceTag tag) {
            tags.Add(tag);
            scrollContainer.Controls.Add(tag);
            tag.Location = new Point((int)window.zoom * tag.startPos, tagLabel.Location.Y - scrollContainer.Location.Y);
            tag.Width = tag.getLength() * (int) window.zoom;
            tag.sequence = this;
            bool positionFine = false;
            while(!positionFine){
                positionFine = true;
                foreach (SequenceTag tagi in tags) {
                    if (tag != tagi && tag.Bounds.IntersectsWith(tagi.Bounds)) {
                        tag.Location = new Point(tag.Location.X, tag.Location.Y + tag.Height);
                        if (tag.Location.Y + tag.Height > scrollContainer.Height){
                            scrollContainer.Height += tag.Height;
                            Height += tag.Height;
                        }
                        positionFine = false;
                    }
                }
            }
        }




        public void setFirstMarker(int xPos){
            window.selectedSequence = this;
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

        private void OnMouseUpOverBG(object sender, MouseEventArgs e) {
            setSecondMarker(e.X - scrollContainer.Location.X);
        }

        private void OnMouseDownOverBG(object sender, MouseEventArgs e) {
            setFirstMarker(e.X - scrollContainer.Location.X);
        }

        private void OnMouseDownOverBarContainer(object sender, MouseEventArgs e) {
            setFirstMarker(e.X);
        }

        private void OnMouseUpOverScrollContainer(object sender, MouseEventArgs e) {
            setSecondMarker(e.X);
        }

        private void OnMouseDownOverSequencePanel(object sender, MouseEventArgs e) {
            setFirstMarker(e.X);
        }

        private void OnMouseUpOverSequencePanel(object sender, MouseEventArgs e) {
            setSecondMarker(e.X);
        }
    }
}
