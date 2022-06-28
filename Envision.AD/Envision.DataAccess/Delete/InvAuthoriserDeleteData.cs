using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class INV_AUTHORISERDeleteData : DataAccessBase
    {
        public INV_AUTHORISER INV_AUTHORISER{get;set;}

        public INV_AUTHORISERDeleteData()
        {
            INV_AUTHORISER = new INV_AUTHORISER();
            StoredProcedureName = StoredProcedure.Prc_INV_AUTHORISER_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@AUTHORISER_ID",INV_AUTHORISER.AUTHORISER_ID)
                                     };
            return parameters;
        }
    }
}
