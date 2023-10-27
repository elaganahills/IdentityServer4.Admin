using Hills.Extensions;
using Hills.Extensions.Windows;
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
    public partial class CertificateTool : Form
    {
        public CertificateTool()
        {
            InitializeComponent();
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            try
            {
                var ids = PowerShellHelper.GetCertificateId(txtDNS.Text);
                if (!ids.IsNullOrEmpty())
                    MessageBox.Show($"Certificate found.\r\n{ids}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                else
                    MessageBox.Show($"Certificate not found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var ids = PowerShellHelper.CreateSelfSignedCertificate(txtDNS.Text, txtAlternativeNames.Text);
                if (!ids.IsNullOrEmpty())
                    MessageBox.Show($"Certificate created succesfully.\r\n{ids}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    throw new Exception("Error creating the certificate: " + ids);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
