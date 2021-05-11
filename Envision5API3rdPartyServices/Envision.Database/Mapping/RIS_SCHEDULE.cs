using Envision.Entity.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class RIS_SCHEDULE : IEntityTypeConfiguration<RisSchedule>
    {
        public void Configure(EntityTypeBuilder<RisSchedule> builder)
        {
            builder.ToTable("RIS_SCHEDULE");
            builder.HasKey(e => new { e.ScheduleId });
            builder.Property(e => e.ScheduleId).HasColumnName("SCHEDULE_ID").IsRequired();
            builder.Property(e => e.RegId).HasColumnName("REG_ID");
            builder.Property(e => e.ScheduleDt).HasColumnName("SCHEDULE_DT");
            builder.Property(e => e.ModalityId).HasColumnName("MODALITY_ID");
            builder.Property(e => e.ScheduleData).HasColumnName("SCHEDULE_DATA");
            builder.Property(e => e.SessionId).HasColumnName("SESSION_ID");
            builder.Property(e => e.StartDatetime).HasColumnName("START_DATETIME");
            builder.Property(e => e.EndDatetime).HasColumnName("END_DATETIME");
            builder.Property(e => e.RefUnit).HasColumnName("REF_UNIT");
            builder.Property(e => e.RefDoc).HasColumnName("REF_DOC");
            builder.Property(e => e.RefDocInstruction).HasColumnName("REF_DOC_INSTRUCTION");
            builder.Property(e => e.ClinicalInstruction).HasColumnName("CLINICAL_INSTRUCTION");
            builder.Property(e => e.Reason).HasColumnName("REASON");
            builder.Property(e => e.Diagnosis).HasColumnName("DIAGNOSIS");
            builder.Property(e => e.PatStatus).HasColumnName("PAT_STATUS");
            builder.Property(e => e.LmpDt).HasColumnName("LMP_DT");
            builder.Property(e => e.IcdId).HasColumnName("ICD_ID");
            builder.Property(e => e.ScheduleStatus).HasColumnName("SCHEDULE_STATUS");
            builder.Property(e => e.InsuranceTypeId).HasColumnName("INSURANCE_TYPE_ID");
            builder.Property(e => e.ConfirmedBy).HasColumnName("CONFIRMED_BY");
            builder.Property(e => e.ConfirmedOn).HasColumnName("CONFIRMED_ON");
            builder.Property(e => e.IsBlocked).HasColumnName("IS_BLOCKED");
            builder.Property(e => e.BlockReason).HasColumnName("BLOCK_REASON");
            builder.Property(e => e.Comments).HasColumnName("COMMENTS");
            builder.Property(e => e.IsReqOnline).HasColumnName("IS_REQONLINE");
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");
            builder.Property(e => e.AllDay).HasColumnName("ALLDAY");
            builder.Property(e => e.EventType).HasColumnName("EVENTTYPE");
            builder.Property(e => e.RecurrenceInfo).HasColumnName("RECURRENCEINFO");
            builder.Property(e => e.Label).HasColumnName("LABEL");
            builder.Property(e => e.Location).HasColumnName("LOCATION");
            builder.Property(e => e.Status).HasColumnName("STATUS");
            builder.Property(e => e.IsBusy).HasColumnName("IS_BUSY");
            builder.Property(e => e.RequestedScheduleDt).HasColumnName("REQUESTED_SCHEDULE_DT");
            builder.Property(e => e.ScheduleExceedBy).HasColumnName("SCHEDULE_EXCEED_BY");
            builder.Property(e => e.WlConfirmedBy).HasColumnName("WL_CONFIRMED_BY");
            builder.Property(e => e.WlConfirmedOn).HasColumnName("WL_CONFIRMED_ON");
            builder.Property(e => e.EncId).HasColumnName("ENC_ID");
            builder.Property(e => e.EncType).HasColumnName("ENC_TYPE");
            builder.Property(e => e.EncClinic).HasColumnName("ENC_CLINIC");
            builder.Property(e => e.NotifyAdminWl).HasColumnName("NOTIFY_ADMIN_WL");
            builder.Property(e => e.HisSync).HasColumnName("HIS_SYNC");
            builder.Property(e => e.AdmissionNo).HasColumnName("ADMISSION_NO");
            builder.Property(e => e.PendingBy).HasColumnName("PENDING_BY");
            builder.Property(e => e.PendingOn).HasColumnName("PENDING_ON");
            builder.Property(e => e.IsComments).HasColumnName("IS_COMMENTS");
            builder.Property(e => e.BusyBy).HasColumnName("BUSY_BY");
            builder.Property(e => e.BusyOn).HasColumnName("BUSY_ON");
            builder.Property(e => e.PendingComments).HasColumnName("PENDING_COMMENTS");
            builder.Property(e => e.TextShow).HasColumnName("TEXT_SHOW");
            builder.Property(e => e.IsPrintConsentForm).HasColumnName("IS_PRINT_CONSENTFORM");
            builder.Property(e => e.RequestResultDatetime).HasColumnName("REQUEST_RESULT_DATETIME");
            builder.Property(e => e.IsAertClinicalInstruction).HasColumnName("IS_ALERT_CLINICAL_INSTRUCTION");
            builder.Property(e => e.ClinicalInstructionTag).HasColumnName("CLINICAL_INSTRUCTION_TAG");

	
            builder.HasMany<RisScheduleDtl>(dtl => dtl.risScheduleDtls)
       .WithOne(mas => mas.RisSchedule)
       .HasForeignKey(f => f.ScheduleId)
       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
