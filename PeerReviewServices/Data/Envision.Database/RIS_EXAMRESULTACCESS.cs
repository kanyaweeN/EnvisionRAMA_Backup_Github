namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULTACCESS
    {
        [Key]
        public int ACCESS_NO { get; set; }

        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int? ACCESS_BY { get; set; }

        public DateTime? ACCESS_ON { get; set; }

        [StringLength(1)]
        public string ACCESS_STATUS { get; set; }

        public string ACCESS_TEXT { get; set; }

        public DateTime? EXIT_ON { get; set; }

        [StringLength(1)]
        public string EXIT_STATUS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public string ACCESS_TEXT_RTF { get; set; }

        [StringLength(1)]
        public string ACCESS_TYPE { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
