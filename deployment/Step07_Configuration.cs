using Hills.Extensions;
using Hills.Extensions.Windows;
using Newtonsoft.Json;
using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
using Skoruba.IdentityServer4.Shared.Configuration.Deploy;
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
using is4models = IdentityServer4.Models;

namespace Hills.IdentityServer4.Deployment
{
    public partial class Step07_Configuration : Step
    {
        public Step07_Configuration()
        {
            InitializeComponent();

            EnableNext = false;
        }

        private void Step05_Configuration_Load(object sender, EventArgs e)
        {
            taskWriteConfigFile.Set(ucTaskResult.Statuses.Task, "Write initial configuration", "");
            taskConfigureSqlUser.Set(ucTaskResult.Statuses.Task, "Configure Sql Server", "");
            taskConfigureFirewall.Set(ucTaskResult.Statuses.Task, "Configure Firewall IS4", "");
            taskConfigureFirewallAdmin.Set(ucTaskResult.Statuses.Task, "Configure Firewall IS4 Admin", "");
            taskInstallService.Set(ucTaskResult.Statuses.Task, "Install Service IS4", "");
            taskInstallServiceAdmin.Set(ucTaskResult.Statuses.Task, "Install Service IS4 Admin", "");
            taskStartService.Set(ucTaskResult.Statuses.Task, "Start Service IS4", "");
            taskStartServiceAdmin.Set(ucTaskResult.Statuses.Task, "Start Service IS4 Admin", "");
            taskWaitService.Set(ucTaskResult.Statuses.Task, "Wait for service to run", "");
            taskWaitServiceAdmin.Set(ucTaskResult.Statuses.Task, "Wait for admin service to run", "");
            taskOpenBrowser.Set(ucTaskResult.Statuses.Task, "Open browser", "");

        }

        private void cmdExecute_Click(object sender, EventArgs e)
        {
            if (!WriteConfigFile())
                return;

            if (!ConfigureSqlUser())
                return;

            if (!ConfigureFirewall())
                return;

            if (!ConfigureFirewallAdmin())
                return;

            if (!InstallService())
                return;           

            if (!InstallServiceAdmin())
                return;

            if (!StartService())
                return;

            System.Threading.Thread.Sleep(5000);

            if (!StartServiceAdmin())
                return;

            if (!WaitService())
                return;

            if (!WaitServiceAdmin())
                return;

            if (!OpenBrowser())
                return;

            cmdExecute.Enabled = false;
            EnableNext = true;
        }

