using Envision.Database.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Envision.Database.DataAccess.Select
{
    public class AdrSelectData : MsSqlEngine
    {
        public AdrSelectData()
        {
        }
        public DataSet SearchAdrByMode(string mode, string mrn, string drugCode)
        {
            if (string.IsNullOrEmpty(mrn)) return null;

            StoredProcedureName = StoredProcedure.Prc_RIS_ADR_SelectByMode;
            Parameters = new DbParameter[] {
                DoParameter("@MODE",mode),
                DoParameter("@MRN",mrn),
                DoParameter("@DRUG_CODE",drugCode),
            };
            bool returnFlag = false;
            return SelectData(out returnFlag);
        }
    }
}
