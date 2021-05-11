namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_ASSIGNMENT
    {
        [Key]
        public int ASSIGNEMENT_ID { get; set; }

        public int ENROLL_ID { get; set; }

        public int? ASSIGNED_BY { get; set; }

        [StringLength(1)]
        public string ASSIGNMENT_TYPE { get; set; }

        public DateTime? ASSIGNED_ON { get; set; }

        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public DateTime? ACK_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
