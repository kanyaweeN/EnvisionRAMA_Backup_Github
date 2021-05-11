using System;
using System.Data;
using System.Data.Common;
using EnvisionInterfaceEngine.Connection.Engine;
using MySql.Data.MySqlClient;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionInterfaceEngine.Connection
{
    public class HOSxPConnection_20130522 : MySqlEngine
    {
        private const string title_log = "EnvisionInterfaceEngine.Connection.HOSxPConnection";

        public HOSxPConnection_20130522() : base() { }
        public HOSxPConnection_20130522(string connectionString) : base(connectionString) { }
        ~HOSxPConnection_20130522() { base.Dispose(); }

        public DataTable selectDataPatientByHisHN(string hisHn)
        {
            string query = @"
select
    pat.hn as HIS_HN,
    pat.pname as PATIENT_TITLE,
    pat.fname as PATIENT_FNAME,
    pat.midname as PATIENT_MNAME,
    pat.lname as PATIENT_LNAME,
    pat.cid as PATIENT_SSN,
    pat.birthday as PATIENT_DOB,
    case pat.sex
        when 1 then 'M'
        when 2 then 'F'
        else 'O'
    end as PATIENT_GENDER,
    pat.hometel as PATIENT_PHONE1,
    pat.worktel as PATIENT_PHONE2,
    pat.informaddr as PATIENT_ADDRESS,
    pat_visit.vn as VISIT_NO,
	pat_ipd.an as ADMISSION_NO,
	IFNULL(pat_ipd_insurance.pttype, pat_opd_insurance.pttype) as INSURANCE_TYPE_UID,
	IFNULL(pat_ipd_insurance.name, pat_opd_insurance.name) as INSURANCE_TYPE_DESC,
	IFNULL(pat_ipd_unit.ward, pat_opd_unit.depcode) as REF_UNIT_UID,
	IFNULL(pat_ipd_unit.name, pat_opd_unit.department) as REF_UNIT_NAME,
	IFNULL(pat_ipd_doc.code, pat_opd_doc.code) as REF_DOC_UID,
	IFNULL(pat_ipd_doc.name, pat_opd_doc.name) as REF_DOC_NAME
from
	patient pat
	inner join ovst pat_visit
			on pat.hn = pat_visit.hn
			and pat_visit.vn in (select MAX(vn) from ovst where hn = pat.hn)
		left join pttype pat_opd_insurance
				on pat_visit.pttype = pat_opd_insurance.pttype
		left join kskdepartment pat_opd_unit
				on pat_visit.last_dep = pat_opd_unit.depcode
		left join doctor pat_opd_doc
				on pat_visit.doctor = pat_opd_doc.code
		left join ipt pat_ipd
				on pat_visit.an = pat_ipd.an
			left join pttype pat_ipd_insurance
					on pat_ipd.pttype = pat_ipd_insurance.pttype
			left join ward pat_ipd_unit
					on pat_ipd.ward = pat_ipd_unit.ward
			left join doctor pat_ipd_doc
					on pat_ipd.dch_doctor = pat_ipd_doc.code
where
    pat.hn = @HN";

            Parameters = new DbParameter[] {
                new MySqlParameter("@HN", hisHn)
            };

            return SelectData(query);
        }

        public DataTable selectDataOrderForCheckNonExists()
        {
            string query = @"
select
    ords.xn as ACCESSION_NO
from
    xray_report ords
    inner join opitemrece bill
            on ords.opitemrece_guid = bill.hos_guid
            and ords.request_date = CURDATE()
            and ords.confirm_read_film = 'N'";
            //and (ords.confirm = 'Y'
            //  or ords.pt_xn is not null)

            Parameters = null;

            return SelectData(query);
        }
        public DataTable selectDataOrderByAccessionNo(string accessionNo)
        {
            string query = @"
select
    ord.xray_order_number as REQUESTNO,
    ord.hn as HIS_HN,
    ord.vn as VISIT_NO,
    ords.an as ADMISSION_NO,
    ords.clinical_information as CLINICAL_INSTRUCTION,
    ords.xn as ACCESSION_NO,
    CAST(CONCAT_WS(
      '-',
      exam.xray_items_code,
      exam_part.xray_type) as char) as EXAM_UID,
    CONCAT_WS(
    ' ',
    exam.xray_items_name,
    exam_part.name) as EXAM_NAME,
    'N' as IS_DELETED,
    priority.xray_priority_id as PRIORITY_UID,
    (select SUM(qty) from xray_report_film where xn = ords.xn) as QTY,
    CONCAT(ord.department, ord.department_code) as REF_UNIT_UID,
    ord.department_name as REF_UNIT_NAME,
    doc.code as REF_DOC_UID,
    doc.name as REF_DOC_NAME,
    patstatus.xray_pt_status as PATSTATUS_UID,
    patstatus.name as PATSTATUS_TEXT,
    pat.pname as PATIENT_TITLE,
    pat.fname as PATIENT_FNAME,
    pat.midname as PATIENT_MNAME,
    pat.lname as PATIENT_LNAME,
    pat.cid as PATIENT_SSN,
    pat.birthday as PATIENT_DOB,
    case pat.sex
        when 1 then 'M'
        when 2 then 'F'
        else 'O'
    end as PATIENT_GENDER,
    pat.informaddr as PATIENT_ADDRESS,
    pat.hometel as PATIENT_PHONE1,
    pat.worktel as PATIENT_PHONE2
from
    xray_head ord
    inner join xray_report ords
            on (ord.vn = ords.vn or ord.vn = ords.an)
            and ords.xn = @ACCESSION_NO
            and ords.confirm_read_film = 'N'
        inner join xray_items exam
                on ords.xray_items_code = exam.xray_items_code
        left join xray_type exam_part
                on ords.xray_type = exam_part.xray_type
        left join xray_room room
                on ords.xray_room_id = room.xray_room
        left join xray_priority priority
                on ords.xray_priority_id = priority.xray_priority_id
        left join xray_pt_status patstatus
                on ords.xray_pt_status = patstatus.xray_pt_status
        left join doctor doc
                on ords.request_doctor = doc.code
    inner join patient pat
            on ord.hn = pat.hn";
            //and (ords.confirm = 'Y'
            //  or ords.pt_xn is not null)

            Parameters = new DbParameter[] {
                new MySqlParameter("@ACCESSION_NO", accessionNo)
            };

            return SelectData(query);
        }
        public DataTable selectDataOrderByAccessionNoForUpdate(string accessionNo, out bool success)
        {
            string query = @"
select
    pttype.pttype as INSURANCE_TYPE_UID,
    pttype.name as INSURANCE_TYPE_DESC,
    bill.qty as QTY,
    bill.sum_price as RATE,
    emp.doctorcode as LAST_MODIFIED_UID,
    emp.name as LAST_MODIFIED_NAME
from
    xray_head ord
    inner join xray_report ords
            on (ord.vn = ords.vn or ord.vn = ords.an)
            and ords.xn = @ACCESSION_NO
        inner join opitemrece bill
                on ords.opitemrece_guid = bill.hos_guid
        left join opduser emp
                on ords.staff = emp.loginname
                and emp.doctorcode is not null
    left join pttype
            on ord.pttype = pttype.pttype";

            Parameters = new DbParameter[] {
                new MySqlParameter("@ACCESSION_NO", accessionNo)
            };

            return SelectData(query, out success);
        }

        public bool selectCheckExistsOrderByAccessionNo(string accessionNo)
        {
            string query = @"
select
    ords.xn as ACCESSION_NO
from
    xray_report ords
where
    ords.xn = @ACCESSION_NO";

            Parameters = new DbParameter[] {
                new MySqlParameter("@ACCESSION_NO", accessionNo)
            };

            bool success = false;
            DataTable dtt = SelectData(query, out success);

            return !(success && !Utilities.HasData(dtt));
        }

        public bool updateDataResultExam(string accessionNo, string resultRtf, string resultText, string severityUid, string radUid, DateTime resultOn)
        {
            string query = @"
update
    xray_report
set
    report_date = CAST(@RESULT_ON as date),
    report_time = CAST(@RESULT_ON as time),
    examined_date = CAST(@RESULT_ON as date),
    examined_time = CAST(@RESULT_ON as time),
    report_rtf = @RESULT_RTF,
    report_text = @RESULT_TEXT,
    xray_note = @RESULT_TEXT,
    normal = @SEVERITY_UID,
    confirm = 'Y',
    confirm_read_film = 'Y',
    doctor = @RAD_UID,
    report_doctor = @RAD_UID
where
    xn = @ACCESSION_NO";

            Parameters = new DbParameter[]  {
                new MySqlParameter("@ACCESSION_NO", accessionNo),
                new MySqlParameter("@RESULT_RTF", resultRtf),
                new MySqlParameter("@RESULT_TEXT", resultText),
                new MySqlParameter("@SEVERITY_UID", severityUid),
                new MySqlParameter("@RAD_UID", radUid),
                new MySqlParameter("@RESULT_ON", resultOn)
            };

            return Execute(query);
        }
    }
}