
namespace DNATagger {
    partial class WindowAddTag {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.colorSelectionButton = new System.Windows.Forms.Button();
            this.confirmTagButton = new System.Windows.Forms.Button();
            this.selectedSequenceLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.startPosSelector = new System.Windows.Forms.NumericUpDown();
            this.endPosSelector = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.startPosSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPosSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // colorSelectionButton
            // 
            this.colorSelectionButton.BackColor = System.Drawing.Color.GreenYellow;
            this.colorSelectionButton.Location = new System.Drawing.Point(127, 111);
            this.colorSelectionButton.Name = "colorSelectionButton";
            this.colorSelectionButton.Size = new System.Drawing.Size(120, 23);
            this.colorSelectionButton.TabIndex = 0;
            this.colorSelectionButton.Text = "Select";
            this.colorSelectionButton.UseVisualStyleBackColor = false;
            this.colorSelectionButton.Click += new System.EventHandler(this.OnSelectColor);
            // 
            // confirmTagButton
            // 
            this.confirmTagButton.Location = new System.Drawing.Point(81, 140);
            this.confirmTagButton.Name = "confirmTagButton";
            this.confirmTagButton.Size = new System.Drawing.Size(75, 23);
            this.confirmTagButton.TabIndex = 0;
            this.confirmTagButton.Text = "Add Tag";
            this.confirmTagButton.UseVisualStyleBackColor = true;
            this.confirmTagButton.Click += new System.EventHandler(this.OnConfirm);
            // 
            // selectedSequenceLabel
            // 
            this.selectedSequenceLabel.AutoSize = true;
            this.selectedSequenceLabel.Location = new System.Drawing.Point(12, 9);
            this.selectedSequenceLabel.Name = "selectedSequenceLabel";
            this.selectedSequenceLabel.Size = new System.Drawing.Size(127, 13);
            this.selectedSequenceLabel.TabIndex = 2;
            this.selectedSequenceLabel.Text = "Add tag to sequence:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Color of new tag:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(127, 33);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(120, 20);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.Text = "Tagged region";
            // 
            // startPosSelector
            // 
            this.startPosSelector.Location = new System.Drawing.Point(127, 60);
            this.startPosSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startPosSelector.Name = "startPosSelector";
            this.startPosSelector.Size = new System.Drawing.Size(120, 20);
            this.startPosSelector.TabIndex = 6;
            this.startPosSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // endPosSelector
            // 
            this.endPosSelector.Location = new System.Drawing.Point(127, 86);
            this.endPosSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endPosSelector.Name = "endPosSelector";
            this.endPosSelector.Size = new System.Drawing.Size(120, 20);
            this.endPosSelector.TabIndex = 6;
            this.endPosSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WindowAddTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(262, 174);
            this.Controls.Add(this.endPosSelector);
            this.Controls.Add(this.startPosSelector);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectedSequenceLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmTagButton);
            this.Controls.Add(this.colorSelectionButton);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WindowAddTag";
            this.Text = "Add Tag";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            ((System.ComponentModel.ISupportInitialize)(this.startPosSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPosSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button colorSelectionButton;
        private System.Windows.Forms.Button confirmTagButton;
        private System.Windows.Forms.Label selectedSequenceLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.NumericUpDown startPosSelector;
        private System.Windows.Forms.NumericUpDown endPosSelector;
    }
}