using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

using Miracle.Translator;
using Envision.Common;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using Miracle.Scanner;
using Envision.NET.Forms.Dialog;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmReportSearchNew : MasterForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        private string synapseICON = ConfigurationSettings.AppSettings["reportSearchICONSynapse"];
        private string requestICON = ConfigurationSettings.AppSettings["reportSearchICONRequest"];

        #region MainForm Variables
        List<string> keys = new List<string>();
        DataTable dtWL = new DataTable();
        DataSet dsWL = new DataSet();
        int tr = 0;
        TimeSpan tspan = new TimeSpan();
        //int sc = 0;
        string searchText = "";
        bool firstLoad = true;
        #endregion

        #region WebBS Variables
        int WebPN = 1;
        string WebPage = "";
        string ResultText = "";
        #endregion

        #region NewTab Variables
        DataRow drNT = null;
        string ntHN = "";
        string ntPATIENT_NAME = "";
        string ntAGE = "";
        string ntGENDER = "";
        string ntEXAM_CODE = "";
        string ntEXAM_TYPE_CODE = "";
        string ntRELEASED_ON = "";
        string ntRELEASE_NAME = "";
        string ntFINALIZED_ON = "";
        string ntFINALIZE_NAME = "";
        string ntREPORT_DATE = "";
        string ntSTUDY_DATE = "";
        string ntRESULT_TEXT_RTF = "";
        string ntWebPage = "";
        string ntACCESSION_NO = "";
        string ntOrderID = "";
        #endregion

        #region PageNum Variable
        #endregion

        #region SearchFilter Variables
        DataTable dtHN = null;
        DataTable dtExamName = new DataTable();
        DataTable dtExamType = new DataTable();
        DataTable dtRadiologist = new DataTable();
        #endregion

        public frmReportSearchNew()
        {
            InitializeComponent();
        }

        private void SearchEngine_Load(object sender, EventArgs e)
        {
            Reload_SearchFilter_1stLoad();
            this.Focus();
            txtHN.VisibleChanged += new EventHandler(panelSearchFilter_ExpandedChanged);
            foreach(DevExpress.XtraEditors.Controls.EditorButton btt in btnPageNumbers.Properties.Buttons)
            {
                btt.Width = 20;
            }
            btnPageNumbers.Properties.Buttons[btnPageNumbers.Properties.Buttons.Count - 1].Width = -1;
            webBS.GoSearch();

            base.CloseWaitDialog();
            firstLoad = false;
        }
        private void SearchEngine_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadStopProgressBar();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReportSearchProcess();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)S
            //{
            //    LoadProgressBar();
            //    Reload();
            //    Reload_WebPage();
            //    Reload_PageNumber();
            //    LoadStopProgressBar();
            //}
        }
        private void frmReportSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReportSearchProcess();
            }
        }
        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex != 0)
            {
                DevExpress.XtraTab.XtraTabPage page = xtraTabControl1.SelectedTabPage;
                string ACCESSION_NO = page.Tag.ToString().Trim();

                ProcessGetRISSearchEngine se = new ProcessGetRISSearchEngine();
                se.RISSearchEngine.MODE = "2";
                se.RISSearchEngine.ACCESSION_NO = ACCESSION_NO;
                se.InvokeDB();

                string rtf = se.Result.Tables[0].Rows[0]["RESULT_TEXT_RTF"].ToString();
                string hn = se.Result.Tables[0].Rows[0]["HN"].ToString();
                string exam = se.Result.Tables[0].Rows[0]["EXAM_CODE"].ToString().Replace(":", "_");

                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                saveDlg.FileName = hn + "_" + exam + ".rtf";
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDlg.FileName;
                    try
                    {
                        File.AppendAllText(filePath, rtf);
                    }
                    catch { }

                    try
                    {
                        System.Diagnostics.Process.Start(filePath);
                    }
                    catch { }
                }
            }
        }
        private void ReportSearchProcess()
        {
            LoadProgressBar();
            Reload();
            Reload_WebPage();
            Reload_PageNumber();
            LoadStopProgressBar();

            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void webBS_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            try
            {
                if (e.Url.Port == 80)
                {
                    LoadProgressBar();

                    string[] sts = e.Url.OriginalString.Split(new char[] { '/' });
                    string pn = sts[sts.Length - 1];
                    int ipn;
                    
                    if (Int32.TryParse(pn, out ipn))
                    {
                        DataRow dr = dsWL.Tables[WebPN - 1].Rows[ipn];
                        #region LoadData
                        ProcessGetRISSearchEngine se = new ProcessGetRISSearchEngine();
                        se.RISSearchEngine.MODE = "2";
                        se.RISSearchEngine.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                        se.InvokeDB();
                        #endregion
                        drNT = se.Result.Tables[0].Rows[0];
                        Reload_NewTabPage();
                        e.Cancel = true;
                    }
                    
                    else
                        e.Cancel = true;

                    LoadStopProgressBar();
                }
                else if (e.Url.ToString().IndexOf("AccessionNumber") >= 0)
                {
                    string[] splitAccession = e.Url.ToString().Split('=');
                    openPACS(splitAccession[1], false);
                    e.Cancel = true;
                }
                else if (e.Url.ToString().IndexOf("ScanImage") >= 0)
                {
                    string[] splitOrderID = e.Url.ToString().Split('=');
                    scanOrder(Convert.ToInt32(splitOrderID[1]));
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                LoadStopProgressBar();
                MessageBox.Show(ex.Message);
                e.Cancel = true;
            }
        }
        private void scanOrder(int order_id)
        {
            #region Scan Image
            //DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
            process.RIS_ORDERIMAGE.ORDER_ID = order_id;
            process.Invoke();
            DataTable dtSImg = process.Result.Tables[0].Copy();
            PointerStruct.ImageUrl = env.PacsUrl2;

            if (dtSImg.Rows.Count > 0)
            {
                if (dtSImg.Rows.Count > 1)
                {
                    Envision.NET.Forms.Dialog.ImageOrder img = new ImageOrder(order_id);
                    img.StartPosition = FormStartPosition.CenterParent;
                    img.ShowDialog();
                }
                else
                {
                    string url = PointerStruct.ImageUrl + "/" + dtSImg.Rows[0]["IMAGE_NAME"].ToString();
                    //System.Diagnostics.Process.Start(url);

                    Envision.NET.Reports.ReportViewer.frmXtraReportViewer Browser = new Envision.NET.Reports.ReportViewer.frmXtraReportViewer(url);
                    Browser.Text = dtSImg.Rows[0]["IMAGE_NAME"].ToString();
                    Browser.StartPosition = FormStartPosition.CenterScreen;
                    Browser.ShowDialog();
                }
            }
            else
            {
                msg.ShowAlert("UID4029", env.CurrentLanguageID);
            }
            #endregion
        }
        private string openPACS(string AccessionNumber, bool is_blank)
        {
            GBLEnvVariable env = new GBLEnvVariable();
            string str = env.PacsUrl + AccessionNumber;
            if (env.LoginType == "W")
            {
                str = env.PacsUrl;
                str = str.Replace("http://", string.Empty);
                str = "http://radiology%5C" + env.UserName + ":" + env.PasswordAD + "@" + str + AccessionNumber;
            }

            if (is_blank)
            {
                //IECompatible ieCom = new IECompatible();
                //ieCom.OpenSynapseLink("_blank");

                //System.Diagnostics.Process.Start(str, "_blank");


                Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
                if (!ieCom.OpenSynapseLink(str))
                    msg.ShowAlert("UID4053", env.CurrentLanguageID);
            }
            else
            {
                Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
                if (!ieCom.OpenSynapseLink(str))
                    msg.ShowAlert("UID4053", env.CurrentLanguageID);
            }

            return str;
        }
        private void webBS_FontHilighting()
        {
            foreach (string key in keys)
            {
                bool flag = false;
                if (Regex.IsMatch("<font color='red'>", key, RegexOptions.IgnoreCase))
                    flag = true;
                if (Regex.IsMatch("</br>", key, RegexOptions.IgnoreCase))
                    flag = true;
                if (Regex.IsMatch("\n", key, RegexOptions.IgnoreCase))
                    flag = true;

                if (!flag)
                    ResultText = Regex.Replace(ResultText, key, "<FONT color='red'>" + key + "</FONT>", RegexOptions.IgnoreCase);
            }
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            int cPage = xtraTabControl1.SelectedTabPageIndex;
            xtraTabControl1.SelectedTabPageIndex = cPage - 1;
            xtraTabControl1.TabPages.RemoveAt(cPage);
        }
        private void btnPageNumbers_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "P")
            {
                if (Convert.ToInt32(btnPageNumbers.Properties.Buttons[1].Caption) == 1)
                    return;

                int k = 1;
                while (k < 11) // range 1 to 10
                {
                    int nm = 0;
                    nm = Convert.ToInt32(btnPageNumbers.Properties.Buttons[k].Caption);
                    btnPageNumbers.Properties.Buttons[k].Caption = (nm - 10).ToString();
                    k++;
                }
            }
            else if (e.Button.Tag.ToString() == "N")
            {
                if (Convert.ToInt32(btnPageNumbers.Properties.Buttons[1].Caption) + 10 > dsWL.Tables.Count)
                    return;

                int k = 1;
                while (k < 11) // range 1 to 10
                {
                    int nm = 0;
                    nm = Convert.ToInt32(btnPageNumbers.Properties.Buttons[k].Caption);
                    btnPageNumbers.Properties.Buttons[k].Caption = (nm + 10).ToString();
                    k++;
                }
            }
            else
            {
                int pg = Convert.ToInt32(e.Button.Caption);
                if (pg <= dsWL.Tables.Count)
                {
                    WebPN = pg;
                    Reload_WebPage();
                    Reload_PageNumber();
                }
            }
        }

        private void LoadTable()
        {
            DateTime dn = DateTime.Now;
            searchText = txtSearch.Text;
            dsWL = new DataSet();

            if (txtHN.Text + txtAge.Text + txtGender.Text
                + txtExamName.Text + txtExamType.Text
                + txtReportDateFrom.Text + txtReportDateTo.Text
                + txtStudyDateFrom.Text + txtStudyDateTo.Text
                + txtRadiologist.Text == "")
            {
                string[] ks = txtSearch.Text.Split(new char[] { ' ' });
                keys.Clear();
                keys.Sort();
                for (int i = 0; i < ks.Length && i < 10; ++i)
                {
                    if (ks[i] != "")
                        keys.Add(ks[i]);
                }

                ProcessGetRISSearchEngine se = new ProcessGetRISSearchEngine();
                for (int i = 0; i < keys.Count; ++i)
                    se.RISSearchEngine.KEYS[i] = keys[i];
                if (txtArrangeBy.SelectedIndex == 0)
                    se.RISSearchEngine.MODE = "1";
                else
                    se.RISSearchEngine.MODE = "11";

                se.InvokeDB();

                dtWL = se.Result.Tables[0].Copy();
                tr = dtWL.Rows.Count;
            }
            else
            {
                string[] ks = txtSearch.Text.Split(new char[] { ' ' });
                keys.Clear();
                keys.Sort();
                for (int i = 0; i < ks.Length && i < 10; ++i)
                {
                    if (ks[i] != "")
                        keys.Add(ks[i]);
                }

                ProcessGetRISSearchEngine se = new ProcessGetRISSearchEngine();
                for (int i = 0; i < keys.Count; ++i)
                    se.RISSearchEngine.KEYS[i] = keys[i];
                if (txtArrangeBy.SelectedIndex == 0)
                    se.RISSearchEngine.MODE = "3";
                else
                    se.RISSearchEngine.MODE = "33";
                se.RISSearchEngine.HN = txtHN.Text == "" ? "" : txtHN.EditValue.ToString();
                se.RISSearchEngine.AGE = txtAge.Text == "" ? 0 : Convert.ToInt32(txtAge.EditValue);
                se.RISSearchEngine.GENDER = txtGender.Text;
                se.RISSearchEngine.EXAM_NAME = txtExamName.Text == "" ? 0 : Convert.ToInt32(txtExamName.EditValue);
                se.RISSearchEngine.EXAM_TYPE = txtExamType.Text == "" ? 0 : Convert.ToInt32(txtExamType.EditValue);
                se.RISSearchEngine.REPORTDATE_FROM = txtReportDateFrom.Text == "" ? "" : txtReportDateFrom.DateTime.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
                se.RISSearchEngine.REPORTDATE_TO = txtReportDateTo.Text == "" ? "" : txtReportDateTo.DateTime.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
                se.RISSearchEngine.STUDYDATE_FROM = txtStudyDateFrom.Text == "" ? "" : txtStudyDateFrom.DateTime.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
                se.RISSearchEngine.STUDYDATE_TO = txtStudyDateTo.Text == "" ? "" : txtStudyDateTo.DateTime.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
                se.RISSearchEngine.EMP_ID = txtRadiologist.Text == "" ? 0 : Convert.ToInt32(txtRadiologist.EditValue);

                se.InvokeDB();

                dtWL = se.Result.Tables[0].Copy();
                tr = dtWL.Rows.Count;
            }
           
            tspan = (DateTime.Now - dn);
            WebPN = 1;

            #region show row number in tab header
            xtraTabControl1.TabPages[0].Text = "Search Result ("+ tr.ToString() +")";
            #endregion

            #region LoadButton to 1stPageNumber
            int k = 1;
            while (k < 11) // range 1 to 10
            {
                btnPageNumbers.Properties.Buttons[k].Caption = k.ToString();
                k++;
            }
            #endregion
        }
        private void LoadFilter()
        {
            #region RemoveCode at 20090712 03:27 AM
            //if (txtHN.Text + txtAge.Text + txtGender.Text
            //    + txtExamName.Text + txtExamType.Text
            //    + txtReportDateFrom.Text + txtReportDateTo.Text
            //    + txtStudyDateFrom.Text + txtStudyDateTo.Text == "")
            //{
            //    dsWL = new DataSet();

            //    DataTable dt = new DataTable();
            //    DataSet ds = new DataSet();
            //    dt = dtWL.Clone();

            //    int tbName = 1;

            //    dt.TableName = tbName.ToString();
            //    foreach (DataRow dr in dtWL.Rows)
            //    {
            //        dt.Rows.Add(dr.ItemArray);
            //        if (dt.Rows.Count % 10 == 0)
            //        {
            //            ds.Tables.Add(dt.Copy());
            //            dt = dt.Clone();
            //            tbName += 1;
            //            dt.TableName = tbName.ToString();
            //        }
            //    }
            //    if (dtWL.Rows.Count < 10)
            //        dsWL.Tables.Add(dt.Copy());
            //    else if (dt.Rows.Count > 0)
            //    {
            //        ds.Tables.Add(dt.Copy());
            //        dsWL = ds;
            //    }
            //    else
            //        dsWL = ds;
            //}
            //else
            //{
                #region RemoveCode at 20090712 03:09 AM
                //DataTable dt = new DataTable();
                //DataTable dtt = new DataTable();
                //dt = dtWL.Copy();
                //dtt = dtWL.Clone();

                //#region filterHN
                //if (txtHN.Text != "")
                //{
                //    dtt = dtWL.Clone();
                //    DataRow[] drs = dt.Select("HN='" + txtHN.EditValue + "'");
                //    foreach (DataRow dr in drs)
                //        dtt.Rows.Add(dr.ItemArray);
                //    dt = dtt;
                //}
                //#endregion

                //#region filterAGE
                //if (txtAge.Text != "")
                //{
                //    dtt = dtWL.Clone();
                //    DataRow[] drs = dt.Select("AGE=" + txtAge.Text);
                //    foreach (DataRow dr in drs)
                //        dtt.Rows.Add(dr.ItemArray);
                //    dt = dtt;
                //}
                //#endregion

                //#region filterGENDER
                //if (txtGender.Text != "")
                //{
                //    dtt = dtWL.Clone();
                //    DataRow[] drs = dt.Select("GENDER='" + txtGender.Text.Substring(0, 1) + "'");
                //    foreach (DataRow dr in drs)
                //        dtt.Rows.Add(dr.ItemArray);
                //    dt = dtt;
                //}
                //#endregion

                //#region filterEXAMNAME
                //if (txtExamName.Text != "")
                //{
                //    dtt = dtWL.Clone();
                //    DataRow[] drs = dt.Select("EXAM_ID=" + txtExamName.EditValue);
                //    foreach (DataRow dr in drs)
                //        dtt.Rows.Add(dr.ItemArray);
                //    dt = dtt;
                //}
                //#endregion

                //#region filterEXAMTYPE
                //if (txtExamType.Text != "")
                //{
                //    dtt = dtWL.Clone();
                //    DataRow[] drs = dt.Select("EXAM_TYPE_ID=" + txtExamType.EditValue);
                //    foreach (DataRow dr in drs)
                //        dtt.Rows.Add(dr.ItemArray);
                //    dt = dtt;
                //}
                //#endregion

                //#region filterFinally
                //dtWL = dt.Copy();
                //#endregion

                //dsWL = new DataSet();
                //DataSet ds = new DataSet();

                //dt = new DataTable();
                //dtt = new DataTable();
                //dt = dtWL.Copy();
                //dtt = dtWL.Clone();

                //int tbName = 1;
                //dt.TableName = tbName.ToString();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    dtt.Rows.Add(dr.ItemArray);
                //    if (dtt.Rows.Count % 10 == 0)
                //    {
                //        ds.Tables.Add(dtt.Copy());
                //        dtt = dt.Clone();
                //        tbName += 1;
                //        dtt.TableName = tbName.ToString();
                //    }
                //}
                //if (dt.Rows.Count < 10)
                //    ds.Tables.Add(dtt.Copy());
                //else if (dt.Rows.Count > 0)
                //{
                //    ds.Tables.Add(dtt.Copy());
                //}
                //dsWL = ds.Copy();

                //tr = dtWL.Rows.Count;
                //#region show row number in tab header
                //xtraTabControl1.TabPages[0].Text = "Search Result (" + tr.ToString() + ")";
                //#endregion
                #endregion
            //}
            #endregion

            dsWL = new DataSet();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt = dtWL.Clone();

            int tbName = 1;

            dt.TableName = tbName.ToString();
            foreach (DataRow dr in dtWL.Rows)
            {
                dt.Rows.Add(dr.ItemArray);
                if (dt.Rows.Count % 10 == 0)
                {
                    ds.Tables.Add(dt.Copy());
                    dt = dt.Clone();
                    tbName += 1;
                    dt.TableName = tbName.ToString();
                }
            }
            if (dtWL.Rows.Count < 10)
                dsWL.Tables.Add(dt.Copy());
            else if (dt.Rows.Count > 0)
            {
                ds.Tables.Add(dt.Copy());
                dsWL = ds;
            }
            else
                dsWL = ds;

        }
        private void LoadGrid()
        {

        }
        private void Reload()
        {
            try
            {
                LoadTable();
                LoadFilter();
                LoadGrid();
            }
            catch (Exception ex)
            {
                LoadStopProgressBar();
                if (ex.Message.Contains("Timeout expired"))
                {
                    MessageBox.Show("Please increase your search filter or type more keyword in search box that can improve the performance", "Too much time to retrieval information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //MessageBox.Show("[Error Message] : " + ex.Message);
                }
                //for (int i = 0; i < 9; ++i)
                //    se.RISSearchEngine.KEYS[i] = "";
                //se.RISSearchEngine.KEYS[0] = "!!@@##$$%%^^&&**(())__++(need empty text)";
                //se.RISSearchEngine.MODE = "1";
                //se.Invoke();
            }
        }

        private void LoadData_Webpage()
        {
            #region check error
            if (dsWL.Tables.Count == 0)
            {
                string ct = @"<html><head><title></title></head><body>";
                ct += @" <table bgcolor='AliceBlue' style='width: 100%; height: auto;'>
                                <tr>
                                    <td style='font-family: sans-serif; font-size: small; width: 150px;'>
                                        Envision SearchEngine
                                    </td>
                                    <td align='right' style='font-family: sans-serif; font-size: small'>" +
                                         "Results 00-00" +
                                         "of about 0 for '" + searchText + "'(" + tspan.TotalSeconds.ToString() + "sec.)" +
                                    @"</td>
                                </tr>
                            </table>";
                ct += "</br>";
                ct += "<font size='4' color='red' face='sans-serif'>No results found</font></br>";
                ct += @"</body></html>";

                WebPage = ct;
                return;
            }

            #endregion

            #region check norow occure
            if (dsWL.Tables[0].Rows.Count==0)
            {
                string ct = @"<html><head><title></title></head><body>";
                ct += @" <table bgcolor='AliceBlue' style='width: 100%; height: auto;'>
                                <tr>
                                    <td style='font-family: sans-serif; font-size: small; width: 150px;'>
                                        Envision SearchEngine
                                    </td>
                                    <td align='right' style='font-family: sans-serif; font-size: small'>" +
                                         "Results 00-00"+
                                         "of about 0 for '" + searchText + "'(" + tspan.TotalSeconds.ToString() + "sec.)" +
                                    @"</td>
                                </tr>
                            </table>";
                ct += "</br>";
                ct += "<font size='4' color='red' face='sans-serif'>No results found</font></br>";
                ct += @"</body></html>";

                WebPage = ct;
                return;
            }
            #endregion

            #region check error
            if (WebPN > dsWL.Tables.Count)
            {
                string ct = @"<html><head><title></title></head><body>";
                ct += @" <table bgcolor='AliceBlue' style='width: 100%; height: auto;'>
                                <tr>
                                    <td style='font-family: sans-serif; font-size: small; width: 150px;'>
                                        Envision SearchEngine
                                    </td>
                                    <td align='right' style='font-family: sans-serif; font-size: small'>" +
                                         "Results 00-00" +
                                         "of about 0 for '" + searchText + "'(" + tspan.TotalSeconds.ToString() + "sec.)" +
                                    @"</td>
                                </tr>
                            </table>";
                ct += "</br>";
                ct += "<font size='4' color='red' face='sans-serif'>No results found</font></br>";
                ct += @"</body></html>";

                WebPage = ct;
                return;
            }
            #endregion

            DataTable dt = new DataTable();
            string content = "";
            int rowCount = 0;

            #region initLoadData
            ProcessGetRISSearchEngine se = new ProcessGetRISSearchEngine();
            se.RISSearchEngine.MODE = "2";
            se.RISSearchEngine.ACCESSION_NO = "_EMPTY_";
            
            se.InvokeDB();
            
            dt = se.Result.Tables[0].Clone();
            #endregion

            foreach (DataRow dr in dsWL.Tables[WebPN - 1].Rows)
            {
                #region LoadData
                se = new ProcessGetRISSearchEngine();
                se.RISSearchEngine.MODE = "2";
                se.RISSearchEngine.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                se.InvokeDB();
                dt.Rows.Add(se.Result.Tables[0].Rows[0].ItemArray);
                #endregion

                ResultText = dt.Rows[dt.Rows.Count - 1]["RESULT_TEXT_PLAIN"].ToString();
                webBS_FontHilighting();
                dt.Rows[dt.Rows.Count - 1]["RESULT_TEXT_PLAIN"] = ResultText;

                dt.Rows[dt.Rows.Count - 1]["FOUND"] = dr["FREQUENCY"].ToString();
            }

            string finallyPage = "";
            if (Convert.ToInt32(WebPN.ToString() + "0") > tr)
                finallyPage = tr.ToString().Length == 1 ? "0" + tr.ToString() : tr.ToString();
            else
                finallyPage = (WebPN.ToString() + "0").ToString();

            if (dt.Rows.Count > 0)
            {
                content = @"<html><head><title></title></head><body>";
                content += @" <table bgcolor='AliceBlue' style='width: 100%; height: auto;'>
                                <tr>
                                    <td style='font-family: sans-serif; font-size: small; width: 150px;'>
                                        Envision SearchEngine
                                    </td>
                                    <td align='right' style='font-family: sans-serif; font-size: small'>" +
                                         "Results " + (WebPN - 1).ToString() + @"1-" + finallyPage + @" " +
                                         "of about " + tr.ToString() + " for '" + searchText + "'(" + tspan.TotalSeconds.ToString() + "sec.)" +
                                    @"</td>
                                </tr>
                            </table>";
                content += "</br>";

                foreach (DataRow dr in dt.Rows)
                {
                    string header = dr["RESULT_TEXT_PLAIN"].ToString();
                    string text = dr["RESULT_TEXT_PLAIN"].ToString();
                    string access_no = dr["ACCESSION_NO"].ToString();
                    string orderDate = dr["STUDY_DATE"].ToString();
                    string orderID = dr["ORDER_ID"].ToString();

                    string hn = "HN:" + "(" + dr["HN"].ToString() + ")" + dr["PATIENT_NAME"].ToString();
                    string prelim = "Prelim:" + dr["RELEASE_NAME"].ToString();
                    string finalize = "Finalize:" + dr["FINALIZE_NAME"].ToString();

                    content +=
                        "<font size='3' color='black' face='sans-serif'><a href='http://localhost/"
                        + rowCount + "'>"
                        + orderDate + " " + hn
                        + "</a>    "
                        + string.Format("<a href='AccessionNumber={0}'><img src='{1}' alt='Open PACS' width='16' height='16' border='0' /></a> &nbsp;", access_no, synapseICON)
                        + string.Format("<a href='ScanImage={0}'><img src='{1}' alt='Open Request Document' width='16' height='16' border='0' /></a>", orderID, requestICON)
                        
                        +"</br></font><font size='2' color='black' face='sans-serif'>"
                        + text + "</font></br>"
                        + "<font size='2' color='gray' face='sans-serif'>" + " " + prelim + " " + finalize + "</font></br>"
                        //+ "<font size='2' color='green' face='sans-serif'> The number of keyword was found that is/are " + dr ["FOUND"].ToString()+ " word/words</font></br>"
                        + "</br>";
                    rowCount++;
                }
                content += @"</body></html>";
            }
            WebPage = content;
        }
        private void LoadFilter_Webpage()
        { 
        
        }
        private void LoadGrid_Webpage()
        {
            webBS.DocumentText = WebPage;
        }
        private void Reload_WebPage()
        {
            LoadData_Webpage();
            LoadFilter_Webpage();
            LoadGrid_Webpage();
        }

        private void LoadData_NewTabPage()
        {
            DataRow dr = drNT;
            ntACCESSION_NO = dr["ACCESSION_NO"].ToString();
            ntHN = dr["HN"].ToString();
            ntPATIENT_NAME = dr["PATIENT_NAME"].ToString();
            ntAGE = dr["AGE"].ToString();
            ntGENDER = dr["GENDER"].ToString();
            ntEXAM_CODE = dr["EXAM_CODE"].ToString();
            ntEXAM_TYPE_CODE = dr["EXAM_TYPE_CODE"].ToString();
            ntRELEASE_NAME = dr["RELEASE_NAME"].ToString();
            ntRELEASED_ON = dr["RELEASED_ON"].ToString()=="" ? "" : Convert.ToDateTime(dr["RELEASED_ON"]).ToString("dd/MM/yyyy");
            ntFINALIZE_NAME = dr["FINALIZE_NAME"].ToString();
            ntFINALIZED_ON = dr["FINALIZED_ON"].ToString() == "" ? "" : Convert.ToDateTime(dr["FINALIZED_ON"]).ToString("dd/MM/yyyy");
            ntSTUDY_DATE = dr["STUDY_DATE"].ToString() == "" ? "" : Convert.ToDateTime(dr["STUDY_DATE"]).ToString("dd/MM/yyyy");
            ntREPORT_DATE = dr["REPORT_DATE"].ToString() == "" ? "" : Convert.ToDateTime(dr["REPORT_DATE"]).ToString("dd/MM/yyyy");
            //TransRtf rtf = new TransRtf(dr["RESULT_TEXT_RTF"].ToString());
            //ntRESULT_TEXT_RTF = rtf.Translator();
            ntRESULT_TEXT_RTF = dr["RESULT_TEXT_HTML"].ToString();
            ntOrderID = dr["ORDER_ID"].ToString();
        }
        private void LoadFilter_NewTabPage()
        {

        }
        private void LoadGrid_NewTabPage()
        {

            string reporting1 = string.IsNullOrEmpty(ntRELEASE_NAME) ? "Finalize Name:" + ntFINALIZE_NAME : "preliminary Name:" + ntRELEASE_NAME;
            string reportDate1 = string.IsNullOrEmpty(ntRELEASED_ON) ? "Finalize Date:" + ntFINALIZED_ON : "preliminary Date:" + ntRELEASED_ON;
            string reporting2 = string.IsNullOrEmpty(reporting1) ? "" : string.IsNullOrEmpty(ntFINALIZE_NAME.Trim()) ? "" : "Finalize Name:" + ntFINALIZE_NAME;
            string reportDate2 = string.IsNullOrEmpty(reportDate1) ? "" : string.IsNullOrEmpty(ntFINALIZED_ON.Trim()) ? "" : "Finalize Date:" + ntFINALIZED_ON;

            string ct = @"<html><head><title></title></head><body>";
            ct += @"<table align='center' bgcolor='AliceBlue' style='width: 100%;  font-size: 11px; font-family: tahoma;'>
                <tr>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        HN:" + ntHN + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Name:" + ntPATIENT_NAME + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Age:" + ntAGE + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Gender:" + ntGENDER + @"</td>
                </tr>
                <tr>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Exam:" + ntEXAM_CODE + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Type:" + ntEXAM_TYPE_CODE + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Study Date:" + ntSTUDY_DATE + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Report Date:" + ntREPORT_DATE + @"</td>
                </tr>
                <tr>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        " + reporting1 + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        " + reportDate1 + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        " + reporting2 + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        " + reportDate2 + @"</td>
                </tr>
                <tr>
                    <td colspan='4' style='border: thin solid #FFFFFF'>
                        " 
                            + string.Format("<a href='AccessionNumber={0}'><img src='{1}' alt='Open PACS' width='16' height='16' border='0' /></a>&nbsp;", ntACCESSION_NO, synapseICON)+
                             string.Format("<a href='ScanImage={0}'><img src='{1}' alt='Open Request Document' width='16' height='16' border='0' /></a>", ntOrderID, requestICON)+
                        @"
                    </td>
                </tr>
            </table>";
        

            ct +=
            @"<table style='width:100%;'>
                <tr>
                 <td align='center' style='width: 10%'>
                    &nbsp;</td>
                <td align='left'>
                    <font size='5' color='black' face='tahoma'>" + ntRESULT_TEXT_RTF + "</font></td>"+
                @"<td align='left' style='width: 10%'>
                    &nbsp;</td></tr></table>";

            #region create webbrowser
            System.Windows.Forms.WebBrowser wb = new System.Windows.Forms.WebBrowser();
            wb.Dock = System.Windows.Forms.DockStyle.Fill;
            wb.Location = new System.Drawing.Point(0, 0);
            wb.MinimumSize = new System.Drawing.Size(20, 20);
            wb.Size = new System.Drawing.Size(100, 100);
            wb.DocumentText = ct;
            wb.Navigating += new WebBrowserNavigatingEventHandler(webBS_Navigating);
            #endregion

            #region create new tab page
            DevExpress.XtraTab.XtraTabPage xtab = new DevExpress.XtraTab.XtraTabPage();
            xtab.Controls.Add(wb);
            xtab.Name = ntACCESSION_NO;
            xtab.Text = "Page:" + xtraTabControl1.TabPages.Count.ToString();
            xtab.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            xtab.Size = new System.Drawing.Size(100, 100);
            xtab.Tag = ntACCESSION_NO;
            #endregion

            #region add new tab page
            xtraTabControl1.TabPages.Add(xtab);
            //DevExpress.XtraTab.XtraTabPage xtab = xtraTabControl1.TabPages[xtraTabControl1.TabPages.Count - 1];
            //xtab.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            //xtab.Name = "tabPage" + (xtraTabControl1.TabPages.Count - 1).ToString();
            //xtab.Text = "'" + searchText + "' Result(" + tr .ToString()+ ")";
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
            #endregion
        }

        private void Reload_NewTabPage()
        {
            #region check repeatedly accession No.
            foreach (DevExpress.XtraTab.XtraTabPage pg in xtraTabControl1.TabPages)
            {
                if (drNT["ACCESSION_NO"].ToString() == pg.Name.ToString())
                {
                    xtraTabControl1.SelectedTabPage = pg;
                    return;
                }
            }
            #endregion

            LoadData_NewTabPage();
            LoadFilter_NewTabPage();
            LoadGrid_NewTabPage();
        }

        private void LoadData_PageNumber()
        {
            if (WebPN <= dsWL.Tables.Count)
            {
                btnPageNumbers.Properties.Buttons[12].Caption = "Page " + WebPN + " of " + dsWL.Tables.Count;
            }
        }
        private void LoadFilter_PageNumber()
        {

        }
        private void LoadGrid_PageNumber()
        {

        }
        private void Reload_PageNumber()
        {
            LoadData_PageNumber();
            LoadFilter_PageNumber();
            LoadGrid_PageNumber();
        }

        private void LoadData_SearchFilter_1stLoad()
        {
            string conString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];

            #region LoadAge
            for (int i = 0; i < 199; i++)
                txtAge.Properties.Items.Add(i.ToString());
            #endregion

            #region LoadGender
            txtGender.Properties.Items.Add("Female");
            txtGender.Properties.Items.Add("Male");
            #endregion

            #region LoadExamName
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conString))
            {
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
                adapter.SelectCommand.Connection = con;
                adapter.SelectCommand.CommandText =
                @" select EXAM_ID,EXAM_UID as 'Exam Code', EXAM_NAME as 'Exam Name', EXAM_UID+':'+EXAM_NAME as 'Code:Name' " +
                @" from RIS_EXAM " +
                @" where IS_ACTIVE = 'Y' " +
                @" order by EXAM_ID asc ";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dtExamName);
            }
            #endregion

            #region LoadExamType
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conString))
            {
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
                adapter.SelectCommand.Connection = con;
                adapter.SelectCommand.CommandText =
                @" select EXAM_TYPE_ID,EXAM_TYPE_UID as 'ExamType Code',EXAM_TYPE_TEXT as 'ExamType Name', EXAM_TYPE_UID+':'+EXAM_TYPE_TEXT as 'Code:Name' " +
                @" from RIS_EXAMTYPE " +
                @" where IS_ACTIVE = 'Y' " +
                @" order by EXAM_TYPE_UID asc ";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dtExamType);
            }
            #endregion

            #region LoadRadilogist
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conString))
            {
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
                adapter.SelectCommand.Connection = con;
                adapter.SelectCommand.CommandText =
                @" select EMP_ID,EMP_UID as 'Rad Code', isnull(FNAME+' ','')+isnull(MNAME+' ','')+isnull(LNAME+' ','') as 'Rad Name', isnull(EMP_UID+': ','')+isnull(FNAME+' ','')+isnull(MNAME+' ','')+isnull(LNAME+' ','') as 'Code:Name' " +
                @" from HR_EMP " +
                @" where IS_ACTIVE = 'Y' AND IS_RADIOLOGIST = 'Y' AND SUPPORT_USER != 'Y' " +
                @" order by FNAME asc ";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dtRadiologist);
            }
            #endregion
        }
        private void LoadFilter_SearchFilter_1stLoad()
        { 
        }
        private void LoadGrid_SearchFilter_1stLoad()
        {
            txtExamName.Properties.DataSource = dtExamName;
            txtExamName.Properties.ValueMember = "EXAM_ID";
            txtExamName.Properties.DisplayMember = "Code:Name";
            txtExamNameView.OptionsView.ShowAutoFilterRow = true;
            txtExamNameView.Columns["Code:Name"].Visible = false;
            txtExamNameView.Columns["EXAM_ID"].Visible = false;
            txtExamNameView.BestFitColumns();

            txtExamType.Properties.DataSource = dtExamType;
            txtExamType.Properties.ValueMember = "EXAM_TYPE_ID";
            txtExamType.Properties.DisplayMember = "Code:Name";
            txtExamTypeView.OptionsView.ShowAutoFilterRow = true;
            txtExamTypeView.Columns["Code:Name"].Visible = false;
            txtExamTypeView.Columns["EXAM_TYPE_ID"].Visible = false;
            txtExamTypeView.BestFitColumns();

            txtRadiologist.Properties.DataSource = dtRadiologist;
            txtRadiologist.Properties.ValueMember = "EMP_ID";
            txtRadiologist.Properties.DisplayMember = "Code:Name";
            txtRadiologistView.OptionsView.ShowAutoFilterRow = true;
            txtRadiologistView.Columns["Code:Name"].Visible = false;
            txtRadiologistView.Columns["EMP_ID"].Visible = false;
            txtRadiologistView.BestFitColumns();
        }
        private void Reload_SearchFilter_1stLoad()
        {
            LoadData_SearchFilter_1stLoad();
            LoadFilter_SearchFilter_1stLoad();
            LoadGrid_SearchFilter_1stLoad();
        }

        private void LoadData_SearchFilter_2ndLoad()
        {
            if (dtHN == null)
            {
                string conString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
                LoadProgressBar();
                #region LoadHN
                dtHN = new DataTable();
                using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conString))
                {
                    System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                    adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
                    adapter.SelectCommand.Connection = con;
                    adapter.SelectCommand.CommandText =
                    @" select HN,isnull(FNAME+' ','')+isnull(MNAME+' ','')+isnull(LNAME,'') as 'Patient Name',HN+':'+isnull(FNAME+' ','')+isnull(MNAME+' ','')+isnull(LNAME,'') as 'HN:NAME',CREATED_ON as 'Registration Date' " +
                    @" from HIS_REGISTRATION " +
                    @" order by CREATED_ON desc ";
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(dtHN);

                    DataRow EmptyRow = dtHN.NewRow();
                    EmptyRow["HN"] = "";
                    EmptyRow["Patient Name"] = "";
                    EmptyRow["HN:NAME"] = "";
                    EmptyRow["Registration Date"] = DateTime.Now;
                    dtHN.Rows.Add(EmptyRow);
                    dtHN.AcceptChanges();
                }
                #endregion
                LoadStopProgressBar();
                txtHN.ShowPopup();
            }
        }
        private void LoadFilter_SearchFilter_2ndLoad()
        {
        }
        private void LoadGrid_SearchFilter_2ndLoad()
        {
            txtHN.Properties.DataSource = dtHN;
            txtHN.Properties.ValueMember = "HN";
            txtHN.Properties.DisplayMember = "HN:NAME";
            txtHNView.OptionsView.ShowAutoFilterRow = true;

            txtHNView.Columns["HN:NAME"].Visible = false;

            txtHNView.Columns["HN"].Width = 100;
            txtHNView.Columns["HN"].VisibleIndex = 0;

            txtHNView.Columns["Patient Name"].Width = 150;
            txtHNView.Columns["Patient Name"].VisibleIndex = 1;

            txtHNView.Columns["Registration Date"].Width = 100;
            txtHNView.Columns["Registration Date"].VisibleIndex = 2;
            txtHNView.Columns["Registration Date"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            txtHNView.Columns["Registration Date"].DisplayFormat.FormatString = "dd/MM/yyyy";
        }
        private void Reload_SearchFilter_2ndLoad()
        {
            LoadData_SearchFilter_2ndLoad();
            LoadFilter_SearchFilter_2ndLoad();
            LoadGrid_SearchFilter_2ndLoad();
        }

        private void txtHN_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                txtHN.Text = "";
            }
        }
        private void txtAge_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                txtAge.Text = "";
        }
        private void txtGender_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                txtGender.Text = "";
        }
        private void txtExamName_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                txtExamName.Text = "";
        }
        private void txtExamType_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                txtExamType.Text = "";
        }
        private void txtReportDateFrom_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                txtReportDateFrom.Text = "";
                txtReportDateTo.Text = "";
            }
        }
        private void txtStudyDateFrom_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                txtStudyDateFrom.Text = "";
                txtStudyDateTo.Text = "";
            }
        }
        private void txtRadiologist_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                txtRadiologist.Text = "";
            }
        }

        private void txtHN_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            Reload_SearchFilter_2ndLoad();
        }
        private void btnpanelVisible_Click(object sender, EventArgs e)
        {
            panelSearchFilter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            btnpanelVisible.Visible = false;
            panelSearchFilter.Expanded = true;
        }
        private void panelSearchFilter_ExpandedChanged(object sender, EventArgs e)
        {
            if (panelSearchFilter.Expanded == false)
            {
                panelSearchFilter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                btnpanelVisible.Visible = true;
            }
        }
        private void txtHN_TextChanged(object sender, EventArgs e)
        {
            //txtHN.EditValue = txtHN.Text;
        }
        private void txtArrangeBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportSearchProcess();
        }

        private void LoadProgressBar()
        {
            if (!firstLoad)
                base.ShowWaitDialog("In Progress...", "Please waiting");
        }
        private void LoadStopProgressBar()
        {
            base.CloseWaitDialog();
        }
    }
}