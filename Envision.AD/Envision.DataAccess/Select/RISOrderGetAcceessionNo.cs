using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Select
{
    public class RISOrderGetAcceessionNo : DataAccessBase
    {
        public RISOrderGetAcceessionNo()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_GenAccession;
        }

        public string GetAccessoionNo(int modalityId, int unitid)
        {
            this.ParameterList = new DbParameter[] { 
                Parameter("@MODALITY", modalityId),
                Parameter("@REF_UNIT", unitid)
            };
            DataSet dsResult = this.ExecuteDataSet();
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        return dsResult.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}
