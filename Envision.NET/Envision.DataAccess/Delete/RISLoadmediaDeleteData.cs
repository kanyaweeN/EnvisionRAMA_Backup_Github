using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_LOADMEDIADeleteData : DataAccessBase 
	{
        public RIS_LOADMEDIA RIS_LOADMEDIA { get; set; }

        public RIS_LOADMEDIADeleteData()
		{
            RIS_LOADMEDIA = new RIS_LOADMEDIA();
            StoredProcedureName = StoredProcedure.Prc_RIS_LOADMEDIA_Delete;

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
                                            Parameter("@LOAD_ID",RIS_LOADMEDIA.LOAD_ID),
                                     };
            return parameters;
        }
	}
}

