namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_SEARCH_DTL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KEY_ID { get; set; }

        public int? KEY_FREQ { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual RIS_EXAMRESULT RIS_EXAMRESULT { get; set; }
    }
}
