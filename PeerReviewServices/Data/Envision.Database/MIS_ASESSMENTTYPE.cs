namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MIS_ASESSMENTTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MIS_ASESSMENTTYPE()
        {
            MIS_BIOPSYRESULT = new HashSet<MIS_BIOPSYRESULT>();
        }

        [Key]
        public int ASESSMENT_TYPE_ID { get; set; }

        [StringLength(30)]
        public string ASESSMENT_TYPE_UID { get; set; }

        [StringLength(300)]
        public string ASESSMENT_TYPE_DESC { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIS_BIOPSYRESULT> MIS_BIOPSYRESULT { get; set; }
    }
}
