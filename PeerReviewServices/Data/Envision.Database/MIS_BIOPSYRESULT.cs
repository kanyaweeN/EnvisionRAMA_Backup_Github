namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MIS_BIOPSYRESULT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public DateTime? RESULT_DT { get; set; }

        public int? RADIOLOGIST_ID { get; set; }

        [StringLength(3)]
        public string LOC_NO_R { get; set; }

        [StringLength(3)]
        public string LOC_NO_L { get; set; }

        [StringLength(1)]
        public string TISSUE_TYPE { get; set; }

        [StringLength(1)]
        public string DEPTH_TYPE_R { get; set; }

        [StringLength(1)]
        public string DEPTH_TYPE_L { get; set; }

        [StringLength(20)]
        public string WIDTH { get; set; }

        [StringLength(20)]
        public string LENGTH { get; set; }

        [StringLength(20)]
        public string DEPTH { get; set; }

        [StringLength(1)]
        public string PROCEDURE_TYPE { get; set; }

        public byte? NO_OF_CORE { get; set; }

        public byte? CALCIUM_PCS { get; set; }

        [StringLength(1)]
        public string IS_SATISFACTORY { get; set; }

        [StringLength(1)]
        public string IS_SURGERY { get; set; }

        [StringLength(450)]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string IS_PALPABLE { get; set; }

        public int? LESION_TYPE_ID { get; set; }

        public int? ASESSMENT_TYPE_ID { get; set; }

        public int? TECHNIQUE_TYPE_ID { get; set; }

        [StringLength(500)]
        public string LAB_DATA { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte BIOPSY_RESULT_ID { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual MIS_ASESSMENTTYPE MIS_ASESSMENTTYPE { get; set; }

        public virtual MIS_LESIONTYPE MIS_LESIONTYPE { get; set; }

        public virtual MIS_TECHNIQUETYPE MIS_TECHNIQUETYPE { get; set; }
    }
}
