namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_OPNOTEITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_OPNOTEITEM()
        {
            RIS_OPNOTEITEMTEMPLATE = new HashSet<RIS_OPNOTEITEMTEMPLATE>();
        }

        [Key]
        public int OP_ITEM_ID { get; set; }

        [StringLength(50)]
        public string OP_ITEM_UID { get; set; }

        [Required]
        [StringLength(50)]
        public string OP_ITEM_NAME { get; set; }

        public int? UNIT_ID { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual HR_UNIT HR_UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_OPNOTEITEMTEMPLATE> RIS_OPNOTEITEMTEMPLATE { get; set; }
    }
}
