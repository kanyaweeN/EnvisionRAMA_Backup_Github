namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMINSTRUCTIONCLINICSESSION
    {
        [Key]
        public int INS_ID { get; set; }

        public int EXAM_ID { get; set; }

        public int SESSION_ID { get; set; }

        [StringLength(30)]
        public string INS_UID { get; set; }

        [StringLength(4000)]
        public string INS_TEXT { get; set; }

        [StringLength(4000)]
        public string INS_TEXT_KID { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
