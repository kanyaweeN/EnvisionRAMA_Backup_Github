using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common.Common;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class GBLLanguageUpdateData :DataAccessBase
    {
        private GBLLanguageUpdateDataParameters _GBLLanguageUpdateDataParameters;
        private GBLLanguage langItem;



        public GBLLanguageUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLLanguage_Update.ToString();
        }

        public void Get()
        {
            _GBLLanguageUpdateDataParameters = new GBLLanguageUpdateDataParameters(this.langItem);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _GBLLanguageUpdateDataParameters.Parameters);
        }

        public GBLLanguage LangItem
        {
            get { return langItem; }
            set { langItem = value; }
        }
    }

    public class GBLLanguageUpdateDataParameters
    {
        private SqlParameter[] _parameters;
        private GBLLanguage _langItem;

        public GBLLanguageUpdateDataParameters(GBLLanguage langItem)
        {
            this._langItem = langItem;
            Build();
        }

        private void Build()
        {

            
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@p_lang_id"	, this._langItem.LangId ),
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
