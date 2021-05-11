namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_SCHEDULEDTL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SCHEDULE_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EXAM_ID { get; set; }

        public int QTY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RATE { get; set; }

        public int? GEN_DTL_ID { get; set; }

        public int? RAD_ID { get; set; }

        public int? PREPARATION_ID { get; set; }

        public int? BPVIEW_ID { get; set; }

        public int? AVG_REQ_MIN { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? PAT_DEST_ID { get; set; }

        [StringLength(1)]
        public string IS_PORTABLE { get; set; }

        [StringLength(1)]
        public string SCHEDULE_PRIORITY { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual GBL_GENERALDTL GBL_GENERALDTL { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        public virtual HR_EMP HR_EMP2 { get; set; }

        public virtual RIS_BPVIEW RIS_BPVIEW { get; set; }

        public virtual RIS_PATIENTDESTINATION RIS_PATIENTDESTINATION { get; set; }

        public virtual RIS_PATIENTPREPARATION RIS_PATIENTPREPARATION { get; set; }
    }
}
