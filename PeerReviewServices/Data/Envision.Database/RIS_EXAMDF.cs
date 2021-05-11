namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMDF
    {
        [Key]
        public int EXAM_DF_ID { get; set; }

        public int? EXAM_ID { get; set; }

        public byte? SL_NO { get; set; }

        [StringLength(1)]
        public string JOB_TYPE { get; set; }

        [StringLength(1)]
        public string CLINIC_TYPE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DF { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_UPDATED_BY { get; set; }

        public DateTime? LAST_UPDATED_ON { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        public virtual RIS_EXAM RIS_EXAM { get; set; }
    }
}
