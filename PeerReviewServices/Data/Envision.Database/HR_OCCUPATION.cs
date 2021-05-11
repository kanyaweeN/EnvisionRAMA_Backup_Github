namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_OCCUPATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HR_OCCUPATION()
        {
            HIS_REGISTRATION = new HashSet<HIS_REGISTRATION>();
        }

        [Key]
        public int OCCUPATION_ID { get; set; }

        [StringLength(50)]
        public string OCCUPATION_UID { get; set; }

        [StringLength(200)]
        public string OCCUPATION_DESC { get; set; }

        public int? ORG_ID { get; set; }

        [StringLength(30)]
        public string CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        [StringLength(30)]
        public string LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HIS_REGISTRATION> HIS_REGISTRATION { get; set; }
    }
}
