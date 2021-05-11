using System;
using System.Data;
using System.Data.Common;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;
using MySql.Data.MySqlClient;

namespace EnvisionInterfaceEngine.Connection
{
	public class PDHConnection : MySqlEngine
	{
		private readonly string title_log;

		public PDHConnection(string connectionString) : base(connectionString) { title_log = ToString(); }
		~PDHConnection() { base.Dispose(); }

		public DataTable selectDataPatientByHisHN(string hisHn) { return new DataTable(); }

		public DataTable selectDataOrder(DateTime date)
		{
			string query = @"
select
	tmp.*,
	patient.pttitle as PATIENT_TITLE,
	patient.ptfname as PATIENT_FNAME,
	patient.ptlname as PATIENT_LNAME,
	patient.cardid as PATIENT_SSN,
	patient.ptdob as PATIENT_DOB,
	case patient.ptsex
		when 'SX1' then 'M'
		when 'SX2' then 'F'
		else 'U'
	end as PATIENT_GENDER
from
	((select
		'IPD' as PATIENT_TYPE,
		ord.hn as HIS_HN,
		ord.an as ADMISSION_NO,
		concat(replace(ord.orderno, '-', ''), '-', ord.seq) as ACCESSION_NO,
		ord.orderno as REQUESTNO,
		ord.seq as Q_NO,
		trim(leading '0' from ord.codexray) as EXAM_UID,
		ord.namexray as EXAM_NAME,
		ord.room_order as REF_UNIT_NAME,
		ord.doctor as REF_DOC_NAME
	from
		ipd.xray_order_ipd ord
		left join RIS.XRAYREQ req
			on ord.orderno = req.REQUESTNO
			and ord.seq = req.Q_NO
			and req.PATIENT_TYPE = 'IPD'
	where
		ord.orderdate = @ExamDate
		and ord.time_order > @ExamTime
		and ((IFNULL(req.ORDER_CONTROL, 'NW') = 'NW'
				and (IFNULL(req.HIS_SYNC, 0) = 0 or trim(leading '0' from ord.codexray) != req.EXAM_UID))
			or (IFNULL(req.ORDER_CONTROL, 'NW') = 'CA' and IFNULL(req.HIS_SYNC, 0) = 1)))
	union
	(select
		'OPD' as PATIENT_TYPE,
		ord.hn as HIS_HN,
		'' as ADMISSION_NO,
		concat(replace(ord.orderno, '-', ''), '-', ord.seq) as ACCESSION_NO,
		ord.orderno as REQUESTNO,
		ord.seq as Q_NO,
		trim(leading '0' from ord.codexray) as EXAM_UID,
		ord.namexray as EXAM_NAME,
		ord.room_order as REF_UNIT_NAME,
		ord.doctor as REF_DOC_NAME
	from
		opd.xray_order_opd ord
		left join RIS.XRAYREQ req
			on ord.orderno = req.REQUESTNO
			and ord.seq = req.Q_NO
			and req.PATIENT_TYPE = 'OPD'
	where
		ord.regdate = @ExamDate
		and ord.time_order > @ExamTime
		and ((IFNULL(req.ORDER_CONTROL, 'NW') = 'NW'
				and (IFNULL(req.HIS_SYNC, 0) = 0 or trim(leading '0' from ord.codexray) != req.EXAM_UID))
			or (IFNULL(req.ORDER_CONTROL, 'NW') = 'CA' and IFNULL(req.HIS_SYNC, 0) = 1)))
	union
	(select
		'PCU' as PATIENT_TYPE,
		ord.hn as HIS_HN,
		'' as ADMISSION_NO,
		concat(replace(ord.orderno, '-', ''), '-', ord.seq) as ACCESSION_NO,
		ord.orderno as REQUESTNO,
		ord.seq as Q_NO,
		trim(leading '0' from ord.codexray) as EXAM_UID,
		ord.namexray as EXAM_NAME,
		ord.room_order as REF_UNIT_NAME,
		ord.doctor as REF_DOC_NAME
	from
		pcu.xray_order_pcu ord
		left join RIS.XRAYREQ req
			on ord.orderno = req.REQUESTNO
			and ord.seq = req.Q_NO
			and req.PATIENT_TYPE = 'PCU'
	where
		ord.regdate = @ExamDate
		and ord.time_order > @ExamTime
		and ((IFNULL(req.ORDER_CONTROL, 'NW') = 'NW'
				and (IFNULL(req.HIS_SYNC, 0) = 0 or trim(leading '0' from ord.codexray) != req.EXAM_UID))
			or (IFNULL(req.ORDER_CONTROL, 'NW') = 'CA' and IFNULL(req.HIS_SYNC, 0) = 1)))) tmp
	inner join pt.pt patient
			on tmp.HIS_HN = patient.hn";

			Parameters = new DbParameter[] {
                new MySqlParameter("@ExamDate", date.ToString("yyyy-MM-dd")),
                new MySqlParameter("@ExamTime", date.ToString("HH:mm:ss"))
            };

			return SelectData(query);
		}
		public DataTable selectDataOrderCancel()
		{
			string query = @"
(select
	req.*
from
	RIS.XRAYREQ req
	left join ipd.xray_order_ipd ord
		on req.REQUESTNO = ord.orderno
		and req.Q_NO = ord.seq
where
	req.PATIENT_TYPE = 'IPD'
	and req.ORDER_CONTROL = 'NW'
	and ord.orderno is null)
union
(select
	req.*
from
	RIS.XRAYREQ req
	left join opd.xray_order_opd ord
		on req.REQUESTNO = ord.orderno
		and req.Q_NO = ord.seq
where
	req.PATIENT_TYPE = 'OPD'
	and req.ORDER_CONTROL = 'NW'
	and ord.orderno is null)
union
(select
	req.*
from
	RIS.XRAYREQ req
	left join pcu.xray_order_pcu ord
		on req.REQUESTNO = ord.orderno
		and req.Q_NO = ord.seq
where
	req.PATIENT_TYPE = 'PCU'
	and req.ORDER_CONTROL = 'NW'
	and ord.orderno is null)";

			Parameters = null;

			return SelectData(query);
		}

