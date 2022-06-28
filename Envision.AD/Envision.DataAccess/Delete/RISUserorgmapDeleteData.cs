using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_USERORGMAPDeleteData : DataAccessBase 
	{
        public RIS_USERORGMAP RIS_USERORGMAP { get; set; }

        public RIS_USERORGMAPDeleteData()
		{
            RIS_USERORGMAP = new RIS_USERORGMAP();
            StoredProcedureName = StoredProcedure.Prc_RIS_USERORGMAP_Delete;
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
                                            Parameter("@EMP_ID"  ,RIS_USERORGMAP.EMP_ID) ,
                                            Parameter("@UNIT_ID"  ,RIS_USERORGMAP.UNIT_ID) ,
                                       };
            return parameters;
        }
	}
}

