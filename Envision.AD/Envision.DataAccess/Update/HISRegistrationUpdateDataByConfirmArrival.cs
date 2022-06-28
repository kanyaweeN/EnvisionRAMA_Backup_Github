using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class HISRegistrationUpdateDataByConfirmArrival : DataAccessBase
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public HISRegistrationUpdateDataByConfirmArrival()
        {
            this.StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_UpdateFromArrival;
            //this.StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_UpdateFromArrivalNew;
        }

        public void UpdateData()
        {
            this.ParameterList = new DbParameter[] { 
                Parameter("@REG_ID", this.HIS_REGISTRATION.REG_ID),
                Parameter("@TITLE", this.HIS_REGISTRATION.TITLE),
                Parameter("@TITLE_ENG", this.HIS_REGISTRATION.TITLE_ENG),
                Parameter("@FNAME_ENG", this.HIS_REGISTRATION.FNAME_ENG),
                Parameter("@LNAME_ENG", this.HIS_REGISTRATION.LNAME_ENG),
                Parameter("@LAST_MODIFIED_BY", this.HIS_REGISTRATION.LAST_MODIFIED_BY),
                Parameter("@ORG_ID", this.HIS_REGISTRATION.ORG_ID),
                Parameter("@IS_FOREIGNER", this.HIS_REGISTRATION.IS_FOREIGNER),
            };
            this.ExecuteNonQuery();
        }
    }
}
