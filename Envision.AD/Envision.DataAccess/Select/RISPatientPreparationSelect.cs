using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Envision.DataAccess.Select
{
    public class RISPatientPreparationSelect : DataAccessBase
    {
        public RISPatientPreparationSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_PATIENTPREPARATION_SELECT;
        }

        public DataSet GetData()
        {
            return this.ExecuteDataSet();
        }
    }
}
