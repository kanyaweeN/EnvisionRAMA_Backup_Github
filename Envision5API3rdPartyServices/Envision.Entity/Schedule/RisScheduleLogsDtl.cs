using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Schedule
{
   public class RisScheduleLogsDtl
    {
        public int SchedulelogId { get; set; }
        public int ScheduleId { get; set; }
        public int ExamId { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public int? GenDtlId { get; set; }
        public int? RadId { get; set; }
        public int? PreparationId { get; set; }
        public int? BpviewId { get; set; }
        public int? AvgReqMin { get; set; }
        public int? PatDestId { get; set; }
        public string IsPortable { get; set; }
        public string SchedulePriority { get; set; }
    }
}