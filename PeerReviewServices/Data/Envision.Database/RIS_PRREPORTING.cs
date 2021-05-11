namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_PRREPORTING
    {
        [Key]
        public int PR_REPORTING_ID { get; set; }

        public int? ASSIGNMENT_ID { get; set; }

        public string REPORT_TEXT_HTML { get; set; }

        public string REPORT_TEXT_PLAIN { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public string REPORT_STATUS { get; set; }

        public virtual RIS_PRASSIGNMENT RIS_PRASSIGNMENT { get; set; }
    }
}
