using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
	public class GBL_HOSPITALDeleteData : DataAccessBase 
	{
        public GBL_HOSPITAL GBL_HOSPITAL { get; set; }

        public GBL_HOSPITALDeleteData()
		{
            GBL_HOSPITAL = new GBL_HOSPITAL();
            StoredProcedureName = StoredProcedure.Prc_GBL_HOSPITAL_Delete;
		}
		
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        public bool DeleteMapping(int HosID) {

            ParameterList = buildParameterMapping(HosID);
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                            Parameter("@HOS_ID"		,  GBL_HOSPITAL.HOS_ID)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterMapping(int HosID)
        {
            DbParameter[] parameters = { 
                                            Parameter("@HOSID"		,  HosID)
                                       };
            return parameters;
        }
	}
}

