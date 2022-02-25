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
            txtServer.Text = "WIN-KJITMKTSORO";
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
                if (string.IsNullOrEmpty(txtIdentityServerAdminRole.Text))
                {
                    MessageBox.Show("IdentityServer Admin Role is required.", "Active Directory connection test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EnableNext = false;
                    return;
                }

                
                try
                {
                    var sb = new StringBuilder();

                    var res = ActiveDirectory.CheckConnection(txtServer.Text, int.Parse(txtPort.Text), chkWindowsAutentiction.Checked,
                    chkSimpleBind.Checked, chkNegotiate.Checked, chkSecureSocketLayer.Checked, chkSigning.Checked, chkSealing.Checked, chkServerBind.Checked
                    , txtUsername.Text, txtPassword.Text, txtTestUsername.Text, txtTestPassword.Text, txtSearchBaseDN.Text);

                    if (res.Succesfull)
                        sb.AppendLine("CheckConnection: " + res.Details);
                    else
                        sb.AppendLine("CheckConnection: [error] " + res.Details);
                    //MessageBox.Show(res.Details + ((res.Succesfull) ? ". Trying to retrive user info next." : ""), "Active Directory connection test", MessageBoxButtons.OK, res.Succesfull ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    //retrive user info
                    var aa = new RootConfigurationTest();
                    aa.ActiveDirectoryConfiguration = new ActiveDirectoryConfiguration()
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

                    
                    var acs = new ActiveDirectoryService(aa);
                    DateTime ts;

                    sb.AppendLine();
                    try
                    {
                        ts = DateTime.Now;
                        var s = acs.TestPrincipalSearcher(txtTestUsername.Text);
                        sb.AppendLine(String.Format("TestPrincipalSearcher({0}): {1}", (int) (DateTime.Now - ts).TotalMilliseconds , s));
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("TestPrincipalSearcher: [error]: " + ex.Message);
                    }

                    sb.AppendLine();
                    try
                    {
                        ts = DateTime.Now;
                        var s = acs.TestFindBy(txtTestUsername.Text);
                        sb.AppendLine(String.Format("TestFindBy({0}): {1}", (int) (DateTime.Now - ts).TotalMilliseconds, s));
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("TestFindBy: [error]: " + ex.Message);
                    }

                    sb.AppendLine();
                    try
                    {
                        ts = DateTime.Now;
                        var s = acs.TestFindAllGroups();
                        sb.AppendLine(String.Format("TestFindBy({0}): {1}", (int) (DateTime.Now - ts).TotalMilliseconds, s));
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("TestFindBy: [error]: " + ex.Message);
                    }

                    sb.AppendLine();
                    try
                    {
                        ts = DateTime.Now;
                        var user = acs.GetAdUserAsync(txtTestUsername.Text, false).Result;
                        sb.AppendLine(String.Format("TestGetAdUserAsync({0}): {1}", (int) (DateTime.Now - ts).TotalMilliseconds, Newtonsoft.Json.JsonConvert.SerializeObject(user)));
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("TestGetAdUserAsync: [error]: " + ex.Message);
                    }

                    var ress = sb.ToString();
                    lastTestResult = ress;
                    lnkCompyLastResult.Enabled= true;
                    if (ress.Contains("[error]"))
                        throw new Exception(ress);

                    
                    MessageBox.Show("Test completed succesfully: " + ress, "Active Directory user info test", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EnableNext = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Active Directory user info test", MessageBoxButtons.OK, MessageBoxIcon.Error);                       
                }
                   
            } else
            {
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
