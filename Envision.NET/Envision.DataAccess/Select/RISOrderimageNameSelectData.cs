using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISOrderimageNameSelectData : DataAccessBase 
	{
        public int RISOrderNumber { get; set; }
        public RISOrderimageNameSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERIMAGES_SelectMinByOrderID;
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
                   Parameter("@ORDER_ID",RISOrderNumber)
			};
            return parameters;
        }
	}
}

