namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_CLINICALINDICATION_WITH_UNIT
    {
        [Key]
        public int CI_UNIT_ID { get; set; }

        public int CI_ID { get; set; }

        public int UNIT_ID { get; set; }

        public int ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_UNIT HR_UNIT { get; set; }

        public virtual RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }
    }
}
