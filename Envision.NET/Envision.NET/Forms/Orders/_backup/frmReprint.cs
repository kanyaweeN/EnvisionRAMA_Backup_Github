using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using DevExpress.XtraEditors.Repository;

using System.Net.Mail;
namespace Envision.NET.Forms.Orders
{
    public partial class frmReprint : Envision.NET.Forms.Main.MasterForm  // Form
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private DataSet ds;
        private MyMessageBox msg = new MyMessageBox();
       
        public frmReprint()
        {
            InitializeComponent();
        }

        #region Manu Tab 
        private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmArrivalWorkList'and MENU_ID=" + this.Menu_ID);
            if (rows.Length == 0)
                return;
            else
            {
                Envision.NET.Forms.Orders.frmArrivalWorkList frm = new Envision.NET.Forms.Orders.frmArrivalWorkList();
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.ShowWaitDialog();
                frm.MdiParent = this.MdiParent;
                frm.txtHN.Focus();
            }
        }
        private void barCreateNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {
                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("New");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();
            }
        }
        private void barModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {
                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("Edit");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();
            }
        }
        private void barSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmScheduleWorkList'");
            if (rows.Length == 0)
                return;
            else
            {
                int id = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                if (!main.FormIsAlive(id))
                {
                    Envision.NET.Forms.Schedule.frmScheduleWorkList frm = new Envision.NET.Forms.Schedule.frmScheduleWorkList();
                    frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                    frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                    frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                    frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                    frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                    frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                    frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                    frm.Text = frm.Menu_Name_User;
                    frm.ShowWaitDialog();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    this.Close();
                }
            }
        }
        private void barLastOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {

                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("Last");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();
            }
        }
        private void barPrintLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ds = new DataSet();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadOrderData();
            BindGridOrder();
        }
        private void barView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
       
        }
        private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((Envision.NET.Forms.Main.frmMain)this.MdiParent).DisplayHome();
        }
        private void barManul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {
                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("Manual");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();
            }
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void barJohnDoe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {
                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("JohnDoe");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();
              
            }
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
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    DataView dv = new DataView(dtt);
                    dv.RowFilter = " colCheck='Y'";
                    for (int i = 0; i < dv.Count; i++)
                    {
                        ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                        geExam.Invoke();
                        ProcessGetRISOrderdtl geOrdtl = new ProcessGetRISOrderdtl();
                        DataTable dtOrdtl = geOrdtl.GetPreview(dv[i]["ACCESSION_NO"].ToString()).Tables[0];
                        int orderID = Convert.ToInt32(dv[i]["ORDER_ID"]);
                        print.OrderEntryDirectPrint(orderID, env.UserID);

                        ////เลือก unit
                        //DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_UID='" + dtOrdtl.Rows[0]["EXAM_UID"].ToString() + "'");
                        //if (!string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                        //{
                        //    if (drExam[0]["UNIT_ID"].ToString() == "2")
                        //    {
                        //        int orderID = Convert.ToInt32(dv[i]["ORDER_ID"]);
                        //        print.OrderEntryDirectPrintAIMC(orderID, env.UserID);
                        //    }
                        //    else
                        //    {
                        //        int orderID = Convert.ToInt32(dv[i]["ORDER_ID"]);
                        //        print.OrderEntryDirectPrint(orderID, env.UserID);
                        //    }
                        //}

                    }
                    //

                    LoadOrderData();
                    BindGridOrder();
                }
                #endregion
            }
            else
            {
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
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    int numberOfPrint = Convert.ToInt32(textNoOfPrint.Text);
                    foreach (DataRow dr in dtt.Rows)
                    {
                        if (dr["colCheck"].ToString() == "Y")
                        {
                            string hn = dr["HN"].ToString();
                            int exam_id = chkPrintExam.Checked == false ? 0 : Convert.ToInt32(dr["EXAM_ID"]);
                            print.PrintSticker(hn, exam_id, chkPrintExam.Checked, numberOfPrint);
                        }
                    }
                    if (rdoOrder.Checked)
                    {
                        Cursor = Cursors.WaitCursor;
                        chkPrintExam.Checked = false;
                        chkPrintExam.Enabled = false;
                        LoadOrderData();
                        BindGridOrder();
                        Cursor = Cursors.Default;
                    }
                    else if (rdoSticker.Checked)
                    {
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
            view1.Columns["colCheck"].Caption = " ";
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
            view1.Columns["colCheck"].Caption = " ";
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

        private void frmReprint_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadOrderData();
            BindGridOrder();
            base.CloseWaitDialog();
        }
    }
}