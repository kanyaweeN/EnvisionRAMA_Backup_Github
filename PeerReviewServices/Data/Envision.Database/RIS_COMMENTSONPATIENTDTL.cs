namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_COMMENTSONPATIENTDTL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int COMMENT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SL_NO { get; set; }

        public int? EXAM_ID { get; set; }

        public int? COMMENT_TO { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(1)]
        public string IS_TRASHED { get; set; }

        [StringLength(1)]
        public string RECIPIENT_TYPE { get; set; }

        public DateTime? ACK_ON { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual RIS_COMMENTSONPATIENT RIS_COMMENTSONPATIENT { get; set; }

        public virtual RIS_EXAM RIS_EXAM { get; set; }
    }
}
