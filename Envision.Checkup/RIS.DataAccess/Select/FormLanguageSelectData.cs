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
    public class FormLanguageSelectData : DataAccessBase
    {
        private FormLanguage _formlangage;
        private FormLanguageSelectDataParameters _formlanguageselectdataparameters;

        public FormLanguageSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_FormObject_Label.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _formlanguageselectdataparameters = new FormLanguageSelectDataParameters(FormLanguage);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _formlanguageselectdataparameters.Parameters);
            return ds;

        }

        public FormLanguage FormLanguage
        {
            get { return _formlangage; }
            set { _formlangage = value; }
        }
    }

    public class FormLanguageSelectDataParameters
    {
        private FormLanguage _formlangage;
        private SqlParameter[] _parameters;

        public FormLanguageSelectDataParameters(FormLanguage formlanguage)
        {
            FormLanguage = formlanguage;
            Build();
        }

        private void Build()
        {

            
            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@SP_Types"	, FormLanguage.ProcedureType ),
                new SqlParameter( "@LangID"		    , FormLanguage.LanguageID ) ,
				new SqlParameter( "@FormID"        , FormLanguage.FormID ),
                new SqlParameter( "@OrgID"        , new GBLEnvVariable().OrgID )
				
				
		    };

            Parameters = parameters;
        }

        public FormLanguage FormLanguage
        {
            get { return _formlangage; }
            set { _formlangage = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
