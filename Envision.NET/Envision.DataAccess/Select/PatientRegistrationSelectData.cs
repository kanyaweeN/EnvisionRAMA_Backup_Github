using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class PatientRegistrationSelectData : DataAccessBase
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public PatientRegistrationSelectData()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            StoredProcedureName = StoredProcedure.Prc_Patient_Registration_Select;
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
                                                      Parameter("@REG_ID",HIS_REGISTRATION.REG_ID)
                                                    , Parameter("@HN",HIS_REGISTRATION.HN)
                                       };
            return parameters;
        }
    }
}
