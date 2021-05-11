namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MG_PATIENTHISTORYCOMPARISON
    {
        [Key]
        public int COMPARISON_ID { get; set; }

        public int REG_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string COMPARED_TYPE { get; set; }

        public int COMPARED_BY { get; set; }

        public DateTime COMPARED_ON { get; set; }

        [StringLength(30)]
        public string COMPARING_EXAM { get; set; }

        [StringLength(30)]
        public string COMPARED_WITH { get; set; }

        [StringLength(200)]
        public string COMPARED_TEXT { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HIS_REGISTRATION HIS_REGISTRATION { get; set; }
    }
}
