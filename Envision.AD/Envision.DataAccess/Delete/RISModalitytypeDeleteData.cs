using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_MODALITYTYPEDeleteData : DataAccessBase 
	{
        
        public string ModalityTypeID { get; set; }

        public RIS_MODALITYTYPEDeleteData()
		{
            ModalityTypeID = "0";
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYTYPE_Delete;
		}

		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@TYPE_ID",ModalityTypeID)
                                     };
            return parameters;
        }
	}
}

