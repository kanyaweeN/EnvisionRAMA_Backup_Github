using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Threading;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessUpdate;
using System.Data.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic;
using Envision.Operational.PACS;
using Envision.Operational.Translator;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using Envision.Common.Common;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using Miracle.Util;
using Miracle.MultiTimesCheckClick;
using Envision.Common;
using Envision.WebService;
using System.Configuration;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace Envision.NET.Forms.Orders
{
    public partial class frmConfirmArrivalWorkList : Envision.NET.Forms.Main.MasterForm//: DevExpress.XtraEditors.XtraForm
    {
        private int selectedOrderId = 0;
        private int selectedScheduleId = 0;
        private int selectedOrgId = 1;
        private int insuranceId = 0;
        private string aadmissionNo = string.Empty;
        private bool canEditExamDatetime;
        private DataTable dtPatientDemographic;
        private DataTable dtCasesInfo;
        private DataTable dttExamFlag, dtExamFlagDTL;
        private SendToPacs sendToPacs;
        private Color bkBackColor = Color.Empty;

        private DataTable dtRefUnit = RISBaseData.His_Department();
        private DataTable dtRefDoc = RISBaseData.His_Doctor();
        private DataTable dtExam = RISBaseData.Ris_Exam();
        private DataTable dtClinic = RISBaseData.RIS_ClinicType();

        private MyMessageBox messageBox;
        private Envision.Common.GBLEnvVariable gblenv;
        private RepositoryItemLookUpEdit repBpview = new RepositoryItemLookUpEdit();

        #region Title Name DataSource
        // Thai Title name
        public string[] TitleThaiName = new string[]
        { 
            "นาย",
            "นางสาว",
            "น.ส.",
            "นาง",
            "ด.ช.",
            "ด.ญ.",
            "บาทหลวง",
            "แม่ชี",
            "พระ",
            "หม่อมราชวงศ์",
            "หม่อมหลวง",
            "รองศาสตราจารย์",
            "ผู้ช่วยศาสตราจารย์",
            "พล.อ.อ.",
            "พล.อ.ท.",
            "พล.อ.ต.",
            "น.อ.",
            "น.ท.",
            "น.ต.",
            "ร.อ.",
            "ร.ท.",
            "ร.ต.",
            "พ.อ.อ.",
            "พ.จ.ท.",
            "พ.อ.ต.",
            "จ.อ.",
            "จ.ท.",
            "จ.ต.",
            "พลฯ",
            "พล.อ.",
            "พล.ท.",
            "พล.ต.",
            "พ.อ.",
            "พ.ท.",
            "พ.ต.",
            "ร.อ.",
            "ร.ท.",
            "ร.ต.",
            "จ.ส.อ.",
            "จ.ส.ท.",
            "จ.ส.ต.",
            "ส.อ.",
            "ส.ท.",
            "ส.ต.",
            "พลฯ",
            "พล.ร.อ.",
            "พล.ร.ท.",
            "พล.ร.ต.",
            "น.อ...ร.น.",
            "น.ท...ร.น.",
            "น.ต...ร.น.",
            "ร.อ...ร.น.",
            "ร.ท...ร.น.",
            "ร.ต...ร.น.",
            "พ.จ.อ.",
            "พ.จ.ท.",
            "พ.จ.ต.",
            "จ.อ.",
            "จ.ท.",
            "จ.ต.",
            "พลฯ",
            "พล.ต.อ.",
            "พล.ต.ท.",
            "พล.ต.ต.",
            "พ.ต.อ.",
            "พ.ต.ท.",
            "พ.ต.ต.",
            "ร.ต.อ.",
            "ร.ต.ท.",
            "ร.ต.ต.",
            "ด.ต.",
            "จ.ส.อ.",
            "ส.ต.อ.",
            "ส.ต.ท.",
            "ส.ต.ต.",
            "พลตำรวจ",
        };
        // Eng Title name
        public string[] TitleEngName = new string[]
        { 
            "Mr.",
            "Ms.",
            "Ms.",
            "Mrs.",
            "Boy",
            "Girl",
            "Fr.",
            "Sis.",
            "Monk",
            "M R",
            "M L", 
            "Assoc P.",
            "Assist Pro.",
            "ACM",
            "AM", 
            "AVM", 
            "GP CAPT",
            "WG CDR",
            "SON LDR",
            "FLT LT",
            "FLG OFF",
            "PLT OFF",
            "FS 1",
            "FS 2",
            "FS 3",
            "SGT",
            "CPL", 
            "LAC",
            "AMN",
            "GEN", 
            "LT GEN", 
            "MAJ GEN",
            "COL", 
            "LT COL", 
            "MAJ",
            "CAPT",
            "LT",
            "SUB KT",
            "SM 1",
            "SM 2",
            "SM 3",
            "PFC",
            "CPL",
            "PFC",
            "PVT",
            "ADM", 
            "V ADM",
            "R AVM",
            "CAPT",
            "CDR",
            "L CDR",
            "LT",
            "LT JG", 
            "SUB LT",
            "CPO 1",
            "CPO 2",
            "CPO 3",
            "PO 1",
            "PO 2",
            "PO 3",
            "SEA-MAN",
            "POL GEN",
            "POL LT GEN", 
            "POL MAL GEN",
            "POL COL",
            "POL LT COL", 
            "POL MAL",
            "POL CAPT",
            "POL LT",
            "POL SUB LT",
            "POL SEN SGT MAJ", 
            "POL SM",
            "POL SGT",
            "POL CPL",
            "POL PFC",
            "POL PVT",         
        };
        #endregion

        public frmConfirmArrivalWorkList()
        {
            InitializeComponent();
        }
        public frmConfirmArrivalWorkList(int order_Id, int schedule_id, int org_id)
        {
            InitializeComponent();
            this.selectedOrderId = order_Id; // back up order id
            this.selectedScheduleId = schedule_id; // back up order id
            this.selectedOrgId = org_id; // back up org id
        }
        private void frmConfirmArrivalWorkList_Load(object sender, EventArgs e)
        {
            this.messageBox = new MyMessageBox();
            this.gblenv = new Envision.Common.GBLEnvVariable();
            this.gblenv.ErrorForm = base.Menu_Name_Class;

            dtPatientDemographic = new DataTable();
            dtCasesInfo = new DataTable();
            DataSet dsSource = new DataSet();

            SetControl();
            this.SetupEditor();
            this.SetUpLastOrderGrid();

            this.txtHN.Focus();
            // Get Xray order info.

            if (this.selectedOrderId == 0)
            {
                ProcessGetRISScheduleInfo processGetRISScheduleInfo = new ProcessGetRISScheduleInfo();
                processGetRISScheduleInfo.SCHEDULE_ID = this.selectedScheduleId;
                processGetRISScheduleInfo.ORG_ID = this.selectedOrgId;
                processGetRISScheduleInfo.Invoke();
                dsSource = processGetRISScheduleInfo.Result;
                canEditExamDatetime = false;
                setTrauma(this.selectedScheduleId, true);
            }
            else
            {
                ProcessGetXrayOrderInfo processGetXrayOrderInfo = new ProcessGetXrayOrderInfo();
                processGetXrayOrderInfo.ORDER_ID = this.selectedOrderId;
                processGetXrayOrderInfo.ORG_ID = this.selectedOrgId;
                processGetXrayOrderInfo.Invoke();
                dsSource = processGetXrayOrderInfo.Result;
                canEditExamDatetime = true;
                setTrauma(this.selectedOrderId, false);
            }
            if (dsSource != null)
                if (dsSource.Tables.Count > 1)
                {
                    dtPatientDemographic = dsSource.Tables[0].Copy(); // copy to gbl datatable
                    dtCasesInfo = dsSource.Tables[1].Copy();

                    UpdateHISRegistration();

                    this.BindingData();
                    //Binding last order to grid
                    this.BindingLastOrderGrid();
                }
            setTemplateBillingLog();
            base.CloseWaitDialog();
            checkAllergies();
        }
        private void setColumnsExamList()
        {

            for (int i = 0; i < viewExamList.Columns.Count; i++)
            {
                viewExamList.Columns[i].Visible = false;
                viewExamList.Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            }

            #region Preparing option
            // priority
            DataTable dtPriority = Envision.BusinessLogic.RISBaseData.Ris_Priority();
            RepositoryItemLookUpEdit repPriority = new RepositoryItemLookUpEdit();
            repPriority.Buttons.Clear();
            repPriority.DataSource = dtPriority;
            repPriority.DisplayMember = "PRIORITY";
            repPriority.ValueMember = "PRI_ID";
            repPriority.AutoHeight = true;
            repPriority.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(repPriority_CloseUp);
            repPriority.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PRIORITY", "Priority"));

            DataTable dtModality = Envision.BusinessLogic.RISBaseData.Ris_Modality();
            RepositoryItemGridLookUpEdit repModality = new RepositoryItemGridLookUpEdit();
            repModality.DataSource = dtModality;
            repModality.DisplayMember = "MODALITY_NAME";
            repModality.ValueMember = "MODALITY_ID";
            repModality.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(_repModality_CloseUp);
            //_repModality.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MODALITY_NAME", "Modality"));
            foreach (GridColumn col in repModality.View.Columns)
                col.Visible = false;
            repModality.View.Columns["MODALITY_NAME"].Visible = true;
            repModality.View.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            repModality.View.Columns["MODALITY_NAME"].Caption = "Modality";

            // exam datetime
            RepositoryItemDateEdit repDateEdit = new RepositoryItemDateEdit();
            repDateEdit.MinValue = DateTime.Today;
            repDateEdit.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(_repDateEdit_CloseUp);

            // clinic
            RepositoryItemGridLookUpEdit repClinic = new RepositoryItemGridLookUpEdit();
            repClinic.DataSource = Envision.BusinessLogic.RISBaseData.RIS_ClinicType();
            repClinic.DisplayMember = "CLINIC_TYPE_TEXT";
            repClinic.ValueMember = "CLINIC_TYPE_ID";
            foreach (GridColumn col in repClinic.View.Columns)
                col.Visible = false;
            repClinic.View.Columns["CLINIC_TYPE_TEXT"].Visible = true;
            repClinic.View.Columns["CLINIC_TYPE_TEXT"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            repClinic.View.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic Type";
            repClinic.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(_repClinic_CloseUp);

            // assign to
            RepositoryItemGridLookUpEdit cmbGRa = new RepositoryItemGridLookUpEdit();
            cmbGRa.DataSource = Envision.BusinessLogic.RISBaseData.Ris_Radiologist();
            cmbGRa.DisplayMember = "UIDAndRadioName";
            cmbGRa.ValueMember = "EMP_ID";
            cmbGRa.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(cmbGRa_CloseUp);
            cmbGRa.NullText = "";
            cmbGRa.View.Columns["EMP_ID"].Visible = false;
            cmbGRa.View.Columns["EMP_UID"].Visible = false;
            cmbGRa.View.Columns["RadioName"].Visible = false;
            cmbGRa.View.Columns["AUTH_LEVEL_ID"].Visible = false;
            cmbGRa.View.Columns["ALLOW_OTHERS_TO_FINALIZE"].Visible = false;
            cmbGRa.View.Columns["RadioNameEng"].Visible = false;
            cmbGRa.View.Columns["UIDAndRadioName"].Visible = true;
            cmbGRa.View.Columns["UIDAndRadioName"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cmbGRa.View.Columns["UIDAndRadioName"].Caption = "Radiologist";

            // bpview
            repBpview.Buttons.Clear();
            repBpview.ImmediatePopup = true;
            repBpview.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repBpview.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repBpview.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BPVIEW_NAME", "Sides", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repBpview.DataSource = RISBaseData.BP_View();
            repBpview.DisplayMember = "BPVIEW_NAME";
            repBpview.ValueMember = "BPVIEW_ID";
            repBpview.NullText = string.Empty;
            repBpview.AutoHeight = true;
            repBpview.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(repBpview_CloseUp);

            //QTY
            RepositoryItemSpinEdit spe = new RepositoryItemSpinEdit();
            spe.Increment = 1;
            spe.MinValue = 1;
            spe.MaxValue = 100;
            spe.MaxLength = 100;
            spe.ValueChanged += new EventHandler(spe_ValueChanged);

            //Portable
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkPortable = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkPortable.ValueChecked = "Y";
            chkPortable.ValueUnchecked = "";
            chkPortable.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkPortable.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkPortable.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkPortable.Click += new EventHandler(chkPortable_Click);

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

            #endregion

            viewExamList.Columns["FLAG_ICON"].ColumnEdit = repFlag;
            viewExamList.Columns["FLAG_ICON"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExamList.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;
            viewExamList.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;
            viewExamList.Columns["FLAG_ICON"].Caption = " ";
            viewExamList.Columns["FLAG_ICON"].Width = -1;
            viewExamList.Columns["FLAG_ICON"].ColVIndex = 1;

            viewExamList.Columns["PRIORITY"].Caption = "Priority";
            viewExamList.Columns["PRIORITY"].ColVIndex = 2;
            viewExamList.Columns["PRIORITY"].Width = 55;
            viewExamList.Columns["PRIORITY"].ColumnEdit = repPriority;

            viewExamList.Columns["EXAM_UID"].Caption = "Exam Code";
            viewExamList.Columns["EXAM_UID"].ColVIndex = 3;
            viewExamList.Columns["EXAM_UID"].Width = 70;
            viewExamList.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;

            viewExamList.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewExamList.Columns["EXAM_NAME"].ColVIndex = 4;
            viewExamList.Columns["EXAM_NAME"].Width = 120;
            viewExamList.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;

            viewExamList.Columns["IS_PORTABLE"].Caption = "Port.";
            viewExamList.Columns["IS_PORTABLE"].ColVIndex = 5;
            viewExamList.Columns["IS_PORTABLE"].Width = 45;
            viewExamList.Columns["IS_PORTABLE"].ColumnEdit = chkPortable;

            viewExamList.Columns["MODALITY_ID"].Caption = "Modality";
            viewExamList.Columns["MODALITY_ID"].ColVIndex = 6;
            viewExamList.Columns["MODALITY_ID"].Width = 90;
            viewExamList.Columns["MODALITY_ID"].ColumnEdit = repModality;

            viewExamList.Columns["BPVIEW_ID"].Caption = "Side View";
            viewExamList.Columns["BPVIEW_ID"].ColVIndex = 7;
            viewExamList.Columns["BPVIEW_ID"].Width = 60;
            //viewExamList.Columns["BPVIEW_ID"].OptionsColumn.AllowEdit = false;
            viewExamList.Columns["BPVIEW_ID"].ColumnEdit = repBpview;

            viewExamList.Columns["QTY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExamList.Columns["QTY"].ColumnEdit = spe;
            viewExamList.Columns["QTY"].Caption = "Qty";
            viewExamList.Columns["QTY"].Width = 50;
            viewExamList.Columns["QTY"].ColVIndex = 8;
            viewExamList.Columns["QTY"].OptionsColumn.ReadOnly = true;

            viewExamList.Columns["EXAM_RATE"].Caption = "Rate";
            viewExamList.Columns["EXAM_RATE"].ColVIndex = 9;
            viewExamList.Columns["EXAM_RATE"].Width = 50;
            viewExamList.Columns["EXAM_RATE"].OptionsColumn.AllowEdit = false;


            viewExamList.Columns["EXAM_DT"].Caption = "Exam DateTime";
            viewExamList.Columns["EXAM_DT"].DisplayFormat.FormatString = "d";
            viewExamList.Columns["EXAM_DT"].ColVIndex = 10;
            viewExamList.Columns["EXAM_DT"].Width = 105;
            viewExamList.Columns["EXAM_DT"].ColumnEdit = repDateEdit;
            viewExamList.Columns["EXAM_DT"].OptionsColumn.AllowEdit = canEditExamDatetime;

            viewExamList.Columns["CLINIC_TYPE_ID"].Caption = "Clinic";
            viewExamList.Columns["CLINIC_TYPE_ID"].DisplayFormat.FormatString = "d";
            viewExamList.Columns["CLINIC_TYPE_ID"].ColVIndex = 11;
            viewExamList.Columns["CLINIC_TYPE_ID"].Width = 60;
            viewExamList.Columns["CLINIC_TYPE_ID"].ColumnEdit = repClinic;

            viewExamList.Columns["ASSIGN_TO"].Caption = "Radiologist";
            viewExamList.Columns["ASSIGN_TO"].DisplayFormat.FormatString = "d";
            viewExamList.Columns["ASSIGN_TO"].ColVIndex = 12;
            viewExamList.Columns["ASSIGN_TO"].Width = 95;
            viewExamList.Columns["ASSIGN_TO"].ColumnEdit = cmbGRa;

            viewExamList.Columns["ASSIGN_TO"].SummaryItem.FieldName = "RATE";
            viewExamList.Columns["ASSIGN_TO"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            viewExamList.Columns["ASSIGN_TO"].SummaryItem.DisplayFormat = "Total : {0}";
        }
        private void chkPortable_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = sender as DevExpress.XtraEditors.CheckEdit;
            DataTable dt = grdExamList.DataSource as DataTable;
            DataRow row = viewExamList.GetDataRow(viewExamList.FocusedRowHandle);
            DataTable dtPanelPortable = new DataTable();
            ProcessGetRISExam examPortable = new ProcessGetRISExam();
            dtPanelPortable = examPortable.GetExamPanelPortable(Convert.ToInt32(row["EXAM_ID"]), Convert.ToInt32(row["CLINIC_TYPE_ID"]));
            if (dtPanelPortable.Rows.Count <= 0)
            {
                row["IS_PORTABLE"] = "N";
                messageBox.ShowAlert("UID4052", gblenv.CurrentLanguageID);
                return;
            }
            if (!chk.Checked)
            {
                foreach (DataRow rows in dtPanelPortable.Rows)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp = dt.Clone();
                    dtTemp.Rows.Add(row.ItemArray);
                    dtTemp.AcceptChanges();
                    row["IS_PORTABLE"] = "Y";
                    DataTable dtExam = RISBaseData.Ris_Exam();
                    DataRow[] rowsExam = dtExam.Select("EXAM_ID=" + rows["AUTO_EXAM_ID"].ToString());

                    dtTemp.Rows[0]["EXAM_ID"] = rowsExam[0]["EXAM_ID"];
                    dtTemp.Rows[0]["EXAM_UID"] = rowsExam[0]["EXAM_UID"];
                    dtTemp.Rows[0]["EXAM_NAME"] = rowsExam[0]["EXAM_NAME"];

                    dtTemp.Rows[0]["FOREIGN_RATE"] = rowsExam[0]["FOREIGN_RATE"];
                    dtTemp.Rows[0]["FOREIGN_SPCIAL_RATE"] = rowsExam[0]["FOREIGN_SPCIAL_RATE"];
                    dtTemp.Rows[0]["FOREIGN_VIP_RATE"] = rowsExam[0]["FOREIGN_VIP_RATE"];

                    dtTemp.Rows[0]["RGL_RATE"] = rowsExam[0]["RATE"];
                    dtTemp.Rows[0]["SPECIAL_RATE"] = rowsExam[0]["SPECIAL_RATE"];
                    dtTemp.Rows[0]["VIP_RATE"] = rowsExam[0]["VIP_RATE"];


                    switch (row["CLINIC_TYPE_UID"].ToString())
                    {
                        case "Normal":
                            dtTemp.Rows[0]["ORDER_RATE"] =
                                dtTemp.Rows[0]["EXAM_RATE"] =
                                dtTemp.Rows[0]["RATE"] = chkNonResident.Checked ? rowsExam[0]["FOREIGN_RATE"] : rowsExam[0]["RATE"];
                            break;
                        case "Special":
                            dtTemp.Rows[0]["ORDER_RATE"] =
                                dtTemp.Rows[0]["EXAM_RATE"] =
                                dtTemp.Rows[0]["RATE"] = chkNonResident.Checked ? rowsExam[0]["FOREIGN_SPCIAL_RATE"] : rowsExam[0]["SPECIAL_RATE"];
                            break;
                        case "VIP":
                            dtTemp.Rows[0]["ORDER_RATE"] =
                                dtTemp.Rows[0]["EXAM_RATE"] =
                                dtTemp.Rows[0]["RATE"] = chkNonResident.Checked ? rowsExam[0]["FOREIGN_VIP_RATE"] : rowsExam[0]["VIP_RATE"];
                            break;
                        default:
                            break;
                    }

                    dt.Merge(dtTemp.Copy());
                }
            }
            else
            {
                row["IS_PORTABLE"] = "N";
                foreach (DataRow rows in dtPanelPortable.Rows)
                {
                    DataRow[] rowsExam = dt.Select("EXAM_ID=" + rows["AUTO_EXAM_ID"].ToString());
                    if (rowsExam.Length > 0)
                    {
                        dt.Rows.Remove(rowsExam[0]);
                        dt.AcceptChanges();
                    }
                }
            }
        }
        private void spe_ValueChanged(object sender, EventArgs e)
        {
            SpinEdit spe = new SpinEdit();
            spe = (SpinEdit)sender;
            DataRow dr = viewExamList.GetDataRow(viewExamList.FocusedRowHandle);
            int sp = Convert.ToInt32(spe.Value.ToString());
            if (sp > 0)
            {
                dr["QTY"] = sp;
                dr.AcceptChanges();
                calTotal();
            }
            else
            {
                dr["QTY"] = 0;
                dr.AcceptChanges();
                calTotal();
            }
        }
        private void SetupEditor()
        {
            //Title name 
            for (int i = 0; i < this.TitleThaiName.Length; i++)
            {
                this.cbThaiTitleName.Properties.Items.Add(this.TitleThaiName[i]);
                this.cbEngTitleName.Properties.Items.Add(this.TitleEngName[i]);
            }
            //Patient Status
            DataTable dtPatientStatus = Envision.BusinessLogic.RISBaseData.RIS_PatStatus();
            btePatientStatus.Properties.DisplayMember = "STATUS_TEXT";
            btePatientStatus.Properties.ValueMember = "STATUS_ID";
            btePatientStatus.Properties.AutoComplete = true;
            btePatientStatus.Properties.View.OptionsView.ShowAutoFilterRow = true;
            btePatientStatus.Properties.View.Columns.Clear();
            btePatientStatus.Properties.View.Columns.Add(new GridColumn() { Caption = "Status", FieldName = "STATUS_TEXT", Width = 80, VisibleIndex = 0 });
            btePatientStatus.Properties.DataSource = dtPatientStatus;

            //Preparation Data
            ProcessGetRISPatientPreparation _processGetRISPatientPreparation = new ProcessGetRISPatientPreparation();
            _processGetRISPatientPreparation.Invoke();
            if (_processGetRISPatientPreparation.Result != null)
            {
                DataTable dtPreparation = _processGetRISPatientPreparation.Result.Tables[0];
                btePreparation.Properties.DisplayMember = "PREPARATION_DESC";
                btePreparation.Properties.ValueMember = "PREPARATION_ID";
                btePreparation.Properties.NullText = "";
                //btePreparation.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PREPARATION_DESC", "Preparation"));
                btePreparation.Properties.AutoComplete = true;
                btePreparation.Properties.View.OptionsView.ShowAutoFilterRow = true;
                btePreparation.Properties.View.Columns.Clear();
                btePreparation.Properties.View.Columns.Add(new GridColumn() { Caption = "Preparation", FieldName = "PREPARATION_DESC", Width = 80, VisibleIndex = 0 });
                btePreparation.Properties.DataSource = dtPreparation;
            }
            // Ref Dept data
            DataTable dttRefDept = dtRefUnit.Copy();
            this.glkOrderingDept.Properties.DisplayMember = "UNIT_NAME";
            this.glkOrderingDept.Properties.ValueMember = "UNIT_ID";
            this.glkOrderingDept.Properties.AutoComplete = true;
            this.glkOrderingDept.Properties.View.OptionsView.ShowAutoFilterRow = true;
            this.glkOrderingDept.Properties.View.Columns.Clear();
            this.glkOrderingDept.Properties.View.Columns.Add(new GridColumn() { Caption = "Code", FieldName = "UNIT_UID", Width = 80, VisibleIndex = 0 });
            this.glkOrderingDept.Properties.View.Columns.Add(new GridColumn() { Caption = "Name", FieldName = "UNIT_NAME", Width = 300, VisibleIndex = 1 });
            this.glkOrderingDept.Properties.DataSource = dttRefDept;
            // Ref Doctor data
            DataTable dttRefDoc = dtRefDoc.Copy();
            this.glkOrderingDoc.Properties.DisplayMember = "RadioName";
            this.glkOrderingDoc.Properties.ValueMember = "EMP_ID";
            this.glkOrderingDoc.Properties.AutoComplete = true;
            //this.glkOrderingDoc.Properties.AutoComplete = false;
            this.glkOrderingDoc.Properties.View.OptionsView.ShowAutoFilterRow = true;
            this.glkOrderingDoc.Properties.View.Columns.Clear();
            this.glkOrderingDoc.Properties.View.Columns.Add(new GridColumn() { Caption = "Code", FieldName = "EMP_UID", Width = 80, VisibleIndex = 0 });
            this.glkOrderingDoc.Properties.View.Columns.Add(new GridColumn() { Caption = "Name", FieldName = "RadioName", Width = 300, VisibleIndex = 1 });
            this.glkOrderingDoc.Properties.DataSource = dttRefDoc;
        }
        private void SetControl()
        {
            //cbThaiTitleName.Properties.Items.Clear();
            //cbEngTitleName.Properties.Items.Clear();

            //for (int i = 0; i < TitleThaiName.Length; i++)
            //{
            //    cbThaiTitleName.Properties.Items.Add(TitleThaiName[i]);
            //    cbEngTitleName.Properties.Items.Add(TitleEngName[i]);
            //}
            ProcessGetHRTitle titleData = new ProcessGetHRTitle();
            titleData.Invoke();
            DataTable dtTitle = titleData.ResultSet.Tables[0];
            cbThaiTitleName.Properties.Items.Clear();
            ComboBoxItemCollection colls = cbThaiTitleName.Properties.Items;
            colls.BeginUpdate();

            cbEngTitleName.Properties.Items.Clear();
            ComboBoxItemCollection collEng = cbEngTitleName.Properties.Items;
            collEng.BeginUpdate();

            try
            {
                foreach (DataRow row in dtTitle.Rows)
                {
                    colls.Add(new Filter_TitleName(Convert.ToInt32(row["TITLE_ID"]), row["TITLE_TH"].ToString(), row["GENDER"].ToString()));
                    collEng.Add(new Filter_TitleName(Convert.ToInt32(row["TITLE_ID"]), row["TITLE_ENG"].ToString(), row["GENDER"].ToString()));
                }

            }
            finally
            {
                colls.EndUpdate();
                collEng.EndUpdate();
            }
        }

        private void SetUpLastOrderGrid()
        {
            // Exam Code 
            GridColumn gc_examCode = new GridColumn();
            gc_examCode.Caption = "Exam Code";
            gc_examCode.FieldName = "EXAM_UID";
            gc_examCode.VisibleIndex = 1;
            gc_examCode.Width = 60;
            gc_examCode.OptionsColumn.AllowEdit = false;
            this.gridView3.Columns.Add(gc_examCode);

            // Exam Name 
            GridColumn gc_examName = new GridColumn();
            gc_examName.Caption = "Exam Name";
            gc_examName.FieldName = "EXAM_NAME";
            gc_examName.VisibleIndex = 2;
            gc_examName.Width = 150;
            gc_examName.OptionsColumn.AllowEdit = false;
            this.gridView3.Columns.Add(gc_examName);

            // order datetime
            GridColumn gc_OrderDateTime = new GridColumn();
            gc_OrderDateTime.Caption = "Order DateTime";
            gc_OrderDateTime.FieldName = "ORDER_DT";
            gc_OrderDateTime.VisibleIndex = 3;
            gc_OrderDateTime.Width = 110;
            gc_OrderDateTime.OptionsColumn.AllowEdit = false;
            gc_OrderDateTime.DisplayFormat.FormatString = "d";
            this.gridView3.Columns.Add(gc_OrderDateTime);

            // Exam Name 
            GridColumn gc_OrderBy = new GridColumn();
            gc_OrderBy.Caption = "Order By";
            gc_OrderBy.FieldName = "ORDER_BY";
            gc_OrderBy.VisibleIndex = 4;
            gc_OrderBy.Width = 120;
            gc_OrderBy.OptionsColumn.AllowEdit = false;
            this.gridView3.Columns.Add(gc_OrderBy);
        }
        private void BindingLastOrderGrid()
        {
            ProcessGetRISOrderLast3Orders processGetRISOrderLast3Orders = new ProcessGetRISOrderLast3Orders();
            processGetRISOrderLast3Orders.REG_ID = Int32.Parse(dtPatientDemographic.Rows[0]["REG_ID"].ToString());
            processGetRISOrderLast3Orders.ORG_ID = Int32.Parse(dtPatientDemographic.Rows[0]["ORG_ID"].ToString());
            processGetRISOrderLast3Orders.Invoke();

            if (processGetRISOrderLast3Orders.Result != null)
                this.gridControl2.DataSource = processGetRISOrderLast3Orders.Result.Tables[0];
        }

        private void BindingData()
        {
            // Binding Exam List
            calTotal();
            this.grdExamList.DataSource = dtCasesInfo;
            setColumnsExamList();

            //Binding Demographic
            if (dtPatientDemographic.Rows.Count > 0)
            {
                getCovid19Icon(dtPatientDemographic.Rows[0]["HN"].ToString());
                this.btePreparation.EditValue = null; // clear value
                this.tbHN.Text = dtPatientDemographic.Rows[0]["HN"].ToString();
                this.tbHN.Tag = dtPatientDemographic.Rows[0]["REG_ID"]; //Keep Tag Reg Id
                this.tbThaiFName.Text = dtPatientDemographic.Rows[0]["FNAME"].ToString();
                this.tbThaiLName.Text = dtPatientDemographic.Rows[0]["LNAME"].ToString();
                if (!string.IsNullOrEmpty(dtPatientDemographic.Rows[0]["FNAME_ENG"].ToString()))
                    this.tbEngFName.Text = dtPatientDemographic.Rows[0]["FNAME_ENG"].ToString();
                else
                    this.tbEngFName.Text = TransToEnglish.Trans(this.tbThaiFName.Text); //Tran
                if (!string.IsNullOrEmpty(dtPatientDemographic.Rows[0]["LNAME_ENG"].ToString()))
                    this.tbEngLName.Text = dtPatientDemographic.Rows[0]["LNAME_ENG"].ToString();
                else
                    tbEngLName.Text = TransToEnglish.Trans(this.tbThaiLName.Text); // Tran
                this.tbGender.Text = dtPatientDemographic.Rows[0]["GENDER"].ToString() == "F" ? "หญิง" : "ชาย";
                // Active or inactive by gender 
                if (dtPatientDemographic.Rows[0]["GENDER"].ToString() == "M")
                    this.dtLMP.Properties.ReadOnly = true;
                else
                    this.dtLMP.Properties.ReadOnly = false;
                this.dtLMP.EditValue = string.IsNullOrEmpty(dtPatientDemographic.Rows[0]["LMP_DT"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dtPatientDemographic.Rows[0]["LMP_DT"]);
                this.dtDOB.EditValue = Convert.ToDateTime(dtPatientDemographic.Rows[0]["DOB"]);
                this.tbAge.Text = dtPatientDemographic.Rows[0]["AGE_TEXT"].ToString();
                this.btePatientStatus.EditValue = dtPatientDemographic.Rows[0]["PAT_STATUS"].ToString();

                this.glkOrderingDept.EditValue = dtPatientDemographic.Rows[0]["REF_UNIT"].ToString();
                this.glkOrderingDoc.EditValue = dtPatientDemographic.Rows[0]["REF_DOC_ID"].ToString();
                this.tbInsuranceType.Text = string.IsNullOrEmpty(dtPatientDemographic.Rows[0]["INSURANCE_TYPE_DESC"].ToString()) ? "เงินสด" : dtPatientDemographic.Rows[0]["INSURANCE_TYPE_DESC"].ToString();
                //set insurance type id
                this.insuranceId = string.IsNullOrEmpty(dtPatientDemographic.Rows[0]["INSURANCE_TYPE_ID"].ToString()) ? 11 : Convert.ToInt32(dtPatientDemographic.Rows[0]["INSURANCE_TYPE_ID"]);
                this.cbThaiTitleName.SelectedItem = dtPatientDemographic.Rows[0]["TITLE"].ToString();
                this.chkNonResident.Checked = dtPatientDemographic.Rows[0]["IS_FOREIGNER"].ToString() == "Y" ? true : false;
                this.btePreparation.EditValue = string.IsNullOrEmpty(dtCasesInfo.Rows[0]["PREPARATION_ID"].ToString()) ? 0 : Convert.ToInt32(dtCasesInfo.Rows[0]["PREPARATION_ID"].ToString());
                #region Request Result Datetime
                if (!string.IsNullOrEmpty(dtPatientDemographic.Rows[0]["REQUEST_RESULT_DATETIME"].ToString()))
                {
                    chkRequestResult.Checked = true;
                    dtRequestResult.DateTime = Convert.ToDateTime(dtPatientDemographic.Rows[0]["REQUEST_RESULT_DATETIME"]);
                    timeReqeustResult.Time = Convert.ToDateTime(dtPatientDemographic.Rows[0]["REQUEST_RESULT_DATETIME"]);
                }
                #endregion

                GetNextAppointment();
            }


            dtCasesInfo.BeginLoadData();
            chkNonResident.ForeColor = chkNonResident.Checked ? Color.Red : Color.Black;

            foreach (DataRow drExam in this.dtCasesInfo.Rows)
            {

                DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + drExam["CLINIC_TYPE_ID"].ToString());
                string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
                switch (clinictypeName.ToUpper())
                {
                    case "SPECIAL": drExam["EXAM_RATE"] = chkNonResident.Checked ? drExam["FOREIGN_SPCIAL_RATE"] : drExam["SPECIAL_RATE"]; break;
                    case "VIP": drExam["EXAM_RATE"] = chkNonResident.Checked ? drExam["FOREIGN_VIP_RATE"] : drExam["VIP_RATE"]; break;
                    default: drExam["EXAM_RATE"] = chkNonResident.Checked ? drExam["FOREIGN_RATE"] : drExam["RGL_RATE"]; break;
                }
            }
            calTotal();
            dtCasesInfo.AcceptChanges();
            dtCasesInfo.EndLoadData();

        }
        private void setTrauma(int id, bool is_schedule)
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            id = id == 0 ? -1 : id;
            if (is_schedule)
            {
                prc.RIS_ORDEREXAMFLAG.SCHEDULE_ID = id;
                prc.InvokeSchedule();
            }
            else
            {
                prc.RIS_ORDEREXAMFLAG.XRAYREQ_ID = id;
                prc.InvokeXrayreq();
            }
            dttExamFlag = prc.Result.Tables[0]; //Set template table.
            dtExamFlagDTL = prc.resultDetail();

            contextcmb.Items.Clear();
            System.Windows.Forms.ComboBox.ObjectCollection colls = contextcmb.Items;
            try
            {
                foreach (DataRow row in dtExamFlagDTL.Rows)
                    colls.Add(new TraumaItems(Convert.ToInt32(row["GEN_DTL_ID"]), row["GEN_TEXT"].ToString(), Convert.ToInt32(row["SL_NO"])));
            }
            finally
            {
            }
            contextcmb.SelectedIndex = 0;
        }
        public void UpdateInsuranceType()
        {
            #region [ Update Insurance Tpye From HIS ]
            //update current info.
            //string encType = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_TYPE"].ToString()) ? "" : this.dtCasesInfo.Rows[0]["ENC_TYPE"].ToString();
            //string encId = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_ID"].ToString()) ? "0" : this.dtCasesInfo.Rows[0]["ENC_ID"].ToString();
            string encType = string.Empty;
            string encId = string.Empty;
            EncounterManagement.LoadEncounter(this.dtPatientDemographic.Rows[0]["HN"].ToString()
                , this.dtPatientDemographic.Rows[0]["UNIT_UID"].ToString()
                , ref encId
                , ref encType);

            this.dtCasesInfo.Rows[0]["ENC_TYPE"] = encType;
            int intEncId = 0;
            this.dtCasesInfo.Rows[0]["ENC_ID"] = int.TryParse(encId.Trim(), out intEncId) ? int.Parse(encId.Trim()) : 0;
            string sdloc = this.dtPatientDemographic.Rows[0]["UNIT_UID"].ToString();
            string prefDate = DateTime.Today.ToShortDateString();
            string insuranceTypeUid = string.Empty;
            if (this.tbInsuranceType.InvokeRequired)
                this.tbInsuranceType.Invoke(new MethodInvoker(delegate
                {
                    this.bkBackColor = this.tbInsuranceType.BackColor;
                    this.tbInsuranceType.Text = "กำลังอัพเดต..."; //set waiting message
                    this.tbInsuranceType.BackColor = Color.Orange;
                }));
            string encounterClinicType = string.Empty;
            int clinicTypeId = dtCasesInfo.Rows[0]["CLINIC_TYPE_ID"].ToString() != string.Empty ? Convert.ToInt32(dtCasesInfo.Rows[0]["CLINIC_TYPE_ID"]) : 1;
            // GET ENCOUNTER CLINIC TYPE
            switch (clinicTypeId)
            {
                case 1: encounterClinicType = "RGL"; break;
                case 7: encounterClinicType = "SPC"; break;
                case 8: encounterClinicType = "SPC"; break;
                case 6: encounterClinicType = "PRM"; break;
                default: encounterClinicType = "RGL"; break;
            }
            try
            {
                insuranceTypeUid = Envision.BusinessLogic.InsuranceManagement.LoadInsuranceCodeFromHIS(this.tbHN.Text, encId, encType, sdloc, prefDate, encounterClinicType);
                DataTable dtInsuranceType = Envision.BusinessLogic.RISBaseData.Ris_InsuranceType();
                DataRow[] drRows = dtInsuranceType.Select("INSURANCE_TYPE_UID='" + insuranceTypeUid + "'");
                if (drRows.Length > 0)
                {
                    if (this.tbInsuranceType.InvokeRequired)
                    {
                        this.tbInsuranceType.Invoke(new MethodInvoker(delegate
                            {
                                this.insuranceId = Convert.ToInt32(drRows[0]["INSURANCE_TYPE_ID"].ToString());
                                this.tbInsuranceType.Text = drRows[0]["INSURANCE_TYPE_DESC"].ToString();
                                this.tbInsuranceType.BackColor = this.bkBackColor;
                            }));
                    }
                }

                dtInsuranceType = null;
                drRows = null;
            }
            catch
            {
                // Set to UNK
                if (this.tbInsuranceType.InvokeRequired)
                {
                    this.tbInsuranceType.Invoke(new MethodInvoker(delegate
                    {
                        this.insuranceId = 11;
                        this.tbInsuranceType.Text = "เงินสด";
                        this.tbInsuranceType.BackColor = this.bkBackColor;
                    }));
                }
            }
            finally
            {
                encType = string.Empty;
                encId = string.Empty;
                sdloc = string.Empty;
                prefDate = string.Empty;
                bkBackColor = Color.Empty;
            }
            #endregion
        }
        public void UpdateAdmissionNumber()
        {
            try
            {
                string admissionNo = EncounterManagement.LoadAdmissinNo(this.tbHN.Text);
                aadmissionNo = string.IsNullOrEmpty(admissionNo) ? string.Empty : admissionNo;
            }
            catch { aadmissionNo = string.Empty; }
            finally
            {
            }
        }
        public void UpdateHISRegistration()
        {
            Patient patient = new Envision.BusinessLogic.Patient(this.dtPatientDemographic.Rows[0]["HN"].ToString(), false);
            if (patient.HasHN)
            {
                try
                {
                    GBLEnvVariable env = new GBLEnvVariable();
                    ProcessUpdateHISRegistration proUpdate = new ProcessUpdateHISRegistration();
                    proUpdate.HIS_REGISTRATION.REG_ID = Int32.Parse(dtPatientDemographic.Rows[0]["REG_ID"].ToString());
                    proUpdate.HIS_REGISTRATION.FNAME = patient.FirstName;
                    proUpdate.HIS_REGISTRATION.LNAME = patient.LastName;
                    proUpdate.HIS_REGISTRATION.FNAME_ENG = patient.FirstName_ENG;
                    proUpdate.HIS_REGISTRATION.LNAME_ENG = patient.LastName_ENG;
                    proUpdate.HIS_REGISTRATION.TITLE = patient.Title;
                    proUpdate.HIS_REGISTRATION.TITLE_ENG = patient.Title_ENG;
                    proUpdate.HIS_REGISTRATION.PHONE1 = patient.Phone1;
                    proUpdate.HIS_REGISTRATION.SSN = patient.SocialNumber;
                    proUpdate.HIS_REGISTRATION.DOB = patient.DateOfBirth;
                    if(patient.Gender == "M"){
                        proUpdate.HIS_REGISTRATION.GENDER = 'M';
                    }
                    else if (patient.Gender == "F"){
                        proUpdate.HIS_REGISTRATION.GENDER = 'F';
                    }
                    //proUpdate.HIS_REGISTRATION.PATIENT_TYPE = patient.Patient_type;
                    proUpdate.HIS_REGISTRATION.LINK_DOWN = patient.LinkDown == false ? 'Y' : 'N';
                    proUpdate.HIS_REGISTRATION.INSURANCE_TYPE = patient.Insurance_Type;
                    proUpdate.HIS_REGISTRATION.LAST_MODIFIED_BY = env.UserID;
                    //proUpdate.HIS_REGISTRATION.IS_JOHNDOE = patient.joh

                    proUpdate.HIS_REGISTRATION.HN = patient.Reg_UID;
                    proUpdate.HIS_REGISTRATION.LAST_MODIFIED_BY = env.UserID;
                    proUpdate.HIS_REGISTRATION.ALLERGIES = string.IsNullOrEmpty(patient.Allergies.ToString().Trim()) ? "" : "Y";
                    proUpdate.UpdateFromArrival();
                }
                catch { }

                dtPatientDemographic.Rows[0]["FNAME"] = patient.FirstName;
                dtPatientDemographic.Rows[0]["LNAME"] = patient.LastName;
                dtPatientDemographic.Rows[0]["FNAME_ENG"] = patient.FirstName_ENG;
                dtPatientDemographic.Rows[0]["LNAME_ENG"] = patient.LastName_ENG;
                dtPatientDemographic.Rows[0]["TITLE"] = patient.Title;
                dtPatientDemographic.Rows[0]["TITLE_ENG"] = patient.Title_ENG;
                dtPatientDemographic.Rows[0]["PHONE1"] = patient.Phone1;
                dtPatientDemographic.Rows[0]["SSN"] = patient.SocialNumber;
                dtPatientDemographic.Rows[0]["DOB"] = patient.DateOfBirth;
                dtPatientDemographic.Rows[0]["GENDER"] = patient.Gender;
            }
        }

        private void checkAllergies()
        {
            if (!string.IsNullOrEmpty(dtPatientDemographic.Rows[0]["Allergies"].ToString().Trim()))
            {
                frmAllergy2 Allergy = new frmAllergy2();
                Allergy.ShowDialog();
            }
        }

        private void getCovid19Icon(string Hn)
        {
            try
            {
                string _url = System.Configuration.ConfigurationSettings.AppSettings["RamaCare"] + Hn;
                Uri ur = new Uri(_url);
                webBrowser1.Url = ur;
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// This method use to build order to RIS_ORDER and RIS_ORDERDTL
        /// </summary>

        private DataTable dtTemplateBillingLog;
        private void setTemplateBillingLog()
        {
            ProcessGetRISBillinglogWithHIS getBilling = new ProcessGetRISBillinglogWithHIS();
            getBilling.RIS_BILLINGLOG_WITH_HIS.ORDER_ID = 0;
            getBilling.Invoke();
            dtTemplateBillingLog = new DataTable();
            dtTemplateBillingLog = getBilling.Result.Tables[0].Copy();
        }
        private int BuildOrder()
        {
            #region Check HIS Billing
            foreach (DataRow eachExamRow2 in this.dtCasesInfo.Rows)
            {
                DataRow[] getBillingExamUID = dtExam.Select("EXAM_UID = '" + eachExamRow2["EXAM_UID"].ToString() + "'");
                string exam_uid = getBillingExamUID[0]["BILLING_CODE"].ToString();
                string _nonResident = chkNonResident.Checked ? "nonresident(v)" : "";
                HIS_Patient proxy = new HIS_Patient();
                DataSet dsCheckRate = proxy.GetEncounterDetailClinicTypePriceType(this.dtPatientDemographic.Rows[0]["HN"].ToString(), exam_uid, DateTime.Now.ToString("dd/MM/yyyy"), _nonResident);
                if (string.IsNullOrEmpty(dsCheckRate.Tables[0].Rows[0]["mrn"].ToString()))
                    dsCheckRate.Tables[0].Rows[0]["mrn"] = this.dtPatientDemographic.Rows[0]["HN"].ToString();

                int _ref_unit = Convert.ToInt32(this.glkOrderingDept.EditValue);
                DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + eachExamRow2["CLINIC_TYPE"].ToString());
                DataRow[] drUnit = dtRefUnit.Select("UNIT_ID=" + _ref_unit.ToString());

                DataView dv = dsCheckRate.Tables[0].DefaultView;
                dv.RowFilter = "sdloc_id='" + drUnit[0]["UNIT_UID"].ToString() + "'";
                if (dv.Count > 0)
                {
                    #region Add TemplateTable Billing
                    DataRow[] rowChkExam = dtTemplateBillingLog.Select("EXAM_ID=" + eachExamRow2["EXAM_ID"].ToString());
                    if (rowChkExam.Length > 0)
                        dtTemplateBillingLog.Rows.Remove(rowChkExam[0]);
                    DataRow rowAddTemp = dtTemplateBillingLog.NewRow();


                    dv.RowFilter = "clinictype='" + drClinic[0]["CLINIC_TYPE_ALIAS"].ToString() + "'";
                    if (dv.Count == 0)
                    {
                        //MessageBox.Show(eachExamRow2["EXAM_UID"].ToString() + " ไม่มีประกาศราคาใน clinic type นี้"); //_strAlert += " " +  + " clinictype= null;";
                        ProcessAddRISBillinglogWithHIS logs = new ProcessAddRISBillinglogWithHIS();
                        logs.RIS_BILLINGLOG_WITH_HIS.UNIT_UID = drUnit[0]["UNIT_UID"].ToString();
                        logs.RIS_BILLINGLOG_WITH_HIS.CLINIC_TYPE_ALIAS = drClinic[0]["CLINIC_TYPE_ALIAS"].ToString();
                        logs.RIS_BILLINGLOG_WITH_HIS.EXAM_UID = exam_uid;
                        logs.RIS_BILLINGLOG_WITH_HIS.HN = this.dtPatientDemographic.Rows[0]["HN"].ToString();
                        logs.RIS_BILLINGLOG_WITH_HIS.CREATED_BY = gblenv.UserID;
                        logs.insertLogByHISErrorClinic();
                    }
                    else
                    {
                        eachExamRow2["ENC_ID"] = dv[0]["enc_id"].ToString();
                        eachExamRow2["ENC_TYPE"] = dv[0]["enc_type"].ToString();
                        eachExamRow2["ENC_CLINIC"] = dv[0]["clinictype"].ToString();
                        eachExamRow2.AcceptChanges();

                        rowAddTemp["EXAM_ID"] = eachExamRow2["EXAM_ID"];
                        rowAddTemp["object_id"] = dv[0]["object_id"];
                        rowAddTemp["enc_id"] = dv[0]["enc_id"];
                        rowAddTemp["enc_type"] = dv[0]["enc_type"];
                        rowAddTemp["mrn"] = dv[0]["mrn"];
                        rowAddTemp["mrn_type"] = dv[0]["mrn_type"];
                        rowAddTemp["sdloc_id"] = dv[0]["sdloc_id"];
                        rowAddTemp["period"] = dv[0]["period"];
                        rowAddTemp["attender"] = dv[0]["attender"];
                        rowAddTemp["enterer"] = dv[0]["enterer"];
                        rowAddTemp["insurance"] = dv[0]["insurance"];
                        rowAddTemp["pt_acc_id"] = dv[0]["pt_acc_id"];
                        rowAddTemp["effectivestartdate"] = convertHISDate(dv[0]["effectivestartdate"].ToString());
                        rowAddTemp["effectiveenddate"] = convertHISDate(dv[0]["effectiveenddate"].ToString());
                        rowAddTemp["statuscode"] = dv[0]["statuscode"];
                        rowAddTemp["productcode"] = dv[0]["productcode"];
                        rowAddTemp["clinictype"] = dv[0]["clinictype"];
                        rowAddTemp["pricetype"] = dv[0]["pricetype"];
                        rowAddTemp["amtprice"] = dv[0]["amtprice"];
                        dtTemplateBillingLog.Rows.Add(rowAddTemp);
                        dtTemplateBillingLog.AcceptChanges();

                    }
                    #endregion
                }
                else
                {
                    //MessageBox.Show(drUnit[0]["UNIT_UID"].ToString() + " ไม่มีการลงทะเบียนที่แผนกนี้");//_strAlert += "sdloc_id=0";
                }

            }
            #endregion

            int orderId = 0;
            bool isOrderSuccess = true;
            // ## Local Parameter
            List<string> accessionList = new List<string>(); //create accession list for keep acession
            bool isSchedule = false;
            if (this.selectedScheduleId != 0)
                isSchedule = true; // set is schedule

            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("EXAM_ID", typeof(int));
            dtTemp.Columns.Add("ACCESSION_NO", typeof(string));
            dtTemp.AcceptChanges();

            DbConnection connection = null;
            DbTransaction transaction = null;
            #region UPDATE HIS REGISTRATION
            // #### UPDATE HIS REGISTRATION ####
            ProcessUpdateHISRegistrationByConfirmArrival processUpdateHISRegistrationByConfirmArrival = new ProcessUpdateHISRegistrationByConfirmArrival();
            processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.TITLE = this.cbThaiTitleName.Text;
            processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.TITLE_ENG = this.cbEngTitleName.Text;
            processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.REG_ID = Convert.ToInt32(this.dtPatientDemographic.Rows[0]["REG_ID"]);
            processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.FNAME_ENG = this.tbEngFName.Text;
            processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.LNAME_ENG = this.tbEngLName.Text;
            processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.LAST_MODIFIED_BY = this.gblenv.UserID;
            processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.ORG_ID = this.gblenv.OrgID;
            processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.IS_FOREIGNER = chkNonResident.Checked ? "Y" : "N";
            processUpdateHISRegistrationByConfirmArrival.Invoke();
            #endregion
            try
            {
                #region Insert to RIS_ORDER

                // #### INSERT DATA TO TABLE RIS_ORDER AND RIS_ORDERDTL ####
                connection = BusinessLogic.RISBaseData.ConnectionDataBase();
                connection.Open();
                transaction = connection.BeginTransaction();

                // Insert to RIS_ORDER
                ProcessAddRISOrderV2 processAddRISOrder = new ProcessAddRISOrderV2();
                processAddRISOrder.Transaction = transaction;
                processAddRISOrder.RIS_ORDER.REG_ID = Convert.ToInt32(this.dtPatientDemographic.Rows[0]["REG_ID"]);
                processAddRISOrder.RIS_ORDER.HN = this.dtPatientDemographic.Rows[0]["HN"].ToString();
                processAddRISOrder.RIS_ORDER.ORG_ID = gblenv.OrgID;
                processAddRISOrder.RIS_ORDER.ARRIVAL_BY = gblenv.UserID;
                processAddRISOrder.RIS_ORDER.ARRIVAL_ON = DateTime.Now;
                processAddRISOrder.RIS_ORDER.CREATED_BY = gblenv.UserID;
                processAddRISOrder.RIS_ORDER.ADMISSION_NO = aadmissionNo;
                if (isSchedule)
                {
                    if (this.dtCasesInfo.Rows[0]["IS_REQONLINE"].ToString() == "Y")
                        processAddRISOrder.RIS_ORDER.IS_REQONLINE = "Y";
                    processAddRISOrder.RIS_ORDER.ORDER_START_TIME = Convert.ToDateTime(this.dtCasesInfo.Rows[0]["START_DATETIME"]);
                    processAddRISOrder.RIS_ORDER.ORDER_DT = Convert.ToDateTime(this.dtCasesInfo.Rows[0]["SCHEDULE_DT"]);
                    processAddRISOrder.RIS_ORDER.REF_DOC = Convert.ToInt32(this.glkOrderingDoc.EditValue);
                    processAddRISOrder.RIS_ORDER.SCHEDULE_ID = selectedScheduleId;
                }
                else
                {
                    processAddRISOrder.RIS_ORDER.IS_REQONLINE = "Y";
                    processAddRISOrder.RIS_ORDER.ORDER_DT = Convert.ToDateTime(this.dtCasesInfo.Rows[0]["ORDER_DT"]);
                    processAddRISOrder.RIS_ORDER.ORDER_START_TIME = Convert.ToDateTime(this.dtCasesInfo.Rows[0]["ORDER_START_TIME"]);
                    processAddRISOrder.RIS_ORDER.REF_DOC = Convert.ToInt32(this.glkOrderingDoc.EditValue);
                }
                processAddRISOrder.RIS_ORDER.REF_UNIT = Convert.ToInt32(this.glkOrderingDept.EditValue);
                processAddRISOrder.RIS_ORDER.INSURANCE_TYPE_ID = insuranceId;
                processAddRISOrder.RIS_ORDER.PAT_STATUS = this.btePatientStatus.EditValue.ToString();
                processAddRISOrder.RIS_ORDER.CLINICAL_INSTRUCTION = this.dtCasesInfo.Rows[0]["CLINICAL_INSTRUCTION"].ToString();
                processAddRISOrder.RIS_ORDER.REF_DOC_INSTRUCTION = this.dtCasesInfo.Rows[0]["REF_DOC_INSTRUCTION"].ToString();
                processAddRISOrder.RIS_ORDER.ENC_ID = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_ID"].ToString()) ? string.Empty : this.dtCasesInfo.Rows[0]["ENC_ID"].ToString();
                processAddRISOrder.RIS_ORDER.ENC_TYPE = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_TYPE"].ToString()) ? string.Empty : this.dtCasesInfo.Rows[0]["ENC_TYPE"].ToString();
                processAddRISOrder.RIS_ORDER.ENC_CLINIC = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_CLINIC"].ToString()) ? string.Empty : this.dtCasesInfo.Rows[0]["ENC_CLINIC"].ToString();
                processAddRISOrder.RIS_ORDER.IS_ALERT_CLINICAL_INSTRUCTION = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString()) ? string.Empty : this.dtCasesInfo.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
                processAddRISOrder.RIS_ORDER.CLINICAL_INSTRUCTION_TAG = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString()) ? string.Empty : this.dtCasesInfo.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString();
                if (!string.IsNullOrEmpty(dtLMP.Text))
                    processAddRISOrder.RIS_ORDER.LMP_DT = dtLMP.DateTime;
                if (selectedScheduleId != 0)
                    processAddRISOrder.RIS_ORDER.SCHEDULE_ID = selectedScheduleId;
                processAddRISOrder.Invoke();
                // set order id 
                orderId = processAddRISOrder.RIS_ORDER.ORDER_ID;

                #region Insert to RIS_ORDERDTL
                // Insert to RIS_ORDERDTL
                ProcessAddRISOrderDtlV2 processAddRISOrderDtl = new ProcessAddRISOrderDtlV2();
                processAddRISOrderDtl.UseTransaction = transaction;
                ProcessGetRISOrderGenAccessionNo processGetRISOrderGenAccessionNo = new ProcessGetRISOrderGenAccessionNo();
                processGetRISOrderGenAccessionNo.Transaction = transaction;

                foreach (DataRow eachExamRow in this.dtCasesInfo.Rows)
                {
                    processAddRISOrderDtl.RIS_ORDERDTL.ORDER_ID = processAddRISOrder.RIS_ORDER.ORDER_ID;
                    processAddRISOrderDtl.RIS_ORDERDTL.EXAM_DT = Convert.ToDateTime(eachExamRow["EXAM_DT"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.ORG_ID = gblenv.OrgID;
                    processAddRISOrderDtl.RIS_ORDERDTL.CREATED_BY = gblenv.UserID;
                    if (isSchedule)
                    {
                        processAddRISOrderDtl.RIS_ORDERDTL.EST_START_TIME = Convert.ToDateTime(eachExamRow["SCHEDULE_DT"]);
                    }
                    else
                    {
                        processAddRISOrderDtl.RIS_ORDERDTL.EST_START_TIME = Convert.ToDateTime(eachExamRow["ORDER_DT"]);
                    }
                    processAddRISOrderDtl.RIS_ORDERDTL.QTY = Convert.ToByte(eachExamRow["QTY"].ToString());
                    processAddRISOrderDtl.RIS_ORDERDTL.ASSIGNED_TO = eachExamRow["ASSIGN_TO"].ToString() == string.Empty ? 0 : Convert.ToInt32(eachExamRow["ASSIGN_TO"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID = Convert.ToInt32(eachExamRow["MODALITY_ID"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.PRIORITY = string.IsNullOrEmpty(eachExamRow["PRIORITY"].ToString()) ? 'R' : Convert.ToChar(eachExamRow["PRIORITY"].ToString());
                    processAddRISOrderDtl.RIS_ORDERDTL.EXAM_ID = Convert.ToInt32(eachExamRow["EXAM_ID"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.RATE = (decimal)eachExamRow["EXAM_RATE"];
                    processAddRISOrderDtl.RIS_ORDERDTL.CLINIC_TYPE = eachExamRow["CLINIC_TYPE_ID"].ToString().Trim() == string.Empty || eachExamRow["CLINIC_TYPE_ID"].ToString().Trim() == null ? 0 : (int)eachExamRow["CLINIC_TYPE_ID"];
                    if (processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID > 0)
                    {
                        //Get acession no
                        processGetRISOrderGenAccessionNo.MODALITY_ID = processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID;
                        processGetRISOrderGenAccessionNo.REF_UNIT_ID = Convert.ToInt32(this.glkOrderingDept.EditValue);
                        processGetRISOrderGenAccessionNo.Invoke();
                        processAddRISOrderDtl.RIS_ORDERDTL.ACCESSION_NO = processGetRISOrderGenAccessionNo.ACCESSION_ON;
                    }
                    else
                    {
                        processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID = 86;
                        processAddRISOrderDtl.RIS_ORDERDTL.ACCESSION_NO = Envision.BusinessLogic.Order.GenHN();
                    }
                    processAddRISOrderDtl.RIS_ORDERDTL.BPVIEW_ID = string.IsNullOrEmpty(eachExamRow["BPVIEW_ID"].ToString()) ? 0 : Convert.ToInt32(eachExamRow["BPVIEW_ID"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.HIS_SYNC = string.IsNullOrEmpty(eachExamRow["HIS_SYNC"].ToString()) ? 'N' : Convert.ToChar(eachExamRow["HIS_SYNC"].ToString());
                    processAddRISOrderDtl.RIS_ORDERDTL.HIS_ACK = eachExamRow["HIS_ACK"].ToString();
                    processAddRISOrderDtl.RIS_ORDERDTL.PREPARATION_ID = btePreparation.EditValue == null ? 0 : (int)btePreparation.EditValue;
                    processAddRISOrderDtl.RIS_ORDERDTL.COMMENTS_ONLINE = eachExamRow["COMMENTS"].ToString();
                    processAddRISOrderDtl.RIS_ORDERDTL.PAT_DEST_ID = eachExamRow["PAT_DEST_ID"].ToString() != string.Empty ? Convert.ToInt32(eachExamRow["PAT_DEST_ID"].ToString()) : 0;
                    processAddRISOrderDtl.Invoke();

                    // add Temp
                    dtTemp.Rows.Add(Convert.ToInt32(eachExamRow["EXAM_ID"]), processAddRISOrderDtl.RIS_ORDERDTL.ACCESSION_NO);
                    dtTemp.AcceptChanges();
                    // add accession for set billing
                    accessionList.Add(processAddRISOrderDtl.RIS_ORDERDTL.ACCESSION_NO);
                }
                #endregion

                if (isSchedule)
                {
                    #region Update OrderId
                    ProcessUpdateRISScheduleSentToOrder processUpdateRISScheduleSentToOrder = new ProcessUpdateRISScheduleSentToOrder();
                    processUpdateRISScheduleSentToOrder.Transaction = transaction;
                    processUpdateRISScheduleSentToOrder.SCHEDULE_ID = selectedScheduleId;
                    processUpdateRISScheduleSentToOrder.ORG_ID = gblenv.OrgID;
                    processUpdateRISScheduleSentToOrder.LAST_MODIFIED_BY = gblenv.UserID;
                    processUpdateRISScheduleSentToOrder.ORDER_ID = orderId;
                    processUpdateRISScheduleSentToOrder.Invoke();
                    #endregion
                    #region insert schedule logs
                    ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
                    schLogs.Transaction = transaction;
                    schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = selectedScheduleId;
                    schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = gblenv.UserID;
                    schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'A';
                    schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Arrived";
                    schLogs.Invoke();
                    #endregion
                    #region Update OrderImages
                    ProcessUpdateRISOrderimages updateOrderImages = new ProcessUpdateRISOrderimages();
                    updateOrderImages.Transaction = transaction;
                    updateOrderImages.RIS_ORDERIMAGE.SCHEDULE_ID = selectedScheduleId;
                    updateOrderImages.RIS_ORDERIMAGE.ORDER_ID = orderId;
                    updateOrderImages.UpdateOrderIdByScheduleId();
                    #endregion
                    #region Update Riskincidents
                    ProcessUpdateRisRiskIncidents processUpdateRiskIncident = new ProcessUpdateRisRiskIncidents();
                    processUpdateRiskIncident.Transaction = transaction;
                    processUpdateRiskIncident.RIS_RISKINCIDENTS.SCHEDULE_ID = selectedScheduleId;
                    processUpdateRiskIncident.RIS_RISKINCIDENTS.ORG_ID = gblenv.OrgID;
                    processUpdateRiskIncident.RIS_RISKINCIDENTS.LAST_MODIFIED_BY = gblenv.UserID;
                    processUpdateRiskIncident.RIS_RISKINCIDENTS.ORDER_ID = orderId;
                    processUpdateRiskIncident.UpdateOrderIdByScheduleId();
                    #endregion
                    #region Update OrderClinicalIndication
                    ProcessUpdateRISOrderClinicalIndication processUpdateClinical = new ProcessUpdateRISOrderClinicalIndication();
                    processUpdateClinical.Transaction = transaction;
                    processUpdateClinical.SCHEDULE_ID = selectedScheduleId;
                    processUpdateClinical.ORG_ID = gblenv.OrgID;
                    processUpdateClinical.LAST_MODIFIED_BY = gblenv.UserID;
                    processUpdateClinical.ORDER_ID = orderId;
                    processUpdateClinical.UpdateByScheduleId();
                    #endregion

                    foreach (DataRow eachExamRow in dtTemp.Rows)
                    {
                        MessageConversationManagement msgUpdate = new MessageConversationManagement();
                        msgUpdate.Transaction = transaction;
                        msgUpdate.updateAccessionCommentSystem(eachExamRow["ACCESSION_NO"].ToString(), selectedScheduleId, orderId, Convert.ToInt32(eachExamRow["EXAM_ID"]), true);
                    }
                }
                else
                {
                    // #### UPDATE XRAYREQ SEND TO ORDER
                    ProcessUpdateXrayReqSendToOrder processUpdateXrayReqSendToOrder = new ProcessUpdateXrayReqSendToOrder();
                    processUpdateXrayReqSendToOrder.Transaction = transaction;
                    processUpdateXrayReqSendToOrder.ORDER_ID = orderId;
                    processUpdateXrayReqSendToOrder.LAST_MODIFIED_BY = gblenv.UserID;
                    processUpdateXrayReqSendToOrder.ORG_ID = gblenv.OrgID;
                    processUpdateXrayReqSendToOrder.XRAY_ID = selectedOrderId;
                    processUpdateXrayReqSendToOrder.Invoke();

                    foreach (DataRow eachExamRow in dtTemp.Rows)
                    {
                        ProcessUpdateXrayReqSendToOrder processUpdateXraydtlReqSendToOrder = new ProcessUpdateXrayReqSendToOrder();
                        processUpdateXraydtlReqSendToOrder.Transaction = transaction;
                        processUpdateXraydtlReqSendToOrder.XRAY_ID = selectedOrderId;
                        processUpdateXraydtlReqSendToOrder.EXAM_ID = Convert.ToInt32(eachExamRow["EXAM_ID"]);
                        processUpdateXraydtlReqSendToOrder.ACCESSION_NO = eachExamRow["ACCESSION_NO"].ToString();
                        processUpdateXraydtlReqSendToOrder.LAST_MODIFIED_BY = gblenv.UserID;
                        processUpdateXraydtlReqSendToOrder.ORG_ID = gblenv.OrgID;
                        processUpdateXraydtlReqSendToOrder.UpdateAccession();

                        MessageConversationManagement msgUpdate = new MessageConversationManagement();
                        msgUpdate.Transaction = transaction;
                        msgUpdate.updateAccessionCommentSystem(eachExamRow["ACCESSION_NO"].ToString(), selectedOrderId, orderId, Convert.ToInt32(eachExamRow["EXAM_ID"]), false);
                    }
                }

                transaction.Commit();
                #endregion
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                SaveScreen(ex);
                isOrderSuccess = false;
                //connection.Close();
                //return orderId;
            }
            finally
            {
                connection.Close();
            }
            try
            {
                ProcessAddGBLErrorLogs prc = new ProcessAddGBLErrorLogs();
                prc.GBL_ERRORLOGS.AAA_IS_SCHEDULE = isSchedule.ToString();// ex.Message;
                prc.GBL_ERRORLOGS.AAA_SCHEDULE_ID = selectedScheduleId;
                prc.GBL_ERRORLOGS.AAA_ORDER_ID = orderId;
                prc.GBL_ERRORLOGS.AAA_SCHEDULELOG_DESC = "isOrderSuccess: " + isOrderSuccess;
                prc.GBL_ERRORLOGS.AAA_LAST_MODIFIED_BY = gblenv.UserID;
                prc.InsertAAASchedulelog();

                if (!isOrderSuccess) return 0;

                #region Update Exam Flag
                if (Utilities.IsHaveData(dttExamFlag))
                {
                    foreach (DataRow rowExamFlag in dttExamFlag.Rows)
                    {
                        if (Convert.ToInt32(rowExamFlag["FLAG_ID"].ToString()) == 0)
                        {
                            ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                            addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = orderId;
                            addExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = string.IsNullOrEmpty(rowExamFlag["XRAYREQ_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["XRAYREQ_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowExamFlag["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["SCHEDULE_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                            addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = gblenv.UserID;
                            addExamFlag.Invoke();
                        }
                        else
                        {
                            ProcessUpdateRISOrderexamflag updateExamFlag = new ProcessUpdateRISOrderexamflag();
                            updateExamFlag.RIS_ORDEREXAMFLAG.FLAG_ID = Convert.ToInt32(rowExamFlag["FLAG_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = orderId;
                            updateExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = string.IsNullOrEmpty(rowExamFlag["XRAYREQ_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["XRAYREQ_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowExamFlag["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["SCHEDULE_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                            updateExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = gblenv.UserID;
                            updateExamFlag.Invoke();
                        }
                    }
                }
                #endregion
                #region Update Request Result Datetime
                if (chkRequestResult.Checked)
                {
                    DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

                    ProcessUpdateRISOrder updateRequestResult = new ProcessUpdateRISOrder();
                    updateRequestResult.RIS_ORDER.ORDER_ID = orderId;
                    updateRequestResult.RIS_ORDER.REQUEST_RESULT_DATETIME = requestResult;
                    updateRequestResult.UpdateRequestResult();
                }
                #endregion
                #region Sent To PACS
                sendToPacs = new SendToPacs();
                sendToPacs.Set_ORMByOrderIdQueue(orderId);
                #endregion
                #region Insert BillingLogs
                foreach (DataRow rowBillingLog in dtTemplateBillingLog.Rows)
                {
                    try
                    {
                        ProcessAddRISBillinglogWithHIS addBillinglog = new ProcessAddRISBillinglogWithHIS();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.amtprice = Convert.ToDouble(rowBillingLog["amtprice"].ToString());
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.attender = rowBillingLog["attender"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.clinictype = rowBillingLog["clinictype"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.CREATED_BY = gblenv.UserID;
                        if (!string.IsNullOrEmpty(rowBillingLog["effectiveenddate"].ToString()))
                            addBillinglog.RIS_BILLINGLOG_WITH_HIS.effectiveenddate = Convert.ToDateTime(rowBillingLog["effectiveenddate"].ToString());
                        if (!string.IsNullOrEmpty(rowBillingLog["effectivestartdate"].ToString()))
                            addBillinglog.RIS_BILLINGLOG_WITH_HIS.effectivestartdate = Convert.ToDateTime(rowBillingLog["effectivestartdate"].ToString());
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.enc_id = rowBillingLog["enc_id"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.enc_type = rowBillingLog["enc_type"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.enterer = rowBillingLog["enterer"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.EXAM_ID = string.IsNullOrEmpty(rowBillingLog["EXAM_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(rowBillingLog["EXAM_ID"].ToString());
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.insurance = rowBillingLog["insurance"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.mrn = rowBillingLog["mrn"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.mrn_type = rowBillingLog["mrn_type"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.object_id = rowBillingLog["object_id"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.ORDER_ID = orderId;
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.period = rowBillingLog["period"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.pricetype = rowBillingLog["pricetype"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.productcode = rowBillingLog["productcode"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.pt_acc_id = rowBillingLog["pt_acc_id"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.sdloc_id = rowBillingLog["sdloc_id"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.statuscode = rowBillingLog["statuscode"].ToString();
                        addBillinglog.Invoke();
                    }
                    catch (Exception ex)
                    {
                        ProcessAddGBLErrorLogs prcs = new ProcessAddGBLErrorLogs();
                        prcs.GBL_ERRORLOGS.AAA_IS_SCHEDULE = isSchedule.ToString();// ex.Message;
                        prcs.GBL_ERRORLOGS.AAA_SCHEDULE_ID = selectedScheduleId;
                        prcs.GBL_ERRORLOGS.AAA_ORDER_ID = orderId;
                        prcs.GBL_ERRORLOGS.AAA_SCHEDULELOG_DESC = "ERROR1 \r\n" + ErrorDetails(ex);
                        prcs.GBL_ERRORLOGS.AAA_LAST_MODIFIED_BY = gblenv.UserID;
                        prcs.InsertAAASchedulelog();
                    }
                }
                #endregion
                #region Send Billing
                //Send Billing
                FinancialBilling fnBill = new FinancialBilling();
                foreach (string eachAccession in accessionList)
                {
                    bool IsSendBilling = fnBill.CheckIsSendBilling(eachAccession);
                    if (IsSendBilling)
                    {
                        string ackMessage = BillingManagement.SUCCESS_SEND_BILLING;
                        if (!BillingManagement.SendBilling(eachAccession, gblenv.UserName, true))
                        {
                            ackMessage = BillingManagement.FAIL_SEND_BILLING;
                            messageBox.ShowAlert("UID6121", gblenv.CurrentLanguageID);
                        }
                        OrderManagement.UpdateOrderHISSync(eachAccession,
                            ackMessage == BillingManagement.FAIL_SEND_BILLING ? "N" : "Y", ackMessage, gblenv.OrgID);
                        Thread.Sleep(100); //set thread sleep 100 msec
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("ขณะนี้ ส่งข้อมูลไปการเงินมีปัญหา", "Send Billing Fail!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProcessAddGBLErrorLogs prc = new ProcessAddGBLErrorLogs();
                prc.GBL_ERRORLOGS.AAA_IS_SCHEDULE = isSchedule.ToString();// ex.Message;
                prc.GBL_ERRORLOGS.AAA_SCHEDULE_ID = selectedScheduleId;
                prc.GBL_ERRORLOGS.AAA_ORDER_ID = orderId;
                prc.GBL_ERRORLOGS.AAA_SCHEDULELOG_DESC = "ERROR2 \r\n" + ErrorDetails(ex);
                prc.GBL_ERRORLOGS.AAA_LAST_MODIFIED_BY = gblenv.UserID;
                //prc.InsertAAASchedulelog();
            }
            accessionList = null;
            return orderId;
        }
        private DateTime convertHISDate(string dateHIS)
        {
            if (string.IsNullOrEmpty(dateHIS))
                return DateTime.MinValue;
            string[] arr1 = dateHIS.Split('/');
            string[] arr2 = arr1[2].Split(' ');
            string[] arr3 = arr2[1].Split(':');
            DateTime dateTime = new DateTime(Convert.ToInt32(arr2[0]), Convert.ToInt32(arr1[1]), Convert.ToInt32(arr1[0]), Convert.ToInt32(arr3[0]), Convert.ToInt32(arr3[1]), Convert.ToInt32(arr3[2]));

            return dateTime;
        }
        
        private void SaveScreen(Exception ex)
        {
            GBLEnvVariable env = new GBLEnvVariable();
            EnvisionWebService ws = new EnvisionWebService(env.WebServiceIP);

            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmp as Image);
            g.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            string _path = ConfigurationSettings.AppSettings["errorImagesPath"].ToString();

            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
            string day = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();


            ProcessAddGBLErrorLogs prc = new ProcessAddGBLErrorLogs();
            prc.GBL_ERRORLOGS.ERROR_MESSAGE = ErrorDetails(ex);// ex.Message;
            prc.GBL_ERRORLOGS.ERROR_SOURCE = ex.Source;
            prc.GBL_ERRORLOGS.USER_HOST_ADDRESS = Utilities.IPAddress();
            prc.GBL_ERRORLOGS.USER_LOGIN = env.UserName;
            prc.GBL_ERRORLOGS.CREATED_BY = env.UserID;
            prc.GBL_ERRORLOGS.ERROR_FORM = "frmConfirmArrivalWorkList";
            prc.Invoke();

            string image_path = string.Format(
                "{0}\\{1}\\{2:HHmmssfff}_{3}.jpg",
                year + month,
                year + month + day,
                DateTime.Now,
                prc.GBL_ERRORLOGS.ERROR_ID.ToString()
                );

            ProcessUpdateGBLErrorLogs prcUpdate = new ProcessUpdateGBLErrorLogs();
            prcUpdate.GBL_ERRORLOGS.ERROR_ID = prc.GBL_ERRORLOGS.ERROR_ID;
            prcUpdate.GBL_ERRORLOGS.PIC_PATH = image_path;
            prcUpdate.Invoke();

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                    ms.Position = 0;
                    byte[] img = new byte[ms.Length];
                    ms.Read(img, 0, Convert.ToInt32(ms.Length));

                    ws.SavePicture(_path + image_path, img);
                }

            }
            catch (Exception exx)
            {
                image_path = string.Empty;

                ws.SaveClientLog("ScanImage", exx.Message);
            }
        }
        private string ErrorDetails(Exception exception)
        {
            string exceptionString = "";
            try
            {
                int i = 0;
                while (exception != null)
                {
                    exceptionString += "*** Exception Level " + i + "***\n";
                    exceptionString += "Message: " + exception.Message + "\n";
                    exceptionString += "Source: " + exception.Source + "\n";
                    exceptionString += "Target Site: " + exception.TargetSite + "\n";
                    exceptionString += "Stack Trace: " + exception.StackTrace + "\n";
                    exceptionString += "Data: ";
                    foreach (System.Collections.DictionaryEntry keyValuePair in
                    exception.Data)
                        exceptionString += keyValuePair.Key.ToString()
                        + ":" + keyValuePair.Value.ToString();

                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(exception, true);
                    Console.WriteLine();
                    exceptionString += "\r\n" + "Line: " + trace.GetFrame(0).GetFileLineNumber();
                    exceptionString += "\n***\n\n";

                    exception = exception.InnerException;

                    i++;
                }
            }
            catch { }

            return exceptionString;
        }
        #region :: Editor Event ::
        private void cbThaiTitleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbEngTitleName.SelectedIndex = this.cbThaiTitleName.SelectedIndex;
            //if (cbEngTitleName.SelectedIndex >= 0)
            //{
                //Filter_TitleName titleTH = cbEngTitleName.SelectedItem as Filter_TitleName;
                //cbEngTitleName.SelectedIndex = cbThaiTitleName.SelectedIndex;
            //}
        }
        private void cbEngTitleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbThaiTitleName.SelectedIndex = this.cbEngTitleName.SelectedIndex;
            //if (cbEngTitleName.SelectedIndex >= 0)
            //{
                //Filter_TitleName titleEng = cbEngTitleName.SelectedItem as Filter_TitleName;
                //cbThaiTitleName.SelectedIndex = cbEngTitleName.SelectedIndex;
            //}
        }
        private void dtLMP_EditValueChanged(object sender, EventArgs e)
        {
            if (dtLMP.EditValue != null)
            {
                if ((DateTime)dtLMP.EditValue == DateTime.MinValue)
                    this.dtLMP.EditValue = null;
            }
        }
        private void cmbGRa_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (this.viewExamList.FocusedRowHandle >= 0)
                if (e.Value != null)
                    this.dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["ASSIGN_TO"] = Convert.ToInt32(e.Value);
        }
        private void _repDateEdit_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (this.viewExamList.FocusedRowHandle >= 0)
                this.dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["EXAM_DT"] = Convert.ToDateTime(e.Value);
        }
        private void _repModality_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            e.AcceptValue = true;
            if (this.viewExamList.FocusedRowHandle >= 0)
                this.dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["MODALITY_ID"] = Convert.ToInt32(e.Value);
        }
        private void _repClinic_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            e.AcceptValue = true;
            if (this.viewExamList.FocusedRowHandle >= 0)
            {
                this.dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["CLINIC_TYPE_ID"] = Convert.ToInt32(e.Value);
                DataTable dtCln = RISBaseData.RIS_ClinicType();
                DataRow[] rowsClinic = dtCln.Select("CLINIC_TYPE_ID = " + Convert.ToInt32(e.Value));

                string CLINIC_UID = rowsClinic[0]["CLINIC_TYPE_UID"].ToString();

                DataRow row = viewExamList.GetDataRow(viewExamList.FocusedRowHandle);
                switch (CLINIC_UID)
                {
                    default:
                    case "Normal":
                        this.dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["EXAM_RATE"] = chkNonResident.Checked ? row["FOREIGN_RATE"] : row["RGL_RATE"];
                        break;
                    case "Special":
                        this.dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["EXAM_RATE"] = chkNonResident.Checked ? row["FOREIGN_SPCIAL_RATE"] : row["SPECIAL_RATE"];
                        break;
                    case "VIP":
                        this.dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["EXAM_RATE"] = chkNonResident.Checked ? row["FOREIGN_VIP_RATE"] : row["VIP_RATE"];
                        break;
                }
                calTotal();
                dtCasesInfo.AcceptChanges();
                grdExamList.DataSource = dtCasesInfo;
            }
        }
        private void repPriority_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            e.AcceptValue = true;
            if (this.viewExamList.FocusedRowHandle >= 0)
                this.dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["PRIORITY"] = e.Value;
        }
        private void repBpview_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            e.AcceptValue = true;
            if (this.viewExamList.FocusedRowHandle >= 0)
            {
                if (!string.IsNullOrEmpty(e.Value.ToString()))
                {
                    DataTable dtBpviewAll = RISBaseData.BP_View();
                    DataRow[] rowBpview = dtBpviewAll.Select("BPVIEW_ID=" + e.Value.ToString());

                    dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["BPVIEW_ID"] = e.Value;
                    dtCasesInfo.Rows[this.viewExamList.FocusedRowHandle]["QTY"] = rowBpview[0]["NO_OF_EXAM"];
                    calTotal();
                }
            }
            dtCasesInfo.AcceptChanges();
            grdExamList.DataSource = dtCasesInfo;
        }
        private void calTotal()
        {
            decimal total = 0.0M;

            foreach (DataRow dr in dtCasesInfo.Rows)
            {
                decimal taxTemp = dr["EXAM_RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["EXAM_RATE"]);
                int qty = dr["QTY"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["QTY"]);
                total = taxTemp * qty;
                dr["RATE"] = total;
            }
        }
        #endregion

        #region :: Tools Bar ::
        private void barLabData_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_lab_data(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
                        //lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Lab_Clicks);
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
            }
            catch { messageBox.ShowAlert("UID4022", gblenv.CurrentLanguageID); }
        }
        private void barPatientAllergy_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_Adr(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
                        //lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Adr_Clicks);
                        lv.Text = "Alergy Detail List";
                        lv.Data = dsHIS.Tables[0];

                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.ShowBox();
                    }
                }
            }
            catch { }
        }
        private void barClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.tbInsuranceType.BackColor = this.bkBackColor; //restore back color
            this.Close();
        }
        private void barSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try 
            {

                this.Cursor = Cursors.WaitCursor;

                if (this.glkOrderingDept.EditValue == null || this.glkOrderingDoc.EditValue == null)
                {
                    if (string.IsNullOrEmpty(this.glkOrderingDept.EditValue.ToString()) || string.IsNullOrEmpty(this.glkOrderingDoc.EditValue.ToString()))
                    {
                        this.messageBox.ShowAlert("UID6123", gblenv.CurrentLanguageID);
                        return;
                    }
                }

                int orderID = this.BuildOrder(); // create order
                if (orderID > 0)
                {
                    _InputLogMultiOrder.AddLog(orderID, Utilities.IPAddress(), "frmConfirmArrivalWorkList_save");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch { }
            finally
            {
                Refresh();
                Thread.Sleep(100);
                EnvisionMultiClickHandler.FlushMouseMessages();
                this.Cursor = Cursors.Default;

            }

        }
        private void barSaveAndPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;

                if (this.glkOrderingDept.EditValue == null || this.glkOrderingDoc.EditValue == null)
                {
                    if (string.IsNullOrEmpty(this.glkOrderingDept.EditValue.ToString()) || string.IsNullOrEmpty(this.glkOrderingDoc.EditValue.ToString()))
                    {
                        this.messageBox.ShowAlert("UID6123", gblenv.CurrentLanguageID);
                        return;
                    }
                }

                int orderID = this.BuildOrder();
                if (orderID > 0)
                {
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    print.OrderEntryDirectPrint(orderID, 1, 1);

                    _InputLogMultiOrder.AddLog(orderID, Utilities.IPAddress(), "frmConfirmArrivalWorkList_saveprint");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch { }
            finally
            {
                Refresh();
                Thread.Sleep(100);
                EnvisionMultiClickHandler.FlushMouseMessages();
                this.Cursor = Cursors.Default;

            }
        }
        /// <summary>
        /// Scan form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmScanImage frm = new frmScanImage();
            frm.ShowDialog();
            frm.Dispose();
        }
        #endregion

        private void btnNextAppointment_Click(object sender, EventArgs e)
        {
            if (tbHN.Text.Trim().Length == 0) return;

            frmNextAppointment frmNextAppt = new frmNextAppointment(tbHN.Text.Trim());
            if (frmNextAppt.ShowDialog() == DialogResult.OK)
            {
                DataRow rowNewAppoint = frmNextAppt.returnNextAppointRow;
                DataRow[] rowRefUnit = dtRefUnit.Select("UNIT_UID='" + rowNewAppoint["appt_doc_dept_code"].ToString() + "'");
                if (rowRefUnit.Length > 0)
                    this.glkOrderingDept.EditValue = rowRefUnit[0]["UNIT_ID"].ToString();

                DataRow[] rowRefDoc = dtRefDoc.Select("EMP_UID='" + rowNewAppoint["appt_doc_code"].ToString() + "'");
                if (rowRefDoc.Length > 0)
                    this.glkOrderingDoc.EditValue = rowRefDoc[0]["EMP_ID"].ToString();

                string strAppDate = rowNewAppoint["appt_date"].ToString();
                if (string.IsNullOrEmpty(strAppDate))
                {
                    DateTime date = Convert.ToDateTime(strAppDate);
                    txtNextAppointment.Text = date.ToString("dd/MM/yyyy");
                }
            }
        }
        private void GetNextAppointment()
        {
            if (tbHN.Text.Trim().Length == 0) return;

            try
            {
                HIS_Patient nextAppt = new HIS_Patient();
                DataTable tb = nextAppt.Get_appointment_detail(tbHN.Text.Trim()).Tables[0];

                if (tb == null || tb.Rows.Count == 0) return;
                if (tb.Rows[0]["appt_date"].ToString().Trim().Length == 0) return;

                DateTime date = Convert.ToDateTime(tb.Rows[0]["appt_date"].ToString());
                txtNextAppointment.Text = date.ToString("dd/MM/yyyy");
            }
            catch
            {
                txtNextAppointment.Text = "";
            }
        }

        private void chkNonResident_CheckedChanged(object sender, EventArgs e)
        {
            dtCasesInfo.BeginLoadData();
            chkNonResident.ForeColor = chkNonResident.Checked ? Color.Red : Color.Black;

            foreach (DataRow drExam in this.dtCasesInfo.Rows)
            {

                DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + drExam["CLINIC_TYPE_ID"].ToString());
                string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
                switch (clinictypeName.ToUpper())
                {
                    case "SPECIAL": drExam["EXAM_RATE"] = chkNonResident.Checked ? drExam["FOREIGN_SPCIAL_RATE"] : drExam["SPECIAL_RATE"]; break;
                    case "VIP": drExam["EXAM_RATE"] = chkNonResident.Checked ? drExam["FOREIGN_VIP_RATE"] : drExam["VIP_RATE"]; break;
                    default: drExam["EXAM_RATE"] = chkNonResident.Checked ? drExam["FOREIGN_RATE"] : drExam["RGL_RATE"]; break;
                }
            }
            calTotal();
            dtCasesInfo.AcceptChanges();
            dtCasesInfo.EndLoadData();
        }

        private void bgUpdateHISData_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgUpdateHISData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInsuranceType();
            UpdateAdmissionNumber();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (viewExamList.FocusedRowHandle > -1)
            {
                DataRow row = viewExamList.GetDataRow(viewExamList.FocusedRowHandle);
                if (row == null) { e.Cancel = true; return; }
                if (row["EXAM_ID"].ToString().Trim() == string.Empty) { e.Cancel = true; return; }
                e.Cancel = false;

                DataRow[] rowExamFlag = dttExamFlag.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
                if (rowExamFlag.Length > 0)
                {
                    DataRow[] rowSelected = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowExamFlag[0]["EXAMFLAG_ID"].ToString());
                    contextcmb.SelectedIndex = dtExamFlagDTL.Rows.IndexOf(rowSelected[0]);
                }
                else
                    contextcmb.SelectedIndex = 0;
            }
            else
                e.Cancel = true;
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            ToolTipControlInfo info = null;
            try
            {
                if (e.SelectedControl == grdExamList)
                {
                    GridView view = grdExamList.GetViewAt(e.ControlMousePosition) as GridView;
                    if (view == null) return;
                    GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle >= 0)
                        {
                            DataRow rowDetail = view.GetDataRow(hi.RowHandle);

                            switch (hi.Column.FieldName)
                            {
                                case "FLAG_ICON":
                                    if (rowDetail["FLAG_ICON"].ToString() == "1")
                                    {
                                        DataRow[] rowFlag = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowDetail["EXAMFLAG_ID"].ToString());
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowFlag[0]["GEN_TEXT"].ToString());
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
                            case "FLAG_ICON": info = new ToolTipControlInfo(hi.HitTest, "Exam Flag"); break;
                            case "PRIORITY": info = new ToolTipControlInfo(hi.HitTest, "Priority"); break;
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
            if (viewExamList.FocusedRowHandle >= 0)
            {
                DataRow rowDtl = viewExamList.GetDataRow(viewExamList.FocusedRowHandle);
                DataRow[] rowCheck = dttExamFlag.Select("EXAM_ID=" + rowDtl["EXAM_ID"].ToString());
                int flag_id = 0;
                int order_id = 0;
                int schedule_id = this.selectedScheduleId;
                int xrayreq_id = this.selectedOrderId;
                if (rowCheck.Length > 0)
                {
                    order_id = string.IsNullOrEmpty(rowCheck[0]["ORDER_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["ORDER_ID"]);
                    schedule_id = string.IsNullOrEmpty(rowCheck[0]["SCHEDULE_ID"].ToString()) ? this.selectedScheduleId : Convert.ToInt32(rowCheck[0]["SCHEDULE_ID"]);
                    xrayreq_id = string.IsNullOrEmpty(rowCheck[0]["XRAYREQ_ID"].ToString()) ? this.selectedOrderId : Convert.ToInt32(rowCheck[0]["XRAYREQ_ID"]);
                    flag_id = string.IsNullOrEmpty(rowCheck[0]["FLAG_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["FLAG_ID"]);
                    dttExamFlag.Rows.Remove(rowCheck[0]);
                }
                dttExamFlag.AcceptChanges();

                TraumaItems trauma = contextcmb.SelectedItem as TraumaItems;
                DataRow rowAdd = dttExamFlag.NewRow();
                rowAdd["FLAG_ID"] = flag_id;
                rowAdd["ORDER_ID"] = order_id;
                rowAdd["SCHEDULE_ID"] = schedule_id;
                rowAdd["XRAYREQ_ID"] = xrayreq_id;
                rowAdd["EXAM_ID"] = rowDtl["EXAM_ID"].ToString();
                rowAdd["EXAMFLAG_ID"] = trauma.Trauma_id();
                rowAdd["REASON"] = "";
                dttExamFlag.Rows.Add(rowAdd);
                dttExamFlag.AcceptChanges();

                DataRow rowData = viewExamList.GetDataRow(viewExamList.FocusedRowHandle);
                rowData["FLAG_ICON"] = trauma.Trauma_id() == 72 ? 0 : trauma.Trauma_Seq();
                rowData["EXAMFLAG_ID"] = trauma.Trauma_id();
                viewExamList.RefreshData();
            }
        }

        private void chkRequestResult_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRequestResult.Checked)
            {
                dtRequestResult.Enabled = true;
                timeReqeustResult.Enabled = true;
            }
            else
            {
                dtRequestResult.Enabled = false;
                timeReqeustResult.Enabled = false;
            }
        }

        private void viewExamList_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            try
            {
                string strqty = e.FocusedColumn.FieldName;
                if (viewExamList.FocusedRowHandle > -1)
                {
                    DataRow dr = viewExamList.GetDataRow(viewExamList.FocusedRowHandle);
                    if (dr["EXAM_UID"].ToString() != string.Empty)
                    {
                        if (strqty == "QTY")
                        {
                            DataRow[] drbp = RISBaseData.BP_View().Select("BPVIEW_ID =" + dr["BPVIEW_ID"].ToString());
                            if (drbp[0]["BPVIEW_NAME"].ToString() == "Other")
                            {
                                viewExamList.Columns["QTY"].OptionsColumn.ReadOnly = false;
                            }
                            else
                            {
                                viewExamList.Columns["QTY"].OptionsColumn.ReadOnly = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void viewExamList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                string strqty = viewExamList.FocusedColumn.FieldName;
                if (viewExamList.FocusedRowHandle > -1)
                {
                    DataRow dr = viewExamList.GetDataRow(viewExamList.FocusedRowHandle);
                    if (dr["EXAM_UID"].ToString() != string.Empty)
                    {
                        if (strqty == "QTY")
                        {
                            DataRow[] drbp = RISBaseData.BP_View().Select("BPVIEW_ID =" + dr["BPVIEW_ID"].ToString());
                            if (drbp[0]["BPVIEW_NAME"].ToString() == "Other")
                            {
                                viewExamList.Columns["QTY"].OptionsColumn.ReadOnly = false;
                            }
                            else
                            {
                                viewExamList.Columns["QTY"].OptionsColumn.ReadOnly = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void speQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                SendKeys.Send("{Tab}");
                return;
            }
        }
    }
}