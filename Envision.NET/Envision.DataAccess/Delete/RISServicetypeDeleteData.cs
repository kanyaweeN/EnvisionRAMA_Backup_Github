using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_SERVICETYPEDeleteData : DataAccessBase 
	{
        public RIS_SERVICETYPE RIS_SERVICETYPE { get; set; }
        public int ServicetypeID { get; set; }

        public RIS_SERVICETYPEDeleteData()
		{
            RIS_SERVICETYPE = new RIS_SERVICETYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_SERVICETYPE_Delete;
		}
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@SERVICE_TYPE_ID"  ,RIS_SERVICETYPE.SERVICE_TYPE_ID) ,
                                       };
            return parameters;
        }
	}
}

