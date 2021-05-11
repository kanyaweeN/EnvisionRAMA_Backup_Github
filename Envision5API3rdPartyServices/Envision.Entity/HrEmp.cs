using Envision.Entity.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity
{
    public class HrEmp
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public string UserName { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string Pwd { get; set; }
        public int? UnitId { get; set; }
        public int? JobtitleId { get; set; }
        public string JobType { get; set; }
        public string Salutation { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string TitleEng { get; set; }
        public string FnameEng { get; set; }
        public string MnameEng { get; set; }
        public string LnameEng { get; set; }
        public string AliasName { get; set; }
        public string Gender { get; set; }
        public string EmailPersonal { get; set; }
        public string EmailOfficial { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneOffice { get; set; }
        public string PreferredPhone { get; set; }
        public int? PabxExt { get; set; }
        public string FaxNo { get; set; }
        public DateTime? Dob { get; set; }
        public string BloodGroup { get; set; }
        public int? DefaultLang { get; set; }
        public int? Religion { get; set; }
        public string PeAddr1 { get; set; }
        public string PeAddr2 { get; set; }
        public string PeAddr3 { get; set; }
        public string PeAddr4 { get; set; }
        public int? AuthLevelId { get; set; }
        public int? ReportingTo { get; set; }
        public bool? AllowOthersToFinalize { get; set; }
        public DateTime? LastPwdModified { get; set; }
        public DateTime? LastLogin { get; set; }
        public string CardNo { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public string MStatus { get; set; }
        public int? DefaultShiftNo { get; set; }
        public string ImgFileName { get; set; }
        public string EmpReportFooter1 { get; set; }
        public string EmpReportFooter2 { get; set; }
        public byte[] Allproperties { get; set; }
        public bool? Visible { get; set; }
        public bool? CanExceedSchedule { get; set; }
        public bool? IsDarkmenu { get; set; }
        public bool? IsAccessvip { get; set; }
        public bool? IsFellow { get; set; }
        public bool? IsNurse { get; set; }
        public bool? IsTechnologist { get; set; }
        public bool? IsActive { get; set; }
        public bool? SupportUser { get; set; }
        public bool? CanKillSession { get; set; }
        public bool? IsResident { get; set; }
        public bool? IsRadiologist { get; set; }
        public string Theme { get; set; }
        public int? LockScreen { get; set; }
        public string ProfileLayout { get; set; }
        public string MenuLayout { get; set; }
        public int? OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public HrJobTitle JobTitle { get; set; }
        public HrUnit Unit { get; set; }
        public RisAuthLevel AuthLevel { get; set; }
        public GblRadExperience RadExperience { get; set; }
    }
}
