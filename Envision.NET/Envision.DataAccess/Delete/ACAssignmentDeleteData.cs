using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Delete
{
    public class ACAssignmentDeleteData : DataAccessBase
    {
        public AC_ASSIGNMENT AC_ASSIGNMENT { get; set; }

        public ACAssignmentDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_Delete;
        }

        public DataSet DeleteData()
        {
            this.ParameterList = new DbParameter[]{
                Parameter("@ASSIGNED_BY", this.AC_ASSIGNMENT.ASSIGNED_BY),
                Parameter("@ACCESSION_NO", this.AC_ASSIGNMENT.ACCESSION_NO),
                Parameter("@ORG_ID", this.AC_ASSIGNMENT.ORG_ID)
            };

            return this.ExecuteDataSet();
        }
    }
}
