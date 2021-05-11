//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    30/03/2552 10:43:30
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISExamresulttemplateSelectData : DataAccessBase 
	{

        private RISExamresult _risexamresult;
		public  RISExamresulttemplateSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTTEMPLATE_Select.ToString();
		}
	
		public DataSet GetData()
		{
            RISExamresultTemplateSelectWorkListParameters param = new RISExamresultTemplateSelectWorkListParameters(RISExamresult);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
			return ds;
		}
        public RISExamresult RISExamresult
        {
            get { return _risexamresult; }
            set { _risexamresult = value; }
        }
        public DataTable GetTemplateShare() {
            RISExamresultTemplateSelectWorkListParameters param = new RISExamresultTemplateSelectWorkListParameters(RISExamresult);
            StoredProcedureName = StoredProcedure.Name.RIS_EXAMTEMPLATESHARE_SelectBy.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
            return ds.Tables[0];
        }
	}
    public class RISExamresultTemplateSelectWorkListParameters
    {
        private RISExamresult _risexamresult;
        private SqlParameter[] _parameters;

        public RISExamresultTemplateSelectWorkListParameters(RISExamresult risexamresult)
        {
            RISExamresult = risexamresult;
            Build();
        }

        public RISExamresult RISExamresult
        {
            get { return _risexamresult; }
            set { _risexamresult = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter[] parameters ={			
             
                new SqlParameter("@EMP_ID",RISExamresult.EMP_ID)
           
			};
            _parameters = parameters;
        }
    }
}

