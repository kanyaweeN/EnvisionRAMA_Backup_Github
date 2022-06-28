namespace Envision.NET.Reports.ReportParameter
{
    partial class RPT_BrowserOLAP
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
            this.webBrowserOlap = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserOlap
            // 
            this.webBrowserOlap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserOlap.Location = new System.Drawing.Point(0, 0);
            this.webBrowserOlap.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserOlap.Name = "webBrowserOlap";
            this.webBrowserOlap.Size = new System.Drawing.Size(755, 455);
            this.webBrowserOlap.TabIndex = 0;
            // 
            // RPT_BrowserOLAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 455);
            this.Controls.Add(this.webBrowserOlap);
            this.Name = "RPT_BrowserOLAP";
            this.Text = "RPT_BrowserOLAP";
            this.Load += new System.EventHandler(this.RPT_BrowserOLAP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserOlap;
    }
}