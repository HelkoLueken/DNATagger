
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorSelectionButton = new System.Windows.Forms.Button();
            this.confirmTagButton = new System.Windows.Forms.Button();
            this.selectedSequenceLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // colorSelectionButton
            // 
            this.colorSelectionButton.BackColor = System.Drawing.Color.GreenYellow;
            this.colorSelectionButton.Location = new System.Drawing.Point(112, 111);
            this.colorSelectionButton.Name = "colorSelectionButton";
            this.colorSelectionButton.Size = new System.Drawing.Size(75, 23);
            this.colorSelectionButton.TabIndex = 0;
            this.colorSelectionButton.Text = "Select";
            this.colorSelectionButton.UseVisualStyleBackColor = false;
            this.colorSelectionButton.Click += new System.EventHandler(this.colorSelectionButton_Click);
            // 
            // confirmTagButton
            // 
            this.confirmTagButton.Location = new System.Drawing.Point(81, 140);
            this.confirmTagButton.Name = "confirmTagButton";
            this.confirmTagButton.Size = new System.Drawing.Size(75, 23);
            this.confirmTagButton.TabIndex = 0;
            this.confirmTagButton.Text = "Add Tag";
            this.confirmTagButton.UseVisualStyleBackColor = true;
            this.confirmTagButton.Click += new System.EventHandler(this.confirmTagButton_Click);
            // 
            // selectedSequenceLabel
            // 
            this.selectedSequenceLabel.AutoSize = true;
            this.selectedSequenceLabel.Location = new System.Drawing.Point(12, 9);
            this.selectedSequenceLabel.Name = "selectedSequenceLabel";
            this.selectedSequenceLabel.Size = new System.Drawing.Size(113, 13);
            this.selectedSequenceLabel.TabIndex = 2;
            this.selectedSequenceLabel.Text = "Add Tag to sequence:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Color of new Tag:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "To";
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(112, 59);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrom.TabIndex = 5;
            this.textBoxFrom.Text = "Base";
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(112, 85);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(100, 20);
            this.textBoxTo.TabIndex = 5;
            this.textBoxTo.Text = "Base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(112, 33);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.Text = "Tagged region";
            // 
            // WindowAddTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(240, 174);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectedSequenceLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmTagButton);
            this.Controls.Add(this.colorSelectionButton);
            this.Name = "WindowAddTag";
            this.Text = "Add Tag";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button colorSelectionButton;
        private System.Windows.Forms.Button confirmTagButton;
        private System.Windows.Forms.Label selectedSequenceLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}