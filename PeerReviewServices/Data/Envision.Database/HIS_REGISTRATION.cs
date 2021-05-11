namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HIS_REGISTRATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HIS_REGISTRATION()
        {
            FIN_INVOICE = new HashSet<FIN_INVOICE>();
            FIN_PAYMENT = new HashSet<FIN_PAYMENT>();
            MG_PATIENTHISTORYCOMPARISON = new HashSet<MG_PATIENTHISTORYCOMPARISON>();
            RIS_COMMENTSONPATIENT = new HashSet<RIS_COMMENTSONPATIENT>();
            RIS_ORDER = new HashSet<RIS_ORDER>();
            RIS_SCHEDULE_RESERVATION = new HashSet<RIS_SCHEDULE_RESERVATION>();
            RIS_SCHEDULE = new HashSet<RIS_SCHEDULE>();
        }

        [Key]
        public int REG_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string HN { get; set; }

        [StringLength(100)]
        public string TITLE { get; set; }

        public DateTime? REG_DT { get; set; }

        [StringLength(100)]
        public string FNAME { get; set; }

        [StringLength(100)]
        public string MNAME { get; set; }

        [StringLength(100)]
        public string LNAME { get; set; }

        [StringLength(100)]
        public string TITLE_ENG { get; set; }

        [StringLength(100)]
        public string FNAME_ENG { get; set; }

        [StringLength(100)]
        public string MNAME_ENG { get; set; }

        [StringLength(100)]
        public string LNAME_ENG { get; set; }

        [StringLength(100)]
        public string SSN { get; set; }

        public DateTime? DOB { get; set; }

        public int? AGE { get; set; }

        [StringLength(100)]
        public string ADDR1 { get; set; }

        [StringLength(100)]
        public string ADDR2 { get; set; }

        [StringLength(100)]
        public string ADDR3 { get; set; }

        [StringLength(100)]
        public string ADDR4 { get; set; }

        [StringLength(100)]
        public string ADDR5 { get; set; }

        [StringLength(100)]
        public string PHONE1 { get; set; }

        [StringLength(100)]
        public string PHONE2 { get; set; }

        [StringLength(100)]
        public string PHONE3 { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(1)]
        public string GENDER { get; set; }

        [StringLength(1)]
        public string MARITAL_STATUS { get; set; }

        public int? OCCUPATION_ID { get; set; }

        [StringLength(50)]
        public string NATIONALITY { get; set; }

        [StringLength(50)]
        public string PASSPORT_NO { get; set; }

        [StringLength(20)]
        public string BLOOD_GROUP { get; set; }

        [StringLength(30)]
        public string RELIGION { get; set; }

        [StringLength(1)]
        public string PATIENT_TYPE { get; set; }

        [StringLength(1)]
        public string BLOCK_PATIENT { get; set; }

        [StringLength(100)]
        public string EM_CONTACT_PERSON { get; set; }

        [StringLength(50)]
        public string EM_RELATION { get; set; }

        [StringLength(100)]
        public string EM_ADDR { get; set; }

        [StringLength(100)]
        public string EM_PHONE { get; set; }

        [StringLength(100)]
        public string INSURANCE_TYPE { get; set; }

        [StringLength(4000)]
        public string HL7_FORMAT { get; set; }

        [StringLength(1)]
        public string HL7_SEND { get; set; }

        [StringLength(1)]
        public string LINK_DOWN { get; set; }

        [StringLength(100)]
        public string ALLERGIES { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [StringLength(1)]
        public string IS_JOHNDOE { get; set; }

        [StringLength(1)]
        public string IS_PREGNANT { get; set; }

        [StringLength(1)]
        public string IS_FOREIGNER { get; set; }

        [StringLength(30)]
        public string HIS_HN { get; set; }

        [StringLength(30)]
        public string EXT_HN { get; set; }

        [StringLength(30)]
        public string PatientIdentificationLabel { get; set; }

        [StringLength(300)]
        public string PatientIdentificationDetail { get; set; }

        [StringLength(30)]
        public string PATIENT_ID_LABEL { get; set; }

        [StringLength(500)]
        public string PATIENT_ID_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIN_INVOICE> FIN_INVOICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIN_PAYMENT> FIN_PAYMENT { get; set; }

        public virtual HR_OCCUPATION HR_OCCUPATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_PATIENTHISTORYCOMPARISON> MG_PATIENTHISTORYCOMPARISON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_COMMENTSONPATIENT> RIS_COMMENTSONPATIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDER> RIS_ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE> RIS_SCHEDULE { get; set; }
    }
}
