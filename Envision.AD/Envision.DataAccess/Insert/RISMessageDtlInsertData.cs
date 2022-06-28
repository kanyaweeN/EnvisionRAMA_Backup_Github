using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class RISCommentSystemDtlInsertData : DataAccessBase
    {
        public RIS_COMMENTSYSTEMDTL RIS_COMMENTSYSTEMDTL { get; set; }
        public RISCommentSystemDtlInsertData()
        {
            RIS_COMMENTSYSTEMDTL = new RIS_COMMENTSYSTEMDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMDTL_Insert_Reader;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMDTL.READER_ID ) ,
                Parameter( "@COMMENT_ID"	, RIS_COMMENTSYSTEMDTL.COMMENT_ID ) ,
            };
            return parameters;
        }

        public void AddByAccession()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMDTL_Insert_ReaderByAccession;
            ParameterList = buildParameterByAccession();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterByAccession()
        {
            DbParameter[] parameters ={
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMDTL.READER_ID ) ,
                Parameter( "@COMMENT_ID"	, RIS_COMMENTSYSTEMDTL.COMMENT_ID ) ,
                Parameter( "@ACCESSION_NO"	, RIS_COMMENTSYSTEMDTL.ACCESSION_NO ) ,
            };
            return parameters;
        }
        public void AddBySchedule()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMDTL_Insert_ReaderBySchedule;
            ParameterList = buildParameterBySchedule();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterBySchedule()
        {
            DbParameter[] parameters ={
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMDTL.READER_ID ) ,
                Parameter( "@COMMENT_ID"	, RIS_COMMENTSYSTEMDTL.COMMENT_ID ) ,
                Parameter( "@SCHEDULE_ID"	, RIS_COMMENTSYSTEMDTL.SCHEDULE_ID ) ,
            };
            return parameters;
        }
        public void AddByXrayreq()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMDTL_Insert_ReaderByXrayreq;
            ParameterList = buildParameterByXrayreq();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterByXrayreq()
        {
            DbParameter[] parameters ={
                Parameter( "@READER_ID"	, RIS_COMMENTSYSTEMDTL.READER_ID ) ,
                Parameter( "@COMMENT_ID"	, RIS_COMMENTSYSTEMDTL.COMMENT_ID ) ,
                Parameter( "@XRAYREQ_ID"	, RIS_COMMENTSYSTEMDTL.XRAYREQ_ID ) ,
            };
            return parameters;
        }
    }
}
