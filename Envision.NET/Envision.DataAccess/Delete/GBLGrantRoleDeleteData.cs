using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class GBL_GRANTROLEDeleteData : DataAccessBase
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }

        public GBL_GRANTROLEDeleteData()
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
            StoredProcedureName = StoredProcedure.Prc_GBLGrantRole_Delete;
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Delete(DbTransaction tran) {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                            Parameter("@Grantroleid"		,  GBL_GRANTROLE.GRANTROLE_ID)
                                       };
            return parameters;
        }
    }
}
