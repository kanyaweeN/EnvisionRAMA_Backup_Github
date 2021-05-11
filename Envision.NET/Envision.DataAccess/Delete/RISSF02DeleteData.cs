using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class RISSF02DeleteData : DataAccessBase
    {
        public RISSF02Data RISSF02Data { get; set; }

        public RISSF02DeleteData()
        {
            RISSF02Data = new RISSF02Data();
            StoredProcedureName = StoredProcedure.PRC_RIS_SF02_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@ICD_ID"  ,RISSF02Data.ICD_ID) ,
                                       };
            return parameters;
        }
       
    }
}
