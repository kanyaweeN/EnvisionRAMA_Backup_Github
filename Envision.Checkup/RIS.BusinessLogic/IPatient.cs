using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.BusinessLogic
{
    public interface IPatientDemographic {

        int Reg_ID 
        {
            get;
            set;
        }
        string Reg_UID 
        {
            get ;
            set ;
        }
        string Title 
        {
            get;
            set;  
        }
        DateTime Reg_DT 
        {
            get;
            set; 
        }
        string FirstName 
        {
            get;
            set; 
        }
        string MiddleName 
        {
            get;
            set;
        }
        string LastName 
        {
            get;
            set;
        }
        string Title_ENG 
        {
            get;
            set;
        }
        string FirstName_ENG 
        {
            get;
            set;
        }
        string MiddleName_ENG 
        {
            get;
            set;
        }
        string LastName_ENG 
        {
            get;
            set;
        }
        string SocialNumber
        {
            get;
            set;
        }
        DateTime DateOfBirth 
        {
            get;
            set;
        }
        int Age 
        {
            get;
            set;
        }
        string Address1 
        {
            get;
            set;
        }
        string Address2 
        {
            get;
            set;
        }
        string Address3 
        {
            get;
            set;
        }
        string Address4 
        {
            get;
            set;
        }
        string Address5 
        {
            get;
            set;
        }
        string Phone1 
        {
            get;
            set;
        }
        string Phone2 
        {
            get;
            set;
        }
        string Phone3 
        {
            get;
            set;
        }
        string Email  
        {
            get;
            set;
        }
        string Gender 
        {
            get;
            set;
        }
        string Marital_Status 
        {
            get;
            set;
        }
        int Occupation_ID 
        {
            get;
            set;
        }
        string Nationality 
        {
            get;
            set;
        }
        string Passport_No 
        {
            get;
            set;
        }
        string Blood_Group 
        {
            get;
            set;
        }
        string Religeon 
        {
            get;
            set;
        }
        string Patient_type 
        {
            get;
            set;
        }
        string Em_Contact_Person 
        {
            get;
            set;
        }
        string Em_Relation 
        {
            get;
            set;
        }
        string Em_Address 
        {
            get;
            set;
        }
        string Em_Phone 
        {
            get;
            set;
        }
        string Insurance_Type 
        {
            get;
            set;
        }
        string HL7_Format 
        {
            get;
            set;
        }
        string HL7_send 
        {
            get;
            set;
        }
        string Allergies 
        {
            get;
            set;
        }
        int Org_ID 
        {
            get;
            set;
        }
        int Created_BY 
        {
            get;
            set;
        }
        DateTime Created_ON 
        {
            get;
            set;
        }
        int Last_Modified_BY 
        {
            get;
            set;
        }
        DateTime Last_Modified_ON 
        {
            get;
            set;
        }
        string REFER_FROM
        {
            get;
            set;
        }
        string REF_DOC_INSTRUCTION
        {
            get;
            set;

        }
        string Department_Name
        {
            get;
            set;
        }
        string Doctor_Name
        {
            get;
            set;
        }
        bool LinkDown { get;}
        bool HasHN { get;}
        bool DataFromHIS { get;set;}
        bool DataFromLocal { get;set;}
        bool DataFromManual { get;set;}
        int InsuranceID { get;set;}
    }
    public interface IPatient 
    {
        IPatientDemographic Demographic
        {
            get;
            set;
        }
    }
    public interface IScanDocument
    {
        bool Scan();
    }
}
