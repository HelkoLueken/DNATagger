
namespace DNATagger {
    partial class SequenceTrack {
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
            this.barContainer = new System.Windows.Forms.Panel();
            this.markerBetween = new System.Windows.Forms.Panel();
            this.markerSek = new System.Windows.Forms.Panel();
            this.markerPrim = new System.Windows.Forms.Panel();
            this.sequenceLabel = new System.Windows.Forms.Label();
            this.tagLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.barContainer.SuspendLayout();
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
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(72, 24);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Header";
            this.headerLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            // 
            // barContainer
            // 
            this.barContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barContainer.AutoScroll = true;
            this.barContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.barContainer.Controls.Add(this.markerBetween);
            this.barContainer.Controls.Add(this.markerSek);
            this.barContainer.Controls.Add(this.markerPrim);
            this.barContainer.Location = new System.Drawing.Point(92, 48);
            this.barContainer.Margin = new System.Windows.Forms.Padding(0);
            this.barContainer.Name = "barContainer";
            this.barContainer.Size = new System.Drawing.Size(990, 66);
            this.barContainer.TabIndex = 2;
            this.barContainer.SizeChanged += new System.EventHandler(this.OnChangeBarContainerSize);
            this.barContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.barContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // markerBetween
            // 
            this.markerBetween.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.markerBetween.BackColor = System.Drawing.Color.Gold;
            this.markerBetween.Location = new System.Drawing.Point(9, 0);
            this.markerBetween.Margin = new System.Windows.Forms.Padding(0);
            this.markerBetween.Name = "markerBetween";
            this.markerBetween.Size = new System.Drawing.Size(40, 2);
            this.markerBetween.TabIndex = 0;
            this.markerBetween.Visible = false;
            // 
            // markerSek
            // 
            this.markerSek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.markerSek.BackColor = System.Drawing.Color.Gold;
            this.markerSek.Location = new System.Drawing.Point(55, 0);
            this.markerSek.Margin = new System.Windows.Forms.Padding(0);
            this.markerSek.Name = "markerSek";
            this.markerSek.Size = new System.Drawing.Size(6, 68);
            this.markerSek.TabIndex = 0;
            this.markerSek.Visible = false;
            // 
            // markerPrim
            // 
            this.markerPrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.markerPrim.BackColor = System.Drawing.Color.Gold;
            this.markerPrim.Location = new System.Drawing.Point(3, 0);
            this.markerPrim.Margin = new System.Windows.Forms.Padding(0);
            this.markerPrim.Name = "markerPrim";
            this.markerPrim.Size = new System.Drawing.Size(6, 66);
            this.markerPrim.TabIndex = 0;
            this.markerPrim.Visible = false;
            // 
            // sequenceLabel
            // 
            this.sequenceLabel.AutoSize = true;
            this.sequenceLabel.BackColor = System.Drawing.Color.LightBlue;
            this.sequenceLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sequenceLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequenceLabel.ForeColor = System.Drawing.Color.Black;
            this.sequenceLabel.Location = new System.Drawing.Point(0, 48);
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
            this.tagLabel.Location = new System.Drawing.Point(0, 72);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(92, 44);
            this.tagLabel.TabIndex = 0;
            this.tagLabel.Text = "Tags";
            this.tagLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.BackColor = System.Drawing.Color.LightBlue;
            this.positionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.positionLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel.ForeColor = System.Drawing.Color.Black;
            this.positionLabel.Location = new System.Drawing.Point(0, 24);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(92, 24);
            this.positionLabel.TabIndex = 0;
            this.positionLabel.Text = "Position";
            this.positionLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            // 
            // SequenceTrack
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.barContainer);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.sequenceLabel);
            this.Controls.Add(this.headerLabel);
            this.Location = new System.Drawing.Point(0, 20);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SequenceTrack";
            this.Size = new System.Drawing.Size(1080, 114);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDraw);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.barContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel barContainer;
        private System.Windows.Forms.Label sequenceLabel;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Panel markerSek;
        private System.Windows.Forms.Panel markerPrim;
        private System.Windows.Forms.Panel markerBetween;
    }
}
