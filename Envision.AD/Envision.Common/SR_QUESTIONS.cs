using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Envision.Common
{
    public class SR_QUESTIONS
    {
        public int Q_ID { get; set; }
        public int Q_TYPE_ID { get; set; }
        public int PART_ID { get; set; }
        public string QUESTION_TEXT { get; set; }
        public string QUESTION_SIDE { get; set; }
        public int SPACE_BEGIN { get; set; }
        public string IS_BOLD { get; set; }
        public string IS_ITALIC { get; set; }
        public string IS_UNDERLINE { get; set; }
        public string LABEL { get; set; }
        public string DEFAULT_VALUE { get; set; }
        public string IS_DEFAULT { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public string APPEND_NEXT { get; set; }
        public string ANSWER { get; set; }
    }
}
