namespace Envision.NET.Reports.ReportParameter
{
    partial class RSS_StatOnline
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 14);
            this.labelControl1.TabIndex = 51;
            this.labelControl1.Text = "Statistic Online";
            // 
            // reportViewer1
            // 
            this.reportViewer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.reportViewer1.Location = new System.Drawing.Point(1, 29);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.ShowPromptAreaButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(830, 612);
            this.reportViewer1.TabIndex = 52;
            this.reportViewer1.UseWaitCursor = true;
            // 
            // RSS_StatOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 642);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.labelControl1);
            this.Name = "RSS_StatOnline";
            this.Text = "RSS_StatOnline";
            this.Load += new System.EventHandler(this.RSS_StatOnline_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}