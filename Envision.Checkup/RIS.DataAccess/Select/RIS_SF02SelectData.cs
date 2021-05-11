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
    public class RIS_SF02SelectData : DataAccessBase
    {

        private RIS_SF02SelectDataParameters _RIS_SF02selectdataparameters;

        public RIS_SF02SelectData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF02_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            //_patientselectdataparameters = new PatienSelectDataParameters();
            _RIS_SF02selectdataparameters = new RIS_SF02SelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString);
            return ds;

        }

        
    }

    public class RIS_SF02SelectDataParameters
    {
        private SqlParameter[] _parameters;

        public RIS_SF02SelectDataParameters()
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
