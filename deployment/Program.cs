using Hills.Extensions.Models;
using Newtonsoft.Json;
using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration;
using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.IdentityServer;
using Skoruba.IdentityServer4.Shared.Configuration.Deploy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hills.Extensions.Models;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hills.Extensions;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;

namespace Hills.IdentityServer4.Deployment
{

    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PowerShellHelper.ModulesPath = Helper.GetExecutableDirectory() + "PowerShellModules\\";

            //load some data from files
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(Helper.GetProjectFilePath(@"deploy.identityserverdata.json")))
            {
                IdentityServerDataContainer movie2 = (IdentityServerDataContainer)new JsonSerializer().Deserialize(file, typeof(IdentityServerDataContainer));
                Clients = movie2.IdentityServerData.Clients;
            }

            if (args.Contains("--open"))
            {
                using (StreamReader file = File.OpenText(Helper.GetProjectFilePath(@"deploy.endpointsadmin.json")))
                {
                    EndPointsAdmin = (List<EndPointConfiguration>)new JsonSerializer().Deserialize(file, typeof(List<EndPointConfiguration>));
                }
                OperaExtensions.OpenBrowserDelayed(Helper.GetOperaPath(), Program.EndPointsAdmin.First().Address, 500);
                return;
            } else if (args.Contains("--uninstall"))
            {
                new Uninstall().Show();
            } else {
                //add test endpoint
                EndPoints.Add(new EndPointConfiguration() {
                    Name = "Default",
                    IpAddress = "0.0.0.0",
                    Port = 6010,
                    UseHttps = true,
                    Certificate_Type = EndPointConfiguration.CertificateTypes.Store,
                    Certificate_StoreName = "Root",
                    Certificate_Subject = "CN=localhost"
                });

                EndPointsAdmin.Add(new EndPointConfiguration()
                {
                    Name = "Default",
                    IpAddress = "0.0.0.0",
                    Port = 6011,
                    UseHttps = true,
                    Certificate_Type = EndPointConfiguration.CertificateTypes.Store,
                    Certificate_StoreName = "Root",
                    Certificate_Subject = "CN=localhost"
                });
                new Step01_Checks().Show();
            }
            Application.Run();
        }

        public static List<Client> Clients = new List<Client>();
        public static List<UserIdentityRoleConfiguration> Roles = new List<UserIdentityRoleConfiguration>();
        public static List<EndPointConfiguration> EndPoints = new List<EndPointConfiguration>();
        public static List<EndPointConfiguration> EndPointsAdmin = new List<EndPointConfiguration>();

        public static ActiveDirectoryConfiguration ActiveDirectoryConfiguration { get; set; }

        public static SqlConnectionInfo SqlConnection { get; set; }
        public static SqlConnectionInfo SqlConnection_ConfigOnly { get; set; }


        public static void Close()
        {
            //this is required to exit all the threads
            Environment.Exit(Environment.ExitCode);
        }
    }
}
