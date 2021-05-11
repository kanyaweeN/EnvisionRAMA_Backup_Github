using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class HR_UNIT : IEntityTypeConfiguration<HrUnit>
    {
        public void Configure(EntityTypeBuilder<HrUnit> builder)
        {
            builder.ToTable("HR_UNIT");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("UNIT_ID").IsRequired();
            builder.Property(e => e.Code).HasColumnName("UNIT_UID");
            builder.Property(e => e.ParentId).HasColumnName("UNIT_ID_PARENT");
            builder.Property(e => e.Name).HasColumnName("UNIT_NAME");
            builder.Property(e => e.AliasName).HasColumnName("UNIT_NAME_ALIAS");
            builder.Property(e => e.PhoneNo).HasColumnName("PHONE_NO");
            builder.Property(e => e.Desc).HasColumnName("DESCR");
            builder.Property(e => e.UnitAlias).HasColumnName("UNIT_ALIAS");
            builder.Property(e => e.UnitType).HasColumnName("UNIT_TYPE");
            builder.Property(e => e.UnitIns).HasColumnName("UNIT_INS");
            builder.Property(e => e.IsExternal).HasColumnName("IS_EXTERNAL").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.Loc).HasColumnName("LOC");
            builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").HasConversion(DbHelper.BooleanToString());
            builder.Property(e => e.LocAlias).HasColumnName("LOC_ALIAS");
            builder.Property(e => e.UnitParentName).HasColumnName("UNIT_PARENT_NAME");
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");

            builder.HasMany<RisExam>(dtl => dtl.ExamList)
              .WithOne(mas => mas.Unit)
              .HasForeignKey(f => f.UnitId)
              .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
