namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULTSEVERITY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_EXAMRESULTSEVERITY()
        {
            RIS_EXAMRESULT = new HashSet<RIS_EXAMRESULT>();
            RIS_EXAMRESULTTEMPLATE = new HashSet<RIS_EXAMRESULTTEMPLATE>();
        }

        [Key]
        public int SEVERITY_ID { get; set; }

        [StringLength(30)]
        public string SEVERITY_UID { get; set; }

        [StringLength(50)]
        public string SEVERITY_NAME { get; set; }

        [StringLength(100)]
        public string SEVERITY_LABEL { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? UNIT_ID { get; set; }

        [StringLength(1)]
        public string IS_CRITICAL { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_UNIT HR_UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULT> RIS_EXAMRESULT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTTEMPLATE> RIS_EXAMRESULTTEMPLATE { get; set; }
    }
}
