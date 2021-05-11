using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Schedule
{
    public class ScheduleResponse
    {
        public int code { get; set; }
        public string message { get; set; }
        public int? pool_id { get; set; }
    }
}
