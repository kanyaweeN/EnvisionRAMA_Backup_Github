namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ONL_SEARCHMATCH
    {
        [Key]
        public int SEARCH_MATCH_ID { get; set; }

        public int? MATCH_EXAMTYPE { get; set; }

        [StringLength(300)]
        public string MATCH_TEXT { get; set; }
    }
}
