namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_PATSTATUS
    {
        [Key]
        public int STATUS_ID { get; set; }

        [StringLength(30)]
        public string STATUS_UID { get; set; }

        [StringLength(100)]
        public string STATUS_TEXT { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_DEFAULT { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual GBL_ENV GBL_ENV1 { get; set; }
    }
}
