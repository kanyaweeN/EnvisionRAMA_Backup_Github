namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MESSAGE
    {
        [Key]
        public int MSG_ID { get; set; }

        public int SENDER_ID { get; set; }

        [StringLength(3000)]
        public string MSG_TEXT { get; set; }

        [StringLength(50)]
        public string MSG_STATUS { get; set; }

        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }
    }
}
