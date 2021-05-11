namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_GROUP
    {
        [Key]
        public int GROUP_ID { get; set; }

        [StringLength(30)]
        public string GROUP_UID { get; set; }

        [StringLength(50)]
        public string GROUP_NAME { get; set; }

        [StringLength(50)]
        public string GROUP_USER_NAME { get; set; }

        [StringLength(50)]
        public string GROUP_PASS { get; set; }

        [StringLength(5)]
        public string GROUP_TYPE { get; set; }

        public int? GROUP_HEAD { get; set; }

        [StringLength(50)]
        public string GROUP_HEAD_NAME { get; set; }

        public int? GROUP_CONTACT_NO { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
