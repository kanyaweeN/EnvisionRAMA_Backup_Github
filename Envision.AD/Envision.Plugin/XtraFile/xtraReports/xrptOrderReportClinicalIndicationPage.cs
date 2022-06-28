using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using System.Data;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptOrderReportClinicalIndicationPage : DevExpress.XtraReports.UI.XtraReport
    {
        private int _empId = new GBLEnvVariable().UserID;
        private int _orgId = new GBLEnvVariable().OrgID;
        private int _orderId;
        private string Clinic;
        private string HN;
        OrderReportParameters _orderReportParameters;
        PatientDemographicParameters _patientDemographic;

        public xrptOrderReportClinicalIndicationPage(string clinicalIndication, int ORDER_ID)
        {
            InitializeComponent();

            _orderId = ORDER_ID;
            GetAllParameters();
            this.SetBindTextControl();
            txtClinicalIndication.Text = clinicalIndication;
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
            //this._orderReportParameters.OrgName = "คณะแพทยศาสตร์โรงพยาบาลรามาธิบดี(ภาควิชารังสีวิทยา)";
            this._orderReportParameters.Clinic = this.Clinic;
            byte[] _orgImg = (byte[])_env.ResultSet.Tables[0].Rows[0]["ORG_IMG"];
            this._orderReportParameters.OrgImg = _orgImg;
            ProcessGetOrderReport _examOfReport = new ProcessGetOrderReport();
            _examOfReport.ORDER_ID = Convert.ToInt32(_orderId);
            _examOfReport.HN = HN;
            _examOfReport.ORG_ID = _orgId;
            _examOfReport.Invoke();

            DataSet _eDs = _examOfReport.Result;
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
            this._orderReportParameters.Request_Result_Datetime = string.IsNullOrEmpty(_eDs.Tables[0].Rows[0]["REQUEST_RESULT_DATETIME"].ToString()) ? "" : Convert.ToDateTime(_eDs.Tables[0].Rows[0]["REQUEST_RESULT_DATETIME"]).ToString("dd/MM/yyyy"); ;

            this._orderReportParameters.HL7Format = _eDs.Tables[0].Rows[0]["HL7_FORMAT"].ToString();
            this._orderReportParameters.PatientIDLabel = _eDs.Tables[0].Rows[0]["PATIENT_ID_LABEL"].ToString();

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
                        , _demographic.Result.Tables[0].Rows[0]["LNAME_ENG"].ToString()
                        , _demographic.Result.Tables[0].Rows[0]["PATIENT_ID_LABEL"].ToString());
                    _patientDemographic.ThaiName = string.Format("{0}{1} {2} {3}", _demographic.Result.Tables[0].Rows[0]["TITLE"].ToString()
                        , _demographic.Result.Tables[0].Rows[0]["FNAME"].ToString()
                        , _demographic.Result.Tables[0].Rows[0]["MNAME"].ToString()
                        , _demographic.Result.Tables[0].Rows[0]["LNAME"].ToString());

                    string _patientIdDetail = string.IsNullOrEmpty(_demographic.Result.Tables[0].Rows[0]["PATIENT_ID_LABEL"].ToString()) ? "" : "[" + _demographic.Result.Tables[0].Rows[0]["PATIENT_ID_LABEL"].ToString() + "]";
                    _patientDemographic.EngName += _patientIdDetail;
                    _patientDemographic.ThaiName += _patientIdDetail;

                    _patientDemographic.HN = this.HN;
                    _patientDemographic.LMPDate = "-";
                    string gender = _demographic.Result.Tables[0].Rows[0]["GENDER"].ToString();
                    //_patientDemographic.Gender = gender == "M" ? "Male" : "Female";
                    _patientDemographic.Gender = gender.Trim();
                }
        }
        private void SetBindTextControl()
        {
            ImageConverter convertor = new ImageConverter();
            Bitmap _image = new Bitmap((Image)convertor.ConvertFrom(_orderReportParameters.OrgImg), new Size(40, 40));
            this.orgImage1.Image = _image;

            txtOrgName.Text = this._orderReportParameters.OrgName.Trim();

            txtOrgAddress.Text = this._orderReportParameters.OrgAddress.Trim();

            if (this._orderReportParameters.HL7Format.Trim().Length == 0)
            {
                txtHN.Text = this.HN;
            }
            else
            {
                txtHN.Text = this.HN + " (" + this._orderReportParameters.HL7Format + ")";
            }

            this.xrBarCode2.Text = _patientDemographic.HN;
            txtPatientName.Text = _patientDemographic.ThaiName;
            txtPatientNameEng.Text = _patientDemographic.EngName;
            txtGender.Text = _patientDemographic.Gender;
            txtAge.Text = _patientDemographic.Age;
            txtClinicType.Text = _orderReportParameters.Clinic;
            txtStatus.Text = _orderReportParameters.PatientStatus;
            txtOrderingDept.Text = _orderReportParameters.Unit;
            txtLMP.Text = _orderReportParameters.LMP;
            txtPatientID.Text = _orderReportParameters.PatientIDLabel;
        }

    }
}
