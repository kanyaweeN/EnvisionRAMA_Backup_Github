using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class DistributionSelect: DataAccessBase
    {
            public DistributionCommon DistributionCommon { get; set; }

            public DistributionSelect()
            {
                StoredProcedureName = StoredProcedure.Prc_Distribution_select;
                DistributionCommon = new DistributionCommon();
            }

            public DataSet Get()
            {
                DataSet ds = new DataSet();
                ParameterList = buildParameter();
                ds = ExecuteDataSet();
                return ds;

            }
            private DbParameter[] buildParameter()
            {
                DbParameter[] parameters = { 
                                                Parameter( "@datefrom"     ,DistributionCommon.datefrom),
                                                Parameter( "@todate"     ,DistributionCommon.todate),
				                                Parameter( "@accessionno"    ,DistributionCommon.accessionno),
                                                Parameter( "@hn"             ,DistributionCommon.hn),
                                                Parameter( "@assigned_to"          ,DistributionCommon.assignedTo)
                                       };
                return parameters;
            }
    }
}
