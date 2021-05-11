using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLLanguageUpdateData :DataAccessBase
    {
        public GBL_LANGUAGE GBL_LANGUAGE { get; set; }

        public GBLLanguageUpdateData()
        {
            GBL_LANGUAGE = new GBL_LANGUAGE();
            StoredProcedureName = StoredProcedure.GBLLanguage_Update;
        }

        public void Get()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@p_lang_id"	, this.GBL_LANGUAGE.LANG_ID ),
                Parameter( "@p_lang_uid"	, this.GBL_LANGUAGE.LANG_UID ),
                Parameter( "@p_lang_name"	, this.GBL_LANGUAGE.LANG_NAME ),
                Parameter( "@p_is_active"	, this.GBL_LANGUAGE.IS_ACTIVE ),
                Parameter( "@p_create_by"	, new GBLEnvVariable().UserID ),
                Parameter( "@p_orgid"	, new GBLEnvVariable().OrgID )
                                      };
            return parameters;
        }

    }
}
