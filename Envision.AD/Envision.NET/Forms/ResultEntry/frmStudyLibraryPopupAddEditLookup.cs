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
using Envision.NET.Forms.Dialog;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmStudyLibraryPopupAddEditLookup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DataTable DataSource 
        { 
            get{ return dtDataSource; }
            set { dtDataSource = value; } 
        }
        public string ColumnFirst { get; set; }
        public string ColumnSecond { get; set; }
        public string ColumnThird { get; set; }
        public string ColumnFourth { get; set; }
        public string FormHeaderName { get; set; }

        private DataTable dtDataSource;
        public DataTable retValue { get; set; }
        public event ValueDataTableEventHandler ValueUpdated;

        public frmStudyLibraryPopupAddEditLookup()
        {
            InitializeComponent();
        }
        private void frmPopupRadstudyGroupLookup_Load(object sender, EventArgs e)
        {
            this.Text = FormHeaderName;
            this.ribbonPage1.Text = FormHeaderName;

            ReloadPopupRadstudyGroupLookup();
        }

        private void LoadPopupRadstudyGroupLookupData()
        {
            dtDataSource.Columns.Add("colCHK");

            foreach (DataRow dr in dtDataSource.Rows)
                dr["colCHK"] = "N";
            dtDataSource.AcceptChanges();

            //if (retValue != null && retValue.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in retValue.Rows)
            //    {
            //        DataRow[] drs = dtDataSource.Select(ColumnFirst + "=" + dr[ColumnFirst]);
            //        if (drs.Length > 0)
            //        { 
            //            foreach(DataRow drsCheck in drs)
            //                drsCheck["colCHK"] = "Y";
            //        }
            //    }
            //}
        }
        private void LoadPopupRadstudyGroupLookupFilter()
        {
            if (retValue == null || retValue.Rows.Count == 0) return;

            foreach (DataRow dr in retValue.Rows)
            {
                string filterExpress = ColumnFirst + "=" + dr[ColumnFirst] + "";
                DataRow[] rows = dtDataSource.Select(filterExpress);
                if (rows.Length > 0)
                    rows[0]["colCHK"] = "Y";
                dtDataSource.AcceptChanges();
            }        
        }
        private void LoadPopupRadstudyGroupLookupGrid()
        {
            gcLookup.DataSource = dtDataSource;

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
            gvLookup.Columns["colCHK"].OptionsColumn.ShowCaption = false;

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
                gvLookup.Columns[ColumnThird].Width = 200;                
                
                gvLookup.Columns[ColumnFourth].ColVIndex = 3;
                gvLookup.Columns[ColumnFourth].Caption = "Title";
                gvLookup.Columns[ColumnFourth].Width = 100;
            }

            //gvLookup.BestFitColumns();
        }
        #region Check All
        bool ItemFlag = false;
        private Graphics Grp;
        private Rectangle Rta;
        private RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();

        private void gvLookup_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Caption == "Checked")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, ItemFlag);
                e.Handled = true;
                Grp = e.Graphics;
                Rta = e.Bounds;

            }
        }

        private void DrawCheckBox(Graphics g, Rectangle r, bool chk)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;

            info = (DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)edit.CreateViewInfo();
            painter = (DevExpress.XtraEditors.Drawing.CheckEditPainter)edit.CreatePainter();
            info.EditValue = chk;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);

            painter.Draw(args);
            args.Cache.Dispose();
        }
        private void gvLookup_ColumnFilterChanged(object sender, EventArgs e)
        {
            DataTable dtt = (DataTable)gcLookup.DataSource;
            DataRow[] rows = dtt.Select(gvLookup.ActiveFilterString);
            ItemFlag = true;
            foreach (DataRow row in rows)
            {
                if (row["colCHK"] == "N")
                {
                    ItemFlag = false;
                    break;
                }
            }
            //DrawCheckBox(Grp, Rta, ItemFlag);

            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info = (DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)edit.CreateViewInfo();
            info.EditValue = ItemFlag;
            //info.Bounds = r;
            //info.CalcViewInfo(g);
            //args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);


        }
        private void gvLookup_Click(object sender, EventArgs e)
        {
            GridHitInfo info;

            Point pt = gvLookup.GridControl.PointToClient(Control.MousePosition);
            info = gvLookup.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                if (info.Column.Caption == "Checked")
                {
                    if (ItemFlag == false)
                    {
                        DataTable dtt = (DataTable)gcLookup.DataSource;
                        DataRow[] rows = dtt.Select(gvLookup.ActiveFilterString);
                        foreach (DataRow row in rows)
                        {
                            row["colCHK"] = "Y";
                        }
                        dtt.AcceptChanges();
                        gcLookup.DataSource = dtt;
                        ItemFlag = true;
                    }
                    else
                    {
                        DataTable dtt = (DataTable)gcLookup.DataSource;
                        DataRow[] rows = dtt.Select(gvLookup.ActiveFilterString);
                        foreach (DataRow row in rows)
                        {
                            row["colCHK"] = "N";
                        }
                        dtt.AcceptChanges();
                        gcLookup.DataSource = dtt;
                        ItemFlag = false;
                    }
                }
            }
        }
        #endregion
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
            int rowIdx = dtDataSource.Rows.IndexOf(row);

            string strChk = row["colCHK"].ToString();
            if (strChk == "Y")
                dtDataSource.Rows[rowIdx]["colCHK"] = "N";
            else
                dtDataSource.Rows[rowIdx]["colCHK"] = "Y";

            dtDataSource.AcceptChanges();
            gvLookup.RefreshData();
        }
        private void btnRipSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            retValue = dtDataSource.Clone();

            DataRow[] rows = dtDataSource.Select("colCHK='Y'");
            foreach (DataRow dr in rows)
                retValue.Rows.Add(dr.ItemArray);

            retValue.AcceptChanges();
            
            this.DialogResult = DialogResult.OK;
            
            ValueDataTableEventArgs valueArgs = new ValueDataTableEventArgs(retValue);
            ValueUpdated(this, valueArgs);
            this.Close();
        }
        private void btnRipClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (btnSelect.Caption == "Select All")
            {
                for(int i=0; i<gvLookup.RowCount;i++)
                {
                    DataRow row = gvLookup.GetDataRow(i);
                    row["colCHK"] = "Y";
                }

                btnSelect.Caption = "Unselect All";
                btnSelect.LargeImageIndex = 3;
            }
            else
            {
                foreach (DataRow dr in dtDataSource.Rows)
                    dr["colCHK"] = "N";
                dtDataSource.AcceptChanges();
                gvLookup.RefreshData();

                btnSelect.Caption = "Select All";
                btnSelect.LargeImageIndex = 2;
            }
        }

        
    }
}