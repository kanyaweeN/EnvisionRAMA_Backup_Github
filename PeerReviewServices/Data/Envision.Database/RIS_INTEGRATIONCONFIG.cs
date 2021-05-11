namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_INTEGRATIONCONFIG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WORK_STATION_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string WORK_STATION_UID { get; set; }

        public int? SERVER_ID { get; set; }

        public bool? USE_SOCKET { get; set; }

        [StringLength(15)]
        public string RECEIVER_IP { get; set; }

        public int? RECEIVER_PORT { get; set; }

        [StringLength(15)]
        public string SENDER_IP { get; set; }

        [StringLength(50)]
        public string WEB_SERVICE_URL { get; set; }

        public bool? SEND_ADT { get; set; }

        public bool? SEND_ADT_RECONCILE { get; set; }

        public bool? SEND_ORM { get; set; }

        public bool? SEND_ORM_BIDIRECTIONAL { get; set; }

        public bool? SEND_ORM_MERGE { get; set; }

        public bool? SEND_ORU { get; set; }

        public bool? SEND_ORU_WHEN_OWNER { get; set; }

        public bool? SEND_PRELIM { get; set; }

        [StringLength(5)]
        public string RESULT_TYPE { get; set; }

        public bool? IS_ACTIVE { get; set; }
    }
}
