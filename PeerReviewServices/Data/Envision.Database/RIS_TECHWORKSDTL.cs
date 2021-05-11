namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_TECHWORKSDTL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte TAKE { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TECHNOLOGIST_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
