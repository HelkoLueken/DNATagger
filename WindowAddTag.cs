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
    public partial class WindowAddTag : Form {

        private WindowMain.ControlCloser controlCloser;
        private DNASequence onto;

        public WindowAddTag(DNASequence onto, WindowMain.ControlCloser controlCloser) {
            InitializeComponent();
            selectedSequenceLabel.Text = "Add Tag to sequence: " + onto;
            this.onto = onto;
            this.controlCloser = controlCloser;
            textBoxFrom.Text = onto.selectedStart.ToString();
            textBoxTo.Text = onto.selectedEnd.ToString();
        }

        private void confirmTagButton_Click(object sender, EventArgs e) {
            SequenceTag tag = new SequenceTag(nameTextBox.Text, int.Parse(textBoxFrom.Text), int.Parse(textBoxTo.Text), colorSelectionButton.BackColor);
            onto.addTag(tag);
            Close();
        }

        private void OnClose(object sender, FormClosedEventArgs e) {
            Dispose();
            controlCloser();
        }

        private void colorSelectionButton_Click(object sender, EventArgs e) {
            colorDialog.ShowDialog();
            colorSelectionButton.BackColor = colorDialog.Color;
        }
    }
}
