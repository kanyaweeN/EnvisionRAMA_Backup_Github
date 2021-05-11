using System;
using System.Collections.Generic;
using System.ComponentModel;
using RIS.Common.Common;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using RIS.Common;
using RIS.BusinessLogic;
using RIS.Operational;
using RIS.Operational.PACS;
using RIS.Forms.GBLMessage;
using RIS.Forms.ResultEntry.Common;
using Miracle.HL7.ORU;
namespace RIS.Forms.ResultEntry
{
    public partial class frmAddendum : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string accession_no;
        private int order_id;
        private string hn;
        private int exam_id;
        private string exam_name;
        private ColorPopupRichText cpFontColor;
        private ColorPopupRichText cpBGFontColor;
        private RIS.BusinessLogic.ResultEntry result;
        private bool update = true;
        private GBLEnvVariable env;
        private MyMessageBox msg;
        private DataTable dttDemo;
        private DataSet dsData;
        private DataRow drData;
        private int AddNO = 1;

        public frmAddendum()
        {
            InitializeComponent();
            rtResult.BackColor = Color.White;
            result = new RIS.BusinessLogic.ResultEntry();
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            accession_no = string.Empty;
            order_id = 0;
            exam_id = 0;
            hn = string.Empty;
            exam_name = string.Empty;
            createPopupMenuFontColor();
            createPopupMenuBGFontColor();
            initFormat();
            initEdit(false);
            iBarFont.EditValue = SelectFont.Name;
            iFontSize.EditValue = Math.Ceiling(SelectFont.Size);
            setFontSize();
            loadPatient();
            loadData();
        }
        public frmAddendum(string AccessionNo,string ExamName,int OrderID,string HN)
        {
            InitializeComponent();
            rtResult.BackColor = Color.LightCyan;
            result = new RIS.BusinessLogic.ResultEntry();
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            accession_no = AccessionNo;
            order_id = OrderID;
            hn = HN;
            exam_name = ExamName;
            createPopupMenuFontColor();
            createPopupMenuBGFontColor();
            initFormat();
            initEdit(false);
            iBarFont.EditValue = SelectFont.Name;
            iFontSize.EditValue = Math.Ceiling(SelectFont.Size);
            setFontSize();
            loadPatient();
            loadData();
            
        }

        private void frmAddendum_Load(object sender, EventArgs e)
        {
            rtPad.Focus();
        }

