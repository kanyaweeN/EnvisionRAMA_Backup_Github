using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_LOADMEDIADTLDeleteData : DataAccessBase 
	{
        public RIS_LOADMEDIADTL RIS_LOADMEDIADTL { get; set; }

        public RIS_LOADMEDIADTLDeleteData()
		{
            RIS_LOADMEDIADTL = new RIS_LOADMEDIADTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_LOADMEDIADTL_Delete;
		}
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        public bool Delete(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();

            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@LOAD_ID",RIS_LOADMEDIADTL.LOAD_ID),
                                            Parameter("@EXAM_ID",RIS_LOADMEDIADTL.EXAM_ID),
                                     };
            return parameters;
        }
	}
}

