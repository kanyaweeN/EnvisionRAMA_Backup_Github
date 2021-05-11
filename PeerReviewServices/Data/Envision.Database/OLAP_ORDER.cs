namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OLAP_ORDER
    {
        [Key]
        public int OLAP_ORDER_ID { get; set; }

        public int? YEAR { get; set; }

        public int? MONTH { get; set; }

        public int? DAY { get; set; }

        public int? HOUR { get; set; }

        public int? ORDER_ID { get; set; }

        public DateTime? ORDER_DT { get; set; }

        [StringLength(1000)]
        public string ENC_TYPE { get; set; }

        [StringLength(100)]
        public string PRIORITY { get; set; }

        [StringLength(100)]
        public string STATUS { get; set; }

        [StringLength(100)]
        public string ACCESSION_NO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RATE { get; set; }

        public byte? QTY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GROSS_INCOME { get; set; }

        [StringLength(1000)]
        public string ORDERING_DEPARTMENT { get; set; }

        [StringLength(1000)]
        public string ORDERING_DEPARTMENT_ALIAS { get; set; }

        [StringLength(1000)]
        public string ORDERING_PHYSICIAN { get; set; }

        [StringLength(1000)]
        public string RADIOLOGIST { get; set; }

        [StringLength(1000)]
        public string PAT_DEST_UID { get; set; }

        [StringLength(100)]
        public string SEVERITY_NAME { get; set; }

        [StringLength(100)]
        public string HN { get; set; }

        [StringLength(1000)]
        public string NAME { get; set; }

        [StringLength(100)]
        public string EXAM_UID { get; set; }

        [StringLength(1000)]
        public string EXAM_NAME { get; set; }

        [StringLength(100)]
        public string EXAM_TYPE { get; set; }

        [StringLength(100)]
        public string SERVICE_TYPE { get; set; }

        [StringLength(100)]
        public string MODALITY_NAME { get; set; }

        [StringLength(100)]
        public string MODALITY_TYPE { get; set; }

        [StringLength(100)]
        public string CLINIC_TYPE { get; set; }

        [StringLength(1)]
        public string IS_SCHEDULE { get; set; }

        [StringLength(1)]
        public string IS_REQONLINE { get; set; }

        [StringLength(1)]
        public string IS_NOTIFY_ADMIN_WL { get; set; }

        [StringLength(30)]
        public string STATUS_TRAN { get; set; }

        [StringLength(200)]
        public string ASSIGNED_TO { get; set; }

        public int? AGE { get; set; }

        [StringLength(30)]
        public string AGE_TEXT { get; set; }

        [StringLength(2000)]
        public string CLINICAL_INSTRUCTION { get; set; }

        [StringLength(10)]
        public string GENDER { get; set; }

        [StringLength(300)]
        public string PATIENT_NAME { get; set; }

        public DateTime? REQUEST_DATETIME { get; set; }

        public DateTime? COMPLETE_DATETIME { get; set; }

        public DateTime? PRELIM_DATETIME { get; set; }

        public DateTime? FINALIZE_DATETIME { get; set; }

        public int? DIFF_COMPLETE_REQUEST { get; set; }

        public int? DIFF_PRELIM_COMPLETE { get; set; }

        public int? DIFF_FINALIZE_COMPLETE { get; set; }

        [StringLength(1000)]
        public string PRELIM_BY_NAME { get; set; }

        [StringLength(1000)]
        public string FINALIZE_BY_NAME { get; set; }

        [StringLength(100)]
        public string JOB_TITLE { get; set; }
    }
}
