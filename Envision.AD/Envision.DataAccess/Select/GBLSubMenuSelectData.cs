using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class GBLSubMenuSelectData : DataAccessBase
    {
        public GBLSubMenuSelectData()
        {
            StoredProcedureName = StoredProcedure.GBLSubMenu_Select;
        }

        public DataSet Get(int iOrgID, string uid, int sp, string pid)
        {
            string uids = uid;
            DataSet ds = new DataSet();
            ParameterList=buildParameter(sp, iOrgID, uids, pid);
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataAdminRole()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_SUBMENU_Select;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int iSP, int iOrgID, string uidno, string pidno)
        {
            int m_iSP;
            int m_iOrgID;
            string uid;
            string pid;

            m_iSP = iSP;
            m_iOrgID = iOrgID;
            uid = uidno;
            pid = pidno;

            DbParameter[] parameters = { 
				                            Parameter( "@SP_Types"	        , m_iSP),
                                            Parameter( "@ORG_ID"		    , m_iOrgID ),
                                            Parameter( "@UdID"		        , uid ),
                                            Parameter( "@PID"		        , pid ),   
                                                                   
                                       };
            return parameters;
        }
    }
}
