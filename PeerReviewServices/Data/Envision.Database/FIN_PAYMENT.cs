namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FIN_PAYMENT
    {
        [Key]
        public int PAY_ID { get; set; }

        public DateTime? PAY_DT { get; set; }

        public long? INV_ID { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        public int? UNIT_ID { get; set; }

        public int? EMP_ID { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? ORDER_ID { get; set; }

        public int? REG_ID { get; set; }

        [StringLength(30)]
        public string PAY_UID { get; set; }

        [StringLength(200)]
        public string REF_NAME { get; set; }

        [StringLength(1000)]
        public string REF_ADR { get; set; }

        public virtual HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_UNIT HR_UNIT { get; set; }
    }
}
