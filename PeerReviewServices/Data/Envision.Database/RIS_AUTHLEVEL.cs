namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_AUTHLEVEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_AUTHLEVEL()
        {
            HR_EMP = new HashSet<HR_EMP>();
            HR_EMP1 = new HashSet<HR_EMP>();
        }

        [Key]
        public int AUTH_LEVEL_ID { get; set; }

        [StringLength(30)]
        public string AUTH_LEVEL_UID { get; set; }

        [StringLength(300)]
        public string AUTH_LEVEL_DESC { get; set; }

        public byte? AUTH_LEVEL_SL { get; set; }

        [StringLength(500)]
        public string AUTH_LEVEL_TEXT { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HR_EMP> HR_EMP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HR_EMP> HR_EMP1 { get; set; }
    }
}
