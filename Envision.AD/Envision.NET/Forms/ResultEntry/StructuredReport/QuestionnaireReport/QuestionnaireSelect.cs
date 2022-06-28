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
    public partial class QuestionnaireSelect : QuestionnaireBase
    {
        private bool firstCheck;
        private bool isMultiSelect;
        private int index;

        public QuestionnaireSelect()
        {
            InitializeComponent();
            firstCheck = true;
            isMultiSelect = true;
            index = 0;
        }
        public QuestionnaireSelect(SR_QUESTIONS Question, List<SR_QUESTIONSDTL> Details, List<SR_QUESTIONSDTLCHILD> Child, bool FillAnswer, int left, int top,bool CheckBox) 
                                 :base(Question,Details,Child,FillAnswer,left,top)
        {
            InitializeComponent();
            firstCheck = true;
            isMultiSelect = true;
            index = 0;
            isMultiSelect = CheckBox;
        }

        private int drawTextBoxControl(QuestionnaireName nameCtrl,SR_QUESTIONSDTLCHILD dtl,int left,int top)
        {
            TextEdit txt = new TextEdit();
            index++;
            txt.Left = left;
            txt.Top = top;
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
            name.IsForce = dtl.IS_DEFAULT == "Y" ? true : false;
            name.QId = dtl.Q_ID;
            name.QIdDtl = dtl.Q_ID_DTL;
            name.QIdDtlChild = dtl.Q_ID_DTL_CHD;
            nameCtrl.Child.Add(name);
            //
            if (dtl.TEXT_SIZE == "D")
                txt.Width += txt.Width;
            else if (dtl.TEXT_SIZE == "H")
                txt.Width = txt.Width / 2;
            if (FillAnswer)
                txt.Text = dtl.ANSWER;
            else if (!string.IsNullOrEmpty(dtl.DEFAULT_VALUE))
                txt.Text = dtl.DEFAULT_VALUE;
            this.Controls.Add(txt);
            //
            QuestionnaireHelper.AdjustSize(this, txt);
            return txt.Right;
        }
        private int drawMemoEditControl(QuestionnaireName nameCtrl,SR_QUESTIONSDTLCHILD dtl, int left, int top)
        {
            MemoEdit txt = new MemoEdit();
            //txt.Width *= 2;
            txt.Width = 300;
            index++;
            txt.Left = left;
            txt.Top = top;
            txt.Name = "textbox" + index.ToString();

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
            name.QIdDtlChild = dtl.Q_ID_DTL_CHD;
            nameCtrl.Child.Add(name);
            //
            if (dtl.TEXT_SIZE == "D")
                txt.Width += txt.Width;
            else if (dtl.TEXT_SIZE == "H")
                txt.Width = txt.Width / 2;
            if (FillAnswer)
                txt.Text = dtl.ANSWER;
            else if (!string.IsNullOrEmpty(dtl.DEFAULT_VALUE))
                txt.Text = dtl.DEFAULT_VALUE;
            this.Controls.Add(txt);
            //
            QuestionnaireHelper.AdjustSize(this, txt);
            return txt.Right;
        }
        private int drawSpinEditControl(QuestionnaireName nameCtrl, SR_QUESTIONSDTLCHILD dtl, int left, int top)
        {
            SpinEdit txt = new SpinEdit();
            index++;
            txt.Left = left;
            txt.Top = top;
            txt.Name = "textbox" + index.ToString();
            QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(txt.Name, string.Empty);
            name.IsForce = dtl.IS_DEFAULT == "Y" ? true : false;
            name.QId = dtl.Q_ID;
            name.QIdDtl = dtl.Q_ID_DTL;
            name.QIdDtlChild = dtl.Q_ID_DTL_CHD;
            name.Value = dtl.ANSWER;
            nameCtrl.Child.Add(name);
            //  
            if (!string.IsNullOrEmpty(dtl.PROP1))
                txt.Properties.MinValue = Convert.ToDecimal(dtl.PROP1);
            if (!string.IsNullOrEmpty(dtl.TEXT_SIZE))
                txt.Properties.MaxValue = Convert.ToDecimal(dtl.TEXT_SIZE);
            txt.EditValue = 0;
            if (FillAnswer)
                txt.Text = dtl.ANSWER;
            this.Controls.Add(txt);
            //
            QuestionnaireHelper.AdjustSize(this, txt);
            return txt.Right;
        }
        private int drawLabelControl(SR_QUESTIONSDTLCHILD dtl, int left, int top)
        {
            int right = 0;
            if (string.IsNullOrEmpty(dtl.DEFAULT_VALUE) || dtl.DEFAULT_VALUE.Trim().Length == 0) return right;

            Queue<char> lstQueue = new Queue<char>();
            char[] ch = dtl.DEFAULT_VALUE.ToCharArray();
            foreach (char data in ch) lstQueue.Enqueue(data);
            string lastText = string.Empty;
            bool isNeedAdd = true;
            while (lstQueue.Count > 0)
            {
                LabelControl lbl = new LabelControl();
                lbl.UseMnemonic = false;
                lbl.AutoSizeMode = LabelAutoSizeMode.Horizontal;
                lbl.Size = new Size(0, 0);
                lbl.Left = left;
                lbl.Top = top;
                FontStyle fs = FontStyle.Regular;
                if (IsBold) fs |= FontStyle.Bold;
                if (IsItalic) fs |= FontStyle.Italic;
                if (IsUnderline) fs |= FontStyle.Underline;
                Font font = new Font(lbl.Font, fs);
                lbl.Font = font;

                string text = lastText + lstQueue.Peek().ToString();
                //if (QuestionnaireHelper.IsLabelOverline(text, false, false, false, lbl.Left))
                if(false)
                {
                    int r=QuestionnaireHelper.AddLabelControl(this, lastText, left, ref top, false, false, false);
                    right = r > right ? r : right;
                    isNeedAdd = false;
                    lastText = string.Empty;
                }
                else
                {
                    isNeedAdd = true;
                    lastText += lstQueue.Dequeue().ToString();
                }
            }
            if (isNeedAdd && !string.IsNullOrEmpty(lastText))
            {
                int r = QuestionnaireHelper.AddLabelControl(this, lastText, left, ref top, false, false, false);
                right = r > right ? r : right;
            }
            return right;
        }
        private int drawSelectionControls(SR_QUESTIONSDTL dtl, int top, ref int bottom)
        { 
            //check child;
            int right = 0;
            if (isMultiSelect)
            {
                CheckBox chk = new CheckBox();
                index++;
                chk.Name = "checkBox" + index.ToString();
                if (FillAnswer)
                {
                    if (string.IsNullOrEmpty(dtl.ANSWER))
                    {
                        //chk.Checked = false;

                        if (dtl.HAS_CHILD == "Y")
                            foreach (SR_QUESTIONSDTLCHILD child in QuestionDetailsChild)
                                if (child.Q_ID == dtl.Q_ID && child.Q_ID_DTL == dtl.Q_ID_DTL)
                                    if (string.IsNullOrEmpty(child.ANSWER))
                                        chk.Checked = false;
                                    else
                                        chk.Checked = true;
                    }
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
                right = chk.Right + 3;
                bottom = chk.Bottom;
                QuestionnaireHelper.AdjustSize(this, chk);
                //add control Name
                QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(chk.Name, dtl.DEFAULT_VALUE);
                name.QId = dtl.Q_ID;
                name.QIdDtl = dtl.Q_ID_DTL;
                name.IsForce = false;
                name.Value = dtl.DEFAULT_VALUE;
                //
                if (dtl.IsHasImage)
                {
                    right = QuestionnaireHelper.AddImageControl(this, dtl.Image, chk.Right, chk.Top, ref bottom) + 3;
                    bottom += 5;
                }
                if (dtl.HAS_CHILD == "Y") 
                {
                    bottom = chk.Bottom > bottom ? chk.Bottom : bottom;
                    int left = chk.Left;
                    int childTop = bottom;
                    foreach (SR_QUESTIONSDTLCHILD child in QuestionDetailsChild) {
                        if (child.Q_ID == dtl.Q_ID && child.Q_ID_DTL == dtl.Q_ID_DTL) {
                            switch (QuestionTypeHelper.GetQuestionType(child.Q_TYPE_ID))
                            {
                                case QuestionType.QNone:
                                    break;
                                case QuestionType.QLable:
                                    left = drawLabelControl(child,left,childTop);
                                    right = left > right ? left : right;
                                    if (bottom < this.Height) bottom = this.Height + 3;
                                    break;
                                case QuestionType.QMemo:
                                    left = drawMemoEditControl(name, child, left, childTop) + 3;
                                    right = left > right ? left : right;
                                    if (bottom < this.Height) bottom = this.Height + 3;
                                    break;
                                case QuestionType.QNumber:
                                    left = drawSpinEditControl(name, child, left, childTop) + 3;
                                    right = left > right ? left : right;
                                    if (bottom < this.Height) bottom = this.Height + 3;
                                    break;
                                case QuestionType.QText:
                                    left = drawTextBoxControl(name, child, left, childTop) + 3;
                                    right = left > right ? left : right;
                                    if (bottom < this.Height) bottom = this.Height + 3;
                                    break;
                            }
                        }
                    }
                }
                this.ControlName.Add(name);
            }
            else
            {
                RadioButton chk = new RadioButton();
                index++;
                chk.Name = "checkBox" + index.ToString();
                if (FillAnswer)
                {
                    if (string.IsNullOrEmpty(dtl.ANSWER))
                    {
                        //chk.Checked = false;

                        if (dtl.HAS_CHILD == "Y")
                            foreach (SR_QUESTIONSDTLCHILD child in QuestionDetailsChild)
                                if (child.Q_ID == dtl.Q_ID && child.Q_ID_DTL == dtl.Q_ID_DTL)
                                    if (string.IsNullOrEmpty(child.ANSWER))
                                        chk.Checked = false;
                                    else
                                        chk.Checked = true;
                    }
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
                right = chk.Right + 3;
                bottom = chk.Bottom;
                QuestionnaireHelper.AdjustSize(this, chk);
                //add control Name
                QuestionnaireName name = QuestionnaireHelper.AddQuestionnaireName(chk.Name, dtl.DEFAULT_VALUE);
                name.QId = dtl.Q_ID;
                name.QIdDtl = dtl.Q_ID_DTL;
                name.IsForce = false;
                name.Value = dtl.DEFAULT_VALUE;
                //
                if (dtl.IsHasImage)
                {
                    right = QuestionnaireHelper.AddImageControl(this, dtl.Image, chk.Right, chk.Top, ref bottom) + 3;
                    bottom += 5;
                }
                if (dtl.HAS_CHILD == "Y")
                {
                    bottom = chk.Bottom > bottom ? chk.Bottom : bottom;
                    int left = chk.Left;
                    int childTop = bottom;
                    foreach (SR_QUESTIONSDTLCHILD child in QuestionDetailsChild)
                    {
                        if (child.Q_ID == dtl.Q_ID && child.Q_ID_DTL == dtl.Q_ID_DTL)
                        {
                            switch (QuestionTypeHelper.GetQuestionType(child.Q_TYPE_ID))
                            {
                                case QuestionType.QNone:
                                    break;
                                case QuestionType.QLable:
                                    left = drawLabelControl(child, left, childTop);
                                    right = left > right ? left : right;
                                    if (bottom < this.Height) bottom = this.Height + 3;
                                    break;
                                case QuestionType.QMemo:
                                    left = drawMemoEditControl(name, child, left, childTop) + 3;
                                    right = left > right ? left : right;
                                    if (bottom < this.Height) bottom = this.Height + 3;
                                    break;
                                case QuestionType.QNumber:
                                    left = drawSpinEditControl(name, child, left, childTop) + 3;
                                    right = left > right ? left : right;
                                    if (bottom < this.Height) bottom = this.Height + 3;
                                    break;
                                case QuestionType.QText:
                                    left = drawTextBoxControl(name, child, left, childTop) + 3;
                                    right = left > right ? left : right;
                                    if (bottom < this.Height) bottom = this.Height + 3;
                                    break;
                            }
                        }
                    }
                }
                this.ControlName.Add(name);
            }
            return right;
        }
        public override void DrawControl()
        {
            drawQuestionText();
            if (Question.IS_BOLD == "Y" && firstCheck)
            {
                //firstCheck = false;
                //if (IsMultiline)
                //{
                //    CurrentLeft = CurrentLeft + 45;
                //    if (Question.SPACE_BEGIN >= 40) CurrentLeft += 25;
                //}
                //else
                //    CurrentLeft = CurrentLeft + 20;
            }
            int top=CurrentTop;
            int bottom=CurrentBottom;
            int right = 0;
            foreach (SR_QUESTIONSDTL dtl in QuestionDetails) {
                right=drawSelectionControls(dtl, top, ref bottom);
           
                if (Question.QUESTION_SIDE == "H")
                    CurrentLeft = right;
                else 
                    top=CurrentTop = bottom;
                bottom = Height > bottom ? Height : bottom; 
                int w=CurrentLeft > Width? CurrentLeft:Width;
                this.Size = new Size(w+10, bottom);
                
            }
        }

        private bool checkMultiSelect() {
            bool flag = true;
            ControlCollection ctrls = this.Controls;
            foreach (Control c in ctrls) {
                CheckBox chk = c as CheckBox;
                if (chk == null) continue;
                if (chk.Checked) {
                    foreach (QuestionnaireName name in ControlName) {
                        if (chk.Name == name.Name) {
                            foreach (QuestionnaireName child in name.Child) {
                                if (child.IsForce) {
                                    foreach (Control ctrlChild in ctrls) {
                                        if (child.Name == ctrlChild.Name) {
                                            TextEdit txt = ctrlChild as TextEdit;
                                            if (txt != null) {
                                                if(txt.Text.Length>0) 
                                                    continue;
                                                else
                                                    return false;
                                            }
                                            MemoEdit mem = ctrlChild as MemoEdit;
                                            if (mem != null) {
                                                if (mem.Text.Length > 0) 
                                                    continue;
                                                else
                                                    return false;
                                            }
                                            SpinEdit sp = ctrlChild as SpinEdit;
                                            if (sp != null) {
                                                if (sp.EditValue!=null) 
                                                    continue;
                                                else
                                                    return false;
                                            }
                                        }
                                    }
                                }
                            }
                        }//end if chk.Name == name.Name
                    }//foreach
                }//endif
            }
            return flag;
        }
        private bool checkSingleSelect() {
            bool flag = true;
            ControlCollection ctrls = this.Controls;
            foreach (Control c in ctrls)
            {
                RadioButton chk = c as RadioButton;
                if (chk == null) continue;
                if (chk.Checked)
                {
                    foreach (QuestionnaireName name in ControlName)
                    {
                        if (chk.Name == name.Name)
                        {
                            foreach (QuestionnaireName child in name.Child)
                            {
                                if (child.IsForce)
                                {
                                    foreach (Control ctrlChild in ctrls)
                                    {
                                        if (child.Name == ctrlChild.Name)
                                        {
                                            TextEdit txt = ctrlChild as TextEdit;
                                            if (txt != null)
                                            {
                                                if (txt.Text.Length > 0)
                                                    continue;
                                                else
                                                    return false;
                                            }
                                            MemoEdit mem = ctrlChild as MemoEdit;
                                            if (mem != null)
                                            {
                                                if (mem.Text.Length > 0)
                                                    continue;
                                                else
                                                    return false;
                                            }
                                            SpinEdit sp = ctrlChild as SpinEdit;
                                            if (sp != null)
                                            {
                                                if (sp.EditValue != null)
                                                    continue;
                                                else
                                                    return false;
                                            }
                                        }
                                    }
                                }
                            }
                        }//end if chk.Name == name.Name
                    }//foreach
                }//endif
            }
            return flag;
        }

        public override bool IsComplete
        {
            get
            {
                if (isMultiSelect)
                    return checkMultiSelect();
                else
                    return checkSingleSelect();
            }
            protected set
            {
                base.IsComplete = value;
            }
        }
        private string getResponseMultiSelect() {
            string str = string.Empty;
            ControlCollection ctrls = this.Controls;
            foreach (Control c in ctrls)
            {
                CheckBox chk = c as CheckBox;
                if (chk == null) continue;
                if (chk.Checked)
                {
                    foreach (QuestionnaireName name in ControlName)
                    {
                        if (chk.Name == name.Name)
                        {
                            str += " " + name.Value;
                            if (name.Child.Count == 0) continue;
                            List<SR_QUESTIONSDTLCHILD> dtls = new List<SR_QUESTIONSDTLCHILD>();
                            foreach (SR_QUESTIONSDTLCHILD dtl in QuestionDetailsChild) {
                                if (dtl.Q_ID == name.QId && dtl.Q_ID_DTL == name.QIdDtl) 
                                    dtls.Add(dtl);
                            }
                            if (dtls.Count > 0) {
                                str += " ";
                                foreach (SR_QUESTIONSDTLCHILD dtl in dtls) {
                                    switch (QuestionTypeHelper.GetQuestionType(dtl.Q_TYPE_ID)) { 
                                        case QuestionType.QLable:
                                            str += dtl.DEFAULT_VALUE + " ";
                                            break;
                                        default:
                                            string ctrlChildName = string.Empty;
                                            foreach(QuestionnaireName nm in name.Child)
                                                if (nm.QId == dtl.Q_ID && nm.QIdDtl == dtl.Q_ID_DTL && nm.QIdDtlChild == dtl.Q_ID_DTL_CHD)
                                                {
                                                    ctrlChildName = nm.Name;
                                                    break;
                                                }
                                            if (!string.IsNullOrEmpty(ctrlChildName)) { 
                                                //หา child control
                                                foreach (Control ctrlChild in ctrls)
                                                    if (ctrlChild.Name.ToLower() == ctrlChildName) {
                                                        TextEdit txt = ctrlChild as TextEdit;
                                                        if (txt != null)
                                                        {
                                                            str += " " + txt.Text + " ";
                                                            break;
                                                        }
                                                        MemoEdit mem = ctrlChild as MemoEdit;
                                                        if (mem != null)
                                                        {
                                                            str += " " + mem.Text + " ";
                                                            break;
                                                        }
                                                        SpinEdit sp = ctrlChild as SpinEdit;
                                                        if (sp != null)
                                                        {
                                                            str += " " + sp.EditValue.ToString() + " ";
                                                            break;
                                                        }
                                                        DateEdit dt = ctrlChild as DateEdit;
                                                        if (dt != null)
                                                        {
                                                            if (dt.EditValue != null || dt.DateTime != DateTime.MinValue)
                                                            {
                                                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                                                                str += " " + dt.DateTime.ToString("dd MMMM yyyy") + " ";
                                                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
                                                            }
                                                            break;
                                                        }
                                                        LabelControl lbl = ctrlChild as LabelControl;
                                                        if (lbl != null)
                                                        {
                                                            str += " " + lbl.Text + " ";
                                                            break;
                                                        }
                                                        break;
                                                    }
                                                //
                                            }
                                            break;
                                    }
                                }
                            }
                        }//end if chk.Name == name.Name
                    }//foreach
                }//endif
            }
            return str;
        }
        private string getResponseSingleSelect()
        {
            string str = string.Empty;
            ControlCollection ctrls = this.Controls;
            foreach (Control c in ctrls)
            {
                RadioButton chk = c as RadioButton;
                if (chk == null) continue;
                if (chk.Checked)
                {
                    foreach (QuestionnaireName name in ControlName)
                    {
                        if (chk.Name == name.Name)
                        {
                            str += " " + name.Value;
                            if (name.Child.Count == 0) continue;
                            List<SR_QUESTIONSDTLCHILD> dtls = new List<SR_QUESTIONSDTLCHILD>();
                            foreach (SR_QUESTIONSDTLCHILD dtl in QuestionDetailsChild)
                            {
                                if (dtl.Q_ID == name.QId && dtl.Q_ID_DTL == name.QIdDtl)
                                    dtls.Add(dtl);
                            }
                            if (dtls.Count > 0)
                            {
                                str += " ";
                                foreach (SR_QUESTIONSDTLCHILD dtl in dtls)
                                {
                                    switch (QuestionTypeHelper.GetQuestionType(dtl.Q_TYPE_ID))
                                    {
                                        case QuestionType.QLable:
                                            str += dtl.DEFAULT_VALUE + " ";
                                            break;
                                        default:
                                            string ctrlChildName = string.Empty;
                                            foreach (QuestionnaireName nm in name.Child)
                                                if (nm.QId == dtl.Q_ID && nm.QIdDtl == dtl.Q_ID_DTL && nm.QIdDtlChild == dtl.Q_ID_DTL_CHD)
                                                {
                                                    ctrlChildName = nm.Name;
                                                    break;
                                                }
                                            if (!string.IsNullOrEmpty(ctrlChildName))
                                            {
                                                //หา child control
                                                foreach (Control ctrlChild in ctrls)
                                                    if (ctrlChild.Name.ToLower() == ctrlChildName)
                                                    {
                                                        TextEdit txt = ctrlChild as TextEdit;
                                                        if (txt != null)
                                                        {
                                                            str += " " + txt.Text + " ";
                                                            break;
                                                        }
                                                        MemoEdit mem = ctrlChild as MemoEdit;
                                                        if (mem != null)
                                                        {
                                                            str += " " + mem.Text + " ";
                                                            break;
                                                        }
                                                        SpinEdit sp = ctrlChild as SpinEdit;
                                                        if (sp != null)
                                                        {
                                                            str += " " + sp.EditValue.ToString() + " ";
                                                            break;
                                                        }
                                                        DateEdit dt = ctrlChild as DateEdit;
                                                        if (dt != null)
                                                        {
                                                            if (dt.EditValue != null || dt.DateTime != DateTime.MinValue)
                                                            {
                                                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                                                                str += " " + dt.DateTime.ToString("dd MMMM yyyy") + " ";
                                                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
                                                            }
                                                            break;
                                                        }
                                                        LabelControl lbl = ctrlChild as LabelControl;
                                                        if (lbl != null)
                                                        {
                                                            str += " " + lbl.Text + " ";
                                                            break;
                                                        }
                                                        break;
                                                    }
                                                //
                                            }
                                            break;
                                    }
                                }
                            }
                        }//end if chk.Name == name.Name
                    }//foreach
                }//endif
            }
            return str;
        }
        public override GenerateQuestionnaireText ResponseTextCollections(bool AppendNext)
        {
            
                GenerateQuestionnaireText q = new GenerateQuestionnaireText();
                q.PartId = Question.PART_ID;
                q.QId = Question.Q_ID;
                q.QIdDtl = 0;
                q.QIdDtlChild = 0;
                string str = string.Empty;
                for (int i = 0; i < Question.SPACE_BEGIN; i++)
                    str += " ";
                str += Question.QUESTION_TEXT;
                q.QuestionText = str;
                str = " ";
                if (isMultiSelect)
                    str += getResponseMultiSelect();
                else
                    str += getResponseSingleSelect();
                if (AppendNext)
                    str += " ";
                else
                    str += "\r\n";
                q.QuestionAck = str;
                q.IsAppendNext = AppendNext;
                q.IsBold = Question.IS_BOLD == "Y" ? true : false;
                q.IsItalic = Question.IS_ITALIC == "Y" ? true : false;
                q.IsUnderLine = Question.IS_UNDERLINE == "Y" ? true : false;
                return q;
           
        }
        public override Answer ResponseAnswer
        {
            get
            {
                Answer answer = new Answer();
                ControlCollection ctrls = this.Controls;
                answer.SR_QUESTIONSANSWERS.Q_ID = Question.Q_ID;
                answer.SR_QUESTIONSANSWERS.PART_ID = Question.PART_ID;
                foreach (QuestionnaireName name in ControlName)
                {
                    bool flag = false;
                    foreach (Control c in ctrls)
                    {
                        if (string.IsNullOrEmpty(c.Name)) continue;
                        if (c.Name.ToLower() == name.Name.ToLower())
                        {
                            flag = true;
                          
                            if (isMultiSelect)
                            {
                                #region CheckBox
                                CheckBox chk = c as CheckBox;
                                if (chk == null) continue;
                                if (chk.Checked)
                                {
                                    SR_QUESTIONSANSWERSDTL qAnsDtl = new SR_QUESTIONSANSWERSDTL();
                                    qAnsDtl.Q_ID = name.QId;
                                    qAnsDtl.Q_ID_DTL = name.QIdDtl;
                                    qAnsDtl.ANSWER = name.Value;
                                    answer.SR_QUESTIONSANSWERSDTL.Add(qAnsDtl);

                                    foreach (QuestionnaireName child in name.Child)
                                    {
                                        if (child == null) continue;

                                        foreach (Control ctrlChild in ctrls)
                                        {
                                            if (ctrlChild.Name == child.Name)
                                            {
                                                SR_QUESTIONSANSWERSDTLCHILD itemChild = new SR_QUESTIONSANSWERSDTLCHILD();
                                                itemChild.Q_ID = child.QId;
                                                itemChild.Q_ID_DTL = child.QIdDtl;
                                                itemChild.Q_ID_DTL_CHD = child.QIdDtlChild;

                                                TextEdit txt = ctrlChild as TextEdit;
                                                if (txt != null)
                                                {
                                                    itemChild.ANSWER = txt.Text;
                                                    answer.SR_QUESTIONSANSWERSDTLCHILD.Add(itemChild);
                                                    break;
                                                }
                                                MemoEdit mem = ctrlChild as MemoEdit;
                                                if (mem != null)
                                                {
                                                    itemChild.ANSWER = mem.Text;
                                                    answer.SR_QUESTIONSANSWERSDTLCHILD.Add(itemChild);
                                                    break;
                                                }
                                                SpinEdit sp = ctrlChild as SpinEdit;
                                                if (sp != null)
                                                {
                                                    itemChild.ANSWER = sp.Text;
                                                    answer.SR_QUESTIONSANSWERSDTLCHILD.Add(itemChild);
                                                    break;
                                                }
                                                DateEdit dt = ctrlChild as DateEdit;
                                                if (dt != null)
                                                {
                                                    if (dt.EditValue != null || dt.DateTime != DateTime.MinValue)
                                                    {

                                                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                                                        itemChild.ANSWER += " " + dt.DateTime.ToString("dd/MMMM/yyyy") + " ";
                                                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
                                                        answer.SR_QUESTIONSANSWERSDTLCHILD.Add(itemChild);
                                                    }
                                                    break;
                                                }

                                            }
                                        }
                                    }
                                } 
                                #endregion
                            }
                            else 
                            {
                                #region RadioBotton
                                RadioButton chk = c as RadioButton;
                                if (chk == null) continue;
                                if (chk.Checked)
                                {
                                    SR_QUESTIONSANSWERSDTL qAnsDtl = new SR_QUESTIONSANSWERSDTL();
                                    qAnsDtl.Q_ID = name.QId;
                                    qAnsDtl.Q_ID_DTL = name.QIdDtl;
                                    qAnsDtl.ANSWER = name.Value;
                                    answer.SR_QUESTIONSANSWERSDTL.Add(qAnsDtl);

                                    foreach (QuestionnaireName child in name.Child)
                                    {
                                        if (child == null) continue;

                                        foreach (Control ctrlChild in ctrls)
                                        {
                                            if (ctrlChild.Name == child.Name)
                                            {
                                                SR_QUESTIONSANSWERSDTLCHILD itemChild = new SR_QUESTIONSANSWERSDTLCHILD();
                                                itemChild.Q_ID = child.QId;
                                                itemChild.Q_ID_DTL = child.QIdDtl;
                                                itemChild.Q_ID_DTL_CHD = child.QIdDtlChild;

                                                TextEdit txt = ctrlChild as TextEdit;
                                                if (txt != null)
                                                {
                                                    itemChild.ANSWER = txt.Text;
                                                    answer.SR_QUESTIONSANSWERSDTLCHILD.Add(itemChild);
                                                    break;
                                                }
                                                MemoEdit mem = ctrlChild as MemoEdit;
                                                if (mem != null)
                                                {
                                                    itemChild.ANSWER = mem.Text;
                                                    answer.SR_QUESTIONSANSWERSDTLCHILD.Add(itemChild);
                                                    break;
                                                }
                                                SpinEdit sp = ctrlChild as SpinEdit;
                                                if (sp != null)
                                                {
                                                    itemChild.ANSWER = sp.Text;
                                                    answer.SR_QUESTIONSANSWERSDTLCHILD.Add(itemChild);
                                                    break;
                                                }
                                                DateEdit dt = ctrlChild as DateEdit;
                                                if (dt != null)
                                                {
                                                    if (dt.EditValue != null || dt.DateTime != DateTime.MinValue)
                                                    {

                                                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                                                        itemChild.ANSWER += " " + dt.DateTime.ToString("dd/MMMM/yyyy") + " ";
                                                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
                                                        answer.SR_QUESTIONSANSWERSDTLCHILD.Add(itemChild);
                                                    }
                                                    break;
                                                }

                                            }
                                        }
                                    }
                                } 
                                #endregion
                            }
                        }
                        if (flag) break;
                    }
                }
                return answer;
            }
        }
    }
}
