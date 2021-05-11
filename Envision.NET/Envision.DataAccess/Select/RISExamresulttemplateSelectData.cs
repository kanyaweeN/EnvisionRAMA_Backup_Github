using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExamresulttemplateSelectData : DataAccessBase 
	{
        public RIS_EXAMRESULT RIS_EXAMRESULT { get; set; }
        public RIS_EXAMRESULTTEMPLATE RIS_EXAMRESULTTEMPLATE { get; set; }
		public  RISExamresulttemplateSelectData()
		{
            RIS_EXAMRESULT = new RIS_EXAMRESULT();
            RIS_EXAMRESULTTEMPLATE = new RIS_EXAMRESULTTEMPLATE();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTEMPLATE_Select;
		}
	
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataTable GetTemplateShare()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.RIS_EXAMTEMPLATESHARE_SelectBy;
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds.Tables[0];
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { Parameter("@EMP_ID",RIS_EXAMRESULT.EMP_ID),
                                            Parameter("@MODE",RIS_EXAMRESULT.TEMPMODE),
                                       };
            return parameters;
        }

        public DataTable GetTemplateById() {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTEMPLATE_SelectById;
            ParameterList = buildParameterById();
            dtt = ExecuteDataTable();
            return dtt;
        }
        private DbParameter[] buildParameterById()
        {
            DbParameter[] parameters = { 
                                           Parameter("@TEMPLATE_ID",RIS_EXAMRESULTTEMPLATE.TEMPLATE_ID),
                                       };
            return parameters;
        }

        public DataTable GetTemplateAuto() {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTEMPLATE_AutoApply;
            ParameterList = buildParameterByAuto();
            dtt = ExecuteDataTable();
            return dtt;
        }
        private DbParameter[] buildParameterByAuto()
        {
            DbParameter[] parameters = { 
                                           Parameter("@EXAM_ID",RIS_EXAMRESULTTEMPLATE.EXAM_ID),
                                           Parameter("@CREATED_BY",RIS_EXAMRESULTTEMPLATE.CREATED_BY),
                                       };
            return parameters;
        }
	}
}

