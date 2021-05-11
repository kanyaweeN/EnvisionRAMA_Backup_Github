namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULT_FILTERWORKLIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_EXAMRESULT_FILTERWORKLIST()
        {
            RIS_EXAMRESULT_FILTERRAD = new HashSet<RIS_EXAMRESULT_FILTERRAD>();
        }

        [Key]
        public int FILTER_ID { get; set; }

        [StringLength(500)]
        public string FILTER_NAME { get; set; }

        public string FILTER_DETAIL { get; set; }

        public int? CRAETED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULT_FILTERRAD> RIS_EXAMRESULT_FILTERRAD { get; set; }
    }
}
