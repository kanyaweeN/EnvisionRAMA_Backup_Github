namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_JOBTITLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HR_JOBTITLE()
        {
            HR_EMP = new HashSet<HR_EMP>();
        }

        [Key]
        public int JOB_TITLE_ID { get; set; }

        [StringLength(30)]
        public string JOB_TITLE_UID { get; set; }

        [StringLength(300)]
        public string JOB_TITLE_DESC { get; set; }

        [StringLength(10)]
        public string IS_ACTIVE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public byte? SL_NO { get; set; }

        [StringLength(30)]
        public string JOB_TITLE_TAG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HR_EMP> HR_EMP { get; set; }
    }
}
