using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DNATagger
{
    public partial class WindowMain : Form
    {
        #region Datenverwaltung

        List<DNASequence> sequences = new List<DNASequence>();
        WindowAddTag tagAddingDialogue;


        public delegate void ControlCloser();
        public void OnCloseMyControl() {
            if (tagAddingDialogue != null)
                tagAddingDialogue.Dispose();
            tagAddingDialogue = null;
        }

        public double zoom {
            get { return Math.Pow(2, zoomRegler.Value); }
        }
        public WindowMain()
        {
            InitializeComponent();
        }



        public DNASequence selectedSequence{ 
            get { DNASequence seq = (DNASequence)sequenceSelector.SelectedItem; return seq; }
            set { sequenceSelector.SelectedItem = value; }
        }



        public int maxTrackLength() {
            /*
            int max = 0;
            foreach (DNASequence track in tracks)
            {
                if (track.getLength() > max) max = track.getLength();
            }
            return max;
            */
            return 0;
        }



        private void addSequence(DNASequence seq){
            seq.window = this;
            sequences.Add(seq);
            panelEditor.Controls.Add(seq);
            sequenceSelector.Items.Add(seq);
            arrangeSequences();
        }



        private void dropSequence(DNASequence seq) {
            this.sequenceSelector.Items.Remove(seq);
            sequences.Remove(seq);
            panelEditor.Controls.Remove(seq);
            arrangeSequences();
            refreshEditor();
        }

        #endregion



        #region Graphische Darstellungen

        public void refreshEditor() {
            arrangeSequences();
            panelEditor.Invalidate();
            foreach (Control ctrl in panelEditor.Controls) ctrl.Invalidate();
        }



        public void arrangeSequences(){
            int y = 0;
            foreach (DNASequence seq in sequences){
                seq.Location = new Point(0, y);
                y += seq.Height + seq.Font.Height * 2;
            }
        }

        #endregion



        #region Event Management

        private void OnAddTestSequence(object sender, EventArgs e)
        {  
            addSequence(new DNASequence(">Testsequenz\nACGT", src : "System Test"));
            refreshEditor(); 
        }



        private void OnOpenFasta(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Fasta File|*.fasta|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            List<DNASequence> readSeqs = FileHandler.readFasta(openFileDialog.FileName);
            foreach (DNASequence seq in readSeqs){
                addSequence(seq);
            }
            refreshEditor();
        }



        private void OnClickCanvas(object sender, MouseEventArgs e)
        {
            Console.WriteLine("X: " + e.X + ", Y: " +e.Y);
            refreshEditor();
        }



        private void OnResize(object sender, EventArgs e)
        {
            refreshEditor();
        }



        private void OnChangeViewOptions(object sender, EventArgs e) {
            refreshEditor();
        }



        private void OnChangeZoom(object sender, EventArgs e) {
            foreach (DNASequence seq in sequences) seq.adjustToZoom();
            refreshEditor();
            Console.WriteLine(zoomRegler.Value);
        }


        private void OnAddTag(object sender, EventArgs e) {
            if (sequenceSelector.SelectedItem == null) return;
            if (selectedSequence == null) return;
            if (tagAddingDialogue == null) tagAddingDialogue = new WindowAddTag(selectedSequence, new ControlCloser(OnCloseMyControl));
            tagAddingDialogue.Show();
            tagAddingDialogue.Focus();
            //selectedSequence.addTag("TestTag", 0, 100, Color.Green);
        }
        #endregion

        #region tutorial
        /*
        private void OnMyPrivatDialogNonModal(object sender, EventArgs e) {
            if (_dlgNonModalDlg == null)
                _dlgNonModalDlg = new DlgMeinDialog(_cbCloseMyControl, _cbGetInfoPkg);  // Zahlenwert= Adresse auf die Funktion

            DlgMeinDialog.ResultDataPkg resPkg = new DlgMeinDialog.ResultDataPkg();

            FeedControlPkg(ref resPkg);
            _dlgNonModalDlg.SetControl(resPkg); // Der existierende Dialog wird nun vorbereitet eingestellt.

            _dlgNonModalDlg.Show();
        }

        public void OnCloseMyControl() {
            if (_dlgNonModalDlg != null)
                _dlgNonModalDlg.Dispose();
            _dlgNonModalDlg = null;
        }
        protected void UpdateNonModalDialog() {
            if (_dlgNonModalDlg == null)
                return;
            DlgMeinDialog.ResultDataPkg resPkg = new DlgMeinDialog.ResultDataPkg();

            FeedControlPkg(ref resPkg);
            _dlgNonModalDlg.SetControl(resPkg);
            _dlgNonModalDlg.Sychronize();
        }*/
        #endregion

        private void OnChangeSelectedSequence(object sender, EventArgs e) {
            foreach (DNASequence seqi in sequences) seqi.unhighlight();
            DNASequence seq = (DNASequence)sequenceSelector.SelectedItem;
            seq.highlight();
            refreshEditor();
        }
    }
}
