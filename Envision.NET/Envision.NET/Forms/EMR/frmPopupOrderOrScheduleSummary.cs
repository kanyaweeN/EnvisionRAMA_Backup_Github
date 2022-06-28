using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Linq;
using Envision.BusinessLogic.ProcessRead;
using Envision.WebService.EMROERWebService;
using Envision.BusinessLogic;
using System.Threading;
using System.Net;
using Miracle.Scanner;
using Envision.NET.Forms.Comment;
using Miracle.PACS;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Common;
using Envision.BusinessLogic.ProcessDelete;
using Miracle.Util;
using DevExpress.XtraGrid;
using Envision.Operational.PACS;

namespace Envision.NET.Forms.EMR
{
    public partial class frmPopupOrderOrScheduleSummary : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        /// <summary>
        /// Page mode enum 
        /// 1. Order : show order summary mode
        /// 2. Schedule : show schedule summary mode
        /// </summary>
        public enum PagesModes
        {
            Order, Schedule
        }
        private int _selectedOrderIdOrScheduleId = 0;
        private int _selectedExamId = 0;
        private int _selectedRegId = 0;
        private string _selectedAccessionNo = string.Empty;
        private string _selectedImageUrl = string.Empty;
        private string _selectedHN = string.Empty;
        private bool _isOnline = false;
        private Envision.Common.GBLEnvVariable _gblEnv;
        private DataTable _scheduleExamDataTable;
        private DataTable _emoerDataTable;
        private PagesModes _pageMode = PagesModes.Order;
        private EMROERWebService _emoerWebService;
        private Thread _threadLoadEMOER;
        private Thread _threadLoadLabData;
        private Thread _threadLoadAllery;
        private Thread _threadLoadNextAppointment;
        private DevExpress.Utils.WaitDialogForm waitDialog;
        private DevExpress.XtraTab.XtraTabPage _backupXtrPage;
        private HIS_Patient _hisPatientWebService;
        private Envision.WebService.HISWebService.Service _hisWebService;
        private Envision.NET.Reports.ReportViewer.frmXtraReportViewer htmlViwer;
        private frmComment _commentForm;
        private frmMessageConversation _messageForm;
        private bool ShortcutToLabdata = false;
        private bool ShortcutToHISAllergy = false;
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        Miracle.UserControls.HISPatientPhotoForm ptPhoto
            = new Miracle.UserControls.HISPatientPhotoForm();

        private int riskMode;// 0=order,1=schedule,2=request_online
        private int risk_order_id, risk_schedule_id, risk_xrayreq_id;
        private DataTable creatinine = new DataTable();

        /// <summary>
        /// Get or set page mode
        /// </summary>
        public PagesModes PageMode
        {
            get { return _pageMode; }
            set
            {
                _pageMode = value;
                this.SetFormMode();
            }
        }
        /// <summary>
        /// constructor
        /// </summary>
        public frmPopupOrderOrScheduleSummary()
        {
            InitializeComponent();
            this._gblEnv = new Envision.Common.GBLEnvVariable();
            this.PageMode = PagesModes.Order;
            this._emoerWebService = new EMROERWebService();
            this._hisPatientWebService = new HIS_Patient();
            this._hisWebService = new Envision.WebService.HISWebService.Service();
            this._messageForm = new frmMessageConversation();
            this._backupXtrPage = this.xtraTabOrderPage;

            this.xtraTabLayoutControl.SelectedTabPage = xtraTabOrderPage;
        }
        private void frmPopupOrderOrScheduleSummary_Load(object sender, EventArgs e)
        {
            if (ShortcutToLabdata)
            {
                this.rbgOutOfBrowser.Visible = false;
                this.rbgMain.Visible = false;
                this.rbgBack.Visible = true;
                this.xtraTabLayoutControl.SelectedTabPage = this.xtraTabLabData;
                ShortcutToLabdata = false;
            }
            else if (ShortcutToHISAllergy)
            {
                this.rbgOutOfBrowser.Visible = false;
                this.rbgMain.Visible = false;
                this.rbgBack.Visible = true;
                this.xtraTabLayoutControl.SelectedTabPage = this.xtraTabAllergy;
                this.xtratabRiskmanagement.SelectedTabPageIndex = 1;
                loadHisAllergy();
                ShortcutToHISAllergy = false;
            }
        }

        /// <summary>
        /// This overload method use to show dialog with order/schedule id and page mode
        /// </summary>
        /// <param name="orderOrScheduleId">Order or Schedule Id</param>
        /// <param name="pageMode">Page mode</param>
        /// <returns>True/false</returns>
        public DialogResult ShowDialog(bool is_showDialog,int regId, int orderOrScheduleId, int selectedExamId, PagesModes pageMode)
        {
            if (is_showDialog)
            {
                this.PageMode = pageMode;
                this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                this._selectedExamId = selectedExamId;
                this._selectedRegId = regId;
                this.LoadFormData(); // set form data
                return this.ShowDialog();
            }
            else
            {
                if (!CheckOpened(this.Text))
                {
                    this.PageMode = pageMode;
                    this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                    this._selectedExamId = selectedExamId;
                    this._selectedRegId = regId;
                    this.LoadFormData(); // set form data
                    this.Show();
                }
                else
                {
                    this.PageMode = pageMode;
                    this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                    this._selectedExamId = selectedExamId;
                    this._selectedRegId = regId;
                    this.LoadFormData(); // set form data
                }
                return DialogResult.OK;
            }
        }
        public DialogResult ShowDialog(bool is_showDialog, int regId, int orderOrScheduleId, int selectedExamId, PagesModes pageMode, bool isOnline)
        {
            if (is_showDialog)
            {
                this.PageMode = pageMode;
                this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                this._selectedExamId = selectedExamId;
                this._selectedRegId = regId;
                this._isOnline = isOnline;
                this.LoadFormData(); // set form data
                return this.ShowDialog();
            }
            else
            {
                if (!CheckOpened(this.Text))
                {
                    this.PageMode = pageMode;
                    this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                    this._selectedExamId = selectedExamId;
                    this._selectedRegId = regId;
                    this._isOnline = isOnline;
                    this.LoadFormData(); // set form data
                    this.Show();
                }
                else
                {
                    this.PageMode = pageMode;
                    this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                    this._selectedExamId = selectedExamId;
                    this._selectedRegId = regId;
                    this._isOnline = isOnline;
                    this.LoadFormData(); // set form data
                }
                return DialogResult.OK;
            }
        }
        public DialogResult ShowDialog(bool is_showDialog, string HN, int orderOrScheduleId, int selectedExamId, PagesModes pageMode, bool is_labSchedule)
        {
            if (is_showDialog)
            {
                this.PageMode = pageMode;
                this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                this._selectedExamId = selectedExamId;
                this._selectedHN = HN;
                this.ShortcutToLabdata = is_labSchedule;
                this.LoadFormData(); // set form data
                return this.ShowDialog();
            }
            else
            {
                if (!CheckOpened(this.Text))
                {
                    //Envision.BusinessLogic.RISBaseData.
                    this.PageMode = pageMode;
                    this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                    this._selectedExamId = selectedExamId;
                    this._selectedHN = HN;
                    this.ShortcutToLabdata = is_labSchedule;
                    this.LoadFormData(); // set form data
                    this.Show();
                }
                else
                {
                    this.PageMode = pageMode;
                    this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                    this._selectedExamId = selectedExamId;
                    this._selectedHN = HN;
                    this.ShortcutToLabdata = is_labSchedule;
                    this.LoadFormData(); // set form data
                }
                return DialogResult.OK;
            }
        }
        /// <summary>
        /// This overload method use to show dialog with accession no
        /// </summary>
        /// <param name="accessionNo"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(bool is_showDialog, string accessionNo)
        {
            if (is_showDialog)
            {
                this._selectedAccessionNo = accessionNo;
                this.PageMode = PagesModes.Order;
                this.LoadFormData(0); // set form data with ordered 
                return this.ShowDialog();
            }
            else
            {
                if (!CheckOpened(this.Text))
                {
                    this._selectedAccessionNo = accessionNo;
                    this.PageMode = PagesModes.Order;
                    this.LoadFormData(0); // set form data with ordered 
                    this.Show();
                }
                else
                {
                    this._selectedAccessionNo = accessionNo;
                    this.PageMode = PagesModes.Order;
                    this.LoadFormData(0); // set form data with ordered 
                }
                return DialogResult.OK;
            }
        }

        public DialogResult ShowDialogWithLabData(bool is_showDialog, string accessionNo)
        {
            if (is_showDialog)
            {
                this._selectedAccessionNo = accessionNo;
                this.PageMode = PagesModes.Order;
                this.LoadFormData(0); // set form data with ordered 
                this.ShortcutToLabdata = true;
                return this.ShowDialog();
            }
            else
            {
                if (!CheckOpened(this.Text))
                {
                    this._selectedAccessionNo = accessionNo;
                    this.PageMode = PagesModes.Order;
                    this.LoadFormData(0); // set form data with ordered 
                    this.ShortcutToLabdata = true;
                    this.Show();
                }
                else {
                    this._selectedAccessionNo = accessionNo;
                    this.PageMode = PagesModes.Order;
                    this.LoadFormData(0); // set form data with ordered 
                    this.ShortcutToLabdata = true;
                }
                return DialogResult.OK;
            }
        }

