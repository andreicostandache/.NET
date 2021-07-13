namespace CarServiceApp
{
    partial class SasiuForm
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
            this.sasiuIdLabel = new System.Windows.Forms.Label();
            this.codSasiuLabel = new System.Windows.Forms.Label();
            this.denumireLabel = new System.Windows.Forms.Label();
            this.sasiuIdTextBox = new System.Windows.Forms.TextBox();
            this.codSasiuTextBox = new System.Windows.Forms.TextBox();
            this.denumireTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sasiuIdLabel
            // 
            this.sasiuIdLabel.AutoSize = true;
            this.sasiuIdLabel.Location = new System.Drawing.Point(52, 56);
            this.sasiuIdLabel.Name = "sasiuIdLabel";
            this.sasiuIdLabel.Size = new System.Drawing.Size(54, 17);
            this.sasiuIdLabel.TabIndex = 0;
            this.sasiuIdLabel.Text = "SasiuId";
            // 
            // codSasiuLabel
            // 
            this.codSasiuLabel.AutoSize = true;
            this.codSasiuLabel.Location = new System.Drawing.Point(52, 122);
            this.codSasiuLabel.Name = "codSasiuLabel";
            this.codSasiuLabel.Size = new System.Drawing.Size(68, 17);
            this.codSasiuLabel.TabIndex = 1;
            this.codSasiuLabel.Text = "CodSasiu";
            // 
            // denumireLabel
            // 
            this.denumireLabel.AutoSize = true;
            this.denumireLabel.Location = new System.Drawing.Point(51, 194);
            this.denumireLabel.Name = "denumireLabel";
            this.denumireLabel.Size = new System.Drawing.Size(69, 17);
            this.denumireLabel.TabIndex = 2;
            this.denumireLabel.Text = "Denumire";
            // 
            // sasiuIdTextBox
            // 
            this.sasiuIdTextBox.Location = new System.Drawing.Point(149, 53);
            this.sasiuIdTextBox.MaxLength = 14;
            this.sasiuIdTextBox.Name = "sasiuIdTextBox";
            this.sasiuIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.sasiuIdTextBox.TabIndex = 3;
            // 
            // codSasiuTextBox
            // 
            this.codSasiuTextBox.Location = new System.Drawing.Point(149, 119);
            this.codSasiuTextBox.MaxLength = 2;
            this.codSasiuTextBox.Name = "codSasiuTextBox";
            this.codSasiuTextBox.Size = new System.Drawing.Size(69, 22);
            this.codSasiuTextBox.TabIndex = 4;
            // 
            // denumireTextBox
            // 
            this.denumireTextBox.Location = new System.Drawing.Point(149, 191);
            this.denumireTextBox.MaxLength = 25;
            this.denumireTextBox.Name = "denumireTextBox";
            this.denumireTextBox.Size = new System.Drawing.Size(216, 22);
            this.denumireTextBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Executa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SasiuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 311);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.denumireTextBox);
            this.Controls.Add(this.codSasiuTextBox);
            this.Controls.Add(this.sasiuIdTextBox);
            this.Controls.Add(this.denumireLabel);
            this.Controls.Add(this.codSasiuLabel);
            this.Controls.Add(this.sasiuIdLabel);
            this.Name = "SasiuForm";
            this.Text = "SasiuForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sasiuIdLabel;
        private System.Windows.Forms.Label codSasiuLabel;
        private System.Windows.Forms.Label denumireLabel;
        private System.Windows.Forms.TextBox sasiuIdTextBox;
        private System.Windows.Forms.TextBox codSasiuTextBox;
        private System.Windows.Forms.TextBox denumireTextBox;
        private System.Windows.Forms.Button button1;
    }
}