namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULTTIME
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RAD_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte SL_NO { get; set; }

        public DateTime? START_ON { get; set; }

        [StringLength(1)]
        public string START_STATUS { get; set; }

        public DateTime? LAST_SAVED_ON { get; set; }

        [StringLength(1)]
        public string LAST_SAVED_STATUS { get; set; }

        public int ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
