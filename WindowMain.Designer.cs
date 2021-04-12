
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
            this.showInDepthMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelEditor = new System.Windows.Forms.Panel();
            this.groupBoxCanvas = new System.Windows.Forms.GroupBox();
            this.groupBoxTools = new System.Windows.Forms.GroupBox();
            this.notizBox = new System.Windows.Forms.RichTextBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxZoom = new System.Windows.Forms.GroupBox();
            this.labelPlus = new System.Windows.Forms.Label();
            this.labelMinus = new System.Windows.Forms.Label();
            this.zoomRegler = new System.Windows.Forms.TrackBar();
            this.notizBoxLabel = new System.Windows.Forms.Label();
            this.tagSelectorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tagSelector = new System.Windows.Forms.ComboBox();
            this.sequenceSelector = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxLetterViewer = new System.Windows.Forms.GroupBox();
            this.LetterViewBox = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.groupBoxPosLabels = new System.Windows.Forms.GroupBox();
            this.mainWindowMenuStrip.SuspendLayout();
            this.groupBoxCanvas.SuspendLayout();
            this.groupBoxTools.SuspendLayout();
            this.groupBoxZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomRegler)).BeginInit();
            this.groupBoxLetterViewer.SuspendLayout();
            this.groupBoxPosLabels.SuspendLayout();
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
            this.loadFastaFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadFastaFileToolStripMenuItem.Text = "From file";
            this.loadFastaFileToolStripMenuItem.Click += new System.EventHandler(this.OnOpenFasta);
            // 
            // asTextToolStripMenuItem
            // 
            this.asTextToolStripMenuItem.Name = "asTextToolStripMenuItem";
            this.asTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asTextToolStripMenuItem.Text = "As text";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.OnAddTestSequence);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.newToolStripMenuItem.Text = "New Project";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.OnNewProject);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.loadToolStripMenuItem.Text = "Load Project";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.OnLoadProject);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.OnSave);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.OnSaveAs);
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
            this.showInDepthMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showInDepthMenuItem
            // 
            this.showInDepthMenuItem.Checked = true;
            this.showInDepthMenuItem.CheckOnClick = true;
            this.showInDepthMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showInDepthMenuItem.Name = "showInDepthMenuItem";
            this.showInDepthMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showInDepthMenuItem.Text = "In depth letter view";
            this.showInDepthMenuItem.CheckStateChanged += new System.EventHandler(this.OnChangeLetterViewerVisibility);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // panelEditor
            // 
            this.panelEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEditor.AutoScroll = true;
            this.panelEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelEditor.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEditor.Location = new System.Drawing.Point(6, 22);
            this.panelEditor.Margin = new System.Windows.Forms.Padding(0);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(1441, 381);
            this.panelEditor.TabIndex = 1;
            this.panelEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClickEditorBG);
            // 
            // groupBoxCanvas
            // 
            this.groupBoxCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCanvas.Controls.Add(this.panelEditor);
            this.groupBoxCanvas.Location = new System.Drawing.Point(12, 190);
            this.groupBoxCanvas.Name = "groupBoxCanvas";
            this.groupBoxCanvas.Size = new System.Drawing.Size(1451, 406);
            this.groupBoxCanvas.TabIndex = 2;
            this.groupBoxCanvas.TabStop = false;
            this.groupBoxCanvas.Text = "Editor";
            // 
            // groupBoxTools
            // 
            this.groupBoxTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTools.Controls.Add(this.groupBoxPosLabels);
            this.groupBoxTools.Controls.Add(this.notizBox);
            this.groupBoxTools.Controls.Add(this.buttonAddTag);
            this.groupBoxTools.Controls.Add(this.button1);
            this.groupBoxTools.Controls.Add(this.groupBoxZoom);
            this.groupBoxTools.Controls.Add(this.notizBoxLabel);
            this.groupBoxTools.Controls.Add(this.tagSelectorLabel);
            this.groupBoxTools.Controls.Add(this.label2);
            this.groupBoxTools.Controls.Add(this.tagSelector);
            this.groupBoxTools.Controls.Add(this.sequenceSelector);
            this.groupBoxTools.Location = new System.Drawing.Point(12, 27);
            this.groupBoxTools.Name = "groupBoxTools";
            this.groupBoxTools.Size = new System.Drawing.Size(1451, 157);
            this.groupBoxTools.TabIndex = 5;
            this.groupBoxTools.TabStop = false;
            // 
            // notizBox
            // 
            this.notizBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notizBox.Location = new System.Drawing.Point(507, 27);
            this.notizBox.Name = "notizBox";
            this.notizBox.Size = new System.Drawing.Size(944, 130);
            this.notizBox.TabIndex = 12;
            this.notizBox.Text = "Notes...";
            this.notizBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.OnClickLink);
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddTag.Location = new System.Drawing.Point(261, 53);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(97, 27);
            this.buttonAddTag.TabIndex = 6;
            this.buttonAddTag.Text = "Add";
            this.buttonAddTag.UseVisualStyleBackColor = false;
            this.buttonAddTag.Click += new System.EventHandler(this.OnAddTag);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(149, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Delete Track";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // groupBoxZoom
            // 
            this.groupBoxZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxZoom.Controls.Add(this.labelPlus);
            this.groupBoxZoom.Controls.Add(this.labelMinus);
            this.groupBoxZoom.Controls.Add(this.zoomRegler);
            this.groupBoxZoom.Location = new System.Drawing.Point(8, 86);
            this.groupBoxZoom.Name = "groupBoxZoom";
            this.groupBoxZoom.Size = new System.Drawing.Size(325, 71);
            this.groupBoxZoom.TabIndex = 8;
            this.groupBoxZoom.TabStop = false;
            this.groupBoxZoom.Text = "Zoom";
            // 
            // labelPlus
            // 
            this.labelPlus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlus.AutoSize = true;
            this.labelPlus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPlus.Location = new System.Drawing.Point(303, 27);
            this.labelPlus.Name = "labelPlus";
            this.labelPlus.Size = new System.Drawing.Size(16, 17);
            this.labelPlus.TabIndex = 8;
            this.labelPlus.Text = "+";
            // 
            // labelMinus
            // 
            this.labelMinus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMinus.AutoSize = true;
            this.labelMinus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMinus.Location = new System.Drawing.Point(6, 27);
            this.labelMinus.Name = "labelMinus";
            this.labelMinus.Size = new System.Drawing.Size(16, 17);
            this.labelMinus.TabIndex = 8;
            this.labelMinus.Text = "-";
            // 
            // zoomRegler
            // 
            this.zoomRegler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomRegler.Location = new System.Drawing.Point(28, 20);
            this.zoomRegler.Maximum = 5;
            this.zoomRegler.Minimum = -5;
            this.zoomRegler.Name = "zoomRegler";
            this.zoomRegler.Size = new System.Drawing.Size(269, 45);
            this.zoomRegler.TabIndex = 7;
            this.zoomRegler.ValueChanged += new System.EventHandler(this.OnChangeZoom);
            // 
            // notizBoxLabel
            // 
            this.notizBoxLabel.AutoSize = true;
            this.notizBoxLabel.Location = new System.Drawing.Point(507, 9);
            this.notizBoxLabel.Name = "notizBoxLabel";
            this.notizBoxLabel.Size = new System.Drawing.Size(84, 15);
            this.notizBoxLabel.TabIndex = 5;
            this.notizBoxLabel.Text = "Annotations";
            // 
            // tagSelectorLabel
            // 
            this.tagSelectorLabel.AutoSize = true;
            this.tagSelectorLabel.Location = new System.Drawing.Point(258, 9);
            this.tagSelectorLabel.Name = "tagSelectorLabel";
            this.tagSelectorLabel.Size = new System.Drawing.Size(91, 15);
            this.tagSelectorLabel.TabIndex = 5;
            this.tagSelectorLabel.Text = "Selected Tag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selected Sequence";
            // 
            // tagSelector
            // 
            this.tagSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tagSelector.Location = new System.Drawing.Point(261, 27);
            this.tagSelector.Name = "tagSelector";
            this.tagSelector.Size = new System.Drawing.Size(240, 23);
            this.tagSelector.TabIndex = 4;
            this.tagSelector.SelectedIndexChanged += new System.EventHandler(this.OnChangeSelectedTag);
            // 
            // sequenceSelector
            // 
            this.sequenceSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sequenceSelector.DropDownWidth = 440;
            this.sequenceSelector.Location = new System.Drawing.Point(6, 27);
            this.sequenceSelector.Name = "sequenceSelector";
            this.sequenceSelector.Size = new System.Drawing.Size(240, 23);
            this.sequenceSelector.TabIndex = 4;
            this.sequenceSelector.SelectedIndexChanged += new System.EventHandler(this.OnChangeSelectedSequence);
            // 
            // groupBoxLetterViewer
            // 
            this.groupBoxLetterViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLetterViewer.AutoSize = true;
            this.groupBoxLetterViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxLetterViewer.Controls.Add(this.LetterViewBox);
            this.groupBoxLetterViewer.Location = new System.Drawing.Point(12, 605);
            this.groupBoxLetterViewer.Name = "groupBoxLetterViewer";
            this.groupBoxLetterViewer.Size = new System.Drawing.Size(1448, 106);
            this.groupBoxLetterViewer.TabIndex = 11;
            this.groupBoxLetterViewer.TabStop = false;
            this.groupBoxLetterViewer.Text = "In Depth Viewer";
            // 
            // LetterViewBox
            // 
            this.LetterViewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LetterViewBox.Location = new System.Drawing.Point(6, 22);
            this.LetterViewBox.Multiline = true;
            this.LetterViewBox.Name = "LetterViewBox";
            this.LetterViewBox.Size = new System.Drawing.Size(1436, 78);
            this.LetterViewBox.TabIndex = 11;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(6, 19);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(56, 15);
            this.lengthLabel.TabIndex = 13;
            this.lengthLabel.Text = "Length:";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(6, 35);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(49, 15);
            this.startLabel.TabIndex = 13;
            this.startLabel.Text = "Start:";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(6, 50);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(35, 15);
            this.endLabel.TabIndex = 13;
            this.endLabel.Text = "End:";
            // 
            // groupBoxPosLabels
            // 
            this.groupBoxPosLabels.Controls.Add(this.lengthLabel);
            this.groupBoxPosLabels.Controls.Add(this.endLabel);
            this.groupBoxPosLabels.Controls.Add(this.startLabel);
            this.groupBoxPosLabels.Location = new System.Drawing.Point(339, 86);
            this.groupBoxPosLabels.Name = "groupBoxPosLabels";
            this.groupBoxPosLabels.Size = new System.Drawing.Size(162, 71);
            this.groupBoxPosLabels.TabIndex = 14;
            this.groupBoxPosLabels.TabStop = false;
            // 
            // WindowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1475, 723);
            this.Controls.Add(this.groupBoxLetterViewer);
            this.Controls.Add(this.groupBoxTools);
            this.Controls.Add(this.groupBoxCanvas);
            this.Controls.Add(this.mainWindowMenuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mainWindowMenuStrip;
            this.Name = "WindowMain";
            this.Text = "DNATagger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.SizeChanged += new System.EventHandler(this.OnResize);
            this.mainWindowMenuStrip.ResumeLayout(false);
            this.mainWindowMenuStrip.PerformLayout();
            this.groupBoxCanvas.ResumeLayout(false);
            this.groupBoxTools.ResumeLayout(false);
            this.groupBoxTools.PerformLayout();
            this.groupBoxZoom.ResumeLayout(false);
            this.groupBoxZoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomRegler)).EndInit();
            this.groupBoxLetterViewer.ResumeLayout(false);
            this.groupBoxLetterViewer.PerformLayout();
            this.groupBoxPosLabels.ResumeLayout(false);
            this.groupBoxPosLabels.PerformLayout();
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
        private System.Windows.Forms.Panel panelEditor;
        private System.Windows.Forms.GroupBox groupBoxCanvas;
        private System.Windows.Forms.GroupBox groupBoxTools;
        private System.Windows.Forms.ComboBox sequenceSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label tagSelectorLabel;
        private System.Windows.Forms.ComboBox tagSelector;
        private System.Windows.Forms.TrackBar zoomRegler;
        private System.Windows.Forms.GroupBox groupBoxZoom;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Label labelPlus;
        private System.Windows.Forms.Label labelMinus;
        private System.Windows.Forms.RichTextBox notizBox;
        private System.Windows.Forms.Label notizBoxLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox groupBoxLetterViewer;
        private System.Windows.Forms.ToolStripMenuItem showInDepthMenuItem;
        private System.Windows.Forms.TextBox LetterViewBox;
        private System.Windows.Forms.GroupBox groupBoxPosLabels;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label startLabel;
    }
}