		public DataTable selectDataOrderForCheckNonExists(DateTime date)
		{
			string query = @"
(select
	orderno as REQUESTNO,
	seq as Q_NO,
	'IPD' as PATIENT_TYPE
from
	ipd.xray_order_ipd
where
	orderdate = @ExamDate
	and time_order = @ExamTime)
union
(select
	orderno as REQUESTNO,
	seq as Q_NO,
	'OPD' as PATIENT_TYPE
from
	opd.xray_order_opd
where
	regdate = @ExamDate
	and time_order = @ExamTime)
union
(select
	orderno as REQUESTNO,
	seq as Q_NO,
	'PCU' as PATIENT_TYPE
from
	pcu.xray_order_pcu
where
	regdate = @ExamDate
	and time_order = @ExamTime)";

			Parameters = new DbParameter[] {
                new MySqlParameter("@ExamDate", date.ToString("yyyy-MM-dd")),
                new MySqlParameter("@ExamTime", date.ToString("HH:mm:ss"))
            };

			return SelectData(query);
		}
		public DataTable selectDataOrderByAccessionNo(string patientType, string requestNo, string qNo)
		{
			string query = string.Empty;

			switch (patientType.ToLower())
			{
				case "ipd":
					#region query IPD
					query = @"
select
	hn as HN,
	an as ADMISSION_NO,
	concat(orderno, '-', seq) as ACCESSION_NO,
	orderno as REQUESTNO,
	codexray as EXAM_UID,
	namexray as EXAM_NAME,
	room_order as REF_UNIT_NAME,
	doctor as REF_DOC_NAME
from
	ipd.xray_order_ipd
where
	orderno = @RequestNo
	and seq = @QNo";
					#endregion
					break;
				case "opd":
					#region query OPD
					query = @"
select
	hn as HN,
	'' as ADMISSION_NO,
	concat(orderno, '-', seq) as ACCESSION_NO,
	orderno as REQUESTNO,
	codexray as EXAM_UID,
	namexray as EXAM_NAME,
	room_order as REF_UNIT_NAME,
	doctor as REF_DOC_NAME
from
	opd.xray_order_opd
where
	orderno = @RequestNo
	and seq = @QNo";
					#endregion
					break;
				case "pcu":
					#region query PCU
					query = @"
select
	hn as HN,
	'' as ADMISSION_NO,
	concat(orderno, '-', seq) as ACCESSION_NO,
	orderno as REQUESTNO,
	codexray as EXAM_UID,
	namexray as EXAM_NAME,
	room_order as REF_UNIT_NAME,
	doctor as REF_DOC_NAME
from
	pcu.xray_order_pcu
where
	orderno = @RequestNo
	and seq = @QNo";
					#endregion
					break;
			}

			Parameters = new DbParameter[] {
                new MySqlParameter("@RequestNo", requestNo),
                new MySqlParameter("@QNo", qNo)};

			return SelectData(query);
		}

