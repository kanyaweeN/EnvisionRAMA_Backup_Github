using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class HR_EMPDeleteData : DataAccessBase 
	{
        public HR_EMP HR_EMP { get; set; }

        public HR_EMPDeleteData()
		{
            HR_EMP = new HR_EMP();
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_Delete;
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
                                         Parameter("@EMP_ID",HR_EMP.EMP_ID)
                                     };
            return parameters;
        }
	}
}

