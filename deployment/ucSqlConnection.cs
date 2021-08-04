using Hills.Extensions;
using Hills.Extensions.Models;
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
    public partial class ucSqlConnection : UserControl
    {
        public delegate void StatusUpdateHandler(object sender, InfoEventArrgs e);
        public event StatusUpdateHandler OnUpdateStatus;
        public bool TestWithoutDatabase { get; set; }

        public SqlConnectionInfo SqlConnection {
            get => new SqlConnectionInfo(txtServer.Text, chkIntegratedSecurity.Checked, txtUsername.Text, txtPassword.Text, txtDatabase.Text);
            set
            {
                txtServer.Text = value.DataSource;
                chkIntegratedSecurity.Checked = value.IntegratedSecurity;
                txtUsername.Text = value.UserID;
                txtPassword.Text = value.Password;
                txtDatabase.Text = value.InitialCatalog;
            }
        }

        public ucSqlConnection()
        {
            InitializeComponent();
        }

        private void cmdTestConnection_Click(object sender, EventArgs e)
        {
            var res = SqlServerExtensions.TestSqlConnection(txtServer.Text, chkIntegratedSecurity.Checked, txtUsername.Text, txtPassword.Text, TestWithoutDatabase?null:txtDatabase.Text);
            MessageBox.Show( res.Details, "Sql Connection Test", MessageBoxButtons.OK,  res.Succesfull ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            OnUpdateStatus?.Invoke(this, new InfoEventArrgs(res.Succesfull));
        }
    }
}
