namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_EMPSCHEDULE
    {
        [Key]
        public int SCHEDULE_ID { get; set; }

        public int? EMP_ID { get; set; }

        public bool? ALLDAY { get; set; }

        [StringLength(50)]
        public string SUBJECT { get; set; }

        public DateTime? STARTDATETIME { get; set; }

        public DateTime? ENDDATETIME { get; set; }

        public int? STATUS { get; set; }

        public int? LABEL { get; set; }

        [StringLength(50)]
        public string LOCATION { get; set; }

        public int? EVENTTYPE { get; set; }

        public string DESCRIPTION { get; set; }

        public string RECURRENCEINFO { get; set; }

        public string REMINDERINFO { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? SCHEDULE_ID_PARENT { get; set; }
    }
}
