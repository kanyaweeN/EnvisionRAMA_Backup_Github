using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class GBLMenuSelectData : DataAccessBase
    {

        public GBLMenuSelectData()
        {
            StoredProcedureName = StoredProcedure.GBLMenu_Select;
        }
        public DataSet Get(int iOrgID, string uid, int sp)
        {
            string uids = uid;
            DataSet ds = new DataSet();
            ParameterList = buildParameter(sp, iOrgID, uid);
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet Get(int EMP_ID) {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.GBLMenu_EmpSelect;
            ParameterList = buildParameterEmp(EMP_ID);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int iSP, int iOrgID, string uidno)
        {
            int m_iSP;
            int m_iOrgID;
            string uid;
            m_iSP = iSP;
            m_iOrgID = iOrgID;
            uid = uidno;
            DbParameter[] parameters = { 
                                            Parameter( "@SP_Types"	        , m_iSP),
                                            Parameter( "@ORG_ID"		    , m_iOrgID ),
                                            Parameter( "@UdID"		        , uid ),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterEmp(int EMP_ID) {
            DbParameter[] parameters = { 
                                            Parameter( "@EMP_ID"	        , EMP_ID),
                                        };
            return parameters;
        }
    }
}
