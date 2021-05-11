namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_SEARCH
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string KEYWORD { get; set; }

        public int? FREQUENCY { get; set; }

        public double? WEIGHT { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(10)]
        public string SOUNDEX { get; set; }
    }
}
