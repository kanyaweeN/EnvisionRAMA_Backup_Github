namespace Envision.Plugin.XtraFile.xtraReports
{
    partial class xrptScheduleReportSubExam
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.pRate = new DevExpress.XtraReports.UI.XRLabel();
            this.dsScheduleReport1 = new Envision.Plugin.XtraFile.xtraData.dsScheduleReport();
            this.pModality = new DevExpress.XtraReports.UI.XRLabel();
            this.pExamCode = new DevExpress.XtraReports.UI.XRLabel();
            this.pExamName = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.pSumRate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.gBL_ENVTableAdapter = new Envision.Plugin.XtraFile.xtraData.dsScheduleReportTableAdapters.GBL_ENVTableAdapter();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.dsScheduleReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pRate,
            this.pModality,
            this.pExamCode,
            this.pExamName});
            this.Detail.Height = 25;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // pRate
            // 
            this.pRate.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.pRate.CanGrow = false;
            this.pRate.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dsScheduleReport1, "GBL_ENV.FK_HR_UNIT_GBL_ENV.RATE", "{0:#,#}")});
            this.pRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pRate.Location = new System.Drawing.Point(450, 0);
            this.pRate.Name = "pRate";
            this.pRate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pRate.Size = new System.Drawing.Size(83, 25);
            this.pRate.StylePriority.UseBorders = false;
            this.pRate.StylePriority.UseFont = false;
            this.pRate.StylePriority.UseTextAlignment = false;
            this.pRate.Text = "pRate";
            this.pRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.pRate.WordWrap = false;
            // 
            // dsScheduleReport1
            // 
            this.dsScheduleReport1.DataSetName = "dsScheduleReport";
            this.dsScheduleReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pModality
            // 
            this.pModality.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.pModality.CanGrow = false;
            this.pModality.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dsScheduleReport1, "GBL_ENV.FK_HR_UNIT_GBL_ENV.MODALITY_NAME", "")});
            this.pModality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pModality.Location = new System.Drawing.Point(308, 0);
            this.pModality.Name = "pModality";
            this.pModality.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pModality.Size = new System.Drawing.Size(142, 25);
            this.pModality.StylePriority.UseBorders = false;
            this.pModality.StylePriority.UseFont = false;
            this.pModality.StylePriority.UseTextAlignment = false;
            this.pModality.Text = "pModality";
            this.pModality.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.pModality.WordWrap = false;
            // 
            // pExamCode
            // 
            this.pExamCode.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.pExamCode.CanGrow = false;
            this.pExamCode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dsScheduleReport1, "GBL_ENV.FK_HR_UNIT_GBL_ENV.EXAM_UID", "")});
            this.pExamCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pExamCode.Location = new System.Drawing.Point(8, 0);
            this.pExamCode.Name = "pExamCode";
            this.pExamCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pExamCode.Size = new System.Drawing.Size(92, 25);
            this.pExamCode.StylePriority.UseBorders = false;
            this.pExamCode.StylePriority.UseFont = false;
            this.pExamCode.StylePriority.UseTextAlignment = false;
            this.pExamCode.Text = "pExamCode";
            this.pExamCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.pExamCode.WordWrap = false;
            // 
            // pExamName
            // 
            this.pExamName.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.pExamName.CanGrow = false;
            this.pExamName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dsScheduleReport1, "GBL_ENV.FK_HR_UNIT_GBL_ENV.EXAM_NAME", "")});
            this.pExamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pExamName.Location = new System.Drawing.Point(100, 0);
            this.pExamName.Name = "pExamName";
            this.pExamName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pExamName.Size = new System.Drawing.Size(208, 25);
            this.pExamName.StylePriority.UseBorders = false;
            this.pExamName.StylePriority.UseFont = false;
            this.pExamName.StylePriority.UseTextAlignment = false;
            this.pExamName.Text = "pExamName";
            this.pExamName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.pExamName.WordWrap = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("FK_HR_UNIT_GBL_ENV.HN", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 33;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(450, 8);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.Size = new System.Drawing.Size(83, 25);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Rate";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.xrLabel3.Location = new System.Drawing.Point(308, 8);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(142, 25);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Modality";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(100, 8);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(208, 25);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Exam Name";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.xrLabel1.Location = new System.Drawing.Point(8, 8);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.Size = new System.Drawing.Size(92, 25);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Code";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pSumRate,
            this.xrLabel9});
            this.GroupFooter1.Height = 25;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // pSumRate
            // 
            this.pSumRate.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.pSumRate.CanGrow = false;
            this.pSumRate.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dsScheduleReport1, "GBL_ENV.FK_HR_UNIT_GBL_ENV.RATE", "")});
            this.pSumRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pSumRate.Location = new System.Drawing.Point(392, 0);
            this.pSumRate.Name = "pSumRate";
            this.pSumRate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pSumRate.Size = new System.Drawing.Size(142, 25);
            this.pSumRate.StylePriority.UseBorders = false;
            this.pSumRate.StylePriority.UseFont = false;
            this.pSumRate.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.pSumRate.Summary = xrSummary1;
            this.pSumRate.Text = "pSumRate";
            this.pSumRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.pSumRate.WordWrap = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.xrLabel9.Location = new System.Drawing.Point(8, 0);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.Size = new System.Drawing.Size(383, 25);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "รวม : ";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gBL_ENVTableAdapter
            // 
            this.gBL_ENVTableAdapter.ClearBeforeFill = true;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Height = 0;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Height = 0;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // xrptScheduleReportSubExam
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.GroupHeader1,
            this.GroupFooter1,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 0, 0);
            this.Name = "xrptScheduleReportSubExam";
            this.PageHeight = 827;
            this.PageWidth = 583;
            this.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.Version = "11.1";
            ((System.ComponentModel.ISupportInitialize)(this.dsScheduleReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel pModality;
        private DevExpress.XtraReports.UI.XRLabel pExamCode;
        private DevExpress.XtraReports.UI.XRLabel pExamName;
        private DevExpress.XtraReports.UI.XRLabel pRate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private Envision.Plugin.XtraFile.xtraData.dsScheduleReport dsScheduleReport1;
        private Envision.Plugin.XtraFile.xtraData.dsScheduleReportTableAdapters.GBL_ENVTableAdapter gBL_ENVTableAdapter;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRLabel pSumRate;
    }
}
