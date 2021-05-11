using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class InvCategoryUpdateData : DataAccessBase
    {
        public INV_CATEGORY INV_CATEGORY { get; set; }

        public InvCategoryUpdateData()
        {
            INV_CATEGORY = new INV_CATEGORY();
            this.StoredProcedureName = StoredProcedure.Prc_INV_CATEGORY_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                Parameter("@CATEGORY_ID",INV_CATEGORY.CATEGORY_ID),
                                Parameter("@CATEGORY_UID",INV_CATEGORY.CATEGORY_UID),
                                Parameter("@CATEGORY_NAME",INV_CATEGORY.CATEGORY_NAME),
                                Parameter("@CATEGORY_DESC",INV_CATEGORY.CATEGORY_DESC),
                                Parameter("@ORG_ID",INV_CATEGORY.ORG_ID),
                                Parameter("@PARENT",INV_CATEGORY.PARENT),
                                      };
            return parameters;
        }
    }
}
