namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_ITEMSTOCK
    {
        [Key]
        public int ITEM_STOCK_ID { get; set; }

        public int? UNIT_ID { get; set; }

        public int? ITEM_ID { get; set; }

        [StringLength(50)]
        public string BATCH { get; set; }

        public DateTime? EXPIRY_DT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QTY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRICE { get; set; }

        public int? REQUISITION_ID { get; set; }

        public int? PO_ID { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
