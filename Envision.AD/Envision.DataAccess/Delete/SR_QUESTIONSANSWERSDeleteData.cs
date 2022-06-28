using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class SR_QUESTIONSANSWERSDeleteData : DataAccessBase
    {
        public SR_QUESTIONSANSWERS SR_QUESTIONSANSWERS { get; set; }

        public SR_QUESTIONSANSWERSDeleteData() {
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERS_Delete;
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@ACCESSION_NO",SR_QUESTIONSANSWERS.ACCESSION_NO)
                                     };
            return parameters;
        }
    }
}
