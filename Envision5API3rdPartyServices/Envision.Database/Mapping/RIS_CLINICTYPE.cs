using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class RIS_CLINICTYPE : IEntityTypeConfiguration<RisClinicType>
    {
        public void Configure(EntityTypeBuilder<RisClinicType> builder)
        {
            builder.ToTable("RIS_CLINICTYPE");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("CLINIC_TYPE_ID").IsRequired();
            builder.Property(e => e.Code).HasColumnName("CLINIC_TYPE_UID");
            builder.Property(e => e.Text).HasColumnName("CLINIC_TYPE_TEXT");
            builder.Property(e => e.IsDefault).HasColumnName("IS_DEFAULT").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.RateIncrease).HasColumnName("RATE_INCREASE");
            builder.Property(e => e.SL).HasColumnName("SL_NO");
            builder.Property(e => e.AliasName).HasColumnName("CLINIC_TYPE_ALIAS");
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");

            builder.HasMany<RisClinicSession>(m => m.ClinicSessionList)
                   .WithOne(c => c.ClinicType)
                   .HasForeignKey(f => f.TypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}