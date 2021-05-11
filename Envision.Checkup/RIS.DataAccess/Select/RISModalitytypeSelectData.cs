//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//         Modifier   :    Sitti Borisuit
//         Modified   :    03/04/2008
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
	public class RISModalitytypeSelectData : DataAccessBase 
	{
        private RISModalitytypeInsertDataParameters _rismodalitytypeselectdataparameters;
		public  RISModalitytypeSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYTYPE_Select.ToString();
		}

		public DataSet GetData()
		{
            _rismodalitytypeselectdataparameters = new RISModalitytypeInsertDataParameters();
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_rismodalitytypeselectdataparameters.Parameters);
			return ds;
		}
	}
	public class RISModalitytypeInsertDataParameters 
	{
		private SqlParameter[] _parameters;
		public RISModalitytypeInsertDataParameters()
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
                //new SqlParameter("@TYPE_ID",RISModalitytype),
                //new SqlParameter("@TYPE_UID",RISModalitytype.TYPE_UID),
                //new SqlParameter("@TYPE_NAME",RISModalitytype.TYPE_NAME),
                //new SqlParameter("@TYPE_NAME_ALIAS",RISModalitytype.TYPE_NAME_ALIAS),
                //new SqlParameter("@DESCR",RISModalitytype.DESCR),
                //new SqlParameter("@CREATED_BY",RISModalitytype.CREATED_BY),
                //new SqlParameter("@CREATED_ON",RISModalitytype.CREATED_ON),
                //new SqlParameter("@LAST_MODIFIED_BY",RISModalitytype.LAST_MODIFIED_BY),
                //new SqlParameter("@LAST_MODIFIED_ON",RISModalitytype.LAST_MODIFIED_ON),
                new SqlParameter("@ORG_ID",new GBLEnvVariable().OrgID)
            };
            Parameters = parameters;
        }
	}
}

