namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_ENVISIONONLINEPARAMETERSLOG
    {
        [Key]
        public int LOG_ID { get; set; }

        [StringLength(50)]
        public string IP { get; set; }

        public DateTime? CLIENT_ACCESS_DATETIME { get; set; }

        [StringLength(300)]
        public string URL { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        [StringLength(30)]
        public string USER_NAME { get; set; }

        [StringLength(30)]
        public string CLINIC { get; set; }

        [StringLength(30)]
        public string UNIT_UID { get; set; }

        [StringLength(30)]
        public string INSURANCE_TYPE_UID { get; set; }

        [StringLength(1)]
        public string ROLE { get; set; }

        [StringLength(10)]
        public string ENC_TYPE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
