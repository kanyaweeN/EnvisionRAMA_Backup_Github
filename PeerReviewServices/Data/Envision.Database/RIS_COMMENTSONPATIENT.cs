namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_COMMENTSONPATIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_COMMENTSONPATIENT()
        {
            RIS_COMMENTSONPATIENTDTL = new HashSet<RIS_COMMENTSONPATIENTDTL>();
        }

        [Key]
        public int COMMENT_ID { get; set; }

        public int? PARENT_ID { get; set; }

        public int REG_ID { get; set; }

        public int? SCHEDULE_ID { get; set; }

        public int? ORDER_ID { get; set; }

        public DateTime? COMMENT_DT { get; set; }

        public int? COMMENT_FROM { get; set; }

        [StringLength(500)]
        public string COMMENT_SUBJECT { get; set; }

        public string COMMENT_BODY { get; set; }

        [StringLength(1)]
        public string COMMENT_STATUS { get; set; }

        [StringLength(1)]
        public string COMMENT_PRIORITY { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_RISK { get; set; }

        [StringLength(1)]
        public string IS_POPUP { get; set; }

        [StringLength(1)]
        public string POP_USER { get; set; }

        public byte? POP_TIME { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual RIS_ORDER RIS_ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_COMMENTSONPATIENTDTL> RIS_COMMENTSONPATIENTDTL { get; set; }
    }
}
