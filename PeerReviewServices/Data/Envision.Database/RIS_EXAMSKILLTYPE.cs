namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMSKILLTYPE
    {
        [Key]
        public int EXAM_SKILLTYPE_ID { get; set; }

        [StringLength(30)]
        public string EXAM_SKILLTYPE_UID { get; set; }

        [StringLength(300)]
        public string EXAM_SKILLTYPE_NAME { get; set; }

        public int? ORG_ID { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
