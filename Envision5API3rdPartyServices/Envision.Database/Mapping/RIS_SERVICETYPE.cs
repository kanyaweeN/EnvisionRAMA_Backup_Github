using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class RIS_SERVICETYPE : IEntityTypeConfiguration<RisServiceType>
    {
        public void Configure(EntityTypeBuilder<RisServiceType> builder)
        {
            builder.ToTable("RIS_SERVICETYPE");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("SERVICE_TYPE_ID").IsRequired();
            builder.Property(e => e.Code).HasColumnName("SERVICE_TYPE_UID");
            builder.Property(e => e.Text).HasColumnName("SERVICE_TYPE_TEXT");
            builder.Property(e => e.IsUpdated).HasColumnName("IS_UPDATED").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");

            builder.HasMany<RisExam>(dtl => dtl.ExamList)
                .WithOne(mas => mas.ServiceType)
                .HasForeignKey(f => f.ServiceTypeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
