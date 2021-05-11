namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXTERNALHL7TRANSLOG
    {
        [Key]
        public long TRANSLOG_ID { get; set; }

        public DateTime? REQUEST_TIMESTAMP { get; set; }

        [StringLength(15)]
        public string REQUESTING_IP { get; set; }

        [StringLength(100)]
        public string REQUESTING_USER { get; set; }

        [StringLength(1)]
        public string REQUEST_TYPE { get; set; }

        [StringLength(400)]
        public string PATIENT_DEMOGRAPHIC { get; set; }

        [StringLength(400)]
        public string EXAM_DETAILS { get; set; }

        public string RESULT_TEXT { get; set; }

        [StringLength(15)]
        public string PACS_IP { get; set; }

        [StringLength(10)]
        public string PACS_PORT { get; set; }

        public string GENERATED_HL7 { get; set; }

        public DateTime? SENDING_TIMESTAMP { get; set; }

        [StringLength(1)]
        public string IS_SUCCESSFUL { get; set; }

        [StringLength(30)]
        public string ACK_TYPE { get; set; }

        [StringLength(30)]
        public string ACK_MSG { get; set; }

        [StringLength(15)]
        public string ACK_SENDING_IP { get; set; }

        public DateTime? ACK_TIMESTAMP { get; set; }
    }
}
