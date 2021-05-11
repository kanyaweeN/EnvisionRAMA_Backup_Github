namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_QUICKTEXT
    {
        [Key]
        public int QUICKTEXT_ID { get; set; }

        [StringLength(300)]
        public string QUICK_TEXT { get; set; }

        [StringLength(150)]
        public string QUICK_TAG { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_GLOBAL { get; set; }
    }
}
