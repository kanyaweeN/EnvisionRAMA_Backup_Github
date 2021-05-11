namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_PODTL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PO_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ITEM_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QTY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UNITPRICE { get; set; }

        [StringLength(1)]
        public string PO_ITEM_STATUS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual INV_PO INV_PO { get; set; }
    }
}
