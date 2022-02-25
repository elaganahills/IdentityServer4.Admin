
namespace Hills.IdentityServer4.Deployment
{
    partial class Step05_PreConfiguredServices
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
            this.lnkRemove = new System.Windows.Forms.LinkLabel();
            this.lnkEdit = new System.Windows.Forms.LinkLabel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.lstClients = new System.Windows.Forms.ListView();
            this.colId = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lnkRemove
            // 
            this.lnkRemove.AutoSize = true;
            this.lnkRemove.Location = new System.Drawing.Point(77, 452);
            this.lnkRemove.Name = "lnkRemove";
            this.lnkRemove.Size = new System.Drawing.Size(50, 15);
            this.lnkRemove.TabIndex = 11;
            this.lnkRemove.TabStop = true;
            this.lnkRemove.Text = "Remove";
            this.lnkRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemove_LinkClicked);
            // 
            // lnkEdit
            // 
            this.lnkEdit.AutoSize = true;
            this.lnkEdit.Location = new System.Drawing.Point(44, 452);
            this.lnkEdit.Name = "lnkEdit";
            this.lnkEdit.Size = new System.Drawing.Size(27, 15);
            this.lnkEdit.TabIndex = 9;
            this.lnkEdit.TabStop = true;
            this.lnkEdit.Text = "Edit";
            this.lnkEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEdit_LinkClicked);
            // 
            // lnkAdd
            // 
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Location = new System.Drawing.Point(9, 452);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(29, 15);
            this.lnkAdd.TabIndex = 10;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Add";
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEdit_LinkClicked);
            // 
            // lstClients
            // 
            this.lstClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName});
            this.lstClients.FullRowSelect = true;
            this.lstClients.HideSelection = false;
            this.lstClients.Location = new System.Drawing.Point(9, 75);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(866, 374);
            this.lstClients.TabIndex = 8;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.DisplayIndex = 1;
            this.colId.Text = "Id";
            this.colId.Width = 150;
            // 
            // colName
            // 
            this.colName.DisplayIndex = 0;
            this.colName.Text = "Name";
            this.colName.Width = 150;
            // 
            // Step05_PreConfiguredServices
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.lnkRemove);
            this.Controls.Add(this.lnkEdit);
            this.Controls.Add(this.lnkAdd);
            this.Controls.Add(this.lstClients);
            this.EnableNext = true;
            this.EnablePrevious = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Step05_PreConfiguredServices";
            this.Text = "Step05_PreConfiguredServices";
            this.Title = "Configure the following applications (clients) during the installation. The appli" +
    "cation hills_identity_admin is mandatory.";
            this.Load += new System.EventHandler(this.Step04_PreConfiguredServices_Load);
            this.Controls.SetChildIndex(this.lstClients, 0);
            this.Controls.SetChildIndex(this.lnkAdd, 0);
            this.Controls.SetChildIndex(this.lnkEdit, 0);
            this.Controls.SetChildIndex(this.lnkRemove, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel lnkRemove;
        private System.Windows.Forms.LinkLabel lnkEdit;
        private System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.ListView lstClients;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colId;
    }
}