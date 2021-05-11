namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SR_QUESTIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SR_QUESTIONS()
        {
            SR_QUESTIONSDTL = new HashSet<SR_QUESTIONSDTL>();
        }

        [Key]
        public int Q_ID { get; set; }

        public int? Q_TYPE_ID { get; set; }

        public int? PART_ID { get; set; }

        [StringLength(300)]
        public string QUESTION_TEXT { get; set; }

        [StringLength(1)]
        public string QUESTION_SIDE { get; set; }

        public int? SPACE_BEGIN { get; set; }

        [StringLength(1)]
        public string IS_BOLD { get; set; }

        [StringLength(1)]
        public string IS_ITALIC { get; set; }

        [StringLength(1)]
        public string IS_UNDERLINE { get; set; }

        [StringLength(100)]
        public string LABEL { get; set; }

        [StringLength(300)]
        public string DEFAULT_VALUE { get; set; }

        [StringLength(1)]
        public string APPEND_NEXT { get; set; }

        [StringLength(1)]
        public string IS_DEFAULT { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        public virtual SR_QUESTIONTYPE SR_QUESTIONTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSDTL> SR_QUESTIONSDTL { get; set; }
    }
}
