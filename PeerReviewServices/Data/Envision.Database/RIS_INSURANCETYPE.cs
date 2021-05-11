namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_INSURANCETYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_INSURANCETYPE()
        {
            RIS_ORDER = new HashSet<RIS_ORDER>();
        }

        [Key]
        public int INSURANCE_TYPE_ID { get; set; }

        [StringLength(30)]
        public string INSURANCE_TYPE_UID { get; set; }

        [StringLength(200)]
        public string INSURANCE_TYPE_DESC { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDER> RIS_ORDER { get; set; }
    }
}
