namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_EXAMRESULT()
        {
            RIS_EXAMRESULTNOTE = new HashSet<RIS_EXAMRESULTNOTE>();
            RIS_PRSTUDIES = new HashSet<RIS_PRSTUDIES>();
            RIS_SEARCH_DTL = new HashSet<RIS_SEARCH_DTL>();
        }

        [Key]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int ORDER_ID { get; set; }

        public int EXAM_ID { get; set; }

        public string RESULT_TEXT_HTML { get; set; }

        public string RESULT_TEXT_PLAIN { get; set; }

        public string RESULT_TEXT_RTF { get; set; }

        [MaxLength(1)]
        public byte[] RESULT_BINARY { get; set; }

        [StringLength(1)]
        public string RESULT_STATUS { get; set; }

        public int? ICD_ID { get; set; }

        public int? SEVERITY_ID { get; set; }

        public string HL7_TEXT { get; set; }

        [StringLength(1)]
        public string HL7_SEND { get; set; }

        public int? RELEASED_BY { get; set; }

        public DateTime? RELEASED_ON { get; set; }

        public int? FINALIZED_BY { get; set; }

        public DateTime? FINALIZED_ON { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? REASON { get; set; }

        [StringLength(5)]
        public string LAYOUT { get; set; }

        public string RESULT_TEXT_RTFtoHTML { get; set; }

        public int? SEVERITYLOG_ID { get; set; }

        public DateTime? FIRST_RELEASED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        public virtual RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTNOTE> RIS_EXAMRESULTNOTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PRSTUDIES> RIS_PRSTUDIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SEARCH_DTL> RIS_SEARCH_DTL { get; set; }
    }
}
