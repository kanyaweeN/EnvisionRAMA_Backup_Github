namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_SESSIONAPPCOUNT
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MODALITY_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SESSION_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte WEEKDAY { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte MAX_APP { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime APP_DATE { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int APP_COUNT { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public byte? MAX_ONLINE_APP { get; set; }

        public int? ONLINE_APP_COUNT { get; set; }

        public byte? MAX_IPD_APP { get; set; }

        [StringLength(1)]
        public string IS_BLOCKED { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_CLINICSESSION RIS_CLINICSESSION { get; set; }

        public virtual RIS_MODALITY RIS_MODALITY { get; set; }
    }
}
