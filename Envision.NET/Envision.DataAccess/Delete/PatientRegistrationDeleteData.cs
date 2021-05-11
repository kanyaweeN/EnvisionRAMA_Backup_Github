using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class PatientRegistrationDeleteData : DataAccessBase
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public PatientRegistrationDeleteData()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            StoredProcedureName = StoredProcedure.Prc_Patient_Registration_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@REG_ID",HIS_REGISTRATION.REG_ID)
                                     };
            return parameters;
        }
    }
}