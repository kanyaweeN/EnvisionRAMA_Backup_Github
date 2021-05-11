using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class _LookUpSelect : DataAccessBase
    {
        DataSet ds;
        public _LookUpSelect()
        {

        }
        public DataSet SelectPatientDestination(string AccessionNo)
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_PatientDestination_Select;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@ACCESSION_NO",AccessionNo),
            };

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet FixDataOnline()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_RepairDataOnline;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet selectDataResultByAccessionNo(string accessionNo)
        {
            if (string.IsNullOrEmpty(accessionNo)) return null;

            #region query result
            string query_result = @"
SET NOCOUNT ON

select
	org.ORG_ALIAS,
	patient.HN,
    ISNULL(patient.TITLE, N'') + ISNULL(patient.FNAME, N'') + N' ' + ISNULL(patient.LNAME, N'') as PATIENT_NAME,
    ISNULL(patient.TITLE_ENG, N'') + ISNULL(patient.FNAME_ENG, N'') + N' ' + ISNULL(patient.LNAME_ENG, N'') as PATIENT_NAME_ENG,
	patient.GENDER as PATIENT_GENDER,
	patient.DOB as PATIENT_DOB,
	CONVERT(nvarchar(max), DATEDIFF(YEAR, patient.DOB, ords.EXAM_DT)) + N'Y' as PATIENT_AGE,
    ord.REQUESTNO,
    ords.EXAM_DT,
	ords.ACCESSION_NO,
	ords.[STATUS],
	case ords.[STATUS]
        when N'P' then N'Prelim'
        when N'F' then N'Finalized'
    end as StatusText,
	severity.SEVERITY_NAME,
	ref_unit.UNIT_NAME as REF_UNIT_NAME,
    ISNULL(ref_doc.SALUTATION, N'') + ISNULL(ref_doc.FNAME, N'') + N' ' + ISNULL(ref_doc.LNAME, N'') as REF_DOC_NAME,
	exam.EXAM_NAME,
	result.RESULT_TEXT_HTML,
	ISNULL(rad.FNAME_ENG, N'') + N' ' + ISNULL(rad.LNAME_ENG, N'') + N', M.D. ' + ISNULL(rad_title.JOB_TITLE_DESC, N'') as Radiologist
from
	RIS_ORDER ord 
	inner join RIS_ORDERDTL ords on ords.ORDER_ID = ord.ORDER_ID 
	left join RIS_EXAMRESULT result on result.ACCESSION_NO = ords.ACCESSION_NO 
	inner join RIS_EXAM exam on ords.EXAM_ID = exam.EXAM_ID 
	inner join GBL_ENV org on ord.ORG_ID = org.ORG_ID 
	left join HR_EMP rad on ords.ASSIGNED_TO = rad.EMP_ID 
	left join HR_JOBTITLE rad_title on rad.JOBTITLE_ID = rad_title.JOB_TITLE_ID 
	inner join HIS_REGISTRATION patient on ord.REG_ID = patient.REG_ID 
	left join HR_UNIT ref_unit on ord.REF_UNIT = ref_unit.UNIT_ID 
	left join HR_EMP ref_doc on ord.REF_DOC = ref_doc.EMP_ID 
	left join RIS_EXAMRESULTSEVERITY severity on result.SEVERITY_ID = severity.SEVERITY_ID
where
    ords.ACCESSION_NO = @ACCESSION_NO
	and ISNULL(ords.IS_DELETED, N'N') = N'N'
	and ISNULL(ord.IS_CANCELED, N'N') = N'N'";
            #endregion
            #region query result addendum
            string query_result_addendum = @"
SET NOCOUNT ON

select
    addendum.ACCESSION_NO,
	ISNULL(rad.FNAME_ENG, N'') + N' ' + ISNULL(rad.LNAME_ENG, N'') + N', M.D. ' + ISNULL(rad_title.JOB_TITLE_DESC, N'') as Radiologist,
    addendum.NOTE_TEXT as RESULT_TEXT,
    addendum.NOTE_ON
from
    RIS_EXAMRESULTNOTE addendum
    inner join HR_EMP rad
            on addendum.NOTE_BY = rad.EMP_ID
		inner join HR_JOBTITLE rad_title
				on rad.JOBTITLE_ID = rad_title.JOB_TITLE_ID
where
    addendum.ACCESSION_NO = @ACCESSION_NO";
            #endregion

            string[] queries = new string[2];
            queries[0] = query_result;
            queries[1] = query_result_addendum;

            

            
            DataSet ds = new DataSet();
            ParameterList = new DbParameter[] 
            { 
                Parameter("@ACCESSION_NO",accessionNo),
            };
            ds.Tables.Add(ExecuteDataTableByStrings(query_result).Copy());
            ParameterList = new DbParameter[] 
            { 
                Parameter("@ACCESSION_NO",accessionNo),
            };
            ds.Tables.Add(ExecuteDataTableByStrings(query_result_addendum).Copy());

            ds.Tables[0].TableName = "Result";
            ds.Tables[1].TableName = "Addendum";
            ds.AcceptChanges();
            return ds.Copy();
        }
    }
}
