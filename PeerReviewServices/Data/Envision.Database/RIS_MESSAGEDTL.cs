namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MESSAGEDTL
    {
        [Key]
        public int MSGDTL_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int READER_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }
    }
}
