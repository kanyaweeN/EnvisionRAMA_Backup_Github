using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Envision.NET.Forms.ResultEntry.Common;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessUpdate;
using DevExpress.XtraEditors.Repository;
using Miracle.Util;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;

namespace Envision.NET.Forms.Admin
{
    public partial class frmReporManagementFilterSetup : Envision.NET.Forms.Main.MasterForm
    {
        private DataTable dttWL, dttFilterMode;
        private MyMessageBox msg;
        private GBLEnvVariable env;
        private string ModeFilter { get; set; }

        public frmReporManagementFilterSetup()
        {
            InitializeComponent();
        }
        private void setRibbonControls(bool is_saveMode)
        {
            rbbEditFilterName.Visible = !is_saveMode;
            rbbFilterColumns.Visible = !is_saveMode;
            rbbSave.Visible = is_saveMode;
            rbbBack.Visible = is_saveMode;
        }
        private void frmReporManagementFilterSetup_Load(object sender, EventArgs e)
        {
            setRibbonControls(false);
            grdFilterMode.Enabled = false;
            grdWL.Enabled = false;
            layoutFilter.Enabled = false;
            ModeFilter = "None";

            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            dttWL = new DataTable();
            dttFilterMode = new DataTable();
            Envision.BusinessLogic.ResultEntry result = new Envision.BusinessLogic.ResultEntry();
            result.RISExamresult.FROM_DATE = DateTime.Now;
            result.RISExamresult.TO_DATE = DateTime.Now;
            result.RISExamresult.MODE = 99;
            dttWL = result.GetWorkList();
            dttWL.Columns.Add("ScanImage");

            grdWL.DataSource = dttWL;
            setGridColumnWL();
            initLocFilter(true);
            initOrderingDepartment();
            initExamType();

            base.CloseWaitDialog();
        }
        private void initOrderingDepartment()
        {
            ccbOrderingDept.Properties.Items.Clear();
            ProcessGetHRUnit get = new ProcessGetHRUnit();
            get.Invoke_forRadiologistWorklist();
            DataTable dt = get.Result.Tables[0];

            ccbOrderingDept.Properties.DataSource = dt;
            ccbOrderingDept.Properties.DisplayMember = "UNIT_UID";
            ccbOrderingDept.Properties.ValueMember = "UNIT_ID";

        }
        private void initExamType()
        {
            ccbExamType.Properties.Items.Clear();
            ProcessGetRISExamType get = new ProcessGetRISExamType();
            get.Invoke();
            DataTable dt = get.Result.Tables[0];

            ccbExamType.Properties.DataSource = dt;
            ccbExamType.Properties.DisplayMember = "EXAM_TYPE_TEXT";
            ccbExamType.Properties.ValueMember = "EXAM_TYPE_ID";


        }
        private void setGridColumnWL()
        {
            #region column edit

            //for (int i = 0; i < dttWL.Columns.Count; i++)
            //    view1.Columns[i].Visible = false;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
                repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 3, 8)});
            repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            repositoryItemImageComboBox2.SmallImages = imgWL;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;


            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkTemplate.ValueChecked = "Y";
            chkTemplate.ValueUnchecked = "N";
            chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
                linkScanImage = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            linkScanImage.Image = imgSmall.Images[22];
            linkScanImage.TextEditStyle = TextEditStyles.DisableTextEditor;
            linkScanImage.ImageAlignment = HorzAlignment.Center;


            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repComment = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repComment.AutoHeight = false;
            repComment.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","Y",9)
            });
            repComment.Name = "repComment";
            repComment.SmallImages = imgWL;
            repComment.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            #endregion column edit


            view1.OptionsSelection.EnableAppearanceFocusedCell = false;

            view1.Columns["CHK"].ColVIndex = 1;
            view1.Columns["CHK"].Caption = " ";
            //view1.Columns["CHK"].Visible = true;
            view1.Columns["CHK"].ColumnEdit = chkTemplate;
            view1.Columns["CHK"].Width = -1;

            view1.Columns["HAS_COMMENT"].Caption = " ";
            view1.Columns["HAS_COMMENT"].ColVIndex = 2;
            view1.Columns["HAS_COMMENT"].ColumnEdit = repComment;
            view1.Columns["HAS_COMMENT"].Width = -1;
            view1.Columns["HAS_COMMENT"].OptionsColumn.ReadOnly = true;
            view1.Columns["HAS_COMMENT"].OptionsColumn.AllowEdit = true;
            view1.Columns["HAS_COMMENT"].Visible = true;

            view1.Columns["ScanImage"].ColVIndex = 3;
            view1.Columns["ScanImage"].ColumnEdit = linkScanImage;
            view1.Columns["ScanImage"].Caption = " ";
            //view1.Columns["ScanImage"].Visible = true;
            view1.Columns["ScanImage"].Width = -1;
            view1.Columns["ScanImage"].OptionsColumn.ReadOnly = false;
            view1.Columns["ScanImage"].OptionsColumn.AllowEdit = true;
            //view1.Columns["ScanImage"].ToolTip = "View Scanned Image";

            view1.Columns["PATIENT_ID_LABEL"].ColVIndex = 4;
            view1.Columns["PATIENT_ID_LABEL"].Caption = " ";
            view1.Columns["PATIENT_ID_LABEL"].OptionsColumn.ReadOnly = true;
            view1.Columns["PATIENT_ID_LABEL"].OptionsColumn.AllowEdit = false;

            view1.Columns["PRIORITY_ID"].ColVIndex = 5;
            view1.Columns["PRIORITY_ID"].ColumnEdit = repositoryItemImageComboBox2;
            view1.Columns["PRIORITY_ID"].Caption = "Priority";
            //view1.Columns["PRIORITY_ID"].Visible = true;
            view1.Columns["PRIORITY_ID"].OptionsColumn.ReadOnly = true;
            view1.Columns["PRIORITY_ID"].OptionsColumn.AllowEdit = false;

            view1.Columns["STATUS"].ColVIndex = 6;
            view1.Columns["STATUS"].Caption = "Status";
            //view1.Columns["STATUS"].Visible = true;
            view1.Columns["STATUS"].OptionsColumn.ReadOnly = true;
            view1.Columns["STATUS"].OptionsColumn.AllowEdit = false;

            view1.Columns["TIMEDIFF"].ColVIndex = 7;
            view1.Columns["TIMEDIFF"].Caption = "Waiting Time";
            //view1.Columns["TIMEDIFF"].Visible = true;
            view1.Columns["TIMEDIFF"].OptionsColumn.ReadOnly = true;
            view1.Columns["TIMEDIFF"].OptionsColumn.AllowEdit = false;

            view1.Columns["ORDER_DT"].ColVIndex = 8;
            view1.Columns["ORDER_DT"].Caption = "Order Time";
            //view1.Columns["ORDER_DT"].Visible = true;
            view1.Columns["ORDER_DT"].DisplayFormat.FormatString = "G";
            view1.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view1.Columns["ORDER_DT"].Width = 73;
            view1.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
            view1.Columns["ORDER_DT"].OptionsColumn.AllowEdit = false;

            view1.Columns["HN"].ColVIndex = 9;
            view1.Columns["HN"].Caption = "HN";
            //view1.Columns["HN"].Visible = true;
            view1.Columns["HN"].OptionsColumn.ReadOnly = true;
            view1.Columns["HN"].OptionsColumn.AllowEdit = false;
            //view1.Columns["HN"].ToolTip = "HN";

            view1.Columns["PatientName"].ColVIndex = 10;
            view1.Columns["PatientName"].Caption = "Patient Name";
            //view1.Columns["PatientName"].Visible = true;
            view1.Columns["PatientName"].OptionsColumn.ReadOnly = true;
            view1.Columns["PatientName"].OptionsColumn.AllowEdit = false;

            view1.Columns["AGE"].ColVIndex = 11;
            view1.Columns["AGE"].Caption = "Age";
            //view1.Columns["AGE"].Visible = true;
            view1.Columns["AGE"].OptionsColumn.ReadOnly = true;
            view1.Columns["AGE"].OptionsColumn.AllowEdit = false;

            view1.Columns["ACCESSION_NO"].ColVIndex = 12;
            view1.Columns["ACCESSION_NO"].Caption = "Accession No";
            //view1.Columns["ACCESSION_NO"].Visible = true;
            view1.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;
            view1.Columns["ACCESSION_NO"].OptionsColumn.AllowEdit = false;

            view1.Columns["EXAM_NAME"].ColVIndex = 13;
            view1.Columns["EXAM_NAME"].Caption = "Exam Name";
            //view1.Columns["EXAM_NAME"].Visible = true;
            view1.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            view1.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;

            view1.Columns["BPVIEW_NAME"].ColVIndex = 14;
            view1.Columns["BPVIEW_NAME"].Caption = "Side";
            view1.Columns["BPVIEW_NAME"].Visible = true;
            view1.Columns["BPVIEW_NAME"].OptionsColumn.ReadOnly = true;
            view1.Columns["BPVIEW_NAME"].OptionsColumn.AllowEdit = false;

            view1.Columns["Radiologist"].ColVIndex = 15;
            view1.Columns["Radiologist"].Caption = "Radiologist";
            //view1.Columns["Radiologist"].Visible = true;
            view1.Columns["Radiologist"].OptionsColumn.ReadOnly = true;
            view1.Columns["Radiologist"].OptionsColumn.AllowEdit = false;

            view1.Columns["RESULT_MODIFIED_BY"].ColVIndex = 16;
            view1.Columns["RESULT_MODIFIED_BY"].Caption = "Last Modified by.";
            //view1.Columns["RESULT_MODIFIED_BY"].Visible = true;
            view1.Columns["RESULT_MODIFIED_BY"].OptionsColumn.ReadOnly = true;
            view1.Columns["RESULT_MODIFIED_BY"].OptionsColumn.AllowEdit = false;

            view1.Columns["Unit"].ColVIndex = 17;
            view1.Columns["Unit"].Caption = "Ordering Dept.";
            //view1.Columns["Unit"].Visible = true;
            view1.Columns["Unit"].OptionsColumn.ReadOnly = true;
            view1.Columns["Unit"].OptionsColumn.AllowEdit = false;

            view1.Columns["CLINIC_TYPE_TEXT"].ColVIndex = 18;
            view1.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
            //view1.Columns["CLINIC_TYPE_TEXT"].Visible = true;
            view1.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.ReadOnly = true;
            view1.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.AllowEdit = false;

            view1.Columns["EXAM_UID"].ColVIndex = 19;
            view1.Columns["EXAM_UID"].Caption = "Exam Code";
            //view1.Columns["EXAM_UID"].Visible = true;
            view1.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            view1.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;

            view1.Columns["ORDER_ID"].Caption = "Order No";
            view1.Columns["ORDER_ID"].Visible = false;
            view1.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;
            view1.Columns["ORDER_ID"].OptionsColumn.AllowEdit = false;

            view1.Columns["XRAY_NO"].Caption = "Xray No.";
            view1.Columns["XRAY_NO"].Visible = false;
            view1.Columns["XRAY_NO"].OptionsColumn.ReadOnly = true;
            view1.Columns["XRAY_NO"].OptionsColumn.AllowEdit = false;

            view1.Columns["PRIORITY"].Caption = " ";
            view1.Columns["PRIORITY"].Visible = false;
            view1.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;
            view1.Columns["PRIORITY"].OptionsColumn.AllowEdit = false;

            view1.Columns["S"].Caption = "S";
            view1.Columns["S"].Visible = false;
            view1.Columns["S"].OptionsColumn.ReadOnly = true;
            view1.Columns["S"].OptionsColumn.AllowEdit = false;

            view1.Columns["EXAM_ID"].Caption = "EXAM_ID";
            view1.Columns["EXAM_ID"].Visible = false;
            view1.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;
            view1.Columns["EXAM_ID"].OptionsColumn.AllowEdit = false;

            view1.Columns["ASSIGNED_TO"].Caption = "ASSIGNED_TO";
            view1.Columns["ASSIGNED_TO"].Visible = false;
            view1.Columns["ASSIGNED_TO"].OptionsColumn.ReadOnly = true;
            view1.Columns["ASSIGNED_TO"].OptionsColumn.AllowEdit = false;

            view1.Columns["MERGE"].Caption = "MERGE";
            view1.Columns["MERGE"].Visible = false;
            view1.Columns["MERGE"].OptionsColumn.ReadOnly = true;
            view1.Columns["MERGE"].OptionsColumn.AllowEdit = false;

            view1.Columns["MERGE_WITH"].Caption = "MERGE_WITH";
            view1.Columns["MERGE_WITH"].Visible = false;
            view1.Columns["MERGE_WITH"].OptionsColumn.ReadOnly = true;
            view1.Columns["MERGE_WITH"].OptionsColumn.AllowEdit = false;

            view1.Columns["Favorite"].Caption = "Favorite";
            view1.Columns["Favorite"].Visible = false;
            view1.Columns["Favorite"].OptionsColumn.ReadOnly = true;
            view1.Columns["Favorite"].OptionsColumn.AllowEdit = false;

            view1.Columns["Teaching"].Caption = "Teaching";
            view1.Columns["Teaching"].Visible = false;
            view1.Columns["Teaching"].OptionsColumn.ReadOnly = true;
            view1.Columns["Teaching"].OptionsColumn.AllowEdit = false;

            view1.Columns["Other"].Caption = "Other";
            view1.Columns["Other"].Visible = false;
            view1.Columns["Other"].OptionsColumn.ReadOnly = true;
            view1.Columns["Other"].OptionsColumn.AllowEdit = false;

            view1.Columns["NO_OF_IMAGES"].ColVIndex = 19;
            view1.Columns["NO_OF_IMAGES"].Caption = "Number of Images";
            //view1.Columns["EXAM_UID"].Visible = true;
            view1.Columns["NO_OF_IMAGES"].OptionsColumn.ReadOnly = true;
            view1.Columns["NO_OF_IMAGES"].OptionsColumn.AllowEdit = false;

            #region Set font style.
            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Finalized");
            stylCon5.Appearance.ForeColor = Color.Green;

            //Prelim(T)
            DevExpress.XtraGrid.StyleFormatCondition stylCon6
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Prelim(T)");
            stylCon6.Appearance.ForeColor = Color.Goldenrod;

            //Draft(T)
            DevExpress.XtraGrid.StyleFormatCondition stylCon7
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Draft(T)");
            stylCon7.Appearance.ForeColor = Color.Goldenrod;

            //Finalize(T)
            DevExpress.XtraGrid.StyleFormatCondition stylCon8
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Finalized(T)");
            stylCon8.Appearance.ForeColor = Color.Green;

            //Locked
            DevExpress.XtraGrid.StyleFormatCondition stylCon9
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Locked");
            stylCon9.Appearance.ForeColor = Color.Blue;

            //Rejected
            DevExpress.XtraGrid.StyleFormatCondition stylCon10
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Rejected");
            stylCon10.Appearance.ForeColor = Color.DarkViolet;

            //Repeated
            DevExpress.XtraGrid.StyleFormatCondition stylCon11
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Repeated");
            stylCon11.Appearance.ForeColor = Color.Violet;

            //Rejected(T)
            DevExpress.XtraGrid.StyleFormatCondition stylCon12
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Rejected(T)");
            stylCon12.Appearance.ForeColor = Color.DarkViolet;

            //Repeated(T)
            DevExpress.XtraGrid.StyleFormatCondition stylCon13
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Repeated(T)");
            stylCon13.Appearance.ForeColor = Color.Violet;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon14
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Complete(T)");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Locked
            DevExpress.XtraGrid.StyleFormatCondition stylCon15
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Short Prelim");
            stylCon15.Appearance.ForeColor = Color.Blue;

            //Locked
            DevExpress.XtraGrid.StyleFormatCondition stylCon16
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Short Prelim(T)");
            stylCon16.Appearance.ForeColor = Color.Blue;

            view1.FormatConditions.Clear();
            view1.FormatConditions.AddRange
                (new DevExpress.XtraGrid.StyleFormatCondition[] 
                    { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5
                        , stylCon6, stylCon7, stylCon8, stylCon9, stylCon10
                        , stylCon11, stylCon12, stylCon13, stylCon14 
                        , stylCon15, stylCon16});
            #endregion

            //if (rad.WORKLIST_GRID_ORDER.Length > 0)
            //{
            //    DataSet getXML = new DataSet();
            //    System.IO.MemoryStream mem = null;
            //    try
            //    {
            //        char[] chr = rad.WORKLIST_GRID_ORDER.ToCharArray();
            //        byte[] data = new byte[chr.Length];
            //        for (int i = 0; i < chr.Length; i++)
            //            data[i] = (byte)chr[i];
            //        mem = new System.IO.MemoryStream(data);

            //        getXML.ReadXml(mem);
            //        for (int j = 0; j < getXML.Tables[0].Rows.Count; j++)
            //        {
            //            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Width = Convert.ToInt32(getXML.Tables[0].Rows[j][1]);
            //            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Visible = Convert.ToBoolean(getXML.Tables[0].Rows[j][2]);
            //            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].ColVIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][3]);
            //            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].GroupIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][4]);
            //            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].AbsoluteIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][5]);
            //            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].VisibleIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][6]);
            //        }
            //        mem.Dispose();
            //    }
            //    catch
            //    { }
            //}
            //else
            //{
            //    getXMLGridWorklist();
            //    rad.WORKLIST_GRID_ORDER = XMLWorklist;
            //}
            //chkFirstSetGridWL = false;
        }
        private void initLocFilter(bool is_Delete)
        {
            ProcessGetRISExamresultFilterworklist filterData = new ProcessGetRISExamresultFilterworklist();
            filterData.Invoke();
            dttFilterMode = filterData.Result.Tables[0];
            dttFilterMode.Columns.Add("Del");

            grdFilterMode.DataSource = dttFilterMode;

            for (int i = 0; i < viewFilterMode.Columns.Count; i++)
                viewFilterMode.Columns[i].Visible = false;

            viewFilterMode.Columns["FILTER_NAME"].Caption = "Filter Unit";
            viewFilterMode.Columns["FILTER_NAME"].Visible = true;
            viewFilterMode.Columns["FILTER_NAME"].OptionsColumn.ReadOnly = is_Delete ? false : true;
            viewFilterMode.Columns["FILTER_NAME"].OptionsColumn.AllowEdit = is_Delete ? true : false;
            viewFilterMode.Columns["FILTER_NAME"].OptionsColumn.AllowFocus = !is_Delete ? false : true;

            if (is_Delete)
            {
                RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
                btn.AutoHeight = false;
                btn.BestFitWidth = 9;
                btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
                btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                btn.Buttons[0].Caption = string.Empty;
                btn.Click += new EventHandler(btnDeleteRow_Click);
                viewFilterMode.Columns["Del"].Caption = string.Empty;
                viewFilterMode.Columns["Del"].ColumnEdit = btn;
                viewFilterMode.Columns["Del"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                viewFilterMode.Columns["Del"].Width = 10;
                viewFilterMode.Columns["Del"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                viewFilterMode.Columns["Del"].Visible = true;
            }

        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (viewFilterMode.FocusedRowHandle >= 0)
            {
                DataRow row = viewFilterMode.GetDataRow(viewFilterMode.FocusedRowHandle);
                ProcessDeleteRISExamresultFilterworklist del = new ProcessDeleteRISExamresultFilterworklist();
                del.RIS_EXAMRESULT_FILTERWORKLIST.FILTER_ID = Convert.ToInt32(row["FILTER_ID"]);
                del.Invoke();

                initLocFilter(true);
            }
        }
        private void btnEditFilterMode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModeFilter = "EditFilterMode";
            setRibbonControls(true);

            grdFilterMode.Enabled = true;
            grdWL.Enabled = false;
            layoutFilter.Enabled = false;
        }
        private void btnEditFilterColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModeFilter = "EditFilterColumns";
            setRibbonControls(true);

            grdFilterMode.Enabled = true;
            grdWL.Enabled = true;
            layoutFilter.Enabled = true;
            initLocFilter(false);

            if (viewFilterMode.FocusedRowHandle < 0)
                view1.ActiveFilterString = "";
            else
            {
                setFilterControls();
            }
        }
        private void btnBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModeFilter = "Back";
            setRibbonControls(false);

            grdFilterMode.Enabled = false;
            grdWL.Enabled = false;
            layoutFilter.Enabled = false;

            initLocFilter(true);
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ProcessUpdateRISExamresultFilterworklist update = new ProcessUpdateRISExamresultFilterworklist();
            ProcessAddRISExamresultFilterworklist create = new ProcessAddRISExamresultFilterworklist();
            switch (ModeFilter)
            {
                case "EditFilterMode":

                    DataTable dtFilteMode = (DataTable)grdFilterMode.DataSource;
                    for (int i = 0; i < dtFilteMode.Rows.Count; i++)
                    {
                        int _filter_id = string.IsNullOrEmpty(dtFilteMode.Rows[i]["FILTER_ID"].ToString()) ? 0 : Convert.ToInt32(dtFilteMode.Rows[i]["FILTER_ID"]);
                        if (_filter_id == 0)
                        {
                            create.RIS_EXAMRESULT_FILTERWORKLIST.FILTER_NAME = dtFilteMode.Rows[i]["FILTER_NAME"].ToString();
                            create.RIS_EXAMRESULT_FILTERWORKLIST.FILTER_DETAIL = dtFilteMode.Rows[i]["FILTER_DETAIL"].ToString();
                            create.RIS_EXAMRESULT_FILTERWORKLIST.CRAETED_BY = env.UserID;
                            create.Invoke();
                        }
                        else
                        {
                            update.RIS_EXAMRESULT_FILTERWORKLIST.FILTER_ID = _filter_id;
                            update.RIS_EXAMRESULT_FILTERWORKLIST.FILTER_NAME = dtFilteMode.Rows[i]["FILTER_NAME"].ToString();
                            update.RIS_EXAMRESULT_FILTERWORKLIST.FILTER_DETAIL = dtFilteMode.Rows[i]["FILTER_DETAIL"].ToString();
                            update.RIS_EXAMRESULT_FILTERWORKLIST.LAST_MODIFIED_BY = env.UserID;
                            update.Invoke();
                        }
                    }
                    break;
                case "EditFilterColumns":
                    if (viewFilterMode.FocusedRowHandle < 0) return;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("EXAM_TYPE");
                    dt.Columns.Add("REF_UNIT");
                    dt.Columns.Add("FILTER_COLUMNS");
                    dt.AcceptChanges();
                    dt.Rows.Add(
                        string.IsNullOrEmpty(ccbExamType.EditValue.ToString()) ? "" : ccbExamType.EditValue.ToString(),
                        string.IsNullOrEmpty(ccbOrderingDept.EditValue.ToString()) ? "" : ccbOrderingDept.EditValue.ToString(),
                        view1.ActiveFilterString);
                    dt.AcceptChanges();
                    dt.TableName = "Filter";
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.AcceptChanges();

                    DataRow rows = viewFilterMode.GetDataRow(viewFilterMode.FocusedRowHandle);
                    update.RIS_EXAMRESULT_FILTERWORKLIST.FILTER_ID = string.IsNullOrEmpty(rows["FILTER_ID"].ToString()) ? 0 : Convert.ToInt32(rows["FILTER_ID"]);
                    update.RIS_EXAMRESULT_FILTERWORKLIST.FILTER_NAME = rows["FILTER_NAME"].ToString();
                    update.RIS_EXAMRESULT_FILTERWORKLIST.FILTER_DETAIL = ds.GetXml();
                    update.RIS_EXAMRESULT_FILTERWORKLIST.LAST_MODIFIED_BY = env.UserID;
                    update.Invoke();
                    break;
            }

            ModeFilter = "None";
            setRibbonControls(false);

            grdFilterMode.Enabled = false;
            grdWL.Enabled = false;
            layoutFilter.Enabled = false;
            initLocFilter(true);
        }

        private void setFilterControls()
        {
            DataRow rows = viewFilterMode.GetDataRow(viewFilterMode.FocusedRowHandle);
            if (!string.IsNullOrEmpty(rows["FILTER_DETAIL"].ToString()))
            {
                DataSet getXML = new DataSet();
                System.IO.MemoryStream mem = null;
                char[] chr = rows["FILTER_DETAIL"].ToString().ToCharArray();
                byte[] data = new byte[chr.Length];
                for (int i = 0; i < chr.Length; i++)
                    data[i] = (byte)chr[i];
                mem = new System.IO.MemoryStream(data);

                getXML.ReadXml(mem);

                if (Utilities.IsHaveData(getXML))
                {
                    ccbExamType.EditValue = getXML.Tables[0].Rows[0]["EXAM_TYPE"].ToString();
                    ccbExamType.RefreshEditValue();
                    ccbOrderingDept.EditValue = getXML.Tables[0].Rows[0]["REF_UNIT"].ToString();
                    ccbOrderingDept.RefreshEditValue();
                    view1.ActiveFilterString = getXML.Tables[0].Rows[0]["FILTER_COLUMNS"].ToString();
                }
            }
            else
                view1.ActiveFilterString = "";
        }
        private void viewFilterMode_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (viewFilterMode.FocusedRowHandle < 0) return;
            if (ModeFilter == "EditFilterColumns")
            {
                setFilterControls();
            }
        }
    }
}