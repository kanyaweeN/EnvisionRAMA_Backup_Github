using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.Common
{
    public class GenerateQuestionnaireText
    {
        public int PartId { get; set; }
        public int QId { get; set; }
        public int QIdDtl { get; set; }
        public int QIdDtlChild { get; set; }

        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public bool IsUnderLine { get; set; }
        public bool IsAppendNext { get; set; }

        public string QuestionText { get; set; }
        public string QuestionAck { get; set; }
        public QuestionType QType { get; set; }


        public GenerateQuestionnaireText()
        {
            IsBold = IsItalic = IsUnderLine = false;
            QuestionText = string.Empty;
            QuestionAck = string.Empty;
            IsAppendNext = false;
            QType = QuestionType.QNone;
        }
    }
}
