namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_ITEM
    {
        [Key]
        public int ITEM_ID { get; set; }

        [StringLength(30)]
        public string ITEM_UID { get; set; }

        [StringLength(100)]
        public string ITEM_NAME { get; set; }

        [StringLength(250)]
        public string ITEM_DESC { get; set; }

        [Column(TypeName = "image")]
        public byte[] ITEM_IMG { get; set; }

        [StringLength(100)]
        public string ITEM_BARCODE { get; set; }

        public int? CATEGORY_ID { get; set; }

        public int? TYPE_ID { get; set; }

        public int? TXN_UNIT { get; set; }

        public byte? RE_ORDER_DAYS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RE_ORDER_QTY { get; set; }

        public byte? ORDER_LEAD_TIME { get; set; }

        [StringLength(1)]
        public string IS_FOREIGN { get; set; }

        [StringLength(1)]
        public string INCLUDE_IN_AUTO_PR { get; set; }

        public int? GL_CODE { get; set; }

        [StringLength(1)]
        public string IS_FA { get; set; }

        [StringLength(1)]
        public string IS_REUSABLE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REUSE_PRICE_PERC { get; set; }

        public int? VENDOR_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PURCHASE_PRICE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SELLING_PRICE { get; set; }

        [StringLength(1)]
        public string ALLOW_PARTIAL_DELIVERY { get; set; }

        [StringLength(1)]
        public string ALLOW_PARTIAL_RECIEVE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WARNING_EMPTY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DANGEROUS_EMPTY { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual INV_CATEGORY INV_CATEGORY { get; set; }

        public virtual INV_ITEMTYPE INV_ITEMTYPE { get; set; }

        public virtual INV_VENDOR INV_VENDOR { get; set; }
    }
}
