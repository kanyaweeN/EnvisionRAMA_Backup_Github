namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_STUDYLIBRARY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RADIOLOGIST_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public bool? IS_FAVORITE { get; set; }

        public bool? IS_TEACHING { get; set; }

        public bool? IS_RESEARCH { get; set; }

        public bool? IS_OTHERS { get; set; }

        [StringLength(500)]
        public string TAGS { get; set; }

        [StringLength(1)]
        public string DIFFICULTY_LEVEL { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(500)]
        public string SUMMARY_ACR { get; set; }

        [StringLength(500)]
        public string SUMMARY_BODYPART { get; set; }

        [StringLength(500)]
        public string SUMMARY_CPT { get; set; }

        [StringLength(500)]
        public string SUMMARY_ICD { get; set; }

        [StringLength(500)]
        public string SUMMARY_SHARED_WITH { get; set; }

        [StringLength(1)]
        public string SHARE_TYPE { get; set; }
    }
}
