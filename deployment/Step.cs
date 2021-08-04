using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hills.IdentityServer4.Deployment
{
    public partial class Step : Form
    {

        public bool EnablePrevious { get => cmdPrevious.Visible; set => cmdPrevious.Visible = value; }
        public bool EnableNext { get => cmdNext.Visible; set => cmdNext.Visible = value; }
        public string LabeleNext { get => cmdNext.Text; set => cmdNext.Text = value; }
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public Step()
        {
            InitializeComponent();

            EnablePrevious = false;
            lblVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        virtual public void cmdPrevious_Click(object sender, EventArgs e)
        {

        }

        virtual public void cmdNext_Click(object sender, EventArgs e)
        {

        }

        virtual public void Step_Load(object sender, EventArgs e)
        {

        }

        public bool ShowMessage(string message, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, icon.ToString(),
               (icon == MessageBoxIcon.Question)? MessageBoxButtons.YesNo:MessageBoxButtons.OK, icon) == DialogResult.Yes;
        }

        public void ShowErrorMessage(string message)
        {
            ShowMessage(message, MessageBoxIcon.Error);
        }
        public bool ShowQuestionMessage(string message)
        {
            return ShowMessage(message, MessageBoxIcon.Question);
        }

        bool TerminateProgram = true;

        public void Close(bool terminateprogram)
        {
            TerminateProgram = terminateprogram;
            Close();
        }

        private void Step_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TerminateProgram)
                Program.Close();
        }
    }
}
