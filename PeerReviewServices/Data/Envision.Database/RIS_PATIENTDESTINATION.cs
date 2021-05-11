namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_PATIENTDESTINATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_PATIENTDESTINATION()
        {
            RIS_LOCATIONMAPPING = new HashSet<RIS_LOCATIONMAPPING>();
            RIS_ORDERDTL = new HashSet<RIS_ORDERDTL>();
            RIS_SCHEDULEDEFAULTDESTINATION = new HashSet<RIS_SCHEDULEDEFAULTDESTINATION>();
            RIS_SCHEDULEDTL = new HashSet<RIS_SCHEDULEDTL>();
        }

        [Key]
        public int PAT_DEST_ID { get; set; }

        [StringLength(30)]
        public string TYPE { get; set; }

        [StringLength(30)]
        public string LABEL { get; set; }

        [StringLength(30)]
        public string ENCOUNTER_TYPE { get; set; }

        [StringLength(30)]
        public string ENCOUNTER_CLINIC_TYPE { get; set; }

        [StringLength(300)]
        public string ORDERING_DEPT { get; set; }

        public int? EXAM_UNIT { get; set; }

        public int ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_UNIT HR_UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_LOCATIONMAPPING> RIS_LOCATIONMAPPING { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERDTL> RIS_ORDERDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTDESTINATION> RIS_SCHEDULEDEFAULTDESTINATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDTL> RIS_SCHEDULEDTL { get; set; }
    }
}
