namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_TECHNOTES
    {
        [Key]
        [Column(Order = 0)]
        public int TECHNOTE_ID { get; set; }

        public string TECHNOTE_DESC { get; set; }

        [StringLength(1)]
        public string PRIORITY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
