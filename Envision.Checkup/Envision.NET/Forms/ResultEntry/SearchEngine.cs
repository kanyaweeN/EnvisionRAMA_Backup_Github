using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace RIS.Forms.ResultEntry
{
    public partial class SearchEngine : Form
    {
        #region MainForm Variables
        List<string> keys = new List<string>();
        DataTable dtWL = new DataTable();
        DataSet dsWL = new DataSet();
        int tr = 0;
        TimeSpan tspan = new TimeSpan();
        //int sc = 0;
        string searchText = "";
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
        #endregion

        #region PageNum Variable
        #endregion

        #region SearchFilter Variables
        DataTable dtHN = null;
        DataTable dtExamName = new DataTable();
        DataTable dtExamType = new DataTable();
        DataTable dtRadiologist = new DataTable();
        #endregion

        public SearchEngine(UUL.ControlFrame.Controls.TabControl Cls)
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
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProgressBar();
            Reload();
            Reload_WebPage();
            Reload_PageNumber();
            LoadStopProgressBar();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadProgressBar();
                Reload();
                Reload_WebPage();
                Reload_PageNumber();
                LoadStopProgressBar();
            }
        }

        private void LoadTable()
        {
            DateTime dn = DateTime.Now;
            searchText = txtSearch.Text;

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
                se.RISSearchEngine.MODE = "1";
                se.Invoke();
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
                se.RISSearchEngine.MODE = "3";
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
                se.Invoke();
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
            LoadTable();
            LoadFilter();
            LoadGrid();
        }

        private void LoadData_Webpage()
        {
            #region check error
            if (dsWL.Tables.Count == 0) return;
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
                ct += "<font size='4' color='red' face='sans-serif'>The keyword wasn't found</font></br>";
                ct += @"</body></html>";

                WebPage = ct;
                return;
            }
            #endregion

            #region check error
            if (WebPN > dsWL.Tables.Count)
            {
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
            se.Invoke();
            dt = se.Result.Tables[0].Clone();
            #endregion

            foreach (DataRow dr in dsWL.Tables[WebPN - 1].Rows)
            {
                #region LoadData
                se = new ProcessGetRISSearchEngine();
                se.RISSearchEngine.MODE = "2";
                se.RISSearchEngine.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                se.Invoke();
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

                    string hn = "HN:" + "(" + dr["HN"].ToString() + ")" + dr["PATIENT_NAME"].ToString();
                    string prelim = "Prelim:" + dr["RELEASE_NAME"].ToString();
                    string finalize = "Finalize:" + dr["FINALIZE_NAME"].ToString();

                    content +=
                        "<font size='3' color='black' face='sans-serif'><a href='http://localhost/"
                        + rowCount + "'>"
                        + orderDate + " " + hn
                        + "</a></br></font><font size='2' color='black' face='sans-serif'>"
                        + text + "</font></br>"
                        + "<font size='2' color='gray' face='sans-serif'>" + " " + prelim + " " + finalize + "</font></br>"
                        + "<font size='2' color='green' face='sans-serif'> The number of keyword was found that is/are " + dr ["FOUND"].ToString()+ " word/words</font></br>"
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
            RIS.Operational.Translator.TransRtf rtf = new RIS.Operational.Translator.TransRtf(dr["RESULT_TEXT_RTF"].ToString());
            ntRESULT_TEXT_RTF = rtf.Translator();
        }
        private void LoadFilter_NewTabPage()
        {

        }
        private void LoadGrid_NewTabPage()
        {
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
                        Exam Code:" + ntEXAM_CODE + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Exam Type:" + ntEXAM_TYPE_CODE + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Study Date:" + ntSTUDY_DATE + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Report Date:" + ntREPORT_DATE + @"</td>
                </tr>
                <tr>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Release Name:" + ntRELEASE_NAME + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Release Date:" + ntRELEASED_ON + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Finalize Name:" + ntFINALIZE_NAME + @"</td>
                    <td align='center' style='border: thin solid #FFFFFF'>
                        Finalize Date:" + ntFINALIZED_ON + @"</td>
                </tr>
            </table></br>";

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
            #endregion

            #region create new tab page
            DevExpress.XtraTab.XtraTabPage xtab = new DevExpress.XtraTab.XtraTabPage();
            xtab.Controls.Add(wb);
            xtab.Name = ntACCESSION_NO;
            xtab.Text = "Page:" + xtraTabControl1.TabPages.Count.ToString();
            xtab.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            xtab.Size = new System.Drawing.Size(100, 100);
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
                        se.Invoke();
                        #endregion
                        drNT = se.Result.Tables[0].Rows[0];
                        Reload_NewTabPage();
                        e.Cancel = true;
                    }
                    else
                        e.Cancel = true;

                    LoadStopProgressBar();
                }
            }
            catch (Exception ex)
            {
                LoadStopProgressBar();
                MessageBox.Show(ex.Message);
                e.Cancel = true;
            }
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
                txtHN.Text = "";
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

        private void LoadProgressBar()
        {
            this.Enabled = false;
            bgW.RunWorkerAsync();    
        }
        private void LoadStopProgressBar()
        {
            bgW.CancelAsync();
            this.Enabled = true;
        }
        private void bgW_DoWork(object sender, DoWorkEventArgs e)
        {
            ProgressBar frmPg = new ProgressBar(bgW);
            frmPg.ShowDialog();
        }
    }

    public class ProgressBar : Form
    {
        #region Designer

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = "In a Progress...";
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(2, 2);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marqueeProgressBarControl1.Properties.Appearance.Options.UseFont = true;
            this.marqueeProgressBarControl1.Properties.ShowTitle = true;
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(180, 23);
            this.marqueeProgressBarControl1.StyleController = this.layoutControl1;
            this.marqueeProgressBarControl1.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.marqueeProgressBarControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(183, 26);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(183, 26);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.marqueeProgressBarControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(181, 24);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Blue";
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(183, 26);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressBar";
            this.Text = "ProgressBar";
            this.Load += new System.EventHandler(this.ProgressBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;

        #endregion

        BackgroundWorker bg;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();

        public ProgressBar(BackgroundWorker bg)
        {
            InitializeComponent();
            this.bg = bg;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Blue";
        }
        private void ProgressBar_Load(object sender, EventArgs e)
        {
            tm.Interval = 500;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Start();
        }
        private void tm_Tick(object sender, EventArgs e)
        {
            if (bg.CancellationPending == true)
                this.Close();
        }
    }
}