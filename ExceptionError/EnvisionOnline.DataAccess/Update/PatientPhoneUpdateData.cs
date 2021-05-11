using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Update
{
   public class PatientPhoneUpdateData: DataAccessBase
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public PatientPhoneUpdateData()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            StoredProcedureName = StoredProcedure.Prc_Patient_Registration_PhoneUpdate;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@REG_ID",HIS_REGISTRATION.REG_ID),
                Parameter("@PHONE1",HIS_REGISTRATION.PHONE1),
                Parameter("@PHONE2",HIS_REGISTRATION.PHONE2),
                Parameter("@EMAIL",HIS_REGISTRATION.EMAIL),
            };
            return parameters;
        }
    }
}
