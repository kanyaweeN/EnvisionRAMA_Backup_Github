namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_MYMENU
    {
        [Key]
        public int MYMENU_ID { get; set; }

        public int? MYMENU_UID { get; set; }

        public int? EMP_ID { get; set; }

        public int? SL_NO { get; set; }

        public int? SUBMENU_ID { get; set; }

        public int? ORG_ID { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual GBL_ENV GBL_ENV1 { get; set; }

        public virtual GBL_ENV GBL_ENV2 { get; set; }

        public virtual GBL_SUBMENU GBL_SUBMENU { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        public virtual HR_EMP HR_EMP1 { get; set; }
    }
}
