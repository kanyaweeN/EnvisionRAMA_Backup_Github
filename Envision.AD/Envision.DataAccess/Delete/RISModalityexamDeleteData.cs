using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_MODALITYEXAMDeleteData : DataAccessBase 
	{
        public RIS_MODALITYEXAM RIS_MODALITYEXAM { get; set; }

        public RIS_MODALITYEXAMDeleteData()
		{
            RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_Delete;
		}

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void DeleteOnline()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_ONL_Delete;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@MODALITY_EXAM_ID",RIS_MODALITYEXAM.MODALITY_EXAM_ID)
                                     };
            return parameters;
        }
	}
}

