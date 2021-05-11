using Envision.Entity;
using Envision.Entity.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class HR_EMP : IEntityTypeConfiguration<HrEmp>
    {
        public void Configure(EntityTypeBuilder<HrEmp> builder)
        {
            builder.ToTable("HR_EMP");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("EMP_ID").IsRequired();
            builder.Property(e => e.EmpCode).HasColumnName("EMP_UID");
            builder.Property(e => e.UserName).HasColumnName("USER_NAME");
            builder.Property(e => e.SecurityQuestion).HasColumnName("SECURITY_QUESTION");
            builder.Property(e => e.SecurityAnswer).HasColumnName("SECURITY_ANSWER");
            builder.Property(e => e.Pwd).HasColumnName("PWD");
            builder.Property(e => e.UnitId).HasColumnName("UNIT_ID");
            builder.Property(e => e.JobtitleId).HasColumnName("JOBTITLE_ID");
            builder.Property(e => e.JobType).HasColumnName("JOB_TYPE");
            builder.Property(e => e.IsRadiologist).HasColumnName("IS_RADIOLOGIST").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.Salutation).HasColumnName("SALUTATION");
            builder.Property(e => e.Fname).HasColumnName("FNAME");
            builder.Property(e => e.Mname).HasColumnName("MNAME");
            builder.Property(e => e.Lname).HasColumnName("LNAME");
            builder.Property(e => e.TitleEng).HasColumnName("TITLE_ENG");
            builder.Property(e => e.FnameEng).HasColumnName("FNAME_ENG");
            builder.Property(e => e.MnameEng).HasColumnName("MNAME_ENG");
            builder.Property(e => e.LnameEng).HasColumnName("LNAME_ENG");
            builder.Property(e => e.Gender).HasColumnName("GENDER");
            builder.Property(e => e.EmailPersonal).HasColumnName("EMAIL_PERSONAL");
            builder.Property(e => e.EmailOfficial).HasColumnName("EMAIL_OFFICIAL");
            builder.Property(e => e.PhoneHome).HasColumnName("PHONE_HOME");
            builder.Property(e => e.PhoneMobile).HasColumnName("PHONE_MOBILE");
            builder.Property(e => e.PhoneOffice).HasColumnName("PHONE_OFFICE");
            builder.Property(e => e.PreferredPhone).HasColumnName("PREFERRED_PHONE");
            builder.Property(e => e.PabxExt).HasColumnName("PABX_EXT");
            builder.Property(e => e.FaxNo).HasColumnName("FAX_NO");
            builder.Property(e => e.Dob).HasColumnName("DOB");
            builder.Property(e => e.BloodGroup).HasColumnName("BLOOD_GROUP");
            builder.Property(e => e.DefaultLang).HasColumnName("DEFAULT_LANG");
            builder.Property(e => e.Religion).HasColumnName("RELIGION");
            builder.Property(e => e.PeAddr1).HasColumnName("PE_ADDR1");
            builder.Property(e => e.PeAddr2).HasColumnName("PE_ADDR2");
            builder.Property(e => e.PeAddr3).HasColumnName("PE_ADDR3");
            builder.Property(e => e.PeAddr4).HasColumnName("PE_ADDR4");
            builder.Property(e => e.AuthLevelId).HasColumnName("AUTH_LEVEL_ID");
            builder.Property(e => e.ReportingTo).HasColumnName("REPORTING_TO");
            builder.Property(e => e.AllowOthersToFinalize).HasColumnName("ALLOW_OTHERS_TO_FINALIZE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.LastPwdModified).HasColumnName("LAST_PWD_MODIFIED");
            builder.Property(e => e.LastLogin).HasColumnName("LAST_LOGIN");
            builder.Property(e => e.CardNo).HasColumnName("CARD_NO");
            builder.Property(e => e.PlaceOfBirth).HasColumnName("PLACE_OF_BIRTH");
            builder.Property(e => e.Nationality).HasColumnName("NATIONALITY");
            builder.Property(e => e.MStatus).HasColumnName("M_STATUS");
            builder.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.SupportUser).HasColumnName("SUPPORT_USER").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.CanKillSession).HasColumnName("CAN_KILL_SESSION").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.DefaultShiftNo).HasColumnName("DEFAULT_SHIFT_NO");
            builder.Property(e => e.ImgFileName).HasColumnName("IMG_FILE_NAME");
            builder.Property(e => e.EmpReportFooter1).HasColumnName("EMP_REPORT_FOOTER1");
            builder.Property(e => e.EmpReportFooter2).HasColumnName("EMP_REPORT_FOOTER2");
            builder.Property(e => e.Allproperties).HasColumnName("ALLPROPERTIES");
            builder.Property(e => e.Visible).HasColumnName("VISIBLE");
            builder.Property(e => e.IsResident).HasColumnName("IS_RESIDENT").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.CanExceedSchedule).HasColumnName("CAN_EXCEED_SCHEDULE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.IsFellow).HasColumnName("IS_FELLOW").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.IsNurse).HasColumnName("IS_NURSE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.IsTechnologist).HasColumnName("IS_TECHNOLOGIST").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.AliasName).HasColumnName("ALIAS_NAME");
            builder.Property(e => e.IsAccessvip).HasColumnName("IS_ACCESSVIP");
            builder.Property(e => e.Theme).HasColumnName("THEME");
            builder.Property(e => e.LockScreen).HasColumnName("LOCK_SCREEN");
            builder.Property(e => e.ProfileLayout).HasColumnName("PROFILE_LAYOUT");
            builder.Property(e => e.MenuLayout).HasColumnName("MENU_LAYOUT");
            builder.Property(e => e.IsDarkmenu).HasColumnName("IS_DARKMENU");
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");

            builder.HasOne<HrJobTitle>(e => e.JobTitle).WithOne().HasForeignKey<HrEmp>(u => u.JobtitleId);
            builder.HasOne<HrUnit>(e => e.Unit).WithOne().HasForeignKey<HrEmp>(u => u.UnitId);
            builder.HasOne<RisAuthLevel>(e => e.AuthLevel).WithOne().HasForeignKey<HrEmp>(u => u.AuthLevelId);
            builder.HasOne<GblRadExperience>(e => e.RadExperience).WithOne().HasForeignKey<HrEmp>(u => u.Id);
        }
    }
}