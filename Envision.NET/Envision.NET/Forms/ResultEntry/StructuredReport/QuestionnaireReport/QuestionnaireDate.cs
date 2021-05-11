using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

using Envision.Common;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.Common;
namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport
{
    public partial class QuestionnaireDate : QuestionnaireBase
    {
        private int imgBottom;
        private int imgLeft;
        private bool firstCheck;

        public QuestionnaireDate()
        {
            InitializeComponent();
            firstCheck = true;
        }
        public QuestionnaireDate(SR_QUESTIONS Question, List<SR_QUESTIONSDTL> Details, List<SR_QUESTIONSDTLCHILD> Child, bool FillAnswer,int left,int top) 
                                 :base(Question,Details,Child,FillAnswer,left,top)
        {
            InitializeComponent();
            firstCheck = true;
        }

        private void drawDateControl() {
            imgBottom=0;
            imgLeft = CurrentLeft;
            DateEdit dt = new DateEdit();
            dt.Name = "dateEdit1";
            //if (Question.IS_BOLD == "Y" && firstCheck)
            //{
            //    if (IsMultiline)
            //        dt.Left = CurrentLeft + 10;//+ 25;
            //    else
            //        dt.Left = CurrentLeft + 20;
            //}
            //else
                dt.Left = CurrentLeft;
            dt.Top = CurrentTop;
            dt.Width += 25;
            QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(dt.Name, string.Empty);
            name.IsForce = Question.IS_DEFAULT == "Y" ? true : false;
            name.QId = Question.Q_ID;
            name.QIdDtl = 0;
            name.QIdDtlChild = 0;
            this.ControlName.Add(name);
            if (FillAnswer)
            {
                if (!string.IsNullOrEmpty(Question.ANSWER))
                {
                    string[] date = Question.ANSWER.Split('/'.ToString().ToCharArray());
                    int year = Convert.ToInt32(date[0]);
                    int month = Convert.ToInt32(date[1]);
                    int day = Convert.ToInt32(date[2]);
                    dt.DateTime = new DateTime(year, month, day, 0, 0, 0);
                    if (dt.DateTime == DateTime.MinValue)
                        dt.EditValue = null;
                }
                else
                    dt.EditValue = null;
            }
            else
            {
                if (Question.IS_DEFAULT == "Y")
                    dt.DateTime = DateTime.Now;
                else
                    dt.EditValue = null;
            }
            dt.Properties.DisplayFormat.FormatString = "dd MMMMM yyyy";
            dt.Properties.EditFormat.FormatString = "dd MMMMM yyyy";
            this.Controls.Add(dt);
            CurrentLeft = dt.Right + 3;
            imgBottom = dt.Bottom + 3;
            QuestionnaireHelper.AdjustSize(this, dt);
        }
        public override void DrawControl()
        {
            drawQuestionText();
            if (QuestionDetails.Count>0)
            {
                SR_QUESTIONSDTL dtl = this.QuestionDetails[0];
                int bottom = 0;
                switch (dtl.IMG_POSITION) { 
                    case "L" :
                        if (Question.IS_BOLD == "Y")
                        {
                            //firstCheck = false;
                            //if (IsMultiline)
                            //    CurrentLeft = CurrentLeft + 10;// + 25;
                            //else
                            //    CurrentLeft = CurrentLeft;// +20;
                        }
                        int right = QuestionnaireHelper.AddImageControl(this, dtl.Image, CurrentLeft, CurrentTop,ref bottom);
                        CurrentLeft = right + 3;
                        drawDateControl();
                        break;
                    case "R":
                        drawDateControl();
                        QuestionnaireHelper.AddImageControl(this, dtl.Image, CurrentLeft, CurrentTop, ref bottom);
                        break;
                    case "T":
                        if (Question.IS_BOLD == "Y")
                        {
                            //firstCheck = false;
                            //if (IsMultiline)
                            //    CurrentLeft = CurrentLeft + 10;// + 25;
                            //else
                            //    CurrentLeft = CurrentLeft;// +20;
                        }
                        QuestionnaireHelper.AddImageControl(this, dtl.Image, CurrentLeft, CurrentTop, ref bottom);
                        CurrentTop = bottom + 3;
                        drawDateControl();
                        break;
                    case "B":
                        drawDateControl();
                        QuestionnaireHelper.AddImageControl(this, dtl.Image, imgLeft, imgBottom, ref bottom);
                        break;
                }
            }
            else
                drawDateControl();
        }
        public override bool IsComplete
        {
            get
            {
                bool flag = true;
                QuestionnaireName name = ControlName[0];
                if (name.IsForce) {
                    ControlCollection ctrls = this.Controls;
                    foreach (Control c in ctrls) {
                        if (c.Name.ToLower() == name.Name.ToLower()) {
                            try
                            {
                                DateEdit dt = c as DateEdit;
                                if (dt.EditValue == null)
                                    flag = false;
                                else if (dt.DateTime == DateTime.MinValue)
                                    flag = false;
                            }
                            catch {
                                flag = false;
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
                    if (ctrl.Name == "dateEdit1")
                    {
                        DateEdit dt = ctrl as DateEdit;
                        if (dt == null) continue;
                        if (dt.EditValue == null || dt.DateTime == DateTime.MinValue) continue;
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                        str += " " + dt.DateTime.ToString("dd MMMM yyyy");
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
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
                return rep;
           
        }
        public override Answer ResponseAnswer
        {
            get
            {
                Answer answer = new Answer();
                ControlCollection ctrls = this.Controls;
                answer.SR_QUESTIONSANSWERS.Q_ID = Question.Q_ID;
                answer.SR_QUESTIONSANSWERS.PART_ID = Question.PART_ID;
                foreach (QuestionnaireName name in ControlName) {
                    bool flag = false;
                    foreach (Control ctrl in ctrls) {
                        if (ctrl.Name.ToLower() == name.Name.ToLower()) {
                            DateEdit dt = ctrl as DateEdit;
                            if (dt == null) break;
                            string str = dt.DateTime.Year.ToString() + "/";
                            str += dt.DateTime.Month.ToString().Length == 2 ? dt.DateTime.Month.ToString() : "0" + dt.DateTime.Month.ToString();
                            str += "/";
                            str += dt.DateTime.Day.ToString().Length == 2 ? dt.DateTime.Day.ToString() : "0" + dt.DateTime.Day.ToString();
                            
                            SR_QUESTIONSANSWERSDTL dtl = new SR_QUESTIONSANSWERSDTL();
                            dtl.Q_ID = name.QId;
                            dtl.ANSWER = str;
                            answer.SR_QUESTIONSANSWERSDTL.Add(dtl);

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
