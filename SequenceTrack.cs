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
    public partial class SequenceTrack : UserControl {

        private List<DNASequence> sequences = new List<DNASequence>();
        private List<SequenceTag> tags = new List<SequenceTag>();
        private String header{ 
            get{ return this.headerLabel.Text; }
            set{ this.headerLabel.Text = value; }
        }

        private WindowMain Window = new WindowMain();
        public WindowMain window{ 
            get{ return this.Window; }
            set{ this.Window = value; }
        }




        public SequenceTrack(List<DNASequence> seqs) {
            InitializeComponent();
            foreach (DNASequence seq in seqs) {
                addSequence(seq);
            }
            this.header = seqs.ElementAt(0).src;
        }

        public SequenceTrack(DNASequence seq) {
            InitializeComponent();
            addSequence(seq);
            this.header = seq.header;
        }



        public void addSequence(DNASequence seq) {
            seq.track = this;
            this.sequences.Add(seq);
            this.barContainer.Controls.Add(seq);
            adjustToZoom();
            arrangeBars();
        }



        public void addTag(String header, int fromPos, int toPos, Color color) {
            SequenceTag tag = new SequenceTag(header, fromPos, toPos, color);
            tags.Add(tag);
            barContainer.Controls.Add(tag);
            tag.Location = new Point((int)Font.Size * tag.startPosition, tagLabel.Location.Y - barContainer.Location.Y);
            tag.Width = tag.getLength() * (int) Font.Size;
            tag.track = this;
            adjustToZoom();
            arrangeBars();
        }



        public void adjustToZoom(){
            foreach (DNASequence seq in sequences) seq.Width = (int)Font.Size * seq.getLengthTotal() / window.zoom;
            foreach (SequenceTag tag in tags) tag.Width = (int)Font.Size * tag.getLength() / window.zoom;
            arrangeBars();
        }




        public void arrangeBars(){
            int lastEnd = 0;
            foreach (DNASequence seq in sequences) {
                seq.Location = new Point(lastEnd, 0);
                lastEnd = seq.Location.X + seq.Width - barContainer.AutoScrollOffset.X;
            }
        }




        public int getEndPosition(){
            int pos = 0;
            foreach (DNASequence seq in sequences) pos += seq.Width;
            return pos;
        }



        public DNASequence getSequence(int i) {
            return this.sequences.ElementAt(i);
        }



        public List<DNASequence> getSequences() {
            return this.sequences;
        }



        public int getLength() {
            int len = 0;
            foreach (DNASequence seq in sequences) {
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
            foreach (SequenceTrack track in Parent.Controls) {
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



        private void OnChangeBarContainerSize(object sender, EventArgs e) {
            arrangeBars();
        }

        private void OnMouseUpOverBG(object sender, MouseEventArgs e) {
            setSecondMarker(e.X - barContainer.Location.X);
        }

        private void OnMouseDownOverBG(object sender, MouseEventArgs e) {
            setFirstMarker(e.X - barContainer.Location.X);
        }

        private void OnMouseDownOverBarContainer(object sender, MouseEventArgs e) {
            setFirstMarker(e.X);
        }

        private void OnMouseUpOverBarContainer(object sender, MouseEventArgs e) {
            setSecondMarker(e.X);
        }
    }
}
