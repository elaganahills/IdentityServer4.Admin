
namespace Hills.IdentityServer4.Deployment
{
    partial class Step01_Checks
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
            this.taskCurrentUser = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskIsUserAdmin = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskIsProcessAdmin = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskExecutablePath = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskUserRoles = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskIs4Path = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskIs4AdminPath = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskOperaPath = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.SuspendLayout();
            // 
            // taskCurrentUser
            // 
            this.taskCurrentUser.Info = "[Info]";
            this.taskCurrentUser.Location = new System.Drawing.Point(12, 75);
            this.taskCurrentUser.Name = "taskCurrentUser";
            this.taskCurrentUser.Size = new System.Drawing.Size(860, 48);
            this.taskCurrentUser.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskCurrentUser.TabIndex = 1;
            this.taskCurrentUser.Title = "[Title]";
            // 
            // taskIsUserAdmin
            // 
            this.taskIsUserAdmin.Info = "[Info]";
            this.taskIsUserAdmin.Location = new System.Drawing.Point(12, 129);
            this.taskIsUserAdmin.Name = "taskIsUserAdmin";
            this.taskIsUserAdmin.Size = new System.Drawing.Size(860, 48);
            this.taskIsUserAdmin.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskIsUserAdmin.TabIndex = 1;
            this.taskIsUserAdmin.Title = "[Title]";
            // 
            // taskIsProcessAdmin
            // 
            this.taskIsProcessAdmin.Info = "[Info]";
            this.taskIsProcessAdmin.Location = new System.Drawing.Point(12, 183);
            this.taskIsProcessAdmin.Name = "taskIsProcessAdmin";
            this.taskIsProcessAdmin.Size = new System.Drawing.Size(860, 48);
            this.taskIsProcessAdmin.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskIsProcessAdmin.TabIndex = 1;
            this.taskIsProcessAdmin.Title = "[Title]";
            // 
            // taskExecutablePath
            // 
            this.taskExecutablePath.Info = "[Info]";
            this.taskExecutablePath.Location = new System.Drawing.Point(12, 291);
            this.taskExecutablePath.Name = "taskExecutablePath";
            this.taskExecutablePath.Size = new System.Drawing.Size(860, 48);
            this.taskExecutablePath.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskExecutablePath.TabIndex = 1;
            this.taskExecutablePath.Title = "[Title]";
            // 
            // taskUserRoles
            // 
            this.taskUserRoles.Info = "[Info]";
            this.taskUserRoles.Location = new System.Drawing.Point(12, 237);
            this.taskUserRoles.Name = "taskUserRoles";
            this.taskUserRoles.Size = new System.Drawing.Size(860, 48);
            this.taskUserRoles.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskUserRoles.TabIndex = 1;
            this.taskUserRoles.Title = "[Title]";
            // 
            // taskIs4Path
            // 
            this.taskIs4Path.Info = "[Info]";
            this.taskIs4Path.Location = new System.Drawing.Point(12, 345);
            this.taskIs4Path.Name = "taskIs4Path";
            this.taskIs4Path.Size = new System.Drawing.Size(860, 48);
            this.taskIs4Path.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskIs4Path.TabIndex = 1;
            this.taskIs4Path.Title = "[Title]";
            // 
            // taskIs4AdminPath
            // 
            this.taskIs4AdminPath.Info = "[Info]";
            this.taskIs4AdminPath.Location = new System.Drawing.Point(9, 399);
            this.taskIs4AdminPath.Name = "taskIs4AdminPath";
            this.taskIs4AdminPath.Size = new System.Drawing.Size(860, 48);
            this.taskIs4AdminPath.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskIs4AdminPath.TabIndex = 1;
            this.taskIs4AdminPath.Title = "[Title]";
            // 
            // taskOperaPath
            // 
            this.taskOperaPath.Info = "[Info]";
            this.taskOperaPath.Location = new System.Drawing.Point(12, 453);
            this.taskOperaPath.Name = "taskOperaPath";
            this.taskOperaPath.Size = new System.Drawing.Size(860, 48);
            this.taskOperaPath.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskOperaPath.TabIndex = 1;
            this.taskOperaPath.Title = "[Title]";
            // 
            // Step01_Checks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.taskUserRoles);
            this.Controls.Add(this.taskOperaPath);
            this.Controls.Add(this.taskIs4AdminPath);
            this.Controls.Add(this.taskIs4Path);
            this.Controls.Add(this.taskExecutablePath);
            this.Controls.Add(this.taskIsProcessAdmin);
            this.Controls.Add(this.taskIsUserAdmin);
            this.Controls.Add(this.taskCurrentUser);
            this.EnableNext = true;
            this.EnablePrevious = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Step01_Checks";
            this.Text = "Step01_Checks";
            this.Title = "Hills Hidentity Server 4 installation tools. Pre-check before installation. All c" +
    "hecks need to be succesfull to proceed.";
            this.Load += new System.EventHandler(this.Step01_Checks_Load);
            this.Controls.SetChildIndex(this.taskCurrentUser, 0);
            this.Controls.SetChildIndex(this.taskIsUserAdmin, 0);
            this.Controls.SetChildIndex(this.taskIsProcessAdmin, 0);
            this.Controls.SetChildIndex(this.taskExecutablePath, 0);
            this.Controls.SetChildIndex(this.taskIs4Path, 0);
            this.Controls.SetChildIndex(this.taskIs4AdminPath, 0);
            this.Controls.SetChildIndex(this.taskOperaPath, 0);
            this.Controls.SetChildIndex(this.taskUserRoles, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucTaskResult taskCurrentUser;
        private ucTaskResult taskIsUserAdmin;
        private ucTaskResult taskIsProcessAdmin;
        private ucTaskResult taskExecutablePath;
        private ucTaskResult taskUserRoles;
        private ucTaskResult taskIs4Path;
        private ucTaskResult taskIs4AdminPath;
        private ucTaskResult taskOperaPath;
    }
}