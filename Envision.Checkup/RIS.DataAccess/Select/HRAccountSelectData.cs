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
    public class HRAccountSelectData : DataAccessBase
    {
        private HRAccount _hraccount;
        private HRAccountSelectDataParameters _hraccountselectdataparameters;

        public HRAccountSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_HR_EMP_GetAccount.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _hraccountselectdataparameters = new HRAccountSelectDataParameters(HRAccount);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _hraccountselectdataparameters.Parameters);
            return ds;
        }

        public HRAccount HRAccount
        {
            get { return _hraccount; }
            set { _hraccount = value; }
        }
    }

    public class HRAccountSelectDataParameters
    {
        private HRAccount _hraccount;
        private SqlParameter[] _parameters;

        public HRAccountSelectDataParameters(HRAccount hraccount)
        {
            _hraccount = hraccount;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                new SqlParameter(   "@Username"    ,    _hraccount.Username )
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
