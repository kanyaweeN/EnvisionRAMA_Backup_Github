namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ONL_HISLINKLOG
    {
        [Key]
        public int LINK_ID { get; set; }

        public string HIS_URL { get; set; }

        [StringLength(50)]
        public string HN { get; set; }

        [StringLength(50)]
        public string USER_NAME { get; set; }

        [StringLength(500)]
        public string UNIT { get; set; }

        [StringLength(500)]
        public string CLINIC { get; set; }

        [StringLength(500)]
        public string INSR { get; set; }

        [StringLength(50)]
        public string ROLE { get; set; }

        [StringLength(500)]
        public string ENC { get; set; }

        [StringLength(50)]
        public string FORM { get; set; }

        public DateTime? CREATED_ON { get; set; }

        [StringLength(100)]
        public string LOG_DESC { get; set; }

        [StringLength(100)]
        public string BROWSER_TYPE { get; set; }

        [StringLength(100)]
        public string USER_HOST_ADDRESS { get; set; }

        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [StringLength(30)]
        public string ZEUS_NO { get; set; }
    }
}
