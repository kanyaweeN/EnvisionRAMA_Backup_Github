namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_UNIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INV_UNIT()
        {
            INV_REQUISITION = new HashSet<INV_REQUISITION>();
            INV_REQUISITION1 = new HashSet<INV_REQUISITION>();
            INV_ROOMSTOCKREDUCE = new HashSet<INV_ROOMSTOCKREDUCE>();
            INV_TRANSACTION = new HashSet<INV_TRANSACTION>();
            INV_TRANSACTION1 = new HashSet<INV_TRANSACTION>();
            INV_UNITREORDERLEVEL = new HashSet<INV_UNITREORDERLEVEL>();
        }

        [Key]
        public int UNIT_ID { get; set; }

        [StringLength(30)]
        public string UNIT_UID { get; set; }

        [StringLength(100)]
        public string UNIT_NAME { get; set; }

        [StringLength(250)]
        public string UNIT_DESC { get; set; }

        public int? EXTERNAL_UNIT { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_UNIT HR_UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_REQUISITION> INV_REQUISITION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_REQUISITION> INV_REQUISITION1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_ROOMSTOCKREDUCE> INV_ROOMSTOCKREDUCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_TRANSACTION> INV_TRANSACTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_TRANSACTION> INV_TRANSACTION1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_UNITREORDERLEVEL> INV_UNITREORDERLEVEL { get; set; }
    }
}
