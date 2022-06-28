using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISCommentsystemAlertInsertData : DataAccessBase
    {
        public RIS_COMMENTSYSTEMALERT RIS_COMMENTSYSTEMALERT { get; set; }

        public RISCommentsystemAlertInsertData()
        {
            RIS_COMMENTSYSTEMALERT = new RIS_COMMENTSYSTEMALERT();
        }

        public void Add()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMALERT_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@COMMENT_ID"	, RIS_COMMENTSYSTEMALERT.COMMENT_ID ) ,
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMALERT.READER_ID ) ,
                Parameter( "@CREATED_BY"	, RIS_COMMENTSYSTEMALERT.CREATED_BY ) ,
                Parameter( "@EXAM_ID"	, RIS_COMMENTSYSTEMALERT.EXAM_ID ) ,
                Parameter( "@SCHEDULE_ID"	, RIS_COMMENTSYSTEMALERT.SCHEDULE_ID ) ,
                Parameter( "@XRAYREQ_ID"	, RIS_COMMENTSYSTEMALERT.XRAYREQ_ID ) ,
                Parameter( "@ACCESSION_NO"	, RIS_COMMENTSYSTEMALERT.ACCESSION_NO ) ,
            };
            return parameters;
        }
        public void AddByAccession()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMALERT_InsertByAccession;
            ParameterList = buildParameterByAccession();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterByAccession()
        {
            DbParameter[] parameters ={
                Parameter( "@COMMENT_ID"	, RIS_COMMENTSYSTEMALERT.COMMENT_ID ) ,
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMALERT.READER_ID ) ,
                Parameter( "@CREATED_BY"	, RIS_COMMENTSYSTEMALERT.CREATED_BY ) ,
                Parameter( "@EXAM_ID"	, RIS_COMMENTSYSTEMALERT.EXAM_ID ) ,
                Parameter( "@ACCESSION_NO"	, RIS_COMMENTSYSTEMALERT.ACCESSION_NO ) ,
            };
            return parameters;
        }
        public void AddBySchedule()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMALERT_InsertBySchedule;
            ParameterList = buildParameterBySchedule();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterBySchedule()
        {
            DbParameter[] parameters ={
                Parameter( "@COMMENT_ID"	, RIS_COMMENTSYSTEMALERT.COMMENT_ID ) ,
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMALERT.READER_ID ) ,
                Parameter( "@CREATED_BY"	, RIS_COMMENTSYSTEMALERT.CREATED_BY ) ,
                Parameter( "@EXAM_ID"	, RIS_COMMENTSYSTEMALERT.EXAM_ID ) ,
                Parameter( "@SCHEDULE_ID"	, RIS_COMMENTSYSTEMALERT.SCHEDULE_ID ) ,
            };
            return parameters;
        }
        public void AddByXrayreq()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMALERT_InsertByXrayreq;
            ParameterList = buildParameterByXrayreq();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterByXrayreq()
        {
            DbParameter[] parameters ={
                Parameter( "@COMMENT_ID"	, RIS_COMMENTSYSTEMALERT.COMMENT_ID ) ,
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMALERT.READER_ID ) ,
                Parameter( "@CREATED_BY"	, RIS_COMMENTSYSTEMALERT.CREATED_BY ) ,
                Parameter( "@EXAM_ID"	, RIS_COMMENTSYSTEMALERT.EXAM_ID ) ,
                Parameter( "@XRAYREQ_ID"	, RIS_COMMENTSYSTEMALERT.XRAYREQ_ID ) ,
            };
            return parameters;
        }
    }
}
