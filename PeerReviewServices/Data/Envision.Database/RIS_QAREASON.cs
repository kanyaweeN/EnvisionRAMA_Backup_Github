namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_QAREASON
    {
        [Key]
        public int REASON_ID { get; set; }

        [StringLength(30)]
        public string REASON_UID { get; set; }

        [StringLength(150)]
        public string REASON_TEXT { get; set; }

        [StringLength(200)]
        public string REASON_ACTION { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
