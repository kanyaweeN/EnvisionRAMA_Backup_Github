using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

using DevExpress.XtraEditors.Repository;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.NET.Forms.Orders;
using Envision.BusinessLogic.ProcessRead;
using Envision.Plugin.DirectPrint;
using Envision.NET.Forms.Main;
using Envision.Plugin.XtraFile.xtraReports;
using System.Drawing.Printing;


namespace Envision.NET.Forms.Orders
{
    public partial class frmReprint : MasterForm
    {
        private DataSet ds;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private bool IsFirstLoad = true;

        public enum FilterMode
        {
            Date, HN
        }
        //private FilterMode fMode = FilterMode.Date;
        private FilterMode fMode = FilterMode.HN;

        public frmReprint()
        {
            InitializeComponent();
            ds = new DataSet();
            this.StartPosition = FormStartPosition.CenterScreen;
            SetFilter();
            LoadOrderData();
            BindGridOrder();
            loadDataPrintList();

            txtHN.Focus();
        }
        private void loadDataPrintList()
        {
            foreach (string item in PrinterSettings.InstalledPrinters)
            {
                cmbPrinterOrder.Properties.Items.Add(item);
                cmbPrinterSticker.Properties.Items.Add(item);
            }

            cmbPrinterOrder.Text =
            cmbPrinterSticker.Text = new PrintDocument().PrinterSettings.PrinterName;
        }
        /// <summary>
        /// This method use to set filter
        /// </summary>
        private void SetFilter()
        {
            this.dteFrom.DateTime = DateTime.Now; //set initial datetime
            this.dteTo.DateTime = DateTime.Now; //set initail datetime

            rdHN.Checked = true;
            cmbPrinterSticker.Enabled = false;
        }

