using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using EnvisionInterfaceEngine.Common.Global;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionInterfaceEngine.Connection
{
    public class SSBFreelancerConnection : MsSqlEngine
    {
        public SSBFreelancerConnection() : base() { ConnectionString = Config.ConnectionString; }
        public SSBFreelancerConnection(string connectionString) : base(connectionString) { }
        ~SSBFreelancerConnection() { base.Dispose(); }

        public DataTable selectDataPatient()
        {
            string query = @"
select top 10
    *
from
    ADT
where
    HIS_SYNC = 'N'";

            Parameters = null;

            return SelectData(query);
        }
        public DataTable selectDataOrder()
        {
            string query = @"
select
    *
from
    ORM
where
    HIS_SYNC = 'N'
	and LEN(ACCESSION_NO) < 17";

            Parameters = null;

            return SelectData(query);
        }

        public bool updateFlagPatient(string hisHn, DateTime updateDateTime, bool flag, string message)
        {
            string query = @"
update
    ADT
set
    HIS_SYNC = @HIS_SYNC,
    HIS_MESSAGE = @HIS_MESSAGE
where
    HN = @HN
    and UpdateDateTime = @UpdateDateTime";

            Parameters = new DbParameter[] {
                new SqlParameter("@HN", hisHn),
                new SqlParameter("@UpdateDateTime", updateDateTime),
                new SqlParameter("@HIS_SYNC", flag ? "Y" : "N"),
                new SqlParameter("@HIS_MESSAGE", message)
            };

            return Execute(query);
        }
        public bool updateFlagOrder(string qNo, DateTime updateDateTime, bool flag, string message)
        {
            string query = @"
update
    ORM
set
    HIS_SYNC = @HIS_SYNC,
    HIS_MESSAGE = @HIS_MESSAGE
where
    ACCESSION_NO = @ACCESSION_NO
    and UpdateDateTime = @UpdateDateTime";

            Parameters = new DbParameter[] {
                new SqlParameter("@ACCESSION_NO", qNo),
                new SqlParameter("@UpdateDateTime", updateDateTime),
                new SqlParameter("@HIS_SYNC", flag ? "Y" : "N"),
                new SqlParameter("@HIS_MESSAGE", message)
            };

            return  Execute(query);
        }

        public bool editDataResultExam(string orgAlias, string hisHn, string requestNo, string qNo, string examUid, string resultText, string resultStatus, string radUid, string radSalutation, string radFName, string radLName, string radTitleEng, string radFNameEng, string radLNameEng, DateTime resultOn)
        {
            string query = @"
select
    ACCESSION_NO
from
    ORU
where
    ACCESSION_NO = @ACCESSION_NO";

            Parameters = new DbParameter[] {
                new SqlParameter("@ACCESSION_NO", qNo)
            };

            if (Utilities.HasData(SelectData(query)))
            {
                #region query update
                query = @"
update
    ORU
set
    SITE_NO = @SITE_NO,
    HN = @HN,
    REQUESTNO = @REQUESTNO,
    EXAM_CODE = @EXAM_CODE,
    RESULT_TEXT_PLAIN = @RESULT_TEXT_PLAIN,
    RESULT_STATUS = @RESULT_STATUS,
    RAD_CODE = @RAD_CODE,
    RAD_SALUTATION = @RAD_SALUTATION,
    RAD_FNAME = @RAD_FNAME,
    RAD_LNAME = @RAD_LNAME,
    RAD_TITLE_ENG = @RAD_TITLE_ENG,
    RAD_FNAME_ENG = @RAD_FNAME_ENG,
    RAD_LNAME_ENG = @RAD_LNAME_ENG,
    RESULT_ON = @RESULT_ON,
    HIS_SYNC = 'N',
    HIS_ON = GETDATE()
where
    ACCESSION_NO = @ACCESSION_NO";
                #endregion
            }
            else
            {
                #region query insert
                query = @"
insert into ORU
(
    SITE_NO,
    HN,
    REQUESTNO,
    ACCESSION_NO,
    EXAM_CODE,
    RESULT_TEXT_PLAIN,
    RESULT_STATUS,
    RAD_CODE,
    RAD_SALUTATION,
    RAD_FNAME,
    RAD_LNAME,
    RAD_TITLE_ENG,
    RAD_FNAME_ENG,
    RAD_LNAME_ENG,
    RESULT_ON,
    HIS_SYNC,
    HIS_ON
)
values
(
    @SITE_NO,
    @HN,
    @REQUESTNO,
    @ACCESSION_NO,
    @EXAM_CODE,
    @RESULT_TEXT_PLAIN,
    @RESULT_STATUS,
    @RAD_CODE,
    @RAD_SALUTATION,
    @RAD_FNAME,
    @RAD_LNAME,
    @RAD_TITLE_ENG,
    @RAD_FNAME_ENG,
    @RAD_LNAME_ENG,
    @RESULT_ON,
    'N',
    GETDATE()
)";
                #endregion
            }

            Parameters = new DbParameter[] {
                new SqlParameter("@SITE_NO", orgAlias),
                new SqlParameter("@HN", hisHn),
                new SqlParameter("@REQUESTNO", requestNo),
                new SqlParameter("@ACCESSION_NO", qNo),
                new SqlParameter("@EXAM_CODE", examUid),
                new SqlParameter("@RESULT_TEXT_PLAIN", resultText),
                new SqlParameter("@RESULT_STATUS", resultStatus),
                new SqlParameter("@RAD_CODE", radUid),
                new SqlParameter("@RAD_SALUTATION", radSalutation),
                new SqlParameter("@RAD_FNAME", radFName),
                new SqlParameter("@RAD_LNAME", radLName),
                new SqlParameter("@RAD_TITLE_ENG", radTitleEng),
                new SqlParameter("@RAD_FNAME_ENG", radFNameEng),
                new SqlParameter("@RAD_LNAME_ENG", radLNameEng),
                new SqlParameter("@RESULT_ON", resultOn),
            };

            return Execute(query);
        }
    }
}