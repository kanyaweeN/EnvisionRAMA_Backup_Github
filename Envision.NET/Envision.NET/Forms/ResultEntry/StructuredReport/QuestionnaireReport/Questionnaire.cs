using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.Common;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.Common;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport
{
    public partial class Questionnaire : UserControl
    {
        public int PartId { get; set; }
        public int PartIndex { get; set; }
        private DataSet dsData;
        private bool fillAnswer;
        private int currentLeft;
        private int currentTop;

        public Questionnaire()
        {
            InitializeComponent();
            PartIndex = 0;
            dsData = null;
            fillAnswer = false;
            currentLeft = currentTop = 0;
        }
        public Questionnaire(int PartId,DataSet Data,string AccessionNo)
        {
            InitializeComponent();
            dsData = Data;
            PartIndex = 0;
            fillAnswer = string.IsNullOrEmpty(AccessionNo) ? false : true;
            this.PartId = PartId;
            currentLeft = 3;
            currentTop = 0;
        }

        private void Questionnaire_Load(object sender, EventArgs e)
        {
            addPartText();
            addQuestionnaire();
        }
        
        private void addPartText() {
            DataView dv = new DataView(dsData.Tables[1]);
            dv.RowFilter = "PART_ID=" + PartId;
            DataTable dtt = dv.ToTable();
            lblPart.Text = dtt.Rows[0]["PART_NAME"].ToString();
            currentTop = lblPart.Bottom + QuestionnaireHelper.NEWLINE_SPACE;
            AdjustSize();
        }
        private SR_QUESTIONS getQuestion(int QId,int QTypeId)
        {
            DataView dv=new DataView(dsData.Tables[2]);
            dv.RowFilter="Q_ID=" + QId;
            DataTable dtt=dv.ToTable();

            SR_QUESTIONS q = new SR_QUESTIONS();
            q.APPEND_NEXT=dtt.Rows[0]["APPEND_NEXT"].ToString();
            q.DEFAULT_VALUE = dtt.Rows[0]["DEFAULT_VALUE"].ToString();
            q.IS_BOLD = dtt.Rows[0]["IS_BOLD"].ToString();
            q.IS_DEFAULT = dtt.Rows[0]["IS_DEFAULT"].ToString();
            q.IS_ITALIC = dtt.Rows[0]["IS_ITALIC"].ToString();
            q.IS_UNDERLINE = dtt.Rows[0]["IS_UNDERLINE"].ToString();
            q.LABEL = dtt.Rows[0]["LABEL"].ToString();
            q.PART_ID = Convert.ToInt32(dtt.Rows[0]["PART_ID"].ToString());
            q.Q_TYPE_ID = QTypeId;
            q.Q_ID = QId;
            q.QUESTION_SIDE = dtt.Rows[0]["QUESTION_SIDE"].ToString();
            q.QUESTION_TEXT = dtt.Rows[0]["QUESTION_TEXT"].ToString();
            q.SPACE_BEGIN = Convert.ToInt32(dtt.Rows[0]["SPACE_BEGIN"].ToString());
            q.ANSWER = dtt.Rows[0]["ANSWER"].ToString();
            return q;
        }
        private List<SR_QUESTIONSDTL> getQuestionDetails(int QId)
        {
            List<SR_QUESTIONSDTL> lst = new List<SR_QUESTIONSDTL>();
            DataView dv = new DataView(dsData.Tables[3]);
            dv.RowFilter = "Q_ID=" + QId;
            DataTable dtt = dv.ToTable();
            foreach (DataRow rowHandle in dtt.Rows) {
                SR_QUESTIONSDTL item = new SR_QUESTIONSDTL();
                item.DEFAULT_VALUE = rowHandle["DEFAULT_VALUE"].ToString();
                item.HAS_CHILD = rowHandle["HAS_CHILD"].ToString();
                item.IMG_POSITION = rowHandle["IMG_POSITION"].ToString();
                item.IS_DEFAULT = rowHandle["IS_DEFAULT"].ToString();
                item.LABEL = rowHandle["LABEL"].ToString();
                item.Q_ID = QId;
                item.Q_ID_DTL = Convert.ToInt32(rowHandle["Q_ID_DTL"].ToString());
                item.TEXT_SIZE = rowHandle["TEXT_SIZE"].ToString();
                item.ANSWER = rowHandle["ANSWER"].ToString();
                item.PROP1 = rowHandle["PROP1"].ToString();

                if (string.IsNullOrEmpty(rowHandle["IMG_DATA"].ToString()))
                {
                    item.IsHasImage = false;
                    item.Image = null;
                }
                else {
                    item.IsHasImage = true;
                    item.Image = QuestionnaireHelper.ConvertByteImage(rowHandle["IMG_DATA"]);
                    if (item.Image == null)
                        item.IsHasImage = false;
                }
                lst.Add(item);
            }
            return lst;
        }
        private List<SR_QUESTIONSDTL> getQuestionDetailsFromDate(int QId)
        {
            List<SR_QUESTIONSDTL> lst = new List<SR_QUESTIONSDTL>();
            string answer = dsData.Tables[2].Rows[0]["ANSWER"].ToString();
            DataView dv = new DataView(dsData.Tables[3]);
            dv.RowFilter = "Q_ID=" + QId;
            DataTable dtt = dv.ToTable();
            foreach (DataRow rowHandle in dtt.Rows)
            {
                SR_QUESTIONSDTL item = new SR_QUESTIONSDTL();
                item.DEFAULT_VALUE = rowHandle["DEFAULT_VALUE"].ToString();
                item.HAS_CHILD = rowHandle["HAS_CHILD"].ToString();
                item.IMG_POSITION = rowHandle["IMG_POSITION"].ToString();
                item.IS_DEFAULT = rowHandle["IS_DEFAULT"].ToString();
                item.LABEL = rowHandle["LABEL"].ToString();
                item.Q_ID = QId;
                item.Q_ID_DTL = Convert.ToInt32(rowHandle["Q_ID_DTL"].ToString());
                item.TEXT_SIZE = rowHandle["TEXT_SIZE"].ToString();
                item.ANSWER = answer;
                item.PROP1 = rowHandle["PROP1"].ToString();

                if (string.IsNullOrEmpty(rowHandle["IMG_DATA"].ToString()))
                {
                    item.IsHasImage = false;
                    item.Image = null;
                }
                else
                {
                    item.IsHasImage = true;
                    item.Image = QuestionnaireHelper.ConvertByteImage(rowHandle["IMG_DATA"]);
                    if (item.Image == null)
                        item.IsHasImage = false;
                }
                lst.Add(item);
            }
            return lst;
        }
        private List<SR_QUESTIONSDTLCHILD> getQuestionDetailsChild(int QId)
        {
            List<SR_QUESTIONSDTLCHILD> lst = new List<SR_QUESTIONSDTLCHILD>();
            DataView dv = new DataView(dsData.Tables[4]);
            dv.RowFilter = "Q_ID=" + QId;
            DataTable dtt = dv.ToTable();
            foreach (DataRow rowHandle in dtt.Rows)
            {
                SR_QUESTIONSDTLCHILD item = new SR_QUESTIONSDTLCHILD();
                item.DEFAULT_VALUE = rowHandle["DEFAULT_VALUE"].ToString();
                item.IMG_POSITION = rowHandle["IMG_POSITION"].ToString();
                item.IS_DEFAULT = rowHandle["IS_DEFAULT"].ToString();
                item.LABEL = rowHandle["LABEL"].ToString();
                item.Q_ID = QId;
                item.Q_ID_DTL = Convert.ToInt32(rowHandle["Q_ID_DTL"].ToString());
                item.Q_ID_DTL_CHD = Convert.ToInt32(rowHandle["Q_ID_DTL_CHD"].ToString());
                item.Q_TYPE_ID = Convert.ToInt32(rowHandle["Q_TYPE_ID"].ToString());
                item.QUESION_SIDE = rowHandle["QUESTION_SIDE"].ToString();
                item.TEXT_SIZE = rowHandle["TEXT_SIZE"].ToString();
                item.ANSWER = rowHandle["ANSWER"].ToString();
                item.PROP1 = rowHandle["PROP1"].ToString();
                if (string.IsNullOrEmpty(rowHandle["IMG_DATA"].ToString()))
                {
                    item.IsHasImage = false;
                    item.Image = null;
                }
                else
                {
                    item.IsHasImage = true;
                    item.Image = QuestionnaireHelper.ConvertByteImage(rowHandle["IMG_DATA"]);
                    if (item.Image == null)
                        item.IsHasImage = false;
                }
                lst.Add(item);
            }
            return lst;
        }
        private QuestionnaireBase generateQuestionnaire(int QTypeId,int QId) {
            QuestionnaireBase qn = null;
            SR_QUESTIONS q = null;
            List<SR_QUESTIONSDTL> dtl=null;
            List<SR_QUESTIONSDTLCHILD> child =null;
            switch (QuestionTypeHelper.GetQuestionType(QTypeId)) { 
                case QuestionType.QNone:
                    break;
                case QuestionType.QCheck:
                    q = getQuestion(QId,QTypeId);
                    dtl = getQuestionDetails(QId);
                    child = getQuestionDetailsChild(QId);
                    qn = new QuestionnaireSelect(q, dtl, child, fillAnswer, currentLeft, currentTop, true);
                    break;
                case QuestionType.QDate:
                    q = getQuestion(QId, QTypeId);
                    dtl = getQuestionDetailsFromDate(QId);
                    child = getQuestionDetailsChild(QId);
                    qn = new QuestionnaireDate(q, dtl, child, fillAnswer, currentLeft, currentTop);
                    break;
                case QuestionType.QGroup:
                    q = getQuestion(QId, QTypeId);
                    dtl = getQuestionDetails(QId);
                    child = getQuestionDetailsChild(QId);
                    qn = new QuestionnaireGroup(q, dtl, child, fillAnswer, currentLeft, currentTop);
                    break;
                case QuestionType.QLable:
                    q = getQuestion(QId, QTypeId);
                    dtl = getQuestionDetails(QId);
                    child= getQuestionDetailsChild(QId);
                    qn = new QuestionnaireLabel(q, dtl, child, fillAnswer,currentLeft,currentTop);
                    break;
                case QuestionType.QMemo:
                    q = getQuestion(QId, QTypeId);
                    dtl = getQuestionDetails(QId);
                    child = getQuestionDetailsChild(QId);
                    qn = new QuestionnaireMemoEdit(q, dtl, child, fillAnswer, currentLeft, currentTop);
                    break;
                case QuestionType.QNColumn:
                    q = getQuestion(QId, QTypeId);
                    dtl = getQuestionDetails(QId);
                    child = getQuestionDetailsChild(QId);
                    qn = new QuestionnaireMultiColumns(q, dtl, child, fillAnswer, currentLeft, currentTop);
                    break;
                case QuestionType.QNumber:
                    q = getQuestion(QId, QTypeId);
                    dtl = getQuestionDetails(QId);
                    child = getQuestionDetailsChild(QId);
                    qn = new QuestionnaireSpinEdit(q, dtl, child, fillAnswer, currentLeft, currentTop);
                    break;
                case QuestionType.QRadio:
                    q = getQuestion(QId, QTypeId);
                    dtl = getQuestionDetails(QId);
                    child = getQuestionDetailsChild(QId);
                    qn = new QuestionnaireSelect(q, dtl, child, fillAnswer, currentLeft, currentTop, false);
                    break;
                case QuestionType.QText:
                    q = getQuestion(QId, QTypeId);
                    dtl = getQuestionDetails(QId);
                    child = getQuestionDetailsChild(QId);
                    qn = new QuestionnaireTextBox(q, dtl, child, fillAnswer, currentLeft, currentTop);
                    break;
            }
            return qn;
        }
        private void addQuestionnaire() {
            if (dsData.Tables[2].Rows.Count == 0) return;
            DataView dv=new DataView(dsData.Tables[2]);
            dv.RowFilter = "PART_ID=" + this.PartId;
            DataTable dtt = dv.ToTable();
            int currentLeft = 0;
            int width = 0;
            bool appendNext = false;
            for (int i = 0; i < dtt.Rows.Count; i++) {
                
                int qId= Convert.ToInt32(dtt.Rows[i]["Q_ID"].ToString());
                int qTypeId=Convert.ToInt32(dtt.Rows[i]["Q_TYPE_ID"].ToString());
                QuestionnaireBase qn = generateQuestionnaire(qTypeId, qId);
                if (qn == null) continue;

                string sss = dtt.Rows[i]["QUESTION_TEXT"].ToString();


                qn.DrawControl();
                qn.QIndex=i;
                qn.Left = currentLeft;
                this.Controls.Add(qn);
                int w =width + qn.Right;
                if (this.Right > w) w = this.Right;
                int h = this.Height > qn.Height ? this.Height : qn.Height;
                this.Size = new Size(w,h);
                if (appendNext)
                {
                    if (qn is QuestionnaireLabel)
                        this.Size = new Size(this.Width, this.Height + 8);
                }
                if (dtt.Rows[i]["APPEND_NEXT"].ToString() == "Y")
                {
                    currentLeft = qn.Right;
                    width = qn.Right;
                    appendNext = true;
                }
                else
                {
                    currentTop = qn.Bottom + QuestionnaireHelper.NEWLINE_SPACE;
                    if (qn is QuestionnaireLabel)
                        currentTop += 8;
                    currentLeft = 0;
                    width = 0;
                    appendNext = false;
                }
            }
        }

        public void AdjustSize()
        {
            int w=this.Width;
            int h=this.Height;
            if (lblPart.Right > this.Width) 
                w=lblPart.Right;
            if(lblPart.Bottom>this.Height)
                h=lblPart.Bottom;
            QuestionnaireHelper.AdjustSize(this, w, h);
        }
        public void AdjustSize(Control ctrl)
        {
            int w = this.Width;
            int h = this.Height;
            if (ctrl.Right > this.Width)
                w = lblPart.Bottom;
            if (ctrl.Bottom > this.Height)
                h = lblPart.Bottom;
            QuestionnaireHelper.AdjustSize(this, w, h);
        }
        public bool IsComplete
        {
            get {
                bool flag = true;
                ControlCollection ctrls = this.Controls;
                foreach (Control ctrl in ctrls) {
                    QuestionnaireBase qn = ctrl as QuestionnaireBase;
                    if (qn == null) continue;
                    if (qn.IsComplete == false)
                    {
                        flag = false;
                        break;
                    }
                }
                return flag;
            }
        }
        public List<GenerateQuestionnaireText> ResponseAnswer
        {
            get
            {
                List<GenerateQuestionnaireText> a = new List<GenerateQuestionnaireText>();
                ControlCollection ctrls = this.Controls;
                bool flag = true;
                foreach (System.Windows.Forms.Control c in ctrls)
                {
                    QuestionnaireBase v = c as QuestionnaireBase;
                    if (v != null)
                    {
                        a.Add(v.ResponseTextCollections(flag));
                        flag = v.IsAppendNext;
                    }
                }
                return a;
            }
        }
        public List<Answer> Answer
        {
            get
            {
                List<Answer> ans = new List<Answer>();
                ControlCollection ctrls = this.Controls;
                foreach (System.Windows.Forms.Control c in ctrls)
                {
                    QuestionnaireBase v = c as QuestionnaireBase;
                    if (v != null)
                        ans.Add(v.ResponseAnswer);
                }
                return ans;
            }
        }
            
        public string QuestionPart
        {
            get
            {
                return lblPart.Text;
            }
        }
    }
}
