namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_EVALUATION
    {
        [Key]
        [Column(Order = 0)]
        public int EVALUATION_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ASSIGNMENT_ID { get; set; }

        [StringLength(1)]
        public string REPORT_TYPE { get; set; }

        public string REPORT_TEXT { get; set; }

        public DateTime? REPORTING_TIMESTAMP { get; set; }

        public int? EVALUATED_BY { get; set; }

        public DateTime? EVALUATED_ON { get; set; }

        public int? GRADE_ID { get; set; }

        [StringLength(1)]
        public string IS_CLINICALLY_SIGNIFICANT { get; set; }

        [StringLength(300)]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? LANGUAGE_OF_REPORT { get; set; }

        [StringLength(300)]
        public string LANGUAGE_OF_REPORT_COMMENTS { get; set; }

        public int? SEVERITY_ID { get; set; }

        public virtual AC_REPORTINGLANGUAGE AC_REPORTINGLANGUAGE { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
