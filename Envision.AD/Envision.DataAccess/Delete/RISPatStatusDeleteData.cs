using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class RIS_PATSTATUSDeleteData : DataAccessBase
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }
        public RIS_PATSTATUSDeleteData()
		{
            RIS_PATSTATUS = new RIS_PATSTATUS();
            StoredProcedureName = StoredProcedure.Prc_RIS_PATSTATUS_Delete;
		}
       
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@STATUS_ID",RIS_PATSTATUS.STATUS_ID) ,
                                       };
            return parameters;
        }
	}
}
