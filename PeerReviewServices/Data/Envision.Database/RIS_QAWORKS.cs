namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_QAWORKS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte SL { get; set; }

        public int? REASON_ID { get; set; }

        [StringLength(1)]
        public string QA_RESULT { get; set; }

        [StringLength(250)]
        public string COMMENTS { get; set; }

        public DateTime? START_TIME { get; set; }

        public DateTime? END_TIME { get; set; }

        public int? NO_OF_IMAGES_PRINT { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_QAWORKS RIS_QAWORKS1 { get; set; }

        public virtual RIS_QAWORKS RIS_QAWORKS2 { get; set; }
    }
}
