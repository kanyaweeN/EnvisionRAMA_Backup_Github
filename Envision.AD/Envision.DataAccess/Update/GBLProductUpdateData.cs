//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com
//         Generate   :    27/06/2551 05:26:50
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class GBLProductUpdateData : DataAccessBase 
	{
        public GBL_PRODUCT GBL_PRODUCT { get; set; }

		public  GBLProductUpdateData()
		{
            GBL_PRODUCT = new GBL_PRODUCT();
            StoredProcedureName = StoredProcedure.Prc_GBL_PRODUCT_UpdateVersion;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@PROD_ID",GBL_PRODUCT.PROD_ID)
                ,Parameter("@PROD_VERSION",GBL_PRODUCT.PROD_VERSION)
                                      };
            return parameters;
        }
	}
}

