namespace CarServiceApp
{
    partial class AutoForm
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
            this.autoIdLabel = new System.Windows.Forms.Label();
            this.numarAutoLabel = new System.Windows.Forms.Label();
            this.sasiuIdLabel = new System.Windows.Forms.Label();
            this.serieSasiuLabel = new System.Windows.Forms.Label();
            this.autoIdTextBox = new System.Windows.Forms.TextBox();
            this.numarAutoTextBox = new System.Windows.Forms.TextBox();
            this.sasiuIdTextBox = new System.Windows.Forms.TextBox();
            this.serieSasiuTextBox = new System.Windows.Forms.TextBox();
            this.clientIdLabel = new System.Windows.Forms.Label();
            this.clientIdTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // autoIdLabel
            // 
            this.autoIdLabel.AutoSize = true;
            this.autoIdLabel.Location = new System.Drawing.Point(56, 52);
            this.autoIdLabel.Name = "autoIdLabel";
            this.autoIdLabel.Size = new System.Drawing.Size(48, 17);
            this.autoIdLabel.TabIndex = 0;
            this.autoIdLabel.Text = "AutoId";
            // 
            // numarAutoLabel
            // 
            this.numarAutoLabel.AutoSize = true;
            this.numarAutoLabel.Location = new System.Drawing.Point(56, 113);
            this.numarAutoLabel.Name = "numarAutoLabel";
            this.numarAutoLabel.Size = new System.Drawing.Size(79, 17);
            this.numarAutoLabel.TabIndex = 1;
            this.numarAutoLabel.Text = "NumarAuto";
            // 
            // sasiuIdLabel
            // 
            this.sasiuIdLabel.AutoSize = true;
            this.sasiuIdLabel.Location = new System.Drawing.Point(56, 176);
            this.sasiuIdLabel.Name = "sasiuIdLabel";
            this.sasiuIdLabel.Size = new System.Drawing.Size(54, 17);
            this.sasiuIdLabel.TabIndex = 2;
            this.sasiuIdLabel.Text = "SasiuId";
            // 
            // serieSasiuLabel
            // 
            this.serieSasiuLabel.AutoSize = true;
            this.serieSasiuLabel.Location = new System.Drawing.Point(56, 237);
            this.serieSasiuLabel.Name = "serieSasiuLabel";
            this.serieSasiuLabel.Size = new System.Drawing.Size(76, 17);
            this.serieSasiuLabel.TabIndex = 3;
            this.serieSasiuLabel.Text = "SerieSasiu";
            // 
            // autoIdTextBox
            // 
            this.autoIdTextBox.Location = new System.Drawing.Point(146, 49);
            this.autoIdTextBox.MaxLength = 14;
            this.autoIdTextBox.Name = "autoIdTextBox";
            this.autoIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.autoIdTextBox.TabIndex = 4;
            // 
            // numarAutoTextBox
            // 
            this.numarAutoTextBox.Location = new System.Drawing.Point(146, 110);
            this.numarAutoTextBox.MaxLength = 10;
            this.numarAutoTextBox.Name = "numarAutoTextBox";
            this.numarAutoTextBox.Size = new System.Drawing.Size(108, 22);
            this.numarAutoTextBox.TabIndex = 5;
            // 
            // sasiuIdTextBox
            // 
            this.sasiuIdTextBox.Location = new System.Drawing.Point(146, 173);
            this.sasiuIdTextBox.MaxLength = 14;
            this.sasiuIdTextBox.Name = "sasiuIdTextBox";
            this.sasiuIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.sasiuIdTextBox.TabIndex = 6;
            // 
            // serieSasiuTextBox
            // 
            this.serieSasiuTextBox.Location = new System.Drawing.Point(146, 234);
            this.serieSasiuTextBox.MaxLength = 25;
            this.serieSasiuTextBox.Name = "serieSasiuTextBox";
            this.serieSasiuTextBox.Size = new System.Drawing.Size(192, 22);
            this.serieSasiuTextBox.TabIndex = 7;
            // 
            // clientIdLabel
            // 
            this.clientIdLabel.AutoSize = true;
            this.clientIdLabel.Location = new System.Drawing.Point(56, 295);
            this.clientIdLabel.Name = "clientIdLabel";
            this.clientIdLabel.Size = new System.Drawing.Size(54, 17);
            this.clientIdLabel.TabIndex = 8;
            this.clientIdLabel.Text = "ClientId";
            // 
            // clientIdTextBox
            // 
            this.clientIdTextBox.Location = new System.Drawing.Point(146, 292);
            this.clientIdTextBox.MaxLength = 14;
            this.clientIdTextBox.Name = "clientIdTextBox";
            this.clientIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.clientIdTextBox.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Executa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AutoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 418);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clientIdTextBox);
            this.Controls.Add(this.clientIdLabel);
            this.Controls.Add(this.serieSasiuTextBox);
            this.Controls.Add(this.sasiuIdTextBox);
            this.Controls.Add(this.numarAutoTextBox);
            this.Controls.Add(this.autoIdTextBox);
            this.Controls.Add(this.serieSasiuLabel);
            this.Controls.Add(this.sasiuIdLabel);
            this.Controls.Add(this.numarAutoLabel);
            this.Controls.Add(this.autoIdLabel);
            this.Name = "AutoForm";
            this.Text = "AutoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label autoIdLabel;
        private System.Windows.Forms.Label numarAutoLabel;
        private System.Windows.Forms.Label sasiuIdLabel;
        private System.Windows.Forms.Label serieSasiuLabel;
        private System.Windows.Forms.TextBox autoIdTextBox;
        private System.Windows.Forms.TextBox numarAutoTextBox;
        private System.Windows.Forms.TextBox sasiuIdTextBox;
        private System.Windows.Forms.TextBox serieSasiuTextBox;
        private System.Windows.Forms.Label clientIdLabel;
        private System.Windows.Forms.TextBox clientIdTextBox;
        private System.Windows.Forms.Button button1;
    }
}