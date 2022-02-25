
namespace Hills.IdentityServer4.Deployment
{
    partial class EditConfiguredService
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRedirectUris = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPostLogoutRedirectUris = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAllowedCorsOrigins = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "ClientId";
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(144, 21);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(424, 23);
            this.txtClientId.TabIndex = 12;
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(144, 50);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(424, 23);
            this.txtClientName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "ClientName";
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Location = new System.Drawing.Point(144, 79);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.Size = new System.Drawing.Size(424, 23);
            this.txtClientSecret.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "ClientSecret";
            // 
            // txtRedirectUris
            // 
            this.txtRedirectUris.Location = new System.Drawing.Point(144, 108);
            this.txtRedirectUris.Multiline = true;
            this.txtRedirectUris.Name = "txtRedirectUris";
            this.txtRedirectUris.Size = new System.Drawing.Size(424, 75);
            this.txtRedirectUris.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "RedirectUris";
            // 
            // txtPostLogoutRedirectUris
            // 
            this.txtPostLogoutRedirectUris.Location = new System.Drawing.Point(144, 189);
            this.txtPostLogoutRedirectUris.Multiline = true;
            this.txtPostLogoutRedirectUris.Name = "txtPostLogoutRedirectUris";
            this.txtPostLogoutRedirectUris.Size = new System.Drawing.Size(424, 75);
            this.txtPostLogoutRedirectUris.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "PostLogoutRedirectUris";
            // 
            // txtAllowedCorsOrigins
            // 
            this.txtAllowedCorsOrigins.Location = new System.Drawing.Point(144, 270);
            this.txtAllowedCorsOrigins.Multiline = true;
            this.txtAllowedCorsOrigins.Name = "txtAllowedCorsOrigins";
            this.txtAllowedCorsOrigins.Size = new System.Drawing.Size(424, 75);
            this.txtAllowedCorsOrigins.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "AllowedCorsOrigins";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(493, 382);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 21;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // EditConfiguredService
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAllowedCorsOrigins);
            this.Controls.Add(this.txtPostLogoutRedirectUris);
            this.Controls.Add(this.txtRedirectUris);
            this.Controls.Add(this.txtClientSecret);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.txtClientId);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "EditConfiguredService";
            this.Text = "EditConfiguredService";
            this.Load += new System.EventHandler(this.EditConfiguredService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRedirectUris;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPostLogoutRedirectUris;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAllowedCorsOrigins;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdSave;
    }
}