		public bool updateDataLog(
			string accessionNo,
			string requestNo,
			string qNo,
			string orderControl,
			string patientType,
			string hisHn,
			string hn,
			string admissionNo,
			string patientTitle,
			string patientFName,
			string patientLName,
			string patientTitleEng,
			string patientFNameEng,
			string patientLNameEng,
			string patientSSN,
			DateTime patientDOB,
			char patientGender,
			string examUid,
			string examName,
			bool hisSync)
		{
			string query = @"select * from RIS.XRAYREQ where ACCESSION_NO = @ACCESSION_NO";

			Parameters = new DbParameter[] {
                new MySqlParameter("@ACCESSION_NO", accessionNo)};

			if (Utilities.HasData(SelectData(query)))
			{
				#region query update
				query = @"
update
	RIS.XRAYREQ
set					
	REQUESTNO = @REQUESTNO,
	Q_NO = @Q_NO,
	ORDER_CONTROL = @ORDER_CONTROL,
	PATIENT_TYPE = @PATIENT_TYPE,
	HIS_HN = @HIS_HN,
	HN = @HN,
	ADMISSION_NO = @ADMISSION_NO,
	PATIENT_TITLE = @PATIENT_TITLE,
	PATIENT_FNAME = @PATIENT_FNAME,
	PATIENT_LNAME = @PATIENT_LNAME,
	PATIENT_TITLE_ENG = @PATIENT_TITLE_ENG,
	PATIENT_FNAME_ENG = @PATIENT_FNAME_ENG,
	PATIENT_LNAME_ENG = @PATIENT_LNAME_ENG,
	PATIENT_SSN = @PATIENT_SSN,
	PATIENT_DOB = @PATIENT_DOB,
	PATIENT_GENDER = @PATIENT_GENDER,
	EXAM_UID = @EXAM_UID,
	EXAM_NAME = @EXAM_NAME,
	HIS_SYNC = @HIS_SYNC,
	HIS_ON = now()
where
	ACCESSION_NO = @ACCESSION_NO";
				#endregion
			}
			else
			{
				#region query insert
				query = @"
insert into RIS.XRAYREQ
(
	ACCESSION_NO,
	REQUESTNO,
	Q_NO,
	ORDER_CONTROL,
	PATIENT_TYPE,
	HIS_HN,
	HN,
	ADMISSION_NO,
	PATIENT_TITLE,
	PATIENT_FNAME,
	PATIENT_LNAME,
	PATIENT_TITLE_ENG,
	PATIENT_FNAME_ENG,
	PATIENT_LNAME_ENG,
	PATIENT_SSN,
	PATIENT_DOB,
	PATIENT_GENDER,
	EXAM_UID,
	EXAM_NAME,
	HIS_SYNC,
	HIS_ON
)
values
(
	@ACCESSION_NO,
	@REQUESTNO,
	@Q_NO,
	@ORDER_CONTROL,
	@PATIENT_TYPE,
	@HIS_HN,
	@HN,
	@ADMISSION_NO,
	@PATIENT_TITLE,
	@PATIENT_FNAME,
	@PATIENT_LNAME,
	@PATIENT_TITLE_ENG,
	@PATIENT_FNAME_ENG,
	@PATIENT_LNAME_ENG,
	@PATIENT_SSN,
	@PATIENT_DOB,
	@PATIENT_GENDER,
	@EXAM_UID,
	@EXAM_NAME,
	@HIS_SYNC,
	now()
)";
				#endregion
			}

			Parameters = new DbParameter[] {
                new MySqlParameter("@ACCESSION_NO", accessionNo),
                new MySqlParameter("@REQUESTNO", requestNo),
                new MySqlParameter("@Q_NO", qNo),
                new MySqlParameter("@ORDER_CONTROL", orderControl),
                new MySqlParameter("@PATIENT_TYPE", patientType),
                new MySqlParameter("@HIS_HN", hisHn),
                new MySqlParameter("@HN", hn),
                new MySqlParameter("@ADMISSION_NO", admissionNo),
                new MySqlParameter("@PATIENT_TITLE", patientTitle),
                new MySqlParameter("@PATIENT_FNAME", patientFName),
                new MySqlParameter("@PATIENT_LNAME", patientLName),
                new MySqlParameter("@PATIENT_TITLE_ENG", patientTitleEng),
                new MySqlParameter("@PATIENT_FNAME_ENG", patientFNameEng),
                new MySqlParameter("@PATIENT_LNAME_ENG", patientLNameEng),
                new MySqlParameter("@PATIENT_SSN", patientSSN),
                new MySqlParameter("@PATIENT_DOB", patientDOB == DateTime.MinValue ? DBNull.Value : (object)patientDOB),
                new MySqlParameter("@PATIENT_GENDER", patientGender),
                new MySqlParameter("@EXAM_UID", examUid),
                new MySqlParameter("@EXAM_NAME", examName),
                new MySqlParameter("@HIS_SYNC", hisSync)};

			return Execute(query);
		}
	}
}