        public DialogResult ShowDialogShortcut(bool is_showDialog, string accessionNo, string barName)
        {
            switch (barName.ToLower())
            {
                case "allergy" :
                    ShortcutToHISAllergy = true;
                    ShortcutToLabdata = false;
                break;
            }
                
            if (is_showDialog)
            {
                this._selectedAccessionNo = accessionNo;
                this.PageMode = PagesModes.Order;
                this.LoadFormData(0); // set form data with ordered 
                return this.ShowDialog();
            }
            else
            {
                if (!CheckOpened(this.Text))
                {
                    this._selectedAccessionNo = accessionNo;
                    this.PageMode = PagesModes.Order;
                    this.LoadFormData(0); // set form data with ordered 
                    this.Show();
                }
                else
                {
                    this._selectedAccessionNo = accessionNo;
                    this.PageMode = PagesModes.Order;
                    this.LoadFormData(0); // set form data with ordered 
                }
                return DialogResult.OK;
            }
        }
        public DialogResult ShowDialogShortcut(bool is_showDialog, string HN, int orderOrScheduleId, int selectedExamId, PagesModes pageMode, bool is_labSchedule, string barName)
        {
            switch (barName.ToLower())
            {
                case "allergy":
                    ShortcutToHISAllergy = true;
                    ShortcutToLabdata = false;
                break;
            }

            if (is_showDialog)
            {
                this.PageMode = pageMode;
                this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                this._selectedExamId = selectedExamId;
                this._selectedHN = HN;
                //this.ShortcutToLabdata = is_labSchedule;
                this.LoadFormData(); // set form data
                return this.ShowDialog();
            }
            else
            {
                if (!CheckOpened(this.Text))
                {
                    //Envision.BusinessLogic.RISBaseData.
                    this.PageMode = pageMode;
                    this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                    this._selectedExamId = selectedExamId;
                    this._selectedHN = HN;
                    //this.ShortcutToLabdata = is_labSchedule;
                    this.LoadFormData(); // set form data
                    this.Show();
                }
                else
                {
                    this.PageMode = pageMode;
                    this._selectedOrderIdOrScheduleId = orderOrScheduleId;
                    this._selectedExamId = selectedExamId;
                    this._selectedHN = HN;
                    //this.ShortcutToLabdata = is_labSchedule;
                    this.LoadFormData(); // set form data
                }
                return DialogResult.OK;
            }
        }
        /// <summary>
        /// This method use to set form data for ordered mode
        /// </summary>
        /// <param name="take">take number</param>
        private void LoadFormData(int take)
        {
            ProcessGetRISTechConsumptionForOrderSummary _processGetRISTechConsumptionForOrderSummary;
            ProcessGetRISTechWorkForOrderSummary _processGetRISTechWorkForOrderSummary;
            ProcessGetRISOrderForOrderSummary _processGetRISOrderForOrderSummary;
            try
            {
                _processGetRISOrderForOrderSummary = new ProcessGetRISOrderForOrderSummary();
                _processGetRISOrderForOrderSummary.RIS_ORDERDTL.ACCESSION_NO = this._selectedAccessionNo;
                _processGetRISOrderForOrderSummary.RIS_ORDERDTL.ORG_ID = this._gblEnv.OrgID;
                _processGetRISOrderForOrderSummary.Invoke();
                if (_processGetRISOrderForOrderSummary.Result.Tables.Count > 0)
                {
                    if (_processGetRISOrderForOrderSummary.Result.Tables[0].Rows.Count > 0)
                    {
                        DataRow selectedRow = _processGetRISOrderForOrderSummary.Result.Tables[0].Rows[0];
                        this._selectedOrderIdOrScheduleId = Convert.ToInt32(selectedRow["ORDER_ID"]);
                        this._selectedRegId = Convert.ToInt32(selectedRow["REG_ID"]);
                        //FILL DEMOGRAPHIC
                        this.tbHN.Text = selectedRow["HN"].ToString();
                        this.tbPatientName.Text = selectedRow["PATIENT_NAME"].ToString();
                        this.tbGender.Text = selectedRow["GENDER"].ToString();
                        this.tbDOB.Text = Convert.ToDateTime(selectedRow["DOB"]).ToString("dd/MM/yyyy");
                        this.tbAge.Text = selectedRow["AGE"].ToString();
                        this.tbOrderingDept.Text = selectedRow["ORDERING_UNIT"].ToString();
                        this.tbOrderingDoc.Text = selectedRow["ORDERING_DOC"].ToString();
                        this.tbAmbulatoryStatus.Text = selectedRow["PATIENT_STATUS"].ToString();

                        //FILL EXAM DATA
                        this.tbOrderId.Text = selectedRow["ORDER_ID"].ToString();
                        this.tbOrderDate.Text = Convert.ToDateTime(selectedRow["ORDER_DT"]).ToString("dd/MM/yyyy");
                        this.tbModality.Text = selectedRow["MODALITY_NAME"].ToString();
                        this.tbExamCode.Text = selectedRow["EXAM_UID"].ToString();
                        this.tbExamName.Text = selectedRow["EXAM_NAME"].ToString();
                        this.tbPriority.Text = selectedRow["PRIORITY"].ToString();
                        this.tbClinicType.Text = selectedRow["CLINIC_TYPE"].ToString();
                        this.tbAccessionNo.Text = _selectedAccessionNo; // no accession
                        this.tbLMP.Text = string.IsNullOrEmpty(selectedRow["LMP_DT"].ToString()) ? Convert.ToDateTime(selectedRow["LMP_DT"]).ToString("dd/MM/yyyy") : "-";
                        this.tbEncType.Text = selectedRow["ENC_TYPE"].ToString();
                        this.mmeComments.Text = !string.IsNullOrEmpty(selectedRow["COMMENTS"].ToString()) ? selectedRow["COMMENTS"].ToString() : "-";
                        if (!string.IsNullOrEmpty(selectedRow["PENDING_COMMENTS"].ToString()))
                        {
                            this.memPendingComments.Text = selectedRow["PENDING_COMMENTS"].ToString();
                            this.lblPendingName.Text = "Pending Name : " + selectedRow["PENDING_NAME"].ToString() + " " + Convert.ToDateTime(selectedRow["PENDING_ON"]).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            this.memPendingComments.Text = "-";
                            this.lblPendingName.Text = "Pending Name : -";
                        }

                        //this.tbEncType.Text = string.IsNullOrEmpty(selectedRow["LMP_DT"].ToString()) ? Convert.ToDateTime(selectedRow["LMP_DT"]).ToString("dd/MM/yyyy") : "-"; // no period
                        if (!string.IsNullOrEmpty(selectedRow["ORDER_START_TIME"].ToString())
                            && !string.IsNullOrEmpty(selectedRow["EST_START_TIME"].ToString()))
                        {
                            // CALCULATE ARRIVAL TIME DELAY
                            TimeSpan orderStartTime = Convert.ToDateTime(selectedRow["ORDER_START_TIME"]).TimeOfDay;
                            this.tbDelay.Text = DateTime.Now.Add(orderStartTime).ToString("HH:mm:ss"); //delay time
                            this.tbArrivalTime.Text = string.Format("{0:00}:{1:00}:{2:00}", orderStartTime.Hours, orderStartTime.Minutes, orderStartTime.Seconds); // arrival time
                            //TimeSpan estStartTime = Convert.ToDateTime(selectedRow["EST_START_TIME"]).TimeOfDay;
                        }

                        //CLINICAL INDICATION AND ICD
                        this.mmClinicalInstruction.Text = selectedRow["CLINICAL_INSTRUCTION"].ToString();
                        if (_processGetRISOrderForOrderSummary.Result.Tables.Count > 1)
                            this.gridICDControl.DataSource = _processGetRISOrderForOrderSummary.Result.Tables[1];
                    }
                }

                // TECH WORK
                _processGetRISTechWorkForOrderSummary = new ProcessGetRISTechWorkForOrderSummary();
                _processGetRISTechWorkForOrderSummary.RIS_TECHWORK.ACCESSION_ON = this._selectedAccessionNo;
                _processGetRISTechWorkForOrderSummary.RIS_TECHWORK.TAKE = (byte)take;
                _processGetRISTechWorkForOrderSummary.RIS_TECHWORK.ORG_ID = this._gblEnv.OrgID;
                _processGetRISTechWorkForOrderSummary.Invoke();
                if (_processGetRISTechWorkForOrderSummary.Result.Tables.Count > 0)
                {
                    if (_processGetRISTechWorkForOrderSummary.Result.Tables[0].Rows.Count > 0)
                    {
                        DataRow selectedRow = _processGetRISTechWorkForOrderSummary.Result.Tables[0].Rows[0];
                        //FILL DATA
                        this.tbKV.Text = selectedRow["KV"].ToString();
                        this.tbmA.Text = selectedRow["mA"].ToString();
                        this.tbNoOfImage.Text = selectedRow["NO_OF_IMAGES"].ToString();
                        this.tbPerformedByName.Text = selectedRow["USER_NAME"].ToString();
                        this.tbSec.Text = selectedRow["SEC"].ToString();
                        this.tbTake.Text = selectedRow["TAKE"].ToString();

                        this.mmExposureTechique.Text = selectedRow["EXPOSURE_TECHNIQUE"].ToString();
                        this.mmProtocol.Text = selectedRow["PROTOCOL"].ToString();
                    }
                }
                // CONSUMPTION
                _processGetRISTechConsumptionForOrderSummary = new ProcessGetRISTechConsumptionForOrderSummary();
                _processGetRISTechConsumptionForOrderSummary.RIS_TECHCONSUMPTION.ACCESSION_NO = this._selectedAccessionNo;
                _processGetRISTechConsumptionForOrderSummary.RIS_TECHCONSUMPTION.TAKE = (byte)(take > 1 ? take - 1 : take);
                _processGetRISTechConsumptionForOrderSummary.RIS_TECHCONSUMPTION.ORG_ID = this._gblEnv.OrgID;
                _processGetRISTechConsumptionForOrderSummary.Invoke();
                if(_processGetRISTechConsumptionForOrderSummary.Result.Tables.Count > 0)
                    this.gridConsumptionControl.DataSource = _processGetRISTechConsumptionForOrderSummary.Result.Tables[0];

                loadRISRiskDataOrder(_selectedOrderIdOrScheduleId);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                this.ResetSummaryEditorData();
            }
            finally { }
        }

