using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class RIS_NURSESDATADTLDeleteData : DataAccessBase
    {
        public RIS_NURSESDATADTL RIS_NURSESDATADTL { get; set; }

        public RIS_NURSESDATADTLDeleteData()
		{
            RIS_NURSESDATADTL = new RIS_NURSESDATADTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_NURSESDATADTL_Delete;
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
                                            Parameter("@NURSE_DATA_UK_ID",RIS_NURSESDATADTL.NURSE_DATA_UK_ID),
                                            Parameter("@DETAIL_DATA_ID",RIS_NURSESDATADTL.DETAIL_DATA_ID)
                                     };
            return parameters;
        }
	}
}
