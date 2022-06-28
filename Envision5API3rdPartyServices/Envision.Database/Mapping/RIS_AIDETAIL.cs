using Envision.Entity.AIResult;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class RIS_AIDETAIL : IEntityTypeConfiguration<RisAIDetail>
    {
        public void Configure(EntityTypeBuilder<RisAIDetail> builder)
        {
            builder.ToTable("RIS_AIDETAIL");
            builder.HasKey(e => new { e.AiId });
            builder.Property(e => e.AiId).HasColumnName("AI_ID").IsRequired();
            builder.Property(e => e.Hn).HasColumnName("HN");
            builder.Property(e => e.AccessionNo).HasColumnName("ACCESSION_NO");
            builder.Property(e => e.DetectValues).HasColumnName("DETECT_VALUES");
            builder.Property(e => e.Remark).HasColumnName("REMARK");
            builder.Property(e => e.AiVendor).HasColumnName("AI_VENDOR");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");
        }
    }
}
