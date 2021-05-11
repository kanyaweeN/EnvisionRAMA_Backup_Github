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

//Modality Type
namespace RIS.Forms.Admin
{
    public partial class RIS_SF07 : Form
    {
        
        private List<string> _deleteItem = new List<string>();
        private DataSet _tempDataSet = new DataSet();
        DBUtility dbu = new DBUtility();
        GBLEnvVariable env = new GBLEnvVariable();
        MyMessageBox msg = new MyMessageBox();
        GBLExceptionLog elog = new GBLExceptionLog();

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public RIS_SF07(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            //ChangeFormLanguage();
           // LoadFormLanguage();

        }

       private void btnDelete_Click_1(object sender, EventArgs e)
        {
            grdModalityType.CommitEdit(new DataGridViewDataErrorContexts());

            for(int i = 0 ;i <grdModalityType.Rows.Count ; i++)  //foreach (DataGridViewRow row in grdLang.Rows)
            {
                bool isDelete = false;
                try
                {
                    isDelete = (bool)grdModalityType.Rows[i].Cells[0].Value;
                }
                catch (Exception ex)
                {
                }

                if (isDelete )
                {
                    if (grdModalityType.Rows[i].Cells[1].Value.ToString() != "")
                        _deleteItem.Add(grdModalityType.Rows[i].Cells[1].Value.ToString());
                    _tempDataSet.Tables[0].Rows.RemoveAt(i);
                    i = -1;
                }
            }
            //foreach(string str in _deleteItem)
            //{
            //    MessageBox.Show(str);
            //}
        }
        
        private void RIS_SF07_Load(object sender, EventArgs e)
        {
            Binding();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            grdModalityType.CommitEdit(new DataGridViewDataErrorContexts());

            string ret = msg.ShowAlert("UID008", env.CurrentLanguageID);
            if (ret.ToString() == "2")
            //if (MessageBox.Show("Are you sure you want to save the data? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<RISModalitytype> insertModalityType = new List<RISModalitytype>();
                List<RISModalitytype> updateModalityType = new List<RISModalitytype>();

                foreach (DataGridViewRow row in grdModalityType.Rows)
                {
                    if (row.Cells[1].Value.ToString() != "")
                    {
                        //string tmpUpdate = row.Cells[4].Value.ToString()== "Y" ? "Y" : "N";
                        updateModalityType.Add(new RISModalitytype(Int32.Parse(row.Cells[1].Value.ToString()), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString()));
                    }
                    else
                    {
                        //string tmpUpdate = row.Cells[4].Value.ToString() == "Y" ? "Y" : "N";
                        insertModalityType.Add(new RISModalitytype(0, row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString()));
                    }
                }

                if (_deleteItem.Count > 0)
                {
                    ProcessDeleteRISModalitytype process = new ProcessDeleteRISModalitytype();
                    process.DeleteItem = _deleteItem;
                    process.Invoke();
                }

                if (insertModalityType.Count > 0)
                {
                    ProcessAddRISModalitytype process = new ProcessAddRISModalitytype();
                    process.ModalityTypeItem = insertModalityType;
                    process.Invoke();
                }

                if (updateModalityType.Count > 0)
                {
                    ProcessUpdateRISModalitytype process = new ProcessUpdateRISModalitytype();
                    process.ModalityTypeItem = updateModalityType;
                    process.Invoke();
                }



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
            grdModalityType.CommitEdit(new DataGridViewDataErrorContexts());
            _tempDataSet.Tables[0].Rows.Add(new object[4]);
        }

        private void Binding()
        {
            _deleteItem.Clear();
            //ProcessSelectGBLLanguage process = new ProcessSelectGBLLanguage();
            ProcessGetRISModalitytype process = new ProcessGetRISModalitytype();
            process.Invoke();
            _tempDataSet = process.Result;
            grdModalityType.AutoGenerateColumns = false;
            grdModalityType.DataSource = _tempDataSet.Tables[0];

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Binding();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
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