
namespace Hills.IdentityServer4.Deployment
{
    partial class Step03_EndPoints
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
            this.SuspendLayout();
            // 
            // ucEndPointsEditor
            // 
            this.ucEndPointsEditor.EndPoints = null;
            this.ucEndPointsEditor.Location = new System.Drawing.Point(9, 75);
            this.ucEndPointsEditor.Name = "ucEndPointsEditor";
            this.ucEndPointsEditor.Size = new System.Drawing.Size(860, 252);
            this.ucEndPointsEditor.TabIndex = 1;
            this.ucEndPointsEditor.Title = "End Points IdentityServer4 Service";
            this.ucEndPointsEditor.OnUpdateStatus += new Hills.IdentityServer4.Deployment.ucEndPointsEditor.StatusUpdateHandler(this.ucEndPointsEditor_OnUpdateStatus);
            // 
            // ucEndPointsEditorAdmin
            // 
            this.ucEndPointsEditorAdmin.EndPoints = null;
            this.ucEndPointsEditorAdmin.Location = new System.Drawing.Point(9, 345);
            this.ucEndPointsEditorAdmin.Name = "ucEndPointsEditorAdmin";
            this.ucEndPointsEditorAdmin.Size = new System.Drawing.Size(860, 252);
            this.ucEndPointsEditorAdmin.TabIndex = 1;
            this.ucEndPointsEditorAdmin.Title = "End Points IdentityServer4 Administrator Service";
            this.ucEndPointsEditorAdmin.OnUpdateStatus += new Hills.IdentityServer4.Deployment.ucEndPointsEditor.StatusUpdateHandler(this.ucEndPointsEditor_OnUpdateStatus);
            // 
            // Step03_EndPoints
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.ucEndPointsEditorAdmin);
            this.Controls.Add(this.ucEndPointsEditor);
            this.EnableNext = true;
            this.EnablePrevious = true;
            this.Name = "Step03_EndPoints";
            this.Text = "Step03_EndPoints";
            this.Title = "Service end points";
            this.Load += new System.EventHandler(this.Step03_EndPoints_Load);
            this.Controls.SetChildIndex(this.ucEndPointsEditor, 0);
            this.Controls.SetChildIndex(this.ucEndPointsEditorAdmin, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucEndPointsEditor ucEndPointsEditor;
        private ucEndPointsEditor ucEndPointsEditorAdmin;
    }
}