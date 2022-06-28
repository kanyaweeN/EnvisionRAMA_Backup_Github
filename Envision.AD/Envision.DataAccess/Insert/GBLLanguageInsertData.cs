using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLLanguageInsertData :DataAccessBase
    {
        public GBL_LANGUAGE GBL_LANGUAGE { get; set; }

        public GBLLanguageInsertData()
        {
            GBL_LANGUAGE = new GBL_LANGUAGE();
            StoredProcedureName = StoredProcedure.GBLLanguage_Insert;
        }

        public void Get()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@p_lang_uid"	, GBL_LANGUAGE.LANG_UID ),
                Parameter( "@p_lang_name"	, GBL_LANGUAGE.LANG_NAME ),
                Parameter( "@p_is_active"	, GBL_LANGUAGE.IS_ACTIVE ),
                Parameter( "@p_create_by"	, new GBLEnvVariable().UserID ),
            Parameter( "@p_orgid"	, new GBLEnvVariable().OrgID )
            };
            return parameters;
        }
    }
}
