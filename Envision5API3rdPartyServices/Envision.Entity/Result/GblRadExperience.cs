using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Result
{
    public class GblRadExperience
    {
        public int Id { get; set; }
        public short? AutoRefreshWlSec { get; set; }
        public string DashboardDefSearch { get; set; }
        public bool? LoadFinalizedExams { get; set; }
        public bool? AllExamVisible { get; set; }
        public bool? LoadAllExam { get; set; }
        public bool? AutoStartOrderImg { get; set; }
        public bool? AutoStartPacsImg { get; set; }
        public string DefDateRange { get; set; }
        public bool? RememberGridOrder { get; set; }
        public string GridDblClickTo { get; set; }
        public string FinishWritingReferTo { get; set; }
        public bool? AllowOtherstoFinalize { get; set; }
        public string FontFace { get; set; }
        public byte? FontSize { get; set; }
        public string SignatureText { get; set; }
        public string SignatureRtf { get; set; }
        public string SignatureHtml { get; set; }
        public byte[] SignatureScan { get; set; }
        public string UsedSignature { get; set; }
        public string WhenGroupSignUse { get; set; }
        public int? MinimizeCharacter { get; set; }
        public string WorklistGridOrder { get; set; }
        public string HistoryGridOrder { get; set; }
        public int? OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string UsedMenubar { get; set; }
        public string Used120dpi { get; set; }
        public string ReconfirmPassOnSave { get; set; }
        public string IsAddendum { get; set; }
        public int? ZoomSetting { get; set; }
        public string AllowMultipleFinalizeUpto { get; set; }
        public bool? ShowPrelim { get; set; }
        public bool? AllowMultipleFinalize { get; set; }
        public string PaperKind { get; set; }
        public int? NoOfCopy { get; set; }
        public string AutoExamname { get; set; }
        public string AutoClinicalindication { get; set; }
        public string OpenPacsWhenMerge { get; set; }
        public int? MaximumShortprelimCharectors { get; set; }
        public string WorklistTableOrder { get; set; }
    }
}
