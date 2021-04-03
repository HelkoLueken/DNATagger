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



        public DNASequence(){ 
            
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





        #region ALT

        private List<ALT_DNASequence> sequences = new List<ALT_DNASequence>();
        private List<ALT_SequenceTag> tags = new List<ALT_SequenceTag>();
        private String header{ 
            get{ return this.headerLabel.Text; }
            set{ this.headerLabel.Text = value; }
        }

        private WindowMain Window = new WindowMain();
        public WindowMain window{ 
            get{ return this.Window; }
            set{ this.Window = value; }
        }




        public DNASequence(List<ALT_DNASequence> seqs) {
            InitializeComponent();
            foreach (ALT_DNASequence seq in seqs) {
                addSequence(seq);
            }
            this.header = seqs.ElementAt(0).src;
        }

        public DNASequence(ALT_DNASequence seq) {
            InitializeComponent();
            addSequence(seq);
            this.header = seq.header;
        }



        public void addSequence(ALT_DNASequence seq) {
            seq.track = this;
            this.sequences.Add(seq);
            this.scrollContainer.Controls.Add(seq);
            adjustToZoom();
            arrangeBars();
        }



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
            foreach (ALT_DNASequence seq in sequences) seq.Width = (int)Font.Size * seq.getLengthTotal() / window.zoom;
            foreach (ALT_SequenceTag tag in tags) tag.Width = (int)Font.Size * tag.getLength() / window.zoom;
            arrangeBars();
        }




        public void arrangeBars(){
            int lastEnd = 0;
            foreach (ALT_DNASequence seq in sequences) {
                seq.Location = new Point(lastEnd, 0);
                lastEnd = seq.Location.X + seq.Width - scrollContainer.AutoScrollOffset.X;
            }
        }




        public int getEndPosition(){
            int pos = 0;
            foreach (ALT_DNASequence seq in sequences) pos += seq.Width;
            return pos;
        }



        public ALT_DNASequence getSequence(int i) {
            return this.sequences.ElementAt(i);
        }



        public List<ALT_DNASequence> getSequences() {
            return this.sequences;
        }



        public int getLength() {
            int len = 0;
            foreach (ALT_DNASequence seq in sequences) {
                len += seq.getLengthTotal();
            }
            return len;
        }



        public override String ToString() {
            return header;
        }



        private void OnDraw(object sender, PaintEventArgs e) {
            Width = Parent.Width - 4;
        }



        private void OnClick(object sender, MouseEventArgs e) {
            select();
        }



        public void select(){
            window.select(this);
            foreach (DNASequence track in Parent.Controls) {
                track.BackColor = Color.DimGray;
                track.headerLabel.BackColor = Color.Blue;
                track.headerLabel.ForeColor = Color.White;
                track.markerPrim.Visible = false;
                track.markerSek.Visible = false;
                track.markerBetween.Visible = false;
            }
            this.BackColor = Color.LightGray;
            headerLabel.BackColor = Color.Yellow;
            headerLabel.ForeColor = Color.Black;
            markerPrim.Visible = true;
            markerSek.Visible = true;
            markerBetween.Visible = true;
        }




        public void setFirstMarker(int xPos){
            select();
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
