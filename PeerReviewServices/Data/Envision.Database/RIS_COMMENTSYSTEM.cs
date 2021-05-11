namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_COMMENTSYSTEM
    {
        [Key]
        public int COMMENT_ID { get; set; }

        public int SENDER_ID { get; set; }

        [StringLength(3000)]
        public string MSG_TEXT { get; set; }

        [StringLength(50)]
        public string MSG_STATUS { get; set; }

        public int? SCHEDULE_ID { get; set; }

        public int? ORDER_ID { get; set; }

        public int? XRAYREQ_ID { get; set; }

        public int? EXAM_ID { get; set; }

        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }
    }
}
