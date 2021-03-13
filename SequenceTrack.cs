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
        private String header{ 
            get{ return this.headerLabel.Text; }
            set{ this.headerLabel.Text = value; }
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
            seq.Location = new Point(getEndPosition(), 0);
            this.sequences.Add(seq);
            this.barContainer.Controls.Add(seq);
        }



        public void adjustToZoom(int zoom){
            int lastEnd = 0;
            foreach (DNASequence seq in sequences){
                seq.adjustToZoom(zoom);
                seq.Location = new Point(lastEnd, 0);
                lastEnd = seq.Location.X + seq.Width;
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
            Width = Parent.Width-4;
        }

        private void OnClick(object sender, MouseEventArgs e) {
            select();
        }



        public void select(){
            WindowMain wdw = (WindowMain)Parent.Parent.Parent;
            wdw.select(this);
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

        private void OnMouseDown(object sender, MouseEventArgs e) {
            select();
            markerSek.Visible = false;
            markerBetween.Visible = false;
            markerPrim.Location = new Point(e.X,0);
        }



        private void OnMouseUp(object sender, MouseEventArgs e) {
            if (BackColor == Color.DimGray) return; //Wenn nicht auch auf diesem Track die Maus runtergedrücktwurde, dieser Track also ausgewählt ist
            if (e.X > markerPrim.Location.X) markerSek.Location = new Point(e.X, 0);
            else{
                markerSek.Location = new Point(markerPrim.Location.X, 0);
                markerPrim.Location = new Point(e.X, 0);
            }
            markerBetween.Location = new Point(markerPrim.Location.X, 0);
            markerBetween.Width = markerSek.Location.X - markerPrim.Location.X;
            markerSek.Visible = true;
            markerBetween.Visible = true;
            Invalidate();
        }
    }
}
