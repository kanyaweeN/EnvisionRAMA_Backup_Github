namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULTLEGACY
    {
        [Key]
        public int EXAMRESULTLEGACY_ID { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        [Required]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [Required]
        [StringLength(30)]
        public string ORDER_UID { get; set; }

        [Required]
        [StringLength(30)]
        public string EXAM_UID { get; set; }

        public string RESULT_TEXT_HTML { get; set; }

        [StringLength(1)]
        public string RESULT_STATUS { get; set; }

        public int? RELEASED_BY { get; set; }

        public DateTime? RELEASED_ON { get; set; }

        public int? FINALIZED_BY { get; set; }

        public DateTime? FINALIZED_ON { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        [StringLength(30)]
        public string USER_NAME { get; set; }
    }
}
