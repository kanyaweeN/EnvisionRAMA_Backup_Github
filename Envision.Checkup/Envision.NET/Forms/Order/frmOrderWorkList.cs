using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common;
using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Forms.GBLMessage;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;


namespace RIS.Forms.Order
{
    public partial class frmOrderWorkList : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private MyMessageBox msg = new MyMessageBox();
        private int[] langid;
        private string defaultlangs;

        private DataSet dsData;

        public frmOrderWorkList(UUL.ControlFrame.Controls.TabControl Cls)
        {
            InitializeComponent();
            loadFormLanguage();
            CloseControl = Cls;
            loadData();
            timer1.Interval = 10000;
        }
        private void loadFormLanguage()
        {
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
            catch { }
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

        private void loadData() {
            this.Cursor = Cursors.WaitCursor;
            dsData = new DataSet();
            ProcessGetXRAYREQ process = new ProcessGetXRAYREQ();
            process.StoreType = 1;
            process.Invoke();
            dsData = process.Result;
            setGridWorkList();
            this.Cursor = Cursors.Default;
            timer1.Enabled = true;
        }
        private void setGridWorkList() { 
            DataTable dtt=dsData.Tables[0];
            foreach (DataRow dr in dtt.Rows)
            {
                string str = dr["DOCNAME"].ToString();
                int index = str.IndexOf("\\");
                if (index > -1) 
                    str = str.Remove(index);
                dr["DOCNAME"] = str;
            }

            dtt.Columns.Add("colDelete");
            grdWorkList.DataSource = dtt;

            view1.OptionsView.ShowBands = false;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            view1.OptionsView.ShowColumnHeaders = true;
            for (int i = 0; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;
            view1.Columns["REQUESTNO"].Caption = "Req. No";
            view1.Columns["REQUESTNO"].Visible = true;
            view1.Columns["REQUESTNO"].OptionsColumn.ReadOnly = true;
            view1.Columns["REQUESTNO"].ColVIndex = 0;
            view1.Columns["HN"].Caption = "HN";
            view1.Columns["HN"].Visible = true;
            view1.Columns["HN"].OptionsColumn.ReadOnly = true;
            view1.Columns["HN"].ColVIndex = 1;
            view1.Columns["FULLNAME"].Caption = "ชื่อ - นามสกุล";
            view1.Columns["FULLNAME"].Width = 200;
            view1.Columns["FULLNAME"].Visible = true;
            view1.Columns["FULLNAME"].OptionsColumn.ReadOnly = true;
            view1.Columns["FULLNAME"].ColVIndex = 2;
            view1.Columns["DOCNAME"].Caption = "แพทย์";
            view1.Columns["DOCNAME"].Width = 150;
            view1.Columns["DOCNAME"].Visible = true;
            view1.Columns["DOCNAME"].OptionsColumn.ReadOnly = true;
            view1.Columns["DOCNAME"].ColVIndex = 3;
            view1.Columns["ORDER_DT"].Caption = "Order date";
            view1.Columns["ORDER_DT"].Visible = true;
            view1.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
            view1.Columns["ORDER_DT"].ColVIndex = 4;
            view1.Columns["colDelete"].Caption = string.Empty;
            view1.Columns["colDelete"].Visible = true;
            
            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btnMakeOrder_Click);
            view1.Columns["colDelete"].Caption = string.Empty;
            view1.Columns["colDelete"].ColumnEdit = btn;
            view1.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            view1.Columns["colDelete"].Width = 50;
            view1.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

        }

        void btnMakeOrder_Click(object sender, EventArgs e)
        {
            string s = msg.ShowAlert("UID1047", new GBLEnvVariable().CurrentLanguageID);
            if (s == "2")
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                int OrderID = Convert.ToInt32(dr["ORDER_ID"]);
                frmOrders frm = new frmOrders(OrderID, "New", CloseControl);
                UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
                page.Selected = true;
                int index = CloseControl.SelectedIndex;
                CloseControl.TabPages.Add(page);
                CloseControl.TabPages.RemoveAt(index);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            loadData();

        }

        #region Manu Tab 
        private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmArrivalWorkList frm = new RIS.Forms.Order.frmArrivalWorkList(this.CloseControl);
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
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmViewPerformance frm = new frmViewPerformance(this.CloseControl);
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
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barManul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Manual", this.CloseControl);
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtInsurace.Focus();
        }
        #endregion
    }
}