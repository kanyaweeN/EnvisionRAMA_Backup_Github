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
    public partial class QuestionnaireGroup : QuestionnaireBase
    {
        private int imgBottom;
        private int imgLeft;
        private bool firstCheck;
        private bool labelFirst;
        private int index;

        public QuestionnaireGroup()
        {
            InitializeComponent();
            firstCheck = true;
            labelFirst = true;
            index = 0;
        }
        public QuestionnaireGroup(SR_QUESTIONS Question, List<SR_QUESTIONSDTL> Details, List<SR_QUESTIONSDTLCHILD> Child, bool FillAnswer, int left, int top) 
                                 :base(Question,Details,Child,FillAnswer,left,top)
        {
            InitializeComponent();
            firstCheck = true;
            labelFirst = true;
            index = 0;
        }
        
        private void drawTextBoxControl(SR_QUESTIONSDTL dtl)
        {
            imgBottom = 0;
            imgLeft = CurrentLeft;
            TextEdit txt = new TextEdit();
            index++;
            txt.Name = "textbox" + index.ToString();
            txt.Width = 300;

            //QuickText Drag Drop
            txt.AllowDrop = true;
            txt.DragEnter += (object sender, DragEventArgs e) =>
            {
                e.Effect = DragDropEffects.All;
            };
            txt.DragDrop += (object sender, DragEventArgs e) =>
            {
                TextEdit TextEditDragDropSender = sender as TextEdit;
                string dragString = (string)e.Data.GetData(typeof(string));
                TextEditDragDropSender.Text += dragString;
            };

            QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(txt.Name, string.Empty);
            name.QId = dtl.Q_ID;
            name.QIdDtl = dtl.Q_ID_DTL;
            name.IsForce = dtl.IS_DEFAULT == "Y" ? true : false;
            this.ControlName.Add(name);
            //
            if (dtl.TEXT_SIZE == "D")
                txt.Width += txt.Width;
            else if (dtl.TEXT_SIZE == "H")
                txt.Width = txt.Width / 2;
            if (!string.IsNullOrEmpty(Question.DEFAULT_VALUE))
                txt.Text = Question.DEFAULT_VALUE;
            //if (Question.IS_BOLD == "Y" && firstCheck)
            //{
            //    if (IsMultiline)
            //        txt.Left = CurrentLeft + 10;// + 25;
            //    else
            //        txt.Left = CurrentLeft;// +20;
            //    imgLeft = txt.Left;
            //    firstCheck = false;
            //}
            //else
                txt.Left = CurrentLeft;
            txt.Top = CurrentTop;
            if (FillAnswer)
                txt.Text = dtl.ANSWER;
            this.Controls.Add(txt);
            //
            CurrentLeft = txt.Right + 3;
            imgBottom = txt.Bottom + 3;
            QuestionnaireHelper.AdjustSize(this, txt);
        }
        private void drawMemoEditControl(SR_QUESTIONSDTL dtl)
        {
            imgBottom = 0;
            imgLeft = CurrentLeft;
            MemoEdit txt = new MemoEdit();
            //txt.Width *= 2;
            txt.Width = 300;
            index++;
            txt.Name = "textbox" + index.ToString();

            //QuickText Drag Drop
            txt.AllowDrop = true;
            txt.DragEnter += (object sender, DragEventArgs e) =>
            {
                e.Effect = DragDropEffects.All;
            };
            txt.DragDrop += (object sender, DragEventArgs e) =>
            {
                MemoEdit MemoEditDragDropSender = sender as MemoEdit;
                string dragString = (string)e.Data.GetData(typeof(string));
                MemoEditDragDropSender.Text += dragString;
            };

            QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(txt.Name, string.Empty);
            name.IsForce = dtl.IS_DEFAULT == "Y" ? true : false;
            name.QId = dtl.Q_ID;
            name.QIdDtl = dtl.Q_ID_DTL;
            this.ControlName.Add(name);
            //
            if (dtl.TEXT_SIZE == "D")
                txt.Width += txt.Width;
            else if (dtl.TEXT_SIZE == "H")
                txt.Width = txt.Width / 2;
            if (!string.IsNullOrEmpty(Question.DEFAULT_VALUE))
                txt.Text = Question.DEFAULT_VALUE;
            //if (Question.IS_BOLD == "Y" && firstCheck)
            //{
            //    if (IsMultiline)
            //        txt.Left = CurrentLeft+10;// + 25;
            //    else
            //        txt.Left = CurrentLeft;// +20;
            //    imgLeft = txt.Left;
            //    firstCheck = false;
            //}
            //else
                txt.Left = CurrentLeft;
            txt.Top = CurrentTop;
            if (FillAnswer)
                txt.Text = dtl.ANSWER;
            this.Controls.Add(txt);
            //
            CurrentLeft = txt.Right + 3;
            imgBottom = txt.Bottom + 3;
            QuestionnaireHelper.AdjustSize(this, txt);
        }
        private void drawSpinEditControl(SR_QUESTIONSDTL dtl)
        {
            imgBottom = 0;
            imgLeft = CurrentLeft;
            SpinEdit txt = new SpinEdit();
            index++;
            txt.Name = "textbox" + index.ToString();
            QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(txt.Name, string.Empty);
            name.IsForce = dtl.IS_DEFAULT == "Y" ? true : false;
            name.QId = dtl.Q_ID;
            name.QIdDtl = dtl.Q_ID_DTL;
            this.ControlName.Add(name);
            //  
            if (!string.IsNullOrEmpty(dtl.PROP1))
                txt.Properties.MinValue = Convert.ToDecimal(dtl.PROP1);
            if (!string.IsNullOrEmpty(dtl.TEXT_SIZE))
                txt.Properties.MaxValue = Convert.ToDecimal(dtl.TEXT_SIZE);
            txt.EditValue = 0;
            //if (Question.IS_BOLD == "Y" && firstCheck)
            //{
            //    if (IsMultiline)
            //        txt.Left = CurrentLeft + 10;//+ 25;
            //    else
            //        txt.Left = CurrentLeft;// +20;
            //    imgLeft = txt.Left;
            //    firstCheck = false;
            //}
            //else
                txt.Left = CurrentLeft;
            txt.Top = CurrentTop;
            if (FillAnswer)
                txt.Text = dtl.ANSWER;
            this.Controls.Add(txt);
            //
            CurrentLeft = txt.Right + 3;
            imgBottom = txt.Bottom + 3;
            QuestionnaireHelper.AdjustSize(this, txt);
        }
        private void drawLabelControl(SR_QUESTIONSDTL dtl)
        {
            if (string.IsNullOrEmpty(dtl.DEFAULT_VALUE) || dtl.DEFAULT_VALUE.Trim().Length == 0) return;

            Queue<char> lstQueue = new Queue<char>();
            char[] ch = dtl.DEFAULT_VALUE.ToCharArray();
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
                        //    CurrentLeft += 25;//38;
                        //else
                        //    CurrentLeft += 20;// 10;
                       
                    }
                    int top = CurrentTop;

                    QuestionnaireName name = new QuestionnaireName();
                    QuestionnaireHelper.AddLabelControl(this, lastText, CurrentLeft, ref top, false, false, false,name,index);
                    ControlName.Add(name);


                    isNeedAdd = false;
                    lastText = string.Empty;
                    CurrentLeft = 3;
                    CurrentTop = top;
                    if (labelFirst==false)
                        CurrentTop = CurrentTop < CurrentBottom ? CurrentBottom : CurrentTop + 5;

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
                //        CurrentLeft += 25;// 38;
                //    else
                //        CurrentLeft += 20;// 10;
                //}
                QuestionnaireName name = new QuestionnaireName();
                CurrentLeft = QuestionnaireHelper.AddLabelControl(this, lastText, CurrentLeft, ref top, false, false, false,name,index);
                ControlName.Add(name);

            }

        }
        public override void DrawControl()
        {
            drawQuestionText();
            foreach (SR_QUESTIONSDTL dtl in QuestionDetails) {
                string lbl = dtl.LABEL;
                lbl = lbl.Replace("#@#", string.Empty);
                if (string.IsNullOrEmpty(lbl)) continue;
                if (lbl == "-1")
                {
                    labelFirst = false;
                    int bottom = 0;
                    //if (Question.IS_BOLD == "Y" && firstCheck)
                    //{
                    //    firstCheck = false;
                    //    if (IsMultiline)
                    //        CurrentLeft = CurrentLeft + 10; //25;
                    //    else
                    //        CurrentLeft = CurrentLeft;// +20;
                    //}
                    int right = QuestionnaireHelper.AddImageControl(this, dtl.Image, CurrentLeft, CurrentTop, ref bottom);
                    CurrentLeft = right + 3;
                    bottom += 3;
                    CurrentBottom = bottom > CurrentBottom ? bottom : CurrentBottom;
                }
                else
                {
                    switch (QuestionTypeHelper.GetQuestionType(Convert.ToInt32(lbl)))
                    {
                        case QuestionType.QNone:
                            labelFirst = false;
                            break;
                        case QuestionType.QLable:
                            drawLabelControl(dtl);
                            break;
                        case QuestionType.QMemo:
                            labelFirst = false;
                            drawMemoEditControl(dtl);
                            //if (CurrentLeft >= Width)
                            //{
                            //    CurrentLeft = QuestionnaireHelper.LEFT_SPACE;
                            //    CurrentTop = Height + QuestionnaireHelper.NEWLINE_SPACE;
                            //    this.Size = new Size(CurrentLeft, Height);
                            //}
                            break;
                        case QuestionType.QNumber:
                            labelFirst = false;
                            drawSpinEditControl(dtl);
                            //if (CurrentLeft >= Width)
                            //{
                            //    CurrentLeft = QuestionnaireHelper.LEFT_SPACE;
                            //    CurrentTop = Height + QuestionnaireHelper.NEWLINE_SPACE;
                            //    this.Size = new Size(CurrentLeft, Height);
                            //}
                            break;
                        case QuestionType.QText:
                            labelFirst = false;
                            drawTextBoxControl(dtl);
                            //if (CurrentLeft >= Width)
                            //{
                            //    CurrentLeft = QuestionnaireHelper.LEFT_SPACE;
                            //    CurrentTop = Height + QuestionnaireHelper.NEWLINE_SPACE;
                            //    this.Size = new Size(CurrentLeft, Height);
                            //}
                            break;
                    }
                }
            }
        }

        public override bool IsComplete
        {
            get
            {
                bool flag = true;
                ControlCollection ctrls = this.Controls;
                foreach (QuestionnaireName name in ControlName) {
                    if (name.IsForce) {
                        foreach (Control c in ctrls) {
                            if (c.Name.ToLower() == name.Name.ToLower())
                            {
                                flag = false;
                                TextEdit txt = c as TextEdit;
                                if (txt != null)
                                {
                                    if (txt.Text.Length > 0) flag = true;
                                    break;
                                }
                                MemoEdit mem = c as MemoEdit;
                                if (mem != null)
                                {
                                    if (mem.Text.Length > 0) flag = true;
                                    break;
                                }
                                SpinEdit sp = c as SpinEdit;
                                if (sp != null) {
                                    if (sp.EditValue != null) flag = true;
                                    break;
                                }
                                break;
                            }
                        }
                    }
                }
                return flag;
            }
            protected set
            {
                base.IsComplete = value;
            }
        }
        public override GenerateQuestionnaireText ResponseTextCollections(bool AppendNext)
        {
            
                GenerateQuestionnaireText rep = new GenerateQuestionnaireText();
                rep.PartId = Question.PART_ID;
                rep.QId = Question.Q_ID;
                rep.QIdDtl = 0;
                rep.QIdDtlChild = 0;
                string str = string.Empty;
                for (int i = 0; i < Question.SPACE_BEGIN; i++)
                    str += " ";
                str += Question.QUESTION_TEXT;
                rep.QuestionText = str;
                str = " ";
                ControlCollection ctrls = this.Controls;
                foreach (QuestionnaireName name in ControlName) {
                    if (name.IsLabel)
                        str += name.Value + " ";
                    else
                    {
                        foreach (Control ctrl in ctrls) {
                            if (string.IsNullOrEmpty(ctrl.Name)) continue;
                            if (ctrl.Name.ToLower() == name.Name.ToLower()) {
                                TextEdit txt = ctrl as TextEdit;
                                if (txt != null)
                                {
                                    str += txt.Text + " ";
                                    break;
                                }
                                MemoEdit mem = ctrl as MemoEdit;
                                if (mem != null)
                                {
                                    str += mem.Text + " ";
                                    break;
                                }
                                SpinEdit sp = ctrl as SpinEdit;
                                if (sp != null)
                                {
                                    str += sp.Text + " ";
                                    break;
                                }
                                break;
                            }
                        }
                    }
                }
                if (AppendNext)
                    str += " ";
                else
                    str += "\r\n";
                rep.QuestionAck = str;
                rep.IsAppendNext = AppendNext;
                rep.IsBold = Question.IS_BOLD == "Y" ? true : false;
                rep.IsItalic = Question.IS_ITALIC == "Y" ? true : false;
                rep.IsUnderLine = Question.IS_UNDERLINE == "Y" ? true : false;
                return rep;
            
        }
        public override Answer ResponseAnswer
        {
            get
            {
                Answer answer = new Answer();
                ControlCollection ctrls = this.Controls;
                foreach (QuestionnaireName name in ControlName)
                {
                    foreach (Control c in ctrls)
                    {
                        if (c.Name.ToLower() == name.Name.ToLower())
                        {
                            answer.SR_QUESTIONSANSWERS.Q_ID = name.QId;
                            answer.SR_QUESTIONSANSWERS.PART_ID = Question.PART_ID;

                            TextEdit txt = c as TextEdit;
                            if (txt != null)
                            {
                                SR_QUESTIONSANSWERSDTL srDtl = new SR_QUESTIONSANSWERSDTL();
                                srDtl.Q_ID = name.QId;
                                srDtl.Q_ID_DTL = name.QIdDtl;
                                srDtl.ANSWER = txt.Text;
                                answer.SR_QUESTIONSANSWERSDTL.Add(srDtl);
                                break;
                            }
                            MemoEdit mem = c as MemoEdit;
                            if (mem != null)
                            {
                                SR_QUESTIONSANSWERSDTL srDtl = new SR_QUESTIONSANSWERSDTL();
                                srDtl.Q_ID = name.QId;
                                srDtl.Q_ID_DTL = name.QIdDtl;
                                srDtl.ANSWER = mem.Text;
                                answer.SR_QUESTIONSANSWERSDTL.Add(srDtl);
                                break;
                            }
                            SpinEdit sp = c as SpinEdit;
                            if (sp != null)
                            {
                                SR_QUESTIONSANSWERSDTL srDtl = new SR_QUESTIONSANSWERSDTL();
                                srDtl.Q_ID = name.QId;
                                srDtl.Q_ID_DTL = name.QIdDtl;
                                srDtl.ANSWER = sp.EditValue.ToString();
                                answer.SR_QUESTIONSANSWERSDTL.Add(srDtl);
                                break;
                            }
                            break;
                        }
                    }
                }
                return answer;
            }
        }
    }
}
