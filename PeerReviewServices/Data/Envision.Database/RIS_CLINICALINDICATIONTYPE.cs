namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_CLINICALINDICATIONTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_CLINICALINDICATIONTYPE()
        {
            RIS_CLINICALINDICATIONLASTVISIT = new HashSet<RIS_CLINICALINDICATIONLASTVISIT>();
            RIS_CLINICALINDICATIONTYPEFAVORITES = new HashSet<RIS_CLINICALINDICATIONTYPEFAVORITES>();
        }

        [Key]
        public int CI_TYPE_ID { get; set; }

        [StringLength(50)]
        public string CI_UID { get; set; }

        [StringLength(300)]
        public string CI_DESC { get; set; }

        public int? PARENT_ID { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? LEVEL { get; set; }

        public int? SL_NO { get; set; }

        [StringLength(1)]
        public string NEED_DETAIL { get; set; }

        [StringLength(1)]
        public string NEED_DETAILLIST { get; set; }

        [StringLength(300)]
        public string DEFAULT_TEXT { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [StringLength(1)]
        public string IS_USER_DEFINED { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONLASTVISIT> RIS_CLINICALINDICATIONLASTVISIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONTYPEFAVORITES> RIS_CLINICALINDICATIONTYPEFAVORITES { get; set; }
    }
}
