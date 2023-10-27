using Skoruba.IdentityServer4.Shared.Configuration.Deploy;
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

    

    public partial class Step04_EndPoints : Hills.IdentityServer4.Deployment.Step
    {
        public Step04_EndPoints()
        {
            InitializeComponent();

            EnableNext = false;

            ucEndPointsEditor.EndPoints = Program.EndPoints;
            ucEndPointsEditorAdmin.EndPoints = Program.EndPointsAdmin;

            ucEndPointsEditor_OnUpdateStatus(null, null);
            RefreshDnsList();
        }

        private void Step03_EndPoints_Load(object sender, EventArgs e)
        {

        }


        public override void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {
                //update client dns
                foreach (var c in Program.Clients)
                {
                    //AllowedCorsOrigins
                    var tempACO = c.AllowedCorsOrigins.ToList();
                    c.AllowedCorsOrigins = new List<string>();
                    foreach (var dns in Program.DnsList)
                        foreach (var c2 in tempACO)
                            c.AllowedCorsOrigins.Add(c2.Replace("localhost", dns));

                    //AllowedCorsOrigins
                    var tempRU = c.RedirectUris.ToList();
                    c.RedirectUris = new List<string>();
                    foreach (var dns in Program.DnsList)
                        foreach (var c2 in tempRU)
                            c.RedirectUris.Add(c2.Replace("localhost", dns));

                    //AllowedCorsOrigins
                    var tempPLRU = c.PostLogoutRedirectUris.ToList();
                    c.PostLogoutRedirectUris = new List<string>();
                    foreach (var dns in Program.DnsList)
                        foreach (var c2 in tempPLRU)
                            c.PostLogoutRedirectUris.Add(c2.Replace("localhost", dns));

                }


                //close current form and open next
                new Step05_PreConfiguredServices().Show();
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
            new Step03_ActiveDirectory().Show();
            this.Close(false);
        }

        private void ucEndPointsEditor_OnUpdateStatus(object sender, InfoEventArrgs e)
        {
            EnableNext = ucEndPointsEditor.ValidEndPointsCount > 0 && ucEndPointsEditorAdmin.ValidEndPointsCount > 0 && Program.DnsList.Any();
        }

        private void lnkCertificateTool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CertificateTool().ShowDialog();
            ucEndPointsEditor.UpdateTable();
            ucEndPointsEditorAdmin.UpdateTable();
        }

        private void lnkAddDNS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ed = new EditDns();
            if (ed.ShowDialog() == DialogResult.OK)
                Program.DnsList.Add(ed.Dns);
            RefreshDnsList();
        }

        private void RefreshDnsList()
        {
            lstDNS.DataSource = null;
            lstDNS.DataSource = Program.DnsList;           
            ucEndPointsEditor_OnUpdateStatus(null, null);
        }

        private void lnkEditDNS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lstDNS.SelectedItems.Count > 0)
            {
                var ed = new EditDns((string)lstDNS.SelectedValue);
                if (ed.ShowDialog() == DialogResult.OK)
                {
                    Program.DnsList.RemoveAll(d => d == (string)lstDNS.SelectedValue);
                    Program.DnsList.Add(ed.Dns);
                }
                RefreshDnsList();
            }            
        }

        private void lnkRemoveDNS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lstDNS.SelectedItems.Count > 0)
            {
                Program.DnsList.RemoveAll(d => d == (string)lstDNS.SelectedValue);
                RefreshDnsList();
            }
        }
    }
}
