using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;

using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Dialog;
using Envision.NET.Forms.Main;

namespace Envision.NET.Forms.Admin
{
    public partial class ExamMerge : MasterForm
    {
        private enum Task
        {
            None, Insert, Update, Delete
        }
        private Task task = Task.None;
        private MyMessageBox message;
        private int limit_merge_item = 2;
        private int currentRow = 0;
        private GBLEnvVariable gbl = new GBLEnvVariable();
        private DataSet examList;
        private DataSet autoMergeList;
        private bool isActive1 = false;

        public ExamMerge()
        {
            InitializeComponent();
        }
        private void ExamMerge_Load(object sender, EventArgs e)
        {

            #region Config
            SetComboBoxItem(cbExamUnit1);
            SetComboBoxItem(cbExamUnit2);
            SetTextboxInitial(false);
            SetComboBoxItemActive(false);
            SetButtonMenuInitial();
            SetInButton();
            SetOutButton();
            SetListBoxItemRightInitial(true);
            SetListBoxItemLeftInitial(true);
            SetRadioandCheckBoxActive(false);
            SetDataGrid();
            #endregion

            base.CloseWaitDialog();
        }

        #region Set Config Active Component
        private void SetInButton()
        {
            //Left exam list box
            if (lsExamName1.ItemCount == 0 || lsExamMerged.ItemCount == limit_merge_item)
                btnExamIn1.Enabled = false;
            else
                btnExamIn1.Enabled = true;
            //Right exam list box
            if (lsExamName2.ItemCount == 0 || lsExamMerged.ItemCount == limit_merge_item)
                btnExamIn2.Enabled = false;
            else
                btnExamIn2.Enabled = true;
        }
        private void SetOutButton()
        {
            if (lsExamMerged.ItemCount == 0)
            {
                btnExamOut1.Enabled = false;
                btnExamOut2.Enabled = false;
            }
            else
            {
                btnExamOut1.Enabled = true;
                btnExamOut2.Enabled = true;
            }
        }
        #endregion

        #region Set Button Menu
        private void SetButtonMenuInitial()
        {
            btnDeleteConfig.Enabled = true;
            btnEditConfig.Enabled = true;
            btnNewConfig.Enabled = true;
            btnOpenConfig.Enabled = true;
            btnRefresh.Enabled = true;

            btnCancel.Enabled = false;
            btnSave.Enabled = false;
        }
        private void SetButtonMenuInitialNoData()
        {
            btnDeleteConfig.Enabled = false;
            btnEditConfig.Enabled = false;
            btnNewConfig.Enabled = true;
            btnOpenConfig.Enabled = true;
            btnRefresh.Enabled = false;

            btnCancel.Enabled = false;
            btnSave.Enabled = false;
        }
        private void SetButtonOpenEvent(bool b) //false --> open
        {
            btnDeleteConfig.Enabled = !b;
            btnEditConfig.Enabled = !b;
            btnNewConfig.Enabled = !b;
            btnOpenConfig.Enabled = !b;
            btnRefresh.Enabled = !b;

            btnCancel.Enabled = !b;
            btnSave.Enabled = !b;
        }
        private void SetButtonNewEvent(bool b) //false --> new
        {
            btnDeleteConfig.Enabled = !b;
            btnEditConfig.Enabled = !b;
            btnNewConfig.Enabled = !b;
            btnOpenConfig.Enabled = !b;
            btnRefresh.Enabled = !b;

            btnCancel.Enabled = b;
            btnSave.Enabled = b;
        }
        private void SetButtonEditEvent(bool b) //false --> new
        {
            btnDeleteConfig.Enabled = !b;
            btnEditConfig.Enabled = !b;
            btnNewConfig.Enabled = !b;
            btnOpenConfig.Enabled = !b;
            btnRefresh.Enabled = !b;

            btnCancel.Enabled = b;
            btnSave.Enabled = b;
        }
        private void SetButtonSaveEvent(bool b)
        {
            SetButtonMenuInitial();

            SetComboBoxItemActive(false);
            ClearListBoxItem1();
            ClearListBoxItem2();
            ClearListBoxMerge();
            SetTextboxInitial(false);
            SetRadioandCheckBoxActive(false);
            SetInButton();
            SetOutButton();

            BindingData(currentRow);

            btnExamIn1.Enabled = false;
            btnExamIn2.Enabled = false;
            task = Task.None;
        }
        private void SetButtonCancelEvent(bool b)
        {
            btnDeleteConfig.Enabled = !b;
            btnEditConfig.Enabled = !b;
            btnNewConfig.Enabled = !b;
            btnOpenConfig.Enabled = !b;
            btnRefresh.Enabled = !b;

            btnCancel.Enabled = b;
            btnSave.Enabled = b;
        }
        #endregion

