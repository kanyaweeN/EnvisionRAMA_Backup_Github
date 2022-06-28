using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISRadstudygroupUpdateData : DataAccessBase 
	{
        public RIS_RADSTUDYGROUP RIS_RADSTUDYGROUP { get; set; }

		public  RISRadstudygroupUpdateData()
		{
            RIS_RADSTUDYGROUP = new RIS_RADSTUDYGROUP();
			StoredProcedureName = StoredProcedure.Prc_RIS_RADSTUDYGROUP_Update;
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
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@RADIOLOGIST_ID",RIS_RADSTUDYGROUP.RADIOLOGIST_ID)
                ,Parameter("@ACCESSION_NO",RIS_RADSTUDYGROUP.ACCESSION_NO)
                ,Parameter("@IS_FAVOURITE",RIS_RADSTUDYGROUP.IS_FAVOURITE)
                ,Parameter("@IS_TEACHING",RIS_RADSTUDYGROUP.IS_TEACHING)
                ,Parameter("@IS_OTHERS",RIS_RADSTUDYGROUP.IS_OTHERS)
                ,Parameter("@ORG_ID",RIS_RADSTUDYGROUP.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_RADSTUDYGROUP.CREATED_BY)
                ,Parameter("MODE",RIS_RADSTUDYGROUP.MODE)
                                      };
            return parameters;
        }
	}
}

