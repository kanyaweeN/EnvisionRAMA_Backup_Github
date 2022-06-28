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
    public partial class QuestionnaireSpinEdit : QuestionnaireBase
    {
        private int imgBottom;
        private int imgLeft;
        private bool firstCheck;

        public QuestionnaireSpinEdit()
        {
            InitializeComponent();
        }
        public QuestionnaireSpinEdit(SR_QUESTIONS Question, List<SR_QUESTIONSDTL> Details, List<SR_QUESTIONSDTLCHILD> Child, bool FillAnswer, int left, int top) 
                                 :base(Question,Details,Child,FillAnswer,left,top)
        {
            InitializeComponent();
            firstCheck = true;
        }

        private void drawSpinEditControl(SR_QUESTIONSDTL dtl) {
            imgBottom = 0;
            //if (CurrentLeft > this.Right)
            //{
            //    CurrentLeft = 3;
            //    if (CurrentTop < this.Height) CurrentTop = Height + 3;
            //}
            //imgLeft = CurrentLeft;
            imgLeft = CurrentLeft;
            SpinEdit txt = new SpinEdit();
            txt.Name = "textBox1";
            QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(txt.Name, string.Empty);
            name.IsForce = Question.IS_DEFAULT == "Y" ? true : false;
            name.QId = dtl.Q_ID;
            name.QIdDtl = dtl.Q_ID_DTL;
            name.QIdDtlChild = 0;
            this.ControlName.Add(name);
            //  
            if(!string.IsNullOrEmpty(dtl.PROP1))
                txt.Properties.MinValue = Convert.ToDecimal(dtl.PROP1);
            if (!string.IsNullOrEmpty(dtl.TEXT_SIZE))
                txt.Properties.MaxValue = Convert.ToDecimal(dtl.TEXT_SIZE);
            txt.EditValue = 0;
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
            if (dtl.IsHasImage) {
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
                        drawSpinEditControl(dtl);
                        break;
                    case "R":
                        drawSpinEditControl(dtl);
                        QuestionnaireHelper.AddImageControl(this, dtl.Image, CurrentLeft, CurrentTop, ref bottom);
                        break;
                    case "T":
                        //if (Question.IS_BOLD == "Y")
                        //{
                        //    firstCheck = false;
                        //    if (IsMultiline)
                        //        CurrentLeft = CurrentLeft + 25;
                        //    else
                        //        CurrentLeft = CurrentLeft + 20;
                        //}
                        QuestionnaireHelper.AddImageControl(this, dtl.Image, CurrentLeft, CurrentTop, ref bottom);
                        CurrentTop = bottom + 3;
                        drawSpinEditControl(dtl);
                        break;
                    case "B":
                        drawSpinEditControl(dtl);
                        QuestionnaireHelper.AddImageControl(this, dtl.Image, imgLeft, imgBottom, ref bottom);
                        break;
                }
            }
            else
                drawSpinEditControl(dtl);
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
                                SpinEdit sp = c as SpinEdit;
                                if (sp != null)
                                {
                                    if (sp.EditValue != null) flag = true;
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
                    SpinEdit txt = ctrl as SpinEdit;
                    if (string.IsNullOrEmpty(txt.EditValue.ToString()))
                        str += " ";
                    else
                        str += " " + txt.EditValue.ToString();
                    break;
                }
            if (AppendNext)
                str += " ";
            else
                str += "\r\n";
            rep.QuestionAck = str;
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
                    bool flag = false;
                    foreach (Control ctrl in ctrls)
                    {
                        if (ctrl.Name.ToLower() == name.Name.ToLower())
                        {
                            SpinEdit txt = ctrl as SpinEdit;
                            if (txt == null) break;

                            answer.SR_QUESTIONSANSWERS.Q_ID = name.QId;
                            answer.SR_QUESTIONSANSWERS.PART_ID = Question.PART_ID;
                            SR_QUESTIONSANSWERSDTL srDtl = new SR_QUESTIONSANSWERSDTL();
                            srDtl.Q_ID = name.QId;
                            srDtl.Q_ID_DTL = name.QIdDtl;
                            srDtl.ANSWER = txt.EditValue.ToString();
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
