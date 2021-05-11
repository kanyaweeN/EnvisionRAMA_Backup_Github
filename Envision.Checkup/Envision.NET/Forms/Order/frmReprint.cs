using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Forms.GBLMessage;
using RIS.Common.Common;
using RIS.BusinessLogic;
using DevExpress.XtraEditors.Repository;

using System.Net.Mail;
using RIS.Plugin.DirectPrint;
namespace RIS.Forms.Order
{
    public partial class frmReprint : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataSet ds;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();

        public frmReprint(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            ds = new DataSet();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadOrderData();
            BindGridOrder();
        }

        #region Manu Tab 
        private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmArrivalWorkList frm = new RIS.Forms.Order.frmArrivalWorkList(this.CloseControl);
            ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            ////frm.BackColor = c;
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barCreateNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("New", this.CloseControl);
            ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            ////frm.BackColor = c;
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Edit", this.CloseControl);
            ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            ////frm.BackColor = c;
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtOrderNo.Focus();
        }
        private void barSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Schedule.frmScheduleWorkList frm = new RIS.Forms.Schedule.frmScheduleWorkList(this.CloseControl);
            ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            ////frm.BackColor = c;
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barLastOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Last", this.CloseControl);
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
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
            System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            frm.BackColor = c;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barManul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Manual", this.CloseControl);
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtInsurace.Focus();
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtt = (DataTable)grdOrder.DataSource;
            bool flag = true;
            if (rdoOrder.Checked)
            {
                #region Print By Order 
                foreach (DataRow dr in dtt.Rows)
                {
                    if (dr["colCheck"].ToString() == "Y")
                    {

                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1035", env.CurrentLanguageID);
                    return;
                }
                string s = msg.ShowAlert("UID1036", env.CurrentLanguageID);
                if (s == "2")
                {
                    //เรียก Print
                    DirectPrint print = new DirectPrint();
                    DataView dv = new DataView(dtt);
                    dv.RowFilter = " colCheck='Y'";
                    int numberOfPrint = Convert.ToInt32(textNoOfPrint.Text);
                    for (int i = 0; i < dv.Count; i++)
                    {
                        int orderID = Convert.ToInt32(dv[i]["ORDER_ID"]);
                        print.OrderEntryDirectPrint(orderID, env.UserID, numberOfPrint);
                    }
                    //
                    LoadOrderData();
                    BindGridOrder();
                }
                #endregion
            }else{
                #region Print By Sticker 
                foreach (DataRow dr in dtt.Rows)
                {
                    if (dr["colCheck"].ToString() == "Y")
                    {

                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1035", env.CurrentLanguageID);
                    return;
                }
                string s = msg.ShowAlert("UID1036", env.CurrentLanguageID);
                if (s == "2")
                {
                    DirectPrint print = new DirectPrint();
                    int numberOfPrint = Convert.ToInt32(textNoOfPrint.Text);
                    foreach (DataRow dr in dtt.Rows) {
                        if (dr["colCheck"].ToString() == "Y") {
                            string hn = dr["HN"].ToString();
                            int exam_id = chkPrintExam.Checked == false ? 0 : Convert.ToInt32(dr["EXAM_ID"]);
                            print.PrintSticker(hn, exam_id,chkPrintExam.Checked,numberOfPrint);
                        }
                    }
                    if (rdoOrder.Checked) {
                        Cursor = Cursors.WaitCursor;
                        chkPrintExam.Checked = false;
                        chkPrintExam.Enabled = false;
                        LoadOrderData();
                        BindGridOrder();
                        Cursor = Cursors.Default;
                    }
                    else if (rdoSticker.Checked) {
                        Cursor = Cursors.WaitCursor;
                        chkPrintExam.Enabled = true;
                        BindStickerData();
                        Cursor = Cursors.Default;
                    }
                }
                #endregion

            }
        }
            

        private void LoadOrderData() { 
            ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
            ds = new DataSet();
            ds = process.GetReprint(0);
        }
        private void BindGridOrder() {
            if (ds == null) return;
            if (ds.Tables.Count == 0) return;
            DataTable dtt = ds.Tables[0];
            view1.Columns.Clear();
            dtt.Columns.Add("colCheck");
            grdOrder.DataSource = dtt;
            view1.RefreshData();

            for (int i = 0; i < view1.Columns.Count; i++)
            {
                view1.Columns[i].Visible = false;
                view1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            view1.OptionsView.ShowAutoFilterRow = true;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = true;

            view1.Columns["ORDER_ID"].VisibleIndex = 1;
            view1.Columns["ORDER_ID"].Caption = "Order No.";
            view1.Columns["ORDER_ID"].Width = 50;

            view1.Columns["HN"].VisibleIndex = 2;
            view1.Columns["HN"].Caption = "HN";
            view1.Columns["HN"].Width = 100;

            view1.Columns["ACCESSION_NO"].VisibleIndex = 3;
            view1.Columns["ACCESSION_NO"].Caption = "Accession No.";
            view1.Columns["ACCESSION_NO"].Width = 100;

            view1.Columns["HISName"].VisibleIndex = 4;
            view1.Columns["HISName"].Caption = "Name";
            view1.Columns["HISName"].Width = 300;

            view1.Columns["ORDER_DT"].VisibleIndex = 5;
            view1.Columns["ORDER_DT"].Caption = "Study time";
            view1.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view1.Columns["ORDER_DT"].DisplayFormat.FormatString = "g";
            view1.Columns["ORDER_DT"].Width = 100;

            view1.Columns["colCheck"].VisibleIndex = 6;
            view1.Columns["colCheck"].Caption = "";
            view1.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            view1.Columns["colCheck"].Width = 50;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chk.Click += new EventHandler(chk_Click);
            view1.Columns["colCheck"].ColumnEdit = chk;
        }

        private void LoadStickerData(ref DataTable dtt) {
            //ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
            //ds = new DataSet();
            //ds = process.GetReprint(1);
            ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
            DataSet ds = new DataSet();
            ds = process.GetReprint(1);
            dtt = ds.Tables[0];
        }
        private void BindStickerData() {
            DataTable dtt = new DataTable("Sticker");
            LoadStickerData(ref dtt);
            dtt.Columns.Add("colCheck");
            
            grdOrder.DataSource = null;
            view1.Columns.Clear();
            grdOrder.DataSource = dtt;

            for (int i = 0; i < view1.Columns.Count; i++)
            {
                view1.Columns[i].Visible = false;
                view1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            view1.OptionsView.ShowAutoFilterRow = true;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = true;

            view1.Columns["ORDER_ID"].VisibleIndex = 1;
            view1.Columns["ORDER_ID"].Caption = "Order No.";
            view1.Columns["ORDER_ID"].Width = 50;

            view1.Columns["HN"].VisibleIndex = 2;
            view1.Columns["HN"].Caption = "HN";
            view1.Columns["HN"].Width = 100;

            view1.Columns["HISName"].VisibleIndex = 5;
            view1.Columns["HISName"].Caption = "Name";
            view1.Columns["HISName"].Width = 200;

            view1.Columns["EXAM_NAME"].VisibleIndex = 3;
            view1.Columns["EXAM_NAME"].Caption = "Exam Name";
            view1.Columns["EXAM_NAME"].Width = 150;

            view1.Columns["ORDER_DT"].VisibleIndex = 6;
            view1.Columns["ORDER_DT"].Caption = "Study time";
            view1.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view1.Columns["ORDER_DT"].DisplayFormat.FormatString = "g";
            view1.Columns["ORDER_DT"].Width = 100;

            view1.Columns["ACCESSION_NO"].VisibleIndex = 4;
            view1.Columns["ACCESSION_NO"].Caption = "Accession No.";
            view1.Columns["ACCESSION_NO"].Width = 100;

            view1.Columns["colCheck"].VisibleIndex = 7;
            view1.Columns["colCheck"].Caption = "";
            view1.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            view1.Columns["colCheck"].Width = 50;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chk.Click += new EventHandler(chk_Click);
            view1.Columns["colCheck"].ColumnEdit = chk;
        }

        private void rdoOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOrder.Checked)
            {
                Cursor = Cursors.WaitCursor;
                chkPrintExam.Checked = false;
                chkPrintExam.Enabled = false;
                LoadOrderData();
                BindGridOrder();
                Cursor = Cursors.Default;
            }
        }
        private void rdoSticker_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSticker.Checked)
            {
                Cursor = Cursors.WaitCursor;
                chkPrintExam.Enabled = true;
                BindStickerData();
                Cursor = Cursors.Default;
            }
        }

    }
}