        #region Set TextBox and ComboBox
        private void SetTextboxInitial(bool b)
        {
            tbConfigName.Properties.ReadOnly = !b;
        }
        private void SetComboBoxItem(DevExpress.XtraEditors.ComboBoxEdit cbe)
        {
            if (examList == null)
                examList = GetExamDataSet();
            foreach (DataRow row in examList.Tables[0].Rows)
            {
                if (!cbe.Properties.Items.Contains(row["UNIT_ID"].ToString())
                    && row["UNIT_ID"].ToString() != "NULL")
                    cbe.Properties.Items.Add(row["UNIT_ID"].ToString());
            }
        }
        private void SetComboBoxSelectedItem(DevExpress.XtraEditors.ComboBoxEdit cbe, string item)
        {
            if (cbe.Properties.Items.Contains(item))
                cbe.Text = item;
                
              
        }
        private void SetComboBoxItemActive(bool b)
        {
            cbExamUnit1.Properties.ReadOnly = !b;
            cbExamUnit2.Properties.ReadOnly = !b;
        }
        #endregion

        #region Set RadioBox and CheckBox
        private void SetRadioandCheckBoxActive(bool b)
        {
            rgAutoApply.Enabled = b;
            chkActive.Enabled = b;
        }
        #endregion

        #region Clear ListBox Item
        private void ClearListBoxItem1()
        {
            lsExamName1.Items.Clear();
        }
        private void ClearListBoxItem2()
        {
            lsExamName2.Items.Clear();
        }
        private void ClearListBoxMerge()
        {
            lsExamMerged.Items.Clear();
        }
        #endregion

        #region Set Listbox Item and Focus
        private void SetListBoxItemRightInitial(bool b)
        {
            lsExamName2.Enabled= b;
        }
        private void SetListBoxItemLeftInitial(bool b)
        {
            lsExamName1.Enabled = b;
        }
        private void SetListBoxItemRight(int index)
        {
            ClearListBoxItem2();
            if (examList == null)
                examList = GetExamDataSet();
            foreach (DataRow dataRow in examList.Tables[0].Rows)
            {
                if (Int32.Parse(dataRow["UNIT_ID"].ToString()) == index)
                {
                    lsExamName2.Items.Add(dataRow["EXAM_NAME"].ToString());
                }
            }
        }
        private void SetListBoxItemLeft(int index)
        {
            ClearListBoxItem1();
            if (examList == null)
                examList = GetExamDataSet();
            foreach (DataRow dataRow in examList.Tables[0].Rows)
            {
                if (Int32.Parse(dataRow["UNIT_ID"].ToString()) == index)
                {
                    lsExamName1.Items.Add(dataRow["EXAM_NAME"].ToString());
                }
            }
        }
        private void SetFocusAndAddListMerge(int examID, DevExpress.XtraEditors.ListBoxControl lbc)
        {
            string exName = "";
            foreach (DataRow data in examList.Tables[0].Rows)
            {
                if (Int32.Parse(data["EXAM_ID"].ToString()) == examID)
                {
                    exName = data["EXAM_NAME"].ToString();
                    if (lbc.Items.Contains(exName))
                    {
                        lbc.SelectedItem = exName;
                        lsExamMerged.Items.Add(exName);
                    }
                    break;
                }  
            }          
        }
        #endregion

        #region DataGrid
        private void SetDataGrid()
        {
            ProcessGetRISAutoMergeConfig proc = new ProcessGetRISAutoMergeConfig();
            proc.Invoke();

            ClearDataGrid();

            autoMergeList = proc.Result;
            gridControl1.DataSource = autoMergeList.Tables[0];
        }
        private void ClearDataGrid()
        {
            gridControl1.DataBindings.Clear();
        }
        private void RefreshGrid()
        {
            ClearDataGrid();
            SetDataGrid();
        }
        #endregion

