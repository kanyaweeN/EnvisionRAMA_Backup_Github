namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_BISETTINGS
    {
        [Key]
        public int BISETTINGS_ID { get; set; }

        public int EMP_ID { get; set; }

        [StringLength(150)]
        public string BI_NAME { get; set; }

        [StringLength(300)]
        public string BI_DESC { get; set; }

        [StringLength(300)]
        public string BI_TAG { get; set; }

        [StringLength(1)]
        public string IS_GLOBAL { get; set; }

        public string BI_FIELD_ORDER { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? BIREPORT_ID { get; set; }
    }
}
