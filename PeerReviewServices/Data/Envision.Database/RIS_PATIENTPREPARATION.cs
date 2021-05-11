namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_PATIENTPREPARATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_PATIENTPREPARATION()
        {
            RIS_SCHEDULEDTL = new HashSet<RIS_SCHEDULEDTL>();
        }

        [Key]
        public int PREPARATION_ID { get; set; }

        [StringLength(30)]
        public string PREPARATION_UID { get; set; }

        [StringLength(300)]
        public string PREPARATION_DESC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDTL> RIS_SCHEDULEDTL { get; set; }
    }
}
