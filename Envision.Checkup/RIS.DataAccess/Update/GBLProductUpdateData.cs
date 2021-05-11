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
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class GBLProductUpdateData : DataAccessBase 
	{
		private GBLProduct	_gblproduct;
		private GBLProductInsertDataParameters	_gblproductinsertdataparameters;
		public  GBLProductUpdateData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_GBL_PRODUCT_UpdateVersion.ToString();
		}
		public  GBLProduct	GBLProduct
		{
			get{return _gblproduct;}
			set{_gblproduct=value;}
		}
		public void Update()
		{
			_gblproductinsertdataparameters = new GBLProductInsertDataParameters(GBLProduct);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_gblproductinsertdataparameters.Parameters);
		}
	}
	public class GBLProductInsertDataParameters 
	{
		private GBLProduct _gblproduct;
		private SqlParameter[] _parameters;
		public GBLProductInsertDataParameters(GBLProduct gblproduct)
		{
			GBLProduct=gblproduct;
			Build();
		}
		public  GBLProduct	GBLProduct
		{
			get{return _gblproduct;}
			set{_gblproduct=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter("@PROD_ID",GBLProduct.PROD_ID)
                //,new SqlParameter("@PROD_NAME",GBLProduct.PROD_NAME)
                //,new SqlParameter("@PROD_DESCR",GBLProduct.PROD_DESCR)
                ,new SqlParameter("@PROD_VERSION",GBLProduct.PROD_VERSION)
                //,new SqlParameter("@RELEASE_DT",GBLProduct.RELEASE_DT)
                //,new SqlParameter("@PROD_TYPE",GBLProduct.PROD_TYPE)
                //,new SqlParameter("@LICENSED_TO",GBLProduct.LICENSED_TO)
                //,new SqlParameter("@LICENSE_TYPE",GBLProduct.LICENSE_TYPE)
                //,new SqlParameter("@VALID_UNTIL",GBLProduct.VALID_UNTIL)
                //,new SqlParameter("@FORCE_LICENSE",GBLProduct.FORCE_LICENSE)
                //,new SqlParameter("@COPY_RIGHT",GBLProduct.COPY_RIGHT)
                //,new SqlParameter("@ORG_ID",GBLProduct.ORG_ID)
                //,new SqlParameter("@CREATED_BY",GBLProduct.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",GBLProduct.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",GBLProduct.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",GBLProduct.LAST_MODIFIED_ON)
			};
            Parameters = parameters;

		}
	}
}

