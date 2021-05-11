namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_ERRORLOGS
    {
        [Key]
        public int ERROR_ID { get; set; }

        [StringLength(50)]
        public string USER_LOGIN { get; set; }

        [StringLength(50)]
        public string USER_HOST_ADDRESS { get; set; }

        public string ERROR_MESSAGE { get; set; }

        public string ERROR_SOURCE { get; set; }

        [StringLength(1000)]
        public string PIC_PATH { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }
    }
}
