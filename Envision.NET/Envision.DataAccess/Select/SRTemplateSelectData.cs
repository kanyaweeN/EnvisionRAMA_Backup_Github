using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class SRTemplateSelectData : DataAccessBase
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }

        public SRTemplateSelectData() {
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_Select;
            SR_TEMPLATE = new SR_TEMPLATE();
        }

        public DataTable Get()
        {
            DataTable data = new DataTable();
            data = ExecuteDataTable();
            return data;
        }
        public DataSet GetById()
        {
            DataSet data = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_SelectById;
            ParameterList = buildParameter();
            data = ExecuteDataSet();
            return data;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                 Parameter("@TEMPLATE_ID",SR_TEMPLATE.TEMPLATE_ID),
                 Parameter("@ORG_ID",SR_TEMPLATE.ORG_ID)
            };
            return parameters;
        }

        public DataTable GetByExam() {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_SelectByExam;
            ParameterList = buildParameterByExam();
            dtt = ExecuteDataTable();
            return dtt;
        }
        private DbParameter[] buildParameterByExam()
        {
            DbParameter[] parameters ={			
                 Parameter("@EXAM_ID",SR_TEMPLATE.EXAM_ID)
            };
            return parameters;
        }

        public DataTable GetTemplate() {
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_Select; 
            return ExecuteDataTable();
        }

        public DataSet SelectData()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_SelectById;
            this.ParameterList = this.BuildParameters();
            DataSet ds = this.ExecuteDataSet();
            ds.Tables[0].TableName = "TEMPLATE";
            ds.Tables[1].TableName = "TEMPLATE_PART";
            ds.Tables[2].TableName = "QUESTIONS";
            ds.Tables[3].TableName = "QUESTIONDTL";
            ds.Tables[4].TableName = "QUESTIONDTLCHILD";
            return ds.Copy();
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] parameter = { 
                                            Parameter("@TEMPLATE_ID", SR_TEMPLATE.TEMPLATE_ID),
                                            Parameter("@ORG_ID", SR_TEMPLATE.ORG_ID)
                                      };

            return parameter;
        }
    }
}
