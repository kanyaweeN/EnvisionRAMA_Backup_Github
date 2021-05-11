namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMRESULTAUTOSAVE
    {
        [Key]
        public int AUTOSAVE_ID { get; set; }

        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int? SL_NO { get; set; }

        public string RESULT_TEXT_HTML { get; set; }

        [StringLength(4000)]
        public string RESULT_TEXT_PLAIN { get; set; }

        public string RESULT_TEXT_RTF { get; set; }

        [StringLength(1)]
        public string RESULT_STATUS { get; set; }

        [StringLength(1)]
        public string FIRST_FINALIZED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
    }
}
