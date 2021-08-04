
namespace Hills.IdentityServer4.Deployment
{
    partial class Step02_SqlConnection
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
            Hills.Extensions.Models.SqlConnectionInfo sqlConnectionInfo1 = new Hills.Extensions.Models.SqlConnectionInfo();
            Hills.Extensions.Models.SqlConnectionInfo sqlConnectionInfo2 = new Hills.Extensions.Models.SqlConnectionInfo();
            this.sqlconnDefault = new Hills.IdentityServer4.Deployment.ucSqlConnection();
            this.sqlconnConfig = new Hills.IdentityServer4.Deployment.ucSqlConnection();
            this.chkSqlConnectionForConfiguration = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // sqlconnDefault
            // 
            this.sqlconnDefault.Location = new System.Drawing.Point(12, 75);
            this.sqlconnDefault.Name = "sqlconnDefault";
            this.sqlconnDefault.Size = new System.Drawing.Size(404, 176);
            sqlConnectionInfo1.DataSource = ".\\SQLEXPRESS";
            sqlConnectionInfo1.InitialCatalog = "IdentityServer4Admin";
            sqlConnectionInfo1.IntegratedSecurity = true;
            sqlConnectionInfo1.Password = "";
            sqlConnectionInfo1.UserID = "";
            this.sqlconnDefault.SqlConnection = sqlConnectionInfo1;
            this.sqlconnDefault.TabIndex = 5;
            this.sqlconnDefault.TestWithoutDatabase = true;
            this.sqlconnDefault.OnUpdateStatus += new Hills.IdentityServer4.Deployment.ucSqlConnection.StatusUpdateHandler(this.sqlconnDefault_OnUpdateStatus);
            // 
            // sqlconnConfig
            // 
            this.sqlconnConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sqlconnConfig.Location = new System.Drawing.Point(12, 304);
            this.sqlconnConfig.Name = "sqlconnConfig";
            this.sqlconnConfig.Size = new System.Drawing.Size(404, 176);
            sqlConnectionInfo2.DataSource = ".\\SQLEXPRESS";
            sqlConnectionInfo2.InitialCatalog = "IdentityServer4Admin";
            sqlConnectionInfo2.IntegratedSecurity = true;
            sqlConnectionInfo2.Password = "";
            sqlConnectionInfo2.UserID = "";
            this.sqlconnConfig.SqlConnection = sqlConnectionInfo2;
            this.sqlconnConfig.TabIndex = 5;
            this.sqlconnConfig.TestWithoutDatabase = true;
            this.sqlconnConfig.Visible = false;
            // 
            // chkSqlConnectionForConfiguration
            // 
            this.chkSqlConnectionForConfiguration.AutoSize = true;
            this.chkSqlConnectionForConfiguration.Location = new System.Drawing.Point(12, 279);
            this.chkSqlConnectionForConfiguration.Name = "chkSqlConnectionForConfiguration";
            this.chkSqlConnectionForConfiguration.Size = new System.Drawing.Size(293, 19);
            this.chkSqlConnectionForConfiguration.TabIndex = 6;
            this.chkSqlConnectionForConfiguration.Text = "Use different connection settings for configuration";
            this.chkSqlConnectionForConfiguration.UseVisualStyleBackColor = true;
            this.chkSqlConnectionForConfiguration.CheckedChanged += new System.EventHandler(this.chkSqlConnectionForConfiguration_CheckedChanged);
            // 
            // Step02_SqlConnection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.chkSqlConnectionForConfiguration);
            this.Controls.Add(this.sqlconnConfig);
            this.Controls.Add(this.sqlconnDefault);
            this.EnablePrevious = true;
            this.Name = "Step02_SqlConnection";
            this.Text = "Step02_SqlConnection";
            this.Title = "Microsoft SQL Server connection settings. Connection must be succesfully tested t" +
    "o proceed.";
            this.Load += new System.EventHandler(this.Step02_SqlConnection_Load);
            this.Controls.SetChildIndex(this.sqlconnDefault, 0);
            this.Controls.SetChildIndex(this.sqlconnConfig, 0);
            this.Controls.SetChildIndex(this.chkSqlConnectionForConfiguration, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ucSqlConnection sqlconnDefault;
        private ucSqlConnection sqlconnConfig;
        private System.Windows.Forms.CheckBox chkSqlConnectionForConfiguration;
    }
}