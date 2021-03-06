using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Xml;
using System.Data;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using Miracle.Translator;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptOrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        private int _empId = new GBLEnvVariable().UserID;
        private int _orgId = new GBLEnvVariable().OrgID;
        private int _orderId;
        private string HN;
        private string Clinic;

        OrderReportParameters _orderReportParameters;
        OrderExamParameters[] _examParameters;
        PatientDemographicParameters _patientDemographic;

        private OrderExamParameters[] examList;
        public xrptOrderReport(int ORDER_ID)
        {
            InitializeComponent();

            _orderId = ORDER_ID;
            GetAllParameters();

            this.examList = _examParameters;
            this.SetAllParameter();
            this.xrSubreport1.ReportSource = new ExamSubReport() { DataSource = _examParameters };
            this.xrSubreport2.ReportSource = new Exam2SubReport() { DataSource = _examParameters };

            //this.Parameters.Clear();
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
            //this.p_pLmp.Value = _patientDemographic.LMPDate;
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
            //Set order description
            GetOrderDescription();
        }
        private void GetOrderDescription()
        {
            this.Parameters["pDes" + 1].Value = "เอกสารนี้ ใช้เป็นหลักฐานในการเอกซเรย์";
        }
        private void GetAllParameters()
        {
            this._orderReportParameters = new OrderReportParameters();
            ProcessGetGBLEnv _env = new ProcessGetGBLEnv();
            //_env.GBL_ENV.ORG_ID = _orgId;
            _env.Invoke();
            this._orderReportParameters.OrgAddress = string.Format("{0} {1} {2} {3}"
                            , _env.ResultSet.Tables[0].Rows[0]["ORG_ADDR1"]
                            , _env.ResultSet.Tables[0].Rows[0]["ORG_ADDR2"]
                            , _env.ResultSet.Tables[0].Rows[0]["ORG_ADDR3"]
                            , _env.ResultSet.Tables[0].Rows[0]["ORG_ADDR4"]);
            this._orderReportParameters.OrgName = "คณะแพทยศาสตรโรงพยาบาลรามาธิบดี(ภาควิชารังสีวิทยา)";
            this._orderReportParameters.Clinic = this.Clinic;
            byte[] _orgImg = (byte[])_env.ResultSet.Tables[0].Rows[0]["ORG_IMG"];
            this._orderReportParameters.OrgImg = _orgImg;
            ProcessGetOrderReport _examOfReport = new ProcessGetOrderReport();
            _examOfReport.ORDER_ID = Convert.ToInt32(_orderId);
            _examOfReport.HN = HN;
            _examOfReport.ORG_ID = _orgId;
            _examOfReport.Invoke();
            DataSet _eDs = _examOfReport.Result;
            _examParameters = new OrderExamParameters[_eDs.Tables[0].Rows.Count];
            this.HN = _eDs.Tables[0].Rows[0]["HN"].ToString();
            for (int i = 0; i < _eDs.Tables[0].Rows.Count; i++)
            {
                OrderExamParameters _exam = new OrderExamParameters();
                _exam.Accession = _eDs.Tables[0].Rows[i]["ACCESSION_NO"].ToString();
                DateTime ExamTimeDate = Convert.ToDateTime(_eDs.Tables[0].Rows[i]["EXAM_DT"]);
                string ExamDate = string.Format("{0}/{1}/{2}", ExamTimeDate.Day, ExamTimeDate.Month, ExamTimeDate.Year);
                string ExamTime = string.Format("{0}:{1}", ExamTimeDate.Hour, ExamTimeDate.Minute);
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
                //add to array
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
            //_demographic.HIS_REGISTRATION.HN = this.HN;
            //_demographic.HIS_REGISTRATION.ORG_ID = 1;
            //_demographic.HN = this.HN;
            //_demographic.ORG_ID = 1;
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
                    if (_patientDemographic.EngName.Trim() == string.Empty)
                    {
                        //auto translate
                        _patientDemographic.EngName = string.Format("{0}{1} {2} {3}", ""
                        , TransToEnglish.Trans(_demographic.Result.Tables[0].Rows[0]["FNAME"].ToString())
                        , TransToEnglish.Trans(_demographic.Result.Tables[0].Rows[0]["MNAME"].ToString())
                        , TransToEnglish.Trans(_demographic.Result.Tables[0].Rows[0]["LNAME"].ToString()));
                    }
                    _patientDemographic.HN = this.HN;
                    _patientDemographic.LMPDate = "-";
                    string gender = _demographic.Result.Tables[0].Rows[0]["GENDER"].ToString();
                    //_patientDemographic.Gender = gender == "M" ? "Male" : "Female";
                    _patientDemographic.Gender = gender.Trim();
                }
        }
    }
}
