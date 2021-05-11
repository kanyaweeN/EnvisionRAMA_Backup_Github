namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_PREXAMMAPPING
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RIS_EXAMMAPPING_ID { get; set; }

        public int? EXAM_ID { get; set; }

        public int? SUB_SPECIALTY_ID { get; set; }

        [StringLength(1)]
        public string ALLOW_PEER_REVIEW { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual RIS_PRSUBSPECIALTY RIS_PRSUBSPECIALTY { get; set; }
    }
}
