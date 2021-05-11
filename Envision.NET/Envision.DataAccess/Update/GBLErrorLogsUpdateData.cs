using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class GBLErrorLogsUpdateData: DataAccessBase
    {
        public GBL_ERRORLOGS GBL_ERRORLOGS { get; set; }

        public GBLErrorLogsUpdateData()
        {
            GBL_ERRORLOGS = new GBL_ERRORLOGS();
            StoredProcedureName = StoredProcedure.Prc_GBL_Errorlogs_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                    Parameter("@ERROR_ID",GBL_ERRORLOGS.ERROR_ID),
Parameter("@PIC_PATH",GBL_ERRORLOGS.PIC_PATH)
                                      };
            return parameters;
        }
    }
}
