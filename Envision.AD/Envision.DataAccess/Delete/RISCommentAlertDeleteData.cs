using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RISCommentAlertDeleteData : DataAccessBase
    {
        public RIS_COMMENTSYSTEMALERT RIS_COMMENTSYSTEMALERT { get; set; }

        public RISCommentAlertDeleteData()
        {
            RIS_COMMENTSYSTEMALERT = new RIS_COMMENTSYSTEMALERT();
        }

        public void Delete()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMALERT_Delete;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        public void DeleteByScheduleId()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMALERT_DeleteByScheduleId;
            ParameterList = buildParameterForDeleteByScheduleId();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMALERT.READER_ID ) ,
                Parameter( "@ACCESSION_NO"	, RIS_COMMENTSYSTEMALERT.ACCESSION_NO ) ,
            };
            return parameters;
        }

        private DbParameter[] buildParameterForDeleteByScheduleId()
        {
            DbParameter[] parameters ={
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMALERT.READER_ID ) ,
                Parameter( "@SCHEDULE_ID"	, RIS_COMMENTSYSTEMALERT.SCHEDULE_ID ) ,
            };
            return parameters;
        }
    }
}