        #region Manu Tab 
        //private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //frmArrivalWorkList frm = new frmArrivalWorkList(this.CloseControl);
        //    ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
        //    ////frm.BackColor = c;
        //    //frm.BackColor = Color.White;
        //    //frm.MaximizeBox = false;
        //    //frm.MinimizeBox = false;
        //    //frm.Text = frm.Text;
        //    //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
        //    //page.Selected = true;
        //    //int index = CloseControl.SelectedIndex;
        //    //CloseControl.TabPages.Add(page);
        //    //CloseControl.TabPages.RemoveAt(index);
        //    //frm.txtHN.Focus();
        //}
        //private void barCreateNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("New", this.CloseControl);
        //    ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
        //    ////frm.BackColor = c;
        //    //frm.BackColor = Color.White;
        //    //frm.MaximizeBox = false;
        //    //frm.MinimizeBox = false;
        //    //frm.Text = frm.Text;
        //    //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
        //    //page.Selected = true;
        //    //int index = CloseControl.SelectedIndex;
        //    //CloseControl.TabPages.Add(page);
        //    //CloseControl.TabPages.RemoveAt(index);
        //    //frm.txtHN.Focus();
        //}
        //private void barModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Edit", this.CloseControl);
        //    ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
        //    ////frm.BackColor = c;
        //    //frm.BackColor = Color.White;
        //    //frm.MaximizeBox = false;
        //    //frm.MinimizeBox = false;
        //    //frm.Text = frm.Text;
        //    //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
        //    //page.Selected = true;
        //    //int index = CloseControl.SelectedIndex;
        //    //CloseControl.TabPages.Add(page);
        //    //CloseControl.TabPages.RemoveAt(index);
        //    //frm.txtOrderNo.Focus();
        //}
        //private void barSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //RIS.Forms.Schedule.frmScheduleWorkList frm = new RIS.Forms.Schedule.frmScheduleWorkList(this.CloseControl);
        //    ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
        //    ////frm.BackColor = c;
        //    //frm.BackColor = Color.White;
        //    //frm.MaximizeBox = false;
        //    //frm.MinimizeBox = false;
        //    //frm.Text = frm.Text;
        //    //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
        //    //page.Selected = true;
        //    //int index = CloseControl.SelectedIndex;
        //    //CloseControl.TabPages.Add(page);
        //    //CloseControl.TabPages.RemoveAt(index);
        //    //frm.txtHN.Focus();
        //}
        //private void barLastOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Last", this.CloseControl);
        //    //frm.BackColor = Color.White;
        //    //frm.MaximizeBox = false;
        //    //frm.MinimizeBox = false;
        //    //frm.Text = frm.Text;
        //    //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
        //    //page.Selected = true;
        //    //int index = CloseControl.SelectedIndex;
        //    //CloseControl.TabPages.Add(page);
        //    //CloseControl.TabPages.RemoveAt(index);
        //    //frm.txtHN.Focus();
        //}
        //private void barPrintLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //RIS.Forms.Order.frmReprint frm = new RIS.Forms.Order.frmReprint(this.CloseControl);
        //    //frm.BackColor = Color.White;
        //    //frm.MaximizeBox = false;
        //    //frm.MinimizeBox = false;
        //    //frm.Text = frm.Text;
        //    //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
        //    //page.Selected = true;
        //    //int index = CloseControl.SelectedIndex;
        //    //CloseControl.TabPages.Add(page);
        //    //CloseControl.TabPages.RemoveAt(index);
        //}
        //private void barView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //RIS.Forms.Order.frmViewPerformance frm = new frmViewPerformance(this.CloseControl);
        //    ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
        //    ////frm.BackColor = c;
        //    //frm.BackColor = Color.White;
        //    //frm.MaximizeBox = false;
        //    //frm.MinimizeBox = false;
        //    //frm.Text = frm.Text;
        //    //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
        //    //page.Selected = true;
        //    //int index = CloseControl.SelectedIndex;
        //    //CloseControl.TabPages.Add(page);
        //    //CloseControl.TabPages.RemoveAt(index);
        //}
        //private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //for (int i = 0; i < CloseControl.TabPages.Count; i++)
        //    //{
        //    //    if (CloseControl.TabPages[i].Title == "Home")
        //    //    {
        //    //        CloseControl.TabPages[i].Selected = true;
        //    //        return;
        //    //    }
        //    //}
        //    //RIS.Forms.Main.frmMainTab frm = new RIS.Forms.Main.frmMainTab(this.CloseControl);
        //    //System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
        //    //frm.BackColor = c;
        //    //frm.MaximizeBox = false;
        //    //frm.MinimizeBox = false;
        //    //frm.Text = frm.Text;
        //    //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
        //    //page.Selected = true;
        //    //int index = CloseControl.SelectedIndex;
        //    //CloseControl.TabPages.Add(page);
        //    //CloseControl.TabPages.RemoveAt(index);
        //}
        //private void barManul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Manual", this.CloseControl);
        //    //frm.BackColor = Color.White;
        //    //frm.MaximizeBox = false;
        //    //frm.MinimizeBox = false;
        //    //frm.Text = frm.Text;
        //    //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
        //    //page.Selected = true;
        //    //int index = CloseControl.SelectedIndex;
        //    //CloseControl.TabPages.Add(page);
        //    //CloseControl.TabPages.RemoveAt(index);
        //    //frm.txtInsurace.Focus();
        //}
        //private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    this.Close();
        //}

