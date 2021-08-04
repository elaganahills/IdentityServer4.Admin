using Hills.Extensions.Models;
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
    public partial class ucEndPointsEditor : UserControl
    {
        public ucEndPointsEditor()
        {
            InitializeComponent();
        }

        public delegate void StatusUpdateHandler(object sender, InfoEventArrgs e);
        public event StatusUpdateHandler OnUpdateStatus;

        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public int EndPointsCount { get => EndPoints.Count; }

        List<EndPointConfiguration> _endPoints;
        public List<EndPointConfiguration> EndPoints
        {
            get => _endPoints;
            set { _endPoints = value; RefreshTable(); }
        }

        void RefreshTable()
        {
            if (EndPoints is null)
                return;


            lstEndPoints.Items.Clear();

            foreach (var ep in EndPoints)
                lstEndPoints.Items.Add(new ListViewItem(new string[]
                { ep.Name,ep.IpAddress,ep.Port.ToString(),ep.UseHttps.ToString(), ep.Certificate_Type.ToString(),ep.Certificate_Source })
                { Tag = ep });

        }

        EndPointConfiguration SelectedItem()
        {
            if (lstEndPoints.SelectedItems.Count == 1)
                return (EndPointConfiguration)lstEndPoints.SelectedItems[0].Tag;
            else
                return null;
        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender == lnkAdd)
                lstEndPoints.SelectedItems.Clear();
            var aep = new EditEndPoint(SelectedItem());
            if (aep.ShowDialog() == DialogResult.OK)
            {
                if (!EndPoints.Contains(aep.EndPoint))
                    EndPoints.Add(aep.EndPoint);
                RefreshTable();
                UpdateStatus();
            }
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var si = SelectedItem();
            if (si != null)
            {
                EndPoints.Remove(si);
                RefreshTable();
                UpdateStatus();
            }
        }

        void UpdateStatus()
        {
            OnUpdateStatus?.Invoke(this, new InfoEventArrgs(EndPointsCount > 0));
        }
    }
}
