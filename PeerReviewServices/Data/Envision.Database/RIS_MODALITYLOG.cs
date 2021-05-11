namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MODALITYLOG
    {
        [Key]
        public int LOG_ID { get; set; }

        public DateTime EFFECTIVE_DT { get; set; }

        [Required]
        [MaxLength(10)]
        public byte[] START_LSN { get; set; }

        [Required]
        [MaxLength(10)]
        public byte[] SEQVAL { get; set; }

        public int OPERATION { get; set; }

        [Required]
        [MaxLength(128)]
        public byte[] UPDATE_MASK { get; set; }

        public int MODALITY_ID { get; set; }

        [StringLength(50)]
        public string MODALITY_UID { get; set; }

        [StringLength(100)]
        public string MODALITY_NAME { get; set; }

        public int? MODALITY_TYPE { get; set; }

        [MaxLength(256)]
        public byte[] ALLPROPERTIES { get; set; }

        public int? UNIT_ID { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public DateTime? START_TIME { get; set; }

        public DateTime? END_TIME { get; set; }

        public byte? AVG_INV_TIME { get; set; }

        public int? ROOM_ID { get; set; }

        public short? CASE_PER_DAY { get; set; }

        [StringLength(1)]
        public string RESTRICT_LEVEL { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_VISIBLE { get; set; }

        [StringLength(1)]
        public string IS_DEFUALT { get; set; }

        public int? PAT_DEST_ID { get; set; }
    }
}
