using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.NET.Forms.Dialog;

using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System.Net;


namespace Envision.NET.Forms.Dialog
{
    public partial class frmLabData : DevExpress.XtraBars.Ribbon.RibbonForm//  Form
    {
        private DataTable dtt;
        private MyMessageBox msg = new MyMessageBox();
        private List<LookUpColumnLabData> list = new List<LookUpColumnLabData>();
        private DataColumn dc = new DataColumn();
        private string _FieldName = "";
        private string _FieldSort = "";

        string fldname;                 //Keep the table field name 
        string[] fieldName;             //To keep the field name in a arry type string
        string title;


        public frmLabData()
        {
            InitializeComponent();
            dtt = null;
            SetGrid();
            layDes.Expanded = false;
            
        }
        public bool ShowDescription
        {
            get { return layDes.Expanded; }
            set { layDes.Expanded = value; }
        }
        public string PreviewFieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }
        public string SortFieldName
        {
            get { return _FieldSort; }
            set { _FieldSort = value; }
        }
        public DataTable Data
        {
            get { return dtt; }
            set { dtt = value; }
        }

        public void ShowBox()
        {
            //if (list.Count == 0)
            //    throw new Exception("Please Add Column");
            if (dtt == null) return;
            //if (dtt.Rows.Count > 0)
            //{
                grdData.DataSource = dtt;
                for (int i = 0; i < dtt.Columns.Count; i++)
                    view1.Columns[i].Visible = false;
                if (list.Count > 0)
                {
                    foreach (LookUpColumnLabData l in list)
                        if (l.Show)
                        {
                            view1.Columns[l.FieldName].Visible = true;
                            view1.Columns[l.FieldName].Caption = l.Caption;
                            // view1.Columns[l.FieldName].BestFit();
                        }
                }
                else
                {
                    for (int i = 0; i < dtt.Columns.Count; i++)
                    {
                        view1.Columns[i].Visible = true;
                        view1.Columns[i].Caption = dtt.Columns[i].Caption.ToString();
                        //lv.AddColumn(dtt.Columns[i].Caption.ToString(), dtt.Columns[i].Caption.ToString(), true, true);
                    }
                }
                if (_FieldSort != string.Empty)
                {
                    try
                    {
                        view1.Columns[_FieldSort].SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
                        view1.Columns[_FieldSort].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                    }
                    catch { }
                }
            //}
            view1.FocusedRowHandle = -999997;
            this.ShowDialog();
        }
        public event ValueUpdatedEventHandler ValueUpdated;

        public void AddColumn(string FieldName, string Caption, bool Show, bool Return)
        {
            LookUpColumnLabData look = new LookUpColumnLabData();
            look.FieldName = FieldName;
            look.Caption = Caption;
            look.Show = Show;
            look.Return = Return;
            list.Add(look);
        }
        public int ColumnCount
        {
            get { return list.Count; }
        }
        private void SetGrid()
        {
            view1.OptionsBehavior.Editable = false;

            view1.OptionsView.ShowGroupPanel = false;
            view1.OptionsView.ShowBands = false;
            view1.OptionsView.ColumnAutoWidth = true;
            view1.OptionsView.ShowAutoFilterRow = false;

            //for (int i = 0; i < PreTemplate.Columns.Count; i++)
            //    PreTemplate.Columns[i].Visible = false;

            view1.OptionsSelection.EnableAppearanceFocusedRow = true;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.InvertSelection = false;
            view1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            //view1.OptionsSelection.MultiSelect = true;

        }

