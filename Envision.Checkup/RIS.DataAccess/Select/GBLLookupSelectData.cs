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


namespace RIS.DataAccess.Select
{
    public class GBLLookupSelectData : DataAccessBase
    {
        private string _qry;
        private GBLLookupSelectDataParameters _formlanguageselectdataparameters;

        public GBLLookupSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLLookup.ToString();
        }

        public DataSet Get(string qry)
        {
            _qry = qry;
            DataSet ds;
            _formlanguageselectdataparameters = new GBLLookupSelectDataParameters(_qry);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _formlanguageselectdataparameters.Parameters);
            return ds;

        }

       
    }

    public class GBLLookupSelectDataParameters
    {
        string _qry;
        private SqlParameter[] _parameters;

        public GBLLookupSelectDataParameters(string qry)
        {
            _qry = qry;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@QRY"	, _qry ),
          			
				
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
