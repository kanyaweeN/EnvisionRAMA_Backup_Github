using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using EnvisionInterfaceEngine.Common;
using EnvisionInterfaceEngine.Common.Global;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionInterfaceEngine.Connection
{
    public class RISConnection : MsSqlEngine
    {
        public RISConnection() : base() { ConnectionString = Config.ConnectionString; }
        public RISConnection(string connectionString) : base(connectionString) { }

        public DataTable selectRisClinicTypeByDateTime(DateTime date, int orgId)
        {
            if (date == null || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
	cn_session.CLINIC_TYPE_ID
from
	RIS_CLINICSESSION cn_session
where
	ISNULL(cn_session.IS_ACTIVE, 'Y') = 'Y'
	and CONVERT(TIME, @DATE) between CONVERT(TIME, START_TIME) and CONVERT(TIME, END_TIME)
    ";

            Parameters = new DbParameter[] {
                DoParameter("@DATE", date),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }
        public DataTable selectRisClinicTypeIsDefault(int orgId)
        {
            if (orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
	cn_type.CLINIC_TYPE_ID
from
	RIS_CLINICTYPE cn_type
where
	ISNULL(cn_type.IS_ACTIVE, 'Y') = 'Y'
	and ISNULL(cn_type.IS_DEFAULT, 'N') = 'Y'
	";

            Parameters = new DbParameter[] { DoParameter("@ORG_ID", orgId) };

            return SelectData(query);
        }
        public DataTable selectRisExamPanel(int examId)
        {
            if (examId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    exam_panel.AUTO_EXAM_ID,
    auto_exam.SERVICE_TYPE,
    ISNULL(bpview.NO_OF_EXAM, 0) as NO_OF_EXAM
from
    RIS_EXAMPANEL exam_panel
    inner join RIS_EXAM auto_exam
			on exam_panel.AUTO_EXAM_ID = auto_exam.EXAM_ID
			and ISNULL(auto_exam.IS_ACTIVE, 'Y') = 'Y'
			and exam_panel.EXAM_ID = @EXAM_ID
		left join RIS_BPVIEW bpview
				on auto_exam.BP_ID = bpview.BPVIEW_ID";

            Parameters = new DbParameter[] { DoParameter("@EXAM_ID", examId) };

            return SelectData(query);
        }
        public DataTable selectRisModalityExamByExamId(int examId)
        {
            if (examId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    modality.MODALITY_ID,
    modality_type.TYPE_NAME_ALIAS
from
    RIS_MODALITYEXAM modality_exam
    inner join RIS_MODALITY modality
            on modality_exam.MODALITY_ID = modality.MODALITY_ID
            and ISNULL(modality.IS_ACTIVE, 'Y') = 'Y'
            and modality_exam.EXAM_ID = @EXAM_ID
            and ISNULL(modality_exam.IS_ACTIVE, 'Y') = 'Y'
		inner join RIS_MODALITYTYPE modality_type
				on modality.MODALITY_TYPE = modality_type.[TYPE_ID]
order by
    modality_exam.IS_DEFAULT_MODALITY desc";

            Parameters = new DbParameter[] { DoParameter("@EXAM_ID", examId) };

            return SelectData(query);
        }
        public DataTable selectRisOrderHasActived(string requestNo, int orgId)
        {
            if (string.IsNullOrEmpty(requestNo) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

if not exists (select
	ord.ORDER_ID
from
	RIS_ORDER ord
	inner join RIS_ORDERDTL ords
			on ord.ORDER_ID = ords.ORDER_ID
where
	(ISNULL(ord.IS_CANCELED, 'N') = 'Y'
		or ISNULL(ords.IS_DELETED, 'N') = 'Y'
		or ISNULL(ords.[STATUS], 'A') != 'A'
        or DATEDIFF(DAY, ord.ORDER_DT, GETDATE()) > 0)
	and ord.REQUESTNO = @REQUESTNO
	)
begin
	select
		ord.ORDER_ID,
		ord.REG_ID,
		ords.EXAM_ID
	from
		RIS_ORDER ord
		inner join RIS_ORDERDTL ords
				on ord.ORDER_ID = ords.ORDER_ID
	where
		ord.REQUESTNO = @REQUESTNO
end";

            Parameters = new DbParameter[] {
                DoParameter("@REQUESTNO", requestNo),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }
        public DataTable selectRisHL7IELogByLogId(int logId)
        {
            if (logId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    log.*
from
    RIS_HL7IELOG log
where
	log.LOG_ID = @LOG_ID";

            Parameters = new DbParameter[] { DoParameter("@LOG_ID", logId) };

            return SelectData(query);
        }
        public DataTable selectRisHL7IELogSender(RIS_HL7IELOG log)
        {
            if ((string.IsNullOrEmpty(log.HN) && string.IsNullOrEmpty(log.ACCESSION_NO)) || log.ORG_ID < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    LOG_ID,
    SENDER_ID
from
    RIS_HL7IELOG
where
    MESSAGE_TYPE = @MESSAGE_TYPE
	and EVENT_TYPE = @EVENT_TYPE
	and ((MESSAGE_TYPE = 'ADT' and HN = @HN) or (MESSAGE_TYPE != 'ADT' and ACCESSION_NO = @ACCESSION_NO))
order by
    LOG_ID";

            Parameters = new DbParameter[] {
                DoParameter("@MESSAGE_TYPE", log.MESSAGE_TYPE),
                DoParameter("@EVENT_TYPE", log.EVENT_TYPE),
                DoParameter("@HN", log.HN),
                DoParameter("@ACCESSION_NO", log.ACCESSION_NO),
                DoParameter("@ORG_ID", log.ORG_ID)};

            return SelectData(query);
        }

        public DataTable selectDataExistsPatientByHn(string hn, int orgId)
        {
            if (string.IsNullOrEmpty(hn) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    REG_ID,
    TITLE,
    FNAME,
    LNAME,
    TITLE_ENG,
    FNAME_ENG,
    LNAME_ENG
from
    HIS_REGISTRATION
where
    HN = @HN
    ";

            Parameters = new DbParameter[] {
                DoParameter("@HN", hn),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }
        public DataTable selectDataExistsEmpByAliasName(string aliasName, int orgId)
        {
            if (string.IsNullOrEmpty(aliasName) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
	emp.EMP_ID
from
	HR_EMP emp
where
	emp.ALIAS_NAME = @ALIAS_NAME
	";

            Parameters = new DbParameter[] {
                DoParameter("@ALIAS_NAME", aliasName),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }
        public DataTable selectDataExistsEmpByEmpUId(string empUid, int orgId)
        {
            if (string.IsNullOrEmpty(empUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    EMP_ID
from
    HR_EMP
where
    EMP_UID = @EMP_UID
    ";

            Parameters = new DbParameter[] {
                DoParameter("@EMP_UID", empUid),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }
        public DataTable selectDataExistsExamByExamUid(string examUid, int orgId)
        {
            if (string.IsNullOrEmpty(examUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    exam.EXAM_ID,
    exam.SERVICE_TYPE,
    ISNULL(exam.QA_REQUIRED, 'Y') as QA_REQUIRED,
    ISNULL(exam.IS_ACTIVE, 'Y') as IS_ACTIVE,
    1 as NO_OF_EXAM
from
    RIS_EXAM exam
where
	exam.EXAM_UID = @EXAM_UID
	";

            Parameters = new DbParameter[] {
                DoParameter("@EXAM_UID", examUid),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }

        #region query exists billing
        private const string query_exists_billing = @"
SET NOCOUNT ON

select
    ord.ORG_ID,
    ord.HN,
    ords.ORDER_ID,
	ords.ACCESSION_NO,
    exam.QA_REQUIRED,
    ISNULL(ord.IS_CANCELED, 'N') as IS_CANCELED,
    ISNULL(ords.IS_DELETED, 'N') as IS_DELETED
from
	RIS_ORDER ord
	inner join RIS_ORDERDTL ords
			on ord.ORDER_ID = ords.ORDER_ID
			{0}
        inner join RIS_EXAM exam
                on ords.EXAM_ID = exam.EXAM_ID";
        #endregion
        public DataTable selectDataExistsBillingByRequestNoAndExamId(string requestNo, int examId, int orgId)
        {
            if (string.IsNullOrEmpty(requestNo) || examId < 1 || orgId < 1) return null;

            Parameters = new DbParameter[] {
                DoParameter("@REQUESTNO", requestNo),
                DoParameter("@EXAM_ID", examId),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(string.Format(query_exists_billing, "and ord.REQUESTNO = @REQUESTNO and ords.EXAM_ID = @EXAM_ID"));
        }
        public DataTable selectDataExistsBillingByAccessionNo(string accessionNo, int orgId)
        {
            if (string.IsNullOrEmpty(accessionNo) || orgId < 1) return null;

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(string.Format(query_exists_billing, "and ords.ACCESSION_NO = @ACCESSION_NO"));
        }
        public DataTable selectDataExistsBillingByInstanceUid(string instanceUid, int orgId)
        {
            if (string.IsNullOrEmpty(instanceUid) || orgId < 1) return null;

            Parameters = new DbParameter[] {
                DoParameter("@INSTANCE_UID", instanceUid),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(string.Format(query_exists_billing, "and ords.INSTANCE_UID = @INSTANCE_UID"));
        }
        public DataTable selectDataExistsUnitByUnitUid(string unitUid, int orgId)
        {
            if (string.IsNullOrEmpty(unitUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    unit.UNIT_ID
from
    HR_UNIT unit
where
    unit.UNIT_UID = @UNIT_UID
    ";

            Parameters = new DbParameter[] {
                DoParameter("@UNIT_UID", unitUid),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }
        public DataTable selectDataExistsPatientStatusByStatusUid(string statusUid, int orgId)
        {
            if (string.IsNullOrEmpty(statusUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    patstatus.STATUS_ID,
    ISNULL(patstatus.IS_ACTIVE, 'Y') as IS_ACTIVE
from
    RIS_PATSTATUS patstatus
where
    patstatus.STATUS_UID = @STATUS_UID
    ";

            Parameters = new DbParameter[] {
                DoParameter("@STATUS_UID", statusUid),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }
        public DataTable selectDataExistsOrgByOrgAlias(string orgAlias)
        {
            if (string.IsNullOrEmpty(orgAlias)) return null;

            string query = @"
SET NOCOUNT ON

select
    env.ORG_ID,
    env.ORG_UID
from
    GBL_ENV env
where
    env.ORG_ALIAS = @ORG_ALIAS";

            Parameters = new DbParameter[] { DoParameter("@ORG_ALIAS", orgAlias) };

            return SelectData(query);
        }
        public DataTable selectDataExistsModalityExam(int modalityId, int examId)
        {
            if (modalityId < 1 || examId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
	moex.*
from
	RIS_MODALITYEXAM moex
where
	moex.MODALITY_ID = @MODALITY_ID
	and moex.EXAM_ID = @EXAM_ID";

            Parameters = new DbParameter[] {
                DoParameter("@MODALITY_ID", modalityId),
                DoParameter("@EXAM_ID", examId)};

            return SelectData(query);
        }
        public DataTable selectDataExistsModalityAETitleByAETitle(string aeTitleName, int orgId)
        {
            if (string.IsNullOrEmpty(aeTitleName) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
	aetitle.AE_TITLE_ID,
	aetitle.MODALITY_ID
from
	RIS_MODALITYAETITLE aetitle
where
	aetitle.AE_TITLE_NAME = @AE_TITLE_NAME
	";

            Parameters = new DbParameter[] {
                DoParameter("@AE_TITLE_NAME", aeTitleName),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }
        public DataTable selectDataIntegrationConfig()
        {
            string query = @"
SET NOCOUNT ON

select
	*
from
	RIS_INTEGRATIONCONFIG config
	inner join RIS_INTEGRATIONSERVERS sv
			on config.SERVER_ID = sv.SERVER_ID
            and ISNULL(config.IS_ACTIVE, 1) = 1";

            Parameters = null;

            return SelectData(query);
        }
        public DataTable selectDataUpdateHTML()
        {
            string query = @"
SET NOCOUNT ON
select ACCESSION_NO from ris_examresult 
where
LAST_MODIFIED_ON between CONVERT(datetime,'2020-08-20 0:00:00') and getdate()
and RESULT_STATUS in ('P','F')
and isnull( RESULT_TEXT_HTML ,'') = ''";

            Parameters = null;

            return SelectData(query);
        }
        public DataTable selectDataIntegrationConfigByWorkStationId(int workStationId)
        {
            string query = @"
SET NOCOUNT ON

select
	*
from
	RIS_INTEGRATIONCONFIG config
	inner join RIS_INTEGRATIONSERVERS sv
			on config.SERVER_ID = sv.SERVER_ID
			and config.WORK_STATION_ID = @WORK_STATION_ID";

            Parameters = new DbParameter[] { DoParameter("@WORK_STATION_ID", workStationId) };

            return SelectData(query);
        }
        public DataTable selectDataRadiologistByEmpUId(string empUid, int orgId)
        {
            if (string.IsNullOrEmpty(empUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    emp.EMP_ID
from
    HR_EMP emp
where
    emp.EMP_UID = @EMP_UID
	and ISNULL(emp.JOB_TYPE, 'U') = 'D'
	and ISNULL(emp.IS_RADIOLOGIST, 'N') = 'Y'
	and ISNULL(emp.IS_ACTIVE, 'Y') = 'Y'
	and ISNULL(emp.SUPPORT_USER, 'N')  = 'N'
    ";

            Parameters = new DbParameter[] {
                DoParameter("@EMP_UID", empUid),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(query);
        }
        #region query adt
        private const string query_adt = @"
SET NOCOUNT ON

select
	(select top 1 WORK_STATION_UID from RIS_INTEGRATIONCONFIG where WORK_STATION_ID = 0) as SendingApplication,
	'' as ReceivingApplication,
	org.ORG_ID,
	org.ORG_ALIAS,
	patient.REG_ID,
	patient.REG_DT,
	patient.EXT_HN,
	patient.HN,
	patient.HIS_HN,
	patient.TITLE as PATIENT_TITLE,
	patient.FNAME as PATIENT_FNAME,
	patient.LNAME as PATIENT_LNAME,
	patient.TITLE_ENG as PATIENT_TITLE_ENG,
	patient.FNAME_ENG as PATIENT_FNAME_ENG,
	patient.LNAME_ENG as PATIENT_LNAME_ENG,
	patient.SSN as PATIENT_SSN,
	patient.GENDER as PATIENT_GENDER,
	patient.DOB as PATIENT_DOB,
	patient.ADDR1 as PATIENT_ADDR1,
	patient.ADDR2 as PATIENT_ADDR2,
	patient.ADDR3 as PATIENT_ADDR3,
	patient.ADDR4 as PATIENT_ADDR4,
	patient.ADDR5 as PATIENT_ADDR5,
	patient.PHONE1 as PATIENT_PHONE1,
	patient.PHONE2 as PATIENT_PHONE2,
	register.EMP_ID as REGISTER_ID,
	register.EMP_UID as REGISTER_UID,
	register.SALUTATION as REGISTER_SALUTATION,
	register.FNAME as REGISTER_FNAME,
	register.LNAME as REGISTER_LNAME,
	register.TITLE_ENG as REGISTER_TITLE_ENG,
	register.FNAME_ENG as REGISTER_FNAME_ENG,
	register.LNAME_ENG as REGISTER_LNAME_ENG,
	patient.LAST_MODIFIED_BY
from
	HIS_REGISTRATION patient
	inner join HR_EMP register
			on patient.LAST_MODIFIED_BY = register.EMP_ID
	inner join GBL_ENV org
			on patient.ORG_ID = org.ORG_ID
{0}";
        #endregion
        public DataTable selectDataHL7ADTByHN(string hn, int orgId)
        {
            if (string.IsNullOrEmpty(hn) || orgId < 1) return null;

            Parameters = new DbParameter[] {
                DoParameter("@HN", hn),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(string.Format(query_adt, "where patient.HN = @HN"));
        }
        #region query orm
        private const string query_orm = @"
SET NOCOUNT ON

select
	(select top 1 WORK_STATION_UID from RIS_INTEGRATIONCONFIG where WORK_STATION_ID = 0) as SendingApplication,
	'' as ReceivingApplication,
	org.ORG_ID,
	org.ORG_ALIAS,
	patient.REG_ID,
	patient.REG_DT,
	patient.EXT_HN,
	patient.HN,
	patient.HIS_HN,
	patient.TITLE as PATIENT_TITLE,
	patient.FNAME as PATIENT_FNAME,
	patient.LNAME as PATIENT_LNAME,
	patient.TITLE_ENG as PATIENT_TITLE_ENG,
	patient.FNAME_ENG as PATIENT_FNAME_ENG,
	patient.LNAME_ENG as PATIENT_LNAME_ENG,
	patient.SSN as PATIENT_SSN,
	patient.GENDER as PATIENT_GENDER,
	patient.DOB as PATIENT_DOB,
	patient.ADDR1 as PATIENT_ADDR1,
	patient.ADDR2 as PATIENT_ADDR2,
	patient.ADDR3 as PATIENT_ADDR3,
	patient.ADDR4 as PATIENT_ADDR4,
	patient.ADDR5 as PATIENT_ADDR5,
	patient.PHONE1 as PATIENT_PHONE1,
	patient.PHONE2 as PATIENT_PHONE2,
	register.EMP_ID as REGISTER_ID,
	register.EMP_UID as REGISTER_UID,
	register.SALUTATION as REGISTER_SALUTATION,
	register.FNAME as REGISTER_FNAME,
	register.LNAME as REGISTER_LNAME,
	register.TITLE_ENG as REGISTER_TITLE_ENG,
	register.FNAME_ENG as REGISTER_FNAME_ENG,
	register.LNAME_ENG as REGISTER_LNAME_ENG,
	ord.ORDER_ID,
	ord.ORDER_DT,
	ord.VISIT_NO,
	ord.ADMISSION_NO,
	ord.REQUESTNO,
	ord.CLINICAL_INSTRUCTION,
	ords.Q_NO,
	ords.ACCESSION_NO,
	ords.QTY,
	ords.RATE as ORDERDTL_RATE,
	ords.INSTANCE_UID,
	ords.IMAGE_CAPTURED_ON,
	ords.[STATUS],
	ords.WORK_STATION_ID,
	case ords.[STATUS]
        when 'N' then 'New'
        when 'A' then 'New'
        when 'S' then 'Sent'
        when 'C' then 'Complete'
        when 'D' then 'Draft'
        when 'P' then 'Prelim'
        when 'F' then 'Finalized'
    end as StatusText,
	case ords.[PRIORITY]
		when 'R' then 'R'
		else 'S'
	end as [PRIORITY],
	pat_status.STATUS_ID as PATIENT_STATUS_ID,
	pat_status.STATUS_UID as PATIENT_STATUS_UID,
	pat_status.STATUS_TEXT as PATIENT_STATUS_TEXT,
	ins.INSURANCE_TYPE_ID,
	ins.INSURANCE_TYPE_UID,
	ins.INSURANCE_TYPE_DESC,
	ref_unit.UNIT_ID as REF_UNIT_ID,
	ref_unit.UNIT_UID as REF_UNIT_UID,
    ref_unit.UNIT_UID + ' : ' + ref_unit.UNIT_NAME as REF_UNIT_NAME,
	ref_doc.EMP_ID as REF_DOC_ID,
	ref_doc.EMP_UID as REF_DOC_UID,
	ref_doc.SALUTATION as REF_DOC_SALUTATION,
	ref_doc.FNAME as REF_DOC_FNAME,
	ref_doc.LNAME as REF_DOC_LNAME,
	ref_doc.TITLE_ENG as REF_DOC_TITLE_ENG,
	ref_doc.FNAME_ENG as REF_DOC_FNAME_ENG,
	ref_doc.LNAME_ENG as REF_DOC_LNAME_ENG,
	rad.*,
	exam.EXAM_ID,
	exam.EXAM_UID,
	exam.EXAM_NAME,
	exam.RATE as EXAM_RATE,
	exam.SERVICE_TYPE,
	ISNULL(exam.DEFER_HIS_RECONCILE, 'N') as DEFER_HIS_RECONCILE,
	modality.TYPE_NAME_ALIAS,
	operator.EMP_ID as OPERATOR_ID,
	operator.EMP_UID as OPERATOR_UID,
	operator.SALUTATION as OPERATOR_SALUTATION,
	operator.FNAME as OPERATOR_FNAME,
	operator.LNAME as OPERATOR_LNAME,
	operator.TITLE_ENG as OPERATOR_TITLE_ENG,
	operator.FNAME_ENG as OPERATOR_FNAME_ENG,
	operator.LNAME_ENG as OPERATOR_LNAME_ENG,
	case
		when ord.IS_CANCELED = 'Y' then 'CA'
		when ords.IS_DELETED = 'Y' then 'CA'
		else case ords.[STATUS]
            when 'A' then 'NW'
            when 'S' then 'SC'
            when 'C' then 'SC'
            else ''
        end
	end as Hl7OrderControl,
	case
		when ord.IS_CANCELED = 'Y' then 'CA'
		when ords.IS_DELETED = 'Y' then 'CA'
		else case ords.[STATUS]
            when 'S' then 'SC'
            when 'C' then 'SC'
            else ''
        end
    end as Hl7OrderStatus,
	case ords.[STATUS]
        when 'A' then 'S'
        when 'S' then 'Sent'
        when 'C' then 'Complete'
        when 'P' then 'P'
        when 'F' then 'F'
        else ''
    end as Hl7ResultStatus,
	ords.LAST_MODIFIED_BY
from
	RIS_ORDER ord
	inner join RIS_ORDERDTL ords
			on ord.ORDER_ID = ords.ORDER_ID
		inner join RIS_EXAM exam
				on ords.EXAM_ID = exam.EXAM_ID
		inner join HR_EMP operator
				on ords.LAST_MODIFIED_BY = operator.EMP_ID
		left join (select
						modality.MODALITY_ID,
						modality_type.TYPE_NAME_ALIAS
					from
						RIS_MODALITY modality
						inner join RIS_MODALITYTYPE modality_type
								on modality.MODALITY_TYPE = modality_type.[TYPE_ID]) as modality
				on ords.MODALITY_ID = modality.MODALITY_ID
		left join (select
						rad.EMP_ID as RAD_ID,
						rad.EMP_UID as RAD_UID,
						rad.SALUTATION as RAD_SALUTATION,
						rad.FNAME as RAD_FNAME,
						rad.LNAME as RAD_LNAME,
						rad.TITLE_ENG as RAD_TITLE_ENG,
						rad.FNAME_ENG as RAD_FNAME_ENG,
						rad.LNAME_ENG as RAD_LNAME_ENG,
						rad.FNAME_ENG
							+ ' '
							+ rad.LNAME_ENG
							+ ', M.D. '
							+ rad_title.JOB_TITLE_DESC as Radiologist
					from
						HR_EMP rad
						inner join HR_JOBTITLE rad_title
								on rad.JOBTITLE_ID = rad_title.JOB_TITLE_ID) as rad
				on ords.ASSIGNED_TO = rad.RAD_ID
	inner join GBL_ENV org
			on ord.ORG_ID = org.ORG_ID
	inner join HIS_REGISTRATION patient
			on ord.REG_ID = patient.REG_ID
	inner join HR_EMP register
			on ord.LAST_MODIFIED_BY = register.EMP_ID
	left join RIS_PATSTATUS pat_status
			on ord.PAT_STATUS = pat_status.STATUS_ID
	left join RIS_INSURANCETYPE ins
			on ord.INSURANCE_TYPE_ID = ins.INSURANCE_TYPE_ID
	left join HR_UNIT ref_unit
			on ord.REF_UNIT = ref_unit.UNIT_ID
	left join HR_EMP ref_doc
			on ord.REF_DOC = ref_doc.EMP_ID
{0}";
        #endregion
        public DataTable selectDataHL7ORMByAccessionNo(string accessionNo, int orgId)
        {
            if (string.IsNullOrEmpty(accessionNo) || orgId < 1) return null;

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo),
                DoParameter("@ORG_ID", orgId)};

            return SelectData(string.Format(query_orm, "where ords.ACCESSION_NO = @ACCESSION_NO"));
        }
        public DataTable selectDataHL7ORMByOrderId(int orderId)
        {
            if (orderId < 1) return null;

            Parameters = new DbParameter[] { DoParameter("@ORDER_ID", orderId) };

            return SelectData(string.Format(query_orm, "where ord.ORDER_ID = @ORDER_ID"));
        }
        #region query oru
        #region query_oru
        private string query_oru = @"
SET NOCOUNT ON

select
	(select top 1 WORK_STATION_UID from RIS_INTEGRATIONCONFIG where WORK_STATION_ID = 0) as SendingApplication,
	'' as ReceivingApplication,
	org.ORG_ID,
	org.ORG_ALIAS,
	patient.REG_ID,
	patient.REG_DT,
	patient.EXT_HN,
	patient.HN,
	patient.HIS_HN,
	patient.TITLE as PATIENT_TITLE,
	patient.FNAME as PATIENT_FNAME,
	patient.LNAME as PATIENT_LNAME,
	patient.TITLE_ENG as PATIENT_TITLE_ENG,
	patient.FNAME_ENG as PATIENT_FNAME_ENG,
	patient.LNAME_ENG as PATIENT_LNAME_ENG,
	patient.SSN as PATIENT_SSN,
	patient.GENDER as PATIENT_GENDER,
	patient.DOB as PATIENT_DOB,
	patient.ADDR1 as PATIENT_ADDR1,
	patient.ADDR2 as PATIENT_ADDR2,
	patient.ADDR3 as PATIENT_ADDR3,
	patient.ADDR4 as PATIENT_ADDR4,
	patient.ADDR5 as PATIENT_ADDR5,
	patient.PHONE1 as PATIENT_PHONE1,
	patient.PHONE2 as PATIENT_PHONE2,
	register.EMP_ID as REGISTER_ID,
	register.EMP_UID as REGISTER_UID,
	register.SALUTATION as REGISTER_SALUTATION,
	register.FNAME as REGISTER_FNAME,
	register.LNAME as REGISTER_LNAME,
	register.TITLE_ENG as REGISTER_TITLE_ENG,
	register.FNAME_ENG as REGISTER_FNAME_ENG,
	register.LNAME_ENG as REGISTER_LNAME_ENG,
	ord.ORDER_ID,
	ord.ORDER_DT,
	ord.VISIT_NO,
	ord.ADMISSION_NO,
	ord.REQUESTNO,
	ord.CLINICAL_INSTRUCTION,
	ords.Q_NO,
	ords.ACCESSION_NO,
	ords.QTY,
	ords.RATE as ORDERDTL_RATE,
	ords.INSTANCE_UID,
	ords.IMAGE_CAPTURED_ON,
	ords.[STATUS],
	ords.WORK_STATION_ID,
	case ords.[STATUS]
        when 'N' then 'New'
        when 'A' then 'New'
        when 'S' then 'Sent'
        when 'C' then 'Complete'
        when 'D' then 'Draft'
        when 'P' then 'Prelim'
        when 'F' then 'Finalized'
    end as StatusText,
	case ords.[PRIORITY]
		when 'R' then 'R'
		else 'S'
	end as [PRIORITY],
	pat_status.STATUS_ID as PATIENT_STATUS_ID,
	pat_status.STATUS_UID as PATIENT_STATUS_UID,
	pat_status.STATUS_TEXT as PATIENT_STATUS_TEXT,
	ins.INSURANCE_TYPE_ID,
	ins.INSURANCE_TYPE_UID,
	ins.INSURANCE_TYPE_DESC,
	ref_unit.UNIT_ID as REF_UNIT_ID,
	ref_unit.UNIT_UID as REF_UNIT_UID,
	ref_unit.UNIT_UID + ' : ' + ref_unit.UNIT_NAME as REF_UNIT_NAME,
	ref_doc.EMP_ID as REF_DOC_ID,
	ref_doc.EMP_UID as REF_DOC_UID,
	ref_doc.SALUTATION as REF_DOC_SALUTATION,
	ref_doc.FNAME as REF_DOC_FNAME,
	ref_doc.LNAME as REF_DOC_LNAME,
	ref_doc.TITLE_ENG as REF_DOC_TITLE_ENG,
	ref_doc.FNAME_ENG as REF_DOC_FNAME_ENG,
	ref_doc.LNAME_ENG as REF_DOC_LNAME_ENG,
	rad.EMP_UID as RAD_ID,
	rad.EMP_UID as RAD_UID,
	rad.SALUTATION as RAD_SALUTATION,
	rad.FNAME as RAD_FNAME,
	rad.LNAME as RAD_LNAME,
	rad.TITLE_ENG as RAD_TITLE_ENG,
	rad.FNAME_ENG as RAD_FNAME_ENG,
	rad.LNAME_ENG as RAD_LNAME_ENG,
	rad.FNAME_ENG
		+ ' '
		+ rad.LNAME_ENG
		+ ', M.D. '
		+ rad_title.JOB_TITLE_TAG as Radiologist,
	exam.EXAM_ID,
	exam.EXAM_UID,
	exam.EXAM_NAME,
	exam.RATE as EXAM_RATE,
	exam.SERVICE_TYPE,
	ISNULL(exam.DEFER_HIS_RECONCILE, 'N') as DEFER_HIS_RECONCILE,
	modality_type.TYPE_NAME_ALIAS,
	operator.EMP_ID as OPERATOR_ID,
	operator.EMP_UID as OPERATOR_UID,
	operator.SALUTATION as OPERATOR_SALUTATION,
	operator.FNAME as OPERATOR_FNAME,
	operator.LNAME as OPERATOR_LNAME,
	operator.TITLE_ENG as OPERATOR_TITLE_ENG,
	operator.FNAME_ENG as OPERATOR_FNAME_ENG,
	operator.LNAME_ENG as OPERATOR_LNAME_ENG,
	case
		when ord.IS_CANCELED = 'Y' then 'CA'
		when ords.IS_DELETED = 'Y' then 'CA'
		else case ords.[STATUS]
            when 'A' then 'NW'
            when 'S' then 'SC'
            when 'C' then 'SC'
            else ''
        end
	end as Hl7OrderControl,
	case
		when ord.IS_CANCELED = 'Y' then 'CA'
		when ords.IS_DELETED = 'Y' then 'CA'
		else case ords.[STATUS]
            when 'S' then 'SC'
            when 'C' then 'SC'
            else ''
        end
    end as Hl7OrderStatus,
	case ords.[STATUS]
        when 'A' then 'S'
        when 'S' then 'Sent'
        when 'C' then 'Complete'
        when 'P' then 'P'
        when 'F' then 'F'
        else ''
    end as Hl7ResultStatus,
	result.RESULT_STATUS,
	result.RESULT_TEXT_HTML,
	result.RESULT_TEXT_PLAIN,
	result.RESULT_TEXT_RTF,
    result.RESULT_TEXT_RTFtoHTML, 
	result.LAST_MODIFIED_ON as RESULT_ON,
	severity.SEVERITY_UID,
	severity.SEVERITY_NAME,
	severity.SEVERITY_LABEL,
	result.LAST_MODIFIED_BY,
    0 AS NOTE_NO,
	result.SEVERITYLOG_ID
from
	RIS_EXAMRESULT result
	inner join RIS_ORDERDTL ords on result.ACCESSION_NO = ords.ACCESSION_NO
								and result.RESULT_STATUS in ('P', 'F')
		inner join HR_EMP rad on ISNULL(result.LAST_MODIFIED_BY, result.CREATED_BY) = rad.EMP_ID
		left join HR_JOBTITLE rad_title on rad.JOBTITLE_ID = rad_title.JOB_TITLE_ID
		inner join HR_EMP operator on ords.LAST_MODIFIED_BY = operator.EMP_ID
		inner join RIS_ORDER ord on ords.ORDER_ID = ord.ORDER_ID
	    inner join HIS_REGISTRATION patient on ord.REG_ID = patient.REG_ID
		inner join HR_EMP register on ord.LAST_MODIFIED_BY = register.EMP_ID
        left join RIS_PATSTATUS pat_status on ord.PAT_STATUS = pat_status.STATUS_ID
		left join RIS_INSURANCETYPE ins on ord.INSURANCE_TYPE_ID = ins.INSURANCE_TYPE_ID
		left join HR_UNIT ref_unit on ord.REF_UNIT = ref_unit.UNIT_ID
		left join HR_EMP ref_doc on ord.REF_DOC = ref_doc.EMP_ID
		inner join RIS_MODALITY modality on ords.MODALITY_ID = modality.MODALITY_ID
		inner join RIS_MODALITYTYPE modality_type on modality.MODALITY_TYPE = modality_type.[TYPE_ID]
		inner join RIS_EXAM exam on result.EXAM_ID = exam.EXAM_ID
		inner join GBL_ENV org on result.ORG_ID = org.ORG_ID
		left join RIS_EXAMRESULTSEVERITY severity on result.SEVERITY_ID = severity.SEVERITY_ID
{0}
        order by result.LAST_MODIFIED_ON desc"; 
        #endregion
        #region query_oru_stat
        private string query_oru_stat = @"
SET NOCOUNT ON

select top 1
	(select top 1 WORK_STATION_UID from RIS_INTEGRATIONCONFIG where WORK_STATION_ID = 0) as SendingApplication,
	'' as ReceivingApplication,
	org.ORG_ID,
	org.ORG_ALIAS,
	patient.REG_ID,
	patient.REG_DT,
	patient.EXT_HN,
	patient.HN,
	patient.HIS_HN,
	patient.TITLE as PATIENT_TITLE,
	patient.FNAME as PATIENT_FNAME,
	patient.LNAME as PATIENT_LNAME,
	patient.TITLE_ENG as PATIENT_TITLE_ENG,
	patient.FNAME_ENG as PATIENT_FNAME_ENG,
	patient.LNAME_ENG as PATIENT_LNAME_ENG,
	patient.SSN as PATIENT_SSN,
	patient.GENDER as PATIENT_GENDER,
	patient.DOB as PATIENT_DOB,
	patient.ADDR1 as PATIENT_ADDR1,
	patient.ADDR2 as PATIENT_ADDR2,
	patient.ADDR3 as PATIENT_ADDR3,
	patient.ADDR4 as PATIENT_ADDR4,
	patient.ADDR5 as PATIENT_ADDR5,
	patient.PHONE1 as PATIENT_PHONE1,
	patient.PHONE2 as PATIENT_PHONE2,
	register.EMP_ID as REGISTER_ID,
	register.EMP_UID as REGISTER_UID,
	register.SALUTATION as REGISTER_SALUTATION,
	register.FNAME as REGISTER_FNAME,
	register.LNAME as REGISTER_LNAME,
	register.TITLE_ENG as REGISTER_TITLE_ENG,
	register.FNAME_ENG as REGISTER_FNAME_ENG,
	register.LNAME_ENG as REGISTER_LNAME_ENG,
	ord.ORDER_ID,
	ord.ORDER_DT,
	ord.VISIT_NO,
	ord.ADMISSION_NO,
	ord.REQUESTNO,
	ord.CLINICAL_INSTRUCTION,
	ords.Q_NO,
	ords.ACCESSION_NO,
	ords.QTY,
	ords.RATE as ORDERDTL_RATE,
	ords.INSTANCE_UID,
	ords.IMAGE_CAPTURED_ON,
	ords.[STATUS],
	ords.WORK_STATION_ID,
	case ords.[STATUS]
        when 'N' then 'New'
        when 'A' then 'New'
        when 'S' then 'Sent'
        when 'C' then 'Complete'
        when 'D' then 'Draft'
        when 'P' then 'Prelim'
        when 'F' then 'Finalized'
    end as StatusText,
	case ords.[PRIORITY]
		when 'R' then 'R'
		else 'S'
	end as [PRIORITY],
	pat_status.STATUS_ID as PATIENT_STATUS_ID,
	pat_status.STATUS_UID as PATIENT_STATUS_UID,
	pat_status.STATUS_TEXT as PATIENT_STATUS_TEXT,
	ins.INSURANCE_TYPE_ID,
	ins.INSURANCE_TYPE_UID,
	ins.INSURANCE_TYPE_DESC,
	ref_unit.UNIT_ID as REF_UNIT_ID,
	ref_unit.UNIT_UID as REF_UNIT_UID,
	ref_unit.UNIT_UID + ' : ' + ref_unit.UNIT_NAME as REF_UNIT_NAME,
	ref_doc.EMP_ID as REF_DOC_ID,
	ref_doc.EMP_UID as REF_DOC_UID,
	ref_doc.SALUTATION as REF_DOC_SALUTATION,
	ref_doc.FNAME as REF_DOC_FNAME,
	ref_doc.LNAME as REF_DOC_LNAME,
	ref_doc.TITLE_ENG as REF_DOC_TITLE_ENG,
	ref_doc.FNAME_ENG as REF_DOC_FNAME_ENG,
	ref_doc.LNAME_ENG as REF_DOC_LNAME_ENG,
	rad.EMP_ID as RAD_ID,
	rad.EMP_UID as RAD_UID,
	rad.SALUTATION as RAD_SALUTATION,
	rad.FNAME as RAD_FNAME,
	rad.LNAME as RAD_LNAME,
	rad.TITLE_ENG as RAD_TITLE_ENG,
	rad.FNAME_ENG as RAD_FNAME_ENG,
	rad.LNAME_ENG as RAD_LNAME_ENG,
	rad.FNAME_ENG
		+ ' '
		+ rad.LNAME_ENG
		+ ', M.D. '
		+ rad_title.JOB_TITLE_TAG as Radiologist,
	exam.EXAM_ID,
	exam.EXAM_UID,
	exam.EXAM_NAME,
	exam.RATE as EXAM_RATE,
	exam.SERVICE_TYPE,
	ISNULL(exam.DEFER_HIS_RECONCILE, 'N') as DEFER_HIS_RECONCILE,
	modality_type.TYPE_NAME_ALIAS,
	operator.EMP_ID as OPERATOR_ID,
	operator.EMP_UID as OPERATOR_UID,
	operator.SALUTATION as OPERATOR_SALUTATION,
	operator.FNAME as OPERATOR_FNAME,
	operator.LNAME as OPERATOR_LNAME,
	operator.TITLE_ENG as OPERATOR_TITLE_ENG,
	operator.FNAME_ENG as OPERATOR_FNAME_ENG,
	operator.LNAME_ENG as OPERATOR_LNAME_ENG,
	case
		when ord.IS_CANCELED = 'Y' then 'CA'
		when ords.IS_DELETED = 'Y' then 'CA'
		else case ords.[STATUS]
            when 'A' then 'NW'
            when 'S' then 'SC'
            when 'C' then 'SC'
            else ''
        end
	end as Hl7OrderControl,
	case
		when ord.IS_CANCELED = 'Y' then 'CA'
		when ords.IS_DELETED = 'Y' then 'CA'
		else case ords.[STATUS]
            when 'S' then 'SC'
            when 'C' then 'SC'
            else ''
        end
    end as Hl7OrderStatus,
	case ords.[STATUS]
        when 'A' then 'S'
        when 'S' then 'Sent'
        when 'C' then 'Complete'
        when 'P' then 'P'
        when 'F' then 'F'
        else ''
    end as Hl7ResultStatus,
	'P' as RESULT_STATUS,
	result.NOTE_TEXT_HTML as RESULT_TEXT_HTML,
	result.NOTE_TEXT as RESULT_TEXT_PLAIN,
	result.NOTE_TEXT_RTF as RESULT_TEXT_RTF,
    result.NOTE_TEXT_RTFtoHTML as RESULT_TEXT_RTFtoHTML, 
	result.LAST_MODIFIED_ON as RESULT_ON,
	NULL as SEVERITY_UID,
	NULL as SEVERITY_NAME,
	NULL as SEVERITY_LABEL,
	result.LAST_MODIFIED_BY,
	result.NOTE_NO,
	reporting.SEVERITYLOG_ID
from
	RIS_EXAMRESULTSTATREPORT result
	inner join RIS_ORDERDTL ords on result.ACCESSION_NO = ords.ACCESSION_NO
    inner join RIS_EXAMRESULT reporting on result.ACCESSION_NO = reporting.ACCESSION_NO
	inner join HR_EMP operator on ords.LAST_MODIFIED_BY = operator.EMP_ID
	inner join RIS_ORDER ord on ords.ORDER_ID = ord.ORDER_ID
	inner join HIS_REGISTRATION patient on ord.REG_ID = patient.REG_ID
	inner join HR_EMP register on ord.LAST_MODIFIED_BY = register.EMP_ID
	inner join RIS_MODALITY modality on ords.MODALITY_ID = modality.MODALITY_ID
	inner join RIS_MODALITYTYPE modality_type on modality.MODALITY_TYPE = modality_type.[TYPE_ID]
	inner join HR_EMP rad on result.LAST_MODIFIED_BY = rad.EMP_ID
	inner join HR_JOBTITLE rad_title on rad.JOBTITLE_ID = rad_title.JOB_TITLE_ID
	inner join RIS_EXAM exam on result.EXAM_ID = exam.EXAM_ID
	inner join GBL_ENV org on result.ORG_ID = org.ORG_ID
	left join RIS_PATSTATUS pat_status on ord.PAT_STATUS = pat_status.STATUS_ID
	left join RIS_INSURANCETYPE ins on ord.INSURANCE_TYPE_ID = ins.INSURANCE_TYPE_ID
	left join HR_UNIT ref_unit on ord.REF_UNIT = ref_unit.UNIT_ID
	left join HR_EMP ref_doc on ord.REF_DOC = ref_doc.EMP_ID
{0}
    order by result.created_on desc";
        #endregion
        private string query_oru_addendum = @"
SET NOCOUNT ON

select
    addendum.ACCESSION_NO,
	rad.FNAME_ENG
		+ ' '
		+ rad.LNAME_ENG
		+ ', M.D. '
		+ rad_title.JOB_TITLE_DESC as Radiologist,
    addendum.NOTE_TEXT as RESULT_TEXT,
    addendum.NOTE_ON
from
    RIS_EXAMRESULTNOTE addendum
    inner join HR_EMP rad
            on addendum.NOTE_BY = rad.EMP_ID
		left join HR_JOBTITLE rad_title
				on rad.JOBTITLE_ID = rad_title.JOB_TITLE_ID
{0}";
        #endregion
        public DataSet selectDataHL7ORUByAccessionNo(string accessionNo, int orgId)
        {
            if (string.IsNullOrEmpty(accessionNo) || orgId < 1) return null;

            string[] queries = new string[2];
            queries[0] = string.Format(query_oru, "where result.ACCESSION_NO = @ACCESSION_NO");
            queries[1] = string.Format(query_oru_addendum, "where addendum.ACCESSION_NO = @ACCESSION_NO");

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo),
                DoParameter("@ORG_ID", orgId)};

            DataSet ds = SelectData(queries);
            ds.Tables[0].TableName = "Result";
            ds.Tables[1].TableName = "Addendum";
            ds.AcceptChanges();

            return ds.Copy();
        }
        public DataSet selectDataHL7ORUStatByAccessionNo(string accessionNo, int orgId)
        {
            if (string.IsNullOrEmpty(accessionNo) || orgId < 1) return null;

            string[] queries = new string[2];
            queries[0] = string.Format(query_oru_stat, "where result.ACCESSION_NO = @ACCESSION_NO");
            queries[1] = string.Format(query_oru_addendum, "where addendum.ACCESSION_NO = @ACCESSION_NO");

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo),
                DoParameter("@ORG_ID", orgId)};

            DataSet ds = SelectData(queries);
            ds.Tables[0].TableName = "Result";
            ds.Tables[1].TableName = "Addendum";
            ds.AcceptChanges();

            return ds.Copy();
        }
        public DataSet selectDataHL7ORUByOrderId(int orderId)
        {
            if (orderId < 1) return null;

            string[] queries = new string[2];
            queries[0] = string.Format(query_oru, "where result.ORDER_ID = @ORDER_ID");
            queries[1] = string.Format(query_oru_addendum, "where addendum.ORDER_ID = @ORDER_ID");

            Parameters = new DbParameter[] { DoParameter("@ORDER_ID", orderId) };

            DataSet ds = SelectData(queries);
            ds.Tables[0].TableName = "Result";
            ds.Tables[1].TableName = "Addendum";
            ds.AcceptChanges();

            return ds.Copy();
        }
        public DataTable selectDataSeverityLog(string accessionNo)
        {
            string query = @"
            select  
            RIS_EXAMRESULTSEVERITY_LOG.SEVERITYLOG_ID,
            RIS_EXAMRESULTSEVERITY_LOG.ACCESSION_NO,
            RIS_EXAMRESULTSEVERITY_LOG.VERBAL_DATETIME,
            RIS_EXAMRESULTSEVERITY_LOG.VERBAL_TIME,
            RIS_EXAMRESULTSEVERITY_LOG.VERBAL_WITH,
            ISNULL(HR_EMP.SALUTATION,'')+HR_EMP.FNAME+' '+HR_EMP.LNAME as [VERBAL_NAME]
            from RIS_EXAMRESULTSEVERITY_LOG
            inner join HR_EMP on RIS_EXAMRESULTSEVERITY_LOG.VERBAL_WITH = HR_EMP.EMP_ID
            where ACCESSION_NO=@ACCESSION_NO";

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo)};

            return SelectData(query);
        }
        public DataTable selectDataSeverity(string accessionNo)
        {
            string query = @"
            select  
            RIS_EXAMRESULTSEVERITY.SEVERITY_LABEL
            from
            ris_examresult
            inner join  RIS_EXAMRESULTSEVERITY on RIS_EXAMRESULT.SEVERITY_ID = RIS_EXAMRESULTSEVERITY.SEVERITY_ID
            where ACCESSION_NO=@ACCESSION_NO";

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo)};

            return SelectData(query);
        }
        public DataTable selectDataRadiologistGroup(string accessionNo)
        {
            string query = @"
            select RIS_EXAMRESULTRADS.ACCESSION_NO,
            HR_EMP.EMP_ID,
            ISNULL(HR_EMP.FNAME_ENG,HR_EMP.FNAME)+ ' ' + ISNULL(HR_EMP.LNAME_ENG,HR_EMP.LNAME) +', M.D.(' + HR_EMP.EMP_UID + ') '+ISNULL(HR_JOBTITLE.JOB_TITLE_TAG,'') as RAD_FULL_NAME  
            from RIS_EXAMRESULTRADS
            inner join HR_EMP on RIS_EXAMRESULTRADS.RAD_ID = HR_EMP.EMP_ID
            inner join HR_JOBTITLE on HR_EMP.JOBTITLE_ID = HR_JOBTITLE.JOB_TITLE_ID
            where ACCESSION_NO = @ACCESSION_NO
            and ISNULL(IS_SHOW_PACS,N'Y') = N'Y'";

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo)};

            return SelectData(query);
        }
        public DataTable selectDataResultDatetime(string accessionNo)
        {
            string query = @"
            select
			ISNULL(RELEASED_ON,GETDATE()) as RELEASED_ON
			,ISNULL(FINALIZED_ON,GETDATE()) as FINALIZED_ON
			,GETDATE() as [CURRENT_DT]
			,ISNULL(
				(select top 1 dl.ASSIGNED_TIMESTAMP from RIS_ORDERDTL dl where dl.ACCESSION_NO = RIS_EXAMRESULT.ACCESSION_NO)
			,GETDATE()) as [ASSIGNED_TIMESTAMP]
		    from
			    RIS_EXAMRESULT
		    where
			    ACCESSION_NO = @ACCESSION_NO";

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo)};

            return SelectData(query);
        }
        public DataTable selectDataResultStat(string accessionNo)
        {
            string query = @"
            select 
			NOTE_TEXT		as TXT,
			NOTE_TEXT_RTF	as RTF,
			dbo.fnGetEmpThaiName(NOTE_BY) RadioName,
			dbo.fnGetEmpEngName(NOTE_BY) RadioNameEng,
			NOTE_ON
		    from		
				    RIS_EXAMRESULTSTATREPORT
		    where		
				    ACCESSION_NO=@ACCESSION_NO 
		    order by	
				    note_no desc";

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo)};

            return SelectData(query);
        }
        public DataTable selectDataSweepHL7ORM()
        {
            string query = @"
            select top 2 ACCESSION_NO,STATUS from RIS_ORDERDTL
inner join RIS_EXAM on RIS_ORDERDTL.EXAM_ID = RIS_EXAM.EXAM_ID
where ISNULL(HL7_SENT,'N') = 'N'
and RIS_EXAM.SERVICE_TYPE = 1
and DATEDIFF(DD,RIS_ORDERDTL.LAST_MODIFIED_ON,GETDATE()) < 60
and ISNULL(STATUS,'N') in ('A','N','R')
order by RIS_ORDERDTL.LAST_MODIFIED_ON desc";
            return SelectData(query);
        }
        public DataTable selectDataSweepHL7ORU()
        {
            string query = @"
            select top 2 ACCESSION_NO From ris_examresult
where ISNULL(HL7_SEND,'N') = 'N'
and DATEDIFF(DD,ris_examresult.LAST_MODIFIED_ON,GETDATE()) < 60
and ISNULL(RESULT_STATUS,'') in ('P','F')
order by ris_examresult.LAST_MODIFIED_ON desc";
            return SelectData(query);
        }
        public DataTable selectDataScheduleNotUpdateStatus()
        {
            string query = @"
            select top 2 ORDER_ID,RIS_ORDER.SCHEDULE_ID,RIS_SCHEDULE.SCHEDULE_STATUS,RIS_ORDER.IS_CANCELED from RIS_ORDER
inner join RIS_SCHEDULE on RIS_ORDER.SCHEDULE_ID = RIS_SCHEDULE.SCHEDULE_ID
where RIS_SCHEDULE.SCHEDULE_STATUS not in ('O','C')
";
            return SelectData(query);
        }
        public void updateDataScheduleNotUpdateStatus(string schStatus , int scheID) {
            string query = @"
                           update RIS_SCHEDULE
set SCHEDULE_STATUS = @SCHEDULE_STATUS
where SCHEDULE_ID = @SCHEDULE_ID
";
            Parameters = new DbParameter[] {
                DoParameter("@SCHEDULE_STATUS", schStatus),
                DoParameter("@SCHEDULE_ID", scheID)};
            
            Execute(query);
        }
        public DataTable selectDataCommentFixScheduleID()
        {
            string query = @"
select top 1 RIS_ORDER.SCHEDULE_ID,RIS_ORDER.ORDER_ID From RIS_COMMENTSYSTEMDTL
inner join RIS_ORDER on RIS_COMMENTSYSTEMDTL.ORDER_ID = RIS_ORDER.ORDER_ID
where ISNULL(RIS_COMMENTSYSTEMDTL.SCHEDULE_ID,0) <> RIS_ORDER.SCHEDULE_ID
";
            return SelectData(query);
        }
        public void updateDataCommentFixScheduleID(int ordId, int scheID)
        {
            string query = @"
update RIS_COMMENTSYSTEMDTL
set SCHEDULE_ID = @SCHEDULE_ID
where ORDER_ID = @ORDER_ID

";
            Parameters = new DbParameter[] {
                DoParameter("@SCHEDULE_ID", scheID),
                DoParameter("@ORDER_ID", ordId)};

            Execute(query);
        }
        public DataTable selectDataCommentFixOrderIdAccession()
        {
            string query = @"
select  RIS_COMMENTSYSTEM.SCHEDULE_ID,RIS_COMMENTSYSTEM.EXAM_ID
from RIS_COMMENTSYSTEM
inner join RIS_ORDER on RIS_COMMENTSYSTEM.SCHEDULE_ID = RIS_ORDER.SCHEDULE_ID
where isnull(RIS_COMMENTSYSTEM.ORDER_ID,0) <> RIS_ORDER.ORDER_ID
and isnull(RIS_ORDER.IS_CANCELED,'N') = 'N'
";
            return SelectData(query);
        }
        public void updateDataCommentFixOrderIdAccession(int examId, int scheID)
        {
            string query = @"
	declare @ACC nvarchar(30),@ORD_ID int
	select top 1 @ACC = ACCESSION_NO, @ORD_ID = RIS_ORDER.ORDER_ID from RIS_ORDER
	inner join RIS_ORDERDTL on RIS_ORDER.ORDER_ID = RIS_ORDERDTL.ORDER_ID
	where SCHEDULE_ID = @SCHEDULE_ID
	and EXAM_ID = @EXAM_ID

	if(@@ROWCOUNT > 0)
	begin
	    --select @SCHEDULE_ID,@EXAM_ID
	    --select @ACC, @ORD_ID
	    update RIS_COMMENTSYSTEM
	    set ACCESSION_NO = @ACC
	    ,ORDER_ID = @ORD_ID
	    where SCHEDULE_ID = @SCHEDULE_ID
	    and EXAM_ID = @EXAM_ID
	    update RIS_COMMENTSYSTEMDTL
	    set ACCESSION_NO = @ACC
	    ,ORDER_ID = @ORD_ID
	    where SCHEDULE_ID = @SCHEDULE_ID
	    and EXAM_ID = @EXAM_ID
	end


";
            Parameters = new DbParameter[] {
                DoParameter("@SCHEDULE_ID", scheID),
                DoParameter("@EXAM_ID", examId)};

            Execute(query);
        }

        public int addHisRegistration(HIS_REGISTRATION reg)
        {
            if (string.IsNullOrEmpty(reg.HN) || reg.ORG_ID < 1) return 0;

            string query = @"
insert into	HIS_REGISTRATION
(
    REG_DT,
	EXT_HN,
	HN,
	HIS_HN,
    TITLE,
    FNAME,
    LNAME,
    TITLE_ENG,
    FNAME_ENG,
    LNAME_ENG,
    SSN,
    DOB,
    GENDER,
    ADDR1,
    ADDR2,
    ADDR3,
    ADDR4,
    ADDR5,
    PHONE1,
    PHONE2,
    IS_JOHNDOE,
    IS_DELETED,
    IS_UPDATED,
    ORG_ID,
    CREATED_BY,
    CREATED_ON,
    LAST_MODIFIED_BY,
    LAST_MODIFIED_ON
)
values
(
	GETDATE(),
	@EXT_HN,
	@HN,
	@HIS_HN,
	@TITLE,
	@FNAME,
	@LNAME,
	@TITLE_ENG,
	@FNAME_ENG,
	@LNAME_ENG,
	@SSN,
    @DOB,
	@GENDER,
	@ADDR1,
	@ADDR2,
	@ADDR3,
	@ADDR4,
	@ADDR5,
	@PHONE1,
	@PHONE2,
	'N',
    'N',
    'N',
	@ORG_ID,
	@LAST_MODIFIED_BY,
	GETDATE(),
	@LAST_MODIFIED_BY,
	GETDATE()
)

set @REG_ID = SCOPE_IDENTITY()";

            Parameters = new DbParameter[] {
                DoParameter("@REG_ID", 0, ParameterDirection.Output),
                DoParameter("@EXT_HN", reg.EXT_HN),
                DoParameter("@HIS_HN", reg.HIS_HN),
                DoParameter("@HN", reg.HN),
                DoParameter("@TITLE", reg.TITLE),
                DoParameter("@FNAME", reg.FNAME),
                DoParameter("@LNAME", reg.LNAME),
                DoParameter("@TITLE_ENG", reg.TITLE_ENG),
                DoParameter("@FNAME_ENG", reg.FNAME_ENG),
                DoParameter("@LNAME_ENG", reg.LNAME_ENG),
                DoParameter("@SSN", reg.SSN),
                DoParameter("@DOB", reg.DOB == DateTime.MinValue ? (object)null : reg.DOB),
                DoParameter("@GENDER", reg.GENDER == char.MinValue ? (object)null : reg.GENDER),
                DoParameter("@ADDR1", reg.ADDR1),
                DoParameter("@ADDR2", reg.ADDR2),
                DoParameter("@ADDR3", reg.ADDR3),
                DoParameter("@ADDR4", reg.ADDR4),
                DoParameter("@ADDR5", reg.ADDR5),
                DoParameter("@PHONE1", reg.PHONE1),
                DoParameter("@PHONE2", reg.PHONE2),
                DoParameter("@ORG_ID", reg.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", reg.LAST_MODIFIED_BY)};

            Execute(query);

            return Utilities.ToInt(Parameters[0].Value.ToString());
        }
        public int addHrEmp(HR_EMP emp)
        {
            if (string.IsNullOrEmpty(emp.EMP_UID) || emp.ORG_ID < 1) return 0;

            string query = @"
insert HR_EMP
(
    EMP_UID,
    SALUTATION,
    FNAME,
    LNAME,
    TITLE_ENG,
    FNAME_ENG,
    LNAME_ENG,
    JOB_TYPE,
    EMP_REPORT_FOOTER1,
    EMP_REPORT_FOOTER2,
    IS_ACTIVE,
    ORG_ID,
    CREATED_BY,
    CREATED_ON,
    LAST_MODIFIED_BY,
    LAST_MODIFIED_ON
)
values
(
    @EMP_UID,
    @SALUTATION,
    @FNAME,
    @LNAME,
    @TITLE_ENG,
    @FNAME_ENG,
    @LNAME_ENG,
    @JOB_TYPE,
    @FNAME+' '+@LNAME,
    @FNAME_ENG+' '+@LNAME_ENG,
    'Y',
    @ORG_ID,
    @LAST_MODIFIED_BY,
    GETDATE(),
    @LAST_MODIFIED_BY,
    GETDATE()
)

set @EMP_ID = SCOPE_IDENTITY()";

            Parameters = new DbParameter[] {
                DoParameter("@EMP_ID", 0, ParameterDirection.Output),
                DoParameter("@EMP_UID", emp.EMP_UID),
                DoParameter("@SALUTATION", string.IsNullOrEmpty(emp.SALUTATION) ? string.Empty : emp.SALUTATION.Trim()),
                DoParameter("@FNAME", string.IsNullOrEmpty(emp.FNAME) ? string.Empty : emp.FNAME.Trim()),
                DoParameter("@LNAME", string.IsNullOrEmpty(emp.LNAME) ? string.Empty : emp.LNAME.Trim()),
                DoParameter("@TITLE_ENG", string.IsNullOrEmpty(emp.TITLE_ENG) ? string.Empty : emp.TITLE_ENG.Trim()),
                DoParameter("@FNAME_ENG", string.IsNullOrEmpty(emp.FNAME_ENG) ? string.Empty : emp.FNAME_ENG.Trim()),
                DoParameter("@LNAME_ENG", string.IsNullOrEmpty(emp.LNAME_ENG) ? string.Empty : emp.LNAME_ENG.Trim()),
                DoParameter("@JOB_TYPE", emp.JOB_TYPE),
                DoParameter("@ORG_ID", emp.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", emp.LAST_MODIFIED_BY)};

            Execute(query);

            return Utilities.ToInt(Parameters[0].Value.ToString());
        }
        public int addHrUnit(HR_UNIT unit)
        {
            if (string.IsNullOrEmpty(unit.UNIT_UID) || unit.ORG_ID < 1) return 0;

            string query = @"
insert into HR_UNIT
(
	UNIT_UID,
	UNIT_NAME,
	UNIT_TYPE,
	IS_EXTERNAL,
	ORG_ID,
	CREATED_BY,
	CREATED_ON,
	LAST_MODIFIED_BY,
	LAST_MODIFIED_ON
)
values
(
	@UNIT_UID,
	@UNIT_NAME,
	'N',
	'Y',
    @ORG_ID,
    @LAST_MODIFIED_BY,
    GETDATE(),
    @LAST_MODIFIED_BY,
    GETDATE()
)

set @UNIT_ID = SCOPE_IDENTITY()";

            Parameters = new DbParameter[] {
                DoParameter("@UNIT_ID", 0, ParameterDirection.Output),
                DoParameter("@UNIT_UID", unit.UNIT_UID),
                DoParameter("@UNIT_NAME", unit.UNIT_NAME),
                DoParameter("@ORG_ID", unit.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", unit.LAST_MODIFIED_BY)};

            Execute(query);

            return Utilities.ToInt(Parameters[0].Value.ToString());
        }
        public int addRisExam(RIS_EXAM exam)
        {
            if (string.IsNullOrEmpty(exam.EXAM_UID) || exam.ORG_ID < 1) return 0;

            string query = @"
insert into RIS_EXAM
(
	EXAM_UID,
	EXAM_NAME,
	EXAM_TYPE,
	BP_ID,
	BPVIEW_ID,
	RATE,
	SERVICE_TYPE,
    QA_REQUIRED,
	DEFER_HIS_RECONCILE,
	UNIT_ID,
	IS_ACTIVE,
	ORG_ID,
	CREATED_BY,
	CREATED_ON,
	LAST_MODIFIED_BY,
	LAST_MODIFIED_ON
)
values
(
	@EXAM_UID,
	@EXAM_NAME,
	@EXAM_TYPE,
	@BP_ID,
	@BPVIEW_ID,
	@RATE,
	@SERVICE_TYPE,
    'Y',
	'N',
	@UNIT_ID,
	'Y',
	@ORG_ID,
    @LAST_MODIFIED_BY,
    GETDATE(),
    @LAST_MODIFIED_BY,
    GETDATE()
)

set @EXAM_ID = SCOPE_IDENTITY()";

            Parameters = new DbParameter[] {
                DoParameter("@EXAM_ID", 0, ParameterDirection.Output),
                DoParameter("@EXAM_UID", exam.EXAM_UID),
                DoParameter("@EXAM_NAME", exam.EXAM_NAME),
                DoParameter("@EXAM_TYPE", exam.EXAM_TYPE),
                DoParameter("@BP_ID", exam.BP_ID),
                DoParameter("@BPVIEW_ID", exam.BPVIEW_ID),
                DoParameter("@RATE", exam.RATE),
                DoParameter("@SERVICE_TYPE", exam.SERVICE_TYPE),
                DoParameter("@UNIT_ID", exam.UNIT_ID),
                DoParameter("@ORG_ID", exam.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", exam.LAST_MODIFIED_BY)};

            Execute(query);

            return Utilities.ToInt(Parameters[0].Value.ToString());
        }
        public int addRisHL7IELog(RIS_HL7IELOG log)
        {
            string query = @"
insert into RIS_HL7IELOG
(
    SENDER_ID,
    RECEIVER_ID,
    MESSAGE_TYPE,
    EVENT_TYPE,
    HN,
    ACCESSION_NO,
    COMPARE_VALUE,
    [STATUS],
	IS_DELETED,
    HL7_TEXT,
    ACKNOWLEDGMENT_CODE,
    TEXT_MESSAGE,
    ORG_ID,
    LAST_MODIFIED_BY,
    LAST_MODIFIED_ON,
    CREATED_BY,
    CREATED_ON                      
)
values
(
    @SENDER_ID,
    @RECEIVER_ID,
    @MESSAGE_TYPE,
	@EVENT_TYPE,
    @HN,
    @ACCESSION_NO,
    @COMPARE_VALUE,
    @STATUS,
	@IS_DELETED,
    @HL7_TEXT,
    @ACKNOWLEDGMENT_CODE,
    @TEXT_MESSAGE,
    @ORG_ID,
    @LAST_MODIFIED_BY,
    GETDATE(),
    @LAST_MODIFIED_BY,
    GETDATE()
)

set @LOG_ID = SCOPE_IDENTITY()";

            Parameters = new DbParameter[] {
                DoParameter("@LOG_ID", 0, ParameterDirection.Output),
                DoParameter("@SENDER_ID", log.SENDER_ID),
                DoParameter("@RECEIVER_ID", log.RECEIVER_ID),
                DoParameter("@MESSAGE_TYPE", log.MESSAGE_TYPE),
                DoParameter("@EVENT_TYPE", log.EVENT_TYPE),
                DoParameter("@HN", log.HN),
                DoParameter("@ACCESSION_NO", log.ACCESSION_NO),
                DoParameter("@COMPARE_VALUE", log.COMPARE_VALUE),
				DoParameter("@STATUS", log.STATUS == char.MinValue ? (object)null : log.STATUS),
				DoParameter("@IS_DELETED", log.IS_DELETED),
                DoParameter("@HL7_TEXT", log.HL7_TEXT),
                DoParameter("@ACKNOWLEDGMENT_CODE", log.ACKNOWLEDGMENT_CODE),
                DoParameter("@TEXT_MESSAGE", log.TEXT_MESSAGE),
                DoParameter("@ORG_ID", log.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", log.LAST_MODIFIED_BY)};

            Execute(query);

            return Utilities.ToInt(Parameters[0].Value.ToString());
        }
        public int addRisModalityAETitle(RIS_MODALITYAETITLE modalityAETitle)
        {
            if (string.IsNullOrEmpty(modalityAETitle.AE_TITLE_NAME) || modalityAETitle.ORG_ID < 1) return 0;

            string query = @"
insert into RIS_MODALITYAETITLE
(
	AE_TITLE_NAME,
	ORG_ID,
	CREATED_BY,
	CREATED_ON,
	LAST_MODIFIED_BY,
	LAST_MODIFIED_ON
)
values
(
	@AE_TITLE_NAME,
	@ORG_ID,
	@LAST_MODIFIED_BY,
	GETDATE(),
	@LAST_MODIFIED_BY,
	GETDATE()
)

set @AE_TITLE_ID = SCOPE_IDENTITY()";

            Parameters = new DbParameter[] {
                DoParameter("@AE_TITLE_ID", modalityAETitle.AE_TITLE_ID, ParameterDirection.Output),
                DoParameter("@AE_TITLE_NAME", modalityAETitle.AE_TITLE_NAME),
                DoParameter("@ORG_ID", modalityAETitle.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", modalityAETitle.LAST_MODIFIED_BY)};

            return Execute(query) ? Utilities.ToInt(Parameters[0].Value.ToString()) : 0;
        }
        public bool addRisModalityExam(int modalityId, int examId, int orgId, int lastModifiedBy)
        {
            if (modalityId < 1 || examId < 1 || orgId < 1) return false;

            string query = @"
insert into RIS_MODALITYEXAM
(
    MODALITY_ID,
    EXAM_ID,
    IS_ACTIVE,
    IS_DEFAULT_MODALITY,
    LAST_MODIFIED_BY,
    LAST_MODIFIED_ON,
    CREATED_BY,
    CREATED_ON
)
values
(
    @MODALITY_ID,
    @EXAM_ID,
    'Y',
    'N',
    @LAST_MODIFIED_BY,
    GETDATE(),
    @LAST_MODIFIED_BY,
    GETDATE()
)";

            Parameters = new DbParameter[] {
                DoParameter("@EXAM_ID", examId),
                DoParameter("@MODALITY_ID", modalityId),
                DoParameter("@ORG_ID", orgId),
                DoParameter("@LAST_MODIFIED_BY", lastModifiedBy)};

            return Execute(query);
        }
        public bool addRisModalityExamByModalityTypeAlias(string modalityTypeAlias, int examId, int orgId, int lastModifiedBy)
        {
            if (examId < 1 || orgId < 1) return false;

            string query = @"
insert into RIS_MODALITYEXAM
(
    MODALITY_ID,
    EXAM_ID,
    IS_ACTIVE,
    IS_DEFAULT_MODALITY,
    LAST_MODIFIED_BY,
    LAST_MODIFIED_ON,
    CREATED_BY,
    CREATED_ON
)
select
    modality.MODALITY_ID,
    @EXAM_ID,
    'Y',
    'N',
    @LAST_MODIFIED_BY,
    GETDATE(),
    @LAST_MODIFIED_BY,
    GETDATE()
from
    RIS_MODALITY modality
    inner join RIS_MODALITYTYPE modality_type
            on modality.MODALITY_TYPE = modality_type.[TYPE_ID]
            and ISNULL(modality.IS_DEFAULT, 'N') = 'Y'
            and modality_type.TYPE_NAME_ALIAS = @TYPE_NAME_ALIAS";

            Parameters = new DbParameter[] {
                DoParameter("@EXAM_ID", examId),
                DoParameter("@TYPE_NAME_ALIAS", modalityTypeAlias),
                DoParameter("@ORG_ID", orgId),
                DoParameter("@LAST_MODIFIED_BY", lastModifiedBy)};

            return Execute(query);
        }

        public void updateDataSentHL7ORM(string accessionNo, int orgId, string hl7Text, string hl7Sent)
        {
            string query = @"
update
    RIS_ORDERDTL
set
    HL7_TEXT = @HL7_TEXT,
    HL7_SENT = @HL7_SENT
where
    ACCESSION_NO = @ACCESSION_NO
	";

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo),
                DoParameter("@ORG_ID", orgId),
                DoParameter("@HL7_TEXT", hl7Text),
                DoParameter("@HL7_SENT", hl7Sent)};

            Execute(query);
        }
        public void updateDataSentHL7ORU(string accessionNo, int orgId, string hl7Text, string hl7Send)
        {
            string query = @"
update
    RIS_EXAMRESULT
set
    HL7_TEXT = @HL7_TEXT,
    HL7_SEND = @HL7_SEND
where
    ACCESSION_NO = @ACCESSION_NO
	";

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo),
                DoParameter("@ORG_ID", orgId),
                DoParameter("@HL7_TEXT", hl7Text),
                DoParameter("@HL7_SEND", hl7Send)};

            Execute(query);
        }
        public void updateHTMLExamresult(string accessionNo, int orgId, string html)
        {
            string query = @"
                            update RIS_EXAMRESULT
                            set RESULT_TEXT_HTML = @RESULT_TEXT_HTML
                            where ACCESSION_NO = @ACCESSION_NO";
            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", accessionNo),
                DoParameter("@RESULT_TEXT_HTML", html)};

            Execute(query);
        }
        public void updateHTMLExamresultstat(int note_no, int orgId, string html)
        {
            string query = @"
                        update RIS_EXAMRESULTSTATREPORT
                        set NOTE_TEXT_HTML = @NOTE_TEXT_HTML
                        where NOTE_NO = @NOTE_NO";

            Parameters = new DbParameter[] {
                DoParameter("@NOTE_NO", note_no),
                DoParameter("@NOTE_TEXT_HTML", html)};

            Execute(query);
        }

        public int addRisOrder(RIS_ORDER order, DbTransaction transaction)
        {
            if (order.ORG_ID < 1) return 0;

            string query = @"
insert into	RIS_ORDER
(
    ORDER_DT,
    ORDER_START_TIME,
    REG_ID,
    HN,
    VISIT_NO,
    REQUESTNO,
    ADMISSION_NO,
    PAT_STATUS,
    INSURANCE_TYPE_ID,
    REF_UNIT,
    REF_DOC,
    CLINICAL_INSTRUCTION,
    IS_REQONLINE,
    IS_PRINTED,
    IS_CANCELED,
    REASON,
    ORG_ID,
    CREATED_BY,
    CREATED_ON,
    LAST_MODIFIED_BY,
    LAST_MODIFIED_ON
)
values
(
    case when @ORDER_DT is null then GETDATE() else @ORDER_DT end,
    GETDATE(),
    @REG_ID,
    @HN,
    @VISIT_NO,
    @REQUESTNO,
    @ADMISSION_NO,
    @PAT_STATUS,
    @INSURANCE_TYPE_ID,
    @REF_UNIT,
    @REF_DOC,
    @CLINICAL_INSTRUCTION,
    'N',
    'N',
    'N',
    @REASON,
    @ORG_ID,
    @LAST_MODIFIED_BY,
    GETDATE(),
    @LAST_MODIFIED_BY,
    GETDATE()
)

set @ORDER_ID = SCOPE_IDENTITY()";

            Parameters = new DbParameter[] {
                DoParameter("@ORDER_ID", 0, ParameterDirection.Output),
                DoParameter("@REG_ID", order.REG_ID),
                DoParameter("@HN", order.HN),
                DoParameter("@ORDER_DT", order.ORDER_DT == DateTime.MinValue ? (object)null : order.ORDER_DT),
                DoParameter("@VISIT_NO", order.VISIT_NO),
                DoParameter("@REQUESTNO", order.REQUESTNO),
                DoParameter("@ADMISSION_NO", order.ADMISSION_NO),
                DoParameter("@PAT_STATUS", order.PAT_STATUS == 0 ? (object)null : order.PAT_STATUS),
                DoParameter("@INSURANCE_TYPE_ID", order.INSURANCE_TYPE_ID == 0 ? (object)null : order.INSURANCE_TYPE_ID),
                DoParameter("@REF_UNIT", order.REF_UNIT == 0 ? (object)null : order.REF_UNIT),
                DoParameter("@REF_DOC", order.REF_DOC == 0 ? (object)null : order.REF_DOC),
                DoParameter("@CLINICAL_INSTRUCTION", order.CLINICAL_INSTRUCTION),
                DoParameter("@REASON", order.REASON),
                DoParameter("@ORG_ID", order.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", order.LAST_MODIFIED_BY)};

            Execute(query, transaction);

            return Utilities.ToInt(Parameters[0].Value.ToString());
        }
        public void addRisOrderDtl(RIS_ORDERDTL orderDetail, DbTransaction transaction)
        {
            string query = @"
insert into RIS_ORDERDTL
(
	ORDER_ID,
	EXAM_ID,
	SERVICE_TYPE,
    CLINIC_TYPE,
	EXAM_DT,
	EST_START_TIME,
	Q_NO,
	ACCESSION_NO,
	MODALITY_ID,
    INSTANCE_UID,
	AE_TITLE_ID,
	IMAGE_CAPTURED_BY,
    IMAGE_CAPTURED_ON,
    IMAGECOUNT,
    QTY,
	RATE,
	[PRIORITY],
	[STATUS],
	ASSIGNED_TO,
	IS_DELETED,
	HIS_SYNC,
	WORK_STATION_ID,
	ORG_ID,
	CREATED_BY,
	CREATED_ON,
	LAST_MODIFIED_BY,
	LAST_MODIFIED_ON
)
values
(
	@ORDER_ID,
	@EXAM_ID,
	case when @SERVICE_TYPE is null then (select top 1 SERVICE_TYPE from RIS_EXAM where EXAM_ID = @EXAM_ID) else @SERVICE_TYPE end,
    case when @CLINIC_TYPE is null then (select top 1 CLINIC_TYPE_ID from RIS_CLINICTYPE order by IS_DEFAULT desc) else @CLINIC_TYPE end,
    case when @EXAM_DT is null then GETDATE() else @EXAM_DT end,
	GETDATE(),
	@Q_NO,
	@ACCESSION_NO,
	@MODALITY_ID,
    @INSTANCE_UID,
	@AE_TITLE_ID,
	@IMAGE_CAPTURED_BY,
    @IMAGE_CAPTURED_ON,
    @IMAGECOUNT,
    @QTY,
	@RATE,
	@PRIORITY,
	@STATUS,
	@ASSIGNED_TO,
	@IS_DELETED,
	@HIS_SYNC,
	@WORK_STATION_ID,
	@ORG_ID,
	@LAST_MODIFIED_BY,
	GETDATE(),
	@LAST_MODIFIED_BY,
	GETDATE()
)";

            Parameters = new DbParameter[] {
                DoParameter("@ORDER_ID", orderDetail.ORDER_ID),
                DoParameter("@EXAM_ID", orderDetail.EXAM_ID),
                DoParameter("@SERVICE_TYPE", orderDetail.SERVICE_TYPE == 0 ? (object)null : orderDetail.SERVICE_TYPE),
                DoParameter("@CLINIC_TYPE", orderDetail.CLINIC_TYPE == 0 ? (object)null : orderDetail.CLINIC_TYPE),
                DoParameter("@EXAM_DT", orderDetail.EXAM_DT == DateTime.MinValue ? (object)null : orderDetail.EXAM_DT),
                DoParameter("@Q_NO", orderDetail.Q_NO),
                DoParameter("@ACCESSION_NO", orderDetail.ACCESSION_NO),
                DoParameter("@MODALITY_ID", orderDetail.MODALITY_ID == 0 ? (object)null : orderDetail.MODALITY_ID),
                DoParameter("@INSTANCE_UID", orderDetail.INSTANCE_UID),
                DoParameter("@AE_TITLE_ID", orderDetail.AE_TITLE_ID == 0 ? (object)null : orderDetail.AE_TITLE_ID),
				DoParameter("@IMAGE_CAPTURED_BY", orderDetail.IMAGE_CAPTURED_BY == 0 ? (object)null : orderDetail.IMAGE_CAPTURED_BY),
                DoParameter("@IMAGE_CAPTURED_ON", orderDetail.IMAGE_CAPTURED_ON == DateTime.MinValue ? (object)null : orderDetail.IMAGE_CAPTURED_ON),
                DoParameter("@IMAGECOUNT", orderDetail.IMAGECOUNT),
                DoParameter("@QTY", orderDetail.QTY),
                DoParameter("@RATE", orderDetail.RATE < 0 ? 0 : orderDetail.RATE),
                DoParameter("@PRIORITY", orderDetail.PRIORITY),
                DoParameter("@STATUS", orderDetail.STATUS),
				DoParameter("@ASSIGNED_TO", orderDetail.ASSIGNED_TO == 0 ? (object)null : orderDetail.ASSIGNED_TO),
				DoParameter("@HIS_SYNC", orderDetail.HIS_SYNC),
				DoParameter("@WORK_STATION_ID", orderDetail.WORK_STATION_ID == 0 ? (object)null : orderDetail.WORK_STATION_ID),
                DoParameter("@IS_DELETED", orderDetail.IS_DELETED),
                DoParameter("@ORG_ID", orderDetail.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", orderDetail.LAST_MODIFIED_BY)
            };

            Execute(query, transaction);
        }

        public bool updateHisRegistration(HIS_REGISTRATION reg)
        {
            if (reg.REG_ID < 1) return false;

            string query = @"
update
	HIS_REGISTRATION
set
	EXT_HN				= case when @EXT_HN is null then EXT_HN else @EXT_HN end,
	HIS_HN				= case when @HIS_HN is null then HIS_HN else @HIS_HN end,
    TITLE				= @TITLE,
    FNAME				= @FNAME,
    LNAME				= @LNAME,
    TITLE_ENG			= @TITLE_ENG,
    FNAME_ENG			= @FNAME_ENG,
    LNAME_ENG			= @LNAME_ENG,
    SSN					= @SSN,
    DOB					= @DOB,
    GENDER				= @GENDER,
    ADDR1				= @ADDR1,
    ADDR2				= @ADDR2,
    ADDR3				= @ADDR3,
    ADDR4				= @ADDR4,
    ADDR5				= @ADDR5,
    PHONE1				= @PHONE1,
    PHONE2				= @PHONE2,
    IS_JOHNDOE			= 'N',
    IS_DELETED          = 'N',
    IS_UPDATED          = 'Y',
    LAST_MODIFIED_BY	= @LAST_MODIFIED_BY,
    LAST_MODIFIED_ON	= GETDATE()
where
	REG_ID              = @REG_ID";

            Parameters = new DbParameter[] {
                DoParameter("@REG_ID", reg.REG_ID),
				DoParameter("@EXT_HN", string.IsNullOrEmpty(reg.EXT_HN) ? (object)null : reg.EXT_HN),
                DoParameter("@HIS_HN", string.IsNullOrEmpty(reg.HIS_HN) ? (object)null : reg.HIS_HN),
                DoParameter("@TITLE", reg.TITLE),
                DoParameter("@FNAME", reg.FNAME),
                DoParameter("@LNAME", reg.LNAME),
                DoParameter("@TITLE_ENG", reg.TITLE_ENG),
                DoParameter("@FNAME_ENG", reg.FNAME_ENG),
                DoParameter("@LNAME_ENG", reg.LNAME_ENG),
                DoParameter("@SSN", reg.SSN),
                DoParameter("@DOB", reg.DOB == DateTime.MinValue ? (object)null : reg.DOB),
                DoParameter("@GENDER", reg.GENDER == char.MinValue ? (object)null : reg.GENDER),
                DoParameter("@ADDR1", reg.ADDR1),
                DoParameter("@ADDR2", reg.ADDR2),
                DoParameter("@ADDR3", reg.ADDR3),
                DoParameter("@ADDR4", reg.ADDR4),
                DoParameter("@ADDR5", reg.ADDR5),
                DoParameter("@PHONE1", reg.PHONE1),
                DoParameter("@PHONE2", reg.PHONE2),
                DoParameter("@LAST_MODIFIED_BY", reg.LAST_MODIFIED_BY)};

            return Execute(query);
        }
        public bool updateHrEmp(HR_EMP emp)
        {
            if (emp.EMP_ID < 1) return false;

            string query = @"
update
	HR_EMP
set
	SALUTATION			= @SALUTATION,
	FNAME				= @FNAME,
	LNAME				= @LNAME,
	LAST_MODIFIED_BY	= @LAST_MODIFIED_BY,
	LAST_MODIFIED_ON	= GETDATE()
where
	EMP_ID				= @EMP_ID";

            Parameters = new DbParameter[] {
                DoParameter("@EMP_ID", emp.EMP_ID),
                DoParameter("@EMP_UID", emp.EMP_UID),
                DoParameter("@SALUTATION", emp.SALUTATION),
                DoParameter("@FNAME", emp.FNAME),
                DoParameter("@LNAME", emp.LNAME),
                DoParameter("@LAST_MODIFIED_BY", emp.LAST_MODIFIED_BY)};

            return Execute(query);
        }
        public bool updateRisExam(RIS_EXAM exam)
        {
            if (exam.EXAM_ID < 1) return false;

            string query = @"
update
	RIS_EXAM
set
	EXAM_NAME	        = @EXAM_NAME,
    LAST_MODIFIED_BY    = @LAST_MODIFIED_BY,
    LAST_MODIFIED_ON    = GETDATE()
where
	EXAM_ID             = @EXAM_ID";

            Parameters = new DbParameter[] {
                DoParameter("@EXAM_ID", exam.EXAM_ID),
                DoParameter("@EXAM_NAME", exam.EXAM_NAME),
                DoParameter("@LAST_MODIFIED_BY", exam.LAST_MODIFIED_BY)};

            return Execute(query);
        }
        public bool updateRisHL7IELog(RIS_HL7IELOG log)
        {
            string query = @"
update
	RIS_HL7IELOG
set
    HN					= @HN,
    ACCESSION_NO		= @ACCESSION_NO,
	[STATUS]            = @STATUS,
	IS_DELETED			= @IS_DELETED,
	HL7_TEXT            = case when @HL7_TEXT is null then HL7_TEXT else @HL7_TEXT end,
	ACKNOWLEDGMENT_CODE = @ACKNOWLEDGMENT_CODE,
	TEXT_MESSAGE        = @TEXT_MESSAGE,
	LAST_MODIFIED_BY    = @LAST_MODIFIED_BY,
	LAST_MODIFIED_ON    = GETDATE()
where
	LOG_ID              = @LOG_ID";

            Parameters = new DbParameter[] {
                DoParameter("@LOG_ID", log.LOG_ID),
                DoParameter("@HN", log.HN),
                DoParameter("@ACCESSION_NO", log.ACCESSION_NO),
                DoParameter("@STATUS", log.STATUS),
                DoParameter("@IS_DELETED", log.IS_DELETED),
                DoParameter("@HL7_TEXT", log.HL7_TEXT),
                DoParameter("@ACKNOWLEDGMENT_CODE", log.ACKNOWLEDGMENT_CODE),
                DoParameter("@TEXT_MESSAGE", log.TEXT_MESSAGE),
                DoParameter("@LAST_MODIFIED_BY", log.LAST_MODIFIED_BY)};

            return Execute(query);
        }
        public bool updateRisOrderDtlStatusHasImage(RIS_ORDERDTL orderDetail)
        {
            if (string.IsNullOrEmpty(orderDetail.ACCESSION_NO) || orderDetail.ORG_ID < 1) return false;

            string query = @"
update
    ords
set
	ords.MODALITY_ID		= case when @MODALITY_ID is null then ords.MODALITY_ID else @MODALITY_ID end,
    ords.[STATUS]           = case ords.[STATUS]
                                when 'N' then @STATUS
                                when 'A' then @STATUS
                                when 'S' then @STATUS
                                when 'C' then @STATUS
                                else ords.[STATUS]
                            end,
    ords.INSTANCE_UID       = @INSTANCE_UID,
	ords.AE_TITLE_ID		= case when @AE_TITLE_ID is null then ords.AE_TITLE_ID else @AE_TITLE_ID end,
	ords.IMAGE_CAPTURED_BY	= case when @IMAGE_CAPTURED_BY is null then IMAGE_CAPTURED_BY
								else @IMAGE_CAPTURED_BY end,
    ords.IMAGE_CAPTURED_ON	= case when ords.IMAGE_CAPTURED_ON is null then
									case when @IMAGE_CAPTURED_ON is null then GETDATE() else @IMAGE_CAPTURED_ON end
                                else ords.IMAGE_CAPTURED_ON end,
    ords.IMAGECOUNT         = case when @IMAGECOUNT > 0 then @IMAGECOUNT else ords.IMAGECOUNT end
from
	RIS_ORDERDTL ords
where
	ords.ACCESSION_NO       = @ACCESSION_NO
    ";

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", orderDetail.ACCESSION_NO),
                DoParameter("@MODALITY_ID", orderDetail.MODALITY_ID == 0 ? (object)null : orderDetail.MODALITY_ID),
                DoParameter("@STATUS", orderDetail.STATUS),
                DoParameter("@INSTANCE_UID", orderDetail.INSTANCE_UID),
                DoParameter("@AE_TITLE_ID", orderDetail.AE_TITLE_ID == 0 ? (object)null : orderDetail.AE_TITLE_ID),
				DoParameter("@IMAGE_CAPTURED_BY", orderDetail.IMAGE_CAPTURED_BY == 0 ? (object)null : orderDetail.IMAGE_CAPTURED_BY),
                DoParameter("@IMAGE_CAPTURED_ON", DateTime.Now),//orderDetail.IMAGE_CAPTURED_ON == DateTime.MinValue ? (object)null : orderDetail.IMAGE_CAPTURED_ON),
                DoParameter("@IMAGECOUNT", orderDetail.IMAGECOUNT),
                DoParameter("@ORG_ID", orderDetail.ORG_ID)};

            return Execute(query);
        }
        public bool updateHrUnit(HR_UNIT unit)
        {
            if (unit.UNIT_ID < 1) return false;

            string query = @"
update
	HR_UNIT
set
	UNIT_NAME			= @UNIT_NAME,
	LAST_MODIFIED_BY	= @LAST_MODIFIED_BY,
	LAST_MODIFIED_ON	= GETDATE()
where
	UNIT_ID				= @UNIT_ID";

            Parameters = new DbParameter[] {
                DoParameter("@UNIT_ID", unit.UNIT_ID),
                DoParameter("@UNIT_NAME", unit.UNIT_NAME),
                DoParameter("@LAST_MODIFIED_BY", unit.LAST_MODIFIED_BY)};

            return Execute(query);
        }

        public void updateRisOrder(RIS_ORDER order, DbTransaction transaction)
        {
            string query = @"
update
	ord
set
    ord.REG_ID              = @REG_ID,
    ord.HN                  = @HN,
    ord.ADMISSION_NO        = case when @ADMISSION_NO is null then ord.ADMISSION_NO else @ADMISSION_NO end,
    ord.PAT_STATUS          = @PAT_STATUS,
    ord.INSURANCE_TYPE_ID   = @INSURANCE_TYPE_ID,
    ord.REF_UNIT            = @REF_UNIT,
    ord.REF_DOC             = @REF_DOC,
    ord.IS_PRINTED          = 'N',
    ord.IS_CANCELED         = 'N',
    ord.LAST_MODIFIED_BY	= @LAST_MODIFIED_BY,
    ord.LAST_MODIFIED_ON	= GETDATE()
from
    RIS_ORDER ord
where
    ord.ORDER_ID			= @ORDER_ID";

            Parameters = new DbParameter[] {
                DoParameter("@ORDER_ID", order.ORDER_ID),
                DoParameter("@REG_ID", order.REG_ID),
                DoParameter("@HN", order.HN),
                DoParameter("@ADMISSION_NO", string.IsNullOrEmpty(order.ADMISSION_NO)  ? (object)null : order.ADMISSION_NO),
                DoParameter("@PAT_STATUS", order.PAT_STATUS == 0 ? (object)null : order.PAT_STATUS),
                DoParameter("@INSURANCE_TYPE_ID", order.INSURANCE_TYPE_ID == 0 ? (object)null : order.INSURANCE_TYPE_ID),
                DoParameter("@REF_UNIT", order.REF_UNIT == 0 ? (object)null : order.REF_UNIT),
                DoParameter("@REF_DOC", order.REF_DOC == 0 ? (object)null : order.REF_DOC),
                DoParameter("@ORG_ID", order.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", order.LAST_MODIFIED_BY)};

            Execute(query, transaction);
        }
        public void updateRisOrderDtl(RIS_ORDERDTL orderDetail, DbTransaction transaction)
        {
            string query = @"
update
	ords
set
    ords.EXAM_ID            = @EXAM_ID,
    ords.MODALITY_ID        = case when @MODALITY_ID is null then ords.MODALITY_ID else @MODALITY_ID end,
    ords.QTY                = @QTY,
    ords.RATE               = case @RATE when 0 then ords.RATE else @RATE end,
    ords.PRIORITY			= @PRIORITY,
	ords.ASSIGNED_TO		= case ords.[STATUS] when 'N' then @ASSIGNED_TO when 'A' then @ASSIGNED_TO else ords.ASSIGNED_TO end,
    ords.IS_DELETED			= @IS_DELETED,
    ords.LAST_MODIFIED_BY	= @LAST_MODIFIED_BY,
    ords.LAST_MODIFIED_ON	= GETDATE()
from
    RIS_ORDERDTL ords
where
    ords.ACCESSION_NO       = @ACCESSION_NO
    ";

            Parameters = new DbParameter[] {
                DoParameter("@EXAM_ID", orderDetail.EXAM_ID),
                DoParameter("@ACCESSION_NO", orderDetail.ACCESSION_NO),
                DoParameter("@MODALITY_ID", orderDetail.MODALITY_ID == 0 ? (object)null : orderDetail.MODALITY_ID),
                DoParameter("@QTY", orderDetail.QTY),
                DoParameter("@RATE", orderDetail.RATE < 0 ? 0 : orderDetail.RATE),
                DoParameter("@PRIORITY", orderDetail.PRIORITY),
				DoParameter("@ASSIGNED_TO", orderDetail.ASSIGNED_TO == 0 ? (object)null : orderDetail.ASSIGNED_TO),
                DoParameter("@IS_DELETED", orderDetail.IS_DELETED),
                DoParameter("@ORG_ID", orderDetail.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", orderDetail.LAST_MODIFIED_BY)};

            Execute(query, transaction);
        }
        public bool updateRisOrderDtl_IsDelete(RIS_ORDERDTL orderDetail)
        {
            string query = @"
update
	ords
set
    ords.IS_DELETED			= @IS_DELETED,
    ords.LAST_MODIFIED_BY	= @LAST_MODIFIED_BY,
    ords.LAST_MODIFIED_ON	= GETDATE()
from
    RIS_ORDERDTL ords
where
    ords.ACCESSION_NO       = @ACCESSION_NO
    ";

            Parameters = new DbParameter[] {
                DoParameter("@ACCESSION_NO", orderDetail.ACCESSION_NO),
                DoParameter("@IS_DELETED", orderDetail.IS_DELETED),
                DoParameter("@ORG_ID", orderDetail.ORG_ID),
                DoParameter("@LAST_MODIFIED_BY", orderDetail.LAST_MODIFIED_BY)};

            return Execute(query);
        }
        public bool updateRisOrderDtlMerge(int regId)
        {
            if (regId < 1) return false;

            string query = @"
SET NOCOUNT ON

declare @last_order int = 0

select top 1
	@last_order = ord.ORDER_ID
from
	RIS_ORDER ord
	inner join RIS_ORDERDTL ords
			on ord.ORDER_ID = ords.ORDER_ID
			and (ISNULL(ord.IS_CANCELED, 'N') = 'Y'
				or ISNULL(ords.IS_DELETED, 'N') = 'Y'
				or ords.[STATUS] in ('D', 'P', 'F'))
			and DATEDIFF(DAY, ord.ORDER_DT, GETDATE()) = 0
			and ord.REG_ID = @REG_ID
order by
	ord.ORDER_ID desc

declare @tbOrder table(ORDER_ID int, EXAM_ID int, ACCESSION_NO nvarchar(30), [MERGE] nvarchar(3))
	insert into @tbOrder
		select
			ord.ORDER_ID,
			ords.EXAM_ID,
			ords.ACCESSION_NO,
			ISNULL(ords.[MERGE], '')
		from
			RIS_ORDER ord
			inner join RIS_ORDERDTL ords
					on ord.ORDER_ID = ords.ORDER_ID
					and ISNULL(ord.IS_CANCELED, 'N') = 'N'
					and ISNULL(ords.IS_DELETED, 'N') = 'N'
					and ISNULL(ords.[MERGE], '') != 'MGR'
					and DATEDIFF(DAY, ord.ORDER_DT, GETDATE()) = 0
					and ord.REG_ID = @REG_ID
					and ord.ORDER_ID > @last_order
				inner join RIS_AUTOMERGECONFIG mgr
						on ords.EXAM_ID = mgr.merger_exam_id
						or ords.EXAM_ID = mgr.mergee_exam_id
		order by
			ords.LAST_MODIFIED_ON desc

if @@ROWCOUNT > 1
begin
	update
		ords
	set
		ords.[MERGE]	= case merger_exam.EXAM_ID when ords.EXAM_ID then 'MRR' else 'MGR' end,
		ords.MERGE_WITH	= case merger_exam.EXAM_ID when ords.EXAM_ID then '' else merger_exam.ACCESSION_NO end
	from
		RIS_AUTOMERGECONFIG mgr
		inner join @tbOrder merger_exam
				on mgr.merger_exam_id = merger_exam.EXAM_ID
		inner join @tbOrder mergee_exam
				on mgr.mergee_exam_id = mergee_exam.EXAM_ID
				and mergee_exam.[MERGE] != 'MRR',
		RIS_ORDERDTL ords
	where
		(ords.ORDER_ID = merger_exam.ORDER_ID
		and ords.EXAM_ID = merger_exam.EXAM_ID)
		or
		(ords.ORDER_ID = mergee_exam.ORDER_ID
		and ords.EXAM_ID = mergee_exam.EXAM_ID)
end";

            Parameters = new DbParameter[] { DoParameter("@REG_ID", regId) };

            return Execute(query);
        }

        public bool reconcilePatient(string oldHn, int newRegId, string newHn, int orgId, int lastModifiedBy)
        {
            string query = @"
update
	HIS_REGISTRATION
set
    IS_DELETED          = 'Y',
    IS_UPDATED          = 'Y',
    LAST_MODIFIED_BY	= @LAST_MODIFIED_BY,
    LAST_MODIFIED_ON	= GETDATE()
where
	HN                  = @OLD_HN

update
    RIS_ORDER
set
    REG_ID		        = @REG_ID,
    HN			        = @HN,
    LAST_MODIFIED_BY	= @LAST_MODIFIED_BY,
    LAST_MODIFIED_ON	= GETDATE()
where
    HN			        = @OLD_HN
    ";


            Parameters = new DbParameter[] {
                DoParameter("@OLD_HN",oldHn),
                DoParameter("@REG_ID", newRegId),
                DoParameter("@HN", newHn),
                DoParameter("@ORG_ID", orgId),
                DoParameter("@LAST_MODIFIED_BY", lastModifiedBy)};

            return Execute(query);
        }
        public string generateAccessionNo(int modalityId, string orgUid)
        {
            string seq_name = string.Empty;

            if (modalityId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    modality.MODALITY_UID,
    modality_type.TYPE_UID,
    modality_type.TYPE_NAME_ALIAS
from
	RIS_MODALITY modality
	inner join RIS_MODALITYTYPE modality_type
			on modality.MODALITY_TYPE = modality_type.[TYPE_ID]
			and modality.MODALITY_ID = @MODALITY_ID";

            Parameters = new DbParameter[] { DoParameter("@MODALITY_ID", modalityId) };

            using (DataTable dtt = SelectData(query))
            {
                if (Utilities.HasData(dtt))
                    seq_name = ConfigManager.GetTypeCode(dtt.Rows[0]["MODALITY_UID"].ToString(), dtt.Rows[0]["TYPE_UID"].ToString()) ?? dtt.Rows[0]["TYPE_NAME_ALIAS"].ToString();
            }

            query = @"
if not exists (select * from GBL_SEQUENCES where SEQ_NAME = @SEQ_NAME)
begin
	insert into GBL_SEQUENCES
	(
		SEQ_NAME
		,SEED
		,INCR
		,CURR_VAL
		,DATESTART
	)
	values
	(
		@SEQ_NAME
		,1
		,1
		,1
		,CONVERT(date, GETDATE())
	)

    set @runNo = 1
end
else
begin
	update
		GBL_SEQUENCES
	set
		@runNo = CURR_VAL =
            case CONVERT(date, DATESTART)
                when CONVERT(date, GETDATE()) then CURR_VAL + INCR
                else 1
            end,
        DATESTART = CONVERT(date, GETDATE())
	where
		SEQ_NAME = @SEQ_NAME
end";

            Parameters = new DbParameter[] {
                DoParameter("@runNo", 0, ParameterDirection.Output),
                DoParameter("@SEQ_NAME", seq_name)};

            Execute(query);

            string format = Config.AccessionNoFormat
                .Replace("[org]", "0")
                .Replace("[datetime]", "1")
                .Replace("[typeCode]", "2")
                .Replace("[runNo]", "3")
                .Trim();

            return string.Format(
                CultureInfo.GetCultureInfo(Config.AccessionNoNLS),
                format,
                orgUid,
                DateTime.Now,
                seq_name,
                Parameters[0].Value);
        }
    }
}