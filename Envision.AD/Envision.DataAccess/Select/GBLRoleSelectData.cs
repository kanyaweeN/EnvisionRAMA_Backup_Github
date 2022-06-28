using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class GBLRoleSelectData : DataAccessBase
    {

        public GBLRoleSelectData()
        {
            StoredProcedureName = StoredProcedure.GBLRole_Select;
        }

        public DataSet Get(int iOrgID, string uid, int sp)
        {
            string uids = uid;
            DataSet ds = new DataSet();
            ParameterList=buildParameter( sp, iOrgID, uids);
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
                                                 	Parameter( "@SP_Types"	, m_iSP),
                                                    Parameter( "@ORG_ID"    , m_iOrgID ),
                                                    Parameter( "@UdID"		, uid ),
                                       };
            return parameters;
        }
    }
}
