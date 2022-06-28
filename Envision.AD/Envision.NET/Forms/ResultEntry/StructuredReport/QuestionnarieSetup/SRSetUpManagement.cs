using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.HeplerClasses;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls;

using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup
{
    public class SRSetUpManagement
    {

        #region Inner Class
        /// <summary>
        /// Define controls type collection
        /// </summary>
        private enum Controls
        {
            Label = 1,
            TextBox = 2,
            CheckBox = 3,
            RadioBox = 4,
            DatePick = 5,
            Memo = 6,
            Number = 7,
            Group = 8,
            NColumn = 9,
            NewLine = 10
        }
        /// <summary>
        /// This struct uset to specifiy font style
        /// Bold, Italic and Underline
        /// </summary>
        public class FontStyle
        {
            private bool _bold = false;
            private bool _italic = false;
            private bool _underline = false;

            /// <summary>
            /// Bold
            /// </summary>
            public bool Bold
            {
                get { return _bold; }
                set { _bold = value; }
            }
            /// <summary>
            /// Italic
            /// </summary>
            public bool Italic
            {
                get { return _italic; }
                set { _italic = value; }
            }
            /// <summary>
            /// Underline
            /// </summary>
            public bool UnderLine
            {
                get { return _underline; }
                set { _underline = value; }
            }
        }
        #endregion

        private ItemMapperCollection tempCollection;
        private ItemMapperCollection tempOldCollection;
        private ProcessGetSRQuestionType processGetStrQuestionType;
        private QuestionTypeCollection innerQuestionTypecollection;
        private int UserId = 7460;
        private int OrgId = 1;
        private GBLEnvVariable env = new GBLEnvVariable();
        private DataSet dsLoadTemplateAllData = null;
        public SRSetUpManagement()
        {
            this.UserId = env.UserID;
            this.OrgId = env.OrgID;
            processGetStrQuestionType = new ProcessGetSRQuestionType();
            innerQuestionTypecollection = new QuestionTypeCollection();
        }
        public QuestionTypeCollection GetQuestionTypes(int OrgId)
        {
            this.innerQuestionTypecollection.Clear();
            this.processGetStrQuestionType.SR_QUESTIONTYPE.ORG_ID = OrgId;
            this.processGetStrQuestionType.Invoke();
            DataSet result = processGetStrQuestionType.Result;
            if (Helper.HaveDataRow(result))
            {
                foreach (DataRow drRow in result.Tables[0].Rows)
                {
                    innerQuestionTypecollection.Add(new SR_QUESTIONTYPE()
                    {
                        Q_TPYE_ID = Convert.ToInt32(drRow["Q_TYPE_ID"]),
                        Q_TPYE_NAME = drRow["Q_TYPE_NAME"].ToString(),
                        Q_TYPE_DESC = drRow["Q_TYPE_DESC"].ToString(),
                        ORG_ID = Convert.ToInt32(drRow["ORG_ID"]),
                        CREATED_BY = Convert.ToInt32(drRow["CREATED_BY"]),
                        CREATED_ON = Convert.ToDateTime(drRow["CREATED_ON"]),
                        IS_ACTIVE = drRow["IS_ACTIVE"].ToString()
                    });
                }
            }
            return innerQuestionTypecollection;
        }

        public DataTable GetLanguage()
        {
            ProcessSelectGBLLanguage proc = new ProcessSelectGBLLanguage();
            proc.Invoke();
            DataTable dttLang = new DataTable();
            dttLang = proc.ResultSet.Tables[0].Copy();
            dttLang.AcceptChanges();
            return dttLang;
        }

        public DataTable GetExamType()
        {
            ProcessGetRISExamType proc = new ProcessGetRISExamType();
            proc.Invoke();
            DataTable dttExamType = new DataTable();
            dttExamType = proc.Result.Tables[0].Copy();
            dttExamType.AcceptChanges();
            return dttExamType;
        }

        public DataTable GetBodySystem()
        {
            ProcessGetRISBpview proc = new ProcessGetRISBpview();
            DataTable dtt = proc.GetBodyPart();
            dtt.AcceptChanges();
            return dtt;
        }

        #region Update

        public enum States
        {
            New, Deleted, Modified
        }
        public bool UpdateTemplate(ref SR_TEMPLATE templateData, DataSet dsSetUp, ItemMapperCollection itemCollection
            , DataSet oldDsSetUp, ItemMapperCollection oldItemCollection, List<int> deleteList)
        {
            bool flag = false;
            try
            {
                this.tempCollection = itemCollection;
                this.tempOldCollection = oldItemCollection;
                ProcessUpdateSRTemplate _processUpdateSrTemplate = new ProcessUpdateSRTemplate();
                _processUpdateSrTemplate.SR_TEMPLATE = templateData;
                _processUpdateSrTemplate.Invoke();

                for (int i = 0; i < dsSetUp.Tables[0].Rows.Count; i++)
                {
                    States state = this.CheckStateDataRow(dsSetUp.Tables[0].Rows[i], oldDsSetUp, 0);
                    switch (state)
                    {
                        case States.New:
                            ProcessAddSRTemplatePart _processAddTemplatePart = new ProcessAddSRTemplatePart();
                            _processAddTemplatePart.SR_TEMPLATEPART.CREATED_BY = this.UserId;
                            _processAddTemplatePart.SR_TEMPLATEPART.ORG_ID = this.OrgId;
                            _processAddTemplatePart.SR_TEMPLATEPART.PART_NAME = dsSetUp.Tables[0].Rows[i][SRSetUpForm.MT_PART_NAME].ToString();
                            _processAddTemplatePart.SR_TEMPLATEPART.SL = Convert.ToInt32(dsSetUp.Tables[0].Rows[i][SRSetUpForm.MT_SL_NO].ToString());
                            _processAddTemplatePart.SR_TEMPLATEPART.TEMPLATE_ID = templateData.TEMPLATE_ID;
                            _processAddTemplatePart.Invoke();
                            this.SaveQuestion(_processAddTemplatePart.SR_TEMPLATEPART.PART_ID, Convert.ToInt32(dsSetUp.Tables[0].Rows[i][SRSetUpForm.MT_MASTER_ID]));
                            break;
                        case States.Modified:
                            ProcessUpdateSRTemplatePart _processUpdateSrTemplatePart = new ProcessUpdateSRTemplatePart();
                            _processUpdateSrTemplatePart.SR_TEMPLATEPART.PART_ID = Convert.ToInt32(dsSetUp.Tables[0].Rows[i][SRSetUpForm.MT_MASTER_ID]);
                            _processUpdateSrTemplatePart.SR_TEMPLATEPART.PART_NAME = dsSetUp.Tables[0].Rows[i][SRSetUpForm.MT_PART_NAME].ToString();
                            _processUpdateSrTemplatePart.SR_TEMPLATEPART.SL = Convert.ToInt32(dsSetUp.Tables[0].Rows[i][SRSetUpForm.MT_SL_NO].ToString()); ;
                            _processUpdateSrTemplatePart.SR_TEMPLATEPART.ORG_ID = this.OrgId;
                            _processUpdateSrTemplatePart.SR_TEMPLATEPART.LAST_MODIFIED_BY = this.UserId;
                            _processUpdateSrTemplatePart.Invoke();
                            this.UpdateQuestion(_processUpdateSrTemplatePart.SR_TEMPLATEPART.PART_ID, Convert.ToInt32(dsSetUp.Tables[0].Rows[i][SRSetUpForm.MT_MASTER_ID]));
                            break;

                    }
                }

                for (int j = 0; j < deleteList.Count; j++)
                {
                    if (deleteList[j] > 0)
                    {
                        ProcessDeleteSRTemplatePart _processDeleteSrTemplatePart = new ProcessDeleteSRTemplatePart();
                        _processDeleteSrTemplatePart.SR_TEMPLATEPART.PART_ID = Convert.ToInt32(deleteList[j]);
                        _processDeleteSrTemplatePart.SR_TEMPLATEPART.ORG_ID = this.OrgId;
                        _processDeleteSrTemplatePart.Invoke();
                    }
                }

                //ProcessDeleteSrTemplate _processDeleteOldTemplate = new ProcessDeleteSrTemplate();
                //_processDeleteOldTemplate.SR_TEMPLATE = templateData;
                //_processDeleteOldTemplate.Invoke();

                //this.SaveTemplatePart(templateData.TEMPLATE_ID, dsSetUp);

                flag = true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                flag = false; 
            }

            return flag;
        }

        private void UpdateQuestion(int partId, int masterId)
        {
            List<ItemMapper> itemList = this.GetQuestionByTemplatePart(masterId);
            List<ItemMapper> OlditemList = this.GetQuestionByTemplatePart(masterId);

            if (itemList.Count > 0)
            {
                //ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
                foreach (ItemMapper item in itemList)
                {
                    //Save New
                    if (Convert.ToInt32(item.Row["ID"].ToString()) < 0)
                    {
                        if (item.ControlType == typeof(ExCheckBox))
                            this.SaveCheckBoxQuestion(item, partId);
                        else if (item.ControlType == typeof(ExDatePick))
                            this.SaveDatePickQuestion(item, partId);
                        else if (item.ControlType == typeof(ExGroup))
                            this.SaveGroupQuestion(item, partId);
                        else if (item.ControlType == typeof(ExLabel))
                            this.SaveLabelQuestion(item, partId);
                        else if (item.ControlType == typeof(ExMemoEdit))
                            this.SaveMemoQuestion(item, partId);
                        else if (item.ControlType == typeof(ExTable))
                            this.SaveMultiColumnQuestion(item, partId);
                        else if (item.ControlType == typeof(ExRadioButton))
                            this.SaveRadioButtonQuestion(item, partId);
                        else if (item.ControlType == typeof(ExSpinEdit))
                            this.SaveNumberQuestion(item, partId);
                        else if (item.ControlType == typeof(ExTextBox))
                            this.SaveTextBoxQuestion(item, partId);
                        else if (item.ControlType == typeof(NewLine))
                            this.SaveNewLine(item, partId);
                    }
                    else
                    {
                        //Update old question
                        if (item.ControlType == typeof(ExCheckBox))
                            this.UpdateCheckBoxQuestion(item, partId);
                        else if (item.ControlType == typeof(ExDatePick))
                            this.UpdateDatePickQuestion(item, partId);
                        else if (item.ControlType == typeof(ExGroup))
                            this.UpdateGroupQuestion(item, partId);
                        else if (item.ControlType == typeof(ExLabel))
                            this.UpdateLabelQuestion(item, partId);
                        else if (item.ControlType == typeof(ExMemoEdit))
                            this.UpdateMemoQuestion(item, partId);
                        else if (item.ControlType == typeof(ExTable))
                            this.UpdateMultiColumnQuestion(item, partId);
                        else if (item.ControlType == typeof(ExRadioButton))
                            this.UpdateRadioButtonQuestion(item, partId);
                        else if (item.ControlType == typeof(ExSpinEdit))
                            this.UpdateNumberQuestion(item, partId);
                        else if (item.ControlType == typeof(ExTextBox))
                            this.UpdateTextBoxQuestion(item, partId);
                        else if (item.ControlType == typeof(NewLine))
                            this.UpdateNewLine(item, partId);
                    }
                }
            }
            //Delete Question
            List<int> tempNewItemId = new List<int>();
            List<int> tempOldItemId = new List<int>();
            foreach (ItemMapper dr in this.tempCollection)
            {
                if(Convert.ToInt32(dr.Row["ID"]) >= 0)
                    tempNewItemId.Add(Convert.ToInt32(dr.Row["ID"]));
            }
            foreach (ItemMapper dr in this.tempOldCollection)
            {
                if (Convert.ToInt32(dr.Row["ID"]) >= 0)
                    tempOldItemId.Add(Convert.ToInt32(dr.Row["ID"]));
            }
            //Loop delete
            foreach (int index in tempOldItemId)
            {
                if (!tempNewItemId.Contains(index))
                {
                    ProcessDeleteSRQuestions _processDeleteSrQuestion = new ProcessDeleteSRQuestions();
                    _processDeleteSrQuestion.SR_QUESTIONS.ORG_ID = this.OrgId;
                    _processDeleteSrQuestion.SR_QUESTIONS.Q_ID = index;
                    _processDeleteSrQuestion.Invoke();
                }
            }
            tempNewItemId = null;
            tempOldItemId = null;
        }

        #region Update Question

        private void UpdateTextBoxQuestion(ItemMapper item, int partId)
        {
            ExTextBox textbox = item.Control as ExTextBox;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            _processUpdateSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = textbox.DefaultText;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_DEFAULT = textbox.ForceInput == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.TextBox;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = textbox.Id;
            _processUpdateSRQuestions.Invoke();

            if (textbox.DetailId != 0)
            {
                ProcessUpdateSRQuestionsDtl _processUpdateSRQuestionDtl = new ProcessUpdateSRQuestionsDtl();
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                //_processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = _processUpdateSRQuestions.SR_QUESTIONS.Q_ID;
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL = textbox.DetailId;
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LAST_MODIFIED_BY = this.UserId;
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(textbox.Size);
                if (textbox.Image != null)
                {
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(textbox.Image);
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(textbox.Position);
                }
                else
                {
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                }
                _processUpdateSRQuestionDtl.Invoke();
            }
            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == textbox.Id)
                    {
                        if (immp.Control is ExRadioButton)
                        {
                            ExRadioButton rdb = ((ExRadioButton)immp.Control);
                            foreach (ExItem iem in rdb.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExCheckBox)
                        {
                            ExCheckBox chk = ((ExCheckBox)immp.Control);
                            foreach (ExItem iem in chk.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExTable)
                        {
                            ExTable tb = ((ExTable)immp.Control);
                            foreach (ExMultiColumn cols in tb.Column)
                                foreach (ExMultiColumnItem im in cols.Column)
                                    this.DeleteQuestionDetail(im.Id);
                        }
                        else if (immp.Control is ExGroup)
                        {
                            ExGroup eg = ((ExGroup)immp.Control);
                            foreach (ExGroupItem gi in eg.Items)
                                this.DeleteQuestionDetail(gi.Id);
                        }
                        break;
                    }
                }
                ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = textbox.Id;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(textbox.Size);
                if (textbox.Image != null)
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(textbox.Image);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(textbox.Position);
                }
                else
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                }
                _processAddSRQuestionDtl.Invoke();
            }
        }

        private void UpdateNumberQuestion(ItemMapper item, int partId)
        {
            ExSpinEdit spinEdit = item.Control as ExSpinEdit;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            _processUpdateSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_DEFAULT = spinEdit.ForceInput == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.Number;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = spinEdit.Id;
            _processUpdateSRQuestions.Invoke();

            if (spinEdit.DetailId != 0)
            {
                ProcessUpdateSRQuestionsDtl _processUpdateSRQuestionDtl = new ProcessUpdateSRQuestionsDtl();
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LAST_MODIFIED_BY = this.UserId;
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = spinEdit.Maximum.ToString();
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL = spinEdit.DetailId;
                if (spinEdit.Image != null)
                {
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(spinEdit.Image);
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(spinEdit.Position);
                }
                else
                {
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                }
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = spinEdit.Minimum.ToString();
                _processUpdateSRQuestionDtl.Invoke();
            }
            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == spinEdit.Id)
                    {
                        if (immp.Control is ExRadioButton)
                        {
                            ExRadioButton rdb = ((ExRadioButton)immp.Control);
                            foreach (ExItem iem in rdb.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExCheckBox)
                        {
                            ExCheckBox chk = ((ExCheckBox)immp.Control);
                            foreach (ExItem iem in chk.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExTable)
                        {
                            ExTable tb = ((ExTable)immp.Control);
                            foreach (ExMultiColumn cols in tb.Column)
                                foreach (ExMultiColumnItem im in cols.Column)
                                    this.DeleteQuestionDetail(im.Id);
                        }
                        else if (immp.Control is ExGroup)
                        {
                            ExGroup eg = ((ExGroup)immp.Control);
                            foreach (ExGroupItem gi in eg.Items)
                                this.DeleteQuestionDetail(gi.Id);
                        }
                        break;
                    }
                }

                ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = spinEdit.Maximum.ToString();
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = spinEdit.Id;
                if (spinEdit.Image != null)
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(spinEdit.Image);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(spinEdit.Position);
                }
                else
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                }
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = spinEdit.Minimum.ToString();
                _processAddSRQuestionDtl.Invoke();
            }
        }

        private void UpdateRadioButtonQuestion(ItemMapper item, int partId)
        {
            ExRadioButton radioButton = item.Control as ExRadioButton;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            //_processAddSRQuestions.SR_QUESTIONS.LABEL = label.Text;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            //_processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = label.datePick == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.RadioBox;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = radioButton.Id;
            _processUpdateSRQuestions.Invoke();
            //delete item
            if (radioButton.DetailId != 0)
                this.DeleteQuestionDetail(radioButton.DetailId);
            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == radioButton.Id)
                    {
                        //if (immp.Control is ExRadioButton)
                        //{
                        //    ExRadioButton rdb = ((ExRadioButton)immp.Control);
                        //    foreach (ExItem iem in rdb.Items)
                        //        this.DeleteQuestionDetail(iem.Id);
                        //}
                        if (immp.Control is ExCheckBox)
                        {
                            ExCheckBox chk = ((ExCheckBox)immp.Control);
                            foreach (ExItem iem in chk.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExTable)
                        {
                            ExTable tb = ((ExTable)immp.Control);
                            foreach (ExMultiColumn cols in tb.Column)
                                foreach (ExMultiColumnItem im in cols.Column)
                                    this.DeleteQuestionDetail(im.Id);
                        }
                        else if (immp.Control is ExGroup)
                        {
                            ExGroup eg = ((ExGroup)immp.Control);
                            foreach (ExGroupItem gi in eg.Items)
                                this.DeleteQuestionDetail(gi.Id);
                        }
                        break;
                    }
                }
            }

            if (radioButton.Items.Count > 0)
            {
                ExRadioButton rb1 = null;
                List<int> _radOldItems = new List<int>();
                List<int> _chdOldItems = new List<int>();
                List<int> _radNewItems = new List<int>();
                List<int> _chdNewItems = new List<int>();
                foreach (ItemMapper olditem in tempOldCollection)
                {
                    if (((ControlBase)olditem.Control).Id == radioButton.Id)
                    {
                        rb1 = olditem.Control as ExRadioButton;
                        if (rb1 != null)
                        {
                            foreach (ExItem eit in rb1.Items)
                            {
                                _radOldItems.Add(eit.Id);
                                foreach (ExChild chd in eit.Child)
                                    _chdOldItems.Add(chd.Id);
                            }
                        }
                        break;
                    }
                }
                if (rb1 != null)
                {
                    string defaultName = string.Empty;
                    foreach (CustomItem cItem in radioButton.Default)
                        if (cItem.Selected)
                        {
                            defaultName = cItem.Name;
                            break;
                        }

                    foreach (ExItem exItem in radioButton.Items)
                    {
                        if (exItem.Id == 0)
                        {
                            this.SaveRadioButtonItem(exItem, defaultName, radioButton.Id);
                        }
                        else
                        {
                            #region Update Detail
                            //update
                            ProcessUpdateSRQuestionsDtl _processUpdateSRQuestionDtl = new ProcessUpdateSRQuestionsDtl();
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LAST_MODIFIED_BY = this.UserId;
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = exItem.Value;
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LABEL = exItem.Text;
                            if (exItem.Text == defaultName)
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = "Y";
                            else
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = "N";

                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL = exItem.Id;
                            if (exItem.Image != null)
                            {
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(exItem.Image);
                                //_processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(exItem.Position);
                            }
                            else
                            {
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                            }
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.HAS_CHILD = exItem.Child.Count > 0 ? "Y" : "N";
                            _processUpdateSRQuestionDtl.Invoke();
                            #endregion

                            #region Child
                            // Insert Child
                            if (_processUpdateSRQuestionDtl.SR_QUESTIONSDTL.HAS_CHILD == "Y")
                            {
                                
                                foreach (ExChild child in exItem.Child)
                                {
                                    if (child.Id == 0)
                                    {
                                        ProcessAddSRQuestionsDtlChild _processAddSRQuestionDtlChild = new ProcessAddSRQuestionsDtlChild();
                                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID = radioButton.Id;
                                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID_DTL = exItem.Id;
                                        //_processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.QUESION_SIDE = child.Layout == Layouts.Horizontal ? "H" : "V";
                                        if (child.Type == ChildControlTypes.Label)
                                        {
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Label;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.Text;
                                        }
                                        else if (child.Type == ChildControlTypes.TextBox)
                                        {
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.TextBox;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            //if (child.Image != null)
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        else if (child.Type == ChildControlTypes.MemoEdit)
                                        {
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Memo;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            //if (child.Image != null)
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        else if (child.Type == ChildControlTypes.Numeric)
                                        {
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = child.Maximum.ToString();
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultValue.ToString();
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.PROP1 = child.Minimum.ToString();
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                                            //if (child.Image != null)
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.ORG_ID = this.OrgId;
                                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.CREATED_BY = this.UserId;
                                        _processAddSRQuestionDtlChild.Invoke();
                                    }
                                    else
                                    {
                                        ProcessUpdateSRQuestionsDtlChild _processUpdateSRQuestionDtlChild = new ProcessUpdateSRQuestionsDtlChild();
                                        //_processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID = radId;
                                        //_processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID_DTL = child.Id;
                                        _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID_DTL_CHD = child.Id;
                                        //_processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.QUESION_SIDE = child.Layout == Layouts.Horizontal ? "H" : "V";
                                        if (child.Type == ChildControlTypes.Label)
                                        {
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Label;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.Text;
                                        }
                                        else if (child.Type == ChildControlTypes.TextBox)
                                        {
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.TextBox;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            //if (child.Image != null)
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        else if (child.Type == ChildControlTypes.MemoEdit)
                                        {
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Memo;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            //if (child.Image != null)
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        else if (child.Type == ChildControlTypes.Numeric)
                                        {
                                            //_processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = child.Maximum.ToString();
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultValue.ToString();
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.PROP1 = child.Minimum.ToString();
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                                            //if (child.Image != null)
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.ORG_ID = this.OrgId;
                                        _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.LAST_MODIFIED_BY = this.UserId;
                                        _processUpdateSRQuestionDtlChild.Invoke();

                                        _chdNewItems.Add(child.Id);
                                    }
                                }
                            

                               

                            #endregion
                            }

                            _radNewItems.Add(exItem.Id);
                        }
                    }

                    #region Delete Removed Child
                    foreach (int i in _chdOldItems)
                    {
                        if (!_chdNewItems.Contains(i))
                            this.DeleteQuestionDetailChild(i);
                    }
                    #endregion

                    #region Delete Removed Item
                    foreach (int i in _radOldItems)
                    {
                        if (!_radNewItems.Contains(i))
                            this.DeleteQuestionDetail(i);
                    }
                    #endregion
                }
                else
                {
                    string defaultName = string.Empty;
                    foreach (CustomItem cItem in radioButton.Default)
                        if (cItem.Selected)
                        {
                            defaultName = cItem.Name;
                            break;
                        }

                    if (radioButton.Items.Count > 0)
                    {
                        foreach (ExItem _radItem in radioButton.Items)
                        {
                            this.SaveRadioButtonItem(_radItem, defaultName, radioButton.Id);
                        }
                    }
                }
            }
        }
            
        private void UpdateMultiColumnQuestion(ItemMapper item, int partId)
        {
            ExTable multiColumn = item.Control as ExTable;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            _processUpdateSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = multiColumn.Column.Count.ToString();
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.LABEL = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.NColumn;
            _processUpdateSRQuestions.SR_QUESTIONS.IS_DEFAULT = multiColumn.Selection == SelectionTypes.Single ? "S" : "M";
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = multiColumn.Id;            
            _processUpdateSRQuestions.Invoke();

            //delete old detail
            if (multiColumn.DetailId != 0)
                this.DeleteQuestionDetail(multiColumn.DetailId);
            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == multiColumn.Id)
                    {
                        if (immp.Control is ExRadioButton)
                        {
                            ExRadioButton rdb = ((ExRadioButton)immp.Control);
                            foreach (ExItem iem in rdb.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExCheckBox)
                        {
                            ExCheckBox chk = ((ExCheckBox)immp.Control);
                            foreach (ExItem iem in chk.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExGroup)
                        {
                            ExGroup eg = ((ExGroup)immp.Control);
                            foreach (ExGroupItem gi in eg.Items)
                                this.DeleteQuestionDetail(gi.Id);
                        }
                        break;
                    }
                }
            }

            //insert new detail
            if (multiColumn.Column.Count > 0)
            {
                //Find old collection
                ExTable table = null;
                List<int> newColumnId = new List<int>();
                List<int> oldColumnId = new List<int>();
                foreach (ItemMapper olditem in tempOldCollection)
                {
                    if (((ControlBase)olditem.Control).Id == multiColumn.Id)
                    {
                        table = olditem.Control as ExTable;
                        if (table != null)
                        {
                            foreach (ExMultiColumn column in table.Column)
                            {
                                foreach (ExMultiColumnItem row in column.Column)
                                    oldColumnId.Add(row.Id);
                            }
                        }
                        break;
                    }
                }
                //Update question detail
                if (table != null)
                {
                    for (int i = 0; i < multiColumn.Column.Count; i++)
                    {
                        foreach (ExMultiColumnItem columnItem in multiColumn.Column[i].Column)
                        {
                            if (columnItem.Id == 0)
                            {
                                ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = multiColumn.Id;
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = columnItem.Text;
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = columnItem.Value;
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = columnItem.Default == true ? "Y" : "N";
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = (i + 1).ToString();
                                _processAddSRQuestionDtl.Invoke();
                            }
                            else
                            {
                                ProcessUpdateSRQuestionsDtl _processUpdateSRQuestionDtl = new ProcessUpdateSRQuestionsDtl();
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LAST_MODIFIED_BY = this.UserId;
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL = columnItem.Id;
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LABEL = columnItem.Text;
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = columnItem.Value;
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = columnItem.Default == true ? "Y" : "N";
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = (i + 1).ToString();
                                _processUpdateSRQuestionDtl.Invoke();
                                newColumnId.Add(columnItem.Id);
                            }
                        }
                    }
                    //delete old item
                    foreach (int index in oldColumnId)
                    {
                        if (!newColumnId.Contains(index))
                            this.DeleteQuestionDetail(index);
                    }
                }
                else
                {
                    ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                    for (int i = 0; i < multiColumn.Column.Count; i++)
                    {
                        foreach (ExMultiColumnItem columnItem in multiColumn.Column[i].Column)
                        {
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = multiColumn.Id;
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = columnItem.Text;
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = columnItem.Value;
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = columnItem.Default == true ? "Y" : "N";
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = (i + 1).ToString();
                            _processAddSRQuestionDtl.Invoke();
                        }
                    }
                }
            }
            
        }

        private void UpdateMemoQuestion(ItemMapper item, int partId)
        {
            ExMemoEdit memoEdit = item.Control as ExMemoEdit;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            _processUpdateSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = memoEdit.DefaultText;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_DEFAULT = memoEdit.ForceInput == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.Memo;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = memoEdit.Id;
            _processUpdateSRQuestions.Invoke();

            if (memoEdit.DetailId != 0)
            {
                ProcessUpdateSRQuestionsDtl _processUpdateSRQuestionDtl = new ProcessUpdateSRQuestionsDtl();
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LAST_MODIFIED_BY = this.UserId;
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(memoEdit.Size);
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL = memoEdit.DetailId;
                if (memoEdit.Image != null)
                {
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(memoEdit.Image);
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(memoEdit.Position);
                }
                else
                {
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                }
                _processUpdateSRQuestionDtl.Invoke();
            }
            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == memoEdit.Id)
                    {
                        if (immp.Control is ExRadioButton)
                        {
                            ExRadioButton rdb = ((ExRadioButton)immp.Control);
                            foreach (ExItem iem in rdb.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExCheckBox)
                        {
                            ExCheckBox chk = ((ExCheckBox)immp.Control);
                            foreach (ExItem iem in chk.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExTable)
                        {
                            ExTable tb = ((ExTable)immp.Control);
                            foreach (ExMultiColumn cols in tb.Column)
                                foreach (ExMultiColumnItem im in cols.Column)
                                    this.DeleteQuestionDetail(im.Id);
                        }
                        else if (immp.Control is ExGroup)
                        {
                            ExGroup eg = ((ExGroup)immp.Control);
                            foreach (ExGroupItem gi in eg.Items)
                                this.DeleteQuestionDetail(gi.Id);
                        }
                        break;
                    }
                }

                ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(memoEdit.Size);
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = memoEdit.Id;
                if (memoEdit.Image != null)
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(memoEdit.Image);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(memoEdit.Position);
                }
                else
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                }
                _processAddSRQuestionDtl.Invoke();
            }
        }

        private void UpdateLabelQuestion(ItemMapper item, int partId)
        {
            ExLabel label = item.Control as ExLabel;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LABEL = label.Text;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            //_processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = label.datePick == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.Label;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = label.Id;
            _processUpdateSRQuestions.Invoke();

            if (label.DetailId != 0)
                this.DeleteQuestionDetail(label.DetailId);
            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == label.Id)
                    {
                        if (immp.Control is ExRadioButton)
                        {
                            ExRadioButton rdb = ((ExRadioButton)immp.Control);
                            foreach(ExItem iem in rdb.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExCheckBox)
                        {
                            ExCheckBox chk = ((ExCheckBox)immp.Control);
                            foreach(ExItem iem in chk.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExTable)
                        {
                            ExTable tb = ((ExTable)immp.Control);
                            foreach (ExMultiColumn cols in tb.Column)
                                foreach(ExMultiColumnItem im in cols.Column)
                                    this.DeleteQuestionDetail(im.Id);
                        }
                        else if (immp.Control is ExGroup)
                        {
                            ExGroup eg = ((ExGroup)immp.Control);
                            foreach (ExGroupItem gi in eg.Items)
                                this.DeleteQuestionDetail(gi.Id);
                        }
                        break;
                    }
                }
            }
        }

        private void UpdateGroupQuestion(ItemMapper item, int partId)
        {
            ExGroup group = item.Control as ExGroup;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = multiColumn.Column.Count.ToString();
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.LABEL = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.Group;
            _processUpdateSRQuestions.SR_QUESTIONS.IS_DEFAULT = "N";
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = group.Id;
            _processUpdateSRQuestions.Invoke();

            if (group.DetailId != 0)
            {
                this.DeleteQuestionDetail(group.DetailId);
            }
            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == group.Id)
                    {
                        if (immp.Control is ExRadioButton)
                        {
                            ExRadioButton rdb = ((ExRadioButton)immp.Control);
                            foreach (ExItem iem in rdb.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExCheckBox)
                        {
                            ExCheckBox chk = ((ExCheckBox)immp.Control);
                            foreach (ExItem iem in chk.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExTable)
                        {
                            ExTable tb = ((ExTable)immp.Control);
                            foreach (ExMultiColumn cols in tb.Column)
                                foreach (ExMultiColumnItem im in cols.Column)
                                    this.DeleteQuestionDetail(im.Id);
                        }
                        break;
                    }
                }
            }
            //insert new detail
            if (group.Items.Count > 0)
            {
                //Find old collection
                ExGroup grp = null;
                List<int> newItemId = new List<int>();
                List<int> oldItemId = new List<int>();
                foreach (ItemMapper olditem in tempOldCollection)
                {
                    if (((ControlBase)olditem.Control).Id == group.Id)
                    {
                        grp = olditem.Control as ExGroup;
                        if (grp != null)
                        {
                            foreach (ExGroupItem im in grp.Items)
                            {
                                oldItemId.Add(im.Id);
                            }
                        }
                        break;
                    }
                }
                if (grp != null)
                {
                    foreach (ExGroupItem groupItem in group.Items)
                    {
                        if (groupItem.Id == 0)
                        {
                            ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = group.Id;
                            if (groupItem.Type == GroupChildControlType.Label)
                            {
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Label);
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.Text;
                            }
                            else if (groupItem.Type == GroupChildControlType.TextBox)
                            {
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.TextBox);
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(groupItem.Size);
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultText;
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                            }
                            else if (groupItem.Type == GroupChildControlType.Multiline)
                            {
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Memo);
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(groupItem.Size);
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultText;
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                            }
                            else if (groupItem.Type == GroupChildControlType.Numeric)
                            {
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Number);
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = groupItem.Maximum.ToString();
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultValue.ToString();
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = groupItem.Minimum.ToString();
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                            }
                            else if (groupItem.Type == GroupChildControlType.Image)
                            {
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", -1); ;
                                if (groupItem.Image != null)
                                {
                                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(groupItem.Position);
                                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(groupItem.Image);
                                }
                                else
                                {
                                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                                }
                            }
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                            _processAddSRQuestionDtl.Invoke();
                        }
                        else
                        {
                            ProcessUpdateSRQuestionsDtl _processUpdateSRQuestionDtl = new ProcessUpdateSRQuestionsDtl();
                            //_processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = group.Id;
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL = groupItem.Id;
                            if (groupItem.Type == GroupChildControlType.Label)
                            {
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Label);
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.Text;
                            }
                            else if (groupItem.Type == GroupChildControlType.TextBox)
                            {
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.TextBox);
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(groupItem.Size);
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultText;
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                            }
                            else if (groupItem.Type == GroupChildControlType.Multiline)
                            {
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Memo);
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(groupItem.Size);
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultText;
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                            }
                            else if (groupItem.Type == GroupChildControlType.Numeric)
                            {
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Number);
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = groupItem.Maximum.ToString();
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultValue.ToString();
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = groupItem.Minimum.ToString();
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                            }
                            else if (groupItem.Type == GroupChildControlType.Image)
                            {
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", -1); ;
                                if (groupItem.Image != null)
                                {
                                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(groupItem.Position);
                                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(groupItem.Image);
                                }
                                else
                                {
                                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                                }
                            }
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LAST_MODIFIED_BY = this.UserId;
                            _processUpdateSRQuestionDtl.Invoke();
                            newItemId.Add(groupItem.Id);
                        }
                    }
                    // Delete remove item
                    foreach (int i in oldItemId)
                        if (!newItemId.Contains(i))
                            this.DeleteQuestionDetail(i);
                }
                else
                {
                    //ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                    foreach (ExGroupItem groupItem in group.Items)
                    {
                        ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = group.Id;
                        if (groupItem.Type == GroupChildControlType.Label)
                        {
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Label);
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.Text;
                        }
                        else if (groupItem.Type == GroupChildControlType.TextBox)
                        {
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.TextBox);
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(groupItem.Size);
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultText;
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                        }
                        else if (groupItem.Type == GroupChildControlType.Multiline)
                        {
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Memo);
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(groupItem.Size);
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultText;
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                        }
                        else if (groupItem.Type == GroupChildControlType.Numeric)
                        {
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Number);
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = groupItem.Maximum.ToString();
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultValue.ToString();
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = groupItem.Minimum.ToString();
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                        }
                        else if (groupItem.Type == GroupChildControlType.Image)
                        {
                            _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", -1); ;
                            if (groupItem.Image != null)
                            {
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(groupItem.Position);
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(groupItem.Image);
                            }
                            else
                            {
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                            }
                        }
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                        _processAddSRQuestionDtl.Invoke();
                    }
                }
            }
        }

        private void UpdateDatePickQuestion(ItemMapper item, int partId)
        {
            ExDatePick datePick = item.Control as ExDatePick;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LABEL = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_DEFAULT = datePick.ForceInput == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.DatePick;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = datePick.Id;
            _processUpdateSRQuestions.Invoke();

            if (datePick.DetailId != 0)
            {
                if (datePick.Image != null)
                {
                    ProcessUpdateSRQuestionsDtl _processUpdateSRQuestionDtl = new ProcessUpdateSRQuestionsDtl();
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LAST_MODIFIED_BY = this.UserId;
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL = datePick.DetailId;
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(datePick.Image);
                    _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(datePick.Position);
                    _processUpdateSRQuestionDtl.Invoke();
                }
                else
                {
                    this.DeleteQuestionDetail(datePick.DetailId);
                }
            }
            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == datePick.Id)
                    {
                        if (immp.Control is ExRadioButton)
                        {
                            ExRadioButton rdb = ((ExRadioButton)immp.Control);
                            foreach (ExItem iem in rdb.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExCheckBox)
                        {
                            ExCheckBox chk = ((ExCheckBox)immp.Control);
                            foreach (ExItem iem in chk.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExTable)
                        {
                            ExTable tb = ((ExTable)immp.Control);
                            foreach (ExMultiColumn cols in tb.Column)
                                foreach (ExMultiColumnItem im in cols.Column)
                                    this.DeleteQuestionDetail(im.Id);
                        }
                        else if (immp.Control is ExGroup)
                        {
                            ExGroup eg = ((ExGroup)immp.Control);
                            foreach (ExGroupItem gi in eg.Items)
                                this.DeleteQuestionDetail(gi.Id);
                        }
                        break;
                    }
                }
                if (datePick.Image != null)
                {
                    ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = datePick.Id;
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(datePick.Image);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(datePick.Position);
                    _processAddSRQuestionDtl.Invoke();
                }
            }
        }

        private void UpdateCheckBoxQuestion(ItemMapper item, int partId)
        {
            ExCheckBox checkBox = item.Control as ExCheckBox;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            //_processAddSRQuestions.SR_QUESTIONS.LABEL = label.Text;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            //_processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = label.datePick == true ? "Y" : "N";
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.CheckBox;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = checkBox.Id;
            _processUpdateSRQuestions.Invoke();
            if (checkBox.DetailId != 0)
                this.DeleteQuestionDetail(checkBox.DetailId);

            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == checkBox.Id)
                    {
                        if (immp.Control is ExRadioButton)
                        {
                            ExRadioButton rdb = ((ExRadioButton)immp.Control);
                            foreach (ExItem iem in rdb.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExGroup)
                        {
                            ExGroup eg = ((ExGroup)immp.Control);
                            foreach (ExGroupItem gi in eg.Items)
                                this.DeleteQuestionDetail(gi.Id);
                        }
                        else if (immp.Control is ExTable)
                        {
                            ExTable tb = ((ExTable)immp.Control);
                            foreach (ExMultiColumn cols in tb.Column)
                                foreach (ExMultiColumnItem im in cols.Column)
                                    this.DeleteQuestionDetail(im.Id);
                        }
                        break;
                    }
                }
            }

            if (checkBox.Items.Count > 0)
            {
                ExCheckBox rb1 = null;
                List<int> _radOldItems = new List<int>();
                List<int> _chdOldItems = new List<int>();
                List<int> _radNewItems = new List<int>();
                List<int> _chdNewItems = new List<int>();
                foreach (ItemMapper olditem in tempOldCollection)
                {
                    if (((ControlBase)olditem.Control).Id == checkBox.Id)
                    {
                        rb1 = olditem.Control as ExCheckBox;
                        if (rb1 != null)
                        {
                            foreach (ExItem eit in rb1.Items)
                            {
                                _radOldItems.Add(eit.Id);
                                foreach (ExChild chd in eit.Child)
                                    _chdOldItems.Add(chd.Id);
                            }
                        }
                        break;
                    }
                }
                if (rb1 != null)
                {
                    foreach (ExItem exItem in checkBox.Items)
                    {
                        if (exItem.Id == 0)
                        {
                            this.SaveCheckBoxItem(exItem, checkBox.Id);
                        }
                        else
                        {
                            #region Update Detail
                            //update
                            ProcessUpdateSRQuestionsDtl _processUpdateSRQuestionDtl = new ProcessUpdateSRQuestionsDtl();
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LAST_MODIFIED_BY = this.UserId;
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = exItem.Value;
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.LABEL = exItem.Text;
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = exItem.Check == true ? "Y" : "N";
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL = exItem.Id;
                            if (exItem.Image != null)
                            {
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(exItem.Image);
                                //_processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(exItem.Position);
                            }
                            else
                            {
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                                _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                            }
                            _processUpdateSRQuestionDtl.SR_QUESTIONSDTL.HAS_CHILD = exItem.Child.Count > 0 ? "Y" : "N";
                            _processUpdateSRQuestionDtl.Invoke();
                            #endregion

                            #region Child
                            // Insert Child
                            if (_processUpdateSRQuestionDtl.SR_QUESTIONSDTL.HAS_CHILD == "Y")
                            {

                                foreach (ExChild child in exItem.Child)
                                {
                                    if (child.Id == 0)
                                    {
                                        ProcessAddSRQuestionsDtlChild _processAddSRQuestionDtlChild = new ProcessAddSRQuestionsDtlChild();
                                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID = checkBox.Id;
                                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID_DTL = exItem.Id;
                                        //_processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.QUESION_SIDE = child.Layout == Layouts.Horizontal ? "H" : "V";
                                        if (child.Type == ChildControlTypes.Label)
                                        {
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Label;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.Text;
                                        }
                                        else if (child.Type == ChildControlTypes.TextBox)
                                        {
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.TextBox;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            //if (child.Image != null)
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        else if (child.Type == ChildControlTypes.MemoEdit)
                                        {
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Memo;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            //if (child.Image != null)
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        else if (child.Type == ChildControlTypes.Numeric)
                                        {
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = child.Maximum.ToString();
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultValue.ToString();
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.PROP1 = child.Minimum.ToString();
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                                            //if (child.Image != null)
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.ORG_ID = this.OrgId;
                                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.CREATED_BY = this.UserId;
                                        _processAddSRQuestionDtlChild.Invoke();
                                    }
                                    else
                                    {
                                        ProcessUpdateSRQuestionsDtlChild _processUpdateSRQuestionDtlChild = new ProcessUpdateSRQuestionsDtlChild();
                                        //_processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID = radId;
                                        //_processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID_DTL = child.Id;
                                        _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID_DTL_CHD = child.Id;
                                        //_processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.QUESION_SIDE = child.Layout == Layouts.Horizontal ? "H" : "V";
                                        if (child.Type == ChildControlTypes.Label)
                                        {
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Label;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.Text;
                                        }
                                        else if (child.Type == ChildControlTypes.TextBox)
                                        {
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.TextBox;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            //if (child.Image != null)
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        else if (child.Type == ChildControlTypes.MemoEdit)
                                        {
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Memo;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            //if (child.Image != null)
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        else if (child.Type == ChildControlTypes.Numeric)
                                        {
                                            //_processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = child.Maximum.ToString();
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultValue.ToString();
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.PROP1 = child.Minimum.ToString();
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                                            _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                                            //if (child.Image != null)
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                                            //}
                                            //else
                                            //{
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                                            //    _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                                            //}
                                        }
                                        _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.ORG_ID = this.OrgId;
                                        _processUpdateSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.LAST_MODIFIED_BY = this.UserId;
                                        _processUpdateSRQuestionDtlChild.Invoke();

                                        _chdNewItems.Add(child.Id);
                                    }
                                }


 

                            #endregion

                            }
                            

                            _radNewItems.Add(exItem.Id);
                        }

                    }
                    #region Delete Removed Child
                    foreach (int i in _chdOldItems)
                    {
                        if (!_chdNewItems.Contains(i))
                            this.DeleteQuestionDetailChild(i);
                    }
                    #endregion

                    #region Delete Removed Item
                    foreach (int i in _radOldItems)
                    {
                        if (!_radNewItems.Contains(i))
                            this.DeleteQuestionDetail(i);
                    }
                    #endregion
                }
                else
                {
                    if (checkBox.Items.Count > 0)
                    {
                        foreach (ExItem _radItem in checkBox.Items)
                        {
                            this.SaveCheckBoxItem(_radItem, checkBox.Id);
                        }
                    }
                }
            }
        }

        private void SaveCheckBoxItem(ExItem _radItem, int id)
        {
            ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = _radItem.Value;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = _radItem.Text;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = _radItem.Check == true ? "Y" : "N";
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = id;
            if (_radItem.Image != null)
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(_radItem.Image);
                //_processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(_radItem.Position);
            }
            else
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
            }
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.HAS_CHILD = _radItem.Child.Count > 0 ? "Y" : "N";
            _processAddSRQuestionDtl.Invoke();
            // Insert Child
            if (_processAddSRQuestionDtl.SR_QUESTIONSDTL.HAS_CHILD == "Y")
            {
                foreach (ExChild child in _radItem.Child)
                {
                    ProcessAddSRQuestionsDtlChild _processAddSRQuestionDtlChild = new ProcessAddSRQuestionsDtlChild();
                    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID = id;
                    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID_DTL = _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL;
                    //_processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.QUESION_SIDE = child.Layout == Layouts.Horizontal ? "H" : "V";
                    if (child.Type == ChildControlTypes.Label)
                    {
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Label;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.Text;
                    }
                    else if (child.Type == ChildControlTypes.TextBox)
                    {
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.TextBox;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                        //if (child.Image != null)
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                        //}
                        //else
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                        //}
                    }
                    else if (child.Type == ChildControlTypes.MemoEdit)
                    {
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Memo;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                        //if (child.Image != null)
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                        //}
                        //else
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                        //}
                    }
                    else if (child.Type == ChildControlTypes.Numeric)
                    {
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = child.Maximum.ToString();
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultValue.ToString();
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.PROP1 = child.Minimum.ToString();
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                        //if (child.Image != null)
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                        //}
                        //else
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                        //}
                    }
                    //else if (child.Type == ChildControlTypes.Image)
                    //{
                    //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                    //    if (child.Image != null)
                    //    {
                    //        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                    //        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                    //    }
                    //    else
                    //    {
                    //        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                    //        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                    //    }
                    //}
                    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.ORG_ID = this.OrgId;
                    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.CREATED_BY = this.UserId;
                    _processAddSRQuestionDtlChild.Invoke();
                }
            }
        }
        /// <summary>
        /// Delete question detail
        /// </summary>
        /// <param name="detailId"></param>
        private void DeleteQuestionDetail(int detailId)
        {
            ProcessDeleteSRQuestionsDtl _processDetailQuestionDtl = new ProcessDeleteSRQuestionsDtl();
            _processDetailQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL = detailId;
            _processDetailQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
            _processDetailQuestionDtl.Invoke();
        }

        /// <summary>
        /// Delete child 
        /// </summary>
        /// <param name="i"></param>
        private void DeleteQuestionDetailChild(int i)
        {
            ProcessDeleteSRQuestionsDtlChild _processDeleteQuestionDtlChild = new ProcessDeleteSRQuestionsDtlChild();
            _processDeleteQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID_DTL_CHD = i;
            _processDeleteQuestionDtlChild.SR_QUESTIONSDTLCHILD.ORG_ID = this.OrgId;
            _processDeleteQuestionDtlChild.Invoke();
        }
        private void UpdateNewLine(ItemMapper item, int partId)
        {
            NewLine label = item.Control as NewLine;
            ProcessUpdateSRQuestions _processUpdateSRQuestions = new ProcessUpdateSRQuestions();
            _processUpdateSRQuestions.SR_QUESTIONS.APPEND_NEXT = "N";
            _processUpdateSRQuestions.SR_QUESTIONS.LAST_MODIFIED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.LABEL = label.Text;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processUpdateSRQuestions.SR_QUESTIONS.IS_BOLD = "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_ITALIC = "N";
            _processUpdateSRQuestions.SR_QUESTIONS.IS_UNDERLINE = "N";
            //_processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = label.datePick == true ? "Y" : "N";
            //_processUpdateSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processUpdateSRQuestions.SR_QUESTIONS.QUESTION_SIDE = "H";
            _processUpdateSRQuestions.SR_QUESTIONS.SPACE_BEGIN = 0;
            _processUpdateSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processUpdateSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.NewLine;
            _processUpdateSRQuestions.SR_QUESTIONS.Q_ID = label.Id;
            _processUpdateSRQuestions.Invoke();

            if (label.DetailId != 0)
                this.DeleteQuestionDetail(label.DetailId);
            else
            {
                foreach (ItemMapper immp in tempOldCollection)
                {
                    if (((ControlBase)immp.Control).Id == label.Id)
                    {
                        if (immp.Control is ExRadioButton)
                        {
                            ExRadioButton rdb = ((ExRadioButton)immp.Control);
                            foreach (ExItem iem in rdb.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExCheckBox)
                        {
                            ExCheckBox chk = ((ExCheckBox)immp.Control);
                            foreach (ExItem iem in chk.Items)
                                this.DeleteQuestionDetail(iem.Id);
                        }
                        else if (immp.Control is ExTable)
                        {
                            ExTable tb = ((ExTable)immp.Control);
                            foreach (ExMultiColumn cols in tb.Column)
                                foreach (ExMultiColumnItem im in cols.Column)
                                    this.DeleteQuestionDetail(im.Id);
                        }
                        else if (immp.Control is ExGroup)
                        {
                            ExGroup eg = ((ExGroup)immp.Control);
                            foreach (ExGroupItem gi in eg.Items)
                                this.DeleteQuestionDetail(gi.Id);
                        }
                        break;
                    }
                }
            }
        }
        #endregion

        private States CheckStateDataRow(DataRow dataRow, DataSet oldDsSetUp, int tableIndex)
        {
            if (Convert.ToInt32(dataRow["ID"].ToString()) < 0)
                return States.New;
            foreach (DataRow dr in oldDsSetUp.Tables[tableIndex].Rows)
            {
                if (dr["ID"].ToString() == dataRow["ID"].ToString())
                    return States.Modified;
            }
            return States.Deleted;
        }
        #endregion

        #region Load
        public bool LoadTemplateSetUp(int templateId, ref SR_TEMPLATE templateData
            , ref DataSet dsTemplate, ref ItemMapperCollection itemCollection)
        {
            bool flag = false;
            ProcessGetSRTemplate _processGetSrTemplate = null;
            try
            {
                _processGetSrTemplate = new ProcessGetSRTemplate();
                _processGetSrTemplate.Mode = ProcessGetSRTemplate.Modes.SelectAllById;
                _processGetSrTemplate.SR_TEMPLATE.TEMPLATE_ID = templateId;
                _processGetSrTemplate.SR_TEMPLATE.ORG_ID = this.OrgId;
                _processGetSrTemplate.Invoke();
                dsLoadTemplateAllData = _processGetSrTemplate.Result;
                // fill data to SR_TEMPLATE
                if (dsLoadTemplateAllData.Tables[0].Rows.Count == 0) return flag;
                else
                {
                    if (string.IsNullOrEmpty(dsLoadTemplateAllData.Tables[0].Rows[0]["BP_ID"].ToString()))
                        templateData.BP_ID = 0;
                    else
                        templateData.BP_ID = Convert.ToInt32(dsLoadTemplateAllData.Tables[0].Rows[0]["BP_ID"]);
                    templateData.DESCRIPTION = dsLoadTemplateAllData.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                    templateData.EXAM_ID = Convert.ToInt32(dsLoadTemplateAllData.Tables[0].Rows[0]["EXAM_ID"].ToString());
                    templateData.IS_ACTIVE = dsLoadTemplateAllData.Tables[0].Rows[0]["IS_ACTIVE"].ToString();
                    templateData.LANG_ID = Convert.ToInt32(dsLoadTemplateAllData.Tables[0].Rows[0]["LANG_ID"].ToString());
                    templateData.ORG_ID = Convert.ToInt32(dsLoadTemplateAllData.Tables[0].Rows[0]["ORG_ID"].ToString());
                    templateData.RSNA_URL = dsLoadTemplateAllData.Tables[0].Rows[0]["RSNA_URL"].ToString();
                    templateData.TEMPLATE_ID = templateId;
                    templateData.TEMPLATE_NAME = dsLoadTemplateAllData.Tables[0].Rows[0]["TEMPLATE_NAME"].ToString();
                    templateData.USER_ID = Convert.ToInt32(dsLoadTemplateAllData.Tables[0].Rows[0]["CREATED_BY"].ToString());
                    templateData.CREATOR = dsLoadTemplateAllData.Tables[0].Rows[0]["CREATOR"].ToString();
                    templateData.CREATED_ON = Convert.ToDateTime(dsLoadTemplateAllData.Tables[0].Rows[0]["CREATED_ON"]);
                }
                // get template part
                if (dsLoadTemplateAllData.Tables[1].Rows.Count == 0) return flag;
                else
                {
                    //int count = 1;
                    foreach (DataRow drTemplatePart in dsLoadTemplateAllData.Tables[1].Rows)
                    {
                        DataRow newRowTemplate = dsTemplate.Tables[0].NewRow();
                        DataRow[] questionRow = dsLoadTemplateAllData.Tables[2].Select(string.Format("PART_ID = '{0}'", drTemplatePart["PART_ID"]));
                        newRowTemplate[SRSetUpForm.MT_MASTER_ID] = drTemplatePart["PART_ID"];
                        newRowTemplate[SRSetUpForm.MT_PART_NAME] = drTemplatePart["PART_NAME"].ToString();
                        newRowTemplate[SRSetUpForm.MT_QA] = questionRow.Length;
                        newRowTemplate[SRSetUpForm.MT_SL_NO] = Convert.ToInt32(drTemplatePart["SL"]);
                        dsTemplate.Tables[0].Rows.Add(newRowTemplate);

                        //get question
                        //if (questionRow.Length > 0)
                        //{
                            int countQuestion = 1;
                            foreach (DataRow drQuestion in questionRow)
                            {
                                DataRow newRowQuestion = dsTemplate.Tables[1].NewRow();
                                newRowQuestion[SRSetUpForm.DT_PARENT_ID] = drTemplatePart["PART_ID"];
                                newRowQuestion[SRSetUpForm.DT_DETAIL_ID] = drQuestion["Q_ID"];
                                FontStyle _fStyle = new FontStyle();
                                _fStyle.Bold = drQuestion["IS_BOLD"].ToString() == "Y" ? true : false;
                                _fStyle.Italic = drQuestion["IS_ITALIC"].ToString() == "Y" ? true : false;
                                _fStyle.UnderLine = drQuestion["IS_UNDERLINE"].ToString() == "Y" ? true : false;
                                newRowQuestion[SRSetUpForm.DT_FONT_STYLE] = this.GetFontStyleValue(_fStyle);
                                newRowQuestion[SRSetUpForm.DT_IS_APPEND] = drQuestion["APPEND_NEXT"];
                                newRowQuestion[SRSetUpForm.DT_LAYOUT] = drQuestion["QUESTION_SIDE"].ToString() == "H" ? "Horizontal" : "Vertical";
                                newRowQuestion[SRSetUpForm.DT_QUESTION_TEXT] = drQuestion["QUESTION_TEXT"];
                                newRowQuestion[SRSetUpForm.DT_SL_NO] = countQuestion;
                                newRowQuestion[SRSetUpForm.DT_SPACEING] = drQuestion["SPACE_BEGIN"];
                                newRowQuestion[SRSetUpForm.DT_CONTROL_TYPE] = drQuestion["Q_TYPE_ID"];
                                dsTemplate.Tables[1].Rows.Add(newRowQuestion);
                                ItemMapper itemMapper = this.GetItemMapperCollection(newRowQuestion); //add item collection
                                this.FillControlData(ref itemMapper, drQuestion);
                                itemCollection.Add(itemMapper);
                                _fStyle = null;
                                itemMapper = null;
                                countQuestion++;
                            //}
                        }
                        //count++;
                    }
                }
                //// get question
                //if (dsQueryAll.Tables[2].Rows.Count == 0) return flag;
                //else
                //{

                //}
            }
            catch { }
            finally { }

            return flag;
        }

        private void FillControlData(ref ItemMapper itemMapper, DataRow drQuestion)
        {
            if (itemMapper.Control == null) return;
            else
            {
                if (itemMapper.ControlType == typeof(ExLabel))
                {
                    ExLabel labelControl = itemMapper.Control as ExLabel;
                    if (labelControl != null)
                    {
                        labelControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        labelControl.Text = drQuestion["LABEL"].ToString();
                    }
                }
                else if (itemMapper.ControlType == typeof(ExTextBox))
                {
                    DataRow[] questionDtlRows = dsLoadTemplateAllData.Tables[3].Select(string.Format("Q_ID = '{0}'", drQuestion["Q_ID"]));
                    ExTextBox textBoxControl = itemMapper.Control as ExTextBox;
                    if (textBoxControl != null)
                    {
                        textBoxControl.DefaultText = drQuestion["DEFAULT_VALUE"].ToString();
                        textBoxControl.ForceInput = drQuestion["IS_DEFAULT"].ToString() == "Y" ? true : false;
                        textBoxControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        if (questionDtlRows.Length > 0)
                        {
                            textBoxControl.DetailId = Convert.ToInt32(questionDtlRows[0]["Q_ID_DTL"].ToString());
                            textBoxControl.Image = this.GetImage(questionDtlRows[0]["IMG_DATA"]);
                            textBoxControl.Position = this.GetEnumImagePosition(questionDtlRows[0]["IMG_POSITION"].ToString());
                            textBoxControl.Size = this.GetEnumTextSize(questionDtlRows[0]["TEXT_SIZE"].ToString());
                        }
                    }
                }
                else if (itemMapper.ControlType == typeof(ExCheckBox))
                {
                    DataRow[] questionDtlRows = dsLoadTemplateAllData.Tables[3].Select(string.Format("Q_ID = '{0}'", drQuestion["Q_ID"]));
                    ExCheckBox checkBoxControl = itemMapper.Control as ExCheckBox;
                    if (checkBoxControl != null)
                    {
                        checkBoxControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        checkBoxControl.Items = new ExItemCollection();
                        if (questionDtlRows.Length > 0)
                        {
                            foreach (DataRow qDtlRow in questionDtlRows)
                            {
                                ExItem item = new ExItem();
                                item.Id = Convert.ToInt32(qDtlRow["Q_ID_DTL"].ToString());
                                item.Text = qDtlRow["LABEL"].ToString();
                                item.Value = qDtlRow["DEFAULT_VALUE"].ToString();
                                item.Check = qDtlRow["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                item.Image = this.GetImage(qDtlRow["IMG_DATA"]);
                                //item.Position = this.GetEnumImagePosition(qDtlRow["IMG_POSITION"].ToString());
                                item.Child = new ExChildCollection();

                                #region [ Child Control ]
                                //get child
                                if (qDtlRow["HAS_CHILD"].ToString() == "Y")
                                {
                                    DataRow[] questionDtlChildRows = dsLoadTemplateAllData.Tables[4].Select(string.Format("Q_ID_DTL = '{0}'", qDtlRow["Q_ID_DTL"]));
                                    if (questionDtlChildRows.Length > 0)
                                    {
                                        foreach (DataRow drChild in questionDtlChildRows)
                                        {
                                            ExChild child = new ExChild();
                                            child.Id = Convert.ToInt32(drChild["Q_ID_DTL_CHD"].ToString());
                                            child.Type = this.GetEnumChildControlType(drChild["Q_TYPE_ID"].ToString());

                                            #region [ Fill Data By Type ]
                                            switch (child.Type)
                                            {
                                                case ChildControlTypes.Label:
                                                    child.Text = drChild["DEFAULT_VALUE"].ToString(); break;
                                                case ChildControlTypes.TextBox:
                                                    child.Size = this.GetEnumTextSize(drChild["TEXT_SIZE"].ToString());
                                                    child.ForceInput = drChild["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                                    //child.Layout = drChild["QUESTION_SIDE"].ToString() == "H" ? Layouts.Horizontal : Layouts.Vertical;
                                                    //child.Image = this.GetImage(drChild["IMG_DATA"]);
                                                    //child.Position = this.GetEnumImagePosition(drChild["IMG_POSITION"].ToString());
                                                    break;
                                                case ChildControlTypes.MemoEdit:
                                                    child.Size = this.GetEnumTextSize(drChild["TEXT_SIZE"].ToString());
                                                    child.ForceInput = drChild["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                                    //child.Layout = drChild["QUESTION_SIDE"].ToString() == "H" ? Layouts.Horizontal : Layouts.Vertical;
                                                    //child.Image = this.GetImage(drChild["IMG_DATA"]);
                                                    //child.Position = this.GetEnumImagePosition(drChild["IMG_POSITION"].ToString());
                                                    break;
                                                case ChildControlTypes.Numeric:
                                                    //child.Size = this.GetEnumTextSize(drChild["TEXT_SIZE"].ToString());
                                                    child.ForceInput = drChild["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                                    //child.Layout = drChild["QUESTION_SIDE"].ToString() == "H" ? Layouts.Horizontal : Layouts.Vertical;
                                                    //child.Image = this.GetImage(drChild["IMG_DATA"]);
                                                    //child.Position = this.GetEnumImagePosition(drChild["IMG_POSITION"].ToString());
                                                    try
                                                    {
                                                        child.Maximum = Convert.ToInt32(drChild["TEXT_SIZE"].ToString());
                                                        child.Minimum = Convert.ToInt32(drChild["PROP1"].ToString());
                                                    }
                                                    catch { return; }
                                                    break;
                                            }
                                            #endregion

                                            item.Child.Add(child);
                                        }
                                    }
                                }
                                #endregion

                                checkBoxControl.Items.Add(item);
                            }
                        }
                    }
                }
                else if (itemMapper.ControlType == typeof(ExRadioButton))
                {
                    DataRow[] questionDtlRows = dsLoadTemplateAllData.Tables[3].Select(string.Format("Q_ID = '{0}'", drQuestion["Q_ID"]));
                    ExRadioButton radioButtonControl = itemMapper.Control as ExRadioButton;
                    radioButtonControl.Default = new List<CustomItem>();
                    radioButtonControl.Default.Add(new CustomItem() { Name = "(None)", Selected = false });
                    if (radioButtonControl != null)
                    {
                        radioButtonControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        radioButtonControl.Items = new ExItemCollection();
                        if (questionDtlRows.Length > 0)
                        {
                            foreach (DataRow qDtlRow in questionDtlRows)
                            {
                                ExItem item = new ExItem();
                                item.Id = Convert.ToInt32(qDtlRow["Q_ID_DTL"].ToString());
                                item.Text = qDtlRow["LABEL"].ToString();
                                item.Value = qDtlRow["DEFAULT_VALUE"].ToString();
                                //item.SetDefault = qDtlRow["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                item.Image = this.GetImage(qDtlRow["IMG_DATA"]);
                                //item.Position = this.GetEnumImagePosition(qDtlRow["IMG_POSITION"].ToString());
                                item.Child = new ExChildCollection();

                                CustomItem cItem = new CustomItem();
                                cItem.Name = item.Text;
                                cItem.Selected = qDtlRow["IS_DEFAULT"].ToString() == "Y" ? true : false;

                                #region [ Child Control ]
                                //get child
                                if (qDtlRow["HAS_CHILD"].ToString() == "Y")
                                {
                                    DataRow[] questionDtlChildRows = dsLoadTemplateAllData.Tables[4].Select(string.Format("Q_ID_DTL = '{0}'", qDtlRow["Q_ID_DTL"]));
                                    if (questionDtlChildRows.Length > 0)
                                    {
                                        foreach (DataRow drChild in questionDtlChildRows)
                                        {
                                            ExChild child = new ExChild();
                                            child.Id = Convert.ToInt32(drChild["Q_ID_DTL_CHD"].ToString());
                                            child.Type = this.GetEnumChildControlType(drChild["Q_TYPE_ID"].ToString());

                                            #region [ Fill Data By Type ]
                                            switch (child.Type)
                                            {
                                                case ChildControlTypes.Label:
                                                    child.Text = drChild["DEFAULT_VALUE"].ToString(); break;
                                                case ChildControlTypes.TextBox:
                                                    child.Size = this.GetEnumTextSize(drChild["TEXT_SIZE"].ToString());
                                                    child.ForceInput = drChild["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                                    //child.Layout = drChild["QUESTION_SIDE"].ToString() == "H" ? Layouts.Horizontal : Layouts.Vertical;
                                                    //child.Image = this.GetImage(drChild["IMG_DATA"]);
                                                    //child.Position = this.GetEnumImagePosition(drChild["IMG_POSITION"].ToString());
                                                    break;
                                                case ChildControlTypes.MemoEdit:
                                                    child.Size = this.GetEnumTextSize(drChild["TEXT_SIZE"].ToString());
                                                    child.ForceInput = drChild["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                                    //child.Layout = drChild["QUESTION_SIDE"].ToString() == "H" ? Layouts.Horizontal : Layouts.Vertical;
                                                    //child.Image = this.GetImage(drChild["IMG_DATA"]);
                                                    //child.Position = this.GetEnumImagePosition(drChild["IMG_POSITION"].ToString());
                                                    break;
                                                case ChildControlTypes.Numeric:
                                                    //child.Size = this.GetEnumTextSize(drChild["TEXT_SIZE"].ToString());
                                                    child.ForceInput = drChild["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                                    //child.Layout = drChild["QUESTION_SIDE"].ToString() == "H" ? Layouts.Horizontal : Layouts.Vertical;
                                                    //child.Image = this.GetImage(drChild["IMG_DATA"]);
                                                    //child.Position = this.GetEnumImagePosition(drChild["IMG_POSITION"].ToString());
                                                    try
                                                    {
                                                        child.Maximum = Convert.ToInt32(drChild["TEXT_SIZE"].ToString());
                                                        child.Minimum = Convert.ToInt32(drChild["PROP1"].ToString());
                                                    }
                                                    catch { return; }
                                                    break;
                                            }
                                            #endregion

                                            item.Child.Add(child);
                                        }
                                    }
                                }
                                #endregion

                                radioButtonControl.Items.Add(item);
                                radioButtonControl.Default.Add(cItem);
                            }
                        }
                    }
                }
                else if (itemMapper.ControlType == typeof(ExDatePick))
                {
                    DataRow[] questionDtlRows = dsLoadTemplateAllData.Tables[3].Select(string.Format("Q_ID = '{0}'", drQuestion["Q_ID"]));
                    ExDatePick dateControl = itemMapper.Control as ExDatePick;
                    if (dateControl != null)
                    {
                        dateControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        dateControl.ForceInput = drQuestion["IS_DEFAULT"].ToString() == "Y" ? true : false;
                        if (questionDtlRows.Length > 0)
                        {
                            //when has image
                            dateControl.DetailId = Convert.ToInt32(questionDtlRows[0]["Q_ID_DTL"].ToString());
                            dateControl.Image = this.GetImage(questionDtlRows[0]["IMG_DATA"]);
                            dateControl.Position = this.GetEnumImagePosition(questionDtlRows[0]["IMG_POSITION"].ToString());
                        }
                    }
                }
                else if (itemMapper.ControlType == typeof(ExMemoEdit))
                {
                    DataRow[] questionDtlRows = dsLoadTemplateAllData.Tables[3].Select(string.Format("Q_ID = '{0}'", drQuestion["Q_ID"]));
                    ExMemoEdit memoControl = itemMapper.Control as ExMemoEdit;
                    if (memoControl != null)
                    {
                        memoControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        memoControl.DefaultText = drQuestion["DEFAULT_VALUE"].ToString();
                        memoControl.ForceInput = drQuestion["IS_DEFAULT"].ToString() == "Y" ? true : false;
                        if (questionDtlRows.Length > 0)
                        {
                            memoControl.DetailId = Convert.ToInt32(questionDtlRows[0]["Q_ID_DTL"].ToString());
                            memoControl.Image = this.GetImage(questionDtlRows[0]["IMG_DATA"]);
                            memoControl.Position = this.GetEnumImagePosition(questionDtlRows[0]["IMG_POSITION"].ToString());
                            memoControl.Size = this.GetEnumTextSize(questionDtlRows[0]["TEXT_SIZE"].ToString());
                        }
                    }
                }
                else if (itemMapper.ControlType == typeof(ExSpinEdit))
                {
                    DataRow[] questionDtlRows = dsLoadTemplateAllData.Tables[3].Select(string.Format("Q_ID = '{0}'", drQuestion["Q_ID"]));
                    ExSpinEdit numberControl = itemMapper.Control as ExSpinEdit;
                    if (numberControl != null)
                    {
                        numberControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        numberControl.DefaultValue = Convert.ToInt32(drQuestion["DEFAULT_VALUE"].ToString());
                        numberControl.ForceInput = drQuestion["IS_DEFAULT"].ToString() == "Y" ? true : false;
                        if (questionDtlRows.Length > 0)
                        {
                            numberControl.DetailId = Convert.ToInt32(questionDtlRows[0]["Q_ID_DTL"].ToString());
                            numberControl.Minimum = Convert.ToInt32(questionDtlRows[0]["PROP1"].ToString());
                            numberControl.Maximum = Convert.ToInt32(questionDtlRows[0]["TEXT_SIZE"].ToString());
                            numberControl.Image = this.GetImage(questionDtlRows[0]["IMG_DATA"]);
                            numberControl.Position = this.GetEnumImagePosition(questionDtlRows[0]["IMG_POSITION"].ToString());
                        }
                    }
                }
                else if (itemMapper.ControlType == typeof(ExGroup))
                {
                    DataRow[] questionDtlRows = dsLoadTemplateAllData.Tables[3].Select(string.Format("Q_ID = '{0}'", drQuestion["Q_ID"]));
                    ExGroup groupControl = itemMapper.Control as ExGroup;
                    if (groupControl != null)
                    {
                        groupControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        groupControl.Items = new ExGroupItemCollection();
                        if (questionDtlRows.Length > 0)
                        {
                            #region Group Item
                            foreach (DataRow drQuestionDtl in questionDtlRows)
                            {
                                ExGroupItem groupItem = new ExGroupItem();
                                groupItem.Id = Convert.ToInt32(drQuestionDtl["Q_ID_DTL"].ToString());
                                groupItem.Type = this.GetGroupItemType(drQuestionDtl["LABEL"].ToString());
                                switch (groupItem.Type)
                                {
                                    case GroupChildControlType.Label:
                                        groupItem.Text = drQuestionDtl["DEFAULT_VALUE"].ToString();
                                        break;
                                    case GroupChildControlType.TextBox:
                                        groupItem.DefaultText = drQuestionDtl["DEFAULT_VALUE"].ToString();
                                        groupItem.ForceInput = drQuestionDtl["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                        groupItem.Size = this.GetEnumTextSize(drQuestionDtl["TEXT_SIZE"].ToString());
                                        break;
                                    case GroupChildControlType.Multiline:
                                        groupItem.DefaultText = drQuestionDtl["DEFAULT_VALUE"].ToString();
                                        groupItem.ForceInput = drQuestionDtl["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                        groupItem.Size = this.GetEnumTextSize(drQuestionDtl["TEXT_SIZE"].ToString());
                                        break;
                                    case GroupChildControlType.Numeric:
                                        groupItem.DefaultValue = Convert.ToInt32(drQuestionDtl["DEFAULT_VALUE"].ToString());
                                        groupItem.ForceInput = drQuestionDtl["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                        groupItem.Minimum = Convert.ToInt32(drQuestionDtl["PROP1"].ToString());
                                        groupItem.Maximum = Convert.ToInt32(drQuestionDtl["TEXT_SIZE"].ToString());
                                        break;
                                    case GroupChildControlType.Image:
                                        groupItem.Image = this.GetImage(drQuestionDtl["IMG_DATA"]);
                                        groupItem.Position = this.GetEnumImagePosition(drQuestionDtl["IMG_POSITION"].ToString());
                                        break;
                                }
                                groupControl.Items.Add(groupItem);
                            }
                            #endregion
                        }
                    }
                }
                else if (itemMapper.ControlType == typeof(ExTable))
                {
                    DataRow[] questionDtlRows = dsLoadTemplateAllData.Tables[3].Select(string.Format("Q_ID = '{0}'", drQuestion["Q_ID"]));
                    ExTable multiColumnControl = itemMapper.Control as ExTable;
                    if (multiColumnControl != null)
                    {
                        multiColumnControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        multiColumnControl.Selection = drQuestion["IS_DEFAULT"].ToString() == "S" ? SelectionTypes.Single : SelectionTypes.Multiple;
                        multiColumnControl.Column = new ExMultiColumnCollection();
                        if (drQuestion["DEFAULT_VALUE"].ToString() != string.Empty)
                        {
                            int numGroup = Convert.ToInt32(drQuestion["DEFAULT_VALUE"].ToString());
                            for (int i = 1; i <= numGroup; i++)
                            {
                                ExMultiColumn column = new ExMultiColumn();
                                foreach (DataRow drDtlrow in questionDtlRows)
                                {
                                    if (drDtlrow["PROP1"].ToString() == i.ToString())
                                    {
                                        ExMultiColumnItem columnItem = new ExMultiColumnItem();
                                        columnItem.Id = Convert.ToInt32(drDtlrow["Q_ID_DTL"].ToString());
                                        columnItem.Default = drDtlrow["IS_DEFAULT"].ToString() == "Y" ? true : false;
                                        columnItem.Text = drDtlrow["LABEL"].ToString();
                                        columnItem.Value = drDtlrow["DEFAULT_VALUE"].ToString();
                                        column.Column.Add(columnItem);
                                    }
                                }
                                multiColumnControl.Column.Add(column);
                            }
                        }
                    }
                }else if (itemMapper.ControlType == typeof(NewLine))
                {
                    NewLine labelControl = itemMapper.Control as NewLine;
                    if (labelControl != null)
                    {
                        labelControl.Id = Convert.ToInt32(drQuestion["Q_ID"].ToString());
                        labelControl.Text = drQuestion["LABEL"].ToString();
                    }
                }
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// Save Template
        /// </summary>
        /// <param name="templateData"></param>
        /// <param name="dsSetUp"></param>
        /// <param name="itemCollection"></param>
        /// <returns></returns>
        public bool SaveTemplate(ref SR_TEMPLATE templateData, DataSet dsSetUp, ItemMapperCollection itemCollection)
        {
            bool flag = false;
            int templateId = 0;
            this.tempCollection = itemCollection;
            ProcessAddSRTemplate _processAddSRTemplate = null;

            #region Save Template Data
            try
            {
                _processAddSRTemplate = new ProcessAddSRTemplate();
                _processAddSRTemplate.SR_TEMPLATE = templateData;
                _processAddSRTemplate.Invoke();
                templateId = _processAddSRTemplate.SR_TEMPLATE.TEMPLATE_ID;
                templateData.TEMPLATE_ID = templateId;
                this.SaveTemplatePart(templateId, dsSetUp);

                flag = true;
            }
            catch(Exception ex) { flag = false; }
            finally
            {
                _processAddSRTemplate = null;
                this.tempCollection = null;
            }
            #endregion

            return flag;
        }

        #region Save Template Part
        /// <summary>
        /// Save Template part
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="dsSetUp"></param>
        private void SaveTemplatePart(int templateId, DataSet dsSetUp)
        {
            if (dsSetUp.Tables[0] != null)
            {
                if (dsSetUp.Tables[0].Rows.Count > 0)
                {
                    ProcessAddSRTemplatePart _processAddTemplatePart = new ProcessAddSRTemplatePart();
                    foreach (DataRow drTemplatePart in dsSetUp.Tables[0].Rows)
                    {
                        if (drTemplatePart[SRSetUpForm.MT_PART_NAME].ToString().Trim() != string.Empty)
                        {
                            _processAddTemplatePart.SR_TEMPLATEPART.CREATED_BY = this.UserId;
                            _processAddTemplatePart.SR_TEMPLATEPART.ORG_ID = this.OrgId;
                            _processAddTemplatePart.SR_TEMPLATEPART.PART_NAME = drTemplatePart[SRSetUpForm.MT_PART_NAME].ToString();
                            _processAddTemplatePart.SR_TEMPLATEPART.SL = Convert.ToInt32(drTemplatePart[SRSetUpForm.MT_SL_NO].ToString());
                            _processAddTemplatePart.SR_TEMPLATEPART.TEMPLATE_ID = templateId;
                            _processAddTemplatePart.Invoke();
                            this.SaveQuestion(_processAddTemplatePart.SR_TEMPLATEPART.PART_ID, Convert.ToInt32(drTemplatePart[SRSetUpForm.MT_MASTER_ID]));
                        }
                    }
                }
            }
        }
        #endregion

        #region Save Question
        /// <summary>
        /// Save Question
        /// </summary>
        /// <param name="partId"></param>
        /// <param name="masterId"></param>
        private void SaveQuestion(int partId, int masterId)
        {
            List<ItemMapper> itemList = this.GetQuestionByTemplatePart(masterId);
            if (itemList.Count > 0)
            {
                //ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
                foreach (ItemMapper item in itemList)
                {
                    if (item.ControlType == typeof(ExCheckBox))
                        this.SaveCheckBoxQuestion(item, partId);
                    else if (item.ControlType == typeof(ExDatePick))
                        this.SaveDatePickQuestion(item, partId);
                    else if (item.ControlType == typeof(ExGroup))
                        this.SaveGroupQuestion(item, partId);
                    else if (item.ControlType == typeof(ExLabel))
                        this.SaveLabelQuestion(item, partId);
                    else if (item.ControlType == typeof(ExMemoEdit))
                        this.SaveMemoQuestion(item, partId);
                    else if (item.ControlType == typeof(ExTable))
                        this.SaveMultiColumnQuestion(item, partId);
                    else if (item.ControlType == typeof(ExRadioButton))
                        this.SaveRadioButtonQuestion(item, partId);
                    else if (item.ControlType == typeof(ExSpinEdit))
                        this.SaveNumberQuestion(item, partId);
                    else if (item.ControlType == typeof(ExTextBox))
                        this.SaveTextBoxQuestion(item, partId);
                    else if (item.ControlType == typeof(NewLine))
                        this.SaveNewLine(item, partId);
                }
            }

        }
        /// <summary>
        /// Get Question by template part
        /// </summary>
        /// <param name="masterId"></param>
        /// <returns></returns>
        public List<ItemMapper> GetQuestionByTemplatePart(int masterId)
        {
            List<ItemMapper> itemList = new List<ItemMapper>();
            foreach (ItemMapper item in this.tempCollection)
            {
                if (Convert.ToInt32(item.Row[SRSetUpForm.DT_PARENT_ID]) == masterId)
                {
                    ItemMapper tempItem = new ItemMapper();
                    tempItem.Row = item.Row;
                    tempItem.Control = item.Control;
                    tempItem.ControlType = item.ControlType;
                    itemList.Add(tempItem);
                }
            }
            return itemList;
        }

        /// <summary>
        /// Get Question by template part
        /// </summary>
        /// <param name="masterId"></param>
        /// <returns></returns>
        public List<ItemMapper> GetOldQuestionByTemplatePart(int masterId)
        {
            List<ItemMapper> itemList = new List<ItemMapper>();
            foreach (ItemMapper item in this.tempOldCollection)
            {
                if (Convert.ToInt32(item.Row[SRSetUpForm.DT_PARENT_ID]) == masterId)
                {
                    ItemMapper tempItem = new ItemMapper();
                    tempItem.Row = item.Row;
                    tempItem.Control = item.Control;
                    tempItem.ControlType = item.ControlType;
                    itemList.Add(tempItem);
                }
            }
            return itemList;
        }
        #endregion

        #region Save Question By Type
        /// <summary>
        /// Text Box Question
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="partId">part id</param>
        private void SaveTextBoxQuestion(ItemMapper item, int partId)
        {
            ExTextBox textbox = item.Control as ExTextBox;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            _processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = textbox.DefaultText;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = textbox.ForceInput == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.TextBox;
            _processAddSRQuestions.Invoke();

            ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = _processAddSRQuestions.SR_QUESTIONS.Q_ID;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(textbox.Size);
            if (textbox.Image != null)
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(textbox.Image);
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(textbox.Position);
            }
            else
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
            }
            _processAddSRQuestionDtl.Invoke();
        }

        /// <summary>
        /// Number Question
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="partId">part id</param>
        private void SaveNumberQuestion(ItemMapper item, int partId)
        {
            ExSpinEdit spinEdit = item.Control as ExSpinEdit;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            _processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = spinEdit.ForceInput == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.Number;
            _processAddSRQuestions.Invoke();

            ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = spinEdit.Maximum.ToString();
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = _processAddSRQuestions.SR_QUESTIONS.Q_ID;
            if (spinEdit.Image != null)
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(spinEdit.Image);
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(spinEdit.Position);
            }
            else
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
            }
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = spinEdit.Minimum.ToString();
            _processAddSRQuestionDtl.Invoke();
        }

        /// <summary>
        /// Single answer Question
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="partId">part id</param>
        private void SaveRadioButtonQuestion(ItemMapper item, int partId)
        {
            ExRadioButton radioButton = item.Control as ExRadioButton;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            //_processAddSRQuestions.SR_QUESTIONS.LABEL = label.Text;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            //_processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = label.datePick == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.RadioBox;
            _processAddSRQuestions.Invoke();

            string defaultName = string.Empty;
            foreach (CustomItem cItem in radioButton.Default)
                if (cItem.Selected)
                {
                    defaultName = cItem.Name;
                    break;
                }

            if (radioButton.Items.Count > 0)
            {
                foreach (ExItem _radItem in radioButton.Items)
                {
                    this.SaveRadioButtonItem(_radItem, defaultName, _processAddSRQuestions.SR_QUESTIONS.Q_ID);
                }
            }
        }
        /// <summary>
        /// Multi column Question
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="partId">part id</param>
        private void SaveMultiColumnQuestion(ItemMapper item, int partId)
        {
            ExTable multiColumn = item.Control as ExTable;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            _processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = multiColumn.Column.Count.ToString();
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.LABEL = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.NColumn;
            _processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = multiColumn.Selection == SelectionTypes.Single ? "S" : "M";
            _processAddSRQuestions.Invoke();
            if (multiColumn.Column.Count > 0)
            {
                ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                for (int i = 0; i < multiColumn.Column.Count; i++)
                {
                    foreach (ExMultiColumnItem columnItem in multiColumn.Column[i].Column)
                    {
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = _processAddSRQuestions.SR_QUESTIONS.Q_ID;
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = columnItem.Text;
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = columnItem.Value;
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = columnItem.Default == true ? "Y" : "N";
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = (i + 1).ToString();
                        _processAddSRQuestionDtl.Invoke();
                    }
                }
            }
        }
        /// <summary>
        /// Memo Question
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="partId">part id</param>
        private void SaveMemoQuestion(ItemMapper item, int partId)
        {
            ExMemoEdit memoEdit = item.Control as ExMemoEdit;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            _processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = memoEdit.DefaultText;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = memoEdit.ForceInput == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.Memo;
            _processAddSRQuestions.Invoke();

            ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(memoEdit.Size);
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = _processAddSRQuestions.SR_QUESTIONS.Q_ID;
            if (memoEdit.Image != null)
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(memoEdit.Image);
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(memoEdit.Position);
            }
            else
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
            }
            _processAddSRQuestionDtl.Invoke();
        }
        /// <summary>
        /// Label Question
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="partId">part id</param>
        private void SaveLabelQuestion(ItemMapper item, int partId)
        {
            ExLabel label = item.Control as ExLabel;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            //_processAddSRQuestions.SR_QUESTIONS.LABEL = label.Text;
            _processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = label.Text;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            //_processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = label.datePick == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.Label;
            _processAddSRQuestions.Invoke();
        }
        /// <summary>
        /// Group Question
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="partId">part id</param>
        private void SaveGroupQuestion(ItemMapper item, int partId)
        {
            ExGroup group = item.Control as ExGroup;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = multiColumn.Column.Count.ToString();
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.LABEL = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.Group;
            _processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = "N";
            _processAddSRQuestions.Invoke();

            //ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
            foreach (ExGroupItem groupItem in group.Items)
            {
                ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = _processAddSRQuestions.SR_QUESTIONS.Q_ID;
                if (groupItem.Type == GroupChildControlType.Label)
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Label);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.Text;
                }
                else if (groupItem.Type == GroupChildControlType.TextBox)
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.TextBox);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(groupItem.Size);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultText;
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                }
                else if (groupItem.Type == GroupChildControlType.Multiline)
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Memo);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = this.GetTextSize(groupItem.Size);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultText;
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                }
                else if (groupItem.Type == GroupChildControlType.Numeric)
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", (int)Controls.Number);
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.TEXT_SIZE = groupItem.Maximum.ToString();
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = groupItem.DefaultValue.ToString();
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.PROP1 = groupItem.Minimum.ToString();
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = groupItem.ForceInput == true ? "Y" : "N";
                }
                else if (groupItem.Type == GroupChildControlType.Image)
                {
                    _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = string.Format("#@#{0}#@#", -1); ;
                    if (groupItem.Image != null)
                    {
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(groupItem.Position);
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(groupItem.Image);
                    }
                    else
                    {
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
                        _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                    }
                }
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                _processAddSRQuestionDtl.Invoke();
            }
        }

        /// <summary>
        /// Date pick Question
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="partId">part id</param>
        private void SaveDatePickQuestion(ItemMapper item, int partId)
        {
            ExDatePick datePick = item.Control as ExDatePick;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            _processAddSRQuestions.SR_QUESTIONS.LABEL = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = datePick.ForceInput == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.DatePick;
            _processAddSRQuestions.Invoke();

            ///If has Image 
            if (datePick.Image != null)
            {
                ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = _processAddSRQuestions.SR_QUESTIONS.Q_ID;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(datePick.Image);
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(datePick.Position);
                _processAddSRQuestionDtl.Invoke();
            }
        }

        /// <summary>
        /// Check Box Question
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="partId">part id</param>
        private void SaveCheckBoxQuestion(ItemMapper item, int partId)
        {
            ExCheckBox checkBox = item.Control as ExCheckBox;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = item.Row[SRSetUpForm.DT_IS_APPEND].ToString();
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            //_processAddSRQuestions.SR_QUESTIONS.LABEL = label.Text;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = _fStyle.Bold == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = _fStyle.Italic == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = _fStyle.UnderLine == true ? "Y" : "N";
            //_processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = label.datePick == true ? "Y" : "N";
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = item.Row[SRSetUpForm.DT_LAYOUT].ToString() == "Horizontal" ? "H" : "V";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = Convert.ToInt32(item.Row[SRSetUpForm.DT_SPACEING].ToString());
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.CheckBox;
            _processAddSRQuestions.Invoke();

            if (checkBox.Items.Count > 0)
            {
                foreach (ExItem _radItem in checkBox.Items)
                {
                    this.SaveCheckBoxItem(_radItem, _processAddSRQuestions.SR_QUESTIONS.Q_ID);
                }
            }
        }

        private void SaveRadioButtonItem(ExItem _radItem, string defaultName, int radId)
        {
            ProcessAddSRQuestionsDtl _processAddSRQuestionDtl = new ProcessAddSRQuestionsDtl();
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.CREATED_BY = this.UserId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.DEFAULT_VALUE = _radItem.Value;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.LABEL = _radItem.Text;
            if (_radItem.Text == defaultName)
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = "Y";
            else
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IS_DEFAULT = "N";

            _processAddSRQuestionDtl.SR_QUESTIONSDTL.ORG_ID = this.OrgId;
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID = radId;
            if (_radItem.Image != null)
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = this.GetImageData(_radItem.Image);
                //_processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = this.GetImagePosition(_radItem.Position);
            }
            else
            {
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_DATA = null;
                _processAddSRQuestionDtl.SR_QUESTIONSDTL.IMG_POSITION = null;
            }
            _processAddSRQuestionDtl.SR_QUESTIONSDTL.HAS_CHILD = _radItem.Child.Count > 0 ? "Y" : "N";
            _processAddSRQuestionDtl.Invoke();
            // Insert Child
            if (_processAddSRQuestionDtl.SR_QUESTIONSDTL.HAS_CHILD == "Y")
            {
                ProcessAddSRQuestionsDtlChild _processAddSRQuestionDtlChild = new ProcessAddSRQuestionsDtlChild();
                foreach (ExChild child in _radItem.Child)
                {
                    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID = radId;
                    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_ID_DTL = _processAddSRQuestionDtl.SR_QUESTIONSDTL.Q_ID_DTL;
                    //_processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.QUESION_SIDE = child.Layout == Layouts.Horizontal ? "H" : "V";
                    if (child.Type == ChildControlTypes.Label)
                    {
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Label;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.Text;
                    }
                    else if (child.Type == ChildControlTypes.TextBox)
                    {
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.TextBox;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                        //if (child.Image != null)
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                        //}
                        //else
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                        //}
                    }
                    else if (child.Type == ChildControlTypes.MemoEdit)
                    {
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Memo;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = this.GetTextSize(child.Size);
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultText;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                        //if (child.Image != null)
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                        //}
                        //else
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                        //}
                    }
                    else if (child.Type == ChildControlTypes.Numeric)
                    {
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.TEXT_SIZE = child.Maximum.ToString();
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE = child.DefaultValue.ToString();
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.PROP1 = child.Minimum.ToString();
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IS_DEFAULT = child.ForceInput == true ? "Y" : "N";
                        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                        //if (child.Image != null)
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                        //}
                        //else
                        //{
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                        //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                        //}
                    }
                    //else if (child.Type == ChildControlTypes.Image)
                    //{
                    //    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.Q_TYPE_ID = (int)Controls.Number;
                    //    if (child.Image != null)
                    //    {
                    //        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = this.GetImagePosition(child.Position);
                    //        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = this.GetImageData(child.Image);
                    //    }
                    //    else
                    //    {
                    //        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_POSITION = null;
                    //        _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.IMG_DATA = null;
                    //    }
                    //}
                    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.ORG_ID = this.OrgId;
                    _processAddSRQuestionDtlChild.SR_QUESTIONSDTLCHILD.CREATED_BY = this.UserId;
                    _processAddSRQuestionDtlChild.Invoke();
                }
            }
        }
        private void SaveNewLine(ItemMapper item, int partId)
        {
            NewLine label = item.Control as NewLine;
            ProcessAddSRQuestions _processAddSRQuestions = new ProcessAddSRQuestions();
            _processAddSRQuestions.SR_QUESTIONS.APPEND_NEXT = "N";
            _processAddSRQuestions.SR_QUESTIONS.CREATED_BY = this.UserId;
            //_processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = spinEdit.DefaultValue.ToString();
            //_processAddSRQuestions.SR_QUESTIONS.LABEL = label.Text;
            _processAddSRQuestions.SR_QUESTIONS.DEFAULT_VALUE = label.Text;
            FontStyle _fStyle = this.GetFontStyle(item.Row[SRSetUpForm.DT_FONT_STYLE].ToString());
            _processAddSRQuestions.SR_QUESTIONS.IS_BOLD = "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_ITALIC = "N";
            _processAddSRQuestions.SR_QUESTIONS.IS_UNDERLINE = "N";
            //_processAddSRQuestions.SR_QUESTIONS.IS_DEFAULT = label.datePick == true ? "Y" : "N";
            //_processAddSRQuestions.SR_QUESTIONS.QUESTION_TEXT = item.Row[SRSetUpForm.DT_QUESTION_TEXT].ToString();
            _processAddSRQuestions.SR_QUESTIONS.QUESTION_SIDE = "H";
            _processAddSRQuestions.SR_QUESTIONS.SPACE_BEGIN = 1;
            _processAddSRQuestions.SR_QUESTIONS.ORG_ID = this.OrgId;
            _processAddSRQuestions.SR_QUESTIONS.PART_ID = partId;
            _processAddSRQuestions.SR_QUESTIONS.Q_TYPE_ID = (int)Controls.NewLine;
            _processAddSRQuestions.Invoke();
        }
        #endregion

        #endregion

        #region Ultility

        /// <summary>
        /// Get font style
        /// </summary>
        /// <param name="fStr"></param>
        /// <returns></returns>
        public FontStyle GetFontStyle(string fStr)
        {
            if (string.IsNullOrEmpty(fStr)) return new FontStyle();
            else
            {
                FontStyle fStyle = new FontStyle();
                string[] spfStr = fStr.Split(',');
                foreach (string ch in spfStr)
                {
                    switch (ch.Trim())
                    {
                        case "0": fStyle.Bold = true; break;
                        case "1": fStyle.Italic = true; break;
                        case "2": fStyle.UnderLine = true; break;
                    }
                }
                return fStyle;
            }
        }
        /// <summary>
        /// Get control size
        /// </summary>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public string GetTextSize(Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.Sizes sizes)
        {
            switch (sizes)
            {
                case Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.Sizes.Double: return "D";
                case Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.Sizes.Half: return "H";
                case Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.Sizes.Normal: return "N";
                default: return "N";
            }
        }
        /// <summary>
        /// Get image data
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public byte[] GetImageData(Image imageSoruce)
        {
            ImageConverter converter = null;
            try
            {
                //Image img = Image.FromFile(imageSoruce);
                converter = new ImageConverter();
                return (byte[])converter.ConvertTo(imageSoruce, typeof(byte[]));
            }
            catch { return null; }
            finally
            {
                converter = null;
            }
        }

        /// <summary>
        /// Get image position
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public string GetImagePosition(Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.Positions positions)
        {
            switch (positions)
            {
                case Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.Positions.Bottom: return "B";
                case Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.Positions.Left: return "L";
                case Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.Positions.Right: return "R";
                case Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.Positions.Top: return "T";
                default: return "L";
            }
        }

        /// <summary>
        /// Get Group item type
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        private GroupChildControlType GetGroupItemType(string strType)
        {
            string str = strType.Replace('#', ' ').Replace('@', ' ');
            str = str.Trim();
            switch (str)
            {
                case "-1": return GroupChildControlType.Image;
                case "1": return GroupChildControlType.Label;
                case "2": return GroupChildControlType.TextBox;
                case "7": return GroupChildControlType.Numeric;
                case "6": return GroupChildControlType.Multiline;
                default: return GroupChildControlType.Label;
            }
        }
        /// <summary>
        /// get enum text size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private Sizes GetEnumTextSize(string size)
        {
            switch (size)
            {
                case "H": return Sizes.Half;
                case "N": return Sizes.Normal;
                case "D": return Sizes.Double;
                default: return Sizes.Normal;
            }
        }
        /// <summary>
        /// get enum child control type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private ChildControlTypes GetEnumChildControlType(string type)
        {
            switch (type)
            {
                case "1": return ChildControlTypes.Label;
                case "2": return ChildControlTypes.TextBox;
                case "7": return ChildControlTypes.Numeric;
                case "6": return ChildControlTypes.MemoEdit;
                default: return ChildControlTypes.Label;
            }
        }
        /// <summary>
        /// get Enum image position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private Positions GetEnumImagePosition(string position)
        {
            switch (position)
            {
                case "T": return Positions.Top;
                case "B": return Positions.Bottom;
                case "L": return Positions.Left;
                case "R": return Positions.Right;
                default: return Positions.Left;
            }
        }
        /// <summary>
        /// Get Image 
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        private Image GetImage(object imageData)
        {
            if (imageData != null)
            {
                ImageConverter conv = null;
                try
                {
                    byte[] imgByte = (byte[])imageData;
                    conv = new ImageConverter();
                    return (Image)conv.ConvertFrom(imgByte);
                }
                catch { return null; }
                finally { conv = null; }
            }
            return null;
        }

        private ItemMapper GetItemMapperCollection(DataRow newRowQuestion)
        {
            ItemMapper item = new ItemMapper();
            //Selector control type
            switch (newRowQuestion[SRSetUpForm.DT_CONTROL_TYPE].ToString())
            {
                case "1": item.ControlType = typeof(ExLabel); break;
                case "2": item.ControlType = typeof(ExTextBox); break;
                case "3": item.ControlType = typeof(ExCheckBox); break;
                case "4": item.ControlType = typeof(ExRadioButton); break;
                case "5": item.ControlType = typeof(ExDatePick); break;
                case "6": item.ControlType = typeof(ExMemoEdit); break;
                case "7": item.ControlType = typeof(ExSpinEdit); break;
                case "8": item.ControlType = typeof(ExGroup); break;
                case "9": item.ControlType = typeof(ExTable); break;
                case "10": item.ControlType = typeof(NewLine); break;
            }
            item.Row = newRowQuestion;
            item.Control = Activator.CreateInstance(item.ControlType); //create instance
            return item;
        }

        private string GetFontStyleValue(FontStyle _fStyle)
        {
            StringBuilder strBuilder = new StringBuilder();
            if (_fStyle.Bold)
                strBuilder.Append("0, ");
            if (_fStyle.Italic)
                strBuilder.Append("1, ");
            if (_fStyle.UnderLine)
                strBuilder.Append("2, ");

            return strBuilder.ToString().Trim().TrimEnd(',');
        }

        #endregion

    }

    #region Collection Class
    public class QuestionTypeCollection : CollectionBase
    {
        public QuestionTypeCollection()
		{
			
		}

        public int Add(SR_QUESTIONTYPE e)
		{
			return this.InnerList.Add(e);
		}

        public void AddRange(SR_QUESTIONTYPE[] es)
		{
			this.InnerList.AddRange(es);	
		}

        public void Remove(SR_QUESTIONTYPE e)
		{
			InnerList.Remove(e);
		}

		public new void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

        public bool Contains(SR_QUESTIONTYPE e)
		{
			return InnerList.Contains(e);
		}

        public SR_QUESTIONTYPE this[int index]
		{
            get { return (SR_QUESTIONTYPE)this.InnerList[index]; }
			set{this.InnerList[index]= value;}
		}
    }
    #endregion

    #region Hepler Class
    public class Helper
    {
        /// <summary>
        /// Use to check datarow form data set
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static bool HaveDataRow(DataSet ds)
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    #endregion
}
