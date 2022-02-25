
namespace Hills.IdentityServer4.Deployment
{
    partial class Uninstall
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
            this.components = new System.ComponentModel.Container();
            this.taskRemoveFirewallRulesAdmin = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskRemoveFirewallRules = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskRemoveServiceAdmin = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.taskRemoveService = new Hills.IdentityServer4.Deployment.ucTaskResult();
            this.tmrExecute = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // taskRemoveFirewallRulesAdmin
            // 
            this.taskRemoveFirewallRulesAdmin.Info = "[Info]";
            this.taskRemoveFirewallRulesAdmin.Location = new System.Drawing.Point(9, 213);
            this.taskRemoveFirewallRulesAdmin.Name = "taskRemoveFirewallRulesAdmin";
            this.taskRemoveFirewallRulesAdmin.Size = new System.Drawing.Size(866, 40);
            this.taskRemoveFirewallRulesAdmin.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskRemoveFirewallRulesAdmin.TabIndex = 3;
            this.taskRemoveFirewallRulesAdmin.Title = "[Title]";
            // 
            // taskRemoveFirewallRules
            // 
            this.taskRemoveFirewallRules.Info = "[Info]";
            this.taskRemoveFirewallRules.Location = new System.Drawing.Point(9, 167);
            this.taskRemoveFirewallRules.Name = "taskRemoveFirewallRules";
            this.taskRemoveFirewallRules.Size = new System.Drawing.Size(866, 40);
            this.taskRemoveFirewallRules.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskRemoveFirewallRules.TabIndex = 4;
            this.taskRemoveFirewallRules.Title = "[Title]";
            // 
            // taskRemoveServiceAdmin
            // 
            this.taskRemoveServiceAdmin.Info = "[Info]";
            this.taskRemoveServiceAdmin.Location = new System.Drawing.Point(9, 121);
            this.taskRemoveServiceAdmin.Name = "taskRemoveServiceAdmin";
            this.taskRemoveServiceAdmin.Size = new System.Drawing.Size(866, 40);
            this.taskRemoveServiceAdmin.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskRemoveServiceAdmin.TabIndex = 5;
            this.taskRemoveServiceAdmin.Title = "[Title]";
            // 
            // taskRemoveService
            // 
            this.taskRemoveService.Info = "[Info]";
            this.taskRemoveService.Location = new System.Drawing.Point(9, 75);
            this.taskRemoveService.Name = "taskRemoveService";
            this.taskRemoveService.Size = new System.Drawing.Size(866, 40);
            this.taskRemoveService.Status = Hills.IdentityServer4.Deployment.ucTaskResult.Statuses.Unknown;
            this.taskRemoveService.TabIndex = 6;
            this.taskRemoveService.Title = "[Title]";
            // 
            // tmrExecute
            // 
            this.tmrExecute.Interval = 500;
            this.tmrExecute.Tick += new System.EventHandler(this.tmrExecute_Tick);
            // 
            // Uninstall
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.taskRemoveFirewallRulesAdmin);
            this.Controls.Add(this.taskRemoveFirewallRules);
            this.Controls.Add(this.taskRemoveServiceAdmin);
            this.Controls.Add(this.taskRemoveService);
            this.EnableNext = true;
            this.EnablePrevious = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Uninstall";
            this.Text = "Uninstall";
            this.Title = "Initial uninstallation procedure steps. To continue close this window.";
            this.Load += new System.EventHandler(this.Uninstall_Load);
            this.Controls.SetChildIndex(this.taskRemoveService, 0);
            this.Controls.SetChildIndex(this.taskRemoveServiceAdmin, 0);
            this.Controls.SetChildIndex(this.taskRemoveFirewallRules, 0);
            this.Controls.SetChildIndex(this.taskRemoveFirewallRulesAdmin, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucTaskResult taskRemoveFirewallRulesAdmin;
        private ucTaskResult taskRemoveFirewallRules;
        private ucTaskResult taskRemoveServiceAdmin;
        private ucTaskResult taskRemoveService;
        private System.Windows.Forms.Timer tmrExecute;
    }
}