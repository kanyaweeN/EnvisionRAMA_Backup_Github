using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity
{
    public class RisExam
    {
        public int Id { get; set; }
        public string ExamCode { get; set; }
        public string GovtId { get; set; }
        public string ExamName { get; set; }
        public string ReportHeader { get; set; }
        public string ReqSample { get; set; }
        public decimal? Rate { get; set; }
        public decimal? GovtRate { get; set; }
        public int? TypeId { get; set; }
        public int? ServiceTypeId { get; set; }
        public decimal? ClaimableAmt { get; set; }
        public decimal? NonclaimableAmt { get; set; }
        public decimal? FreeAmt { get; set; }
        public string SpecialClinic { get; set; }
        public decimal? SpecialRate { get; set; }
        public string VatApplicable { get; set; }
        public decimal? VatRate { get; set; }
        public int? UnitId { get; set; }
        public int? RevHeadId { get; set; }
        public bool? IsActive { get; set; }
        public decimal? AvgReqHrs { get; set; }
        public decimal? MinReqHrs { get; set; }
        public decimal? CostPrice { get; set; }
        public byte? ReleaseAuthLevel { get; set; }
        public byte? FinalizeAuthLevel { get; set; }
        public string PreparationFlag { get; set; }
        public decimal? PreparationTat { get; set; }
        public string RepeatFlag { get; set; }
        public int? IcdId { get; set; }
        public int? AcrId { get; set; }
        public int? CptId { get; set; }
        public byte? DefCapture { get; set; }
        public byte? DefImages { get; set; }
        public bool? IsStructuredReport { get; set; }
        public bool? QaRequired { get; set; }
        public bool? IsUpdated { get; set; }
        public bool? IsDeleted { get; set; }
        public int? OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public RisExamType ExamType { get; set; }
        public RisServiceType ServiceType { get; set; }
        public HrUnit Unit { get; set; }
    }
}
