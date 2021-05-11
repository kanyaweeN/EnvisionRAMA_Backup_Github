namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_CONFLICTEXAMGROUP
    {
        [Key]
        public int CONFLICTEXAM_ID { get; set; }

        public short? GROUP_NO { get; set; }

        public byte? MEMBER_COUNT { get; set; }

        public int EXAM_ID { get; set; }

        [StringLength(1)]
        public string IS_SEQUENTIAL { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        public int? ORG_ID { get; set; }

        [StringLength(30)]
        public string CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        [StringLength(30)]
        public string LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
