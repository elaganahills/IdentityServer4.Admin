
namespace Hills.IdentityServer4.Deployment
{
    partial class EditEndPoint
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
            this.lnkSelectFile = new System.Windows.Forms.LinkLabel();
            this.cmbCertificate = new System.Windows.Forms.ComboBox();
            this.cmbCertificateType = new System.Windows.Forms.ComboBox();
            this.cmbIpAddress = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkHttps = new System.Windows.Forms.CheckBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lnkSelectFile
            // 
            this.lnkSelectFile.AutoSize = true;
            this.lnkSelectFile.Location = new System.Drawing.Point(405, 189);
            this.lnkSelectFile.Name = "lnkSelectFile";
            this.lnkSelectFile.Size = new System.Drawing.Size(57, 15);
            this.lnkSelectFile.TabIndex = 19;
            this.lnkSelectFile.TabStop = true;
            this.lnkSelectFile.Text = "Select file";
            this.lnkSelectFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectFile_LinkClicked);
            // 
            // cmbCertificate
            // 
            this.cmbCertificate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCertificate.FormattingEnabled = true;
            this.cmbCertificate.Location = new System.Drawing.Point(125, 157);
            this.cmbCertificate.Name = "cmbCertificate";
            this.cmbCertificate.Size = new System.Drawing.Size(274, 23);
            this.cmbCertificate.TabIndex = 16;
            // 
            // cmbCertificateType
            // 
            this.cmbCertificateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCertificateType.FormattingEnabled = true;
            this.cmbCertificateType.Location = new System.Drawing.Point(125, 128);
            this.cmbCertificateType.Name = "cmbCertificateType";
            this.cmbCertificateType.Size = new System.Drawing.Size(131, 23);
            this.cmbCertificateType.TabIndex = 17;
            this.cmbCertificateType.SelectedIndexChanged += new System.EventHandler(this.cmbCertificateType_SelectedIndexChanged);
            // 
            // cmbIpAddress
            // 
            this.cmbIpAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIpAddress.FormattingEnabled = true;
            this.cmbIpAddress.Location = new System.Drawing.Point(125, 41);
            this.cmbIpAddress.Name = "cmbIpAddress";
            this.cmbIpAddress.Size = new System.Drawing.Size(274, 23);
            this.cmbIpAddress.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Use Https";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Port";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Certificate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Certificate type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ip Address";
            // 
            // chkHttps
            // 
            this.chkHttps.Location = new System.Drawing.Point(125, 99);
            this.chkHttps.Name = "chkHttps";
            this.chkHttps.Size = new System.Drawing.Size(104, 23);
            this.chkHttps.TabIndex = 9;
            this.chkHttps.UseVisualStyleBackColor = true;
            this.chkHttps.CheckedChanged += new System.EventHandler(this.chkHttps_CheckedChanged);
            // 
            // txtFile
            // 
            this.txtFileName.Location = new System.Drawing.Point(125, 186);
            this.txtFileName.Name = "txtFile";
            this.txtFileName.Size = new System.Drawing.Size(274, 23);
            this.txtFileName.TabIndex = 7;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(125, 70);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(131, 23);
            this.txtPort.TabIndex = 8;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(324, 281);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 20;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(125, 215);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(274, 23);
            this.txtPassword.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Password";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(125, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(274, 23);
            this.txtName.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Name";
            // 
            // EditEndPoint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(510, 337);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lnkSelectFile);
            this.Controls.Add(this.cmbCertificate);
            this.Controls.Add(this.cmbCertificateType);
            this.Controls.Add(this.cmbIpAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkHttps);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditEndPoint";
            this.Text = "EditEndPoint";
            this.Load += new System.EventHandler(this.EditEndPoint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkSelectFile;
        private System.Windows.Forms.ComboBox cmbCertificate;
        private System.Windows.Forms.ComboBox cmbCertificateType;
        private System.Windows.Forms.ComboBox cmbIpAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHttps;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
    }
}