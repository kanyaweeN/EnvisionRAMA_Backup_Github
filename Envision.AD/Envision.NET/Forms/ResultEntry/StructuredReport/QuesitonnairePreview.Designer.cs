namespace Envision.NET.Forms.ResultEntry.StructuredReport
{
    partial class QuesitonnairePreview
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.questionnaireGenerator1 = new Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.QuestionnaireGenerator();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Size = new System.Drawing.Size(790, 48);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // questionnaireGenerator1
            // 
            this.questionnaireGenerator1.AutoScroll = true;
            this.questionnaireGenerator1.BackColor = System.Drawing.Color.Transparent;
            this.questionnaireGenerator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionnaireGenerator1.Location = new System.Drawing.Point(0, 48);
            this.questionnaireGenerator1.Name = "questionnaireGenerator1";
            this.questionnaireGenerator1.Size = new System.Drawing.Size(790, 519);
            this.questionnaireGenerator1.TabIndex = 1;
            // 
            // QuesitonnairePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 567);
            this.Controls.Add(this.questionnaireGenerator1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "QuesitonnairePreview";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.QuesitonnairePreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.QuestionnaireGenerator questionnaireGenerator1;
    }
}