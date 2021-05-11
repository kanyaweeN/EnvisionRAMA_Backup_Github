using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class GBLMenuSelectData : DataAccessBase
    {
        private GBLMenuSelectDataParameters _menuselectdataparameters;

        public GBLMenuSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLMenu_Select.ToString();
        }

        public DataSet Get(int iOrgID, string uid, int sp)
        {
            string uids = uid;
                        
            DataSet ds;
            _menuselectdataparameters = new GBLMenuSelectDataParameters(sp, iOrgID, uids);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _menuselectdataparameters.Parameters);
            return ds;

        }

    }

    public class GBLMenuSelectDataParameters
    {
        //int sp;
        //string uid;
        //int dtlid;

        int m_iSP;
        int m_iOrgID;
        string uid;

        private SqlParameter[] _parameters;

        public GBLMenuSelectDataParameters(int iSP, int iOrgID, string uidno)
        {
            m_iSP = iSP;
            m_iOrgID = iOrgID;
            uid = uidno;
            //dtlid = dtl_id;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@SP_Types"	, m_iSP),
                new SqlParameter( "@ORG_IG"		    , m_iOrgID ),
                new SqlParameter( "@UdID"		    , uid ),
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
