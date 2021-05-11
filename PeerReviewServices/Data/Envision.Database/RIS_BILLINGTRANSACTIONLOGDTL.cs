namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_BILLINGTRANSACTIONLOGDTL
    {
        [Key]
        [Column(Order = 0)]
        public int BILL_LOG_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ACCESSION_NO { get; set; }

        [Required]
        public string BILLING_MSG { get; set; }

        [Required]
        [StringLength(100)]
        public string BILLING_ACK_MSG { get; set; }

        [StringLength(50)]
        public string HN { get; set; }

        [StringLength(50)]
        public string AN { get; set; }

        [StringLength(50)]
        public string ISEQ { get; set; }

        [StringLength(50)]
        public string UNIT_UID { get; set; }

        public DateTime? ORDER_DT { get; set; }

        [StringLength(50)]
        public string EXAM_UID { get; set; }

        public int? QTY { get; set; }

        public decimal? RATE { get; set; }

        public decimal? AMOUNT { get; set; }

        [StringLength(50)]
        public string HR_UNIT { get; set; }

        [StringLength(5)]
        public string MSG_TYPE { get; set; }

        [StringLength(50)]
        public string CLINIC_TYPE { get; set; }

        [StringLength(50)]
        public string INSURANCE_TYPE_UID { get; set; }

        [StringLength(50)]
        public string HR_EMP { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [Required]
        [StringLength(20)]
        public string BILLING_TYPE { get; set; }

        [StringLength(100)]
        public string ENC_ID { get; set; }

        [StringLength(10)]
        public string ENC_TYPE { get; set; }
    }
}
