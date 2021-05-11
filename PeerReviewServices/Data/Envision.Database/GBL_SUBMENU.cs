namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_SUBMENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GBL_SUBMENU()
        {
            GBL_GRANTOBJECT = new HashSet<GBL_GRANTOBJECT>();
            GBL_MYMENU = new HashSet<GBL_MYMENU>();
            GBL_SUPPORT = new HashSet<GBL_SUPPORT>();
        }

        [Key]
        public int SUBMENU_ID { get; set; }

        [StringLength(30)]
        public string SUBMENU_UID { get; set; }

        public int? MENU_ID { get; set; }

        [StringLength(1)]
        public string SUBMENU_TYPE { get; set; }

        [StringLength(50)]
        public string SUBMENU_CLASS_NAME { get; set; }

        [StringLength(50)]
        public string SUBMENU_NAME_SYS { get; set; }

        [StringLength(50)]
        public string SUBMENU_NAME_USER { get; set; }

        public int? PARENT { get; set; }

        [StringLength(100)]
        public string DESCR { get; set; }

        public int? SL_NO { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [StringLength(1)]
        public string ADD_TO_HOME { get; set; }

        [StringLength(1)]
        public string CAN_VIEW { get; set; }

        [StringLength(1)]
        public string CAN_MODIFY { get; set; }

        [StringLength(1)]
        public string CAN_REMOVE { get; set; }

        [StringLength(1)]
        public string CAN_CREATE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GRANTOBJECT> GBL_GRANTOBJECT { get; set; }

        public virtual GBL_MENU GBL_MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_MYMENU> GBL_MYMENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SUPPORT> GBL_SUPPORT { get; set; }
    }
}
