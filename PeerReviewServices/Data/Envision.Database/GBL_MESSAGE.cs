namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_MESSAGE
    {
        [Key]
        public int MSG_ID { get; set; }

        public DateTime? MSG_DT { get; set; }

        public int? MSG_FROM { get; set; }

        [StringLength(500)]
        public string MSG_SUBJECT { get; set; }

        public string MSG_BODY { get; set; }

        [StringLength(1)]
        public string MSG_STATUS { get; set; }

        [StringLength(1)]
        public string MSG_PRIORITY { get; set; }

        [StringLength(1)]
        public string IS_STARRED { get; set; }

        [StringLength(1)]
        public string IS_FORCED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
