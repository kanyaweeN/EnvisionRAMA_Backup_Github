using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTab;

using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;

using Envision.NET.Forms.Main;
using Envision.NET.Forms.EMR;
using Envision.NET.Forms.ResultEntry;
using Envision.Operational.Translator;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using Envision.Common.Common;
using Envision.BusinessLogic.ProcessUpdate;
using DevExpress.XtraEditors.Controls;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmTechnologist : MasterForm
    {
        Envision.BusinessLogic.Technologist tech = new Envision.BusinessLogic.Technologist();
        MyMessageBox msg = new MyMessageBox();
        GBLEnvVariable env = new GBLEnvVariable();
        private frmPopupOrderOrScheduleSummary _orderSummary;

        DateTime dttStart;
        DateTime dttEnd;
        DateTime dttFrom;
        DateTime dttTo;

        DataTable dttCon;
        DataTable dttExam;

        DataTable dtModality;
        DataView dvModality;

        DataTable dtWorkLoad;
        DataView dvWorkLoad;
        DataTable dtReject;
        DataView dvReject;

        DataView dvConsumable;
        DataTable dtConsumable;

        DataView dvConsumable_ce;
        DataTable dtConsumable_ce;

        DataTable dtDemographic;
        DataTable dtSelectCase;

        DataTable dtHisReg;
        DataView dvHisReg;

        string mode = "";

        string HN = "";
        int modalityID = 0;
        int take = 0;
        string accessionNo = "";

        int orderID = 0;
        int status = 0;

        string HNDem = "";

        string loadmode = "";

        int cabUserBy = 0;
        int cabGroupBy = 0;
        string capMode = ""; //'USERMEM' or 'GROUPMEM'

        bool onCapture = false;

        List<int> selectModId = new List<int>();

        DataTable dtMemList = new DataTable("MemList");
        DataTable dtRadList = new DataTable("RadList");
        int nowMemRows = 0;
        private DataTable dttExamFlag, dtExamFlagDTL;
        private DataSet dtClinicalindicationtype = new DataSet();

        int radSlno = 1;
        public frmTechnologist()
        {
            InitializeComponent();
            this._orderSummary = new frmPopupOrderOrScheduleSummary();
        }
        public frmTechnologist(string mode)
        {
            InitializeComponent();

            loadmode = mode;

            this._orderSummary = new frmPopupOrderOrScheduleSummary();

        }
        private void frmTechnologist_Load(object sender, EventArgs e)
        {
            #region start with NORMAL mode
            if (mode == "")
            {
                xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtHN.Text = "";
                txtFromdate.DateTime = DateTime.Now;
                txtToDate.DateTime = DateTime.Now;

                #region initial status column
                if (dttCon == null)
                {
                    dttCon = new DataTable();
                    dttCon.Columns.Add("ID", typeof(int));
                    dttCon.Columns.Add("Name", typeof(string));

                    DataRow dr = dttCon.NewRow();
                    dr[0] = 0;
                    dr[1] = "Waiting";
                    dttCon.Rows.Add(dr);

                    dr = dttCon.NewRow();
                    dr[0] = 1;
                    dr[1] = "Started";
                    dttCon.Rows.Add(dr);

                    dr = dttCon.NewRow();
                    dr[0] = 2;
                    dr[1] = "Complete";
                    dttCon.Rows.Add(dr);

                    //dr = dttCon.NewRow();
                    //dr[0] = 3;
                    //dr[1] = "Discontinued";
                    //dttCon.Rows.Add(dr);

                    //dr = dttCon.NewRow();
                    //dr[0] = 4;
                    //dr[1] = "Canceled";
                    //dttCon.Rows.Add(dr);
                }
                #endregion

                #region initial modality combobox
                tech.LoadModality();
                DataTable dt = tech.dtModality;

                selectModId.Clear();
                selectModId.Add(0);

                txtComboModality.Properties.Items.Clear();
                txtComboModality.Properties.Items.Add("ALL:MODALITY");

                chkListModality.Properties.Items.Clear();
                chkListModality.Properties.Items.Add("ALL:MODALITY");

                foreach (DataRow dr in dt.Rows)
                {
                    selectModId.Add((int)dr["MODALITY_ID"]);
                    txtComboModality.Properties.Items.Add(dr["MODALITY_UID"].ToString() + ":" + dr["MODALITY_NAME"].ToString());
                    chkListModality.Properties.Items.Add(dr["MODALITY_NAME"].ToString() + "(" + dr["MODALITY_UID"].ToString() + ")");
                }

                txtComboModality.SelectedIndex = 0;
                chkListModality.Properties.Items[0].CheckState = CheckState.Checked;
                chkListModality.Text = "ALL:MODALITY";
                #endregion

                #region initial usermember table
                dtMemList.Columns.AddRange
                    (
                        new DataColumn[]
                        {
                            new DataColumn("id")
                            ,new DataColumn("fullname")
                            ,new DataColumn("unit")
                            ,new DataColumn("fullnameTemp")
                            ,new DataColumn("slno",typeof(int))
                        }
                    );
                dtRadList.Columns.AddRange
               (
                   new DataColumn[]
                        {
                            new DataColumn("id")
                            ,new DataColumn("fullname")
                            ,new DataColumn("unit")
                            ,new DataColumn("fullnameTemp")
                            ,new DataColumn("slno",typeof(int))
                             ,new DataColumn("del")
                        }
               );
                #endregion

                #region load user login
                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HR_EMP.MODE = "EmpId";
                bg.HR_EMP.EMP_ID = env.UserID;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = 0;
                bg.Invoke();

                addMemList(bg.Result.Tables[0],false);
                #endregion

                modalityID = 0;
                cabUserBy = env.UserID;
                //chkAllModality.Checked = false;
                ReloadWorkload();
                ReloadReject();
            }
            #endregion

            #region start with TAB mode
            if (mode != "")
            {
                xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtHN.Text = "";
                txtFromdate.DateTime = DateTime.Now;
                txtToDate.DateTime = DateTime.Now;

                modalityID = 0;
                cabUserBy = env.UserID;

                #region initial status column
                if (dttCon == null)
                {
                    dttCon = new DataTable();
                    dttCon.Columns.Add("ID", typeof(int));
                    dttCon.Columns.Add("Name", typeof(string));

                    DataRow dr = dttCon.NewRow();
                    dr[0] = 0;
                    dr[1] = "Waiting";
                    dttCon.Rows.Add(dr);

                    dr = dttCon.NewRow();
                    dr[0] = 1;
                    dr[1] = "Started";
                    dttCon.Rows.Add(dr);

                    dr = dttCon.NewRow();
                    dr[0] = 2;
                    dr[1] = "Complete";
                    dttCon.Rows.Add(dr);

                    //dr = dttCon.NewRow();
                    //dr[0] = 3;
                    //dr[1] = "Discontinued";
                    //dttCon.Rows.Add(dr);

                    //dr = dttCon.NewRow();
                    //dr[0] = 4;
                    //dr[1] = "Canceled";
                    //dttCon.Rows.Add(dr);
                }
                #endregion

                #region initial modality combobox
                tech.LoadModality();
                DataTable dt = tech.dtModality;

                selectModId.Clear();
                selectModId.Add(0);

                txtComboModality.Properties.Items.Clear();
                txtComboModality.Properties.Items.Add("ALL:MODALITY");

                foreach (DataRow dr in dt.Rows)
                {
                    selectModId.Add((int)dr["MODALITY_ID"]);
                    txtComboModality.Properties.Items.Add(dr["MODALITY_UID"].ToString() + ":" + dr["MODALITY_NAME"].ToString());
                    chkListModality.Properties.Items.Add(dr["MODALITY_NAME"].ToString() + "(" + dr["MODALITY_UID"].ToString() + ")");
                }

                txtComboModality.SelectedIndex = 0;
                chkListModality.Properties.Items[0].CheckState = CheckState.Checked;
                chkListModality.Text = "ALL:MODALITY";
                #endregion

                #region initial usermember table
                dtMemList.Columns.AddRange
                            (
                                new DataColumn[]
                        {
                            new DataColumn("id")
                            ,new DataColumn("fullname")
                            ,new DataColumn("unit")
                            ,new DataColumn("fullnameTemp")
                            ,new DataColumn("slno",typeof(int))
                        }
                            );
                dtRadList.Columns.AddRange
            (
                new DataColumn[]
                        {
                            new DataColumn("id")
                            ,new DataColumn("fullname")
                            ,new DataColumn("unit")
                            ,new DataColumn("fullnameTemp")
                            ,new DataColumn("slno",typeof(int))
                            ,new DataColumn("del")
                        }
            );
                #endregion

                #region load user login
                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HR_EMP.MODE = "EmpId";
                bg.HR_EMP.EMP_ID = env.UserID;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = 0;
                bg.Invoke();

                DataRow row = dtMemList.NewRow();
                row["id"] = bg.Result.Tables[0].Rows[0]["EMP_ID"];
                row["FullName"] = bg.Result.Tables[0].Rows[0]["FullName"];
                row["Unit"] = bg.Result.Tables[0].Rows[0]["UNIT_NAME"];
                dtMemList.Rows.Add(row);

                ribbonUserMembers_DataShowing();
                #endregion

                //chkAllModality.Checked = false;
                ReloadCapture();
                ReloadDemographic();
                onCapture = true;
                ribbonPage_DataShowing();
            }
            #endregion

            setTrauma();

            grdRadioSetup.DataSource = dtRadList;
            setGridradioSetup();

            tmAutoRefresh.Start();
            txtComboModality.SelectedIndexChanged += new EventHandler(txtComboModality_SelectedIndexChanged);
            chkListModality.Properties.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(Properties_CloseUp);
            try
            {
                ProcessGetClinicalIndicationType processClinicalindicationtype = new ProcessGetClinicalIndicationType();
                dtClinicalindicationtype = processClinicalindicationtype.GetClinicalIndicationType(env.OrgID, env.UserID);
            }
            catch { }
            base.CloseWaitDialog();
        }
        private void setTrauma()
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.ORDER_ID = -1;
            prc.Invoke();
            dttExamFlag = prc.Result.Tables[0]; //Set template table.
            dtExamFlagDTL = prc.resultDetail();

            contextcmb.Items.Clear();
            System.Windows.Forms.ComboBox.ObjectCollection colls = contextcmb.Items;
            try
            {
                foreach (DataRow row in dtExamFlagDTL.Rows)
                {
                    colls.Add(new TraumaItems(Convert.ToInt32(row["GEN_DTL_ID"]), row["GEN_TEXT"].ToString(), Convert.ToInt32(row["SL_NO"])));
                }
            }
            finally
            {
            }
            contextcmb.SelectedIndex = 0;
        }
        private void getTrauma(int order_id)
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.ORDER_ID = order_id == 0 ? -1 : order_id;
            prc.Invoke();

            dttExamFlag = prc.Result.Tables[0];
        }
        private void setGridradioSetup()
        {
            for (int i = 0; i < viewSetup.Columns.Count; i++)
            {
                viewSetup.Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                viewSetup.Columns[i].Visible = false;
            }

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDel = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnDel.ButtonsStyle = BorderStyles.Office2003;
            btnDel.Buttons[0].Kind = ButtonPredefines.Delete;
            btnDel.TextEditStyle = TextEditStyles.HideTextEditor;
            btnDel.ButtonClick += new ButtonPressedEventHandler(btnDel_ButtonClick);

            viewSetup.Columns["slno"].Caption = "NO.";
            viewSetup.Columns["slno"].Visible = true;
            viewSetup.Columns["slno"].OptionsColumn.ReadOnly = true;
            viewSetup.Columns["slno"].OptionsColumn.AllowEdit = false;
            viewSetup.Columns["slno"].Width = 50;
            viewSetup.Columns["slno"].ColVIndex = 1;

            viewSetup.Columns["fullname"].Caption = "Name";
            viewSetup.Columns["fullname"].Visible = true;
            viewSetup.Columns["fullname"].OptionsColumn.ReadOnly = true;
            viewSetup.Columns["fullname"].OptionsColumn.AllowEdit = false;
            viewSetup.Columns["fullname"].Width = 180;
            viewSetup.Columns["fullname"].ColVIndex = 2;

            viewSetup.Columns["unit"].Caption = "Unit";
            viewSetup.Columns["unit"].Visible = true;
            viewSetup.Columns["unit"].OptionsColumn.ReadOnly = true;
            viewSetup.Columns["unit"].OptionsColumn.AllowEdit = false;
            viewSetup.Columns["unit"].Width = 100;
            viewSetup.Columns["unit"].ColVIndex = 3;

            viewSetup.Columns["del"].Caption = " ";
            viewSetup.Columns["del"].Visible = true;
            viewSetup.Columns["del"].OptionsColumn.ReadOnly = false;
            viewSetup.Columns["del"].OptionsColumn.AllowEdit = true;
            viewSetup.Columns["del"].Width = 23;
            viewSetup.Columns["del"].ColumnEdit = btnDel;
            viewSetup.Columns["del"].ColVIndex = 4;

        }
        private void btnDel_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DataRow dr = viewSetup.GetDataRow(viewSetup.FocusedRowHandle);

            if (env.UserID == Convert.ToInt32(dr["id"])) return;
            int selectedRadId = Convert.ToInt32(dr["id"]);
            
            if (env.UserID == Convert.ToInt32(dr["id"])) return;
            dtRadList.Rows[viewSetup.FocusedRowHandle].Delete();
            dtRadList.AcceptChanges();
            for (int i = 0; i < dtRadList.Rows.Count; i++)
                dtRadList.Rows[i]["slno"] = i + 1;
            dtRadList.AcceptChanges();
            grdRadioSetup.DataSource = dtRadList;
            setGridradioSetup();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            ReloadModality();
        }
        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReloadModality();
            }
        }

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadLoginPage();
        }
        private void btnModality_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadModality();
        }
        private void btnWorkload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ReloadWorkload();
            if (xtraTabControl2.SelectedTabPage == tabWorkload)
                ReloadWorkload();
            else if (xtraTabControl2.SelectedTabPage == tabRejectImage)
                ReloadReject();
        }
        private void btnCapture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadCapture();
        }
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Refreshing();
        }
        private void Refreshing()
        {
            if (xtraTabControl1.SelectedTabPage == pageLogIn)
                ReloadLoginPage();
            else if (xtraTabControl1.SelectedTabPage == pageModality)
                ReloadModality();
            else if (xtraTabControl1.SelectedTabPage == pageWorkload)
            {
                //ReloadWorkload();
                if (xtraTabControl2.SelectedTabPage == tabWorkload)
                    ReloadWorkload();
                else if (xtraTabControl2.SelectedTabPage == tabRejectImage)
                    ReloadReject();
            }
            else if (xtraTabControl1.SelectedTabPage == pageCapture)
                ReloadCapture();
            else if (xtraTabControl1.SelectedTabPage == pageDemographic)
                ReloadDemographic();
        }

        private void ReloadLoginPage()
        {
            xtraTabControl1.SelectedTabPage = pageLogIn;
            ribbonPage1.Text = "LogIn Page";
            layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            txtUsername.Focus();
            ribbonPage_DataShowing();
            ribbonBtn_visibility();
        }

        private void LoadDataModality()
        {
            tech.LoadModality();
            DataTable dt = tech.dtModality;
            dt.Columns.Add("btnWorkload");
            dtModality = dt;
        }
        private void LoadFilterModality()
        {
            DataView dv = dtModality.DefaultView;
            dv.Sort = "MODALITY_NAME asc";
            dvModality = dv;
        }
        private void LoadGridModality()
        {
            gridControl1.DataSource = dvModality;

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].Visible = false;
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                gridView1.Columns[k].OptionsColumn.AllowFocus = false;
                k++;
            }

            #region load columns
            gridView1.Columns["MODALITY_UID"].ColVIndex = 0;
            gridView1.Columns["MODALITY_UID"].Caption = "Modality Code";
            //gridView1.Columns["MODALITY_UID"].Width = 100;

            gridView1.Columns["MODALITY_NAME"].ColVIndex = 1;
            gridView1.Columns["MODALITY_NAME"].Caption = "Modality Name";
            //gridView1.Columns["MODALITY_NAME"].Width = 100;

            gridView1.Columns["ROOM_UID"].ColVIndex = 2;
            gridView1.Columns["ROOM_UID"].Caption = "Room Name";
            //gridView1.Columns["ROOM_UID"].Width = 100;

            gridView1.Columns["UNIT_NAME"].ColVIndex = 3;
            gridView1.Columns["UNIT_NAME"].Caption = "Unit Name";
            //gridView1.Columns["UNIT_NAME"].Width = 100;

            gridView1.Columns["TYPE_NAME"].ColVIndex = 4;
            gridView1.Columns["TYPE_NAME"].Caption = "Type Name";
            //gridView1.Columns["TYPE_NAME"].Width = 100;

            gridView1.Columns["btnWorkload"].ColVIndex = 5;
            gridView1.Columns["btnWorkload"].Caption = "";
            gridView1.Columns["btnWorkload"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["btnWorkload"].Width = 75;
            gridView1.Columns["btnWorkload"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["btnWorkload"].OptionsColumn.AllowFocus = true;

            gridView1.BestFitColumns();
            #endregion

            #region load edititem
            RepositoryItemButtonEdit btnWorkload = new RepositoryItemButtonEdit();
            btnWorkload.Buttons.Clear();
            btnWorkload.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton());
            btnWorkload.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnWorkload.Buttons[0].Image = (Image)imgSmall.Images[0].Clone();
            btnWorkload.Buttons[0].ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btnWorkload.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnWorkload.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnWorkload_ButtonClick);
            gridView1.Columns["btnWorkload"].ColumnEdit = btnWorkload;
            #endregion
        }
        private void ReloadModality()
        {
            #region check text format
            if (txtUsername.Text.Trim() == "")
            {
                msg.ShowAlert("UID001", env.CurrentLanguageID);
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                msg.ShowAlert("UID002", env.CurrentLanguageID);
                return;
            }
            #endregion

            #region save user pass
            tech.USERNAME = txtUsername.Text;
            tech.PASSOWRD = txtPassword.Text;
            #endregion

            #region check user pass
            if (tech.LoadTechnician())
            {
                xtraTabControl1.SelectedTabPage = pageModality;
                ribbonPage1.Text = "Modality Page";
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                LoadDataModality();
                LoadFilterModality();
                LoadGridModality();

                ribbonPage_DataShowing();
                ribbonBtn_visibility();
            }
            else
            {
                ReloadLoginPage();
                tech.Reset();
                msg.ShowAlert("UID003", env.CurrentLanguageID);
            }
            #endregion

        }

        #region Modality Page
        private void btnWorkload_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                ReloadWorkload();
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                ReloadWorkload();
            }
        }
        #endregion

        #region Workload
        private void LoadDataWorkload()
        {
            #region LoadData
            DataSet ds = new DataSet();
            //ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
            //ds = process.GetDataCapture(dttFrom, dttTo);
            if (radioGroup1.SelectedIndex == 0)
            {
                ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
                ds = process.GetDataCapture(dttFrom, dttTo, env.UserID);
            }
            else
            {
                ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
                ds = process.GetDataCapturebyHN(txtHN.Text, env.UserID);
            }
            #endregion

            #region LoadNewColumns
            ds.Tables[0].Columns.Add("Delay", typeof(string));
            ds.Tables[0].Columns.Add("colStatus", typeof(int));
            ds.Tables[0].Columns.Add("CHK", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //DateTime dt=DateTime.Now;
                //if(dr["EST_START_TIME"].ToString().Trim()!=string.Empty)
                //     dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                //TimeSpan ts = dt.TimeOfDay;
                //dr["Delay"] = DateTime.Now.Add(ts);
                if (dr["STATUS"].ToString().Trim() == "S")
                    dr["colStatus"] = 1;
                else if (dr["STATUS"].ToString().Trim() == "C")
                    dr["colStatus"] = 2;
                else
                    dr["colStatus"] = 0;

                DateTime dt = DateTime.Now;
                if (dr["EST_START_TIME"].ToString() != string.Empty)
                    dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                TimeSpan ts = DateTime.Now.Subtract(dt);
                string day = ts.Days == 0 ? "00" : ts.Days.ToString();
                day = day.Length == 1 ? "0" + day + ":" : day + ":";
                string hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                string minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                minute = minute.Length == 1 ? "0" + minute : minute;
                dr["Delay"] = day + hour + minute;

                dr["CHK"] = "N";

                if (!string.IsNullOrEmpty(dr["ALLERGIES"].ToString()) && dr["ALLERGIES"].ToString().Trim() != "N")
                    dr["ALLERGIES"] = "Y";
            }
            dtWorkLoad = ds.Tables[0].Copy();
            #endregion
        }
        private void LoadFilterWorkload()
        {
            //dv = dtWorkLoad.DefaultView;
            //if (txtComboModality.SelectedIndex == 0)
            //    dv.RowFilter = "";
            //else
            //    dv.RowFilter = "MODALITY_ID=" + selectModId[txtComboModality.SelectedIndex].ToString();

            #region less than one selected
            bool unSelAll = true;

            int kk = 0;
            while (kk < chkListModality.Properties.Items.Count)
            {
                if (chkListModality.Properties.Items[kk].CheckState == CheckState.Checked)
                {
                    unSelAll = false;
                    break;
                }
                ++kk;
            }

            if (unSelAll)
            {
                chkListModality.Properties.Items[0].CheckState = CheckState.Checked;
                chkListModality.Text = "ALL:MODALITY";
            }
            #endregion

            DataView dv = dtWorkLoad.DefaultView;
            dv.RowFilter = "";

            if (chkListModality.Properties.Items[0].CheckState == CheckState.Checked)
                dv.RowFilter = "";
            else
            {
                List<string> id = new List<string>();
                int k = 1;
                while (k < chkListModality.Properties.Items.Count)
                {
                    if (chkListModality.Properties.Items[k].CheckState == CheckState.Checked)
                    {
                        id.Add(selectModId[k].ToString());
                    }
                    ++k;
                }

                //try
                //{
                //    string qry = "";
                //    foreach (string str in id.ToArray())
                //        qry += " MODALITY_ID=" + str + " or ";
                //    qry = qry.Substring(0, qry.Length - 3);

                //    dv.RowFilter = qry;
                //}
                //catch
                //{
                //    dv.RowFilter = "MODALITY_ID=-1";
                //}

                if (id.Count > 0)
                {
                    string qry = "";
                    foreach (string str in id.ToArray())
                        qry += " MODALITY_ID=" + str + " or ";
                    qry = qry.Substring(0, qry.Length - 3);

                    dv.RowFilter = "(" + qry + ")";
                }
            }

            if (chkShowStartComplete.CheckState == CheckState.Unchecked)
            {
                if (dv.RowFilter == "")
                    dv.RowFilter += "(STATUS = 'A' OR STATUS = 'B')";
                else
                    dv.RowFilter += " AND (STATUS = 'A' OR STATUS = 'B')";
            }
            else
            {
                if (dv.RowFilter == "")
                    dv.RowFilter += "(STATUS = 'A' OR STATUS = 'B' OR STATUS = 'S' OR STATUS = 'C')";
                else
                    dv.RowFilter += " AND (STATUS = 'A' OR STATUS = 'B' OR STATUS = 'S' OR STATUS = 'C')";
            }

            //if (chkShowStartComplete.CheckState == CheckState.Unchecked)
            //{
            //    if (dv.RowFilter == "")
            //        dv.RowFilter += "(STATUS = 'W')";
            //    else
            //        dv.RowFilter += " AND (STATUS = 'W')";
            //}
            //else
            //{
            //    if (dv.RowFilter == "")
            //        dv.RowFilter += "(STATUS = 'W' OR STATUS = 'C')";
            //    else
            //        dv.RowFilter += " AND (STATUS = 'W' OR STATUS = 'C')";
            //}

            dvWorkLoad = dv;
        }
        private void LoadGridWorkload()
        {
            gridControl2.DataSource = dvWorkLoad;

            int k = 0;
            while (k < gridView2.Columns.Count)
            {
                gridView2.Columns[k].Visible = false;
                gridView2.Columns[k].OptionsColumn.AllowEdit = false;
                //gridView2.Columns[k].OptionsColumn.AllowFocus = false;
                ++k;
            }

            gridView2.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView2.OptionsSelection.InvertSelection = false;
            gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView2.OptionsView.ShowAutoFilterRow = true;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repFlag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repFlag.AutoHeight = false;
            repFlag.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",2,1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",3,2),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",4,3),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",5,4)
            });
            repFlag.Name = "repFlag";
            repFlag.SmallImages = img16;
            repFlag.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repFlag.Buttons[0].Visible = false;

            #region column edit
            gridView2.Columns["CHK"].Caption = " ";
            gridView2.Columns["CHK"].ColVIndex = 1;
            gridView2.Columns["CHK"].Width = -1;
            gridView2.Columns["CHK"].OptionsColumn.AllowEdit = true;

            // alert code
            gridView2.Columns["CLINICAL_INSTRUCTION_TAG"].ColVIndex = 2;
            gridView2.Columns["CLINICAL_INSTRUCTION_TAG"].Caption = " ";
            gridView2.Columns["CLINICAL_INSTRUCTION_TAG"].Width = 50;
            gridView2.Columns["CLINICAL_INSTRUCTION_TAG"].OptionsColumn.ReadOnly = true;
            gridView2.Columns["CLINICAL_INSTRUCTION_TAG"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["CLINICAL_INSTRUCTION_TAG"].OptionsFilter.AllowFilter = false;

            gridView2.Columns["FLAG_ICON"].ColVIndex = 3;
            gridView2.Columns["FLAG_ICON"].Caption = " ";
            gridView2.Columns["FLAG_ICON"].Width = -1;
            gridView2.Columns["FLAG_ICON"].ColumnEdit = repFlag;
            gridView2.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;
            gridView2.Columns["FLAG_ICON"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;

            //gridView2.Columns["HAS_COMMENT"].Caption = " ";
            //gridView2.Columns["HAS_COMMENT"].ColVIndex = 2;
            //gridView2.Columns["HAS_COMMENT"].BestFit();
            //gridView2.Columns["HAS_COMMENT"].OptionsColumn.ReadOnly = true;
            //gridView2.Columns["HAS_COMMENT"].OptionsColumn.AllowEdit = true;

            gridView2.Columns["READER"].Caption = " ";
            gridView2.Columns["READER"].ColVIndex = 4;
            gridView2.Columns["READER"].Width = -1;
            gridView2.Columns["READER"].OptionsColumn.ReadOnly = true;
            gridView2.Columns["READER"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["READER"].OptionsFilter.AllowFilter = false;

            gridView2.Columns["ALLERGIES"].Caption = " ";
            gridView2.Columns["ALLERGIES"].ColVIndex = 5;
            gridView2.Columns["ALLERGIES"].Width = 20;
            gridView2.Columns["ALLERGIES"].OptionsColumn.ReadOnly = true;
            gridView2.Columns["ALLERGIES"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["ALLERGIES"].OptionsFilter.AllowFilter = false;

            gridView2.Columns["PRIORITY"].Caption = "Priority";
            gridView2.Columns["PRIORITY"].ColVIndex = 6;
            gridView2.Columns["PRIORITY"].Width = 40;

            gridView2.Columns["HN"].Caption = "HN";
            gridView2.Columns["HN"].ColVIndex = 7;
            gridView2.Columns["HN"].Width = 50;

            gridView2.Columns["PatientName"].Caption = "Patient Name";
            gridView2.Columns["PatientName"].ColVIndex = 8;
            gridView2.Columns["PatientName"].Width = 90;

            gridView2.Columns["AGEText"].ColVIndex = 9;
            gridView2.Columns["AGEText"].Caption = "Age";
            gridView2.Columns["AGEText"].Width = 75;
            //gridView2.Columns["AGE"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            gridView2.Columns["GENDER"].Caption = "Gender";
            gridView2.Columns["GENDER"].ColVIndex = 10;
            gridView2.Columns["GENDER"].Width = 40;

            gridView2.Columns["STATUS_TEXT"].Caption = "Patient Status";
            gridView2.Columns["STATUS_TEXT"].ColVIndex = 11;
            gridView2.Columns["STATUS_TEXT"].Width = 49;

            gridView2.Columns["ACCESSION_NO"].Caption = "Accession No.";
            gridView2.Columns["ACCESSION_NO"].ColVIndex = 12;
            gridView2.Columns["ACCESSION_NO"].Width = 50;

            gridView2.Columns["EXAM_UID"].Caption = "Exam Code";
            gridView2.Columns["EXAM_UID"].ColVIndex = 13;
            gridView2.Columns["EXAM_UID"].Width = 50;

            gridView2.Columns["EXAM_NAME"].Caption = "Exam Name";
            gridView2.Columns["EXAM_NAME"].ColVIndex = 14;
            gridView2.Columns["EXAM_NAME"].Width = 169;

            gridView2.Columns["MODALITY_NAME"].Caption = "Modality";
            gridView2.Columns["MODALITY_NAME"].ColVIndex = 15;
            gridView2.Columns["MODALITY_NAME"].Width = 128;

            gridView2.Columns["CLINIC_TYPE"].Caption = "Clinic Type";
            gridView2.Columns["CLINIC_TYPE"].ColVIndex = 16;
            gridView2.Columns["CLINIC_TYPE"].Width = 100;

            //gridView2.Columns["ORDER_START_TIME"].Caption = "Arr. Time";
            //gridView2.Columns["ORDER_START_TIME"].ColVIndex = 10;
            //gridView2.Columns["ORDER_START_TIME"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            //gridView2.Columns["ORDER_START_TIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            //gridView2.Columns["ORDER_START_TIME"].Width = 73;

            //gridView2.Columns["EST_START_TIME"].Caption = "EST";
            //gridView2.Columns["EST_START_TIME"].ColVIndex = 11;
            //gridView2.Columns["EST_START_TIME"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            //gridView2.Columns["EST_START_TIME"].DisplayFormat.FormatString = "hh:mm:ss";
            //gridView2.Columns["EST_START_TIME"].Width = 69;

            //gridView2.Columns["TAKE"].Caption = "Take";
            //gridView2.Columns["TAKE"].ColVIndex = 13;
            //gridView2.Columns["TAKE"].Width = 21;

            gridView2.Columns["TIMEDIFF"].Caption = "Waiting Time";
            gridView2.Columns["TIMEDIFF"].ColVIndex = 17;
            gridView2.Columns["TIMEDIFF"].Width = 75;

            gridView2.Columns["colStatus"].ColVIndex = 18;
            gridView2.Columns["colStatus"].OptionsColumn.FixedWidth = true;
            gridView2.Columns["colStatus"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            gridView2.Columns["colStatus"].OptionsColumn.ReadOnly = false;
            gridView2.Columns["colStatus"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["colStatus"].OptionsColumn.AllowFocus = true;
            gridView2.Columns["colStatus"].Caption = "Status";
            gridView2.Columns["colStatus"].Width = 65;

            gridView2.Columns["Delay"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridView2.Columns["Delay"].Width = 51;

            #endregion

            #region repository edit
            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Condition", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "Name";
            repositoryItemLookUpEdit1.ValueMember = "ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.DataSource = dttCon;
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(condition_CloseUp);
            gridView2.Columns["colStatus"].ColumnEdit = repositoryItemLookUpEdit1;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", "Routine", 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent","Urgent", 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", "Stat", 8)});
            repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            repositoryItemImageComboBox2.SmallImages = imgWL;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridView2.Columns["PRIORITY"].ColumnEdit = repositoryItemImageComboBox2;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkTemplate.ValueChecked = "Y";
            chkTemplate.ValueUnchecked = "N";
            chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkTemplate.Click += new EventHandler(chkTemplate_Click);
            gridView2.Columns["CHK"].ColumnEdit = chkTemplate;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repComment = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repComment.AutoHeight = false;
            repComment.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","New",1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","Read",9)
            });
            repComment.Name = "repComment";
            repComment.SmallImages = imgWL;
            repComment.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repComment.Buttons[0].Visible = false;
            repComment.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            repComment.ShowPopupShadow = false;
            repComment.DropDownRows = 0;
            repComment.Click += new EventHandler(repComment_Click);
            gridView2.Columns["READER"].ColumnEdit = repComment;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repAllery = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repAllery.AutoHeight = false;
            repAllery.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","Y",12)
            });
            repAllery.Name = "repAllery";
            repAllery.SmallImages = imgWL;
            repAllery.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repAllery.Buttons[0].Visible = false;
            //repAllery.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            //repAllery.ShowPopupShadow = false;
            //repAllery.DropDownRows = 0;
            //repAllery.Click += new EventHandler(repComment_Click);
            gridView2.Columns["ALLERGIES"].ColumnEdit = repAllery;
            #endregion

            #region styleformat
            //DevExpress.XtraGrid.StyleFormatCondition cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["colStatus"], null, "B");
            //cn.Appearance.BackColor = Color.LightGreen;
            //cn.ApplyToRow = true;
            //gridView2.FormatConditions.Add(cn);

            //DevExpress.XtraGrid.Columns.GridColumn gc = view1.Columns["ORDER_START_TIME"];
            //gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //gc.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            //DevExpress.XtraGrid.Columns.GridColumn gcEST = view1.Columns["EST_START_TIME"];
            //gcEST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //gcEST.DisplayFormat.FormatString = "hh:mm:ss";

            //DevExpress.XtraGrid.Columns.GridColumn gcDelay = view1.Columns["Delay"];
            ////gcDelay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            ////gcDelay.DisplayFormat.FormatString = "hh:mm:ss";
            ////gcDelay.DisplayFormat.FormatString = "dd:hh:mm";

            #endregion

        }

        private void repComment_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle < 0) return;
            tmAutoRefresh.Stop();
            DataRow rowHandle = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            frmMessageConversation frm = new frmMessageConversation(rowHandle["ACCESSION_NO"].ToString());
            frm.ShowDialog();
            frm.Dispose();

            Refreshing();
            tmAutoRefresh.Start();
        }
        private void ReloadWorkload()
        {
            tmAutoRefresh.Stop();

            //if (gridView1.FocusedRowHandle < 0) return;

            ribbonPage1.Text = "Workload";
            xtraTabControl1.SelectedTabPage = pageWorkload;
            layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //modalityID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["MODALITY_ID"]);
            ribbonControl1.SelectedPage = ribPageWorkload;

            if (radioGroup1.SelectedIndex == 0)
            {
                panelDate.Visible = true;
                panelHN.Visible = false;

                dttFrom = new DateTime(txtFromdate.DateTime.Year, txtFromdate.DateTime.Month, txtFromdate.DateTime.Day, 0, 0, 0);
                dttTo = new DateTime(txtToDate.DateTime.Year, txtToDate.DateTime.Month, txtToDate.DateTime.Day, 23, 59, 59); ;
                HN = "";
            }
            else
            {
                panelDate.Visible = false;
                panelHN.Visible = true;

                dttFrom = new DateTime(1800, 1, 1, 1, 1, 1);
                dttTo = new DateTime(9000, 1, 1, 1, 1, 1);
                HN = txtHN.Text;
            }

            LoadDataWorkload();
            LoadFilterWorkload();
            LoadGridWorkload();

            ribbonPage_DataShowing();
            ribbonBtn_visibility();

            onCapture = false;

            tmAutoRefresh.Start();

        }
        #endregion

        #region Reject
        private void LoadDataReject()
        {
            #region LoadData
            DataSet ds = new DataSet();
            //ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
            //ds = process.GetDataCapture(dttFrom, dttTo);
            if (radioGroup1.SelectedIndex == 0)
            {
                ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
                ds = process.GetDataRejectPacsImage(dttFrom, dttTo, env.UserID);
            }
            else
            {
                ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
                ds = process.GetDataRejectPacsImagebyHN(txtHN.Text, env.UserID);
            }
            #endregion

            #region LoadNewColumns
            ds.Tables[0].Columns.Add("Delay", typeof(string));
            ds.Tables[0].Columns.Add("colStatus", typeof(int));
            ds.Tables[0].Columns.Add("CHK", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //DateTime dt=DateTime.Now;
                //if(dr["EST_START_TIME"].ToString().Trim()!=string.Empty)
                //     dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                //TimeSpan ts = dt.TimeOfDay;
                //dr["Delay"] = DateTime.Now.Add(ts);
                if (dr["STATUS"].ToString().Trim() == "S")
                    dr["colStatus"] = 1;
                else if (dr["STATUS"].ToString().Trim() == "C")
                    dr["colStatus"] = 2;
                else
                    dr["colStatus"] = 0;

                DateTime dt = DateTime.Now;
                if (dr["EST_START_TIME"].ToString() != string.Empty)
                    dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                TimeSpan ts = DateTime.Now.Subtract(dt);
                string day = ts.Days == 0 ? "00" : ts.Days.ToString();
                day = day.Length == 1 ? "0" + day + ":" : day + ":";
                string hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                string minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                minute = minute.Length == 1 ? "0" + minute : minute;
                dr["Delay"] = day + hour + minute;

                dr["CHK"] = "N";

                if (!string.IsNullOrEmpty(dr["ALLERGIES"].ToString()) && dr["ALLERGIES"].ToString().Trim() != "N")
                    dr["ALLERGIES"] = "Y";
            }
            dtReject = ds.Tables[0].Copy();
            #endregion
        }
        private void LoadFilterReject()
        {
            #region less than one selected
            bool unSelAll = true;

            int kk = 0;
            while (kk < chkListModality.Properties.Items.Count)
            {
                if (chkListModality.Properties.Items[kk].CheckState == CheckState.Checked)
                {
                    unSelAll = false;
                    break;
                }
                ++kk;
            }

            if (unSelAll)
            {
                chkListModality.Properties.Items[0].CheckState = CheckState.Checked;
                chkListModality.Text = "ALL:MODALITY";
            }
            #endregion

            DataView dv = dtReject.DefaultView;
            dv.RowFilter = "";

            if (chkListModality.Properties.Items[0].CheckState == CheckState.Checked)
                dv.RowFilter = "";
            else
            {
                List<string> id = new List<string>();
                int k = 1;
                while (k < chkListModality.Properties.Items.Count)
                {
                    if (chkListModality.Properties.Items[k].CheckState == CheckState.Checked)
                    {
                        id.Add(selectModId[k].ToString());
                    }
                    ++k;
                }

                if (id.Count > 0)
                {
                    string qry = "";
                    foreach (string str in id.ToArray())
                        qry += " MODALITY_ID=" + str + " or ";
                    qry = qry.Substring(0, qry.Length - 3);

                    dv.RowFilter = "(" + qry + ")";
                }
            }

            //if (chkShowStartComplete.CheckState == CheckState.Unchecked)
            //{
            //    if (dv.RowFilter == "")
            //        dv.RowFilter += "(STATUS = 'A' OR STATUS = 'B')";
            //    else
            //        dv.RowFilter += " AND (STATUS = 'A' OR STATUS = 'B')";
            //}
            //else
            //{
            //    if (dv.RowFilter == "")
            //        dv.RowFilter += "(STATUS = 'A' OR STATUS = 'B' OR STATUS = 'S' OR STATUS = 'C')";
            //    else
            //        dv.RowFilter += " AND (STATUS = 'A' OR STATUS = 'B' OR STATUS = 'S' OR STATUS = 'C')";
            //}

            dvReject = dv;
        }
        private void LoadGridReject()
        {
            gridControl6.DataSource = dvReject;

            int k = 0;
            while (k < gridViewReject.Columns.Count)
            {
                gridViewReject.Columns[k].Visible = false;
                gridViewReject.Columns[k].OptionsColumn.AllowEdit = false;
                //gridView2.Columns[k].OptionsColumn.AllowFocus = false;
                ++k;
            }

            gridViewReject.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewReject.OptionsSelection.InvertSelection = false;
            gridViewReject.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewReject.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridViewReject.OptionsView.ShowAutoFilterRow = true;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repFlag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repFlag.AutoHeight = false;
            repFlag.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",2,1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",3,2),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",4,3),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",5,4)
            });
            repFlag.Name = "repFlag";
            repFlag.SmallImages = img16;
            repFlag.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repFlag.Buttons[0].Visible = false;

            #region column edit
            // alert code
            gridViewReject.Columns["CLINICAL_INSTRUCTION_TAG"].ColVIndex = 1;
            gridViewReject.Columns["CLINICAL_INSTRUCTION_TAG"].Caption = " ";
            gridViewReject.Columns["CLINICAL_INSTRUCTION_TAG"].Width = 50;
            gridViewReject.Columns["CLINICAL_INSTRUCTION_TAG"].OptionsColumn.ReadOnly = true;
            gridViewReject.Columns["CLINICAL_INSTRUCTION_TAG"].OptionsColumn.AllowEdit = false;
            gridViewReject.Columns["CLINICAL_INSTRUCTION_TAG"].OptionsFilter.AllowFilter = false;

            gridViewReject.Columns["FLAG_ICON"].ColVIndex = 2;
            gridViewReject.Columns["FLAG_ICON"].Caption = " ";
            gridViewReject.Columns["FLAG_ICON"].Width = -1;
            gridViewReject.Columns["FLAG_ICON"].ColumnEdit = repFlag;
            gridViewReject.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;
            gridViewReject.Columns["FLAG_ICON"].OptionsColumn.AllowEdit = false;
            gridViewReject.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;

            gridViewReject.Columns["READER"].Caption = " ";
            gridViewReject.Columns["READER"].ColVIndex = 3;
            gridViewReject.Columns["READER"].Width = -1;
            gridViewReject.Columns["READER"].OptionsColumn.ReadOnly = true;
            gridViewReject.Columns["READER"].OptionsColumn.AllowEdit = true;
            gridViewReject.Columns["READER"].OptionsFilter.AllowFilter = false;

            gridViewReject.Columns["ALLERGIES"].Caption = " ";
            gridViewReject.Columns["ALLERGIES"].ColVIndex = 4;
            gridViewReject.Columns["ALLERGIES"].Width = 20;
            gridViewReject.Columns["ALLERGIES"].OptionsColumn.ReadOnly = true;
            gridViewReject.Columns["ALLERGIES"].OptionsColumn.AllowEdit = true;
            gridViewReject.Columns["ALLERGIES"].OptionsFilter.AllowFilter = false;

            gridViewReject.Columns["PRIORITY"].Caption = "Priority";
            gridViewReject.Columns["PRIORITY"].ColVIndex = 5;
            gridViewReject.Columns["PRIORITY"].Width = 40;

            gridViewReject.Columns["HN"].Caption = "HN";
            gridViewReject.Columns["HN"].ColVIndex = 6;
            gridViewReject.Columns["HN"].Width = 50;

            gridViewReject.Columns["PatientName"].Caption = "Patient Name";
            gridViewReject.Columns["PatientName"].ColVIndex = 7;
            gridViewReject.Columns["PatientName"].Width = 90;

            gridViewReject.Columns["AGEText"].ColVIndex = 8;
            gridViewReject.Columns["AGEText"].Caption = "Age";
            gridViewReject.Columns["AGEText"].Width = 75;
            //gridView2.Columns["AGE"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            gridViewReject.Columns["GENDER"].Caption = "Gender";
            gridViewReject.Columns["GENDER"].ColVIndex = 9;
            gridViewReject.Columns["GENDER"].Width = 40;

            gridViewReject.Columns["STATUS_TEXT"].Caption = "Patient Status";
            gridViewReject.Columns["STATUS_TEXT"].ColVIndex = 10;
            gridViewReject.Columns["STATUS_TEXT"].Width = 49;

            gridViewReject.Columns["ACCESSION_NO"].Caption = "Accession No.";
            gridViewReject.Columns["ACCESSION_NO"].ColVIndex = 11;
            gridViewReject.Columns["ACCESSION_NO"].Width = 50;

            gridViewReject.Columns["EXAM_UID"].Caption = "Exam Code";
            gridViewReject.Columns["EXAM_UID"].ColVIndex = 12;
            gridViewReject.Columns["EXAM_UID"].Width = 50;

            gridViewReject.Columns["EXAM_NAME"].Caption = "Exam Name";
            gridViewReject.Columns["EXAM_NAME"].ColVIndex = 13;
            gridViewReject.Columns["EXAM_NAME"].Width = 169;

            gridViewReject.Columns["MODALITY_NAME"].Caption = "Modality";
            gridViewReject.Columns["MODALITY_NAME"].ColVIndex = 14;
            gridViewReject.Columns["MODALITY_NAME"].Width = 128;

            gridViewReject.Columns["CLINIC_TYPE"].Caption = "Clinic Type";
            gridViewReject.Columns["CLINIC_TYPE"].ColVIndex = 15;
            gridViewReject.Columns["CLINIC_TYPE"].Width = 100;

            gridViewReject.Columns["GEN_TEXT"].Caption = "Reject Reason";
            gridViewReject.Columns["GEN_TEXT"].ColVIndex = 16;
            gridViewReject.Columns["GEN_TEXT"].Width = 169;

            gridViewReject.Columns["REJECT_COMMENTS"].Caption = "Reject Comments";
            gridViewReject.Columns["REJECT_COMMENTS"].ColVIndex = 17;
            gridViewReject.Columns["REJECT_COMMENTS"].Width = 128;

            gridViewReject.Columns["PHONE_CALL_BACK"].Caption = "Phone call back";
            gridViewReject.Columns["PHONE_CALL_BACK"].ColVIndex = 18;
            gridViewReject.Columns["PHONE_CALL_BACK"].Width = 100;
            #endregion

            #region repository edit

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", "Routine", 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent","Urgent", 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", "Stat", 8)});
            repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            repositoryItemImageComboBox2.SmallImages = imgWL;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridViewReject.Columns["PRIORITY"].ColumnEdit = repositoryItemImageComboBox2;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repComment = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repComment.AutoHeight = false;
            repComment.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","New",1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","Read",9)
            });
            repComment.Name = "repComment";
            repComment.SmallImages = imgWL;
            repComment.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repComment.Buttons[0].Visible = false;
            repComment.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            repComment.ShowPopupShadow = false;
            repComment.DropDownRows = 0;
            repComment.Click += new EventHandler(repComment_Reject_Click);
            gridViewReject.Columns["READER"].ColumnEdit = repComment;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repAllery = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repAllery.AutoHeight = false;
            repAllery.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","Y",12)
            });
            repAllery.Name = "repAllery";
            repAllery.SmallImages = imgWL;
            repAllery.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repAllery.Buttons[0].Visible = false;
            gridViewReject.Columns["ALLERGIES"].ColumnEdit = repAllery;
            #endregion
        }

        private void repComment_Reject_Click(object sender, EventArgs e)
        {
            if (gridViewReject.FocusedRowHandle < 0) return;
            tmAutoRefresh.Stop();
            DataRow rowHandle = gridViewReject.GetDataRow(gridView2.FocusedRowHandle);
            frmMessageConversation frm = new frmMessageConversation(rowHandle["ACCESSION_NO"].ToString());
            frm.ShowDialog();
            frm.Dispose();

            Refreshing();
            tmAutoRefresh.Start();
        }
        private void ReloadReject()
        {
            tmAutoRefresh.Stop();

            //if (gridView1.FocusedRowHandle < 0) return;

            ribbonPage1.Text = "Workload";
            xtraTabControl1.SelectedTabPage = pageWorkload;
            layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //modalityID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["MODALITY_ID"]);
            ribbonControl1.SelectedPage = ribPageWorkload;

            if (radioGroup1.SelectedIndex == 0)
            {
                panelDate.Visible = true;
                panelHN.Visible = false;

                dttFrom = new DateTime(txtFromdate.DateTime.Year, txtFromdate.DateTime.Month, txtFromdate.DateTime.Day, 0, 0, 0);
                dttTo = new DateTime(txtToDate.DateTime.Year, txtToDate.DateTime.Month, txtToDate.DateTime.Day, 23, 59, 59); ;
                HN = "";
            }
            else
            {
                panelDate.Visible = false;
                panelHN.Visible = true;

                dttFrom = new DateTime(1800, 1, 1, 1, 1, 1);
                dttTo = new DateTime(9000, 1, 1, 1, 1, 1);
                HN = txtHN.Text;
            }

            LoadDataReject();
            LoadFilterReject();
            LoadGridReject();

            ribbonPage_DataShowing();
            ribbonBtn_visibility();

            onCapture = false;

            tmAutoRefresh.Start();

        }
        #endregion

        #region Workload Page
        private void condition_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null || e.Value.ToString() == "") return;
            if (e.AcceptValue)
            {
                status_selected(e.Value);
            }
        }
        private void onlyStart()
        {
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (row != null)
            {
                insertTechWork(row, "S");
                ReloadWorkload();
            }
        }
        private void onlyComplete()
        {
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (row != null)
            {
                insertTechWork(row, "C");
                ReloadWorkload();
            }
        }
        private void insertTechWork(DataRow  row, string status)
        {
            RIS_TECHWORK tech = new RIS_TECHWORK();
            tech.ACCESSION_ON = row["ACCESSION_NO"].ToString();
            tech.START_TIME = dttStart;
            tech.END_TIME = dttEnd;
            tech.ORG_ID = env.OrgID;
            tech.CREATED_BY = cabUserBy;
            ProcessAddRISTechworks process = new ProcessAddRISTechworks(tech);
            process.Invoke();

            //update status
            //ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
            //processUpdate.RISOrderdtl.ACCESSION_NO = row["ACCESSION_NO"].ToString();
            //processUpdate.RISOrderdtl.STATUS = status;
            //processUpdate.RISOrderdtl.CREATED_BY = cabUserBy;
            //processUpdate.UpdateStatus();
            //searchByCapture();

            //insert ris_techwork detail
            foreach (DataRow dr in dtMemList.Rows)
            {
                ProcessAddRISTechworksdtl pad = new ProcessAddRISTechworksdtl();
                pad.RIS_TECHWORKSDTL.ACCESSION_NO = row["ACCESSION_NO"].ToString();
                pad.RIS_TECHWORKSDTL.TECHNOLOGIST_ID = Convert.ToInt32(dr["id"]);
                pad.RIS_TECHWORKSDTL.CREATED_BY = env.UserID;
                pad.RIS_TECHWORKSDTL.RAD_SLNO = Convert.ToInt32(dr["slno"]);
                pad.Invoke();
            }
            foreach (DataRow dr in dtRadList.Rows)
            {
                ProcessAddRISTechworksdtl pad = new ProcessAddRISTechworksdtl();
                pad.RIS_TECHWORKSDTL.ACCESSION_NO = row["ACCESSION_NO"].ToString();
                pad.RIS_TECHWORKSDTL.TECHNOLOGIST_ID = Convert.ToInt32(dr["id"]);
                pad.RIS_TECHWORKSDTL.CREATED_BY = env.UserID;
                pad.RIS_TECHWORKSDTL.RAD_SLNO = Convert.ToInt32(dr["slno"]);
                pad.AddRadGroup();
            }
        }
        private void yesEntry()
        {
            //string s = msg.ShowAlert("UID1043", env.CurrentLanguageID);
            ////capturebBy = env.UserID;
            //if (s == "2")
            //{
            //    Dialog.PerformUsr per = new RIS.Forms.Technologist.Dialog.PerformUsr();
            //    per.StartPosition = FormStartPosition.CenterParent;
            //    if (DialogResult.OK == per.ShowDialog())
            //    {
            //        cabUserBy = per.PerformBy;
            //        //group_id = 0;
            //        capMode = "USERMEM";
            //    }
            //    else
            //        return;
            //}
            //else if (s == "3")
            //{
            //    Dialog.PerformUsrGroup per = new RIS.Forms.Technologist.Dialog.PerformUsrGroup();
            //    per.StartPosition = FormStartPosition.CenterParent;
            //    if (DialogResult.OK == per.ShowDialog())
            //    {
            //        cabGroupBy = per.PerformBy;
            //        //group_id = 0;
            //        capMode = "GROUPMEM";
            //    }
            //    else
            //        return;
            //}

            ReloadCapture();
            ReloadDemographic();
            onCapture = true;
            ribbonPage_DataShowing();

            ribbonControl1.SelectedPage = ribPageTechnologist;
        }

        private void SetStatusCancelDiscontinue(DataRow dr)
        {
            Reason frm = new Reason();
            if (DialogResult.OK == frm.ShowDialog())
            {
                ProcessAddRISTechworks process = new ProcessAddRISTechworks();
                process.RIS_TECHWORK.ACCESSION_ON = dr["ACCESSION_NO"].ToString();
                process.RIS_TECHWORK.TAKE = Convert.ToByte(dr["TAKE"]);
                process.RIS_TECHWORK.START_TIME = dttStart;
                process.RIS_TECHWORK.END_TIME = dttEnd;
                //process.RISTechworks.EXPOSURE_TECHNIQUE = txtExposure.Text.Trim();
                //process.RISTechworks.PROTOCOL = txtProtocol.Text.Trim();
                //process.RISTechworks.KV = txtKV.Text.Trim();
                //process.RISTechworks.mA = txtmA.Text.Trim();
                //process.RISTechworks.SEC = txtSec.Text.Trim();
                process.RIS_TECHWORK.STATUS = 'X';
                //process.RISTechworks.NO_OF_IMAGES = Convert.ToInt32(txtNoOfImage.Text);
                process.RIS_TECHWORK.ORG_ID = env.OrgID;
                process.RIS_TECHWORK.CREATED_BY = capMode == "USERMEM" ? cabUserBy : cabGroupBy;
                process.RIS_TECHWORK.PERFORMANCED_BY = capMode == "USERMEM" ? cabUserBy : cabGroupBy;
                process.RIS_TECHWORK.COMMENTS = frm.Comment;
                process.Invoke();


                //ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                //processUpdate.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                //processUpdate.RISOrderdtl.STATUS = "X";
                //processUpdate.RISOrderdtl.CREATED_BY = capMode == "USERMEM" ? cabUserBy : cabGroupBy;
                //processUpdate.UpdateStatus();
                //searchByCapture();
                ReloadWorkload();
            }
        }
        private void btnGO_Click(object sender, EventArgs e)
        {
            //ReloadWorkload();
            if (xtraTabControl2.SelectedTabPage == tabWorkload)
                ReloadWorkload();
            else if (xtraTabControl2.SelectedTabPage == tabRejectImage)
                ReloadReject();
        }
        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ReloadWorkload();
                if (xtraTabControl2.SelectedTabPage == tabWorkload)
                    ReloadWorkload();
                else if (xtraTabControl2.SelectedTabPage == tabRejectImage)
                    ReloadReject();
            }
        }
        private void radioGroup1_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                panelDate.Visible = true;
                panelHN.Visible = false;
            }
            else
            {
                panelDate.Visible = false;
                panelHN.Visible = true;
            }
        }

        private void waitingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status_selected(dttCon.Rows[0][0]);
        }
        private void startedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status_selected(dttCon.Rows[1][0]);
        }
        private void completeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status_selected(dttCon.Rows[2][0]);
        }
        private void discontinuedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status_selected(dttCon.Rows[3][0]);
        }
        private void canceledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status_selected(dttCon.Rows[4][0]);
        }

        private void status_selected(object value)
        {
            tmAutoRefresh.Stop();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                dttStart = DateTime.Now;
                string s = string.Empty;
                int id = Convert.ToInt32(value);
                dr["colStatus"] = id;
                gridView2.RefreshData();
                if (id == 1)
                {
                    s = msg.ShowAlert("UID1039", env.CurrentLanguageID);
                    dttEnd = DateTime.Now;
                    if (s == "2")
                        yesEntry();
                    if (s == "3")
                        onlyStart();
                    else
                    {
                        dr["colStatus"] = 0;
                        gridView2.RefreshData();
                    }
                }
                else if (id == 2)
                {
                    s = msg.ShowAlert("UID1042", env.CurrentLanguageID);
                    dttEnd = DateTime.Now;
                    //status = 2;
                    if (s == "2")
                        yesEntry();
                    if (s == "3")
                        onlyComplete();
                    else
                    {
                        dr["colStatus"] = 0;
                        gridView2.RefreshData();
                    }
                }
                else if (id == 3)
                {
                    //discontinue
                    dttEnd = DateTime.Now;
                    s = msg.ShowAlert("UID1040", env.CurrentLanguageID);
                    if (s == "2")
                        // MessageBox.Show("X");
                        SetStatusCancelDiscontinue(dr);
                    else
                    {
                        dr["colStatus"] = 0;
                        gridView2.RefreshData();
                    }
                }
                else if (id == 4)
                {
                    //cancel
                    dttEnd = DateTime.Now;
                    s = msg.ShowAlert("UID1041", env.CurrentLanguageID);
                    if (s == "2")
                        // MessageBox.Show("X");
                        SetStatusCancelDiscontinue(dr);
                    else
                    {
                        dr["colStatus"] = 0;
                        gridView2.RefreshData();
                    }
                }
                else
                {
                    dr["colStatus"] = 0;
                    gridView2.RefreshData();
                }
            }
            tmAutoRefresh.Start();
        }
        private void chkAllModality_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllModality.Checked)
                dvWorkLoad.RowFilter = "";
            else
                dvWorkLoad.RowFilter = "MODALITY_ID=" + modalityID.ToString();
            gridView2.RefreshData();
            gridView2.BestFitColumns();
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            status_selected(dttCon.Rows[1][0]);
        }
        private void txtComboModality_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFilterWorkload();
            LoadGridWorkload();
        }

        private void Properties_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.CloseMode == DevExpress.XtraEditors.PopupCloseMode.ButtonClick)
            {
                LoadFilterWorkload();
                LoadGridWorkload();
            }
        }
        private void chkShowStartComplete_CheckedChanged(object sender, EventArgs e)
        {
            LoadFilterWorkload();
            LoadGridWorkload();
        }
        private void tmAutoRefresh_Tick(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageWorkload)
            {
                //ReloadWorkload();
                if (xtraTabControl2.SelectedTabPage == tabWorkload)
                    ReloadWorkload();
                else if (xtraTabControl2.SelectedTabPage == tabRejectImage)
                    ReloadReject();
            }
        }

        private void commentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle < 0) return;

            tmAutoRefresh.Stop();
            DataRow fcRow = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            frmMessageConversation frm = new frmMessageConversation(fcRow["ACCESSION_NO"].ToString());
            frm.ShowDialog();

            Refreshing();
            tmAutoRefresh.Start();
        }
        private void barComments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl2.SelectedTabPage == tabWorkload)
                CommentsProcess();
            else if (xtraTabControl2.SelectedTabPage == tabRejectImage)
                CommentsProcessReject();
        }
        private void btnOrderSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //OrderSummaryProcess();
            if (xtraTabControl2.SelectedTabPage == tabWorkload)
                OrderSummaryProcess();
            else if (xtraTabControl2.SelectedTabPage == tabRejectImage)
                OrderSummaryProcessReject();
        }
        private void orderSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderSummaryProcess();
        }
        private void toolStripHisAllergy_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle < -1) return;

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            this._orderSummary.ShowDialogShortcut(true, dr["ACCESSION_NO"].ToString(), "allergy");
        }
        private void CommentsProcess()
        {
            Comment.frmComment frm = null;
            if (gridView2.FocusedRowHandle < 0)
            {
                frm = new Envision.NET.Forms.Comment.frmComment();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                DataRow rowHandle = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                string hn = rowHandle["HN"].ToString();
                int orderId = Convert.ToInt32(rowHandle["ORDER_ID"].ToString());
                frm = new Envision.NET.Forms.Comment.frmComment(hn, orderId, Envision.NET.Forms.Comment.QueryFromMode.Order);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            frm.Dispose();
        }
        private void OrderSummaryProcess()
        {
            if (gridView2.FocusedRowHandle < -1) return;

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            //Envision.NET.Forms.Technologist.frmPatientData ordimg = new Envision.NET.Forms.Technologist.frmPatientData(dr["ACCESSION_NO"].ToString());
            //ordimg.Text = "Order Summary";
            //ordimg.FormBorderStyle = FormBorderStyle.Sizable;
            //ordimg.StartPosition = FormStartPosition.CenterScreen;
            //ordimg.MaximizeBox = false;
            //ordimg.MinimizeBox = false;
            //ordimg.ShowDialog();
            this._orderSummary.ShowDialog(true, dr["ACCESSION_NO"].ToString());
        }

        private void chkTemplate_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (gridView2.FocusedRowHandle > -1)
                {
                    gridView2.OptionsBehavior.Editable = false;

                    DataRow drChk = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                    if (chk.Checked == false)
                        drChk["CHK"] = "Y";
                    else
                        drChk["CHK"] = "N";

                    drChk.AcceptChanges();

                    if (drChk["CHK"].ToString() == "Y")
                    {
                        string ACCESSION_NO = drChk["ACCESSION_NO"].ToString();
                        string MERGE = drChk["MERGE"].ToString();
                        string MERGE_WITH = drChk["MERGE_WITH"].ToString();

                        for (int i = 0; i < gridView2.RowCount; i++)
                        {
                            if (i == gridView2.FocusedRowHandle) continue;

                            DataRow row = gridView2.GetDataRow(i);
                            if (
                                (row["ACCESSION_NO"].ToString().Length == 0 ? "EMPTY" : row["ACCESSION_NO"].ToString())
                                == MERGE_WITH
                                || (row["MERGE_WITH"].ToString().Length == 0 ? "EMPTY" : row["MERGE_WITH"].ToString())
                                == ACCESSION_NO
                                || (row["MERGE_WITH"].ToString().Length == 0 ? "EMPTY" : row["MERGE_WITH"].ToString())
                                == MERGE_WITH
                                || (row["ACCESSION_NO"].ToString().Length == 0 ? "EMPTY" : row["ACCESSION_NO"].ToString())
                                == ACCESSION_NO
                                )
                            {
                                row["CHK"] = "Y";
                            }
                        }
                    }
                    else
                    {
                        string ACCESSION_NO = drChk["ACCESSION_NO"].ToString();
                        string MERGE = drChk["MERGE"].ToString();
                        string MERGE_WITH = drChk["MERGE_WITH"].ToString();

                        for (int i = 0; i < gridView2.RowCount; i++)
                        {
                            if (i == gridView2.FocusedRowHandle) continue;

                            DataRow row = gridView2.GetDataRow(i);
                            if (
                                (row["ACCESSION_NO"].ToString().Length == 0 ? "EMPTY" : row["ACCESSION_NO"].ToString())
                                == MERGE_WITH
                                || (row["MERGE_WITH"].ToString().Length == 0 ? "EMPTY" : row["MERGE_WITH"].ToString())
                                == ACCESSION_NO
                                || (row["MERGE_WITH"].ToString().Length == 0 ? "EMPTY" : row["MERGE_WITH"].ToString())
                                == MERGE_WITH
                                || (row["ACCESSION_NO"].ToString().Length == 0 ? "EMPTY" : row["ACCESSION_NO"].ToString())
                                == ACCESSION_NO
                                )
                            {
                                row["CHK"] = "N";
                            }
                        }
                    }

                    gridView2.OptionsBehavior.Editable = true;
                }
            }
        }
        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = gridView2.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    if (dr["IS_ALERT_CLINICAL_INSTRUCTION"].ToString() == "Y")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                        //e.Appearance.ForeColor = Color.White;
                    }
                    else
                        //Show Online case
                        if (dr["IS_REQONLINE"].ToString() == "Y")
                        {
                            e.Appearance.BackColor = Color.SkyBlue;
                        }
                        else
                        {
                            //Show Merge case
                            if (dr["MERGE"].ToString() != string.Empty)
                            {
                                if (dr["MERGE_WITH"].ToString() != string.Empty)
                                {
                                    e.Appearance.BackColor = Color.LightPink;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.LightPink;
                                }
                            }
                            else
                            {
                                e.Appearance.BackColor = SystemColors.Window;
                            }
                        }
                }
            }
        }
        private void btnMerge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl2.SelectedTabPage == tabRejectImage) return;
            if (gridView2.FocusedRowHandle < 0) return;

            DataView dvW = (DataView)gridControl2.DataSource;
            DataTable dtW = dvW.Table;
            //DataRow[] drS = dtW.Select(" CHK = 'Y' AND (STATUS = 'New' OR STATUS = 'New(T)')");
            DataRow[] drS = dtW.Select(" CHK = 'Y' AND (ORDER_STATUS = 'A' OR ORDER_STATUS = 'C')");

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr["ORDER_STATUS"].ToString().ToLower() == "f" || dr["ORDER_STATUS"].ToString().ToLower() == "p" || dr["ORDER_STATUS"].ToString().ToLower() == "d" || dr["STATUS"].ToString().ToLower() == "locked")
            {
                msg.ShowAlert("UID1116", env.CurrentLanguageID);
                return;
            }
            if (CheckIsLock(dr["ACCESSION_NO"].ToString(), dr["ORDER_STATUS"].ToString()) == -1)
            {
                msg.ShowAlert("UID5005", env.CurrentLanguageID);
                return;
            }
            Merge frm;
            if (drS.Length > 0)
                frm = new Merge(dr, drS);
            else
                frm = new Merge(dr);
            frm.ShowDialog();

            ReloadWorkload();
        }
        private void btnSplit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl2.SelectedTabPage == tabRejectImage) return;
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                switch (dr["ORDER_STATUS"].ToString())
                {
                    case "D":
                        msg.ShowAlert("UID1116", env.CurrentLanguageID);
                        ReloadWorkload();
                        return;
                        break;
                    case "P":
                        msg.ShowAlert("UID1116", env.CurrentLanguageID);
                        ReloadWorkload();
                        return;
                        break;
                    case "F":
                        msg.ShowAlert("UID1116", env.CurrentLanguageID);
                        ReloadWorkload();
                        return;
                        break;
                    default:
                        break;
                }
                split(dr);
                ReloadWorkload();
                //UnLockCase(true);
            }
            else
            {
                msg.ShowAlert("UID018", env.CurrentLanguageID);
                return;
            }
        }
        private void split(DataRow data)
        {
            #region Required Check.
            if (string.IsNullOrEmpty(data["MERGE"].ToString()))
            {
                msg.ShowAlert("UID1123", env.CurrentLanguageID);
                return;
            }
            #endregion

            if (msg.ShowAlert("UID1124", env.CurrentLanguageID) == "2")
            {
                Envision.BusinessLogic.ResultEntry result = new Envision.BusinessLogic.ResultEntry();
                result.RISExamresult.ACCESSION_NO = data["ACCESSION_NO"].ToString();
                result.RISExamresult.MERGE = "SPT";
                result.RISExamresult.MERGE_WITH = string.Empty;
                result.MergeSplit();
            }
        }
        private int CheckIsLock(string AccessionNO, string Status)
        {
            LookUpSelect ls = new LookUpSelect();
            DataSet dsLock = ls.SelectExamResultLock(AccessionNO, env.UserID);
            int SL_NO = 0;
            if (dsLock.Tables[1].Rows.Count > 0)
            {
                if (dsLock.Tables[1].Rows[0]["WORKING_RAD"].ToString() == env.UserID.ToString())
                {
                    TriggerResultTime(AccessionNO, env.UserID, Status);
                    SL_NO = Convert.ToInt32(dsLock.Tables[1].Rows[0]["SL_NO"].ToString());
                    return env.UserID; //true 
                }
            }
            else
            {
                TriggerResultTime(AccessionNO, env.UserID, Status);
                return env.UserID; //true
            }
            return -1; // false,This case can't select
        }
        private void TriggerResultTime(string _AccessionNO, int _rad_id, string Status)
        {
            ProcessAddRISExamresulttime _prctime = new ProcessAddRISExamresulttime();
            _prctime.RIS_EXAMRESULTTIME.ACCESSION_NO = _AccessionNO;
            _prctime.RIS_EXAMRESULTTIME.RAD_ID = _rad_id;
            _prctime.RIS_EXAMRESULTTIME.START_STATUS = Status;
            _prctime.Invoke();
        }
        #endregion

        private void LoadDataCapture()
        {
            getExamData();
            getTechWork();
            getConsumable();
        }
        private void LoadFilterCapture()
        {
            DataView dv = dvConsumable;
            dv.RowFilter = " IS_DELETED <>'Y' ";
        }
        private void LoadGridCapture()
        {
            gridControl3.DataSource = dvConsumable;

            int k = 0;
            while (k < gridView3.Columns.Count)
            {
                gridView3.Columns[k].Visible = false;
                ++k;
            }

            gridView3.OptionsView.ShowBands = false;
            gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView3.OptionsView.ShowColumnHeaders = true;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
            repositoryItemLookUpEdit1.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.DataSource = dttExam;
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examID_KeyUp);
            repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examID_CloseUp);
            gridView3.Columns["EXAM_ID"].ColumnEdit = repositoryItemLookUpEdit1;
            gridView3.Columns["EXAM_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            gridView3.Columns["EXAM_ID"].Visible = true;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit2.ImmediatePopup = true;
            repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit2.AutoHeight = false;
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.ValueMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.DataSource = dttExam;
            repositoryItemLookUpEdit2.NullText = string.Empty;
            repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
            repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
            //gridView3.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            gridView3.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            gridView3.Columns["EXAM_NAME"].Visible = true;

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btnDeleteRow_Click);
            gridView3.Columns["colDelete"].Caption = string.Empty;
            gridView3.Columns["colDelete"].ColumnEdit = btn;
            gridView3.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gridView3.Columns["colDelete"].Width = 50;
            gridView3.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemSpinEdit spin = new RepositoryItemSpinEdit();
            spin.KeyUp += new KeyEventHandler(qty_KeyUp);
            spin.ValueChanged += new EventHandler(qty_ValueChanged);
            spin.MinValue = 0.1M;
            spin.MaxValue = 999.99M;
            gridView3.Columns["QTY"].ColumnEdit = spin;


            gridView3.Columns["QTY"].Visible = true;
            gridView3.Columns["RATE"].Visible = true;
            gridView3.Columns["Total"].Visible = true;
            //gridView3.Columns["colDelete"].Visible = true;

            gridView3.Columns["EXAM_ID"].Caption = "Consumable Code";
            gridView3.Columns["EXAM_NAME"].Caption = "Consumable Name";
            gridView3.Columns["QTY"].Caption = "Qty";
            gridView3.Columns["RATE"].Caption = "Rate";
            gridView3.Columns["RATE"].OptionsColumn.ReadOnly = true;
            gridView3.Columns["RATE"].DisplayFormat.FormatString = "#,##0.00";
            gridView3.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gridView3.Columns["Total"].Caption = "Total";
            //gridView3.Columns["Total"].OptionsColumn.ReadOnly = true;
            //gridView3.Columns["Total"].DisplayFormat.FormatString = "#,##0.00";
            //gridView3.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView3.Columns["colDelete"].Caption = string.Empty;
            gridView3.BestFitColumns();

            TotalRate_Calculating();
        }
        private void ReloadCapture()
        {
            ReloadCaptureChangeExam();

            #region old code
            /*if (gridView2.FocusedRowHandle < 0) return;

            ribbonPage1.Text = "Capture";
            xtraTabControl1.SelectedTabPage = pageCapture;
            ribbonControl1.SelectedPage = ribPageTechnologist;
            layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            take = Convert.ToInt32(dr["TAKE"]);
            accessionNo = dr["ACCESSION_NO"].ToString();
            orderID = Convert.ToInt32(dr["order_id"]);
            status = Convert.ToInt32(dr["colStatus"]);

            #region set combobox index
            if (cboStatus.Items.Count == 0)
            {
                cboStatus.Items.Clear();
                cboStatus.ValueMember = "ID";
                cboStatus.DisplayMember = "Name";
                cboStatus.DataSource = dttCon;
            }

            if (status == 1)
                cboStatus.SelectedIndex = 1;
            else if (status == 2)
                cboStatus.SelectedIndex = 2;
            else
                cboStatus.SelectedIndex = 0;
            #endregion

            #region clear textbox
            txtKV.Text = "";
            txtmA.Text = "";
            txtSec.Text = "";
            txtExposure.Text = "";
            txtNoOfImage.Text = "";
            txtProtocol.Text = "";
            #endregion

            LoadDataCapture();
            LoadFilterCapture();
            LoadGridCapture();

            ribbonPage_DataShowing();
            ribbonBtn_visibility();*/
            #endregion
        }

        #region Capture Page
        private void getExamData()
        {
            try
            {
                //ProcessGetRISExam processExam = new ProcessGetRISExam();
                //processExam.Invoke();
                //DataRow[] drs = processExam.Result.Tables[0].Select("EXAM_TYPE=8");
                //dttExam = processExam.Result.Tables[0].Clone();
                //foreach (DataRow dr in drs)
                //    dttExam.Rows.Add(dr.ItemArray);
                //dttExam.TableName = "RIS_EXAM";
                LookUpSelect lk = new LookUpSelect();
                dttExam = lk.SelectExamConsumable().Tables[0];
                dttExam.TableName = "RIS_EXAM";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getTechWork()
        {
            try
            {
                int tmpTake = take > 1 ? take - 1 : take;
                ProcessGetRISTechworks process = new ProcessGetRISTechworks();
                process.RIS_TECHWORK.ACCESSION_ON = accessionNo;
                process.RIS_TECHWORK.TAKE = (byte)tmpTake;
                process.Invoke();
                if (process.Result != null && process.Result.Tables.Count > 0 && process.Result.Tables[0].Rows.Count > 0)
                {
                    txtKV.Text = process.Result.Tables[0].Rows[0]["KV"].ToString();
                    txtmA.Text = process.Result.Tables[0].Rows[0]["mA"].ToString();
                    txtSec.Text = process.Result.Tables[0].Rows[0]["SEC"].ToString();
                    txtExposure.Text = process.Result.Tables[0].Rows[0]["EXPOSURE_TECHNIQUE"].ToString();
                    txtNoOfImage.Text = process.Result.Tables[0].Rows[0]["NO_OF_IMAGES"].ToString().Trim() == string.Empty ? "0" : process.Result.Tables[0].Rows[0]["NO_OF_IMAGES"].ToString();
                    txtProtocol.Text = process.Result.Tables[0].Rows[0]["PROTOCOL"].ToString();
                    mode = "Edit";
                }
                else
                {
                    mode = "New";
                }

                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HR_EMP.MODE = "EmpId";
                bg.HR_EMP.EMP_ID = cabUserBy;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = 0;
                bg.Invoke();

                DataRow dr = bg.Result.Tables[0].Rows[0];
                txtPerformName.Text = dr["FullName"].ToString();
                txtTake.Text = tmpTake.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getConsumable()
        {
            //LookUpSelect lk = new LookUpSelect();
            //dtt = lk.SelectExamConsumable().Tables[0];
            //orderManger = new OrderManager();
            //order thisOrder = new order(ORDER_ID);
            //OrderDate = thisOrder.Item.ORDER_DT;
            //_modality = (int)thisOrder.ItemDetail.Rows[0]["MODALITY_ID"];
            //setGridData();
            //calTotal();
            //DataTable dtt = new DataTable();
            //dtt = thisOrder.ItemDetail.Clone();

            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            int ORDER_ID = Convert.ToInt32(row["ORDER_ID"]);
            Order thisOrder = new Order(ORDER_ID);
            DataTable dtt = new DataTable();
            //if (mode == "New")
            //{
            //    dtt = thisOrder.ItemDetail.Clone();
            //    dtt.Columns.Add("Total", typeof(decimal));
            //    //dtt.Columns.Add("colDelete", typeof(string));
            //}
            //else
            //{
            //    dtt = thisOrder.ItemDetail.Copy();
            //    dtt.Columns.Add("Total", typeof(decimal));
            //    //dtt.Columns.Add("colDelete", typeof(string));
            //    foreach (DataRow dr in dtt.Rows)
            //    {
            //        DataRow[] drs = dttExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString().Trim());
            //        if (drs.Length > 0)
            //        {
            //            dr["EXAM_NAME"] = drs[0]["EXAM_NAME"].ToString();
            //            decimal qty = dr["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["QTY"]);
            //            decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
            //            dr["Total"] = qty * rate;
            //        }
            //    }
            //}

            dtt = thisOrder.ItemDetail.Copy();
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["SERVICE_TYPE"].ToString() != "3")
                {
                    if (dr["SERVICE_TYPE"].ToString().Trim() != "")
                    {
                        dr.Delete();
                    }
                }
            }
            dtt.AcceptChanges();
            dtt.Columns.Add("Total", typeof(decimal));
            //dtt.Columns.Add("colDelete", typeof(string));
            List<int> indexs = new List<int>();
            int k = 0;
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["EXAM_ID"] != null && dr["EXAM_ID"].ToString().Trim() != "")
                {
                    string query = "EXAM_ID=" + dr["EXAM_ID"].ToString().Trim();
                    DataRow[] drs = dttExam.Select(query);
                    if (drs.Length > 0)
                    {
                        dr["EXAM_NAME"] = drs[0]["EXAM_NAME"].ToString();
                        decimal qty = dr["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["QTY"]);
                        decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
                        dr["Total"] = qty * rate;
                    }
                }
                else
                {
                    indexs.Add(k);
                }
                k++;
            }

            foreach (int index in indexs)
                dtt.Rows.RemoveAt(index);

            #region old code
            //ProcessGetRISTechconsumption process = new ProcessGetRISTechconsumption();
            //DataTable dtt = new DataTable();
            //if (mode == "New")
            //{
            //    process.RISTechconsumption.ACCESSION_NO = "fadel cheteng";
            //    process.RISTechconsumption.TAKE = 0;
            //    process.Invoke();
            //    dtt = process.Result.Tables[0].Copy();
            //    dtt.Columns.Add("Total", typeof(decimal));
            //    dtt.Columns.Add("colDelete", typeof(string));
            //}
            //else
            //{
            //    process.RISTechconsumption.ACCESSION_NO = accessionNo;
            //    int tmpTake = take > 1 ? take - 1 : take;
            //    process.RISTechconsumption.TAKE = (byte)tmpTake;
            //    process.Invoke();
            //    dtt = process.Result.Tables[0].Copy();
            //    dtt.Columns.Add("Total", typeof(decimal));
            //    dtt.Columns.Add("colDelete", typeof(string));
            //    foreach (DataRow dr in dtt.Rows)
            //    {
            //        DataRow[] drs = dttExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString().Trim());
            //        if (drs.Length > 0)
            //        {
            //            dr["EXAM_NAME"] = drs[0]["EXAM_NAME"].ToString();
            //            decimal qty = dr["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["QTY"]);
            //            decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
            //            dr["Total"] = qty * rate;
            //        }
            //    }
            //}
            #endregion

            DataRow newRow = dtt.NewRow();
            newRow["QTY"] = 1;
            newRow["IS_DELETED"] = "N";
            dtt.Rows.Add(newRow);

            dtConsumable = dtt;
            dvConsumable = dtt.DefaultView;
        }

        private void qty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView3.FocusedColumn = gridView3.VisibleColumns[0];
                gridView3.MoveNext();
            }
            TotalRate_Calculating();
        }
        private void qty_ValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SpinEdit spin = (DevExpress.XtraEditors.SpinEdit)sender;
            decimal val = spin.Value;
            if (spin.Value.ToString().Trim() == string.Empty) return;
            if (val < 0.1M)
            {
                val = 0.1M;
                return;
            }
            int row = gridView3.FocusedRowHandle;
            if (mode == "Edit")
            {
                // หา row จริง ๆ
            }
            DataView dv = (DataView)gridControl3.DataSource;
            DataTable dtt = dv.Table;
            decimal qty = Convert.ToDecimal(spin.Value);
            decimal rate = dtt.Rows[row]["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dtt.Rows[row]["RATE"]);
            dtt.Rows[row]["QTY"] = qty;
            dtt.Rows[row]["Total"] = qty * rate;
            gridView3.RefreshData();

            TotalRate_Calculating();
        }

        private void examID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (e.Value.ToString() != string.Empty)
                {
                    DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                    int row = gridView3.FocusedRowHandle;
                    DataView dv = (DataView)gridControl3.DataSource;
                    DataTable dtt = dv.Table;
                    bool flag = false;
                    for (int i = 0; i < dtt.Rows.Count; i++)
                        if (dtt.Rows[i]["EXAM_ID"].ToString().Trim() == e.Value.ToString().Trim())
                        {
                            flag = true;
                            break;
                        }
                    if (flag)
                    {
                        msg.ShowAlert("UID1044", env.CurrentLanguageID);
                        e.AcceptValue = false;
                        return;
                    }
                    updateExamID(e.Value.ToString());
                    if (gridView3.FocusedColumn.VisibleIndex != gridView3.VisibleColumns.Count - 1)
                    {
                        gridView3.FocusedRowHandle = row;
                        gridView3.FocusedColumn = gridView3.VisibleColumns[2];
                    }
                    else
                    {
                        gridView3.FocusedColumn = gridView3.VisibleColumns[0];
                        gridView3.MoveNext();
                    }
                }
                TotalRate_Calculating();
            }
        }
        private void examID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (gridView3.FocusedColumn.VisibleIndex != gridView3.VisibleColumns.Count - 1)
                    gridView3.FocusedColumn = gridView3.VisibleColumns[2];
                else
                {
                    gridView3.FocusedColumn = gridView3.VisibleColumns[0];
                    gridView3.MoveNext();
                }
                TotalRate_Calculating();
            }
        }
        private void examName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (e.Value.ToString() != string.Empty)
                {
                    DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                    int row = gridView3.FocusedRowHandle;
                    bool flag = false;
                    DataView dv = (DataView)gridControl3.DataSource;
                    DataTable dtt = dv.Table;
                    for (int i = 0; i < dtt.Rows.Count; i++)
                        if (dtt.Rows[i]["EXAM_NAME"].ToString().Trim() == e.Value.ToString().Trim())
                        {
                            flag = true;
                            break;
                        }
                    if (flag)
                    {
                        msg.ShowAlert("UID1044", env.CurrentLanguageID);
                        e.AcceptValue = false;
                        return;
                    }
                    UpdateExamName(e.Value.ToString());
                    if (gridView3.FocusedColumn.VisibleIndex != gridView3.VisibleColumns.Count - 1)
                    {
                        gridView3.FocusedRowHandle = row;
                        gridView3.FocusedColumn = gridView3.VisibleColumns[gridView3.FocusedColumn.VisibleIndex + 1];
                    }
                    else
                    {
                        gridView3.FocusedColumn = gridView3.VisibleColumns[0];
                        gridView3.MoveNext();
                    }
                }
                TotalRate_Calculating();
            }
        }
        private void examName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gridView3.FocusedColumn.VisibleIndex != gridView3.VisibleColumns.Count - 1)
                    gridView3.FocusedColumn = gridView3.VisibleColumns[gridView3.FocusedColumn.VisibleIndex + 1];
                else
                {
                    gridView3.FocusedColumn = gridView3.VisibleColumns[0];
                    gridView3.MoveNext();
                }
                TotalRate_Calculating();
            }
        }

        private bool canAddRow()
        {
            DataView dv = (DataView)gridControl3.DataSource;
            DataTable dtt = dv.Table;
            bool flag = true;
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        private void updateExamID(string strSearch)
        {
            DataView dv = (DataView)gridControl3.DataSource;
            DataTable dtt = dv.Table;
            int row = gridView3.FocusedRowHandle;
            if (mode == "Edit")
            {
                if (dtt.Rows[row]["IS_DELETED"].ToString().Trim() == "Y")
                {
                    for (int j = 0; j < dtt.Rows.Count; j++)
                        if (dtt.Rows[j]["IS_DELETED"].ToString().Trim() == "N")
                        {
                            row = j;
                            break;
                        }
                }
            }
            int i = 0;
            for (; i < dttExam.Rows.Count; i++)
                if (dttExam.Rows[i]["EXAM_ID"].ToString() == strSearch)
                    break;
            if (i < dttExam.Rows.Count)
            {
                DataRow dr = dttExam.Rows[i];
                dtt.Rows[row]["EXAM_ID"] = dr["EXAM_ID"];
                dtt.Rows[row]["EXAM_NAME"] = dr["EXAM_NAME"];
                dtt.Rows[row]["RATE"] = dr["RATE"];
                decimal qty = dtt.Rows[row]["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dtt.Rows[row]["QTY"]);
                decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
                dtt.Rows[row]["Total"] = qty * rate;
                if (canAddRow())
                {
                    dr = dtt.NewRow();
                    dr["IS_DELETED"] = "N";
                    dr["QTY"] = 1;
                    dtt.Rows.Add(dr);
                }
                gridView3.RefreshData();
            }
        }
        private void UpdateExamName(string strSearch)
        {
            DataView dv = (DataView)gridControl3.DataSource;
            DataTable dtt = dv.Table;
            int row = gridView3.FocusedRowHandle;
            int i = 0;
            for (; i < dttExam.Rows.Count; i++)
                if (dttExam.Rows[i]["EXAM_NAME"].ToString() == strSearch)
                    break;
            if (i < dttExam.Rows.Count)
            {
                DataRow dr = dttExam.Rows[i];
                dtt.Rows[row]["EXAM_ID"] = dr["EXAM_ID"];
                dtt.Rows[row]["EXAM_NAME"] = dr["EXAM_NAME"];
                dtt.Rows[row]["RATE"] = dr["RATE"];
                decimal qty = dtt.Rows[row]["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dtt.Rows[row]["QTY"]);
                decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
                dtt.Rows[row]["Total"] = qty * rate;
                gridView3.RefreshData();
                if (canAddRow())
                {
                    dr = dtt.NewRow();
                    dr["IS_DELETED"] = "N";
                    dr["QTY"] = 1;
                    dtt.Rows.Add(dr);
                }
            }
        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)gridControl3.DataSource;
            DataTable dtt = dv.Table;
            if (dtt.Rows.Count > 0)
            {
                string s = string.Empty;
                if (mode == "New")
                {
                    if (dtt.Rows[gridView3.FocusedRowHandle]["EXAM_ID"].ToString().Trim() == string.Empty) return;
                    s = msg.ShowAlert("UID1025", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        dtt.Rows[gridView3.FocusedRowHandle].Delete();
                        dtt.AcceptChanges();
                        dv = new DataView(dtt);
                        gridControl3.DataSource = dv;
                    }
                }
                else
                {
                    if (dtt.Rows[gridView3.FocusedRowHandle]["EXAM_ID"].ToString().Trim() == string.Empty) return;
                    s = msg.ShowAlert("UID1025", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        //if (dtt.Rows[view1.FocusedRowHandle]["ACCESSION_NO"].ToString().Trim() != string.Empty)
                        //    delExam.Add(Convert.ToInt32(dtt.Rows[view1.FocusedRowHandle]["EXAM_ID"]));
                        dtt.Rows[gridView3.FocusedRowHandle].Delete();
                        dtt.AcceptChanges();
                        dv = new DataView(dtt);
                        gridControl3.DataSource = dv;

                    }

                }
            }
            TotalRate_Calculating();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            dttEnd = DateTime.Now;
            if (mode == "New")
            {
                string s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                if (s == "2")
                {
                    try
                    {
                        ProcessAddRISTechworks process = new ProcessAddRISTechworks();
                        process.RIS_TECHWORK.ACCESSION_ON = accessionNo;
                        process.RIS_TECHWORK.TAKE = (byte)take;
                        process.RIS_TECHWORK.START_TIME = dttStart;
                        process.RIS_TECHWORK.END_TIME = dttEnd;
                        process.RIS_TECHWORK.EXPOSURE_TECHNIQUE = txtExposure.Text.Trim();
                        process.RIS_TECHWORK.PROTOCOL = txtProtocol.Text.Trim();
                        process.RIS_TECHWORK.KV = txtKV.Text.Trim();
                        process.RIS_TECHWORK.mA = txtmA.Text.Trim();
                        process.RIS_TECHWORK.SEC = txtSec.Text.Trim();

                        if (cboStatus.SelectedValue.ToString() == "0")
                            process.RIS_TECHWORK.STATUS = 'A';
                        else if (cboStatus.SelectedValue.ToString() == "1")
                            process.RIS_TECHWORK.STATUS = 'S';
                        else if (cboStatus.SelectedValue.ToString() == "2")
                            process.RIS_TECHWORK.STATUS = 'C';
                        else
                            process.RIS_TECHWORK.STATUS = 'X';

                        if (process.RIS_TECHWORK.STATUS == 'X')
                        {
                            Reason frm = new Reason();
                            frm.ShowDialog();
                            process.RIS_TECHWORK.COMMENTS = frm.Comment;
                        }
                        process.RIS_TECHWORK.NO_OF_IMAGES = Convert.ToInt32(txtNoOfImage.Text);
                        process.RIS_TECHWORK.ORG_ID = env.OrgID;
                        process.RIS_TECHWORK.CREATED_BY = env.UserID;
                        //process.RISTechworks.PERFORMANCED_BY = Convert.ToInt32(tech.dtTech.Rows[0]["EMP_ID"]);
                        //process.RISTechworks.PERFORMANCED_BY = Convert.ToInt32(env.UserID);
                        process.RIS_TECHWORK.PERFORMANCED_BY = cabUserBy;
                        process.Invoke();

                        //add consumption
                        ProcessAddRISTechconsumption processCon = new ProcessAddRISTechconsumption();
                        processCon.RIS_TECHCONSUMPTION.ACCESSION_NO = accessionNo;
                        processCon.RIS_TECHCONSUMPTION.TAKE = (byte)take;
                        processCon.RIS_TECHCONSUMPTION.CREATED_BY = cabUserBy;

                        dvConsumable = (DataView)gridControl3.DataSource;
                        DataTable dtt = dvConsumable.Table;
                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["EXAM_ID"].ToString().Trim() != string.Empty)
                            {
                                processCon.RIS_TECHCONSUMPTION.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                                processCon.RIS_TECHCONSUMPTION.IS_DELETED = 'N';
                                processCon.RIS_TECHCONSUMPTION.QTY = Convert.ToDecimal(dr["QTY"]);
                                processCon.RIS_TECHCONSUMPTION.RATE = Convert.ToDecimal(dr["RATE"]);
                                processCon.Invoke();
                            }
                        }
                        //update status order;
                        //ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                        //processUpdate.RISOrderdtl.ACCESSION_NO = accessionNo;
                        //processUpdate.RISOrderdtl.STATUS = process.RISTechworks.STATUS;
                        //processUpdate.RISOrderdtl.CREATED_BY = cabUserBy;
                        //processUpdate.UpdateStatus();

                        //insert ris_techwork detail
                        if (process.RIS_TECHWORK.STATUS == 'S')
                        {
                            foreach (DataRow dr in dtMemList.Rows)
                            {
                                ProcessAddRISTechworksdtl pad = new ProcessAddRISTechworksdtl();
                                pad.RIS_TECHWORKSDTL.ACCESSION_NO = accessionNo;
                                pad.RIS_TECHWORKSDTL.TECHNOLOGIST_ID = Convert.ToInt32(dr["id"]);
                                pad.RIS_TECHWORKSDTL.CREATED_BY = env.UserID;
                                try
                                {
                                    pad.Invoke();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            foreach (DataRow dr in dtRadList.Rows)
                            {
                                ProcessAddRISTechworksdtl pad = new ProcessAddRISTechworksdtl();
                                pad.RIS_TECHWORKSDTL.ACCESSION_NO = accessionNo;
                                pad.RIS_TECHWORKSDTL.TECHNOLOGIST_ID = Convert.ToInt32(dr["id"]);
                                pad.RIS_TECHWORKSDTL.CREATED_BY = env.UserID;
                                pad.RIS_TECHWORKSDTL.RAD_SLNO = Convert.ToInt32(dr["slno"]);
                                try
                                {
                                    pad.AddRadGroup();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }

                        ReloadWorkload();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        return;
                    }
                }
            }
            else
            {
                string s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                if (s == "2")
                {
                    try
                    {
                        ProcessAddRISTechworks process = new ProcessAddRISTechworks();
                        process.RIS_TECHWORK.ACCESSION_ON = accessionNo;
                        process.RIS_TECHWORK.TAKE = (byte)take;
                        process.RIS_TECHWORK.START_TIME = dttStart;
                        process.RIS_TECHWORK.END_TIME = dttEnd;
                        process.RIS_TECHWORK.EXPOSURE_TECHNIQUE = txtExposure.Text.Trim();
                        process.RIS_TECHWORK.PROTOCOL = txtProtocol.Text.Trim();
                        process.RIS_TECHWORK.KV = txtKV.Text.Trim();
                        process.RIS_TECHWORK.mA = txtmA.Text.Trim();
                        process.RIS_TECHWORK.SEC = txtSec.Text.Trim();
                        if (cboStatus.SelectedValue.ToString() == "0")
                            process.RIS_TECHWORK.STATUS = 'A';
                        else if (cboStatus.SelectedValue.ToString() == "1")
                            process.RIS_TECHWORK.STATUS = 'C';
                        else if (cboStatus.SelectedValue.ToString() == "2")
                            process.RIS_TECHWORK.STATUS = 'C';
                        else
                            process.RIS_TECHWORK.STATUS = 'X';
                        if (process.RIS_TECHWORK.STATUS == 'X')
                        {
                            Reason frm = new Reason();
                            frm.ShowDialog();
                            process.RIS_TECHWORK.COMMENTS = frm.Comment;
                        }
                        process.RIS_TECHWORK.NO_OF_IMAGES = Convert.ToInt32(txtNoOfImage.Text);
                        process.RIS_TECHWORK.ORG_ID = env.OrgID;
                        process.RIS_TECHWORK.CREATED_BY = env.UserID;
                        //process.RISTechworks.PERFORMANCED_BY = Convert.ToInt32(tech.dtTech.Rows[0]["EMP_ID"]);
                        //process.RISTechworks.PERFORMANCED_BY = Convert.ToInt32(env.UserID);
                        process.RIS_TECHWORK.PERFORMANCED_BY = cabUserBy;
                        process.Invoke();

                        //Consumption
                        //delete consumption
                        ProcessDeleteRISTechconsumption processDel = new ProcessDeleteRISTechconsumption();
                        processDel.RIS_TECHCONSUMPTION.ACCESSION_NO = accessionNo;
                        processDel.RIS_TECHCONSUMPTION.TAKE = (byte)take;
                        processDel.Invoke();

                        //add consumption
                        ProcessAddRISTechconsumption processCon = new ProcessAddRISTechconsumption();
                        processCon.RIS_TECHCONSUMPTION.ACCESSION_NO = accessionNo;
                        processCon.RIS_TECHCONSUMPTION.TAKE = (byte)take;
                        processCon.RIS_TECHCONSUMPTION.CREATED_BY = env.UserID;
                        dvConsumable = (DataView)gridControl3.DataSource;
                        DataTable dtt = dvConsumable.Table;
                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["EXAM_ID"].ToString().Trim() != string.Empty)
                            {
                                processCon.RIS_TECHCONSUMPTION.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                                processCon.RIS_TECHCONSUMPTION.IS_DELETED = 'N';
                                processCon.RIS_TECHCONSUMPTION.QTY = Convert.ToDecimal(dr["QTY"]);
                                processCon.RIS_TECHCONSUMPTION.RATE = Convert.ToDecimal(dr["RATE"]);
                                processCon.Invoke();
                            }
                        }

                        //update status order;
                        //ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                        //processUpdate.RISOrderdtl.ACCESSION_NO = accessionNo;
                        //processUpdate.RISOrderdtl.STATUS = process.RISTechworks.STATUS;
                        //processUpdate.RISOrderdtl.CREATED_BY = env.UserID;
                        //processUpdate.UpdateStatus();

                        ReloadWorkload();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        return;
                    }
                }
            }
        }
        private void btnWorkList_Click(object sender, EventArgs e)
        {
            ReloadWorkload();
        }
        private void TotalRate_Calculating()
        {
            int k = 0;
            decimal sumtol = 0;
            while (k < gridView3.RowCount)
            {
                DataRow row = gridView3.GetDataRow(k);
                if (!string.IsNullOrEmpty(row["Total"].ToString()))
                    sumtol += Convert.ToDecimal(row["Total"]);
                ++k;
            }
            txtTotalRate.Text = "Total : " + sumtol.ToString();
        }
        private void btnConsumable_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            int ORDER_ID = Convert.ToInt32(dr["ORDER_ID"]);
            frmConsumable frm = new frmConsumable(ORDER_ID);//_order_id);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ControlBox = false;
            //frm.ShowDialog();
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders(order_id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                getConsumable();
                LoadFilterCapture();
                LoadGridCapture();
                //ReloadCapture();
            }
        }
        #endregion

        private void LoadDataDemographic()
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            string acc = dr["ACCESSION_NO"].ToString().Trim();
            int ord = Convert.ToInt32(dr["ORDER_ID"]);
            HNDem = dr["HN"].ToString().Trim();

            Envision.BusinessLogic.ResultEntry result = new Envision.BusinessLogic.ResultEntry();
            result.RISExamresult.ACCESSION_NO = acc;
            result.RISExamresult.ORDER_ID = ord;
            result.RISExamresult.HN = HNDem;
            result.RISExamresult.EMP_ID = env.UserID;


            dtDemographic = result.GetDemographic();
            dtSelectCase = result.GetHistoryReport();
            dtHisReg = result.GetHistory();
            dvHisReg = new DataView(dtHisReg.Copy());
        }
        private void LoadFilterDemographic()
        {
            txtDemo_AccNo.Text = dtSelectCase.Rows[0]["ACCESSION_NO"].ToString();
            dvHisReg.RowFilter = "ACCESSION_NO <>'" + txtDemo_AccNo.Text + "' ";
        }
        private void LoadGridDemographic()
        {
            gridControl4.DataSource = dvHisReg;

            for (int i = 0; i < gridView4.Columns.Count; i++)
            {
                gridView4.Columns[i].Visible = false;
                gridView4.Columns[i].OptionsColumn.ReadOnly = true;
            }

            #region column edit
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 3, 8)});
            repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            repositoryItemImageComboBox2.SmallImages = imgWL;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit link = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            link.Image = imgHIS.Images[3];
            link.Click += new EventHandler(link_Click);

            //DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnlink = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            //btnlink. = imgHIS.Images[3];
            //btnlink.Click += new EventHandler(link_Click);

            DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkOrder = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            linkOrder.Image = imgHIS.Images[4];
            linkOrder.Click += new EventHandler(linkOrder_Click);
            //linkOrder.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            #endregion column edit

            #region column settings
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.Click += new EventHandler(chk_Click);

            gridView4.Columns["chkCol"].ColumnEdit = chk;
            gridView4.Columns["chkCol"].Caption = "";
            gridView4.Columns["chkCol"].Visible = true;
            gridView4.Columns["chkCol"].BestFit();
            gridView4.Columns["chkCol"].ColVIndex = 0;

            gridView4.Columns["PRIORITY_ID"].ColumnEdit = repositoryItemImageComboBox2;
            gridView4.Columns["PRIORITY_ID"].Caption = "Priority";
            gridView4.Columns["PRIORITY_ID"].Visible = true;
            gridView4.Columns["PRIORITY_ID"].BestFit();
            gridView4.Columns["PRIORITY_ID"].ColVIndex = 1;
            gridView4.Columns["PRIORITY_ID"].OptionsColumn.ReadOnly = true;

            gridView4.Columns["STATUS"].Caption = "Status";
            gridView4.Columns["STATUS"].Visible = true;
            gridView4.Columns["STATUS"].BestFit();
            gridView4.Columns["STATUS"].ColVIndex = 2;
            gridView4.Columns["STATUS"].OptionsColumn.ReadOnly = true;

            gridView4.Columns["TIMEDIFF"].Caption = "Waiting Time";
            gridView4.Columns["TIMEDIFF"].Visible = true;
            gridView4.Columns["TIMEDIFF"].BestFit();
            gridView4.Columns["TIMEDIFF"].ColVIndex = 3;
            gridView4.Columns["TIMEDIFF"].OptionsColumn.ReadOnly = true;

            gridView4.Columns["ORDER_DT"].Caption = "Order Time";
            gridView4.Columns["ORDER_DT"].Visible = true;
            gridView4.Columns["ORDER_DT"].ColVIndex = 4;
            gridView4.Columns["ORDER_DT"].DisplayFormat.FormatString = "G";
            gridView4.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView4.Columns["ORDER_DT"].Width = 73;
            //gridView4.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;

            gridView4.Columns["PacsImg"].Caption = "PACS Image";
            gridView4.Columns["PacsImg"].Visible = true;
            gridView4.Columns["PacsImg"].BestFit();
            gridView4.Columns["PacsImg"].ColVIndex = 5;
            gridView4.Columns["PacsImg"].ColumnEdit = link;
            gridView4.Columns["PacsImg"].OptionsColumn.ReadOnly = false;

            gridView4.Columns["OrderImg"].Caption = "Order Sum.";
            gridView4.Columns["OrderImg"].Visible = true;
            gridView4.Columns["OrderImg"].ColumnEdit = linkOrder;
            gridView4.Columns["OrderImg"].BestFit();
            gridView4.Columns["OrderImg"].ColVIndex = 6;
            gridView4.Columns["OrderImg"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView4.Columns["OrderImg"].OptionsColumn.ReadOnly = false;

            gridView4.Columns["ACCESSION_NO"].Caption = "Accession No";
            gridView4.Columns["ACCESSION_NO"].Visible = true;
            gridView4.Columns["ACCESSION_NO"].BestFit();
            gridView4.Columns["ACCESSION_NO"].ColVIndex = 7;
            gridView4.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;

            gridView4.Columns["EXAM_NAME"].Caption = "Exam Name";
            gridView4.Columns["EXAM_NAME"].Visible = true;
            gridView4.Columns["EXAM_NAME"].BestFit();
            gridView4.Columns["EXAM_NAME"].ColVIndex = 8;
            gridView4.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;

            gridView4.Columns["Radiologist"].Caption = "Radiologist";
            gridView4.Columns["Radiologist"].Visible = true;
            gridView4.Columns["Radiologist"].BestFit();
            gridView4.Columns["Radiologist"].ColVIndex = 9;
            gridView4.Columns["Radiologist"].OptionsColumn.ReadOnly = true;

            gridView4.Columns["Unit"].Caption = "Ordering Dept.";
            gridView4.Columns["Unit"].Visible = true;
            gridView4.Columns["Unit"].BestFit();
            gridView4.Columns["Unit"].ColVIndex = 10;
            gridView4.Columns["Unit"].OptionsColumn.ReadOnly = true;

            gridView4.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
            gridView4.Columns["CLINIC_TYPE_TEXT"].Visible = true;
            gridView4.Columns["CLINIC_TYPE_TEXT"].BestFit();
            gridView4.Columns["CLINIC_TYPE_TEXT"].ColVIndex = 11;
            gridView4.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.ReadOnly = true;
            gridView4.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.AllowEdit = false;

            gridView4.Columns["EXAM_UID"].Caption = "Exam Code";
            gridView4.Columns["EXAM_UID"].Visible = true;
            gridView4.Columns["EXAM_UID"].BestFit();
            gridView4.Columns["EXAM_UID"].ColVIndex = 12;
            gridView4.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;

            gridView4.Columns["ORDER_ID"].Caption = "Order No";
            gridView4.Columns["ORDER_ID"].Visible = true;
            gridView4.Columns["ORDER_ID"].BestFit();
            gridView4.Columns["ORDER_ID"].ColVIndex = 13;
            gridView4.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;
            #endregion

            #region Set font style.
            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView4.Columns["Status"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView4.Columns["Status"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView4.Columns["Status"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView4.Columns["Status"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView4.Columns["Status"], null, "Finalized");
            stylCon5.Appearance.ForeColor = Color.Green;

            ////Prelim(T)
            //DevExpress.XtraGrid.StyleFormatCondition stylCon6
            //    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Prelim(T)");
            //stylCon6.Appearance.ForeColor = Color.Goldenrod;

            ////Draft(T)
            //DevExpress.XtraGrid.StyleFormatCondition stylCon7
            //    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Draft(T)");
            //stylCon7.Appearance.ForeColor = Color.Goldenrod;

            ////Finalize(T)
            //DevExpress.XtraGrid.StyleFormatCondition stylCon8
            //    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Finalized(T)");
            //stylCon8.Appearance.ForeColor = Color.Green;

            ////Locked
            //DevExpress.XtraGrid.StyleFormatCondition stylCon9
            //    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Locked");
            //stylCon9.Appearance.ForeColor = Color.Blue;

            gridView4.FormatConditions.Clear();
            gridView4.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });//, stylCon6, stylCon7, stylCon8, stylCon9 });

            #endregion
        }
        private void ReloadDemographic()
        {
            if (gridView2.FocusedRowHandle < 0) return;

            ribbonPage1.Text = "Demographic";
            xtraTabControl1.SelectedTabPage = pageDemographic;
            layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //modalityID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["MODALITY_ID"]);
            ribbonControl1.SelectedPage = ribPageDemographic;

            LoadDataDemographic();
            LoadFilterDemographic();
            LoadGridDemographic();

            ribbonPage_DataShowing();
            ribbonBtn_visibility();
        }

        #region Demographic Page
        private void chk_Click(object sender, EventArgs e)
        {
            if (gridView4.FocusedRowHandle > -1)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (gridView4.FocusedRowHandle > 0)
                {
                    DataRow drChk = gridView4.GetDataRow(gridView4.FocusedRowHandle);
                    if (chk.Checked == false)
                        drChk["CHK"] = "Y";
                    else
                        drChk["CHK"] = "N";

                    drChk.AcceptChanges();
                }
            }
        }
        private void linkOrder_Click(object sender, EventArgs e)
        {
            if (gridView4.FocusedRowHandle > -1)
            {
                DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
                //frmPatientData ordimg = new frmPatientData(dr["ACCESSION_NO"].ToString());
                //ordimg.Text = "Order Summary";
                //ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                //ordimg.StartPosition = FormStartPosition.CenterScreen;
                //ordimg.MaximizeBox = false;
                //ordimg.MinimizeBox = false;
                //ordimg.ShowDialog();
                this._orderSummary.ShowDialog(true, dr["ACCESSION_NO"].ToString());
            }
        }
        private void link_Click(object sender, EventArgs e)
        {
            if (gridView4.FocusedRowHandle > -1)
            {
                DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
                System.Diagnostics.Process.Start(env.PacsUrl + dr["ACCESSION_NO"].ToString().Trim());
            }
        }

        private void btnGotoCapture_Click(object sender, EventArgs e)
        {
            ReloadCapture();
        }

        private void btnTechWorklist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadWorkload();
        }
        private void btnTechDemographic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ribbonControl1.SelectedPage = ribPageDemographic;
        }

        private void btnTechNurse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //NurseForm frm = new NurseForm(this.CloseControl);
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr == null || dr.ItemArray.Length < 1) return;

            string HN = dr["HN"].ToString().Trim();
            string acc = dr["ACCESSION_NO"].ToString().Trim();
            ProcessGetHISRegistration getData = new ProcessGetHISRegistration(HN);
            getData.Invoke();
            if (getData.Result.Tables[0].Rows.Count < 1) return;

            DataRow row = getData.Result.Tables[0].Rows[0];
            string Name = row["FNAME"].ToString().Trim() + " " + row["LNAME"].ToString().Trim();
            string ID = row["REG_ID"].ToString().Trim();
            NurseForm frm = new NurseForm();
            //NurseForm frm = new NurseForm(this.CloseControl);
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        private void btnTechOperator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //OperatorNote frm = new OperatorNote(this.CloseControl);
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (row == null || row.ItemArray.Length < 1) return;

            string HN = row["HN"].ToString().Trim();
            string EXAM_ID = row["EXAM_ID"].ToString().Trim();

            OperatorNote frm = new OperatorNote();
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnTechPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnReprint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        private void LoadCaptureChangeExamData()
        {
            getExamData_ce();
            getTechWork_ce();
            getConsumable_ce();
        }
        private void LoadCaptureChangeExamFilter()
        {
            DataView dv = dvConsumable_ce;
            dv.RowFilter = " IS_DELETED <>'Y' ";
        }
        private void LoadCaptureChangeExamGrid()
        {
            gridControl5.DataSource = dvConsumable_ce;

            int k = 0;
            while (k < gridView5.Columns.Count)
            {
                gridView5.Columns[k].Visible = false;
                gridView5.Columns[k].OptionsColumn.AllowEdit = false;
                ++k;
            }

            gridView5.OptionsView.ShowBands = false;
            gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView5.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView5.OptionsView.ShowColumnHeaders = true;
            gridView5.OptionsView.ShowGroupPanel = false;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
            repositoryItemLookUpEdit1.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.DataSource = dttExam;
            repositoryItemLookUpEdit1.NullText = string.Empty;
            //repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examID_KeyUp);
            //repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examID_CloseUp);
            gridView5.Columns["EXAM_ID"].ColumnEdit = repositoryItemLookUpEdit1;
            gridView5.Columns["EXAM_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            gridView5.Columns["EXAM_ID"].Visible = true;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit2.ImmediatePopup = true;
            repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit2.AutoHeight = false;
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.ValueMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.DataSource = dttExam;
            repositoryItemLookUpEdit2.NullText = string.Empty;
            //repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
            //repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
            //gridView5.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            gridView5.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            gridView5.Columns["EXAM_NAME"].Visible = true;

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            //btn.Click += new EventHandler(btnDeleteRow_Click);
            gridView5.Columns["colDelete"].Caption = string.Empty;
            gridView5.Columns["colDelete"].ColumnEdit = btn;
            gridView5.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gridView5.Columns["colDelete"].Width = 50;
            gridView5.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemSpinEdit spin = new RepositoryItemSpinEdit();
            //spin.KeyUp += new KeyEventHandler(qty_KeyUp);
            //spin.ValueChanged += new EventHandler(qty_ValueChanged);
            spin.MinValue = 0.1M;
            spin.MaxValue = 999.99M;
            gridView5.Columns["QTY"].ColumnEdit = spin;

            gridView5.Columns["QTY"].Visible = true;
            gridView5.Columns["RATE"].Visible = true;
            gridView5.Columns["Total"].Visible = true;
            //gridView5.Columns["colDelete"].Visible = true;

            gridView5.Columns["EXAM_ID"].Caption = "Consumable Code";
            gridView5.Columns["EXAM_NAME"].Caption = "Consumable Name";
            gridView5.Columns["QTY"].Caption = "Qty";
            gridView5.Columns["RATE"].Caption = "Rate";
            gridView5.Columns["RATE"].OptionsColumn.ReadOnly = true;
            gridView5.Columns["RATE"].DisplayFormat.FormatString = "#,##0.00";
            gridView5.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gridView5.Columns["Total"].Caption = "Total";
            //gridView5.Columns["Total"].OptionsColumn.ReadOnly = true;
            //gridView5.Columns["Total"].DisplayFormat.FormatString = "#,##0.00";
            //gridView5.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView5.Columns["colDelete"].Caption = string.Empty;
            gridView5.BestFitColumns();

            TotalRate_Calculating_ce();
        }
        private void ReloadCaptureChangeExam()
        {
            if (gridView2.FocusedRowHandle < 0) return;

            ribbonPage1.Text = "Capture";
            xtraTabControl1.SelectedTabPage = pageCaptureChangeExam;
            ribbonControl1.SelectedPage = ribPageTechnologist;
            layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            take = Convert.ToInt32(dr["TAKE"]);
            accessionNo = dr["ACCESSION_NO"].ToString();
            orderID = Convert.ToInt32(dr["order_id"]);
            status = Convert.ToInt32(dr["colStatus"]);

            #region set combobox index
            if (cboStatus_ce.Items.Count == 0)
            {
                cboStatus_ce.Items.Clear();
                cboStatus_ce.ValueMember = "ID";
                cboStatus_ce.DisplayMember = "Name";
                cboStatus_ce.DataSource = dttCon;
            }

            if (status == 1)
                cboStatus_ce.SelectedIndex = 1;
            else if (status == 2)
                cboStatus_ce.SelectedIndex = 2;
            else
                cboStatus_ce.SelectedIndex = 0;
            #endregion

            #region clear textbox
            txtKV_ce.Text = "";
            txtmA_ce.Text = "";
            txtSec_ce.Text = "";
            txtExposure_ce.Text = "";
            txtNoOfImage_ce.Text = "";
            txtProtocol_ce.Text = "";
            #endregion

            LoadCaptureChangeExamData();
            LoadCaptureChangeExamFilter();
            LoadCaptureChangeExamGrid();

            ribbonPage_DataShowing();
            ribbonBtn_visibility();

            string unit_id = dr["UNIT_ID"].ToString().Trim();
            if (unit_id == "7" || unit_id == "2")
                btnChangeExam_LayoutItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                btnChangeExam_LayoutItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        #region Capture Change Exam
        private void getExamData_ce()
        {
            try
            {
                LookUpSelect lk = new LookUpSelect();
                dttExam = lk.SelectExamConsumable().Tables[0];
                dttExam.TableName = "RIS_EXAM";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getTechWork_ce()
        {
            try
            {
                int tmpTake = take > 1 ? take - 1 : take;
                ProcessGetRISTechworks process = new ProcessGetRISTechworks();
                process.RIS_TECHWORK.ACCESSION_ON = accessionNo;
                process.RIS_TECHWORK.TAKE = (byte)tmpTake;
                process.Invoke();
                if (process.Result != null && process.Result.Tables.Count > 0 && process.Result.Tables[0].Rows.Count > 0)
                {
                    txtKV_ce.Text = process.Result.Tables[0].Rows[0]["KV"].ToString();
                    txtmA_ce.Text = process.Result.Tables[0].Rows[0]["mA"].ToString();
                    txtSec_ce.Text = process.Result.Tables[0].Rows[0]["SEC"].ToString();
                    txtExposure_ce.Text = process.Result.Tables[0].Rows[0]["EXPOSURE_TECHNIQUE"].ToString();
                    txtNoOfImage_ce.Text = process.Result.Tables[0].Rows[0]["NO_OF_IMAGES"].ToString().Trim() == string.Empty ? "0" : process.Result.Tables[0].Rows[0]["NO_OF_IMAGES"].ToString();
                    txtProtocol_ce.Text = process.Result.Tables[0].Rows[0]["PROTOCOL"].ToString();
                    mode = "Edit";
                }
                else
                {
                    mode = "New";
                }

                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HR_EMP.MODE = "EmpId";
                bg.HR_EMP.EMP_ID = cabUserBy;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = 0;
                bg.Invoke();

                DataRow dr = bg.Result.Tables[0].Rows[0];
                txtPerformName_ce.Text = dr["FullName"].ToString();
                txtTake_ce.Text = tmpTake.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getConsumable_ce()
        {
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            int ORDER_ID = Convert.ToInt32(row["ORDER_ID"]);
            Order thisOrder = new Order(ORDER_ID);
            DataTable dtt = new DataTable();

            dtt = thisOrder.ItemDetail.Copy();
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["SERVICE_TYPE"].ToString() != "3")
                {
                    if (dr["SERVICE_TYPE"].ToString().Trim() != "")
                    {
                        dr.Delete();
                    }
                }
            }
            dtt.AcceptChanges();
            dtt.Columns.Add("Total", typeof(decimal));
            List<int> indexs = new List<int>();
            int k = 0;
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["EXAM_ID"] != null && dr["EXAM_ID"].ToString().Trim() != "")
                {
                    string query = "EXAM_ID=" + dr["EXAM_ID"].ToString().Trim();
                    DataRow[] drs = dttExam.Select(query);
                    if (drs.Length > 0)
                    {
                        dr["EXAM_NAME"] = drs[0]["EXAM_NAME"].ToString();
                        decimal qty = dr["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["QTY"]);
                        decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
                        dr["Total"] = qty * rate;
                    }
                }
                else
                {
                    indexs.Add(k);
                }
                k++;
            }

            foreach (int index in indexs)
                dtt.Rows.RemoveAt(index);

            DataRow newRow = dtt.NewRow();
            newRow["QTY"] = 1;
            newRow["IS_DELETED"] = "N";
            dtt.Rows.Add(newRow);

            dtConsumable_ce = dtt;
            dvConsumable_ce = new DataView(dtt);
        }

        private void btnComplete_ce_Click(object sender, EventArgs e)
        {
            dttEnd = DateTime.Now;
            if (mode == "New")
            {
                string s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                if (s == "2")
                {
                    try
                    {
                        ProcessAddRISTechworks process = new ProcessAddRISTechworks();
                        process.RIS_TECHWORK.ACCESSION_ON = accessionNo;
                        process.RIS_TECHWORK.TAKE = (byte)take;
                        process.RIS_TECHWORK.START_TIME = dttStart;
                        process.RIS_TECHWORK.END_TIME = dttEnd;
                        process.RIS_TECHWORK.EXPOSURE_TECHNIQUE = txtExposure_ce.Text.Trim();
                        process.RIS_TECHWORK.PROTOCOL = txtProtocol_ce.Text.Trim();
                        process.RIS_TECHWORK.KV = txtKV_ce.Text.Trim();
                        process.RIS_TECHWORK.mA = txtmA_ce.Text.Trim();
                        process.RIS_TECHWORK.SEC = txtSec_ce.Text.Trim();

                        string status = cboStatus_ce.SelectedValue.ToString();
                        if (status == "0")
                            process.RIS_TECHWORK.STATUS = 'A';
                        else if (status == "1")
                            process.RIS_TECHWORK.STATUS = 'S';
                        else if (status == "2")
                            process.RIS_TECHWORK.STATUS = 'C';
                        else
                            process.RIS_TECHWORK.STATUS = 'X';

                        if (process.RIS_TECHWORK.STATUS == 'X')
                        {
                            Reason frm = new Reason();
                            frm.ShowDialog();
                            process.RIS_TECHWORK.COMMENTS = frm.Comment;
                        }
                        process.RIS_TECHWORK.NO_OF_IMAGES = Convert.ToInt32(txtNoOfImage_ce.Text);
                        process.RIS_TECHWORK.ORG_ID = env.OrgID;
                        process.RIS_TECHWORK.CREATED_BY = env.UserID;
                        //process.RISTechworks.PERFORMANCED_BY = Convert.ToInt32(tech.dtTech.Rows[0]["EMP_ID"]);
                        //process.RISTechworks.PERFORMANCED_BY = Convert.ToInt32(env.UserID);
                        process.RIS_TECHWORK.PERFORMANCED_BY = cabUserBy;
                        process.Invoke();

                        //add consumption
                        ProcessAddRISTechconsumption processCon = new ProcessAddRISTechconsumption();
                        processCon.RIS_TECHCONSUMPTION.ACCESSION_NO = accessionNo;
                        processCon.RIS_TECHCONSUMPTION.TAKE = (byte)take;
                        processCon.RIS_TECHCONSUMPTION.CREATED_BY = cabUserBy;

                        dvConsumable_ce = (DataView)gridControl5.DataSource;
                        DataTable dtt = dvConsumable_ce.Table;
                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["EXAM_ID"].ToString().Trim() != string.Empty)
                            {
                                processCon.RIS_TECHCONSUMPTION.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                                processCon.RIS_TECHCONSUMPTION.IS_DELETED = 'N';
                                processCon.RIS_TECHCONSUMPTION.QTY = Convert.ToDecimal(dr["QTY"]);
                                processCon.RIS_TECHCONSUMPTION.RATE = Convert.ToDecimal(dr["RATE"]);
                                processCon.Invoke();
                            }
                        }
                        //update status order;
                        //ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                        //processUpdate.RISOrderdtl.ACCESSION_NO = accessionNo;
                        //processUpdate.RISOrderdtl.STATUS = process.RISTechworks.STATUS;
                        //processUpdate.RISOrderdtl.CREATED_BY = cabUserBy;
                        //processUpdate.UpdateStatus();

                        //insert ris_techwork detail
                        if (process.RIS_TECHWORK.STATUS == 'S')
                        {
                            foreach (DataRow dr in dtMemList.Rows)
                            {
                                ProcessAddRISTechworksdtl pad = new ProcessAddRISTechworksdtl();
                                pad.RIS_TECHWORKSDTL.ACCESSION_NO = accessionNo;
                                pad.RIS_TECHWORKSDTL.TECHNOLOGIST_ID = Convert.ToInt32(dr["id"]);
                                pad.RIS_TECHWORKSDTL.CREATED_BY = env.UserID;
                                pad.RIS_TECHWORKSDTL.RAD_SLNO = Convert.ToInt32(dr["slno"]);
                                try
                                {
                                    pad.Invoke();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }

                        ReloadWorkload();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        return;
                    }
                }
            }
            else
            {
                string s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                if (s == "2")
                {
                    try
                    {
                        ProcessAddRISTechworks process = new ProcessAddRISTechworks();
                        process.RIS_TECHWORK.ACCESSION_ON = accessionNo;
                        process.RIS_TECHWORK.TAKE = (byte)take;
                        process.RIS_TECHWORK.START_TIME = dttStart;
                        process.RIS_TECHWORK.END_TIME = dttEnd;
                        process.RIS_TECHWORK.EXPOSURE_TECHNIQUE = txtExposure_ce.Text.Trim();
                        process.RIS_TECHWORK.PROTOCOL = txtProtocol_ce.Text.Trim();
                        process.RIS_TECHWORK.KV = txtKV_ce.Text.Trim();
                        process.RIS_TECHWORK.mA = txtmA_ce.Text.Trim();
                        process.RIS_TECHWORK.SEC = txtSec_ce.Text.Trim();
                        string status = cboStatus_ce.SelectedValue.ToString();
                        if (status == "0")
                            process.RIS_TECHWORK.STATUS = 'A';
                        else if (status == "1")
                            process.RIS_TECHWORK.STATUS = 'C';
                        else if (status == "2")
                            process.RIS_TECHWORK.STATUS = 'C';
                        else
                            process.RIS_TECHWORK.STATUS = 'X';
                        if (process.RIS_TECHWORK.STATUS == 'X')
                        {
                            Reason frm = new Reason();
                            frm.ShowDialog();
                            process.RIS_TECHWORK.COMMENTS = frm.Comment;
                        }
                        process.RIS_TECHWORK.NO_OF_IMAGES = Convert.ToInt32(txtNoOfImage_ce.Text);
                        process.RIS_TECHWORK.ORG_ID = env.OrgID;
                        process.RIS_TECHWORK.CREATED_BY = env.UserID;
                        //process.RISTechworks.PERFORMANCED_BY = Convert.ToInt32(tech.dtTech.Rows[0]["EMP_ID"]);
                        //process.RISTechworks.PERFORMANCED_BY = Convert.ToInt32(env.UserID);
                        process.RIS_TECHWORK.PERFORMANCED_BY = cabUserBy;
                        process.Invoke();

                        //Consumption
                        //delete consumption
                        ProcessDeleteRISTechconsumption processDel = new ProcessDeleteRISTechconsumption();
                        processDel.RIS_TECHCONSUMPTION.ACCESSION_NO = accessionNo;
                        processDel.RIS_TECHCONSUMPTION.TAKE = (byte)take;
                        processDel.Invoke();

                        //add consumption
                        ProcessAddRISTechconsumption processCon = new ProcessAddRISTechconsumption();
                        processCon.RIS_TECHCONSUMPTION.ACCESSION_NO = accessionNo;
                        processCon.RIS_TECHCONSUMPTION.TAKE = (byte)take;
                        processCon.RIS_TECHCONSUMPTION.CREATED_BY = env.UserID;
                        dvConsumable_ce = (DataView)gridControl5.DataSource;
                        DataTable dtt = dvConsumable_ce.Table;
                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["EXAM_ID"].ToString().Trim() != string.Empty)
                            {
                                processCon.RIS_TECHCONSUMPTION.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                                processCon.RIS_TECHCONSUMPTION.IS_DELETED = 'N';
                                processCon.RIS_TECHCONSUMPTION.QTY = Convert.ToDecimal(dr["QTY"]);
                                processCon.RIS_TECHCONSUMPTION.RATE = Convert.ToDecimal(dr["RATE"]);
                                processCon.Invoke();
                            }
                        }

                        //update status order;
                        //ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                        //processUpdate.RISOrderdtl.ACCESSION_NO = accessionNo;
                        //processUpdate.RISOrderdtl.STATUS = process.RISTechworks.STATUS;
                        //processUpdate.RISOrderdtl.CREATED_BY = env.UserID;
                        //processUpdate.UpdateStatus();

                        ReloadWorkload();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        return;
                    }
                }
            }
        }
        private void btnWorkList_ce_Click(object sender, EventArgs e)
        {
            ReloadWorkload();
        }
        private void TotalRate_Calculating_ce()
        {
            int k = 0;
            decimal sumtol = 0;
            while (k < gridView5.RowCount)
            {
                DataRow row = gridView5.GetDataRow(k);
                if (!string.IsNullOrEmpty(row["Total"].ToString()))
                    sumtol += Convert.ToDecimal(row["Total"]);
                ++k;
            }
            txtTotalRate_ce.Text = "Total : " + sumtol.ToString();
        }
        private void btnConsumable_ce_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            int ORDER_ID = Convert.ToInt32(dr["ORDER_ID"]);
            frmConsumable frm = new frmConsumable(ORDER_ID);//_order_id);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ControlBox = false;
            //frm.ShowDialog();
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders(order_id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                getConsumable_ce();
                LoadCaptureChangeExamFilter();
                LoadCaptureChangeExamGrid();
                //ReloadCapture();
            }
        }

        private void btnChangeExam_Click(object sender, EventArgs e)
        {
            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnChangeExam_Clicks);
            lv.AddColumn("EXAM_ID", "EXAM_ID", false, true);
            lv.AddColumn("EXAM_UID", "Code", true, true);
            lv.AddColumn("EXAM_NAME", "Name", true, true);
            lv.AddColumn("RATE", "Rate", true, true);
            lv.Text = "Exam List";

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            string unit_id = dr["UNIT_ID"].ToString().Trim();
            if (unit_id == "7")
            {
                ProcessGetRISExam getData = new ProcessGetRISExam();
                DataTable interv_table = getData.GetExamInvervent();

                lv.Data = interv_table;
                lv.Size = new Size(500, 500);
                lv.StartPosition = FormStartPosition.CenterScreen;
                lv.ShowBox();
            }
            else if (unit_id == "2")
            {
                ProcessGetRISExam getData = new ProcessGetRISExam();
                DataTable interv_table = getData.GetExamAIMC();

                lv.Data = interv_table;
                lv.Size = new Size(500, 500);
                lv.StartPosition = FormStartPosition.CenterScreen;
                lv.ShowBox();
            }
        }
        private void btnChangeExam_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] values = e.NewValue.Split(new Char[] { '^' });
            int EXAM_ID = Convert.ToInt32(values[0]);
            string EXAM_UID = values[1];
            string EXAM_NAME = values[3];
            decimal RATE = Convert.ToDecimal(values[6]);

            MyMessageBox msg = new MyMessageBox();
            string choose = msg.ShowAlert("UID4002", new GBLEnvVariable().CurrentLanguageID);
            if (choose == "1") return;

            int row_index = gridView2.FocusedRowHandle;
            if (row_index < 0) return;

            DataRow row = gridView2.GetDataRow(row_index);
            string ACCESSION_NO = row["ACCESSION_NO"].ToString();
            int ORDER_ID = Convert.ToInt32(row["ORDER_ID"]);

            //ProcessUpdateRISOrderdtl updateData = new ProcessUpdateRISOrderdtl();
            //updateData.UpdateChangeExam(ACCESSION_NO, EXAM_ID);

            //ReloadCapture();
            //ReloadDemographic();
            //onCapture = true;
            //ribbonPage_DataShowing();

            //ribbonControl1.SelectedPage = ribPageTechnologist;

            OrderManager orderManager = new OrderManager();
            Order orderItem = new Order(ORDER_ID);
            DataRow[] rows = orderItem.ItemDetail.Select("[ACCESSION_NO]='" + ACCESSION_NO + "'");
            DataTable table_temp = orderItem.ItemDetail.Clone();
            if (rows.Length == 0) return;

            rows[0]["EXAM_ID"] = EXAM_ID;
            rows[0]["EXAM_UID"] = EXAM_UID;
            rows[0]["EXAM_NAME"] = EXAM_NAME;
            rows[0]["RATE"] = RATE;
            rows[0]["QTY"] = 1;
            table_temp.Rows.Add(rows[0].ItemArray);
            orderItem.ItemDetail = table_temp.Copy();
            orderManager.Add(orderItem);
            bool flag = orderManager[0].Invoke();
            if (flag)
            {
                getConsumable_ce();
                LoadCaptureChangeExamFilter();
                LoadCaptureChangeExamGrid();

                txtDemo_ExamName.Text = EXAM_UID;
                txtDemo_ExamCode.Text = EXAM_NAME;
                lblExam_ce.Text = txtDemo_ExamName.Text + " (" + txtDemo_ExamCode.Text + ")";
            }
            else
            {
                msg = new MyMessageBox();
                GBLEnvVariable env = new GBLEnvVariable();
                msg.ShowAlert("UID1024", env.CurrentLanguageID);
            }
        }
        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtBarCode.Text.Trim().Length == 0) return;

                DataRow focus_row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                int ORDER_ID = Convert.ToInt32(focus_row["ORDER_ID"]);
                string EXAM_BARCODE = txtBarCode.Text;
                //if (EXAM_BARCODE.Trim().Length < 0) return;

                ProcessGetRISExam getData = new ProcessGetRISExam();
                DataTable exam_table = getData.GetExam_byBarcode(EXAM_BARCODE);
                if (exam_table.Rows.Count == 0)
                {
                    frmTechnologist_BarcodeChange showForm
                        = new frmTechnologist_BarcodeChange(EXAM_BARCODE, ORDER_ID);
                    DialogResult dialod_result = showForm.ShowDialog();
                    if (dialod_result == DialogResult.OK)
                    {
                        getConsumable_ce();
                        LoadCaptureChangeExamFilter();
                        LoadCaptureChangeExamGrid();
                        txtBarCode.Text = "";
                    }
                }
                else
                {
                    OrderManager orderManager = new OrderManager();
                    Order orderItem = new Order(ORDER_ID);
                    DataRow exam_row = exam_table.Rows[0];

                    DataRow[] row_check_duplicate
                        = orderItem.ItemDetail.Select("[EXAM_ID]=" + exam_row["EXAM_ID"].ToString());
                    if (row_check_duplicate.Length != 0) return;

                    DataTable orderTable = orderItem.ItemDetail.Copy();
                    DataTable table_temp = orderItem.ItemDetail.Clone();
                    DataRow orderRow0 = orderTable.Rows[0];

                    DataRow row = orderTable.NewRow();
                    row["ORDER_ID"] = DBNull.Value;

                    row["EST_START_TIME"] = orderRow0["EST_START_TIME"];
                    row["QTY"] = 1;

                    row["ASSIGNED_TO"] = orderRow0["ASSIGNED_TO"];
                    row["MODALITY_ID"] = orderRow0["MODALITY_ID"];
                    row["PRIORITY"] = orderRow0["PRIORITY"];

                    row["EXAM_ID"] = exam_row["EXAM_ID"];
                    row["RATE"] = exam_row["RATE"];
                    row["CLINIC_TYPE"] = orderRow0["CLINIC_TYPE"];
                    row["BPVIEW_ID"] = orderRow0["BPVIEW_ID"];

                    row["EXAM_UID"] = exam_row["EXAM_UID"];
                    row["EXAM_NAME"] = exam_row["EXAM_NAME"];

                    table_temp.Rows.Add(row.ItemArray);
                    orderItem.ItemDetail = table_temp.Copy();

                    orderManager.Add(orderItem);
                    bool flag = orderManager[0].Invoke();
                    if (flag)
                    {
                        getConsumable_ce();
                        LoadCaptureChangeExamFilter();
                        LoadCaptureChangeExamGrid();
                    }
                    else
                    {
                        MyMessageBox msg = new MyMessageBox();
                        GBLEnvVariable env = new GBLEnvVariable();
                        msg.ShowAlert("UID1024", env.CurrentLanguageID);
                    }
                }
            }
        }
        #endregion

        private void ribbonPage_DataShowing()
        {
            if (xtraTabControl1.SelectedTabPage == pageLogIn)
            {

            }
            else if (xtraTabControl1.SelectedTabPage == pageModality)
            {
                #region first page
                //ribPageTech.Visible = true;
                //ribPageMod.Visible = false;
                //ribPageCap.Visible = false;

                //txtTechName.EditValue = tech.dtTech.Rows[0]["fullname"];
                //txtTechUnit.EditValue = loadUnitName(tech.dtTech.Rows[0]["unit_id"]);
                //txtTechCapture.EditValue = loadLastCapture(tech.dtTech.Rows[0]["emp_id"]);
                #endregion
            }
            else if (xtraTabControl1.SelectedTabPage == pageWorkload)
            {
                #region first page
                //ribPageTech.Visible = true;
                //ribPageMod.Visible = true;
                //ribPageCap.Visible = false;

                //DataRow[] drs = tech.dtModality.Select("modality_id=" + modalityID);
                //txtModName.EditValue = "(" + drs[0]["modality_uid"].ToString() + ")" + drs[0]["modality_name"].ToString();
                //txtModRoom.EditValue = drs[0]["room_uid"].ToString();
                //txtModUnit.EditValue = "(" + drs[0]["unit_uid"].ToString() + ")" + drs[0]["unit_name"].ToString();
                #endregion

                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HR_EMP.MODE = "EmpId";
                bg.HR_EMP.EMP_ID = cabUserBy;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = 0;
                bg.Invoke();

                DataRow dr = bg.Result.Tables[0].Rows[0];
                txtDash_TechName.EditValue = dr["FullName"];
                Envision.BusinessLogic.ResultEntry result = new Envision.BusinessLogic.ResultEntry();
                result.RISExamresult.EMP_ID = cabUserBy;
                DataSet ds = result.GetCaseAmount();
                txtDash_Assg.EditValue = "Today : " + ds.Tables[1].Rows[0][0].ToString() + " | All : " + ds.Tables[0].Rows[0][0].ToString();

                //txtDash_TechName.EditValue = env.FirstName + " " + env.LastName;
                //RIS.BusinessLogic.ResultEntry result = new RIS.BusinessLogic.ResultEntry();
                //result.RISExamresult.EMP_ID = env.UserID;
                //DataSet ds = result.GetCaseAmount();
                //txtDash_Assg.EditValue = "Today : " + ds.Tables[1].Rows[0][0].ToString() + " | All : " + ds.Tables[0].Rows[0][0].ToString();

                ProcessGetHRUnit process = new ProcessGetHRUnit();
                process.Invoke();
                DataTable dtt = process.Result.Tables[0];
                DataRow[] drs = dtt.Select("UNIT_ID=" + dr["UNIT_ID"]);
                if (drs.Length > 0)
                {
                    txtDash_Dept.EditValue = drs[0]["UNIT_NAME"].ToString();
                }
            }
            else if (xtraTabControl1.SelectedTabPage == pageCapture)
            {
                #region first page
                //ribPageTech.Visible = true;
                //ribPageMod.Visible = true;
                //ribPageCap.Visible = true;

                //DataRow[] drs = tech.dtModality.Select("modality_id=" + modalityID);
                //txtModName.EditValue = "(" + drs[0]["modality_uid"].ToString() + ")" + drs[0]["modality_name"].ToString();
                //txtModRoom.EditValue = drs[0]["room_uid"].ToString();
                //txtModUnit.EditValue = "(" + drs[0]["unit_uid"].ToString() + ")" + drs[0]["unit_name"].ToString();

                //drs = null;
                //drs = dtWorkLoad.Select("order_id=" + orderID.ToString());
                //txtCapHN.EditValue = drs[0]["HN"].ToString();
                //txtCapPatienName.EditValue = drs[0]["PatientName"].ToString();
                //txtCapExamName.EditValue = "(" + drs[0]["exam_uid"].ToString() + ")" + drs[0]["exam_name"].ToString();
                #endregion
            }
            else if (xtraTabControl1.SelectedTabPage == pageDemographic)
            {
                #region Demographic.
                string name = string.Empty;
                txtDemo_HN.EditValue = dtDemographic.Rows[0]["HN"].ToString();
                txtDemo_AN.EditValue = dtDemographic.Rows[0]["AN"].ToString();
                txtDemo_ID.EditValue = dtDemographic.Rows[0]["SSN"].ToString();
                name = dtDemographic.Rows[0]["FNAME"].ToString() + " ";
                name += dtDemographic.Rows[0]["MNAME"].ToString() + " ";
                name += dtDemographic.Rows[0]["LNAME"].ToString();
                txtDemo_ThName.EditValue = name;
                if (string.IsNullOrEmpty(dtDemographic.Rows[0]["FNAME_ENG"].ToString()))
                {
                    name = TransToEnglish.Trans(dtDemographic.Rows[0]["FNAME_ENG"].ToString()) + " ";
                    name += TransToEnglish.Trans(dtDemographic.Rows[0]["MNAME_ENG"].ToString()) + " ";
                    name += TransToEnglish.Trans(dtDemographic.Rows[0]["LNAME_ENG"].ToString());
                }
                else
                {
                    name = dtDemographic.Rows[0]["FNAME_ENG"].ToString() + " ";
                    name += dtDemographic.Rows[0]["MNAME_ENG"].ToString() + " ";
                    name += dtDemographic.Rows[0]["LNAME_ENG"].ToString();
                }
                txtDemo_EngName.EditValue = name;
                txtDemo_Addr.EditValue = dtDemographic.Rows[0]["ADDR"].ToString();
                txtDemo_Gender.EditValue = dtDemographic.Rows[0]["GENDER"].ToString();
                txtDemo_DOB.EditValue = dtDemographic.Rows[0]["DOB"].ToString();
                txtDemo_Age.EditValue = dtDemographic.Rows[0]["AGE"].ToString();
                txtDemo_Dept.EditValue = dtDemographic.Rows[0]["UNIT_NAME"].ToString();
                txtDemo_Doctor.EditValue = dtDemographic.Rows[0]["EMP_NAME"].ToString();
                txtDemo_Phone.EditValue = dtDemographic.Rows[0]["UNIT_TEL"].ToString();
                #endregion

                #region Select Case.
                name = dtSelectCase.Rows[0]["STATUS"].ToString();
                switch (name)
                {
                    case "A": name = "New"; break;
                    case "D": name = "Draft"; break;
                    case "P": name = "Prelim"; break;
                    case "F": name = "Finalized"; break;
                    case "C": name = "Complete"; break;
                    case "G": name = "New"; break;
                }

                txtDemo_Status.Text = name;
                name = dtSelectCase.Rows[0]["PRIORITY"].ToString();
                switch (name)
                {
                    case "R": name = "Routine"; break;
                    case "S": name = "Stat"; break;
                    case "U": name = "Urgent"; break;
                }
                txtDemo_AccNo.Text = dtSelectCase.Rows[0]["ACCESSION_NO"].ToString();
                txtDemo_Priority.Text = name;
                txtDemo_ExamCode.Text = dtSelectCase.Rows[0]["EXAM_UID"].ToString();
                txtDemo_ExamName.Text = dtSelectCase.Rows[0]["EXAM_NAME"].ToString();

                #endregion

                #region Capture
                lblPatientName.Text = txtDemo_ThName.EditValue.ToString() + " (" + txtDemo_HN.EditValue.ToString() + ") ";
                lblExam.Text = txtDemo_ExamName.Text + " (" + txtDemo_ExamCode.Text + ")";
                lbOrderDoc.Text = txtDemo_Doctor.EditValue.ToString();

                lblAge.Text = txtDemo_Age.EditValue.ToString();
                lblGender.Text = txtDemo_Gender.EditValue.ToString();

                lbOrderDept.Text = txtDemo_Dept.EditValue.ToString();
                #endregion

                #region Capture Change Exam
                lblPatientName_ce.Text = txtDemo_ThName.EditValue.ToString() + " (" + txtDemo_HN.EditValue.ToString() + ") ";
                lblExam_ce.Text = txtDemo_ExamName.Text + " (" + txtDemo_ExamCode.Text + ")";
                lbOrderDoc_ce.Text = txtDemo_Doctor.EditValue.ToString();

                lblAge_ce.Text = txtDemo_Age.EditValue.ToString();
                lblGender_ce.Text = txtDemo_Gender.EditValue.ToString();

                lbOrderDept_ce.Text = txtDemo_Dept.EditValue.ToString();
                #endregion
            }
            else if (xtraTabControl1.SelectedTabPage == pageCaptureChangeExam)
            {

            }
        }
        private void ribbonBtn_visibility()
        {
            if (xtraTabControl1.SelectedTabPage == pageLogIn)
            {

            }
            else if (xtraTabControl1.SelectedTabPage == pageModality)
            {
                ribBtnLogIn.Visible = true;
                ribBtnMod.Visible = false;
                ribBtnWorkload.Visible = true;
                ribBtnCapture.Visible = false;
                ribBtnRefresh.Visible = true;
            }
            else if (xtraTabControl1.SelectedTabPage == pageWorkload)
            {
                ribBtnLogIn.Visible = true;
                ribBtnMod.Visible = true;
                ribBtnWorkload.Visible = false;
                ribBtnCapture.Visible = true;
                ribBtnRefresh.Visible = true;
            }
            else if (xtraTabControl1.SelectedTabPage == pageCapture)
            {
                ribBtnLogIn.Visible = false;
                ribBtnMod.Visible = false;
                ribBtnWorkload.Visible = true;
                ribBtnCapture.Visible = false;
                ribBtnRefresh.Visible = false;
            }
        }
        private string loadUnitName(object unitid)
        {
            string cns = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable dt = new DataTable("unit");

            using (SqlConnection connection = new SqlConnection(cns))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = @"select '(' + unit_uid + ')' + unit_name as unit_name from hr_unit where unit_id=" + unitid.ToString().Trim();
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);
            }
            return dt.Rows[0]["unit_name"].ToString();
        }
        private string loadLastCapture(object empid)
        {
            string cns = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable dt = new DataTable("lastcap");

            using (SqlConnection connection = new SqlConnection(cns))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = @"select max(end_time) as end_time from ris_techworks where performanced_by=" + empid.ToString().Trim();
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);
            }
            return dt.Rows[0]["end_time"].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[0]["end_time"]).ToString("g");
        }

        private void ribbonControl1_SelectedPageChanging(object sender, DevExpress.XtraBars.Ribbon.RibbonPageChangingEventArgs e)
        {
            grdRadioSetup.Visible = false;
            if (e.Page == ribPageWorkload && onCapture == false)
                xtraTabControl1.SelectedTabPage = pageWorkload;
            else if (e.Page == ribPageDemographic && onCapture == true)
                xtraTabControl1.SelectedTabPage = pageDemographic;
            //else if (e.Page == ribPageTechnologist && onCapture == true)
            //    xtraTabControl1.SelectedTabPage = pageCapture;
            else if (e.Page == ribPageTechnologist && onCapture == true)
                xtraTabControl1.SelectedTabPage = pageCaptureChangeExam;
            else if (e.Page == ribbonRads)
                grdRadioSetup.Visible = true;
        }
        private void btnRibItemWorklist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadWorkload();
        }
        private void btnRibItemDemographic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadDemographic();
        }
        private void btnRibItemCapture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadCapture();
        }

        private void LoadDataUserMembers()
        {
            #region

            #endregion
        }
        private void LoadFilterUserMembers()
        {
            #region

            #endregion
        }
        private void LoadGridUserMembers()
        {
            #region

            #endregion
        }
        private void ReloadUserMembers()
        {
            LoadDataUserMembers();
            LoadFilterUserMembers();
            LoadGridUserMembers();
        }

        #region User Members
        private void ribbonUserMembers_DataShowing()
        {
            if (nowMemRows < 0)
                nowMemRows = 0;

            if (nowMemRows > dtMemList.Rows.Count - 1)
                nowMemRows = dtMemList.Rows.Count - 1;

            try
            {
                bartxtName1.EditValue = dtMemList.Rows[nowMemRows]["FullName"].ToString();
                bartxtUnit1.EditValue = dtMemList.Rows[nowMemRows]["Unit"].ToString();
            }
            catch
            {
                bartxtName1.EditValue = "";
                bartxtUnit1.EditValue = "";
            }

            try
            {
                bartxtName2.EditValue = dtMemList.Rows[nowMemRows + 1]["FullName"].ToString();
                bartxtUnit2.EditValue = dtMemList.Rows[nowMemRows + 1]["Unit"].ToString();
            }
            catch
            {
                bartxtName2.EditValue = "";
                bartxtUnit2.EditValue = "";
            }

            try
            {
                bartxtName3.EditValue = dtMemList.Rows[nowMemRows + 2]["FullName"].ToString();
                bartxtUnit3.EditValue = dtMemList.Rows[nowMemRows + 2]["Unit"].ToString();
            }
            catch
            {
                bartxtName3.EditValue = "";
                bartxtUnit3.EditValue = "";
            }

            barlbID1.Caption = "#" + (nowMemRows + 1).ToString();
            barlbID2.Caption = "#" + (nowMemRows + 2).ToString();
            barlbID3.Caption = "#" + (nowMemRows + 3).ToString();
        }
        private void barBtnUp_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (nowMemRows == 0) return;
            nowMemRows--;
            ribbonUserMembers_DataShowing();
        }
        private void barBtnDown_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (nowMemRows == dtMemList.Rows.Count - 1) return;
            nowMemRows++;
            ribbonUserMembers_DataShowing();
        }

        private void barBtnAddUser_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PerformUsr per = new PerformUsr();
            per.StartPosition = FormStartPosition.CenterParent;
            if (DialogResult.OK == per.ShowDialog())
            {
                int emp_id = per.PerformBy;
                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HR_EMP.MODE = "EmpId";
                bg.HR_EMP.EMP_ID = emp_id;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = 0;
                bg.Invoke();

                addMemList(bg.Result.Tables[0],false);
            }
            else
                return;
        }
        private void barBtnAddRads_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_Physician);
            lv.AddColumn("EMP_ID", "Doctor ID", false, true);
            lv.AddColumn("EMP_UID", "Doctor Code", true, true);
            lv.AddColumn("RadioName", "Doctor Name", true, true);
            lv.Text = "Doctor Search";

            lv.Data = lvS.SelectOrderFrom("Physician").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Physician(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            ProcessGetHREmp bg = new ProcessGetHREmp();
            bg.HR_EMP.MODE = "EmpId";
            bg.HR_EMP.EMP_ID = Convert.ToInt32(retValue[0]);
            bg.HR_EMP.USER_NAME = "";
            bg.HR_EMP.UNIT_ID = 0;
            bg.HR_EMP.AUTH_LEVEL_ID = 0;
            bg.Invoke();

            DataTable dt = bg.Result.Tables[0];
            
            #region check duplicate user
            foreach (DataRow dr in dtRadList.Rows)
            {
                if (dr["id"] == retValue[0] || dr["id"].ToString().Trim() == retValue[0].Trim())
                {
                    msg.ShowAlert("UID2060", env.CurrentLanguageID);
                    return;
                }
            }
            #endregion
            int slno = dtRadList.Rows.Count;
            
            DataRow row = dtRadList.NewRow();
            row["id"] = retValue[0];
            row["fullname"] = dt.Rows[0]["FullName"] + "(" + dt.Rows[0]["JOB_TITLE_DESC"] + ")";
            row["unit"] = dt.Rows[0]["UNIT_NAME"];
            row["fullnameTemp"] = dt.Rows[0]["FullName"] + "(" + dt.Rows[0]["JOB_TITLE_DESC"] + ")";
            row["slno"] = slno+1;
            dtRadList.Rows.Add(row);
            setGridradioSetup();
        }

        private void barBtnDelete1_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtMemList.Rows.Count == 1) return;
            try
            {
                refreshRadSlno(nowMemRows);
                dtMemList.Rows.RemoveAt(nowMemRows);
                ribbonUserMembers_DataShowing();
            }
            catch { }
        }
        private void barBtnDelete2_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtMemList.Rows.Count == 1) return;
            try
            {
                refreshRadSlno(nowMemRows + 1);
                dtMemList.Rows.RemoveAt(nowMemRows + 1);
                ribbonUserMembers_DataShowing();
            }
            catch { }
        }
        private void barBtnDelete3_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtMemList.Rows.Count == 1) return;
            try
            {
                refreshRadSlno(nowMemRows + 2);
                dtMemList.Rows.RemoveAt(nowMemRows + 2);
                ribbonUserMembers_DataShowing();
            }
            catch { }
        }
        private void addMemList(DataTable dt,bool isRad)
        {
            #region check duplicate user
            foreach (DataRow dr in dtMemList.Rows)
            {
                if (dr["id"] == dt.Rows[0]["EMP_ID"] || dr["id"].ToString().Trim() == dt.Rows[0]["EMP_ID"].ToString().Trim())
                {
                    msg.ShowAlert("UID2060", env.CurrentLanguageID);
                    return;
                }
            }
            #endregion
            string _slno = "";
            int slno = 0;

            DataRow row = dtMemList.NewRow();
            row["id"] = dt.Rows[0]["EMP_ID"];
            row["fullname"] = _slno + dt.Rows[0]["FullName"] + "(" + dt.Rows[0]["JOB_TITLE_DESC"] + ")";
            row["unit"] = dt.Rows[0]["UNIT_NAME"];
            row["fullnameTemp"] = dt.Rows[0]["FullName"] + "(" + dt.Rows[0]["JOB_TITLE_DESC"] + ")";
            row["slno"] = slno;
            dtMemList.Rows.Add(row);

            ribbonUserMembers_DataShowing();
        }
        private void refreshRadSlno(int rowIndex)
        {
            DataRow row = dtMemList.Rows[rowIndex];
            if(!string.IsNullOrEmpty( row["slno"].ToString()))
                if (Convert.ToInt32(row["slno"]) > 0)
                {
                    DataRow[] rows = dtMemList.Select("slno > 0");
                    foreach (DataRow rowRefresh in rows)
                    {
                        rowRefresh["slno"] = Convert.ToInt32(rowRefresh["slno"]) - 1;
                        rowRefresh["fullname"] = "[" + rowRefresh["slno"].ToString() + "]" + rowRefresh["FullNameTemp"];
                    }
                }
        }
        #endregion User Members

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                getTrauma(Convert.ToInt32(row["ORDER_ID"]));

                DataRow[] rowExamFlag = dttExamFlag.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
                if (rowExamFlag.Length > 0)
                {
                    DataRow[] rowSelected = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowExamFlag[0]["EXAMFLAG_ID"].ToString());
                    contextcmb.SelectedIndex = dtExamFlagDTL.Rows.IndexOf(rowSelected[0]);
                }
                else
                    contextcmb.SelectedIndex = 0;
            }

        }
        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            ToolTipControlInfo info = null;
            try
            {
                if (e.SelectedControl == gridControl2 || e.SelectedControl == gridControl6)
                {
                    GridView view = null;
                    if (xtraTabControl2.SelectedTabPage == tabWorkload)
                        view = gridControl2.GetViewAt(e.ControlMousePosition) as GridView;
                    else if (xtraTabControl2.SelectedTabPage == tabRejectImage)
                        view = gridControl6.GetViewAt(e.ControlMousePosition) as GridView;

                    if (view == null) return;
                    GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle >= 0)
                        {
                            DataRow rowDetail = view.GetDataRow(hi.RowHandle);

                            switch (hi.Column.FieldName)
                            {
                                case "PATIENT_ID_LABEL":
                                    if (!string.IsNullOrEmpty(rowDetail["PATIENT_ID_LABEL"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["PATIENT_ID_DETAIL"].ToString());
                                        return;
                                    }
                                    break;
                                case "READER":
                                    if (!string.IsNullOrEmpty(rowDetail["READER"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["READER"].ToString());
                                        return;
                                    }
                                    break;
                                case "SCANIMAGES":
                                    if (rowDetail["SCANIMAGES"].ToString() == "0")
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), "No document.");
                                        return;
                                    }
                                    break;
                                case "FLAG_ICON":
                                    if (!string.IsNullOrEmpty(rowDetail["FLAG_ICON"].ToString()))
                                        if (rowDetail["FLAG_ICON"].ToString() != "0")
                                        {
                                            info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["FLAG_DESC"].ToString());
                                            return;
                                        }
                                    break;
                                case "CLINICAL_INSTRUCTION_TAG":
                                    if (!string.IsNullOrEmpty(rowDetail["CLINICAL_INSTRUCTION_TAG"].ToString()))
                                    {
                                        string strinfo = string.Empty;
                                        string[] tag = rowDetail["CLINICAL_INSTRUCTION_TAG"].ToString().Split(',');
                                        DataTable dtCliType = dtClinicalindicationtype.Tables[0].Copy();

                                        foreach (string str in tag)
                                        {
                                            DataRow[] drClitype = dtCliType.Select("CI_TAG = '" + str + "'");
                                            if (drClitype.Length > 0)
                                            {
                                                if (strinfo == string.Empty)
                                                    strinfo = drClitype[0]["CI_DESC"].ToString();
                                                else
                                                    strinfo += "\r\n" + drClitype[0]["CI_DESC"].ToString();
                                            }
                                        }

                                        if (strinfo != string.Empty)
                                            info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), strinfo);

                                        return;
                                    }
                                    break;
                                case "ALLERGIES":
                                    if (rowDetail["ALLERGIES"].ToString() == "Y")
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), "Allergy");
                                        return;
                                    }
                                    break;

                                case "GEN_TEXT":
                                    if (!string.IsNullOrEmpty(rowDetail["GEN_TEXT"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["GEN_TEXT"].ToString());
                                        return;
                                    }
                                    break;
                                case "REJECT_COMMENTS":
                                    if (!string.IsNullOrEmpty(rowDetail["REJECT_COMMENTS"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["REJECT_COMMENTS"].ToString());
                                        return;
                                    }
                                    break;
                                case "PHONE_CALL_BACK":
                                    if (!string.IsNullOrEmpty(rowDetail["PHONE_CALL_BACK"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["PHONE_CALL_BACK"].ToString());
                                        return;
                                    }
                                    break;
                            }
                        }
                    }
                    if (hi.HitTest == GridHitTest.GroupPanel)
                    {
                        info = new ToolTipControlInfo(hi.HitTest, "Group panel");
                        return;
                    }

                    if (hi.HitTest == GridHitTest.RowIndicator)
                    {
                        info = new ToolTipControlInfo(GridHitTest.RowIndicator.ToString() + hi.RowHandle.ToString(), "Row Handle: " + hi.RowHandle.ToString());
                        return;
                    }
                    if (hi.HitTest == GridHitTest.Column)
                    {
                        switch (hi.Column.FieldName)
                        {
                            case "SCANIMAGES": info = new ToolTipControlInfo(hi.HitTest, "Document"); break;
                            case "READER": info = new ToolTipControlInfo(hi.HitTest, "Comments"); break;
                            case "PATIENT_ID_LABEL": info = new ToolTipControlInfo(hi.HitTest, "Patient Detail"); break;
                            case "FLAG_ICON": info = new ToolTipControlInfo(hi.HitTest, "Exam Flag"); break;
                            case "CLINICAL_INSTRUCTION_TAG": info = new ToolTipControlInfo(hi.HitTest, "Alert Code"); break;
                            case "ALLERGIES": info = new ToolTipControlInfo(hi.HitTest, "Allergy"); break;
                        }
                    }
                }
            }
            finally
            {
                e.Info = info;
            }
        }
        private void contextcmb_DropDownClosed(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0)
            {
                TraumaItems trauma = contextcmb.SelectedItem as TraumaItems;
                DataRow rowDtl = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                DataRow[] rowCheck = dttExamFlag.Select("EXAM_ID=" + rowDtl["EXAM_ID"].ToString());
                if (rowCheck.Length > 0)
                {
                    ProcessUpdateRISOrderexamflag updateExamFlag = new ProcessUpdateRISOrderexamflag();
                    updateExamFlag.RIS_ORDEREXAMFLAG.FLAG_ID = Convert.ToInt32(rowCheck[0]["FLAG_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = Convert.ToInt32(rowCheck[0]["ORDER_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = Convert.ToInt32(rowCheck[0]["XRAYREQ_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowCheck[0]["ORDER_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["SCHEDULE_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowDtl["EXAM_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = trauma.Trauma_id();
                    updateExamFlag.RIS_ORDEREXAMFLAG.REASON = rowCheck[0]["REASON"].ToString();
                    updateExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                    updateExamFlag.Invoke();
                }
                else
                {
                    ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                    addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = Convert.ToInt32(rowDtl["ORDER_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = Convert.ToInt32(rowDtl["XRAYREQ_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowDtl["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowDtl["SCHEDULE_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowDtl["EXAM_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = trauma.Trauma_id();
                    addExamFlag.RIS_ORDEREXAMFLAG.REASON = "";
                    addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                    addExamFlag.Invoke();
                }
                rowDtl["FLAG_ICON"] = trauma.Trauma_id() == 72 ? 0 : 1;
                gridView2.RefreshData();
            }
        }
        private void inspectraAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                LookUpSelect lv = new LookUpSelect();
                try
                {
                    System.Diagnostics.Process.Start("chrome.exe", lv.GetAIImageLink(1, dr["ACCESSION_NO"].ToString()));
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show("Unable to find Google Chrome...",
                        "chrome.exe not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void rAMAAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                LookUpSelect lv = new LookUpSelect();
                try
                {
                    System.Diagnostics.Process.Start("chrome.exe", lv.GetAIImageLink(2, dr["ACCESSION_NO"].ToString()));
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show("Unable to find Google Chrome...",
                        "chrome.exe not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void orderSummaryToolStripMenuItemReject_Click(object sender, EventArgs e)
        {
            OrderSummaryProcessReject();
        }
        private void commentsToolStripMenuItemReject_Click(object sender, EventArgs e)
        {
            if (gridViewReject.FocusedRowHandle < 0) return;

            tmAutoRefresh.Stop();
            DataRow fcRow = gridViewReject.GetDataRow(gridViewReject.FocusedRowHandle);
            frmMessageConversation frm = new frmMessageConversation(fcRow["ACCESSION_NO"].ToString());
            frm.ShowDialog();

            Refreshing();
            tmAutoRefresh.Start();
        }
        private void CommentsProcessReject()
        {
            Comment.frmComment frm = null;
            if (gridViewReject.FocusedRowHandle < 0)
            {
                frm = new Envision.NET.Forms.Comment.frmComment();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                DataRow rowHandle = gridViewReject.GetDataRow(gridViewReject.FocusedRowHandle);
                string hn = rowHandle["HN"].ToString();
                int orderId = Convert.ToInt32(rowHandle["ORDER_ID"].ToString());
                frm = new Envision.NET.Forms.Comment.frmComment(hn, orderId, Envision.NET.Forms.Comment.QueryFromMode.Order);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            frm.Dispose();
        }
        private void OrderSummaryProcessReject()
        {
            if (gridViewReject.FocusedRowHandle < -1) return;

            DataRow dr = gridViewReject.GetDataRow(gridViewReject.FocusedRowHandle);
            this._orderSummary.ShowDialog(true, dr["ACCESSION_NO"].ToString());
        }

        private void gridViewReject_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = gridViewReject.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    if (dr["IS_ALERT_CLINICAL_INSTRUCTION"].ToString() == "Y")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                        //e.Appearance.ForeColor = Color.White;
                    }
                    else
                        //Show Online case
                        if (dr["IS_REQONLINE"].ToString() == "Y")
                        {
                            e.Appearance.BackColor = Color.SkyBlue;
                        }
                        else
                        {
                            //Show Merge case
                            if (dr["MERGE"].ToString() != string.Empty)
                            {
                                if (dr["MERGE_WITH"].ToString() != string.Empty)
                                {
                                    e.Appearance.BackColor = Color.LightPink;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.LightPink;
                                }
                            }
                            else
                            {
                                e.Appearance.BackColor = SystemColors.Window;
                            }
                        }
                }
            }
        }
        private void xtraTabControl2_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (xtraTabControl2.SelectedTabPage == tabWorkload)
                ReloadWorkload();
            else if (xtraTabControl2.SelectedTabPage == tabRejectImage)
                ReloadReject();
        }
    }
}