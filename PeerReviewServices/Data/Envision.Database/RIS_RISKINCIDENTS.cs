namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_RISKINCIDENTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_RISKINCIDENTS()
        {
            RIS_RISKINCIDENTUSERS = new HashSet<RIS_RISKINCIDENTUSERS>();
        }

        [Key]
        public int INCIDENT_ID { get; set; }

        public int? INCIDENT_UID { get; set; }

        public DateTime INCIDENT_DT { get; set; }

        public int? RISK_CAT_ID { get; set; }

        [StringLength(150)]
        public string INCIDENT_SUBJ { get; set; }

        [StringLength(500)]
        public string INCIDENT_DESC { get; set; }

        public int? COMMENT_ID { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string PRIORITY { get; set; }

        public int? REG_ID { get; set; }

        public int? ORDER_ID { get; set; }

        public int? SCHEDULE_ID { get; set; }

        public int? XRAYREQ_ID { get; set; }

        [StringLength(1)]
        public string INCIDENT_CHOOSED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_RISKINCIDENTUSERS> RIS_RISKINCIDENTUSERS { get; set; }
    }
}
