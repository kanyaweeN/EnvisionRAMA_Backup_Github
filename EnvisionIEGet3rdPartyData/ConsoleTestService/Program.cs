using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml;
using EnvisionInterfaceEngine.Common;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Common.Miracle;
using EnvisionInterfaceEngine.Connection;
using EnvisionInterfaceEngine.Operational;
using EnvisionInterfaceEngine.Operational.HL7;
using EnvisionInterfaceEngine.WebService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using EnvisionInterfaceEngine.Connection.Engine;
using System.Data.Odbc;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ConsoleTestService
{
	static class Program
	{
		static void Main()
		{
			string message = HL7Manager.cleanHL7Text(@"");

			object[] result = HL7Manager.ConvertHL7ToObject(message);
			
			while (Console.ReadKey().Key != ConsoleKey.Escape) { };
		}
		static void MainFixHIS2000Result()
		{
			RISConnection ris = new RISConnection("server=.; database=RIS_PCMC_Fix; User ID=sa; Password=mira001;");
			DataTable ris_dtt_order = ris.SelectData(@"select ord.ACCESSION_NO from _fix_his_order ord left join _fix_his_result result on ord.ACCESSION_NO = result.ACCESSION_NO where result.ACCESSION_NO is null");

			ODBCEngine sybase = new ODBCEngine();
			sybase.Connection = new ODBCEngine("dsn=his2000").Connection;
			sybase.Error += new ODBCEventHandlerError(ODBCEngine_Error);

			foreach (DataRow row in ris_dtt_order.Rows)
			{
				DataTable his_dtt_result = sybase.SelectData(@"
select
    a.editdatetime as RESULT_NO,
	a.report as RESULT_TEXT,
	a.result as SEVERITY,
    a.specialistid as RAD_ID
from
    filler a
    inner join filleritem b
            on a.id = b.fillerid
where
    b.orderid = " + row["ACCESSION_NO"].ToString());

				if (Utilities.HasData(his_dtt_result))
				{
					ris.Parameters = new DbParameter[] {
                        new SqlParameter("@ACCESSION_NO", row["ACCESSION_NO"].ToString()),
                        new SqlParameter("@RESULT_ON", Utilities.ToDateTime(his_dtt_result.Rows[0]["RESULT_NO"])),
                        new SqlParameter("@RESULT_TEXT", his_dtt_result.Rows[0]["RESULT_TEXT"].ToString()),
                        new SqlParameter("@RAD_ID", Utilities.ToInt(his_dtt_result.Rows[0]["RAD_ID"].ToString())),
                        new SqlParameter("@SEVERITY", his_dtt_result.Rows[0]["SEVERITY"].ToString())};
				}
				else
				{
					ris.Parameters = new DbParameter[] {
                        new SqlParameter("@ACCESSION_NO", row["ACCESSION_NO"].ToString()),
                        new SqlParameter("@RESULT_ON", DBNull.Value),
                        new SqlParameter("@RESULT_TEXT", DBNull.Value),
                        new SqlParameter("@RAD_ID", DBNull.Value),
                        new SqlParameter("@SEVERITY", DBNull.Value)};
				}

				ris.Execute(@"
insert into _fix_his_result
(
    ACCESSION_NO,
    RESULT_ON,
    RESULT_TEXT,
    RAD_ID,
    SEVERITY
)
values
(
    @ACCESSION_NO,
    @RESULT_ON,
    @RESULT_TEXT,
    @RAD_ID,
    @SEVERITY
)");
			}
		}
		static void MainFixHIS2000Patient()
		{
			ODBCEngine sybase = new ODBCEngine();
			sybase.Connection = new ODBCEngine("dsn=his2000").Connection;
			sybase.Error += new ODBCEventHandlerError(ODBCEngine_Error);

			RISConnection ris = new RISConnection("server=.; database=RIS_PCMC_Fix; User ID=sa; Password=mira001;");
			DataTable ris_dtt_patient = ris.SelectData("select * from his_patient where PATIENT_TITLE is null");

			Console.WriteLine(ris_dtt_patient.Rows.Count.ToString());

			#region his query patient
			string his_query_patient = @"
select
	salutation.longdesc as PATIENT_TITLE,
	pat.firstname as PATIENT_FNAME,
	pat.lastname as PATIENT_LNAME,
	pat.otherno as PATIENT_SSN,
	pat.birthdate as PATIENT_DOB,
	pat.gender as PATIENT_GENDER,
	pataddr.phone as PATIENT_PHONE1,
	pataddr.mobile as PATIENT_PHONE2,
	patcoverage.coveragetypeid as INSURANCE_TYPE_UID,
	coveragetype.coveragetypedesc as INSURANCE_TYPE_DESC,
	patreg.patregno as ADMISSION_NO,
	patreg.meansno as PAT_STATUS,
	patreg.progno as REF_UNIT_UID,
	prog.progdesc as REF_UNIT_NAME,
	phys.practno as REF_DOC_UID,
	person.salutation as REF_DOC_TITLE,
	person.firstname as REF_DOC_FNAME,
	person.lastname as REF_DOC_LNAME
from
	pat
	left outer join pataddr
			on pat.masterno = pataddr.masterno
		left outer join lookup salutation
				on pat.salutation = salutation.shortdesc
		left outer join patcoverage
				on pat.masterno = patcoverage.masterno
			left outer join coveragetype
					on patcoverage.coveragetypeid = coveragetype.coveragetypeid
	left outer join patreg
			on pat.masterno = patreg.masterno
		left outer join prog
				on patreg.progno = prog.progno
		left outer join phys
				on phys.personid = ISNULL(patreg.responsibleproviderid, 600)
			left outer join person
					on phys.personid = person.personid
where
	pataddr.status_type = '1'
	and salutation.type = 'salutation'
	and patcoverage.default_patc = '1'
	and pat.masterno = {0}
	and patreg.patregid = {1}";
			#endregion

			int loop_index_running = 0;

			foreach (DataRow row in ris_dtt_patient.Rows)
			{
				loop_index_running += 1;

				string ris_hn = row["HN"].ToString();
				string ris_visit_no = row["VISIT_NO"].ToString();

				DataTable his_dtt_patient = sybase.SelectData(string.Format(his_query_patient, ris_hn, ris_visit_no));

				if (!Utilities.HasData(his_dtt_patient))
				{
					Console.WriteLine(loop_index_running.ToString() + "Skip");

					continue;
				}

				ris.Parameters = new DbParameter[] {
                    new SqlParameter("@HN", ris_hn),
                    new SqlParameter("@VISIT_NO", ris_visit_no),
                    new SqlParameter("@PATIENT_TITLE", Utilities.ToCleanString(his_dtt_patient.Rows[0]["PATIENT_TITLE"])),
                    new SqlParameter("@PATIENT_FNAME", Utilities.ToCleanString(his_dtt_patient.Rows[0]["PATIENT_FNAME"])),
                    new SqlParameter("@PATIENT_LNAME", Utilities.ToCleanString(his_dtt_patient.Rows[0]["PATIENT_LNAME"])),
                    new SqlParameter("@PATIENT_SSN", Utilities.ToCleanString(his_dtt_patient.Rows[0]["PATIENT_SSN"])),
                    new SqlParameter("@PATIENT_DOB", Utilities.ToDateTime(his_dtt_patient.Rows[0]["PATIENT_DOB"]).ToString("yyyy-MM-dd")),
                    new SqlParameter("@PATIENT_GENDER", Utilities.ToCleanString(his_dtt_patient.Rows[0]["PATIENT_GENDER"])),
                    new SqlParameter("@PATIENT_PHONE1", Utilities.ToCleanString(his_dtt_patient.Rows[0]["PATIENT_PHONE1"])),
                    new SqlParameter("@PATIENT_PHONE2", Utilities.ToCleanString(his_dtt_patient.Rows[0]["PATIENT_PHONE2"])),
                    new SqlParameter("@INSURANCE_TYPE_UID", Utilities.ToCleanString(his_dtt_patient.Rows[0]["INSURANCE_TYPE_UID"])),
                    new SqlParameter("@INSURANCE_TYPE_DESC", Utilities.ToCleanString(his_dtt_patient.Rows[0]["INSURANCE_TYPE_DESC"])),
                    new SqlParameter("@ADMISSION_NO", Utilities.ToCleanString(his_dtt_patient.Rows[0]["ADMISSION_NO"])),
                    new SqlParameter("@PAT_STATUS", Utilities.ToCleanString(his_dtt_patient.Rows[0]["PAT_STATUS"])),
                    new SqlParameter("@REF_UNIT_UID", Utilities.ToCleanString(his_dtt_patient.Rows[0]["REF_UNIT_UID"])),
                    new SqlParameter("@REF_UNIT_NAME", Utilities.ToCleanString(his_dtt_patient.Rows[0]["REF_UNIT_NAME"])),
                    new SqlParameter("@REF_DOC_UID", Utilities.ToCleanString(his_dtt_patient.Rows[0]["REF_DOC_UID"])),
                    new SqlParameter("@REF_DOC_TITLE", Utilities.ToCleanString(his_dtt_patient.Rows[0]["REF_DOC_TITLE"])),
                    new SqlParameter("@REF_DOC_FNAME", Utilities.ToCleanString(his_dtt_patient.Rows[0]["REF_DOC_FNAME"])),
                    new SqlParameter("@REF_DOC_LNAME", Utilities.ToCleanString(his_dtt_patient.Rows[0]["REF_DOC_LNAME"]))};

				ris.Execute(@"
update
    his_patient
set
    PATIENT_TITLE = @PATIENT_TITLE,
    PATIENT_FNAME = @PATIENT_FNAME,
    PATIENT_LNAME = @PATIENT_LNAME,
    PATIENT_SSN = @PATIENT_SSN,
    PATIENT_DOB = @PATIENT_DOB,
    PATIENT_GENDER = @PATIENT_GENDER,
    PATIENT_PHONE1 = @PATIENT_PHONE1,
    PATIENT_PHONE2 = @PATIENT_PHONE2,
    INSURANCE_TYPE_UID = @INSURANCE_TYPE_UID,
    INSURANCE_TYPE_DESC = @INSURANCE_TYPE_DESC,
    ADMISSION_NO = @ADMISSION_NO,
    PAT_STATUS = @PAT_STATUS,
    REF_UNIT_UID = @REF_UNIT_UID,
    REF_UNIT_NAME = @REF_UNIT_NAME,
    REF_DOC_UID = @REF_DOC_UID,
    REF_DOC_TITLE = @REF_DOC_TITLE,
    REF_DOC_FNAME = @REF_DOC_FNAME,
    REF_DOC_LNAME = @REF_DOC_LNAME
where
    HN = @HN
    and VISIT_NO = @VISIT_NO");

				Console.WriteLine(loop_index_running.ToString() + "Added");
			}

			Console.WriteLine("Finish");
			Console.ReadKey();
		}
		static void MainFixHIS2000Order()
		{
			ODBCEngine sybase = new ODBCEngine();
			sybase.Connection = new ODBCEngine("dsn=his2000").Connection;
			sybase.Error += new ODBCEventHandlerError(ODBCEngine_Error);

			string query = @"
select
	ord.id as order_id,
	ord.masterno,
	ord.patregid,
	ord.orderedbypersonid,
	ord.orderdatetime,
	ord.orderstatusid,
	ord.servicecatid,
	ord.flag_print,
	ords.id as orderitem_id,
	ords.orderid,
	ords.servicecatalogitemid,
	ords.servicetyeid,
	ords.digroupid,
	ords.scheduleddatetime,
	ords.editdatetime,
	ords.orderpriorityid,
	ords.orderstatusid,
	ords.patcoverageid,
	ords.qty,
	ords.price,
	ords.discount_coverage,
	ords.charge,
	ords.rqty,
	ords.specimentypeid,
	ords.servicelocationid,
	ords.cancel_flag,
	ords.cov_cancel,
	ords.copay
from
	""order"" ord
	inner join orderitem ords
			on ord.id = ords.orderid
where
	ord.orderdatetime > '2013-06-03'
	and ord.orderdatetime < '2013-06-04'
	and ords.servicelocationid = 193";

			DataTable dtt = sybase.SelectData(query);
			Console.WriteLine(dtt.Rows.Count.ToString());

			#region ris query
			string ris_query = @"
insert into his_order
(
    order_id,
    masterno,
    patregid,
    orderedbypersonid,
    orderdatetime,
    orderstatusid,
    servicecatid,
    flag_print,
    orderitem_id,
    servicecatalogitemid,
    servicetyeid,
    digroupid,
    scheduleddatetime,
    editdatetime,
    orderpriorityid,
    patcoverageid,
    qty,
    price,
    discount_coverage,
    charge,
    rqty,
    specimentypeid,
    servicelocationid,
    cancel_flag,
    cov_cancel,
    copay
)
values
(
    @order_id,
    @masterno,
    @patregid,
    @orderedbypersonid,
    @orderdatetime,
    @orderstatusid,
    @servicecatid,
    @flag_print,
    @orderitem_id,
    @servicecatalogitemid,
    @servicetyeid,
    @digroupid,
    @scheduleddatetime,
    @editdatetime,
    @orderpriorityid,
    @patcoverageid,
    @qty,
    @price,
    @discount_coverage,
    @charge,
    @rqty,
    @specimentypeid,
    @servicelocationid,
    @cancel_flag,
    @cov_cancel,
    @copay
)";
			#endregion
			RISConnection ris = new RISConnection("server=.; database=RIS_PCMC_Fix; User ID=sa; Password=mira001;");

			foreach (DataRow row in dtt.Rows)
			{
				ris.Parameters = new DbParameter[] {
                    new SqlParameter("@order_id", row["order_id"].ToString()),
                    new SqlParameter("@masterno", row["masterno"].ToString()),
                    new SqlParameter("@patregid", row["patregid"].ToString()),
                    new SqlParameter("@orderedbypersonid", row["orderedbypersonid"].ToString()),
                    new SqlParameter("@orderdatetime", row["orderdatetime"].ToString()),
                    new SqlParameter("@orderstatusid", row["orderstatusid"].ToString()),
                    new SqlParameter("@servicecatid", row["servicecatid"].ToString()),
                    new SqlParameter("@flag_print", row["flag_print"].ToString()),
                    new SqlParameter("@orderitem_id", row["orderitem_id"].ToString()),
                    new SqlParameter("@servicecatalogitemid", row["servicecatalogitemid"].ToString()),
                    new SqlParameter("@servicetyeid", row["servicetyeid"].ToString()),
                    new SqlParameter("@digroupid", row["digroupid"].ToString()),
                    new SqlParameter("@scheduleddatetime", row["scheduleddatetime"].ToString()),
                    new SqlParameter("@editdatetime", row["editdatetime"].ToString()),
                    new SqlParameter("@orderpriorityid", row["orderpriorityid"].ToString()),
                    new SqlParameter("@patcoverageid", row["patcoverageid"].ToString()),
                    new SqlParameter("@qty", row["qty"].ToString()),
                    new SqlParameter("@price", row["price"].ToString()),
                    new SqlParameter("@discount_coverage", row["discount_coverage"].ToString()),
                    new SqlParameter("@charge", row["charge"].ToString()),
                    new SqlParameter("@rqty", row["rqty"].ToString()),
                    new SqlParameter("@specimentypeid", row["specimentypeid"].ToString()),
                    new SqlParameter("@servicelocationid", row["servicelocationid"].ToString()),
                    new SqlParameter("@cancel_flag", row["cancel_flag"].ToString()),
                    new SqlParameter("@cov_cancel", row["cov_cancel"].ToString()),
                    new SqlParameter("@copay", row["copay"].ToString())};

				ris.Execute(ris_query);
			}

			Console.WriteLine("Finish");
			Console.ReadKey();
		}

		static void ODBCEngine_Error(OdbcException e)
		{
			throw e;
		}

		static string getHL7ORM()
		{
			HL7ORM hl7_orm = new HL7ORM();

			hl7_orm.MSH.MESSAGE_CONTROL_ID = DateTime.Now.ToString("yyyyMMddHHmmssffff");

			hl7_orm.ORDER_CONTROL = "NW";
			hl7_orm.ORG.ORG_ALIAS = "JMY Hospital";

			hl7_orm.PATIENT.HN = "JMY001";
			hl7_orm.PATIENT.HIS_HN = "JMY001";
			hl7_orm.PATIENT.TITLE = "คำนำหน้า";
			hl7_orm.PATIENT.FNAME = "ชื่อ";
			hl7_orm.PATIENT.LNAME = "นามสกุล";
			hl7_orm.PATIENT.TITLE_ENG = "TitleName";
			hl7_orm.PATIENT.FNAME_ENG = "FirstName";
			hl7_orm.PATIENT.LNAME_ENG = "LastName";
			hl7_orm.PATIENT.GENDER = 'M';
			hl7_orm.PATIENT.DOB = Convert.ToDateTime("2001-12-30");
			hl7_orm.PATIENT.SSN = "1234567890123";
			hl7_orm.PATIENT.ADDR1 = "Thailand";
			hl7_orm.PATIENT.PHONE1 = "028888888";
			hl7_orm.PATIENT.PHONE2 = "0888888888";

			hl7_orm.ORDER.ADMISSION_NO = string.Empty;
			hl7_orm.ORDER.REQUESTNO = string.Empty;
			hl7_orm.ORDER.CLINICAL_INSTRUCTION = "ทดสอบ <br> ว่ะฮ่าๆ";

			hl7_orm.REFERENCE_UNIT.UNIT_UID = string.Empty;
			hl7_orm.REFERENCE_UNIT.UNIT_NAME = string.Empty;

			hl7_orm.REFERRING_DOCTOR.EMP_UID = string.Empty;
			hl7_orm.REFERRING_DOCTOR.SALUTATION = string.Empty;
			hl7_orm.REFERRING_DOCTOR.FNAME = string.Empty;
			hl7_orm.REFERRING_DOCTOR.LNAME = string.Empty;
			hl7_orm.REFERRING_DOCTOR.TITLE_ENG = string.Empty;
			hl7_orm.REFERRING_DOCTOR.FNAME_ENG = string.Empty;
			hl7_orm.REFERRING_DOCTOR.LNAME_ENG = string.Empty;

			hl7_orm.ORDER_DETAIL.ACCESSION_NO = "20121212TEST01";
			hl7_orm.ORDER_DETAIL.INSTANCE_UID = string.Empty;
			hl7_orm.ORDER_DETAIL.PRIORITY = 'R';

			hl7_orm.EXAM.EXAM_UID = "EXAM01";
			hl7_orm.EXAM.EXAM_NAME = "EXAM_TEST01";

			hl7_orm.MODALITYTYPE.TYPE_NAME_ALIAS = "CR";

			//hl7_orm.ASSIGNED_TO.EMP_UID = data["ASSIGNED_TO_UID",.ToString();
			//hl7_orm.ASSIGNED_TO.SALUTATION = data["ASSIGNED_TO_SALUTATION",.ToString();
			//hl7_orm.ASSIGNED_TO.FNAME = data["ASSIGNED_TO_FNAME",.ToString();
			//hl7_orm.ASSIGNED_TO.LNAME = data["ASSIGNED_TO_LNAME",.ToString();
			//hl7_orm.ASSIGNED_TO.TITLE_ENG = data["ASSIGNED_TO_TITLE_ENG",.ToString();
			//hl7_orm.ASSIGNED_TO.FNAME_ENG = data["ASSIGNED_TO_FNAME_ENG",.ToString();
			//hl7_orm.ASSIGNED_TO.LNAME_ENG = data["ASSIGNED_TO_LNAME_ENG",.ToString();

			//hl7_orm.LAST_MODIFIED.EMP_UID = data["LAST_MODIFIED_UID",.ToString();
			//hl7_orm.LAST_MODIFIED.SALUTATION = data["LAST_MODIFIED_SALUTATION",.ToString();
			//hl7_orm.LAST_MODIFIED.FNAME = data["LAST_MODIFIED_FNAME",.ToString();
			//hl7_orm.LAST_MODIFIED.LNAME = data["LAST_MODIFIED_LNAME",.ToString();


			return GenerateORM.GenerateHL7(hl7_orm);
		}

	}
}