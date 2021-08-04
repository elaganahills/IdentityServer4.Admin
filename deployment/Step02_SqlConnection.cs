using Hills.Extensions;
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
    public partial class Step02_SqlConnection : Step
    {
        public Step02_SqlConnection()
        {
            InitializeComponent();

            EnableNext = false;
        }

        private void Step02_SqlConnection_Load(object sender, EventArgs e)
        {

        }

        public override void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {
                //Save Sql Info
                Program.SqlConnection = sqlconnDefault.SqlConnection;

                if (chkSqlConnectionForConfiguration.Checked)
                    Program.SqlConnection = sqlconnConfig.SqlConnection;
                else
                    Program.SqlConnection_ConfigOnly = null;


                //close current form and open next
                new Step03_EndPoints().Show();
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
            new Step01_Checks().Show();
            this.Close(false);
        }

        private void chkSqlConnectionForConfiguration_CheckedChanged(object sender, EventArgs e)
        {
            sqlconnConfig.Visible = chkSqlConnectionForConfiguration.Checked;
        }

        private void sqlconnDefault_OnUpdateStatus(object sender, InfoEventArrgs e)
        {
            base.EnableNext = e.Value;
        }
    }
}
