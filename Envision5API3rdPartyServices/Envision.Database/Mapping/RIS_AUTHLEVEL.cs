using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class RIS_AUTHLEVEL : IEntityTypeConfiguration<RisAuthLevel>
    {
        public void Configure(EntityTypeBuilder<RisAuthLevel> builder)
        {
            builder.ToTable("RIS_AUTHLEVEL");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("AUTH_LEVEL_ID").IsRequired();
            builder.Property(e => e.Code).HasColumnName("AUTH_LEVEL_UID");
            builder.Property(e => e.Desc).HasColumnName("AUTH_LEVEL_DESC");
            builder.Property(e => e.SL).HasColumnName("AUTH_LEVEL_SL");
            builder.Property(e => e.Text).HasColumnName("AUTH_LEVEL_TEXT");
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");
        }
    }
}