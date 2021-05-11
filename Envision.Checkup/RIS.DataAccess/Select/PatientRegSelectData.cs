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
    public class PatientRegSelectData : DataAccessBase
    {
        private string _patreg;
        private PatientRegSelectDataParameters _productselectdataparameters;

        public PatientRegSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_PatientReg.ToString();
        }

        public DataSet Get(string patreg)
        {
            _patreg = patreg;
            DataSet ds;
            _productselectdataparameters = new PatientRegSelectDataParameters(_patreg);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _productselectdataparameters.Parameters);
            return ds;

        }


    }

    public class PatientRegSelectDataParameters
    {
        private string _patreg;
        private SqlParameter[] _parameters;

        public PatientRegSelectDataParameters(string patreg)
        {
            _patreg = patreg;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@REG_UID"	,  _patreg )
             				
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
