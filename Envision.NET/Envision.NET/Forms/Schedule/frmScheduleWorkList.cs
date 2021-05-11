using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using RIS.Common;
//using RIS.BusinessLogic;
//using RIS.Common.Common;
//using RIS.Operational;
//using RIS.Forms.GBLMessage;


using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.NET.Forms.Schedule
{
    public partial class frmScheduleWorkList : Envision.NET.Forms.Main.MasterForm  // Form
    {
        private DataSet ds = null;
        private ProcessGetRISScheduledtl process = null;
        private RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
        private RepositoryItemGridLookUpEdit grdLMo = new RepositoryItemGridLookUpEdit();
        private RepositoryItemGridLookUpEdit grdLPat = new RepositoryItemGridLookUpEdit();
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private int[] langid;
        private string defaultlangs;
        private bool flag;

        public frmScheduleWorkList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitControl();
            LoadDataToGrid();
            SetColumnInGrid();
            LoadFormLanguage();
           
        }
        private void frmScheduleWorkList_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
        private void LoadFormLanguage()
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

        private void InitControl()
        {
            dateFrom.DateTime = DateTime.Today;
            dateTo.DateTime = DateTime.Today;
            lblToday.Text = "<" + DateTime.Today.ToString("dd/MM/yyy") +">";
        }
        private void LoadDataToGrid()
        {
            process = new ProcessGetRISScheduledtl(dateFrom.DateTime, dateTo.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59),0);
            ds = new DataSet();
            process.Invoke();
            ds = process.Result;
            gridControl1.DataSource = ds.Tables[0];
        }
        private void SetColumnInGrid()
        {
            ////gridControl1.DataSource = ds.Tables[0];
            //advBandedGridView1.OptionsView.ShowAutoFilterRow = false;
            //advBandedGridView1.OptionsView.ShowBands = false;
            //advBandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            //advBandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            //advBandedGridView1.OptionsView.ColumnAutoWidth = true;

            for (int i = 0; i < advBandedGridView1.Columns.Count; i++)
                advBandedGridView1.Columns[i].Visible = false;
            
            advBandedGridView1.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["HN"].Visible = true;
            advBandedGridView1.Columns["HN"].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns["HN"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["HN"].Width = 90;

            advBandedGridView1.Columns["NameThai"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["NameThai"].Visible = true;
            advBandedGridView1.Columns["NameThai"].Caption = "Patient Name";
            advBandedGridView1.Columns["NameThai"].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns["NameThai"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["NameThai"].Width = 190;

            grdLPat = new RepositoryItemGridLookUpEdit();
            DataTable dtPat = RISBaseData.RIS_PatStatus();
            grdLPat.DataSource = dtPat;
            grdLPat.NullText = "";
            grdLPat.ValueMember = "STATUS_ID";
            grdLPat.DisplayMember = "STATUS_TEXT";
            grdLPat.CloseUp += new CloseUpEventHandler(grdLPat_CloseUp);

            #region SetGrid Pat in Lookup
            grdLPat.View.OptionsView.ShowAutoFilterRow = true;

            grdLPat.View.Columns["STATUS_ID"].Visible = false;
            grdLPat.View.Columns["STATUS_UID"].Visible = false;
            grdLPat.View.Columns["STATUS_TEXT"].Visible = true;
            grdLPat.View.Columns["IS_ACTIVE"].Visible = false;
            grdLPat.View.Columns["ORG_ID"].Visible = false;
            grdLPat.View.Columns["CREATED_BY"].Visible = false;
            grdLPat.View.Columns["CREATED_ON"].Visible = false;
            grdLPat.View.Columns["LAST_MODIFIED_BY"].Visible = false;
            grdLPat.View.Columns["LAST_MODIFIED_ON"].Visible = false;
            grdLPat.View.Columns["IS_DEFAULT"].Visible = false;

            grdLPat.View.Columns["STATUS_TEXT"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdLPat.View.Columns["STATUS_TEXT"].Caption = "Status";
            #endregion



            advBandedGridView1.Columns["PAT_STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["PAT_STATUS"].Visible = true;
            advBandedGridView1.Columns["PAT_STATUS"].Caption = "Patient Status";
            advBandedGridView1.Columns["PAT_STATUS"].ColumnEdit = grdLPat;
            advBandedGridView1.Columns["PAT_STATUS"].OptionsColumn.ReadOnly = false;
            //advBandedGridView1.Columns["pat_status"].Width = 190;

            advBandedGridView1.Columns["EXAM_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["EXAM_UID"].Visible = true;
            advBandedGridView1.Columns["EXAM_UID"].Caption = "Exam Code";
            advBandedGridView1.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["EXAM_UID"].Width = 90;

            advBandedGridView1.Columns["EXAM_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["EXAM_NAME"].Visible = true;
            advBandedGridView1.Columns["EXAM_NAME"].Caption = "Exam Name";
            advBandedGridView1.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["EXAM_NAME"].Width = 130;


            advBandedGridView1.Columns["SCHEDULE_DT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["SCHEDULE_DT"].Visible = true;
            advBandedGridView1.Columns["SCHEDULE_DT"].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns["SCHEDULE_DT"].Caption = "Exam Date";
            advBandedGridView1.Columns["SCHEDULE_DT"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["APPOINT_DT"].Width = 100;

            DataTable dtMo = RISBaseData.Ris_Modality();
            grdLMo = new RepositoryItemGridLookUpEdit();
            grdLMo.DataSource = dtMo;
            //grdLMo.NullText = "";
            grdLMo.ValueMember = "MODALITY_ID";
            grdLMo.DisplayMember = "MODALITY_NAME";
            grdLMo.CloseUp += new CloseUpEventHandler(grdLMo_CloseUp);

            #region SetGridMo in Grid
            grdLMo.View.OptionsView.ShowAutoFilterRow = true;
            for (int i = 0; i < dtMo.Columns.Count; i++)
                grdLMo.View.Columns[i].Visible = false;


            //grdLMo.View.Columns["MODALITY_ID"].Visible = false;
            //grdLMo.View.Columns["MODALITY_UID"].Visible = false;
            //grdLMo.View.Columns["MODALITY_NAME"].Visible = true;
            //grdLMo.View.Columns["ROOM_UID"].Visible = false;
            //grdLMo.View.Columns["MODALITY_TYPE"].Visible = false;
            grdLMo.View.Columns["MODALITY_NAME"].Visible = true;

            grdLMo.View.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdLMo.View.Columns["MODALITY_NAME"].Caption = "MODALITY"; 
            #endregion

            advBandedGridView1.Columns["MODALITY_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["MODALITY_ID"].Visible = true;
            advBandedGridView1.Columns["MODALITY_ID"].Caption = "Modality";
            advBandedGridView1.Columns["MODALITY_ID"].ColumnEdit = grdLMo;
            advBandedGridView1.Columns["MODALITY_ID"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["MODALITY_NAME"].Width = 130;

            advBandedGridView1.Columns["CLINIC_TYPE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["CLINIC_TYPE"].Visible = true;
            advBandedGridView1.Columns["CLINIC_TYPE"].Caption = "Clinic";
            advBandedGridView1.Columns["CLINIC_TYPE"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["CLINIC_TYPE"].OptionsColumn.AllowEdit = false;

            advBandedGridView1.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["QTY"].Visible = false;
            advBandedGridView1.Columns["QTY"].Caption = "QTY";
            advBandedGridView1.Columns["QTY"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["QTY"].OptionsColumn.AllowEdit = false;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //chk.ValueChecked = "1";
            //chk.ValueUnchecked = "0";
            chk.ValueChecked = "C";
            chk.ValueUnchecked = "S";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chk.Click += new EventHandler(chk_Click);

            //advBandedGridView1.Columns["SCHEDULE_STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["SCHEDULE_STATUS"].Visible = false;
            //advBandedGridView1.Columns["SCHEDULE_STATUS"].Width = 40;
            //advBandedGridView1.Columns["SCHEDULE_STATUS"].Name = "SCHEDULE_STATUS";
            //advBandedGridView1.Columns["SCHEDULE_STATUS"].Caption = string.Empty;
            //advBandedGridView1.Columns["SCHEDULE_STATUS"].ColumnEdit = chk;
            //advBandedGridView1.Columns["SCHEDULE_STATUS"].ColVIndex = 0;
            //advBandedGridView1.Columns["SCHEDULE_STATUS"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnToOrder = new RepositoryItemButtonEdit();
            btnToOrder.ButtonsStyle = BorderStyles.Office2003;
            btnToOrder.Buttons[0].Caption = "Order";
            btnToOrder.Buttons[0].Kind = ButtonPredefines.Plus;
            btnToOrder.TextEditStyle = TextEditStyles.HideTextEditor;
            btnToOrder.ButtonClick += new ButtonPressedEventHandler(btnToOrder_ButtonClick);
            advBandedGridView1.Columns["Check"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Check"].Visible = true;
            advBandedGridView1.Columns["Check"].Width = 200;
            advBandedGridView1.Columns["Check"].Name = "Check";
            advBandedGridView1.Columns["Check"].Caption = "Order";
            advBandedGridView1.Columns["Check"].ColumnEdit = btnToOrder;
            //advBandedGridView1.Columns["Check"].ColVIndex = 7;

           
        }
        private void makeOrder()
        {
            DataTable dtCon = (DataTable)gridControl1.DataSource;
            DataRow drSent = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
            //DataRow[] drSend = dtCon.Select("SCHEDULE_ID=" + dtCon.Rows[advBandedGridView1.FocusedRowHandle]["SCHEDULE_ID"].ToString());
            frmScheduleConfrim frmCon = new frmScheduleConfrim(drSent);
            frmCon.MinimizeBox = false;
            frmCon.MaximizeBox = false;
            frmCon.StartPosition = FormStartPosition.CenterParent;
            frmCon.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmCon.Text = "Take Order";
            frmCon.ShowDialog();

            LoadDataToGrid();
            SetColumnInGrid();
        }

        private void grdLPat_CloseUp(object sender, CloseUpEventArgs e)
        {
            try
            {
                int row = (int)e.Value;
                //DataTable dtGL = (DataTable)grdLPat.DataSource;
                //UpdateGrid(row, "PatientStatus");

                updatePatientStatus(row);
            }
            catch (Exception)
            {

            }

        }
        private void grdLMo_CloseUp(object sender, CloseUpEventArgs e)
        {
            //try
            //{
            //int row = (int)e.Value;
            //DataTable dtGM = (DataTable)grdLMo.DataSource;
            //UpdateGrid(row, "Modality");
            //}
            //catch (Exception)
            //{
            //}
        }
        private void updatePatientStatus(int pat_id) {
            DataRow row = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
            ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
            proc.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(row["SCHEDULE_ID"].ToString());
            proc.RIS_SCHEDULE.PAT_STATUS = pat_id;
            proc.RIS_SCHEDULE.ORG_ID = env.OrgID;
            proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
            proc.UpdatePatientStatus();
            LoadDataToGrid();
        }
        private void btnToOrder_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            makeOrder();
        }
        private void advBandedGridView1_Click(object sender, EventArgs e)
        {
            if (ds == null) return;
            if (ds.Tables.Count == 0) return;

            GridHitInfo info;
            Point pt = advBandedGridView1.GridControl.PointToClient(Control.MousePosition);
            info = advBandedGridView1.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                if (ds.Tables[0].Rows.Count == 0) return;
                if (info.Column.Name == "SCHEDULE_STATUS")
                {
                    for (int i = 0; i < advBandedGridView1.RowCount; i++)
                        //advBandedGridView1.SetRowCellValue(i, "SCHEDULE_STATUS", 1);
                        advBandedGridView1.SetRowCellValue(i, "SCHEDULE_STATUS", "C");
                    flag = true;
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["SCHEDULE_STATUS"]);
                    string sid = msg.ShowAlert("UID1034", new GBLEnvVariable().CurrentLanguageID);
                    if (sid == "1")
                    {
                        for (int i = 0; i < advBandedGridView1.RowCount; i++)
                            //advBandedGridView1.SetRowCellValue(i, "SCHEDULE_STATUS", 0);
                            advBandedGridView1.SetRowCellValue(i, "SCHEDULE_STATUS", "S");
                    }
                    else
                    {
                        for (int i = 0; i < advBandedGridView1.RowCount; i++)
                        {
                            DataRow dr = advBandedGridView1.GetDataRow(i);
                            ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
                            process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
                            process.RIS_SCHEDULE.SCHEDULE_STATUS = Convert.ToChar("C");  // dr["SCHEDULE_STATUS"].ToString();
                            process.RIS_SCHEDULE.CREATED_BY = new GBLEnvVariable().UserID;
                            process.Invoke();
                        }
                        LoadDataToGrid();
                        SetColumnInGrid();
                    }
                    flag = false;
                    advBandedGridView1.InvalidateColumnHeader(advBandedGridView1.Columns["SCHEDULE_STATUS"]);
                }
            }
        }
        private void advBandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            makeOrder();
        }
       
        #region Draw CheckBox
        private void advBandedGridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
        //    if (e.Column == null) return;
        //    if (e.Column.Name == "SCHEDULE_STATUS")
        //    {
        //        e.Info.InnerElements.Clear();
        //        e.Painter.DrawObject(e.Info);
        //        DrawCheckBox(e.Graphics, e.Bounds, flag);
        //        e.Handled = true;
        //    }

        }
        #endregion

        #region Manu Tab 
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
            InitControl();
            LoadDataToGrid();
            SetColumnInGrid();
            LoadFormLanguage();
            txtHN.Focus();
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
        #endregion

        #region Key Down
        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 8)
            {
                //e.Handled = false;
                if (txtHN.Text.Trim().Length <= 0)
                {
                    LoadDataToGrid();
                    SetColumnInGrid();
                }
            }
            else if ((int)e.KeyChar == 13)
            {
                
                if (txtHN.Text.Trim() == string.Empty)
                {
                    //string s = Envision.Operational.Translator.ConvertHNtoKKU.HN_KKU(txtHN.Text);
                    //if (!Envision.Operational.Translator.ConvertHNtoKKU.IsUseHn(s))
                    //{
                    //    msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                    //    gridControl1.DataSource = null;
                    //    ds = null;
                    //    return;
                    //}
                    LoadDataToGrid();
                    SetColumnInGrid();
                    return;
                }
                ProcessGetRISSchedule process = new ProcessGetRISSchedule(txtHN.Text);
                process.RIS_SCHEDULE.HN = txtHN.Text;
                process.Invoke();
                DataSet dsData = process.Result;

                if (dsData != null)
                    if (dsData.Tables.Count > 0)
                        if (dsData.Tables[0].Rows.Count == 1)
                        {
                            ds = new DataSet();
                            ds = dsData;
                            gridControl1.DataSource = ds.Tables[0];
                            SetColumnInGrid();
                            for (int i = 0; i < advBandedGridView1.RowCount; i++)
                                advBandedGridView1.SetRowCellValue(i, "SCHEDULE_STATUS", "O");
                            //string sid = msg.ShowAlert("UID1034", new GBLEnvVariable().CurrentLanguageID);
                            string sid = "2";
                            if (sid == "2")
                            {
                                DataTable dtCon = (DataTable)gridControl1.DataSource;
                                DataRow drSent = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                                DataRow[] drSend = dtCon.Select("SCHEDULE_ID=" + dtCon.Rows[advBandedGridView1.FocusedRowHandle]["SCHEDULE_ID"].ToString());


                                frmScheduleConfrim frmCon = new frmScheduleConfrim(drSent);
                                frmCon.MinimizeBox = false;
                                frmCon.MaximizeBox = false;
                                frmCon.StartPosition = FormStartPosition.CenterParent;
                                frmCon.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                                frmCon.Text = "Take Order";
                                frmCon.ShowDialog();

                                //for (int i = 0; i < advBandedGridView1.RowCount; i++)
                                //{
                                //    DataRow dr = advBandedGridView1.GetDataRow(i);
                                //    ProcessUpdateRISSchedule processUpdate = new ProcessUpdateRISSchedule();
                                //    processUpdate.RISSchedule.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
                                //    processUpdate.RISSchedule.SCHEDULE_STATUS = "O";  // dr["SCHEDULE_STATUS"].ToString();
                                //    processUpdate.RISSchedule.CREATED_BY = new GBLEnvVariable().UserID;
                                //    processUpdate.Invoke();
                                //}
                                LoadDataToGrid();
                                SetColumnInGrid();
                                txtHN.Text = string.Empty;
                                txtHN.Focus();
                            }
                            else
                            {
                                for (int i = 0; i < advBandedGridView1.RowCount; i++)
                                    advBandedGridView1.SetRowCellValue(i, "SCHEDULE_STATUS", "S");
                            }

                            txtHN.SelectionStart = 0;
                            txtHN.SelectionLength = txtHN.Text.Length;
                            txtHN.Focus();
                            return;
                        }
                        else if (dsData.Tables[0].Rows.Count > 1)
                        {
                            gridControl1.DataSource = dsData.Tables[0]; ;
                            SetColumnInGrid();
                            return;
                        }
                msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                ds = null;
                gridControl1.DataSource = null;
            }
        }
        private void txtHN_Validating(object sender, CancelEventArgs e)
        {
            this.dateFrom.Focus();
        }

        private void dateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dateTo.Focus();
        }
        private void dateTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch.Focus();
        }
        private void dateFrom_Validating(object sender, CancelEventArgs e)
        {
            dateTo.Focus();
        }
        private void dateTo_Validating(object sender, CancelEventArgs e)
        {
            btnSearch.Focus();
        } 
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dateFrom.Text == string.Empty || dateTo.Text == string.Empty) return;
            LoadDataToGrid();
            SetColumnInGrid();
        }

        private void barCommets_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Comment.frmComment frm = null;
            if (advBandedGridView1.FocusedRowHandle < 0)
            {
                frm = new Envision.NET.Forms.Comment.frmComment();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                string hn = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle)["HN"].ToString();
                frm = new Envision.NET.Forms.Comment.frmComment(hn);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            frm.Dispose();
        }

        private void barLabData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (advBandedGridView1.FocusedRowHandle > -1)
            {
                string HN = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle)["HN"].ToString();
                try
                {
                    HIS_Patient HIS_p = new HIS_Patient();
                    DataSet dsHIS = HIS_p.Get_lab_data(HN);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
                        lv.ValueUpdated += new ValueUpdatedEventHandler(lv_ValueUpdated);
                        lv.Text = "Lab Detail List";
                        lv.Data = dsHIS.Tables[0];
                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.PreviewFieldName = "report";
                        lv.SortFieldName = "lab_date";
                        lv.ShowDescription = true;
                        lv.ShowBox();
                    }
                }
                catch (Exception ex)
                {
                    msg.ShowAlert("UID4022", new GBLEnvVariable().CurrentLanguageID);
                }
            }
        }
        private void lv_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
        }
    }
}