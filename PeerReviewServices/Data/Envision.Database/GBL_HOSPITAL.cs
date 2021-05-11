namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_HOSPITAL
    {
        [Key]
        public int HOS_ID { get; set; }

        [StringLength(30)]
        public string HOS_UID { get; set; }

        [StringLength(500)]
        public string HOS_NAME { get; set; }

        [StringLength(100)]
        public string HOS_NAME_ALIAS { get; set; }

        [StringLength(50)]
        public string PHONE_NO { get; set; }

        [StringLength(500)]
        public string DESCR { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? ORG_ID { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
