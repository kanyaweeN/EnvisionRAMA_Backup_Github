namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_PRSTUDIES
    {
        [Key]
        public int STUDY_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public byte ITERATION { get; set; }

        public int PR_ALGORITHM_ID { get; set; }

        public int PR_GROUP_ID { get; set; }

        public int RAD_ID { get; set; }

        public int? RAD_OPINION { get; set; }

        [StringLength(1)]
        public string IS_CLINICALLY_SIGNIFICANT { get; set; }

        [StringLength(300)]
        public string RAD_COMMENTS { get; set; }

        [StringLength(1)]
        public string QA_SCORE { get; set; }

        public int? QA_BY { get; set; }

        public DateTime? QA_ON { get; set; }

        [StringLength(1)]
        public string PR_STATUS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? REPORT_LANG_ID { get; set; }

        [StringLength(300)]
        public string REPORT_LANG_COMMENTS { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_EXAMRESULT RIS_EXAMRESULT { get; set; }

        public virtual RIS_PRALGORITHM RIS_PRALGORITHM { get; set; }

        public virtual RIS_PRGROUP RIS_PRGROUP { get; set; }
    }
}
