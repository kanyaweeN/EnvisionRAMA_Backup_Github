using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
        ~RISConnection() { base.Dispose(); }

        //This query copy from query_oru at sulotion EnvisionInterfaceEngine.
        public DataTable selectRisExamResultByAccessionNo(string accessionNo)
        {
            if (string.IsNullOrEmpty(accessionNo)) return null;

            string query = @"
SET NOCOUNT ON

select
    ord.ORDER_ID,
	ord.ORDER_DT,
    result.ACCESSION_NO,
    result.RESULT_STATUS,
    result.RESULT_TEXT_HTML,
    result.RESULT_TEXT_PLAIN,
    result.RESULT_TEXT_RTF,
	result.LAST_MODIFIED_BY,
	result.LAST_MODIFIED_ON as RESULT_ON,
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
		+ ', M.D.'
		+ case rad.AUTH_LEVEL_ID
			when 3 then
				case rad.IS_RADIOLOGIST
					when 'Y' then ''
					else ' Radiologist'
				end
			else ''
		end as Radiologist,
    exam.EXAM_UID,
    exam.EXAM_NAME,
    ISNULL(exam.DEFER_HIS_RECONCILE, 'N') as DEFER_HIS_RECONCILE,
    reg.HN,
    reg.HIS_HN,
    reg.TITLE as PATIENT_TITLE,
    reg.FNAME as PATIENT_FNAME,
    reg.LNAME as PATIENT_LNAME,
    reg.TITLE_ENG as PATIENT_TITLE_ENG,
    reg.FNAME_ENG as PATIENT_FNAME_ENG,
    reg.LNAME_ENG as PATIENT_LNAME_ENG,
    reg.SSN as PATIENT_SSN,
    reg.GENDER as PATIENT_GENDER,
    reg.DOB as PATIENT_DOB,
    reg.ADDR1 as PATIENT_ADDR1,
    reg.PHONE1 as PATIENT_PHONE1,
    reg.PHONE2 as PATIENT_PHONE2,
    env.ORG_ID,
    env.ORG_ALIAS
from
    RIS_ORDER ord
    inner join RIS_EXAMRESULT result
            on ord.ORDER_ID = result.ORDER_ID
			and result.ACCESSION_NO = @ACCESSION_NO
            and result.RESULT_STATUS in ('P', 'F')
        inner join HR_EMP rad
                on result.LAST_MODIFIED_BY = rad.EMP_ID
        inner join RIS_EXAM exam
                on result.EXAM_ID = exam.EXAM_ID
    inner join HIS_REGISTRATION reg
            on ord.REG_ID = reg.REG_ID
    inner join GBL_ENV env
			on ord.ORG_ID = env.ORG_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@ACCESSION_NO", accessionNo)
            };

            return SelectData(query);
        }

        //HIS_REGISTRATION
        public DataTable selectDataExistsPatientByHN(string hn, int orgId)
        {
            if (string.IsNullOrEmpty(hn) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    REG_ID,
	TITLE_ENG,
	FNAME_ENG,
	LNAME_ENG
from
    HIS_REGISTRATION
where
    HN = @HN
    and ORG_ID = @ORG_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@HN", hn),
                new SqlParameter("@ORG_ID", orgId)
            };

            return SelectData(query);
        }

        //HR_EMP
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
    and ORG_ID = @ORG_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@EMP_UID", empUid),
                new SqlParameter("@ORG_ID", orgId)
            };

            return SelectData(query);
        }
        public DataTable selectDataHrEmpByEmpId(int empId)
        {
            if (empId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    EMP_UID
from
    HR_EMP
where
    EMP_ID = @EMP_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@EMP_ID", empId)
            };

            return SelectData(query);
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

            Parameters = new DbParameter[]
            {
                new SqlParameter("@EMP_ID", 0) { Direction = ParameterDirection.Output },
                new SqlParameter("@EMP_UID", emp.EMP_UID),
                new SqlParameter("@SALUTATION", string.IsNullOrEmpty(emp.SALUTATION) ? string.Empty : emp.SALUTATION.Trim()),
                new SqlParameter("@FNAME", string.IsNullOrEmpty(emp.FNAME) ? string.Empty : emp.FNAME.Trim()),
                new SqlParameter("@LNAME", string.IsNullOrEmpty(emp.LNAME) ? string.Empty : emp.LNAME.Trim()),
                new SqlParameter("@TITLE_ENG", string.IsNullOrEmpty(emp.TITLE_ENG) ? string.Empty : emp.TITLE_ENG.Trim()),
                new SqlParameter("@FNAME_ENG", string.IsNullOrEmpty(emp.FNAME_ENG) ? string.Empty : emp.FNAME_ENG.Trim()),
                new SqlParameter("@LNAME_ENG", string.IsNullOrEmpty(emp.LNAME_ENG) ? string.Empty : emp.LNAME_ENG.Trim()),
                new SqlParameter("@JOB_TYPE", emp.JOB_TYPE),
                new SqlParameter("@ORG_ID", emp.ORG_ID),
                new SqlParameter("@LAST_MODIFIED_BY", emp.LAST_MODIFIED_BY)
            };

            Execute(query);

            return Utilities.ToInt(Parameters[0].Value.ToString());
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

            Parameters = new DbParameter[]
            {
                new SqlParameter("@EMP_ID", emp.EMP_ID),
                new SqlParameter("@EMP_UID", emp.EMP_UID),
                new SqlParameter("@SALUTATION", emp.SALUTATION),
                new SqlParameter("@FNAME", emp.FNAME),
                new SqlParameter("@LNAME", emp.LNAME),
                new SqlParameter("@LAST_MODIFIED_BY", emp.LAST_MODIFIED_BY)
            };

            return Execute(query);
        }

        //HR_UNIT
        public DataTable selectDataExistsUnitByUnitUid(string unitUid, int orgId)
        {
            if (string.IsNullOrEmpty(unitUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    UNIT_ID
from
    HR_UNIT
where
    UNIT_UID = @UNIT_UID
    and ORG_ID = @ORG_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@UNIT_UID", unitUid),
                new SqlParameter("@ORG_ID", orgId)
            };

            return SelectData(query);
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
                new SqlParameter("@UNIT_ID", 0) { Direction = ParameterDirection.Output },
                new SqlParameter("@UNIT_UID", unit.UNIT_UID),
                new SqlParameter("@UNIT_NAME", unit.UNIT_NAME),
                new SqlParameter("@ORG_ID", unit.ORG_ID),
                new SqlParameter("@LAST_MODIFIED_BY", unit.LAST_MODIFIED_BY)
            };

            Execute(query);

            return Utilities.ToInt(Parameters[0].Value.ToString());
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

            Parameters = new DbParameter[]
            {
                new SqlParameter("@UNIT_ID", unit.UNIT_ID),
                new SqlParameter("@UNIT_NAME", unit.UNIT_NAME),
                new SqlParameter("@LAST_MODIFIED_BY", unit.LAST_MODIFIED_BY)
            };

            return Execute(query);
        }

        //RIS_CLINICTYPE
        public DataTable selectDataExistsClinicTypeByClinicTypeUid(string clinicTypeUid, int orgId)
        {
            if (string.IsNullOrEmpty(clinicTypeUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    CLINIC_TYPE_ID
from
    RIS_CLINICTYPE
where
    CLINIC_TYPE_UID = @CLINIC_TYPE_UID
    and ORG_ID = @ORG_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@CLINIC_TYPE_UID", clinicTypeUid),
                new SqlParameter("@ORG_ID", orgId)
            };

            return SelectData(query);
        }

        //RIS_EXAM
        public DataTable selectDataExistsExamByExamUid(string examUid, int orgId)
        {
            if (string.IsNullOrEmpty(examUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    exam.EXAM_ID,
    ISNULL(exam.IS_ACTIVE, 'Y') as IS_ACTIVE,
    ISNULL(exam.DEFER_HIS_RECONCILE, 'N') as DEFER_HIS_RECONCILE
from
    RIS_EXAM exam
where
    exam.EXAM_UID = @EXAM_UID
    and exam.ORG_ID = @ORG_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@EXAM_UID", examUid),
                new SqlParameter("@ORG_ID", orgId)
            };

            return SelectData(query);
        }
        public DataTable selectDataRisExamByExamId(int examId)
        {
            if (examId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    exam.EXAM_UID
from
    RIS_EXAM exam
where
	exam.EXAM_ID = @EXAM_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@EXAM_ID", examId)
            };

            return SelectData(query);
        }
        public DataTable selectDataRisExamCheckup()
        {
            string query = @"
SET NOCOUNT ON

select
    exam.EXAM_UID,
    exam.EXAM_NAME
from
    RIS_EXAM exam
where
	ISNULL(IS_CHECKUP, 'N') = 'Y'";

            Parameters = null;

            return SelectData(query);
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
	RATE,
	SERVICE_TYPE,
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
	@RATE,
	@SERVICE_TYPE,
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
                new SqlParameter("@EXAM_ID", 0){ Direction = ParameterDirection.Output },
                new SqlParameter("@EXAM_UID", exam.EXAM_UID),
                new SqlParameter("@EXAM_NAME", exam.EXAM_NAME),
                new SqlParameter("@EXAM_TYPE", exam.EXAM_TYPE),
                new SqlParameter("@RATE", exam.RATE),
                new SqlParameter("@SERVICE_TYPE", exam.SERVICE_TYPE),
                new SqlParameter("@UNIT_ID", exam.UNIT_ID),
                new SqlParameter("@ORG_ID", exam.ORG_ID),
                new SqlParameter("@LAST_MODIFIED_BY", exam.LAST_MODIFIED_BY)
            };

            Execute(query);

            return Utilities.ToInt(Parameters[0].Value.ToString());
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

            Parameters = new DbParameter[]
            {
                new SqlParameter("@EXAM_ID", exam.EXAM_ID),
                new SqlParameter("@EXAM_NAME", exam.EXAM_NAME),
                new SqlParameter("@LAST_MODIFIED_BY", exam.LAST_MODIFIED_BY)
            };

            return Execute(query);
        }
        public bool updateRisExamRate(RIS_EXAM exam)
        {
            if (exam.EXAM_ID < 1) return false;

            string query = @"
update
	RIS_EXAM
set
	RATE				= @RATE,
    LAST_MODIFIED_BY    = @LAST_MODIFIED_BY,
    LAST_MODIFIED_ON    = GETDATE()
where
	EXAM_ID             = @EXAM_ID";

            Parameters = new DbParameter[]
            {
                new SqlParameter("@EXAM_ID", exam.EXAM_ID),
                new SqlParameter("@RATE", exam.RATE),
                new SqlParameter("@LAST_MODIFIED_BY", exam.LAST_MODIFIED_BY)
            };

            return Execute(query);
        }

        //RIS_INSURANCETYPE
        public DataTable selectDataExistsInsuranceTypeByInsuranceTypeUid(string insuranceTypeUid, int orgId)
        {
            if (string.IsNullOrEmpty(insuranceTypeUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    INSURANCE_TYPE_ID
from
    RIS_INSURANCETYPE
where
    INSURANCE_TYPE_UID = @INSURANCE_TYPE_UID
    and ORG_ID = @ORG_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@INSURANCE_TYPE_UID", insuranceTypeUid),
                new SqlParameter("@ORG_ID", orgId)
            };

            return SelectData(query);
        }
        public DataTable selectDataRisInsuranceTypeByInsuranceTypeId(int insuranceTypeId)
        {
            if (insuranceTypeId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    insurance.INSURANCE_TYPE_UID
from
    RIS_INSURANCETYPE insurance
where
	insurance.INSURANCE_TYPE_ID = @INSURANCE_TYPE_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@INSURANCE_TYPE_ID", insuranceTypeId)
            };

            return SelectData(query);
        }
        public int addRisInsuranceType(RIS_INSURANCETYPE insurance)
        {
            if (string.IsNullOrEmpty(insurance.INSURANCE_TYPE_UID) || insurance.ORG_ID < 1) return 0;

            string query = @"
insert into RIS_INSURANCETYPE
(
	INSURANCE_TYPE_UID,
	INSURANCE_TYPE_DESC,
	ORG_ID,
	CREATED_BY,
	CREATED_ON,
	LAST_MODIFIED_BY,
	LAST_MODIFIED_ON
)
values
(
	@INSURANCE_TYPE_UID,
	@INSURANCE_TYPE_DESC,
    @ORG_ID,
    @LAST_MODIFIED_BY,
    GETDATE(),
    @LAST_MODIFIED_BY,
    GETDATE()
)

set @INSURANCE_TYPE_ID = SCOPE_IDENTITY()";

            Parameters = new DbParameter[] {
                new SqlParameter("@INSURANCE_TYPE_ID", 0) { Direction = ParameterDirection.Output },
                new SqlParameter("@INSURANCE_TYPE_UID", insurance.INSURANCE_TYPE_UID),
                new SqlParameter("@INSURANCE_TYPE_DESC", insurance.INSURANCE_TYPE_DESC),
                new SqlParameter("@ORG_ID", insurance.ORG_ID),
                new SqlParameter("@LAST_MODIFIED_BY", insurance.LAST_MODIFIED_BY)
            };

            Execute(query);

            return Utilities.ToInt(Parameters[0].Value.ToString());
        }
        public bool updateRisInsuranceType(RIS_INSURANCETYPE insurance)
        {
            if (insurance.INSURANCE_TYPE_ID < 1) return false;

            string query = @"
update
	RIS_INSURANCETYPE
set
	INSURANCE_TYPE_DESC	= @INSURANCE_TYPE_DESC,
	LAST_MODIFIED_BY	= @LAST_MODIFIED_BY,
	LAST_MODIFIED_ON	= GETDATE()
where
	INSURANCE_TYPE_ID	= @INSURANCE_TYPE_ID";

            Parameters = new DbParameter[]
            {
                new SqlParameter("@INSURANCE_TYPE_ID", insurance.INSURANCE_TYPE_ID),
                new SqlParameter("@INSURANCE_TYPE_DESC", insurance.INSURANCE_TYPE_DESC),
                new SqlParameter("@LAST_MODIFIED_BY", insurance.LAST_MODIFIED_BY)
            };

            return Execute(query);
        }

        //RIS_PATSTATUS
        public DataTable selectDataExistsRisPatStatusByStatusUid(string statusUid, int orgId)
        {
            if (string.IsNullOrEmpty(statusUid) || orgId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
    STATUS_ID
from
    RIS_PATSTATUS
where
    STATUS_UID = @STATUS_UID
	and ORG_ID = @ORG_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@STATUS_UID", statusUid),
                new SqlParameter("@ORG_ID", orgId)
            };

            return SelectData(query);
        }

        //RIS_ORDER
        public bool updateRisOrder(int orderId, int insuranceTypeId, int lastModifiedBy)
        {
            if (orderId < 1) return false;

            string query = @"
update
    ord
set
    ord.INSURANCE_TYPE_ID   = case when @INSURANCE_TYPE_ID is null then ord.INSURANCE_TYPE_ID
                                else @INSURANCE_TYPE_ID end,
    ord.LAST_MODIFIED_BY   = case when @LAST_MODIFIED_BY is null then ord.LAST_MODIFIED_BY
                                else @LAST_MODIFIED_BY end
from
    RIS_ORDER ord
where
    ord.ORDER_ID = @ORDER_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@ORDER_ID",  orderId),
                new SqlParameter("@INSURANCE_TYPE_ID", insuranceTypeId == 0 ? DBNull.Value : (object)insuranceTypeId),
                new SqlParameter("@LAST_MODIFIED_BY", lastModifiedBy == 0 ? DBNull.Value : (object)lastModifiedBy)
            };

            return Execute(query);
        }

        //RIS_ORDERDTL
        public DataTable selectDataExistsRisOrderDtlByAccessionNo(string accessionNo)
        {
            if (string.IsNullOrEmpty(accessionNo)) return null;

            string query = @"
SET NOCOUNT ON

select
	ACCESSION_NO
from
    RIS_ORDERDTL
where
    ACCESSION_NO = @ACCESSION_NO";

            Parameters = new DbParameter[] {
                new SqlParameter("@ACCESSION_NO", accessionNo)
            };

            return SelectData(query);
        }
        public DataTable selectDataRisOrderDtlByOrderId(int orderId)
        {
            if (orderId < 1) return null;

            string query = @"
SET NOCOUNT ON

select
	ACCESSION_NO
from
    RIS_ORDERDTL
where
    ORDER_ID = @ORDER_ID";

            Parameters = new DbParameter[] {
                new SqlParameter("@ORDER_ID", orderId)
            };

            return SelectData(query);
        }
        public DataTable selectDataRisOrderDtlDoNotActive(DateTime dateSince)
        {
            if (dateSince == DateTime.MinValue) return null;

            string query = @"
SET NOCOUNT ON

select
	ords.ACCESSION_NO
from
	RIS_ORDER ord
	inner join RIS_ORDERDTL ords
			on ord.ORDER_ID = ords.ORDER_ID
			and ISNULL(ord.IS_CANCELED, 'N') = 'N'
			and ISNULL(ords.IS_DELETED, 'N') = 'N'
            and ords.[STATUS] not in ('S', 'C', 'D', 'P', 'F')
            and ords.CREATED_ON > @DATE_SINCE";

            Parameters = new DbParameter[] {
                new SqlParameter("@DATE_SINCE", dateSince)
            };

            return SelectData(query);
        }
        public bool checkIsDeletedByAccession(string accessionNo)
        {
            bool flag = false;
            string query = @"
            SET NOCOUNT ON
            select  COUNT(1) 
            from    RIS_ORDER
                    inner join RIS_ORDERDTL on RIS_ORDER.ORDER_ID = RIS_ORDERDTL.ORDER_ID
            where   RIS_ORDERDTL.ACCESSION_NO = @ACCESSION_NO
                    and ISNULL(IS_CANCELED,'N') = 'N'
                    and ISNULL(IS_DELETED,'N') = 'N'";

            Parameters = new DbParameter[] {
                new SqlParameter("@ACCESSION_NO", accessionNo)
            };
            DataTable dt = SelectData(query);
            if (Utilities.HasData(dt))
                flag = Convert.ToInt32(dt.Rows[0][0]) > 0 ? false : true;
            return flag;
        }

        public bool updateRisOrderDtl(string accessionNo, int clinicTypeId, int qty, decimal rate, int lastModifiedBy)
        {
            if (string.IsNullOrEmpty(accessionNo)) return false;

            string query = @"
update
    ords
set
    ords.CLINIC_TYPE        = case when @CLINIC_TYPE is null then ords.CLINIC_TYPE
                                else @CLINIC_TYPE end,
    ords.QTY                = case when @QTY is null then ords.QTY
                                else @QTY end,
    ords.RATE               = case when @RATE is null then ords.RATE
                                else @RATE end,
    ords.LAST_MODIFIED_BY   = case when @LAST_MODIFIED_BY is null then ords.LAST_MODIFIED_BY
                                else @LAST_MODIFIED_BY end
from
    RIS_ORDERDTL ords
where
    ords.ACCESSION_NO = @ACCESSION_NO";

            Parameters = new DbParameter[] {
                new SqlParameter("@ACCESSION_NO", accessionNo),
                new SqlParameter("@CLINIC_TYPE", clinicTypeId == 0 ? DBNull.Value : (object)clinicTypeId),
                new SqlParameter("@QTY", qty == 0 ? DBNull.Value : (object)qty),
                new SqlParameter("@RATE", rate == 0 ? DBNull.Value : (object)rate),
                new SqlParameter("@LAST_MODIFIED_BY", lastModifiedBy == 0 ? DBNull.Value : (object)lastModifiedBy)
            };

            return Execute(query);
        }
        //        public bool updateRisOrderDtl_IsDelete(string accessionNo, char isDelete)
        //        {
        //            string query = @"
        //update
        //	ords
        //set
        //    ords.IS_DELETED = @IS_DELETED
        //from
        //    RIS_ORDERDTL ords
        //where
        //    ords.ACCESSION_NO = @ACCESSION_NO";

        //            Parameters = new DbParameter[] {
        //                new SqlParameter("@ACCESSION_NO", accessionNo),
        //                new SqlParameter("@IS_DELETED", isDelete)
        //            };

        //            return Execute(query);
        //        }

        #region Helper
        public bool editEmp(HR_EMP emp)
        {
            bool flag = false;

            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataExistsEmpByEmpUId(emp.EMP_UID, emp.ORG_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    emp.EMP_ID = Convert.ToInt32(dtt.Rows[0]["EMP_ID"].ToString());

                    flag = ris.updateHrEmp(emp);
                }
                else
                {
                    emp.EMP_ID = ris.addHrEmp(emp);

                    flag = emp.EMP_ID > 0;
                }
            }

            return flag;
        }
        public bool editUnit(HR_UNIT unit)
        {
            bool flag = false;

            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataExistsUnitByUnitUid(unit.UNIT_UID, unit.ORG_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    unit.UNIT_ID = Convert.ToInt32(dtt.Rows[0]["UNIT_ID"].ToString());

                    flag = ris.updateHrUnit(unit);
                }
                else
                {
                    unit.UNIT_ID = ris.addHrUnit(unit);

                    flag = unit.UNIT_ID > 0;
                }
            }

            return flag;
        }
        public bool editInsuranceType(RIS_INSURANCETYPE insurance)
        {
            bool flag = false;

            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataExistsInsuranceTypeByInsuranceTypeUid(insurance.INSURANCE_TYPE_UID, insurance.ORG_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    insurance.INSURANCE_TYPE_ID = Convert.ToInt32(dtt.Rows[0]["INSURANCE_TYPE_ID"].ToString());

                    flag = ris.updateRisInsuranceType(insurance);
                }
                else
                {
                    insurance.INSURANCE_TYPE_ID = ris.addRisInsuranceType(insurance);

                    flag = insurance.INSURANCE_TYPE_ID > 0;
                }
            }

            return flag;
        }
        public void insertMWLLogs(DataTable dtHIS)
        {
            foreach (DataRow rows in dtHIS.Rows)
            {

                string query = @"
INSERT INTO [RIS_MWLLOGS]
           ([patRegNo]
           ,[patName]
           ,[patDOB]
           ,[patGender]
           ,[patLastUpdate]
           ,[ordModality]
           ,[ordTestCode]
           ,[ordTestDescription]
           ,[docCode]
           ,[docNameEng]
           ,[ordCreateTime]
           ,[his_id]
           ,[IS_SYNC])
     VALUES
           (@patRegNo
           ,@patName
           ,@patDOB
           ,@patGender
           ,@patLastUpdate
           ,@ordModality
           ,@ordTestCode
           ,@ordTestDescription
           ,@docCode
           ,@docNameEng
           ,@ordCreateTime
           ,@his_id
           ,'N')";

                Parameters = new DbParameter[] {
                new SqlParameter("@patRegNo", rows["patRegNo"].ToString()),
                new SqlParameter("@patName", rows["patName"].ToString()),
                new SqlParameter("@patDOB", string.IsNullOrEmpty(rows["patDOB"].ToString())?DateTime.MinValue:  Convert.ToDateTime(rows["patDOB"])),
                new SqlParameter("@patGender", rows["patGender"].ToString()),
                new SqlParameter("@patLastUpdate", string.IsNullOrEmpty(rows["patLastUpdate"].ToString())?DateTime.MinValue:Convert.ToDateTime(rows["patLastUpdate"])),
                new SqlParameter("@ordModality", rows["ordModality"].ToString()),
                new SqlParameter("@ordTestCode", rows["ordTestCode"].ToString()),
                new SqlParameter("@ordTestDescription", rows["ordTestDescription"].ToString()),
                new SqlParameter("@docCode", rows["docCode"].ToString()),
                new SqlParameter("@docNameEng", rows["docNameEng"].ToString()),
                new SqlParameter("@ordCreateTime", rows["ordCreateTime"]),
                new SqlParameter("@his_id", Convert.ToInt32(rows["his_id"])),
            };
                SelectData(query);
            }
        }
        public void chekSync()
        {
            string queryChk = @"select * from GBL_HEARTBEAT";
            bool success;
            DataTable dt = SelectData(queryChk, out success);
            string query = @"
            update GBL_HEARTBEAT
            set IS_UP = @IS_UP";
            Parameters = new DbParameter[] {
                new SqlParameter("@IS_UP", success),
            };
            SelectData(query);
        }
        #endregion
    }
}