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


namespace Envision.NET.Forms.Dialog
{
    public partial class LookupHN : DevExpress.XtraBars.Ribbon.RibbonForm//  Form
    {
        private DataTable dtt;
        private MyMessageBox msg = new MyMessageBox();
        private List<LookUpColumn> list = new List<LookUpColumn>();
        private DataColumn dc = new DataColumn();
        private string _FieldName = "";
        private string _FieldSort = "";

        string fldname;                 //Keep the table field name 
        string[] fieldName;             //To keep the field name in a arry type string
        string title;


        public LookupHN()
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
                    foreach (LookUpColumn l in list)
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
        public void EnvisionPatient()
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
                foreach (LookUpColumn l in list)
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
        }
        public void EnvisionPatient(DataTable dttEnvisionPatient)
        {
            grdData.DataSource = dttEnvisionPatient;
            for (int i = 0; i < dtt.Columns.Count; i++)
                view1.Columns[i].Visible = false;
            if (list.Count > 0)
            {
                foreach (LookUpColumn l in list)
                    if (l.Show)
                    {
                        view1.Columns[l.FieldName].Visible = true;
                        view1.Columns[l.FieldName].Caption = l.Caption;
                    }
            }
            else
            {
                for (int i = 0; i < dtt.Columns.Count; i++)
                {
                    view1.Columns[i].Visible = true;
                    view1.Columns[i].Caption = dtt.Columns[i].Caption.ToString();
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
            //this.ShowDialog();
        }
        public event ValueUpdatedEventHandler ValueUpdated;

        public void AddColumn(string FieldName, string Caption, bool Show, bool Return)
        {
            LookUpColumn look = new LookUpColumn();
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

            if (view1.FocusedRowHandle < 0)
            {
                string msgid = msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
            }
            else
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);

                if (dr == null)
                {
                    string msgid = msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
                    return;
                }
                string newValue = string.Empty;
                //LookUpColumn lk = new LookUpColumn();
                //for (int ar = 0; ar < dr.ItemArray.Length; ar++)
                //{

                //    newValue += newValue == string.Empty ? dr[ar].ToString() : "^" + dr[ar].ToString();
                //}
                //newValue = string.Empty;
                newValue += dr["HN"].ToString();//"^" + dr[ar].ToString(); 
                newValue += "^" + dr["REG_ID"].ToString();
                newValue += "^" + dr["FNAME"].ToString();
                newValue += "^" + dr["LNAME"].ToString();
                this.AddColumn("HN", "HN", true, true);
                this.AddColumn("REG_ID", "ID", false, true);
                this.AddColumn("FNAME", "First name", true, true);
                this.AddColumn("LNAME", "Last Name", true, true);
                this.DialogResult = DialogResult.OK;

                ValueUpdatedEventArgs valueArgs =  new ValueUpdatedEventArgs(newValue);
                ValueUpdated(this, valueArgs);
                this.Close();
            }
        }
        private void btnCloseN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void SearchFilter()
        {
            if (txtSearchKey.Text.Length > 4)
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

                    sbSearch.Append(" OR " + col.FieldName + " LIKE '" + txtSearchKey.Text + "%' ");
                }

                columnCustomer.FilterInfo = new ColumnFilterInfo(sbSearch.ToString().Substring(3));
            }
        }
        private void ReloadFilter()
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

                sbSearch.Append(" OR " + col.FieldName + " LIKE '" + txtSearchKey.Text + "%' ");
            }

            columnCustomer.FilterInfo = new ColumnFilterInfo(sbSearch.ToString().Substring(3));
        }

        private void view1_DoubleClick(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0)
            {
                string msgid = msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
            }
            else
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);

                if (dr == null)
                {
                    string msgid = msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
                    return;
                }
                string newValue = string.Empty;
                //LookUpColumn lk = new LookUpColumn();
                for (int ar = 0; ar < dr.ItemArray.Length; ar++)
                {

                    newValue += newValue == string.Empty ? dr[ar].ToString() : "^" + dr[ar].ToString();
                }
                this.DialogResult = DialogResult.OK;

                ValueUpdatedEventArgs valueArgs = new ValueUpdatedEventArgs(newValue);
                ValueUpdated(this, valueArgs);
                this.Close();
            }
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            //list.Clear();
            SearchFilter();
        }

        private void LookupData_Load(object sender, EventArgs e)
        {

        }

        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                if (_FieldName != "")
                {
                    DataRow dr = view1.GetDataRow(e.FocusedRowHandle);
                    rtDes.Text = dr[_FieldName].ToString();
                }
            }
        }

        private void txtSearchKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // btnOKN_Click(sender, e);
                if (txtSearchKey.Text == "")
                {
                    this.EnvisionPatient();
                    //list.Clear();
                    ReloadFilter();
                }
                else
                {
                    Envision.BusinessLogic.ProcessRead.ProcessGetHISRegistration prc = new ProcessGetHISRegistration(txtSearchKey.Text);
                    prc.Invoke();
                    this.EnvisionPatient(prc.Result.Tables[0].Copy());
                }
            }
        }
    }
}
