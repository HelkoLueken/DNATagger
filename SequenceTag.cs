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
        public int startPos;
        public int endPos;
        public String notes;
        private Font standartFont;





        public SequenceTag(String header, int fromPos, int toPos, Color color) {
            InitializeComponent();
            standartFont = Font;
            this.header = header;
            this.BackColor = color;
            notes = "Notes to " + header;
            if (fromPos < 1) fromPos = 1;
            if (toPos < 1) toPos = 1;
            if (toPos >= fromPos){
                this.startPos = fromPos;
                this.endPos = toPos;
            }
            else{
                this.startPos = toPos;
                this.endPos = fromPos;
            }
        }



        public String header {
            get { return this.Name; }
            set {
                this.Name = value;
                headerLabel.Text = value;
            }
        }



        private WindowMain window {
            get {
                if (Parent == null || !(Parent.Parent.Parent.Parent.Parent is WindowMain)) return null;
                WindowMain window = (WindowMain)Parent.Parent.Parent.Parent.Parent;
                return window;
            }
        }



        public DNASequence sequence{ 
            get{
                if (Parent == null) return null;
                DNASequence seq = (DNASequence)Parent.Parent;
                return seq;
            }
        }



        public int getLength(){
            return endPos - startPos;
        }



        public override String ToString() {
            return this.header;
        }



        public void highlight(){
            Font = new Font(this.Font, FontStyle.Bold);
        }



        public void unhighlight(){ 
            Font = standartFont;
        }



        private void OnMouseDown(object sender, MouseEventArgs e) {
            sequence.setFirstMarker(e.X + Location.X);
            window.selectedTag = this;
        }



        private void OnMouseUp(object sender, MouseEventArgs e) {
            sequence.setSecondMarker(e.X + Location.X);
        }



        private void OnDraw(object sender, PaintEventArgs e) {
            if (window.selectedTag == this) highlight();
            else unhighlight();
        }
    }
}
