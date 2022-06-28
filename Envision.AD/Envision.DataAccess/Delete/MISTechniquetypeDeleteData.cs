using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class MIS_TECHNIQUETYPEDeleteData : DataAccessBase 
	{
        public MIS_TECHNIQUETYPE MIS_TECHNIQUETYPE { get; set; }
        public MIS_TECHNIQUETYPEDeleteData()
		{
            MIS_TECHNIQUETYPE = new MIS_TECHNIQUETYPE();
            StoredProcedureName = StoredProcedure.Prc_MIS_TECHNIQUETYPE_Delete;
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
            DbParameter[] parameters ={
                                       // Parameter("@TECHNIQUE_TYPE_ID",MIS_TECHNIQUETYPE.TECHNIQUE_TYPE_ID)
                                     };
            return parameters;
        }
	}
	
}

