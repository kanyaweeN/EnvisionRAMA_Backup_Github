namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_NURSESDATA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_NURSESDATA()
        {
            RIS_NURSESDATADTL = new HashSet<RIS_NURSESDATADTL>();
        }

        [Key]
        public int NURSE_DATA_UK_ID { get; set; }

        public int NURSE_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public DateTime INPUT_DT { get; set; }

        public int? ANESTHESIA_TECHNIQUE { get; set; }

        [StringLength(1)]
        public string PAST_ILL_DM { get; set; }

        [StringLength(1)]
        public string PAST_ILL_HT { get; set; }

        [StringLength(1)]
        public string PAST_ILL_HD { get; set; }

        [StringLength(1)]
        public string PAST_ILL_ASTHMA { get; set; }

        [StringLength(1)]
        public string PAST_ILL_OTHERS { get; set; }

        [StringLength(400)]
        public string PROCEDURE { get; set; }

        [StringLength(400)]
        public string DIAGNOSIS { get; set; }

        [StringLength(500)]
        public string OTHER_DESCRIPTION { get; set; }

        public int? ASSISTANT_ID { get; set; }

        public int? OPERATOR_ID { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_NURSESDATADTL> RIS_NURSESDATADTL { get; set; }
    }
}
