using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class GBLSubMenuObjectLabelSelectData : DataAccessBase
    {

        public GBLSubMenuObjectLabelSelectData()
        {
            StoredProcedureName = StoredProcedure.GBLSubMenuObjectLabel_Select;
        }

        public DataSet Get(int iOrgID, string uid, int sp, int pid)
        {
            string uids = uid;
            ParameterList = buildParameter(sp, iOrgID, uids, pid);
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int iSP, int iOrgID, string uidno, int pidno)
        {
            int m_iSP;
            int m_iOrgID;
            string uid;
            int pid;
            m_iSP = iSP;
            m_iOrgID = iOrgID;
            uid = uidno;
            pid = pidno;
            DbParameter[] parameters = { 
                                                        Parameter( "@SP_Types"	, m_iSP),
                                                        Parameter( "@ORG_IG"    , m_iOrgID ),
                                                        Parameter( "@UdID"		, uid ),
                                                        Parameter( "@LangID"	, pid ),
                                       };
            return parameters;
        }
    }
}
