using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class INV_PRDeleteData : DataAccessBase 
	{
        public INV_PR INV_PR { get; set; }

        public INV_PRDeleteData()
		{
            INV_PR = new INV_PR();
            StoredProcedureName = StoredProcedure.Prc_INV_PR_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@PR_ID",INV_PR.PR_ID),
                                     };
            return parameters;
        }
	}
}

