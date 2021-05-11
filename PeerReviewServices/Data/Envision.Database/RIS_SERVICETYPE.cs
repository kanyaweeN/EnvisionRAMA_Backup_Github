namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_SERVICETYPE
    {
        [Key]
        public int SERVICE_TYPE_ID { get; set; }

        [StringLength(50)]
        public string SERVICE_TYPE_UID { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [StringLength(500)]
        public string SERVICE_TYPE_TEXT { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
