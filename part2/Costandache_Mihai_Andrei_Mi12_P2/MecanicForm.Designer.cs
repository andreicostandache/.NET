namespace CarServiceApp
{
    partial class MecanicForm
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
            this.mecanicIdLabel = new System.Windows.Forms.Label();
            this.numeLabel = new System.Windows.Forms.Label();
            this.prenumeLabel = new System.Windows.Forms.Label();
            this.mecanicIdTextBox = new System.Windows.Forms.TextBox();
            this.numeTextBox = new System.Windows.Forms.TextBox();
            this.prenumeTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mecanicIdLabel
            // 
            this.mecanicIdLabel.AutoSize = true;
            this.mecanicIdLabel.Location = new System.Drawing.Point(50, 46);
            this.mecanicIdLabel.Name = "mecanicIdLabel";
            this.mecanicIdLabel.Size = new System.Drawing.Size(71, 17);
            this.mecanicIdLabel.TabIndex = 0;
            this.mecanicIdLabel.Text = "MecanicId";
            // 
            // numeLabel
            // 
            this.numeLabel.AutoSize = true;
            this.numeLabel.Location = new System.Drawing.Point(50, 114);
            this.numeLabel.Name = "numeLabel";
            this.numeLabel.Size = new System.Drawing.Size(45, 17);
            this.numeLabel.TabIndex = 1;
            this.numeLabel.Text = "Nume";
            // 
            // prenumeLabel
            // 
            this.prenumeLabel.AutoSize = true;
            this.prenumeLabel.Location = new System.Drawing.Point(50, 182);
            this.prenumeLabel.Name = "prenumeLabel";
            this.prenumeLabel.Size = new System.Drawing.Size(65, 17);
            this.prenumeLabel.TabIndex = 2;
            this.prenumeLabel.Text = "Prenume";
            // 
            // mecanicIdTextBox
            // 
            this.mecanicIdTextBox.Location = new System.Drawing.Point(139, 43);
            this.mecanicIdTextBox.MaxLength = 14;
            this.mecanicIdTextBox.Name = "mecanicIdTextBox";
            this.mecanicIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.mecanicIdTextBox.TabIndex = 3;
            // 
            // numeTextBox
            // 
            this.numeTextBox.Location = new System.Drawing.Point(139, 111);
            this.numeTextBox.MaxLength = 15;
            this.numeTextBox.Name = "numeTextBox";
            this.numeTextBox.Size = new System.Drawing.Size(133, 22);
            this.numeTextBox.TabIndex = 4;
            // 
            // prenumeTextBox
            // 
            this.prenumeTextBox.Location = new System.Drawing.Point(139, 179);
            this.prenumeTextBox.MaxLength = 15;
            this.prenumeTextBox.Name = "prenumeTextBox";
            this.prenumeTextBox.Size = new System.Drawing.Size(133, 22);
            this.prenumeTextBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Executa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MecanicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 304);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.prenumeTextBox);
            this.Controls.Add(this.numeTextBox);
            this.Controls.Add(this.mecanicIdTextBox);
            this.Controls.Add(this.prenumeLabel);
            this.Controls.Add(this.numeLabel);
            this.Controls.Add(this.mecanicIdLabel);
            this.Name = "MecanicForm";
            this.Text = "MecanicForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mecanicIdLabel;
        private System.Windows.Forms.Label numeLabel;
        private System.Windows.Forms.Label prenumeLabel;
        private System.Windows.Forms.TextBox mecanicIdTextBox;
        private System.Windows.Forms.TextBox numeTextBox;
        private System.Windows.Forms.TextBox prenumeTextBox;
        private System.Windows.Forms.Button button1;
    }
}