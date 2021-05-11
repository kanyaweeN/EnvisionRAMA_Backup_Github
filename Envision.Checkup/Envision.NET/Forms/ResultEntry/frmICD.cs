using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common;
using RIS.Common.Common;
using RIS.BusinessLogic;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using System.Collections;

namespace RIS.Forms.ResultEntry
{
    public partial class frmICD : Form
    {
        int count = 0;
        string hn = "";
        string accession = "";
        ArrayList arr = new ArrayList();
        int intcount = 0;
        public frmICD(string _hn, string _accession)
        {
            InitializeComponent();
            hn = _hn;
            accession = _accession;
            PopulateGrid(hn);
            GridEditable();
        }

#region Load Grid
        public void PopulateGrid(string _hn)
        {
            ResultEntryICD icd = new ResultEntryICD();
            icd.SpType = 2;
            icd.OrgID = new GBLEnvVariable().OrgID;
            icd.PatientID = _hn;

            ProcessGetResultICD ricd = new ProcessGetResultICD();
            ricd.ResultEntryICD = icd;
            ricd.Invoke();
            DataTable dticd = ricd.ResultSet.Tables[0];
            UltraGrid1.DataSource = dticd;
            //UltraGrid1.DataBind();
            if (this.UltraGrid1.DisplayLayout.ValueLists.Exists("Change"))
                return;
            if (this.UltraGrid1.DisplayLayout.ValueLists.Exists("Change2"))
                return;

            Infragistics.Win.ValueListsCollection lists = this.UltraGrid1.DisplayLayout.ValueLists;
            Infragistics.Win.ValueList vl = lists.Add("Change");
            Infragistics.Win.ValueList v2 = lists.Add("Change2");
            icd.SpType = 1;
            ricd.ResultEntryICD = icd;
            ricd.Invoke();
            DataTable dtcode = ricd.ResultSet.Tables[0];
            int i = 0;
            while (i < dtcode.Rows.Count)
            {

                vl.ValueListItems.Add(dtcode.Rows[i]["ICD_ID"].ToString(), dtcode.Rows[i]["ICD_UID"].ToString());
                v2.ValueListItems.Add(dtcode.Rows[i]["ICD_ID"].ToString(), dtcode.Rows[i]["ICD_DESC"].ToString());
                i++;
                
            }
            UltraGrid1.DisplayLayout.Bands[0].Columns["ICD Code"].ValueList = vl;
            UltraGrid1.DisplayLayout.Bands[0].Columns["ICD Description"].ValueList = v2;
            UltraGrid1.Text = "";
            UltraGrid1.DataSource = dticd;
            intcount = UltraGrid1.Rows.Count;
        }
#endregion
        #region GridEditableFalse
        public void GridEditable()
        {
            for (int i = 1; i < 2; i++)
            {
                this.UltraGrid1.DisplayLayout.Bands[0].Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
        }
 #endregion

        #region UltraGrid1_InitializeLayout

        void UltraGrid1_CellListSelect(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            //int ind=e.Cell.Row.Index;
            //int a=e.Cell.ValueList.SelectedItemIndex;
            string icdcode= (e.Cell.Row.Cells["ICD Code"].Text.ToString());
            string pqry4 = "select ICD_DESC from HIS_ICD where ICD_UID='" + icdcode + "'";
            ProcessGetGBLLookup plkp4 = new ProcessGetGBLLookup(pqry4);
            plkp4.Invoke();
            DataTable pdt4 = plkp4.ResultSet.Tables[0];
            string ICDdesc = (pdt4.Rows[0]["ICD_DESC"].ToString().Trim());
            e.Cell.Row.Cells["ICD Description"].Value=ICDdesc;
            
            for (int i = 1; i < UltraGrid1.Rows.Count; i++)
            {
                
                    string txt = (this.UltraGrid1.Rows[i].Cells["ICD Code"].Text.ToString().Trim());
                    if (txt == icdcode)
                    {
                        MessageBox.Show("Already Exist this ICD Code","Duplicate Value");
                        PopulateGrid(hn);
                        return;
                    }
                   
            }



        }

        private void UltraGrid1_AfterRowsDeleted(object sender, System.EventArgs e)
        {
            for (int j = 0; j < arr.Count; j++)
            {
                ResultEntryICD icd = new ResultEntryICD();
                icd.SpType = 4;
                icd.IcdID = Convert.ToInt32(arr[j].ToString());
                icd.PatientID = hn;

                icd.ResultFlag = "R";
                icd.OrgID = new GBLEnvVariable().OrgID;
                icd.CreatedBy = new GBLEnvVariable().UserID;

                ProcessGetResultICD ricd = new ProcessGetResultICD();
                ricd.ResultEntryICD = icd;
                ricd.Invoke();

            }
            intcount = UltraGrid1.Rows.Count;
        }
        void UltraGrid1_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            arr.Clear();
            for (int i = 0; i < UltraGrid1.Rows.Count;i++ )
            {
                if (UltraGrid1.Rows[i].Selected == true)
                {
                    string txt=(this.UltraGrid1.Rows[i].Cells["ICD Code"].Text.ToString().Trim());
                   
                    string pqry4 = "select ICD_ID from HIS_ICD where ICD_UID='" + txt + "'";
                    ProcessGetGBLLookup plkp4 = new ProcessGetGBLLookup(pqry4);
                    plkp4.Invoke();
                    DataTable pdt4 = plkp4.ResultSet.Tables[0];
                    string ICDid = (pdt4.Rows[0]["ICD_ID"].ToString().Trim());
                    arr.Add(ICDid);
                }
            }
            
                        
        }
        void UltraGrid1_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
           
