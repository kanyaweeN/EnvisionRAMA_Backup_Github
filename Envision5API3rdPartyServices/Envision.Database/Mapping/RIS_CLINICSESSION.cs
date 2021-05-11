using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class RIS_CLINICSESSION : IEntityTypeConfiguration<RisClinicSession>
    {
        public void Configure(EntityTypeBuilder<RisClinicSession> builder)
        {
            builder.ToTable("RIS_CLINICSESSION");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("SESSION_ID").IsRequired();
            builder.Property(e => e.Code).HasColumnName("SESSION_UID");
            builder.Property(e => e.Name).HasColumnName("SESSION_NAME");
            builder.Property(e => e.TypeId).HasColumnName("CLINIC_TYPE_ID");
            builder.Property(e => e.StartTime).HasColumnName("START_TIME");
            builder.Property(e => e.EndTime).HasColumnName("END_TIME");
            builder.Property(e => e.SL).HasColumnName("SL_NO");
            builder.Property(e => e.AliasName).HasColumnName("SESSION_NAME_ALIAS");
            builder.Property(e => e.IsOnline).HasColumnName("SHOW_ONLINE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");


        }
    }
}
