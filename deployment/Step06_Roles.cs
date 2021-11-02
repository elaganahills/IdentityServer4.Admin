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
using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;

namespace Hills.IdentityServer4.Deployment
{
    public partial class Step06_Roles : Step
    {
        public Step06_Roles()
        {
            InitializeComponent();

            EnableNext = false;

            //adjust redirect urls
            if (!Program.Roles.Any())
            {
                Program.Roles.Add(new UserIdentityRoleConfiguration() { Name = "Administrator" });
                Program.Roles.Add(new UserIdentityRoleConfiguration() { Name = "Supervisor" });
                Program.Roles.Add(new UserIdentityRoleConfiguration() { Name = "User" });
                Program.Roles.Add(new UserIdentityRoleConfiguration() { Name = "HillsIdentityAdminAdministrator",
                    ActiveDirectoryRole = Program.ActiveDirectoryConfiguration?.IdentityServerAdminRole
                });

            }

            RefreshTable();
        }

        private void Step06_Roles_Load(object sender, EventArgs e)
        {

        }

        void RefreshTable()
        {
            lstRoles.Items.Clear();

            foreach (var ep in Program.Roles)
                lstRoles.Items.Add(new ListViewItem(new string[]
                { ep.Name,ep.ActiveDirectoryRole})
                { Tag = ep });

            EnableNext = Program.Roles.Any();
        }

        UserIdentityRoleConfiguration SelectedItem()
        {
            if (lstRoles.SelectedItems.Count == 1)
                return (UserIdentityRoleConfiguration)lstRoles.SelectedItems[0].Tag;
            else
                return null;
        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender == lnkAdd)
                lstRoles.SelectedItems.Clear();
            var aep = new EditRole(SelectedItem());
            if (aep.ShowDialog() == DialogResult.OK)
            {
                if (!Program.Roles.Contains(aep.Role))
                    Program.Roles.Add(aep.Role);
                RefreshTable();
            }
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var si = SelectedItem();
            if (si != null)
            {
                Program.Roles.Remove(si);
                RefreshTable();
            }
        }


        public override void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {

                //close current form and open next
                new Step07_Configuration().Show();
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
            new Step05_PreConfiguredServices().Show();
            this.Close(false);
        }


    }
}