        private void loadData() {
            if (string.IsNullOrEmpty(accession_no)) {
                rtPad.ReadOnly = true;
                rtPad.BackColor = Color.White;
                return;
            }
            result.RISExamresult.ACCESSION_NO = accession_no;
            dsData= result.GetExamNote();
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
        private void loadPatient() {
            result.RISExamresult.ACCESSION_NO = accession_no;
            result.RISExamresult.ORDER_ID = order_id;
            result.RISExamresult.HN = hn;
            DataSet ds = result.GetHistory();

            string name = string.Empty;
            txtHN.EditValue = ds.Tables[0].Rows[0]["HN"].ToString();
            name = ds.Tables[0].Rows[0]["FNAME"].ToString() + " ";
            name += ds.Tables[0].Rows[0]["MNAME"].ToString() + " ";
            name += ds.Tables[0].Rows[0]["LNAME"].ToString();
            txtPatientName.EditValue = name;
            txtAge.EditValue = ds.Tables[0].Rows[0]["AGE"].ToString();
            txtGender.EditValue= ds.Tables[0].Rows[0]["GENDER"].ToString();
            txtAccession.EditValue = accession_no;
            txtExamName.EditValue = exam_name;
            dttDemo = new DataTable();
            dttDemo = ds.Tables[0].Copy();
            DataRow[] dr = ds.Tables[2].Select("ACCESSION_NO = '" + accession_no+"'");
            if(dr.Length>0)
            {
                drData = dr[0];
            }
            exam_id = Convert.ToInt32(ds.Tables[1].Rows[0]["EXAM_ID"].ToString());

        }

        private void createPopupMenuFontColor()
        {
            cpFontColor = new ColorPopupRichText(popupControlContainer1, iBarFontColor, rtPad);
        }
        private void createPopupMenuBGFontColor()
        {
            cpBGFontColor = new ColorPopupRichText(popupControlContainer2, iBarFontBGColor, rtPad, true);
        }
        private void initFormat()
        {
            update = false;
            iBold.Down = SelectFont.Bold;
            iItaic.Down = SelectFont.Italic;
            iUnderLine.Down = SelectFont.Underline;
            iBullet.Down = rtPad.SelectionBullet;
            initAlignment();

            iBarFont.EditValue = SelectFont.Name;
            iFontSize.EditValue = Math.Ceiling(SelectFont.Size);

            if (rtPad.SelectionLength == 0)
            {
                if (rtPad.SelectionFont != null)
                {
                    FontFamily fontFamily = new FontFamily(rtPad.SelectionFont.Name);
                    float size = Convert.ToSingle(rtPad.SelectionFont.Size);

                    FontStyle fs = FontStyle.Regular;
                    if (SelectFont.Bold)
                        fs |= FontStyle.Bold;
                    if (SelectFont.Italic)
                        fs |= FontStyle.Italic;
                    if (SelectFont.Underline)
                        fs |= FontStyle.Underline;

                    Font font = new Font(fontFamily, size, fs);
                    rtPad.SelectionFont = font;
                }
            }
            update = true;


        }
        private void initEdit(bool b)
        {
            iCut.Enabled = b;
            iCopy.Enabled = b;
            iSelectAll.Enabled = rtPad.CanSelect;
            initPaste();
        }
        private void initAlignment()
        {
            switch (rtPad.SelectionAlignment)
            {
                case HorizontalAlignment.Left:
                    //iAlignLeft.Down = true;
                    iAlignCenter.Down = false;
                    iAlignRight.Down = false;
                    break;
                case HorizontalAlignment.Center:
                    iAlignLeft.Down = false;
                    iAlignCenter.Down = true;
                    iAlignRight.Down = false;
                    break;
                case HorizontalAlignment.Right:
                    iAlignLeft.Down = false;
                    iAlignCenter.Down = false;
                    iAlignRight.Down = true;
                    break;
            }
        }
        private void initPaste()
        {
            iPaste.Enabled = rtPad.CanPaste(DataFormats.GetFormat(0));

        }
        private void setFontSize()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbo = (DevExpress.XtraEditors.Repository.RepositoryItemComboBox)iFontSize.Edit;
            for (int i = 8; i < 74; i += 2)
            {
                cbo.Items.Add(i);

            }
        }
        private Font SelectFont
        {
            get
            {
                if (rtPad.SelectionFont != null)
                    return rtPad.SelectionFont;
                return rtPad.Font;
            }
            set
            {
                rtPad.Font = value;
            }
        }
        private FontStyle rtPadFontStyle()
        {
            FontStyle fs = new FontStyle();
            if (iBold.Down)
                fs |= FontStyle.Bold;
            if (iItaic.Down)
                fs |= FontStyle.Italic;
            if (iUnderLine.Down)
                fs |= FontStyle.Underline;
            return fs;
        }
        public RichTextBox CurrentRichTextBox
        {
            get
            {
                return rtPad;
            }
        }