        /// <summary>
        /// this method use to set form data
        /// </summary>
        private void LoadFormData()
        {
            ProcessGetXrayAndRISScheduleSummary _processGetXrayAndRISScheduleSummary = null;
            try
            {
                // TECH WORK
                this.tbKV.Text = "-";
                this.tbmA.Text = "-";
                this.tbNoOfImage.Text = "-";
                this.tbPerformedByName.Text = "-";
                this.tbSec.Text = "-";
                this.tbTake.Text = "-";
                this.mmExposureTechique.Text = string.Empty;
                this.mmProtocol.Text = string.Empty;

                _processGetXrayAndRISScheduleSummary = new ProcessGetXrayAndRISScheduleSummary();
                _processGetXrayAndRISScheduleSummary.ORG_ID = _gblEnv.OrgID;
                if (_selectedRegId != 0)
                    _processGetXrayAndRISScheduleSummary.REG_ID = _selectedRegId;
                else
                    _processGetXrayAndRISScheduleSummary.HN = _selectedHN;
                _processGetXrayAndRISScheduleSummary.ID = _selectedOrderIdOrScheduleId;
                _processGetXrayAndRISScheduleSummary.EXAM_ID = _selectedExamId;
                if (_pageMode == PagesModes.Order)
                {
                    _processGetXrayAndRISScheduleSummary.MODE = 0; // QUERY ORDER
                    loadRISRiskDataRequestXray(_selectedOrderIdOrScheduleId);
                }
                else
                {
                    _processGetXrayAndRISScheduleSummary.MODE = 1; // QUERY SCHEDULE
                    loadRISRiskDataSchedule(_selectedOrderIdOrScheduleId);
                }
                _processGetXrayAndRISScheduleSummary.Invoke();
                DataSet dsResult = _processGetXrayAndRISScheduleSummary.Result;



                if (dsResult != null)
                {
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            DataRow selectedRow = dsResult.Tables[0].Rows[0];
                            // FILL DATA FOR PATIENT DEMOGRAPHIC
                            this._selectedRegId = Convert.ToInt32(selectedRow["REG_ID"]);
                            this.tbHN.Text = selectedRow["HN"].ToString();
                            this.tbPatientName.Text = selectedRow["PATIENT_NAME"].ToString();
                            this.tbGender.Text = selectedRow["GENDER"].ToString();
                            this.tbDOB.Text = Convert.ToDateTime(selectedRow["DOB"]).ToString("dd/MM/yyyy");
                            this.tbAge.Text = selectedRow["AGE"].ToString();
                            this.tbOrderingDept.Text = selectedRow["ORDERING_UNIT"].ToString();
                            this.tbOrderingDoc.Text = selectedRow["ORDERING_DOC"].ToString();
                            this.tbAmbulatoryStatus.Text = selectedRow["PATIENT_STATUS"].ToString();

                            // FILL DATA FOR EXAM
                            this.tbAccessionNo.Text = "-"; // no accession
                            this.tbArrivalTime.Text = "-"; // no arrival time
                            this.tbDelay.Text = "-"; //no delay time
                            this.tbLMP.Text = "-"; //no define lmp
                            this.tbEncType.Text = selectedRow["ENC_TYPE"].ToString();
                            this.mmeComments.Text = !string.IsNullOrEmpty(selectedRow["COMMENTS"].ToString()) ? selectedRow["COMMENTS"].ToString() : "-";
                            if (!string.IsNullOrEmpty(selectedRow["PENDING_NAME"].ToString()))
                            {
                                this.memPendingComments.Text = selectedRow["PENDING_COMMENTS"].ToString();
                                this.lblPendingName.Text = "Pending Name : " + selectedRow["PENDING_NAME"].ToString() + " " + Convert.ToDateTime(selectedRow["PENDING_ON"]).ToString("dd/MM/yyyy HH:mm");
                            }
                            else
                            {
                                this.memPendingComments.Text = string.IsNullOrEmpty(selectedRow["PENDING_COMMENTS"].ToString()) ? "-" : selectedRow["PENDING_COMMENTS"].ToString();
                                this.lblPendingName.Text = "Pending Name : -";
                            }

                            // CLINICAL INSTRUCTION
                            this.mmClinicalInstruction.Text = selectedRow["CLINICAL_INSTRUCTION"].ToString();
                            this.txtPatientIdDetail.Text = selectedRow["PATIENT_ID_LABEL"].ToString();
                            
                            if (_pageMode == PagesModes.Order)
                            {
                                // SPECIFY FOR ORDER
                                this.tbOrderId.Text = selectedRow["ORDER_ID"].ToString();
                                this.tbOrderDate.Text = Convert.ToDateTime(selectedRow["ORDER_DT"]).ToString("dd/MM/yyyy");
                                this.tbModality.Text = selectedRow["MODALITY_NAME"].ToString();
                                this.tbExamCode.Text = selectedRow["EXAM_UID"].ToString();
                                this.tbExamName.Text = selectedRow["EXAM_NAME"].ToString();
                                this.tbPriority.Text = selectedRow["PRIORITY"].ToString();
                                this.tbClinicType.Text = selectedRow["CLINIC_TYPE"].ToString();
                                //ICD
                                if (dsResult.Tables.Count > 1)
                                    this.gridICDControl.DataSource = dsResult.Tables[1];
                            }
                            else
                            {
                                //Schedule
                                // // SPECIFY FOR SCHEDULE
                                this.tbScheduleId.Text = selectedRow["SCHEDULE_ID"].ToString();
                                this.tbScheduleDate.Text = Convert.ToDateTime(selectedRow["SCHEDULE_DT"]).ToString("dd/MM/yyyy");
                                this.tbSessionTime.Text = selectedRow["SESSION_NAME"].ToString();
                                this.BuildScheduleExamDataSet(_processGetXrayAndRISScheduleSummary.Result);
                                this.gridAppointmentDataControl.DataSource = this._scheduleExamDataTable;
                                // Binding Exam
                                this.tbExamCode.DataBindings.Clear();
                                this.tbExamName.DataBindings.Clear();
                                this.tbExamCode.DataBindings.Add(new Binding("TEXT", this._scheduleExamDataTable, "EXAM_UID"));
                                this.tbExamName.DataBindings.Add(new Binding("TEXT", this._scheduleExamDataTable, "EXAM_NAME"));
                                DataRow[] selectedExamRows = this._scheduleExamDataTable.Select("EXAM_ID=" + this._selectedExamId);
                                if (selectedExamRows.Length > 0)
                                    // SET Selected row by exam id
                                    this.gridAppointmentDataView.FocusedRowHandle = this._scheduleExamDataTable.Rows.IndexOf(selectedExamRows[0]);
                                this.tbModality.Text = selectedRow["MODALITY_NAME"].ToString();
                                this.tbPriority.Text = "-"; // not set priority for schedule
                                this.tbStartTime.Text = Convert.ToDateTime(selectedRow["START_DATETIME"]).ToString("dd/MM/yyyy HH:mm");
                                this.tbEndTime.Text = Convert.ToDateTime(selectedRow["END_DATETIME"]).ToString("dd/MM/yyyy HH:mm");
                                // SCHEDULE HISTORY
                                if (dsResult.Tables.Count > 1)
                                {
                                        this.gridScheduleHistoryControl.DataSource = dsResult.Tables[1];
                                        this.gridScheduleHistoryView.Columns["CATEGORY"].GroupIndex = 1;
                                }
                                //ICD
                                if (dsResult.Tables.Count > 2)
                                    this.gridICDControl.DataSource = dsResult.Tables[2];
                            }
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
//#if DEBUG
//                MessageBox.Show(ex.Message);
//#endif
                this.ResetSummaryEditorData();
            }
            finally 
            {
                _processGetXrayAndRISScheduleSummary = null;
            }

        }

        /// <summary>
        /// This method use to load er clincial indication data
        /// </summary>
        private void LoadERClinicalIndicationData()
        {
            LookUpSelect lkpSelectData = null;
            try
            {
                //LOAD DATA FROM HIS WEBSERVICE
                this._emoerDataTable = this._emoerWebService.GetEMRbyMRN(this.tbHN.Text.Trim()).Tables[0];
                // ADD IS ENVISION COLUMN
                if (!this._emoerDataTable.Columns.Contains("IS_ENVISION"))
                {
                    this._emoerDataTable.Columns.Add("IS_ENVISION", typeof(string));
                    this._emoerDataTable.AcceptChanges();
                    foreach (DataRow eachRow in this._emoerDataTable.Rows)
                        eachRow["IS_ENVISION"] = "N";
                }
                // LOAD DATA FROM RIS DATABASE
                lkpSelectData= new LookUpSelect();
                DataSet dsOwner = lkpSelectData.SelectClinicalData(this.tbHN.Text.Trim());
                if (dsOwner.Tables.Count > 0)
                {
                    dsOwner.Tables[0].Columns.Add("IS_ENVISION", typeof(string));
                    dsOwner.Tables[0].AcceptChanges();
                    foreach (DataRow eachRow in dsOwner.Tables[0].Rows)
                    {
                        eachRow["IS_ENVISION"] = "Y";
                        DataRow dr = _emoerDataTable.NewRow();
                        dr.ItemArray = eachRow.ItemArray;
                        this._emoerDataTable.Rows.Add(dr);
                    }
                }

                //ADD DATETIME COLUMN
                if (!this._emoerDataTable.Columns.Contains(""))
                {
                    this._emoerDataTable.Columns.Add("v_datetime", typeof(DateTime));
                    this._emoerDataTable.AcceptChanges();
                }

                // MODIFIY DATETIME
                foreach (DataRow eachRow in this._emoerDataTable.Rows)
                {
                    try
                    {
                        string[] date_str = { };
                        string day = string.Empty;
                        string month = string.Empty;
                        string year = string.Empty;
                        if (eachRow["IS_ENVISION"].ToString() == "Y")
                        {
                            if (!string.IsNullOrEmpty(eachRow["v_date"].ToString()))
                            {
                                date_str = eachRow["v_date"].ToString().Split(new string[] { "/" }, StringSplitOptions.None);
                                day = date_str[1];
                                month = date_str[0];
                                year = date_str[2];
                                string new_date_str = string.Format("{0}/{1}/{2}", day, month, year);

                                eachRow["v_date"] = new_date_str;
                            }
                        }
                        date_str = eachRow["v_date"].ToString().Split(new string[] { "/" }, StringSplitOptions.None);
                        year = date_str[2];
                        month = date_str[1];
                        day = date_str[0];

                        string[] time_str = eachRow["v_time"].ToString().Split(new string[] { ":" }, StringSplitOptions.None);
                        int hour = Convert.ToInt32(time_str[0]);
                        int min = Convert.ToInt32(time_str[1]);

                        DateTime date_time = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), hour, min, 0);
                        //dr["v_datetime"] = date_time.ToString("dd/MM/yyyy HH:mm");
                        eachRow["v_datetime"] = date_time;
                        //DateTime dtTime = Convert.ToDateTime(eachRow["v_time"]);
                        //eachRow["v_datetime"] = Convert.ToDateTime(eachRow["v_date"]).Add(new TimeSpan(dtTime.Hour, dtTime.Minute, dtTime.Second)).ToString("dd/MM/yyyy HH:mm");
                    }
                    catch { }
                }

                //SORTING AND BINDING DATA
                DataView dvEmoer = new DataView(this._emoerDataTable);
                dvEmoer.Sort = "v_datetime desc"; //sorting
                if (this.gridPatientDataHisotoryControl.InvokeRequired)
                {
                    this.gridPatientDataHisotoryControl.Invoke(new MethodInvoker(delegate 
                        {
                            this.gridPatientDataHisotoryControl.DataSource = dvEmoer; //binding  
                        }));
                }
                //SET EDITOR BINDING
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        //CLEAR
                        this.tbStudyDate.DataBindings.Clear();
                        this.mmCadio.DataBindings.Clear();
                        this.mmClincial.DataBindings.Clear();
                        this.mmCns.DataBindings.Clear();
                        this.mmDiags.DataBindings.Clear();
                        this.mmExt.DataBindings.Clear();
                        this.mmGa.DataBindings.Clear();
                        this.mmGi.DataBindings.Clear();
                        this.mmHeent.DataBindings.Clear();
                        this.mmPH.DataBindings.Clear();
                        this.mmPI.DataBindings.Clear();
                        this.mmPlan.DataBindings.Clear();
                        this.mmRpr.DataBindings.Clear();
                        //SET
                        this.tbStudyDate.DataBindings.Add("TEXT", dvEmoer, "v_datetime");
                        this.mmCadio.DataBindings.Add("TEXT", dvEmoer, "cadio");
                        this.mmClincial.DataBindings.Add("TEXT", dvEmoer, "cc");
                        this.mmCns.DataBindings.Add("TEXT", dvEmoer, "cns");
                        this.mmDiags.DataBindings.Add("TEXT", dvEmoer, "diags");
                        this.mmExt.DataBindings.Add("TEXT", dvEmoer, "ext");
                        this.mmGa.DataBindings.Add("TEXT", dvEmoer, "ga");
                        this.mmGi.DataBindings.Add("TEXT", dvEmoer, "gi");
                        this.mmHeent.DataBindings.Add("TEXT", dvEmoer, "heent");
                        this.mmPH.DataBindings.Add("TEXT", dvEmoer, "ph");
                        this.mmPI.DataBindings.Add("TEXT", dvEmoer, "pi");
                        this.mmPlan.DataBindings.Add("TEXT", dvEmoer, "plan");
                        this.mmRpr.DataBindings.Add("TEXT", dvEmoer, "rpr");
                        this.waitDialog.Close();
                    }));
                }
            }
            catch (Exception ex) 
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //this.ResetERClinicalIndicationEditorData();
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.ResetERClinicalIndicationEditorData();
                        this.waitDialog.Close();
                    }));
                }
            }
            finally 
            { 
                lkpSelectData = null;
                if(this._threadLoadEMOER.IsAlive)
                    this._threadLoadEMOER.Abort();
            }
        }

        /// <summary>
        /// This method use to load lab data
        /// </summary>
        private void LoadLabData()
        {
            try
            {
                this._hisPatientWebService.Get_demographic_long(this.tbHN.Text.Trim());
                DataSet ds = this._hisPatientWebService.Get_lab_data(this.tbHN.Text.Trim());
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(delegate
                    {
                        DataRow[] drRows = ds.Tables[0].Select("", "lab_date desc");
                        DataTable newdtt = ds.Tables[0].Clone();
                        foreach (DataRow eachRow in drRows)
                        {
                            DataRow dr = newdtt.NewRow();
                            dr.ItemArray = eachRow.ItemArray;
                            newdtt.Rows.Add(dr);
                        }
                        this.gridLabDataControl.DataSource = newdtt;
                        this.waitDialog.Close();
                    }));
            }
            catch(Exception ex) 
            {
#if DEBUG
                //MessageBox.Show(ex.Message);
#endif
                //this.ResetLabDataEditorData();
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.ResetLabDataEditorData();
                        this.waitDialog.Close();
                    }));
                }
            }
            finally 
            {
                if(this._threadLoadLabData.IsAlive)
                    this._threadLoadLabData.Abort(); 
            }
        }

        /// <summary>
        /// This method use to load allergy data
        /// </summary>
        private void LoadAllergyData()
        {
            #region old มันมีปัญหาตอนโหลดหน้าครั้งแรก Codeตรงนี้มันเป็นทำงานแบบพร้อมกับฟังก์ชันอื่นด้วย(อยากรู้เพิ่มเติมหา googleนะ) แต่ตรงนี้มันไปเรียกใช้อะไรสักอย่างจากอีกงาน แต่อีกงานมันยังทำอันนั้นไม่เสร็จหรอยังไม่ได้ทำ ก็เลย error 
//            try
//            {
//                DataSet ds = this._hisPatientWebService.Get_Adr(this.tbHN.Text.Trim());
//                if (this.InvokeRequired)
//                {
//                    this.Invoke(new MethodInvoker(delegate 
//                        {
//                            this.gridAllergyControl.DataSource = ds.Tables[0];
//                            this.waitDialog.Close();
//                        }));
//                }
//            }
//            catch(Exception ex) 
//            {
//#if DEBUG
//                //MessageBox.Show(ex.Message);
//#endif
//                if (this.InvokeRequired)
//                {
//                    this.Invoke(new MethodInvoker(delegate
//                    {
//                        this.ResetAllergyData();
//                        this.waitDialog.Close();
//                    }));
//                }
//            }
//            finally 
//            {
//                if (this._threadLoadAllery.IsAlive)
//                    this._threadLoadAllery.Abort();
//            }
            #endregion

            try
            {
                DataSet ds = this._hisPatientWebService.Get_Adr(this.tbHN.Text.Trim());
                //if (this.InvokeRequired)
                //{
                    //this.Invoke(new MethodInvoker(delegate
                    //{
                        if (ds.Tables.Count > 0){
                            this.gridAllergyControl.DataSource = ds.Tables[0];
                        }
                        this.waitDialog.Close();
                    //}));
                //}
            }
            catch (Exception ex)
            {
#if DEBUG
                //MessageBox.Show(ex.Message);
#endif
                //if (this.InvokeRequired)
                //{
                    //this.Invoke(new MethodInvoker(delegate
                    //{
                        this.ResetAllergyData();
                        this.waitDialog.Close();
                    //}));
                //}
            }
            //finally
            //{
            //    if (this._threadLoadAllery.IsAlive)
            //        this._threadLoadAllery.Abort();
            //}
        }

        /// <summary>
        /// this method use to load scan order data
        /// </summary>
        private void LoadScanOrderData()
        {
            if (this._isOnline == true)
                return;
            ProcessGetRISOrderimages _processGetRISOrderImage = null;
            try
            {
                _processGetRISOrderImage = new ProcessGetRISOrderimages();
                if (PageMode == PagesModes.Order)
                    _processGetRISOrderImage.RIS_ORDERIMAGE.ORDER_ID = _selectedOrderIdOrScheduleId;
                else
                    _processGetRISOrderImage.RIS_ORDERIMAGE.SCHEDULE_ID = _selectedOrderIdOrScheduleId;
                _processGetRISOrderImage.Invoke();
                if (_processGetRISOrderImage.Result != null)
                {
                    if (_processGetRISOrderImage.Result.Tables.Count > 0)
                    {
                        this.gridScanOrderControl.DataSource = _processGetRISOrderImage.Result.Tables[0];
                        if (_processGetRISOrderImage.Result.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = _processGetRISOrderImage.Result.Tables[0].Rows[0];
                            PointerStruct.ImageUrl = this._gblEnv.PacsUrl2;
                            this._selectedImageUrl = PointerStruct.ImageUrl + "/" + dr["IMAGE_NAME"].ToString();
                            this.webBrowser2.Navigate(_selectedImageUrl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        /// <summary>
        /// This method use to load next appointment
        /// </summary>
        private void LoadNextAppointment()
        {
            try
            {
                DataTable dtt = _hisWebService.Get_appointment_detail(this.tbHN.Text.Trim()).Tables[0];
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.gridNextAptControl.DataSource = dtt;
                        this.waitDialog.Close();
                    }));
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.ResetNextAppointment();
                        this.waitDialog.Close();
                    }));
                }
            }
            finally
            {
                if (this._threadLoadNextAppointment.IsAlive)
                    this._threadLoadNextAppointment.Abort();
            }
        }

        /// <summary>
        /// This method use to build schudule exam dataset
        /// </summary>
        private void BuildScheduleExamDataSet(DataSet dataSet)
        {
            if (this._scheduleExamDataTable == null)
            {
                //Create exam datatable
                this._scheduleExamDataTable = new DataTable("DT_SCHEDULE_EXAMS");
                this._scheduleExamDataTable.Columns.Add("EXAM_ID", typeof(int));
                this._scheduleExamDataTable.Columns.Add("EXAM_UID", typeof(string));
                this._scheduleExamDataTable.Columns.Add("EXAM_NAME", typeof(string));
                this._scheduleExamDataTable.Columns.Add("RADIOLOGIST", typeof(string));
                this._scheduleExamDataTable.AcceptChanges();
            }

            this._scheduleExamDataTable.Rows.Clear(); // clear row first
            // Add exam to list
            foreach (DataRow eachRow in dataSet.Tables[0].Rows)
            {
                DataRow ptrRow = this._scheduleExamDataTable.NewRow();
                ptrRow["EXAM_ID"] = Convert.ToInt32(eachRow["EXAM_ID"]);
                ptrRow["EXAM_UID"] = eachRow["EXAM_UID"].ToString();
                ptrRow["EXAM_NAME"] = eachRow["EXAM_NAME"].ToString();
                ptrRow["RADIOLOGIST"] = eachRow["RADIOLOGIST"].ToString();
                this._scheduleExamDataTable.Rows.Add(ptrRow);
                ptrRow = null;
            }
        }   

        /// <summary>
        /// This method use to set form mode [ order / schedule mode ]
        /// </summary>
        private void SetFormMode()
        {
            bool flag = true;

            this.layoutOrderOrScheduleDetail.Text = "Patient Detail";
            this.barScanOrderForm.LargeWidth = 90;
            this.barScanOrderForm.Caption = "Scan Documents";
            this.Text = "Summary";

            if (this._pageMode == PagesModes.Order)
            {
                this.xtraTabMain.TabPages.Clear();
                this.xtraTabMain.TabPages.Add(this.xtraTabClinicalIndicationAndICDPage);
                this.xtraTabMain.TabPages.Add(this.xtraTabExaminationDetailsAndConsumptionPage);
                this.xtraTabMain.SelectedTabPage = this.xtraTabClinicalIndicationAndICDPage;
                flag = true;
            }
            else
            {
                this.xtraTabMain.TabPages.Clear();
                this.xtraTabMain.TabPages.Add(this.xtraTabClinicalIndicationAndICDPage);
                this.xtraTabMain.TabPages.Add(this.xtraTabAppointmentDataPage);
                this.xtraTabMain.TabPages.Add(this.xtraTabScheduleHistoryPage);
                this.xtraTabMain.SelectedTabPage = this.xtraTabClinicalIndicationAndICDPage;
                flag = false;
            }
            this.txtScheduleId.Visible = !flag;
            this.tbScheduleId.Visible = !flag;
            this.txtScheduleDate.Visible = !flag;
            this.tbScheduleDate.Visible = !flag;
            this.tbSessionTime.Visible = !flag;
            this.txtSessionTime.Visible = !flag;
            this.txtStartTime.Visible = !flag;
            this.tbStartTime.Visible = !flag;
            this.tbEndTime.Visible = !flag;
            this.txtEndTime.Visible = !flag;
            //this.txtComment.Visible = flag;
            //this.tbComment.Visible = flag;
            this.txtDelay.Visible = flag;
            this.tbDelay.Visible = flag;
            this.txtLMP.Visible = flag;
            this.tbLMP.Visible = flag;
            this.txtPeriod.Visible = flag;
            this.tbEncType.Visible = flag;
            this.txtClinicType.Visible = flag;
            this.tbClinicType.Visible = flag;
            this.txtOrderId.Visible = flag;
            this.tbOrderId.Visible = flag;
            this.txtOrderDate.Visible = flag;
            this.tbOrderDate.Visible = flag;
        }

        /// <summary>
        /// This method use to clear summary editor data
        /// </summary>
        private void ResetSummaryEditorData()
        {
            this.tbOrderId.Text = string.Empty;
            this.tbOrderDate.Text = string.Empty;
            this.tbHN.Text = string.Empty;
            this.tbPatientName.Text = string.Empty;
            this.tbGender.Text = string.Empty;
            this.tbDOB.Text = string.Empty;
            this.tbOrderingDept.Text = string.Empty;
            this.tbOrderingDoc.Text = string.Empty;
            this.tbAmbulatoryStatus.Text = string.Empty;
            this.tbPriority.Text = string.Empty;
            this.tbModality.Text = string.Empty;
            this.tbExamCode.Text = string.Empty;
            this.tbExamName.Text = string.Empty;
            this.tbAccessionNo.Text = string.Empty;
            this.tbArrivalTime.Text = string.Empty;
            this.tbClinicType.Text = string.Empty;
            this.tbDelay.Text = string.Empty;
            this.tbLMP.Text = string.Empty;
            this.tbEncType.Text = string.Empty;
            this.tbSessionTime.Text = string.Empty;
            this.tbStartTime.Text = string.Empty;
            this.tbEndTime.Text = string.Empty;
            this.tbScheduleId.Text = string.Empty;
            this.tbScheduleDate.Text = string.Empty;
            this.gridAppointmentDataControl.DataSource = null;
            this.gridScheduleHistoryControl.DataSource = null;
            this.gridICDControl.DataSource = null;
            this.gridConsumptionControl.DataSource = null;
            this.mmClinicalInstruction.Text = string.Empty;
            this.mmExposureTechique.Text = string.Empty;
            this.mmProtocol.Text = string.Empty;
            this.mmeComments.Text = string.Empty;
            this.tbExamCode.DataBindings.Clear();
            this.tbExamName.DataBindings.Clear();

            // TECH WORK
            this.tbKV.Text = string.Empty;
            this.tbmA.Text = string.Empty;
            this.tbNoOfImage.Text = string.Empty;
            this.tbPerformedByName.Text = string.Empty;
            this.tbSec.Text = string.Empty;
            this.tbTake.Text = string.Empty;
            this.mmExposureTechique.Text = string.Empty;
            this.mmProtocol.Text = string.Empty;
            this._selectedOrderIdOrScheduleId = 0;
            this._selectedExamId = 0;
            this._selectedAccessionNo = string.Empty;
            this._scheduleExamDataTable = null;
            this._selectedRegId = 0;
            this._selectedHN = string.Empty;
        }

        /// <summary>
        /// This method use to clear ER Clinical Indication editor data
        /// </summary>
        private void ResetERClinicalIndicationEditorData()
        {
            this.tbStudyDate.DataBindings.Clear();
            this.mmCadio.DataBindings.Clear();
            this.mmClincial.DataBindings.Clear();
            this.mmCns.DataBindings.Clear();
            this.mmDiags.DataBindings.Clear();
            this.mmExt.DataBindings.Clear();
            this.mmGa.DataBindings.Clear();
            this.mmGi.DataBindings.Clear();
            this.mmHeent.DataBindings.Clear();
            this.mmPH.DataBindings.Clear();
            this.mmPI.DataBindings.Clear();
            this.mmPlan.DataBindings.Clear();
            this.mmRpr.DataBindings.Clear();

            this.tbStudyDate.Text = string.Empty;
            this.mmCadio.Text = string.Empty;
            this.mmClincial.Text = string.Empty;
            this.mmCns.Text = string.Empty;
            this.mmDiags.Text = string.Empty;
            this.mmExt.Text = string.Empty;
            this.mmGa.Text = string.Empty;
            this.mmGi.Text = string.Empty;
            this.mmHeent.Text = string.Empty;
            this.mmPH.Text = string.Empty;
            this.mmPI.Text = string.Empty;
            this.mmPlan.Text = string.Empty;
            this.mmRpr.Text = string.Empty;

            this.gridPatientDataHisotoryControl.DataSource = null;
        }

        /// <summary>
        /// This method use to clear lab data editor data
        /// </summary>
        private void ResetLabDataEditorData()
        {
            this.gridLabDataControl.DataSource = null;
            this.xtraTabLabReport.SelectedTabPageIndex = 0;
            this.webBrowser1.Navigate(string.Empty);
            this.mmLabReport.Text = string.Empty;
        }
        /// <summary>
        /// This method use to clear scan order form
        /// </summary>
        private void ResetScanOrderForm()
        {
            this.gridScanOrderView.FocusedRowHandle = -99997;
            this._selectedImageUrl = string.Empty;
            this.gridScanOrderControl.DataSource = null;
            this.webBrowser2.Navigate(string.Empty);
            //this.webBrowser2.Navigate(string.Empty);
        }

        /// <summary>
        /// This method use to clear allergy data
        /// </summary>
        private void ResetAllergyData()
        {
            this.gridAllergyControl.DataSource = null;
        }

        /// <summary>
        /// This method use to reset next appointment
        /// </summary>
        private void ResetNextAppointment()
        {
            
        }

        /// <summary>
        /// This method use to show load dialog
        /// </summary>
        private void CloseLoadingDialog()
        {
            if(this.waitDialog != null)
                this.waitDialog.Close();
        }

        /// <summary>
        /// This method use to close loading dialog
        /// </summary>
        private void ShowLoadingDialog(string message, int width, int height)
        {
            this.waitDialog = new DevExpress.Utils.WaitDialogForm(message, "Dialog", new Size(width, height));
        }

        #region [ Override Method ]
        /// <summary>
        /// On page closed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            // Reset editor data
            this.ResetSummaryEditorData(); 
            this.ResetERClinicalIndicationEditorData();
            this.ResetLabDataEditorData();
            this.ResetAllergyData();
            this.ResetScanOrderForm();
            this.xtraTabLayoutControl.SelectedTabPage = this.xtraTabOrderPage;
            if (this._threadLoadLabData != null && this._threadLoadLabData.IsAlive)
                this._threadLoadLabData.Abort(); // destory thread
            if (this._threadLoadEMOER != null && this._threadLoadEMOER.IsAlive)
                this._threadLoadEMOER.Abort(); // destory thread
            if (this._threadLoadAllery != null && this._threadLoadAllery.IsAlive)
                this._threadLoadAllery.Abort(); // destory thread
            if (this._threadLoadNextAppointment != null && this._threadLoadNextAppointment.IsAlive)
                this._threadLoadNextAppointment.Abort(); // destory thread
            this._backupXtrPage = this.xtraTabOrderPage;
            this.xtraTabLabReport.SelectedTabPage = this.xtraTabLabText;
            this.rbgBack.Visible = false;
            this.rbgMain.Visible = true;
            this.CloseLoadingDialog();
            base.OnClosed(e);
        }
        #endregion

        #region [ Tools Bar Event ]
        /// <summary>
        /// Bar Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Er Clinical Indication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barERClinicalIndication_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.rbgOutOfBrowser.Visible = false;
            this.rbgMain.Visible = false;
            this.rbgBack.Visible = true;
            this.xtraTabLayoutControl.SelectedTabPage = this.xtraTabERClinicalIndication;
        }
        /// <summary>
        /// Back Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.rbgMain.Visible = true;
            this.rbgBack.Visible = false;
            this.rbgOutOfBrowser.Visible = false;
            this.xtraTabLayoutControl.SelectedTabPage = this._backupXtrPage;

            if (this._threadLoadLabData != null && this._threadLoadLabData.IsAlive)
                this._threadLoadLabData.Abort(); // destory thread
            if (this._threadLoadEMOER != null && this._threadLoadEMOER.IsAlive)
                this._threadLoadEMOER.Abort(); // destory thread
            if (this._threadLoadAllery != null && this._threadLoadAllery.IsAlive)
                this._threadLoadAllery.Abort(); // destory thread
            if (this._threadLoadNextAppointment != null && this._threadLoadNextAppointment.IsAlive)
                this._threadLoadNextAppointment.Abort(); // destory thread
            this.CloseLoadingDialog();
        }
        /// <summary>
        /// Lab Data 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barLabData_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.rbgOutOfBrowser.Visible = false;
            this.rbgMain.Visible = false;
            this.rbgBack.Visible = true;
            this.xtraTabLayoutControl.SelectedTabPage = this.xtraTabLabData;            
        }

        /// <summary>
        /// Allergy 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barAllergy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.rbgOutOfBrowser.Visible = false;
            this.rbgMain.Visible = false;
            this.rbgBack.Visible = true;
            this.xtraTabLayoutControl.SelectedTabPage = this.xtraTabAllergy;
            loadHisAllergy();
        }

        /// <summary>
        /// PACS Image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barPACSImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (env.LoginType == "E")
            //{
                // UpdatePacs
                new OpenPACS(env.PacsUrl).OpenIEAccession(this._selectedAccessionNo, env.UserName, env.PasswordAD, "", env.LoginType);
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(this._selectedAccessionNo.Trim()))
            //    {
            //        string str = this._gblEnv.PacsUrl + this._selectedAccessionNo;
            //        if (this._gblEnv.LoginType == "W")
            //        {
            //            str = this._gblEnv.PacsUrl;
            //            str = str.Replace("http://", string.Empty);
            //            str = "http://radiology%5C" + this._gblEnv.UserName + ":" + this._gblEnv.PasswordAD + "@" + str + this._selectedAccessionNo;
            //        }
            //        //System.Diagnostics.Process.Start(str);
            //        Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
            //        if (!ieCom.OpenSynapseLink(str))
            //            msg.ShowAlert("UID4053", env.CurrentLanguageID);
            //    }

            //}
            
        }

        /// <summary>
        /// PACS PowerJacket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barPACSPowerJacket_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(string.IsNullOrEmpty(this._selectedHN.Trim()))
            {
                ProcessGetRISOrderForOrderSummary _processGetRISOrderForOrderSummary = new ProcessGetRISOrderForOrderSummary();
                _processGetRISOrderForOrderSummary.RIS_ORDERDTL.ACCESSION_NO = this._selectedAccessionNo;
                _processGetRISOrderForOrderSummary.RIS_ORDERDTL.ORG_ID = this._gblEnv.OrgID;
                _processGetRISOrderForOrderSummary.Invoke();

                if (_processGetRISOrderForOrderSummary.Result.Tables.Count > 0)
                {
                    if (_processGetRISOrderForOrderSummary.Result.Tables[0].Rows.Count > 0)
                    {
                        DataRow selectedRow = _processGetRISOrderForOrderSummary.Result.Tables[0].Rows[0];
                        this._selectedHN = selectedRow["HN"].ToString();
                    }
                }
            
            }

            if (!string.IsNullOrEmpty(this._selectedHN.Trim()))
            {
                //if (env.LoginType == "E")
                //{
                    new OpenPACS(env.PacsUrl).OpenIEHn(this._selectedHN);
                //}
                //else
                //{
                //    string str = this._gblEnv.PacsUrl3 + this._selectedHN;
                //    if (this._gblEnv.LoginType == "W")
                //    {
                //        str = this._gblEnv.PacsUrl3;
                //        str = str.Replace("http://", string.Empty);
                //        str = "http://radiology%5C" + this._gblEnv.UserName + ":" + this._gblEnv.PasswordAD + "@" + str + this._selectedHN;
                //    }
                //    //System.Diagnostics.Process.Start(str);
                //    Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
                //    if (!ieCom.OpenSynapseLink(str))
                //        msg.ShowAlert("UID4053", env.CurrentLanguageID);
                //}
            }
        }
        /// <summary>
        /// Scan order form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barScanOrderForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.rbgOutOfBrowser.Visible = true;
            this.rbgMain.Visible = false;
            this.rbgBack.Visible = true;
            this.xtraTabLayoutControl.SelectedTabPage = this.xtraTabScanOrder;
        }

        /// <summary>
        /// Out of browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barOutOfBrowser_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(this._selectedImageUrl))
            {
                htmlViwer = new Envision.NET.Reports.ReportViewer.frmXtraReportViewer(this._selectedImageUrl);
                htmlViwer.ShowInTaskbar = false;
                htmlViwer.StartPosition = FormStartPosition.CenterScreen;
                htmlViwer.ShowDialog();
            }
        }
        /// <summary>
        /// Next Appointment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barNextAppointment_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.rbgOutOfBrowser.Visible = false;
            this.rbgMain.Visible = false;
            this.rbgBack.Visible = true;
            this.xtraTabLayoutControl.SelectedTabPage = this.xtraTabNextApt;
        }
        private void barCommentSyst_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmMessageConversation frmComment = new frmMessageConversation();
            switch (PageMode)
            {
                case PagesModes.Order:
                    if (string.IsNullOrEmpty(_selectedAccessionNo))
                        this._messageForm.ShowDialog(this._selectedOrderIdOrScheduleId, true);
                    else
                        this._messageForm.ShowDialog(false,this._selectedAccessionNo, 0);
                    //frmComment.TopLevel = true;
                    //frmComment.ShowDialog();
                    //frmComment.Focus();
                    break;
                case PagesModes.Schedule:
                    this._messageForm.ShowDialog(false, "", this._selectedOrderIdOrScheduleId);
                    //frmComment.TopLevel = true;
                    //frmComment.ShowDialog();
                    //frmComment.Focus();
                    break;
            }
        }
        #endregion

        #region [ Editor Event ]
        /// <summary>
        /// Priority edit value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPriority_EditValueChanged(object sender, EventArgs e)
        {
            // IF priority = stat --> foreground color = RED
            // ELSE forground color = BLACK
            if (this.tbPriority.EditValue.Equals("Stat"))
                this.tbPriority.Properties.Appearance.ForeColor = Color.Red;
            else
                this.tbPriority.Properties.Appearance.ForeColor = Color.Black;
        }
        /// <summary>
        /// Root Tab control page changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabLayoutControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //this._backupXtrPage = this.xtraTabLayoutControl.SelectedTabPage;
            if (this.xtraTabLayoutControl.SelectedTabPage == this.xtraTabOrderPage) { }
            // ER Clinical Indication Tab
            else if (this.xtraTabLayoutControl.SelectedTabPage == this.xtraTabERClinicalIndication)
            {
                this.ShowLoadingDialog("Loading...", 150, 50);
                //Load EMOER Data using thread
                this._threadLoadEMOER = new Thread(new ThreadStart(this.LoadERClinicalIndicationData));
                this._threadLoadEMOER.Start();
            }
            else if (this.xtraTabLayoutControl.SelectedTabPage == this.xtraTabLabData)
            {
                this.ShowLoadingDialog("Loading...", 150, 50);
                this._threadLoadLabData = new Thread(new ThreadStart(this.LoadLabData));
                this._threadLoadLabData.Start();
                gridLabDataView.FocusedRowHandle = -1;
                gridLabDataView.FocusedRowHandle = 0;
            }
            else if (this.xtraTabLayoutControl.SelectedTabPage == this.xtraTabScanOrder)
                this.LoadScanOrderData();
            else if (this.xtraTabLayoutControl.SelectedTabPage == this.xtraTabNextApt)
            {
                this.ShowLoadingDialog("Loading...", 150, 50);
                this._threadLoadNextAppointment = new Thread(new ThreadStart(this.LoadNextAppointment));
                this._threadLoadNextAppointment.Start();
            }

            //if (this.xtraTabLayoutControl.SelectedTabPage == this.xtraTabOrderPage)
                //ShowPatientPhoto();
            //else
                //HidePatientPhoto();
        }
        /// <summary>
        /// Grid Lab Data Focus row changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLabDataView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.gridLabDataView.FocusedRowHandle > -1)
            {
                DataRow selectedRow = this.gridLabDataView.GetFocusedDataRow();
                //Check report type
                string link = selectedRow["report"].ToString().ToUpper();
                if (link.Contains("\\GW4"))
                {
                    //SHOW HTML
                    IPAddress[] IPs = Dns.GetHostAddresses(Dns.GetHostName());
                    if (IPs.Length == 0) return;
                    string IP = IPs[0].ToString();
                    string htmlLink = link;//"";
                    //if (IP.Contains("192.168"))
                    //    htmlLink = link.Replace("\\GW3", "\\192.168.0.227");
                    //else
                        //htmlLink = link.Replace("\\GW3", "\\10.6.86.23");
                        //htmlLink = link.Replace("\\GW4", "\\10.6.86.31");
                    this.webBrowser1.Navigate(htmlLink);
                    this.xtraTabLabReport.SelectedTabPage = this.xtraTabLabHTML;
                }
                else
                {
                    //SHOW PLAIN TEXT
                    link = link.Replace("\n", "\r\n");
                    this.mmLabReport.Text = link;
                    this.xtraTabLabReport.SelectedTabPage = this.xtraTabLabText;
                }
            }
        }
        /// <summary>
        /// Grid Scan order focus row changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridScanOrderView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                DataRow dr = this.gridScanOrderView.GetDataRow(e.FocusedRowHandle);
                PointerStruct.ImageUrl = this._gblEnv.PacsUrl2;
                this._selectedImageUrl = PointerStruct.ImageUrl + "/" + dr["IMAGE_NAME"].ToString();
                this.webBrowser2.Navigate(_selectedImageUrl);
            }
        }
        /// <summary>
        /// Comment System
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion

        #region Risk Indication
        private void loadRISRiskDataOrder(int order_id)
        {
            riskMode = 0;
            DataTable dtIncident = new DataTable();
            ProcessGetRisRiskIncidents incident = new ProcessGetRisRiskIncidents();
            incident.RIS_RISKINCIDENTS.ORDER_ID = order_id;
            dtIncident = incident.getDataByOrderID();

            loadRiskIndicationData(dtIncident);
        }
        private void loadRISRiskDataSchedule(int schedule_id)
        {
            riskMode = 1;
            DataTable dtIncident = new DataTable();
            ProcessGetRisRiskIncidents incident = new ProcessGetRisRiskIncidents();
            incident.RIS_RISKINCIDENTS.SCHEDULE_ID = schedule_id;
            dtIncident = incident.getDataByScheduleID();
            loadRiskIndicationData(dtIncident);
        }
        private void loadRISRiskDataRequestXray(int xrayreq_id)
        {
            riskMode = 2;
            DataTable dtIncident = new DataTable();
            ProcessGetRisRiskIncidents incident = new ProcessGetRisRiskIncidents();
            incident.RIS_RISKINCIDENTS.XRAYREQ_ID = xrayreq_id;
            dtIncident = incident.getDataByXrayReqID();
            loadRiskIndicationData(dtIncident);
        }
        private void loadRiskIndicationData(DataTable dt)
        {
            if (Utilities.IsHaveData(dt))
            {
                risk_order_id = Convert.ToInt32(dt.Rows[0]["ORDER_ID"]);
                risk_schedule_id = Convert.ToInt32(dt.Rows[0]["SCHEDULE_ID"]);
                risk_xrayreq_id = Convert.ToInt32(dt.Rows[0]["XRAYREQ_ID"]);
            }
            else
            {
                switch (riskMode)
                {
                    case 0: risk_order_id = _selectedOrderIdOrScheduleId; break;
                    case 1: risk_schedule_id = _selectedOrderIdOrScheduleId; break;
                    case 2: risk_xrayreq_id = _selectedOrderIdOrScheduleId; break;
                }
            }
            ProcessGetRisRiskCategorise risk = new ProcessGetRisRiskCategorise();
            risk.RIS_RISKCATEGORISE.ORG_ID = env.OrgID;
            risk.Invoke();
            DataTable dtRiskCateforise = risk.Result.Tables[0];

            #region check Alert Risk
            if (dt.Rows.Count == dtRiskCateforise.Rows.Count)
            {
                barAllergy.LargeImageIndex = 2;
                barAllergy.Appearance.ForeColor = Color.Black;
            }
            else
            {
                barAllergy.LargeImageIndex = 12;
                barAllergy.Appearance.ForeColor = Color.Red;
            }
            #endregion
            #region Preparing CT Risk
            DataTable dtCT = new DataTable();
            dtCT.Columns.Add("YES");
            dtCT.Columns.Add("NO");
            //dtCT.Columns.Add("MAYBE");
            dtCT.Columns.Add("INCIDENT_CHOOSED");
            dtCT.Columns.Add("INCIDENT_DESC");
            dtCT.Columns.Add("RISK_CAT_ID",typeof(int));
            dtCT.Columns.Add("RISK_CAT_UID");
            dtCT.Columns.Add("RISK_CAT_DESC");
            dtCT.AcceptChanges();

            DataRow[] rowsCT = dtRiskCateforise.Select("RISK_CAT_UID='RISK OF CT STUDY'");
            foreach (DataRow rowCT in rowsCT)
            {
                DataRow addTempCT = dtCT.NewRow();
                addTempCT["RISK_CAT_ID"] = rowCT["RISK_CAT_ID"];
                addTempCT["RISK_CAT_UID"] = rowCT["RISK_CAT_UID"];
                addTempCT["RISK_CAT_DESC"] = rowCT["RISK_CAT_DESC"];
                dtCT.Rows.Add(addTempCT);
                dtCT.AcceptChanges();
            }

            DataRow[] rowsSelectCT = dt.Select("INCIDENT_SUBJ='RISK OF CT STUDY'");
            if (rowsSelectCT.Length > 0)
            {
                foreach (DataRow rowCT in rowsSelectCT)
                {
                    DataRow[] chk = dtCT.Select("RISK_CAT_ID=" + rowCT["RISK_CAT_ID"].ToString());
                    if (chk.Length > 0)
                    {
                        switch (rowCT["INCIDENT_CHOOSED"].ToString())
                        {
                            case "Y": chk[0]["YES"] = "Y"; break;
                            case "N": chk[0]["NO"] = "Y"; break;
                            //case "M": chk[0]["MAYBE"] = "Y"; break;
                        }
                        chk[0]["INCIDENT_CHOOSED"] = rowCT["INCIDENT_CHOOSED"].ToString();
                        chk[0]["INCIDENT_DESC"] = rowCT["INCIDENT_DESC"].ToString();
                    }
                }
            }
            grdRiskCT.DataSource = dtCT;
            setColumnsCT();
            #endregion
            #region Preparing MRI Risk
            DataTable dtMRI = new DataTable();
            dtMRI.Columns.Add("YES");
            dtMRI.Columns.Add("NO");
            //dtMRI.Columns.Add("MAYBE");
            dtMRI.Columns.Add("INCIDENT_CHOOSED");
            dtMRI.Columns.Add("INCIDENT_DESC");
            dtMRI.Columns.Add("RISK_CAT_ID",typeof(int));
            dtMRI.Columns.Add("RISK_CAT_UID");
            dtMRI.Columns.Add("RISK_CAT_DESC");
            dtMRI.AcceptChanges();

            DataRow[] rowsMRI = dtRiskCateforise.Select("RISK_CAT_UID='RISK OF MRI STUDY'");
            foreach (DataRow rowMRI in rowsMRI)
            {
                DataRow addTempMRI = dtMRI.NewRow();
                addTempMRI["RISK_CAT_ID"] = rowMRI["RISK_CAT_ID"];
                addTempMRI["RISK_CAT_UID"] = rowMRI["RISK_CAT_UID"];
                addTempMRI["RISK_CAT_DESC"] = rowMRI["RISK_CAT_DESC"];
                dtMRI.Rows.Add(addTempMRI);
                dtMRI.AcceptChanges();
            }

            DataRow[] rowsSelectMRI = dt.Select("INCIDENT_SUBJ='RISK OF MRI STUDY'");
            if (rowsSelectMRI.Length > 0)
            {
                foreach (DataRow rowMRI in rowsSelectMRI)
                {
                    DataRow[] chk = dtMRI.Select("RISK_CAT_ID=" + rowMRI["RISK_CAT_ID"].ToString().Trim());
                    if (chk.Length > 0)
                    {
                        switch (rowMRI["INCIDENT_CHOOSED"].ToString())
                        {
                            case "Y": chk[0]["YES"] = "Y"; break;
                            case "N": chk[0]["NO"] = "Y"; break;
                            //case "M": chk[0]["MAYBE"] = "Y"; break;
                        }
                        chk[0]["INCIDENT_CHOOSED"] = rowMRI["INCIDENT_CHOOSED"].ToString();
                        chk[0]["INCIDENT_DESC"] = rowMRI["INCIDENT_DESC"].ToString();
                    }
                }
            }
            grdRiskMRI.DataSource = dtMRI;
            setColumnsMRI();
            #endregion
            #region setCreatinine
            lbGFR.Text = "GFR (ml/min/1.73m" + "\x00B2" + " : ";
            txtCreatinine.Text = "-";
            txtGFR.Text = "-";
            txtReportedDate.Text = "-";
            lblAlertLastestResultDate.Text = "";
            txtCreatinine.ForeColor = Color.Black; 

            ProcessGetCreatinine labcreatinine = new ProcessGetCreatinine();
            labcreatinine.RIS_LABCREATININE.SCHEDULE_ID = risk_schedule_id;
            labcreatinine.Invoke();
            DataTable dtLabcreatinine = labcreatinine.Result;
            if (Utilities.IsHaveData(dtLabcreatinine))
            {
                creatinine = dtLabcreatinine;
                DataRow[] rowcreatinine = dtLabcreatinine.Select("SHORT_TEST= 'Creatinine'");
                if (Utilities.IsHaveData(rowcreatinine))
                {
                    txtCreatinine.Text = string.IsNullOrEmpty(rowcreatinine[0]["RESULT_VALUE"].ToString()) == true ? "-" : rowcreatinine[0]["RESULT_VALUE"].ToString();
                    if (!string.IsNullOrEmpty(rowcreatinine[0]["RANGE"].ToString()))
                    {
                        string[] range = rowcreatinine[0]["RANGE"].ToString().Split('-');
                        double Value = Convert.ToDouble(rowcreatinine[0]["RESULT_VALUE"].ToString());
                        double min = Convert.ToDouble(range[0].ToString());
                        double max = Convert.ToDouble(range[1].ToString());
                        if (Value < min || Value > max)
                        {
                            txtCreatinine.ForeColor = Color.Red; 
                        }
                    }
                    
                }
                else {
                    txtCreatinine.Text = "-";
                }

                DataRow[] rowGFR = dtLabcreatinine.Select("SHORT_TEST= 'eGFR (CKD-EPI)'");
                if (Utilities.IsHaveData(rowGFR))
                {
                    txtGFR.Text = string.IsNullOrEmpty(rowcreatinine[0]["RESULT_VALUE"].ToString()) == true ? "-" : rowcreatinine[0]["RESULT_VALUE"].ToString();
                 }
                else
                {
                    txtGFR.Text = "-";
                }

                txtReportedDate.Text = rowcreatinine[0]["REPORT_DATETIME"].ToString();
                if (DateTime.Now.AddMonths(-3) > Convert.ToDateTime(rowcreatinine[0]["REPORT_DATETIME"].ToString()))
                {
                    lblAlertLastestResultDate.Text = "ผลเลือดเกิน 3 เดือน แนะนำให้ตวรจผลเลือดใหม่";
                }
            }
            else
            {
                lblAlertLastestResultDate.Text = "คนไข้ไม่มีผลเลือด";
            }

            
           
            #endregion

            //DataRow[] rowCREATININE = dt.Select("RISK_CAT_ID=12");
            //if (rowCREATININE.Length > 0)
            //{
            //    txtCreatinine.Text = rowCREATININE[0]["INCIDENT_DESC"].ToString();
            //}
            //else
            //    txtCreatinine.Text = "";
            DataRow[] rowUseContrast = dt.Select("RISK_CAT_ID=22");
            if (rowUseContrast.Length > 0)
            {
                switch (rowUseContrast[0]["INCIDENT_CHOOSED"].ToString())
                {
                    case "N": rdoContrast.SelectedIndex = 0; break;
                    case "Y": rdoContrast.SelectedIndex = 1; break;
                    default: rdoContrast.SelectedIndex = -1; break;
                }

                DataRow[] CT = dt.Select("INCIDENT_SUBJ='RISK OF CT STUDY'");
                DataRow[] MRI = dt.Select("INCIDENT_SUBJ='RISK OF MRI STUDY'");
                if (CT.Length > 0)
                {
                    subtabRisk.SelectedTabPageIndex = 1;
                    showTxtUseContrast("tabCT");
                }
                else if (MRI.Length > 0)
                {
                    subtabRisk.SelectedTabPageIndex = 0;
                    showTxtUseContrast("tabMRI");
                }
                //txtUseContrast.Text = rowUseContrast[0]["INCIDENT_DESC"].ToString();
            }
            else
            {
                rdoContrast.SelectedIndex = -1;
                txtUseContrast.Text = "";
            }
        }
        private void loadHisAllergy()
        {
            if (this.xtratabRiskmanagement.SelectedTabPage == this.tabHISAllergy)
            {
                this.ShowLoadingDialog("Loading...", 150, 50);
                //this._threadLoadAllery = new Thread(new ThreadStart(this.LoadAllergyData));
                //this._threadLoadAllery.Start();
                this.LoadAllergyData();
                this.waitDialog.Close();
            }
        }
        private void setColumnsMRI()
        {
            for (int i = 0; i < viewRiskMRI.Columns.Count; i++)
            {
                viewRiskMRI.Columns[i].Visible = false;
                viewRiskMRI.Columns[i].OptionsColumn.AllowEdit = false;
            }
            viewRiskMRI.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewRiskMRI.OptionsSelection.EnableAppearanceFocusedRow = true;


            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkYesMRI = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkYesMRI.ValueChecked = "Y";
            chkYesMRI.ValueUnchecked = "N";
            chkYesMRI.RadioGroupIndex = 2;
            chkYesMRI.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            chkYesMRI.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkYesMRI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkYesMRI.CheckedChanged += new EventHandler(chkYesMRI_CheckedChanged);

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkNoMRI = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkNoMRI.ValueChecked = "Y";
            chkNoMRI.ValueUnchecked = "N";
            chkNoMRI.RadioGroupIndex = 2;
            chkNoMRI.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            chkNoMRI.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkNoMRI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkNoMRI.CheckedChanged += new EventHandler(chkNoMRI_CheckedChanged);

            //DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkMaybeMRI = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //chkMaybeMRI.ValueChecked = "Y";
            //chkMaybeMRI.ValueUnchecked = "N";
            //chkMaybeMRI.RadioGroupIndex = 2;
            //chkMaybeMRI.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            //chkMaybeMRI.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            //chkMaybeMRI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chkMaybeMRI.CheckedChanged += new EventHandler(chkMaybeMRI_CheckedChanged);

            viewRiskMRI.Columns["YES"].ColVIndex = 1;
            viewRiskMRI.Columns["NO"].ColVIndex = 2;
            //viewRiskMRI.Columns["MAYBE"].ColVIndex = 3;
            viewRiskMRI.Columns["RISK_CAT_DESC"].ColVIndex = 4;
            viewRiskMRI.Columns["INCIDENT_DESC"].ColVIndex = 5;


            viewRiskMRI.Columns["YES"].Width = 50;
            viewRiskMRI.Columns["NO"].Width = 50;
            //viewRiskMRI.Columns["MAYBE"].Width = 60;
            viewRiskMRI.Columns["RISK_CAT_DESC"].Width = 350;
            viewRiskMRI.Columns["INCIDENT_DESC"].Width = 310;

            viewRiskMRI.Columns["YES"].OptionsColumn.AllowEdit = true;
            viewRiskMRI.Columns["NO"].OptionsColumn.AllowEdit = true;
            //viewRiskMRI.Columns["MAYBE"].OptionsColumn.AllowEdit = true;
            viewRiskMRI.Columns["INCIDENT_DESC"].OptionsColumn.AllowEdit = true;


            viewRiskMRI.Columns["YES"].Caption = "ใช่";
            viewRiskMRI.Columns["NO"].Caption = "ไม่ใช่";
            //viewRiskMRI.Columns["MAYBE"].Caption = "ไม่ทราบ";
            viewRiskMRI.Columns["RISK_CAT_DESC"].Caption = "Risk Description";
            viewRiskMRI.Columns["INCIDENT_DESC"].Caption = "Detail";

            viewRiskMRI.Columns["YES"].ColumnEdit = chkYesMRI;
            viewRiskMRI.Columns["NO"].ColumnEdit = chkNoMRI;
            //viewRiskMRI.Columns["MAYBE"].ColumnEdit = chkMaybeMRI;

        }
        private void chkYesMRI_CheckedChanged(object sender, EventArgs e)
        {
            if (viewRiskMRI.FocusedRowHandle < 0) return;
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk == null) return;
            DataRow rowHandle = viewRiskMRI.GetDataRow(viewRiskMRI.FocusedRowHandle);
            rowHandle["YES"] = "Y";
            rowHandle["NO"] = "N";
            //rowHandle["MAYBE"] = "N";
            rowHandle["INCIDENT_CHOOSED"] = "Y";

            viewRiskMRI.RefreshData();
        }
        private void chkNoMRI_CheckedChanged(object sender, EventArgs e)
        {
            if (viewRiskMRI.FocusedRowHandle < 0) return;
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk == null) return;
            DataRow rowHandle = viewRiskMRI.GetDataRow(viewRiskMRI.FocusedRowHandle);
            rowHandle["YES"] = "N";
            rowHandle["NO"] = "Y";
            //rowHandle["MAYBE"] = "N";
            rowHandle["INCIDENT_CHOOSED"] = "N";

            viewRiskMRI.RefreshData();
        }
        //private void chkMaybeMRI_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (viewRiskMRI.FocusedRowHandle < 0) return;
        //    DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
        //    if (chk == null) return;
        //    DataRow rowHandle = viewRiskMRI.GetDataRow(viewRiskMRI.FocusedRowHandle);
        //    rowHandle["YES"] = "N";
        //    rowHandle["NO"] = "N";
        //    rowHandle["MAYBE"] = "Y";
        //    rowHandle["INCIDENT_CHOOSED"] = "M";

        //    viewRiskMRI.RefreshData();
        //}
        private void setColumnsCT()
        {
            for (int i = 0; i < viewRiskCT.Columns.Count; i++)
            {
                viewRiskCT.Columns[i].Visible = false;
                viewRiskCT.Columns[i].OptionsColumn.AllowEdit = false;
            }
            viewRiskCT.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewRiskCT.OptionsSelection.EnableAppearanceFocusedRow = true;


            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkYesCT = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkYesCT.ValueChecked = "Y";
            chkYesCT.ValueUnchecked = "N";
            chkYesCT.RadioGroupIndex = 1;
            chkYesCT.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            chkYesCT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkYesCT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkYesCT.CheckedChanged += new EventHandler(chkYesCT_CheckedChanged);

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkNoCT = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkNoCT.ValueChecked = "Y";
            chkNoCT.ValueUnchecked = "N";
            chkNoCT.RadioGroupIndex = 1;
            chkNoCT.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            chkNoCT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkNoCT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkNoCT.CheckedChanged += new EventHandler(chkNoCT_CheckedChanged);

            //DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkMaybeCT = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //chkMaybeCT.ValueChecked = "Y";
            //chkMaybeCT.ValueUnchecked = "N";
            //chkMaybeCT.RadioGroupIndex = 1;
            //chkMaybeCT.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            //chkMaybeCT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            //chkMaybeCT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chkMaybeCT.CheckedChanged += new EventHandler(chkMaybeCT_CheckedChanged);

            viewRiskCT.Columns["YES"].ColVIndex = 1;
            viewRiskCT.Columns["NO"].ColVIndex = 2;
            //viewRiskCT.Columns["MAYBE"].ColVIndex = 3;
            viewRiskCT.Columns["RISK_CAT_DESC"].ColVIndex = 4;
            viewRiskCT.Columns["INCIDENT_DESC"].ColVIndex = 5;


            viewRiskCT.Columns["YES"].Width = 50;
            viewRiskCT.Columns["NO"].Width = 50;
            //viewRiskCT.Columns["MAYBE"].Width = 60;
            viewRiskCT.Columns["RISK_CAT_DESC"].Width = 350;
            viewRiskCT.Columns["INCIDENT_DESC"].Width = 310;

            viewRiskCT.Columns["YES"].OptionsColumn.AllowEdit = true;
            viewRiskCT.Columns["NO"].OptionsColumn.AllowEdit = true;
            //viewRiskCT.Columns["MAYBE"].OptionsColumn.AllowEdit = true;
            viewRiskCT.Columns["INCIDENT_DESC"].OptionsColumn.AllowEdit = true;


            viewRiskCT.Columns["YES"].Caption = "ใช่";
            viewRiskCT.Columns["NO"].Caption = "ไม่ใช่";
            //viewRiskCT.Columns["MAYBE"].Caption = "ไม่ทราบ";
            viewRiskCT.Columns["RISK_CAT_DESC"].Caption = "Risk Description";
            viewRiskCT.Columns["INCIDENT_DESC"].Caption = "Detail";

            viewRiskCT.Columns["YES"].ColumnEdit = chkYesCT;
            viewRiskCT.Columns["NO"].ColumnEdit = chkNoCT;
            //viewRiskCT.Columns["MAYBE"].ColumnEdit = chkMaybeCT;
        }
        private void chkYesCT_CheckedChanged(object sender, EventArgs e)
        {
            if (viewRiskCT.FocusedRowHandle < 0) return;
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk == null) return;
            DataRow rowHandle = viewRiskCT.GetDataRow(viewRiskCT.FocusedRowHandle);
            rowHandle["YES"] = "Y";
            rowHandle["NO"] = "N";
            //rowHandle["MAYBE"] = "N";
            rowHandle["INCIDENT_CHOOSED"] = "Y";

            viewRiskCT.RefreshData();
        }
        private void chkNoCT_CheckedChanged(object sender, EventArgs e)
        {
            if (viewRiskCT.FocusedRowHandle < 0) return;
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk == null) return;
            DataRow rowHandle = viewRiskCT.GetDataRow(viewRiskCT.FocusedRowHandle);
            rowHandle["YES"] = "N";
            rowHandle["NO"] = "Y";
            //rowHandle["MAYBE"] = "N";
            rowHandle["INCIDENT_CHOOSED"] = "N";

            viewRiskCT.RefreshData();
        }
        //private void chkMaybeCT_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (viewRiskCT.FocusedRowHandle < 0) return;
        //    DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
        //    if (chk == null) return;
        //    DataRow rowHandle = viewRiskCT.GetDataRow(viewRiskCT.FocusedRowHandle);
        //    rowHandle["YES"] = "N";
        //    rowHandle["NO"] = "N";
        //    rowHandle["MAYBE"] = "Y";
        //    rowHandle["INCIDENT_CHOOSED"] = "M";

        //    viewRiskCT.RefreshData();
        //}
        private void rdoContrast_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtUseContrast.Enabled = rdoContrast.SelectedIndex == 1 ? true : false;
            if (subtabRisk.SelectedTabPageIndex == 0)
            {
                showTxtUseContrast("tabMRI");
            }
            else
            {
                showTxtUseContrast("tabCT");
            }
        }
        private void btnSaveRisk_Click(object sender, EventArgs e)
        {
            ProcessDeleteRisRiskIncidents processDeleteRiskIncident = new ProcessDeleteRisRiskIncidents();
            switch (riskMode)
            {
                case 0:
                    processDeleteRiskIncident.RIS_RISKINCIDENTS.ORDER_ID = risk_order_id;
                    processDeleteRiskIncident.DeleteOrderID();
                    break;
                case 1:
                    processDeleteRiskIncident.RIS_RISKINCIDENTS.SCHEDULE_ID = risk_schedule_id;
                    processDeleteRiskIncident.DeleteScheduleID();
                    break;
                case 2:
                    processDeleteRiskIncident.RIS_RISKINCIDENTS.XRAYREQ_ID = risk_xrayreq_id;
                    processDeleteRiskIncident.DeleteXrayREQID();
                    break;
                default:
                    break;
            }

            //if (!string.IsNullOrEmpty(txtCreatinine.Text.Trim()))
            //    saveRiskIndication(12, "ALLERGIC", txtCreatinine.Text.Trim(), "Y");
            if (rdoContrast.SelectedIndex == 1)
                saveRiskIndication(22, "ALLERGIC", txtUseContrast.Text.Trim(), "Y");
            else if (rdoContrast.SelectedIndex == 0)
                saveRiskIndication(22, "ALLERGIC", txtUseContrast.Text.Trim(), "N");
            #region Save MRI Risk
            DataTable dtMRIsave = grdRiskMRI.DataSource as DataTable;
            foreach (DataRow rowsMRI in dtMRIsave.Rows)
                if (rowsMRI["INCIDENT_CHOOSED"].ToString()=="Y" ||rowsMRI["INCIDENT_CHOOSED"].ToString()=="N" ||rowsMRI["INCIDENT_CHOOSED"].ToString()=="M")
                    saveRiskIndication(Convert.ToInt32(rowsMRI["RISK_CAT_ID"]), rowsMRI["RISK_CAT_UID"].ToString(), rowsMRI["INCIDENT_DESC"].ToString(), rowsMRI["INCIDENT_CHOOSED"].ToString());
            #endregion

            #region Save CT Risk
            DataTable dtCTsave = grdRiskCT.DataSource as DataTable;
            foreach (DataRow rowsCT in dtCTsave.Rows)
                if (rowsCT["INCIDENT_CHOOSED"].ToString() == "Y" || rowsCT["INCIDENT_CHOOSED"].ToString() == "N" || rowsCT["INCIDENT_CHOOSED"].ToString() == "M")
                    saveRiskIndication(Convert.ToInt32(rowsCT["RISK_CAT_ID"]), rowsCT["RISK_CAT_UID"].ToString(), rowsCT["INCIDENT_DESC"].ToString(), rowsCT["INCIDENT_CHOOSED"].ToString());
            #endregion

        }
        private void saveRiskIndication(int risk_cat_id, string risk_subject, string risk_desc,string incident_choosed)
        {
            ProcessAddRisRiskIncidents processAddRiskIncident = new ProcessAddRisRiskIncidents();
            processAddRiskIncident.RIS_RISKINCIDENTS.RISK_CAT_ID = risk_cat_id;
            processAddRiskIncident.RIS_RISKINCIDENTS.ORG_ID = env.OrgID;
            processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_UID = string.Empty;
            processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_SUBJ = risk_subject;
            processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_DT = DateTime.Now;
            processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_DESC = risk_desc;
            processAddRiskIncident.RIS_RISKINCIDENTS.CREATED_BY = env.UserID;
            processAddRiskIncident.RIS_RISKINCIDENTS.COMMENT_ID = -1;
            processAddRiskIncident.RIS_RISKINCIDENTS.REG_ID = _selectedRegId;
            processAddRiskIncident.RIS_RISKINCIDENTS.SCHEDULE_ID = risk_schedule_id;
            processAddRiskIncident.RIS_RISKINCIDENTS.ORDER_ID = risk_order_id;
            processAddRiskIncident.RIS_RISKINCIDENTS.XRAYREQ_ID = risk_xrayreq_id;
            processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_CHOOSED = incident_choosed;
            processAddRiskIncident.Invoke();
        }

        private void showTxtUseContrast(string tab)
        {
            if (rdoContrast.SelectedIndex == 1)
            {
                if (tab == "tabMRI")
                {
                    txtUseContrast.Text = "- GFR น้อยกว่า 30 ml/min/1.73m" + "\x00B2" + " พิจารณาความเสี่ยงต่อภาวะ Nephrogenic systemic fibrosis และอธิบายความเสี่ยงนี้แก่ผู้ป่วย \n" +
                        "- ผู้ป่วยHemodialysis และ CAPD ส่งปรึกษาอายุรแพทย์โรคไต";
                }
                else if (tab == "tabCT")
                {
                    txtUseContrast.Text = "- GFR 30-60 ml/min พิจารณาIV Hydration เพื่อป้องกันภาวะ CONTRAST INDUCED NEPHROPATHY \n" +
                        //"- <a href=" + "http:\\......" + ">Print Standing Order for IV Hydration</a> <br/>" +
                        "- Print Standing Order for IV Hydration\n" +
                        "- GFR น้อยกว่าหรือเท่ากับ 30 ml/min  ส่งปรึกษาอายุรแพทย์โรคไต";

                }
            }
            else if (rdoContrast.SelectedIndex != 1)
            {
                txtUseContrast.Text = "";
            }
        }
        #endregion

        private void ShowPatientPhoto()
        {
            //ptPhoto = new Miracle.UserControls.HISPatientPhotoForm();
            //ptPhoto.Location = new Point(this.Location.X, this.Location.Y);

            try
            {
                ptPhoto.Show();
            }
            catch
            {
                ptPhoto = new Miracle.UserControls.HISPatientPhotoForm();
                ptPhoto.Show();
            }
        }
        private void HidePatientPhoto()
        {
            ptPhoto.Hide();
        }

        private void xtratabRiskmanagement_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            loadHisAllergy();
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    frm.Focus();
                    frm.TopMost = true;
                    return true;
                }
            }
            return false;
        }

        private void subtabRisk_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (subtabRisk.SelectedTabPageIndex == 0) {
                showTxtUseContrast("tabMRI");
            }else{
                showTxtUseContrast("tabCT");
            }
        }
    }
}