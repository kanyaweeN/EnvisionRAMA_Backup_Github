using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLEmployeeUpdateData : DataAccessBase
    {
        public HR_EMP HR_EMP { get; set; }

        public GBLEmployeeUpdateData()
        {
            HR_EMP = new HR_EMP();
            StoredProcedureName = StoredProcedure.GBLEmployee_UpdateAccount;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                    Parameter( "@Empid" ,    HR_EMP.EMP_ID),
                    
                    Parameter( "@Username" ,  HR_EMP.USER_NAME),
                    Parameter( "@Password" ,  HR_EMP.PWD),
                    Parameter( "@Empuid" ,     HR_EMP.EMP_UID),
                    Parameter( "@Unitid" ,     HR_EMP.UNIT_ID),
                    Parameter( "@Gender" ,     HR_EMP.GENDER),

                    Parameter( "@Salutation" , HR_EMP.SALUTATION),
                    Parameter( "@Fname" ,      HR_EMP.FNAME),
                    Parameter( "@Mname" ,      HR_EMP.MNAME),
                    Parameter( "@Lname" ,      HR_EMP.LNAME),

                    Parameter( "@Titleeng" ,   HR_EMP.TITLE_ENG),
                    Parameter( "@Fnameeng" ,   HR_EMP.FNAME_ENG),
                    Parameter( "@Mnameeng" ,   HR_EMP.MNAME_ENG),
                    Parameter( "@Lnameeng" ,   HR_EMP.LNAME_ENG),

                    Parameter( "@Securityquestion" , HR_EMP.SECURITY_QUESTION),
                    Parameter( "@Securityanswer" , HR_EMP.SECURITY_ANSWER),

                    Parameter( "@Defaultlang" ,    HR_EMP.DEFAULT_LANG),
                    Parameter( "@Authlvid" ,   HR_EMP.AUTH_LEVEL_ID),
                    Parameter( "@Jobtype" ,    HR_EMP.JOB_TYPE),

                    Parameter( "@Active" , HR_EMP.IS_ACTIVE),
                    Parameter( "@Radiologist" ,    HR_EMP.IS_RADIOLOGIST),
                    Parameter( "@Allowfinalize" ,  HR_EMP.ALLOW_OTHERS_TO_FINALIZE),
                    Parameter( "@Support" ,    HR_EMP.SUPPORT_USER),
                    Parameter( "@Cankill"  ,HR_EMP.CAN_KILL_SESSION),

                    Parameter( "@Orgid"  ,HR_EMP.ORG_ID),

                    Parameter( "@Emp_report_footer1"  ,HR_EMP.EMP_REPORT_FOOTER1),
                    Parameter( "@Emp_report_footer2"  ,HR_EMP.EMP_REPORT_FOOTER2),
                                      };
            return parameters;
        }
    }
}
