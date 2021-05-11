namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_ALERTDTL
    {
        [Key]
        public int ALT_DTL_ID { get; set; }

        public int ALT_ID { get; set; }

        public int LANG_ID { get; set; }

        [StringLength(300)]
        public string ALT_TEXT { get; set; }

        [StringLength(1)]
        public string ALT_TYPE { get; set; }

        [StringLength(50)]
        public string ALT_TITLE { get; set; }

        public int? ALT_BUTTON { get; set; }

        [StringLength(25)]
        public string CAPTION_BTN1 { get; set; }

        [StringLength(25)]
        public string CAPTION_BTN2 { get; set; }

        [StringLength(25)]
        public string CAPTION_BTN3 { get; set; }

        public byte? DEFAULT_BTN { get; set; }

        public byte? TIME_SEC { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual GBL_LANGUAGE GBL_LANGUAGE { get; set; }
    }
}