        bool OpenBrowser()
        {
            try
            {
                OperaExtensions.OpenBrowserDelayed(Helper.GetOperaPath(), Program.EndPoints.First().Address, 500);
                OperaExtensions.OpenBrowserDelayed(Helper.GetOperaPath(), Program.EndPointsAdmin.First().Address, 500);

                taskOpenBrowser.Set(ucTaskResult.Statuses.Good, "Operation completed");

                return true;
            }
            catch (Exception ex)
            {
                taskOpenBrowser.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool WaitServiceAdmin()
        {
            try
            {
                taskWaitServiceAdmin.Set(ucTaskResult.Statuses.Wait, "Waiting for service");

                Extensions.Models.TestResult testResult = null;
                for (int x = 0; x < 10; x++)
                {
                    testResult = HttpExtensions.TestUrl(Program.EndPointsAdmin.First().Address + "/images/hhslogo01.png");
                    if (testResult.Succesfull)
                    {
                        taskWaitServiceAdmin.AppendInfo(ucTaskResult.Statuses.Good, "Endpoint reached.");
                        return true;
                    }
                    taskWaitServiceAdmin.AppendInfo(".");
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                }

                taskWaitServiceAdmin.Set(ucTaskResult.Statuses.Error, testResult.Details);

                return false;
            }
            catch (Exception ex)
            {
                taskWaitServiceAdmin.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool WaitService()
        {
            try
            {
                taskWaitService.Set(ucTaskResult.Statuses.Wait, "Waiting for service");

                Extensions.Models.TestResult testResult = null;
                for (int x = 0; x<10; x++)
                {
                    testResult = HttpExtensions.TestUrl(Program.EndPoints.First().Address + "/.well-known/openid-configuration");
                    if (testResult.Succesfull)
                    {
                        taskWaitService.AppendInfo(ucTaskResult.Statuses.Good, "Endpoint reached.");
                        return true;
                    }
                    taskWaitService.AppendInfo(".");
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                }

                taskWaitService.Set(ucTaskResult.Statuses.Error, testResult.Details);

                return false;
            }
            catch (Exception ex)
            {
                taskWaitService.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool StartServiceAdmin()
        {
            try
            {
                if (!PowerShellHelper.RunService("Hills.IdentityServer4.Admin"))
                {
                    System.Threading.Thread.Sleep(5000);
                    if (!PowerShellHelper.RunService("Hills.IdentityServer4.Admin"))
                    {
                        System.Threading.Thread.Sleep(5000);
                        if (!PowerShellHelper.RunService("Hills.IdentityServer4.Admin"))
                        {
                            throw new Exception("Powershell error");
                        }
                    }
                }

                taskStartServiceAdmin.Set(ucTaskResult.Statuses.Good, "Operation completed succesfully");
                return true;
            }
            catch (Exception ex)
            {
                taskStartServiceAdmin.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool StartService()
        {
            try
            {
                if (!PowerShellHelper.RunService("Hills.IdentityServer4"))
                {
                    System.Threading.Thread.Sleep(5000);
                    if (!PowerShellHelper.RunService("Hills.IdentityServer4"))
                    {
                        System.Threading.Thread.Sleep(5000);
                        if (!PowerShellHelper.RunService("Hills.IdentityServer4"))
                        {
                            throw new Exception("Powershell error");
                        }
                    }
                }
                    

                taskStartService.Set(ucTaskResult.Statuses.Good, "Operation completed succesfully");
                return true;
            }
            catch (Exception ex)
            {
                taskStartService.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool InstallServiceAdmin()
        {
            try
            {
                if (!PowerShellHelper.RegisterService("Hills.IdentityServer4.Admin", Helper.GetIdentityServer4AdminExecutablePath(),
                   null, "Hills Identity Admin", PowerShellHelper.StartupTypes.Automatic,
                   "Hills Health Solutions module for services identity administration", true))
                    throw new Exception("Powershell error");

                taskInstallServiceAdmin.Set(ucTaskResult.Statuses.Good, "Operation completed succesfully");
                return true;
            }
            catch (Exception ex)
            {
                taskInstallServiceAdmin.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool InstallService()
        {
            try
            {
                if (!PowerShellHelper.RegisterService("Hills.IdentityServer4", Helper.GetIdentityServer4ExecutablePath(),
                   null, "Hills Identity", PowerShellHelper.StartupTypes.Automatic,
                   "Hills Health Solutions module for services identity", true))
                    throw new Exception("Powershell error");

                taskInstallService.Set(ucTaskResult.Statuses.Good, "Operation completed succesfully");
                return true;
            }
            catch (Exception ex)
            {
                taskInstallService.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool ConfigureFirewallAdmin()
        {
            try
            {
                if (!PowerShellHelper.CreateFirewallExeption("Hills.IdentityServer4.Admin", "Hills Identity Admin Module Inbound", PowerShellHelper.FirewallDirection.Inbound, Helper.GetIdentityServer4AdminExecutablePath()))
                    throw new Exception("Powershell error");
                if (!PowerShellHelper.CreateFirewallExeption("Hills.IdentityServer4.Admin", "Hills Identity Admin Module Outbound", PowerShellHelper.FirewallDirection.Outbound, Helper.GetIdentityServer4AdminExecutablePath()))
                    throw new Exception("Powershell error");

                taskConfigureFirewallAdmin.Set(ucTaskResult.Statuses.Good, "Operation completed succesfully");
                return true;
            }
            catch (Exception ex)
            {
                taskConfigureFirewallAdmin.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool ConfigureFirewall()
        {
            try
            {
                if (!PowerShellHelper.CreateFirewallExeption("Hills.IdentityServer4", "Hills Identity Module Inbound", PowerShellHelper.FirewallDirection.Inbound, Helper.GetIdentityServer4ExecutablePath()))
                    throw new Exception("Powershell error");
                if (!PowerShellHelper.CreateFirewallExeption("Hills.IdentityServer4", "Hills Identity Module Outbound", PowerShellHelper.FirewallDirection.Outbound, Helper.GetIdentityServer4ExecutablePath()))
                    throw new Exception("Powershell error");

                taskConfigureFirewall.Set(ucTaskResult.Statuses.Good, "Operation completed succesfully");
                return true;
            }
            catch (Exception ex)
            {
                taskConfigureFirewall.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool ConfigureSqlUser()
        {
            try
            {
                if (Program.SqlConnection.DataSource.StartsWith(".")){
                    var res = SqlServerExtensions.ConfigWindowsUserAsAdmin(Program.SqlConnection_ConfigOnly ?? Program.SqlConnection);
                    taskConfigureSqlUser.Set(res.Succesfull ? ucTaskResult.Statuses.Good : ucTaskResult.Statuses.Error, res.Details);
                    return res.Succesfull;
                } else
                {
                    taskConfigureSqlUser.Set( ucTaskResult.Statuses.Good, "Not needed for network SQL Server");
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                taskConfigureSqlUser.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        bool WriteConfigFile()
        {
            try
            {
                var isdc = new IdentityServerDataContainer();
                var isd = new IdentityServerData();
                isdc.IdentityServerData = isd;
                isd.Clients = Program.Clients;
                if (isd.Clients.Any())
                {
                    //we need to create api and relative resources
                    isd.ApiScopes = new List<is4models.ApiScope>();

                    foreach (var cl in isd.Clients)
                    {
                        isd.ApiScopes.Add(new is4models.ApiScope() {
                            Name = cl.ClientName + "_api",
                            DisplayName = cl.ClientName + "_api",
                            Required = true,
                            UserClaims = new string[] { "role", "name" },
                        });
                        isd.ApiResources.Add(new is4models.ApiResource()
                        {
                            Name = cl.ClientName + "_api",
                            Scopes = new string[] { cl.ClientName + "_api", },
                        });

                    }
                }
                isdc.IdentityData = new IdentityDataConfiguration();
                isdc.IdentityData.Roles = Program.Roles;

                // save client also to local file
                using (StreamWriter file = new StreamWriter(Helper.GetProjectFilePath(@"deploy.identityserverdata.json"), false))
                    new JsonSerializer() { NullValueHandling = NullValueHandling.Ignore }.Serialize(file, isdc);

                // deserialize JSON directly from a file
                using (StreamWriter file = new StreamWriter(Helper.GetIdentityServer4AdminDataFilePath(), false))
                    new JsonSerializer() { NullValueHandling = NullValueHandling.Ignore }.Serialize(file, isdc);                                 

                //Admin deploy file
                var clientsettings = Program.Clients.FirstOrDefault(c => c.ClientId == "hills_identity_admin");
                var deployadmin = new DeployAppSettingsAdmin();
                deployadmin.ConnectionStrings = new ConnectionStringsConfiguration();
                deployadmin.ConnectionStrings.SetConnections(Program.SqlConnection.ConnectionString);
                deployadmin.AdminConfiguration = new AdminConfigurationDeploy();
                deployadmin.AdminConfiguration.ClientSecret = clientsettings.ClientSecrets.FirstOrDefault().Value;
                deployadmin.AdminConfiguration.IdentityAdminRedirectUri = Program.EndPointsAdmin.FirstOrDefault().Address + @"/signin-oidc";
                deployadmin.AdminConfiguration.IdentityServerBaseUrl = Program.EndPoints.FirstOrDefault().Address;
                deployadmin.EndPoints = Program.EndPointsAdmin;
                deployadmin.ActiveDirectoryConfiguration = Program.ActiveDirectoryConfiguration;
       

                using (StreamWriter file = new StreamWriter(Helper.GetIdentityServer4AdminAppSettingsFilePath(), false))
                    new JsonSerializer() { NullValueHandling = NullValueHandling.Ignore }.Serialize(file, deployadmin);

                using (StreamWriter file = new StreamWriter(Helper.GetProjectFilePath(@"deploy.endpointsadmin.json"), false))
                    new JsonSerializer() { NullValueHandling = NullValueHandling.Ignore }.Serialize(file, Program.EndPointsAdmin);

                //Identity deploy file
                var deployid = new DeployAppSettings();
                deployid.ConnectionStrings = new ConnectionStringsConfiguration();
                deployid.ConnectionStrings.SetConnections(Program.SqlConnection.ConnectionString);
                deployid.AdminConfiguration = new  AdminConfiguration();
                deployid.AdminConfiguration.IdentityAdminBaseUrl = Program.EndPointsAdmin.FirstOrDefault().Address;
                deployid.EndPoints = Program.EndPoints;
                deployid.ActiveDirectoryConfiguration = Program.ActiveDirectoryConfiguration;

                using (StreamWriter file = new StreamWriter(Helper.GetIdentityServer4AppSettingsFilePath(), false))
                    new JsonSerializer() { NullValueHandling = NullValueHandling.Ignore }.Serialize(file, deployid);


                taskWriteConfigFile.Set(ucTaskResult.Statuses.Good, "Operation completed succesfully");
                return true;
            }
            catch (Exception ex)
            {
                taskWriteConfigFile.Set(ucTaskResult.Statuses.Error, ex.Message);
                return false;
            }
        }

        public override void cmdNext_Click(object sender, EventArgs e)
        {
            //close current form and open previous
            new Step08_End().Show();
            this.Close(false);
        }

        public override void cmdPrevious_Click(object sender, EventArgs e)
        {
            try
            {

                //close current form and open next
                new Step05_PreConfiguredServices().Show();
                this.Close(false);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
          
        }
    }
}
