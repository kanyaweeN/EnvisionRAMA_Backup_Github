using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Schedule
{
    public class ScheduleDtlCheckupData
    {
        public string exam_code { get; set; }
        public string exam_name { get; set; }
        public int qty { get; set; }
        public decimal rate { get; set; }
    }
}
