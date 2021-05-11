using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionInterfaceEngine.Connection
{
	public class SKNConnection : MsSqlEngine
	{
		private readonly string title_log;

		public SKNConnection() : base() { title_log = ToString(); }
		public SKNConnection(string connectionString) : base(connectionString) { }
		~SKNConnection() { base.Dispose(); }

		public DataTable selectDataPatientByHisHn(string hisHn)
		{
			string query = @"
select
	patient.Pid as HIS_HN,
	title.TitleTyp as PATIENT_TITLE,
	patient.fname as PATIENT_FNAME,
	patient.lname as PATIENT_LNAME,
	patient.Cid as PATIENT_SSN,
	patient.birthdate as PATIENT_DOB,
	case patient.sex
		when 1 then 'M'
		when 2 then 'F'
		else 'O' end as PATIENT_GENDER
from
	Patient patient
	inner join TitleParth title
			on patient.pname = title.TitleId
where
	patient.Pid = @HN";

			Parameters = new DbParameter[] { new SqlParameter("@HN", hisHn) };

			return SelectData(query);
		}
		public DataTable selectDataPatientVisitByHisHn(string hisHn)
		{
			string query = @"
select top 1
	opd.VsId as VISIT_NO,
	opd.VsOpdR as REF_UNIT_CODE,
	unit.TorName as REF_UNIT_NAME,
	opd.VsDate as UPDATED_DATE,
	opd.VsTime as UPDATED_TIME
from
	VisitOpd opd
	inner join TOpdRoom unit
			on opd.VsOpdR = unit.TOrId
where
	opd.VsPid = @HN
order by
	opd.VsId desc";

			Parameters = new DbParameter[] { new SqlParameter("@HN", hisHn) };

			return SelectData(query);
		}
		public DataTable selectDataPatientAdmitByHisHn(string hisHn)
		{
			string query = @"
select top 1
	ipd.ADRid as ADMISSION_NO,
	ipd.ADWard as REF_UNIT_CODE,
	unit.WardDesc as REF_UNIT_NAME,
	ipd.ADDate as UPDATED_DATE,
	ipd.ADTime as UPDATED_TIME
from
	AdmitData ipd
	inner join Ward unit
			on ipd.ADWard = unit.WordId
where
	ipd.ADPid = @HN
order by
	ipd.ADRid desc";

			Parameters = new DbParameter[] { new SqlParameter("@HN", hisHn) };

			return SelectData(query);
		}

		public DataTable selectDataOrder()
		{
			string query = @"
select
	*
from
	RIS_ORDER ord
where
	ISNULL(ord.HIS_SYNC, '0') = '0'";

			Parameters = null;

			return SelectData(query);
		}
		public DataTable selectDataOrderByRequestNo(string requestNo, string examUid, out bool success)
		{
			string query = @"
select
	*
from
	RIS_ORDER ord
where
	REQUESTNO = @REQUESTNO
	and EXAM_CODE = @EXAM_CODE";

			Parameters = new DbParameter[] {
                new SqlParameter("@REQUESTNO", requestNo),
                new SqlParameter("@EXAM_CODE", examUid)};

			return SelectData(query, out success);
		}
		public bool updateDataOrderRequestNo(string requestNo, string examUid)
		{
			string query = @"
update
	RIS_ORDER
set
	REQUESTNO = @REQUESTNO
where
	ACCESSION_NO = @REQUESTNO
	and EXAM_CODE = @EXAM_CODE";

			Parameters = new DbParameter[] {
                new SqlParameter("@REQUESTNO", requestNo),
                new SqlParameter("@EXAM_CODE", examUid)};

			return Execute(query);
		}
		public bool updateDataOrderAccessionNo(string accessionNo, string requestNo, string examUid)
		{
			string query = @"
update
	RIS_ORDER
set
	ACCESSION_NO = @ACCESSION_NO
where
	REQUESTNO = @REQUESTNO
	and EXAM_CODE = @EXAM_CODE";

			Parameters = new DbParameter[] {
                new SqlParameter("@ACCESSION_NO", accessionNo),
                new SqlParameter("@REQUESTNO", requestNo),
                new SqlParameter("@EXAM_CODE", examUid)};

			return Execute(query);
		}
		public bool updateDataOrderSync(string requestNo, string examUid, bool hisSync, string hisMessage)
		{
			string query = @"
update
	RIS_ORDER
set
	HIS_SYNC = @HIS_SYNC,
	HIS_MESSAGE = @HIS_MESSAGE,
	HIS_RV = @HIS_RV
where
	REQUESTNO = @REQUESTNO
	and EXAM_CODE = @EXAM_CODE";

			Parameters = new DbParameter[] {
                new SqlParameter("@REQUESTNO", requestNo),
                new SqlParameter("@EXAM_CODE", examUid),
                new SqlParameter("@HIS_SYNC", hisSync ? '1' : '0'),
                new SqlParameter("@HIS_MESSAGE", hisMessage),
                new SqlParameter("@HIS_RV", DateTime.Now.ToString("ddMMyyyyHHmmss", CultureInfo.GetCultureInfo("th-TH")))};

			return Execute(query);
		}

		public bool editDataResultExam(DataRow data, DataRow[] addendum)
		{
			string accession_no = data["ACCESSION_NO"].ToString();

			DateTime dt_result_on = Utilities.ToDateTime(data["RESULT_ON"]);

			if (addendum.Length > 0)
			{
				DateTime dt_note_on = Utilities.ToDateTime(addendum[0]["NOTE_ON"]);

				if (dt_result_on < dt_note_on)
					dt_result_on = dt_note_on;
			}

			if (string.IsNullOrEmpty(accession_no)) return false;

			string query = @"
SET NOCOUNT ON

select
    ACCESSION_NO
from
    RIS_RESULT
where
    ACCESSION_NO = @ACCESSION_NO";

			Parameters = new DbParameter[] { new SqlParameter("@ACCESSION_NO", accession_no) };

			if (Utilities.HasData(SelectData(query)))
			{
				#region query update
				query = @"
update
	RIS_RESULT
set
	HN = @HN,
	REQUESTNO = @REQUESTNO,
	RAD_CODE = @RAD_CODE,
	RAD_SALUTATION = @RAD_SALUTATION,
	RAD_FNAME = @RAD_FNAME,
	RAD_LNAME = @RAD_LNAME,
	RESULT_STATUS = @RESULT_STATUS,
	RESULT_TEXT_RTF = @RESULT_TEXT_RTF,
	SEVERITY_CODE = @SEVERITY_CODE,
	RESULT_ON = @RESULT_ON,
	HIS_SYNC = 0,
	HIS_MESSAGE = NULL,
	HIS_ON = @HIS_ON
where
	ACCESSION_NO = @ACCESSION_NO";
				#endregion
			}
			else
			{
				#region query insert
				query = @"
insert into RIS_RESULT
(
	HN,
	REQUESTNO,
	ACCESSION_NO,
	RAD_CODE,
	RAD_SALUTATION,
	RAD_FNAME,
	RAD_LNAME,
	RESULT_STATUS,
	RESULT_TEXT_RTF,
	RESULT_ON,
	SEVERITY_CODE,
	HIS_SYNC,
	HIS_MESSAGE,
	HIS_ON
)
values
(
	@HN,
	@REQUESTNO,
	@ACCESSION_NO,
	@RAD_CODE,
	@RAD_SALUTATION,
	@RAD_FNAME,
	@RAD_LNAME,
	@RESULT_STATUS,
	@RESULT_TEXT_RTF,
	@RESULT_ON,
	@SEVERITY_CODE,
	'0',
	NULL,
	@HIS_ON
)";
				#endregion
			}

			Parameters = new DbParameter[] {
				new SqlParameter("@HN", data["HN"].ToString()),
				new SqlParameter("@REQUESTNO", data["REQUESTNO"].ToString()),
				new SqlParameter("@ACCESSION_NO", data["ACCESSION_NO"].ToString()),
				new SqlParameter("@RAD_CODE", data["RAD_UID"].ToString()),
				new SqlParameter("@RAD_SALUTATION", data["RAD_SALUTATION"].ToString()),
				new SqlParameter("@RAD_FNAME", data["RAD_FNAME"].ToString()),
				new SqlParameter("@RAD_LNAME", data["RAD_LNAME"].ToString()),
				new SqlParameter("@RESULT_STATUS", data["RESULT_STATUS"].ToString()),
				new SqlParameter("@RESULT_TEXT_RTF", data["RESULT_TEXT_RTF"].ToString()),
				new SqlParameter("@SEVERITY_CODE", data["SEVERITY_UID"].ToString()),
				new SqlParameter("@RESULT_ON", dt_result_on.ToString("ddMMyyyyHHmmss", CultureInfo.GetCultureInfo("th-TH"))),
                new SqlParameter("@HIS_ON", DateTime.Now.ToString("ddMMyyyyHHmmss", CultureInfo.GetCultureInfo("th-TH")))};

			return Execute(query);
		}

		private static string PrepareResultHtml(string resultHTML, DataRow[] addendum)
		{
			string result = string.Empty;

			if (Utilities.HasData(addendum))
			{
				int length = addendum.Length;
				int counter = 0;

				result = string.Empty;

				result += @"<font face='Microsoft Sans Serif' size='3' color='white'>";

				for (int i = 0; i < length; length--)
				{
					DataRow dr = addendum[counter++];

					result += string.Format("Addendum {0} ", length.ToString());
					result += string.Format("Written By {0} ", dr["Radiologist"].ToString());
					result += string.Format("Date {0:dd/MM/yyyy HH:mm}", Convert.ToDateTime(dr["NOTE_ON"]));
					result += @" <br> ";
					result += dr["RESULT_TEXT"].ToString();
					result += @" <br> ";
					result += @" <br> ";
				}

				result += @" <br> ";
				result += @"-------------------------";
				result += @" <br> ";
				result += @" <br> ";
				result += @" <br> ";
				result += @"</font>";
			}

			result += resultHTML;

			return result.Replace("\r\n", " <br> ").Replace("\n", " <br> ").Replace("\r", " <br> ");
		}
		private static string PrepareResultPlain(string resultPlain, DataRow[] addendum)
		{
			string result = string.Empty;

			if (Utilities.HasData(addendum))
			{
				int length = addendum.Length;
				int counter = 0;

				result = string.Empty;

				for (int i = 0; i < length; length--)
				{
					DataRow dr = addendum[counter++];

					result += string.Format("Addendum {0} ", length.ToString());
					result += string.Format("Written By {0} ", dr["Radiologist"].ToString());
					result += string.Format("Date {0:dd/MM/yyyy HH:mm}", Convert.ToDateTime(dr["NOTE_ON"]));
					result += "\r\n";
					result += dr["RESULT_TEXT"].ToString();
					result += "\r\n";
					result += "\r\n";
				}

				result += "\r\n";
				result += "-------------------------";
				result += "\r\n";
				result += "\r\n";
				result += "\r\n";
			}

			result += resultPlain;

			return result;
		}
	}
}