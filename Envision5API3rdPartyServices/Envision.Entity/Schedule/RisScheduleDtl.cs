using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Schedule
{
    public class RisScheduleDtl
    {
        public int ScheduleId { get; set; }
        public int ExamId { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public int? GenDtlId { get; set; }
        public int? RadId { get; set; }
        public int? PreparationId { get; set; }
        public int? BpviewId { get; set; }
        public int? AvgReqMin { get; set; }
        public int OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int? PatDestId { get; set; }
        public string IsPortable { get; set; }
        public string SchedulePriority { get; set; }

        public RisSchedule RisSchedule { get; set; }
    }
}
