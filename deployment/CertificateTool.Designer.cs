
namespace Hills.IdentityServer4.Deployment
{
    partial class CertificateTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAlternativeNames = new System.Windows.Forms.TextBox();
            this.txtDNS = new System.Windows.Forms.TextBox();
            this.cmdFind = new System.Windows.Forms.Button();
            this.cmdCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Alternative Names";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "DNS";
            // 
            // txtAlternativeNames
            // 
            this.txtAlternativeNames.Location = new System.Drawing.Point(157, 52);
            this.txtAlternativeNames.Name = "txtAlternativeNames";
            this.txtAlternativeNames.Size = new System.Drawing.Size(424, 23);
            this.txtAlternativeNames.TabIndex = 14;
            this.txtAlternativeNames.Text = "dns:localhost; ip:127.0.0.1";
            // 
            // txtDNS
            // 
            this.txtDNS.Location = new System.Drawing.Point(157, 23);
            this.txtDNS.Name = "txtDNS";
            this.txtDNS.Size = new System.Drawing.Size(424, 23);
            this.txtDNS.TabIndex = 15;
            this.txtDNS.Text = "localhost";
            // 
            // cmdFind
            // 
            this.cmdFind.Location = new System.Drawing.Point(455, 103);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(126, 23);
            this.cmdFind.TabIndex = 18;
            this.cmdFind.Text = "Find certificate";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // cmdCreate
            // 
            this.cmdCreate.Location = new System.Drawing.Point(323, 103);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(126, 23);
            this.cmdCreate.TabIndex = 18;
            this.cmdCreate.Text = "Create certificate";
            this.cmdCreate.UseVisualStyleBackColor = true;
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // CertificateTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 149);
            this.Controls.Add(this.cmdCreate);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAlternativeNames);
            this.Controls.Add(this.txtDNS);
            this.Name = "CertificateTool";
            this.Text = "Certificate Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAlternativeNames;
        private System.Windows.Forms.TextBox txtDNS;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.Button cmdCreate;
    }
}