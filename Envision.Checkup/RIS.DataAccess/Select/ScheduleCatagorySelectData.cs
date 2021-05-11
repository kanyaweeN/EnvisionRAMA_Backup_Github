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
    public class ScheduleCatagorySelectData : DataAccessBase
    {
        private EmpScheduleCatagory _catdata;
        private EmpScheduleSelectDataParameters _catagoryselectdataparameters;

        public ScheduleCatagorySelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_EmployeeScheduleCatagory.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _catagoryselectdataparameters = new EmpScheduleSelectDataParameters(EmpScheduleCatagory);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _catagoryselectdataparameters.Parameters);
            return ds;

        }

        public EmpScheduleCatagory EmpScheduleCatagory
        {
            get { return _catdata; }
            set { _catdata = value; }
        }
    }

    public class EmpScheduleSelectDataParameters
    {
        private EmpScheduleCatagory _catdata;
        private SqlParameter[] _parameters;

        public EmpScheduleSelectDataParameters(EmpScheduleCatagory catdata)
        {
            EmpScheduleCatagory = catdata;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                new SqlParameter( "@SP_TYPE"	, EmpScheduleCatagory.SpType ),
                new SqlParameter( "@CATEGORY_ID"	, EmpScheduleCatagory.CategoryID ),
				new SqlParameter( "@ORG_ID"	, EmpScheduleCatagory.OrgID )
                
				
		    };

            Parameters = parameters;
        }

        public EmpScheduleCatagory EmpScheduleCatagory
        {
            get { return _catdata; }
            set { _catdata = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
