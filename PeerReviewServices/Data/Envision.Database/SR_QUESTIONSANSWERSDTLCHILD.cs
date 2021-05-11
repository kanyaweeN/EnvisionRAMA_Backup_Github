namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SR_QUESTIONSANSWERSDTLCHILD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Q_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Q_ID_DTL { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Q_ID_DTL_CHD { get; set; }

        public int? Q_TYPE_ID { get; set; }

        [StringLength(100)]
        public string LABEL { get; set; }

        [StringLength(1000)]
        public string DEFAULT_VALUE { get; set; }

        [StringLength(1000)]
        public string ANSWER { get; set; }

        [StringLength(1)]
        public string IS_DEFAULT { get; set; }

        [StringLength(1)]
        public string IMG_POSITION { get; set; }

        [Column(TypeName = "image")]
        public byte[] IMG_DATA { get; set; }

        [StringLength(30)]
        public string PROP1 { get; set; }

        [StringLength(1)]
        public string QUESTION_SIDE { get; set; }

        [StringLength(30)]
        public string TEXT_SIZE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }

        public virtual SR_QUESTIONTYPE SR_QUESTIONTYPE { get; set; }
    }
}
