using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class DistributionNewUpdateData : DataAccessBase
    {
        public DistributionNew DistributionNew { get; set; }

        public DistributionNewUpdateData()
        {
            DistributionNew = new DistributionNew();
            StoredProcedureName = StoredProcedure.Prc_DistributionNew_Update;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter assigned_to = Parameter();
            assigned_to.ParameterName = "@assigned_to";
            if (DistributionNew.assignedTo == null)
                assigned_to.Value = DBNull.Value;
            else
                assigned_to.Value = DistributionNew.assignedTo == 0 ? (object)DBNull.Value : DistributionNew.assignedTo;

            DbParameter[] parameters ={
                Parameter( "@accession_no"         ,  DistributionNew.accessionno  ),
                assigned_to,
                Parameter( "@last_modified_by"     ,  DistributionNew.LAST_MODIFIED_BY),
                Parameter("@priority",DistributionNew.PRIORITY),
                                      };
            return parameters;
        }
    }
}
