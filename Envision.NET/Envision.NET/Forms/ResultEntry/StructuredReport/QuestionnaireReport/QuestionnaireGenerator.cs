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
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Utils;
using DevExpress.XtraRichEdit.API.Native;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;

using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.Common;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport
{
    public partial class QuestionnaireGenerator : UserControl
    {
        private int templateId;
        private DataSet dsTemplate;
        private GBLEnvVariable env = new GBLEnvVariable();
        public QuestionnaireGenerator()
        {
            InitializeComponent();
        }

        public bool IsComplete {
            get
            {
                bool flag = true;
                ControlCollection ctrls = panelCtrl.Controls;
                foreach (Control ctrl in ctrls) {
                    Questionnaire qn = ctrl as Questionnaire;
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
        public void GenerateQuestion(DataSet Data, int Width) {
            panelCtrl.Controls.Clear();

           
            
            dsTemplate = Data;
            int bottom = 0;
            DataTable dtt = dsTemplate.Tables[1];
            foreach (DataRow row in dsTemplate.Tables[1].Rows)
            {
                int partId = Convert.ToInt32(row["PART_ID"].ToString());
                Questionnaire qn = new Questionnaire(partId, dsTemplate, string.Empty);
                qn.Top = bottom;
                panelCtrl.Controls.Add(qn);

                bottom = qn.Bottom + 3;
                QuestionnaireHelper.AdjustSize(this, qn);
            }
        }
        public void GenerateQuestion(int TemplateId,int Width) 
        {
            panelCtrl.Controls.Clear();
            QuestionnaireHelper.BaseWidth = Width;

            panelCtrl.Controls.Clear();
            templateId = TemplateId;
            ProcessGetSRTemplate proc = new ProcessGetSRTemplate();
            proc.SR_TEMPLATE.TEMPLATE_ID = templateId;
            proc.SR_TEMPLATE.ORG_ID = env.OrgID;
            dsTemplate = proc.GetbyId();

            DataTable dtt = dsTemplate.Tables[2];
            dtt.Columns.Add("ANSWER", typeof(string));
            dtt.AcceptChanges();

            dtt = dsTemplate.Tables[3];
            dtt.Columns.Add("ANSWER", typeof(string));
            dtt.AcceptChanges();

            dtt = dsTemplate.Tables[4];
            dtt.Columns.Add("ANSWER", typeof(string));
            dtt.AcceptChanges();

            dtt = dsTemplate.Tables[1];
            int bottom = 0;
           
            foreach (DataRow row in dtt.Rows)
            {
                int partId = Convert.ToInt32(row["PART_ID"].ToString());
                Questionnaire qn = new Questionnaire(partId, dsTemplate, string.Empty);
                qn.Top = bottom;
                panelCtrl.Controls.Add(qn);
               
                bottom = qn.Bottom + 3;
                QuestionnaireHelper.AdjustSize(this, qn);
            }
        }
        public void GenerateQuestion(int TemplateId, int Width, string AccessionNo) 
        {
            panelCtrl.Controls.Clear();
            templateId = TemplateId;

            dsTemplate = new DataSet();
            ProcessGetSRTemplate proc = new ProcessGetSRTemplate();
            proc.SR_TEMPLATE.TEMPLATE_ID = -1;
            dsTemplate = proc.GetbyId();

            ProcessGetSRQuestionsAnswers procAns = new ProcessGetSRQuestionsAnswers();
            procAns.SR_QUESTIONSANSWERS.ACCESSION_NO = AccessionNo;
            DataSet ds = procAns.GetAnswers();

            DataTable dtt = dsTemplate.Tables[1];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow row = dtt.NewRow();
                row["PART_ID"] = dr["PART_ID"];
                row["PART_NAME"] = dr["PART_NAME"];
                row["TEMPLATE_ID"] = dr["TEMPLATE_ID"];
                dtt.Rows.Add(row);
            }
            dtt.AcceptChanges();
            dtt = dsTemplate.Tables[2];
            dtt.Columns.Add("ANSWER", typeof(string));
            dtt.AcceptChanges();
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                DataRow row = dtt.NewRow();
                row["Q_ID"] = dr["Q_ID"];
                row["PART_ID"] = dr["PART_ID"];
                row["Q_TYPE_ID"] = dr["Q_TYPE_ID"];
                row["QUESTION_TEXT"] = dr["QUESTION_TEXT"];
                row["QUESTION_SIDE"] = dr["QUESTION_SIDE"];
                row["SPACE_BEGIN"] = dr["SPACE_BEGIN"];
                row["IS_BOLD"] = dr["IS_BOLD"];
                row["IS_ITALIC"] = dr["IS_ITALIC"];
                row["IS_UNDERLINE"] = dr["IS_UNDERLINE"];
                row["LABEL"] = dr["LABEL"];
                row["DEFAULT_VALUE"] = dr["DEFAULT_VALUE"];
                row["ANSWER"] = dr["ANSWER"];
                row["APPEND_NEXT"]=dr["APPEND_NEXT"];
                row["IS_DEFAULT"] = dr["IS_DEFAULT"];
                dtt.Rows.Add(row);
            }
            dtt.AcceptChanges();

           
            dtt = dsTemplate.Tables[3];
            dtt.Columns.Add("ANSWER", typeof(string));
            dtt.AcceptChanges();
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                DataRow row = dtt.NewRow();
                row["Q_ID"] = dr["Q_ID"];
                row["Q_ID_DTL"] = dr["Q_ID_DTL"];
                row["LABEL"] = dr["LABEL"];
                row["DEFAULT_VALUE"] = dr["DEFAULT_VALUE"];
                row["IS_DEFAULT"] = dr["IS_DEFAULT"];
                row["HAS_CHILD"] = dr["HAS_CHILD"];
                row["IMG_POSITION"] = dr["IMG_POSITION"];
                row["IMG_DATA"] = dr["IMG_DATA"];
                row["PROP1"] = dr["PROP1"];
                row["TEXT_SIZE"] = dr["TEXT_SIZE"];
                row["ANSWER"] = dr["ANSWER"];
                dtt.Rows.Add(row);
            }
            dtt.AcceptChanges();

            dtt = dsTemplate.Tables[4];
            dtt.Columns.Add("ANSWER", typeof(string));
            dtt.AcceptChanges();
            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                DataRow row = dtt.NewRow();
                row["Q_ID"] = dr["Q_ID"];
                row["Q_ID_DTL"] = dr["Q_ID_DTL"];
                row["Q_ID_DTL_CHD"] = dr["Q_ID_DTL_CHD"];
                row["Q_TYPE_ID"] = dr["Q_TYPE_ID"];
                row["LABEL"] = dr["LABEL"];
                row["DEFAULT_VALUE"] = dr["DEFAULT_VALUE"];
                row["IS_DEFAULT"] = dr["IS_DEFAULT"];
                row["IMG_POSITION"] = dr["IMG_POSITION"];
                row["IMG_DATA"] = dr["IMG_DATA"];
                row["PROP1"] = dr["PROP1"];
                row["TEXT_SIZE"] = dr["TEXT_SIZE"];
                row["QUESTION_SIDE"] = dr["QUESTION_SIDE"];
                row["ANSWER"] = dr["ANSWER"];
                dtt.Rows.Add(row);
            }
            dtt.AcceptChanges();



            int bottom = 0;
            dtt = dsTemplate.Tables[1];
            foreach (DataRow row in dsTemplate.Tables[1].Rows)
            {
                int partId = Convert.ToInt32(row["PART_ID"].ToString());
                Questionnaire qn = new Questionnaire(partId, dsTemplate,AccessionNo);
                qn.Top = bottom;
                panelCtrl.Controls.Add(qn);

                bottom = qn.Bottom + 3;
                QuestionnaireHelper.AdjustSize(this, qn);
            }
        }
        public void GetResultText_OLD(RichEditControl rtPad) {
            ControlCollection ctrls = panelCtrl.Controls;
            rtPad.CreateNewDocument();
            DocumentPosition pos;
            //
            pos = rtPad.Document.CaretPosition;
            rtPad.Document.InsertParagraph(pos);
            pos = rtPad.Document.CaretPosition;
            rtPad.Document.InsertParagraph(pos);
            pos = rtPad.Document.CaretPosition;
            //
            bool isNeedRow = true;
            bool isFirstTime = true;
            foreach (System.Windows.Forms.Control c in ctrls)
            {
               
                Questionnaire v = c as Questionnaire;
                if (v != null)
                {
                    string str = v.QuestionPart;
                    if (string.IsNullOrEmpty(str)) continue;
                    
                    Document doc = rtPad.Document;
                    int currentParagraph = rtPad.Document.Paragraphs.Count;
                    DocumentRange range = rtPad.Document.Paragraphs[currentParagraph - 1].Range;
                    CharacterProperties cp = doc.BeginUpdateCharacters(range);
                    cp.Bold = true;
                    doc.EndUpdateCharacters(cp);
                    rtPad.Document.InsertText(pos, str);

                    if (isNeedRow)
                    {
                        pos = rtPad.Document.CaretPosition;
                        rtPad.Document.InsertParagraph(pos);
                        isNeedRow = false;
                    }

                    foreach (GenerateQuestionnaireText q in v.ResponseAnswer)
                    {
                        if (q == null) continue;

                        str = q.QuestionText;
                        if (!string.IsNullOrEmpty(str))
                        {
                            int index = pos.ToInt();
                            if (q.IsAppendNext == false)
                            {
                                pos = rtPad.Document.CaretPosition;
                                rtPad.Document.InsertParagraph(pos);
                                index = pos.ToInt();
                            }
                            else
                                str = " " + str;
                            rtPad.Document.InsertText(pos, str);

                            DocumentRange rr = rtPad.Document.CreateRange(index, str.Length);
                            CharacterProperties cc = doc.BeginUpdateCharacters(rr);
                            cc.Bold = q.IsBold;
                            cc.Italic = q.IsItalic;
                            cc.Underline = q.IsUnderLine ? UnderlineType.Single : UnderlineType.None;
                            doc.EndUpdateCharacters(cc);

                        }
                        else 
                            rtPad.Document.InsertParagraph(pos);

                        str = q.QuestionAck;
                        if (!string.IsNullOrEmpty(str))
                        {
                            string[] data = str.Split("\r\n".ToString().ToCharArray());
                            foreach (string s in data)
                            {
                                if (string.IsNullOrEmpty(s)) continue;
                                pos = rtPad.Document.CaretPosition;
                                int index = pos.ToInt();
                                rtPad.Document.InsertText(pos, s);
                                DocumentRange rr = rtPad.Document.CreateRange(index, s.Length);
                                CharacterProperties cc = doc.BeginUpdateCharacters(rr);
                                cc.Bold = false;
                                cc.Italic = false;
                                cc.Underline = UnderlineType.None;
                                doc.EndUpdateCharacters(cc);
                            }
                        }
                      
                    }//end for loop.
                }
                if (v != null) {
                    pos = rtPad.Document.CaretPosition;
                    rtPad.Document.InsertParagraph(pos);
                    pos = rtPad.Document.CaretPosition;
                    rtPad.Document.InsertParagraph(pos);
                    if (isFirstTime && v.ResponseAnswer.Count == 0)
                    {
                        isFirstTime = false;
                        isNeedRow = false;
                    }
                    else 
                        isNeedRow = true;
                }
            }//end for loop
        }
        private void newLine(DocumentPosition pos, RichEditControl rtPad)
        {
            pos = rtPad.Document.CaretPosition;
            rtPad.Document.InsertParagraph(pos);
        }
        public void GetResultText(RichEditControl rtPad)
        {
            ControlCollection ctrls = panelCtrl.Controls;
            rtPad.CreateNewDocument();
            DocumentPosition pos = rtPad.Document.CaretPosition;
            bool firstLine = true;
            foreach (System.Windows.Forms.Control c in ctrls)
            {

                Questionnaire v = c as Questionnaire;
                if (v != null)
                {
                    //add Part Text
                    //newLine(pos, rtPad);
                    //newLine(pos, rtPad);
                    string str = v.QuestionPart;
                    if (string.IsNullOrEmpty(str)) continue;
                    Document doc = rtPad.Document;
                    int currentParagraph = rtPad.Document.Paragraphs.Count;
                    DocumentRange range = rtPad.Document.Paragraphs[currentParagraph - 1].Range;
                    CharacterProperties cp = doc.BeginUpdateCharacters(range);
                    cp.Bold = true;
                    doc.EndUpdateCharacters(cp);
                    rtPad.Document.InsertText(pos, str);
                    newLine(pos, rtPad);

                    foreach (GenerateQuestionnaireText q in v.ResponseAnswer)
                    {
                        if (q == null) continue;
                        str = q.QuestionText;
                        if (!string.IsNullOrEmpty(str))
                        {
                            int index = pos.ToInt();
                            if (firstLine)
                            {
                                str = " " + str;
                                firstLine = false;
                            }
                            else if (q.IsAppendNext)
                                str = " " + str;
                            else
                            {
                                rtPad.Document.InsertParagraph(pos);
                                index = pos.ToInt();
                            }
                            rtPad.Document.InsertText(pos, str);

                            DocumentRange rr = rtPad.Document.CreateRange(index, str.Length);
                            CharacterProperties cc = doc.BeginUpdateCharacters(rr);
                            cc.Bold = q.IsBold;
                            cc.Italic = q.IsItalic;
                            cc.Underline = q.IsUnderLine ? UnderlineType.Single : UnderlineType.None;
                            doc.EndUpdateCharacters(cc);
                        }
                        else
                        {
                            if (q.IsAppendNext)
                                str = " " + str;
                            else
                                rtPad.Document.InsertParagraph(pos);
                        }
                        #region Response from User.
                        str = q.QuestionAck;
                        if (q.QType == QuestionType.QMemo) {
                            if (q.QuestionAck.Trim() == "\r\n" || string.IsNullOrEmpty(q.QuestionAck.Trim()))
                                continue;
                        }
                        if (!string.IsNullOrEmpty(str))
                        {
                            string[] data = str.Split("\r\n".ToString().ToCharArray());
                           // bool flagLine = true;
                            foreach (string s in data)
                            {
                                if (string.IsNullOrEmpty(s))
                                {
                                    if(q.QType==QuestionType.QMemo && data.Length>0)
                                        newLine(pos, rtPad);
                                    continue;
                                }
                                pos = rtPad.Document.CaretPosition;
                                int index = pos.ToInt();
                                string txt = s;
                                try
                                {
                                    if (q.QType == QuestionType.QMemo)
                                    {

                                        char[] txtData = txt.ToCharArray();
                                        if (txtData.Length == 0) continue;
                                        txt = string.Empty;
                                        for (int i = 0; i < txtData.Length; i++)
                                        {
                                            if (i == 0)
                                                if (string.IsNullOrEmpty(txtData[i].ToString().Trim())) continue;
                                            txt += txtData[i];
                                        }
                                        //txt = s.TrimStart(' '.ToString().ToCharArray());
                                        //if (string.IsNullOrEmpty(txt)) continue;
                                        txt = " " + txt;
                                        rtPad.Document.InsertText(pos, txt);
                                    }
                                    else
                                        rtPad.Document.InsertText(pos, txt);
                                    DocumentRange rr = rtPad.Document.CreateRange(index, txt.Length);
                                    CharacterProperties cc = doc.BeginUpdateCharacters(rr);
                                    cc.Bold = false;
                                    cc.Italic = false;
                                    cc.Underline = UnderlineType.None;
                                    doc.EndUpdateCharacters(cc);
                                }
                                catch (Exception exx){
                                    newLine(pos, rtPad);
                                }
                            }
                        }
                        #endregion


                    }//end for loop.
                }
            }//end for loop
        }
        public AnswerCollection GetAnswerQuestion()
        {
            AnswerCollection ans = new AnswerCollection();
            ControlCollection ctrls = panelCtrl.Controls;
            foreach (System.Windows.Forms.Control c in ctrls)
            {
                Questionnaire v = c as Questionnaire;
                if (v != null)
                    ans.Answer.AddRange(v.Answer);
            }
            return ans;
        }

        private void QuestionnaireGenerator_Load(object sender, EventArgs e)
        {
            QuestionnaireHelper.BaseWidth = this.Right; ;
            
        }
        public void ClearQuestionnaire() {
            panelCtrl.Controls.Clear();
        }
    }
}
