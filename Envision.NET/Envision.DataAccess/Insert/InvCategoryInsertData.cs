using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvCategoryInsertData : DataAccessBase
    {
        public INV_CATEGORY INV_CATEGORY { get; set; }

        public InvCategoryInsertData()
        {
            INV_CATEGORY = new INV_CATEGORY();
            this.StoredProcedureName = StoredProcedure.Prc_INV_CATEGORY_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                            Parameter("@CATEGORY_UID",INV_CATEGORY.CATEGORY_UID),
                            Parameter("@CATEGORY_NAME",INV_CATEGORY.CATEGORY_NAME),
                            Parameter("@CATEGORY_DESC",INV_CATEGORY.CATEGORY_DESC),
                            Parameter("@PARENT",INV_CATEGORY.PARENT),
                            Parameter("@ORG_ID",INV_CATEGORY.ORG_ID),
            };
            return parameters;
        }
    }
}
