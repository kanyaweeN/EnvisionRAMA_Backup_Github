using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common.Common;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class GBLLanguageInsertData :DataAccessBase
    {
        private GBLLanguageInsertDataParameters _GBLLanguageInsertDataParameters;
        private GBLLanguage langItem;



        public GBLLanguageInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLLanguage_Insert.ToString();
        }

        public void Get()
        {
            _GBLLanguageInsertDataParameters = new GBLLanguageInsertDataParameters(this.langItem);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _GBLLanguageInsertDataParameters.Parameters);
        }

        public GBLLanguage LangItem
        {
            get { return langItem; }
            set { langItem = value; }
        }
    }

    public class GBLLanguageInsertDataParameters
    {
        private SqlParameter[] _parameters;
        private GBLLanguage _langItem;

        public GBLLanguageInsertDataParameters(GBLLanguage langItem)
        {
            this._langItem = langItem;
            Build();
        }

        private void Build()
        {

            
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@p_lang_uid"	, this._langItem.LandUid ),
                new SqlParameter( "@p_lang_name"	, this._langItem.LangName ),
                new SqlParameter( "@p_is_active"	, this._langItem.IsActive ),
                new SqlParameter( "@p_create_by"	, new GBLEnvVariable().UserID ),
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
