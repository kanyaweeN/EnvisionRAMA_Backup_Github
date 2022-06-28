using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class INV_CATEGORYDeleteData : DataAccessBase
    {
        public INV_CATEGORY INV_CATEGORY { get; set; }

        public INV_CATEGORYDeleteData()
        {
            INV_CATEGORY = new INV_CATEGORY();
            this.StoredProcedureName = StoredProcedure.Prc_INV_CATEGORY_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@CATEGORY_ID",INV_CATEGORY.CATEGORY_ID)
                                     };
            return parameters;
        }
    }
}
