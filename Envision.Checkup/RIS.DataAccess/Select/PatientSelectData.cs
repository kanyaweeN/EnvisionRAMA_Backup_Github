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
    public class PatientSelectData : DataAccessBase
    {

        private PatienSelectDataParameters _patientselectdataparameters;

        public PatientSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF04_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _patientselectdataparameters = new PatienSelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString);
            return ds;

        }

        
    }

    public class PatienSelectDataParameters
    {
        private SqlParameter[] _parameters;

        public PatienSelectDataParameters()
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
