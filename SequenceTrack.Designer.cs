
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
            this.antisenseLabel = new System.Windows.Forms.Label();
            this.barContainer = new System.Windows.Forms.Panel();
            this.senseLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            // 
            // antisenseLabel
            // 
            this.antisenseLabel.AutoSize = true;
            this.antisenseLabel.BackColor = System.Drawing.Color.LightBlue;
            this.antisenseLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.antisenseLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antisenseLabel.ForeColor = System.Drawing.Color.White;
            this.antisenseLabel.Location = new System.Drawing.Point(0, 48);
            this.antisenseLabel.Name = "antisenseLabel";
            this.antisenseLabel.Size = new System.Drawing.Size(102, 24);
            this.antisenseLabel.TabIndex = 0;
            this.antisenseLabel.Text = "Antisense";
            // 
            // barContainer
            // 
            this.barContainer.AutoScroll = true;
            this.barContainer.Location = new System.Drawing.Point(102, 24);
            this.barContainer.Name = "barContainer";
            this.barContainer.Size = new System.Drawing.Size(600, 73);
            this.barContainer.TabIndex = 2;
            // 
            // senseLabel
            // 
            this.senseLabel.BackColor = System.Drawing.Color.LightBlue;
            this.senseLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.senseLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senseLabel.ForeColor = System.Drawing.Color.White;
            this.senseLabel.Location = new System.Drawing.Point(0, 24);
            this.senseLabel.Name = "senseLabel";
            this.senseLabel.Size = new System.Drawing.Size(102, 24);
            this.senseLabel.TabIndex = 0;
            this.senseLabel.Text = "Sense";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gold;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tags";
            // 
            // SequenceTrack
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.barContainer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.senseLabel);
            this.Controls.Add(this.antisenseLabel);
            this.Controls.Add(this.headerLabel);
            this.Location = new System.Drawing.Point(0, 20);
            this.Name = "SequenceTrack";
            this.Size = new System.Drawing.Size(703, 98);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDraw);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label antisenseLabel;
        private System.Windows.Forms.Panel barContainer;
        private System.Windows.Forms.Label senseLabel;
        private System.Windows.Forms.Label label1;
    }
}
