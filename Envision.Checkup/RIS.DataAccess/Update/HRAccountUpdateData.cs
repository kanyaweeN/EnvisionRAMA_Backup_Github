using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class HRAccountUpdateData : DataAccessBase
    {
        private HRAccount _hraccount;
        private HRAccountInsertDataParameters _gblenvinsertdataparameters;

        public HRAccountUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_HR_EMP_UpdateAccount.ToString();
        }

        public void Add()
        {
            _gblenvinsertdataparameters = new HRAccountInsertDataParameters(HRAccount);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblenvinsertdataparameters.Parameters);
        }

        public HRAccount HRAccount
        {
            get { return _hraccount; }
            set { _hraccount = value; }
        }
    }
    public class HRAccountInsertDataParameters
    {
        private HRAccount _hraccount;
        private SqlParameter[] _parameters;

        public HRAccountInsertDataParameters(HRAccount hraccount)
        {
            HRAccount = hraccount;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@USER_NAME"         ,   HRAccount.Username   ),
                new SqlParameter( "@PWD"        ,   HRAccount.Password  ),
                new SqlParameter( "@SECURITY_QUESTION"        ,   HRAccount.SecurityQuestion  ),
                new SqlParameter( "@SECURITY_ANSWER"        ,   HRAccount.SecurityAnswer  ),
			};

            Parameters = parameters;
        }

        public HRAccount HRAccount
        {
            get { return _hraccount; }
            set { _hraccount = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
