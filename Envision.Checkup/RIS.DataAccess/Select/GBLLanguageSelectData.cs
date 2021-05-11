using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class GBLLanguageSelectData : DataAccessBase
    {
        private GBLLanguageSelectDataParameters _GBLLanguageSelectDataParameters;

        public GBLLanguageSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLLanguage_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _GBLLanguageSelectDataParameters = new GBLLanguageSelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _GBLLanguageSelectDataParameters.Parameters);
            return ds;
        }
        public DataSet Get2()
        {
            StoredProcedureName = StoredProcedure.Name.GBLLanguage_Select2.ToString();
            DataSet ds;
            _GBLLanguageSelectDataParameters = new GBLLanguageSelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _GBLLanguageSelectDataParameters.Parameters);
            return ds;
        }
    }

    public class GBLLanguageSelectDataParameters
    {
        private SqlParameter[] _parameters;

        public GBLLanguageSelectDataParameters()
        {
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@p_orgid"	, new GBLEnvVariable().OrgID )
				
				
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
