
namespace Hills.IdentityServer4.Deployment
{
    partial class EditDns
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.txtDns = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "DNS";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtDns
            // 
            this.txtDns.Location = new System.Drawing.Point(61, 12);
            this.txtDns.Name = "txtDns";
            this.txtDns.Size = new System.Drawing.Size(424, 23);
            this.txtDns.TabIndex = 12;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(410, 41);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 21;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // EditDns
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(523, 83);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDns);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "EditDns";
            this.Text = "EditDns";
            this.Load += new System.EventHandler(this.EditDns_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDns;
        private System.Windows.Forms.Button cmdSave;
    }
}