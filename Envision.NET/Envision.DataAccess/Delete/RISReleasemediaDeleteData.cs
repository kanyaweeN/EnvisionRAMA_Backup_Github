using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RISReleasemediaDeleteData : DataAccessBase 
	{
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }

		public  RISReleasemediaDeleteData()
		{
            RIS_RELEASEMEDIA=new RIS_RELEASEMEDIA();
            StoredProcedureName = StoredProcedure.Prc_RIS_RELEASEMEDIA_Delete;
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
                                           Parameter("@RELEASE_ID"  ,RIS_RELEASEMEDIA.RELEASE_ID) 
                                       };
            return parameters;
        }
	}

}