        #region Blinding Data
        private void BindingData(int index)
        {
            if (index >= 0)
            {
                int MrUnID = Int32.Parse(autoMergeList.Tables[0].Rows[index]["merger_unit_id"].ToString());
                int MrExID = Int32.Parse(autoMergeList.Tables[0].Rows[index]["merger_exam_id"].ToString());
                int MeUnID = Int32.Parse(autoMergeList.Tables[0].Rows[index]["mergee_unit_id"].ToString());
                int MeExID = Int32.Parse(autoMergeList.Tables[0].Rows[index]["mergee_exam_id"].ToString());

                SetListBoxItemLeft(MrUnID);
                SetListBoxItemRight(MeUnID);

                lsExamMerged.Items.Clear(); //Clear all items after add new items;

                SetFocusAndAddListMerge(MrExID, lsExamName1);
                SetFocusAndAddListMerge(MeExID, lsExamName2);

                tbConfigName.Text = autoMergeList.Tables[0].Rows[index]["CONFIG_NAME"].ToString();

                if (autoMergeList.Tables[0].Rows[index]["IS_ACTIVE"].ToString() == "Y")
                    chkActive.Checked = true;
                else
                    chkActive.Checked = false;

                if (autoMergeList.Tables[0].Rows[index]["AUTO_APPLY"].ToString() == "Y")
                    rgAutoApply.SelectedIndex = 0;
                else
                    rgAutoApply.SelectedIndex = 1;

                SetComboBoxSelectedItem(cbExamUnit1, MrUnID.ToString());
                SetComboBoxSelectedItem(cbExamUnit2, MeUnID.ToString());
            }
        }
        #endregion

        #region Get Data
        private DataSet GetExamDataSet()
        {
            ProcessGetRISExam proc = new ProcessGetRISExam();
            proc.Invoke();
            return proc.Result;
        }
        private int GetExamID(string exam_name)
        {
            foreach(DataRow row in examList.Tables[0].Rows)
            {
                if (row["EXAM_NAME"].ToString() == exam_name)
                    return Int32.Parse(row["EXAM_ID"].ToString());
            }
            return -1;
        }
        private int GetUnitID(string exam_name)
        {
            foreach (DataRow row in examList.Tables[0].Rows)
            {
                if (row["EXAM_NAME"].ToString() == exam_name)
                    return Int32.Parse(row["UNIT_ID"].ToString());
            }
            return -1;
        }
        #endregion

        #region Add Auto Merge Exam
        private void AddAutoMergeExam(string AutoApplyValue, string isActiveValue)
        {
            ProcessAddRISAutoMergeExam proc = new ProcessAddRISAutoMergeExam();
            proc.RIS_AUTOMERGECONFIG.CREATED_BY = gbl.UserID;
            proc.RIS_AUTOMERGECONFIG.ORG_ID = gbl.OrgID;

            proc.RIS_AUTOMERGECONFIG.CONFIG_NAME = tbConfigName.Text;
            proc.RIS_AUTOMERGECONFIG.AUTO_APPLY = AutoApplyValue.ToString().Trim().Length == 0 ? 'N' : AutoApplyValue.ToString().Trim()[0];
            proc.RIS_AUTOMERGECONFIG.IS_ACTIVE = isActiveValue.ToString().Trim().Length == 0 ? 'N' : isActiveValue.ToString().Trim()[0];

            proc.RIS_AUTOMERGECONFIG.merger_unit_id = GetUnitID(lsExamMerged.Items[0].ToString());
            proc.RIS_AUTOMERGECONFIG.merger_exam_id = GetExamID(lsExamMerged.Items[0].ToString());
            proc.RIS_AUTOMERGECONFIG.mergee_unit_id = GetUnitID(lsExamMerged.Items[1].ToString());
            proc.RIS_AUTOMERGECONFIG.mergee_exam_id = GetExamID(lsExamMerged.Items[1].ToString());

            proc.Invoke();
            
        }
        #endregion

