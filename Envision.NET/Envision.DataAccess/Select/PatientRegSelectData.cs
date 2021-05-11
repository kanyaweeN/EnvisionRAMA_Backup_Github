using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class PatientRegSelectData : DataAccessBase
    {
        public string PATREG { get; set; }

        public PatientRegSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_PatientReg;
        }

        public DataSet Get(string patreg)
        {
            PATREG = patreg;
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                      Parameter("@REG_UID",PATREG)
                                       };
            return parameters;
        }

    }
}
