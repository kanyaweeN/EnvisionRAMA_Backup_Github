namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MG_BREASTEXAMRESULT
    {
        [Key]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public DateTime? REPORTING_DATE { get; set; }

        [StringLength(1)]
        public string PATIENT_TYPE { get; set; }

        [StringLength(200)]
        public string PATIENT_TYPE_TEXT { get; set; }

        [StringLength(1)]
        public string BREAST_COMPOSITION { get; set; }

        public byte? NO_OF_MASS { get; set; }

        [StringLength(1)]
        public string IS_MULTIPLE_MASS { get; set; }

        [StringLength(1)]
        public string HAS_DOMINANT_CYST { get; set; }

        [StringLength(1)]
        public string IS_MG_NEGATIVE { get; set; }

        [StringLength(1)]
        public string IS_US_NEGATIVE { get; set; }

        [StringLength(1)]
        public string PERSONAL_HISTORY_OF_BREAST_CANCER { get; set; }

        [StringLength(1)]
        public string PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE { get; set; }

        [StringLength(1)]
        public string FAMILY_HISTORY_OF_BREAST_CANCER { get; set; }

        [StringLength(1)]
        public string FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE { get; set; }

        [StringLength(1)]
        public string CLINICAL_HISTORY_TYPE { get; set; }

        [StringLength(500)]
        public string IMPRESSION_TEXT { get; set; }

        [StringLength(1)]
        public string FINAL_ASSESSMENT_TYPE { get; set; }

        [StringLength(1)]
        public string RECOMMENDATION_TYPE { get; set; }

        [StringLength(1)]
        public string RECOMMENDATION_TYPE_WITH_BREAST_SIDE { get; set; }

        [StringLength(200)]
        public string RECOMMENDATION_TYPE_TEXT { get; set; }

        [StringLength(1)]
        public string REPORT_STATUS { get; set; }

        public int? PRELIM_BY { get; set; }

        public int? FINALIZED_BY { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [Column(TypeName = "image")]
        public byte[] BREAT_IMAGE_LEFT { get; set; }

        [Column(TypeName = "image")]
        public byte[] BREAT_IMAGE_RIGHT { get; set; }

        [StringLength(1)]
        public string IS_MULTIPLE_CYST { get; set; }

        [StringLength(1)]
        public string SHOW_BREAST_IMAGE_LEFT { get; set; }

        [StringLength(1)]
        public string SHOW_BREAST_IMAGE_RIGHT { get; set; }

        [StringLength(300)]
        public string COMMENT { get; set; }

        [StringLength(1)]
        public string IS_MIX_MODE { get; set; }

        [StringLength(1000)]
        public string MAMMOGRAM_TEXT { get; set; }

        [StringLength(1000)]
        public string ULTRASOUND_TEXT { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
