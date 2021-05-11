using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class MG_BREASTMARKTEMPLATE
    {
        public int TPL_ID { get; set; }
        public string TPL_NAME { get; set; }
        public int EMP_ID { get; set; }
        public string SHAPE { get; set; }
        public string STYLE { get; set; }
        public string FILL_COLOR { get; set; }
        public string STROKE_COLOR { get; set; }
        public string BORDER_COLOR { get; set; }
        public string FONT_COLOR { get; set; }
        public string FONT_FAMILY { get; set; }
        public int FONT_SIZE { get; set; }
        public int DIMENSION { get; set; }
        public int THICKNESS { get; set; }
        public string UNIT { get; set; }
        public string SHOW_BORDER { get; set; }
        public string CAN_RESIZE { get; set; }
        public string IS_DEFAULT { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
