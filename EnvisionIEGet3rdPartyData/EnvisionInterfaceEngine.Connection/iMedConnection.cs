using System;
using System.Data;
using System.Data.Common;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;
using Npgsql;

namespace EnvisionInterfaceEngine.Connection
{
    public class iMedConnection : PostgreSQLEngine
    {
        private const string title_log = "EnvisionInterfaceEngine.Connection.iMedConnection";

        public iMedConnection() : base() { }
        public iMedConnection(string connectionString) : base(connectionString) { }
        ~iMedConnection() { base.Dispose(); }

        public DataTable selectDataPatientHasChanged()
        {
            string query = @"
select
    hn_new as HIS_HN,
    title as PATIENT_TITLE,
    fname as PATIENT_FNAME,
    lname as PATIENT_LNAME,
    title_eng as PATIENT_TITLE_ENG,
    fname_eng as PATIENT_FNAME_ENG,
    lname_eng as PATIENT_LNAME_ENG,
	social_no as PATIENT_SSN,
    gender as PATIENT_GENDER,
    dob as PATIENT_DOB,
    address as PATIENT_ADD1,
    phone as PATIENT_PHONE1,
    hn_old as OLD_PATIENT_HIS_HN
from
	demographic
where
    ris_dttm = 'N'";

            Parameters = null;

            return SelectData(query);
        }
        public DataTable selectDataOrder()
        {
            string query = @"
select
    hn as HIS_HN,
    title as PATIENT_TITLE,
    fname as PATIENT_FNAME,
    lname as PATIENT_LNAME,
    pid as PATIENT_SSN,
    gender as PATIENT_GENDER,
    dob as PATIENT_DOB,
    address as PATIENT_ADD1,
    phone as PATIENT_PHONE1,
    request_datetime as ORDER_DT,
    reportwl_key as REQUESTNO,
    clinical_data as CLINICAL_INSTRUCTION,
    accession_no as ACCESSION_NO,
    rate as ORDERDTL_RATE,
    insurance_code as INSURANCE_TYPE_UID,
    insurance_desc as INSURANCE_TYPE_DESC,
	unit_code as REF_UNIT_UID,
    unit_name as REF_UNIT_NAME,
    physician_code as REF_DOC_UID,
    physician_title as REF_DOC_SALUTATION,
    physician_fname as REF_DOC_FNAME,
    physician_lname as REF_DOC_LNAME,
    physician_fname_eng as REF_DOC_FNAME_ENG,
    physician_lname_eng as REF_DOC_LNAME_ENG,
    physician_tel as REF_DOC_PHONE,
    exam_code as EXAM_UID,
    exam_name as EXAM_NAME,
    case status
        when 'D' then 'CA'
        else 'NW'
    end as OrderControl
from
    envision_mwlwl
where
    ris_dttm = 'N'";

            Parameters = null;

            return SelectData(query);
        }

        public bool updateFlagPatient(string hisHn)
        {
            string query = @"
update
	demographic
set
    ris_dttm = '" + DateTime.Today.ToString("yyyyMMddHHmmss") + @"'
where
    hn_new = '" + hisHn + @"'";

            Parameters = null;

            return Execute(query);
        }
        public bool updateFlagOrder(string accessionNo)
        {
            string query = @"
update
	envision_mwlwl
set
    ris_dttm = '" + DateTime.Today.ToString("yyyyMMddHHmmss") + @"'
where
    accession_no = '" + accessionNo + @"'";

            Parameters = null;

            return Execute(query);
        }

        public bool editDataResultExam(string hisHn, string accessionNo, string resultText, string resultRtf, string resultHtml, string resultStatus, string radUid, string radSalutation, string radFName, string radLName, string radFNameEng, string radLNameEng, string radiologist, DateTime resultOn)
        {
            string query = @"
select
    accession_no
from
	envision_reportwl
where
    accession_no = @accession_no";

            Parameters = new DbParameter[] {
                new NpgsqlParameter("@accession_no", accessionNo)
            };

            if (Utilities.HasData(SelectData(query)))
            {
                #region query update
                query = @"
update
    envision_reportwl
set
    hn                  = @hn,
    report_text         = @report_text,
    report_rtf          = @report_rtf,
    report_html         = @report_html,
    report_status       = @report_status,
    rad_code            = @rad_code,
    rad_fname           = @rad_fname,
    rad_lname           = @rad_lname,
    rad_fname_eng       = @rad_fname_eng,
    rad_lname_eng       = @rad_lname_eng,
    rad_title           = @rad_title,
    rad_fullname        = @rad_fullname,
    report_datetime     = @report_datetime,
    his_dttm            = 'N'
where
    accession_no        = @accession_no";
                #endregion
            }
            else
            {
                #region query insert
                query = @"
insert into envision_reportwl
(
    hn,
    accession_no,
    report_text,
    report_rtf,
    report_html,
    report_status,
    rad_code,
    rad_fname,
    rad_lname,
    rad_fname_eng,
    rad_lname_eng,
    rad_title,
    rad_fullname,
    report_datetime,
    his_dttm
)
values
(
    @hn,
    @accession_no,
    @report_text,
    @report_rtf,
    @report_html,
    @report_status,
    @rad_code,
    @rad_fname,
    @rad_lname,
    @rad_fname_eng,
    @rad_lname_eng,
    @rad_title,
    @rad_fullname,
    @report_datetime,
    'N'
)";
                #endregion
            }

            Parameters = new DbParameter[] {
                new NpgsqlParameter("@hn", hisHn),
                new NpgsqlParameter("@accession_no", accessionNo),
                new NpgsqlParameter("@report_text", resultText),
                new NpgsqlParameter("@report_rtf", resultRtf),
                new NpgsqlParameter("@report_html", resultHtml),
                new NpgsqlParameter("@report_status", resultStatus),
                new NpgsqlParameter("@rad_code", radUid),
                new NpgsqlParameter("@rad_fname", radFName),
                new NpgsqlParameter("@rad_lname", radLName),
                new NpgsqlParameter("@rad_fname_eng", radFNameEng),
                new NpgsqlParameter("@rad_lname_eng", radLNameEng),
                new NpgsqlParameter("@rad_title", radSalutation),
                new NpgsqlParameter("@rad_fullname", radiologist),
                new NpgsqlParameter("@report_datetime", resultOn.ToString("yyyyMMddHHmmss")),
            };

            return Execute(query);
        }
    }
}