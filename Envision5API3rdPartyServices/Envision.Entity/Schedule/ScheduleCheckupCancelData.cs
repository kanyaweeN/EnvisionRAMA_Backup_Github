using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Schedule
{
    public class ScheduleCheckupCancelData
    {
        public int pool_id { get; set; }
        public string cancel_by_code { get; set; }
        public string cancel_by_name { get; set; }
        public string cancel_reason { get; set; }
    }
}
