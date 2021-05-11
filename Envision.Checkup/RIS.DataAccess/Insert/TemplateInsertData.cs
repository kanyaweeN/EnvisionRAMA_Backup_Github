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
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class TemplateInsertData : DataAccessBase
    {
        private ExamResultTemplate _temp;

        private TemplateInsertDataParameters _templatedataparameters;

        public TemplateInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_Template_Insert.ToString();
        }

        public void Add()
        {
            _templatedataparameters = new TemplateInsertDataParameters(ExamResultTemplate);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _templatedataparameters.Parameters);
            
        }

        public ExamResultTemplate ExamResultTemplate
        {
            get { return _temp; }
            set { _temp = value; }
        }
    }

    public class TemplateInsertDataParameters
    {
        private ExamResultTemplate _temp;
        private SqlParameter[] _parameters;

        public TemplateInsertDataParameters(ExamResultTemplate template)
        {
            ExamResultTemplate = template;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@EXAM_ID"	, ExamResultTemplate.ExamID ) ,
                new SqlParameter( "@TEMPLATE_NAME"	, ExamResultTemplate.TemplateNmae ) ,
				new SqlParameter( "@TEMPLATE_TEXT"        , ExamResultTemplate.TemplateText ) ,
				new SqlParameter( "@TEMPLATE_TYPE"	, ExamResultTemplate.TemplateType ) ,
				new SqlParameter( "@AUTO_APPLY"	    , ExamResultTemplate.AutoApply ) ,
				new SqlParameter( "@ORG_ID"		, ExamResultTemplate.OrgID ) ,
				new SqlParameter( "@CREATED_BY"	    , ExamResultTemplate.CreatedBy ), 
                new SqlParameter( "@SHARE_WITH"	    , ExamResultTemplate.ShareWith ), 

			};

            Parameters = parameters;
        }

        public ExamResultTemplate ExamResultTemplate
        {
            get { return _temp; }
            set { _temp = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
