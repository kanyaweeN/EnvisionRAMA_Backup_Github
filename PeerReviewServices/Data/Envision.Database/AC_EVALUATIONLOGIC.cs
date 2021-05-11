namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_EVALUATIONLOGIC
    {
        [Key]
        public int EVALUATION_LOGIC_ID { get; set; }

        public int EMP_ID { get; set; }

        [StringLength(1)]
        public string START_WITH_EVALUATION { get; set; }

        public byte? NO_OF_CASES { get; set; }

        [StringLength(1)]
        public string IS_RANDOM { get; set; }

        [StringLength(1)]
        public string EVALUATE_AFTER { get; set; }

        [StringLength(1)]
        public string EVALUATE_ALL { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
