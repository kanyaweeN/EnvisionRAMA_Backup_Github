namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_PRDTL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PR_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ITEM_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QTY { get; set; }

        [StringLength(250)]
        public string REMARK { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual INV_PR INV_PR { get; set; }

        public virtual INV_PRDTL INV_PRDTL1 { get; set; }

        public virtual INV_PRDTL INV_PRDTL2 { get; set; }
    }
}
