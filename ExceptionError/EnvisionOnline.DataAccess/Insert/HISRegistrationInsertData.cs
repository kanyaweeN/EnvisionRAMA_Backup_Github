using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using System.Data;

namespace EnvisionOnline.DataAccess.Insert
{
    public class HISRegistrationInsertData : DataAccessBase
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        private int action;

        public HISRegistrationInsertData()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_Insert;
            action = 0;
        }
        public HISRegistrationInsertData(bool linkdown)
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            if (linkdown)
            {
                StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_InsertByLinkDown;
                action = 1;
            }
            else
            {
                StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_InsertOrUpdateFromHIS;
                action = 2;
            }
        }

        public int Add()
        {
            int retValue = 0;
            try
            {
                if (action == 0)
                {
                    ParameterList = buildParameter();
                    ExecuteNonQuery();
                    retValue = (int)ParameterList[0].Value; ;
                }
                else if (action == 1)
                {
                    ParameterList = buildParameterLinkdown();
                    ExecuteNonQuery();
                    retValue = (int)ParameterList[0].Value; ;
                }
                else if (action == 2)
                {
                    ParameterList = buildParameterInsertOrUpdate();
                    ExecuteNonQuery();
                    retValue = (int)ParameterList[0].Value; ;
                }
            }
            catch (Exception ex)
            {

            }
            return retValue;
        }
        public int Add(DbTransaction tran)
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return (int)ParameterList[0].Value;
        }

        public int CheckHISData(HIS_REGISTRATION his)//(string HN)
        {
            int retValue = 0;
            try
            {

                his = new HIS_REGISTRATION();
                StoredProcedureName = StoredProcedure.Prc_HIS_InsertFromHIS;
                ParameterList = buildParameterByHIS();
                ExecuteNonQuery();
                retValue = (int)ParameterList[0].Value; ;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return retValue;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter pREG_ID = Parameter("@REG_ID", HIS_REGISTRATION.REG_ID);
            pREG_ID.Direction = ParameterDirection.Output;



            DbParameter pREG_DT = Parameter();
            pREG_DT.ParameterName = "@REG_DT";
            if (HIS_REGISTRATION.REG_DT == null)
                pREG_DT.Value = DBNull.Value;
            else
                pREG_DT.Value = HIS_REGISTRATION.REG_DT == DateTime.MinValue ? (object)DBNull.Value : HIS_REGISTRATION.REG_DT;

            DbParameter pDOB = Parameter();
            pDOB.ParameterName = "@DOB";
            if (HIS_REGISTRATION.DOB == null)
                pDOB.Value = DBNull.Value;
            else
                pDOB.Value = HIS_REGISTRATION.DOB == DateTime.MinValue ? (object)DBNull.Value : HIS_REGISTRATION.DOB;

            DbParameter pOCCUPATION_ID = Parameter();
            pOCCUPATION_ID.ParameterName = "@OCCUPATION_ID";
            if (HIS_REGISTRATION.OCCUPATION_ID == null)
                pOCCUPATION_ID.Value = DBNull.Value;
            else
                pOCCUPATION_ID.Value = HIS_REGISTRATION.OCCUPATION_ID == 0 ? (object)DBNull.Value : HIS_REGISTRATION.OCCUPATION_ID;


            DbParameter[] parameters ={
                pREG_ID
                ,Parameter("@HN",HIS_REGISTRATION.HN)
                ,Parameter("@TITLE",HIS_REGISTRATION.TITLE)
                ,pREG_DT
                ,Parameter("@FNAME",HIS_REGISTRATION.FNAME)

                ,Parameter("@MNAME",HIS_REGISTRATION.MNAME)
                ,Parameter("@LNAME",HIS_REGISTRATION.LNAME)
                ,Parameter("@TITLE_ENG",HIS_REGISTRATION.TITLE_ENG)
                ,Parameter("@FNAME_ENG",HIS_REGISTRATION.FNAME_ENG)
                ,Parameter("@MNAME_ENG",HIS_REGISTRATION.MNAME_ENG)

                ,Parameter("@LNAME_ENG",HIS_REGISTRATION.LNAME_ENG)
                ,Parameter("@SSN",HIS_REGISTRATION.SSN)
                ,pDOB
                ,Parameter("@AGE",HIS_REGISTRATION.AGE)
                ,Parameter("@ADDR1",HIS_REGISTRATION.ADDR1)

                ,Parameter("@ADDR2",HIS_REGISTRATION.ADDR2)
                ,Parameter("@ADDR3",HIS_REGISTRATION.ADDR3)
                ,Parameter("@ADDR4",HIS_REGISTRATION.ADDR4)
                ,Parameter("@ADDR5",HIS_REGISTRATION.ADDR5)
                ,Parameter("@PHONE1",HIS_REGISTRATION.PHONE1)

                ,Parameter("@PHONE2",HIS_REGISTRATION.PHONE2)
                ,Parameter("@PHONE3",HIS_REGISTRATION.PHONE3)
                ,Parameter("@EMAIL",HIS_REGISTRATION.EMAIL)
                ,Parameter("@GENDER",HIS_REGISTRATION.GENDER)
                ,Parameter("@MARITAL_STATUS",HIS_REGISTRATION.MARITAL_STATUS)

                ,pOCCUPATION_ID
                ,Parameter("@NATIONALITY",HIS_REGISTRATION.NATIONALITY)
                ,Parameter("@PASSPORT_NO",HIS_REGISTRATION.PASSPORT_NO)
                ,Parameter("@BLOOD_GROUP",HIS_REGISTRATION.BLOOD_GROUP)
                ,Parameter("@RELIGEON",HIS_REGISTRATION.RELIGION)

                ,Parameter("@PATIENT_TYPE",HIS_REGISTRATION.PATIENT_TYPE)
                ,Parameter("@EM_CONTACT_PERSON",HIS_REGISTRATION.EM_CONTACT_PERSON)
                ,Parameter("@EM_RELATION",HIS_REGISTRATION.EM_RELATION)
                ,Parameter("@EM_ADDR",HIS_REGISTRATION.EM_ADDR)
                ,Parameter("@EM_PHONE",HIS_REGISTRATION.EM_PHONE)

                ,Parameter("@INSURANCE_TYPE",HIS_REGISTRATION.INSURANCE_TYPE)
                ,Parameter("@HL7_FORMAT",HIS_REGISTRATION.HL7_FORMAT)
                ,Parameter("@HL7_SEND",HIS_REGISTRATION.HL7_SEND)
                ,Parameter("@LINK_DOWN",HIS_REGISTRATION.LINK_DOWN)
                ,Parameter("@ALLERGIES",HIS_REGISTRATION.ALLERGIES)

                ,Parameter("@ORG_ID",HIS_REGISTRATION.ORG_ID)
                ,Parameter("@CREATED_BY",HIS_REGISTRATION.CREATED_BY)
                ,Parameter("@IS_JOHNDOE",HIS_REGISTRATION.IS_JOHNDOE)
               
            };
            return parameters;
        }
        private DbParameter[] buildParameterLinkdown()
        {
            DbParameter pREG_ID = Parameter("@REG_ID", HIS_REGISTRATION.REG_ID);
            pREG_ID.Direction = ParameterDirection.Output;
            DbParameter pHN = Parameter("@HN", HIS_REGISTRATION.HN);
            DbParameter pREG_DT = Parameter();
            pREG_DT.ParameterName = "@REG_DT";
            if (HIS_REGISTRATION.REG_DT == null)
                pREG_DT.Value = DBNull.Value;
            else
                pREG_DT.Value = HIS_REGISTRATION.REG_DT == DateTime.MinValue ? (object)DBNull.Value : HIS_REGISTRATION.REG_DT;
            DbParameter pFNAME = Parameter("@FNAME", HIS_REGISTRATION.FNAME);
            DbParameter pLNAME = Parameter("@LNAME", HIS_REGISTRATION.LNAME);
            DbParameter pFNAME_ENG = Parameter("@FNAME_ENG", HIS_REGISTRATION.FNAME_ENG);
            DbParameter pLNAME_ENG = Parameter("@LNAME_ENG", HIS_REGISTRATION.LNAME_ENG);
            DbParameter pSSN = Parameter("@SSN", HIS_REGISTRATION.SSN);
            DbParameter pDOB = Parameter();
            pDOB.ParameterName = "@DOB";
            if (HIS_REGISTRATION.DOB == null)
                pDOB.Value = DBNull.Value;
            else
                pDOB.Value = HIS_REGISTRATION.DOB == DateTime.MinValue ? (object)DBNull.Value : HIS_REGISTRATION.DOB;
            DbParameter pPHONE1 = Parameter("@PHONE1", HIS_REGISTRATION.PHONE1);
            DbParameter pGENDER = Parameter("@GENDER", HIS_REGISTRATION.GENDER);
            DbParameter pCREATED_BY = Parameter("@CREATED_BY", HIS_REGISTRATION.CREATED_BY);
            DbParameter pIS_JOHNDOE = Parameter("@IS_JOHNDOE", HIS_REGISTRATION.IS_JOHNDOE);

            DbParameter[] parameters ={
                    pREG_ID
                    ,pHN
                    ,pREG_DT
                    ,pFNAME
                    ,pLNAME
                    ,pFNAME_ENG
                    ,pLNAME_ENG
                    ,pSSN
                    ,pDOB
                    ,pPHONE1
                    ,pGENDER
                    ,pCREATED_BY
                    ,pIS_JOHNDOE
                     //,Parameter("@INSURANCE_TYPE",HIS_REGISTRATION.INSURANCE_TYPE)
            };
            return parameters;
        }
        private DbParameter[] buildParameterInsertOrUpdate()
        {
            DbParameter pREG_ID = Parameter("@REG_ID", HIS_REGISTRATION.REG_ID);
            pREG_ID.Direction = ParameterDirection.Output;
            DbParameter pHN = Parameter("@HN", HIS_REGISTRATION.HN);
            DbParameter pTITLE = Parameter("@TITLE", HIS_REGISTRATION.TITLE);
            DbParameter pFNAME = Parameter("@FNAME", HIS_REGISTRATION.FNAME);
            DbParameter pLNAME = Parameter("@LNAME", HIS_REGISTRATION.LNAME);
            DbParameter pTITLE_ENG = Parameter("@TITLE_ENG", HIS_REGISTRATION.TITLE_ENG);
            DbParameter pFNAME_ENG = Parameter("@FNAME_ENG", HIS_REGISTRATION.FNAME_ENG);
            DbParameter pLNAME_ENG = Parameter("@LNAME_ENG", HIS_REGISTRATION.LNAME_ENG);
            DbParameter pSSN = Parameter("@SSN", HIS_REGISTRATION.SSN);
            DbParameter pDOB = Parameter();
            pDOB.ParameterName = "@DOB";
            if (HIS_REGISTRATION.DOB == null)
                pDOB.Value = DBNull.Value;
            else
                pDOB.Value = HIS_REGISTRATION.DOB == DateTime.MinValue ? (object)DBNull.Value : HIS_REGISTRATION.DOB;
            DbParameter pADDR1 = Parameter("@ADDR1", HIS_REGISTRATION.ADDR1);
            DbParameter pPHONE1 = Parameter("@PHONE1", HIS_REGISTRATION.PHONE1);

            DbParameter pGENDER = Parameter("@GENDER", HIS_REGISTRATION.GENDER);
            DbParameter pCREATED_BY = Parameter("@CREATED_BY", HIS_REGISTRATION.CREATED_BY);
            DbParameter pIS_JOHNDOE = Parameter("@IS_JOHNDOE", HIS_REGISTRATION.IS_JOHNDOE);
            //DbParameter pSHN = Parameter("@SHN", HIS_REGISTRATION.S_HN);
            DbParameter[] parameters ={
                    pREG_ID
                    ,pHN
                    ,pTITLE
                    ,pFNAME
                    ,pLNAME
                    ,pTITLE_ENG
                    ,pFNAME_ENG
                    ,pLNAME_ENG
                    ,pSSN
                    ,pDOB
                    ,pADDR1
                    ,Parameter("@ADDR2",HIS_REGISTRATION.ADDR2)
                    ,Parameter("@ADDR3",HIS_REGISTRATION.ADDR3)
                    ,Parameter("@ADDR4",HIS_REGISTRATION.ADDR4)
                    ,pPHONE1
                    ,Parameter("@PHONE2",HIS_REGISTRATION.PHONE2)
                    ,Parameter("@PHONE3",HIS_REGISTRATION.PHONE3)
                    ,Parameter("@EMAIL",HIS_REGISTRATION.EMAIL)
                    ,pGENDER
                    ,Parameter("@NATIONALITY",HIS_REGISTRATION.NATIONALITY)
                    ,Parameter("@EM_CONTACT_PERSON",HIS_REGISTRATION.EM_CONTACT_PERSON)
                    ,Parameter("@INSURANCE_TYPE",HIS_REGISTRATION.INSURANCE_TYPE)
                    ,Parameter("@ORG_ID",HIS_REGISTRATION.ORG_ID)
                    ,pCREATED_BY
                    ,pIS_JOHNDOE
                    ,Parameter("@IS_FOREIGNER",HIS_REGISTRATION.IS_FOREIGNER)
                    ,Parameter("@PATIENT_ID_LABEL", HIS_REGISTRATION.PATIENT_ID_LABEL)
                    ,Parameter("@PATIENT_ID_DETAIL", HIS_REGISTRATION.PATIENT_ID_DETAIL)
                   // ,pSHN
            };
            return parameters;
        }
        private DbParameter[] buildParameterByHIS()
        {
            DbParameter pREG_ID = Parameter("@REG_ID", HIS_REGISTRATION.REG_ID);
            pREG_ID.Direction = ParameterDirection.Output;
            DbParameter pHN = Parameter("@HN", HIS_REGISTRATION.HN);
            DbParameter pRHN = Parameter("@RHN", HIS_REGISTRATION.REG_ID.ToString());
            DbParameter pTITLE_ENG = Parameter("@TITLE_ENG", HIS_REGISTRATION.TITLE_ENG);
            DbParameter pFNAME_ENG = Parameter("@FNAME_ENG", HIS_REGISTRATION.FNAME_ENG);
            DbParameter pLNAME_ENG = Parameter("@LNAME_ENG", HIS_REGISTRATION.LNAME_ENG);
            DbParameter pTEL = Parameter("@TEL", HIS_REGISTRATION.PHONE1);

            DbParameter[] parameters ={
                    pREG_ID
                    ,pHN 
                    ,pRHN
                    ,pTITLE_ENG
                    ,pFNAME_ENG
                    ,pLNAME_ENG
                    ,pTEL
            };
            return parameters;
        }

    }
}
