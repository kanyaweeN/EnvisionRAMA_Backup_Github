namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_NOTIFICATION
    {
        [Key]
        public int NOTIFICATION_ID { get; set; }

        [StringLength(30)]
        public string NOTIFICATION_UID { get; set; }

        public string NOTIFICATION_DESC { get; set; }

        [StringLength(1000)]
        public string SUBJECT { get; set; }

        public int? NOTIFICATION_EMP_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
