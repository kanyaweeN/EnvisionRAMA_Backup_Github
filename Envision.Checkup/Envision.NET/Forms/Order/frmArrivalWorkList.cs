using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Operational;
using RIS.Forms.GBLMessage;


using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;

namespace RIS.Forms.Order
{
    public partial class frmArrivalWorkList : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataSet ds = null;
        private ProcessGetRISOrderdtl process = null;
        private RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
        private MyMessageBox msg = new MyMessageBox();
        private int[] langid;
        private string defaultlangs;
        bool flagConfirm = false;
        bool flagArrival = false;

        public frmArrivalWorkList(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitControl();
            LoadDataToGrid();
            SetColumnInGrid();
            LoadFormLanguage();
        }

        private void frmArrivalWorkList_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void InitControl()
        {
            dateFrom.DateTime = DateTime.Today.AddDays(-1);
            dateTo.DateTime = DateTime.Today;
        }
        private void LoadDataToGrid()
        {
            process = new ProcessGetRISOrderdtl(dateFrom.DateTime, dateTo.DateTime);
            ds = new DataSet();
            process.Invoke();
            ds = process.Result;
        }
        private void SetColumnInGrid()
        {
            advBandedGridView1.OptionsView.ShowAutoFilterRow = true;
            gridControl1.DataSource = ds.Tables[0];
            advBandedGridView1.OptionsView.ShowBands = false;
            //set „ÀÈÀ—«ø‘≈¥Ï· ¥ßµ√ß°≈“ß
            //set „ÀÈÀ—ø‘≈¥Ï¡’ checkbox

            for (int i = 0; i < advBandedGridView1.Columns.Count; i++)
                advBandedGridView1.Columns[i].Visible = false;

            //advBandedGridView1.OptionsView.ShowIndicator = false;
            //advBandedGridView1.OptionsView.ShowGroupPanel = false;
            
            advBandedGridView1.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["HN"].Visible = true;
            advBandedGridView1.Columns["HN"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["HN"].Width = 100;
            advBandedGridView1.Columns["HN"].Width = 80;

            advBandedGridView1.Columns["NameThai"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["NameThai"].Visible = true;
            advBandedGridView1.Columns["NameThai"].Caption = "Patient Name";
            advBandedGridView1.Columns["NameThai"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["NameThai"].Width = 240;
            advBandedGridView1.Columns["NameThai"].Width = 190;

            advBandedGridView1.Columns["EXAM_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["EXAM_UID"].Visible = true;
            advBandedGridView1.Columns["EXAM_UID"].Caption = "Exam Code";
            advBandedGridView1.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["EXAM_UID"].Width = 90;

            advBandedGridView1.Columns["EXAM_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["EXAM_NAME"].Visible = true;
            advBandedGridView1.Columns["EXAM_NAME"].Caption = "Exam Name";
            advBandedGridView1.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["EXAM_NAME"].Width = 130;

            advBandedGridView1.Columns["ORDER_DT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["ORDER_DT"].Visible = true;
            advBandedGridView1.Columns["ORDER_DT"].Caption = "Exam Date";
            advBandedGridView1.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["ORDER_DT"].Width = 110;

            advBandedGridView1.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["MODALITY_NAME"].Visible = true;
            advBandedGridView1.Columns["MODALITY_NAME"].Caption = "Modality";
            advBandedGridView1.Columns["MODALITY_NAME"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["MODALITY_NAME"].Width = 100;

            advBandedGridView1.Columns["Confirm"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Confirm"].Visible = true;
            advBandedGridView1.Columns["Confirm"].Width = 40;
            advBandedGridView1.Columns["Confirm"].Name = "Confirm";
            advBandedGridView1.Columns["Confirm"].Caption = string.Empty;
            RepositoryItemCheckEdit chkConfirm = new RepositoryItemCheckEdit();
            chkConfirm.ValueChecked = "C";
            chkConfirm.ValueUnchecked = "N";
            chkConfirm.Click += new EventHandler(chkConfirm_Click);
            chkConfirm.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkConfirm.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkConfirm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            advBandedGridView1.Columns["Confirm"].ColumnEdit = chkConfirm;
            advBandedGridView1.Columns["Confirm"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            
            advBandedGridView1.Columns["SELF_ARRIVAL"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["SELF_ARRIVAL"].Visible = true;
            advBandedGridView1.Columns["SELF_ARRIVAL"].Width = 40;
            advBandedGridView1.Columns["SELF_ARRIVAL"].Name = "SELF_ARRIVAL";
            advBandedGridView1.Columns["SELF_ARRIVAL"].Caption = string.Empty;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkArrival= new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkArrival.ValueChecked = "A";
            chkArrival.ValueUnchecked = "N";
            chkArrival.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkArrival.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkArrival.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkArrival.Click += new EventHandler(chkArrival_Click);
            advBandedGridView1.Columns["SELF_ARRIVAL"].ColumnEdit = chkArrival;
            advBandedGridView1.Columns["SELF_ARRIVAL"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        }
        private void LoadFormLanguage() {
            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;
            fl.LanguageID = 1;
            fl.ProcedureType = 2;
            ProcessGetLanguage langs = new ProcessGetLanguage();
            langs.FormLanguage = fl;
            try
            {
                langs.Invoke();
            }
            catch{}
            try
            {

                DataTable dt = langs.ResultSet.Tables[0];
                langid = new int[dt.Rows.Count];
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    string lid = dt.Rows[k]["LANG_ID"].ToString();
                    langid[k] = Convert.ToInt32(lid);
                    if ((dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim()) == ("Y"))
                    {
                        defaultlangs = dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim();
                        new GBLEnvVariable().CurrentLanguageID = Convert.ToInt32(dt.Rows[k]["LANG_ID"].ToString().Trim());
                    }
                    k++;
                }
            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
            SetColumnInGrid();
        }

        private void chkConfirm_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (!chk.Checked)
            {
                chk.Checked = true;
                string sid = msg.ShowAlert("UID1033", new GBLEnvVariable().CurrentLanguageID);
                if(sid=="2")
                {
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    ProcessUpdateRISOrder process = new ProcessUpdateRISOrder();
                    process.RISOrder.ORDER_ID = Convert.ToInt32(dr[0]);
                    process.RISOrder.SELF_ARRIVAL = "C";
                    process.RISOrder.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    process.Invoke();
                    LoadDataToGrid();
                    SetColumnInGrid();
                }
                else
                    chk.Checked = false;

            }else {
                chk.Checked = false;
                string sid = msg.ShowAlert("UID1035", new GBLEnvVariable().CurrentLanguageID);
                if(sid=="2")
                {
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    ProcessUpdateRISOrder process = new ProcessUpdateRISOrder();
                    process.RISOrder.ORDER_ID = Convert.ToInt32(dr[0]);
                    process.RISOrder.SELF_ARRIVAL = "N";
                    process.RISOrder.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    process.Invoke();
                    LoadDataToGrid();
                    SetColumnInGrid();
                }
                else
                    chk.Checked = true;
            }
        }
        private void chkArrival_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            chk.Checked = true;
            string str = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "Confirm").ToString();
            advBandedGridView1.SetRowCellValue(advBandedGridView1.FocusedRowHandle, "Confirm", "C");
            string sid = msg.ShowAlert("UID1035", new GBLEnvVariable().CurrentLanguageID);
            if(sid=="2")
            {
                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                ProcessUpdateRISOrder process = new ProcessUpdateRISOrder();
                process.RISOrder.ORDER_ID = Convert.ToInt32(dr[0]);
                process.RISOrder.SELF_ARRIVAL = "A";
                process.RISOrder.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                process.Invoke();
                LoadDataToGrid();
                SetColumnInGrid();
            }
            else
            {
                advBandedGridView1.SetRowCellValue(advBandedGridView1.FocusedRowHandle, "Confirm", str);
                chk.Checked = false;
            }
        }

        private void advBandedGridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Name == "Confirm")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds,flagConfirm);
                e.Handled = true;
            }
            else if (e.Column.Name == "SELF_ARRIVAL")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds,flagArrival);
                e.Handled = true;
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
        private void advBandedGridView1_Click(object sender, EventArgs e)
        {
            if (ds == null) return;
            if (ds.Tables.Count == 0) return;
            GridHitInfo info;
            Point pt = advBandedGridView1.GridControl.PointToClient(Control.MousePosition);
            info = advBandedGridView1.CalcHitInfo(pt);
            if (info.InColumn) {
                if (info.Column == null) return;
                if (ds.Tables[0].Rows.Count == 0) return;
                if (info.Column.Name == "Confirm") {
                    for (int i = 0; i < advBandedGridView1.RowCount; i++)
                        advBandedGridView1.SetRowCellValue(i, "Confirm", "C");
                    flagConfirm = true;
                    flagArrival = false;
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["Confirm"]);
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["SELF_ARRIVAL"]);
                    string sid = msg.ShowAlert("UID1034", new GBLEnvVariable().CurrentLanguageID);
                    if (sid == "1")
                    {
                        LoadDataToGrid();
                        SetColumnInGrid();
                    }
                    else
                    {
                        for (int i = 0; i < advBandedGridView1.RowCount; i++)
                        {
                            DataRow dr = advBandedGridView1.GetDataRow(i);
                            ProcessUpdateRISOrder process = new ProcessUpdateRISOrder();
                            process.RISOrder.ORDER_ID = Convert.ToInt32(dr[0]);
                            process.RISOrder.SELF_ARRIVAL = "C";
                            process.RISOrder.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                            process.Invoke();
                        }
                        LoadDataToGrid();
                        SetColumnInGrid();
                    }
                    flagConfirm = false;
                    flagArrival = false;
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["Confirm"]);
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["SELF_ARRIVAL"]);
                }
                else if (info.Column.Name == "SELF_ARRIVAL") {
                    for (int i = 0; i < advBandedGridView1.RowCount; i++)
                    {
                        advBandedGridView1.SetRowCellValue(i, "Confirm", "C");
                        advBandedGridView1.SetRowCellValue(i, "SELF_ARRIVAL", "A");
                    }
                    flagConfirm = true;
                    flagArrival = true;
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["Confirm"]);
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["SELF_ARRIVAL"]);
                    string sid = msg.ShowAlert("UID1034", new GBLEnvVariable().CurrentLanguageID);
                    if (sid == "1")
                    {
                       
                        LoadDataToGrid();
                        SetColumnInGrid();

                        
                    }
                    else
                    {
                        for (int i = 0; i < advBandedGridView1.RowCount; i++)
                        {
                            DataRow dr = advBandedGridView1.GetDataRow(i);
                            ProcessUpdateRISOrder process = new ProcessUpdateRISOrder();
                            process.RISOrder.ORDER_ID = Convert.ToInt32(dr[0]);
                            process.RISOrder.SELF_ARRIVAL = "A";
                            process.RISOrder.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                            process.Invoke();
                        }
                        LoadDataToGrid();
                        SetColumnInGrid();
                    }
                    flagConfirm = false;
                    flagArrival = false;
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["Confirm"]);
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["SELF_ARRIVAL"]);

                }
            }
        }

        #region Manu Tab
        private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmArrivalWorkList frm = new RIS.Forms.Order.frmArrivalWorkList(this.CloseControl);
            //System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            //frm.BackColor = c;
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtHN.Focus();
        }
        private void barCreateNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("New", this.CloseControl);
            //System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            //frm.BackColor = c;
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtHN.Focus();
        }
        private void barModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Edit", this.CloseControl);
            //System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            //frm.BackColor = c;
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtOrderNo.Focus();
        }
        private void barSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Schedule.frmScheduleWorkList frm = new RIS.Forms.Schedule.frmScheduleWorkList(this.CloseControl);
            //System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            //frm.BackColor = c;
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtHN.Focus();
        }
        private void barLastOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Last", this.CloseControl);
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtHN.Focus();
        }
        private void barPrintLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmReprint frm = new RIS.Forms.Order.frmReprint(this.CloseControl);
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmViewPerformance frm = new frmViewPerformance(this.CloseControl);
            //System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            //frm.BackColor = c;
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < CloseControl.TabPages.Count; i++)
            {
                if (CloseControl.TabPages[i].Title == "Home")
                {
                    CloseControl.TabPages[i].Selected = true;
                    return;
                }
            }
            RIS.Forms.Main.frmMainTab frm = new RIS.Forms.Main.frmMainTab(this.CloseControl);
            //System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            //frm.BackColor = c;
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        #endregion

        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
             if ((int)e.KeyChar == 8) e.Handled = false;
             else if ((int)e.KeyChar == 13)
             {
                 if (txtHN.Text.Trim() != string.Empty)
                 {
                     string s = RIS.Operational.Translator.ConvertHNtoKKU.HN_KKU(txtHN.Text);
                     if (!RIS.Operational.Translator.ConvertHNtoKKU.IsUseHn(s))
                     {
                         msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                         gridControl1.DataSource = null;
                         ds = null;
                         return;
                     }
                 }
                 ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl(txtHN.Text);
                 process.Invoke();
                 DataSet dsData = process.Result;
                 if (dsData != null)
                     if (dsData.Tables.Count > 0)
                         if (dsData.Tables[0].Rows.Count > 0)
                         {
                             ds = new DataSet();
                             ds = dsData;
                             SetColumnInGrid();
                             return;
                         }
                 msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                 ds = null;
                 gridControl1.DataSource = null;
             }
            //
            
        }
    }
}