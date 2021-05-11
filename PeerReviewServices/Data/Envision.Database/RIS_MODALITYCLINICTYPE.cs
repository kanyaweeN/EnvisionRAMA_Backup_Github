namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MODALITYCLINICTYPE
    {
        [Key]
        public int MODALITY_CLINICTYPE_ID { get; set; }

        public int? CLINIC_TYPE_ID { get; set; }

        public int? MODALITY_ID { get; set; }

        public DateTime? START_DATETIME { get; set; }

        public DateTime? END_DATETIME { get; set; }

        public int? MAX_APP { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
