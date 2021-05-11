namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_BIREPORTS
    {
        [Key]
        public int BIREPORTS_ID { get; set; }

        [StringLength(30)]
        public string BIREPORTS_UID { get; set; }

        [StringLength(150)]
        public string BIREPORTS_NAME { get; set; }

        [StringLength(300)]
        public string BIREPORTS_TAG { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
