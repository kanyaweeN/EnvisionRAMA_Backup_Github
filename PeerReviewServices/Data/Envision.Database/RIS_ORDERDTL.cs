namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_ORDERDTL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ORDER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EXAM_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public byte? Q_NO { get; set; }

        public int MODALITY_ID { get; set; }

        public DateTime? EXAM_DT { get; set; }

        public int? SERVICE_TYPE { get; set; }

        public byte QTY { get; set; }

        public DateTime? EST_START_TIME { get; set; }

        public int? ASSIGNED_TO { get; set; }

        [StringLength(1000)]
        public string HL7_TEXT { get; set; }

        [StringLength(1)]
        public string HL7_SENT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RATE { get; set; }

        [StringLength(200)]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string SPECIAL_CLINIC { get; set; }

        [StringLength(1)]
        public string SELF_ARRIVAL { get; set; }

        public int? IMAGE_CAPTURED_BY { get; set; }

        public DateTime? IMAGE_CAPTURED_ON { get; set; }

        public int? QA_BY { get; set; }

        public DateTime? QA_ON { get; set; }

        public int? ORG_ID { get; set; }

        [StringLength(1)]
        public string PRIORITY { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ASSIGNED_BY { get; set; }

        public DateTime? ASSIGNED_TIMESTAMP { get; set; }

        public int? CLINIC_TYPE { get; set; }

        public int? BPVIEW_ID { get; set; }

        [StringLength(3)]
        public string MERGE { get; set; }

        [StringLength(30)]
        public string MERGE_WITH { get; set; }

        [StringLength(1)]
        public string HIS_SYNC { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(300)]
        public string HIS_ACK { get; set; }

        public int? PREPARATION_ID { get; set; }

        [StringLength(200)]
        public string ORDER_GUID { get; set; }

        public int? NO_OF_IMAGES { get; set; }

        public int? NO_OF_FILMS { get; set; }

        [StringLength(15)]
        public string MPPS_STATUS { get; set; }

        [StringLength(20)]
        public string CAPTURE_START_ON { get; set; }

        [StringLength(20)]
        public string CAPTURE_END_ON { get; set; }

        public int? PAT_DEST_ID { get; set; }

        [StringLength(1)]
        public string HAS_COMMENT { get; set; }

        [StringLength(1)]
        public string IS_PORTABLE { get; set; }

        public int? AE_TITLE_ID { get; set; }

        [StringLength(200)]
        public string COMMENTS_FREERATE { get; set; }

        public int? IMAGECOUNT { get; set; }

        [StringLength(100)]
        public string INSTANCE_UID { get; set; }

        public int? WORK_STATION_ID { get; set; }

        [StringLength(1)]
        public string IS_DF { get; set; }

        public DateTime? DF_ON { get; set; }

        public int? DF_BY { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_CLINICTYPE RIS_CLINICTYPE { get; set; }

        public virtual RIS_EXAM RIS_EXAM { get; set; }

        public virtual RIS_MODALITY RIS_MODALITY { get; set; }

        public virtual RIS_MODALITYAETITLE RIS_MODALITYAETITLE { get; set; }

        public virtual RIS_ORDER RIS_ORDER { get; set; }

        public virtual RIS_PATIENTDESTINATION RIS_PATIENTDESTINATION { get; set; }
    }
}
