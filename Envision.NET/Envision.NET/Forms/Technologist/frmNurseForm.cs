using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Utils;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using System.Data.Common;
using Envision.BusinessLogic;
using DevExpress.XtraEditors.Repository;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmNurseForm : Envision.NET.Forms.Main.MasterForm  //Form
    {
        MyMessageBox msg = new MyMessageBox();
        GBLEnvVariable env = new GBLEnvVariable();
        int G;// for grid
        private string TempHN, TempName, TempID, ORG, TempAccession;
        private int IdNurse, IdNurseDtl;
        private string RibbonClick;
        private DataTable dtTemp = new DataTable();
        private List<string> ls = new List<string>();
        //private Button btnDelete = new Button();

        bool start_wtih_data = false;
        public string ACCESSION_NO;

        private DataTable dtConsumable_ce;
        private DataView dvConsumable_ce;

        private DataTable dtCumulative_ce;
        private DataView dvCumulative_ce;

        private DataTable dttExam;
        private int order_id;

        public frmNurseForm()
        {
            InitializeComponent();
            start_wtih_data = false;
        }
        private void NurseForm_Load(object sender, EventArgs e)
        {
            if (!start_wtih_data)
            {
                EnableFillDemo(false);
                EnableFillMedical(false);
                SetGridNull();
                //cmbAnesTech.Properties.Items.Add("ant");
                //cmbAnesTech.Properties.Items.Add("lion");
                //cmbAnesTech.Text = "select"; 
            
                cmbAnesTech.Properties.Items.Add("Adrenal Gland");
                cmbAnesTech.Properties.Items.Add("Anatomy in Cutaneous Surgery");
                cmbAnesTech.Properties.Items.Add("Anatomy of Olfactory System");
                cmbAnesTech.Properties.Items.Add("Anatomy of the Vestibular System");
                cmbAnesTech.Properties.Items.Add("Arterial Supply, Overview");
                cmbAnesTech.Properties.Items.Add("Arterial Supply, Orbit");
                cmbAnesTech.Properties.Items.Add("Arteries to Brain and Meninges");
                cmbAnesTech.Properties.Items.Add("Bones of the Foot");
                cmbAnesTech.Properties.Items.Add("Brachial Plexus");
                cmbAnesTech.Properties.Items.Add("Brain Overview");
            }
            else
            {
                ProcessGetRISNursesData getData = new ProcessGetRISNursesData();
                getData.RIS_NURSESDATA.SELECTCASE = 30;
                getData.RIS_NURSESDATA.ACCESSION_NO = ACCESSION_NO;
                getData.Invoke();

                if (getData.Result.Tables[0].Rows.Count == 0)
                {
                    RibbonClick = "NEW";
                    this.Text = "NurseForm - " + RibbonClick;

                    getData = new ProcessGetRISNursesData();
                    getData.RIS_NURSESDATA.SELECTCASE = 31;
                    getData.RIS_NURSESDATA.ACCESSION_NO = ACCESSION_NO;
                    getData.Invoke();
                    DataRow row = getData.Result.Tables[0].Rows[0];

                    TempHN = row["HN"].ToString();
                    TempName = row["FullName"].ToString();
                    TempID = row["REG_ID"].ToString();

                    txtHN.Text = TempHN;
                    txtName.Text = TempName;

                    txtExam.Text = row["EXAM_NAME"].ToString();
                    txtWARD.Text = row["UNIT_NAME"].ToString();
                    txtAccessionNo.Text = row["ACCESSION_NO"].ToString();
                    txtOrderDt.Text = Convert.ToDateTime(row["ORDER_DT"]).ToString("dd/MM/yyyy HH:mm");
                    ORG = row["org_id"].ToString();

                    SetGridNull();

                    EnableFillDemo(true);
                    EnableFillMedical(true);
                }
                else
                {
                    RibbonClick = "Edit";
                    this.Text = "NurseForm - " + RibbonClick;

                    getData = new ProcessGetRISNursesData();
                    getData.RIS_NURSESDATA.SELECTCASE = 32;
                    getData.RIS_NURSESDATA.ACCESSION_NO = ACCESSION_NO;
                    getData.Invoke();

                    DataRow row = getData.Result.Tables[0].Rows[0];

                    txtHN.Text = row["HN"].ToString();
                    txtAccessionNo.Text = row["ACCESSION_NO"].ToString();
                    txtWARD.Text = row["UNIT_NAME"].ToString();
                    txtExam.Text = row["EXAM_NAME"].ToString();
                    txtName.Text = row["FullName"].ToString();
                    txtOrderDt.Text = row["ORDER_DT"].ToString();
                    IdNurse = Convert.ToInt32(row["NURSE_DATA_UK_ID"]);

                    ProcessGetRISNursesData geNu = new ProcessGetRISNursesData();
                    geNu.RIS_NURSESDATA.SELECTCASE = 2;
                    geNu.RIS_NURSESDATA.ACCESSIONPARAMETER = row["ACCESSION_NO"].ToString();
                    geNu.RIS_NURSESDATA.NURSE_DATA_UK_ID = Convert.ToInt32(row["NURSE_DATA_UK_ID"]);
                    geNu.Invoke();
                    DataSet ds = geNu.Result;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //cmbAnesTech.Text = ds.Tables[0].Rows[i]["ANESTHESIA_TECHNIQUE"].ToString();
                        switch (Convert.ToInt32(ds.Tables[0].Rows[i]["ANESTHESIA_TECHNIQUE"]))
                        {
                            case 0: cmbAnesTech.Text = "select"; break;
                            case 1: cmbAnesTech.Text = "ant"; break;
                            case 2: cmbAnesTech.Text = "lion"; break;
                        }
                        switch (ds.Tables[0].Rows[i]["PAST_ILL_DM"].ToString())
                        {
                            case "1": chkDM.Checked = true; break;
                            case "0": chkDM.Checked = false; break;
                        }
                        switch (ds.Tables[0].Rows[i]["PAST_ILL_HT"].ToString())
                        {
                            case "1": chkHT.Checked = true; break;
                            case "0": chkHT.Checked = false; break;
                        }
                        switch (ds.Tables[0].Rows[i]["PAST_ILL_HD"].ToString())
                        {
                            case "1": chkHD.Checked = true; break;
                            case "0": chkHD.Checked = false; break;
                        }
                        switch (ds.Tables[0].Rows[i]["PAST_ILL_ASTHMA"].ToString())
                        {
                            case "1": chkASTHMA.Checked = true; break;
                            case "0": chkASTHMA.Checked = false; break;
                        }
                        switch (ds.Tables[0].Rows[i]["PAST_ILL_OTHERS"].ToString())
                        {
                            case "1": chkOthers.Checked = true; break;
                            case "0": chkOthers.Checked = false; break;
                        }
                        memDiagnosis.Text = ds.Tables[0].Rows[i]["DIAGNOSIS"].ToString();
                        memOtherD.Text = ds.Tables[0].Rows[i]["OTHER_DESCRIPTION"].ToString();
                        memProceduce.Text = ds.Tables[0].Rows[i]["PROCEDURE"].ToString();

                    }
                    ProcessGetRISNursesDataDtl geNuDtl = new ProcessGetRISNursesDataDtl();
                    geNuDtl.RIS_NURSESDATADTL.SELECTCASE = 1;
                    geNuDtl.RIS_NURSESDATADTL.NURSE_DATA_UK_ID = Convert.ToInt32(row["NURSE_DATA_UK_ID"]);
                    geNuDtl.Invoke();
                    DataSet dsDtl = geNuDtl.Result;

                    gridControl1.DataSource = dsDtl.Tables[0];
                    SetGridColumn();

                    EnableFillDemo(true);
                    EnableFillMedical(true);
                }
            }
            base.CloseWaitDialog();

            LookUpSelect lk = new LookUpSelect();
            dttExam = lk.SelectExamConsumable().Tables[0];
            dttExam.TableName = "RIS_EXAM";
        }

        private void btnHN_Click(object sender, EventArgs e)
        {
            if (RibbonClick == "NEW")
            {
                LookupData lvR = new LookupData();
                lvR.ValueUpdated += new ValueUpdatedEventHandler(HN_ValueUpdated);
                lvR.AddColumn("HN", "HN", true, true);
                lvR.AddColumn("FullName", "Name", true, true);
                lvR.AddColumn("REG_ID", "ID", true, true);
                lvR.Text = "HN Search";

                ProcessGetRISNursesData geNu = new ProcessGetRISNursesData();
                geNu.RIS_NURSESDATA.SELECTCASE = 20;
                geNu.Invoke();


                lvR.Data = geNu.Result.Tables[0];
                lvR.ShowBox();
            }
            else if (RibbonClick == "Edit")
            {
                LookupData lvR = new LookupData();
                lvR.ValueUpdated += new ValueUpdatedEventHandler(SelectShowData_Edit);
                lvR.AddColumn("HN", "HN", true, true);
                lvR.AddColumn("UNIT_NAME", "WARD", true, true);
                lvR.AddColumn("EXAM_NAME", "Exam Name", true, true);
                lvR.AddColumn("FullName", "Name", true, true);
                lvR.AddColumn("ACCESSION_NO", "Accession No.", true, true);
                lvR.Text = "HN Search";

                ProcessGetRISNursesData geNu = new ProcessGetRISNursesData();
                geNu.RIS_NURSESDATA.SELECTCASE = 22;
                geNu.Invoke();

                #region check is empty?
                if (geNu.Result.Tables == null || geNu.Result.Tables[0].Rows.Count == 0)
                {
                    //MessageBox.Show("No Data", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    msg.ShowAlert("UID009", env.CurrentLanguageID);
                    return;
                }
                #endregion

                lvR.Data = geNu.Result.Tables[0];
                lvR.ShowBox();
            }
            //chkBarcode.Checked = false;
        }
        private void HN_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            TempHN = retValue[0];
            TempName = retValue[1];
            TempID = retValue[2];

            txtAge.Text = retValue[3];
            txtGender.Text = retValue[4];

            LookupData lvR = new LookupData();
            lvR.ValueUpdated += new ValueUpdatedEventHandler(Exam_ValueUpdated);
            lvR.AddColumn("EXAM_ID", "ID", true, true);
            lvR.AddColumn("EXAM_NAME", "Exam Name", true, true);
            lvR.AddColumn("UNIT_NAME", "Unit", true, true);
            lvR.AddColumn("ACCESSION_NO", "Accession", true, true);
            lvR.AddColumn("ORDER_DT", "Time", true, true);
            lvR.AddColumn("org_id", "ID", false, true);
            lvR.Text = "Exam Name Search";

            ProcessGetRISNursesData geNu = new ProcessGetRISNursesData();
            geNu.RIS_NURSESDATA.SELECTCASE = 21;
            geNu.Invoke();


            lvR.Data = geNu.Result.Tables[0];
            lvR.ShowBox();
        }
        private void Exam_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtHN.Text = TempHN;
            txtName.Text = TempName;
  
            txtExam.Text = retValue[1] + " " + retValue[2];
            txtWARD.Text = retValue[3];
            txtAccessionNo.Text = retValue[4];
            txtOrderDt.Text = retValue[5];
            ORG = retValue[6];

            order_id = Convert.ToInt32(retValue[7]);

            SetGridNull();

            EnableFillDemo(true);
            EnableFillMedical(true);

            LoadCaptureChangeExamGrid();
            LoadCumulativeGrid();
        }
        private void SelectShowData_Edit(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtHN.Text = retValue[0];
            txtAccessionNo.Text = retValue[4];
            txtWARD.Text = retValue[1];
            txtExam.Text = retValue[2];
            txtName.Text = retValue[3];
            txtOrderDt.Text = retValue[5];
            IdNurse = Convert.ToInt32(retValue[6]);

            ProcessGetRISNursesData geNu = new ProcessGetRISNursesData();
            geNu.RIS_NURSESDATA.SELECTCASE = 2;
            geNu.RIS_NURSESDATA.ACCESSIONPARAMETER = retValue[4];
            geNu.RIS_NURSESDATA.NURSE_DATA_UK_ID = Convert.ToInt32(retValue[6]);
            geNu.Invoke();
            DataSet ds = geNu.Result;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //cmbAnesTech.Text = ds.Tables[0].Rows[i]["ANESTHESIA_TECHNIQUE"].ToString();
                switch (Convert.ToInt32(ds.Tables[0].Rows[i]["ANESTHESIA_TECHNIQUE"]))
                {
                    case 0: cmbAnesTech.Text = "select"; break;
                    case 1: cmbAnesTech.Text = "ant"; break;
                    case 2: cmbAnesTech.Text = "lion"; break;
                }
                switch (ds.Tables[0].Rows[i]["PAST_ILL_DM"].ToString())
                {
                    case "1": chkDM.Checked = true; break;
                    case "0": chkDM.Checked = false; break;
                }
                switch (ds.Tables[0].Rows[i]["PAST_ILL_HT"].ToString())
                {
                    case "1": chkHT.Checked = true; break;
                    case "0": chkHT.Checked = false; break;
                }
                switch (ds.Tables[0].Rows[i]["PAST_ILL_HD"].ToString())
                {
                    case "1": chkHD.Checked = true; break;
                    case "0": chkHD.Checked = false; break;
                }
                switch (ds.Tables[0].Rows[i]["PAST_ILL_ASTHMA"].ToString())
                {
                    case "1": chkASTHMA.Checked = true; break;
                    case "0": chkASTHMA.Checked = false; break;
                }
                switch (ds.Tables[0].Rows[i]["PAST_ILL_OTHERS"].ToString())
                {
                    case "1": chkOthers.Checked = true; break;
                    case "0": chkOthers.Checked = false; break;
                }
                memDiagnosis.Text = ds.Tables[0].Rows[i]["DIAGNOSIS"].ToString();
                memOtherD.Text = ds.Tables[0].Rows[i]["OTHER_DESCRIPTION"].ToString();
                memProceduce.Text = ds.Tables[0].Rows[i]["PROCEDURE"].ToString();

            }
            ProcessGetRISNursesDataDtl geNuDtl = new ProcessGetRISNursesDataDtl();
            geNuDtl.RIS_NURSESDATADTL.SELECTCASE = 1;
            geNuDtl.RIS_NURSESDATADTL.NURSE_DATA_UK_ID = Convert.ToInt32(retValue[6]);
            geNuDtl.Invoke();
            DataSet dsDtl = geNuDtl.Result;

            gridControl1.DataSource = dsDtl.Tables[0];
            SetGridColumn();

            EnableFillDemo(true);
            EnableFillMedical(true);

        }
        private void SetGridNull()
        {
            ProcessGetRISNursesDataDtl geNu = new ProcessGetRISNursesDataDtl();
            geNu.RIS_NURSESDATADTL.SELECTCASE = 0;
            geNu.Invoke();
            DataSet ds = geNu.Result;

            gridControl1.DataSource = ds.Tables[0];
            SetGridColumn();

            //gdcNew.DataSource = ds.Tables[0];
            //SetGridColumnNew();

        }
        private void SetGridColumn()
        {
            //advBandedGridView1.OptionsView.ShowAutoFilterRow = true;
            advBandedGridView1.OptionsView.ShowGroupPanel = false;
            advBandedGridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            advBandedGridView1.OptionsView.ShowBands = false;
            advBandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            advBandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            advBandedGridView1.OptionsBehavior.Editable = true;

            for (int i = 0; i < advBandedGridView1.Columns.Count; i++)
            {
                advBandedGridView1.Columns[i].Visible = false;
            }

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = true;
            chk.ValueUnchecked = false;
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = FormatType.Custom;
            //chk.Click += new EventHandler(chk_Click);

            //DevExpress.XtraEditors.CheckEdit checkEdit = new CheckEdit();



            //DataColumn dc = new DataColumn("All", System.Type.GetType("System.Boolean"));
            //advBandedGridView1.Columns["All"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //advBandedGridView1.Columns["All"].Visible = true;
            //advBandedGridView1.Columns["All"].Name = "All";
            //advBandedGridView1.Columns["All"].Caption = "All";
            //advBandedGridView1.Columns["All"].ColumnEdit = chk;
            //advBandedGridView1.Columns["All"].OptionsColumn.AllowSort = DefaultBoolean.False;


            //advBandedGridView1.Columns["All"].VisibleIndex = 0;
            //gridView1.Columns["All"].VisibleIndex = 0;


            //DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            //dtEdit.ShowToday = true;

            advBandedGridView1.Columns["TIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["TIME"].Visible = true;
            advBandedGridView1.Columns["TIME"].Caption = "TIME";
            //advBandedGridView1.Columns["TIME"].ColumnEdit = dtEdit;
            advBandedGridView1.Columns["TIME"].OptionsColumn.ReadOnly = false;

            advBandedGridView1.Columns["Hr/Min"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Hr/Min"].Visible = true;
            advBandedGridView1.Columns["Hr/Min"].Caption = "Hr/Min";
            advBandedGridView1.Columns["Hr/Min"].OptionsColumn.ReadOnly = false;

            advBandedGridView1.Columns["RR/Min"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["RR/Min"].Visible = true;
            advBandedGridView1.Columns["RR/Min"].Caption = "RR/Min";
            advBandedGridView1.Columns["RR/Min"].OptionsColumn.ReadOnly = false;

            advBandedGridView1.Columns["BP Mmhg"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["BP Mmhg"].Visible = true;
            advBandedGridView1.Columns["BP Mmhg"].Caption = "BP Mmhg";
            advBandedGridView1.Columns["BP Mmhg"].OptionsColumn.ReadOnly = false;

            advBandedGridView1.Columns["O2 Sat(%)"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["O2 Sat(%)"].Visible = true;
            advBandedGridView1.Columns["O2 Sat(%)"].Caption = "O2 Sat(%)";
            advBandedGridView1.Columns["O2 Sat(%)"].OptionsColumn.ReadOnly = false;

            advBandedGridView1.Columns["Conscious"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Conscious"].Visible = true;
            advBandedGridView1.Columns["Conscious"].Caption = "Conscious";
            advBandedGridView1.Columns["Conscious"].OptionsColumn.ReadOnly = false;

            advBandedGridView1.Columns["Process Note"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Process Note"].Visible = true;
            advBandedGridView1.Columns["Process Note"].Caption = "Progress Note";
            advBandedGridView1.Columns["Process Note"].OptionsColumn.ReadOnly = false;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            rbtnDelete.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            rbtnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            rbtnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            rbtnDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(rbtnDelete_Clicks);

            advBandedGridView1.Columns["DELETE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["DELETE"].Visible = true;
            advBandedGridView1.Columns["DELETE"].Caption = "";
            advBandedGridView1.Columns["DELETE"].ColumnEdit = rbtnDelete;
            advBandedGridView1.Columns["DELETE"].OptionsColumn.ReadOnly = false;

        }
        private void rbtnDelete_Clicks(object sender, EventArgs e)
        {
            if (advBandedGridView1.FocusedRowHandle<0) return;

            string id = msg.ShowAlert("UID4003", new GBLEnvVariable().CurrentLanguageID);
            if (id == "2")
            {
                if (RibbonClick == "Edit")
                {

                    DataTable dtG = (DataTable)gridControl1.DataSource; //ข้อมูล grid เข้า datatable
                    ls.Add(dtG.Rows[G]["DETAIL_DATA_ID"].ToString());

                    advBandedGridView1.DeleteRow(G);
                }
                else if (RibbonClick == "NEW")
                {
                    //viewsNew.DeleteSelectedRows();
                    advBandedGridView1.DeleteSelectedRows();
                }

            }

        }
        private void EnableFillDemo(bool flag)
        {
            txtAccessionNo.Enabled = flag;
            txtExam.Enabled = flag;
            txtHN.Enabled = flag;
            txtName.Enabled = flag;
            txtOrderDt.Enabled = flag;
            txtWARD.Enabled = flag;
            btnHN.Enabled = flag;
            chkBarcode.Enabled = flag;

            btnAlergy.Enabled = flag;
            btnHistory.Enabled = flag;
            btnLabData.Enabled = flag;

            txtAge.Enabled = flag;
            txtGender.Enabled = flag;

            rbNEW.Visible = !flag;
            rbEdit.Visible = !flag;

            rbSave.Visible = flag;
            rbCancel.Visible = flag;
        }
        private void EnableFillMedical(bool flag)
        {
            cmbAnesTech.Enabled = flag;
            cmbAssistant.Enabled = flag;
            cmbOperator.Enabled = flag;
            memDiagnosis.Enabled = flag;
            memOtherD.Enabled = flag;
            memProceduce.Enabled = flag;
            gridControl1.Enabled = flag;
            btnSave.Enabled = flag;
            btnDelete.Enabled = flag;
            grcPastLliness.Enabled = flag;

        }

        #region Ribbon
        private void btnRbNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EnableFillDemo(false);
            EnableFillMedical(false);
            ClearDemoG();
            ClearMedical();
            btnHN.Enabled = true;
            //txtHN.Text = "คลิกเลือก HN--->";

            chkBarcode.Enabled = true;
            //tbControl.SelectedTabPage = tbpNew;

            RibbonClick = "NEW";
            btnDelete.Text = "Cancel";

            txtHN.Enabled = true;
            txtHN.Focus();

            txtAccessionNo.Enabled = true;

            //EnableFillMedical(true);
        }
        private void btnRbEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EnableFillDemo(false);
            EnableFillMedical(false);
            ClearDemoG();
            ClearMedical();

            btnHN.Enabled = true;
            txtHN.Text = "คลิกเลือก HN--->";

            chkBarcode.Enabled = true;
            RibbonClick = "Edit";
            btnDelete.Text = "Delete";

            btnHN.Focus();
        }


        private void btnRbClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.RemoveAt(index);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRbHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //for (int i = 0; i < CloseControl.TabPages.Count; i++)
            //{
            //    if (CloseControl.TabPages[i].Title == "Home")
            //    {
            //        CloseControl.TabPages[i].Selected = true;
            //        return;
            //    }
            //}
            //RIS.Forms.Main.frmMainTab frm = new RIS.Forms.Main.frmMainTab(this.CloseControl);
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
        }
        #endregion

        private void txtAccessionNo_TextChanged(object sender, EventArgs e)
        {
            if (chkBarcode.Checked == true)
            {

            }

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (RibbonClick == "Edit")
            {
                if (chkBarcode.Checked == true)
                {
                    txtAccessionNo.Enabled = true;
                    txtHN.Enabled = false;
                    txtAccessionNo.Text = "";
                    txtHN.Text = "คลิกเลือก HN--->";

                }
                else
                {
                    txtAccessionNo.Enabled = false;
                    txtHN.Enabled = true;
                    txtHN.Text = "คลิกเลือก HN--->";
                }

            }
            else if (RibbonClick == "NEW")
            {
                if (chkBarcode.Checked == true)
                {
                    txtAccessionNo.Enabled = true;
                    txtHN.Enabled = false;
                    txtAccessionNo.Text = "";
                    txtHN.Text = "คลิกเลือก HN--->";
                }
                else
                {
                    txtAccessionNo.Enabled = false;
                    txtHN.Enabled = true;
                    txtHN.Text = "คลิกเลือก HN--->";
                }
            }

        }
        private void ClearDemoG()
        {
            txtAccessionNo.Text = "";
            txtExam.Text = "";
            txtHN.Text = "";
            txtName.Text = "";
            txtOrderDt.Text = "";
            txtWARD.Text = "";

            //chkBarcode.Checked = false;

            txtAge.Text = "";
            txtGender.Text = "";

            //gridControl5.DataSource = ((DataTable)gridControl5.DataSource).Clone();
            //gridControl2.DataSource = ((DataTable)gridControl2.DataSource).Clone();
        }
        private void ClearMedical()
        {
            cmbAnesTech.Text = "";
            cmbAssistant.Text = "";
            cmbOperator.Text = "";

            chkASTHMA.Checked = false;
            chkDM.Checked = false;
            chkHD.Checked = false;
            chkHT.Checked = false;
            chkOthers.Checked = false;

            memDiagnosis.Text = "";
            memOtherD.Text = "";
            memProceduce.Text = "";

            gridControl1.DataSource = null;

        }
        private void InsertData()
        {
            //SqlTransaction tran = null;
            //SqlConnection con = null;
            //DbTransaction tran = null;
            //DbConnection con = null;
            int RecieveID;
            try
            {
                //DataAccess.DataAccessBase basedata = new RIS.DataAccess.DataAccessBase();
                //con = basedata.GetSQLConnection();
                //con.Open();
                //tran = con.BeginTransaction();

                //Envision.DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
                //con = db.Connection();
                //con.Open();
                //tran = con.BeginTransaction();


                ProcessAddRISNursesData InNu = new ProcessAddRISNursesData();
                ProcessAddRISNursesDataDtl InNuDtl = new ProcessAddRISNursesDataDtl();

                InNu.RIS_NURSESDATA.NURSE_ID = env.UserID;
                InNu.RIS_NURSESDATA.ACCESSION_NO = txtAccessionNo.Text;
                InNu.RIS_NURSESDATA.ANESTHESIA_TECHNIQUE = Convert.ToInt32(cmbAnesTech.SelectedIndex);
                if (chkDM.Checked == true)
                { InNu.RIS_NURSESDATA.PAST_ILL_DM = '1'; }
                else
                { InNu.RIS_NURSESDATA.PAST_ILL_DM = '0'; }

                if (chkHT.Checked == true)
                { InNu.RIS_NURSESDATA.PAST_ILL_HT = '1'; }
                else
                { InNu.RIS_NURSESDATA.PAST_ILL_HT = '0'; }

                if (chkHD.Checked == true)
                { InNu.RIS_NURSESDATA.PAST_ILL_HD = '1'; }
                else
                { InNu.RIS_NURSESDATA.PAST_ILL_HD = '0'; }

                if (chkASTHMA.Checked == true)
                { InNu.RIS_NURSESDATA.PAST_ILL_ASTHMA = '1'; }
                else
                { InNu.RIS_NURSESDATA.PAST_ILL_ASTHMA = '0'; }

                if (chkOthers.Checked == true)
                { InNu.RIS_NURSESDATA.PAST_ILL_OTHERS = '1'; }
                else
                { InNu.RIS_NURSESDATA.PAST_ILL_OTHERS = '0'; }

                InNu.RIS_NURSESDATA.PROCEDURE = memProceduce.Text;
                InNu.RIS_NURSESDATA.DIAGNOSIS = memDiagnosis.Text;
                InNu.RIS_NURSESDATA.OTHER_DESCRIPTION = memOtherD.Text;

                InNu.RIS_NURSESDATA.ASSISTANT_ID = 2345; //I make it
                InNu.RIS_NURSESDATA.OPERATOR_ID = 3456; // I make it

                InNu.RIS_NURSESDATA.ORG_ID = Convert.ToInt32(ORG);
                InNu.RIS_NURSESDATA.CREATED_BY = env.UserID;
                InNu.RIS_NURSESDATA.LAST_MODIFIED_BY = env.UserID;

                InNu.Invoke();

                RecieveID = InNu.RIS_NURSESDATA.NURSE_DATA_UK_ID;

                /*---------------------Insert NursesDataDtl--------------*/

                DataTable dtg = (DataTable)gridControl1.DataSource;
                DataTable dtT = dtg.Copy();
                dtT.AcceptChanges();



                foreach (DataRow dr in dtT.Rows)
                {
                    InNuDtl.RIS_NURSESDATADTL.NURSE_DATA_UK_ID = InNu.RIS_NURSESDATA.NURSE_DATA_UK_ID;
                    if (dr["TIME"].ToString() == "")
                    {
                        InNuDtl.RIS_NURSESDATADTL.DETAIL_TIME = DateTime.Now;
                    }
                    else
                    {
                        InNuDtl.RIS_NURSESDATADTL.DETAIL_TIME = Convert.ToDateTime(dr["TIME"].ToString());  
                    }

                    InNuDtl.RIS_NURSESDATADTL.HR_MIN = dr["Hr/Min"].ToString();
                    InNuDtl.RIS_NURSESDATADTL.RR_MIN = dr["RR/Min"].ToString();
                    InNuDtl.RIS_NURSESDATADTL.BP_MMHG = dr["BP Mmhg"].ToString();
                    InNuDtl.RIS_NURSESDATADTL.O2_SAT = dr["O2 Sat(%)"].ToString();
                    InNuDtl.RIS_NURSESDATADTL.CONCSIOUS = dr["Conscious"].ToString();
                    InNuDtl.RIS_NURSESDATADTL.PROGRESS_NOTE = dr["Process Note"].ToString();
                    InNuDtl.RIS_NURSESDATADTL.CREATED_BY = env.UserID;
                    InNuDtl.RIS_NURSESDATADTL.LAST_MODIFIED_BY = env.UserID;

                    InNuDtl.Invoke();
                }
                //tran.Commit();

                //MessageBox.Show("Save Complete", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                msg.ShowAlert("UID005", env.CurrentLanguageID);
            }
            catch (Exception)
            {

                //tran.Rollback();

            }
            finally
            {
                //if (con.State == ConnectionState.Open)
                //    con.Close();
                //tran.Dispose();
            }



        }
        private void UpdateData()
        {
            ProcessUpdateRISNursesData upNu = new ProcessUpdateRISNursesData();
            upNu.RIS_NURSESDATA.NURSE_DATA_UK_ID = IdNurse;
            upNu.RIS_NURSESDATA.ANESTHESIA_TECHNIQUE = cmbAnesTech.SelectedIndex;
            upNu.RIS_NURSESDATA.NURSE_ID = env.UserID;
            switch (chkASTHMA.Checked)
            {
                case true: upNu.RIS_NURSESDATA.PAST_ILL_ASTHMA = '1'; break;
                case false: upNu.RIS_NURSESDATA.PAST_ILL_ASTHMA = '0'; break;
            }
            switch (chkDM.Checked)
            {
                case true: upNu.RIS_NURSESDATA.PAST_ILL_DM = '1'; break;
                case false: upNu.RIS_NURSESDATA.PAST_ILL_DM = '0'; break;
            }
            switch (chkHD.Checked)
            {
                case true: upNu.RIS_NURSESDATA.PAST_ILL_HD = '1'; break;
                case false: upNu.RIS_NURSESDATA.PAST_ILL_HD = '0'; break;
            }
            switch (chkHT.Checked)
            {
                case true: upNu.RIS_NURSESDATA.PAST_ILL_HT = '1'; break;
                case false: upNu.RIS_NURSESDATA.PAST_ILL_HT = '0'; break;
            }
            switch (chkOthers.Checked)
            {
                case true: upNu.RIS_NURSESDATA.PAST_ILL_OTHERS = '1'; break;
                case false: upNu.RIS_NURSESDATA.PAST_ILL_OTHERS = '0'; break;
            }
            upNu.RIS_NURSESDATA.PROCEDURE = memProceduce.Text;
            upNu.RIS_NURSESDATA.DIAGNOSIS = memDiagnosis.Text;
            upNu.RIS_NURSESDATA.OTHER_DESCRIPTION = memOtherD.Text;
            upNu.RIS_NURSESDATA.ASSISTANT_ID = cmbAssistant.SelectedIndex;
            upNu.RIS_NURSESDATA.OPERATOR_ID = cmbOperator.SelectedIndex;
            upNu.RIS_NURSESDATA.LAST_MODIFIED_BY = env.UserID;
            upNu.Invoke();

            for (int dlnd = 0; dlnd < ls.Count; dlnd++)
            {
                ProcessDeleteRISNursesDtlData dlNuDtl = new ProcessDeleteRISNursesDtlData();
                dlNuDtl.RIS_NURSESDATADTL.NURSE_DATA_UK_ID = IdNurse;
                dlNuDtl.RIS_NURSESDATADTL.DETAIL_DATA_ID = Convert.ToInt32(ls[dlnd]);
                dlNuDtl.Invoke();
            }

            ProcessUpdateRISNursesDataDtl upNudtl = new ProcessUpdateRISNursesDataDtl();
            DataTable dtG = (DataTable)gridControl1.DataSource;
            DataTable dtt = dtG.Copy();
            dtt.AcceptChanges();
            dtG.AcceptChanges();
            for (int g = 0; g < dtG.Rows.Count; g++)
            {
                if (dtG.Rows[g]["DETAIL_DATA_ID"].ToString() == "")
                {
                    ProcessAddRISNursesDataDtl inNudtl = new ProcessAddRISNursesDataDtl();
                    inNudtl.RIS_NURSESDATADTL.NURSE_DATA_UK_ID = IdNurse;
                    if (dtG.Rows[g]["TIME"].ToString() == "")
                    {
                        inNudtl.RIS_NURSESDATADTL.DETAIL_TIME = DateTime.Now;
                    }
                    else
                    {
                        inNudtl.RIS_NURSESDATADTL.DETAIL_TIME = Convert.ToDateTime(dtG.Rows[g]["TIME"]);
                    }
                    inNudtl.RIS_NURSESDATADTL.HR_MIN = dtG.Rows[g]["Hr/Min"].ToString();
                    inNudtl.RIS_NURSESDATADTL.RR_MIN = dtG.Rows[g]["RR/Min"].ToString();
                    inNudtl.RIS_NURSESDATADTL.BP_MMHG = dtG.Rows[g]["BP Mmhg"].ToString();
                    inNudtl.RIS_NURSESDATADTL.O2_SAT = dtG.Rows[g]["O2 Sat(%)"].ToString();
                    inNudtl.RIS_NURSESDATADTL.CONCSIOUS = dtG.Rows[g]["Conscious"].ToString();
                    inNudtl.RIS_NURSESDATADTL.PROGRESS_NOTE = dtG.Rows[g]["Process Note"].ToString();
                    inNudtl.RIS_NURSESDATADTL.CREATED_BY = env.UserID;
                    inNudtl.RIS_NURSESDATADTL.LAST_MODIFIED_BY = env.UserID;
                    inNudtl.Invoke();

                }
                else
                {
                    upNudtl.RIS_NURSESDATADTL.NURSE_DATA_UK_ID = IdNurse;
                    upNudtl.RIS_NURSESDATADTL.DETAIL_DATA_ID = Convert.ToInt32(dtG.Rows[g]["DETAIL_DATA_ID"]);
                    upNudtl.RIS_NURSESDATADTL.DETAIL_TIME = Convert.ToDateTime(dtG.Rows[g]["TIME"]);
                    upNudtl.RIS_NURSESDATADTL.HR_MIN = dtG.Rows[g]["Hr/Min"].ToString();
                    upNudtl.RIS_NURSESDATADTL.RR_MIN = dtG.Rows[g]["RR/Min"].ToString();
                    upNudtl.RIS_NURSESDATADTL.BP_MMHG = dtG.Rows[g]["BP Mmhg"].ToString();
                    upNudtl.RIS_NURSESDATADTL.O2_SAT = dtG.Rows[g]["O2 Sat(%)"].ToString();
                    upNudtl.RIS_NURSESDATADTL.CONCSIOUS = dtG.Rows[g]["Conscious"].ToString();
                    upNudtl.RIS_NURSESDATADTL.PROGRESS_NOTE = dtG.Rows[g]["Process Note"].ToString();
                    upNudtl.RIS_NURSESDATADTL.LAST_MODIFIED_BY = env.UserID;
                    upNudtl.Invoke();
                }

            }
            dtt.AcceptChanges();
            //MessageBox.Show("Save Complete", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            msg.ShowAlert("UID005", env.CurrentLanguageID);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RibbonClick == "NEW")
            {
                try
                {
                    if (gridControl1.DataSource != null)
                    {
                        string id = msg.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);
                        if (id == "2")
                        {
                            InsertData();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        msg.ShowAlert("UID4005", new GBLEnvVariable().CurrentLanguageID);
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    msg.ShowAlert("UID1024", env.CurrentLanguageID);
                }
            }
            else if (RibbonClick == "Edit")
            {
                if (gridControl1.DataSource != null)
                {
                    string id = msg.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);
                    if (id == "2")
                    {
                        UpdateData();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    msg.ShowAlert("UID4005", new GBLEnvVariable().CurrentLanguageID);
                }
            }

            ClearDemoG();
            ClearMedical();
            gridControl1.DataSource = null;

            EnableFillDemo(false);
            EnableFillMedical(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (RibbonClick == "Edit")
            {
                string idDel = msg.ShowAlert("UID4003",new GBLEnvVariable().CurrentLanguageID);
                if (idDel == "2")
                {
                    DataTable dtG = (DataTable)gridControl1.DataSource;
                    for (int i = 0; i < dtG.Rows.Count; i++)
                    {
                        ProcessDeleteRISNursesDtlData dlNu = new ProcessDeleteRISNursesDtlData();
                        dlNu.RIS_NURSESDATADTL.NURSE_DATA_UK_ID = IdNurse;
                        dlNu.RIS_NURSESDATADTL.DETAIL_DATA_ID = Convert.ToInt32(dtG.Rows[i]["DETAIL_DATA_ID"].ToString());
                        dlNu.Invoke();

                    }

                    ProcessDeleteRISNursesData dl = new ProcessDeleteRISNursesData();
                    dl.RIS_NURSESDATA.NURSE_DATA_UK_ID = IdNurse;
                    dl.Invoke();  
                }
                ClearDemoG();
                ClearMedical();
                EnableFillDemo(false);
                EnableFillMedical(false);
            }
            else if (RibbonClick == "NEW")
            {
                ClearDemoG();
                ClearMedical();
                EnableFillDemo(false);
                EnableFillMedical(false);
            }
            //advBandedGridView1.DeleteSelectedRows();
        }

        private void advBandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            G = e.FocusedRowHandle;
        }

        private void txtAccessionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int ID = 0;
                if (chkBarcode.Checked == true)
                {
                    ProcessGetRISNursesData geNu = new ProcessGetRISNursesData();
                    geNu.RIS_NURSESDATA.SELECTCASE = 1;
                    geNu.RIS_NURSESDATA.ACCESSIONPARAMETER = txtAccessionNo.Text;
                    geNu.Invoke();
                    DataSet ds = geNu.Result;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        txtHN.Text = ds.Tables[0].Rows[i]["HN"].ToString();
                        txtExam.Text = ds.Tables[0].Rows[i]["EXAM_NAME"].ToString();
                        txtName.Text = ds.Tables[0].Rows[i]["NAME"].ToString();
                        txtOrderDt.Text = ds.Tables[0].Rows[i]["order_dt"].ToString();
                        txtWARD.Text = ds.Tables[0].Rows[i]["UNIT_NAME"].ToString();
                    }
                    if (RibbonClick == "Edit")
                    {
                        ProcessGetRISNursesData geNu2 = new ProcessGetRISNursesData();
                        geNu2.RIS_NURSESDATA.SELECTCASE = 3;
                        geNu2.RIS_NURSESDATA.ACCESSIONPARAMETER = txtAccessionNo.Text;
                        geNu2.Invoke();
                        DataSet ds2 = geNu2.Result;
                        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                        {
                            ID = Convert.ToInt32(ds2.Tables[0].Rows[i]["NURSE_DATA_UK_ID"]);
                            //cmbAnesTech.Text = ds.Tables[0].Rows[i]["ANESTHESIA_TECHNIQUE"].ToString();
                            switch (Convert.ToInt32(ds2.Tables[0].Rows[i]["ANESTHESIA_TECHNIQUE"]))
                            {
                                case 0: cmbAnesTech.Text = "select"; break;
                                case 1: cmbAnesTech.Text = "ant"; break;
                                case 2: cmbAnesTech.Text = "lion"; break;
                            }
                            switch (ds2.Tables[0].Rows[i]["PAST_ILL_DM"].ToString())
                            {
                                case "1": chkDM.Checked = true; break;
                                case "0": chkDM.Checked = false; break;
                            }
                            switch (ds2.Tables[0].Rows[i]["PAST_ILL_HT"].ToString())
                            {
                                case "1": chkHT.Checked = true; break;
                                case "0": chkHT.Checked = false; break;
                            }
                            switch (ds2.Tables[0].Rows[i]["PAST_ILL_HD"].ToString())
                            {
                                case "1": chkHD.Checked = true; break;
                                case "0": chkHD.Checked = false; break;
                            }
                            switch (ds2.Tables[0].Rows[i]["PAST_ILL_ASTHMA"].ToString())
                            {
                                case "1": chkASTHMA.Checked = true; break;
                                case "0": chkASTHMA.Checked = false; break;
                            }
                            switch (ds2.Tables[0].Rows[i]["PAST_ILL_OTHERS"].ToString())
                            {
                                case "1": chkOthers.Checked = true; break;
                                case "0": chkOthers.Checked = false; break;
                            }
                            memDiagnosis.Text = ds2.Tables[0].Rows[i]["DIAGNOSIS"].ToString();
                            memOtherD.Text = ds2.Tables[0].Rows[i]["OTHER_DESCRIPTION"].ToString();
                            memProceduce.Text = ds2.Tables[0].Rows[i]["PROCEDURE"].ToString();

                        }
                        ProcessGetRISNursesDataDtl geNuDtl = new ProcessGetRISNursesDataDtl();
                        geNuDtl.RIS_NURSESDATADTL.SELECTCASE = 1;
                        geNuDtl.RIS_NURSESDATADTL.NURSE_DATA_UK_ID = ID;
                        geNuDtl.Invoke();
                        DataSet dsDtl = geNuDtl.Result;

                        gridControl1.DataSource = dsDtl.Tables[0];
                        SetGridColumn();


                    }
                    EnableFillDemo(true);
                    EnableFillMedical(true);
                }
                else if (chkBarcode.Checked == false)
                {
                    SendKeys.Send("{tab}");
                }
            }
        }

        private void btnWorklist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmTechnologist frm = new frmTechnologist(this.CloseControl);
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }

        private void btnLabData_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

        }

        private void btnAlergy_Click(object sender, EventArgs e)
        {

        }

        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (txtHN.Text.Trim().Length > 0)
            {
                ProcessGetRISNursesData geNu = new ProcessGetRISNursesData();
                geNu.RIS_NURSESDATA.SELECTCASE = 24;
                geNu.RIS_NURSESDATA.HN = txtHN.Text.Trim();
                geNu.Invoke();

                if (geNu.Result.Tables[0].Rows.Count == 0) return;

                DataRow row = geNu.Result.Tables[0].Rows[0];
                TempHN = row["HN"].ToString();
                TempName = row["FullName"].ToString(); //FullName
                TempID = row["REG_ID"].ToString();   //REG_ID

                order_id = Convert.ToInt32(row["ORDER_ID"].ToString());

                txtAge.Text = row["AGE"].ToString();
                txtGender.Text = row["GENDER"].ToString();

                LookupData lvR = new LookupData();
                lvR.ValueUpdated += new ValueUpdatedEventHandler(Exam_ValueUpdated);
                lvR.AddColumn("EXAM_ID", "ID", true, true);
                lvR.AddColumn("EXAM_NAME", "Exam Name", true, true);
                lvR.AddColumn("UNIT_NAME", "Unit", true, true);
                lvR.AddColumn("ACCESSION_NO", "Accession", true, true);
                lvR.AddColumn("ORDER_DT", "Time", true, true);
                lvR.AddColumn("org_id", "ID", false, true);
                lvR.Text = "Exam Name Search";

                ProcessGetRISNursesData geNurse = new ProcessGetRISNursesData();
                geNu.RIS_NURSESDATA.SELECTCASE = 21;
                geNu.Invoke();


                lvR.Data = geNu.Result.Tables[0];
                lvR.ShowBox();
            }
        }

        private void getConsumable_ce()
        {
            //DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            //int ORDER_ID = Convert.ToInt32(row["ORDER_ID"]);
            
            Order thisOrder = new Order(order_id);
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
        private void LoadCaptureChangeExamGrid()
        {
            getConsumable_ce();

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

            //TotalRate_Calculating_ce();
        }
        private void btnConsumable_ce_Click(object sender, EventArgs e)
        {
            //DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            //int ORDER_ID = Convert.ToInt32(dr["ORDER_ID"]);
            frmConsumable frm = new frmConsumable(order_id);//_order_id);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ControlBox = false;
            //frm.ShowDialog();
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders(order_id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCaptureChangeExamGrid();
                LoadCumulativeGrid();
            }
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSaving();
        }
        private void btnSaving()
        {
            if (RibbonClick == "NEW")
            {
                try
                {
                    if (gridControl1.DataSource != null)
                    {
                        string id = msg.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);
                        if (id == "2")
                        {
                            InsertData();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        msg.ShowAlert("UID4005", new GBLEnvVariable().CurrentLanguageID);
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    msg.ShowAlert("UID1024", env.CurrentLanguageID);
                }
            }
            else if (RibbonClick == "Edit")
            {
                if (gridControl1.DataSource != null)
                {
                    string id = msg.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);
                    if (id == "2")
                    {
                        UpdateData();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    msg.ShowAlert("UID4005", new GBLEnvVariable().CurrentLanguageID);
                }
            }

            ClearDemoG();
            ClearMedical();
            gridControl1.DataSource = null;

            EnableFillDemo(false);
            EnableFillMedical(false);
        }

        private void barBtnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDeleting();
        }
        private void btnDeleting()
        {
            if (RibbonClick == "Edit")
            {
                string idDel = msg.ShowAlert("UID4003", new GBLEnvVariable().CurrentLanguageID);
                if (idDel == "2")
                {
                    DataTable dtG = (DataTable)gridControl1.DataSource;
                    for (int i = 0; i < dtG.Rows.Count; i++)
                    {
                        ProcessDeleteRISNursesDtlData dlNu = new ProcessDeleteRISNursesDtlData();
                        dlNu.RIS_NURSESDATADTL.NURSE_DATA_UK_ID = IdNurse;
                        dlNu.RIS_NURSESDATADTL.DETAIL_DATA_ID = Convert.ToInt32(dtG.Rows[i]["DETAIL_DATA_ID"].ToString());
                        dlNu.Invoke();

                    }

                    ProcessDeleteRISNursesData dl = new ProcessDeleteRISNursesData();
                    dl.RIS_NURSESDATA.NURSE_DATA_UK_ID = IdNurse;
                    dl.Invoke();
                }
                ClearDemoG();
                ClearMedical();
                EnableFillDemo(false);
                EnableFillMedical(false);
            }
            else if (RibbonClick == "NEW")
            {
                ClearDemoG();
                ClearMedical();
                EnableFillDemo(false);
                EnableFillMedical(false);
            }
            //advBandedGridView1.DeleteSelectedRows();
        }

        private void getCumulative_ce()
        {
            ProcessGetRISNursesData geNu = new ProcessGetRISNursesData();
            geNu.RIS_NURSESDATA.SELECTCASE = 25;
            geNu.RIS_NURSESDATA.HN = txtHN.Text.Trim();
            geNu.Invoke();

            dtCumulative_ce = geNu.Result.Tables[0];
            dvCumulative_ce = new DataView(geNu.Result.Tables[0]);
        }
        private void LoadCumulativeGrid()
        {
            getCumulative_ce();

            gridControl2.DataSource = dvCumulative_ce;

            int k = 0;
            while (k < gridView2.Columns.Count)
            {
                gridView2.Columns[k].Visible = false;
                gridView2.Columns[k].OptionsColumn.AllowEdit = false;
                ++k;
            }

            gridView2.OptionsView.ShowBands = false;
            gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView2.OptionsView.ShowColumnHeaders = true;
            gridView2.OptionsView.ShowGroupPanel = false;

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
            gridView2.Columns["EXAM_ID"].ColumnEdit = repositoryItemLookUpEdit1;
            gridView2.Columns["EXAM_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            gridView2.Columns["EXAM_ID"].Visible = true;

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
            //gridView2.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            gridView2.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            gridView2.Columns["EXAM_NAME"].Visible = true;

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            //btn.Click += new EventHandler(btnDeleteRow_Click);
            gridView2.Columns["colDelete"].Caption = string.Empty;
            gridView2.Columns["colDelete"].ColumnEdit = btn;
            gridView2.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gridView2.Columns["colDelete"].Width = 50;
            gridView2.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemSpinEdit spin = new RepositoryItemSpinEdit();
            //spin.KeyUp += new KeyEventHandler(qty_KeyUp);
            //spin.ValueChanged += new EventHandler(qty_ValueChanged);
            spin.MinValue = 0.1M;
            spin.MaxValue = 999.99M;
            gridView2.Columns["QTY"].ColumnEdit = spin;

            gridView2.Columns["QTY"].Visible = true;
            gridView2.Columns["RATE"].Visible = true;
            gridView2.Columns["Total"].Visible = true;
            //gridView2.Columns["colDelete"].Visible = true;

            gridView2.Columns["EXAM_ID"].Caption = "Consumable Code";
            gridView2.Columns["EXAM_NAME"].Caption = "Consumable Name";
            gridView2.Columns["QTY"].Caption = "Qty";
            gridView2.Columns["RATE"].Caption = "Rate";
            gridView2.Columns["RATE"].OptionsColumn.ReadOnly = true;
            gridView2.Columns["RATE"].DisplayFormat.FormatString = "#,##0.00";
            gridView2.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gridView2.Columns["Total"].Caption = "Total";
            //gridView2.Columns["Total"].OptionsColumn.ReadOnly = true;
            //gridView2.Columns["Total"].DisplayFormat.FormatString = "#,##0.00";
            //gridView2.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView2.Columns["colDelete"].Caption = string.Empty;
            gridView2.BestFitColumns();

            //TotalRate_Calculating_ce();
        }

    }
}