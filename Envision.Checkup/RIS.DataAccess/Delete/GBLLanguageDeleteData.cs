using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common.Common;

namespace RIS.DataAccess.Delete
{
    public class GBLLanguageDeleteData :DataAccessBase
    {
        private GBLLanguageDeleteDataParameters _GBLLanguageDeleteDataParameters;
        private string langId;



        public GBLLanguageDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLLanguage_Delete.ToString();
        }

        public void Get()
        {
            _GBLLanguageDeleteDataParameters = new  GBLLanguageDeleteDataParameters(this.langId);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _GBLLanguageDeleteDataParameters.Parameters);
        }

        public string LangId
        {
            get { return langId; }
            set { langId = value; }
        }
    }

    public class GBLLanguageDeleteDataParameters
    {
        private SqlParameter[] _parameters;
        private string langId;

        public GBLLanguageDeleteDataParameters(string langId)
        {
            this.langId = langId;
            Build();
        }

        private void Build()
        {

            
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@p_modify_by"	, new GBLEnvVariable().UserID ),
                new SqlParameter( "@p_orgid"	, new GBLEnvVariable().OrgID ),
                new SqlParameter( "@p_delete"	, Int32.Parse( this.langId) )
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
