using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class PatientRegistrationUpdateData : DataAccessBase
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public PatientRegistrationUpdateData()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            StoredProcedureName = StoredProcedure.Prc_Patient_Registration_Update;
        }

        public DataSet Update()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            //ExecuteNonQuery();
            ds = ExecuteDataSet();
            return ds;
        }
        public bool DateOverflow(DateTime dt)
        {
            if (dt.Year <= 1753 || dt.Year >= 9999)
                return true;
            else
                return false;
        }
        private DbParameter[] buildParameter()
        {

            DbParameter pPicture = Parameter();
            pPicture.DbType = DbType.Binary;
            pPicture.ParameterName = "@Picture";
            if (HIS_REGISTRATION.Picture_Forsave == null)
                pPicture.Value = DBNull.Value;
            else
                pPicture.Value = HIS_REGISTRATION.Picture_Forsave;

            if (HIS_REGISTRATION.Picture_Forsave == null)
            {
                HIS_REGISTRATION.Picture_Forsave = new byte[] { };
            }

            if (DateOverflow(Convert.ToDateTime(HIS_REGISTRATION.DOB)))
            {
                DbParameter[] parameters = {
                                            Parameter("@REG_ID",HIS_REGISTRATION.REG_ID),
                                            Parameter("@HN",HIS_REGISTRATION.HN),                                            

                                            Parameter("@TITLE",HIS_REGISTRATION.TITLE),
                                            Parameter("@FNAME",HIS_REGISTRATION.FNAME),
                                            Parameter("@MNAME",HIS_REGISTRATION.MNAME),
                                            Parameter("@LNAME",HIS_REGISTRATION.LNAME),
                                            Parameter("@TITLE_ENG",HIS_REGISTRATION.TITLE_ENG),
                                            Parameter("@FNAME_ENG",HIS_REGISTRATION.FNAME_ENG),
                                            Parameter("@MNAME_ENG",HIS_REGISTRATION.MNAME_ENG),
                                            Parameter("@LNAME_ENG",HIS_REGISTRATION.LNAME_ENG),

                                            Parameter("@SSN",HIS_REGISTRATION.SSN),
                                            Parameter("@NATIONALITY",HIS_REGISTRATION.NATIONALITY),
                                            Parameter("@MARITAL_STATUS",HIS_REGISTRATION.MARITAL_STATUS),
                                            Parameter("@PASSPORT_NO",HIS_REGISTRATION.PASSPORT_NO),

                                            Parameter("@GENDER",HIS_REGISTRATION.GENDER),
                                            Parameter("@DOB",null),
                                            Parameter("@AGE",HIS_REGISTRATION.AGE),
                                            Parameter("@BLOOD_GROUP",HIS_REGISTRATION.BLOOD_GROUP),

                                            Parameter("@PHONE1",HIS_REGISTRATION.PHONE1),
                                            Parameter("@PHONE2",HIS_REGISTRATION.PHONE2),
                                            Parameter("@EMAIL",HIS_REGISTRATION.EMAIL),
                                            Parameter("@ADDR1",HIS_REGISTRATION.ADDR1),
                                            Parameter("@ADDR2",HIS_REGISTRATION.ADDR2),
                                            Parameter("@ADDR3",HIS_REGISTRATION.ADDR3),
                                            Parameter("@ADDR4",HIS_REGISTRATION.ADDR4),
                                            Parameter("@ADDR5",HIS_REGISTRATION.ADDR5),
                                                                                 
                                            Parameter("@EM_CONTACT_PERSON",HIS_REGISTRATION.EM_CONTACT_PERSON),
                                            Parameter("@EM_ADDR",HIS_REGISTRATION.EM_ADDR),
                                            Parameter("@EM_PHONE",HIS_REGISTRATION.EM_PHONE),
                                            Parameter("@EM_RELATION",HIS_REGISTRATION.EM_RELATION),

                                            Parameter("@ALLERGIES",HIS_REGISTRATION.ALLERGIES), 
                                            Parameter("@INSURANCE_TYPE",HIS_REGISTRATION.INSURANCE_TYPE),
                                            //Parameter("@Picture",pPicture),                                                            
                                            Parameter("@Picture",HIS_REGISTRATION.Picture_Forsave),
                                        };
                return parameters;
            }
            else
            {
                
                DbParameter[] parameters = {
                                            Parameter("@REG_ID",HIS_REGISTRATION.REG_ID),
                                            Parameter("@HN",HIS_REGISTRATION.HN),                                            
                                            //Parameter("@REG_DT",HIS_REGISTRATION.REG_DT),

                                            Parameter("@TITLE",HIS_REGISTRATION.TITLE),
                                            Parameter("@FNAME",HIS_REGISTRATION.FNAME),
                                            Parameter("@MNAME",HIS_REGISTRATION.MNAME),
                                            Parameter("@LNAME",HIS_REGISTRATION.LNAME),
                                            Parameter("@TITLE_ENG",HIS_REGISTRATION.TITLE_ENG),
                                            Parameter("@FNAME_ENG",HIS_REGISTRATION.FNAME_ENG),
                                            Parameter("@MNAME_ENG",HIS_REGISTRATION.MNAME_ENG),
                                            Parameter("@LNAME_ENG",HIS_REGISTRATION.LNAME_ENG),

                                            Parameter("@SSN",HIS_REGISTRATION.SSN),
                                            Parameter("@NATIONALITY",HIS_REGISTRATION.NATIONALITY),
                                            Parameter("@MARITAL_STATUS",HIS_REGISTRATION.MARITAL_STATUS),
                                            Parameter("@PASSPORT_NO",HIS_REGISTRATION.PASSPORT_NO),

                                            Parameter("@GENDER",HIS_REGISTRATION.GENDER),
                                            Parameter("@DOB",HIS_REGISTRATION.DOB),
                                            Parameter("@AGE",HIS_REGISTRATION.AGE),
                                            Parameter("@BLOOD_GROUP",HIS_REGISTRATION.BLOOD_GROUP),

                                            Parameter("@PHONE1",HIS_REGISTRATION.PHONE1),
                                            Parameter("@PHONE2",HIS_REGISTRATION.PHONE2),
                                            Parameter("@EMAIL",HIS_REGISTRATION.EMAIL),
                                            Parameter("@ADDR1",HIS_REGISTRATION.ADDR1),
                                            Parameter("@ADDR2",HIS_REGISTRATION.ADDR2),
                                            Parameter("@ADDR3",HIS_REGISTRATION.ADDR3),
                                            Parameter("@ADDR4",HIS_REGISTRATION.ADDR4),
                                            Parameter("@ADDR5",HIS_REGISTRATION.ADDR5),
                                                                                 
                                            Parameter("@EM_CONTACT_PERSON",HIS_REGISTRATION.EM_CONTACT_PERSON),
                                            Parameter("@EM_ADDR",HIS_REGISTRATION.EM_ADDR),
                                            Parameter("@EM_PHONE",HIS_REGISTRATION.EM_PHONE),
                                            Parameter("@EM_RELATION",HIS_REGISTRATION.EM_RELATION),

                                            Parameter("@ALLERGIES",HIS_REGISTRATION.ALLERGIES), 
                                            Parameter("@INSURANCE_TYPE",HIS_REGISTRATION.INSURANCE_TYPE)
                ,
                                            //pPicture,        
                                            Parameter("@Picture",HIS_REGISTRATION.Picture_Forsave),
                                        };
                return parameters;
            }

        }

    }
}