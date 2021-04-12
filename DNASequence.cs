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
        public String notes;
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
            notes = "Loaded from: " + src;
            createAntisense();
        }



        public DNASequence(String header, String sequence, String src){
            InitializeComponent();
            this.header = header;
            this.sense = sequence.ToCharArray();
            this.src = src;
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
            foreach (SequenceTag tag in tags) tag.unhighlight();
        }



        public void adjustToZoom() {
            sequencePanel.Width = (int)(getLengthTotal() * window.zoom);
            foreach (SequenceTag tag in tags){
                tag.Location = new Point((int)(screenBaseWidth() * tag.startPos + scrollContainer.AutoScrollPosition.X), tag.Location.Y);
                tag.Width = (int)(screenBaseWidth() * tag.getLength());
            }
            sequencePanel.Controls.Clear();
            int interval = Width/3;
            for (int pos = 0; pos < sequencePanel.Width; pos += interval){
                Label lab = new Label();
                lab.AutoSize = true;
                lab.Location = new Point(pos, sequencePanel.Location.Y);
                lab.Text = getBasePosAtScreenPos(pos).ToString();
                sequencePanel.Controls.Add(lab);
            }
            foreach (SequenceTag tag in tags){
                Label startLab = new Label();
                startLab.Location = new Point((int)(screenBaseWidth() * tag.startPos), sequencePanel.Location.Y);
                startLab.Text = tag.startPos.ToString();
                startLab.AutoSize = true;
                Label endLab = new Label();
                endLab.Location = new Point((int)(screenBaseWidth() * tag.endPos), sequencePanel.Location.Y);
                endLab.Text = tag.endPos.ToString();
                endLab.AutoSize = true;
                foreach(Label labi in sequencePanel.Controls) {
                    if (labi.Bounds.IntersectsWith(startLab.Bounds) || labi.Bounds.IntersectsWith(endLab.Bounds)) sequencePanel.Controls.Remove(labi);
                }
                sequencePanel.Controls.Add(startLab);
                sequencePanel.Controls.Add(endLab);
            }
        }



        public double screenBaseWidth(){
            return (double)sequencePanel.Width / (double)getLengthTotal();
        }



        public Int32 getBasePosAtScreenPos(int pos){
            if (pos <= 0) return 0;
            Int32 o = (pos * getLengthTotal() / sequencePanel.Width);
            if (o > getLengthTotal()) return getLengthTotal();
            return o;
        }



        public String header {
            get { return this.Name; }
            set {
                this.Name = value;
                headerLabel.Text = value;
            }
        }



        public String sequence{ 
            get{
                StringBuilder o = new StringBuilder();
                foreach (char c in sense) o.Append(c.ToString());
                return o.ToString();
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


        public int selectedStart =>  getBasePosAtScreenPos(markerPrim.Location.X - scrollContainer.AutoScrollPosition.X);

        public int selectedEnd{ 
            get { return getBasePosAtScreenPos(markerSek.Location.X - scrollContainer.AutoScrollPosition.X); }
        }



        public int getLengthSense() {
            return this.sense.Length;
        }



        public int getLengthAntisense() {
            return this.antisense.Length;
        }



        public int getLengthTotal() {
            int up = this.sense.Length + this.offsetSense;
            if (antisense == null) return up;
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
            adjustToZoom();
            tag.sequence = this;
            window.refreshTagSelector();
            foreach (SequenceTag tagi in tags) tagi.unhighlight(); //Eigentlich überflüssig aber beim ersten speichern in der Combobox wird ein Tag iwie als null hinterlegt, daher kann der letzte Tag anders nicht erreicht werden
            window.selectedTag = tag;
            initializeTagPosition(tag);
        }



        /**<summary>Berechnet die Screenposition für den neu hinzugefügten Tag.
         * Die Y-Koordinate wird hiernach nicht merh verändert</summary>
         */
        private void initializeTagPosition(SequenceTag tag){
            bool positionFine = false;
            tag.Location = new Point(tag.Location.X, tagLabel.Location.Y - scrollContainer.Location.Y);
            while (!positionFine) {
                positionFine = true;
                foreach (SequenceTag tagi in tags) {
                    if (tag != tagi && tag.Bounds.IntersectsWith(tagi.Bounds)) {
                        tag.Location = new Point(tag.Location.X, tag.Location.Y + tag.Height);
                        if (tag.Location.Y + tag.Height > scrollContainer.Height) {
                            scrollContainer.Height += tag.Height;
                            Height += tag.Height;
                        }
                        positionFine = false;
                    }
                }
            }
        }



        /**<summary>Generiert einen String, der den Beginn der ausgewählten Basensequenz mit Beschriftungen ausgibt.</summary>
         */
        public String getInDepthView(){
            StringBuilder o = new StringBuilder();

            for (int i = selectedStart; o.Length < window.displayableLetters - (int)Math.Log10(i) && i < selectedEnd; i++){
                if ((selectedStart - i)%10 == 0 ) o.Append(i);
                if (i - selectedStart > o.Length) o.Append(" ");
            }
            o.AppendLine();
            for (int i = selectedStart; i < selectedStart + window.displayableLetters && i < selectedEnd; i++){
                o.Append(sense[i].ToString());
            }

            return o.ToString();
        }



        public List<SequenceTag> getTags(){
            return tags;
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
            window.inDepthView = getInDepthView();
            Invalidate();
        }



        private void OnMouseDown(object sender, MouseEventArgs e){ 
            if (sender == this) setFirstMarker(e.X - scrollContainer.Location.X);
            else setFirstMarker(e.X);
        }



        private void OnMouseUp(object sender, MouseEventArgs e){
            if (sender == this) setSecondMarker(e.X - scrollContainer.Location.X);
            else setSecondMarker(e.X);
        }

        private void OnClickSequencePanel(object sender, MouseEventArgs e) {
            window.unselectTag();
        }
    }
}
