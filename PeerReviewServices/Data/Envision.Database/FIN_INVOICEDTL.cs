namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FIN_INVOICEDTL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long INV_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EXAM_ID { get; set; }

        public int ITEM_ID { get; set; }

        public byte? QTY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DISCOUNT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAYABLE { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? ORDER_ID { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
