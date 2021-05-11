using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EnvisionOnline.Common.Common;
using EnvisionOnline.ReportViewer.Reports.xrptOrderReportComponent;
using EnvisionOnline.BusinessLogic.ProcessRead;
using System.Data;
using EnvisionOnline.Operational;

namespace EnvisionOnline.ReportViewer.Reports
{
    public partial class xrptOrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        private int _empId;
        private int _orgId;
        private int _orderId;
        private string HN;
        private string Clinic;
        private bool IS_ONL;

        OrderReportParameters _orderReportParameters;
        OrderExamParameters[] _examParameters;
        PatientDemographicParameters _patientDemographic;

        private OrderExamParameters[] examList;
        public xrptOrderReport(int ORDER_ID,bool is_online,int emp_id)
        {
            InitializeComponent();

            _empId = emp_id;
            _orgId = 1;
            _orderId = ORDER_ID;
            IS_ONL = is_online;

            GetAllParameters();

            this.examList = _examParameters;

            this.SetBindTextControl();

            this.xrSubreport1.ReportSource = new ExamSubReport() { DataSource = _examParameters };
            this.xrSubreport2.ReportSource = new Exam2SubReport() { DataSource = _examParameters };

            this.Parameters.Clear();
        }

        private void SetAllParameter()
        {
           
            this.pOrgAddress.Value = _orderReportParameters.OrgAddress;
            this.pOrgName.Value = _orderReportParameters.OrgName;
            ImageConverter convertor = new ImageConverter();
            Bitmap _image = new Bitmap((Image)convertor.ConvertFrom(_orderReportParameters.OrgImg), new Size(40, 40));
            this.orgImage1.Image = _image;
            this.orgImage2.Image = _image;
            this.p_pAge.Value = _patientDemographic.Age;
            this.p_pEngName.Value = _patientDemographic.EngName;
            this.p_pThainame.Value = _patientDemographic.ThaiName;
            this.p_pGender.Value = _patientDemographic.Gender;
            this.pHN.Value = _patientDemographic.HN;
            this.pClinic.Value = _orderReportParameters.Clinic;
            if (examList != null && examList.Length > 0)
            {
                this.p_pStatus.Value = examList[0].pStatus;
                this.pExamDate.Value = examList[0].ExamDate;
                this.pExamTime.Value = examList[0].ExamTime;
            }
            this.pUnit.Value = _orderReportParameters.Unit;
            this.pPrintDate.Value = _orderReportParameters.PrintDate;
            this.pPrintTime.Value = _orderReportParameters.PrintTime;
            this.pOrderingName.Value = _orderReportParameters.OrderBy;
            this.pPrintBy.Value = _orderReportParameters.PrintBy;
            this.xrBarCode2.Text = _patientDemographic.HN;
            this.xrBarCode3.Text = _patientDemographic.HN;
            this.Parameters["pDes" + 1].Value = "เอกสารนี้ ใช้เป็นหลักฐานในการเอกซเรย์";
        }
        private void SetBindTextControl()
        {
            ImageConverter convertor = new ImageConverter();
            Bitmap _image = new Bitmap((Image)convertor.ConvertFrom(_orderReportParameters.OrgImg), new Size(40, 40));
            this.orgImage1.Image = _image;
            this.orgImage2.Image = _image;

            txtOrgName.Text = this._orderReportParameters.OrgName.Trim();
            txtOrgName2.Text = this._orderReportParameters.OrgName.Trim();

            txtOrgAddress.Text = this._orderReportParameters.OrgAddress.Trim();
            txtOrgAddress2.Text = this._orderReportParameters.OrgAddress.Trim();

            txtHN.Text = this.HN;
            txtHN2.Text = this.HN;

            this.xrBarCode2.Text = _patientDemographic.HN;
            this.xrBarCode3.Text = _patientDemographic.HN;

            txtPatientName.Text = _patientDemographic.ThaiName;
            txtPatientName2.Text = _patientDemographic.ThaiName;

            txtPatientNameEng.Text = _patientDemographic.EngName;
            txtPatientNameEng2.Text = _patientDemographic.EngName;

            txtGender.Text = _patientDemographic.Gender;
            txtGender2.Text = _patientDemographic.Gender;

            txtAge.Text = _patientDemographic.Age;
            txtAge2.Text = _patientDemographic.Age;

            txtClinicType.Text = _orderReportParameters.Clinic;
            txtClinicType2.Text = _orderReportParameters.Clinic;

            txtStatus.Text = _orderReportParameters.PatientStatus;
            txtStatus2.Text = _orderReportParameters.PatientStatus;

            txtOrderingDept.Text = _orderReportParameters.Unit;
            txtOrderingDept2.Text = _orderReportParameters.Unit;

            txtLMP.Text = _orderReportParameters.LMP;
            txtLMP2.Text = _orderReportParameters.LMP;

            //txtOrderBy.Text = _orderReportParameters.OrderBy;
            //txtOrderDatetime.Text = _orderReportParameters.OrderDT;

            lblOrderingDoc.Text = _orderReportParameters.OrderingDoc;
            lblRequestName.Text = _orderReportParameters.Request_Name;
            lblRequestDatetime.Text = _orderReportParameters.Request_Datetime;
            lblArrivedName.Text = _orderReportParameters.Arrived_Name;
            lblArrivedDatetime.Text = _orderReportParameters.Arrived_Datetime;

            //txtPrintBy.Text = _orderReportParameters.PrintBy;
            //txtPrintDatetime.Text = _orderReportParameters.PrintDate;

            txtOrderDescription.Text = _orderReportParameters.OrgOrderDescription;

            if (_orderReportParameters.ClinicalIndication.Trim().Length == 0)
            {
                txtClinicalIndication.Text = "";
            }
            else
                txtClinicalIndication.Text = "Clinical Indication : " + _orderReportParameters.ClinicalIndication.Trim();

            if (_orderReportParameters.AppointBy.Trim().Length == 0)
            {
                lbAppintBy.Visible = false;
                lbAppintBy2.Visible = false;
                txtAppointBy.Visible = false;
                txtAppointBy2.Visible = false;
            }
            else
            {
                lbAppintBy.Visible = true;
                lbAppintBy2.Visible = true;
                txtAppointBy.Visible = true;
                txtAppointBy2.Visible = true;

                txtAppointBy.Text = _orderReportParameters.AppointBy;
                txtAppointBy2.Text = _orderReportParameters.AppointBy;
            }
        }

