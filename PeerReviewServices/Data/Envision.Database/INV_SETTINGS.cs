namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_SETTINGS
    {
        [Key]
        public int SETTINGS_ID { get; set; }

        [StringLength(30)]
        public string SETTINGS_UID { get; set; }

        [StringLength(1)]
        public string INV_METHOD { get; set; }

        [StringLength(1)]
        public string FREE_PROD_PRICING { get; set; }

        [StringLength(1)]
        public string DISCOUNT_EFFECT { get; set; }

        public byte? PO_AUTH_LEVEL { get; set; }

        [StringLength(1)]
        public string GENERATE_AUTO_PR { get; set; }

        public byte? AUTO_PR_FREQ_DAYS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GLOBAL_SELLING_MARKUP { get; set; }

        [StringLength(1)]
        public string ALLOW_NEW_IF_PENDING { get; set; }

        [StringLength(1)]
        public string OVERRIDE_IF_EMERGENCY { get; set; }

        [StringLength(1)]
        public string SELL_REUSED_WO_RENTRY { get; set; }

        [StringLength(1)]
        public string REORDER_CALC_METHOD { get; set; }

        [StringLength(1)]
        public string CENTRAL_STOCK_UNIT { get; set; }

        [StringLength(1)]
        public string DEPT_STOCK_UNIT { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
