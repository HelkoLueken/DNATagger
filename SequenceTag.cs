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
    public partial class SequenceTag : UserControl {
        private DNASequence _seq;
        public int startPos;
        public int endPos;

        public DNASequence sequence {
            get { return _seq; }
            set { _seq = value; }
        }

        public String header {
            get { return this.Name; }
            set {
                this.Name = value;
                headerLabel.Text = value;
            }
        }



        public SequenceTag(String header, int fromPos, int toPos, Color color) {
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
            sequence.setFirstMarker(e.X + Location.X);
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            sequence.setSecondMarker(e.X + Location.X);
        }
    }
}
