/*
 * Project	: RIS
 *
 * Author   : Tossapol Anchaleechamaikorn
 * eMail    : yod.jim@gmail.com
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
    public class RISSF09SelectData : DataAccessBase
    {

        private RISSF09SelectDataParameters _rissf09selectdataparameters;

        public RISSF09SelectData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF09_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _rissf09selectdataparameters = new RISSF09SelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString);
            return ds;

        }

        
    }

    public class RISSF09SelectDataParameters
    {
        private SqlParameter[] _parameters;

        public RISSF09SelectDataParameters()
        {
            Build();
        }

        private void Build()
        {

            Parameters = null ;
        }

       
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
