namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MERGELOG
    {
        public int id { get; set; }

        [StringLength(50)]
        public string ACCESSION_NO { get; set; }

        [StringLength(50)]
        public string MERGE { get; set; }

        [StringLength(50)]
        public string MERGE_WITH { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public int? ORG_ID { get; set; }
    }
}