        #region Group Save and Close.
        private void iSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rtPad.Text.Length < 9)
            {
                msg.ShowAlert("UID1127", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (msg.ShowAlert("UID1019", env.CurrentLanguageID) == "2")
            {
                RIS.Operational.Translator.TransRtf tran = new RIS.Operational.Translator.TransRtf(rtPad.Rtf);
                string html;
                string TextHTML = tran.Translator();
                html = "Addendum : " + AddNO.ToString() + ", Written By : " + env.FirstNameEng + " " + env.LastNameEng + ",M.D., Date : " + DateTime.Now.ToString() + "<br/>";
                html += TextHTML;
                string str = string.Empty;
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    int dr_i = dsData.Tables[0].Rows.Count;
                    foreach (DataRow dr in dsData.Tables[0].Rows)
                    {
                        html += "<br/>Addendum : " + dr_i.ToString() + ", ";
                        html += "Written By : ";
                        html += dr["RadioNameEng"].ToString();
                        html += ", Date : ";
                        DateTime dt = Convert.ToDateTime(dr["NOTE_ON"]);
                        html += dt.ToString() + "<br/>";
                        tran = new RIS.Operational.Translator.TransRtf(dr["RTF"].ToString());
                        html += tran.Translator();
                        html += "<br/><br/>";
                        dr_i--;
                    }
                }
                ////str = ;
                //rtResult.Text += "\r\n";
                ////rtResult.Text += "--------------\r\n";
                ////rtResult.Text += "\r\n\r\n";
                ////rtResult.Text += "\r\n\r\n";
                //rtResult.Text += dsData.Tables[1].Rows[0]["TXT"].ToString();
                //rtResult.Text += "\r\n" + dsData.Tables[1].Rows[0]["RadioNameEng"].ToString() + "(" + dsData.Tables[1].Rows[0]["EMP_UID"].ToString() + ")";
                //rtResult.Text += "\r\nRadiologsit";

                tran = new RIS.Operational.Translator.TransRtf(dsData.Tables[1].Rows[0]["RTF"].ToString());
                html += "<br/>-------------------------<br/>";
                str = "<br/>";
                str += tran.Translator();
                str += "<br/>" + dsData.Tables[1].Rows[0]["RadioNameEng"].ToString() + "(" + dsData.Tables[1].Rows[0]["EMP_UID"].ToString()+ ")<br/> Radiologist";
                html += str;

                #region create table and generate to pacs.
                DataTable dtMSG = new DataTable();
                dtMSG.Columns.Add("HN");
                dtMSG.Columns.Add("FNAME");
                dtMSG.Columns.Add("MNAME");
                dtMSG.Columns.Add("LNAME");
                dtMSG.Columns.Add("THFNAME");
                dtMSG.Columns.Add("THMNAME");
                dtMSG.Columns.Add("GENDER");
                dtMSG.Columns.Add("DOB");
                dtMSG.Columns.Add("PHONE");
                dtMSG.Columns.Add("ADDRESS");
                dtMSG.Columns.Add("ACCESSION_NO");
                dtMSG.Columns.Add("STATUS");
                dtMSG.Columns.Add("EXAM_ID");
                dtMSG.Columns.Add("EXAM_NAME");
                dtMSG.Columns.Add("HL7TXT");
                dtMSG.Columns.Add("ORDNO");
                DataTable tmpMSG = dtMSG.Clone();
                DataRow row = dtMSG.NewRow();
                row["HN"] = dttDemo.Rows[0]["HN"].ToString();
                row["FNAME"] = dttDemo.Rows[0]["FNAME_ENG"].ToString();
                row["MNAME"] = dttDemo.Rows[0]["MNAME_ENG"].ToString();
                row["LNAME"] = dttDemo.Rows[0]["LNAME_ENG"].ToString();
                row["THFNAME"] = dttDemo.Rows[0]["FNAME"].ToString();
                row["THMNAME"] = dttDemo.Rows[0]["LNAME"].ToString();
                row["GENDER"] = dttDemo.Rows[0]["GENDER_ID"].ToString();
                row["DOB"] = dttDemo.Rows[0]["DOB"];
                row["PHONE"] = dttDemo.Rows[0]["PHONE"].ToString();
                row["ACCESSION_NO"] = accession_no;
                row["STATUS"] = "F";
                row["EXAM_ID"] = exam_id;// drData["EXAM_UID"].ToString();
                row["EXAM_NAME"] = exam_name;
                row["HL7TXT"] = html;
                row["ORDNO"] = order_id;
                dtMSG.Rows.Add(row);
                dtMSG.AcceptChanges();
                #endregion

                GenerateORU oru = new GenerateORU();
                string hl7 = string.Empty;
                DataTable dttbl = oru.createMessage(dtMSG);
                if (dttbl.Rows.Count > 0)
                    hl7 = dttbl.Rows[0]["HL7_TXT"].ToString();

                ExamAddendum ad = new ExamAddendum();
                ad.OrderID = order_id;
                ad.ExamID = exam_id;
                ad.AccessionNo = accession_no;
                ad.NoteText = rtPad.Text;
                ad.NoteBy = env.UserID;
                ad.OrgID = env.OrgID;
                ad.Hl7Text = hl7;
                ad.RESULT_TEXT_RTF = rtPad.Rtf;
                ProcessAddAddendum padd = new ProcessAddAddendum();
                padd.ExamAddendum = ad;
                padd.Invoke();

                #region Merege Data.
                if (!string.IsNullOrEmpty(drData["MERGE"].ToString()))
                {
                    if (drData["MERGE"].ToString().ToLower() != "spt")
                    {

                        // result.RISExamresult.ACCESSION_NO = drData["MERGE"].ToString().ToLower() == "mrr" ? drData["ACCESSION_NO"].ToString() : drData["MERGE_WITH"].ToString();
                        result.RISExamresult.MERGE = drData["MERGE"].ToString();
                        result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                        result.RISExamresult.MERGE_WITH = drData["MERGE_WITH"].ToString();
                        DataTable dtt = result.GetMergeData();

                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["ACCESSION_NO"].ToString() != drData["ACCESSION_NO"].ToString())
                            {

                                tmpMSG = new DataTable();
                                tmpMSG = dtMSG.Clone();
                                row = tmpMSG.NewRow();
                                row["HN"] = hn;
                                row["FNAME"] = dttDemo.Rows[0]["FNAME_ENG"].ToString();
                                row["MNAME"] = dttDemo.Rows[0]["MNAME_ENG"].ToString();
                                row["LNAME"] = dttDemo.Rows[0]["LNAME_ENG"].ToString();
                                row["THFNAME"] = dttDemo.Rows[0]["FNAME"].ToString();
                                row["THMNAME"] = dttDemo.Rows[0]["LNAME"].ToString();
                                row["GENDER"] = dttDemo.Rows[0]["GENDER_ID"].ToString();
                                row["DOB"] = dttDemo.Rows[0]["DOB"];
                                row["PHONE"] = dttDemo.Rows[0]["PHONE"].ToString();
                                row["ACCESSION_NO"] = dr["ACCESSION_NO"].ToString();
                                row["STATUS"] = "F";
                                row["EXAM_ID"] = dr["EXAM_UID"].ToString();
                                row["EXAM_NAME"] = dr["EXAM_NAME"].ToString();
                                row["HL7TXT"] = html;
                                row["ORDNO"] = drData["ORDER_ID"].ToString();
                                tmpMSG.Rows.Add(row);
                                tmpMSG.AcceptChanges();

                                DataTable tmpPACS = oru.createMessage(tmpMSG);
                                if (tmpPACS.Rows.Count > 0)
                                    hl7 = tmpPACS.Rows[0]["HL7_TXT"].ToString();

                                //ExamAddendum ad = new ExamAddendum();
                                ad.OrderID = Convert.ToInt32(dr["ORDER_ID"].ToString());
                                ad.ExamID = Convert.ToInt32(dr["EXAM_ID"].ToString());
                                ad.AccessionNo = dr["ACCESSION_NO"].ToString();
                                ad.NoteText = rtPad.Text;
                                ad.NoteBy = env.UserID;
                                ad.OrgID = env.OrgID;
                                ad.Hl7Text = hl7;
                                ad.RESULT_TEXT_RTF = rtPad.Rtf;
                                //ProcessAddAddendum padd = new ProcessAddAddendum();
                                padd.ExamAddendum = ad;
                                padd.Invoke();

                                row = dttbl.NewRow();
                                row["ACCESSION_NO"] = ad.AccessionNo;
                                row["HL7_TXT"] = hl7;
                                dttbl.Rows.Add(row);
                                dttbl.AcceptChanges();
                            }
                        }//end looping
                    }//end if check 'spt'
                }//end if check mere null 
                #endregion

                SendToPacs send = new SendToPacs();
                send.Set_ORUByAccessionNoQueue(accession_no);

                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
       
        private void iClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Group Edit.
        private void iPaste_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.Paste();
        }
        private void iCut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.Cut();
            initPaste();
        }
        private void iCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.Copy();
            initPaste();
        }
        private void iSelectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            rtPad.SelectAll();
            initPaste();
        }
        private void iPicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            initPaste();
        }
        #endregion

        #region Group Format.
        private void iFontStyle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.SelectionFont = new Font(SelectFont.FontFamily.Name, SelectFont.Size, rtPadFontStyle());
        }
        private void iAlign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Caption == "Align Left")
            {
                //if (iAlignLeft.Down)
                //{
                rtPad.SelectionAlignment = HorizontalAlignment.Left;
                iAlignCenter.Down = false;
                iAlignRight.Down = false;
                //}
            }
            else if (e.Item.Caption == "Center")
            {
                if (iAlignCenter.Down)
                {
                    rtPad.SelectionAlignment = HorizontalAlignment.Center;
                    iAlignLeft.Down = false;
                    iAlignRight.Down = false;
                }

            }
            else
            {
                if (iAlignRight.Down)
                {
                    rtPad.SelectionAlignment = HorizontalAlignment.Right;
                    iAlignLeft.Down = false;
                    iAlignCenter.Down = false;
                }
            }
        }
        private void iBullet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.SelectionBullet = iBullet.Down;
        }
        private void ibarSpell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            spellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType;
            spellChecker1.Check(rtPad);
        }
        private void iBarFont_EditValueChanged(object sender, EventArgs e)
        {
            if (update)
            {
                if (string.IsNullOrEmpty(iBarFont.EditValue.ToString()))
                    return;
                FontFamily fontFamily = new FontFamily(iBarFont.EditValue.ToString());
                float size = Convert.ToSingle(iFontSize.EditValue);
                Font font = new Font(fontFamily, size);

                rtPad.SelectionFont = font;
            }
        }
        private void iBarFontColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.SelectionColor = cpFontColor.ResultColor;

        }
        private void iBarFontBGColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.SelectionBackColor = cpBGFontColor.ResultColor;
        }
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
        private void iFontSize_EditValueChanged(object sender, EventArgs e)
        {
            if (update)
            {
                int fontSize = 12;
                if (string.IsNullOrEmpty(iFontSize.EditValue.ToString()))
                {
                    iFontSize.EditValue = 12;
                    return;
                }
                if (!int.TryParse(iFontSize.EditValue.ToString(), out fontSize))
                {
                    iFontSize.EditValue = 12;
                    return;

                }


                fontSize = Convert.ToInt32(iFontSize.EditValue);
                if (fontSize < 8 || fontSize > 72)
                {
                    fontSize = 12;
                    if (rtPad.SelectionFont != null)
                        fontSize = Convert.ToInt32(rtPad.SelectionFont.Size);
                    iFontSize.EditValue = fontSize;
                    return;
                }

                FontFamily fontFamily = new FontFamily(iBarFont.EditValue.ToString());
                float size = Convert.ToSingle(iFontSize.EditValue);
                Font font = new Font(fontFamily, size);
                rtPad.SelectionFont = font;
            }
        }
        private void iUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.Undo();
        }
        private void iRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.Redo();
        }
        #endregion

        private void rtPad_SelectionChanged(object sender, EventArgs e)
        {
            initFormat();
            initEdit(rtPad.SelectionLength > 0);
            if (rtPad.SelectionLength > 0) {
                ribbonControl1.SelectedPage = pageEdit;
            }
        }

       
    }
}
 //if (dtt.Rows.Count > 0)
 //           {
 //               System.IO.MemoryStream mem = null;
 //               try
 //               {
 //                   char[] chr = dtt.Rows[0]["NOTE_TEXT_RTF"].ToString().ToCharArray();
 //                   byte[] data = new byte[chr.Length];
 //                   for (int i = 0; i < chr.Length; i++)
 //                       data[i] = (byte)chr[i];
 //                   mem = new System.IO.MemoryStream(data);
 //                   rtResult.LoadFile(mem, RichTextBoxStreamType.RichText);
 //                   mem.Dispose();
 //               }
 //               catch
 //               {
 //                   rtResult.AppendText(dtt.Rows[0]["NOTE_TEXT"].ToString());
 //               }
 //               finally
 //               {
 //                   mem.Dispose();
 //                   GC.WaitForPendingFinalizers();
 //                   GC.Collect();
 //               }

 //           }
 //           else {
 //               dtt = result.GetExamResult();
 //               System.IO.MemoryStream mem = null;
 //               try
 //               {
 //                   char[] chr = dtt.Rows[0]["RESULT_TEXT_RTF"].ToString().ToCharArray();
 //                   byte[] data = new byte[chr.Length];
 //                   for (int i = 0; i < chr.Length; i++)
 //                       data[i] = (byte)chr[i];
 //                   mem = new System.IO.MemoryStream(data);
 //                   rtResult.LoadFile(mem, RichTextBoxStreamType.RichText);
 //                   mem.Dispose();
 //               }
 //               catch
 //               {
 //                   rtResult.AppendText(dtt.Rows[0]["RESULT_TEXT_PLAIN"].ToString());
 //               }
 //               finally
 //               {
 //                   mem.Dispose();
 //                   GC.WaitForPendingFinalizers();
 //                   GC.Collect();
 //               }
 //           }