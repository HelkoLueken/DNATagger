﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNATagger {
    public partial class ALT_SequenceTag : UserControl {
        private DNASequence _track;
        private int startPos;
        private int endPos;

        public DNASequence track {
            get { return _track; }
            set { _track = value; }
        }

        public String header {
            get { return this.Name; }
            set {
                this.Name = value;
                headerLabel.Text = value;
            }
        }



        public int startPosition{ 
            get{ return startPos; }
        }





        public ALT_SequenceTag(String header, int fromPos, int toPos, Color color) {
            InitializeComponent();
            this.header = header;
            this.startPos = fromPos;
            this.endPos = toPos;
            this.BackColor = color;
        }



        public int getLength(){
            return endPos - startPos;
        }



        public override String ToString() {
            return this.header;
        }



        private void OnClick(object sender, MouseEventArgs e) {
        }



        private void OnMouseDown(object sender, MouseEventArgs e) {
            track.setFirstMarker(e.X + Location.X);
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            track.setSecondMarker(e.X + Location.X);
        }
    }
}
