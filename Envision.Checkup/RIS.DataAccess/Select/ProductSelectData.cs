/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;
using RIS.Common.Common;


namespace RIS.DataAccess.Select
{
    public class ProductSelectData : DataAccessBase
    {
        private ProductSelectDataParameters _productselectdataparameters;

        public ProductSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLProduct.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _productselectdataparameters = new ProductSelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _productselectdataparameters.Parameters);
            return ds;

        }

       
    }

    public class ProductSelectDataParameters
    {
       
        private SqlParameter[] _parameters;

        public ProductSelectDataParameters()
        {
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@ORG_ID"	, new GBLEnvVariable().OrgID  )
             				
		    };

            Parameters = parameters;
        }
        
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
