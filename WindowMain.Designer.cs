
namespace DNATagger
{
    partial class WindowMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainWindowMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterDNASequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFastaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAntisenseStrandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNucleotideLettersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.groupBoxCanvas = new System.Windows.Forms.GroupBox();
            this.trackSelector = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tagSelector = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sequenceSelector = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mainWindowMenuStrip.SuspendLayout();
            this.groupBoxCanvas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainWindowMenuStrip
            // 
            this.mainWindowMenuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.mainWindowMenuStrip.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainWindowMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.mainWindowMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainWindowMenuStrip.Name = "mainWindowMenuStrip";
            this.mainWindowMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mainWindowMenuStrip.Size = new System.Drawing.Size(1475, 24);
            this.mainWindowMenuStrip.TabIndex = 0;
            this.mainWindowMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuBar;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterDNASequenceToolStripMenuItem,
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // enterDNASequenceToolStripMenuItem
            // 
            this.enterDNASequenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFastaFileToolStripMenuItem,
            this.asTextToolStripMenuItem,
            this.testToolStripMenuItem});
            this.enterDNASequenceToolStripMenuItem.Name = "enterDNASequenceToolStripMenuItem";
            this.enterDNASequenceToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.enterDNASequenceToolStripMenuItem.Text = "Enter DNA sequence...";
            // 
            // loadFastaFileToolStripMenuItem
            // 
            this.loadFastaFileToolStripMenuItem.Name = "loadFastaFileToolStripMenuItem";
            this.loadFastaFileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loadFastaFileToolStripMenuItem.Text = "From file";
            this.loadFastaFileToolStripMenuItem.Click += new System.EventHandler(this.OnOpenFasta);
            // 
            // asTextToolStripMenuItem
            // 
            this.asTextToolStripMenuItem.Name = "asTextToolStripMenuItem";
            this.asTextToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.asTextToolStripMenuItem.Text = "As text";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.OnAddTestSequence);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.newToolStripMenuItem.Text = "New Project";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.loadToolStripMenuItem.Text = "Load Project";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAntisenseStrandToolStripMenuItem,
            this.showNucleotideLettersToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showAntisenseStrandToolStripMenuItem
            // 
            this.showAntisenseStrandToolStripMenuItem.CheckOnClick = true;
            this.showAntisenseStrandToolStripMenuItem.Name = "showAntisenseStrandToolStripMenuItem";
            this.showAntisenseStrandToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.showAntisenseStrandToolStripMenuItem.Text = "Show Antisense Strand";
            this.showAntisenseStrandToolStripMenuItem.Click += new System.EventHandler(this.OnChangeViewOptions);
            // 
            // showNucleotideLettersToolStripMenuItem
            // 
            this.showNucleotideLettersToolStripMenuItem.Checked = true;
            this.showNucleotideLettersToolStripMenuItem.CheckOnClick = true;
            this.showNucleotideLettersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showNucleotideLettersToolStripMenuItem.Name = "showNucleotideLettersToolStripMenuItem";
            this.showNucleotideLettersToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.showNucleotideLettersToolStripMenuItem.Text = "Show Letters when zoomed in";
            this.showNucleotideLettersToolStripMenuItem.Click += new System.EventHandler(this.OnChangeViewOptions);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // canvasPanel
            // 
            this.canvasPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvasPanel.AutoScroll = true;
            this.canvasPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.canvasPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.canvasPanel.Location = new System.Drawing.Point(6, 22);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(1439, 483);
            this.canvasPanel.TabIndex = 1;
            this.canvasPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDrawCanvas);
            this.canvasPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClickCanvas);
            // 
            // groupBoxCanvas
            // 
            this.groupBoxCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCanvas.Controls.Add(this.canvasPanel);
            this.groupBoxCanvas.Location = new System.Drawing.Point(14, 203);
            this.groupBoxCanvas.Name = "groupBoxCanvas";
            this.groupBoxCanvas.Size = new System.Drawing.Size(1449, 508);
            this.groupBoxCanvas.TabIndex = 2;
            this.groupBoxCanvas.TabStop = false;
            this.groupBoxCanvas.Text = "Sequence Viewer";
            // 
            // trackSelector
            // 
            this.trackSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackSelector.FormattingEnabled = true;
            this.trackSelector.Location = new System.Drawing.Point(7, 27);
            this.trackSelector.Name = "trackSelector";
            this.trackSelector.Size = new System.Drawing.Size(339, 23);
            this.trackSelector.TabIndex = 4;
            this.trackSelector.SelectedIndexChanged += new System.EventHandler(this.OnChangeViewOptions);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tagSelector);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.sequenceSelector);
            this.groupBox1.Controls.Add(this.trackSelector);
            this.groupBox1.Location = new System.Drawing.Point(14, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 155);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // tagSelector
            // 
            this.tagSelector.AutoSize = true;
            this.tagSelector.Location = new System.Drawing.Point(9, 98);
            this.tagSelector.Name = "tagSelector";
            this.tagSelector.Size = new System.Drawing.Size(91, 15);
            this.tagSelector.TabIndex = 5;
            this.tagSelector.Text = "Selected Tag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selected Sequence";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected Track";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 117);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(339, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.OnChangeViewOptions);
            // 
            // sequenceSelector
            // 
            this.sequenceSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceSelector.FormattingEnabled = true;
            this.sequenceSelector.Location = new System.Drawing.Point(7, 70);
            this.sequenceSelector.Name = "sequenceSelector";
            this.sequenceSelector.Size = new System.Drawing.Size(339, 23);
            this.sequenceSelector.TabIndex = 4;
            this.sequenceSelector.SelectedIndexChanged += new System.EventHandler(this.OnChangeViewOptions);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(409, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Delete Track";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OnDeleteTrack);
            // 
            // WindowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1475, 723);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxCanvas);
            this.Controls.Add(this.mainWindowMenuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mainWindowMenuStrip;
            this.Name = "WindowMain";
            this.Text = "DNATagger";
            this.SizeChanged += new System.EventHandler(this.OnResize);
            this.mainWindowMenuStrip.ResumeLayout(false);
            this.mainWindowMenuStrip.PerformLayout();
            this.groupBoxCanvas.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainWindowMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterDNASequenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFastaFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.GroupBox groupBoxCanvas;
        private System.Windows.Forms.ToolStripMenuItem showAntisenseStrandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNucleotideLettersToolStripMenuItem;
        private System.Windows.Forms.ComboBox trackSelector;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox sequenceSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label tagSelector;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

