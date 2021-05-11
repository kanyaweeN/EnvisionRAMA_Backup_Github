namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_NURSESDATADTL
    {
        public int NURSE_DATA_UK_ID { get; set; }

        [Key]
        public int DETAIL_DATA_ID { get; set; }

        public DateTime? DETAIL_TIME { get; set; }

        [StringLength(30)]
        public string HR_MIN { get; set; }

        [StringLength(30)]
        public string RR_MIN { get; set; }

        [StringLength(30)]
        public string BP_MMHG { get; set; }

        [StringLength(30)]
        public string O2_SAT { get; set; }

        [StringLength(30)]
        public string CONCSIOUS { get; set; }

        [StringLength(100)]
        public string PROGRESS_NOTE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual RIS_NURSESDATA RIS_NURSESDATA { get; set; }
    }
}
