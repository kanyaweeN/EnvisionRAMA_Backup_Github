namespace Envision.Plugin.XtraFile.xtraReports
{
    partial class xrptOrderReportClinicalIndicationPage
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
            DevExpress.XtraPrinting.BarCode.Code39Generator code39Generator1 = new DevExpress.XtraPrinting.BarCode.Code39Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.txtClinicalIndication = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHN = new DevExpress.XtraReports.UI.XRLabel();
            this.txtPatientName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtClinicType = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGender = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAge = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrderingDept = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode2 = new DevExpress.XtraReports.UI.XRBarCode();
            this.txtOrgName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgAddress = new DevExpress.XtraReports.UI.XRLabel();
            this.orgImage1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.txtPatientNameEng = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtLMP = new DevExpress.XtraReports.UI.XRLabel();
            this.lbAppintBy = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAppointBy = new DevExpress.XtraReports.UI.XRLabel();
            this.txtPatientID = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtClinicalIndication});
            this.Detail.Height = 33;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtClinicalIndication
            // 
            this.txtClinicalIndication.AutoWidth = true;
            this.txtClinicalIndication.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtClinicalIndication.CanShrink = true;
            this.txtClinicalIndication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClinicalIndication.Location = new System.Drawing.Point(8, 0);
            this.txtClinicalIndication.Multiline = true;
            this.txtClinicalIndication.Name = "txtClinicalIndication";
            this.txtClinicalIndication.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtClinicalIndication.Size = new System.Drawing.Size(525, 33);
            this.txtClinicalIndication.StylePriority.UseBorders = false;
            this.txtClinicalIndication.StylePriority.UseFont = false;
            this.txtClinicalIndication.StylePriority.UseTextAlignment = false;
            this.txtClinicalIndication.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtPatientID,
            this.txtAppointBy,
            this.lbAppintBy,
            this.txtLMP,
            this.xrLabel3,
            this.txtPatientNameEng,
            this.orgImage1,
            this.txtOrgAddress,
            this.txtOrgName,
            this.xrBarCode2,
            this.txtOrderingDept,
            this.xrLabel33,
            this.txtStatus,
            this.xrLabel31,
            this.txtAge,
            this.xrLabel27,
            this.txtGender,
            this.xrLabel25,
            this.txtClinicType,
            this.txtPatientName,
            this.txtHN,
            this.xrLabel20,
            this.xrLabel18,
            this.xrLabel17});
            this.PageHeader.Height = 125;
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
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.Location = new System.Drawing.Point(0, 42);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.Size = new System.Drawing.Size(42, 17);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "HN : ";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.Location = new System.Drawing.Point(0, 58);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.Size = new System.Drawing.Size(42, 17);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Thai : ";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xrLabel20.Location = new System.Drawing.Point(0, 92);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.Size = new System.Drawing.Size(42, 17);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Clinic : ";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtHN
            // 
            this.txtHN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHN.Location = new System.Drawing.Point(42, 42);
            this.txtHN.Name = "txtHN";
            this.txtHN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHN.Size = new System.Drawing.Size(325, 17);
            this.txtHN.StylePriority.UseFont = false;
            this.txtHN.StylePriority.UseTextAlignment = false;
            this.txtHN.Text = "txtHN";
            this.txtHN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.Location = new System.Drawing.Point(42, 58);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPatientName.Size = new System.Drawing.Size(300, 17);
            this.txtPatientName.StylePriority.UseFont = false;
            this.txtPatientName.StylePriority.UseTextAlignment = false;
            this.txtPatientName.Text = "txtPatientName";
            this.txtPatientName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtClinicType
            // 
            this.txtClinicType.AutoWidth = true;
            this.txtClinicType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClinicType.Location = new System.Drawing.Point(42, 92);
            this.txtClinicType.Name = "txtClinicType";
            this.txtClinicType.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtClinicType.Size = new System.Drawing.Size(150, 17);
            this.txtClinicType.StylePriority.UseFont = false;
            this.txtClinicType.StylePriority.UseTextAlignment = false;
            this.txtClinicType.Text = "txtClinicType";
            this.txtClinicType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.Location = new System.Drawing.Point(342, 58);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.Size = new System.Drawing.Size(83, 17);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "Gender : ";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // txtGender
            // 
            this.txtGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGender.Location = new System.Drawing.Point(425, 58);
            this.txtGender.Name = "txtGender";
            this.txtGender.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGender.Size = new System.Drawing.Size(108, 17);
            this.txtGender.StylePriority.UseFont = false;
            this.txtGender.StylePriority.UseTextAlignment = false;
            this.txtGender.Text = "txtGender";
            this.txtGender.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.Location = new System.Drawing.Point(342, 75);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.Size = new System.Drawing.Size(83, 17);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Age : ";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // txtAge
            // 
            this.txtAge.CanGrow = false;
            this.txtAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAge.Location = new System.Drawing.Point(425, 75);
            this.txtAge.Name = "txtAge";
            this.txtAge.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAge.Size = new System.Drawing.Size(108, 17);
            this.txtAge.StylePriority.UseFont = false;
            this.txtAge.StylePriority.UseTextAlignment = false;
            this.txtAge.Text = "txtAge";
            this.txtAge.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xrLabel31.Location = new System.Drawing.Point(342, 108);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.Size = new System.Drawing.Size(83, 17);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "Status : ";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtStatus
            // 
            this.txtStatus.AutoWidth = true;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtStatus.Location = new System.Drawing.Point(425, 108);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStatus.Size = new System.Drawing.Size(108, 17);
            this.txtStatus.StylePriority.UseFont = false;
            this.txtStatus.StylePriority.UseTextAlignment = false;
            this.txtStatus.Text = "txtStatus";
            this.txtStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xrLabel33.Location = new System.Drawing.Point(342, 92);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.Size = new System.Drawing.Size(83, 17);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "OPD/W :";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtOrderingDept
            // 
            this.txtOrderingDept.CanGrow = false;
            this.txtOrderingDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderingDept.Location = new System.Drawing.Point(425, 92);
            this.txtOrderingDept.Name = "txtOrderingDept";
            this.txtOrderingDept.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrderingDept.Size = new System.Drawing.Size(108, 17);
            this.txtOrderingDept.StylePriority.UseFont = false;
            this.txtOrderingDept.StylePriority.UseTextAlignment = false;
            this.txtOrderingDept.Text = "txtOrderingDept";
            this.txtOrderingDept.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.txtOrderingDept.WordWrap = false;
            // 
            // xrBarCode2
            // 
            this.xrBarCode2.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrBarCode2.AutoModule = true;
            this.xrBarCode2.Font = new System.Drawing.Font("Times New Roman", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrBarCode2.Location = new System.Drawing.Point(367, 42);
            this.xrBarCode2.Name = "xrBarCode2";
            this.xrBarCode2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrBarCode2.ShowText = false;
            this.xrBarCode2.Size = new System.Drawing.Size(167, 17);
            this.xrBarCode2.StylePriority.UseFont = false;
            this.xrBarCode2.StylePriority.UsePadding = false;
            this.xrBarCode2.StylePriority.UseTextAlignment = false;
            code39Generator1.CalcCheckSum = false;
            code39Generator1.WideNarrowRatio = 3F;
            this.xrBarCode2.Symbology = code39Generator1;
            this.xrBarCode2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtOrgName
            // 
            this.txtOrgName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtOrgName.Location = new System.Drawing.Point(42, 0);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgName.Size = new System.Drawing.Size(458, 17);
            this.txtOrgName.StylePriority.UseFont = false;
            this.txtOrgName.StylePriority.UseTextAlignment = false;
            this.txtOrgName.Text = "txtOrgName";
            this.txtOrgName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtOrgAddress
            // 
            this.txtOrgAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtOrgAddress.Location = new System.Drawing.Point(42, 17);
            this.txtOrgAddress.Name = "txtOrgAddress";
            this.txtOrgAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgAddress.Size = new System.Drawing.Size(458, 25);
            this.txtOrgAddress.StylePriority.UseFont = false;
            this.txtOrgAddress.StylePriority.UseTextAlignment = false;
            this.txtOrgAddress.Text = "txtOrgAddress";
            this.txtOrgAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // orgImage1
            // 
            this.orgImage1.Location = new System.Drawing.Point(0, 0);
            this.orgImage1.Name = "orgImage1";
            this.orgImage1.Size = new System.Drawing.Size(42, 42);
            // 
            // txtPatientNameEng
            // 
            this.txtPatientNameEng.CanGrow = false;
            this.txtPatientNameEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPatientNameEng.Location = new System.Drawing.Point(42, 75);
            this.txtPatientNameEng.Name = "txtPatientNameEng";
            this.txtPatientNameEng.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPatientNameEng.Size = new System.Drawing.Size(300, 17);
            this.txtPatientNameEng.StylePriority.UseFont = false;
            this.txtPatientNameEng.StylePriority.UseTextAlignment = false;
            this.txtPatientNameEng.Text = "txtPatientNameEng";
            this.txtPatientNameEng.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xrLabel3.Location = new System.Drawing.Point(192, 92);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(42, 17);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "LMP : ";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtLMP
            // 
            this.txtLMP.AutoWidth = true;
            this.txtLMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLMP.Location = new System.Drawing.Point(233, 92);
            this.txtLMP.Name = "txtLMP";
            this.txtLMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtLMP.Size = new System.Drawing.Size(108, 17);
            this.txtLMP.StylePriority.UseFont = false;
            this.txtLMP.StylePriority.UseTextAlignment = false;
            this.txtLMP.Text = "txtLMP";
            this.txtLMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbAppintBy
            // 
            this.lbAppintBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbAppintBy.Location = new System.Drawing.Point(0, 108);
            this.lbAppintBy.Name = "lbAppintBy";
            this.lbAppintBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbAppintBy.Size = new System.Drawing.Size(58, 17);
            this.lbAppintBy.StylePriority.UseFont = false;
            this.lbAppintBy.StylePriority.UseTextAlignment = false;
            this.lbAppintBy.Text = "ลงนัดโดย : ";
            this.lbAppintBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtAppointBy
            // 
            this.txtAppointBy.AutoWidth = true;
            this.txtAppointBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppointBy.Location = new System.Drawing.Point(58, 108);
            this.txtAppointBy.Name = "txtAppointBy";
            this.txtAppointBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAppointBy.Size = new System.Drawing.Size(283, 17);
            this.txtAppointBy.StylePriority.UseFont = false;
            this.txtAppointBy.StylePriority.UseTextAlignment = false;
            this.txtAppointBy.Text = "txtAppointBy";
            this.txtAppointBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtPatientID
            // 
            this.txtPatientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtPatientID.Location = new System.Drawing.Point(500, 0);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPatientID.Size = new System.Drawing.Size(33, 42);
            this.txtPatientID.StylePriority.UseFont = false;
            this.txtPatientID.Text = "P1";
            // 
            // xrptOrderReportClinicalIndicationPage
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.Name = "xrptOrderReportClinicalIndicationPage";
            this.PageHeight = 827;
            this.PageWidth = 583;
            this.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.Version = "9.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel txtClinicalIndication;
        private DevExpress.XtraReports.UI.XRLabel txtPatientID;
        private DevExpress.XtraReports.UI.XRLabel txtAppointBy;
        private DevExpress.XtraReports.UI.XRLabel lbAppintBy;
        private DevExpress.XtraReports.UI.XRLabel txtLMP;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel txtPatientNameEng;
        private DevExpress.XtraReports.UI.XRPictureBox orgImage1;
        private DevExpress.XtraReports.UI.XRLabel txtOrgAddress;
        private DevExpress.XtraReports.UI.XRLabel txtOrgName;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode2;
        private DevExpress.XtraReports.UI.XRLabel txtOrderingDept;
        private DevExpress.XtraReports.UI.XRLabel xrLabel33;
        private DevExpress.XtraReports.UI.XRLabel txtStatus;
        private DevExpress.XtraReports.UI.XRLabel xrLabel31;
        private DevExpress.XtraReports.UI.XRLabel txtAge;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
        private DevExpress.XtraReports.UI.XRLabel txtGender;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLabel txtClinicType;
        private DevExpress.XtraReports.UI.XRLabel txtPatientName;
        private DevExpress.XtraReports.UI.XRLabel txtHN;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
    }
}