            if (count > 0)
            {
                if (UltraGrid1.Rows.Count > 0)
                {
                    string icdid = this.UltraGrid1.Rows[1].Cells["ICD Code"].Value.ToString().Trim();
                    count++;
                    ResultEntryICD icd = new ResultEntryICD();
                    icd.SpType = 3;
                    icd.IcdID = Convert.ToInt32(icdid);
                    icd.PatientID = hn;

                    string pqry4 = "select ORDER_ID,EXAM_ID from ris_orderdtl where accession_no='" + accession + "'";
                    ProcessGetGBLLookup plkp4 = new ProcessGetGBLLookup(pqry4);
                    plkp4.Invoke();
                    DataTable pdt4 = plkp4.ResultSet.Tables[0];
                    int orderid = Convert.ToInt32(pdt4.Rows[0]["ORDER_ID"].ToString().Trim());

                    icd.OrderNo = orderid;
                    icd.AccessionNo = accession;
                    icd.ResultFlag = "R";
                    icd.OrgID = new GBLEnvVariable().OrgID;
                    icd.CreatedBy = new GBLEnvVariable().UserID;

                    ProcessGetResultICD ricd = new ProcessGetResultICD();
                    ricd.ResultEntryICD = icd;
                    ricd.Invoke();
                    intcount++;
                }
               

            }
            count = 1;
            
        }

        void UltraGrid1_BeforeRowInsert(object sender, Infragistics.Win.UltraWinGrid.BeforeRowInsertEventArgs e)
        {
            //do something
            
        }

        private void UltraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // Add-Row Feature Related Settings
            // --------------------------------------------------------------------------------
            // To enable the add-row functionality set the AllowAddNew. If you set the property 
            // to FixedAddRowOnTop or FixedAddRowOnBottom then the add-row will be fixed in the
            // root band. It won't scroll out of view as rows are scrolled.
            //
            e.Layout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;
           
            // Set the appearance for template add-rows. Template add-rows are the 
            // add-row templates that are displayed with each rows collection.
            //
            e.Layout.Override.TemplateAddRowAppearance.BackColor = Color.FromArgb(245, 250, 255);
            e.Layout.Override.TemplateAddRowAppearance.ForeColor = SystemColors.GrayText;

            // Once  the user modifies the contents of a template add-row, it becomes
            // an add-row and the AddRowAppearance gets applied to such rows.
            //
            e.Layout.Override.AddRowAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.AddRowAppearance.ForeColor = Color.Blue;

