using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class MGPatientHistoryComparisonUpdate : DataAccessBase
    {
        public MG_PATIENTHISTORYCOMPARISON MG_PATIENTHISTORYCOMPARISON { get; set; }

        public MGPatientHistoryComparisonUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_PATIENTHISTORYCOMPARISON_UPDATE;
        }

        public void UpdateData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter pComparedOn = null;
            if (this.MG_PATIENTHISTORYCOMPARISON.COMPARED_ON == DateTime.MinValue)
                pComparedOn = Parameter("@COMPARED_ON", DBNull.Value);
            else
                pComparedOn = Parameter("@COMPARED_ON", this.MG_PATIENTHISTORYCOMPARISON.COMPARED_ON);
            DbParameter[] parameters = { 
                                            Parameter("@COMPARISON_ID", this.MG_PATIENTHISTORYCOMPARISON.COMPARISON_ID),
                                            Parameter("@REG_ID", this.MG_PATIENTHISTORYCOMPARISON.REG_ID),
                                            Parameter("@COMPARED_TYPE", this.MG_PATIENTHISTORYCOMPARISON.COMPARED_TYPE),
                                            Parameter("@COMPARED_BY", this.MG_PATIENTHISTORYCOMPARISON.COMPARED_BY),
                                            pComparedOn,
                                            Parameter("@COMPARING_EXAM", this.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM),
                                            Parameter("@COMPARED_WITH", this.MG_PATIENTHISTORYCOMPARISON.COMPARED_WITH),
                                            Parameter("@COMPARED_TEXT", this.MG_PATIENTHISTORYCOMPARISON.COMPARED_TEXT),
                                            Parameter("@ORG_ID", this.MG_PATIENTHISTORYCOMPARISON.ORG_ID),
                                            Parameter("@LAST_MODIFIED_BY", this.MG_PATIENTHISTORYCOMPARISON.LAST_MODIFIED_BY)
                                       };

            return parameters;
        }
    }
}
