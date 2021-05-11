using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISOrderimagesSelectData : DataAccessBase 
	{
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }
		public  RISOrderimagesSelectData()
		{
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERIMAGES_Select;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataTable GetDataByID() {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERIMAGES_SelectByID;
            ParameterList = buildParameter();
            dtt = ExecuteDataTable();
            return dtt;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@ORDER_ID",RIS_ORDERIMAGE.ORDER_ID)
                ,Parameter("@SCHEDULE_ID",RIS_ORDERIMAGE.SCHEDULE_ID)
			};
            return parameters;
        }
	}
}

