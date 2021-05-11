namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_HL7TRANSACTIONLOG
    {
        [Key]
        public int LOG_NO { get; set; }

        [Required]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [Required]
        [StringLength(5)]
        public string MSG_TYPE { get; set; }

        [StringLength(1)]
        public string TRANS_TYPE { get; set; }

        [StringLength(100)]
        public string TRANS_WITH { get; set; }

        public DateTime? TRANS_TIMESTAMP { get; set; }

        [Required]
        [StringLength(2)]
        public string ACK_MSG { get; set; }

        public DateTime? ACK_TIMESTAMP { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
