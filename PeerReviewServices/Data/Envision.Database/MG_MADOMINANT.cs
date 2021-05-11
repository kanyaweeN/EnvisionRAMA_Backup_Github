namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MG_MADOMINANT
    {
        [Key]
        public int DOMINATE_CYST_ID { get; set; }

        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public byte? MASS_NO { get; set; }

        public int? DIAMETER { get; set; }

        public int? CLOCK_LOCATION { get; set; }

        [StringLength(1)]
        public string SIDE { get; set; }

        [StringLength(1)]
        public string IS_DOMINANT_CYST { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }
    }
}
