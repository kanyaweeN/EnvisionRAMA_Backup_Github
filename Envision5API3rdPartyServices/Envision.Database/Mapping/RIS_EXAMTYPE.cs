using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Envision.Database.Mapping
{
    public class RIS_EXAMTYPE : IEntityTypeConfiguration<RisExamType>
    {
        public void Configure(EntityTypeBuilder<RisExamType> builder)
        {
            builder.ToTable("RIS_EXAMTYPE");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("EXAM_TYPE_ID").IsRequired();
            builder.Property(e => e.Code).HasColumnName("EXAM_TYPE_UID");
            builder.Property(e => e.Text).HasColumnName("EXAM_TYPE_TEXT");
            builder.Property(e => e.Abbr).HasColumnName("EXAM_TYPE_ABBR");
            builder.Property(e => e.Instruction).HasColumnName("EXAM_TYPE_INS");
            builder.Property(e => e.InstructionKid).HasColumnName("EXAM_TYPE_INS_KID");
            builder.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");

            builder.HasMany<RisExam>(dtl => dtl.ExamList)
                   .WithOne(mas => mas.ExamType)
                   .HasForeignKey(f => f.TypeId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
