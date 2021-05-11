using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.UtilityClass;
using RIS.Common.DBConnection;
using RIS.BusinessLogic;
using RIS.Common;
using UUL.ControlFrame.Controls;
using System.Globalization;
using System.Threading;
using RIS.Common.Common;
using System.Collections;
using RIS.Operational;
using RIS.Forms.GBLMessage;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;

//Service Type
namespace RIS.Forms.Admin
{
    public partial class RIS_SF10 : Form
    {

        private List<int> _deleteItem = new List<int>();
        private DataSet _tempDataSet = new DataSet();
        DBUtility dbu = new DBUtility();
        GBLEnvVariable env = new GBLEnvVariable();
        MyMessageBox msg = new MyMessageBox();
        GBLExceptionLog elog = new GBLExceptionLog();

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public RIS_SF10(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            //ChangeFormLanguage();
           // LoadFormLanguage();

        }

        private void RIS_SF10_Load(object sender, EventArgs e)
        {
            Binding();
            ColumnSetting();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //dbu.CloseFrom(CloseControl, this);
        }       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable table1 = (DataTable)gridControl1.DataSource;
            DataRow row1 = table1.Rows[view1.FocusedRowHandle];

            if (row1[0].ToString() != "")
                _deleteItem.Add(Int32.Parse(row1[0].ToString()));

            table1.Rows.RemoveAt(view1.FocusedRowHandle);
            //grdServiceType.CommitEdit(new DataGridViewDataErrorContexts());

            //for(int i = 0 ;i <grdServiceType.Rows.Count ; i++)  //foreach (DataGridViewRow row in grdLang.Rows)
            //{
            //    bool isDelete = false;
            //    try
            //    {
            //        isDelete = (bool)grdServiceType.Rows[i].Cells[0].Value;
            //    }
            //    catch (Exception ex)
            //    {
            //    }

            //    if (isDelete )
            //    {
            //        if (grdServiceType.Rows[i].Cells[1].Value.ToString() != "")
            //            _deleteItem.Add(grdServiceType.Rows[i].Cells[1].Value.ToString());
            //        _tempDataSet.Tables[0].Rows.RemoveAt(i);
            //        i = -1;
            //    }
            //}
            //foreach(string str in _deleteItem)
            //{
            //    MessageBox.Show(str);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //grdServiceType.CommitEdit(new DataGridViewDataErrorContexts());

            //string ret = msg.ShowAlert("UID008", env.CurrentLanguageID);
            string ret = "2";
            if (ret.ToString() == "2")
            //if (MessageBox.Show("Are you sure you want to save the data? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<RISServicetype> insertServiceType = new List<RISServicetype>();
                List<RISServicetype> updateServiceType = new List<RISServicetype>();

                //string str = grdServiceType.Rows[0].Cells[0].Value.ToString();

                //foreach (DataGridViewRow row in grdServiceType.Rows)
                //{
                //    if (row.Cells[1].Value.ToString() != "")
                //    {
                //        string tmpUpdate = row.Cells[4].Value.ToString()== "Y" ? "Y" : "N";
                //        updateServiceType.Add(new RISServicetype(Int32.Parse(row.Cells[1].Value.ToString()), row.Cells[2].Value.ToString(), tmpUpdate, row.Cells[3].Value.ToString()));
                //    }
                //    else
                //    {
                //        string tmpUpdate = row.Cells[4].Value.ToString() == "Y" ? "Y" : "N";
                //        insertServiceType.Add(new RISServicetype(0, row.Cells[2].Value.ToString(), tmpUpdate, row.Cells[3].Value.ToString()));
                //    }
                //}

                DataTable table1 = (DataTable)gridControl1.DataSource;

                foreach(DataRow row in table1.Rows)
                {
                    if (row[1].ToString() == "" || row[2].ToString() == "")
                    {
                        msg.ShowAlert("UID2001", 1); 
                        return;
                    }

                    if(row[0].ToString()!="")
                    {
                        updateServiceType.Add(new RISServicetype(Int32.Parse(row[0].ToString()), row[1].ToString(), row[2].ToString(),
                            row[3].ToString(),"N","N"));
                    }
                    else
                    {
                        insertServiceType.Add(new RISServicetype(new int(), row[1].ToString(),row[2].ToString(),
                            row[3].ToString(),"N","N"));
                    }
                }

