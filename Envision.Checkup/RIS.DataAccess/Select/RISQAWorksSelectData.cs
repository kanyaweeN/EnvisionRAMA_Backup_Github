using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISQAWorksSelectData : DataAccessBase 
    {
        private RISQaworks _RISQaworks;
        private RISQAWorksInsertDataParameters _RISQaworksInserParameters;
        private RISQAWorksSelectHNDataParameters _RISQaworksSelectHNParameters;
        public RISQAWorksSelectData()
        {
            _RISQaworks = new RISQaworks();
        }
        public RISQaworks RISQaworks
        {
            get { return _RISQaworks; }
            set { _RISQaworks = value; }
        }
        public DataSet GetReport_QAWorks(DateTime FromDate, DateTime ToDate, int UserID)
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_QAWORKS_Select_rptQAWorks.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = null;
            _RISQaworksInserParameters = new RISQAWorksInsertDataParameters(FromDate, ToDate, UserID);
            ds = dbhelper.Run(base.ConnectionString, _RISQaworksInserParameters.Parameters);
            return ds;
        }
        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_QAWORKS_Select.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = null;
            _RISQaworksSelectHNParameters = new RISQAWorksSelectHNDataParameters(this._RISQaworks);
            ds = dbhelper.Run(base.ConnectionString, _RISQaworksSelectHNParameters.Parameters);
            return ds;
        }
        public class RISQAWorksInsertDataParameters
        {
            private RISQaworks  _RISQaworks;
            private SqlParameter[] _parameters;
            public RISQAWorksInsertDataParameters(DateTime FromDate, DateTime ToDate, int UserID)
            {
                BuildReport(FromDate, ToDate, UserID);
            }
            public SqlParameter[] Parameters
            {
                get { return _parameters; }
                set { _parameters = value; }
            }
            public void BuildReport(DateTime FromDate, DateTime ToDate, int UserID)
            {
                SqlParameter[] parameters ={ 
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@USER_ID",UserID)
            };
                Parameters = parameters;
            }
        }
    }

    public class RISQAWorksSelectHNDataParameters
    {
        private RISQaworks _RISQaworks;
        private SqlParameter[] _parameters;
        public RISQAWorksSelectHNDataParameters(RISQaworks risqaworks)
        {
            _RISQaworks = risqaworks;
            Build();
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        public RISQaworks RISQaworks
        {
            get { return _RISQaworks; }
            set { _RISQaworks = value; }
        }
        public void Build()
        {
            SqlParameter[] parameters ={
                    new SqlParameter("@MODE",RISQaworks.MODE),
                    new SqlParameter("@FROM_DATE",RISQaworks.FROM_DATE),
                    new SqlParameter("@TO_DATE",RISQaworks.TO_DATE),
            };
            Parameters = parameters;
        }
    }
}
