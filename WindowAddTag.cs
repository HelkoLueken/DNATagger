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
        private DNASequence targetSequence;





        public WindowAddTag(DNASequence targetSequence, WindowMain.ControlCloser controlCloser) {
            InitializeComponent();
            selectedSequenceLabel.Text = "Add Tag to sequence: " + targetSequence;
            this.targetSequence = targetSequence;
            this.controlCloser = controlCloser;
            textBoxFrom.Text = targetSequence.selectedStart.ToString();
            textBoxTo.Text = targetSequence.selectedEnd.ToString();
        }



        private void OnConfirm(object sender, EventArgs e) {
            SequenceTag tag = new SequenceTag(nameTextBox.Text, int.Parse(textBoxFrom.Text), int.Parse(textBoxTo.Text), colorSelectionButton.BackColor);
            targetSequence.addTag(tag);
            Close();
        }



        private void OnClose(object sender, FormClosedEventArgs e) {
            Dispose();
            controlCloser();
        }



        private void OnSelectColor(object sender, EventArgs e) {
            colorDialog.ShowDialog();
            colorSelectionButton.BackColor = colorDialog.Color;
        }
    }
}
