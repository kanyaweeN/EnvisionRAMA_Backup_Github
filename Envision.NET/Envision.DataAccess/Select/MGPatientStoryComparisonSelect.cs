using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class MGPatientStoryComparisonSelect : DataAccessBase
    {
        public MG_PATIENTHISTORYCOMPARISON MG_PATIENTHISTORYCOMPARISON { get; set; }
        public MGPatientStoryComparisonSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_PATIENTHISTORYCOMPARISON_SELECT;
        }

        public DataSet GetData(int mode)
        {
            DataSet result = null;
            this.ParameterList = this.BuildParameters(mode);
            result = this.ExecuteDataSet();
            return result;
        }

        private DbParameter[] BuildParameters(int mode)
        {
            DbParameter[] parameters = { 
                                            Parameter("@ORG_ID", MG_PATIENTHISTORYCOMPARISON.ORG_ID),
                                            Parameter("@COMPARISON_ID", MG_PATIENTHISTORYCOMPARISON.COMPARISON_ID),
                                            Parameter("@COMPARING_EXAM", MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM),
                                            Parameter("@REG_ID", MG_PATIENTHISTORYCOMPARISON.REG_ID),
                                            Parameter("@MODE", mode),
                                       };
            return parameters;
        }
    }
}
