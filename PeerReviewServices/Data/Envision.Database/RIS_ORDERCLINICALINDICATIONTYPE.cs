namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_ORDERCLINICALINDICATIONTYPE
    {
        [Key]
        public int ORDER_CI_TYPE_ID { get; set; }

        public int? ORDER_ID { get; set; }

        public int? CI_TYPE_ID { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? SCHEDULE_ID { get; set; }

        [StringLength(1)]
        public string IS_FREE_TEXT { get; set; }

        [StringLength(1)]
        public string IS_REQONLINE { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
