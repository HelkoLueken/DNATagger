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
    public partial class TextBar : UserControl {
        public TextBar(String t) {
            InitializeComponent();
            Text = t;
            Location = new Point(500, 50);
        }



        public string Text {
            get { return label1.Text; }
            set { this.label1.Text = value; }
        }








        private void TextBar_Load(object sender, EventArgs e) {
        }
    }
}
