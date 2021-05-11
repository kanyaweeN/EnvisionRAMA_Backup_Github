namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_CLINICSESSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_CLINICSESSION()
        {
            RIS_MODALITYCONFIG = new HashSet<RIS_MODALITYCONFIG>();
            RIS_SESSIONAPPCOUNT = new HashSet<RIS_SESSIONAPPCOUNT>();
            RIS_SESSIONMAXAPP = new HashSet<RIS_SESSIONMAXAPP>();
        }

        [Key]
        public int SESSION_ID { get; set; }

        [StringLength(30)]
        public string SESSION_UID { get; set; }

        [StringLength(300)]
        public string SESSION_NAME { get; set; }

        public int? CLINIC_TYPE_ID { get; set; }

        public DateTime? START_TIME { get; set; }

        public DateTime? END_TIME { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public byte? SL_NO { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [StringLength(50)]
        public string SESSION_NAME_ALIAS { get; set; }

        [StringLength(1)]
        public string SHOW_ONLINE { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_CLINICTYPE RIS_CLINICTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYCONFIG> RIS_MODALITYCONFIG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SESSIONAPPCOUNT> RIS_SESSIONAPPCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SESSIONMAXAPP> RIS_SESSIONMAXAPP { get; set; }
    }
}
