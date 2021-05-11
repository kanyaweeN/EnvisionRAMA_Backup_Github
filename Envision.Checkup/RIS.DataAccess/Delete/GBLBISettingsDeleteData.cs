using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using RIS.DataAccess;
using System.Data.SqlClient;
namespace Envision.DataAccess.Delete
{
    public class GBLBISettingsDeleteData : DataAccessBase
    {
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }
        public GBLBISettingsDeleteData()
		{
            GBL_BISETTINGS = new GBL_BISETTINGS();
            StoredProcedureName = StoredProcedure.Name.Prc_GBL_BISETTINGS_Delete.ToString();
		}
       
		public bool Delete()
		{
            SqlParameter[] ParameterList = buildParameter();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(base.ConnectionString, ParameterList);
			return true;
		}
        private SqlParameter[] buildParameter()
        {
            SqlParameter[] parameters = { 
                                           new SqlParameter("@BISETTINGS_ID",GBL_BISETTINGS.BISETTINGS_ID) ,
                                       };
            return parameters;
        }
	}
}
