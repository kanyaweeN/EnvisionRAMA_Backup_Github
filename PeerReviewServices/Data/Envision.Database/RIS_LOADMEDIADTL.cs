namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_LOADMEDIADTL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LOAD_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EXAM_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public DateTime? EXAM_DT { get; set; }

        public byte QTY { get; set; }

        [StringLength(1000)]
        public string HL7_TEXT { get; set; }

        [StringLength(1)]
        public string HL7_SENT { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual RIS_EXAM RIS_EXAM { get; set; }

        public virtual RIS_LOADMEDIA RIS_LOADMEDIA { get; set; }
    }
}
