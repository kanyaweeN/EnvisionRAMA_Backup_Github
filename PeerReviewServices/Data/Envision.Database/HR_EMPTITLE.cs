namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_EMPTITLE
    {
        [Key]
        public int TITLE_ID { get; set; }

        [StringLength(100)]
        public string TITLE_DESC { get; set; }

        [StringLength(100)]
        public string TITLE_DESC_ENG { get; set; }

        public int? SL_NO { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
