using Hills.IdentityServer4.Deployment.Properties;
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
    public partial class ucTaskResult : UserControl
    {

        public enum Statuses { Unknown, Wait, Info, Good, Warning, Error,
            Task
        }
        Statuses _status;

        public Statuses Status
        {
            get => _status;
            set
            {
                _status = value;
                switch (_status)
                {
                    case Statuses.Unknown:
                        pbIcon.Image = Resources.question;
                        break;
                    case Statuses.Wait:
                        pbIcon.Image = Resources.wait;
                        break;
                    case Statuses.Task:
                        pbIcon.Image = Resources.task;
                        break;
                    case Statuses.Info:
                        pbIcon.Image = Resources.info;
                        break;
                    case Statuses.Good:
                        pbIcon.Image = Resources.check;
                        break;
                    case Statuses.Warning:
                        pbIcon.Image = Resources.warning;
                        break;
                    case Statuses.Error:
                        pbIcon.Image = Resources.error;
                        break;
                }

            }
        }

        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        
        public string Info { get => lblInfo.Text; set => lblInfo.Text = value; }

        public void Set(Statuses status, string title, string info)
        {
            Title = title;
            Set(status, info);
        }
        public void Set(Statuses status, string info)
        {
            Status = status;
            Info = info;
        }
        public void AppendInfo(Statuses status, string info)
        {
            Status = status;
            Info += info;
        }
        public void AppendInfo(string info)
        {
            Info += info;
        }

        public ucTaskResult()
        {
            InitializeComponent();
        }

        private void lnkMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Info, "More",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
