using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class FormLanguageSelectData : DataAccessBase
    {
        public FormLanguage FormLanguage { get; set; }

        public FormLanguageSelectData()
        {
            FormLanguage = new FormLanguage();
            StoredProcedureName = StoredProcedure.Prc_FormObject_Label;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                             Parameter( "@SP_Types"	        , FormLanguage.ProcedureType ),
                                             Parameter( "@LangID"		    , FormLanguage.LanguageID ) ,
		                                     Parameter( "@FormID"           , FormLanguage.FormID ),
                                             Parameter( "@OrgID"            , new GBLEnvVariable().OrgID )
                                       };
            return parameters;
        }
        
        
    }
}
