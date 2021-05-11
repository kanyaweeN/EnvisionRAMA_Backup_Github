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
    public class RISSF02SelectData : DataAccessBase
    {

        private RISSF02SelectDataParameters _rissf02selectdataparameters;

        public RISSF02SelectData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF02_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _rissf02selectdataparameters = new RISSF02SelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString);
            return ds;

        }

        
    }

    public class RISSF02SelectDataParameters
    {
        private SqlParameter[] _parameters;

        public RISSF02SelectDataParameters()
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
