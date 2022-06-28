namespace Envision.Plugin.XtraFile.xtraReports
{
    partial class Exam2SubReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.pExamUID = new DevExpress.XtraReports.UI.XRTableCell();
            this.pExamName = new DevExpress.XtraReports.UI.XRTableCell();
            this.pExamDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.pExamTime = new DevExpress.XtraReports.UI.XRTableCell();
            this.pRate = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.Height = 18;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrTable1.Location = new System.Drawing.Point(0, 0);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(383, 18);
            this.xrTable1.StylePriority.UseFont = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.pExamUID,
            this.pExamName,
            this.pExamDate,
            this.pExamTime,
            this.pRate});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1;
            // 
            // pExamUID
            // 
            this.pExamUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pExamUID.Name = "pExamUID";
            this.pExamUID.StylePriority.UseFont = false;
            this.pExamUID.StylePriority.UseTextAlignment = false;
            this.pExamUID.Text = "pExamUID";
            this.pExamUID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.pExamUID.Weight = 0.38903394255874679;
            // 
            // pExamName
            // 
            this.pExamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pExamName.Name = "pExamName";
            this.pExamName.StylePriority.UseFont = false;
            this.pExamName.StylePriority.UseTextAlignment = false;
            this.pExamName.Text = "pExamName";
            this.pExamName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.pExamName.Weight = 1.1723237597911227;
            // 
            // pExamDate
            // 
            this.pExamDate.Name = "pExamDate";
            this.pExamDate.StylePriority.UseTextAlignment = false;
            this.pExamDate.Text = "pExamDate";
            this.pExamDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.pExamDate.Weight = 0.52349869451697129;
            // 
            // pExamTime
            // 
            this.pExamTime.Name = "pExamTime";
            this.pExamTime.StylePriority.UseTextAlignment = false;
            this.pExamTime.Text = "pExamTime";
            this.pExamTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.pExamTime.Weight = 0.39099216710182766;
            // 
            // pRate
            // 
            this.pRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.pRate.Name = "pRate";
            this.pRate.StylePriority.UseFont = false;
            this.pRate.StylePriority.UseTextAlignment = false;
            this.pRate.Text = "pRate";
            this.pRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.pRate.Weight = 0.52415143603133152;
            // 
            // Exam2SubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.Name = "Exam2SubReport";
            this.PageHeight = 827;
            this.PageWidth = 583;
            this.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.Version = "9.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell pExamUID;
        private DevExpress.XtraReports.UI.XRTableCell pExamName;
        private DevExpress.XtraReports.UI.XRTableCell pExamDate;
        private DevExpress.XtraReports.UI.XRTableCell pExamTime;
        private DevExpress.XtraReports.UI.XRTableCell pRate;
    }
}
