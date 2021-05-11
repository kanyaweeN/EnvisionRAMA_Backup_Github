using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using System.Data;

namespace RIS.DataAccess.Insert
{
    public class PatientRegistrationInsertData : DataAccessBase
    {
        HISRegistration _hisreg;

        public PatientRegistrationInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_Patient_Registration_Insert.ToString();
        }

        public DataSet Add()
        {
            PatientRegistrationInsertDataParameter parameters = new PatientRegistrationInsertDataParameter(HISRegistration);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = new DataSet();
            ds = dbhelper.Run(this.ConnectionString, parameters.SqlParameter);
            return ds;
        }

        public HISRegistration HISRegistration
        {
            get { return _hisreg; }
            set { _hisreg = value; }
        }
    }

    public class PatientRegistrationInsertDataParameter
    {
        HISRegistration _hisreg;
        SqlParameter[] _parameters;

        public PatientRegistrationInsertDataParameter(HISRegistration hisreg)
        {
            _hisreg = hisreg;
            Build();
        }

        private void Build()
        {
            

            if (DateOverflow(_hisreg.DOB))
            {
                SqlParameter[] parameters = {
                                            new SqlParameter("@REG_ID",-1),
                                            new SqlParameter("@HN",_hisreg.HN),
                                            new SqlParameter("@REG_DT",_hisreg.REG_DT),

                                            new SqlParameter("@TITLE",_hisreg.TITLE),
                                            new SqlParameter("@FNAME",_hisreg.FNAME),
                                            new SqlParameter("@MNAME",_hisreg.MNAME),
                                            new SqlParameter("@LNAME",_hisreg.LNAME),
                                            new SqlParameter("@TITLE_ENG",_hisreg.TITLE_ENG),
                                            new SqlParameter("@FNAME_ENG",_hisreg.FNAME_ENG),
                                            new SqlParameter("@MNAME_ENG",_hisreg.MNAME_ENG),
                                            new SqlParameter("@LNAME_ENG",_hisreg.LNAME_ENG),

                                            new SqlParameter("@SSN",_hisreg.SSN),
                                            new SqlParameter("@NATIONALITY",_hisreg.NATIONALITY),
                                            new SqlParameter("@MARITAL_STATUS",_hisreg.MARITAL_STATUS),
                                            new SqlParameter("@PASSPORT_NO",_hisreg.PASSPORT_NO),                             
                                            
                                            new SqlParameter("@GENDER",_hisreg.GENDER),
                                            new SqlParameter("@DOB",null),
                                            new SqlParameter("@AGE",_hisreg.AGE),
                                            new SqlParameter("@BLOOD_GROUP",_hisreg.BLOOD_GROUP),
                                            
                                            new SqlParameter("@PHONE1",_hisreg.PHONE1),
                                            new SqlParameter("@PHONE2",_hisreg.PHONE2),
                                            new SqlParameter("@EMAIL",_hisreg.EMAIL),
                                            new SqlParameter("@ADDR1",_hisreg.ADDR1),
                                            new SqlParameter("@ADDR2",_hisreg.ADDR2),
                                            new SqlParameter("@ADDR3",_hisreg.ADDR3),
                                            new SqlParameter("@ADDR4",_hisreg.ADDR4),
                                            new SqlParameter("@ADDR5",_hisreg.ADDR5),
                                            
                                            new SqlParameter("@EM_CONTACT_PERSON",_hisreg.EM_CONTACT_PERSON),
                                            new SqlParameter("@EM_ADDR",_hisreg.EM_ADDR),
                                            new SqlParameter("@EM_PHONE",_hisreg.EM_PHONE),
                                            new SqlParameter("@EM_RELATION",_hisreg.EM_RELATION),

                                            new SqlParameter("@ALLERGIES",_hisreg.ALLERGIES),    
                                            new SqlParameter("@INSURANCE_TYPE",_hisreg.INSURANCE_TYPE),                                           
                                            
                                            new SqlParameter("@Picture",_hisreg.Picture),
                                         };
                SqlParameter = parameters;
            }
            else
            {
                SqlParameter[] parameters = {
                                            new SqlParameter("@REG_ID",-1),
                                            new SqlParameter("@HN",_hisreg.HN),
                                            new SqlParameter("@REG_DT",_hisreg.REG_DT),

                                            new SqlParameter("@TITLE",_hisreg.TITLE),
                                            new SqlParameter("@FNAME",_hisreg.FNAME),
                                            new SqlParameter("@MNAME",_hisreg.MNAME),
                                            new SqlParameter("@LNAME",_hisreg.LNAME),
                                            new SqlParameter("@TITLE_ENG",_hisreg.TITLE_ENG),
                                            new SqlParameter("@FNAME_ENG",_hisreg.FNAME_ENG),
                                            new SqlParameter("@MNAME_ENG",_hisreg.MNAME_ENG),
                                            new SqlParameter("@LNAME_ENG",_hisreg.LNAME_ENG),

                                            new SqlParameter("@SSN",_hisreg.SSN),
                                            new SqlParameter("@NATIONALITY",_hisreg.NATIONALITY),
                                            new SqlParameter("@MARITAL_STATUS",_hisreg.MARITAL_STATUS),
                                            new SqlParameter("@PASSPORT_NO",_hisreg.PASSPORT_NO),                             
                                            
                                            new SqlParameter("@GENDER",_hisreg.GENDER),
                                            new SqlParameter("@DOB",_hisreg.DOB),
                                            new SqlParameter("@AGE",_hisreg.AGE),
                                            new SqlParameter("@BLOOD_GROUP",_hisreg.BLOOD_GROUP),
                                            
                                            new SqlParameter("@PHONE1",_hisreg.PHONE1),
                                            new SqlParameter("@PHONE2",_hisreg.PHONE2),
                                            new SqlParameter("@EMAIL",_hisreg.EMAIL),
                                            new SqlParameter("@ADDR1",_hisreg.ADDR1),
                                            new SqlParameter("@ADDR2",_hisreg.ADDR2),
                                            new SqlParameter("@ADDR3",_hisreg.ADDR3),
                                            new SqlParameter("@ADDR4",_hisreg.ADDR4),
                                            new SqlParameter("@ADDR5",_hisreg.ADDR5),
                                            
                                            new SqlParameter("@EM_CONTACT_PERSON",_hisreg.EM_CONTACT_PERSON),
                                            new SqlParameter("@EM_ADDR",_hisreg.EM_ADDR),
                                            new SqlParameter("@EM_PHONE",_hisreg.EM_PHONE),
                                            new SqlParameter("@EM_RELATION",_hisreg.EM_RELATION),

                                            new SqlParameter("@ALLERGIES",_hisreg.ALLERGIES),    
                                            new SqlParameter("@INSURANCE_TYPE",_hisreg.INSURANCE_TYPE),    
                    
                                            new SqlParameter("@Picture",_hisreg.Picture),
                                        };
                SqlParameter = parameters;
            }
            
        }

        private bool DateOverflow(DateTime dt)
        {
            if (dt.Year <= 1753 || dt.Year >= 9999)
                return true;
            else
                return false;
        }

        public SqlParameter[] SqlParameter
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}