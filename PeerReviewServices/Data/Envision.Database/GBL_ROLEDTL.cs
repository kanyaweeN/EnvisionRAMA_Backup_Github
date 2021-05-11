namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_ROLEDTL
    {
        [Key]
        public int ROLEDTL_ID { get; set; }

        [StringLength(30)]
        public string ROLEDTL_UID { get; set; }

        public int? ROLE_ID { get; set; }

        public int? SUBMENU_ID { get; set; }

        [StringLength(1)]
        public string CAN_VIEW { get; set; }

        [StringLength(1)]
        public string CAN_MODIFY { get; set; }

        [StringLength(1)]
        public string CAN_REMOVE { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(1)]
        public string CAN_CREATE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
