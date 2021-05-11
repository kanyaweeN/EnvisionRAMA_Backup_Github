namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_TRANSACTION
    {
        [Key]
        public int TXN_ID { get; set; }

        [StringLength(1)]
        public string TXN_TYPE { get; set; }

        public int? REQUISITION_ID { get; set; }

        public int? PO_ID { get; set; }

        public int? FROM_UNIT { get; set; }

        public int? TO_UNIT { get; set; }

        [StringLength(200)]
        public string COMMENTS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual INV_UNIT INV_UNIT { get; set; }

        public virtual INV_UNIT INV_UNIT1 { get; set; }
    }
}
