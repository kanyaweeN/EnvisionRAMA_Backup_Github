//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    02/06/2552 08:25:41
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class HREmpInsertData : DataAccessBase 
	{
		private HREmp	_hremp;
        private HREmpInsertDataFromHISParameters param;
		public  HREmpInsertData()
		{
			//StoredProcedureName = StoredProcedure.Name.Prc_HR_EMP_Insert.ToString();
		}
        public HREmp HREmp
        {
            get { return _hremp; }
            set { _hremp = value; }
        }
        public bool Add()
        {
            HREmpInsertDataParameters param1;
            param1 = new HREmpInsertDataParameters(HREmp);
            StoredProcedureName = StoredProcedure.Name.Prc_HR_EMP_Insert.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, param1.Parameters);
            return true;
        }
        public bool Add(bool flag, bool autocommit)
        {
            if (flag)
            {
                DataAccess.DataAccessBase.BeginTransaction();
                SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
                HREmpInsertDataParameters param1;
                param1 = new HREmpInsertDataParameters(HREmp);
                StoredProcedureName = StoredProcedure.Name.Prc_HR_EMP_Insert.ToString();
                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                dbhelper.Run(tran, param1.Parameters);
                if (autocommit) DataAccess.DataAccessBase.Commit();
            }
            else Add();
            return true;
        }
        public int AddFromHIS() { 
            param = new HREmpInsertDataFromHISParameters(HREmp);
            StoredProcedureName = StoredProcedure.Name.Prc_HR_EMP_InsertFromHIS.ToString();
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds=  dbhelper.Run(base.ConnectionString,param.Parameters);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            return id;
        }
	}
	public class HREmpInsertDataFromHISParameters 
	{
		private HREmp _hremp;
		private SqlParameter[] _parameters;
        public HREmpInsertDataFromHISParameters(HREmp hremp)
		{
			HREmp=hremp;
			Build();
		}
		public  HREmp	HREmp
		{
			get{return _hremp;}
			set{_hremp=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter("@EMP_UID",HREmp.EMP_UID)
                ,new SqlParameter("@USER_NAME",HREmp.USER_NAME)
                ,new SqlParameter("@FNAME",HREmp.FNAME)
                ,new SqlParameter("@LNAME",HREmp.LNAME)
                ,new SqlParameter("@ORG_ID",HREmp.ORG_ID)
                ,new SqlParameter("@CREATED_BY",HREmp.CREATED_BY)
			};
			_parameters = parameters;
		}
    }

    public class HREmpInsertDataParameters
    {
        private HREmp _hremp;
        private SqlParameter[] _parameters;
        public HREmpInsertDataParameters(HREmp hremp)
        {
            HREmp = hremp;
            Build();
        }
        public HREmp HREmp
        {
            get { return _hremp; }
            set { _hremp = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        public void Build()
        {
            SqlParameter[] parameters ={			
                new SqlParameter("@EMP_UID",HREmp.EMP_UID)
                ,new SqlParameter("@USER_NAME",HREmp.USER_NAME)
                ,new SqlParameter("@SECURITY_QUESTION",HREmp.SECURITY_QUESTION)
                ,new SqlParameter("@SECURITY_ANSWER",HREmp.SECURITY_ANSWER)
                ,new SqlParameter("@PWD",HREmp.PWD)
                ,new SqlParameter("@UNIT_ID",HREmp.UNIT_ID==0?null:HREmp.UNIT_ID)
                //,new SqlParameter("@JOBTITLE_ID",HREmp.JOBTITLE_ID)
                ,new SqlParameter("@JOB_TYPE",HREmp.JOB_TYPE)
                ,new SqlParameter("@IS_RADIOLOGIST",HREmp.IS_RADIOLOGIST)
                ,new SqlParameter("@SALUTATION",HREmp.SALUTATION)
                ,new SqlParameter("@FNAME",HREmp.FNAME)
                ,new SqlParameter("@MNAME",HREmp.MNAME)
                ,new SqlParameter("@LNAME",HREmp.LNAME)
                ,new SqlParameter("@TITLE_ENG",HREmp.TITLE_ENG)
                ,new SqlParameter("@FNAME_ENG",HREmp.FNAME_ENG)
                ,new SqlParameter("@MNAME_ENG",HREmp.MNAME_ENG)
                ,new SqlParameter("@LNAME_ENG",HREmp.LNAME_ENG)
                ,new SqlParameter("@GENDER",HREmp.GENDER)
                //,new SqlParameter("@EMAIL_PERSONAL",HREmp.EMAIL_PERSONAL)
                //,new SqlParameter("@EMAIL_OFFICIAL",HREmp.EMAIL_OFFICIAL)
                //,new SqlParameter("@PHONE_HOME",HREmp.PHONE_HOME)
                //,new SqlParameter("@PHONE_MOBILE",HREmp.PHONE_MOBILE)
                //,new SqlParameter("@PHONE_OFFICE",HREmp.PHONE_OFFICE)
                //,new SqlParameter("@PREFERRED_PHONE",HREmp.PREFERRED_PHONE)
                //,new SqlParameter("@PABX_EXT",HREmp.PABX_EXT)
                //,new SqlParameter("@FAX_NO",HREmp.FAX_NO)
                //,new SqlParameter("@DOB",HREmp.DOB)
                //,new SqlParameter("@BLOOD_GROUP",HREmp.BLOOD_GROUP)
                ,new SqlParameter("@DEFAULT_LANG",HREmp.DEFAULT_LANG==0?null:HREmp.DEFAULT_LANG)
                //,new SqlParameter("@RELIGION",HREmp.RELIGION)
                //,new SqlParameter("@PE_ADDR1",HREmp.PE_ADDR1)
                //,new SqlParameter("@PE_ADDR2",HREmp.PE_ADDR2)
                //,new SqlParameter("@PE_ADDR3",HREmp.PE_ADDR3)
                //,new SqlParameter("@PE_ADDR4",HREmp.PE_ADDR4)
                ,new SqlParameter("@AUTH_LEVEL_ID",HREmp.AUTH_LEVEL_ID==0?null:HREmp.AUTH_LEVEL_ID)
                //,new SqlParameter("@REPORTING_TO",HREmp.REPORTING_TO)
                ,new SqlParameter("@ALLOW_OTHERS_TO_FINALIZE",HREmp.ALLOW_OTHERS_TO_FINALIZE)
                //,new SqlParameter("@LAST_PWD_MODIFIED",HREmp.LAST_PWD_MODIFIED)
                //,new SqlParameter("@LAST_LOGIN",HREmp.LAST_LOGIN)
                //,new SqlParameter("@CARD_NO",HREmp.CARD_NO)
                //,new SqlParameter("@PLACE_OF_BIRTH",HREmp.PLACE_OF_BIRTH)
                //,new SqlParameter("@NATIONALITY",HREmp.NATIONALITY)
                //,new SqlParameter("@M_STATUS",HREmp.M_STATUS)
                ,new SqlParameter("@IS_ACTIVE",HREmp.IS_ACTIVE)
                ,new SqlParameter("@SUPPORT_USER",HREmp.SUPPORT_USER)
                ,new SqlParameter("@CAN_KILL_SESSION",HREmp.CAN_KILL_SESSION)
                //,new SqlParameter("@DEFAULT_SHIFT_NO",HREmp.DEFAULT_SHIFT_NO)
                //,new SqlParameter("@IMG_FILE_NAME",HREmp.IMG_FILE_NAME)
                ,new SqlParameter("@EMP_REPORT_FOOTER1",HREmp.EMP_REPORT_FOOTER1)
                ,new SqlParameter("@EMP_REPORT_FOOTER2",HREmp.EMP_REPORT_FOOTER2)
                //,new SqlParameter("@ALLPROPERTIES",HREmp.ALLPROPERTIES)
                //,new SqlParameter("@VISIBLE",HREmp.VISIBLE)
                ,new SqlParameter("@ORG_ID",HREmp.ORG_ID)
                ,new SqlParameter("@CREATED_BY",HREmp.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",HREmp.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",HREmp.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",HREmp.LAST_MODIFIED_ON)
                ,new SqlParameter("@IS_RESIDENT",HREmp.IS_RESIDENT)
			};
            _parameters = parameters;
        }
    }
}

