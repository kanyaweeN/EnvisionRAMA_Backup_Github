using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISSessionmaxappUpdateData: DataAccessBase 
	{
        public RIS_SESSIONMAXAPP RIS_SESSIONMAXAPP { get; set; }

        public RISSessionmaxappUpdateData()
		{
            RIS_SESSIONMAXAPP = new RIS_SESSIONMAXAPP();
            StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONMAXAPP_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@MODALITY_ID",RIS_SESSIONMAXAPP.MODALITY_ID),
Parameter("@SESSION_ID",RIS_SESSIONMAXAPP.SESSION_ID),
Parameter("@WEEKDAY",RIS_SESSIONMAXAPP.WEEKDAY),
Parameter("@MAX_APP",RIS_SESSIONMAXAPP.MAX_APP),
Parameter("@MAX_IPD_APP",RIS_SESSIONMAXAPP.MAX_IPD_APP),
Parameter("@MAX_ONLINE_APP",RIS_SESSIONMAXAPP.MAX_ONLINE_APP),
Parameter("@LAST_MODIFIED_BY",RIS_SESSIONMAXAPP.LAST_MODIFIED_BY),

                                      };
            return parameters;
        }
	}
}