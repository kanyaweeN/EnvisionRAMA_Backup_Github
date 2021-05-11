namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MODALITYCONFIG
    {
        [Key]
        [Column(Order = 0)]
        public int MODALITY_CONFIG_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CLINIC_SESSION_ID { get; set; }

        public byte? WEEKDAY { get; set; }

        public int? MODALITY_ID { get; set; }

        public int? MODALITY_TYPE_TOTAL { get; set; }

        public int? MODALITY_TOTAL { get; set; }

        public byte? ADULT { get; set; }

        public byte? CHILD { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? ORG_ID { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        public virtual RIS_CLINICSESSION RIS_CLINICSESSION { get; set; }

        public virtual RIS_MODALITY RIS_MODALITY { get; set; }
    }
}
