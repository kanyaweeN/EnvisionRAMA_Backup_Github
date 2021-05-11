using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISPatstatusSeleteDataN : DataAccessBase
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }
        public RISPatstatusSeleteDataN()
		{
            RIS_PATSTATUS = new RIS_PATSTATUS();
			StoredProcedureName = StoredProcedure.Prc_RIS_PATSTATUSN_Select;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@selectcase",RIS_PATSTATUS.SELECTCASE)
                ,Parameter("@STATUS_UID",RIS_PATSTATUS.STATUS_UID)
			};
            return parameters;
        }
	}
}
