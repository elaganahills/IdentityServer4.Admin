using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.IdentityServer;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
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
    public partial class EditDns : Form
    {
        public string Dns;
        string CrRl = "\r\n";
        public EditDns()
        {
            InitializeComponent();
        }

        public EditDns(string dns) : this()
        {
            Dns = dns;
        }

        private void EditDns_Load(object sender, EventArgs e)
        {
                txtDns.Text = Dns;

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

            Dns = txtDns.Text;
           
            DialogResult = DialogResult.OK;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
