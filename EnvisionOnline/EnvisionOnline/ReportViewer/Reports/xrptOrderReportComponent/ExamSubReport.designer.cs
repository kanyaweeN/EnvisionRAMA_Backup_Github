namespace EnvisionOnline.ReportViewer.Reports.xrptOrderReportComponent
{
    partial class ExamSubReport
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
            DevExpress.XtraReports.UI.XRPanel xrPanel3;
            DevExpress.XtraPrinting.BarCode.Code39Generator code39Generator1 = new DevExpress.XtraPrinting.BarCode.Code39Generator();
            this.tSumRate = new DevExpress.XtraReports.UI.XRLabel();
            this.tCount = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.tableExam = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.txtComment = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAccessionNo = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBarCodeAccession = new DevExpress.XtraReports.UI.XRBarCode();
            this.tRoom = new DevExpress.XtraReports.UI.XRLabel();
            this.tExamTime = new DevExpress.XtraReports.UI.XRLabel();
            this.tRate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.tExamDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel80 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel79 = new DevExpress.XtraReports.UI.XRLabel();
            this.tExamStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.tExamName = new DevExpress.XtraReports.UI.XRLabel();
            this.tExamUID = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            xrPanel3 = new DevExpress.XtraReports.UI.XRPanel();
            ((System.ComponentModel.ISupportInitialize)(this.tableExam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // xrPanel3
            // 
            xrPanel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            xrPanel3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tSumRate,
            this.tCount,
            this.xrLabel65,
            this.xrLabel63});
            xrPanel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            xrPanel3.Name = "xrPanel3";
            xrPanel3.SizeF = new System.Drawing.SizeF(367F, 30F);
            xrPanel3.StylePriority.UseBorders = false;
            // 
            // tSumRate
            // 
            this.tSumRate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tSumRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tSumRate.LocationFloat = new DevExpress.Utils.PointFloat(275F, 5F);
            this.tSumRate.Name = "tSumRate";
            this.tSumRate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tSumRate.SizeF = new System.Drawing.SizeF(84F, 22F);
            this.tSumRate.StylePriority.UseBorders = false;
            this.tSumRate.StylePriority.UseFont = false;
            this.tSumRate.StylePriority.UseTextAlignment = false;
            this.tSumRate.Text = "tSumRate";
            this.tSumRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tCount
            // 
            this.tCount.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tCount.LocationFloat = new DevExpress.Utils.PointFloat(58F, 5F);
            this.tCount.Name = "tCount";
            this.tCount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tCount.SizeF = new System.Drawing.SizeF(100F, 22F);
            this.tCount.StylePriority.UseBorders = false;
            this.tCount.StylePriority.UseFont = false;
            this.tCount.StylePriority.UseTextAlignment = false;
            this.tCount.Text = "tCount";
            this.tCount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel65
            // 
            this.xrLabel65.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel65.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(217F, 5F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(50F, 22F);
            this.xrLabel65.StylePriority.UseBorders = false;
            this.xrLabel65.StylePriority.UseFont = false;
            this.xrLabel65.StylePriority.UseTextAlignment = false;
            this.xrLabel65.Text = "Total :";
            this.xrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel63
            // 
            this.xrLabel63.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel63.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(8F, 5F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(50F, 22F);
            this.xrLabel63.StylePriority.UseBorders = false;
            this.xrLabel63.StylePriority.UseFont = false;
            this.xrLabel63.StylePriority.UseTextAlignment = false;
            this.xrLabel63.Text = "Count :";
            this.xrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageBreak1,
            this.tableExam});
            this.Detail.HeightF = 80F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageBreak1.Name = "xrPageBreak1";
            this.xrPageBreak1.Visible = false;
            this.xrPageBreak1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPageBreak1_BeforePrint);
            // 
            // tableExam
            // 
            this.tableExam.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.tableExam.Name = "tableExam";
            this.tableExam.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.tableExam.SizeF = new System.Drawing.SizeF(367F, 80F);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseBorders = false;
            this.xrTableRow2.Weight = 0.75D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtComment,
            this.txtAccessionNo,
            this.txtBarCodeAccession,
            this.tRoom,
            this.tExamTime,
            this.tRate,
            this.xrLabel83,
            this.tExamDate,
            this.xrLabel80,
            this.xrLabel79,
            this.tExamStatus,
            this.tExamName,
            this.tExamUID});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Weight = 3D;
            // 
            // txtComment
            // 
            this.txtComment.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.LocationFloat = new DevExpress.Utils.PointFloat(8F, 55F);
            this.txtComment.Name = "txtComment";
            this.txtComment.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtComment.SizeF = new System.Drawing.SizeF(125F, 20F);
            this.txtComment.StylePriority.UseBorders = false;
            this.txtComment.StylePriority.UseFont = false;
            this.txtComment.StylePriority.UseTextAlignment = false;
            this.txtComment.Text = "Comment";
            this.txtComment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtAccessionNo
            // 
            this.txtAccessionNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtAccessionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccessionNo.LocationFloat = new DevExpress.Utils.PointFloat(167F, 41F);
            this.txtAccessionNo.Name = "txtAccessionNo";
            this.txtAccessionNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAccessionNo.SizeF = new System.Drawing.SizeF(192F, 17F);
            this.txtAccessionNo.StylePriority.UseBorders = false;
            this.txtAccessionNo.StylePriority.UseFont = false;
            this.txtAccessionNo.StylePriority.UseTextAlignment = false;
            this.txtAccessionNo.Text = "txtAccessionNo";
            this.txtAccessionNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtBarCodeAccession
            // 
            this.txtBarCodeAccession.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtBarCodeAccession.AutoModule = true;
            this.txtBarCodeAccession.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtBarCodeAccession.Font = new System.Drawing.Font("Times New Roman", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarCodeAccession.LocationFloat = new DevExpress.Utils.PointFloat(133F, 58F);
            this.txtBarCodeAccession.Name = "txtBarCodeAccession";
            this.txtBarCodeAccession.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.txtBarCodeAccession.ShowText = false;
            this.txtBarCodeAccession.SizeF = new System.Drawing.SizeF(225F, 17F);
            this.txtBarCodeAccession.StylePriority.UseBorders = false;
            this.txtBarCodeAccession.StylePriority.UseFont = false;
            this.txtBarCodeAccession.StylePriority.UsePadding = false;
            this.txtBarCodeAccession.StylePriority.UseTextAlignment = false;
            code39Generator1.CalcCheckSum = false;
            code39Generator1.WideNarrowRatio = 3F;
            this.txtBarCodeAccession.Symbology = code39Generator1;
            this.txtBarCodeAccession.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tRoom
            // 
            this.tRoom.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRoom.LocationFloat = new DevExpress.Utils.PointFloat(58F, 20F);
            this.tRoom.Name = "tRoom";
            this.tRoom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tRoom.SizeF = new System.Drawing.SizeF(165F, 17F);
            this.tRoom.StylePriority.UseBorders = false;
            this.tRoom.StylePriority.UseFont = false;
            this.tRoom.StylePriority.UseTextAlignment = false;
            this.tRoom.Text = "xrLabel8";
            this.tRoom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // tExamTime
            // 
            this.tExamTime.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tExamTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tExamTime.LocationFloat = new DevExpress.Utils.PointFloat(300F, 3F);
            this.tExamTime.Name = "tExamTime";
            this.tExamTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tExamTime.SizeF = new System.Drawing.SizeF(55F, 17F);
            this.tExamTime.StylePriority.UseBorders = false;
            this.tExamTime.StylePriority.UseFont = false;
            this.tExamTime.StylePriority.UseTextAlignment = false;
            this.tExamTime.Text = "xrLabel5";
            this.tExamTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tRate
            // 
            this.tRate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.tRate.LocationFloat = new DevExpress.Utils.PointFloat(275F, 20F);
            this.tRate.Name = "tRate";
            this.tRate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tRate.SizeF = new System.Drawing.SizeF(83F, 17F);
            this.tRate.StylePriority.UseBorders = false;
            this.tRate.StylePriority.UseFont = false;
            this.tRate.StylePriority.UseTextAlignment = false;
            this.tRate.Text = "xrLabel7";
            this.tRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel83
            // 
            this.xrLabel83.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel83.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(225F, 20F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(43F, 17F);
            this.xrLabel83.StylePriority.UseBorders = false;
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            this.xrLabel83.Text = "Rate : ";
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tExamDate
            // 
            this.tExamDate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tExamDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tExamDate.LocationFloat = new DevExpress.Utils.PointFloat(225F, 3F);
            this.tExamDate.Name = "tExamDate";
            this.tExamDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tExamDate.SizeF = new System.Drawing.SizeF(75F, 17F);
            this.tExamDate.StylePriority.UseBorders = false;
            this.tExamDate.StylePriority.UseFont = false;
            this.tExamDate.StylePriority.UseTextAlignment = false;
            this.tExamDate.Text = "xrLabel4";
            this.tExamDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel80
            // 
            this.xrLabel80.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel80.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel80.LocationFloat = new DevExpress.Utils.PointFloat(8F, 20F);
            this.xrLabel80.Name = "xrLabel80";
            this.xrLabel80.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel80.SizeF = new System.Drawing.SizeF(50F, 17F);
            this.xrLabel80.StylePriority.UseBorders = false;
            this.xrLabel80.StylePriority.UseFont = false;
            this.xrLabel80.StylePriority.UseTextAlignment = false;
            this.xrLabel80.Text = "Room : ";
            this.xrLabel80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel79
            // 
            this.xrLabel79.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel79.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel79.LocationFloat = new DevExpress.Utils.PointFloat(8F, 38F);
            this.xrLabel79.Name = "xrLabel79";
            this.xrLabel79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel79.SizeF = new System.Drawing.SizeF(50F, 17F);
            this.xrLabel79.StylePriority.UseBorders = false;
            this.xrLabel79.StylePriority.UseFont = false;
            this.xrLabel79.StylePriority.UseTextAlignment = false;
            this.xrLabel79.Text = "Status : ";
            this.xrLabel79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tExamStatus
            // 
            this.tExamStatus.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tExamStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tExamStatus.LocationFloat = new DevExpress.Utils.PointFloat(58F, 38F);
            this.tExamStatus.Name = "tExamStatus";
            this.tExamStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tExamStatus.SizeF = new System.Drawing.SizeF(100F, 17F);
            this.tExamStatus.StylePriority.UseBorders = false;
            this.tExamStatus.StylePriority.UseFont = false;
            this.tExamStatus.StylePriority.UseTextAlignment = false;
            this.tExamStatus.Text = "xrLabel9";
            this.tExamStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // tExamName
            // 
            this.tExamName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tExamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tExamName.LocationFloat = new DevExpress.Utils.PointFloat(58F, 3F);
            this.tExamName.Name = "tExamName";
            this.tExamName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tExamName.SizeF = new System.Drawing.SizeF(167F, 17F);
            this.tExamName.StylePriority.UseBorders = false;
            this.tExamName.StylePriority.UseFont = false;
            this.tExamName.Text = "xrLabel3";
            // 
            // tExamUID
            // 
            this.tExamUID.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tExamUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tExamUID.LocationFloat = new DevExpress.Utils.PointFloat(8F, 3F);
            this.tExamUID.Name = "tExamUID";
            this.tExamUID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tExamUID.SizeF = new System.Drawing.SizeF(50F, 17F);
            this.tExamUID.StylePriority.UseBorders = false;
            this.tExamUID.StylePriority.UseFont = false;
            this.tExamUID.StylePriority.UseTextAlignment = false;
            this.tExamUID.Text = "xrLabel11";
            this.tExamUID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tExamUID.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.tExamUID_BeforePrint);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            xrPanel3});
            this.GroupFooter1.HeightF = 30F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 0F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 0F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // ExamSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.GroupFooter1,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 827;
            this.PageWidth = 583;
            this.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.Version = "11.1";
            ((System.ComponentModel.ISupportInitialize)(this.tableExam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable tableExam;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRLabel txtComment;
        private DevExpress.XtraReports.UI.XRLabel txtAccessionNo;
        private DevExpress.XtraReports.UI.XRBarCode txtBarCodeAccession;
        private DevExpress.XtraReports.UI.XRLabel tRoom;
        private DevExpress.XtraReports.UI.XRLabel tExamTime;
        private DevExpress.XtraReports.UI.XRLabel tRate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel83;
        private DevExpress.XtraReports.UI.XRLabel tExamDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel80;
        private DevExpress.XtraReports.UI.XRLabel xrLabel79;
        private DevExpress.XtraReports.UI.XRLabel tExamStatus;
        private DevExpress.XtraReports.UI.XRLabel tExamName;
        private DevExpress.XtraReports.UI.XRLabel tExamUID;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel tSumRate;
        private DevExpress.XtraReports.UI.XRLabel tCount;
        private DevExpress.XtraReports.UI.XRLabel xrLabel65;
        private DevExpress.XtraReports.UI.XRLabel xrLabel63;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
    }
}
