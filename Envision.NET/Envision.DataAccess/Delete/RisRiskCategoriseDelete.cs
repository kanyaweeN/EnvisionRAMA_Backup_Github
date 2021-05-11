using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RisRiskCategoriseDelete : DataAccessBase
    {
        public RIS_RISKCATEGORISE RIS_RISKCATEGORISE;
        public RisRiskCategoriseDelete()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RISKCATEGORIES_DELETE;
        }
        public void DeleteData()
        {
            ParameterList = BuildParameters();
            ExecuteNonQuery();
        }
        public DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = {
                                           Parameter("@RISK_CAT_ID", RIS_RISKCATEGORISE.RISK_CAT_ID)
                                       };
            return parameters;
        }
    }
}
