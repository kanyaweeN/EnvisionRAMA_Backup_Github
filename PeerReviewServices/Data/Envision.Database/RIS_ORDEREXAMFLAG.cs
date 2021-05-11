namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_ORDEREXAMFLAG
    {
        [Key]
        public int FLAG_ID { get; set; }

        public int? ORDER_ID { get; set; }

        public int? SCHEDULE_ID { get; set; }

        public int? XRAYREQ_ID { get; set; }

        public int EXAM_ID { get; set; }

        public int EXAMFLAG_ID { get; set; }

        [StringLength(500)]
        public string REASON { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
