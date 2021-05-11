using System;

namespace Envision.Entity.Common.User
{
    public class UserInfo : BaseObject
    {
        public UserInfo(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public string UserName { get; set;}
        public string SecurityQuestion { get; set;}
        public string SecurityAnswer { get; set;}
        public string Password { get; set;}
        public int? UnitId { get; set;}
        public int? JobtitleId { get; set;}
        public string JobType { get; set;}
        public string Title { get; set;}
        public string FirstName { get; set;}
        public string MiddleName { get; set;}
        public string LastName { get; set;}
        public string TitleEng { get; set;}
        public string FirstNameEng { get; set;}
        public string MiddleNameEng { get; set;}
        public string LastNameEng { get; set;}
        public string Gender { get; set;}
        public string DisplayName { get; set;}
        public string EmailPersonal { get; set;}
        public string EmailOfficial { get; set;}
        public string PhoneHome { get; set;}
        public string PhoneMobile { get; set;}
        public string PhoneOffice { get; set;}
        public string PreferredPhone { get; set;}
        public int? PABXExt { get; set;}
        public string FaxNumber { get; set;}
        public DateTime? DateOfBirth { get; set;}
        public string BloodGroup { get; set;}
        public int? DefaultLanguage { get; set;}
        public int? Religion { get; set;}
        public string Addr1 { get; set;}
        public string Addr2 { get; set;}
        public string Addr3 { get; set;}
        public string Addr4 { get; set;}
        public int? AuthLevelId { get; set;}
        public int? ReportingTo { get; set;}
        public DateTime? LastPwdModified { get; set;}
        public DateTime? LastLogin { get; set;}
        public string CardNo { get; set;}
        public string PlaceOfBirth { get; set;}
        public string Nationality { get; set;}
        public string MilitaryStatus { get; set;}
        public int? DefaultShiftNumber { get; set;}
        public string ImageFileName { get; set;}
        public string ReportFooter1 { get; set;}
        public string ReportFooter2 { get; set;}
        public byte[] Allproperties { get; set;}
        public bool? IsActive { get; set; }
        public bool? Visible { get; set;}
        public bool? SupportUser { get; set; }
        public bool? CanKillSession { get; set; }
        public bool? CanExceedSchedule { get; set; }
        public bool? AllowOthersToFinalize { get; set; }
        public bool? IsRadiologist { get; set; }
        public bool? IsResident { get; set; }
        public bool? IsFellow { get; set; }
        public bool? IsNurse { get; set; }
        public bool? IsTechnologist { get; set; }
    }
}