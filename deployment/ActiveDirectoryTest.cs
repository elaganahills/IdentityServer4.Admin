using Hills.Extensions;
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
    public partial class ActiveDirectoryTest : Form
    {
       

        ActiveDirectoryConfiguration _adsf;
        string _testUsername, _testPassword;

        public ActiveDirectoryTest()
        {
            InitializeComponent();
        }
        public ActiveDirectoryTest(ActiveDirectoryConfiguration adsf, string testUsername, string testPassword) : this()
        {
            _adsf = adsf;
            _testUsername = testUsername;
            _testPassword = testPassword;
        }

        private void ActiveDirectoryTest_Load(object sender, EventArgs e)
        {

        }

        bool error;

        private void ActiveDirectoryTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!error)
                DialogResult = DialogResult.OK;
        }

        private void ActiveDirectoryTest_Shown(object sender, EventArgs e)
        {
            error = false;
            DateTime ts;
            var rct = new RootConfigurationTest();
            rct.ActiveDirectoryConfiguration = _adsf;
            var acs = new ActiveDirectoryService(rct);

            //Connection test
            ts = DateTime.Now;
            var res = ActiveDirectory.CheckConnection(_adsf.Server, _adsf.Port, _adsf.WindowsAutentication,
                 _adsf.UseSimpleBind, _adsf.UseNegotiate, _adsf.UseSecureSocketLayer, _adsf.UseSigning, _adsf.UseSealing, _adsf.UseServerBind
                 , _adsf.Username, _adsf.Password, _testUsername, _testPassword, _adsf.SearchBaseDN);
            
            lblCheckConnectionDuration.Text = "Duration: " + (DateTime.Now - ts).ToPrettyFormat();
            txtCheckConnectionResult.Text = ((res.Succesfull)? "[success]": "[error]") + ("\r\n" + res.Details);
            if (!res.Succesfull)
                error = true;

            ts = DateTime.Now;
            try
            {                
                var s = acs.TestPrincipalSearcher(_testUsername);
                txtTestPrincipalSearcherResult.Text = "[success]\r\n" + s;
            }
            catch (Exception ex)
            {
                txtTestPrincipalSearcherResult.Text = "[error]\r\n" + ex.Message;
                error = true;
            }
            lblTestPrincipalSearcherDuration.Text = "Duration: " + (DateTime.Now - ts).ToPrettyFormat();


            ts = DateTime.Now;
            try
            {
                var s = acs.TestFindBy(_testUsername);
                txtTestFindByResult.Text = "[success]\r\n" + s;
            }
            catch (Exception ex)
            {
                txtTestFindByResult.Text = "[error]\r\n" + ex.Message;
                error = true;
            }
            lblTestFindByDuration.Text = "Duration: " + (DateTime.Now - ts).ToPrettyFormat();


            ts = DateTime.Now;
            try
            {
                var s = acs.TestFindAllGroups();
                txtTestFindAllGroupsResult.Text = "[success]\r\n" + s;
            }
            catch (Exception ex)
            {
                txtTestFindAllGroupsResult.Text = "[error]\r\n" + ex.Message;
                error = true;
            }
            lblTestFindAllGroupsDuration.Text = "Duration: " + (DateTime.Now - ts).ToPrettyFormat();

            ts = DateTime.Now;
            try
            {
                var s = acs.GetAdUserAsync(_testUsername, false).Result;
                var j = Newtonsoft.Json.JsonConvert.SerializeObject(s, new Newtonsoft.Json.JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore }); 
                txtTestGetAdUserAsyncResult.Text = "[success]\r\n" + j;
            }
            catch (Exception ex)
            {
                txtTestGetAdUserAsyncResult.Text = "[error]\r\n" + ex.Message;
                error = true;
            }
            lblTestGetAdUserAsyncDuration.Text = "Duration: " + (DateTime.Now - ts).ToPrettyFormat();          


        }
    }
}