                if (_deleteItem.Count > 0)
                {
                    ProcessDeleteRISServicetype process = new ProcessDeleteRISServicetype();
                    process.DeleteItem = _deleteItem;
                    process.Invoke();
                }

                if (updateServiceType.Count > 0)
                {
                    ProcessUpdateRISServicetype process = new ProcessUpdateRISServicetype();
                    process.ServiceTypeItem = updateServiceType;
                    process.Invoke();
                }

                if (insertServiceType.Count > 0)
                {
                    ProcessAddRISServicetype process = new ProcessAddRISServicetype();
                    process.ServiceTypeItem = insertServiceType;
                    process.Invoke();
                }

                msg.ShowAlert("UID008", env.CurrentLanguageID);
            }          
            
            Binding();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void nGrouper1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //grdServiceType.CommitEdit(new DataGridViewDataErrorContexts());
            //_tempDataSet.Tables[0].Rows.Add(new object[3]);
            DataTable table1 = (DataTable)gridControl1.DataSource;
            table1.Rows.Add(new object[4]);
        }

        private void Binding()
        {
            //_deleteItem.Clear();
            ProcessGetRISServicetype process = new ProcessGetRISServicetype(true);
            process.Invoke();
            _tempDataSet = process.Result;
            //grdServiceType.AutoGenerateColumns = false;
            //grdServiceType.DataSource = _tempDataSet.Tables[0].Copy();
            _tempDataSet.Tables[0].Columns.Add("DELETE");
            gridControl1.DataSource = _tempDataSet.Tables[0].Copy();

            _deleteItem = new List<int>();
        }

        private void ColumnSetting()
        {
            //SERVICE_TYPE_ID column setting
            view1.Columns["SERVICE_TYPE_ID"].Visible = true;
            view1.Columns["SERVICE_TYPE_ID"].Caption = "Service ID";
            view1.Columns["SERVICE_TYPE_ID"].OptionsColumn.AllowEdit = false;

            //SERVICE_TYPE_UID column setting
            RepositoryItemTextEdit textedit = new RepositoryItemTextEdit();
            textedit.EditValueChanged+=new EventHandler(textedit_EditValueChanged);
            view1.Columns["SERVICE_TYPE_UID"].Visible = true;
            view1.Columns["SERVICE_TYPE_UID"].Caption = "Service UID";
            view1.Columns["SERVICE_TYPE_UID"].ColumnEdit = textedit;

            //SERVICE_TYPE_TEXT column setting
            view1.Columns["SERVICE_TYPE_TEXT"].Visible = true;
            view1.Columns["SERVICE_TYPE_TEXT"].Caption = "Service Name";
            view1.Columns["SERVICE_TYPE_TEXT"].ColumnEdit = textedit;

            //IS_ACTIVE column setting
            RepositoryItemCheckEdit chkConfirm = new RepositoryItemCheckEdit();
            chkConfirm.ValueChecked = "Y";
            chkConfirm.ValueUnchecked = "N";
            chkConfirm.CheckStyle = CheckStyles.Standard;
            chkConfirm.NullStyle = StyleIndeterminate.Unchecked;
            chkConfirm.DisplayFormat.FormatType = FormatType.Custom;
            chkConfirm.CheckedChanged += new EventHandler(CheckedChanged);
            view1.Columns["IS_ACTIVE"].ColumnEdit = chkConfirm;

            //DELETE column setting
            RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
            btnDelete.AutoHeight = false;
            btnDelete.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Caption = string.Empty;
            btnDelete.Click += new EventHandler(btnDelete_Click);
            view1.Columns["DELETE"].ColumnEdit = btnDelete;

            //BestFit All Column
            for (int k = 0; k < view1.Columns.Count; k++)
            {
                view1.Columns[k].BestFit();
            }
        }

        void textedit_EditValueChanged(object sender, EventArgs e)
        {
            //DataRow row = (gridControl1.DataSource as DataTable).Rows[view1.FocusedRowHandle][view1.FocusedColumn];
            DevExpress.XtraEditors.TextEdit textedit = sender as DevExpress.XtraEditors.TextEdit;
            try
            {
                (gridControl1.DataSource as DataTable).Rows[view1.FocusedRowHandle][view1.FocusedColumn.FieldName.ToString()] = textedit.Text;
            }
            catch (Exception)
            { 
            
            }
            
            //throw new Exception("The method or operation is not implemented.");
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            
            DevExpress.XtraEditors.CheckEdit check1 = (DevExpress.XtraEditors.CheckEdit)sender;

            DataTable table1 = (DataTable)gridControl1.DataSource;
            DataRow row1 = table1.Rows[view1.FocusedRowHandle];

            row1[3] = check1.Checked == true ? "Y" : "N";
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        { 
        
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Binding();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
            //CloseControl.TabPages.RemoveAt(CloseControl.SelectedIndex);
        }

        //#region formlanguage
        //private void ChangeFormLanguage()
        //{


        //    FormLanguage fl = new FormLanguage();
        //    fl.FormID = 20;
        //    fl.LanguageID = new GBLEnvVariable().CurrentLanguageID;
        //    fl.ProcedureType = 1;

        //    ProcessGetLanguage langs = new ProcessGetLanguage();
        //    langs.FormLanguage = fl;
        //    try
        //    {
        //        langs.Invoke();
        //    }
        //    catch
        //    {
        //    }

        //    try
        //    {

        //        DataTable dt = langs.ResultSet.Tables[0];
        //        int k = 0;
        //        while (k < dt.Rows.Count)
        //        {
        //            if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblHeader").ToUpper().Trim())
        //            {
        //                this.nGrouper1.HeaderItem.Text =dt.Rows[k]["LABEL"].ToString().Trim();
        //            }
        //            if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblDelete").ToUpper().Trim())
        //            {
        //                this.clmDel.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
        //            }
        //            if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblLangUid").ToUpper().Trim())
        //            {
        //                this.LangUID.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
        //            }
        //            if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblLangName").ToUpper().Trim())
        //            {
        //                this.LangName.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
        //            }
        //            if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblLangIsActive").ToUpper().Trim())
        //            {
        //                this.IsActive.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
        //            }
                    
        //            //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblAuthMode").ToUpper().Trim())
        //            //{

        //            //    lblAuthMode.Text = dt.Rows[k]["LABEL"].ToString().Trim();
        //            //}
        //            //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUserName").ToUpper().Trim())
        //            //{
        //            //    lblUserName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
        //            //}
        //            //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblPassword").ToUpper().Trim())
        //            //{
        //            //    lblPassword.Text = dt.Rows[k]["LABEL"].ToString().Trim();
        //            //}
        //            //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblLanguage").ToUpper().Trim())
        //            //{
        //            //    lblLanguage.Text = dt.Rows[k]["LABEL"].ToString().Trim();
        //            //}

        //            //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkRem").ToUpper().Trim())
        //            //{
        //            //    chkRem.Text = dt.Rows[k]["LABEL"].ToString().Trim();
        //            //}
        //            //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnLogin").ToUpper().Trim())
        //            //{
        //            //    btnLogin.Text = dt.Rows[k]["LABEL"].ToString().Trim();
        //            //}
        //            //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnCancel").ToUpper().Trim())
        //            //{
        //            //    btnCancel.Text = dt.Rows[k]["LABEL"].ToString().Trim();
        //            //}

        //            k++;
        //        }



        //    }
        //    catch (Exception EX) { MessageBox.Show(EX.Message); }


        //    return;

        //}
        //#endregion



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Parent == null)
                {
                    string uid = treeView1.SelectedNode.Text.ToString();
                    //MessageBox.Show(treeView1.SelectedNode.ImageIndex.ToString());
                    //string pid = treeView1.SelectedNode.Parent.Text.ToString();
                    //MessageBox.Show (treeView1.SelectedNode.Parent.Text.ToString());

                    //string uid = treeView1.SelectedNode.Tag.ToString();
                    //loadTree2(uid, "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                elog.LogException(ex.ToString(), env.CurrentFormID, "F");
                return;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            //loadTree("" + txtSearch.Text.ToString().Trim() + "");
        }
        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
        }
    }
}