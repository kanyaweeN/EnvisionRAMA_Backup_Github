namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MODALITY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_MODALITY()
        {
            RIS_MODALITYAETITLE = new HashSet<RIS_MODALITYAETITLE>();
            RIS_MODALITYCONFIG = new HashSet<RIS_MODALITYCONFIG>();
            RIS_MODALITYEXAM_ONL = new HashSet<RIS_MODALITYEXAM_ONL>();
            RIS_MODALITYEXAM = new HashSet<RIS_MODALITYEXAM>();
            RIS_MODALITYUNIT = new HashSet<RIS_MODALITYUNIT>();
            RIS_ORDERDTL = new HashSet<RIS_ORDERDTL>();
            RIS_SCHEDULE_RESERVATION = new HashSet<RIS_SCHEDULE_RESERVATION>();
            RIS_SCHEDULEDEFAULTMODALITY = new HashSet<RIS_SCHEDULEDEFAULTMODALITY>();
            RIS_SCHEDULE = new HashSet<RIS_SCHEDULE>();
            RIS_SESSIONAPPCOUNT = new HashSet<RIS_SESSIONAPPCOUNT>();
            RIS_SESSIONMAXAPP = new HashSet<RIS_SESSIONMAXAPP>();
        }

        [Key]
        public int MODALITY_ID { get; set; }

        [StringLength(50)]
        public string MODALITY_UID { get; set; }

        [StringLength(100)]
        public string MODALITY_NAME { get; set; }

        public int? MODALITY_TYPE { get; set; }

        [MaxLength(256)]
        public byte[] ALLPROPERTIES { get; set; }

        public int? UNIT_ID { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public DateTime? START_TIME { get; set; }

        public DateTime? END_TIME { get; set; }

        public byte? AVG_INV_TIME { get; set; }

        public int? ROOM_ID { get; set; }

        public short? CASE_PER_DAY { get; set; }

        [StringLength(1)]
        public string RESTRICT_LEVEL { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_VISIBLE { get; set; }

        [StringLength(1)]
        public string IS_DEFUALT { get; set; }

        public int? PAT_DEST_ID { get; set; }

        [StringLength(1)]
        public string IS_DEFAULT { get; set; }

        [StringLength(1)]
        public string IS_REQONLINE { get; set; }

        [StringLength(30)]
        public string PATIENT_TYPE { get; set; }

        [StringLength(3)]
        public string DEFAULT_SESSION { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_ROOM HR_ROOM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYAETITLE> RIS_MODALITYAETITLE { get; set; }

        public virtual RIS_MODALITYTYPE RIS_MODALITYTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYCONFIG> RIS_MODALITYCONFIG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYEXAM_ONL> RIS_MODALITYEXAM_ONL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYEXAM> RIS_MODALITYEXAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYUNIT> RIS_MODALITYUNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERDTL> RIS_ORDERDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTMODALITY> RIS_SCHEDULEDEFAULTMODALITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE> RIS_SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SESSIONAPPCOUNT> RIS_SESSIONAPPCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SESSIONMAXAPP> RIS_SESSIONMAXAPP { get; set; }
    }
}
