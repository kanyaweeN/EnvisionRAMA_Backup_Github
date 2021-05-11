namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_RADEXPERIENCE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RADIOLOGIST_ID { get; set; }

        public short? AUTO_REFRESH_WL_SEC { get; set; }

        [StringLength(1)]
        public string DASHBOARD_DEF_SEARCH { get; set; }

        public bool? LOAD_FINALIZED_EXAMS { get; set; }

        public bool? ALL_EXAM_VISIBLE { get; set; }

        public bool? LOAD_ALL_EXAM { get; set; }

        public bool? AUTO_START_ORDER_IMG { get; set; }

        public bool? AUTO_START_PACS_IMG { get; set; }

        [StringLength(2)]
        public string DEF_DATE_RANGE { get; set; }

        public bool? REMEMBER_GRID_ORDER { get; set; }

        [StringLength(1)]
        public string GRID_DBL_CLICK_TO { get; set; }

        [StringLength(1)]
        public string FINISH_WRITING_REFER_TO { get; set; }

        public bool? ALLOW_OTHERSTO_FINALIZE { get; set; }

        [StringLength(50)]
        public string FONT_FACE { get; set; }

        public byte? FONT_SIZE { get; set; }

        public string SIGNATURE_TEXT { get; set; }

        public string SIGNATURE_RTF { get; set; }

        public string SIGNATURE_HTML { get; set; }

        [Column(TypeName = "image")]
        public byte[] SIGNATURE_SCAN { get; set; }

        [StringLength(1)]
        public string USED_SIGNATURE { get; set; }

        [StringLength(1)]
        public string WHEN_GROUP_SIGN_USE { get; set; }

        public int? MINIMIZE_CHARACTER { get; set; }

        public string WORKLIST_GRID_ORDER { get; set; }

        public string HISTORY_GRID_ORDER { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string USED_MENUBAR { get; set; }

        [StringLength(1)]
        public string USED_120DPI { get; set; }

        [StringLength(1)]
        public string RECONFIRM_PASS_ON_SAVE { get; set; }

        [StringLength(1)]
        public string IS_ADDENDUM { get; set; }

        public int? ZOOM_SETTING { get; set; }

        [StringLength(3)]
        public string ALLOW_MULTIPLE_FINALIZE_UPTO { get; set; }

        public bool? SHOW_PRELIM { get; set; }

        public bool? ALLOW_MULTIPLE_FINALIZE { get; set; }

        [StringLength(30)]
        public string PAPER_KIND { get; set; }

        public int? NO_OF_COPY { get; set; }

        [StringLength(1)]
        public string AUTO_EXAMNAME { get; set; }

        [StringLength(1)]
        public string AUTO_CLINICALINDICATION { get; set; }

        [StringLength(1)]
        public string OPEN_PACS_WHEN_MERGE { get; set; }

        public int? MAXIMUM_SHORTPRELIM_CHARECTORS { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
