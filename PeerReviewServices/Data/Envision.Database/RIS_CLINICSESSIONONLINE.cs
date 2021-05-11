namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_CLINICSESSIONONLINE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SESSION_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MODALITY_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte WEEKDAY { get; set; }

        public int? CLINIC_TYPE_ID { get; set; }

        public DateTime? START_TIME { get; set; }

        public DateTime? END_TIME { get; set; }

        public int? ORG_ID { get; set; }

        public byte? SL_NO { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string IS_CHILDREN { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_CLINICTYPE RIS_CLINICTYPE { get; set; }
    }
}
