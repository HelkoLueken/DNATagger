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
        private List<SequenceTag> tags = new List<SequenceTag>();
        private static String allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_ ?";






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
            if (!hasValidSequence()) this.Dispose();
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



        public static bool isValidSequence(String letters){ 
            foreach (char c in letters){
                if (!allowedChars.Contains(c.ToString())) return false;
            }
            return true;
        }



        public bool hasValidSequence(){
            foreach (char c in sense) {
                if (!allowedChars.Contains(c.ToString())) return false;
            }
            return true;
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



        private WindowMain window {
            get {
                if (Parent == null || !(Parent.Parent.Parent is WindowMain)) return null;
                WindowMain window = (WindowMain)Parent.Parent.Parent;
                return window; 
            
            }
        }



        public override String ToString() {
            return this.header;
        }



        public double getScreenBaseWidth() {
            return (double)sequencePanel.Width / (double)getLengthTotal();
        }



        public Int32 getBasePosAtScreenPos(int pos) {
            Int32 o = 1 + (int)(pos / getScreenBaseWidth());
            if (o > getLengthTotal()) return getLengthTotal();
            if (o < 1) return 1;
            return o;
        }



        public int getScreenPosAtBasePos(int basePos){
            return 1 + (int)((basePos-1) * getScreenBaseWidth());
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
                tag.Width = (int)(getScreenBaseWidth() * tag.getLength());
            }
            setPositionLabels();
        }



        private void setPositionLabels(){
            sequencePanel.Controls.Clear();
            int labelInterval = (int)(500 / getScreenBaseWidth());
            for (int i = 1; i < getLengthTotal(); i += labelInterval) {
                addPositionLabel(i);
            }
            foreach (SequenceTag tag in tags) {
                addPositionLabel(tag.startPos);
                addPositionLabel(tag.endPos);
            }
        }



        private void addPositionLabel(int atBase) {
            Label lab = new Label();
            lab.Text = atBase.ToString();
            lab.Location = new Point(getScreenPosAtBasePos(atBase) - (int)(0.5*Font.Size), sequencePanel.Location.Y);
            lab.AutoSize = true;
            lab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            lab.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            sequencePanel.Controls.Add(lab);
            foreach (Label labi in sequencePanel.Controls) if (labi.Bounds.IntersectsWith(lab.Bounds) && labi != lab) sequencePanel.Controls.Remove(labi);
            lab.Invalidate();
        }



        public void setFirstMarker(int xPos) {
            window.selectedSequence = this;
            markerPrim.Location = new Point(xPos, 0);
            markerSek.Location = markerPrim.Location;
            markerBetween.Location = markerPrim.Location;
            markerBetween.Width = 2;

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
            window.addTag(tag);
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
            if (sender == scrollContainer) setFirstMarker(e.X);
            if (sender == sequencePanel) setFirstMarker(e.X + scrollContainer.AutoScrollPosition.X);
            if (sender is Label){
                Label lab = (Label)sender;
                setFirstMarker(e.X + lab.Location.X + scrollContainer.AutoScrollPosition.X);
            }
        }



        private void OnMouseUp(object sender, MouseEventArgs e){
            if (sender == this) setSecondMarker(e.X - scrollContainer.Location.X);
            if (sender == scrollContainer) setSecondMarker(e.X);
            if (sender == sequencePanel) setSecondMarker(e.X + scrollContainer.AutoScrollPosition.X);
            if (sender is Label) {
                Label lab = (Label)sender;
                setSecondMarker(e.X + lab.Location.X + scrollContainer.AutoScrollPosition.X);
            }
        }




        private void OnDraw(object sender, PaintEventArgs e) {
            Width = Parent.Width - 4;
            if (window.selectedSequence == this) highlight();
            else unhighlight();
        }



        private void OnClick(object sender, MouseEventArgs e) {
            window.selectedSequence = this;
            window.selectedTag = null;
        }

        #endregion
    }
}
