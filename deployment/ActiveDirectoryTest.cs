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


            //-------------TEST CONNECTION CREDENTIALS-------------------
            ts = DateTime.Now;
            var res1 = ActiveDirectory.CheckConnection(_adsf.Server, _adsf.Port, _adsf.WindowsAutentication, _adsf.Username, _adsf.Password);
            var res2 = ActiveDirectory.CheckConnection(_adsf.Server, _adsf.Port, _adsf.WindowsAutentication, _testUsername, _testPassword);

            lblCheckConnectionDuration.Text = "Duration: " + (DateTime.Now - ts).ToPrettyFormat();
            txtCheckConnectionResult.Text = "Search user: " + ((res1.Succesfull)? "[success]": "[error]") + ("\r\n" + res1.Details);
            txtCheckConnectionResult.Text += "\r\nTest user: " + ((res2.Succesfull) ? "[success]" : "[error]") + ("\r\n" + res2.Details);
            if (!res1.Succesfull || !res2.Succesfull)
                error = true;
            //--------------------------------------------------------------


 
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
