using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISPatientDestinationSelect : DataAccessBase
    {
        public RIS_PATIENTDESTINATION RIS_PATIENTDESTINATION { get; set; }
        
        public RISPatientDestinationSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_PATIENTDESTINATION_Select;
        }

        public DataSet GetData()
        {
            this.ParameterList = new DbParameter[]{
                Parameter("@ORG_ID", this.RIS_PATIENTDESTINATION.ORG_ID)
            };
            return this.ExecuteDataSet();
        }
    }
}
