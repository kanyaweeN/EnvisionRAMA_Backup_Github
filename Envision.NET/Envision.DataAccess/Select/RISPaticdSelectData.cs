using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISPaticdSelectData : DataAccessBase 
	{
        public RIS_PATICD RIS_PATICD { get; set; }
        private int action = 0;

		public  RISPaticdSelectData()
		{
            RIS_PATICD = new RIS_PATICD();
            StoredProcedureName = StoredProcedure.Prc_RIS_PATICD_Select;
            action = 0;
		}
        public RISPaticdSelectData(int OrderID)
        {
            RIS_PATICD = new RIS_PATICD();
            RIS_PATICD.ORDER_NO = OrderID;
            StoredProcedureName = StoredProcedure.Prc_RIS_PATICD_SelectByOrder;
            action = 1;
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            if (action == 1)
            {
                ParameterList = buildParameter();
            }
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                   Parameter("@ORDER_ID",RIS_PATICD.ORDER_NO)
			};
            return parameters;
        }
	}
}

