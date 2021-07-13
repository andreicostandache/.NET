namespace CarServiceApp
{
    partial class MaterialForm
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
            this.materialIdLabel = new System.Windows.Forms.Label();
            this.denumireLabel = new System.Windows.Forms.Label();
            this.cantitateLabel = new System.Windows.Forms.Label();
            this.pretLabel = new System.Windows.Forms.Label();
            this.dataAprovizionareLabel = new System.Windows.Forms.Label();
            this.materialIdTextBox = new System.Windows.Forms.TextBox();
            this.denumireTextBox = new System.Windows.Forms.TextBox();
            this.cantitateTextBox = new System.Windows.Forms.TextBox();
            this.pretTextBox = new System.Windows.Forms.TextBox();
            this.dataAprovizionareTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // materialIdLabel
            // 
            this.materialIdLabel.AutoSize = true;
            this.materialIdLabel.Location = new System.Drawing.Point(50, 42);
            this.materialIdLabel.Name = "materialIdLabel";
            this.materialIdLabel.Size = new System.Drawing.Size(69, 17);
            this.materialIdLabel.TabIndex = 0;
            this.materialIdLabel.Text = "MaterialId";
            // 
            // denumireLabel
            // 
            this.denumireLabel.AutoSize = true;
            this.denumireLabel.Location = new System.Drawing.Point(50, 99);
            this.denumireLabel.Name = "denumireLabel";
            this.denumireLabel.Size = new System.Drawing.Size(69, 17);
            this.denumireLabel.TabIndex = 1;
            this.denumireLabel.Text = "Denumire";
            // 
            // cantitateLabel
            // 
            this.cantitateLabel.AutoSize = true;
            this.cantitateLabel.Location = new System.Drawing.Point(50, 156);
            this.cantitateLabel.Name = "cantitateLabel";
            this.cantitateLabel.Size = new System.Drawing.Size(64, 17);
            this.cantitateLabel.TabIndex = 2;
            this.cantitateLabel.Text = "Cantitate";
            // 
            // pretLabel
            // 
            this.pretLabel.AutoSize = true;
            this.pretLabel.Location = new System.Drawing.Point(50, 216);
            this.pretLabel.Name = "pretLabel";
            this.pretLabel.Size = new System.Drawing.Size(34, 17);
            this.pretLabel.TabIndex = 3;
            this.pretLabel.Text = "Pret";
            // 
            // dataAprovizionareLabel
            // 
            this.dataAprovizionareLabel.AutoSize = true;
            this.dataAprovizionareLabel.Location = new System.Drawing.Point(50, 274);
            this.dataAprovizionareLabel.Name = "dataAprovizionareLabel";
            this.dataAprovizionareLabel.Size = new System.Drawing.Size(125, 17);
            this.dataAprovizionareLabel.TabIndex = 4;
            this.dataAprovizionareLabel.Text = "DataAprovizionare";
            // 
            // materialIdTextBox
            // 
            this.materialIdTextBox.Location = new System.Drawing.Point(187, 39);
            this.materialIdTextBox.MaxLength = 14;
            this.materialIdTextBox.Name = "materialIdTextBox";
            this.materialIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.materialIdTextBox.TabIndex = 5;
            // 
            // denumireTextBox
            // 
            this.denumireTextBox.Location = new System.Drawing.Point(187, 96);
            this.denumireTextBox.MaxLength = 50;
            this.denumireTextBox.Name = "denumireTextBox";
            this.denumireTextBox.Size = new System.Drawing.Size(295, 22);
            this.denumireTextBox.TabIndex = 6;
            // 
            // cantitateTextBox
            // 
            this.cantitateTextBox.Location = new System.Drawing.Point(187, 153);
            this.cantitateTextBox.MaxLength = 14;
            this.cantitateTextBox.Name = "cantitateTextBox";
            this.cantitateTextBox.Size = new System.Drawing.Size(114, 22);
            this.cantitateTextBox.TabIndex = 7;
            // 
            // pretTextBox
            // 
            this.pretTextBox.Location = new System.Drawing.Point(187, 213);
            this.pretTextBox.MaxLength = 14;
            this.pretTextBox.Name = "pretTextBox";
            this.pretTextBox.Size = new System.Drawing.Size(114, 22);
            this.pretTextBox.TabIndex = 8;
            // 
            // dataAprovizionareTextBox
            // 
            this.dataAprovizionareTextBox.Location = new System.Drawing.Point(187, 271);
            this.dataAprovizionareTextBox.MaxLength = 100;
            this.dataAprovizionareTextBox.Name = "dataAprovizionareTextBox";
            this.dataAprovizionareTextBox.Size = new System.Drawing.Size(188, 22);
            this.dataAprovizionareTextBox.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Executa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 388);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataAprovizionareTextBox);
            this.Controls.Add(this.pretTextBox);
            this.Controls.Add(this.cantitateTextBox);
            this.Controls.Add(this.denumireTextBox);
            this.Controls.Add(this.materialIdTextBox);
            this.Controls.Add(this.dataAprovizionareLabel);
            this.Controls.Add(this.pretLabel);
            this.Controls.Add(this.cantitateLabel);
            this.Controls.Add(this.denumireLabel);
            this.Controls.Add(this.materialIdLabel);
            this.Name = "MaterialForm";
            this.Text = "MaterialForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label materialIdLabel;
        private System.Windows.Forms.Label denumireLabel;
        private System.Windows.Forms.Label cantitateLabel;
        private System.Windows.Forms.Label pretLabel;
        private System.Windows.Forms.Label dataAprovizionareLabel;
        private System.Windows.Forms.TextBox materialIdTextBox;
        private System.Windows.Forms.TextBox denumireTextBox;
        private System.Windows.Forms.TextBox cantitateTextBox;
        private System.Windows.Forms.TextBox pretTextBox;
        private System.Windows.Forms.TextBox dataAprovizionareTextBox;
        private System.Windows.Forms.Button button1;
    }
}