namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULTTEMPLATE
    {
        [Key]
        public int TEMPLATE_ID { get; set; }

        [StringLength(30)]
        public string TEMPLATE_UID { get; set; }

        public int EXAM_ID { get; set; }

        [StringLength(100)]
        public string TEMPLATE_NAME { get; set; }

        [StringLength(100)]
        public string TEMPLATE_HEADER { get; set; }

        public string TEMPLATE_TEXT { get; set; }

        public string TEMPLATE_TEXT_RTF { get; set; }

        public byte[] TEMPLATE_BINARY { get; set; }

        [StringLength(1)]
        public string TEMPLATE_TYPE { get; set; }

        public int? SEVERITY_ID { get; set; }

        [StringLength(1)]
        public string AUTO_APPLY { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_EXAM RIS_EXAM { get; set; }

        public virtual RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY { get; set; }
    }
}
