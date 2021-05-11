namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_PRALGORITHM
    {
        [Key]
        public int PR_ALGORITHM_ID { get; set; }

        [StringLength(100)]
        public string ALGORITHM_TEXT { get; set; }

        [StringLength(500)]
        public string LOGIC { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(50)]
        public string PERIOD { get; set; }

        public int? PERCENTAGE_PER_SUBSPECIALTY { get; set; }

        public int? MAX_PER_SUBSPECIALTY { get; set; }

        public int? PERCENTAGE_PER_RAD { get; set; }

        public int? MAX_CASE_PER_MONTH { get; set; }

        public int? MAX_ASSIGNMENT_PER_RAD { get; set; }
    }
}
