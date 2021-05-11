namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SR_TEMPLATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SR_TEMPLATE()
        {
            SR_TEMPLATEANSWERSPART = new HashSet<SR_TEMPLATEANSWERSPART>();
            SR_TEMPLATEPART = new HashSet<SR_TEMPLATEPART>();
            SR_USERPREFERENCE = new HashSet<SR_USERPREFERENCE>();
        }

        [Key]
        public int TEMPLATE_ID { get; set; }

        [StringLength(100)]
        public string TEMPLATE_NAME { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? EXAM_ID { get; set; }

        public int? BP_ID { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        [StringLength(100)]
        public string RSNA_URL { get; set; }

        public int? LANG_ID { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual GBL_LANGUAGE GBL_LANGUAGE { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        public virtual RIS_BODYPART RIS_BODYPART { get; set; }

        public virtual RIS_EXAM RIS_EXAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATEANSWERSPART> SR_TEMPLATEANSWERSPART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATEPART> SR_TEMPLATEPART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_USERPREFERENCE> SR_USERPREFERENCE { get; set; }
    }
}
