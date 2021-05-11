namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_AUTHORIZATION
    {
        [Key]
        public int AUTH_ID { get; set; }

        public DateTime? AUTH_DT { get; set; }

        public int? PR_ID { get; set; }

        public int? ITEM_ID { get; set; }

        public int? EMP_ID { get; set; }

        public int? QTY { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual INV_REQUISITION INV_REQUISITION { get; set; }
    }
}
