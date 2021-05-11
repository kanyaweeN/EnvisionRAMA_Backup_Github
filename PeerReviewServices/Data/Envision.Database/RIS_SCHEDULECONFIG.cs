namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_SCHEDULECONFIG
    {
        [Key]
        public int SCHEDULE_CONFIG_ID { get; set; }

        public byte? SCHEDULE_CONFIRM_TIME { get; set; }

        [StringLength(1)]
        public string CAN_OVERLAP { get; set; }

        [StringLength(1)]
        public string CAN_EXCEED_MAX { get; set; }

        [StringLength(1)]
        public string SHOW_ALERT { get; set; }

        [StringLength(1)]
        public string NEED_CONFIRMATION { get; set; }

        [StringLength(3)]
        public string DEFAULT_SEARCH { get; set; }

        [StringLength(3)]
        public string DEFAULT_ONLINE_ACTION { get; set; }

        public TimeSpan? START_WORK_TIME { get; set; }

        public TimeSpan? END_WORK_TIME { get; set; }

        [StringLength(1)]
        public string WORK_TIME_IS_CHECKED { get; set; }

        [StringLength(3)]
        public string DEFAULT_CALENDAR_VIEW { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string ALLOW_UNTIMED_SCHEDULE { get; set; }

        public TimeSpan? TIME_SCALE { get; set; }

        public byte? SCHEDULE_REFRESH_TIME { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }
    }
}
