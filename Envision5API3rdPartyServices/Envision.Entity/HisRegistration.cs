using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity
{
    public class HisRegistration
    {
        public int RegId { get; set; }
        public string Hn { get; set; }
        public string Title { get; set; }
        public DateTime? RegDt { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string TitleEng { get; set; }
        public string FnameEng { get; set; }
        public string LnameEng { get; set; }
        public string MnameEng { get; set; }
        public string Ssn { get; set; }
        public DateTime? Dob { get; set; }
        public int? Age { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int? OccupationId { get; set; }
        public string Natiionality { get; set; }
        public string PassportNo { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public string PatientType { get; set; }
        public string BlockPatient { get; set; }
        public string EmContactPerson { get; set; }
        public string EmRelation { get; set; }
        public string EmAddress { get; set; }
        public string EmPhone { get; set; }
        public string InsuranceType { get; set; }
        public string Allergies { get; set; }
        public int OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string IsDeleted { get; set; }
        public string IsUpdated { get; set; }
        public byte[] Pciture { get; set; }
        public string PcitureName { get; set; }
        public string IsJohndoe { get; set; }
        public string IsForeigner { get; set; }
        public string HisHn { get; set; }
        public string ExtHn { get; set; }
        public string PatientIdentificationLabel { get; set; }
        public string PatientIdentificationDetail { get; set; }
        public bool? IsVip { get; set; }
    }
}
