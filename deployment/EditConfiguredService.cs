using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.IdentityServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is4m =  IdentityServer4.Models;

namespace Hills.IdentityServer4.Deployment
{
    public partial class EditConfiguredService : Form
    {
        public Client Client;
        string CrRl = "\r\n";
        public EditConfiguredService()
        {
            InitializeComponent();
        }

        public EditConfiguredService(Client client) : this()
        {
            Client = client;
        }

        private void EditConfiguredService_Load(object sender, EventArgs e)
        {
            if (Client != null)
            {
                txtClientId.Text = Client.ClientId;
                txtClientName.Text = Client.ClientName;
                txtClientSecret.Text = Client.ClientSecrets.FirstOrDefault()?.Value;
                txtRedirectUris.Text = string.Join(CrRl, Client.RedirectUris);
                txtPostLogoutRedirectUris.Text = string.Join(CrRl, Client.PostLogoutRedirectUris);
                txtAllowedCorsOrigins.Text = string.Join(CrRl, Client.AllowedCorsOrigins);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Client == null)
                Client = new Client();

            Client.ClientId = txtClientId.Text;
            Client.ClientName = txtClientName.Text;
            Client.RedirectUris = txtRedirectUris.Text.Split(CrRl.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Client.PostLogoutRedirectUris = txtPostLogoutRedirectUris.Text.Split(CrRl.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Client.AllowedCorsOrigins = txtAllowedCorsOrigins.Text.Split(CrRl.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Client.ClientSecrets.Clear();
            if (!string.IsNullOrEmpty(txtClientSecret.Text))
                Client.ClientSecrets.Add(new is4m.Secret() { Value = txtClientSecret.Text });
            DialogResult = DialogResult.OK;

        }
    }
}
