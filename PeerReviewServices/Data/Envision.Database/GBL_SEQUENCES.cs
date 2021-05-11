namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_SEQUENCES
    {
        [Key]
        [StringLength(255)]
        public string Seq_Name { get; set; }

        public int Seed { get; set; }

        public int Incr { get; set; }

        public int? Curr_val { get; set; }

        public DateTime? DateStart { get; set; }

        public int? ORG_ID { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
