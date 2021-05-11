namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_RESULTSTATUSCHANGELOG
    {
        [Key]
        public int STATUS_CHNAGE_ID { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        public int? ORDER_ID { get; set; }

        [StringLength(100)]
        public string ACCESSION_NO { get; set; }

        public int? EXAM_ID { get; set; }

        [StringLength(1)]
        public string ORGINAL_STATUS { get; set; }

        [StringLength(1)]
        public string CHANGED_STATUS { get; set; }

        public int? REQUEST_BY { get; set; }

        [StringLength(100)]
        public string CHNAGE_PC { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