        private void btnOKN_Click(object sender, EventArgs e)
        {
            //if (view1.FocusedRowHandle < 0)
            //{
            //    string msgid = msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
            //}
            //else
            //{
            //    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);

            //    if (dr == null)
            //    {
            //        string msgid = msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
            //        return;
            //    }
            //    string newValue = string.Empty;
            //    //LookUpColumnLabData lk = new LookUpColumnLabData();
            //    for (int ar = 0; ar < dr.ItemArray.Length; ar++)
            //    {

            //        newValue += newValue == string.Empty ? dr[ar].ToString() : "^" + dr[ar].ToString();
            //    }
            //    this.DialogResult = DialogResult.OK;

            //    ValueUpdatedEventArgs valueArgs =  new ValueUpdatedEventArgs(newValue);
            //    ValueUpdated(this, valueArgs);
            //    this.Close();
            //}

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnCloseN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void SearchFilter()
        {
            view1.Columns[0].FilterInfo = new ColumnFilterInfo();
            //string StrCol1 = view1.Columns[0].FieldName;
            string StrCol2 = view1.Columns[1].FieldName;
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn columnCustomer = view1.Columns[StrCol2];
            //List<string> lstFieldName = new List<string>();
            StringBuilder sbSearch = new StringBuilder();

            if (sbSearch.ToString().Length > 3)
            {
                return;
            }
            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col in view1.Columns)
            {
             
                sbSearch.Append(" OR " + col.FieldName + " LIKE '%" + txtSearchKey.Text + "%' ");
            }

            columnCustomer.FilterInfo = new ColumnFilterInfo(sbSearch.ToString().Substring(3));
          
        }

        private void view1_DoubleClick(object sender, EventArgs e)
        {
            //if (view1.FocusedRowHandle < 0)
            //{
            //    string msgid = msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
            //}
            //else
            //{
            //    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);

            //    if (dr == null)
            //    {
            //        string msgid = msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
            //        return;
            //    }
            //    string newValue = string.Empty;
            //    //LookUpColumnLabData lk = new LookUpColumnLabData();
            //    for (int ar = 0; ar < dr.ItemArray.Length; ar++)
            //    {

            //        newValue += newValue == string.Empty ? dr[ar].ToString() : "^" + dr[ar].ToString();
            //    }
            //    this.DialogResult = DialogResult.OK;

            //    ValueUpdatedEventArgs valueArgs = new ValueUpdatedEventArgs(newValue);
            //    ValueUpdated(this, valueArgs);
            //    this.Close();
            //}
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            list.Clear();
            SearchFilter();
        }

        private void LookupData_Load(object sender, EventArgs e)
        {
            tabLabData.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }

        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle >= 0)
                {
                    if (_FieldName != "")
                    {
                        DataRow dr = view1.GetDataRow(e.FocusedRowHandle);
                        string link = dr[_FieldName].ToString().ToUpper();

                        if (link.Contains("\\GW3"))
                            ShowHTMLLabResult(link);
                        else
                            ShowPaintTextResult(link);
                    }
                }
            }
            catch
            { 
                
            }
        }

        private void ShowPaintTextResult(string link)
        {
            tabLabData.SelectedTabPage = pagePlaintText;
            rtDes.Text = link;
        }

        private void ShowHTMLLabResult(string link)
        {
            tabLabData.SelectedTabPage = pageHtml;

            IPAddress[] IPs = Dns.GetHostAddresses(Dns.GetHostName());
            if (IPs.Length == 0) return;
            string IP = IPs[0].ToString();

            string htmlLink = "";
            //if (IP.Contains("192.168"))
            //{
            //    htmlLink = link.Replace("\\GW3", "\\192.168.0.227");
            //}
            //else
            //{
                htmlLink = link.Replace("\\GW3", "\\10.6.86.23");
            //}

            webHtml.Navigate(htmlLink);
        }

        //private void ShowHTMLLabResult(string link)
        //{
        //    tabLabData.SelectedTabPage = pageHtml;
        //    string WebPage = "http://miracle99/EnvisionLabData/Default.aspx";
        //    WebPage = WebPage + "?LabDataPath=" + link;
        //    webHtml.Navigate(WebPage);
        //}

        private void txtSearchKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOKN_Click(sender, e);
            }
        }
    }

    struct LookUpColumnLabData
    {
        public string FieldName;
        public string Caption;
        public bool Show;
        public bool Return;
    }


}
