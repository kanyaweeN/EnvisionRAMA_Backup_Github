using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

using Envision.Common;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.Common;
namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport
{
    public partial class QuestionnaireLabel : QuestionnaireBase
    {
        public QuestionnaireLabel()
        {
            InitializeComponent();
        }
        public QuestionnaireLabel(SR_QUESTIONS Question, List<SR_QUESTIONSDTL> Details, List<SR_QUESTIONSDTLCHILD> Child, bool FillAnswer,int left,int top) 
                                 :base(Question,Details,Child,FillAnswer,left,top)
        {
            InitializeComponent();
        }

        private void drawLabelControl() {
            if (string.IsNullOrEmpty(Question.DEFAULT_VALUE) || Question.DEFAULT_VALUE.Trim().Length == 0) return;

            Queue<char> lstQueue = new Queue<char>();
            char[] ch = Question.DEFAULT_VALUE.ToCharArray();
            foreach (char data in ch) lstQueue.Enqueue(data);
            string lastText = string.Empty;
            bool isNeedAdd = true;
            bool firstCheck = true;
            while (lstQueue.Count > 0)
            {
                LabelControl lbl = new LabelControl();
                lbl.UseMnemonic = false;
                lbl.AutoSizeMode = LabelAutoSizeMode.Horizontal;
                lbl.Size = new Size(0, 0);
                lbl.Left = CurrentLeft;
                FontStyle fs = FontStyle.Regular;
                if (IsBold) fs |= FontStyle.Bold;
                if (IsItalic) fs |= FontStyle.Italic;
                if (IsUnderline) fs |= FontStyle.Underline;
                Font font = new Font(lbl.Font, fs);
                lbl.Font = font;

                string text = lastText + lstQueue.Peek().ToString();
                if (QuestionnaireHelper.IsLabelOverline(text, false, false, false, lbl.Left))
                {
                    if (Question.IS_BOLD == "Y" && firstCheck)
                    {
                        firstCheck = false;
                        //if (IsMultiline)
                        //    CurrentLeft += 38;
                        //else
                        //    CurrentLeft += 10;

                        //if (IsMultiline)
                        //    CurrentLeft += 10;
                    }
                    int top = CurrentTop;
                    QuestionnaireHelper.AddLabelControl(this, lastText, CurrentLeft, ref top, false, false, false);
                    isNeedAdd = false;
                    lastText = string.Empty;
                    CurrentLeft = 3;
                    CurrentTop = top;
                }
                else
                {
                    isNeedAdd = true;
                    lastText += lstQueue.Dequeue().ToString();
                }
            }
            if (isNeedAdd && !string.IsNullOrEmpty(lastText))
            {
                int top = CurrentTop;
                //if (Question.IS_BOLD == "Y" && firstCheck)
                //{
                //    if (IsMultiline)
                //        CurrentLeft += 38;
                //    else
                //        CurrentLeft += 10;
                //}

                //if (IsMultiline)
                //    CurrentLeft += 10;
                CurrentLeft = QuestionnaireHelper.AddLabelControl(this, lastText, CurrentLeft, ref top, false, false, false);
            }
        
        }
        public override void DrawControl()
        {
            drawQuestionText();
            drawLabelControl();

            this.Size = new Size(this.Width, this.Height + QuestionnaireHelper.NEWLINE_SPACE);
        }
        public override GenerateQuestionnaireText ResponseTextCollections(bool AppendNext)
        {
                GenerateQuestionnaireText rep = new GenerateQuestionnaireText();
                rep.IsBold = Question.IS_BOLD == "Y" ? true : false;
                rep.IsItalic = Question.IS_ITALIC == "Y" ? true : false;
                rep.IsUnderLine = Question.IS_UNDERLINE == "Y" ? true : false;
                rep.PartId = Question.PART_ID;
                rep.QId = Question.Q_ID;
                rep.QIdDtl = 0;
                rep.QIdDtlChild = 0;
                rep.QuestionText = Question.QUESTION_TEXT;
                rep.QuestionAck = Question.DEFAULT_VALUE;
                rep.IsAppendNext = AppendNext;
                return rep;
           
        }
        public override bool IsComplete
        {
            get
            {
                return true;
            }
            protected set
            {
                base.IsComplete = value;
            }
        }
    }
}
