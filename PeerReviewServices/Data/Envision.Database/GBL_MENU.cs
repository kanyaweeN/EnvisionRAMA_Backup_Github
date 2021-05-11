namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GBL_MENU()
        {
            GBL_SUBMENU = new HashSet<GBL_SUBMENU>();
        }

        [Key]
        public int MENU_ID { get; set; }

        [StringLength(30)]
        public string MENU_UID { get; set; }

        [StringLength(50)]
        public string MENU_NAME { get; set; }

        [StringLength(100)]
        public string MENU_NAMESPACE { get; set; }

        [Column(TypeName = "image")]
        public byte[] MENU_ICON { get; set; }

        [StringLength(100)]
        public string DESCR { get; set; }

        public int? PARENT { get; set; }

        public int? SL_NO { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SUBMENU> GBL_SUBMENU { get; set; }
    }
}
