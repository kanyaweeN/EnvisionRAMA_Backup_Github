namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_BILLINGTRANSACTIONLOG_AUDIT
    {
        [Key]
        [Column(Order = 0)]
        public int PAY_AUDIT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime PAY_START { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }
    }
}
