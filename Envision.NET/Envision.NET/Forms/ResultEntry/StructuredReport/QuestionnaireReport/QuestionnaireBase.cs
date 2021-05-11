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
    public class QuestionnaireBase : UserControl
    {
    
        public int QIndex { get; set; }
        public int CurrentLeft { get; set; }
        public int CurrentRight { get; set; }
        public int CurrentTop { get; set; }
        public int CurrentBottom { get; set; }

        public bool FillAnswer { get; set; }
        public virtual bool IsComplete { get; protected set; }
        //public bool IsHasImage { get; set; }
        public bool IsQuestionnareComplete { get; private set; }
        
        //protected Image ImageData { get; set; }
        protected SR_QUESTIONS Question { get; set; }
        protected List<SR_QUESTIONSDTL> QuestionDetails { get; set; }
        protected List<SR_QUESTIONSDTLCHILD> QuestionDetailsChild { get; set; }
        protected List<QuestionnaireName> ControlName;
        protected bool IsBold { get; set; }
        protected bool IsItalic { get; set; }
        protected bool IsUnderline { get; set; }
        protected bool IsMultiline { get; set; }

        private void initiateData() { 
            QIndex = 0;
            CurrentLeft = CurrentRight = CurrentTop = CurrentBottom = 0;
           
            FillAnswer = false;
            IsQuestionnareComplete = false;

            Question = new SR_QUESTIONS();
            QuestionDetails = new List<SR_QUESTIONSDTL>();
            QuestionDetailsChild = new List<SR_QUESTIONSDTLCHILD>();
            ControlName = new List<QuestionnaireName>();
            IsBold = IsItalic = IsUnderline = false;
            IsMultiline = false;
            InitializeComponent();
        }

        public QuestionnaireBase() {
            initiateData();
        }
        public QuestionnaireBase(SR_QUESTIONS Question,List<SR_QUESTIONSDTL> Details,List<SR_QUESTIONSDTLCHILD> Child,bool FillAnswer,int left,int top)
        {
            initiateData();
            this.Question = Question;
            this.QuestionDetails = Details;
            this.QuestionDetailsChild = Child;

            this.FillAnswer = FillAnswer;
            IsBold = Question.IS_BOLD == "Y" ? true : false;
            IsItalic = Question.IS_ITALIC == "Y" ? true : false;
            IsUnderline = Question.IS_UNDERLINE == "Y" ? true : false;
            CurrentLeft = left;
            CurrentTop = top;
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // QuestionnaireBase
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "QuestionnaireBase";
            this.Size = new System.Drawing.Size(0, 0);
            this.Load += new System.EventHandler(this.QuestionnaireBase_Load);
            this.ResumeLayout(false);

        }
        
        
        protected void drawQuestionText() {
            if (string.IsNullOrEmpty(Question.QUESTION_TEXT.Trim())) return;

            Queue<char> lstQueue = new Queue<char>();
            char[] ch = Question.QUESTION_TEXT.ToCharArray();
            for (int i = 0; i < Question.SPACE_BEGIN; i++) lstQueue.Enqueue(' ');
            foreach (char data in ch) lstQueue.Enqueue(data);
            string lastText = string.Empty;
            bool isNeedAdd = true;
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
                if (QuestionnaireHelper.IsLabelOverline(text, IsBold, IsItalic, IsUnderline))
                {
                    int top = CurrentTop;
                    if (IsBold)
                    {
                        string s = lastText.Substring(lastText.Length - 28);
                        lastText = lastText.Substring(0, lastText.Length - 28);
                        char[] data = s.ToCharArray();
                        Queue<char> tmpLst = new Queue<char>();
                        tmpLst = lstQueue;
                        lstQueue = new Queue<char>();
                        foreach (char c in data)
                            lstQueue.Enqueue(c);
                        while (tmpLst.Count > 0)
                            lstQueue.Enqueue(tmpLst.Dequeue());
                    }
                    QuestionnaireHelper.AddLabelControl(this, lastText, CurrentLeft, ref top, IsBold, IsItalic, IsUnderline, QuestionnaireHelper.BaseWidth - 40);
                    isNeedAdd = false;
                    lastText = string.Empty;
                    CurrentLeft = QuestionnaireHelper.LEFT_SPACE;
                    CurrentTop = top;
                    IsMultiline = true;
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
                CurrentLeft = QuestionnaireHelper.AddLabelControl(this, lastText, CurrentLeft, ref top, IsBold, IsItalic, IsUnderline);
                if (CurrentLeft > QuestionnaireHelper.BaseWidth - 40) 
                    CurrentLeft = QuestionnaireHelper.LEFT_SPACE;
            }
        }
        protected int addImageToControl(int left,ref int bottom) {
            return 0;
        }
        

        private void QuestionnaireBase_Load(object sender, EventArgs e)
        {
           
        }
        public virtual void DrawControl()
        {
            throw new Exception("Method DrawControl() is not implementation");
        }
        public virtual GenerateQuestionnaireText ResponseTextCollections(bool AppendNext)
        {
            return null;
        }
        public virtual Answer ResponseAnswer { get; private set; }
        public bool IsAppendNext {
            get {
                bool flag = false;
                if (Question.APPEND_NEXT == "Y") flag = true;
                return flag;
            }
        }


        protected void drawQuestionText11_OLD() {
            CurrentLeft = 3;
            if (string.IsNullOrEmpty(Question.QUESTION_TEXT.Trim())) {
                if (Question.SPACE_BEGIN == 0) return;
            }
            Queue<char> lstQueue = new Queue<char>();
            char[] ch = Question.QUESTION_TEXT.ToCharArray();
            for (int i = 0; i < Question.SPACE_BEGIN; i++) lstQueue.Enqueue(' ');
            foreach (char data in ch) lstQueue.Enqueue(data);
            string lastText = string.Empty;
            while (lstQueue.Count > 0)
            {
                LabelControl lbl = new LabelControl();
                lbl.UseMnemonic = false;
                lbl.AutoSizeMode = LabelAutoSizeMode.Horizontal;
                lbl.Size = new Size(0, 0);
                FontStyle fs = FontStyle.Regular;
                if (IsBold) fs |= FontStyle.Bold;
                if (IsItalic) fs |= FontStyle.Italic;
                if (IsUnderline) fs |= FontStyle.Underline;
                Font font = new Font(lbl.Font, fs);
                lbl.Font = font;
                lbl.Text = lstQueue.Dequeue().ToString();
                lbl.Top = CurrentBottom;
                
                lbl.Left = CurrentLeft;
               // this.panelCtrl.Controls.Add(lbl);

                int w = this.Right > lbl.Right ? this.Right : lbl.Right;
                int h = this.Bottom > lbl.Bottom ? this.Bottom : lbl.Bottom;
                this.Size = new Size(w, h);
            }
        }
    }
}
