using Hills.Extensions;
using Hills.Extensions.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hills.IdentityServer4.Deployment
{
    public partial class Uninstall : Step
    {
        public Uninstall()
        {
            InitializeComponent();

            EnablePrevious = false;
            LabeleNext = "Close";

        }

        private void Uninstall_Load(object sender, EventArgs e)
        {
            taskRemoveService.Set(ucTaskResult.Statuses.Task, "Remove Identity Server service", "");
            taskRemoveServiceAdmin.Set(ucTaskResult.Statuses.Task, "Remove Identity Server Admin service", "");
            taskRemoveFirewallRules.Set(ucTaskResult.Statuses.Task, "Remove Identity Server firewall rules", "");
            taskRemoveFirewallRulesAdmin.Set(ucTaskResult.Statuses.Task, "Remove Identity Server Admin firewall rules", "");

            tmrExecute.Start();

        }

        public override void cmdNext_Click(object sender, EventArgs e)
        {
            this.Close(true);
        }

        private void tmrExecute_Tick(object sender, EventArgs e)
        {
            tmrExecute.Stop();
            try
            {
                if (PowerShellHelper.DeleteService("Hills.IdentityServer4"))
                    taskRemoveService.Set(ucTaskResult.Statuses.Good, "Operation completed");
            }
            catch (Exception ex)
            {
                taskRemoveService.Set(ucTaskResult.Statuses.Error, ex.Message);
            }

            try
            {
                if (PowerShellHelper.DeleteService("Hills.IdentityServer4.Admin"))
                    taskRemoveServiceAdmin.Set(ucTaskResult.Statuses.Good, "Operation completed");
            }
            catch (Exception ex)
            {
                taskRemoveServiceAdmin.Set(ucTaskResult.Statuses.Error, ex.Message);
            }

            try
            {
                if (PowerShellHelper.DeleteFirewallRule("Hills.IdentityServer4"))
                    taskRemoveFirewallRules.Set(ucTaskResult.Statuses.Good, "Operation completed");
            }
            catch (Exception ex)
            {
                taskRemoveFirewallRules.Set(ucTaskResult.Statuses.Error, ex.Message);
            }

            try
            {
                if (PowerShellHelper.DeleteFirewallRule("Hills.IdentityServer4.Admin"))
                    taskRemoveFirewallRulesAdmin.Set(ucTaskResult.Statuses.Good, "Operation completed");
            }
            catch (Exception ex)
            {
                taskRemoveFirewallRulesAdmin.Set(ucTaskResult.Statuses.Error, ex.Message);
            }
        }
    }
}
