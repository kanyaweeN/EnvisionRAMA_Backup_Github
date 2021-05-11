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
    public class FavouriteSelectData : DataAccessBase
    {
        private FavSelectDataParameters _envselectdataparameters;

        public FavouriteSelectData(string sp)
        {
            if (sp == "1")
            {
                StoredProcedureName = StoredProcedure.Name.Prc_GBLUserMenu.ToString();
            }
            else if (sp == "2")
            {
                StoredProcedureName = StoredProcedure.Name.Prc_GBLUserSubMenu.ToString();
            }
            else
            {
                StoredProcedureName = StoredProcedure.Name.Prc_GBLMyFavourite.ToString();
            }
        }

        public DataSet Get()
        {
            DataSet ds;
            _envselectdataparameters = new FavSelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _envselectdataparameters.Parameters);
            return ds;

        }


    }

    public class FavSelectDataParameters
    {

        private SqlParameter[] _parameters;

        public FavSelectDataParameters()
        {
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@EMP_ID"	, new GBLEnvVariable().UserID  )
             				
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
