using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Forms.GBLMessage;
using RIS.BusinessLogic;
using RIS.Operational;
using RIS.Common;
using RIS.Common.Common;
using RIS.Common.UtilityClass;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace RIS.Forms.Admin
{
    
    public partial class RIS_SF08 : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DBUtility dbu;
        private string Mode;
        private DataSet ds;
        private DataSet dsExam;
        private DataTable dttExam;
        private MyMessageBox msg = new MyMessageBox();
        private BindingSource bs;
        private DataTable dtClinic;
        private DataTable dttClinic;

        public RIS_SF08(UUL.ControlFrame.Controls.TabControl Tab)
        {
            InitializeComponent();
            
            CloseControl = Tab;
            SetEnableDisableControl(false);
            Mode = "New";
            dsExam = null;
            dbu = new DBUtility();
            ExamTable();
            LoadData(0);
            SetGridExam();
            LoadTree();
            SetNavigator();
            bs.MoveLast();
            bs.MoveFirst();

            LoadData_TabClinic();
            GridSetting_TabClinic();
            nTabControl1.SelectedIndex = 0;
            //HIS_Patient hi = new HIS_Patient();
            //DataSet ds = hi.Get_appointment_detail("4009221");

            //DataTable tb = new DataTable();
            //tb.Rows.Add(new object[]);
        }

        #region Tab Setup 
        private void btnModalityType_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lv_ValueUpdated);

            string qry = @"
                            select 
                            MODALITY_ID
                            ,MODALITY_UID
                            ,MODALITY_NAME
                            ,TYPE_ID
                            ,TYPE_UID
                            ,TYPE_NAME
                            ,START_TIME
                            ,END_TIME
                            ,AVG_INV_TIME
                            ,IS_ACTIVE
                            from 

                            RIS_MODALITY m
                            ,RIS_MODALITYTYPE t

                            where
                            ISNULL(IS_UPDATED,'N')<>'Y'
                            and ISNULL(IS_DELETED,'N')<>'Y'
                            and m.MODALITY_TYPE=t.TYPE_ID";

            string fields = "ID,Code,Name,Type ID,Type Code,Type Name,Start,End,Average,Active";
            string con = "";
            lv.getData(qry, fields, con, "Modality Search");
            lv.Show();
        }
        private void lv_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtModilyCode.Tag = retValue[0];
            txtModilyCode.Text = retValue[1];
            txtModalityName.Text = retValue[2];
            txtModalityType.Tag = retValue[3];
            txtModalityType.Text = retValue[4];
            txtModalityTypeName.Text = retValue[5];
            txtDisplayModalityCode.Text = txtModilyCode.Text;
            txtDisplayModalityName.Text = txtModalityName.Text;
            txtStartTime.Text = retValue[6];
            txtEndTime.Text = retValue[7];
            txtAverageTime.Text = retValue[8];
            if (retValue[9] == "Y")
                chkActive.Checked = true;
            else
                chkActive.Checked = false;
            btnUnitCode.Focus();
        }

        private void btnUnitCode_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated+=new RIS.Forms.Lookup.ValueUpdatedEventHandler(Unit_ValueUpdate);
            string qry = @"
                           select 
                                UNIT_ID
                                ,UNIT_UID
                                ,UNIT_NAME
                           from
                                HR_UNIT";

            string fields = "ID,Code,Name";
            string con = "";
            lv.getData(qry, fields, con, "Unit Search");
            lv.Show();
        }
        private void Unit_ValueUpdate(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtUnitCode.Tag = retValue[0];
            txtUnitCode.Text = retValue[1];
            txtUnitName.Text = retValue[2];
            btnRoom.Focus();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Room_ValueUpdated);
            string qry = @"
                        select 
                            ROOM_ID
                            ,ROOM_UID
                        from
                            HR_ROOM
                        where
                            IS_ACTIVE='Y'";

            string fields = "ID,Name";
            string con = "";
            lv.getData(qry, fields, con, "Unit Search");
            lv.Show();
        }
        private void Room_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtRoomCode.Tag = retValue[0];
            txtRoomCode.Text = retValue[0];
            txtRoomName.Text = retValue[1];
        }
        #endregion

        #region Navigator Button 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearText();
            SetEnableDisableControl(true);
            Mode = "New";
            LoadData(0);
            SetGridExam();
            grdData.EmbeddedNavigator.Buttons.Remove.Visible = true;
            nTabPage1.Focus();
            btnModalityType.Focus();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtModilyCode.Tag != null)
            {
                SetEnableDisableControl(true);
                Mode = "Edit";
                int modilityid = (int)txtModilyCode.Tag;
                LoadData(modilityid);
                SetGridExam();
                grdData.EmbeddedNavigator.Buttons.Remove.Visible = false;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtModilyCode.Tag != null) 
            {

                if (msg.ShowAlert("UID2003",1) == "1") 
                    return;

                DataTable dtt = (DataTable)bs.DataSource;
                ProcessUpdateRISModality processUpdate = new ProcessUpdateRISModality();
                processUpdate.RISModality.MODALITY_ID = txtModilyCode.Tag == null ? 0 : Convert.ToInt32(txtModilyCode.Tag);
                processUpdate.RISModality.MODALITY_UID = txtModilyCode.Text;
                processUpdate.RISModality.MODALITY_NAME = txtModalityName.Text;
                processUpdate.RISModality.MODALITY_TYPE = txtModalityType.Tag == null ? "0" : txtModalityType.Tag.ToString();
                processUpdate.RISModality.ORG_ID = new GBLEnvVariable().OrgID;
                processUpdate.RISModality.ROOM_ID = txtRoomCode.Tag == null ? 0 : Convert.ToInt32(txtRoomCode.Tag);
                processUpdate.RISModality.UNIT_ID = txtUnitCode.Tag == null ? 0 : Convert.ToInt32(txtUnitCode.Tag);
                processUpdate.RISModality.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                processUpdate.RISModality.IS_ACTIVE = chkActive.Checked ? "Y" : "N";
                processUpdate.RISModality.IS_UPDATED = dtt.Rows[bs.Position]["IS_UPDATED"].ToString();
                processUpdate.RISModality.IS_DELETED = "Y";
                processUpdate.Invoke();

                Delete_TabClinic();

                ClearText();
                SetEnableDisableControl(false);
                Mode = "New";
                dsExam = null;
                dbu = new DBUtility();
                ExamTable();
                LoadTree();
                SetNavigator();
                if (bs.Count > 0)
                {
                    bs.MoveLast();
                    bs.MoveFirst();
                }
                nTabControl1.SelectedIndex = 0;

                treeView1.CollapseAll();
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == "New")
            {
                #region Requre Check
                if (txtModilyCode.Tag == null)
                {
                    nTabControl1.SelectedIndex = 0;
                    btnModalityType.Focus();
                    return;
                }
                if (txtUnitCode.Tag == null)
                {
                    nTabControl1.SelectedIndex = 0;
                    btnUnitCode.Focus();
                    return;
                }
                if (txtRoomCode.Tag == null)
                {
                    nTabControl1.SelectedIndex = 0;
                    btnUnitCode.Focus();
                    return;
                }
                if (dsExam.Tables[0].Rows.Count == 0)
                {
                    nTabControl1.SelectedIndex = 1;
                    grdData.Focus();
                    return;
                }
                if (checkInputGrid())
                {
                    nTabControl1.SelectedIndex = 1;
                    grdData.Focus();
                    return;
                }
                if (checkInputGrid_TabClinic())
                {
                    nTabControl1.SelectedIndex = 2;
                    gridControl1.Focus();
                    return;
                }
                #endregion

                InsertData();
            }
            else
            {
                #region Requre Check

                #endregion

                UpdateData();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Mode == "New")
            {
                ClearText();
                Mode = "New";
                dsExam = null;
                dbu = new DBUtility();
                ExamTable();
            }
            else
                Mode = "Edit";
            SetEnableDisableControl(false);
            SetNavigator();
            if (bs.Count > 0)
            {
                bs.MoveLast();
                bs.MoveFirst();
            }
            nTabControl1.SelectedIndex = 0;
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        } 
        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }
        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }
        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void SetNavigator() {

            ProcessGetRISModality processGet = new ProcessGetRISModality(true);
            processGet.Invoke();
            ds = processGet.Result.Copy();
            bs = new BindingSource();
            bs.DataSource = ds.Tables[0].Copy();

            txtModilyCode.DataBindings.Clear();
            txtModalityName.DataBindings.Clear();
            txtModalityType.DataBindings.Clear();
            txtModalityTypeName.DataBindings.Clear();
            txtUnitCode.DataBindings.Clear();
            txtUnitName.DataBindings.Clear();
            txtRoomCode.DataBindings.Clear();
            txtRoomName.DataBindings.Clear();
            txtStartTime.DataBindings.Clear();
            txtEndTime.DataBindings.Clear();
            txtAverageTime.DataBindings.Clear();
            txtDisplayModalityCode.DataBindings.Clear();
            txtDisplayModalityName.DataBindings.Clear();
            dedStart.DataBindings.Clear();
            dedEnd.DataBindings.Clear();
            speAvgTime.DataBindings.Clear();

            txtModilyCode.DataBindings.Add("Tag", bs, "MODALITY_ID");
            txtModalityType.DataBindings.Add("Tag", bs, "MODALITY_TYPE");
            txtUnitCode.DataBindings.Add("Tag", bs, "UNIT_ID");
            txtRoomCode.DataBindings.Add("Tag", bs, "ROOM_ID");

            txtModilyCode.DataBindings.Add("Text", bs, "MODALITY_UID");
            txtModalityName.DataBindings.Add("Text", bs, "MODALITY_NAME");
            txtModalityType.DataBindings.Add("Text", bs, "TYPE_UID");
            txtModalityTypeName.DataBindings.Add("Text", bs, "TYPE_NAME");
            txtUnitCode.DataBindings.Add("Text", bs, "UNIT_UID");
            txtUnitName.DataBindings.Add("Text", bs, "UNIT_NAME");
            txtRoomCode.DataBindings.Add("Text", bs, "ROOM_ID");
            txtRoomName.DataBindings.Add("Text", bs, "ROOM_UID");
            txtStartTime.DataBindings.Add("Text", bs, "START_TIME");
            txtEndTime.DataBindings.Add("Text", bs, "END_TIME");
            txtAverageTime.DataBindings.Add("Text", bs, "AVG_INV_TIME");
            txtDisplayModalityCode.DataBindings.Add("Text", bs, "MODALITY_UID");
            txtDisplayModalityName.DataBindings.Add("Text", bs, "MODALITY_NAME");
            dedStart.DataBindings.Add("DateTime", bs, "START_TIME");
            dedEnd.DataBindings.Add("DateTime",bs,"END_TIME");
            speAvgTime.DataBindings.Add("Value", bs, "AVG_INV_TIME");
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            bindingNavigator1.BindingSource = bs;
        }
        private void bs_PositionChanged(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables[0].Rows[bs.Position];
            string strchk = dr["IS_ACTIVE"].ToString();
            chkActive.Checked = strchk == "Y" ? true : false;
            int modality = (int)dr["MODALITY_ID"];
            LoadData(modality);
            grdData.DataSource = null;
            SetGridExam();
            bs_PositionChanged_TabClinic(modality);
        }
        #endregion
        
        #region Language 
        private void ChangeFormLanguage()
        {


            FormLanguage fl = new FormLanguage();
            //fl.FormID = 6;
            fl.LanguageID = new GBLEnvVariable().CurrentLanguageID;
            fl.ProcedureType = 1;

            ProcessGetLanguage langs = new ProcessGetLanguage();
            langs.FormLanguage = fl;
            try
            {
                langs.Invoke();
            }
            catch
            {
            }

            try
            {

                DataTable dt = langs.ResultSet.Tables[0];
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkActive").ToUpper().Trim())
                    //    chkActive.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkView").ToUpper().Trim())
                    //    chkView.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkModify").ToUpper().Trim())
                    //    chkModify.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkRemove").ToUpper().Trim())
                    //    chkRemove.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkAddToHome").ToUpper().Trim())
                    //    chkAddToHome.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkCreate").ToUpper().Trim())
                    //    chkCreate.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    //
                    /*
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnAdd").ToUpper().Trim())
                        btnAdd.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnEdit").ToUpper().Trim())
                        btnEdit.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    */

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnDelete").ToUpper().Trim())
                        btnDelete.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnRefresh").ToUpper().Trim())
                    //    btnRefresh.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnClose").ToUpper().Trim())
                        btnClose.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblMenuUID").ToUpper().Trim())
                    //    lblMenuUID.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblMenuName").ToUpper().Trim())
                    //    lblMenuName.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubUID").ToUpper().Trim())
                    //    lblSubUID.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubName").ToUpper().Trim())
                    //    lblSubName.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubClass").ToUpper().Trim())
                    //    lblSubClass.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubSys").ToUpper().Trim())
                    //    lblSubSys.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblParent").ToUpper().Trim())
                    //    lblParent.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSerial").ToUpper().Trim())
                    //    lblSerial.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblDesc").ToUpper().Trim())
                    //    lblDesc.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblObjects").ToUpper().Trim())
                    //    nGrouper1.HeaderItem.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    k++;
                }



            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }
        private void LoadFormLanguage()
        {

            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;
            fl.LanguageID = 1;
            fl.ProcedureType = 2;

            ProcessGetLanguage langs = new ProcessGetLanguage();
            langs.FormLanguage = fl;
            try
            {
                langs.Invoke();
            }
            catch
            {
            }

            try
            {

                DataTable dt = langs.ResultSet.Tables[0];

                int k = 0;
                while (k < dt.Rows.Count)
                {
                    //cmbLanguage.Items.Add(dt.Rows[k]["LANG_NAME"].ToString());
                    string lid = dt.Rows[k]["LANG_ID"].ToString();
                    k++;
                }

                //cmbLanguage.Text = new GBLEnvVariable().LangName;

            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }
        #endregion

        #region TreeView 
        private void LoadTree() {
            treeView1.Nodes.Clear();
            treeView1.ImageList = imageList1;
            ProcessGetRISModality processModality = new ProcessGetRISModality(true);
            ProcessGetRISModalityexam processExam = new ProcessGetRISModalityexam(true);
            processModality.Invoke();
            processExam.Invoke();
            DataTable dtModality = processModality.Result.Tables[0];
            DataTable dtExam = processExam.Result.Tables[0];
            for (int i=0;i<dtModality.Rows.Count;i++) {
                DataRow dr = dtModality.Rows[i];
                treeView1.Nodes.Add(dr["MODALITY_NAME"].ToString() + "(" + dr["ROOM_UID"].ToString() + ")");
                treeView1.Nodes[i].Tag = dr["MODALITY_ID"].ToString().Trim();
                foreach (DataRow drExam in dtExam.Rows) {
                    if (dr["MODALITY_ID"].ToString().Trim() == drExam["MODALITY_ID"].ToString().Trim())
                    {
                        string examName = string.Empty;
                        foreach (DataRow drr in dttExam.Rows) {
                            if (drExam["EXAM_ID"].ToString().Trim() == drr["EXAM_ID"].ToString().Trim())
                            {
                                examName = drr["EXAM_NAME"].ToString().Trim();
                                break;
                            }
                        }

                        //TreeNode newNodes = new TreeNode(drExam["EXAM_ID"].ToString().Trim());
                        TreeNode newNodes = new TreeNode(examName);
                        newNodes.Tag = drExam["MODALITY_EXAM_ID"];
                        treeView1.Nodes[i].Nodes.Add(newNodes);
                    }
                }
            }
            treeView1.ExpandAll();
        }
        private void LoadTree(string modalityName)
        {
            treeView1.Nodes.Clear();
            treeView1.ImageList = imageList1;
            ProcessGetRISModality processModality = new ProcessGetRISModality(true);
            ProcessGetRISModalityexam processExam = new ProcessGetRISModalityexam(true);
            processModality.Invoke();
            processExam.Invoke();
            DataTable dtModality = processModality.Result.Tables[0];
            DataTable dtExam = processExam.Result.Tables[0];
            for (int i = 0; i < dtModality.Rows.Count; i++)
            {
                DataRow dr = dtModality.Rows[i];
                if (dr["MODALITY_NAME"].ToString().Trim().ToUpper() == modalityName.ToUpper())
                {
                    treeView1.Nodes.Add(dr["MODALITY_NAME"].ToString() + "(" + dr["ROOM_UID"].ToString() + ")");
                    treeView1.Nodes[treeView1.Nodes.Count-1].Tag = dr["MODALITY_ID"].ToString().Trim();
                    foreach (DataRow drExam in dtExam.Rows)
                    {
                        if (dr["MODALITY_ID"].ToString().Trim() == drExam["MODALITY_ID"].ToString().Trim())
                        {
                            string examName = string.Empty;
                            foreach (DataRow drr in dttExam.Rows)
                            {
                                if (drExam["EXAM_ID"].ToString().Trim() == drr["EXAM_ID"].ToString().Trim())
                                {
                                    examName = drr["EXAM_NAME"].ToString().Trim();
                                    break;
                                }
                            }

                            //TreeNode newNodes = new TreeNode(drExam["EXAM_ID"].ToString().Trim());
                            TreeNode newNodes = new TreeNode(examName);
                            newNodes.Tag = drExam["MODALITY_EXAM_ID"];
                            treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Add(newNodes);
                        }
                    }
                }
            }
            treeView1.ExpandAll();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.ToString()!="")//e.Node.LastNode != null)
            {
                string s = e.Node.Tag.ToString();
                DataTable dtt = (DataTable)bs.DataSource;
                for (int i = 0; i < dtt.Rows.Count; i++) {
                    if (dtt.Rows[i]["MODALITY_ID"].ToString().Trim() == s) {
                        SetEnableDisableControl(false);
                        bs.Position = i;
                        treeView1_AfterSelect_TabClinic(s);
                        break;
                    }
                }
            }
        }
        #endregion
        

        private void SetEnableDisableControl(bool flag)
        {
            nGroupSetup.Enabled = flag;
            nGroupMapping.Enabled = flag;

            grdData.EmbeddedNavigator.Buttons.Append.Visible = true;
            grdData.EmbeddedNavigator.Buttons.Remove.Visible = false;
            grdData.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            grdData.EmbeddedNavigator.Buttons.Edit.Visible = false;
            grdData.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            btnAdd.Visible = !flag;
            btnEdit.Visible = !flag;
            btnDelete.Visible = !flag;
            btnSave.Visible = flag;
            btnCancel.Visible = flag;
            btnSave.Enabled = flag;
            btnCancel.Enabled = flag;

            groupClinic.Enabled = flag;
        }
        private void ClearText() {
            txtModilyCode.Tag = null;
            txtModilyCode.Text = txtModalityName.Text = string.Empty;
            txtModalityType.Text = txtModalityTypeName.Text = string.Empty;
            txtUnitCode.Tag = null;
            txtUnitCode.Text = txtUnitName.Text = string.Empty;
            txtRoomCode.Tag = null;
            txtRoomCode.Text = txtRoomName.Text = string.Empty;
            txtStartTime.Text = txtEndTime.Text = txtAverageTime.Text = string.Empty;
            txtDisplayModalityCode.Text = txtDisplayModalityName.Text = string.Empty;
            txtSearch.Text = "Search";
            chkActive.Checked = true;
            dedStart.Text = dedEnd.Text = string.Empty;
            speAvgTime.Text = "0";
        }
        private void SetGridExam() {
            grdData.DataSource = dsExam.Tables[0];
            int i = 0;
            for (; i < advData.Columns.Count; i++)
                advData.Columns[i].Visible = false;

            #region Set Master 
            if (Mode == "Edit")
            {
                advData.Columns["DELETE"].Visible = true;
                advData.Columns["DELETE"].ColVIndex = 0;
                advData.Columns["DELETE"].Caption = "Delete";
                advData.Columns["DELETE"].BestFit();
            }
            advData.Columns["EXAM_ID"].Visible = true;
            advData.Columns["EXAM_ID"].ColVIndex = 1;
            advData.Columns["EXAM_ID"].Caption = "Exam Code";
            advData.Columns["EXAM_ID"].Width = 80;

            advData.Columns["EXAM_NAME"].Visible = true;
            advData.Columns["EXAM_NAME"].ColVIndex = 2;
            advData.Columns["EXAM_NAME"].Caption = "Exam Name";
            advData.Columns["EXAM_NAME"].Width = 120;
            advData.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;

            advData.Columns["IS_ACTIVE"].Visible = true;
            advData.Columns["IS_ACTIVE"].ColVIndex = 3;
            advData.Columns["IS_ACTIVE"].Caption = "Active";
            advData.Columns["IS_ACTIVE"].BestFit();

            advData.Columns["IS_DEFAULT_MODALITY"].Visible = true;
            advData.Columns["IS_DEFAULT_MODALITY"].ColVIndex = 4;
            advData.Columns["IS_DEFAULT_MODALITY"].Caption = "Default";
            advData.Columns["IS_DEFAULT_MODALITY"].BestFit();

            advData.Columns["IS_UPDATED"].Visible = true;
            advData.Columns["IS_UPDATED"].ColVIndex = 5;
            advData.Columns["IS_UPDATED"].Caption = "Update";
            advData.Columns["IS_UPDATED"].BestFit();

            advData.Columns["IS_DELETED"].Visible = true;
            advData.Columns["IS_DELETED"].ColVIndex = 6;
            advData.Columns["IS_DELETED"].Caption = "Delete";
            advData.Columns["IS_DELETED"].BestFit();
            #endregion

            #region Set Details 
            RepositoryItemCheckEdit chkDeleteRec = new RepositoryItemCheckEdit();
            chkDeleteRec.ValueChecked = "Y";
            chkDeleteRec.ValueUnchecked = "N";
            chkDeleteRec.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkDeleteRec.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkDeleteRec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chkDeleteRec.Click += new EventHandler(chkDeleteRec_Click);
            advData.Columns["DELETE"].ColumnEdit = chkDeleteRec;

            RepositoryItemCheckEdit chkActive = new RepositoryItemCheckEdit();
            chkActive.ValueChecked = "Y";
            chkActive.ValueUnchecked = "N";
            chkActive.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkActive.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkActive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chkActive.Click += new EventHandler(chkActive_Click);
            advData.Columns["IS_ACTIVE"].ColumnEdit = chkActive;

            RepositoryItemCheckEdit chkDefault = new RepositoryItemCheckEdit();
            chkDefault.ValueChecked = "Y";
            chkDefault.ValueUnchecked = "N";
            chkDefault.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkDefault.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkDefault.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chkDefault.Click += new EventHandler(chkDefault_Click);
            advData.Columns["IS_DEFAULT_MODALITY"].ColumnEdit = chkDefault;

            RepositoryItemCheckEdit chkUpdate = new RepositoryItemCheckEdit();
            chkUpdate.ValueChecked = "Y";
            chkUpdate.ValueUnchecked = "N";
            chkUpdate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkUpdate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chkUpdate.Click += new EventHandler(chkUpdate_Click);
            advData.Columns["IS_UPDATED"].ColumnEdit = chkUpdate;

            RepositoryItemCheckEdit chkDelete = new RepositoryItemCheckEdit();
            chkDelete.ValueChecked = "Y";
            chkDelete.ValueUnchecked = "N";
            chkDelete.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkDelete.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkDelete.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //chkDelete.Click += new EventHandler(chkDelete_Click);
            advData.Columns["IS_DELETED"].ColumnEdit = chkActive;


            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID") });
            repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
            repositoryItemLookUpEdit1.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.ShowFooter = false;
            repositoryItemLookUpEdit1.ShowHeader = false;
            repositoryItemLookUpEdit1.NullText = "Exam Code";
            repositoryItemLookUpEdit1.EditValueChanged += new EventHandler(ExamCode_EditValueChanged);
            repositoryItemLookUpEdit1.DataSource = dttExam;
            advData.Columns["EXAM_ID"].ColumnEdit = repositoryItemLookUpEdit1;

            #endregion
        }
        private void LoadData(int modalityID)
        {
            if (modalityID==0)
            {
                dsExam = new DataSet();
                DataTable dtt = new DataTable();
                dtt.Columns.Add("MODALITY_EXAM_ID", typeof(int));
                dtt.Columns.Add("MODALITY_ID", typeof(int));
                dtt.Columns.Add("EXAM_ID", typeof(int));
                dtt.Columns.Add("IS_ACTIVE", typeof(string));
                dtt.Columns.Add("IS_DEFAULT_MODALITY", typeof(string));
                dtt.Columns.Add("IS_UPDATED", typeof(string));
                dtt.Columns.Add("IS_DELETED", typeof(string));
                
                dtt.Columns.Add("ID", typeof(int));
                dtt.Columns.Add("DELETE", typeof(string));
                dtt.Columns.Add("EXAM_NAME", typeof(string));
                dsExam.Tables.Add(dtt);
            }
            else {
                ProcessGetRISModalityexam process = new ProcessGetRISModalityexam(modalityID);
                process.Invoke();
                dsExam = process.Result.Copy();
                dsExam.Tables[0].Columns.Add("DELETE", typeof(string));
               
            }
        }
        private DataTable ExamTable() {
            if (dttExam == null)
            {
                dttExam = new DataTable();
                ProcessGetRISExam process = new ProcessGetRISExam();
                process.Invoke();
                dttExam = process.Result.Tables[0].Copy();
            }
            return dttExam;
        }
        private bool checkInputGrid()
        {
             bool flag = false;
             foreach (DataRow dr in dsExam.Tables[0].Rows)
                 if (dr.RowState != DataRowState.Deleted)
                 {
                     if (dr["EXAM_ID"].ToString().Trim() == string.Empty)
                     {
                         flag = true;
                         break;
                     }
                 }
             return flag;
        }
        private void InsertData() {
            DateTime dateStart; //Modify at 2008 08 26
            DateTime dateEnd; // 
            ProcessAddRISModality process = new ProcessAddRISModality();
            //processAdd.RISModality.MODALITY_ID = txtModilyCode.Tag == null ? 0 : Convert.ToInt32(txtModilyCode.Tag);
            process.RISModality.MODALITY_UID = txtModilyCode.Text;
            process.RISModality.MODALITY_NAME = txtModalityName.Text;
            process.RISModality.MODALITY_TYPE = txtModalityType.Tag == null ? "0" : txtModalityType.Tag.ToString();
            process.RISModality.UNIT_ID = txtUnitCode.Tag == null ? 0 : Convert.ToInt32(txtUnitCode.Tag);
            process.RISModality.ROOM_ID = txtRoomCode.Tag == null ? 0 : Convert.ToInt32(txtRoomCode.Tag);
            if (DateTime.TryParse(dedStart.Text, out dateStart))process.RISModality.START_TIME = dateStart;
            else process.RISModality.START_TIME = null;
            if (DateTime.TryParse(dedEnd.Text, out dateEnd))process.RISModality.END_TIME = dateEnd;
            else process.RISModality.END_TIME = null;
            process.RISModality.AVG_INV_TIME = byte.Parse(speAvgTime.Value.ToString());
            process.RISModality.IS_ACTIVE = chkActive.Checked ? "Y" : "N";
            process.RISModality.ORG_ID = new GBLEnvVariable().OrgID;
            process.RISModality.CREATED_BY = new GBLEnvVariable().UserID;
            process.Invoke();

            //Modify at 2008 08 26
            int numID = (int)process.DataResult.Tables[0].Rows[0]["MODALITY_ID"];
            ProcessAddRISModalityexam processAdd = new ProcessAddRISModalityexam();
            processAdd.RISModalityexam.CREATED_BY= new GBLEnvVariable().UserID;
            processAdd.RISModalityexam.MODALITY_ID = numID;
            foreach (DataRow dr in dsExam.Tables[0].Rows) {
                if (dr.RowState != DataRowState.Deleted) {
                    processAdd.RISModalityexam.ORG_ID = new GBLEnvVariable().OrgID;
                    processAdd.RISModalityexam.EXAM_ID = (int)dr["EXAM_ID"];
                    processAdd.RISModalityexam.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim() == string.Empty ? "N" : "Y";
                    processAdd.RISModalityexam.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim() == string.Empty ? "N" : "Y";
                    processAdd.RISModalityexam.IS_DELETED = dr["IS_DELETED"].ToString().Trim() == string.Empty ? "N" : "Y";
                    processAdd.RISModalityexam.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim() == string.Empty ? "N" : "Y";
                    processAdd.Invoke();
                    
                }
            }

            InsertData_TabClinic(numID);

            msg.ShowAlert("UID005", new GBLEnvVariable().CurrentLanguageID);
            ClearText();
            SetEnableDisableControl(false);
            Mode = "New";
            dsExam = null;
            dbu = new DBUtility();
            ExamTable();
            LoadTree();
            SetNavigator();
            if (bs.Count > 0)
            {
                bs.MoveLast();
                bs.MoveFirst();
            }
            nTabControl1.SelectedIndex = 0;
            treeView1.CollapseAll();
        }
        private void UpdateData() 
        {
            DataTable dtt = (DataTable)bs.DataSource;
            ProcessUpdateRISModality processUpdate = new ProcessUpdateRISModality();
            processUpdate.RISModality.MODALITY_ID = txtModilyCode.Tag == null ? 0 : Convert.ToInt32(txtModilyCode.Tag);
            processUpdate.RISModality.MODALITY_UID = txtModilyCode.Text;
            processUpdate.RISModality.MODALITY_NAME = txtModalityName.Text;
            processUpdate.RISModality.MODALITY_TYPE = txtModalityType.Tag == null ? "0" : txtModalityType.Tag.ToString();
            processUpdate.RISModality.ORG_ID = new GBLEnvVariable().OrgID;
            processUpdate.RISModality.ROOM_ID = txtRoomCode.Tag == null ? 0 : Convert.ToInt32(txtRoomCode.Tag);
            processUpdate.RISModality.UNIT_ID = txtUnitCode.Tag == null ? 0 : Convert.ToInt32(txtUnitCode.Tag);
            processUpdate.RISModality.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
            processUpdate.RISModality.IS_ACTIVE = chkActive.Checked ? "Y" : "N";
            processUpdate.RISModality.IS_UPDATED = "N";
            processUpdate.RISModality.IS_DELETED = dtt.Rows[bs.Position]["IS_DELETED"].ToString() == "" ? null : dtt.Rows[bs.Position]["IS_DELETED"].ToString();
            processUpdate.Invoke();
            foreach (DataRow dr in dsExam.Tables[0].Rows)
            {
                if (dr["DELETE"].ToString() == "Y")
                {
                    if (dr["MODALITY_EXAM_ID"].ToString().Trim() != string.Empty)
                    {
                        //delete
                        ProcessDeleteRISModalityexam processDelete = new ProcessDeleteRISModalityexam();
                        processDelete.RISModalityexam.MODALITY_EXAM_ID = Convert.ToInt32(dr["MODALITY_EXAM_ID"]);
                        processDelete.Invoke();
                    }
                }
                else if (dr["MODALITY_EXAM_ID"].ToString().Trim().Length == 0)
                {
                    //insert
                    ProcessAddRISModalityexam processAdd = new ProcessAddRISModalityexam();
                    processAdd.RISModalityexam.CREATED_BY = new GBLEnvVariable().UserID;
                    processAdd.RISModalityexam.MODALITY_ID = processUpdate.RISModality.MODALITY_ID;
                    processAdd.RISModalityexam.ORG_ID = new GBLEnvVariable().OrgID;
                    processAdd.RISModalityexam.EXAM_ID = (int)dr["EXAM_ID"];
                    processAdd.RISModalityexam.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim() == string.Empty || dr["IS_ACTIVE"].ToString().Trim() == "N" ? "N" : "Y";
                    processAdd.RISModalityexam.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim() == string.Empty || dr["IS_DEFAULT_MODALITY"].ToString().Trim() == "N" ? "N" : "Y";
                    processAdd.RISModalityexam.IS_DELETED = dr["IS_DELETED"].ToString().Trim() == string.Empty || dr["IS_DELETED"].ToString().Trim() == "N" ? "N" : "Y";
                    processAdd.RISModalityexam.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim() == string.Empty || dr["IS_UPDATED"].ToString().Trim() == "N" ? "N" : "Y";
                    processAdd.Invoke();
                }
                else
                {
                    //update
                    ProcessUpdateRISModalityexam processUpdateDetails = new ProcessUpdateRISModalityexam();
                    processUpdateDetails.RISModalityexam.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    processUpdateDetails.RISModalityexam.EXAM_ID = (int)dr["EXAM_ID"];
                    processUpdateDetails.RISModalityexam.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim() == string.Empty || dr["IS_ACTIVE"].ToString().Trim() == "N" ? "N" : "Y";
                    processUpdateDetails.RISModalityexam.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim() == string.Empty || dr["IS_DEFAULT_MODALITY"].ToString().Trim() == "N" ? "N" : "Y";
                    processUpdateDetails.RISModalityexam.IS_DELETED = dr["IS_DELETED"].ToString().Trim() == string.Empty || dr["IS_DELETED"].ToString().Trim() == "N" ? "N" : "Y";
                    processUpdateDetails.RISModalityexam.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim() == string.Empty || dr["IS_UPDATED"].ToString().Trim() == "N" ? "N" : "Y";
                    processUpdateDetails.RISModalityexam.MODALITY_EXAM_ID = (int)dr["MODALITY_EXAM_ID"];
                    processUpdateDetails.RISModalityexam.MODALITY_ID = (int)dr["MODALITY_ID"];
                    processUpdateDetails.RISModalityexam.ORG_ID = new GBLEnvVariable().OrgID;
                    processUpdateDetails.RISModalityexam.QA_BYPASS = dr["QA_BYPASS"].ToString();
                    processUpdateDetails.RISModalityexam.TECH_BYPASS = dr["TECH_BYPASS"].ToString();
                    //processUpdateDetails.RISModalityexam.CREATED_BY =(int) dr["CREATED_BY"];
                    processUpdateDetails.Invoke();
                }
            }
                
            UpdateData_TabClinic(processUpdate.RISModality.MODALITY_ID);

            msg.ShowAlert("UID005", new GBLEnvVariable().CurrentLanguageID);
            ClearText();
            SetEnableDisableControl(false);
            Mode = "New";
            dsExam = null;
            dbu = new DBUtility();
            ExamTable();
            LoadTree();
            SetNavigator();
            if (bs.Count > 0)
            {
                bs.MoveLast();
                bs.MoveFirst();
            }
            nTabControl1.SelectedIndex = 0;
            treeView1.CollapseAll();
        }

        private void ExamCode_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit lookup = (DevExpress.XtraEditors.LookUpEdit)sender;
            int rowINdex = advData.FocusedRowHandle;
            DataRow dr = advData.GetDataRow(advData.FocusedRowHandle);
            int i = 0;
            for (; i < dttExam.Rows.Count; i++)
            {
                if (lookup.Text.Trim() == dttExam.Rows[i]["EXAM_UID"].ToString().Trim())
                    break;
            }
            dr["EXAM_ID"] = Convert.ToInt32(dttExam.Rows[i]["EXAM_ID"]);
            dr["EXAM_NAME"] = dttExam.Rows[i]["EXAM_NAME"].ToString();
            
            advData.RefreshData();
          
        }
        private void grdData_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (txtModilyCode.Tag == null) {
                e.Handled = true;
                nTabControl1.SelectedIndex = 0;
                btnModalityType.Focus();
                return;

            }
            if (txtUnitCode.Tag == null) {
                e.Handled = true;
                nTabControl1.SelectedIndex = 0;
                btnUnitCode.Focus();
                return;
            }
            if (txtRoomCode.Tag == null) {
                e.Handled = true;
                nTabControl1.SelectedIndex = 0;
                btnRoom.Focus();
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Text = string.Empty;
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13) {
                if (txtSearch.Text.Trim().Length == 0) {
                    LoadTree();
                    txtSearch.Text = "Search";
                }
                else
                    LoadTree(txtSearch.Text);
            }
        }

        private void RIS_SF08_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.White;
        }
        private void RIS_SF08_Load(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        #region Tab Clinic Type

        private void LoadData_TabClinic()
        {
            ProcessGetRISModalityclinictype getProcess = new ProcessGetRISModalityclinictype();
            getProcess.Invoke(0);
            dtClinic = getProcess.Result.Tables[0].Copy();
            gridControl1.DataSource = dtClinic;

            ProcessGetRISModalityclinictype proget = new ProcessGetRISModalityclinictype();
            proget.Invoke(1);
            dttClinic = proget.Result.Tables[0].Copy();
        }
        private void GridSetting_TabClinic()
        {
            foreach (BandedGridColumn col in gridView1.Columns)
                col.Visible = false;

            #region Master Settings

            gridView1.Columns["Delete"].Visible = true;
            gridView1.Columns["Clinic Code"].Visible = true;
            gridView1.Columns["Clinic Name"].Visible = true;
            gridView1.Columns["Start Datetime"].Visible = true;
            gridView1.Columns["End Datetime"].Visible = true;
            gridView1.Columns["Max App"].Visible = true;

            //gridView1.Columns["Clinic Code"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Clinic Name"].OptionsColumn.AllowEdit = false;
            //gridView1.Columns["Start Datetime"].OptionsColumn.AllowEdit = false;
            //gridView1.Columns["End Datetime"].OptionsColumn.AllowEdit = false;
            //gridView1.Columns["Max App"].OptionsColumn.AllowEdit = false;

            #endregion Master Settings

            #region Detail Settings

            RepositoryItemCheckEdit repositoryItemCheckEdit = new RepositoryItemCheckEdit();
            repositoryItemCheckEdit.ValueChecked = "Y";
            repositoryItemCheckEdit.ValueUnchecked = "N";
            repositoryItemCheckEdit.NullText = "N";
            repositoryItemCheckEdit.ValueGrayed = "N";
            gridView1.Columns["Delete"].ColumnEdit = repositoryItemCheckEdit;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLINIC_TYPE_UID") });
            repositoryItemLookUpEdit1.DisplayMember = "CLINIC_TYPE_UID";
            repositoryItemLookUpEdit1.ValueMember = "CLINIC_TYPE_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.ShowFooter = false;
            repositoryItemLookUpEdit1.ShowHeader = false;
            repositoryItemLookUpEdit1.NullText = "Clinic Code";
            repositoryItemLookUpEdit1.EditValueChanged += new EventHandler(ClinicCode_EditValueChanged);
            repositoryItemLookUpEdit1.DataSource = dttClinic;
            repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridView1.Columns["Clinic Code"].ColumnEdit = repositoryItemLookUpEdit1;

            RepositoryItemDateEdit repositoryItemDateEdit1 = new RepositoryItemDateEdit();
            repositoryItemDateEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridView1.Columns["Start Datetime"].ColumnEdit = repositoryItemDateEdit1;

            RepositoryItemDateEdit repositoryItemDateEdit2 = new RepositoryItemDateEdit();
            repositoryItemDateEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridView1.Columns["End Datetime"].ColumnEdit = repositoryItemDateEdit2;

            RepositoryItemSpinEdit repositoryItemSpinEdit = new RepositoryItemSpinEdit();
            repositoryItemSpinEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //repositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            //repositoryItemSpinEdit.Mask.EditMask = "[0-9]{0,9}";
            repositoryItemSpinEdit.MaxValue = 2147483647;
            repositoryItemSpinEdit.MinValue = 0;
            repositoryItemSpinEdit.NullText = "0";
            gridView1.Columns["Max App"].ColumnEdit = repositoryItemSpinEdit;
            #endregion Detail Settings
        }
        private void ClinicCode_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit lookup = (DevExpress.XtraEditors.LookUpEdit)sender;
            int rowINdex = gridView1.FocusedRowHandle;
            if (rowINdex > -1 && lookup.ItemIndex > -1)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                int inx = lookup.ItemIndex;
                dr["Clinic Code"] = Convert.ToInt32(dttClinic.Rows[inx]["CLINIC_TYPE_ID"]);
                dr["Clinic Name"] = dttClinic.Rows[inx]["CLINIC_TYPE_TEXT"].ToString();
                dr["CLINIC_TYPE_UID"] = dttClinic.Rows[inx]["CLINIC_TYPE_UID"].ToString();
                gridView1.RefreshData();
                gridView1.BestFitColumns();
            }
        }
        private void treeView1_AfterSelect_TabClinic(string modId)
        {
            ProcessGetRISModalityclinictype getProcess = new ProcessGetRISModalityclinictype();
            getProcess.RISModalityclinictype.MODALITY_ID = Convert.ToInt32(modId);
            getProcess.Invoke(2);
            dtClinic = getProcess.Result.Tables[0].Copy();
            gridControl1.DataSource = dtClinic;
        }
        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (txtModilyCode.Tag == null) {
                e.Handled = true;
                nTabControl1.SelectedIndex = 0;
                btnModalityType.Focus();
                return;

            }
            if (txtUnitCode.Tag == null) {
                e.Handled = true;
                nTabControl1.SelectedIndex = 0;
                btnUnitCode.Focus();
                return;
            }
            if (txtRoomCode.Tag == null) {
                e.Handled = true;
                nTabControl1.SelectedIndex = 0;
                btnRoom.Focus();
            }

            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Custom)
            {
                DataRow row = dtClinic.NewRow();
                row["Delete"] = "N";
                row["Start Datetime"] = DateTime.Now;
                row["End DateTime"] = DateTime.Now;
                row["Max App"] = 1;
                dtClinic.Rows.Add(row);
                dtClinic.AcceptChanges();
            }
        }

        private void InsertData_TabClinic(int ModalityID)
        {
            gridView1.RefreshData();
            if (gridView1.RowCount > 0)
            {
                int k = 0;
                while (k < gridView1.RowCount)
                {
                    DataRow row = gridView1.GetDataRow(k);
                    if (row["Clinic Code"].ToString().Trim() != "")
                    {
                        ProcessAddRISModalityclinictype addModality = new ProcessAddRISModalityclinictype();
                        addModality.RISModalityclinictype.CLINIC_TYPE_ID = Convert.ToInt32(row["Clinic Code"]);
                        addModality.RISModalityclinictype.MODALITY_ID = ModalityID;
                        addModality.RISModalityclinictype.START_DATETIME = row["Start Datetime"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["Start Datetime"]);
                        addModality.RISModalityclinictype.END_DATETIME = row["End Datetime"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["End Datetime"]);
                        addModality.RISModalityclinictype.MAX_APP = row["Max App"].ToString() == "" ? 1 : Convert.ToInt32(row["Max App"]);
                        addModality.RISModalityclinictype.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
                        addModality.RISModalityclinictype.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                        addModality.Invoke();
                    }

                    ++k;
                }
            }
        }
        private void UpdateData_TabClinic(int ModalityID)
        {
            gridView1.RefreshData();
            if (gridView1.RowCount > 0)
            {
                int k = 0;
                while (k < gridView1.RowCount)
                {
                    DataRow row = gridView1.GetDataRow(k);
                    if (row["Clinic Code"].ToString().Trim() != "")
                    {
                        if (row["Delete"].ToString() == "Y")
                        {
                            if (row["MODALITY_CLINICTYPE_ID"].ToString().Trim() != "")
                            {
                                ProcessDeleteRISModalityclinictype delModality = new ProcessDeleteRISModalityclinictype();
                                delModality.RISModalityclinictype.MODALITY_CLINICTYPE_ID = Convert.ToInt32(row["MODALITY_CLINICTYPE_ID"]);
                                delModality.Invoke();
                            }
                        }
                        else if (row["MODALITY_CLINICTYPE_ID"].ToString().Trim() != "")
                        {
                            ProcessUpdateRISModalityclinictype updateModality = new ProcessUpdateRISModalityclinictype();
                            updateModality.RISModalityclinictype.MODALITY_CLINICTYPE_ID = Convert.ToInt32(row["MODALITY_CLINICTYPE_ID"]);
                            updateModality.RISModalityclinictype.CLINIC_TYPE_ID = Convert.ToInt32(row["Clinic Code"]);
                            updateModality.RISModalityclinictype.CLINIC_TYPE_ID_OLD = Convert.ToInt32(row["CLINIC_TYPE_ID"]);
                            updateModality.RISModalityclinictype.MODALITY_ID = ModalityID;
                            updateModality.RISModalityclinictype.START_DATETIME = row["Start Datetime"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["Start Datetime"]);
                            updateModality.RISModalityclinictype.END_DATETIME = row["End Datetime"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["End Datetime"]);
                            updateModality.RISModalityclinictype.MAX_APP = row["Max App"].ToString() == "" ? 1 : Convert.ToInt32(row["Max App"]);
                            updateModality.RISModalityclinictype.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
                            updateModality.RISModalityclinictype.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                            updateModality.Invoke();
                        }
                        else
                        {
                            ProcessAddRISModalityclinictype addModality = new ProcessAddRISModalityclinictype();
                            addModality.RISModalityclinictype.CLINIC_TYPE_ID = Convert.ToInt32(row["Clinic Code"]);
                            addModality.RISModalityclinictype.MODALITY_ID = ModalityID;
                            addModality.RISModalityclinictype.START_DATETIME = row["Start Datetime"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["Start Datetime"]);
                            addModality.RISModalityclinictype.END_DATETIME = row["End Datetime"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["End Datetime"]);
                            addModality.RISModalityclinictype.MAX_APP = row["Max App"].ToString() == "" ? 1 : Convert.ToInt32(row["Max App"]);
                            addModality.RISModalityclinictype.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
                            addModality.RISModalityclinictype.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                            addModality.Invoke();
                        }
                    }
                    ++k;
                }
            }
        }

        private void Delete_TabClinic()
        {
            int k = 0;
            while (k < gridView1.RowCount)
            {
                DataRow row = gridView1.GetDataRow(k);
                if (row["Clinic Code"].ToString().Trim() != "")
                {

                    if (row["MODALITY_CLINICTYPE_ID"].ToString().Trim() != "")
                    {
                        ProcessDeleteRISModalityclinictype delModality = new ProcessDeleteRISModalityclinictype();
                        delModality.RISModalityclinictype.MODALITY_CLINICTYPE_ID = Convert.ToInt32(row["MODALITY_CLINICTYPE_ID"]);
                        delModality.Invoke();
                    }
                }
            }
        }

        private void txtDisplayModalityCode_TextChanged(object sender, EventArgs e)
        {
            txtModCode.Text = txtDisplayModalityCode.Text;
        }
        private void txtDisplayModalityName_TextChanged(object sender, EventArgs e)
        {
            txtModName.Text = txtDisplayModalityName.Text;
        }

        private bool checkInputGrid_TabClinic()
        {
            bool flag = false;

            gridView1.RefreshData();
            int k = 0;
            while (k < gridView1.RowCount)
            {
                DataRow row = gridView1.GetDataRow(k);
                if (row["Clinic Code"].ToString() == "")
                { 
                    flag = true;
                    break;
                }
                ++k;
            }

            return flag;
        }
        private void bs_PositionChanged_TabClinic(int modID)
        {
            ProcessGetRISModalityclinictype getProcess = new ProcessGetRISModalityclinictype();
            getProcess.RISModalityclinictype.MODALITY_ID = Convert.ToInt32(modID);
            getProcess.Invoke(2);
            dtClinic = getProcess.Result.Tables[0].Copy();
            gridControl1.DataSource = dtClinic;
        }

        #endregion Tab Clinic Type
    }
}
