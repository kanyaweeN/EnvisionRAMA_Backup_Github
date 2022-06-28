using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class SRQuestionsAnswerSelectData : DataAccessBase
    {
        public SR_QUESTIONSANSWERS SR_QUESTIONSANSWERS { get; set; }

        public SRQuestionsAnswerSelectData() {
            SR_QUESTIONSANSWERS = new SR_QUESTIONSANSWERS();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERS_Check;
        }

        public DataTable GetData() {
            DataTable dtt = new DataTable();
            ParameterList = buildParameter();
            dtt = ExecuteDataTable();
            return dtt;
        }
        public DataTable GetTempalteByAccession() {
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATEANSWERSPART_SelectByAcc;
            DataTable dtt = new DataTable();
            ParameterList = buildParameter();
            dtt = ExecuteDataTable();
            return dtt;
        }
        public DataSet GetAnswersData() {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERS_Select;
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                 Parameter("@ACCESSION_NO",SR_QUESTIONSANSWERS.ACCESSION_NO)
            };
            return parameters;
        }

        public DataTable GetTempalteById(int TemplateId)
        {
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATEANSWERSPART_SelectById;
            DataTable dtt = new DataTable();
            ParameterList = buildParameterId(TemplateId);
            dtt = ExecuteDataTable();
            return dtt;
        }
        private DbParameter[] buildParameterId(int TemplateId)
        {
            DbParameter[] parameters ={			
                 Parameter("@TEMPLATE_ID",TemplateId)
            };
            return parameters;
        }
    }
}
