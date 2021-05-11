namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_FINALIZEPRIVILEGE
    {
        [Key]
        public int FINALIZEPRIVILEGE_ID { get; set; }

        public int? EMP_ID { get; set; }

        public int? EXAM_ID { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? ORG_ID { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }
    }
}
