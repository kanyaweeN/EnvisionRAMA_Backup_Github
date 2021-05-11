namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_SESSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GBL_SESSION()
        {
            GBL_SESSIONLOG = new HashSet<GBL_SESSIONLOG>();
        }

        [Key]
        public int SESSION_ID { get; set; }

        [StringLength(1)]
        public string SESSION_STAT { get; set; }

        public int? EMP_ID { get; set; }

        [StringLength(50)]
        public string SESSION_GUID { get; set; }

        [StringLength(13)]
        public string SID { get; set; }

        [Column("SERIAL#")]
        [StringLength(13)]
        public string SERIAL_ { get; set; }

        [StringLength(1)]
        public string LOGON_TYPE { get; set; }

        public DateTime? LOGON_DT { get; set; }

        public DateTime? LOGOUT_DT { get; set; }

        [StringLength(1)]
        public string LOGOUT_TYPE { get; set; }

        public int? KILLED_BY { get; set; }

        [StringLength(500)]
        public string KILL_REASON { get; set; }

        [StringLength(100)]
        public string OS_USER_NAME { get; set; }

        [StringLength(100)]
        public string OS_NAME { get; set; }

        [StringLength(100)]
        public string OS_TIMEZONE { get; set; }

        [StringLength(100)]
        public string OS_REGION { get; set; }

        [StringLength(20)]
        public string IP_ADDR_OWN { get; set; }

        [StringLength(20)]
        public string IP_ADDR_CURR { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(50)]
        public string PROD_VERSION { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SESSIONLOG> GBL_SESSIONLOG { get; set; }
    }
}
