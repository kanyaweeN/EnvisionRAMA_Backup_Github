namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MODALITYLOGCAPTURE
    {
        [Key]
        public int CAPTURE_ID { get; set; }

        public DateTime START_TIME { get; set; }

        [Required]
        [MaxLength(10)]
        public byte[] MIN_LSN { get; set; }

        [Required]
        [MaxLength(10)]
        public byte[] MAX_LSN { get; set; }

        public DateTime END_TIME { get; set; }

        public int INSERT_COUNT { get; set; }

        public int UPDATE_COUNT { get; set; }

        public int DELETE_COUNT { get; set; }

        public int STATUS_CODE { get; set; }
    }
}
