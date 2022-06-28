using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class MGPatientHistoryComparisonInsert : DataAccessBase
    {
        public MG_PATIENTHISTORYCOMPARISON MG_PATIENTHISTORYCOMPARISON { get; set; }
        public DbTransaction Trans { get; set; }
        public MGPatientHistoryComparisonInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_PATIENTHISTORYCOMPARISON_INSERT;
        }

        public void InsertData(bool UseTransaction)
        {
            this.ParameterList = this.BuildParameters();
            if (UseTransaction && (this.Trans != null))
                this.Transaction = this.Trans;
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
                                            Parameter("@REG_ID", this.MG_PATIENTHISTORYCOMPARISON.REG_ID),
                                            Parameter("@COMPARED_TYPE", this.MG_PATIENTHISTORYCOMPARISON.COMPARED_TYPE),
                                            Parameter("@COMPARED_BY", this.MG_PATIENTHISTORYCOMPARISON.COMPARED_BY),
                                            pComparedOn,
                                            Parameter("@COMPARING_EXAM", this.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM),
                                            Parameter("@COMPARED_WITH", this.MG_PATIENTHISTORYCOMPARISON.COMPARED_WITH),
                                            Parameter("@COMPARED_TEXT", this.MG_PATIENTHISTORYCOMPARISON.COMPARED_TEXT),
                                            Parameter("@ORG_ID", this.MG_PATIENTHISTORYCOMPARISON.ORG_ID),
                                            Parameter("@CREATED_BY", this.MG_PATIENTHISTORYCOMPARISON.CREATED_BY)
                                       };

            return parameters;
        }
    }
}
