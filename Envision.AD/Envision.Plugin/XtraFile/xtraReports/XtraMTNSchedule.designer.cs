namespace Envision.Plugin.XtraFile.xtraReports
{
    partial class XtraMTNSchedule
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
            this.tbCellMTN_DT = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbCellSTART_TIME = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbCellEND_TIME = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbCellMODALITY_UID = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbCellMTN_SCH_STATUS_TEXT = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbCellMTN_COST = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbCellRESPONSIBLE_PERSON_NAME = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbCellCOMMENTS = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbCellMTN_TYPE_UID = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.Height = 58;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Location = new System.Drawing.Point(0, 0);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(1000, 58);
            this.xrTable1.StylePriority.UseBorders = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tbCellMTN_DT,
            this.tbCellSTART_TIME,
            this.tbCellEND_TIME,
            this.tbCellMODALITY_UID,
            this.tbCellMTN_SCH_STATUS_TEXT,
            this.tbCellMTN_COST,
            this.tbCellRESPONSIBLE_PERSON_NAME,
            this.tbCellCOMMENTS,
            this.tbCellMTN_TYPE_UID});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1;
            // 
            // tbCellMTN_DT
            // 
            this.tbCellMTN_DT.Name = "tbCellMTN_DT";
            this.tbCellMTN_DT.StylePriority.UseTextAlignment = false;
            this.tbCellMTN_DT.Text = "MTN_DT";
            this.tbCellMTN_DT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tbCellMTN_DT.Weight = 0.25075000000000003;
            // 
            // tbCellSTART_TIME
            // 
            this.tbCellSTART_TIME.Name = "tbCellSTART_TIME";
            this.tbCellSTART_TIME.StylePriority.UseTextAlignment = false;
            this.tbCellSTART_TIME.Text = "START_TIME";
            this.tbCellSTART_TIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tbCellSTART_TIME.Weight = 0.273875;
            // 
            // tbCellEND_TIME
            // 
            this.tbCellEND_TIME.Name = "tbCellEND_TIME";
            this.tbCellEND_TIME.StylePriority.UseTextAlignment = false;
            this.tbCellEND_TIME.Text = "END_TIME";
            this.tbCellEND_TIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tbCellEND_TIME.Weight = 0.30087499999999995;
            // 
            // tbCellMODALITY_UID
            // 
            this.tbCellMODALITY_UID.Name = "tbCellMODALITY_UID";
            this.tbCellMODALITY_UID.StylePriority.UseTextAlignment = false;
            this.tbCellMODALITY_UID.Text = "MODALITY_UID";
            this.tbCellMODALITY_UID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tbCellMODALITY_UID.Weight = 0.30049999999999988;
            // 
            // tbCellMTN_SCH_STATUS_TEXT
            // 
            this.tbCellMTN_SCH_STATUS_TEXT.Name = "tbCellMTN_SCH_STATUS_TEXT";
            this.tbCellMTN_SCH_STATUS_TEXT.StylePriority.UseTextAlignment = false;
            this.tbCellMTN_SCH_STATUS_TEXT.Text = "MTN_SCH_STATUS_TEXT";
            this.tbCellMTN_SCH_STATUS_TEXT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tbCellMTN_SCH_STATUS_TEXT.Weight = 0.37500000000000022;
            // 
            // tbCellMTN_COST
            // 
            this.tbCellMTN_COST.Name = "tbCellMTN_COST";
            this.tbCellMTN_COST.StylePriority.UseTextAlignment = false;
            this.tbCellMTN_COST.Text = "MTN_COST";
            this.tbCellMTN_COST.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tbCellMTN_COST.Weight = 0.29949999999999988;
            // 
            // tbCellRESPONSIBLE_PERSON_NAME
            // 
            this.tbCellRESPONSIBLE_PERSON_NAME.Name = "tbCellRESPONSIBLE_PERSON_NAME";
            this.tbCellRESPONSIBLE_PERSON_NAME.StylePriority.UseTextAlignment = false;
            this.tbCellRESPONSIBLE_PERSON_NAME.Text = "RESPONSIBLE_PERSON_NAME";
            this.tbCellRESPONSIBLE_PERSON_NAME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tbCellRESPONSIBLE_PERSON_NAME.Weight = 0.35087499999999994;
            // 
            // tbCellCOMMENTS
            // 
            this.tbCellCOMMENTS.Name = "tbCellCOMMENTS";
            this.tbCellCOMMENTS.StylePriority.UseTextAlignment = false;
            this.tbCellCOMMENTS.Text = "COMMENTS";
            this.tbCellCOMMENTS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tbCellCOMMENTS.Weight = 0.524875;
            // 
            // tbCellMTN_TYPE_UID
            // 
            this.tbCellMTN_TYPE_UID.Name = "tbCellMTN_TYPE_UID";
            this.tbCellMTN_TYPE_UID.StylePriority.UseTextAlignment = false;
            this.tbCellMTN_TYPE_UID.Text = "MTN_TYPE_UID";
            this.tbCellMTN_TYPE_UID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tbCellMTN_TYPE_UID.Weight = 0.32374999999999987;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.PageHeader.Height = 42;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Location = new System.Drawing.Point(0, 0);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.Size = new System.Drawing.Size(1000, 42);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Schedule Date";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.25075000000000003;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Start Date";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 0.273875;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "End Date";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 0.30087499999999995;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "Modality";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 0.30049999999999988;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "Status";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell5.Weight = 0.37500000000000022;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "Cost";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 0.29949999999999988;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Responsible Name";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 0.35087499999999994;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "Comments";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell8.Weight = 0.524875;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "Type";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 0.32374999999999987;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 30;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.ReportHeader.Height = 48;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(83, 8);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.Size = new System.Drawing.Size(417, 33);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Modality Maintenance Schedule";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XtraMTNSchedule
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.Name = "XtraMTNSchedule";
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "9.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tbCellMODALITY_UID;
        private DevExpress.XtraReports.UI.XRTableCell tbCellMTN_SCH_STATUS_TEXT;
        private DevExpress.XtraReports.UI.XRTableCell tbCellMTN_COST;
        private DevExpress.XtraReports.UI.XRTableCell tbCellMTN_DT;
        private DevExpress.XtraReports.UI.XRTableCell tbCellSTART_TIME;
        private DevExpress.XtraReports.UI.XRTableCell tbCellEND_TIME;
        private DevExpress.XtraReports.UI.XRTableCell tbCellRESPONSIBLE_PERSON_NAME;
        private DevExpress.XtraReports.UI.XRTableCell tbCellCOMMENTS;
        private DevExpress.XtraReports.UI.XRTableCell tbCellMTN_TYPE_UID;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}
