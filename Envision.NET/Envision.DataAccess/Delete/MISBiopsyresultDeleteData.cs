using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class MIS_BIOPSYRESULTDeleteData : DataAccessBase 
	{
        public MIS_BIOPSYRESULT MIS_BIOPSYRESULT { get; set; }

        public MIS_BIOPSYRESULTDeleteData()
		{
            MIS_BIOPSYRESULT = new MIS_BIOPSYRESULT();
            StoredProcedureName = StoredProcedure.Prc_MIS_BIOPSYRESULT_Delete;
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
                                        Parameter("@ACCESSION_NO",MIS_BIOPSYRESULT.ACCESSION_NO)
                                     };
            return parameters;
        }
	}
}

