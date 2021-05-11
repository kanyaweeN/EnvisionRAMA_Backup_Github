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
using RIS.Forms.Order;

namespace RIS.Forms.Schedule
{
    public partial class frmScheduleWorkList : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataSet ds = null;
        private ProcessGetRISScheduledtl process = null;
        private RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
        private RepositoryItemGridLookUpEdit grdLMo = new RepositoryItemGridLookUpEdit();
        private RepositoryItemGridLookUpEdit grdLPat = new RepositoryItemGridLookUpEdit();
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private int[] langid;
        private string defaultlangs;
        private bool flag = false;

        public frmScheduleWorkList(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitControl();
            LoadDataToGrid();
            SetColumnInGrid();
            LoadFormLanguage();
        }
        private void frmScheduleWorkList_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void InitControl()
        {
            dateFrom.DateTime = DateTime.Today;
            dateTo.DateTime = DateTime.Today;
            lblToday.Text = "<" + DateTime.Today.ToString("dd/MM/yyy") +">";
        }
        private void LoadDataToGrid()
        {
            process = new ProcessGetRISScheduledtl(dateFrom.DateTime, dateTo.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59));
            ds = new DataSet();
            process.Invoke();
            ds = process.Result;
            gridControl1.DataSource = ds.Tables[0];
        }
        private void SetColumnInGrid()
        {
            //gridControl1.DataSource = ds.Tables[0];
            advBandedGridView1.OptionsView.ShowAutoFilterRow = false;
            advBandedGridView1.OptionsView.ShowBands = false;
            advBandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            advBandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            advBandedGridView1.OptionsView.ColumnAutoWidth = true;

            for (int i = 0; i < advBandedGridView1.Columns.Count; i++)
                advBandedGridView1.Columns[i].Visible = false;
            
            advBandedGridView1.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["HN"].Visible = true;
            advBandedGridView1.Columns["HN"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["HN"].Width = 90;

            advBandedGridView1.Columns["NameThai"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["NameThai"].Visible = true;
            advBandedGridView1.Columns["NameThai"].Caption = "Patient Name";
            advBandedGridView1.Columns["NameThai"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["NameThai"].Width = 190;

            grdLPat = new RepositoryItemGridLookUpEdit();
            DataTable dtPat = order.RIS_PatStatus();
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



            advBandedGridView1.Columns["pat_status"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["pat_status"].Visible = true;
            advBandedGridView1.Columns["pat_status"].Caption = "Patient Status";
            advBandedGridView1.Columns["pat_status"].ColumnEdit = grdLPat;
            advBandedGridView1.Columns["pat_status"].OptionsColumn.ReadOnly = false;
            //advBandedGridView1.Columns["pat_status"].Width = 190;

            advBandedGridView1.Columns["EXAM_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["EXAM_UID"].Visible = true;
            advBandedGridView1.Columns["EXAM_UID"].Caption = "Exam Code";
            advBandedGridView1.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["EXAM_UID"].Width = 90;

            advBandedGridView1.Columns["EXAM_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["EXAM_NAME"].Visible = true;
            advBandedGridView1.Columns["EXAM_NAME"].Caption = "Exam Name";
            advBandedGridView1.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["EXAM_NAME"].Width = 130;

            
            advBandedGridView1.Columns["APPOINT_DT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["APPOINT_DT"].Visible = true;
            advBandedGridView1.Columns["APPOINT_DT"].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns["APPOINT_DT"].Caption = "Exam Date";
            advBandedGridView1.Columns["APPOINT_DT"].OptionsColumn.ReadOnly = true;
            //advBandedGridView1.Columns["APPOINT_DT"].Width = 100;

            DataTable dtMo = order.Ris_Modality();
            grdLMo = new RepositoryItemGridLookUpEdit();
            grdLMo.DataSource = dtMo;
            //grdLMo.NullText = "";
            grdLMo.ValueMember = "MODALITY_ID";
            grdLMo.DisplayMember = "MODALITY_NAME";
            grdLMo.CloseUp += new CloseUpEventHandler(grdLMo_CloseUp);

            #region SetGridMo in Grid
            grdLMo.View.OptionsView.ShowAutoFilterRow = true;

            grdLMo.View.Columns["MODALITY_ID"].Visible = false;
            grdLMo.View.Columns["MODALITY_UID"].Visible = false;
            grdLMo.View.Columns["MODALITY_NAME"].Visible = true;
            grdLMo.View.Columns["ROOM_UID"].Visible = false;
            grdLMo.View.Columns["MODALITY_TYPE"].Visible = false;


            grdLMo.View.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdLMo.View.Columns["MODALITY_NAME"].Caption = "MODALITY"; 
            #endregion

            advBandedGridView1.Columns["MODALITY_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["MODALITY_ID"].Visible = true;
            advBandedGridView1.Columns["MODALITY_ID"].Caption = "Modality";
            advBandedGridView1.Columns["MODALITY_ID"].ColumnEdit = grdLMo;
            advBandedGridView1.Columns["MODALITY_ID"].OptionsColumn.ReadOnly = false;
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

        void grdLPat_CloseUp(object sender, CloseUpEventArgs e)
        {
            try
            {
                int row = (int)e.Value;
                DataTable dtGL = (DataTable)grdLPat.DataSource;
                UpdateGrid(row, "PatientStatus");
            }
            catch (Exception)
            {

            }

        }

        void grdLMo_CloseUp(object sender, CloseUpEventArgs e)
        {
            try
            {
            int row = (int)e.Value;
            DataTable dtGM = (DataTable)grdLMo.DataSource;
            UpdateGrid(row, "Modality");
            }
            catch (Exception)
            {
            }

        }

        private void UpdateGrid(int detail,string selectcase)
        {
            DataTable dtG = (DataTable)gridControl1.DataSource;
            //Patient patient = new Patient(dtG.Rows[advBandedGridView1.FocusedRowHandle]["HN"].ToString());

            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            DataTable dt = proc.GetScheduleData();
            DataRow[] drSchedule = dt.Select("SCHEDULE_ID = " + dtG.Rows[advBandedGridView1.FocusedRowHandle]["SCHEDULE_ID"].ToString());
            ProcessUpdateRISScheduledtl process = new ProcessUpdateRISScheduledtl();
            //ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();

            if (selectcase == "PatientStatus")
            {
                #region his_registration.
                //int regID = 0;
                //ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                //pAddHIS.HISRegistration.ADDR1 = patient.Address1;
                //pAddHIS.HISRegistration.ADDR2 = patient.Address2;
                //pAddHIS.HISRegistration.ADDR3 = patient.Address3;
                //pAddHIS.HISRegistration.ADDR4 = patient.Address4;
                //pAddHIS.HISRegistration.EM_CONTACT_PERSON = patient.Em_Contact_Person;
                //pAddHIS.HISRegistration.EMAIL = patient.Email;
                //pAddHIS.HISRegistration.NATIONALITY = patient.Nationality;
                //pAddHIS.HISRegistration.CREATED_BY = env.UserID;
                //pAddHIS.HISRegistration.DOB = patient.DateOfBirth;
                //pAddHIS.HISRegistration.FNAME = patient.FirstName;
                //pAddHIS.HISRegistration.FNAME_ENG = patient.FirstName_ENG;
                //pAddHIS.HISRegistration.MNAME_ENG = patient.MiddleName_ENG;
                //pAddHIS.HISRegistration.GENDER = patient.Gender;
                //pAddHIS.HISRegistration.HN = patient.Reg_UID;
                //pAddHIS.HISRegistration.LNAME = patient.LastName;
                //pAddHIS.HISRegistration.LNAME_ENG = patient.LastName_ENG;
                //pAddHIS.HISRegistration.ORG_ID = env.OrgID;
                ////pAddHIS.HISRegistration.PHONE1 = txtPhone.Text;
                ////pAddHIS.HISRegistration.PHONE2 = txtMobile.Text;
                //pAddHIS.HISRegistration.PHONE3 = patient.Phone3;
                //pAddHIS.HISRegistration.SSN = patient.SocialNumber;
                //pAddHIS.HISRegistration.TITLE = patient.Title;
                //pAddHIS.HISRegistration.TITLE_ENG = patient.Title_ENG;
                //pAddHIS.HISRegistration.INSURANCE_TYPE = patient.InsuranceID.ToString();
                //pAddHIS.Invoke();
                //regID = pAddHIS.HISRegistration.REG_ID;
                #endregion

                #region update normal.
                //process.RISSchedule.APPOINT_DT = Convert.ToDateTime(drSchedule[0]["APPOINT_DT"]);//start;
                //process.RISSchedule.BLOCK_REASON = null;
                //process.RISSchedule.CLINIC_TYPE = Convert.ToInt32(drSchedule[0]["CLINIC_TYPE"]);//Convert.ToInt32(txtClinicType.Tag.ToString());
                //process.RISSchedule.LAST_MODIFIED_BY = env.UserID;
                //process.RISSchedule.END_DATETIME = Convert.ToDateTime(drSchedule[0]["END_DATETIME"]);//end;
                //process.RISSchedule.EXAM_ID = Convert.ToInt32(drSchedule[0]["EXAM_ID"]);//Convert.ToInt32(txtExamUID.Tag.ToString());
                //process.RISSchedule.HN = patient.Reg_UID;
                //process.RISSchedule.MODALITY_ID = Convert.ToInt32(drSchedule[0]["MODALITY_ID"]);//Convert.ToInt32(apt.ResourceId.ToString());
                //process.RISSchedule.ORG_ID = env.OrgID;
                ////process.RISSchedule.REASON_CHANGE = drSchedule[0]["REASON_CHANGE"].ToString(); //txtInputReason.Text.Trim();
                //process.RISSchedule.REASON = drSchedule[0]["REASON"].ToString(); //txtReason.Text;
                //process.RISSchedule.REF_UNIT = Convert.ToInt32(drSchedule[0]["REF_UNIT"]); //Convert.ToInt32(txtOrderDept.Tag.ToString());
                //process.RISSchedule.REF_DOC = Convert.ToInt32(drSchedule[0]["REF_DOC"]); //Convert.ToInt32(txtOrderDoc.Tag.ToString());
                //process.RISSchedule.REG_ID = regID;
                //process.RISSchedule.SCHEDULE_DATA = drSchedule[0]["SCHEDULE_DATA"].ToString(); //patient.Reg_UID + "," + patient.FirstName + " " + patient.MiddleName + " " + patient.LastName + "," + txtExamName.Text;
                //process.RISSchedule.SCHEDULE_DT = Convert.ToDateTime(drSchedule[0]["SCHEDULE_DT"]); //start;
                //process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(drSchedule[0]["SCHEDULE_ID"]); //Convert.ToInt32(apt.Location);
                //process.RISSchedule.RATE = Convert.ToInt32(drSchedule[0]["RATE"]); //Convert.ToDecimal(txtRate.Text);
                ////process.RISSchedule.GEN_DTL_ID = Convert.ToInt32(drSchedule[0]["GEN_DTL_ID"]);//Convert.ToInt32(txtRate.Tag);
                //process.RISSchedule.RAD_ID = Convert.ToInt32(drSchedule[0]["RAD_ID"]);// Convert.ToInt32(txtRadiologist.Tag);

                //process.RISSchedule.PATSTATUS_ID = detail;


                process.RISScheduledtl.SCHEDULE_ID = Convert.ToInt32(drSchedule[0]["SCHEDULE_ID"]);
                process.RISScheduledtl.SELECTCASE = 1;
                process.RISScheduledtl.PAT_STATUS = detail;
                process.Invoke();

                #endregion
            }
            else
            {
                #region his_registration.
                //int regID = 0;
                //ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                //pAddHIS.HISRegistration.ADDR1 = patient.Address1;
                //pAddHIS.HISRegistration.ADDR2 = patient.Address2;
                //pAddHIS.HISRegistration.ADDR3 = patient.Address3;
                //pAddHIS.HISRegistration.ADDR4 = patient.Address4;
                //pAddHIS.HISRegistration.EM_CONTACT_PERSON = patient.Em_Contact_Person;
                //pAddHIS.HISRegistration.EMAIL = patient.Email;
                //pAddHIS.HISRegistration.NATIONALITY = patient.Nationality;
                //pAddHIS.HISRegistration.CREATED_BY = env.UserID;
                //pAddHIS.HISRegistration.DOB = patient.DateOfBirth;
                //pAddHIS.HISRegistration.FNAME = patient.FirstName;
                //pAddHIS.HISRegistration.FNAME_ENG = patient.FirstName_ENG;
                //pAddHIS.HISRegistration.MNAME_ENG = patient.MiddleName_ENG;
                //pAddHIS.HISRegistration.GENDER = patient.Gender;
                //pAddHIS.HISRegistration.HN = patient.Reg_UID;
                //pAddHIS.HISRegistration.LNAME = patient.LastName;
                //pAddHIS.HISRegistration.LNAME_ENG = patient.LastName_ENG;
                //pAddHIS.HISRegistration.ORG_ID = env.OrgID;
                ////pAddHIS.HISRegistration.PHONE1 = txtPhone.Text;
                ////pAddHIS.HISRegistration.PHONE2 = txtMobile.Text;
                //pAddHIS.HISRegistration.PHONE3 = patient.Phone3;
                //pAddHIS.HISRegistration.SSN = patient.SocialNumber;
                //pAddHIS.HISRegistration.TITLE = patient.Title;
                //pAddHIS.HISRegistration.TITLE_ENG = patient.Title_ENG;
                //pAddHIS.HISRegistration.INSURANCE_TYPE = patient.InsuranceID.ToString();
                //pAddHIS.Invoke();
                //regID = pAddHIS.HISRegistration.REG_ID;
                #endregion

                #region update normal.
                //process.RISSchedule.APPOINT_DT = Convert.ToDateTime(drSchedule[0]["APPOINT_DT"]);//start;
                //process.RISSchedule.BLOCK_REASON = null;
                //process.RISSchedule.CLINIC_TYPE = Convert.ToInt32(drSchedule[0]["CLINIC_TYPE"]);//Convert.ToInt32(txtClinicType.Tag.ToString());
                //process.RISSchedule.LAST_MODIFIED_BY = env.UserID;
                //process.RISSchedule.END_DATETIME = Convert.ToDateTime(drSchedule[0]["END_DATETIME"]);//end;
                //process.RISSchedule.EXAM_ID = Convert.ToInt32(drSchedule[0]["EXAM_ID"]);//Convert.ToInt32(txtExamUID.Tag.ToString());
                //process.RISSchedule.HN = patient.Reg_UID;
                //process.RISSchedule.MODALITY_ID = detail;//Convert.ToInt32(drSchedule[0]["MODALITY_ID"]);//Convert.ToInt32(apt.ResourceId.ToString());
                //process.RISSchedule.ORG_ID = env.OrgID;
                ////process.RISSchedule.REASON_CHANGE = drSchedule[0]["REASON_CHANGE"].ToString(); //txtInputReason.Text.Trim();
                //process.RISSchedule.REASON = drSchedule[0]["REASON"].ToString(); //txtReason.Text;
                //process.RISSchedule.REF_UNIT = Convert.ToInt32(drSchedule[0]["REF_UNIT"]); //Convert.ToInt32(txtOrderDept.Tag.ToString());
                //process.RISSchedule.REF_DOC = Convert.ToInt32(drSchedule[0]["REF_DOC"]); //Convert.ToInt32(txtOrderDoc.Tag.ToString());
                //process.RISSchedule.REG_ID = regID;
                //process.RISSchedule.SCHEDULE_DATA = drSchedule[0]["SCHEDULE_DATA"].ToString(); //patient.Reg_UID + "," + patient.FirstName + " " + patient.MiddleName + " " + patient.LastName + "," + txtExamName.Text;
                //process.RISSchedule.SCHEDULE_DT = Convert.ToDateTime(drSchedule[0]["SCHEDULE_DT"]); //start;
                //process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(drSchedule[0]["SCHEDULE_ID"]); //Convert.ToInt32(apt.Location);
                //process.RISSchedule.RATE = Convert.ToInt32(drSchedule[0]["RATE"]); //Convert.ToDecimal(txtRate.Text);
                ////process.RISSchedule.GEN_DTL_ID = Convert.ToInt32(drSchedule[0]["GEN_DTL_ID"]);//Convert.ToInt32(txtRate.Tag);
                //process.RISSchedule.RAD_ID = Convert.ToInt32(drSchedule[0]["RAD_ID"]);// Convert.ToInt32(txtRadiologist.Tag);


                //process.RISSchedule.PATSTATUS_ID = Convert.ToInt32(drSchedule[0]["PAT_STATUS"]);

                process.RISScheduledtl.SCHEDULE_ID = Convert.ToInt32(drSchedule[0]["SCHEDULE_ID"]);
                process.RISScheduledtl.SELECTCASE = 0;
                process.RISScheduledtl.MODALITY_ID = detail;

                process.Invoke();

                #endregion
            }
        }

        public void btnToOrder_ButtonClick(object sender, ButtonPressedEventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dateFrom.Text == string.Empty || dateTo.Text == string.Empty) return;
            LoadDataToGrid();
            SetColumnInGrid();
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

        //private void DrawCheckBox(Graphics g, Rectangle r, bool chk)
        //{
        //    DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
        //    DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
        //    DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;

        //    info = (DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)edit.CreateViewInfo();
        //    painter = (DevExpress.XtraEditors.Drawing.CheckEditPainter)edit.CreatePainter();
        //    info.EditValue = chk;
        //    info.Bounds = r;
        //    info.CalcViewInfo(g);
        //    args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);

        //    painter.Draw(args);
        //    args.Cache.Dispose();
        //}

        //private void chk_Click(object sender, EventArgs e)
        //{
        //    DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
        //    chk.Checked = true;
        //    #region Old logic
        //    //string sid = msg.ShowAlert("UID011", new GBLEnvVariable().CurrentLanguageID);
        //    //if (sid == "2")
        //    //{
        //    //    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
        //    //    ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
        //    //    process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
        //    //    process.RISSchedule.CREATED_BY = new GBLEnvVariable().UserID;
        //    //    process.Invoke();
        //    //    LoadDataToGrid();
        //    //    SetColumnInGrid();
        //    //} 
        //    #endregion
        //    string sid = msg.ShowAlert("UID1033", new GBLEnvVariable().CurrentLanguageID);
        //    if (sid == "2")
        //    {
        //        DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
        //        ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
        //        process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
        //        process.RISSchedule.SCHEDULE_STATUS = "C";  // dr["SCHEDULE_STATUS"].ToString();
        //        process.RISSchedule.CREATED_BY = new GBLEnvVariable().UserID;
        //        process.Invoke();
        //        LoadDataToGrid();
        //        SetColumnInGrid();
        //    }
        //    chk.Checked = false;
        //} 
        #endregion

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
                if (info.Column.Name == "SCHEDULE_STATUS") {
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
                            process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
                            process.RISSchedule.SCHEDULE_STATUS = "C";  // dr["SCHEDULE_STATUS"].ToString();
                            process.RISSchedule.CREATED_BY = new GBLEnvVariable().UserID;
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
            RIS.Forms.Order.frmViewPerformance frm = new RIS.Forms.Order.frmViewPerformance(this.CloseControl);
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
                ProcessGetRISSchedule process = new ProcessGetRISSchedule(txtHN.Text);
                //process.RISSchedule.HN = txtHN.Text;
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

        private void barManul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Manual", this.CloseControl);
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtInsurace.Focus();
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }
    }
}