        #region Update Auto Merge Exam
        private void UpdateAutoMergeExam(string autoApplyValue, string isActiveValue)
        {
            ProcessUpdateRISAutoMergeConfig proc = new ProcessUpdateRISAutoMergeConfig();
            proc.RIS_AUTOMERGECONFIG.LAST_MODIFIED_BY = gbl.UserID;

            proc.RIS_AUTOMERGECONFIG.CONFIG_NAME = tbConfigName.Text;
            proc.RIS_AUTOMERGECONFIG.AUTO_APPLY = autoApplyValue.ToString().Trim().Length == 0 ? 'N' : autoApplyValue.ToString().Trim()[0];
            proc.RIS_AUTOMERGECONFIG.IS_ACTIVE = isActiveValue.ToString().Trim().Length == 0 ? 'N' : isActiveValue.ToString().Trim()[0];

            proc.RIS_AUTOMERGECONFIG.merger_unit_id = GetUnitID(lsExamMerged.Items[0].ToString());
            proc.RIS_AUTOMERGECONFIG.merger_exam_id = GetExamID(lsExamMerged.Items[0].ToString());
            proc.RIS_AUTOMERGECONFIG.mergee_unit_id = GetUnitID(lsExamMerged.Items[1].ToString());
            proc.RIS_AUTOMERGECONFIG.mergee_exam_id = GetExamID(lsExamMerged.Items[1].ToString());

            proc.Invoke();
        }
        #endregion

        #region Delete Auto Merge Exam
        private void DeleteAutoMergeExam()
        {
            ProcessDeleteRISAutoMergeConfig proc = new ProcessDeleteRISAutoMergeConfig();
            proc.Config_Name = tbConfigName.Text;
            proc.Invoke();
        }
        #endregion

