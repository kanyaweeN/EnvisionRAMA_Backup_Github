using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RisRiskCategoriseInsert : DataAccessBase
    {
        public RIS_RISKCATEGORISE RIS_RISKCATEGORISE;
        public RisRiskCategoriseInsert()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RISKCATEGORIES_INSERT;
        }
        public void InsertData()
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
                                           Parameter("@CREATED_BY", RIS_RISKCATEGORISE.CREATED_BY)
                                       };
            return parameters;
        }
    }
}
