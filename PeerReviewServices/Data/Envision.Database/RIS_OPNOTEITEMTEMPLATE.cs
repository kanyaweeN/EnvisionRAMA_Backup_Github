namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_OPNOTEITEMTEMPLATE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OP_ITEM_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EXAM_ID { get; set; }

        public string ITEM_VALUE { get; set; }

        [StringLength(50)]
        public string ITEM_UNIT { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string OPNOTE_TYPE { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual RIS_EXAM RIS_EXAM { get; set; }

        public virtual RIS_OPNOTEITEM RIS_OPNOTEITEM { get; set; }
    }
}
