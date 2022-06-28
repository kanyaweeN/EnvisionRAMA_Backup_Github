using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISUserorgmapUpdateData : DataAccessBase 
	{
        public RIS_USERORGMAP RIS_USERORGMAP { get; set; }

		public  RISUserorgmapUpdateData()
		{
            RIS_USERORGMAP = new RIS_USERORGMAP();
			StoredProcedureName = StoredProcedure.Prc_RIS_USERORGMAP_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Update(DbTransaction tran) 
		{
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
//Parameter("@EMP_ID",RIS_USERORGMAP.EMP_ID)
//,Parameter("@ACCESS_ORG_ID",RIS_USERORGMAP.ACCESS_ORG_ID)
//,Parameter("@UNIT_ID",RIS_USERORGMAP.UNIT_ID)
//,Parameter("@ORG_ID",RIS_USERORGMAP.ORG_ID)
//,Parameter("@CREATED_BY",RIS_USERORGMAP.CREATED_BY)
//,Parameter("@CREATED_ON",RIS_USERORGMAP.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",RIS_USERORGMAP.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",RIS_USERORGMAP.LAST_MODIFIED_ON)
                                      };
            return parameters;
        }
	}
}

