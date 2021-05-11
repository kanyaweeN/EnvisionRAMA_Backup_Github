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
    public partial class QuestionnaireMultiColumns : QuestionnaireBase
    {
        private bool firstCheck;
        private bool isMultiSelect;
        private int index;

        public QuestionnaireMultiColumns()
        {
            InitializeComponent();
            firstCheck = true;
            isMultiSelect = true;
            index = 0;
        }
        public QuestionnaireMultiColumns(SR_QUESTIONS Question, List<SR_QUESTIONSDTL> Details, List<SR_QUESTIONSDTLCHILD> Child, bool FillAnswer, int left, int top) 
                                 :base(Question,Details,Child,FillAnswer,left,top)
        {
            InitializeComponent();
            firstCheck = true;
            isMultiSelect = true;
            index = 0;
        }
        private int drawRadioCheckBoxControl(SR_QUESTIONSDTL dtl,int top,ref int bottom) {
            int right = 0;
            if (isMultiSelect)
            {
                CheckBox chk = new CheckBox();
                index++;
                chk.Name = "checkBox" + index.ToString();
                if (FillAnswer)
                {
                    if (string.IsNullOrEmpty(dtl.ANSWER))
                        chk.Checked = false;
                    else
                        chk.Checked = true;
                }
                else
                    chk.Checked = dtl.IS_DEFAULT == "Y" ? true : false;
                chk.AutoSize = true;
                chk.Left = CurrentLeft;
                chk.Top = top;
                chk.Text = dtl.LABEL;
                this.Controls.Add(chk);
                right = chk.Right;
                bottom = chk.Bottom;
                QuestionnaireHelper.AdjustSize(this, chk);
                //add control Name
                QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(chk.Name,dtl.DEFAULT_VALUE);
                name.QId = dtl.Q_ID;
                name.QIdDtl = dtl.Q_ID_DTL;
                name.IsForce = false;
                name.Value = dtl.DEFAULT_VALUE;
                this.ControlName.Add(name);
            }
            else {
                RadioButton chk = new RadioButton();
                index++;
                chk.Name = "radioButton" + index.ToString();
                if (FillAnswer)
                {
                    if (string.IsNullOrEmpty(dtl.ANSWER))
                        chk.Checked = false;
                    else
                        chk.Checked = true;
                }
                else
                    chk.Checked = dtl.IS_DEFAULT == "Y" ? true : false;
                chk.AutoSize = true;
                chk.Left = CurrentLeft;
                chk.Top = top;
                chk.Text = dtl.LABEL;
                this.Controls.Add(chk);
                bottom = chk.Bottom;
                right = chk.Right;
                QuestionnaireHelper.AdjustSize(this, chk);
                //add control Name
                QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(chk.Name, dtl.DEFAULT_VALUE);
                name.IsForce = false;
                name.QId = dtl.Q_ID;
                name.QIdDtl = dtl.Q_ID_DTL;
                name.Value = dtl.DEFAULT_VALUE;
                this.ControlName.Add(name);
            }
            return right + QuestionnaireHelper.NEWLINE_SPACE;
        }
        public override void DrawControl()
        {
            drawQuestionText();
            //if (Question.IS_BOLD == "Y" && firstCheck)
            //{
            //    firstCheck = false;
            //    if (IsMultiline)
            //        CurrentLeft = CurrentLeft + 45;
            //    else
            //        CurrentLeft = CurrentLeft + 20;
            //}
            if (string.IsNullOrEmpty(Question.DEFAULT_VALUE)) return;
            isMultiSelect = Question.IS_DEFAULT == "M" ? true : false;
            int numberOfColumns = Convert.ToInt32(Question.DEFAULT_VALUE);
            int top = CurrentTop;
            int bottom = 0;
            int right = 0;
            for (int i = 1; i <= numberOfColumns; i++) {
                int r = CurrentRight;
                foreach (SR_QUESTIONSDTL dtl in QuestionDetails)
                {
                    if (dtl.PROP1 == i.ToString())
                    {
                        right = drawRadioCheckBoxControl(dtl, top, ref bottom);
                        top = bottom;
                        
                        //CurrentLeft = CurrentLeft > right ? CurrentLeft : right;
                        int h = Height > bottom ? Height : bottom;
                        r += right +10;
                    }
                }
                this.Size = new Size(r, Height);

                //change
                if (Question.QUESTION_SIDE == "H")
                {
                    top = CurrentTop;
                    CurrentLeft = right+3;
                    bottom = 0;
                }
                else {
                    top = CurrentTop = bottom + 10;
                }
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
                    foreach (Control ctrl in ctrls) {
                        if (string.IsNullOrEmpty(ctrl.Name)) continue;
                        if (name.Name.ToLower() == ctrl.Name.ToLower())
                        {
                            if (isMultiSelect)
                            {
                                CheckBox chk = ctrl as CheckBox;
                                if (chk == null) continue;
                                if (chk.Checked) str += name.Value + " ";
                            }
                            else {
                                RadioButton chk = ctrl as RadioButton;
                                if (chk == null) continue;
                                if (chk.Checked) str += name.Value + " ";
                            }
                            break;
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
                answer.SR_QUESTIONSANSWERS.Q_ID = Question.Q_ID;
                answer.SR_QUESTIONSANSWERS.PART_ID = Question.PART_ID;
                ControlCollection ctrls = this.Controls;
                foreach (QuestionnaireName name in ControlName)
                {
                    bool flag = false;
                    foreach (Control ctrl in ctrls) {
                        if (name.Name.ToLower() == ctrl.Name.ToLower()) {
                            flag = true;
                            if (isMultiSelect)
                            {
                                CheckBox chk = ctrl as CheckBox;
                                if (chk == null) break;
                                if (chk.Checked)
                                {
                                    SR_QUESTIONSANSWERSDTL dtl = new SR_QUESTIONSANSWERSDTL();
                                    dtl.Q_ID = name.QId;
                                    dtl.Q_ID_DTL = name.QIdDtl;
                                    dtl.ANSWER = name.Value;
                                    answer.SR_QUESTIONSANSWERSDTL.Add(dtl);
                                }
                            }
                            else {
                                RadioButton chk = ctrl as RadioButton;
                                if (chk == null) break;
                                if (chk.Checked)
                                {
                                    SR_QUESTIONSANSWERSDTL dtl = new SR_QUESTIONSANSWERSDTL();
                                    dtl.Q_ID = name.QId;
                                    dtl.Q_ID_DTL = name.QIdDtl;
                                    dtl.ANSWER = name.Value;
                                    answer.SR_QUESTIONSANSWERSDTL.Add(dtl);
                                }
                            }
                        }
                        if (flag) break;
                    }
                }
                return answer;
            }
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
