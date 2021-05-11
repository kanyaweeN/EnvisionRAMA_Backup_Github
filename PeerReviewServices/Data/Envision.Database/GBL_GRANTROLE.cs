namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_GRANTROLE
    {
        [Key]
        public int GRANTROLE_ID { get; set; }

        public int ROLE_ID { get; set; }

        public int EMP_ID { get; set; }

        public int? CAN_GRANT { get; set; }

        public int? GRANTOR { get; set; }

        public DateTime? GRANT_DT { get; set; }

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

        public virtual GBL_ROLE GBL_ROLE { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
