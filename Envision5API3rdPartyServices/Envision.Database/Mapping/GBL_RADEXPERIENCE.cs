using Envision.Entity.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Database.Mapping
{
    public class GBL_RADEXPERIENCE : IEntityTypeConfiguration<GblRadExperience>
    {
        public void Configure(EntityTypeBuilder<GblRadExperience> builder)
        {
            builder.ToTable("GBL_RADEXPERIENCE");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("RADIOLOGIST_ID").IsRequired();
            builder.Property(e => e.AutoRefreshWlSec).HasColumnName("AUTO_REFRESH_WL_SEC");
            builder.Property(e => e.DashboardDefSearch).HasColumnName("DASHBOARD_DEF_SEARCH");
            builder.Property(e => e.LoadFinalizedExams).HasColumnName("LOAD_FINALIZED_EXAMS");
            builder.Property(e => e.AllExamVisible).HasColumnName("ALL_EXAM_VISIBLE");
            builder.Property(e => e.LoadAllExam).HasColumnName("LOAD_ALL_EXAM");
            builder.Property(e => e.AutoStartOrderImg).HasColumnName("AUTO_START_ORDER_IMG");
            builder.Property(e => e.AutoStartPacsImg).HasColumnName("AUTO_START_PACS_IMG");
            builder.Property(e => e.DefDateRange).HasColumnName("DEF_DATE_RANGE");
            builder.Property(e => e.RememberGridOrder).HasColumnName("REMEMBER_GRID_ORDER");
            builder.Property(e => e.GridDblClickTo).HasColumnName("GRID_DBL_CLICK_TO");
            builder.Property(e => e.FinishWritingReferTo).HasColumnName("FINISH_WRITING_REFER_TO");
            builder.Property(e => e.AllowOtherstoFinalize).HasColumnName("ALLOW_OTHERSTO_FINALIZE");
            builder.Property(e => e.FontFace).HasColumnName("FONT_FACE");
            builder.Property(e => e.FontSize).HasColumnName("FONT_SIZE");
            builder.Property(e => e.SignatureText).HasColumnName("SIGNATURE_TEXT");
            builder.Property(e => e.SignatureRtf).HasColumnName("SIGNATURE_RTF");
            builder.Property(e => e.SignatureHtml).HasColumnName("SIGNATURE_HTML");
            builder.Property(e => e.SignatureScan).HasColumnName("SIGNATURE_SCAN");
            builder.Property(e => e.UsedSignature).HasColumnName("USED_SIGNATURE");
            builder.Property(e => e.WhenGroupSignUse).HasColumnName("WHEN_GROUP_SIGN_USE");
            builder.Property(e => e.MinimizeCharacter).HasColumnName("MINIMIZE_CHARACTER");
            builder.Property(e => e.WorklistGridOrder).HasColumnName("WORKLIST_GRID_ORDER");
            builder.Property(e => e.HistoryGridOrder).HasColumnName("HISTORY_GRID_ORDER");
            builder.Property(e => e.OrgId).HasColumnName("ORG_ID");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            builder.Property(e => e.LastModifiedOn).HasColumnName("LAST_MODIFIED_ON");
            builder.Property(e => e.UsedMenubar).HasColumnName("USED_MENUBAR");
            builder.Property(e => e.Used120dpi).HasColumnName("USED_120DPI");
            builder.Property(e => e.ReconfirmPassOnSave).HasColumnName("RECONFIRM_PASS_ON_SAVE");
            builder.Property(e => e.IsAddendum).HasColumnName("IS_ADDENDUM");
            builder.Property(e => e.ZoomSetting).HasColumnName("ZOOM_SETTING");
            builder.Property(e => e.AllowMultipleFinalizeUpto).HasColumnName("ALLOW_MULTIPLE_FINALIZE_UPTO");
            builder.Property(e => e.ShowPrelim).HasColumnName("SHOW_PRELIM");
            builder.Property(e => e.AllowMultipleFinalize).HasColumnName("ALLOW_MULTIPLE_FINALIZE");
            builder.Property(e => e.PaperKind).HasColumnName("PAPER_KIND");
            builder.Property(e => e.NoOfCopy).HasColumnName("NO_OF_COPY");
            builder.Property(e => e.AutoExamname).HasColumnName("AUTO_EXAMNAME");
            builder.Property(e => e.AutoClinicalindication).HasColumnName("AUTO_CLINICALINDICATION");
            builder.Property(e => e.OpenPacsWhenMerge).HasColumnName("OPEN_PACS_WHEN_MERGE");
            builder.Property(e => e.MaximumShortprelimCharectors).HasColumnName("MAXIMUM_SHORTPRELIM_CHARECTORS");
            builder.Property(e => e.WorklistTableOrder).HasColumnName("WORKLIST_TABLE_ORDER");
        }
    }
}