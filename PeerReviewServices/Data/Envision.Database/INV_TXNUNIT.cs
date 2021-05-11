namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_TXNUNIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INV_TXNUNIT()
        {
            INV_TRANSACTIONDTL = new HashSet<INV_TRANSACTIONDTL>();
        }

        [Key]
        public int TXN_UNIT_ID { get; set; }

        [StringLength(30)]
        public string TXN_UNIT_UID { get; set; }

        [StringLength(100)]
        public string TXN_UNIT_NAME { get; set; }

        [StringLength(250)]
        public string TXN_UNIT_DESC { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_TRANSACTIONDTL> INV_TRANSACTIONDTL { get; set; }

        public virtual INV_TXNUNIT INV_TXNUNIT1 { get; set; }

        public virtual INV_TXNUNIT INV_TXNUNIT2 { get; set; }
    }
}
