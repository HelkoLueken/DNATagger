
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
            this.sequenceLabel = new System.Windows.Forms.Label();
            this.tagLabel = new System.Windows.Forms.Label();
            this.trackMarker = new DNATagger.TrackMarker();
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
            this.barContainer.Controls.Add(this.trackMarker);
            this.barContainer.Location = new System.Drawing.Point(92, 24);
            this.barContainer.Name = "barContainer";
            this.barContainer.Size = new System.Drawing.Size(985, 66);
            this.barContainer.TabIndex = 2;
            this.barContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.barContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // sequenceLabel
            // 
            this.sequenceLabel.AutoSize = true;
            this.sequenceLabel.BackColor = System.Drawing.Color.LightBlue;
            this.sequenceLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sequenceLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequenceLabel.ForeColor = System.Drawing.Color.Black;
            this.sequenceLabel.Location = new System.Drawing.Point(0, 24);
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
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(92, 40);
            this.tagLabel.TabIndex = 0;
            this.tagLabel.Text = "Tags";
            this.tagLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            // 
            // trackMarker
            // 
            this.trackMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.trackMarker.BackColor = System.Drawing.Color.Transparent;
            this.trackMarker.Location = new System.Drawing.Point(0, 3);
            this.trackMarker.Name = "trackMarker";
            this.trackMarker.Size = new System.Drawing.Size(102, 61);
            this.trackMarker.TabIndex = 0;
            this.trackMarker.Visible = false;
            // 
            // SequenceTrack
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.barContainer);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.sequenceLabel);
            this.Controls.Add(this.headerLabel);
            this.Location = new System.Drawing.Point(0, 20);
            this.Name = "SequenceTrack";
            this.Size = new System.Drawing.Size(1080, 92);
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
        private TrackMarker trackMarker;
    }
}
