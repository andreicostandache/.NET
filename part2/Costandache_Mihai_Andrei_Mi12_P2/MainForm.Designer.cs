namespace CarServiceApp
{
    partial class MainForm
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
            this.entitiesComboBox = new System.Windows.Forms.ComboBox();
            this.entitiesLabel = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.viewAllBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.entitiesDataGridView = new System.Windows.Forms.DataGridView();
            this.getAssociationsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // entitiesComboBox
            // 
            this.entitiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entitiesComboBox.FormattingEnabled = true;
            this.entitiesComboBox.Items.AddRange(new object[] {
            "Auto",
            "Client",
            "Comanda",
            "DetaliuComanda",
            "Sasiu",
            "Imagine",
            "Material",
            "Mecanic",
            "Operatie"});
            this.entitiesComboBox.Location = new System.Drawing.Point(146, 46);
            this.entitiesComboBox.Name = "entitiesComboBox";
            this.entitiesComboBox.Size = new System.Drawing.Size(175, 24);
            this.entitiesComboBox.TabIndex = 2;
            // 
            // entitiesLabel
            // 
            this.entitiesLabel.AutoSize = true;
            this.entitiesLabel.Location = new System.Drawing.Point(31, 49);
            this.entitiesLabel.Name = "entitiesLabel";
            this.entitiesLabel.Size = new System.Drawing.Size(92, 17);
            this.entitiesLabel.TabIndex = 3;
            this.entitiesLabel.Text = "Selectati tipul";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(121, 131);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(89, 32);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Adaugare";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(121, 202);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(89, 32);
            this.searchBtn.TabIndex = 5;
            this.searchBtn.Text = "Cautare";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.SearchingBtn_Click);
            // 
            // viewAllBtn
            // 
            this.viewAllBtn.Location = new System.Drawing.Point(94, 270);
            this.viewAllBtn.Name = "viewAllBtn";
            this.viewAllBtn.Size = new System.Drawing.Size(148, 50);
            this.viewAllBtn.TabIndex = 6;
            this.viewAllBtn.Text = "Vizualizare colectie";
            this.viewAllBtn.UseVisualStyleBackColor = true;
            this.viewAllBtn.Click += new System.EventHandler(this.ViewingBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(1044, 393);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(89, 32);
            this.editBtn.TabIndex = 7;
            this.editBtn.Text = "Editare";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(806, 393);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(89, 32);
            this.deleteBtn.TabIndex = 8;
            this.deleteBtn.Text = "Stergere";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.RemovingBtn_Click);
            // 
            // entitiesDataGridView
            // 
            this.entitiesDataGridView.AllowUserToAddRows = false;
            this.entitiesDataGridView.AllowUserToDeleteRows = false;
            this.entitiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.entitiesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.entitiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entitiesDataGridView.Location = new System.Drawing.Point(348, 42);
            this.entitiesDataGridView.Name = "entitiesDataGridView";
            this.entitiesDataGridView.RowTemplate.Height = 24;
            this.entitiesDataGridView.Size = new System.Drawing.Size(1000, 278);
            this.entitiesDataGridView.TabIndex = 9;
            // 
            // getAssociationsBtn
            // 
            this.getAssociationsBtn.Location = new System.Drawing.Point(547, 393);
            this.getAssociationsBtn.Name = "getAssociationsBtn";
            this.getAssociationsBtn.Size = new System.Drawing.Size(89, 32);
            this.getAssociationsBtn.TabIndex = 10;
            this.getAssociationsBtn.Text = "Asocieri";
            this.getAssociationsBtn.UseVisualStyleBackColor = true;
            this.getAssociationsBtn.Click += new System.EventHandler(this.getAssociationsBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 450);
            this.Controls.Add(this.getAssociationsBtn);
            this.Controls.Add(this.entitiesDataGridView);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.viewAllBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.entitiesLabel);
            this.Controls.Add(this.entitiesComboBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox entitiesComboBox;
        private System.Windows.Forms.Label entitiesLabel;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button viewAllBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DataGridView entitiesDataGridView;
        private System.Windows.Forms.Button getAssociationsBtn;
    }
}

