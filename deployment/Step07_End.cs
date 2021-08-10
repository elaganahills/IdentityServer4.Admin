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
    public partial class Step07_End : Step
    {
        public Step07_End()
        {
            InitializeComponent();
        }

        private void Step06_End_Load(object sender, EventArgs e)
        {

        }

        public override void cmdNext_Click(object sender, EventArgs e)
        {
            this.Close(true);
        }
    }
}
