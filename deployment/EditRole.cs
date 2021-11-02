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
    public partial class EditRole : Form
    {
        public UserIdentityRoleConfiguration Role;
        string CrRl = "\r\n";
        public EditRole()
        {
            InitializeComponent();
        }

        public EditRole(UserIdentityRoleConfiguration role) : this()
        {
            Role = role;
        }

        private void EditRole_Load(object sender, EventArgs e)
        {
            if (Role != null)
            {
                txtRole.Text = Role.Name;
                txtActiveDirectoryRole.Text = Role.ActiveDirectoryRole;               
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Role == null)
                Role = new UserIdentityRoleConfiguration();

            Role.Name = txtRole.Text;
            Role.ActiveDirectoryRole = txtActiveDirectoryRole.Text;
           
            DialogResult = DialogResult.OK;

        }
    }
}
