
namespace Hills.IdentityServer4.Deployment
{
    partial class ucEndPointsEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lnkRemove = new System.Windows.Forms.LinkLabel();
            this.lnkEdit = new System.Windows.Forms.LinkLabel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstEndPoints = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colIpAddress = new System.Windows.Forms.ColumnHeader();
            this.colPort = new System.Windows.Forms.ColumnHeader();
            this.colHttps = new System.Windows.Forms.ColumnHeader();
            this.colCertType = new System.Windows.Forms.ColumnHeader();
            this.colCertFileName = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lnkRemove
            // 
            this.lnkRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkRemove.AutoSize = true;
            this.lnkRemove.Location = new System.Drawing.Point(71, 298);
            this.lnkRemove.Name = "lnkRemove";
            this.lnkRemove.Size = new System.Drawing.Size(50, 15);
            this.lnkRemove.TabIndex = 12;
            this.lnkRemove.TabStop = true;
            this.lnkRemove.Text = "Remove";
            this.lnkRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemove_LinkClicked);
            // 
            // lnkEdit
            // 
            this.lnkEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkEdit.AutoSize = true;
            this.lnkEdit.Location = new System.Drawing.Point(38, 298);
            this.lnkEdit.Name = "lnkEdit";
            this.lnkEdit.Size = new System.Drawing.Size(27, 15);
            this.lnkEdit.TabIndex = 10;
            this.lnkEdit.TabStop = true;
            this.lnkEdit.Text = "Edit";
            this.lnkEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEdit_LinkClicked);
            // 
            // lnkAdd
            // 
            this.lnkAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Location = new System.Drawing.Point(3, 298);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(29, 15);
            this.lnkAdd.TabIndex = 11;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Add";
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEdit_LinkClicked);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(144, 15);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "End Points IdentityServer4";
            // 
            // lstEndPoints
            // 
            this.lstEndPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEndPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colIpAddress,
            this.colPort,
            this.colHttps,
            this.colCertType,
            this.colCertFileName});
            this.lstEndPoints.FullRowSelect = true;
            this.lstEndPoints.HideSelection = false;
            this.lstEndPoints.Location = new System.Drawing.Point(3, 18);
            this.lstEndPoints.Name = "lstEndPoints";
            this.lstEndPoints.Size = new System.Drawing.Size(615, 277);
            this.lstEndPoints.TabIndex = 8;
            this.lstEndPoints.UseCompatibleStateImageBehavior = false;
            this.lstEndPoints.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 150;
            // 
            // colIpAddress
            // 
            this.colIpAddress.Text = "Ip Address";
            this.colIpAddress.Width = 100;
            // 
            // colPort
            // 
            this.colPort.Text = "Port";
            // 
            // colHttps
            // 
            this.colHttps.Text = "Https";
            // 
            // colCertType
            // 
            this.colCertType.Text = "Cert Type";
            this.colCertType.Width = 100;
            // 
            // colCertFileName
            // 
            this.colCertFileName.Text = "Cert Source";
            this.colCertFileName.Width = 300;
            // 
            // ucEndPointsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkRemove);
            this.Controls.Add(this.lnkEdit);
            this.Controls.Add(this.lnkAdd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstEndPoints);
            this.Name = "ucEndPointsEditor";
            this.Size = new System.Drawing.Size(621, 313);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkRemove;
        private System.Windows.Forms.LinkLabel lnkEdit;
        private System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lstEndPoints;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colIpAddress;
        private System.Windows.Forms.ColumnHeader colPort;
        private System.Windows.Forms.ColumnHeader colHttps;
        private System.Windows.Forms.ColumnHeader colCertType;
        private System.Windows.Forms.ColumnHeader colCertFileName;
    }
}
