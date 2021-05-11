namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_SCHEDULEDEFAULTDESTINATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_SCHEDULEDEFAULTDESTINATION()
        {
            RIS_SCHEDULEDEFAULTMODALITY = new HashSet<RIS_SCHEDULEDEFAULTMODALITY>();
        }

        [Key]
        public int SCH_DEF_DEST_ID { get; set; }

        public int EMP_ID { get; set; }

        public int PAT_DEST_ID { get; set; }

        public int ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        public virtual HR_EMP HR_EMP2 { get; set; }

        public virtual RIS_PATIENTDESTINATION RIS_PATIENTDESTINATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTMODALITY> RIS_SCHEDULEDEFAULTMODALITY { get; set; }
    }
}