            // You can set the SpecialRowSeparator to a value with TemplateAddRow flag
            // turned on to display a separator ui element after the add-row. By default
            // UltraGrid displays a separator element if AllowAddNew is either
            // FixedAddRowOnTop or FixedAddRowOnBottom. For scrolling add-rows you have to
            // set the SpecialRowSeparator explicitly. You can also control the appearance
            // of the separator using the SpecialRowSeparatorAppearance proeprty.
            //
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow;
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = SystemColors.Control;

            // You can display a prompt in the add-row by setting the TemplateAddRowPrompt 
            // proeprty. By default UltraGrid does not display any add-row prompt.
            //
            e.Layout.Override.TemplateAddRowPrompt = "Click here to add a new record...";

            // You can control the appearance of the prompt using the Override's
            // TemplateAddRowPromptAppearance property. By default the prompt is
            // transparent. You can make it non-transparent by setting the appearance'
            // BackColorAlpha property or by setting the BackColor to a desired value.
            //
            e.Layout.Override.TemplateAddRowPromptAppearance.ForeColor = Color.Maroon;
            e.Layout.Override.TemplateAddRowPromptAppearance.FontData.Bold = DefaultableBoolean.True;

            // By default the prompt is displayed across multiple cells. You can confine
            // the prompt a particular cell by setting the SpecialRowPromptField property
            // of the band to the key of the column that you want to display the prompt in.
            //
            //e.Layout.Bands[0].SpecialRowPromptField = e.Layout.Bands[0].Columns[0].Key;

            // You can set the default value of an add-row field by using the DefaultCellValue 
            // property of the column. Also you can initialize a template add-row to dynamic
            // default values using the InitializeTemplateAddRow event of the UltraGrid.
            //e.Layout.Bands[0].Columns[5].DefaultCellValue = "(DefaultValue)";
            // --------------------------------------------------------------------------------

            // Other miscellaneous settings
            // --------------------------------------------------------------------------------
            // Set the scroll style to immediate so the rows get scrolled immediately
            // when the vertical scrollbar thumb is dragged.
            //
            e.Layout.ScrollStyle = ScrollStyle.Immediate;

            // ScrollBounds of ScrollToFill will prevent the user from scrolling the
            // grid further down once the last row becomes fully visible.
            //
            e.Layout.ScrollBounds = ScrollBounds.ScrollToFill;
            // --------------------------------------------------------------------------------

            // Initialize controls
            // --------------------------------------------------------------------------------
            // Load the AllowAddNew combobox.
            
            // --------------------------------------------------------------------------------
        }

        #endregion // UltraGrid1_InitializeLayout

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Visible=false; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                int cnt = UltraGrid1.Rows.Count;
            if (cnt == intcount)
            {
            }
            else if((cnt > intcount)&& (cnt>0))
            {
                UltraGrid1.Refresh();
                string icdid = this.UltraGrid1.Rows[0].Cells["ICD Code"].Value.ToString().Trim();
                ResultEntryICD icd = new ResultEntryICD();
                icd.SpType = 3;
                icd.IcdID = Convert.ToInt32(icdid);
                icd.PatientID = hn;

                string pqry4 = "select ORDER_ID,EXAM_ID from ris_orderdtl where accession_no='" + accession + "'";
                ProcessGetGBLLookup plkp4 = new ProcessGetGBLLookup(pqry4);
                plkp4.Invoke();
                DataTable pdt4 = plkp4.ResultSet.Tables[0];
                int orderid = Convert.ToInt32(pdt4.Rows[0]["ORDER_ID"].ToString().Trim());

                icd.OrderNo = orderid;
                icd.AccessionNo = accession;
                icd.ResultFlag = "R";
                icd.OrgID = new GBLEnvVariable().OrgID;
                icd.CreatedBy = new GBLEnvVariable().UserID;

                ProcessGetResultICD ricd = new ProcessGetResultICD();
                ricd.ResultEntryICD = icd;
                ricd.Invoke();
            }

            this.Visible=false;
            intcount = 0;
            count = 0;
        }

    }
}