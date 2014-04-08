namespace InstallCentrifyCertificates
{
    partial class Form1
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
            this.lbl_status = new System.Windows.Forms.Label();
            this.pb_certs = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(13, 13);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(56, 13);
            this.lbl_status.TabIndex = 0;
            this.lbl_status.Text = "Opening...";
            // 
            // pb_certs
            // 
            this.pb_certs.Location = new System.Drawing.Point(16, 43);
            this.pb_certs.Name = "pb_certs";
            this.pb_certs.Size = new System.Drawing.Size(358, 23);
            this.pb_certs.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 78);
            this.Controls.Add(this.pb_certs);
            this.Controls.Add(this.lbl_status);
            this.Name = "Form1";
            this.Text = "PSP Install Centrify Certificates";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ProgressBar pb_certs;
    }
}

