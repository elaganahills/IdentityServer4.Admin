using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration;
using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.IdentityServer;
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
    public partial class Step05_PreConfiguredServices : Step
    {
        public Step05_PreConfiguredServices()
        {
            InitializeComponent();

            EnableNext = false;

            //adjust redirect urls
            var clientsettings = Program.Clients.FirstOrDefault(c => c.ClientId == "hills_identity_admin");
            clientsettings.RedirectUris = Program.EndPointsAdmin.Select(ep => ep.Address + "/signin-oidc").ToArray();
            clientsettings.PostLogoutRedirectUris = Program.EndPointsAdmin.Select(ep => ep.Address + "/signout-callback-oidc").ToArray();
            clientsettings.AllowedCorsOrigins = Program.EndPointsAdmin.Select(ep => ep.Address).ToArray();
            clientsettings.ClientUri = Program.EndPointsAdmin.First().Address;
            clientsettings.FrontChannelLogoutUri = Program.EndPointsAdmin.First().Address + "/signout-oidc";

            RefreshTable();
        }

        private void Step04_PreConfiguredServices_Load(object sender, EventArgs e)
        {

        }

        void RefreshTable()
        {
            lstClients.Items.Clear();

            foreach (var ep in Program.Clients)
                lstClients.Items.Add(new ListViewItem(new string[]
                { ep.ClientId,ep.ClientName})
                { Tag = ep });

            EnableNext = Program.Clients.Any(c => c.ClientId == "hills_identity_admin");
        }

        Client SelectedItem()
        {
            if (lstClients.SelectedItems.Count == 1)
                return (Client)lstClients.SelectedItems[0].Tag;
            else
                return null;
        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender == lnkAdd)
                lstClients.SelectedItems.Clear();
            var aep = new EditConfiguredService(SelectedItem());
            if (aep.ShowDialog() == DialogResult.OK)
            {
                if (!Program.Clients.Contains(aep.Client))
                    Program.Clients.Add(aep.Client);
                RefreshTable();
            }
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var si = SelectedItem();
            if (si != null)
                Program.Clients.Remove(si);
        }


        public override void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {

                //close current form and open next
                new Step06_Configuration().Show();
                this.Close(false);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public override void cmdPrevious_Click(object sender, EventArgs e)
        {
            //close current form and open previous
            new Step04_EndPoints().Show();
            this.Close(false);
        }
    }
}
