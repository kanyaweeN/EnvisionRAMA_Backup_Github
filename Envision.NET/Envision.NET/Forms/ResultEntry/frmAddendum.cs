using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

using Envision.NET.Forms.ResultEntry;
using Envision.NET.Forms.ResultEntry.Common;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Operational.PACS;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpellChecker;
using System.Globalization;
using DevExpress.Utils.Menu;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using System.IO;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmAddendum : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string accession_no;
        private int order_id;
        private string hn;
        private int exam_id;
        private string exam_uid;
        private string exam_name;
        private ColorPopupRichText cpFontColor;
        private ColorPopupRichText cpBGFontColor;
        private Envision.BusinessLogic.ResultEntry result;
        private bool update = true;
        private GBLEnvVariable env;
        private MyMessageBox msg;
        private DataSet dsData;
        private DataRow drData;
        private int AddNO = 1;
        public GBL_RADEXPERIENCE rad { get; set; }
        //Popup richeditcontrol
        private LookAndFeelMenu menu = null;
        IDXMenuManager fMenuManager;

        string[] retValue;

        public frmAddendum()
        {
            InitializeComponent();
            rtResult.BackColor = Color.White;
            result = new Envision.BusinessLogic.ResultEntry();
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            accession_no = string.Empty;
            order_id = 0;
            exam_id = 0;
            hn = string.Empty;
            exam_name = string.Empty;

        }
        public frmAddendum(string AccessionNo, string ExamName, int OrderID, string HN)
        {
            InitializeComponent();
            rtResult.BackColor = Color.LightCyan;
            result = new Envision.BusinessLogic.ResultEntry();
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            rad = new GBL_RADEXPERIENCE();
            result = new Envision.BusinessLogic.ResultEntry();

            accession_no = AccessionNo;
            order_id = OrderID;
            hn = HN;
            exam_name = ExamName;
            
        }

        private void frmAddendum_Load(object sender, EventArgs e)
        {
            initEdit(false);
            loadPatient();
            loadData();

            SetDefaultFont(rtPad);
            SetPaperDefalt();

            #region Add Dictionary
            DictionaryStorage.Dictionaries.Clear();
            AddDictionaries(DictionaryStorage);
            spellChecker1.SpellCheckMode = SpellCheckMode.AsYouType;

            #endregion

            rtPad.Focus();

        }
        private void AddDictionaries(SharedDictionaryStorage storage)
        {
            CultureInfo engCulture = new CultureInfo("en-us");
            if (storage.Dictionaries.Count == 0)
            {
                SpellCheckerISpellDictionary dictionary = new SpellCheckerISpellDictionary("C:\\Program Files\\Envision_Dic\\american.xlg", "C:\\Program Files\\Envision_Dic\\english.aff", engCulture);
                dictionary.AlphabetPath = "C:\\Program Files\\Envision_Dic\\EnglishAlphabet.txt";
                dictionary.Load();
                storage.Dictionaries.Add(dictionary);
                SpellCheckerCustomDictionary customDictionary = new SpellCheckerCustomDictionary("C:\\Program Files\\Envision_Dic\\CustomEnglish.dic", engCulture);
                customDictionary.Load();
                storage.Dictionaries.Add(customDictionary);
            }
        }
        
        private void SetPaperDefalt()
        {
            #region Set Paper

            rtPad.Document.Sections[0].Page.PaperKind = System.Drawing.Printing.PaperKind.A5;
            rtPad.Document.Sections[0].Page.Landscape = true;
            rtPad.Document.Sections[0].Margins.Left = 100;

            #endregion
        }
        private void SetDefaultFont()
        {
            #region Set Font
            Document doc = rtPad.Document;

            DocumentRange sel = rtPad.Document.Range;
            CharacterProperties charProperties = rtPad.Document.BeginUpdateCharacters(sel);
            charProperties.FontName = rad.FONT_FACE;//"Microsoft Sans Serif";
            charProperties.FontSize = rad.FONT_SIZE;
            rtPad.Document.EndUpdateCharacters(charProperties);

            ParagraphProperties pp = doc.BeginUpdateParagraphs(sel);
            // Set triple spacing
            pp.LineSpacingType = ParagraphLineSpacing.Multiple;
            pp.LineSpacingMultiplier = (float)1.3;
            doc.EndUpdateParagraphs(pp);

            #endregion
        }
        private void SetDefaultFont(DevExpress.XtraRichEdit.RichEditControl rtTemp)
        {
            Document doc = rtTemp.Document;

            DocumentRange sel = rtTemp.Document.Range;
            CharacterProperties charProperties = rtTemp.Document.BeginUpdateCharacters(sel);
            charProperties.FontName = rad.FONT_FACE;//"Microsoft Sans Serif";
            charProperties.FontSize = rad.FONT_SIZE;
            rtTemp.Document.EndUpdateCharacters(charProperties);

            ParagraphProperties pp = doc.BeginUpdateParagraphs(sel);
            // Set triple spacing
            pp.LineSpacingType = ParagraphLineSpacing.Multiple;
            pp.LineSpacingMultiplier = (float)1.3;
            doc.EndUpdateParagraphs(pp);
        }
        
        private void loadData()
        {
            if (string.IsNullOrEmpty(accession_no))
            {
                rtPad.ReadOnly = true;
                rtPad.BackColor = Color.White;
                return;
            }
            result.RISExamresult.ACCESSION_NO = accession_no;
            dsData = result.GetExamNote();
            if (dsData.Tables[0].Rows.Count > 0)
            {
                int dr_i = dsData.Tables[0].Rows.Count;
                foreach (DataRow dr in dsData.Tables[0].Rows)
                {
                    rtResult.Text += "Addendum : " + dr_i.ToString() + ", ";
                    rtResult.Text += "Written By : ";
                    rtResult.Text += dr["RadioNameEng"].ToString();
                    rtResult.Text += ", Date : ";
                    DateTime dt = Convert.ToDateTime(dr["NOTE_ON"]);
                    rtResult.Text += dt.ToString() + "\r\n";
                    rtResult.Text += dr["TXT"].ToString();
                    rtResult.Text += "\r\n\r\n";
                    dr_i--;
                }
                rtResult.Text += "\r\n";
                rtResult.Text += "--------------\r\n";
                //rtResult.Text += "\r\n\r\n";
                //rtResult.Text += "\r\n\r\n";
                rtResult.Text += dsData.Tables[1].Rows[0]["TXT"].ToString();
                rtResult.Text += "\r\n" + dsData.Tables[1].Rows[0]["RadioNameEng"].ToString() + "(" + dsData.Tables[1].Rows[0]["EMP_UID"].ToString() + ")";
                rtResult.Text += "\r\nRadiologsit";
                AddNO = dsData.Tables[0].Rows.Count + 1;
            }
            else
            {
                System.IO.MemoryStream mem = null;
                try
                {

                    char[] chr = dsData.Tables[1].Rows[0]["RTF"].ToString().ToCharArray();
                    byte[] data = new byte[chr.Length];
                    for (int i = 0; i < chr.Length; i++)
                        data[i] = (byte)chr[i];
                    mem = new System.IO.MemoryStream(data);
                    rtResult.LoadFile(mem, RichTextBoxStreamType.RichText);
                    mem.Dispose();
                }
                catch
                {
                    rtResult.AppendText(dsData.Tables[1].Rows[0]["TXT"].ToString());
                }
                finally
                {
                    mem.Dispose();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }
        }
        private void loadPatient()
        {

            result.RISExamresult.ACCESSION_NO = accession_no;
            result.RISExamresult.HN = hn;
            result.RISExamresult.EMP_ID = env.UserID;
            result.RISExamresult.ORDER_ID = order_id;
            DataTable dttDemo = result.GetDemographic();
            DataTable dttHistory = result.GetHistory();
            DataTable dttHistoryReport = result.GetHistoryReport();

            string name = string.Empty;
            txtHN.EditValue = dttDemo.Rows[0]["HN"].ToString();
            name = dttDemo.Rows[0]["FNAME"].ToString() + " ";
            name += dttDemo.Rows[0]["MNAME"].ToString() + " ";
            name += dttDemo.Rows[0]["LNAME"].ToString();
            txtPatientName.EditValue = name;
            txtAge.EditValue = dttDemo.Rows[0]["AGE"].ToString();
            txtGender.EditValue = dttDemo.Rows[0]["GENDER"].ToString();
            txtAccession.EditValue = accession_no;
            txtExamName.EditValue = exam_name;

            DataRow[] dr = dttHistory.Select("ACCESSION_NO = '" + accession_no + "'");
            if (dr.Length > 0)
            {
                drData = dr[0];
            }
            exam_id = Convert.ToInt32(dttHistoryReport.Rows[0]["EXAM_ID"].ToString());
            exam_uid = dttHistoryReport.Rows[0]["EXAM_UID"].ToString();
        }

        private void initEdit(bool b)
        {
            iCut.Enabled = b;
            iCopy.Enabled = b;
            iSelectAll.Enabled = rtPad.CanSelect;
        }
        public RichEditControl CurrentRichTextBox
        {
            get
            {
                return rtPad;
            }
        }

        #region Group Save and Close.
        private void iSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveAddendum();
        }
        private void SaveAddendum()
        {
            if (rtPad.Text.Length < 9)
            {
                msg.ShowAlert("UID1127", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (msg.ShowAlert("UID1019", env.CurrentLanguageID) == "2")
            {
                try
                {
                    string rtf = rtPad.Document.RtfText;
                    string txt = rtPad.Document.Text;
                    string TextHTML = convertRTFToHTML(rtf);
                    string html = "";

                    //html = "<br><font face='Microsoft Sans Serif' size='2' >Addendum : " + AddNO.ToString() + ", Written By : " + env.FirstNameEng + " " + env.LastNameEng + ",M.D., Date : " + GetDatetimeNowFromSQLServer() + "</font><br/>";
                    //html += TextHTML;
                    //if (dsData.Tables[0].Rows.Count > 0)
                    //{
                    //    int dr_i = dsData.Tables[0].Rows.Count;
                    //    foreach (DataRow dr in dsData.Tables[0].Rows)
                    //    {
                    //        html += "<br><font face='Microsoft Sans Serif' size='2'>Addendum : " + dr_i.ToString() + ", ";
                    //        html += "Written By : ";
                    //        html += dr["RadioNameEng"].ToString();
                    //        html += ", Date : ";
                    //        DateTime dt = Convert.ToDateTime(dr["NOTE_ON"]);
                    //        html += dt.ToString() + "<br/>";
                    //        html += convertRTFToHTML(dr["RTF"].ToString());
                    //        html += "</font><br/><br/>";
                    //        dr_i--;
                    //    }
                    //}
                    //html = html.Replace("size='2'", "size='4'");
                    //html += "<br/>-------------------------<br/>";
                    //html += "<br/>";
                    //html += dsData.Tables[1].Rows[0]["HTML"].ToString();
                    //html = removeSyntax(html);

                    #region create table and generate to pacs.
                    DataTable dtt_pacs = new DataTable();
                    dtt_pacs.Columns.Add("ACCESSION_NO");
                    dtt_pacs.AcceptChanges();
                    #endregion

                    RIS_EXAMRESULTNOTE ad = new RIS_EXAMRESULTNOTE();
                    ad.ORDER_ID = order_id;
                    ad.EXAM_ID = exam_id;
                    ad.ACCESSION_NO = accession_no;
                    ad.NOTE_TEXT = txt;
                    ad.NOTE_TEXT_RTF = rtf;
                    ad.NOTE_BY = env.UserID;
                    ad.ORG_ID = env.OrgID;
                    ad.HL7_TEXT = string.Empty;
                    ProcessAddAddendum padd = new ProcessAddAddendum();
                    padd.RIS_EXAMRESULTNOTE = ad;
                    padd.Invoke();

                    dtt_pacs.Rows.Add(ad.ACCESSION_NO);

                    #region Merege Data.
                    if (!string.IsNullOrEmpty(drData["MERGE"].ToString()))
                    {
                        if (drData["MERGE"].ToString().ToLower() != "spt")
                        {
                            result.RISExamresult.MERGE = drData["MERGE"].ToString();
                            result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                            result.RISExamresult.MERGE_WITH = drData["MERGE_WITH"].ToString();
                            DataTable dtt = result.GetMergeData();

                            foreach (DataRow dr in dtt.Rows)
                            {
                                if (dr["ACCESSION_NO"].ToString() != drData["ACCESSION_NO"].ToString())
                                {

                                    //ExamAddendum ad = new ExamAddendum();
                                    ad.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"].ToString());
                                    ad.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"].ToString());
                                    ad.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                                    ad.NOTE_TEXT = txt;
                                    ad.NOTE_TEXT_RTF = rtf;
                                    ad.NOTE_BY = env.UserID;
                                    ad.ORG_ID = env.OrgID;
                                    ad.HL7_TEXT = string.Empty;
                                    //ProcessAddAddendum padd = new ProcessAddAddendum();
                                    padd.RIS_EXAMRESULTNOTE = ad;
                                    padd.Invoke();

                                    dtt_pacs.Rows.Add(ad.ACCESSION_NO);
                                }
                            }//end looping
                        }//end if check 'spt'
                    }//end if check mere null 
                    #endregion

                    SendToPacs pacs = new SendToPacs();
                    foreach (DataRow row in dtt_pacs.Rows)
                        pacs.Set_ORUByAccessionNoQueue(row["ACCESSION_NO"].ToString().Trim());

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }
        private string convertRTFToHTML(string rtfFormat)
        {
            Miracle.Translator.TransRtf tran = new Miracle.Translator.TransRtf(rtfFormat);

            string html = tran.Translator()
                .Replace("<img	src=\"none\" />", string.Empty)
                .Replace(@"\X000d\", "<br>");
            return html;
        }
        private void sendMessageToPACS(Object obj)
        {
            DataTable dtt = obj as DataTable;
            if (dtt != null)
            {
                if (dtt.Rows.Count > 0)
                {
                    SendToPacs pacs = new SendToPacs();
                    foreach (DataRow row in dtt.Rows)
                    {
                        pacs.Set_ORUByAccessionNoQueue(row["ACCESSION_NO"].ToString().Trim());
                    }
                }
            }
        }
        private string arrangeGroup()
        {
            ProcessGetHREmp geHr = new ProcessGetHREmp();
            geHr.HR_EMP.MODE = "select_All_Active";
            geHr.Invoke();
            DataTable dtHr = new DataTable();
            dtHr = geHr.Result.Tables[0];
            string finalName = "";
            string ResultDoctor = "";

            ProcessGetRISExamresultrads rad = new ProcessGetRISExamresultrads();
            rad.RIS_EXAMRESULTRADS.ACCESSION_NO = accession_no;
            rad.Invoke();
            DataTable dtSetGroup = rad.Result.Tables[0];

            if (dtSetGroup.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSetGroup.Rows)
                {
                    DataTable dtAuthe = selectCheckAuthen(Convert.ToInt32(dr["RAD_ID"]));
                    if (dtAuthe.Rows.Count > 0)
                    {
                        string resultDoc = "";
                        if (dtAuthe.Rows[0]["AUTH_LEVEL_ID"].ToString() == "3")
                        {
                            DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
                            finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
                            finalName += " ";
                            finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
                            finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";

                            if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString().StartsWith("RAD"))
                                ResultDoctor += finalName + " Radiologist<br/>";
                            else if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString().StartsWith("FEL"))
                                ResultDoctor += finalName + " Radiologist<br/>";
                            else
                                ResultDoctor += finalName + "\r\n";
                        }
                        else
                        {
                            DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
                            finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
                            finalName += " ";
                            finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
                            finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";
                            ResultDoctor += finalName + "<br/>";
                        }
                    }
                }
            }
            return ResultDoctor;
        }
        private DataTable selectCheckAuthen(int EMP_ID)
        {
            ProcessGetHREmp hr = new ProcessGetHREmp();
            hr.HR_EMP.MODE = "check_Auther";
            hr.HR_EMP.EMP_ID = EMP_ID;
            hr.Invoke();
            DataTable dtAuth = hr.Result.Tables[0];
            dtAuth.AcceptChanges();
            return dtAuth;
        }
        private void iClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private string removeSyntax(string html)
        {
            string rejectImg = "<img	src=\"none\" />";
            html = html.Replace(rejectImg, "");

            string wrongText = @"\X000d\";
            html = html.Replace(wrongText, "<br>");

            //\X000d
            string wrongText2 = @"\X000d";
            html = html.Replace(wrongText2, "<br>");

            return html;
        }
        #endregion

        #region Group Format.
        private void iBarFontInc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(iFontSize.EditValue.ToString()))
            {
                iFontSize.EditValue = 12;
                return;
            }
            int fontSize = Convert.ToInt32(iFontSize.EditValue);
            fontSize += 2;
            if (fontSize > 72)
                iFontSize.EditValue = 72;
            else
                iFontSize.EditValue = fontSize;
        }
        private void iBarFontDec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(iFontSize.EditValue.ToString()))
            {
                iFontSize.EditValue = 12;
                return;
            }
            int fontSize = Convert.ToInt32(iFontSize.EditValue);
            fontSize -= 2;
            if (fontSize < 8)
                iFontSize.EditValue = 8;
            else
                iFontSize.EditValue = fontSize;

        }
        #endregion

        private void rtPad_PreparePopupMenu(object sender, PreparePopupMenuEventArgs e)
        {
            Control control = new Control();
            Point pos2 = new Point(rtPad.Cursor.HotSpot.X, rtPad.Cursor.HotSpot.Y);
            DXPopupMenu mu = new DXPopupMenu();
            DevExpress.LookAndFeel.UserLookAndFeel Look = new UserLookAndFeel(rtPad);
            MenuManagerHelper.ShowMenu(mu, Look, fMenuManager, control, pos2);
            e.Menu.RemoveMenuItem(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ShowFontForm);
            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add to Dictionary", new EventHandler(addDic_Click), imgSmall.Images[0]));
        }
        public void addDic_Click(object sender, EventArgs e)
        {
            spellChecker1.Check(rtPad);
            spellChecker1.SpellCheckMode = SpellCheckMode.AsYouType;
        }

        private void rtPad_EmptyDocumentCreated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.rtPad.Document.Text))
            {
                Font font = new Font("Microsoft Sans Serif", 14);
                CharacterProperties charProperties = this.rtPad.Document.BeginUpdateCharacters(this.rtPad.Document.Range);
                charProperties.FontName = font.Name;
                charProperties.FontSize = font.Size;
                this.rtPad.Document.EndUpdateCharacters(charProperties);
            }

        }
        private void Severity_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            retValue = e.NewValue.Split(new Char[] { '^' });
        }
        private string GetDatetimeNowFromSQLServer()
        {
            try
            {
                LookUpSelect lk = new LookUpSelect();
                DataSet ds = lk.SelectDatetimeNowFromSQLServer();
                DateTime dtNow = Convert.ToDateTime(ds.Tables[0].Rows[0][0]);
                return dtNow.ToString();
            }
            catch
            {
                return DateTime.Now.ToString();
            }
        }
        private void rtPad_KeyDown(object sender, KeyEventArgs e)
        {
            InputLanguage lg = InputLanguage.CurrentInputLanguage;

            if (lg.LayoutName == "US" || lg.LayoutName == "EN")
                e.SuppressKeyPress = false;
            else
                e.SuppressKeyPress = true;
        }
        private void rtPad_SelectionChanged(object sender, EventArgs e)
        {
            SetDefaultFont();
        }
    }


}
