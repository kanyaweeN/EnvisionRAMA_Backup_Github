using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_QAREASONDeleteData : DataAccessBase 
	{
        public RIS_QAREASON RIS_QAREASON { get; set; }

        public RIS_QAREASONDeleteData()
		{
            RIS_QAREASON = new RIS_QAREASON();
            StoredProcedureName = StoredProcedure.Prc_RIS_QAREASON_Delete;
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
                                           Parameter("@REASON_ID",RIS_QAREASON.REASON_ID) ,
                                       };
            return parameters;
        }
	}
}

