namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_HL7IELOG
    {
        [Key]
        public int LOG_ID { get; set; }

        [StringLength(30)]
        public string SENDER { get; set; }

        [StringLength(30)]
        public string RECEIVER { get; set; }

        [StringLength(3)]
        public string MESSAGE_TYPE { get; set; }

        [StringLength(3)]
        public string EVENT_TYPE { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [StringLength(30)]
        public string COMPARE_VALUE { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [Required]
        public string HL7_TEXT { get; set; }

        [Required]
        [StringLength(2)]
        public string ACKNOWLEDGMENT_CODE { get; set; }

        [Required]
        [StringLength(500)]
        public string TEXT_MESSAGE { get; set; }

        [StringLength(1)]
        public string IS_LOCK { get; set; }

        public int ORG_ID { get; set; }

        public int LAST_MODIFIED_BY { get; set; }

        public DateTime LAST_MODIFIED_ON { get; set; }

        public int CREATED_BY { get; set; }

        public DateTime CREATED_ON { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? SENDER_ID { get; set; }

        public int? RECEIVER_ID { get; set; }
    }
}
