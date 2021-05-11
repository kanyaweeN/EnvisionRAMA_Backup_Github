namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_SCHEDULE_RESERVATION
    {
        [Key]
        public int SCHEDULE_ID { get; set; }

        public int REG_ID { get; set; }

        public DateTime SCHEDULE_DT { get; set; }

        public int? MODALITY_ID { get; set; }

        public string SCHEDULE_DATA { get; set; }

        public int? SESSION_ID { get; set; }

        public DateTime START_DATETIME { get; set; }

        public DateTime END_DATETIME { get; set; }

        public int? REF_UNIT { get; set; }

        public int? REF_DOC { get; set; }

        public string REF_DOC_INSTRUCTION { get; set; }

        public string CLINICAL_INSTRUCTION { get; set; }

        [StringLength(300)]
        public string REASON { get; set; }

        [StringLength(300)]
        public string DIAGNOSIS { get; set; }

        public int? PAT_STATUS { get; set; }

        public DateTime? LMP_DT { get; set; }

        public int? ICD_ID { get; set; }

        [StringLength(1)]
        public string SCHEDULE_STATUS { get; set; }

        public int? INSURANCE_TYPE_ID { get; set; }

        public int? CONFIRMED_BY { get; set; }

        public DateTime? CONFIRMED_ON { get; set; }

        [StringLength(1)]
        public string IS_BLOCKED { get; set; }

        [StringLength(300)]
        public string BLOCK_REASON { get; set; }

        [StringLength(500)]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string IS_REQONLINE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public bool? ALLDAY { get; set; }

        public int? EVENTTYPE { get; set; }

        public string RECURRENCEINFO { get; set; }

        public int? LABEL { get; set; }

        [StringLength(50)]
        public string LOCATION { get; set; }

        public int? STATUS { get; set; }

        [StringLength(1)]
        public string IS_BUSY { get; set; }

        public DateTime? REQUESTED_SCHEDULE_DT { get; set; }

        public int? SCHEDULE_EXCEED_BY { get; set; }

        public int? WL_CONFIRMED_BY { get; set; }

        public DateTime? WL_CONFIRMED_ON { get; set; }

        public int? ENC_ID { get; set; }

        [StringLength(10)]
        public string ENC_TYPE { get; set; }

        [StringLength(30)]
        public string ENC_CLINIC { get; set; }

        [Required]
        [StringLength(1)]
        public string NOTIFY_ADMIN_WL { get; set; }

        [StringLength(1)]
        public string HIS_SYNC { get; set; }

        [StringLength(30)]
        public string ADMISSION_NO { get; set; }

        public int? PENDING_BY { get; set; }

        public DateTime? PENDING_ON { get; set; }

        [StringLength(1)]
        public string IS_COMMENTS { get; set; }

        public int? BUSY_BY { get; set; }

        public DateTime? BUSY_ON { get; set; }

        [StringLength(3000)]
        public string PENDING_COMMENTS { get; set; }

        [StringLength(1000)]
        public string TEXT_SHOW { get; set; }

        [StringLength(1)]
        public string IS_PRINT_CONSENTFORM { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HIS_ICD HIS_ICD { get; set; }

        public virtual HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        public virtual HR_EMP HR_EMP2 { get; set; }

        public virtual HR_EMP HR_EMP3 { get; set; }

        public virtual HR_UNIT HR_UNIT { get; set; }

        public virtual RIS_MODALITY RIS_MODALITY { get; set; }
    }
}
