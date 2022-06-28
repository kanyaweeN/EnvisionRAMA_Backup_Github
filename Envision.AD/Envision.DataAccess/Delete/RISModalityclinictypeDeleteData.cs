using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_MODALITYCLINICTYPEDeleteData : DataAccessBase 
	{
        public RIS_MODALITYCLINICTYPE RIS_MODALITYCLINICTYPE { get; set; }

        public RIS_MODALITYCLINICTYPEDeleteData()
		{
            RIS_MODALITYCLINICTYPE = new RIS_MODALITYCLINICTYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYCLINICTYPE_Delete;
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
                                            Parameter("@MODALITY_CLINICTYPE_ID",RIS_MODALITYCLINICTYPE.MODALITY_CLINICTYPE_ID)
                                     };
            return parameters;
        }
	}
}

 