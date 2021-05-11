namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_PRODUCT
    {
        [Key]
        public int PROD_ID { get; set; }

        [StringLength(30)]
        public string PROD_UID { get; set; }

        [StringLength(200)]
        public string PROD_NAME { get; set; }

        [StringLength(2000)]
        public string PROD_DESCR { get; set; }

        [StringLength(50)]
        public string PROD_VERSION { get; set; }

        public DateTime? RELEASE_DT { get; set; }

        [StringLength(1)]
        public string PROD_TYPE { get; set; }

        [StringLength(100)]
        public string LICENSED_TO { get; set; }

        [StringLength(1)]
        public string LICENSE_TYPE { get; set; }

        public DateTime? VALID_UNTIL { get; set; }

        [StringLength(1)]
        public string FORCE_LICENSE { get; set; }

        [StringLength(1000)]
        public string COPY_RIGHT { get; set; }

        public int? ORG_ID { get; set; }

        [StringLength(30)]
        public string CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        [StringLength(30)]
        public string LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
