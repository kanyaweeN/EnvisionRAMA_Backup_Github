using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class RISOrderConfliction : DataAccessBase
    {
        private RISOrderConflictionParameters _menuselectdataparameters;

        public RISOrderConfliction()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RISOrderConfliction.ToString();
        }

        public DataSet Get(int iOrgID, int iOrderID, int iCheckExamID)
        {
            DataSet ds;
            _menuselectdataparameters = new RISOrderConflictionParameters(iOrgID, iOrderID, iCheckExamID);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _menuselectdataparameters.Parameters);
            return ds;
        }

        public DataSet Get(int iOrgID, int iOrderID, DateTime ExamDatetime, DateTime CheckExamDatetime)
        {
            DataSet ds=null;
            _menuselectdataparameters = new RISOrderConflictionParameters(iOrgID, iOrderID, ExamDatetime, CheckExamDatetime);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _menuselectdataparameters.Parameters);
            return ds;
        }

    }

    public class RISOrderConflictionParameters
    {
        int m_iOrderID;
        int m_iOrgID;
        int m_iCheckExamID;
        DateTime m_ExamDatetime = new DateTime(1977, 1, 1);
        DateTime m_CheckExamDatetime = new DateTime(1977, 1, 1);

        private SqlParameter[] _parameters;

        public RISOrderConflictionParameters(int iOrgID, int iOrderID, int iCheckExamID)
        {
            m_iOrderID = iOrderID;
            m_iOrgID = iOrgID;
            m_iCheckExamID = iCheckExamID;
            //m_ExamDatetime = ExamDatetime;
            Build();
        }

        public RISOrderConflictionParameters(int iOrgID, int iOrderID, DateTime ExamDatetime, DateTime CheckExamDatetime)
        {
            m_iOrderID = iOrderID;
            m_iOrgID = iOrgID;
            //m_iCheckExamID = iCheckExamID;
            m_ExamDatetime = ExamDatetime;
            m_CheckExamDatetime = CheckExamDatetime;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@ORG_IG"		    , m_iOrgID ),
                new SqlParameter( "@OrderID"		    , m_iOrderID ),
                new SqlParameter( "@ExamID"		    , m_iCheckExamID ),
                new SqlParameter( "@ExamDatetime"   , m_ExamDatetime ),
                new SqlParameter( "@CheckExamDatetime"   , m_CheckExamDatetime ),
 		    };

            Parameters = parameters;
        }


        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}