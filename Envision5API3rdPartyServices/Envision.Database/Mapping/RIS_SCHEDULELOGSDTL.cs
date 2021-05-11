using Envision.Entity.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class RIS_SCHEDULELOGSDTL : IEntityTypeConfiguration<RisScheduleLogsDtl>
    {
        public void Configure(EntityTypeBuilder<RisScheduleLogsDtl> builder)
        {
            builder.ToTable("RIS_SCHEDULELOGSDTL");
            builder.HasKey(e => new { e.SchedulelogId });
            builder.Property(e => e.SchedulelogId).HasColumnName("SCHEDULELOG_ID").IsRequired();
            builder.Property(e => e.ScheduleId).HasColumnName("SCHEDULE_ID").IsRequired();
            builder.Property(e => e.ExamId).HasColumnName("EXAM_ID");
            builder.Property(e => e.Qty).HasColumnName("QTY");
            builder.Property(e => e.Rate).HasColumnName("RATE");
            builder.Property(e => e.GenDtlId).HasColumnName("GEN_DTL_ID");
            builder.Property(e => e.RadId).HasColumnName("RAD_ID");
            builder.Property(e => e.PreparationId).HasColumnName("PREPARATION_ID");
            builder.Property(e => e.BpviewId).HasColumnName("BPVIEW_ID");
            builder.Property(e => e.AvgReqMin).HasColumnName("AVG_REQ_MIN");
            builder.Property(e => e.PatDestId).HasColumnName("PAT_DEST_ID");
            builder.Property(e => e.IsPortable).HasColumnName("IS_PORTABLE");
            builder.Property(e => e.SchedulePriority).HasColumnName("SCHEDULE_PRIORITY");
        }
    }
}
