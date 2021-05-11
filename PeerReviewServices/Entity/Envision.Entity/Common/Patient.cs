using System;

namespace Envision.Entity.Common
{
    public class Patient : BaseObject
    {
        public Patient(){

        }

        public int Id { get; set;}
        public string HN { get; set;}
        public DateTime? RegistDate { get; set;}
        public string Title { get; set; }
        public string FirstName { get; set;}
        public string MiddleName { get; set;}
        public string LastName { get; set;}
        public string TitleEng { get; set;}
        public string FirstNameEng { get; set; }
        public string MiddleNameEng { get; set; }
        public string LastNameEng { get; set; }
        public string SocialNumber { get; set;}
        public DateTime? DateOfBirth { get; set;}
        public int? Age { get; set;}
        public string Addr1 { get; set;}
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string Addr4 { get; set; }
        public string Addr5 { get; set; }
        public string Phone1 { get; set;}
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set;}
        public string Gender { get; set;}
        public string MaritalStatus { get; set;}
        public int? OccupationId { get; set;} 
        public string Nationality { get; set;}
        public string PassportNumber { get; set;}
        public string BloodGroup { get; set;}
        public string Religion { get; set;}
        public string PatientType { get; set;}
        public string BlockPatient { get; set;}
        public string EmergencyContactPerson { get; set;}
        public string EmergencyContactRelation { get; set;}
        public string EmergencyContactAddress { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string InsuranceType { get; set;}
        public string HL7 { get; set;}
        public string IsHL7Send { get; set;}
        public string IsLinkDown { get; set;}
        public string Allergy { get; set;}
        public string IsDelete { get; set;}
        public string IsUpdate { get; set;}
        public string IsJohnDoe { get; set; }
        public string IsPregnant { get; set; }
        public byte[] Picture { get; set;}
    }
}