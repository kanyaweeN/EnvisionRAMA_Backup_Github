using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Insert
{
	public class RISUserorgmapInsertData : DataAccessBase 
	{
        public RIS_USERORGMAP RIS_USERORGMAP { get; set; }

        public RISUserorgmapInsertData()
		{
            RIS_USERORGMAP = new RIS_USERORGMAP();
            StoredProcedureName = StoredProcedure.Prc_RIS_USERORGMAP_Insert;
		}
		public bool Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		
        private DbParameter[] buildParameter() {
            DbParameter[] parameters ={			
                Parameter("@EMP_ID",RIS_USERORGMAP.EMP_ID)
                ,Parameter("@ACCESS_ORG_ID",RIS_USERORGMAP.ACCESS_ORG_ID)
                ,Parameter("@UNIT_ID",RIS_USERORGMAP.UNIT_ID==0?(object) DBNull.Value :RIS_USERORGMAP.UNIT_ID)
                ,Parameter("@ORG_ID",RIS_USERORGMAP.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_USERORGMAP.CREATED_BY)
			};
            return parameters;
        }
	}
}

