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

        #region Datenverwaltung

        private char[] sense;
        private char[] antisense;
        private int offsetSense = 0;
        private int offsetAntisense = 0;
        public String notes;
        private WindowMain _window = new WindowMain();
        private List<SequenceTag> tags = new List<SequenceTag>();






        public DNASequence(String fastaSingle) {
            InitializeComponent();
            String[] lines = fastaSingle.Split('\n');
            if (lines.Length == 2) {
                header = lines[0];
                sense = lines[1].ToCharArray();
            }
            else {
                header = "Unnamed DNA Sequence";
                sense = fastaSingle.ToCharArray();
            }
        }



        public DNASequence(String header, String sequence){
            InitializeComponent();
            this.header = header;
            this.sense = sequence.ToCharArray();
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



        public String header {
            get { return this.Name; }
            set {
                this.Name = value;
                headerLabel.Text = value;
            }
        }



        public String sequence {
            get {
                StringBuilder o = new StringBuilder();
                foreach (char c in sense) o.Append(c.ToString());
                return o.ToString();
            }
        }



        public WindowMain window {
            get { return this._window; }
            set { this._window = value; }
        }



        public override String ToString() {
            return this.header;
        }



        public double screenBaseWidth() {
            return (double)sequencePanel.Width / (double)getLengthTotal();
        }



        public Int32 getBasePosAtScreenPos(int pos) {
            Int32 o = 1 + (int)(pos * screenBaseWidth());
            if (o > getLengthTotal() + 1) return getLengthTotal() + 1;
            if (o < 1) return 1;
            return o;
        }



        public int getScreenPosAtBasePos(int basePos){
            return (int)((basePos-1) * screenBaseWidth());
        }



        public int selectedStart => getBasePosAtScreenPos(markerPrim.Location.X - scrollContainer.AutoScrollPosition.X);



        public int selectedEnd {
            get { return getBasePosAtScreenPos(markerSek.Location.X - scrollContainer.AutoScrollPosition.X); }
        }



        public int getLengthTotal() {
            int up = this.sense.Length + this.offsetSense;
            if (antisense == null) return up;
            int lo = this.antisense.Length + this.offsetAntisense;
            if (up >= lo) return up;
            else return lo;
        }



        public List<SequenceTag> getTags() {
            return tags;
        }



        public void dropTag(SequenceTag tag) {
            tags.Remove(tag);
            scrollContainer.Controls.Remove(tag);
            tag.Dispose();
        }

        #endregion



        #region Grafische Darstellungen

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
            if (window == null || Parent == null) return;
            sequencePanel.Width = (int)(getLengthTotal() * window.zoom);
            foreach (SequenceTag tag in tags){
                tag.Location = new Point(getScreenPosAtBasePos(tag.startPos) + scrollContainer.AutoScrollPosition.X, tag.Location.Y);
                tag.Width = (int)(screenBaseWidth() * tag.getLength());
            }
            sequencePanel.Controls.Clear();
            for (int pos = 0; pos < sequencePanel.Width; pos += Width/3){
                Label lab = addPositionLabel(getBasePosAtScreenPos(pos));
            }
            foreach (SequenceTag tag in tags){
                Label startLab = addPositionLabel(tag.startPos);
                Label endLab = addPositionLabel(tag.endPos);
                foreach(Label labi in sequencePanel.Controls) {
                    if (labi.Bounds.IntersectsWith(startLab.Bounds) && labi != startLab || labi.Bounds.IntersectsWith(endLab.Bounds) && labi != endLab) sequencePanel.Controls.Remove(labi);
                }
            }
        }



        private Label addPositionLabel(int atBase) {
            Label lab = new Label();
            lab.Text = atBase.ToString();
            lab.Location = new Point(getScreenPosAtBasePos(atBase) - (int)(0.5*Font.Size), sequencePanel.Location.Y);
            lab.AutoSize = true;
            sequencePanel.Controls.Add(lab);
            return lab;
        }



        public void setFirstMarker(int xPos) {
            window.selectedSequence = this;
            markerSek.Visible = false;
            markerBetween.Visible = false;
            markerPrim.Location = new Point(xPos, 0);
        }



        public void setSecondMarker(int xPos) {
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



        public void addTag(SequenceTag tag) {
            tags.Add(tag);
            scrollContainer.Controls.Add(tag);
            adjustToZoom();
            tag.sequence = this;
            window.refreshTagSelector();
            foreach (SequenceTag tagi in tags) tagi.unhighlight(); //Eigentlich überflüssig aber beim ersten speichern in der Combobox wird ein Tag iwie als null hinterlegt, daher kann der letzte Tag anders nicht erreicht werden
            window.selectedTag = tag;
            window.inDepthView = getInDepthView();
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

        #region inDepthView
        /**<summary>Generiert einen String, der den Beginn der ausgewählten Basensequenz mit Beschriftungen ausgibt.</summary>
         */
        public String getInDepthView(){
            StringBuilder o = new StringBuilder();
            o.AppendLine(getPositionLine());
            o.AppendLine(getLetterLine());
            o.AppendLine(getTagBoundsLines());
            return o.ToString();
        }



        private String getPositionLine(){
            StringBuilder o = new StringBuilder();
            for (int i = selectedStart; o.Length < window.displayableLetters - (int)Math.Log10(i) && i < selectedEnd; i++) {
                if (i % 10 == 0) o.Append(i);
                if (i - selectedStart > o.Length) o.Append(" ");
            }
            return o.ToString();
        }



        private String getLetterLine(){
            StringBuilder o = new StringBuilder();
            for (int i = selectedStart; i < selectedStart + window.displayableLetters && i < selectedEnd; i++) {
                o.Append(sense[i-1].ToString());
            }
            return o.ToString();
        }



        private String getTagBoundsLines(){
            StringBuilder o = new StringBuilder();
            foreach (SequenceTag tag in tags) {
                if (tag.startPos >= selectedStart && tag.startPos <= selectedEnd && tag.startPos <= selectedStart + window.displayableLetters) {
                    for (int i = selectedStart; i < tag.startPos-1; i++) o.Append(" ");
                    o.Append("|");
                    if (tag.header.Length < window.displayableLetters - (tag.startPos - selectedStart) - 3) o.Append("-> " + tag.header);
                    o.AppendLine();
                }
                if (tag.endPos >= selectedStart && tag.endPos <= selectedEnd && tag.endPos <= selectedStart + window.displayableLetters) {
                    if (tag.header.Length < tag.endPos - selectedStart - 4) {
                        for (int i = selectedStart; i < tag.endPos - tag.header.Length - 4; i++) o.Append(" ");
                        o.Append(tag.header + " ->|");
                    }
                    else {
                        for (int i = selectedStart; i < tag.endPos; i++) o.Append(" ");
                        o.Append("|");
                    }
                    o.AppendLine();
                }
            }
            return o.ToString();
        }

        #endregion

        #endregion



        #region Eventhandling

        private void OnMouseDown(object sender, MouseEventArgs e){ 
            if (sender == this) setFirstMarker(e.X - scrollContainer.Location.X);
            else setFirstMarker(e.X);
        }



        private void OnMouseUp(object sender, MouseEventArgs e){
            if (sender == this) setSecondMarker(e.X - scrollContainer.Location.X);
            else setSecondMarker(e.X);
        }




        private void OnDraw(object sender, PaintEventArgs e) {
            Width = Parent.Width - 4;
        }



        private void OnClick(object sender, MouseEventArgs e) {
            window.selectedSequence = this;
            window.unselectTag();
        }

        #endregion
    }
}
