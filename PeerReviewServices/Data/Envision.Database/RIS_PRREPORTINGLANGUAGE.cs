namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_PRREPORTINGLANGUAGE
    {
        [Key]
        public int REPORT_LANG_ID { get; set; }

        [StringLength(500)]
        public string REPORT_LANG_LABEL { get; set; }

        [StringLength(30)]
        public string REPORT_LANG_VALUE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string SEND_MESSAGE { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
