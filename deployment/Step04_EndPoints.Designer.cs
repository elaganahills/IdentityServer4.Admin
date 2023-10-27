
namespace Hills.IdentityServer4.Deployment
{
    partial class Step04_EndPoints
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
            this.ucEndPointsEditor = new Hills.IdentityServer4.Deployment.ucEndPointsEditor();
            this.ucEndPointsEditorAdmin = new Hills.IdentityServer4.Deployment.ucEndPointsEditor();
            this.lnkCertificateTool = new System.Windows.Forms.LinkLabel();
            this.lstDNS = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkRemoveDNS = new System.Windows.Forms.LinkLabel();
            this.lnkEditDNS = new System.Windows.Forms.LinkLabel();
            this.lnkAddDNS = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ucEndPointsEditor
            // 
            this.ucEndPointsEditor.EndPoints = null;
            this.ucEndPointsEditor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ucEndPointsEditor.Location = new System.Drawing.Point(9, 75);
            this.ucEndPointsEditor.Name = "ucEndPointsEditor";
            this.ucEndPointsEditor.Size = new System.Drawing.Size(860, 151);
            this.ucEndPointsEditor.TabIndex = 1;
            this.ucEndPointsEditor.Title = "End Points IdentityServer4 Service";
            this.ucEndPointsEditor.OnUpdateStatus += new Hills.IdentityServer4.Deployment.ucEndPointsEditor.StatusUpdateHandler(this.ucEndPointsEditor_OnUpdateStatus);
            // 
            // ucEndPointsEditorAdmin
            // 
            this.ucEndPointsEditorAdmin.EndPoints = null;
            this.ucEndPointsEditorAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ucEndPointsEditorAdmin.Location = new System.Drawing.Point(9, 232);
            this.ucEndPointsEditorAdmin.Name = "ucEndPointsEditorAdmin";
            this.ucEndPointsEditorAdmin.Size = new System.Drawing.Size(860, 164);
            this.ucEndPointsEditorAdmin.TabIndex = 1;
            this.ucEndPointsEditorAdmin.Title = "End Points IdentityServer4 Administrator Service";
            this.ucEndPointsEditorAdmin.OnUpdateStatus += new Hills.IdentityServer4.Deployment.ucEndPointsEditor.StatusUpdateHandler(this.ucEndPointsEditor_OnUpdateStatus);
            // 
            // lnkCertificateTool
            // 
            this.lnkCertificateTool.AutoSize = true;
            this.lnkCertificateTool.Location = new System.Drawing.Point(12, 588);
            this.lnkCertificateTool.Name = "lnkCertificateTool";
            this.lnkCertificateTool.Size = new System.Drawing.Size(85, 15);
            this.lnkCertificateTool.TabIndex = 4;
            this.lnkCertificateTool.TabStop = true;
            this.lnkCertificateTool.Text = "Certificate tool";
            this.lnkCertificateTool.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCertificateTool_LinkClicked);
            // 
            // lstDNS
            // 
            this.lstDNS.FormattingEnabled = true;
            this.lstDNS.ItemHeight = 15;
            this.lstDNS.Location = new System.Drawing.Point(12, 427);
            this.lstDNS.Name = "lstDNS";
            this.lstDNS.Size = new System.Drawing.Size(857, 109);
            this.lstDNS.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "DNS list to be used to reach applications";
            // 
            // lnkRemoveDNS
            // 
            this.lnkRemoveDNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkRemoveDNS.AutoSize = true;
            this.lnkRemoveDNS.Location = new System.Drawing.Point(80, 539);
            this.lnkRemoveDNS.Name = "lnkRemoveDNS";
            this.lnkRemoveDNS.Size = new System.Drawing.Size(50, 15);
            this.lnkRemoveDNS.TabIndex = 15;
            this.lnkRemoveDNS.TabStop = true;
            this.lnkRemoveDNS.Text = "Remove";
            this.lnkRemoveDNS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemoveDNS_LinkClicked);
            // 
            // lnkEditDNS
            // 
            this.lnkEditDNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkEditDNS.AutoSize = true;
            this.lnkEditDNS.Location = new System.Drawing.Point(47, 539);
            this.lnkEditDNS.Name = "lnkEditDNS";
            this.lnkEditDNS.Size = new System.Drawing.Size(27, 15);
            this.lnkEditDNS.TabIndex = 13;
            this.lnkEditDNS.TabStop = true;
            this.lnkEditDNS.Text = "Edit";
            this.lnkEditDNS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditDNS_LinkClicked);
            // 
            // lnkAddDNS
            // 
            this.lnkAddDNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkAddDNS.AutoSize = true;
            this.lnkAddDNS.Location = new System.Drawing.Point(12, 539);
            this.lnkAddDNS.Name = "lnkAddDNS";
            this.lnkAddDNS.Size = new System.Drawing.Size(29, 15);
            this.lnkAddDNS.TabIndex = 14;
            this.lnkAddDNS.TabStop = true;
            this.lnkAddDNS.Text = "Add";
            this.lnkAddDNS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddDNS_LinkClicked);
            // 
            // Step04_EndPoints
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.lnkRemoveDNS);
            this.Controls.Add(this.lnkEditDNS);
            this.Controls.Add(this.lnkAddDNS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDNS);
            this.Controls.Add(this.lnkCertificateTool);
            this.Controls.Add(this.ucEndPointsEditorAdmin);
            this.Controls.Add(this.ucEndPointsEditor);
            this.EnableNext = true;
            this.EnablePrevious = true;
            this.Name = "Step04_EndPoints";
            this.Text = "Step03_EndPoints";
            this.Title = "Service end points";
            this.Load += new System.EventHandler(this.Step03_EndPoints_Load);
            this.Controls.SetChildIndex(this.ucEndPointsEditor, 0);
            this.Controls.SetChildIndex(this.ucEndPointsEditorAdmin, 0);
            this.Controls.SetChildIndex(this.lnkCertificateTool, 0);
            this.Controls.SetChildIndex(this.lstDNS, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lnkAddDNS, 0);
            this.Controls.SetChildIndex(this.lnkEditDNS, 0);
            this.Controls.SetChildIndex(this.lnkRemoveDNS, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucEndPointsEditor ucEndPointsEditor;
        private ucEndPointsEditor ucEndPointsEditorAdmin;
        private System.Windows.Forms.LinkLabel lnkCertificateTool;
        private System.Windows.Forms.ListBox lstDNS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkRemoveDNS;
        private System.Windows.Forms.LinkLabel lnkEditDNS;
        private System.Windows.Forms.LinkLabel lnkAddDNS;
    }
}