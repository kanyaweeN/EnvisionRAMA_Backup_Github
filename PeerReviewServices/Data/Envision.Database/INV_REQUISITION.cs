namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_REQUISITION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INV_REQUISITION()
        {
            INV_AUTHORIZATION = new HashSet<INV_AUTHORIZATION>();
            INV_REQUISITIONDTL = new HashSet<INV_REQUISITIONDTL>();
        }

        [Key]
        public int REQUISITION_ID { get; set; }

        [StringLength(50)]
        public string REQUISITION_UID { get; set; }

        [StringLength(1)]
        public string REQUISITION_TYPE { get; set; }

        [StringLength(1)]
        public string GENERATE_MODE { get; set; }

        public int? FROM_UNIT { get; set; }

        public int? TO_UNIT { get; set; }

        public int? GENERATED_BY { get; set; }

        public DateTime? GENERATED_ON { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_STAT { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_AUTHORIZATION> INV_AUTHORIZATION { get; set; }

        public virtual INV_UNIT INV_UNIT { get; set; }

        public virtual INV_UNIT INV_UNIT1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_REQUISITIONDTL> INV_REQUISITIONDTL { get; set; }
    }
}
