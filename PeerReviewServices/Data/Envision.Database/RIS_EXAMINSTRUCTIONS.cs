namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMINSTRUCTIONS
    {
        [Key]
        public int INS_ID { get; set; }

        public int? EXAM_TYPE_ID { get; set; }

        public int? EXAM_ID { get; set; }

        [StringLength(30)]
        public string INS_UID { get; set; }

        [StringLength(4000)]
        public string INS_TEXT { get; set; }

        [StringLength(1)]
        public string INHERIT_GROUP { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(4000)]
        public string INS_NAV { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_EXAM RIS_EXAM { get; set; }

        public virtual RIS_EXAMTYPE RIS_EXAMTYPE { get; set; }
    }
}
