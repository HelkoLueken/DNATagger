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
            startPosSelector.Maximum = targetSequence.getLengthTotal();
            endPosSelector.Maximum = targetSequence.getLengthTotal();
            startPosSelector.Value = targetSequence.selectedStart;
            endPosSelector.Value = targetSequence.selectedEnd;
        }



        private void OnConfirm(object sender, EventArgs e) {
            if (targetSequence != null && !targetSequence.IsDisposed) {
                SequenceTag tag = new SequenceTag(nameTextBox.Text, (int)startPosSelector.Value, (int)endPosSelector.Value, colorSelectionButton.BackColor);
                targetSequence.addTag(tag);
            }
            else MessageBox.Show("This Sequence no longer exists in editor!", "Sequence Not Found", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
