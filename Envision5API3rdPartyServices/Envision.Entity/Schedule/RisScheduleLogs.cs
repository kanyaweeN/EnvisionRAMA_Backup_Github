using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Schedule
{
    public class RisScheduleLogs
    {
        public int SchedulelogId { get; set; } 
        public int ScheduleId { get; set; }
        public int RegId { get; set; }
        public DateTime ScheduleDt { get; set; }
        public int ModalityId { get; set; }
        public string ScheduleData { get; set; }
        public int? SessionId { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public int? RefUnit { get; set; }
        public int? RefDoc { get; set; }
        public string RefDocInstruction { get; set; }
        public string ClinicalInstruction { get; set; }
        public string Reason { get; set; }
        public string Diagnosis { get; set; }
        public int? PatStatus { get; set; }
        public DateTime? LmpDt { get; set; }
        public int? IcdId { get; set; }
        public string ScheduleStatus { get; set; }
        public int? InsuranceTypeId { get; set; }
        public int? ConfirmedBy { get; set; }
        public DateTime? ConfirmedOn { get; set; }
        public string IsBlocked { get; set; }
        public string BlockReason { get; set; }
        public string Comments { get; set; }
        public string IsReqOnline { get; set; }
        public bool? AllDay { get; set; }
        public int? EventType { get; set; }
        public string RecurrenceInfo { get; set; }
        public int? Label { get; set; }
        public string Location { get; set; }
        public int? Status { get; set; }
        public string IsBusy { get; set; }
        public DateTime? RequestedScheduleDt { get; set; }
        public int? ScheduleExceedBy { get; set; }
        public int? WlConfirmedBy { get; set; }
        public DateTime? WlConfirmedOn { get; set; }
        public int? EncId { get; set; }
        public string EncType { get; set; }
        public string EncClinic { get; set; }
        public string NotifyAdminWl { get; set; }
        public string HisSync { get; set; }
        public string AdmissionNo { get; set; }
        public int? PendingBy { get; set; }
        public DateTime? PendingOn { get; set; }
        public string IsComments { get; set; }
        public int? BusyBy { get; set; }
        public DateTime? BusyOn { get; set; }
        public string PendingComments { get; set; }
        public int OrgId { get; set; }
        public int? LogsModifiedBy { get; set; }
        public DateTime? LogsModifiedOn { get; set; }
        public string LogsDesc { get; set; }
        public string LogsStatus { get; set; }
    }
}