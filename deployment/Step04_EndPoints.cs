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

    

    public partial class Step04_EndPoints : Step
    {
        public Step04_EndPoints()
        {
            InitializeComponent();

            EnableNext = false;

            ucEndPointsEditor.EndPoints = Program.EndPoints;
            ucEndPointsEditorAdmin.EndPoints = Program.EndPointsAdmin;

            ucEndPointsEditor_OnUpdateStatus(null, null);
        }

        private void Step03_EndPoints_Load(object sender, EventArgs e)
        {

        }


        public override void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {

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
            EnableNext = ucEndPointsEditor.EndPointsCount > 0 && ucEndPointsEditorAdmin.EndPointsCount > 0;
        }
    }
}
