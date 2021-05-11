using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmPopupRadstudyGroupLookup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DataTable DataSource 
        { 
            get{ return dtRadStudy; }
            set{ dtRadStudy = value; } 
        }
        public string ColumnFirst { get; set; }
        public string ColumnSecond { get; set; }
        public string ColumnThird { get; set; }
        public string ColumnFourth { get; set; }
        public string FormHeaderName { get; set; }

        private DataTable dtRadStudy;
        private DataTable dtResult;

        public frmPopupRadstudyGroupLookup(ref DataTable dtResult)
        {
            this.dtResult = dtResult;
            InitializeComponent();
        }
        private void frmPopupRadstudyGroupLookup_Load(object sender, EventArgs e)
        {
            this.Text = FormHeaderName;
            this.ribbonPage1.Text = FormHeaderName;
            this.dtResult = new DataTable();

            ReloadPopupRadstudyGroupLookup();
        }

        private void LoadPopupRadstudyGroupLookupData()
        {
            dtRadStudy.Columns.Add("colCHK");

            foreach (DataRow dr in dtRadStudy.Rows)
                dr["colCHK"] = "N";

            dtRadStudy.AcceptChanges();
        }
        private void LoadPopupRadstudyGroupLookupFilter()
        {

        }
        private void LoadPopupRadstudyGroupLookupGrid()
        {
            gcLookup.DataSource = dtRadStudy;

            //gvLookup.OptionsView.ColumnAutoWidth = true;
            foreach (BandedGridColumn col in gvLookup.Columns)
            {
                col.OptionsColumn.ReadOnly = true;
                col.Visible = false;
            }

            gvLookup.Columns[ColumnSecond].ColVIndex = 1;
            gvLookup.Columns[ColumnSecond].Caption = "Code";
            gvLookup.Columns[ColumnSecond].Width = 100;

            gvLookup.Columns[ColumnThird].ColVIndex = 2;
            gvLookup.Columns[ColumnThird].Caption = "Name";
            gvLookup.Columns[ColumnThird].Width = 300;

            gvLookup.Columns["colCHK"].ColVIndex = 3;
            gvLookup.Columns["colCHK"].Caption = "Checked";
            gvLookup.Columns["colCHK"].Width = 50;
            gvLookup.Columns["colCHK"].OptionsColumn.ReadOnly = false;

            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            //chk.Caption = string.Empty;
            //chk.ValueChecked = "Y";
            //chk.ValueGrayed = "N";
            //chk.ValueUnchecked = "N";
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = CheckStyles.Standard;
            chk.NullStyle = StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = FormatType.Custom;
            chk.Caption = string.Empty;
            chk.EditValueChanged += new EventHandler(chk_EditValueChanged);
            gvLookup.Columns["colCHK"].ColumnEdit = chk;

            if (ColumnFourth != null && ColumnFourth.Length > 0)
            {
                gvLookup.Columns[ColumnFourth].ColVIndex = 3;
                gvLookup.Columns[ColumnFourth].Caption = "Title";
                gvLookup.Columns[ColumnFourth].Width = 100;
            }

            //gvLookup.BestFitColumns();
        }
        private void ReloadPopupRadstudyGroupLookup()
        {
            LoadPopupRadstudyGroupLookupData();
            LoadPopupRadstudyGroupLookupFilter();
            LoadPopupRadstudyGroupLookupGrid();
        }

        private void chk_EditValueChanged(object sender, EventArgs e)
        {
            if (gvLookup.FocusedRowHandle < 0) return;

            DataRow row = gvLookup.GetFocusedDataRow();
            int rowIdx = dtRadStudy.Rows.IndexOf(row);

            string strChk = row["colCHK"].ToString();
            if (strChk == "Y")
                dtRadStudy.Rows[rowIdx]["colCHK"] = "N";
            else
                dtRadStudy.Rows[rowIdx]["colCHK"] = "Y";

            dtRadStudy.AcceptChanges();
            gvLookup.RefreshData();
        }
        private void btnRipSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            dtResult = dtRadStudy.Clone();

            DataRow[] rows = dtRadStudy.Select("colCHK='Y'");
            foreach (DataRow dr in rows)
                dtResult.Rows.Add(dr.ItemArray);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnRipClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}