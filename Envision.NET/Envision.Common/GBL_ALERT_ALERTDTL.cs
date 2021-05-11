using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;


namespace Envision.Common
{
    public class GBL_ALERT_ALERTDTL
    {
        public int ALT_ID { get; set; }

        public string ALT_UID { get; set; }

        public int ORG_ID { get; set; }

        public int CREATED_BY { get; set; }

        public string CREATED_ON { get; set; }

        public int LAST_MODIFIED_BY { get; set; }

        public string LAST_MODIFIED_ON { get; set; }

        public int LANG_ID { get; set; }
        public string ALT_TEXT { get; set; }

        public string ALT_TYPE { get; set; }

        public string IS_ACTIVE { get; set; }
        public string ALT_TITLE { get; set; }
        public int ALT_BUTTON { get; set; }
        public string CAPTION_BTN1 { get; set; }

        public string CAPTION_BTN2 { get; set; }

        public string CAPTION_BTN3 { get; set; }

        public int DEFAULT_BTN { get; set; }
        public int TIME_SEC { get; set; }
    }
}
