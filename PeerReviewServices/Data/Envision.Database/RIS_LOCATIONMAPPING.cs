namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_LOCATIONMAPPING
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UNIT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PAT_DEST_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual HR_UNIT HR_UNIT { get; set; }

        public virtual RIS_PATIENTDESTINATION RIS_PATIENTDESTINATION { get; set; }
    }
}
