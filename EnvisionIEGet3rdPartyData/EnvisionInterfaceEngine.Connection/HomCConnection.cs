using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionInterfaceEngine.Connection
{
    public class HomCConnection : MsSqlEngine
    {
        public HomCConnection() : base() { }
        public HomCConnection(string connectionString) : base(connectionString) { }
        ~HomCConnection() { base.Dispose(); }

        public DataTable selectDataOrder()
        {
            string query = @"
select
    his.*
from
    (
    select
	    ord.xprefix,
	    ord.xrunno,
	    ord.xreq_date,
	    ord.xreq_time,
	    ord.newXN,
	    ords.xpart_code,
	    ords.xproc_code,
	    ords.runNo,
	    pat.hn as HIS_HN,
	    pat.titleCode as PATIENT_TITLE,
	    pat.firstName as PATIENT_FNAME,
	    pat.lastName as PATIENT_LNAME,
	    pat.birthDay as PATIENT_DOB,
	    case pat.sex
		    when 'ช' then 'M'
		    when 'ญ' then 'F'
		    else 'O'
	    end as PATIENT_GENDER,
	    ord.regist_flag as VISIT_NO,
	    ord.xprefix + ord.xrunno + CONVERT(nvarchar(10), case ords.xrev_flag when 'R' then ords.xreq_reverse else ords.runNo end) as Q_NO,
	    ords.filmCount as QTY,
	    ords.xprice_amt as RATE,
	    case UPPER(ords.xrev_flag)
		    when 'R' then 'Y'
		    else 'N'
        end as IS_DELETED,
        exam.xproc_part + exam.xproc_code as EXAM_UID,
        exam.xproc_des as EXAM_NAME,
        ISNULL(dept.deptCode, ward.ward_id) as UNIT_UID,
        ISNULL(dept.deptDesc, ward.ward_name) as UNIT_NAME
    from
	    Xreq_h ord
	    inner join Xreq_d ords
			    on ord.xprefix = ords.xprefix
			    and ord.xrunno = ords.xrunno
		    inner join Xproc exam
				    on ords.xpart_code = exam.xproc_part
				    and ords.xproc_code = exam.xproc_code
	    left join DEPT dept
			    on ord.reqWard = dept.deptCode
	    left join Ward ward
			    on ord.reqWard = ward.ward_id
	    inner join PATIENT pat
			    on ord.hn = pat.hn
    ) his
    left join RIS_XRAYREQ ris
            on his.Q_NO = ris.Q_NO
where
    ISNULL(ris.RIS_FLAG, 'N') = 'N'";

            Parameters = null;

            return SelectData(query);
        }

        public bool updateDataOrderFlag(string hisXPreFix, string hisXRunNo, string hisRunNo, char flag)
        {
            string query = @"
update
    RIS_XRAYREQ
set
    RIS_FLAG = @RIS_FLAG
where
    Q_NO = @Q_NO";

            Parameters = new DbParameter[] {
                new SqlParameter("@Q_NO", hisXPreFix + hisXRunNo + hisRunNo),
                new SqlParameter("@RIS_FLAG", flag)
            };

            return Execute(query);
        }

        public bool selectDataExistsResult(string hisXPrefix, string hisXRunNo)
        {
            string query = @"
select
    *
from
    XresHis
where
    xprefix = @xPrefix
    and xrunno = @xRunNo";

            Parameters = new DbParameter[] {
                new SqlParameter("@xPrefix", hisXPrefix),
                new SqlParameter("@xRunNo", hisXRunNo)
            };

            return Utilities.HasData(SelectData(query));
        }

        public bool addDataResult(string hisXPrefix, string hisXRunNo, string hisHn, string hisVisitDate, string hisVisitNo, string hisXReqDate, string hisXnNo, string hisXPart, string hisExamUid, string hisRadUid, string hisUserName, string resultTextRtf)
        {
            string query = @"
update
    DOCC
set
    mtdExamNo = CONVERT(int, mtdExamNo) + 1
where
    docCode = @hisRadUid

insert into XresHis
(
    xprefix,
    xrunno,
    hn,
    regist_flag,
    xres_date,
    xres_time,
    xres_doc_code,
    xres_normal,
    xresTxt,
    lastRunNo,
    xn_no,
    xpart_code,
    xreq_date,
    visitDate,
    usrName
)
values
(
    @hisXPrefix,
    @hisXRunNo,
    @hisHn,
    @hisVisitNo,
    CONVERT(date, GETDATE()),
    CONVERT(time, GETDATE()),
    @hisRadUid,
    'N',
    @risResultTextRtf,
    0,
    @hisXnNo,
    @hisXPart,
    @hisXReqDate,
    @hisVisitDate,
    @hisUserName
)

update
    Xreq_h
set
    xres_flag = 'Y'
where
    xprefix = @hisXPrefix
    and xrunno = @hisXRunNo
    and hn = @hisHn
    and regist_flag = @hisVisitNo";

            Parameters = new DbParameter[] {
                new SqlParameter("@hisXPrefix", hisXPrefix),
                new SqlParameter("@hisXRunNo", hisXRunNo),
                new SqlParameter("@hisHn", hisHn),
                new SqlParameter("@hisVisitDate", hisVisitDate),
                new SqlParameter("@hisVisitNo", hisVisitNo),
                new SqlParameter("@hisXReqDate", hisXReqDate),
                new SqlParameter("@hisXnNo", hisXnNo),
                new SqlParameter("@hisXPart", hisXPart),
                new SqlParameter("@hisExamUid", hisExamUid),
                new SqlParameter("@hisRadUid", hisRadUid),
                new SqlParameter("@hisUserName", hisUserName),
                new SqlParameter("@risResultTextRtf", resultTextRtf)
            };

            return Execute(query);
        }
        public bool addDataResultDtl(string hisXPrefix, string hisXRunNo, string hisXReqDate, string hisRunNo, string hisXPartCode, string hisXProcCode)
        {
            string query = @"
insert into xhis_d
(
    xprefix,
    xrunno,
    xreq_date,
    runNo,
    xpart_code,
    xproc_code
)
values
(
    @hisXPrefix,
    @hisXRunNo,
    @hisXReqDate,
    @hisRunNo,
    @hisXPartCode,
    @hisXProcCode
)";
            Parameters = new DbParameter[] {
                new SqlParameter("@hisXPrefix", hisXPrefix),
                new SqlParameter("@hisXRunNo", hisXRunNo),
                new SqlParameter("@hisXReqDate", hisXReqDate),
                new SqlParameter("@hisRunNo", hisRunNo),
                new SqlParameter("@hisXPartCode", hisXPartCode),
                new SqlParameter("@hisXProcCode", hisXProcCode)
            };

            return Execute(query);
        }
        public bool updateDataResultDtl(string hisXPrefix, string hisXRunNo, string resultTextRtf)
        {
            string query = @"
update
	XresHis
set
	print_count = '',
    xresTxt = @risResultTextRtf
where
	xprefix = @hisXPrefix
	and xrunno = @hisXRunNo";

            Parameters = new DbParameter[] {
                new SqlParameter("@hisXPrefix", hisXPrefix),
                new SqlParameter("@hisXRunNo", hisXRunNo),
                new SqlParameter("@risResultTextRtf", resultTextRtf)
            };

            return Execute(query);
        }

        #region query select legacy archive
        private string query_select_legacy_archive = @"
select
	pat.hn as HN
	,ISNULL(pat.firstName, '') + ' ' + ISNULL(pat.lastName, '') as [Patient Name]
	,result.regist_flag as [Reg No]
	,SUBSTRING(result.xres_date, 7, 2) + '/' + SUBSTRING(result.xres_date, 5, 2) + '/' + SUBSTRING(result.xres_date, 1, 4) + ' ' + SUBSTRING(result.xres_time, 1, 2) + ':' + SUBSTRING(result.xres_time, 3, 2) as [Modified On]
	,xprefix as [Exam Type]
	,case xres_normal
		when 'N' then 'Abnormal'
		else 'Normal'
	end as Result
	,xresTxt as RESULT_TEXT_RTF
from
	XresHis result
	inner join PATIENT pat
			on result.hn = pat.hn
where
    {0}";
        #endregion
        public DataTable selectDataLegacyArchiveByHN(string hisHn)
        {
            string query = string.Format(query_select_legacy_archive, "pat.hn = @hisHn");

            Parameters = new DbParameter[] {
                new SqlParameter("@hisHn", hisHn)
            };

            return SelectData(query);
        }
        public DataTable selectDataLegacyArchiveByDate(DateTime dateBegin, DateTime dateEnd)
        {
            string query = string.Format(query_select_legacy_archive, "result.xres_date between @dateBegin and @dateEnd");

            Parameters = new DbParameter[] {
                new SqlParameter("@dateBegin", dateBegin),
                new SqlParameter("@dateEnd", dateEnd)
            };

            return SelectData(query);
        }
    }
}
