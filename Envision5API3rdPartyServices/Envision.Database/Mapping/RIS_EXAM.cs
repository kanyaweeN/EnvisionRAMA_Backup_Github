using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Envision.Database.Mapping
{
    public class RIS_EXAM : IEntityTypeConfiguration<RisExam>
    {
        public void Configure(EntityTypeBuilder<RisExam> builder)
        {
            builder.ToTable("RIS_EXAM");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("EXAM_ID").IsRequired();
            builder.Property(e => e.ExamCode).HasColumnName("EXAM_UID");
            builder.Property(e => e.GovtId).HasColumnName("GOVT_ID");
            builder.Property(e => e.ExamName).HasColumnName("EXAM_NAME").IsRequired();
            builder.Property(e => e.ReportHeader).HasColumnName("REPORT_HEADER");
            builder.Property(e => e.ReqSample).HasColumnName("REQ_SAMPLE");
            builder.Property(e => e.Rate).HasColumnName("RATE");
            builder.Property(e => e.GovtRate).HasColumnName("GOVT_RATE");
            builder.Property(e => e.TypeId).HasColumnName("EXAM_TYPE");
            builder.Property(e => e.ServiceTypeId).HasColumnName("SERVICE_TYPE").IsRequired().HasConversion(DbHelper.IntToString());
            builder.Property(e => e.ClaimableAmt).HasColumnName("CLAIMABLE_AMT");
            builder.Property(e => e.NonclaimableAmt).HasColumnName("NONCLAIMABLE_AMT");
            builder.Property(e => e.FreeAmt).HasColumnName("FREE_AMT");
            builder.Property(e => e.SpecialClinic).HasColumnName("SPECIAL_CLINIC");
            builder.Property(e => e.SpecialRate).HasColumnName("SPECIAL_RATE");
            builder.Property(e => e.VatApplicable).HasColumnName("VAT_APPLICABLE");
            builder.Property(e => e.VatRate).HasColumnName("VAT_RATE");
            builder.Property(e => e.UnitId).HasColumnName("UNIT_ID");
            builder.Property(e => e.RevHeadId).HasColumnName("REV_HEAD_ID");
            builder.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.AvgReqHrs).HasColumnName("AVG_REQ_HRS");
            builder.Property(e => e.MinReqHrs).HasColumnName("MIN_REQ_HRS");
            builder.Property(e => e.CostPrice).HasColumnName("COST_PRICE");
            builder.Property(e => e.ReleaseAuthLevel).HasColumnName("RELEASE_AUTH_LEVEL");
            builder.Property(e => e.FinalizeAuthLevel).HasColumnName("FINALIZE_AUTH_LEVEL");
            builder.Property(e => e.PreparationFlag).HasColumnName("PREPARATION_FLAG");
            builder.Property(e => e.PreparationTat).HasColumnName("PREPARATION_TAT");
            builder.Property(e => e.RepeatFlag).HasColumnName("REPEAT_FLAG");
            builder.Property(e => e.IcdId).HasColumnName("ICD_ID");
            builder.Property(e => e.AcrId).HasColumnName("ACR_ID");
            builder.Property(e => e.CptId).HasColumnName("CPT_ID");
            builder.Property(e => e.DefCapture).HasColumnName("DEF_CAPTURE");
            builder.Property(e => e.DefImages).HasColumnName("DEF_IMAGES");
            builder.Property(e => e.IsStructuredReport).HasColumnName("IS_STRUCTURED_REPORT").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.QaRequired).HasColumnName("QA_REQUIRED").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.IsUpdated).HasColumnName("IS_UPDATED").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY").HasConversion(DbHelper.IntToString());
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY").HasConversion(DbHelper.IntToString());
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");
        }
    }
}
