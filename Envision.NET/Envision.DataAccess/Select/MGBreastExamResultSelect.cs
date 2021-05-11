using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class MGBreastExamResultSelect : DataAccessBase
    {
        public MG_BREASTEXAMRESULT MG_BREASTEXAMRESULT { get; set; }
        public MGBreastExamResultSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTEXAMRESULT_SELECT;
        }
        public DataSet GetData(int Mode)
        {
            DataSet result = null;
            ParameterList = this.BuildParameters(Mode);
            result = this.ExecuteDataSet();
            return result;
        }

        private DbParameter[] BuildParameters(int Mode)
        {
            DbParameter[] parameters = { 
                                            Parameter("@ACCESSION_NO", MG_BREASTEXAMRESULT.ACCESSION_NO),
                                            Parameter("@ORG_ID", MG_BREASTEXAMRESULT.ORG_ID),
                                            Parameter("@MODE", Mode)
                                       };
            return parameters;
        }
    }
}
