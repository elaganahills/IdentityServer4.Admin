using Hills.Extensions;
using Skoruba.IdentityServer4.Shared.Configuration.Deploy;
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
using Hills.Extensions.Models;

namespace Hills.IdentityServer4.Deployment
{
    public partial class EditEndPoint : Form
    {
        public EndPointConfiguration EndPoint;

        public EditEndPoint(EndPointConfiguration endpoint) : this ()
        {
            EndPoint = endpoint;
        }

        public EditEndPoint()
        {
            InitializeComponent();

            cmbIpAddress.DataSource = NetworkExtensions.GetIpAddressList<string>();
            cmbCertificateType.DataSource = Enum.GetNames(typeof(EndPointConfiguration.CertificateTypes));
            cmbCertificate.DataSource = CertificatesExtensions.GetCertificatesList();
            cmbCertificate.DisplayMember = "Description";
            cmbCertificate.ValueMember = "Id";

            chkHttps_CheckedChanged(null, null);
        }

        private void EditEndPoint_Load(object sender, EventArgs e)
        {
            if (EndPoint != null)
            {
                txtName.Text = EndPoint.Name;
                cmbIpAddress.SelectedItem = EndPoint.IpAddress;
                txtPort.Text = EndPoint.Port.ToString();
                chkHttps.Checked = EndPoint.UseHttps;
                cmbCertificateType.SelectedItem = EndPoint.Certificate_Type.ToString();
                cmbCertificate.SelectedValue = EndPoint.Certificate_Id;
                txtPassword.Text = EndPoint.Certificate_Password;
                txtFileName.Text = EndPoint.Certificate_FileName;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (EndPoint == null)
                EndPoint = new EndPointConfiguration();

            EndPoint.Name = txtName.Text;
            EndPoint.IpAddress = (string)cmbIpAddress.SelectedValue;
            EndPoint.Port = int.Parse(txtPort.Text);
            EndPoint.UseHttps = chkHttps.Checked;
            EndPoint.Certificate_Type = (EndPointConfiguration.CertificateTypes)Enum.Parse(typeof(EndPointConfiguration.CertificateTypes), cmbCertificateType.SelectedValue.ToString()); ;
            if (EndPoint.Certificate_Type == EndPointConfiguration.CertificateTypes.Store)
            {
                var cert = (CertificateDto)cmbCertificate.SelectedItem;
                EndPoint.Certificate_Subject = cert.Subject;
                EndPoint.Certificate_StoreName = cert.StoreName;
            }
            else if (EndPoint.Certificate_Type == EndPointConfiguration.CertificateTypes.File)
            {
                if (!string.IsNullOrEmpty(selectedFilePath))
                    EndPoint.Certificate_File = File.ReadAllBytes(selectedFilePath);
                EndPoint.Certificate_FileName = txtFileName.Text;
                EndPoint.Certificate_Password = txtPassword.Text;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        string selectedFilePath;
        private void lnkSelectFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Certificate file (*.pfx)|*.pfx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = ofd.FileName;
                txtFileName.Text = Path.GetFileName(selectedFilePath);
            }

        }

        private void cmbCertificateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cmbCertificateType.SelectedValue == EndPointConfiguration.CertificateTypes.None.ToString())
            {
                cmbCertificate.Enabled = false;
                txtFileName.Text = "";
                txtFileName.Enabled = false;
                txtPassword.Enabled = false;
                lnkSelectFile.Enabled = false;
            }
            else if ((string)cmbCertificateType.SelectedValue == EndPointConfiguration.CertificateTypes.File.ToString())
            {
                cmbCertificate.Enabled = false;
                txtFileName.Enabled = true;
                txtPassword.Enabled = true;
                lnkSelectFile.Enabled = true;
            } else if ((string)cmbCertificateType.SelectedValue == EndPointConfiguration.CertificateTypes.Store.ToString())
            {
                cmbCertificate.Enabled = true;
                txtFileName.Enabled = false;
                txtFileName.Text = "";
                txtPassword.Enabled = false;
                lnkSelectFile.Enabled = false;
            }
        }

        private void chkHttps_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkHttps.Checked)
            {
                cmbCertificate.SelectedItem = null;
                cmbCertificateType.SelectedItem = EndPointConfiguration.CertificateTypes.None.ToString();
                cmbCertificateType.Enabled = false;
            } else
            {
                cmbCertificateType.Enabled = true;
            }
        }
    }
}