        private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmArrivalWorkList'");
            if (rows.Length == 0)
                return;
            else
            {
                Envision.NET.Forms.Orders.frmArrivalWorkListNew frm = new Envision.NET.Forms.Orders.frmArrivalWorkListNew();
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
            //Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            //DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            //DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmScheduleWorkList'");
            //if (rows.Length == 0)
            //    return;
            //else
            //{
            //    int id = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
            //    if (!main.FormIsAlive(id))
            //    {
            //        Envision.NET.Forms.Schedule.frmScheduleWorkList frm = new Envision.NET.Forms.Schedule.frmScheduleWorkList();
            //        frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
            //        frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
            //        frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
            //        frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
            //        frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
            //        frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
            //        frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
            //        frm.Text = frm.Menu_Name_User;
            //        frm.ShowWaitDialog();
            //        frm.MdiParent = this.MdiParent;
            //        frm.Show();
            //        this.Close();
            //    }
            //}

            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            //DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmArrivalWorkListExtend'");
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmArrivalWorkListNew'");

            if (rows.Length > 0)
            {
                int id = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                if (!main.FormIsAlive(id))
                {
                    Envision.NET.Forms.Orders.frmArrivalWorkListNew frm = new Envision.NET.Forms.Orders.frmArrivalWorkListNew();
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
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmReprint' and MENU_ID=2");
            if (rows.Length == 0)
            {
                return;
            }
            else
            {
                int id = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                if (!main.FormIsAlive(id))
                {
                    Envision.NET.Forms.Orders.frmReprint frm = new Envision.NET.Forms.Orders.frmReprint();
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
                    this.Close();
                }
            }
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
        private void barScanImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmScanImage frm = new frmScanImage();
            frm.ShowDialog();
            frm.Dispose();
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtt = (DataTable)grdOrder.DataSource;
            bool flag = true;
            int numberOfCopy = Convert.ToInt32(textNoOfPrint.Text);
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
                    print.PrinterSelected.PrinterName = cmbPrinterOrder.Text;
                    DataView dv = new DataView(dtt);
                    dv.RowFilter = " colCheck='Y'";
                    for (int i = 0; i < dv.Count; i++)
                    {
                        ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                        geExam.Invoke();
                        ProcessGetRISOrderdtl geOrdtl = new ProcessGetRISOrderdtl();
                        DataTable dtOrdtl = geOrdtl.GetPreview(dv[i]["ACCESSION_NO"].ToString()).Tables[0];
                        DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_UID='" + dtOrdtl.Rows[0]["EXAM_UID"].ToString() + "'");
                        if (!string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                        {
                            if (drExam[0]["UNIT_ID"].ToString() == "2")
                            {
                                int orderID = Convert.ToInt32(dv[i]["ORDER_ID"]);
                                print.OrderEntryDirectPrintAIMC(orderID, env.UserID,numberOfCopy);
                            }
                            else
                            {
                                int orderID = Convert.ToInt32(dv[i]["ORDER_ID"]);
                                print.OrderEntryDirectPrint(orderID, env.UserID,numberOfCopy);
                            }
                        }

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
                    DirectPrint print = new DirectPrint();
                    print.PrinterSelected.PrinterName = cmbPrinterSticker.Text;
                    foreach (DataRow dr in dtt.Rows)
                    {
                        if (dr["colCheck"].ToString() == "Y")
                        {
                            string hn = dr["HN"].ToString();
                            int exam_id = chkPrintExam.Checked == false ? 0 : Convert.ToInt32(dr["EXAM_ID"]);
                            print.PrintSticker(hn, exam_id, chkPrintExam.Checked, numberOfCopy);
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
            if (fMode == FilterMode.Date)
            {
                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                ds = new DataSet();
                DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                ds = process.GetReprint(0, string.Empty, dtFrom, dtTo);
            }
            else if (fMode == FilterMode.HN)
            {
                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                ds = new DataSet();
                DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                ds = process.GetReprint(2, txtHN.Text, dtFrom, dtTo);
            }
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
            if (fMode == FilterMode.Date)
            {
                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataSet ds = new DataSet();
                ds = process.GetReprint(1, string.Empty, dteFrom.DateTime, dteTo.DateTime);
                dtt = ds.Tables[0];
            }
            else if (fMode == FilterMode.HN)
            {
                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataSet ds = new DataSet();
                ds = process.GetReprint(3, txtHN.Text, dteFrom.DateTime, dteTo.DateTime);
                dtt = ds.Tables[0];
            }
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
                cmbPrinterSticker.Enabled = false;
                cmbPrinterOrder.Enabled = true;
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
                cmbPrinterOrder.Enabled = false;
                cmbPrinterSticker.Enabled = true;
                BindStickerData();
                Cursor = Cursors.Default;

            }
        }
        private void rdDate_CheckedChanged(object sender, EventArgs e)
        {
            //if (IsFirstLoad) return;

            if (rdDate.Checked)
            {
                fMode = FilterMode.Date;
                txtHN.Visible = false;

                SearchData();
            }
        }

        private void rdHN_CheckedChanged(object sender, EventArgs e)
        {
            //if (IsFirstLoad) return;

            if (rdHN.Checked)
            {
                fMode = FilterMode.HN;
                txtHN.Visible = true;
                txtHN.Focus();

                //SearchData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoOrder.Checked)
            {
                if (fMode == FilterMode.Date)
                {
                    ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                    ds = new DataSet();
                    DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                    DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                    ds = process.GetReprint(0, string.Empty, dtFrom, dtTo);
                    this.BindGridOrder(); //refresh grid
                }
                else if (fMode == FilterMode.HN)
                {
                    if (string.IsNullOrEmpty(txtHN.Text.Trim()))
                        MessageBox.Show("Fill HN please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                        ds = new DataSet();
                        DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                        DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                        ds = process.GetReprint(2, txtHN.Text, dtFrom, dtTo);

                        this.BindGridOrder(); //refresh grid
                    }
                }
            }
            else
            {
                if (fMode == FilterMode.Date)
                {
                    ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                    ds = new DataSet();
                    DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                    DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                    ds = process.GetReprint(1, string.Empty, dtFrom, dtTo);
                    this.BindStickerData(); //refresh grid
                }
                else if (fMode == FilterMode.HN)
                {
                    if (string.IsNullOrEmpty(txtHN.Text.Trim()))
                        MessageBox.Show("Fill HN please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                        ds = new DataSet();
                        DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                        DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                        ds = process.GetReprint(3, txtHN.Text, dtFrom, dtTo);

                        this.BindStickerData(); //refresh grid
                    }
                }
            }
        }
        /// <summary>
        /// This method use to capture key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnSearch_Click(sender, null);
        }

        private void frmReprint_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
            IsFirstLoad = false;
        }

        private void barComments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Comment.frmComment frm = null;
            if (view1.FocusedRowHandle < 0)
            {
                frm = new Envision.NET.Forms.Comment.frmComment();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else 
            {
                string hn = view1.GetDataRow(view1.FocusedRowHandle)["HN"].ToString();
                frm = new Envision.NET.Forms.Comment.frmComment(hn);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            frm.Dispose();
        }

        private void SearchData()
        {
            if (rdoOrder.Checked)
            {
                if (fMode == FilterMode.Date)
                {
                    ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                    ds = new DataSet();
                    DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                    DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                    ds = process.GetReprint(0, string.Empty, dtFrom, dtTo);
                    this.BindGridOrder(); //refresh grid
                }
                else if (fMode == FilterMode.HN)
                {
                    if (string.IsNullOrEmpty(txtHN.Text.Trim()))
                        MessageBox.Show("Fill HN please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                        ds = new DataSet();
                        DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                        DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                        ds = process.GetReprint(2, txtHN.Text, dtFrom, dtTo);

                        this.BindGridOrder(); //refresh grid
                    }
                }
            }
            else
            {
                if (fMode == FilterMode.Date)
                {
                    ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                    ds = new DataSet();
                    DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                    DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                    ds = process.GetReprint(1, string.Empty, dtFrom, dtTo);
                    this.BindStickerData(); //refresh grid
                }
                else if (fMode == FilterMode.HN)
                {
                    if (string.IsNullOrEmpty(txtHN.Text.Trim()))
                        MessageBox.Show("Fill HN please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                        ds = new DataSet();
                        DateTime dtFrom = new DateTime(dteFrom.DateTime.Year, dteFrom.DateTime.Month, dteFrom.DateTime.Day, 0, 0, 0);
                        DateTime dtTo = new DateTime(dteTo.DateTime.Year, dteTo.DateTime.Month, dteTo.DateTime.Day, 23, 59, 59);
                        ds = process.GetReprint(3, txtHN.Text, dtFrom, dtTo);

                        this.BindStickerData(); //refresh grid
                    }
                }
            }
        }

        private void grdOrder_Click(object sender, EventArgs e)
        {

        }

        private void cmbPrinterOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}