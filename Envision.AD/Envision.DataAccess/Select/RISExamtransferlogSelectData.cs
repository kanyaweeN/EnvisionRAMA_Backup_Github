using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISExamtransferlogSelectData : DataAccessBase
    {
        public RIS_EXAMTRANSFERLOG RIS_EXAMTRANSFERLOG { get; set; }
        public RISExamtransferlogSelectData()
        {
            RIS_EXAMTRANSFERLOG = new RIS_EXAMTRANSFERLOG();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMTRANSFERLOG_Select;
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { Parameter("@USER_ID",RIS_EXAMTRANSFERLOG.CREATED_BY),
                                       };
            return parameters;
        }
        public DataSet getTransferByAccession()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMTRANSFERLOG_SelectByAccession;
            DataSet ds = new DataSet();
            ParameterList = buildParameterTransferByAccession();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterTransferByAccession()
        {
            DbParameter[] parameters = { Parameter("@ACCESSION_NO",RIS_EXAMTRANSFERLOG.ACCESSION_NO),
                                       };
            return parameters;
        }
        public DataSet getTransferByHN()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMTRANSFERLOG_SelectByHN;
            DataSet ds = new DataSet();
            ParameterList = buildParameterTransferByHN();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterTransferByHN()
        {
            DbParameter[] parameters = { Parameter("@HN",RIS_EXAMTRANSFERLOG.HN),
                                       };
            return parameters;
        } 
    }
}

