using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Dialog;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using Envision.NET.Forms.Orders;


namespace Envision.NET.Forms.Orders
{
    public partial class frmOrderWorkList : Envision.NET.Forms.Main.MasterForm
    {
         
        private MyMessageBox msg = new MyMessageBox();
        private int[] langid;
        private string defaultlangs;

        private DataSet dsData;

        public frmOrderWorkList()
        {
            InitializeComponent();
            loadFormLanguage();
            timer1.Interval = 240000;
        }
        private void frmOrderWorkList_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
            laodDataFirstTime();
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
        private void laodDataFirstTime() {
            grdWorkList.Enabled = false;
            dsData = new DataSet();

            DateTime dtF = new DateTime();
            DateTime dtT = new DateTime();
            dtT = DateTime.Now;
            dtF = DateTime.Now;
            dateSearch.DateTime = dtF;
            dateSearch2.DateTime = dtT;
            loadDataDate();

            //ProcessGetXRAYREQ process = new ProcessGetXRAYREQ();
            //process.StoreType = 1;
            //process.Invoke();
            //dsData = process.Result;
            //setGridWorkList();
            grdWorkList.Enabled = true;

        }
        private void loadData() {
            grdWorkList.Enabled = false;
            if (!bgWL.IsBusy)
                bgWL.RunWorkerAsync();
            Application.DoEvents();
            dsData = new DataSet();
            ProcessGetXRAYREQ process = new ProcessGetXRAYREQ();
            process.StoreType = 1;
            process.Invoke();
            dsData = process.Result;
            setGridWorkList();
            this.Cursor = Cursors.Default;
            timer1.Enabled = true;
            bgWL.CancelAsync();
            grdWorkList.Enabled = true;

        }
        private void loadData(DateTime date)
        {
            this.Cursor = Cursors.WaitCursor;
            dsData = new DataSet();
            ProcessGetXRAYREQ process = new ProcessGetXRAYREQ();
            process.StoreType = 3;
            process.XRAYREQ.ORDER_DT = date;
            process.Invoke();
            dsData = process.Result;
            setGridWorkList();
            this.Cursor = Cursors.Default;
        }
        private void loadData(string HN)
        {
            timer1.Enabled = false;
            grdWorkList.Enabled = false;
            
            if (!bgWL.IsBusy)
                bgWL.RunWorkerAsync();
            Application.DoEvents();
            DataTable dtt = dsData.Tables[0].Clone();
            DataRow[] rows = dsData.Tables[0].Select("HN='" + HN + "'");
            if (rows.Length > 0) {
                foreach (DataRow row in rows) {
                    DataRow r = dtt.NewRow();
                    for (int i = 0; i < dtt.Columns.Count; i++)
                        r[i] = row[i];
                    dtt.Rows.Add(r);
                }
            }
            dtt.AcceptChanges();


            if (dtt.Rows.Count == 0)
            {
                try
                {
                    //Envision.WebService.HISWebService.KMCHService proxy = new Envision.WebService.HISWebService.KMCHService();
                    //GBLEnvVariable env = new GBLEnvVariable();
                    //proxy.Url = env.WebServiceIP;
                    //proxy.GetXrayRequestByHN(HN);

                    //ProcessGetXRAYREQ proc = new ProcessGetXRAYREQ();
                    //proc.XRAYREQ.HN = HN;
                    //dsData = new DataSet();
                    //dsData = proc.GetWorkListByHN();
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                dsData = new DataSet();
                dsData.Tables.Add(dtt);
                dsData.AcceptChanges();
            }
            grdWorkList.DataSource = null;
            setGridWorkList();
            bgWL.CancelAsync();
            grdWorkList.Enabled = true; 
        }
        private void setGridWorkList() { 
            DataTable dtt=dsData.Tables[0];

            try
            {
                dtt.Columns.Add("colDelete");
            }
            catch { }
            dtt.AcceptChanges();
            grdWorkList.DataSource = dtt;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            for (int i = 0; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["XRAY_TYPE"].Caption = "Xray Type";
            view1.Columns["XRAY_TYPE"].Visible = true;
            view1.Columns["XRAY_TYPE"].OptionsColumn.ReadOnly = true;
            view1.Columns["XRAY_TYPE"].OptionsColumn.AllowEdit = false;
            view1.Columns["XRAY_TYPE"].ColVIndex = 0;

            view1.Columns["S_XREQ"].Caption = "Req No.";
            view1.Columns["S_XREQ"].Visible = true;
            view1.Columns["S_XREQ"].OptionsColumn.ReadOnly = true;
            view1.Columns["S_XREQ"].OptionsColumn.AllowEdit = false;
            view1.Columns["S_XREQ"].ColVIndex = 1;
           
            view1.Columns["HN"].Caption = "HN";
            view1.Columns["HN"].Visible = true;
            view1.Columns["HN"].OptionsColumn.ReadOnly = true;
            view1.Columns["HN"].OptionsColumn.AllowEdit = false;
            view1.Columns["HN"].ColVIndex = 2;

            view1.Columns["AN"].Caption = "Admit No.";
            view1.Columns["AN"].Visible = true;
            view1.Columns["AN"].OptionsColumn.ReadOnly = true;
            view1.Columns["AN"].OptionsColumn.AllowEdit = false;
            view1.Columns["AN"].ColVIndex = 3;

            view1.Columns["PATIENT_NAME"].Caption = "Patient Name";
            view1.Columns["PATIENT_NAME"].Width = 200;
            view1.Columns["PATIENT_NAME"].Visible = true;
            view1.Columns["PATIENT_NAME"].OptionsColumn.ReadOnly = true;
            view1.Columns["PATIENT_NAME"].OptionsColumn.AllowEdit = false;
            view1.Columns["PATIENT_NAME"].ColVIndex = 4;

            view1.Columns["XREQ_DATE"].Caption = "Req Date";
            view1.Columns["XREQ_DATE"].Visible = true;
            view1.Columns["XREQ_DATE"].OptionsColumn.ReadOnly = true;
            view1.Columns["XREQ_DATE"].OptionsColumn.AllowEdit = false;
            view1.Columns["XREQ_DATE"].ColVIndex = 5;

            view1.Columns["XREQ_TIME"].Caption = "Req Time";
            view1.Columns["XREQ_TIME"].Visible = true;
            view1.Columns["XREQ_TIME"].OptionsColumn.ReadOnly = true;
            view1.Columns["XREQ_TIME"].OptionsColumn.AllowEdit = false;
            view1.Columns["XREQ_TIME"].ColVIndex = 6;

            view1.Columns["TOTAL_AMT"].Caption = "Amount";
            view1.Columns["TOTAL_AMT"].Width = 50;
            view1.Columns["TOTAL_AMT"].Visible = true;
            view1.Columns["TOTAL_AMT"].OptionsColumn.ReadOnly = true;
            view1.Columns["TOTAL_AMT"].OptionsColumn.AllowEdit = false;
            view1.Columns["TOTAL_AMT"].ColVIndex = 7;

        
            view1.Columns["colDelete"].Caption =" ";
            view1.Columns["colDelete"].Visible = true;
            
            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btnMakeOrder_Click);
            view1.Columns["colDelete"].Caption = " ";
            view1.Columns["colDelete"].ColumnEdit = btn;
            view1.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            view1.Columns["colDelete"].Width = 50;
            view1.Columns["colDelete"].OptionsColumn.AllowEdit = true;
            view1.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

        }

        private void btnMakeOrder_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
            if (row != null)
            {
                int orderID = Convert.ToInt32(row["REG_ID"]);
                frmOrders frm = new frmOrders(orderID, "New");
                frm.MinimizeBox = false;
                frm.MaximizeBox = false;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (chkSearch.Checked == true)
                    {
                            loadDataDate();
                    }
                    else
                    {
                        if (this.textBox1.Text.Length > 0)
                            loadData(textBox1.Text);
                        //loadData();
                    }
                }

            }
            timer1.Enabled = true;
        }
        private void view1_DoubleClick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
            if (row != null)
            {
                int orderID = Convert.ToInt32(row["REG_ID"]);
                frmOrders frm = new frmOrders(orderID, "New");
                frm.MinimizeBox = false;
                frm.MaximizeBox = false;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (chkSearch.Checked == true)
                    {
                        loadDataDate();
                    }
                    else
                    {
                        if (this.textBox1.Text.Length > 0)
                            loadData(textBox1.Text);
                        //loadData();
                    }
                }

            }
            timer1.Enabled = true;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            grdWorkList.Enabled = false;
            if (!bgWL.IsBusy)
                bgWL.RunWorkerAsync();
            Application.DoEvents();
            //Envision.WebService.HISWebService.KMCHService proxy = new Envision.WebService.HISWebService.KMCHService();
            //GBLEnvVariable env = new GBLEnvVariable();
            //proxy.Url = env.WebServiceIP;
            //try
            //{
            //    proxy.GetXrayRequest();
            //    System.Threading.Thread.Sleep(5000);
            //}
            //catch (Exception ex) { 
            
            //}
            bgWL.CancelAsync();
            timer1.Enabled = true;
            //loadData();
            loadDataDate();
        }

        private void chkSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearch.Checked == true)
            {
                dateSearch.Enabled = true;
                dateSearch2.Enabled = true;
                textBox1.Enabled = false;
                timer1.Enabled = true;
                //if (textBox1.Text != "")
                //{
                //    loadData(textBox1.Text);
                //}
            }
            else
            {
                dateSearch.Enabled = false;
                dateSearch2.Enabled = false;
                textBox1.Enabled = true;
                timer1.Enabled = false;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chkSearch.Checked)
            {
                loadDataDate();
            }
            else
            {
                if (textBox1.Text.Trim().Length == 0)
                    loadData();
                else
                    loadData(textBox1.Text.Trim());
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 47) e.Handled = true;
            //if (chkSearch.Checked == true)
            //{
            //    if ((int)e.KeyChar == 8) e.Handled = false;
            //    else if ((int)e.KeyChar == 13)
                    
            //}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (chkToday.Checked)
                loadDataToday();
            else
                loadData();
            loadDataDate();
        }
        private void dateSearch_EditValueChanged(object sender, EventArgs e)
        {
            //if (chkSearch.Checked == true)
            //{
            //    DateTime dt = new DateTime(this.dateSearch.DateTime.Year, this.dateSearch.DateTime.Month, this.dateSearch.DateTime.Day);
            //    loadData(dt);
            //}
        }

        #region Manu Tab 
        private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmArrivalWorkList' and MENU_ID=" + this.Menu_ID);
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
            //RIS.Forms.Schedule.frmScheduleWorkList frm = new RIS.Forms.Schedule.frmScheduleWorkList(this.CloseControl);
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
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
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmReprint' and MENU_ID=" + this.Menu_ID);
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
            //RIS.Forms.Order.frmViewPerformance frm = new frmViewPerformance(this.CloseControl);
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
        }
        private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((Envision.NET.Forms.Main.frmMain)this.MdiParent).DisplayHome();
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
        private void barScanImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmScanImage frm = new frmScanImage();
            frm.ShowDialog();
            frm.Dispose();
        }
        #endregion

        private void bgWL_DoWork(object sender, DoWorkEventArgs e)
        {
            //Envision.NET.Forms.Dialog.WaitDialog dlg = new WaitDialog(bgWL);
            //dlg.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (textBox1.Text.Trim().Length > 0)
                    loadData(textBox1.Text.Trim());
                else
                    loadData();
        }

        private void loadDataToday() {
            string today = (DateTime.Today.Year + 543).ToString();
            today += DateTime.Today.Month.ToString().Length == 2 ? DateTime.Today.Month.ToString() : "0" + DateTime.Today.Month.ToString();
            today += DateTime.Today.Day.ToString().Length == 2 ? DateTime.Today.Day.ToString() : "0" + DateTime.Today.Day.ToString();
            grdWorkList.Enabled = false;
            if (!bgWL.IsBusy)
                bgWL.RunWorkerAsync();
            Application.DoEvents();
            dsData = new DataSet();
            ProcessGetXRAYREQ process = new ProcessGetXRAYREQ();
            dsData = process.GetRequestReq(today);
            setGridWorkList();
            this.Cursor = Cursors.Default;
            timer1.Enabled = true;
            bgWL.CancelAsync();
            grdWorkList.Enabled = true;
        }
        private void loadDataDate()
        {
            DateTime dtF = new DateTime();
            DateTime dtT = new DateTime();

            dtF = dateSearch.DateTime;
            dtT = dateSearch2.DateTime;
            string dateF = (dtF.Year + 543).ToString();
            dateF += dtF.Month.ToString().Length == 2 ? dtF.Month.ToString() : "0" + dtF.Month.ToString();
            dateF += dtF.Day.ToString().Length == 2 ? dtF.Day.ToString() : "0" + dtF.Day.ToString();

            string dateT = (dtT.Year + 543).ToString();
            dateT += dtT.Month.ToString().Length == 2 ? dtT.Month.ToString() : "0" + dtT.Month.ToString();
            dateT += dtT.Day.ToString().Length == 2 ? dtT.Day.ToString() : "0" + dtT.Day.ToString();

            grdWorkList.Enabled = false;
            if (!bgWL.IsBusy)
                bgWL.RunWorkerAsync();
            Application.DoEvents();
            dsData = new DataSet();
            ProcessGetXRAYREQ process = new ProcessGetXRAYREQ();
            dsData = process.GetRequestDateLenge(dateF, dateT);
            setGridWorkList();
            this.Cursor = Cursors.Default;
            timer1.Enabled = true;
            bgWL.CancelAsync();
            grdWorkList.Enabled = true;
        }
        private void chkToday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToday.Checked)
                loadDataToday();
            else
                loadData();
        }

        private void barComments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Comment.frmComment frm = null;
            if (view1.FocusedRowHandle<0)
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

        
    }
}