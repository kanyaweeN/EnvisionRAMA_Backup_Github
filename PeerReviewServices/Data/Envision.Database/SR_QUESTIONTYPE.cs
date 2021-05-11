namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SR_QUESTIONTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SR_QUESTIONTYPE()
        {
            SR_QUESTIONS = new HashSet<SR_QUESTIONS>();
            SR_QUESTIONSANSWERS = new HashSet<SR_QUESTIONSANSWERS>();
            SR_QUESTIONSANSWERSDTLCHILD = new HashSet<SR_QUESTIONSANSWERSDTLCHILD>();
            SR_QUESTIONSDTLCHILD = new HashSet<SR_QUESTIONSDTLCHILD>();
        }

        [Key]
        public int Q_TYPE_ID { get; set; }

        [StringLength(50)]
        public string Q_TYPE_NAME { get; set; }

        [StringLength(200)]
        public string Q_TYPE_DESC { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONS> SR_QUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERS> SR_QUESTIONSANSWERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERSDTLCHILD> SR_QUESTIONSANSWERSDTLCHILD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSDTLCHILD> SR_QUESTIONSDTLCHILD { get; set; }
    }
}
