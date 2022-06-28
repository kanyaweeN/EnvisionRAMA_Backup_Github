using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using Envision.Plugin.XtraFile.xtraReports;
using Envision.Plugin.XtraFile.xtraReports.InterventionDocument;

namespace Envision.NET.Forms.Schedule
{
    public partial class frmScheduleInterventionDocument : Form
    {
        public string HN { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public DataTable dtPrintDoc;

        public frmScheduleInterventionDocument()
        {
            InitializeComponent();
        }
        private void frmSchedulePrintDocument_Load(object sender, EventArgs e)
        {
            ReLoadSchemaTable();
        }

        private void LoadSchemaTableData()
        {
            dtPrintDoc = new DataTable("PrintDoc");
            dtPrintDoc.Columns.Add("IS_CHECKED");
            dtPrintDoc.Columns.Add("PRINT_PREVIEW");
            dtPrintDoc.Columns.Add("REPORT_NAME");
            dtPrintDoc.Columns.Add("REPORT_ID");
            dtPrintDoc.AcceptChanges();

            dtPrintDoc.Rows.Add(new object[] { "N", "", "Angiogram with Angioplasty", "1" });
            dtPrintDoc.Rows.Add(new object[] { "N", "", "Angiography", "2" });
            dtPrintDoc.Rows.Add(new object[] { "N", "", "Biopsy", "3" });
            dtPrintDoc.Rows.Add(new object[] { "N", "", "RFA", "4" });
            dtPrintDoc.Rows.Add(new object[] { "N", "", "TACE", "5" });
            dtPrintDoc.AcceptChanges();
        }
        private void LoadSchemaTableFilter()
        { 
        
        }
        private void LoadSchemaTableGrid()
        {
            gcPrintDoc.DataSource = dtPrintDoc;

            RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
            edit.AllowGrayed = false;
            edit.ValueChecked = "Y";
            edit.ValueUnchecked = "N";
            edit.CheckedChanged += new EventHandler(edit_CheckedChanged);
            gvPrintDoc.Columns["IS_CHECKED"].ColumnEdit = edit;
            gvPrintDoc.Columns["IS_CHECKED"].Caption = " ";
            gvPrintDoc.Columns["IS_CHECKED"].VisibleIndex = 1;
            gvPrintDoc.Columns["IS_CHECKED"].OptionsColumn.FixedWidth = true;
            gvPrintDoc.Columns["IS_CHECKED"].Width = 60;

            RepositoryItemHyperLinkEdit link = new RepositoryItemHyperLinkEdit();
            link.Caption = "Print Preview";
            //link.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            link.Click += new EventHandler(link_Click);
            gvPrintDoc.Columns["PRINT_PREVIEW"].ColumnEdit = link;
            gvPrintDoc.Columns["PRINT_PREVIEW"].Caption = "Print Preview";
            gvPrintDoc.Columns["PRINT_PREVIEW"].VisibleIndex = 2;
            gvPrintDoc.Columns["PRINT_PREVIEW"].OptionsColumn.FixedWidth = true;
            gvPrintDoc.Columns["PRINT_PREVIEW"].Width = 100;

            //RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            //btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //btn.Buttons[0].Caption = "Print Preview";
            //btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            //btn.Click += new EventHandler(link_Click);
            //gvPrintDoc.Columns["PRINT_PREVIEW"].ColumnEdit = btn;
            //gvPrintDoc.Columns["PRINT_PREVIEW"].Caption = "Print Preview";
            //gvPrintDoc.Columns["PRINT_PREVIEW"].VisibleIndex = 2;

            gvPrintDoc.Columns["REPORT_NAME"].Caption = "Name";
            gvPrintDoc.Columns["REPORT_NAME"].VisibleIndex = 3;
            gvPrintDoc.Columns["REPORT_NAME"].OptionsColumn.AllowEdit = false;

            gvPrintDoc.Columns["REPORT_ID"].Visible = false;

            gvPrintDoc.BestFitColumns();
        }
        private void ReLoadSchemaTable()
        {
            LoadSchemaTableData();
            LoadSchemaTableFilter();
            LoadSchemaTableGrid();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (DataRow row in dtPrintDoc.Rows)
            {
                if (row["IS_CHECKED"].ToString() == "Y")
                {
                    DirectPrint(row["REPORT_ID"].ToString());
                }
            }

            this.Close();
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void link_Click(object sender, EventArgs e)
        {
            ShowPrintPreview();
        }
        private void edit_CheckedChanged(object sender, EventArgs e)
        {
            if (gvPrintDoc.FocusedRowHandle < 0) return;

            DataRow row = gvPrintDoc.GetFocusedDataRow();
            DataRow[] rows = dtPrintDoc.Select("REPORT_ID='" + row["REPORT_ID"].ToString() + "'");
            if (rows.Length > 0)
            {
                if (rows[0]["IS_CHECKED"].ToString() == "Y")
                    rows[0]["IS_CHECKED"] = "N";
                else if (rows[0]["IS_CHECKED"].ToString() == "N")
                    rows[0]["IS_CHECKED"] = "Y";

                dtPrintDoc.AcceptChanges();
            }
        }

        private void imgControl_Click(object sender, EventArgs e)
        {
            PictureEdit pedit = (PictureEdit)sender;

            Form nf = new Form();
            nf.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            nf.Size = new Size(420, 600);
            nf.StartPosition = FormStartPosition.CenterScreen;
            nf.BackgroundImage = pedit.Image;
            nf.BackgroundImageLayout = ImageLayout.Stretch;
            nf.ShowDialog();
        }
        private void DirectPrint(string ReportID)
        {
            if (ReportID == "1")
            {
                xrptAngiogramWithAngioplasty rpt = new xrptAngiogramWithAngioplasty(HN, PatientName, Age);
                rpt.Print();
            }
            else if (ReportID == "2")
            {
                xrptAngiography rpt = new xrptAngiography(HN, PatientName, Age);
                rpt.Print();
            }
            else if (ReportID == "3")
            {
                xrptBiopsy rpt = new xrptBiopsy(HN, PatientName, Age);
                rpt.Print();
            }
            else if (ReportID == "4")
            {
                xrptRFA rpt = new xrptRFA(HN, PatientName, Age);
                rpt.Print();
            }
            else if (ReportID == "5")
            {
                xrptTACE rpt = new xrptTACE(HN, PatientName, Age);
                rpt.Print();
            }
        }
        private void ShowPrintPreview()
        {
            if (gvPrintDoc.FocusedRowHandle < 0) return;

            DataRow row = gvPrintDoc.GetFocusedDataRow();
            ShowPrintPreviewByReportID(row["REPORT_ID"].ToString());
        }
        private void ShowPrintPreviewByReportID(string ReportID)
        {
            if (ReportID == "1")
            {
                xrptAngiogramWithAngioplasty rpt = new xrptAngiogramWithAngioplasty(HN, PatientName, Age);
                rpt.ShowPreviewDialog();
            }
            else if (ReportID == "2")
            {
                xrptAngiography rpt = new xrptAngiography(HN, PatientName, Age);
                rpt.ShowPreviewDialog();
            }
            else if (ReportID == "3")
            {
                xrptBiopsy rpt = new xrptBiopsy(HN, PatientName, Age);
                rpt.ShowPreviewDialog();
            }
            else if (ReportID == "4")
            {
                xrptRFA rpt = new xrptRFA(HN, PatientName, Age);
                rpt.ShowPreviewDialog();
            }
            else if (ReportID == "5")
            {
                xrptTACE rpt = new xrptTACE(HN, PatientName, Age);
                rpt.ShowPreviewDialog();
            }
        }
    }
}
