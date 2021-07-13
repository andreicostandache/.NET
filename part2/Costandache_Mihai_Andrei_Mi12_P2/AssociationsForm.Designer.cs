namespace CarServiceApp
{
    partial class AssociationsForm
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
            this.entitiesTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // entitiesTreeView
            // 
            this.entitiesTreeView.Location = new System.Drawing.Point(53, 48);
            this.entitiesTreeView.Name = "entitiesTreeView";
            this.entitiesTreeView.Size = new System.Drawing.Size(274, 338);
            this.entitiesTreeView.TabIndex = 0;
            // 
            // AssociationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 436);
            this.Controls.Add(this.entitiesTreeView);
            this.Name = "AssociationsForm";
            this.Text = "Associations";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView entitiesTreeView;
    }
}