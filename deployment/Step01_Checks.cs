using Hills.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hills.IdentityServer4.Deployment
{
    public partial class Step01_Checks : Step
    {
        public Step01_Checks()
        {
            InitializeComponent();

            EnableNext = false;

            taskCurrentUser.Set(ucTaskResult.Statuses.Unknown, "Current User", "");
            taskIsUserAdmin.Set(ucTaskResult.Statuses.Unknown, "Is User Admin", "");
            taskIsProcessAdmin.Set(ucTaskResult.Statuses.Unknown, "Is Process Admin", "");
            taskUserRoles.Set(ucTaskResult.Statuses.Unknown, "User Roles", "");
            taskExecutablePath.Set(ucTaskResult.Statuses.Unknown, "Executable Path", "");
            taskIs4Path.Set(ucTaskResult.Statuses.Unknown, "IdentityServer4 Path", "");
            taskIs4AdminPath.Set(ucTaskResult.Statuses.Unknown, "IdentityServer4 Admin Path", "");
            taskOperaPath.Set(ucTaskResult.Statuses.Unknown, "Opera Path", "");
           
        }

        private void Step01_Checks_Load(object sender, EventArgs e)
        {

            taskCurrentUser.Set(ucTaskResult.Statuses.Good, Environment.UserName);

            //PowerShellHelper.EnableRemoting();

            var processadmin = PowerShellHelper.CheckCurrentProcessAdmin();
            taskIsProcessAdmin.Set(processadmin ? ucTaskResult.Statuses.Good : ucTaskResult.Statuses.Error, processadmin.ToString());

            var userroles = PowerShellHelper.GetCurrentUserRoles();
            taskUserRoles.Set(ucTaskResult.Statuses.Good, userroles);

            var useradmin = userroles.Contains("Administrators");
            taskIsUserAdmin.Set(useradmin ? ucTaskResult.Statuses.Good : ucTaskResult.Statuses.Error, useradmin.ToString());

            taskExecutablePath.Set(ucTaskResult.Statuses.Good, Helper.GetExecutablePath());

            var path = Helper.GetIdentityServer4AdminExecutablePath();
            taskIs4AdminPath.Set(File.Exists(path) ? ucTaskResult.Statuses.Good : ucTaskResult.Statuses.Error, path);

            path = Helper.GetIdentityServer4ExecutablePath();
            taskIs4Path.Set(File.Exists(path) ? ucTaskResult.Statuses.Good : ucTaskResult.Statuses.Error, path);

            path = Helper.GetOperaPath();
            taskOperaPath.Set(File.Exists(path) ? ucTaskResult.Statuses.Good : ucTaskResult.Statuses.Error, path);

            base.Invalidate();

            if (taskIsProcessAdmin.Status == ucTaskResult.Statuses.Good
                && taskIsUserAdmin.Status == ucTaskResult.Statuses.Good
                && taskIs4AdminPath.Status == ucTaskResult.Statuses.Good
                && taskIs4Path.Status == ucTaskResult.Statuses.Good)
                base.EnableNext = true;

            //OperaExtensions.OpenBrowserDelayed(Helper.GetOperaPath(), Program.EndPoints.First().Address, 500);
            //OperaExtensions.OpenBrowserDelayed(Helper.GetOperaPath(), Program.EndPointsAdmin.First().Address, 500);
        }

        public override void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {
                //close current form and open next
                new Step02_SqlConnection().Show();
                this.Close(false);

            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

       
    }
}
