//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    04/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
	public class RISServicetypeSelectData : DataAccessBase 
	{
        private RISServicetypeSelectDataParameters _risservicetypeselectdataparameters;
        private bool selectAll;
		public  RISServicetypeSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_SERVICETYPE_Select.ToString();
            selectAll = false;
		}
        public RISServicetypeSelectData(bool selectAll)
        {
            if(selectAll)
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_SERVICETYPE_SelectAll.ToString();
            else
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_SERVICETYPE_Select.ToString();
            this.selectAll = selectAll;
        }
		public DataSet GetData()
		{
            _risservicetypeselectdataparameters = new RISServicetypeSelectDataParameters();
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = null;
            if(selectAll)
                ds = dbhelper.Run(base.ConnectionString);
            else
                ds=dbhelper.Run(base.ConnectionString, _risservicetypeselectdataparameters.Parameters);
			return ds;
		}
	}
	public class RISServicetypeSelectDataParameters 
	{
		private SqlParameter[] _parameters;
		public RISServicetypeSelectDataParameters()
		{
			Build();
		}

		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={
                //new SqlParameter("@SERVICE_TYPE_ID",RISServicetype.SERVICE_TYPE_ID),
                //new SqlParameter("@SERVICE_TYPE_UID",RISServicetype.SERVICE_TYPE_UID),
                //new SqlParameter("@IS_UPDATED",RISServicetype.IS_UPDATED),
                //new SqlParameter("@IS_DELETED",RISServicetype.IS_DELETED),
                new SqlParameter("@ORG_ID",new GBLEnvVariable().OrgID)
                //new SqlParameter("@CREATED_BY",RISServicetype.CREATED_BY),
                //new SqlParameter("@CREATED_ON",RISServicetype.CREATED_ON),
                //new SqlParameter("@LAST_MODIFIED_BY",RISServicetype.LAST_MODIFIED_BY),
                //new SqlParameter("@LAST_MODIFIED_ON",RISServicetype.LAST_MODIFIED_ON),
                //new SqlParameter("@IS_ACTIVE",RISServicetype.IS_ACTIVE),
                //new SqlParameter("@SERVICE_TYPE_TEXT",RISServicetype.SERVICE_TYPE_TEXT)
            };
			Parameters = parameters;
		}
	}
}

