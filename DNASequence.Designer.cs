
namespace DNATagger {
    partial class DNASequence {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.headerLabel = new System.Windows.Forms.Label();
            this.scrollContainer = new System.Windows.Forms.Panel();
            this.markerPrim = new System.Windows.Forms.Panel();
            this.markerBetween = new System.Windows.Forms.Panel();
            this.markerSek = new System.Windows.Forms.Panel();
            this.sequencePanel = new System.Windows.Forms.Panel();
            this.sequenceLabel = new System.Windows.Forms.Label();
            this.tagLabel = new System.Windows.Forms.Label();
            this.scrollContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.Color.Blue;
            this.headerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.headerLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.White;
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(72, 24);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Header";
            this.headerLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            // 
            // scrollContainer
            // 
            this.scrollContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollContainer.AutoScroll = true;
            this.scrollContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scrollContainer.Controls.Add(this.markerPrim);
            this.scrollContainer.Controls.Add(this.markerBetween);
            this.scrollContainer.Controls.Add(this.markerSek);
            this.scrollContainer.Controls.Add(this.sequencePanel);
            this.scrollContainer.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollContainer.Location = new System.Drawing.Point(92, 24);
            this.scrollContainer.Margin = new System.Windows.Forms.Padding(0);
            this.scrollContainer.Name = "scrollContainer";
            this.scrollContainer.Padding = new System.Windows.Forms.Padding(1);
            this.scrollContainer.Size = new System.Drawing.Size(990, 65);
            this.scrollContainer.TabIndex = 2;
            this.scrollContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.scrollContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // markerPrim
            // 
            this.markerPrim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.markerPrim.BackColor = System.Drawing.Color.Red;
            this.markerPrim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.markerPrim.Location = new System.Drawing.Point(100, 1);
            this.markerPrim.Margin = new System.Windows.Forms.Padding(0);
            this.markerPrim.Name = "markerPrim";
            this.markerPrim.Size = new System.Drawing.Size(6, 65);
            this.markerPrim.TabIndex = 0;
            this.markerPrim.Visible = false;
            // 
            // markerBetween
            // 
            this.markerBetween.BackColor = System.Drawing.Color.Red;
            this.markerBetween.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.markerBetween.Location = new System.Drawing.Point(100, 1);
            this.markerBetween.Margin = new System.Windows.Forms.Padding(0);
            this.markerBetween.Name = "markerBetween";
            this.markerBetween.Size = new System.Drawing.Size(20, 3);
            this.markerBetween.TabIndex = 0;
            this.markerBetween.Visible = false;
            // 
            // markerSek
            // 
            this.markerSek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.markerSek.BackColor = System.Drawing.Color.Red;
            this.markerSek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.markerSek.Location = new System.Drawing.Point(120, 1);
            this.markerSek.Margin = new System.Windows.Forms.Padding(0);
            this.markerSek.Name = "markerSek";
            this.markerSek.Size = new System.Drawing.Size(6, 65);
            this.markerSek.TabIndex = 0;
            this.markerSek.Visible = false;
            // 
            // sequencePanel
            // 
            this.sequencePanel.BackColor = System.Drawing.Color.Gold;
            this.sequencePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sequencePanel.Location = new System.Drawing.Point(1, 1);
            this.sequencePanel.Margin = new System.Windows.Forms.Padding(0);
            this.sequencePanel.MinimumSize = new System.Drawing.Size(4, 4);
            this.sequencePanel.Name = "sequencePanel";
            this.sequencePanel.Size = new System.Drawing.Size(240, 22);
            this.sequencePanel.TabIndex = 0;
            this.sequencePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClickSequencePanel);
            this.sequencePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.sequencePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // sequenceLabel
            // 
            this.sequenceLabel.AutoSize = true;
            this.sequenceLabel.BackColor = System.Drawing.Color.LightBlue;
            this.sequenceLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sequenceLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequenceLabel.ForeColor = System.Drawing.Color.Black;
            this.sequenceLabel.Location = new System.Drawing.Point(0, 24);
            this.sequenceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.sequenceLabel.Name = "sequenceLabel";
            this.sequenceLabel.Size = new System.Drawing.Size(92, 24);
            this.sequenceLabel.TabIndex = 0;
            this.sequenceLabel.Text = "Sequence";
            this.sequenceLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            // 
            // tagLabel
            // 
            this.tagLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tagLabel.BackColor = System.Drawing.Color.LightBlue;
            this.tagLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tagLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagLabel.ForeColor = System.Drawing.Color.Black;
            this.tagLabel.Location = new System.Drawing.Point(0, 48);
            this.tagLabel.Margin = new System.Windows.Forms.Padding(0);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(92, 43);
            this.tagLabel.TabIndex = 0;
            this.tagLabel.Text = "Tags";
            this.tagLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            // 
            // DNASequence
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.scrollContainer);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.sequenceLabel);
            this.Controls.Add(this.headerLabel);
            this.Location = new System.Drawing.Point(0, 20);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DNASequence";
            this.Size = new System.Drawing.Size(1080, 91);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDraw);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.scrollContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel scrollContainer;
        private System.Windows.Forms.Label sequenceLabel;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.Panel markerSek;
        private System.Windows.Forms.Panel markerPrim;
        private System.Windows.Forms.Panel markerBetween;
        private System.Windows.Forms.Panel sequencePanel;
    }
}