        private void GetAllParameters()
        {
            this._orderReportParameters = new OrderReportParameters();
            ProcessGetGBLEnv _env = new ProcessGetGBLEnv();
            _env.Invoke();
            this._orderReportParameters.OrgAddress = string.Format("{0} {1} {2} {3}"
                            , _env.ResultSet.Tables[0].Rows[0]["ORG_ADDR1"]
                            , _env.ResultSet.Tables[0].Rows[0]["ORG_ADDR2"]
                            , _env.ResultSet.Tables[0].Rows[0]["ORG_ADDR3"]
                            , _env.ResultSet.Tables[0].Rows[0]["ORG_ADDR4"]);
            this._orderReportParameters.Clinic = this.Clinic;
            byte[] _orgImg = (byte[])_env.ResultSet.Tables[0].Rows[0]["ORG_IMG"];
            this._orderReportParameters.OrgImg = _orgImg;
            ProcessGetOrderReport _examOfReport = new ProcessGetOrderReport();
            _examOfReport.ORDER_ID = Convert.ToInt32(_orderId);
            _examOfReport.HN = HN;
            _examOfReport.ORG_ID = _orgId;
            if (IS_ONL)
                _examOfReport.InvokeOnline();
            else
                _examOfReport.Invoke();

            DataSet _eDs = _examOfReport.Result;
            if (Utilities.IsHaveData(_eDs))
            {
                _examParameters = new OrderExamParameters[_eDs.Tables[0].Rows.Count];
                this.HN = _eDs.Tables[0].Rows[0]["HN"].ToString();
                this._orderReportParameters.OrgName = _eDs.Tables[0].Rows[0]["ORG_HOSPITAL_NAME"].ToString();
                this._orderReportParameters.OrgOrderDescription = _eDs.Tables[0].Rows[0]["HR_UNIT_INS"].ToString();
                this._orderReportParameters.PatientStatus = _eDs.Tables[0].Rows[0]["PAT_STATUS"].ToString();
                this._orderReportParameters.LMP = _eDs.Tables[0].Rows[0]["LMP_DT"].ToString();
                this._orderReportParameters.Clinic = _eDs.Tables[0].Rows[0]["CLINIC_NAME"].ToString();

                this._orderReportParameters.OrderBy = _eDs.Tables[0].Rows[0]["ORDER_BY"].ToString();
                this._orderReportParameters.OrderDT = (Convert.ToDateTime(_eDs.Tables[0].Rows[0]["ORDER_DT"])).ToString("dd/MM/yyyy HH:mm");
                this._orderReportParameters.PrintDate = (Convert.ToDateTime(_eDs.Tables[0].Rows[0]["PRINT_DT"])).ToString("dd/MM/yyyy HH:mm");
                this._orderReportParameters.PrintBy = _eDs.Tables[0].Rows[0]["PRINT_BY"].ToString();

                this._orderReportParameters.OrderingDoc = _eDs.Tables[0].Rows[0]["REF_DOC_NAME"].ToString();
                this._orderReportParameters.Request_Datetime = _eDs.Tables[0].Rows[0]["REQUEST_DATETIME"].ToString();
                this._orderReportParameters.Request_Name = _eDs.Tables[0].Rows[0]["REQUEST_NAME"].ToString();
                this._orderReportParameters.Arrived_Datetime = _eDs.Tables[0].Rows[0]["ARRIVED_DATETIME"].ToString();
                this._orderReportParameters.Arrived_Name = _eDs.Tables[0].Rows[0]["ARRIVED_NAME"].ToString();


                this._orderReportParameters.AppointBy = _eDs.Tables[0].Rows[0]["APPOINTMENT_BY"].ToString();
                this._orderReportParameters.ClinicalIndication = _eDs.Tables[0].Rows[0]["CLINICAL_INSTRUCTION"].ToString();
            }
            for (int i = 0; i < _eDs.Tables[0].Rows.Count; i++)
            {
                OrderExamParameters _exam = new OrderExamParameters();
                _exam.Accession = _eDs.Tables[0].Rows[i]["ACCESSION_NO"].ToString();
                DateTime ExamTimeDate = string.IsNullOrEmpty(_eDs.Tables[0].Rows[i]["EXAM_DT"].ToString()) ? Convert.ToDateTime(_eDs.Tables[0].Rows[i]["ORDER_DT"]) : Convert.ToDateTime(_eDs.Tables[0].Rows[i]["EXAM_DT"]); ;
                string ExamDate = string.Format("{0}/{1}/{2}", ExamTimeDate.Day, ExamTimeDate.Month, ExamTimeDate.Year);
                string ExamTime = string.Format("{0}", ExamTimeDate.ToString("HH:mm"));
                _exam.ExamDate = ExamDate;
                _exam.ExamTime = ExamTime;
                _exam.ExamName = _eDs.Tables[0].Rows[i]["EXAM_NAME"].ToString() + "{" + _eDs.Tables[0].Rows[i]["BP_VIEW"].ToString() + "}";
                _exam.ExamUID = _eDs.Tables[0].Rows[i]["EXAM_UID"].ToString();
                _exam.Priority = _eDs.Tables[0].Rows[i]["EXAM_STATUS"].ToString();
                _exam.Rate = Convert.ToDecimal(_eDs.Tables[0].Rows[i]["RATE"]);
                _exam.Room = _eDs.Tables[0].Rows[i]["ROOM"].ToString();
                _exam.pStatus = _eDs.Tables[0].Rows[i]["PAT_STATUS"].ToString();
                _orderReportParameters.Unit = _eDs.Tables[0].Rows[0]["UNIT_UID"].ToString();
                _orderReportParameters.OrderBy = _eDs.Tables[0].Rows[0]["ORDER_BY"].ToString();
                _exam.Comment = _eDs.Tables[0].Rows[i]["COMMENTS_ONLINE"].ToString();
                _examParameters[i] = _exam;
            }
            ProcessGetHREmp _hrEmp = new ProcessGetHREmp();
            _hrEmp.HR_EMP.EMP_ID = Convert.ToInt32(_empId);
            _hrEmp.HR_EMP.MODE = "EmpId";
            _hrEmp.Invoke();
            this._orderReportParameters.PrintBy = string.Format("{0} {1}"
                , _hrEmp.Result.Tables[0].Rows[0]["FNAME"]
                , _hrEmp.Result.Tables[0].Rows[0]["LNAME"]);

            this._patientDemographic = new PatientDemographicParameters();
            ProcessGetHISRegistration _demographic = new ProcessGetHISRegistration(this.HN);
            _demographic.Invoke();
            if (_demographic.Result != null)
                if (_demographic.Result.Tables[0].Rows.Count != 0)
                {
                    _patientDemographic.Age = _demographic.Result.Tables[0].Rows[0]["AGE2"].ToString();
                    _patientDemographic.EngName = string.Format("{0}{1} {2} {3}", ""
                        , _demographic.Result.Tables[0].Rows[0]["FNAME_ENG"].ToString()
                        , _demographic.Result.Tables[0].Rows[0]["MNAME_ENG"].ToString()
                        , _demographic.Result.Tables[0].Rows[0]["LNAME_ENG"].ToString());
                    _patientDemographic.ThaiName = string.Format("{0}{1} {2} {3}", _demographic.Result.Tables[0].Rows[0]["TITLE"].ToString()
                        , _demographic.Result.Tables[0].Rows[0]["FNAME"].ToString()
                        , _demographic.Result.Tables[0].Rows[0]["MNAME"].ToString()
                        , _demographic.Result.Tables[0].Rows[0]["LNAME"].ToString());

                    _patientDemographic.HN = this.HN;
                    _patientDemographic.LMPDate = "-";
                    string gender = _demographic.Result.Tables[0].Rows[0]["GENDER"].ToString();
                    _patientDemographic.Gender = gender.Trim();
                }
        }
    }
}
