namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULTSTATREPORT
    {
        public int ORDER_ID { get; set; }

        public int EXAM_ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        public int NOTE_NO { get; set; }

        public string NOTE_TEXT { get; set; }

        public int? NOTE_BY { get; set; }

        public DateTime? NOTE_ON { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public string NOTE_TEXT_RTF { get; set; }

        public string NOTE_TEXT_HTML { get; set; }

        public string NOTE_TEXT_RTFtoHTML { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
