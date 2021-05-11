using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISUserorgmapSelectData : DataAccessBase 
	{
        public RIS_USERORGMAP RIS_USERORGMAP { get; set; }
		public  RISUserorgmapSelectData()
		{
            RIS_USERORGMAP = new RIS_USERORGMAP();
			StoredProcedureName = StoredProcedure.Prc_RIS_USERORGMAP_Select;
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
                Parameter("@EMP_ID",RIS_USERORGMAP.EMP_ID)
                ,Parameter("@UNIT_ID",RIS_USERORGMAP.UNIT_ID)
                ,Parameter("@MODE",RIS_USERORGMAP.MODE)
			};
            return parameters;
        }
	}
}