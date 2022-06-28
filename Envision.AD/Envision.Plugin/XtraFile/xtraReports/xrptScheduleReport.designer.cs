namespace Envision.Plugin.XtraFile.xtraReports
{
    partial class xrptScheduleReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xrptScheduleReport));
            DevExpress.XtraPrinting.BarCode.Code39Generator code39Generator1 = new DevExpress.XtraPrinting.BarCode.Code39Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lblPatientID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.lblConfirmOn = new DevExpress.XtraReports.UI.XRLabel();
            this.lblConfirmBy = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPrintOn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPrintBy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCreatedBy = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCreatedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.dsScheduleReport1 = new Envision.Plugin.XtraFile.xtraData.dsScheduleReport();
            this.gBL_ENVTableAdapter = new Envision.Plugin.XtraFile.xtraData.dsScheduleReportTableAdapters.GBL_ENVTableAdapter();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrBarCode2 = new DevExpress.XtraReports.UI.XRBarCode();
            this.lblClinic = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAge = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGender = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAppointDt = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPatientEng = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPatientThai = new DevExpress.XtraReports.UI.XRLabel();
            this.lblHN = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.subIns = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrptScheduleReportSubIns2 = new Envision.Plugin.XtraFile.xtraReports.xrptScheduleReportSubIns();
            this.subExam = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrptScheduleReportSubExam2 = new Envision.Plugin.XtraFile.xtraReports.xrptScheduleReportSubExam();
            this.dataScheduleTableAdapter = new Envision.Plugin.XtraFile.xtraData.dsScheduleReportTableAdapters.dataScheduleTableAdapter();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.dsScheduleReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrptScheduleReportSubIns2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrptScheduleReportSubExam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Height = 0;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblPatientID,
            this.xrPictureBox1,
            this.xrLabel1});
            this.PageHeader.Height = 85;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblPatientID
            // 
            this.lblPatientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblPatientID.Location = new System.Drawing.Point(467, 8);
            this.lblPatientID.Multiline = true;
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPatientID.Size = new System.Drawing.Size(67, 67);
            this.lblPatientID.StylePriority.UseFont = false;
            this.lblPatientID.StylePriority.UseTextAlignment = false;
            this.lblPatientID.Text = "P1";
            this.lblPatientID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(0, 8);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(83, 67);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.xrLabel1.Location = new System.Drawing.Point(83, 8);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.Size = new System.Drawing.Size(383, 67);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "คณะแพทยศาสตร์โรงพยาบาลรามาธิบดี(ภาควิชารังสีวิทยา)\r\n270 ถ.พระราม 6 ทุ่งพญาไท ราชเ" +
                "ทวี กรุงเทพมหานคร 10400";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblConfirmOn,
            this.lblConfirmBy,
            this.lblPrintOn,
            this.xrLabel2,
            this.lblPrintBy,
            this.xrPageInfo1,
            this.xrLabel11,
            this.lblCreatedBy,
            this.lblCreatedOn});
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblConfirmOn
            // 
            this.lblConfirmOn.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblConfirmOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblConfirmOn.Location = new System.Drawing.Point(250, 67);
            this.lblConfirmOn.Name = "lblConfirmOn";
            this.lblConfirmOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblConfirmOn.Size = new System.Drawing.Size(267, 8);
            this.lblConfirmOn.StylePriority.UseBorders = false;
            this.lblConfirmOn.StylePriority.UseFont = false;
            this.lblConfirmOn.StylePriority.UseTextAlignment = false;
            this.lblConfirmOn.Text = "lblConfirmOn";
            this.lblConfirmOn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblConfirmBy
            // 
            this.lblConfirmBy.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblConfirmBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblConfirmBy.Location = new System.Drawing.Point(0, 67);
            this.lblConfirmBy.Name = "lblConfirmBy";
            this.lblConfirmBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblConfirmBy.Size = new System.Drawing.Size(250, 8);
            this.lblConfirmBy.StylePriority.UseBorders = false;
            this.lblConfirmBy.StylePriority.UseFont = false;
            this.lblConfirmBy.StylePriority.UseTextAlignment = false;
            this.lblConfirmBy.Text = "lblConfirmBy";
            this.lblConfirmBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblPrintOn
            // 
            this.lblPrintOn.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblPrintOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPrintOn.Location = new System.Drawing.Point(250, 75);
            this.lblPrintOn.Name = "lblPrintOn";
            this.lblPrintOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPrintOn.Size = new System.Drawing.Size(150, 25);
            this.lblPrintOn.StylePriority.UseBorders = false;
            this.lblPrintOn.StylePriority.UseFont = false;
            this.lblPrintOn.StylePriority.UseTextAlignment = false;
            this.lblPrintOn.Text = "lblPrintOn";
            this.lblPrintOn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.Location = new System.Drawing.Point(0, 8);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(517, 33);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "ราคานี้อาจมีการเปลี่ยนแปลงได้ โดยไม่ต้องแจ้งให้ทราบล่วงหน้า";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblPrintBy
            // 
            this.lblPrintBy.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblPrintBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPrintBy.Location = new System.Drawing.Point(0, 75);
            this.lblPrintBy.Name = "lblPrintBy";
            this.lblPrintBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPrintBy.Size = new System.Drawing.Size(250, 25);
            this.lblPrintBy.StylePriority.UseBorders = false;
            this.lblPrintBy.StylePriority.UseFont = false;
            this.lblPrintBy.StylePriority.UseTextAlignment = false;
            this.lblPrintBy.Text = "lblPrintBy";
            this.lblPrintBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrPageInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.xrPageInfo1.Format = "Page {0}/{1}";
            this.xrPageInfo1.Location = new System.Drawing.Point(400, 42);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.Size = new System.Drawing.Size(117, 25);
            this.xrPageInfo1.StylePriority.UseBorders = false;
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "GBL_ENV.VENDOR_H2", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.xrLabel11.Location = new System.Drawing.Point(400, 75);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.Size = new System.Drawing.Size(117, 25);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "xrLabel11";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCreatedBy.Location = new System.Drawing.Point(0, 42);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCreatedBy.Size = new System.Drawing.Size(250, 25);
            this.lblCreatedBy.StylePriority.UseBorders = false;
            this.lblCreatedBy.StylePriority.UseFont = false;
            this.lblCreatedBy.StylePriority.UseTextAlignment = false;
            this.lblCreatedBy.Text = "lblCreatedBy";
            this.lblCreatedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.lblCreatedOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCreatedOn.Location = new System.Drawing.Point(250, 42);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCreatedOn.Size = new System.Drawing.Size(150, 25);
            this.lblCreatedOn.StylePriority.UseBorders = false;
            this.lblCreatedOn.StylePriority.UseFont = false;
            this.lblCreatedOn.StylePriority.UseTextAlignment = false;
            this.lblCreatedOn.Text = "lblCreatedOn";
            this.lblCreatedOn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dsScheduleReport1
            // 
            this.dsScheduleReport1.DataSetName = "dsScheduleReport";
            this.dsScheduleReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gBL_ENVTableAdapter
            // 
            this.gBL_ENVTableAdapter.ClearBeforeFill = true;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupFooter1});
            this.DetailReport.DataAdapter = this.dataScheduleTableAdapter;
            this.DetailReport.DataMember = "GBL_ENV.FK_HR_UNIT_GBL_ENV";
            this.DetailReport.DataSource = this.dsScheduleReport1;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Height = 0;
            this.Detail1.Name = "Detail1";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrBarCode2,
            this.lblClinic,
            this.lblAge,
            this.lblGender,
            this.lblAppointDt,
            this.lblPatientEng,
            this.lblPatientThai,
            this.lblHN,
            this.xrLabel7,
            this.xrLabel4,
            this.xrLabel3});
            this.ReportHeader.KeepTogether = true;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrBarCode2
            // 
            this.xrBarCode2.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrBarCode2.AutoModule = true;
            this.xrBarCode2.Font = new System.Drawing.Font("Times New Roman", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrBarCode2.Location = new System.Drawing.Point(283, 0);
            this.xrBarCode2.Name = "xrBarCode2";
            this.xrBarCode2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrBarCode2.ShowText = false;
            this.xrBarCode2.Size = new System.Drawing.Size(250, 25);
            this.xrBarCode2.StylePriority.UseFont = false;
            this.xrBarCode2.StylePriority.UsePadding = false;
            this.xrBarCode2.StylePriority.UseTextAlignment = false;
            code39Generator1.CalcCheckSum = false;
            code39Generator1.WideNarrowRatio = 3F;
            this.xrBarCode2.Symbology = code39Generator1;
            this.xrBarCode2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblClinic
            // 
            this.lblClinic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblClinic.Location = new System.Drawing.Point(342, 75);
            this.lblClinic.Name = "lblClinic";
            this.lblClinic.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblClinic.Size = new System.Drawing.Size(192, 25);
            this.lblClinic.StylePriority.UseFont = false;
            this.lblClinic.StylePriority.UseTextAlignment = false;
            this.lblClinic.Text = "lblClinic";
            this.lblClinic.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblAge
            // 
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblAge.Location = new System.Drawing.Point(283, 50);
            this.lblAge.Name = "lblAge";
            this.lblAge.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAge.Size = new System.Drawing.Size(250, 25);
            this.lblAge.StylePriority.UseFont = false;
            this.lblAge.StylePriority.UseTextAlignment = false;
            this.lblAge.Text = "lblAge";
            this.lblAge.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblGender.Location = new System.Drawing.Point(283, 25);
            this.lblGender.Name = "lblGender";
            this.lblGender.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGender.Size = new System.Drawing.Size(250, 25);
            this.lblGender.StylePriority.UseFont = false;
            this.lblGender.StylePriority.UseTextAlignment = false;
            this.lblGender.Text = "lblGender";
            this.lblGender.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblAppointDt
            // 
            this.lblAppointDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblAppointDt.Location = new System.Drawing.Point(50, 75);
            this.lblAppointDt.Name = "lblAppointDt";
            this.lblAppointDt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAppointDt.Size = new System.Drawing.Size(292, 25);
            this.lblAppointDt.StylePriority.UseFont = false;
            this.lblAppointDt.StylePriority.UseTextAlignment = false;
            this.lblAppointDt.Text = "lblAppointDt";
            this.lblAppointDt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblPatientEng
            // 
            this.lblPatientEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPatientEng.Location = new System.Drawing.Point(50, 50);
            this.lblPatientEng.Name = "lblPatientEng";
            this.lblPatientEng.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPatientEng.Size = new System.Drawing.Size(233, 25);
            this.lblPatientEng.StylePriority.UseFont = false;
            this.lblPatientEng.StylePriority.UseTextAlignment = false;
            this.lblPatientEng.Text = "lblPatientEng";
            this.lblPatientEng.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblPatientThai
            // 
            this.lblPatientThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPatientThai.Location = new System.Drawing.Point(50, 25);
            this.lblPatientThai.Name = "lblPatientThai";
            this.lblPatientThai.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPatientThai.Size = new System.Drawing.Size(233, 25);
            this.lblPatientThai.StylePriority.UseFont = false;
            this.lblPatientThai.StylePriority.UseTextAlignment = false;
            this.lblPatientThai.Text = "lblPatientThai";
            this.lblPatientThai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblHN
            // 
            this.lblHN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblHN.Location = new System.Drawing.Point(50, 0);
            this.lblHN.Name = "lblHN";
            this.lblHN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblHN.Size = new System.Drawing.Size(233, 25);
            this.lblHN.StylePriority.UseFont = false;
            this.lblHN.StylePriority.UseTextAlignment = false;
            this.lblHN.Text = "lblHN";
            this.lblHN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.Location = new System.Drawing.Point(0, 75);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.Size = new System.Drawing.Size(50, 25);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "วันนัด : ";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.Location = new System.Drawing.Point(0, 25);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.Size = new System.Drawing.Size(50, 25);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "ชื่อ : ";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.Location = new System.Drawing.Point(0, 0);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(50, 25);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "HN : ";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("HN", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 0;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subIns,
            this.subExam});
            this.GroupFooter1.Height = 50;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // subIns
            // 
            this.subIns.Location = new System.Drawing.Point(0, 25);
            this.subIns.Name = "subIns";
            this.subIns.ReportSource = this.xrptScheduleReportSubIns2;
            this.subIns.Size = new System.Drawing.Size(533, 25);
            // 
            // subExam
            // 
            this.subExam.Location = new System.Drawing.Point(0, 0);
            this.subExam.Name = "subExam";
            this.subExam.ReportSource = this.xrptScheduleReportSubExam2;
            this.subExam.Size = new System.Drawing.Size(533, 25);
            // 
            // dataScheduleTableAdapter
            // 
            this.dataScheduleTableAdapter.ClearBeforeFill = true;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Height = 0;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Height = 20;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // xrptScheduleReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.DetailReport,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.DataAdapter = this.gBL_ENVTableAdapter;
            this.DataMember = "GBL_ENV";
            this.DataSource = this.dsScheduleReport1;
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 0, 20);
            this.Name = "xrptScheduleReport";
            this.PageHeight = 827;
            this.PageWidth = 583;
            this.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.Version = "11.1";
            ((System.ComponentModel.ISupportInitialize)(this.dsScheduleReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrptScheduleReportSubIns2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrptScheduleReportSubExam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private Envision.Plugin.XtraFile.xtraData.dsScheduleReport dsScheduleReport1;
        private Envision.Plugin.XtraFile.xtraData.dsScheduleReportTableAdapters.GBL_ENVTableAdapter gBL_ENVTableAdapter;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private Envision.Plugin.XtraFile.xtraData.dsScheduleReportTableAdapters.dataScheduleTableAdapter dataScheduleTableAdapter;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRSubreport subExam;
        private xrptScheduleReportSubExam xrptScheduleReportSubExam1;
        private DevExpress.XtraReports.UI.XRSubreport subIns;
        private xrptScheduleReportSubIns xrptScheduleReportSubIns1;
        private DevExpress.XtraReports.UI.XRLabel lblPrintBy;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel lblCreatedOn;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel lblCreatedBy;
        private xrptScheduleReportSubExam xrptScheduleReportSubExam2;
        private xrptScheduleReportSubIns xrptScheduleReportSubIns2;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lblHN;
        private DevExpress.XtraReports.UI.XRLabel lblPatientThai;
        private DevExpress.XtraReports.UI.XRLabel lblAppointDt;
        private DevExpress.XtraReports.UI.XRLabel lblPatientEng;
        private DevExpress.XtraReports.UI.XRLabel lblGender;
        private DevExpress.XtraReports.UI.XRLabel lblClinic;
        private DevExpress.XtraReports.UI.XRLabel lblAge;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode2;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel lblPatientID;
        private DevExpress.XtraReports.UI.XRLabel lblPrintOn;
        private DevExpress.XtraReports.UI.XRLabel lblConfirmOn;
        private DevExpress.XtraReports.UI.XRLabel lblConfirmBy;
    }
}
