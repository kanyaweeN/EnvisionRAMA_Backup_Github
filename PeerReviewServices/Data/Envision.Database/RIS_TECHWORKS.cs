namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_TECHWORKS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ACCESSION_ON { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte TAKE { get; set; }

        public DateTime? START_TIME { get; set; }

        public DateTime? END_TIME { get; set; }

        [StringLength(200)]
        public string EXPOSURE_TECHNIQUE { get; set; }

        [StringLength(200)]
        public string PROTOCOL { get; set; }

        [StringLength(20)]
        public string KV { get; set; }

        [StringLength(20)]
        public string mA { get; set; }

        [StringLength(20)]
        public string SEC { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [StringLength(200)]
        public string COMMENTS { get; set; }

        public int? NO_OF_IMAGES { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public int? PERFORMANCED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_TECHWORKS RIS_TECHWORKS1 { get; set; }

        public virtual RIS_TECHWORKS RIS_TECHWORKS2 { get; set; }
    }
}
