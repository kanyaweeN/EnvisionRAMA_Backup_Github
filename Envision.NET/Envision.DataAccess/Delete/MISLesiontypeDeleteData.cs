using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class MIS_LESIONTYPEDeleteData : DataAccessBase 
	{
        public MIS_LESIONTYPE MIS_LESIONTYPE { get; set; }

        public MIS_LESIONTYPEDeleteData()
		{
            MIS_LESIONTYPE = new MIS_LESIONTYPE();
            StoredProcedureName = StoredProcedure.Prc_MIS_LESIONTYPE_Delete;
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
                                       // Parameter("@LESION_TYPE_ID",MIS_LESIONTYPE.LESION_TYPE_ID)
                                     };
            return parameters;
        }
	}
}

