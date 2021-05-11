namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULTRADS
    {
        [Required]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int RAD_ID { get; set; }

        public bool? CAN_PRELIM { get; set; }

        public bool? CAN_FINALIZE { get; set; }

        public byte? SL_NO { get; set; }

        public int ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [Key]
        public int EXAMRESULTRADS_ID { get; set; }

        public int? JOB_TITLE_ID { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
