namespace CarServiceApp
{
    partial class OperatieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.operatieIdLabel = new System.Windows.Forms.Label();
            this.denumireLabel = new System.Windows.Forms.Label();
            this.timpExecutieLabel = new System.Windows.Forms.Label();
            this.operatieIdTextBox = new System.Windows.Forms.TextBox();
            this.denumireTextBox = new System.Windows.Forms.TextBox();
            this.timpExecutieTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // operatieIdLabel
            // 
            this.operatieIdLabel.AutoSize = true;
            this.operatieIdLabel.Location = new System.Drawing.Point(57, 49);
            this.operatieIdLabel.Name = "operatieIdLabel";
            this.operatieIdLabel.Size = new System.Drawing.Size(74, 17);
            this.operatieIdLabel.TabIndex = 0;
            this.operatieIdLabel.Text = "OperatieId";
            // 
            // denumireLabel
            // 
            this.denumireLabel.AutoSize = true;
            this.denumireLabel.Location = new System.Drawing.Point(57, 125);
            this.denumireLabel.Name = "denumireLabel";
            this.denumireLabel.Size = new System.Drawing.Size(69, 17);
            this.denumireLabel.TabIndex = 1;
            this.denumireLabel.Text = "Denumire";
            // 
            // timpExecutieLabel
            // 
            this.timpExecutieLabel.AutoSize = true;
            this.timpExecutieLabel.Location = new System.Drawing.Point(57, 198);
            this.timpExecutieLabel.Name = "timpExecutieLabel";
            this.timpExecutieLabel.Size = new System.Drawing.Size(92, 17);
            this.timpExecutieLabel.TabIndex = 2;
            this.timpExecutieLabel.Text = "TimpExecutie";
            // 
            // operatieIdTextBox
            // 
            this.operatieIdTextBox.Location = new System.Drawing.Point(178, 46);
            this.operatieIdTextBox.MaxLength = 14;
            this.operatieIdTextBox.Name = "operatieIdTextBox";
            this.operatieIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.operatieIdTextBox.TabIndex = 3;
            // 
            // denumireTextBox
            // 
            this.denumireTextBox.Location = new System.Drawing.Point(178, 111);
            this.denumireTextBox.MaxLength = 256;
            this.denumireTextBox.Multiline = true;
            this.denumireTextBox.Name = "denumireTextBox";
            this.denumireTextBox.Size = new System.Drawing.Size(279, 48);
            this.denumireTextBox.TabIndex = 4;
            // 
            // timpExecutieTextBox
            // 
            this.timpExecutieTextBox.Location = new System.Drawing.Point(178, 195);
            this.timpExecutieTextBox.MaxLength = 10;
            this.timpExecutieTextBox.Name = "timpExecutieTextBox";
            this.timpExecutieTextBox.Size = new System.Drawing.Size(117, 22);
            this.timpExecutieTextBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Executa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // OperatieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timpExecutieTextBox);
            this.Controls.Add(this.denumireTextBox);
            this.Controls.Add(this.operatieIdTextBox);
            this.Controls.Add(this.timpExecutieLabel);
            this.Controls.Add(this.denumireLabel);
            this.Controls.Add(this.operatieIdLabel);
            this.Name = "OperatieForm";
            this.Text = "OperatieForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label operatieIdLabel;
        private System.Windows.Forms.Label denumireLabel;
        private System.Windows.Forms.Label timpExecutieLabel;
        private System.Windows.Forms.TextBox operatieIdTextBox;
        private System.Windows.Forms.TextBox denumireTextBox;
        private System.Windows.Forms.TextBox timpExecutieTextBox;
        private System.Windows.Forms.Button button1;
    }
}