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
    public partial class QuestionnaireMemoEdit : QuestionnaireBase
    {
        private int imgBottom;
        private int imgLeft;
        private bool firstCheck;

        public QuestionnaireMemoEdit()
        {
            InitializeComponent();
        }

        public QuestionnaireMemoEdit(SR_QUESTIONS Question, List<SR_QUESTIONSDTL> Details, List<SR_QUESTIONSDTLCHILD> Child, bool FillAnswer, int left, int top) 
                                 :base(Question,Details,Child,FillAnswer,left,top)
        {
            InitializeComponent();
            firstCheck = true;
        }
        private void drawMemoEditControl(SR_QUESTIONSDTL dtl)
        {
            imgBottom = 0;
            //if (CurrentLeft > this.Right)
            //{
            //    CurrentLeft = 3;
            //    if (CurrentTop < this.Height) CurrentTop = Height +3;
            //}
            imgLeft = CurrentLeft;

            MemoEdit txt = new MemoEdit();
            txt.Name = "textBox1";
            //txt.Width *= 2;
            txt.Width = 300;

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
            name.IsForce = Question.IS_DEFAULT == "Y" ? true : false;
            name.QId = dtl.Q_ID;
            name.QIdDtl = dtl.Q_ID_DTL;
            name.QIdDtlChild = 0;
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
            //        txt.Left = CurrentLeft + 25;
            //    else
            //        txt.Left = CurrentLeft + 20;
            //    imgLeft = txt.Left;
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
        public override void DrawControl()
        {
            drawQuestionText();
            SR_QUESTIONSDTL dtl = this.QuestionDetails[0];
            if (dtl.IsHasImage)
            {
                int bottom = 0;
                switch (dtl.IMG_POSITION)
                {
                    case "L":
                        //if (Question.IS_BOLD == "Y")
                        //{
                        //    firstCheck = false;
                        //    if (IsMultiline)
                        //        CurrentLeft = CurrentLeft + 25;
                        //    else
                        //        CurrentLeft = CurrentLeft + 20;
                        //}
                        int right = QuestionnaireHelper.AddImageControl(this, dtl.Image, CurrentLeft, CurrentTop, ref bottom);
                        CurrentLeft = right + 3;
                        drawMemoEditControl(dtl);
                        break;
                    case "R":
                        drawMemoEditControl(dtl);
                        QuestionnaireHelper.AddImageControl(this, dtl.Image, CurrentLeft, CurrentTop, ref bottom);
                        break;
                    case "T":
                        if (Question.IS_BOLD == "Y")
                        {
                            firstCheck = false;
                            if (IsMultiline)
                                CurrentLeft = CurrentLeft + 25;
                            else
                                CurrentLeft = CurrentLeft + 20;
                        }
                        QuestionnaireHelper.AddImageControl(this, dtl.Image, CurrentLeft, CurrentTop, ref bottom);
                        CurrentTop = bottom + 3;
                        drawMemoEditControl(dtl);
                        break;
                    case "B":
                        drawMemoEditControl(dtl);
                        QuestionnaireHelper.AddImageControl(this, dtl.Image, imgLeft, imgBottom, ref bottom);
                        break;
                }
            }
            else
                drawMemoEditControl(dtl);
        }

        public override bool IsComplete
        {
            get
            {
                bool flag = true;
                ControlCollection ctrls = this.Controls;
                foreach (QuestionnaireName name in ControlName)
                {
                    if (name.IsForce)
                    {
                        flag = false;
                        foreach (Control c in ctrls)
                        {
                            if (c.Name.ToLower() == name.Name.ToLower())
                            {
                                MemoEdit mem = c as MemoEdit;
                                if (mem != null)
                                {
                                    if (mem.Text.Length > 0) flag = true;
                                    break;
                                }
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
                foreach (System.Windows.Forms.Control ctrl in ctrls)
                    if (ctrl.Name == "textBox1")
                    {
                        MemoEdit txt = ctrl as MemoEdit;
                        str += " " + txt.Text.TrimEnd();
                        break;
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
                rep.QType = QuestionType.QMemo;
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
                    bool flag = false;
                    foreach (Control ctrl in ctrls)
                    {
                        if (ctrl.Name.ToLower() == name.Name.ToLower())
                        {
                            MemoEdit txt = ctrl as MemoEdit;
                            if (txt == null) break;

                            answer.SR_QUESTIONSANSWERS.Q_ID = name.QId;
                            answer.SR_QUESTIONSANSWERS.PART_ID = Question.PART_ID;
                            SR_QUESTIONSANSWERSDTL srDtl = new SR_QUESTIONSANSWERSDTL();
                            srDtl.Q_ID = name.QId;
                            srDtl.Q_ID_DTL = name.QIdDtl;
                            srDtl.ANSWER = txt.Text;
                            answer.SR_QUESTIONSANSWERSDTL.Add(srDtl);
                            flag = true;
                            break;
                        }
                    }
                    if (flag) break;
                }
                return answer;
            }
        }
    }
}
