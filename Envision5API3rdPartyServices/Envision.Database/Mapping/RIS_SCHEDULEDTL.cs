using Envision.Entity.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class RIS_SCHEDULEDTL : IEntityTypeConfiguration<RisScheduleDtl>
    {
        public void Configure(EntityTypeBuilder<RisScheduleDtl> builder)
        {
            builder.ToTable("RIS_SCHEDULEDTL");
            builder.HasKey(e => new { e.ScheduleId, e.ExamId });
            builder.Property(e => e.ScheduleId).HasColumnName("SCHEDULE_ID").IsRequired();
            builder.Property(e => e.ExamId).HasColumnName("EXAM_ID");
            builder.Property(e => e.Qty).HasColumnName("QTY");
            builder.Property(e => e.Rate).HasColumnName("RATE");
            builder.Property(e => e.GenDtlId).HasColumnName("GEN_DTL_ID");
            builder.Property(e => e.RadId).HasColumnName("RAD_ID");
            builder.Property(e => e.PreparationId).HasColumnName("PREPARATION_ID");
            builder.Property(e => e.BpviewId).HasColumnName("BPVIEW_ID");
            builder.Property(e => e.AvgReqMin).HasColumnName("AVG_REQ_MIN");
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");
            builder.Property(e => e.PatDestId).HasColumnName("PAT_DEST_ID");
            builder.Property(e => e.IsPortable).HasColumnName("IS_PORTABLE");
            builder.Property(e => e.SchedulePriority).HasColumnName("SCHEDULE_PRIORITY");
        }
    }
}
