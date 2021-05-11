namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULTCONSULT
    {
        [Key]
        public int CONSULT_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int FINALIZING_RAD { get; set; }

        public int? REQUESTED_BY { get; set; }

        public DateTime? REQUESTED_ON { get; set; }

        public int CONSULTING_RAD { get; set; }

        public DateTime CONSULTED_ON { get; set; }

        [StringLength(1)]
        public string IS_FREE { get; set; }

        [StringLength(1)]
        public string SEND_IM { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public string ORIGINAL_RESULT_TEXT { get; set; }

        public string NEW_RESULT_TEXT { get; set; }

        public int? TRANSFER_TO { get; set; }

        public int? ORDER_ID { get; set; }
    }
}
