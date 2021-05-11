namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_CLINICALINDICATIONCHECKUPLIST
    {
        [Key]
        public int CHECKLIST_ID { get; set; }

        [StringLength(30)]
        public string CHECKLIST_UID { get; set; }

        [StringLength(1000)]
        public string CHECKLIST_DESC { get; set; }

        public int? ORG_ID { get; set; }

        public int? CRAETED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
