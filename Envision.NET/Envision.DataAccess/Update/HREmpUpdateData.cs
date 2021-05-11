//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    18/06/2009 04:37:10
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class HREmpUpdateData : DataAccessBase 
	{
        public HR_EMP HR_EMP { get; set; }

		public  HREmpUpdateData()
		{
            HR_EMP = new HR_EMP();
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_Update;
            //StoredProcedureName = StoredProcedure.Prc_HR_EMP_Update_withJobTitle;		
        }
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Update(DbTransaction tran) 
		{
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters =
            {
                Parameter("@EMP_ID",HR_EMP.EMP_ID)
                ,Parameter("@EMP_UID",HR_EMP.EMP_UID)
                ,Parameter("@USER_NAME",HR_EMP.USER_NAME)
                ,Parameter("@SECURITY_QUESTION",HR_EMP.SECURITY_QUESTION)
                ,Parameter("@SECURITY_ANSWER",HR_EMP.SECURITY_ANSWER)
                ,Parameter("@PWD",HR_EMP.PWD)
                ,Parameter("@UNIT_ID",HR_EMP.UNIT_ID==0?null:HR_EMP.UNIT_ID)
                ,Parameter("@JOB_TYPE",HR_EMP.JOB_TYPE)
                ,Parameter("@IS_RADIOLOGIST",HR_EMP.IS_RADIOLOGIST)
                ,Parameter("@SALUTATION",HR_EMP.SALUTATION)
                ,Parameter("@FNAME",HR_EMP.FNAME)
                ,Parameter("@MNAME",HR_EMP.MNAME)
                ,Parameter("@LNAME",HR_EMP.LNAME)
                ,Parameter("@TITLE_ENG",HR_EMP.TITLE_ENG)
                ,Parameter("@FNAME_ENG",HR_EMP.FNAME_ENG)
                ,Parameter("@MNAME_ENG",HR_EMP.MNAME_ENG)
                ,Parameter("@LNAME_ENG",HR_EMP.LNAME_ENG)
                ,Parameter("@GENDER",HR_EMP.GENDER)
                ,Parameter("@DEFAULT_LANG",HR_EMP.DEFAULT_LANG==0?null:HR_EMP.DEFAULT_LANG)
                ,Parameter("@AUTH_LEVEL_ID",HR_EMP.AUTH_LEVEL_ID==0?null:HR_EMP.AUTH_LEVEL_ID)
                ,Parameter("@ALLOW_OTHERS_TO_FINALIZE",HR_EMP.ALLOW_OTHERS_TO_FINALIZE)
                ,Parameter("@IS_ACTIVE",HR_EMP.IS_ACTIVE)
                ,Parameter("@SUPPORT_USER",HR_EMP.SUPPORT_USER)
                ,Parameter("@CAN_KILL_SESSION",HR_EMP.CAN_KILL_SESSION)
                ,Parameter("@EMP_REPORT_FOOTER1",HR_EMP.EMP_REPORT_FOOTER1)
                ,Parameter("@EMP_REPORT_FOOTER2",HR_EMP.EMP_REPORT_FOOTER2)
                ,Parameter("@ORG_ID",HR_EMP.ORG_ID)
                ,Parameter("@LAST_MODIFIED_BY",HR_EMP.LAST_MODIFIED_BY)
                ,Parameter("@IS_RESIDENT",HR_EMP.IS_RESIDENT)
                ,Parameter("@JOBTITLE_ID",HR_EMP.JOBTITLE_ID==0?null:HR_EMP.JOBTITLE_ID)
                ,Parameter("@IS_FELLOW",HR_EMP.IS_FELLOW)

                ,Parameter("@PHONE_HOME",HR_EMP.PHONE_HOME)
                ,Parameter("@PHONE_MOBILE",HR_EMP.PHONE_MOBILE)
                ,Parameter("@PHONE_OFFICE",HR_EMP.PHONE_OFFICE)
                
                ,Parameter("@EMAIL_PERSONAL",HR_EMP.EMAIL_PERSONAL)
                ,Parameter("@EMAIL_OFFICIAL",HR_EMP.EMAIL_OFFICIAL)
                ,Parameter("@CAN_EXCEED_SCHEDULE",HR_EMP.CAN_EXCEED_SCHEDULE)
                
            };
            return parameters;
        }
	}
}