        #region Check Value Component
        private bool IsConfigNameValid(string config_name)
        {
            string invalidText = "NULL";
            if (config_name.Trim() == String.Empty
                || config_name.Trim() == invalidText.ToUpper()
                || config_name.Trim() == invalidText.ToLower())
            {
                message = new MyMessageBox();
                message.ShowAlert("UID6003", new GBLEnvVariable().CurrentLanguageID);
                message.Dispose();

                tbConfigName.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Check Limit ListBox Item
        private bool CheckLimitLisBoxItem(DevExpress.XtraEditors.ListBoxControl listbox)
        {
            if (listbox.ItemCount == limit_merge_item)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Check Item Listbox
        private bool IsDuplicationListBoxItem(string itemName)
        {
            for (int i = 0; i < lsExamMerged.Items.Count; i++)
            {
                if (lsExamMerged.Items.Contains(itemName))
                {
                    message = new MyMessageBox();
                    message.ShowAlert("UID6001", new GBLEnvVariable().CurrentLanguageID);
                    message.Dispose();
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void cbExamUnit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedIndex >= 0)
            {
                if(isActive1)
                    SetListBoxItemLeft(Int32.Parse(((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedItem.ToString()));
                SetListBoxItemLeftInitial(true);
                SetInButton();
            }
        }

        private void cbExamUnit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedIndex >= 0)
            {
                if (isActive1)
                     SetListBoxItemRight(Int32.Parse(((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedItem.ToString()));
                SetListBoxItemRightInitial(true);
                SetInButton();
            }
        }
        private void lsExamMerged_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetInButton();
            SetOutButton();  
        }
        private void btnExamIn1_Click(object sender, EventArgs e)
        {
            string item = lsExamName1.SelectedItem.ToString();
            if (lsExamName1.SelectedIndex >= 0 && !IsDuplicationListBoxItem(item) && CheckLimitLisBoxItem(lsExamMerged))
            {
                lsExamMerged.Items.Add(item);
                SetInButton();
            }
        }

        private void btnExamOut1_Click(object sender, EventArgs e)
        {
            if (lsExamMerged.SelectedIndex >= 0)
            {
                lsExamMerged.Items.RemoveAt(lsExamMerged.SelectedIndex);
                SetOutButton();
            }
        }

        private void btnExamIn2_Click(object sender, EventArgs e)
        {
            string item = lsExamName2.SelectedItem.ToString();
            if (lsExamName2.SelectedIndex >= 0 && !IsDuplicationListBoxItem(item) && CheckLimitLisBoxItem(lsExamMerged))
            {
                lsExamMerged.Items.Add(item);
                SetInButton();
            }
        }

        private void btnExamOut2_Click(object sender, EventArgs e)
        {
            if (lsExamMerged.SelectedIndex >= 0)
            {
                lsExamMerged.Items.RemoveAt(lsExamMerged.SelectedIndex);
                SetOutButton();
            }
        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            //SetButtonOpenEvent(true);
        }

        private void btnNewConfig_Click(object sender, EventArgs e)
        {
            SetTextboxInitial(true);
            SetComboBoxItemActive(true);
            SetButtonNewEvent(true);
            SetRadioandCheckBoxActive(true);

            tbConfigName.Text = String.Empty;

            isActive1 = true;
            gridControl1.Enabled = false;
            task = Task.Insert;
        }

        private void btnEditConfig_Click(object sender, EventArgs e)
        {
            SetTextboxInitial(false);
            SetComboBoxItemActive(true);
            SetButtonEditEvent(true);
            SetRadioandCheckBoxActive(true);

            isActive1 = true;
            gridControl1.Enabled = false;
            task = Task.Update;
        }

        private void btnDeleteConfig_Click(object sender, EventArgs e)
        {
            message = new MyMessageBox();
            string result = message.ShowAlert("UID6004", new GBLEnvVariable().CurrentLanguageID);
            message.Dispose();

            //Press OK button
            if (Int32.Parse(result) == 2) 
            {
                DeleteAutoMergeExam();
                RefreshGrid();
                examList = GetExamDataSet();
                if (examList.Tables[0].Rows.Count == 0)
                {
                    SetButtonMenuInitialNoData();
                    ClearListBoxItem1();
                    ClearListBoxItem2();
                    ClearListBoxMerge();
                    tbConfigName.Text = string.Empty;
                }
                else
                {
                    BindingData(autoMergeList.Tables[0].Rows.Count - 1);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string autoApply = "Y";
            string isActive = "Y";
            try
            {
                if (task == Task.Insert)
                {
                    //Check Valid Values
                    if (IsConfigNameValid(tbConfigName.Text) && !CheckLimitLisBoxItem(lsExamMerged))
                    {
                        if (rgAutoApply.SelectedIndex == 0)
                            autoApply = "Y";
                        else if (rgAutoApply.SelectedIndex == 1)
                            autoApply = "N";
                        if (chkActive.Checked == true)
                            isActive = "Y";
                        else
                            isActive = "N";

                        AddAutoMergeExam(autoApply, isActive);
                        message = new MyMessageBox();
                        message.ShowAlert("UID6000", gbl.CurrentLanguageID);
                        message.Dispose();

                        SetButtonSaveEvent(false);
                        RefreshGrid();
                        isActive1 = false;
                        gridControl1.Enabled = true;
                        SetComboBoxItemActive(false);
                    }
                    else if (CheckLimitLisBoxItem(lsExamMerged))
                    {
                        message = new MyMessageBox();
                        message.ShowAlert("UID6005", gbl.CurrentLanguageID);
                        message.Dispose();
                    }
                }
                else if (task == Task.Update)
                {
                    if (!CheckLimitLisBoxItem(lsExamMerged))
                    {
                        if (rgAutoApply.SelectedIndex == 0)
                            autoApply = "Y";
                        else if (rgAutoApply.SelectedIndex == 1)
                            autoApply = "N";
                        if (chkActive.Checked == true)
                            isActive = "Y";
                        else
                            isActive = "N";

                        UpdateAutoMergeExam(autoApply, isActive);
                        message = new MyMessageBox();
                        message.ShowAlert("UID6000", gbl.CurrentLanguageID);
                        message.Dispose();

                        SetButtonEditEvent(false);
                        RefreshGrid();
                        isActive1 = false;
                        gridControl1.Enabled = true;
                        SetComboBoxItemActive(false);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            finally
            {

            }
    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetButtonCancelEvent(false);
            SetComboBoxItemActive(false);
            ClearListBoxItem1();
            ClearListBoxItem2();
            ClearListBoxMerge();

            SetTextboxInitial(false);
            SetRadioandCheckBoxActive(false);
            SetInButton();
            SetOutButton();

            BindingData(currentRow);

            btnExamIn1.Enabled = false;
            btnExamIn2.Enabled = false;

            isActive1 = false;
            gridControl1.Enabled = true;

            task = Task.None;
        }

        private void bandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                currentRow = e.FocusedRowHandle;
                BindingData(currentRow);
                SetInButton();
                SetOutButton();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindingData(currentRow);
            SetInButton();
            SetOutButton();
        }
    }
}
