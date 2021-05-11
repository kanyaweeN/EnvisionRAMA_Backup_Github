namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_TRANSACTIONDTL
    {
        [Key]
        public int TXNDTL_ID { get; set; }

        public int TXN_ID { get; set; }

        public int ITEM_ID { get; set; }

        public int? REF_ITEM_ID { get; set; }

        public int? TXN_UNIT { get; set; }

        public int? BATCH { get; set; }

        public DateTime? EXPIRY_DT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QTY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRICE { get; set; }

        [StringLength(200)]
        public string COMMENTS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual INV_TXNUNIT INV_TXNUNIT { get; set; }
    }
}
