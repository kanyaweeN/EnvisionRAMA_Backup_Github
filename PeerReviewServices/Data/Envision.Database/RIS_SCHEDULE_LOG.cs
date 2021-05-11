namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_SCHEDULE_LOG
    {
        public int ID { get; set; }

        public int? SCHEDULE_ID { get; set; }

        public int? REG_ID { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        public int? MODALITY_ID { get; set; }

        public int? EXAM_ID { get; set; }

        public DateTime? START_DATETIME { get; set; }

        public DateTime? END_DATETIME { get; set; }

        public int? REF_UNIT { get; set; }

        public int? REF_DOC { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [StringLength(1000)]
        public string REASON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? SESSION_ID { get; set; }

        [StringLength(50)]
        public string LOGS_DESC { get; set; }
    }
}
