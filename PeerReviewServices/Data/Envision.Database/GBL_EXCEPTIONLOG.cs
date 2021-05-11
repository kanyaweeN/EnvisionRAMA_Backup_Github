namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_EXCEPTIONLOG
    {
        [Key]
        public int EXC_ID { get; set; }

        [StringLength(30)]
        public string EXC_UID { get; set; }

        [StringLength(1)]
        public string EXC_TYPE { get; set; }

        [StringLength(300)]
        public string EXC_TEXT { get; set; }

        [StringLength(30)]
        public string EXC_IP { get; set; }

        [StringLength(100)]
        public string EXC_PC_NAME { get; set; }

        public int? CURRENT_FORM_ID { get; set; }

        public int? CURRENT_LANG_ID { get; set; }

        public int? CONNECTED_EMP_ID { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
