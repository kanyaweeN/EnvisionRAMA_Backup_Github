using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class MGPatientHistoryComparisonDelete : DataAccessBase
    {
        public MG_PATIENTHISTORYCOMPARISON MG_PATIENTHISTORYCOMPARISON { get; set; }

        public MGPatientHistoryComparisonDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_PATIENTHISTORYCOMPARISON_DELETE;
        }

        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@COMPARING_EXAM", MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM)
                                       };

            return parameters;
        }
    }
}
