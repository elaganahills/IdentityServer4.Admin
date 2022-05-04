using Hills.Extensions;
using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration;
using Skoruba.IdentityServer4.Shared.Configuration.Configuration;
using Skoruba.IdentityServer4.STS.Identity.Configuration;
using Skoruba.IdentityServer4.STS.Identity.Services;
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
    public partial class Step03_ActiveDirectory : Step
    {
        public Step03_ActiveDirectory()
        {
            InitializeComponent();

            EnableNext = true;
        }

        private void Step03_ActiveDirectory_Load(object sender, EventArgs e)
        {
#if DEBUG
            chkEnable.Checked = true;
            txtServer.Text = "7.103.222.179";
            txtUsername.Text = "Administrator";
            txtPassword.Text = "Merlon99";
            txtTestUsername.Text = "Administrator";
            txtTestPassword.Text = "Merlon99";
            txtIdentityServerAdminRole.Text = "Account Manger";
#endif
        }

        public override void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {

                //Save Sql Info
                Program.ActiveDirectoryConfiguration = new ActiveDirectoryConfiguration()
                {
                    Server = txtServer.Text,
                    Enabled = chkEnable.Checked,
                    Port = int.Parse(txtPort.Text),
                    UseSecureSocketLayer = chkSecureSocketLayer.Checked,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    SearchBaseDN = txtSearchBaseDN.Text,
                    WindowsAutentication = chkWindowsAutentiction.Checked,
                    LoadAttributes = chkLoadAtributes.Checked,
                    UserAttributes = AttributesToList(txtUserAtributes.Text),
                    GroupAttributes = AttributesToList(txtGroupAtributes.Text),
                    IdentityServerAdminRole = txtIdentityServerAdminRole.Text
                };

                //close current form and open next
                new Step04_EndPoints().Show();
                this.Close(false);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        List<string> AttributesToList(string csvs)
        {
            if (string.IsNullOrEmpty(csvs))
                return null;

            return new List<string>(csvs.Split(";,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()));
        }

        public override void cmdPrevious_Click(object sender, EventArgs e)
        {
            //close current form and open previous
            new Step02_SqlConnection().Show();
            this.Close(false);
        }

      
        private void sqlconnDefault_OnUpdateStatus(object sender, InfoEventArrgs e)
        {
            base.EnableNext = e.Value;
        }

        string lastTestResult;
        private void cmdTestConnection_Click(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                EnableNext = false;

                if (string.IsNullOrEmpty(txtIdentityServerAdminRole.Text))
                {
                    MessageBox.Show("IdentityServer Admin Role is required.", "Active Directory connection test", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                    return;
                }

                var adc = new ActiveDirectoryConfiguration()
                {
                    Enabled = true,
                    Server = txtServer.Text,
                    Port = int.Parse(txtPort.Text),
                    SearchBaseDN = txtSearchBaseDN.Text,
                    WindowsAutentication = chkWindowsAutentiction.Checked,
                    UseSimpleBind = chkSimpleBind.Checked,
                    UseNegotiate = chkNegotiate.Checked,
                    UseSecureSocketLayer = chkSecureSocketLayer.Checked,
                    UseSigning = chkSigning.Checked,
                    UseSealing = chkSealing.Checked,
                    UseServerBind = chkServerBind.Checked,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    LoadAttributes = chkLoadAtributes.Checked,
                    UserAttributes = txtUserAtributes.Text.Split(",;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList(),
                    GroupAttributes = txtGroupAtributes.Text.Split(",;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList(),

                };

                if (new ActiveDirectoryTest(adc, txtTestUsername.Text,txtTestPassword.Text).ShowDialog() == DialogResult.OK)
                    EnableNext = true;

            }
              
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
                EnableNext = false;
            else
                EnableNext = true;
        }

        private void chkSigning_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lnkCompyLastResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TextCopy.ClipboardService.SetText(lastTestResult);

        }
    }
}
