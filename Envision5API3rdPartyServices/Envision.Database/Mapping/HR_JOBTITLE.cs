using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class HR_JOBTITLE : IEntityTypeConfiguration<HrJobTitle>
    {
        public void Configure(EntityTypeBuilder<HrJobTitle> builder)
        {
            builder.ToTable("HR_JOBTITLE");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("JOB_TITLE_ID").IsRequired();
            builder.Property(e => e.Code).HasColumnName("JOB_TITLE_UID");
            builder.Property(e => e.Desc).HasColumnName("JOB_TITLE_DESC");
            builder.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.SL).HasColumnName("SL_NO");
            builder.Property(e => e.Tag).HasColumnName("JOB_TITLE_TAG");
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");
        }
    }
}