using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class HIS_REGISTRATION : IEntityTypeConfiguration<HisRegistration>
    {
        public void Configure(EntityTypeBuilder<HisRegistration> builder)
        {
            builder.ToTable("HIS_REGISTRATION");
            builder.HasKey(e => new { e.RegId });
            builder.Property(e => e.RegId).HasColumnName("REG_ID").IsRequired();
            builder.Property(e => e.Hn).HasColumnName("HN");
            builder.Property(e => e.Title).HasColumnName("TITLE");
            builder.Property(e => e.RegDt).HasColumnName("REG_DT");
            builder.Property(e => e.Fname).HasColumnName("FNAME");
            builder.Property(e => e.Mname).HasColumnName("MNAME");
            builder.Property(e => e.Lname).HasColumnName("LNAME");
            builder.Property(e => e.TitleEng).HasColumnName("TITLE_ENG");
            builder.Property(e => e.FnameEng).HasColumnName("FNAME_ENG");
            builder.Property(e => e.MnameEng).HasColumnName("MNAME_ENG");
            builder.Property(e => e.LnameEng).HasColumnName("LNAME_ENG");
            builder.Property(e => e.Ssn).HasColumnName("SSN");
            builder.Property(e => e.Dob).HasColumnName("DOB");
            builder.Property(e => e.Age).HasColumnName("AGE");
            builder.Property(e => e.Address1).HasColumnName("ADDR1");
            builder.Property(e => e.Address2).HasColumnName("ADDR2");
            builder.Property(e => e.Address3).HasColumnName("ADDR3");
            builder.Property(e => e.Address4).HasColumnName("ADDR4");
            builder.Property(e => e.Address5).HasColumnName("ADDR5");
            builder.Property(e => e.Phone1).HasColumnName("PHONE1");
            builder.Property(e => e.Phone2).HasColumnName("PHONE2");
            builder.Property(e => e.Phone3).HasColumnName("PHONE3");
            builder.Property(e => e.Gender).HasColumnName("GENDER");
            builder.Property(e => e.MaritalStatus).HasColumnName("MARITAL_STATUS");
            builder.Property(e => e.OccupationId).HasColumnName("OCCUPATION_ID");
            builder.Property(e => e.Natiionality).HasColumnName("NATIONALITY");
            builder.Property(e => e.PassportNo).HasColumnName("PASSPORT_NO");
            builder.Property(e => e.BloodGroup).HasColumnName("BLOOD_GROUP");
            builder.Property(e => e.Religion).HasColumnName("RELIGION");
            builder.Property(e => e.PatientType).HasColumnName("PATIENT_TYPE");
            builder.Property(e => e.BlockPatient).HasColumnName("BLOCK_PATIENT");
            builder.Property(e => e.EmContactPerson).HasColumnName("EM_CONTACT_PERSON");
            builder.Property(e => e.EmRelation).HasColumnName("EM_RELATION");
            builder.Property(e => e.EmAddress).HasColumnName("EM_ADDR");
            builder.Property(e => e.EmPhone).HasColumnName("EM_PHONE");
            builder.Property(e => e.InsuranceType).HasColumnName("INSURANCE_TYPE");
            builder.Property(e => e.Allergies).HasColumnName("ALLERGIES");
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");
            builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED");
            builder.Property(e => e.IsUpdated).HasColumnName("IS_UPDATED");
            builder.Property(e => e.Pciture).HasColumnName("Picture");
            builder.Property(e => e.IsJohndoe).HasColumnName("IS_JOHNDOE");
            builder.Property(e => e.IsForeigner).HasColumnName("IS_FOREIGNER");
            builder.Property(e => e.HisHn).HasColumnName("HIS_HN");
            builder.Property(e => e.ExtHn).HasColumnName("EXT_HN");
            builder.Property(e => e.PatientIdentificationLabel).HasColumnName("PatientIdentificationLabel");
            builder.Property(e => e.PatientIdentificationDetail).HasColumnName("PatientIdentificationDetail");
            builder.Property(e => e.IsVip).HasColumnName("IS_VIP");
            builder.Property(e => e.PcitureName).HasColumnName("PICTURE_NAME");
        }
    }
}
