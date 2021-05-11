using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISOrderConfliction : DataAccessBase
    {
        public RISOrderConfliction()
        {
            StoredProcedureName = StoredProcedure.Prc_RISOrderConfliction;
        }

        public DataSet Get(int iOrgID, int iOrderID, int iCheckExamID)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(iOrgID, iOrderID, iCheckExamID);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int iOrgID, int iOrderID, int iCheckExamID)
        {
            int m_iOrderID = 0;
            int m_iOrgID = 0;
            int m_iCheckExamID = 0;
            DateTime m_ExamDatetime = new DateTime(1977, 1, 1);
            DateTime m_CheckExamDatetime = new DateTime(1977, 1, 1);

            m_iOrderID = iOrderID;
            m_iOrgID = iOrgID;
            m_iCheckExamID = iCheckExamID;

            DbParameter[] parameters ={			
				Parameter( "@ORG_ID"		    , m_iOrgID ),
                Parameter( "@OrderID"		    , m_iOrderID ),
                Parameter( "@ExamID"		    , m_iCheckExamID ),
                Parameter( "@ExamDatetime"   , m_ExamDatetime ),
                Parameter( "@CheckExamDatetime"   , m_CheckExamDatetime ),
			};
            return parameters;
        }
        public DataSet Get(int iOrgID, int iOrderID, DateTime ExamDatetime, DateTime CheckExamDatetime)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(iOrgID, iOrderID, ExamDatetime, CheckExamDatetime);
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameter(int iOrgID, int iOrderID, DateTime ExamDatetime, DateTime CheckExamDatetime)
        {
            int m_iOrderID = 0;
            int m_iOrgID = 0;
            int m_iCheckExamID = 0;
            DateTime m_ExamDatetime = new DateTime(1977, 1, 1);
            DateTime m_CheckExamDatetime = new DateTime(1977, 1, 1);

            m_iOrderID = iOrderID;
            m_iOrgID = iOrgID;
            //m_iCheckExamID = iCheckExamID;
            m_ExamDatetime = ExamDatetime;
            m_CheckExamDatetime = CheckExamDatetime;

            DbParameter[] parameters ={			
				Parameter( "@ORG_ID"		    , m_iOrgID ),
                Parameter( "@ORDER_ID"		    , m_iOrderID ),
                Parameter( "@CHECKEXAM_ID"		    , m_iCheckExamID ),
                Parameter( "@ExamDatetime"   , m_ExamDatetime ),
                Parameter( "@CheckExamDatetime"   , m_CheckExamDatetime ),
			};
            return parameters;
        }
    }
}