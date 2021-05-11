using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class GBL_ALERTDeleteData : DataAccessBase
    {
        public GBL_ALERT GBL_ALERT { get; set; }
       
        public GBL_ALERTDeleteData()
        {
            GBL_ALERT = new GBL_ALERT();
            StoredProcedureName = StoredProcedure.GBLAlert_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Delete(DbTransaction tran)
        {
            if (tran != null)
            {
                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
            }
            else
                Delete();
        }
        
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                        Parameter("@AlertID"		,  GBL_ALERT.ALT_ID)
                                       };
            return parameters;
        }
    }
}
