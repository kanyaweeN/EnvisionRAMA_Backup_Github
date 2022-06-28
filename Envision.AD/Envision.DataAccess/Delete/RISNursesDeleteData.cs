using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class RIS_NURSESDATADeleteData : DataAccessBase
    {
        public RIS_NURSESDATA RIS_NURSESDATA { get; set; }

        public RIS_NURSESDATADeleteData()
		{
            RIS_NURSESDATA = new RIS_NURSESDATA();
            StoredProcedureName = StoredProcedure.Prc_RIS_NURSESDATA_Delete;
		}
       
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@NURSE_DATA_UK_ID",RIS_NURSESDATA.NURSE_DATA_UK_ID)
                                     };
            return parameters;
        }
	}
}
