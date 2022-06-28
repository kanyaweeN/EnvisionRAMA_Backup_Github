using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RisRiskCategoriseUpdate : DataAccessBase
    {
        public RIS_RISKCATEGORISE RIS_RISKCATEGORISE;
        public RisRiskCategoriseUpdate()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RISKCATEGORIES_UPDATE;
        }
        public void UpdateData()
        {
            ParameterList = BuildParameters();
            ExecuteNonQuery();
        }
        public DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = {
                                           Parameter("@RISK_CAT_UID", RIS_RISKCATEGORISE.RISK_CAT_UID),
                                           Parameter("@RISK_CAT_DESC", RIS_RISKCATEGORISE.RISK_CAT_DESC),
                                           Parameter("@ORG_ID", RIS_RISKCATEGORISE.ORG_ID),
                                           Parameter("@LAST_MODIFIED_BY", RIS_RISKCATEGORISE.LAST_MODIFIED_BY),
                                           Parameter("@RISK_CAT_ID", RIS_RISKCATEGORISE.RISK_CAT_ID)
                                       };
            return parameters;
        }
    }
}
