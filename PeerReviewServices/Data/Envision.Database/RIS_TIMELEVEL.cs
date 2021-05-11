namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_TIMELEVEL
    {
        [Key]
        [StringLength(10)]
        public string DateTime { get; set; }

        public DateTime? DatetimeOnCreate { get; set; }

        [StringLength(50)]
        public string EnglishDay { get; set; }

        [StringLength(50)]
        public string ThaiDay { get; set; }

        public int? DayNumberOfMonth { get; set; }

        [StringLength(50)]
        public string EnglishMonth { get; set; }

        [StringLength(50)]
        public string ThaiMonth { get; set; }

        public int? MonthNumberOfYear { get; set; }

        public int? EnglishYear { get; set; }

        public int? ThaiYear { get; set; }

        public int? DayOfWeek { get; set; }

        public int? CalendarHalfYear { get; set; }

        public int? CalendarQuarter { get; set; }
    }
}
