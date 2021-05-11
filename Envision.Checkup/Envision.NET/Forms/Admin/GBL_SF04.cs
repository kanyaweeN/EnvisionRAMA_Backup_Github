using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common;
using RIS.BusinessLogic;
using RIS.Forms.GBLMessage;
using RIS.Operational;
using System.Threading;
using System.Data.SqlClient;

namespace RIS.Forms.Admin
{
    public partial class GBL_SF04 : Form
    {

        private DataTable dt;
        private MyMessageBox mmb = new MyMessageBox();
        private TreeNode[] nodes;
        private TreeNode nodewasselected;
        private bool dbempty;

        private RIS.Common.UtilityClass.DBUtility dbu;
        private UUL.ControlFrame.Controls.TabControl CloseControl;

        private List<string> id = new List<string>();

        public GBL_SF04(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            ComboBox_Setting();
        }
        private void ComboBox_Setting()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable datatable = new DataTable("HR_UNIT");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = @" SELECT UNIT_ID, UNIT_UID FROM HR_UNIT";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(datatable);
            }

            foreach (DataRow row in datatable.Rows)
            { 
                cbbUnit.Items.Add(row["UNIT_UID"]);
                id.Add(row["UNIT_ID"].ToString());
            }
            cbbUnit.SelectedIndex = 0;
            nmUnitID.Value = 1;
        }
        private void cbbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbUnit.Text.Trim() == "")
            {
                nmUnitID.Value = -1;
            }
            else
            {
                int index = cbbUnit.SelectedIndex;
                nmUnitID.Value = Convert.ToDecimal(id[index]);
            }
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            LoadTable();
            SetTreeView();

            //tree1.AfterSelect += new TreeViewEventHandler(tree1_AfterSelect);
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            chkENG.CheckedChanged += new EventHandler(chkENG_CheckedChanged);
            //btnGrantRole.Click +=new EventHandler(btnGrantRole_Click);
            //btnUnit.Click += new EventHandler(btnUnit_Click);

            ProcessGetHRAccount bg = new ProcessGetHRAccount();
            HRAccount hr = new HRAccount();
            hr.Username = new RIS.Common.Common.GBLEnvVariable().UserName;
            bg.HRAccount = hr;
            bg.Invoke();
            string chk = bg.ResultSet.Tables[0].Rows[0]["SUPPORT_USER"].ToString();
            if (chk.ToUpper() == "Y")
                btnShowPW.Visible = true;
            else
                btnShowPW.Visible = false;
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnUnit_Clicks);

            string qry = @"
                        select
                            UNIT_ID,
	                        UNIT_NAME,
	                        UNIT_NAME_ALIAS
                        from
	                        HR_UNIT
                        where
                            UNIT_ID like '%%' OR
                            UNIT_NAME like '%%' OR
                            UNIT_NAME_ALIAS like '%%'";

            string fields = "Unit ID, Unit Name, Name Alias";
            string con = "";
            lv.getData(qry, fields, con, "Unit Detail List");
            lv.Show();
        }
        private void btnUnit_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtUnitID.Text = retValue[0];
            txtUnitName.Text = retValue[1];
        }
        private void btnGrantRole_Click(object sender, EventArgs e)
        {
            if (txtEmpUID.Tag == null) return;
            GBL_SF13 gblsf13 = new GBL_SF13(int.Parse(txtEmpUID.Tag.ToString()), txtEmpUID.Text,
                                            txtNameS.Text + " " + txtNameF.Text + " " + txtNameM.Text + " " + txtNameL.Text);
            gblsf13.Show();
        }
        private void chkENG_CheckedChanged(object sender, EventArgs e)
        {
            tree1.Nodes.Clear();
            SetTreeView();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SetTreeViewwithSearching();
        }
        private void btnGO_Click(object sender, EventArgs e)
        {
            LoadTable();
            tree1.Nodes.Clear();
            SetTreeView();                
        }
        private void tree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag == null) return;
                if (dbempty == true) return;

                DataRow row;
                row = dt.Rows[(int)e.Node.Tag];

                txtUSERNAME.Text = row["USER_NAME"].ToString();
                try { txtPASSWORD.Text = Secure.Decrypt(row["PWD"].ToString()); }
                catch (Exception ex) { txtPASSWORD.Text = "1234"; }
                txtEmpUID.Text = row["EMP_UID"].ToString();
                txtEmpUID.Tag = (object)row["EMP_ID"].ToString();
                txtUnitID.Text = row["UNIT_ID"].ToString();
                txtUnitName.Text = row["UNIT_NAME"].ToString();
                if (row["GENDER"].ToString() == "M")
                    cmbGENDER.SelectedIndex = 0;
                else cmbGENDER.SelectedIndex = 1;
                txtNameS.Text = row["SALUTATION"].ToString();
                txtNameF.Text = row["FNAME"].ToString();
                txtNameM.Text = row["MNAME"].ToString();
                txtNameL.Text = row["LNAME"].ToString();
                txtNameSEng.Text = row["TITLE_ENG"].ToString();
                txtNameFEng.Text = row["FNAME_ENG"].ToString();
                txtNameMEng.Text = row["MNAME_ENG"].ToString();
                txtNameLEng.Text = row["LNAME_ENG"].ToString();
                txtQuestion.Text = row["SECURITY_QUESTION"].ToString();
                txtAnswer.Text = row["SECURITY_ANSWER"].ToString();
                if (row["DEFAULT_LANG"].ToString() == "3")
                    cmbLanguage.SelectedIndex = 2;
                else if (row["DEFAULT_LANG"].ToString() == "2")
                    cmbLanguage.SelectedIndex = 1;
                else cmbLanguage.SelectedIndex = 0;
                nmbAuthorLvID.Value = decimal.Parse(row["AUTH_LEVEL_ID"].ToString());
                txtJobType.Text = row["JOB_TYPE"].ToString();
                if (row["IS_ACTIVE"].ToString() == "Y")
                    chkActive.Checked = true;
                else chkActive.Checked = false;
                if (row["IS_RADIOLOGIST"].ToString() == "Y")
                    chkRadiologist.Checked = true;
                else chkRadiologist.Checked = false;
                if (row["ALLOW_OTHERS_TO_FINALIZE"].ToString() == "Y")
                    chkAllowFinalize.Checked = true;
                else chkAllowFinalize.Checked = false;
                if (row["SUPPORT_USER"].ToString() == "Y")
                    chkSupportUser.Checked = true;
                else chkSupportUser.Checked = false;
                if (row["CAN_KILL_SESSION"].ToString() == "Y")
                    chkCanKillSession.Checked = true;
                else chkCanKillSession.Checked = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnGrantRole.Enabled = true;

                nodewasselected = (TreeNode)e.Node.Clone();
            }
            catch (Exception ex)
            { 
             
            }
        }

        private void LoadTable()
        {
            dt = new DataTable();

            GBLEmployee employee = new GBLEmployee();
            ProcessGetEmployee processget = new ProcessGetEmployee();

            employee.Auth_Level_ID = (int)nmAuthorLV.Value;
            employee.Unit_ID = (int)nmUnitID.Value;
            processget.GBLEmployee = employee;
            processget.Invoke();

            dt = processget.DataResult.Tables[0].Copy();

            if (dt.Rows.Count > 0)
                dbempty = false;
            else dbempty = true;

        }
        private void SetTreeView()
        {
            TreeNode treenode;
            if (chkENG.Checked == false)
            {
                int k = 0;
                foreach (DataRow row in dt.Rows)
                {
                    treenode = new TreeNode(row["EMP_UID"].ToString() + " " +
                                            row["USER_NAME"].ToString() + " " +
                                            row["SALUTATION"].ToString() + " " +
                                            row["FNAME"].ToString() + " " +
                                            row["MNAME"].ToString() + " " +
                                            row["LNAME"].ToString());
                    treenode.Tag = k;
                    tree1.Nodes.Add(treenode);
                    ++k;
                }
            }
            else if (chkENG.Checked == true)
            {
                int k = 0;
                foreach (DataRow row in dt.Rows)
                {
                    treenode = new TreeNode(row["EMP_UID"].ToString() + " " +
                                         row["USER_NAME"].ToString() + " " +
                                         row["TITLE_ENG"].ToString() + " " +
                                         row["FNAME_ENG"].ToString() + " " +
                                         row["MNAME_ENG"].ToString() + " " +
                                         row["LNAME_ENG"].ToString());
                    treenode.Tag = k;
                    tree1.Nodes.Add(treenode);
                    ++k;
                }
            }
            
            nodes = new TreeNode[tree1.Nodes.Count];
            tree1.Nodes.CopyTo(nodes, 0);
        }
        private void SetTreeViewwithSearching()
        {
            if (txtSearch.Text == "")
            {
                tree1.Nodes.Clear();
                tree1.Nodes.AddRange((TreeNode[])nodes.Clone());
            }
            else
            {
                tree1.Nodes.Clear();
                foreach (TreeNode node in nodes)
                {
                    if (node.Text.Contains(txtSearch.Text))
                        tree1.Nodes.Add((TreeNode)node.Clone());
                }
            }
        }
        private void EnableControl(bool enable)
        {
            txtSearch.Enabled = !enable;
            nmAuthorLV.Enabled = !enable;
            chkENG.Enabled = !enable;
            btnGO.Enabled = !enable;
            tree1.Enabled = !enable;
            nmUnitID.Enabled = !enable;

            txtUSERNAME.Enabled = enable;
            txtPASSWORD.Enabled = enable;
            txtEmpUID.Enabled = enable;
            cmbGENDER.Enabled = enable;
            txtUnitID.Enabled = enable;
            txtUnitName.Enabled = enable;
            btnUnit.Enabled = enable;
            txtNameS.Enabled = enable;
            txtNameF.Enabled = enable;
            txtNameM.Enabled = enable;
            txtNameL.Enabled = enable;
            txtNameSEng.Enabled = enable;
            txtNameFEng.Enabled = enable;
            txtNameMEng.Enabled = enable;
            txtNameLEng.Enabled = enable;
            txtQuestion.Enabled = enable;
            txtAnswer.Enabled = enable;
            cmbLanguage.Enabled = enable;
            nmbAuthorLvID.Enabled = enable;
            txtJobType.Enabled = enable;
            chkActive.Enabled = enable;
            chkRadiologist.Enabled = enable;
            chkAllowFinalize.Enabled = enable;
            chkSupportUser.Enabled = enable;
            chkCanKillSession.Enabled = enable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtSearch.Enabled = false;
            nmAuthorLV.Enabled = false;
            chkENG.Enabled = false;
            btnGO.Enabled = false;
            tree1.Enabled = false;
            nmUnitID.Enabled = false;

            txtUSERNAME.Text = string.Empty;
            txtPASSWORD.Text = string.Empty;
            txtEmpUID.Text = string.Empty;
            cmbGENDER.SelectedIndex = 0;
            txtUnitID.Text = string.Empty;
            txtUnitName.Text = string.Empty;
            btnUnit.Enabled = true;
            txtNameS.Text = string.Empty;
            txtNameF.Text = string.Empty;
            txtNameM.Text = string.Empty;
            txtNameL.Text = string.Empty;
            txtNameSEng.Text = string.Empty;
            txtNameFEng.Text = string.Empty;
            txtNameMEng.Text = string.Empty;
            txtNameLEng.Text = string.Empty;
            txtQuestion.Text = string.Empty;
            txtAnswer.Text = string.Empty;
            cmbLanguage.SelectedIndex = 0;
            nmbAuthorLvID.Value = 3;
            txtJobType.Text = string.Empty;
            chkActive.Checked = false;
            chkRadiologist.Checked = false;
            chkAllowFinalize.Checked = false;
            chkSupportUser.Checked = false;
            chkCanKillSession.Checked = false;

            txtUSERNAME.Enabled = true;
            txtPASSWORD.Enabled = true;
            txtEmpUID.Enabled = true;
            cmbGENDER.Enabled = true;
            txtUnitID.Enabled = true;
            txtUnitName.Enabled = true;
            btnUnit.Enabled = true;
            txtNameS.Enabled = true;
            txtNameF.Enabled = true;
            txtNameM.Enabled = true;
            txtNameL.Enabled = true;
            txtNameSEng.Enabled = true;
            txtNameFEng.Enabled = true;
            txtNameMEng.Enabled = true;
            txtNameLEng.Enabled = true;
            txtQuestion.Enabled = true;
            txtAnswer.Enabled = true;
            cmbLanguage.Enabled = true;
            nmbAuthorLvID.Enabled = true;
            txtJobType.Enabled = true;
            chkActive.Enabled = true;
            chkRadiologist.Enabled = true;
            chkAllowFinalize.Enabled = true;
            chkSupportUser.Enabled = true;
            chkCanKillSession.Enabled = true;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSaveAdd.Visible = true;
            btnCancel.Visible = true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dbempty == true) return;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSaveEdit.Visible = true;
            btnCancel.Visible = true;

            EnableControl(true);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dbempty == true) return;
            if (mmb.ShowAlert("UID2003", 1) == "1") return;

            GBLEmployee employee = new GBLEmployee();
            ProcessDeleteGBLEmployee processdelete = new ProcessDeleteGBLEmployee();
            employee.Emp_ID = int.Parse(txtEmpUID.Tag.ToString());
            processdelete.GBLEmployee = employee;
            processdelete.Invoke();

            RefreshDelete();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (txtUSERNAME.Text == "")
            { /*MessageBox.Show("ท่านยังไม่ได้กรอกusername");*/ mmb.ShowAlert("UID2001", 1); return; }
            else if (txtPASSWORD.Text == "")
            { /*MessageBox.Show("ท่านไม่ได้กรอก password");*/ mmb.ShowAlert("UID2001", 1); return; }
            else if (txtUnitID.Text == "")
            { /*MessageBox.Show("ท่านไม่ได้ใส่ unitid");*/ mmb.ShowAlert("UID2001", 1); return; }

                SaveAdd();
        }
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (txtUSERNAME.Text == "")
            { /*MessageBox.Show("ท่านยังไม่ได้กรอกusername");*/ mmb.ShowAlert("UID2001", 1); return; }
            else if (txtPASSWORD.Text == "")
            { /*MessageBox.Show("ท่านไม่ได้กรอก password");*/ mmb.ShowAlert("UID2001", 1); return; }
            else if (txtUnitID.Text == "")
            { /*MessageBox.Show("ท่านไม่ได้ใส่ unitid");*/ mmb.ShowAlert("UID2001", 1); return; }

            SaveEdit();
        }
        private void btnSaveDelete_Click(object sender, EventArgs e)
        {
            SaveDelete();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Enabled = true;
            nmAuthorLV.Enabled = true;
            chkENG.Enabled = true;
            btnGO.Enabled = true;
            tree1.Enabled = true;

            EnableControl(false);

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnSaveAdd.Visible = false;
            btnSaveEdit.Visible = false;
            btnSaveDelete.Visible = false;
            btnCancel.Visible = false;

            object ee = null;
            TreeViewEventArgs eee = new TreeViewEventArgs(nodewasselected);
            tree1_AfterSelect(ee, eee);

            //if (btnSaveAdd.Visible == true) { btnGO_Click(sender, e); }
        }

        private void SaveAdd()
        {
            GBLEmployee employee = new GBLEmployee();
            ProcessAddGBLEmployee processadd = new ProcessAddGBLEmployee();

            employee.User_Name = txtUSERNAME.Text;
            try { employee.Pwd = Secure.Encrypt(txtPASSWORD.Text); }
            catch (Exception ex) { employee.Pwd = Secure.Encrypt("1234"); }
            employee.Unit_ID = int.Parse(txtUnitID.Text);
            employee.Emp_UID = txtEmpUID.Text;
            try { employee.Emp_ID = int.Parse(txtEmpUID.Tag.ToString()); }
            catch (Exception) { }
            employee.Gender = cmbGENDER.Text;
            employee.Salutation = txtNameS.Text;
            employee.Fname = txtNameF.Text;
            employee.Mname = txtNameM.Text;
            employee.Lname = txtNameL.Text;
            employee.Title_Eng = txtNameSEng.Text;
            employee.Fname_Eng = txtNameFEng.Text;
            employee.Mname_Eng = txtNameMEng.Text;
            employee.Lname_Eng = txtNameLEng.Text;
            employee.Security_Question = txtQuestion.Text;
            employee.Security_Answer = txtAnswer.Text;
            employee.Default_Lang = cmbLanguage.SelectedIndex + 1;
            employee.Auth_Level_ID = int.Parse(nmbAuthorLvID.Value.ToString());
            employee.Job_Type = txtJobType.Text;
            if (chkActive.Checked == true)
                employee.Is_Active = "Y";
            else employee.Is_Active = "N";
            if (chkRadiologist.Checked == true)
                employee.Is_Radiologist = "Y";
            else employee.Is_Radiologist = "N";
            if (chkAllowFinalize.Checked == true)
                employee.Allow_Other_To_Finalize = "Y";
            else employee.Allow_Other_To_Finalize = "N";
            if (chkSupportUser.Checked == true)
                employee.Support_User = "Y";
            else employee.Support_User = "N";
            if (chkCanKillSession.Checked == true)
                employee.Can_Kill_Session = "Y";
            else employee.Can_Kill_Session = "N";
            employee.Org_ID = new global::RIS.Common.Common.GBLEnvVariable().OrgID;

            employee.EMP_REPORT_FOOTER1 = txtNameSEng.Text + " " + txtNameFEng.Text + " " + txtNameMEng.Text + " " + txtNameLEng.Text;
            employee.EMP_REPORT_FOOTER2 = txtNameSEng.Text + " " + txtNameFEng.Text + " " + txtNameMEng.Text + " " + txtNameLEng.Text;

            processadd.GBLEmployee = employee;
            processadd.Invoke();

            mmb.ShowAlert("UID2002",1);

            RefreshAdd();
        }
        private void SaveEdit()
        {
            GBLEmployee employee = new GBLEmployee();
            ProcessUpdateGBLEmployee processupdate = new ProcessUpdateGBLEmployee();

            employee.User_Name = txtUSERNAME.Text;
            try { employee.Pwd = Secure.Encrypt(txtPASSWORD.Text); }
            catch (Exception ex) { employee.Pwd = Secure.Encrypt("1234"); }
            employee.Unit_ID = int.Parse(txtUnitID.Text);
            employee.Emp_UID = txtEmpUID.Text;
            employee.Emp_ID = int.Parse(txtEmpUID.Tag.ToString());
            employee.Gender = cmbGENDER.Text;
            employee.Salutation = txtNameS.Text;
            employee.Fname = txtNameF.Text;
            employee.Mname = txtNameM.Text;
            employee.Lname = txtNameL.Text;
            employee.Title_Eng = txtNameSEng.Text;
            employee.Fname_Eng = txtNameFEng.Text;
            employee.Mname_Eng = txtNameMEng.Text;
            employee.Lname_Eng = txtNameLEng.Text;
            employee.Security_Question = txtQuestion.Text;
            employee.Security_Answer = txtAnswer.Text;
            employee.Default_Lang = cmbLanguage.SelectedIndex + 1;
            employee.Auth_Level_ID = int.Parse(nmbAuthorLvID.Value.ToString());
            employee.Job_Type = txtJobType.Text;
            if (chkActive.Checked == true)
                employee.Is_Active = "Y";
            else employee.Is_Active = "N";
            if (chkRadiologist.Checked == true)
                employee.Is_Radiologist = "Y";
            else employee.Is_Radiologist = "N";
            if (chkAllowFinalize.Checked == true)
                employee.Allow_Other_To_Finalize = "Y";
            else employee.Allow_Other_To_Finalize = "N";
            if (chkSupportUser.Checked == true)
                employee.Support_User = "Y";
            else employee.Support_User = "N";
            if (chkCanKillSession.Checked == true)
                employee.Can_Kill_Session = "Y";
            else employee.Can_Kill_Session = "N";
            employee.Org_ID = new global::RIS.Common.Common.GBLEnvVariable().OrgID;

            employee.EMP_REPORT_FOOTER1 = txtNameSEng.Text + " " + txtNameFEng.Text + " " + txtNameMEng.Text + " " + txtNameLEng.Text;
            employee.EMP_REPORT_FOOTER2 = txtNameSEng.Text + " " + txtNameFEng.Text + " " + txtNameMEng.Text + " " + txtNameLEng.Text;

            processupdate.GBLEmployee = employee;
            processupdate.Invoke();

            mmb.ShowAlert("UID2002", 1);

            RefreshEdit();
        }
        private void SaveDelete()
        {
            RefreshDelete();
        }
        private void RefreshAdd()
        {

            txtUSERNAME.Text = string.Empty;
            txtPASSWORD.Text = string.Empty;
            txtEmpUID.Text = string.Empty;
            cmbGENDER.SelectedIndex = 0;
            txtUnitID.Text = string.Empty;
            txtUnitName.Text = string.Empty;
            btnUnit.Enabled = true;
            txtNameS.Text = string.Empty;
            txtNameF.Text = string.Empty;
            txtNameM.Text = string.Empty;
            txtNameL.Text = string.Empty;
            txtNameSEng.Text = string.Empty;
            txtNameFEng.Text = string.Empty;
            txtNameMEng.Text = string.Empty;
            txtNameLEng.Text = string.Empty;
            txtQuestion.Text = string.Empty;
            txtAnswer.Text = string.Empty;
            cmbLanguage.SelectedIndex = 0;
            nmbAuthorLvID.Value = 3;
            txtJobType.Text = string.Empty;
            chkActive.Checked = false;
            chkRadiologist.Checked = false;
            chkAllowFinalize.Checked = false;
            chkSupportUser.Checked = false;
            chkCanKillSession.Checked = false;

            LoadTable();
            tree1.Nodes.Clear();
            SetTreeView();

            mmb.ShowAlert("UID2050", 1);
        }
        private void RefreshEdit()
        {
            txtSearch.Enabled = true;
            nmAuthorLV.Enabled = true;
            chkENG.Enabled = true;
            btnGO.Enabled = true;
            tree1.Enabled = true;

            EnableControl(false);

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnSaveAdd.Visible = false;
            btnSaveEdit.Visible = false;
            btnSaveDelete.Visible = false;
            btnCancel.Visible = false;

            LoadTable();
            tree1.Nodes.Clear();
            SetTreeView();

            object ee = null;
            TreeViewEventArgs eee = new TreeViewEventArgs(nodewasselected);
            tree1_AfterSelect(ee, eee);

            mmb.ShowAlert("UID2050", 1);
        }
        private void RefreshDelete()
        {
            EnableControl(false);

            if (tree1.Nodes.Count > 0)
            {
                object ee = null;
                TreeViewEventArgs eee = new TreeViewEventArgs(tree1.Nodes[0]);
                tree1_AfterSelect(ee, eee);
            }
            else 
            {
                object ee = new object();
                EventArgs eee = new EventArgs();
                btnAdd_Click(ee, eee);
            }

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnSaveAdd.Visible = false;
            btnSaveEdit.Visible = false;
            btnSaveDelete.Visible = false;
            btnCancel.Visible = false;

            LoadTable();
            tree1.Nodes.Clear();
            SetTreeView();
        }

        #region txtName translate Thai to English
        private void txtNameS_Validated(object sender, EventArgs e)
        {
            //TextBox sd = (TextBox)sender;
            //txtNameSEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text);
        }
        private void txtNameF_Validated(object sender, EventArgs e)
        {
            TextBox sd = (TextBox)sender;
            txtNameFEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text).Trim();
            if (txtNameFEng.Text.Length > 0)
                txtNameFEng.Text = txtNameFEng.Text.Substring(0, 1).ToUpper() + txtNameFEng.Text.Substring(1);
        }
        private void txtNameM_Validated(object sender, EventArgs e)
        {
            TextBox sd = (TextBox)sender;
            txtNameMEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text).Trim();
            if (txtNameMEng.Text.Length > 0)
                txtNameMEng.Text = txtNameMEng.Text.Substring(0, 1).ToUpper() + txtNameMEng.Text.Substring(1);
        }
        private void txtNameL_Validated(object sender, EventArgs e)
        {
            TextBox sd = (TextBox)sender;
            txtNameLEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(sd.Text).Trim();
            if (txtNameLEng.Text.Length > 0)
                txtNameLEng.Text = txtNameLEng.Text.Substring(0, 1).ToUpper() + txtNameLEng.Text.Substring(1);
        }
        #endregion txtName translate Thai to English

        private void btnGrantUnit_Click(object sender, EventArgs e)
        {
            if (txtEmpUID.Tag == null) return;
            if (txtUnitID.Text.Trim().Equals(""))
            {
                GrantUnit gblsf13 = new GrantUnit(int.Parse(txtEmpUID.Tag.ToString()), txtEmpUID.Text,
                                                txtNameS.Text + " " + txtNameF.Text + " " + txtNameM.Text + " " + txtNameL.Text);
                gblsf13.Show();
            }
            else
            {
                GrantUnit gblsf13 = new GrantUnit(int.Parse(txtEmpUID.Tag.ToString()), txtEmpUID.Text,
                                                txtNameS.Text + " " + txtNameF.Text + " " + txtNameM.Text + " " + txtNameL.Text
                                                ,int.Parse(txtUnitID.Text));
                gblsf13.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(txtEmpUID.Tag!=null)
            {
                SaveEdit_Reset();
            }
        }

        private void SaveEdit_Reset()
        {
            MyMessageBox msg = new MyMessageBox();
            string str = msg.ShowAlert("UID2112", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
            if (str == "2")
            {
                GBLEmployee employee = new GBLEmployee();
                ProcessUpdateGBLEmployee processupdate = new ProcessUpdateGBLEmployee();

                employee.User_Name = txtUSERNAME.Text;
                employee.Pwd = Secure.Encrypt("envision");
                employee.Unit_ID = int.Parse(txtUnitID.Text);
                employee.Emp_UID = txtEmpUID.Text;
                employee.Emp_ID = int.Parse(txtEmpUID.Tag.ToString());
                employee.Gender = cmbGENDER.Text;
                employee.Salutation = txtNameS.Text;
                employee.Fname = txtNameF.Text;
                employee.Mname = txtNameM.Text;
                employee.Lname = txtNameL.Text;
                employee.Title_Eng = txtNameSEng.Text;
                employee.Fname_Eng = txtNameFEng.Text;
                employee.Mname_Eng = txtNameMEng.Text;
                employee.Lname_Eng = txtNameLEng.Text;
                employee.Security_Question = txtQuestion.Text;
                employee.Security_Answer = txtAnswer.Text;
                employee.Default_Lang = cmbLanguage.SelectedIndex + 1;
                employee.Auth_Level_ID = int.Parse(nmbAuthorLvID.Value.ToString());
                employee.Job_Type = txtJobType.Text;
                if (chkActive.Checked == true)
                    employee.Is_Active = "Y";
                else employee.Is_Active = "N";
                if (chkRadiologist.Checked == true)
                    employee.Is_Radiologist = "Y";
                else employee.Is_Radiologist = "N";
                if (chkAllowFinalize.Checked == true)
                    employee.Allow_Other_To_Finalize = "Y";
                else employee.Allow_Other_To_Finalize = "N";
                if (chkSupportUser.Checked == true)
                    employee.Support_User = "Y";
                else employee.Support_User = "N";
                if (chkCanKillSession.Checked == true)
                    employee.Can_Kill_Session = "Y";
                else employee.Can_Kill_Session = "N";
                employee.Org_ID = new global::RIS.Common.Common.GBLEnvVariable().OrgID;

                employee.EMP_REPORT_FOOTER1 = txtNameSEng.Text + " " + txtNameFEng.Text + " " + txtNameMEng.Text + " " + txtNameLEng.Text;
                employee.EMP_REPORT_FOOTER2 = txtNameSEng.Text + " " + txtNameFEng.Text + " " + txtNameMEng.Text + " " + txtNameLEng.Text;

                processupdate.GBLEmployee = employee;
                processupdate.Invoke();

                mmb.ShowAlert("UID2113", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);

                RefreshEdit();
            }
        }

        private void btnShowPW_Click(object sender, EventArgs e)
        {
            if (txtPASSWORD.Text != "")
            {
                MessageBox.Show(txtPASSWORD.Text,"User Password",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("not has a password in the textbox.");
            }
        }
    }
}