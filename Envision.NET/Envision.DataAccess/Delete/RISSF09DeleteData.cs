using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class RISSF09DeleteData : DataAccessBase
    {
        public RISSF09Data RISSF09Data { get; set; }

        public RISSF09DeleteData()
        {
            RISSF09Data = new RISSF09Data();
            StoredProcedureName = StoredProcedure.PRC_RIS_SF09_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@EXAM_TYPE_ID"		,  RISSF09Data.EXAM_TYPE_ID) ,
                                       };
            return parameters;
        }
        
    }
}
