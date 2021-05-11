namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_SESSIONLOG
    {
        [Key]
        public int SESSIONLOG_ID { get; set; }

        public int? SESSION_ID { get; set; }

        [StringLength(50)]
        public string SESSION_GUID { get; set; }

        public int? SUBMENU_ID { get; set; }

        public DateTime? ACCESSED_ON { get; set; }

        public DateTime? ACCESSED_OUT { get; set; }

        [StringLength(300)]
        public string ACTIVITY_DESC { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual GBL_SESSION GBL_SESSION { get; set; }
    }
}
