using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_RADSTUDYGROUPDeleteData : DataAccessBase 
	{
        public RIS_RADSTUDYGROUP RIS_RADSTUDYGROUP { get; set; }

        public RIS_RADSTUDYGROUPDeleteData()
		{
            RIS_RADSTUDYGROUP = new RIS_RADSTUDYGROUP();
            StoredProcedureName = StoredProcedure.Prc_RIS_RADSTUDYGROUP_Delete;
		}
		
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Delete(DbTransaction tran) 
		{
			if (tran!=null)
			{

                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
			}
			else Delete();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@RADIOLOGIST_ID"  ,RIS_RADSTUDYGROUP.RADIOLOGIST_ID) ,
                                           Parameter("@ACCESSION_NO"    ,RIS_RADSTUDYGROUP.ACCESSION_NO) 
                                       };
            return parameters;
        }
	}
}

