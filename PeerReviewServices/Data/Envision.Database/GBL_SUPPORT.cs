namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_SUPPORT
    {
        [Key]
        public int SUPPORT_ID { get; set; }

        [StringLength(30)]
        public string SUPPORT_UID { get; set; }

        public DateTime? REQUEST_DT { get; set; }

        public int? USER_ID { get; set; }

        [StringLength(15)]
        public string USER_IP { get; set; }

        public int? CURRENT_OBJECT { get; set; }

        [StringLength(100)]
        public string SUBJECT { get; set; }

        [StringLength(500)]
        public string MESSAGE { get; set; }

        [StringLength(1)]
        public string PRIORITY { get; set; }

        [Column(TypeName = "image")]
        public byte[] ATTACHMENT { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [StringLength(300)]
        public string COMMENTS { get; set; }

        public int? REPONSE_BY { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual GBL_SUBMENU GBL_SUBMENU { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
