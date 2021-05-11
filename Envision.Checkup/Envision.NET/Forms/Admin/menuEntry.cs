using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common.UtilityClass;
using RIS.Common.DBConnection;

using UUL.ControlFrame.Controls;

namespace RIS.Forms.Admin
{
    public partial class menuEntry : Form
    {
        //--Create object of dbConnection class for database interaction--\\        
        DBUtility dbu = new DBUtility();
                
        private UUL.ControlFrame.Controls.TabControl CloseControl;

        public menuEntry(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
        }

        //--Variable for trace the selected submenu id--\\
        string subMenuNo;
        //--Variable for keep the initial menu id--\\
        string menuId;
        //--Variable for keep the initial row number in the list view--\\
        int rowNum = 0;
        //--Variable for keep the selected node number--\\
        int nodeNo = 0;

        public void loadMenu()
        {
            //--Load menu tree--\\                        
            try
            {
                DataTable dt = DatabaseUtility.ExecuteDataTable("select * from USER_MENU order by SL_NO");
                if (dt.Rows.Count == 0)
                {
                    treeMenu.Nodes.Add("No menu entered");
                }
                else
                {
                    treeMenu.Nodes.Add("List of Menu");
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        TreeNode newNode = new TreeNode(dt.Rows[i]["MENU_NAME"].ToString());
                        newNode.Tag = dt.Rows[i]["MENU_NO"].ToString();
                        treeMenu.Nodes[0].Nodes.Add(newNode);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            treeMenu.ExpandAll();
        }

        public void loadMenuInormation(string tag)
        {
            //--Pick information of the selected menu--\\
            try
            {
                DataTable dt1 = DatabaseUtility.ExecuteDataTable("select * from USER_MENU where MENU_NO = @menuNo", new SqlParameter("menuNo", tag));
                //--Put value in the related field--\\
                txtMenuNo.Text = dt1.Rows[0]["MENU_NO"].ToString();
                txtMenuId.Text = dt1.Rows[0]["MENU_ID"].ToString();
                menuId = dt1.Rows[0]["MENU_ID"].ToString();
                txtMenuName.Text = dt1.Rows[0]["MENU_NAME"].ToString();
                txtMenuDesc.Text = dt1.Rows[0]["DESCR"].ToString();
                txtMenuSerial.Text = dt1.Rows[0]["SL_NO"].ToString();
                cmbMenuStat.Text = dt1.Rows[0]["STATUS"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public void loadSubmenuInformation(string tag1)
        {
            //--Clear control--\\
            dbu.clearCntrl(this, "groupBox2", "TextBox,ComboBox");
            //--Clear the list view--\\
            listView1.Items.Clear();
            //--Pick submenu information--\\
            try
            {
                DataTable dt5 = DatabaseUtility.ExecuteDataTable("select * from USER_SUBMENU where MENU_NO = @menuNo order by SUBMENU_LEVEL, SL_NO", new SqlParameter("menuNo", tag1));
                DataTable dt6;
                
                //--Put the value in the list view--\\
                int k = 0;
                while (k < dt5.Rows.Count)
                {
                    dt6 = new DataTable();
                    if (dt5.Rows[k]["PARENT_SUBMENU_NO"].ToString() != "")
                    {
                        dt6 = DatabaseUtility.ExecuteDataTable("select SUBMENU_NAME_USER from USER_SUBMENU where SUBMENU_NO = @subMenuNo ", new SqlParameter("subMenuNo", dt5.Rows[k]["PARENT_SUBMENU_NO"].ToString()));
                    }

                    listView1.Items.Add(dt5.Rows[k]["SUBMENU_NAME_USER"].ToString(), k);
                    listView1.Items[k].SubItems.Add(dt5.Rows[k]["SUBMENU_TYPE"].ToString());
                    listView1.Items[k].SubItems.Add(dt5.Rows[k]["STATUS"].ToString());
                    listView1.Items[k].SubItems.Add(dt5.Rows[k]["DESCR"].ToString());
                    listView1.Items[k].SubItems.Add(dt5.Rows[k]["FORM_NAME"].ToString());
                    listView1.Items[k].SubItems.Add(dt5.Rows[k]["SL_NO"].ToString());
                    listView1.Items[k].SubItems.Add(dt5.Rows[k]["PARENT_SUBMENU_NO"].ToString());
                    listView1.Items[k].SubItems.Add(dt5.Rows[k]["SUBMENU_LEVEL"].ToString());
                    listView1.Items[k].SubItems.Add(dt5.Rows[k]["SUBMENU_NO"].ToString());
                    if (dt5.Rows[k]["PARENT_SUBMENU_NO"].ToString() != "")
                    {
                        listView1.Items[k].SubItems.Add(dt6.Rows[0]["SUBMENU_NAME_USER"].ToString());
                    }
                    else
                    {
                        listView1.Items[k].SubItems.Add("<null>");
                    }
                    k++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void menuEntry_Load(object sender, EventArgs e)
        {
            //-Load the menu tree--\\
            loadMenu();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void treeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.LastNode == null)
            {
                try
                {
                    nodeNo = Convert.ToInt32(treeMenu.SelectedNode.Index);
                    //--Make button enabled--\\
                    btnAddNew.Text = "Add New";
                    btnEdit.Enabled = true;
                    btnEdit.Text = "Edit";
                    btnDelete.Enabled = true;
                    btnSubAddNew.Enabled = true;
                    btnSubAddNew.Text = "Add New";
                    btnSubEdit.Enabled = false;
                    btnSubDelete.Enabled = false;
                    checkBox1.Checked = false;
                    checkBox1.Visible = false;

                    //--Contro property change--\\
                    txtMenuNo.Enabled = false;
                    txtMenuId.Enabled = false;
                    txtMenuName.Enabled = false;
                    txtMenuDesc.Enabled = false;
                    txtMenuSerial.Enabled = false;
                    cmbMenuStat.Enabled = false;

                    //-Change groupbox2 control property--\\
                    txtSubName.Enabled = false;
                    txtSubDesc.Enabled = false;
                    cmbSubmenuType.Enabled = false;
                    cmbSubStatus.Enabled = false;
                    txtFormName.Enabled = false;
                    txtSubMenuSerial.Enabled = false;
                    cmbParentSubMenu.Enabled = false;
                    
                    //--Call the loadInformation function to load details information of currently selected master name in the treeView--\\        
                    loadMenuInormation(treeMenu.SelectedNode.Tag.ToString());
                    subMenuNo = "";

                    //--Load submenu list in the submenu listView--\\
                    loadSubmenuInformation(treeMenu.SelectedNode.Tag.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                //--Change button text--\\
                btnEdit.Text = "Ok";
                //--Contro property change--\\
                txtMenuNo.Enabled = false;
                txtMenuId.Enabled = false;
                txtMenuName.Enabled = true;
                txtMenuDesc.Enabled = true;
                txtMenuSerial.Enabled = false;
                cmbMenuStat.Enabled = true;

                checkBox1.Visible = true;
            }

            else
            {
                //--Check that the menu is present in the database or not--\\
                int chkId1 = checkExistsMenuId(txtMenuId.Text.Trim(), txtMenuNo.Text.Trim());
                if (chkId1 == 1)
                {
                    //--Code for edit information--\\
                    try
                    {
                        int i = 0;
                        i = DatabaseUtility.ExecuteNonQuery("update USER_MENU set " + 
                                "MENU_ID = @menuID, MENU_NAME = @menuName, DESCR = @menuDesc, " + 
                                "STATUS = @menuStat where MENU_NO = @menuNo", 
                                new SqlParameter("menuID", txtMenuId.Text.Trim()), 
                                new SqlParameter("menuName", txtMenuName.Text.Trim()), 
                                new SqlParameter("menuDesc", txtMenuDesc.Text.Trim()), 
                                new SqlParameter("menuStat", cmbMenuStat.Text.Trim()), 
                                new SqlParameter("menuNo", txtMenuNo.Text.Trim()));
                        if (i == 0)
                        {
                            //MessageBox.Show(em.msgRet(4).ToString());
                            return;
                        }
                        else
                        {
                            //MessageBox.Show(em.msgRet(3).ToString());

                            //--Contro property change--\\
                            btnEdit.Enabled = false;
                            btnDelete.Enabled = false;

                            //--Reload the menu tree with the updated menu information--\\
                            treeMenu.Nodes.Clear();
                            loadMenu();
                            listView1.Items.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                else
                {
                    //MessageBox.Show("Menu ID " + em.msgRet(6).ToString());
                    txtMenuId.Focus();
                    return;
                }
            }
        }

        public int checkExistsMenuId(string menuId, string menuNo)
        {
            //--check that the menu id is present or not in the database--\\
            DataTable dt9;
            try
            {
                if (menuNo == "")
                {
                    dt9 = DatabaseUtility.ExecuteDataTable("select MENU_ID from USER_MENU where MENU_ID = @menuID", 
                            new SqlParameter("menuID", menuId));
                }
                else
                {
                    dt9 = DatabaseUtility.ExecuteDataTable("select MENU_ID from USER_MENU where MENU_ID = @menuID and MENU_NO <> @menuNo", 
                            new SqlParameter("menuID", menuId), new SqlParameter("menuNo", menuNo));
                }
                
                if (dt9.Rows.Count == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 2;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (btnAddNew.Text == "Add New")
            {
                checkBox1.Checked = false;
                checkBox1.Visible = false;
                //--Clear taxt box and comboBox--\\
                dbu.clearCntrl(this, "groupBox1", "TextBox,ComboBox");
                //--Change button Property--\\
                btnAddNew.Text = "Save";
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSubAddNew.Text = "Add New";
                btnSubAddNew.Enabled = false;
                //--Contro property change--\\
                txtMenuNo.Enabled = false;
                txtMenuId.Enabled = true;
                txtMenuName.Enabled = true;
                txtMenuDesc.Enabled = true;
                txtMenuSerial.Enabled = false;
                cmbMenuStat.Enabled = true;

                //-Change groupbox2 control property--\\
                txtSubName.Enabled = false;
                txtSubDesc.Enabled = false;
                cmbSubmenuType.Enabled = false;
                cmbSubStatus.Enabled = false;
                txtFormName.Enabled = false;
                
                //--clear listview--\\
                listView1.Items.Clear();


                //--Generate Menu number--\\
                try
                {
                    //MessageBox.Show(dt3.Rows[0][0].ToString());
                    int menuNo = Convert.ToInt32(DatabaseUtility.ExecuteScalar("select max(MENU_NO) from USER_MENU").ToString());
                    menuNo++;
                    txtMenuNo.Text = menuNo.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                //--Generate Serial number--\\
                try
                {
                    int serialNo = Convert.ToInt32(DatabaseUtility.ExecuteScalar("select max(SL_NO) from USER_MENU").ToString());
                    serialNo++;
                    txtMenuSerial.Text = serialNo.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                //--Check validation--\\
                if (txtMenuId.Text == "")
                {
                    MessageBox.Show("Menu ID field can not be blank");
                    txtMenuId.Focus();
                    return;
                }
                if (txtMenuName.Text == "")
                {
                    MessageBox.Show("Menu Name field can not be blank");
                    txtMenuName.Focus();
                    return;
                }
                if (cmbMenuStat.Text == "")
                {
                    MessageBox.Show("Status field can not be blank");
                    cmbMenuStat.Focus();
                    return;
                }
                else
                {
                    //--Check that the menu is present in the database or not--\\
                    int chkId = checkExistsMenuId(txtMenuId.Text.Trim(), "");
                    if (chkId == 1)
                    {
                        //--Save new menu information--\\
                        try
                        {
                            int m = 0;
                            m = DatabaseUtility.ExecuteNonQuery("insert into USER_MENU(MENU_NO,MENU_ID,DESCR,MENU_NAME,SL_NO,STATUS) " +
                                "values(@menuNo,@menuID,@menuDesc,@menuName,@menuSL,@menuStat) ",
                                new SqlParameter("menuNo", txtMenuNo.Text.Trim()),
                                new SqlParameter("menuID", txtMenuId.Text.Trim()),
                                new SqlParameter("menuDesc", txtMenuDesc.Text.Trim()),
                                new SqlParameter("menuName", txtMenuName.Text.Trim()),
                                new SqlParameter("menuSL", txtMenuSerial.Text.Trim()),
                                new SqlParameter("menuStat", cmbMenuStat.Text.Trim()));
                            if (m == 1)
                            {
                                MessageBox.Show("Information saved successfully");
                                //cc.clearCntrl(this, "groupBox1", "TextBox,ComboBox");
                                treeMenu.Nodes.Clear();
                                loadMenu();
                                //--Change control property--\\
                                txtMenuId.Enabled = false;
                                txtMenuName.Enabled = false;
                                txtMenuDesc.Enabled = false;
                                cmbMenuStat.Enabled = false;
                                //--Change button property--\\
                                btnAddNew.Text = "Add New";
                                btnSubAddNew.Enabled = true;
                                btnEdit.Enabled = true;
                                btnDelete.Enabled = true;
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Not Saved");
                                cmbMenuStat.Focus();
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Menu ID field can not be blank");
                        txtMenuId.Focus();
                        return;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //--code for delete menu information with the submenu together--\\

            

            //--Now Delete the menu information from the meu table--\\
            DialogResult result;
            //string msg = em.msgRet(7).ToString();
            result = MessageBox.Show("Would you like to delete the selected item", "Clove Lakes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //--First delete all submenu list related to the selected menu going to be deleted--\\
                try
                {
                    DatabaseUtility.ExecuteNonQuery("delete from USER_SUBMENU where MENU_NO = @menuNo ",
                                    new SqlParameter("menuNo", txtMenuNo.Text.Trim()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                int n = 0;

                try
                {
                    n = DatabaseUtility.ExecuteNonQuery("delete from USER_MENU where MENU_NO = @menuNo ",
                                new SqlParameter("menuNo", txtMenuNo.Text.Trim()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (n == 1)
                {
                    MessageBox.Show("Information deleted");
                    dbu.clearCntrl(this, "groupBox1", "TextBox,ComboBox");
                    treeMenu.Nodes.Clear();
                    loadMenu();
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSubAddNew.Enabled = false;
                    listView1.Items.Clear();
                    return;
                }
                else
                {
                    MessageBox.Show("Information not deleted");
                    return;
                }
            }
        }

        private void btnSubAddNew_Click(object sender, EventArgs e)
        {
            if (btnSubAddNew.Text == "Add New")
            {
                //--Keep initial row num--\\
                rowNum = listView1.Items.Count;
                //--Change the button text--\\
                btnSubAddNew.Text = "Save";
                //--Clear TextBox and GroupBox--\\
                dbu.clearCntrl(this, "groupBox2", "TextBox,ComboBox");
                //--Change control property--\\
                btnSubEdit.Enabled = false;
                btnSubDelete.Enabled = false;

                //-Change groupbox2 control property--\\
                txtSubName.Enabled = true;
                txtSubDesc.Enabled = true;
                cmbSubmenuType.Enabled = true;
                cmbSubmenuType.Text = "F";
                cmbSubStatus.Enabled = true;
                cmbSubStatus.Text = "A";
                txtFormName.Enabled = true;
                populateParentSubMenu(txtMenuNo.Text.Trim(), subMenuNo);

                cmbParentSubMenu.Enabled = true;
                cmbParentSubMenu.Text = "<null>";
                txtSubMenuSerial.Enabled = true;
                
            }

            //--Come in when the button text is add--\\
            else
            {
                if (txtMenuNo.Text == "")
                {
                    MessageBox.Show("Menu ID field can not be blank");
                    txtMenuNo.Focus();
                    return;
                }
                else if (txtSubName.Text == "")
                {
                    MessageBox.Show("Submenu name field can not be blank");
                    txtSubName.Focus();
                    return;
                }
                /*else if (txtFormName.Text == "")
                {
                    MessageBox.Show("Form Name field can not be blank");
                    txtFormName.Focus();
                    return;
                }*/
                else
                {

                    bool found = true;
                    int p = 0;
                    while (p < listView1.Items.Count)
                    {
                        if (txtSubName.Text.Trim() == listView1.Items[p].SubItems[0].Text.Trim())
                        {
                            found = false;
                        }
                        p++;
                    }
                    if (found == true)
                    {
                        if (txtFormName.Text.Trim() != "")
                        {                        
                            p = 0;
                            while (p < listView1.Items.Count)
                            {
                                if (txtFormName.Text.Trim() == listView1.Items[p].SubItems[4].Text.Trim())
                                {
                                    found = false;
                                }
                                p++;
                            }
                        }
                        if (found == true)
                        {
                            //--Get the maximum submenu number in the database--\\
                            try
                            {
                                int submenuNo = Convert.ToInt32(DatabaseUtility.ExecuteScalar("select max(SUBMENU_NO) from USER_SUBMENU").ToString()) + 1;

                                //--save newly inserted submenu information--\\
                                
                                cmbParentSubMenuNo.SelectedIndex = cmbParentSubMenu.SelectedIndex;
                                
                                string parentNo;

                                if (cmbParentSubMenuNo.Text.Trim() == "<null>")
                                {
                                    parentNo = "";

                                }
                                else
                                {
                                    parentNo = cmbParentSubMenuNo.Text.Trim();
                                }

                                try
                                {
                                    int n = DatabaseUtility.ExecuteNonQuery("insert into USER_SUBMENU(SUBMENU_NO,MENU_NO,SUBMENU_NAME_USER,SUBMENU_TYPE,STATUS,DESCR,FORM_NAME,SUBMENU_LEVEL,PARENT_SUBMENU_NO,SL_NO) " +
                                            "values(@subMenuNo,@menuNo,@subMenuName,@subMenuType,@subMenuStatus,@subMenuDesc,@formName,@subMenuLevel,@parentSubMenuNo,@subMenuSL) ",
                                            new SqlParameter("subMenuNo", submenuNo),
                                            new SqlParameter("menuNo", txtMenuNo.Text.Trim()),
                                            new SqlParameter("subMenuName", txtSubName.Text.Trim()),
                                            new SqlParameter("subMenuType", cmbSubmenuType.Text),
                                            new SqlParameter("subMenuStatus", cmbSubStatus.Text),
                                            DatabaseUtility.checkEmpty("subMenuDesc", txtSubDesc.Text.Trim()),
                                            DatabaseUtility.checkEmpty("formName", txtFormName.Text.Trim()),
                                            new SqlParameter("subMenuLevel", getSubMenuLevel(parentNo)),
                                            DatabaseUtility.checkEmpty("parentSubMenuNo", parentNo),
                                            DatabaseUtility.checkEmpty("subMenuSL", txtSubMenuSerial.Text.Trim()));

                                    if (n == 1)
                                    {
                                        MessageBox.Show("Information added");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Information not added");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                                //listView1.Items.Clear();
                                treeMenu.Nodes.Clear();
                                loadMenu();
                                listView1.Items.Clear();
                                loadSubmenuInformation(txtMenuNo.Text.Trim());
                                dbu.clearCntrl(this, "groupBox2", "TextBox,ComboBox");
                                btnEdit.Enabled = true;
                                btnDelete.Enabled = true;
                                btnSubAddNew.Text = "Add New";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }

                            dbu.clearCntrl(this, "groupBox2", "TextBox,ComboBox");
                        }
                        else
                        {
                            MessageBox.Show("You cant add two form with same name");
                            txtFormName.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Submenu Name already taken.");
                        txtSubName.Focus();
                        return;
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--Change control property--\\
            btnSubEdit.Enabled = true;
            btnSubDelete.Enabled = true;
            btnSubAddNew.Enabled = true;
            btnSubAddNew.Text = "Add New";
            //-Change groupbox2 control property--\\
            txtSubName.Enabled = false;
            txtSubDesc.Enabled = false;
            cmbSubmenuType.Enabled = false;
            cmbSubStatus.Enabled = false;
            txtFormName.Enabled = false;
            txtSubMenuSerial.Enabled = false;
            cmbParentSubMenu.Enabled = false;

            //--Put the selected listView info to the text box for edit--\\
            ListView.SelectedListViewItemCollection breakfast = this.listView1.SelectedItems;
            foreach (ListViewItem item in breakfast)
            {
                //--get the lookupdtlId--\\
                //string sql6 = "select SUBMENU_NO from USER_SUBMENU where MENU_NO='" + txtMenuNo.Text.Trim() + "' and SUBMENU_NAME_USER='" + item.SubItems[0].Text.Trim() + "'";

                //DataTable dt6 = new DataTable();
                try
                {
                    
                    subMenuNo = item.SubItems[8].Text;
                    txtSubName.Text = item.SubItems[0].Text;
                    txtSubDesc.Text = item.SubItems[3].Text;
                    cmbSubmenuType.Text = item.SubItems[1].Text;
                    cmbSubStatus.Text = item.SubItems[2].Text;
                    txtFormName.Text = item.SubItems[4].Text;
                    txtSubMenuSerial.Text = item.SubItems[5].Text;
                    populateParentSubMenu(txtMenuNo.Text.Trim(), subMenuNo);
                    cmbParentSubMenu.Text = item.SubItems[9].Text;
                    //cmbParentSubMenu
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void populateParentSubMenu(string menuNo, string subMenuNo)
        {
            DataTable dt9;
            try
            {
                if (menuNo == "")
                {
                    dt9 = DatabaseUtility.ExecuteDataTable("select SUBMENU_NO, SUBMENU_NAME_USER from USER_SUBMENU where MENU_NO = @menuNo and STATUS = @subMenuStat",
                            new SqlParameter("menuNo", menuNo), new SqlParameter("subMenuStat", "A"));
                }
                else if (subMenuNo == "")
                {
                    dt9 = DatabaseUtility.ExecuteDataTable("select SUBMENU_NO, SUBMENU_NAME_USER from USER_SUBMENU where MENU_NO = @menuNo and STATUS = @subMenuStat",
                            new SqlParameter("menuNo", menuNo), new SqlParameter("subMenuStat", "A"));
                }
                else
                {
                    dt9 = DatabaseUtility.ExecuteDataTable("select SUBMENU_NO, SUBMENU_NAME_USER from USER_SUBMENU where MENU_NO = @menuNo and SUBMENU_NO <> @sunMenuNo and STATUS = @subMenuStat",
                            new SqlParameter("menuNo", menuNo), new SqlParameter("sunMenuNo", subMenuNo), new SqlParameter("subMenuStat", "A"));
                }

                int i = 0;
                cmbParentSubMenu.Items.Clear();
                cmbParentSubMenu.Items.Add("<null>");
                cmbParentSubMenuNo.Items.Add("<null>");
                while (i < dt9.Rows.Count)
                {
                    cmbParentSubMenu.Items.Add(dt9.Rows[i]["SUBMENU_NAME_USER"].ToString());
                    cmbParentSubMenuNo.Items.Add(dt9.Rows[i]["SUBMENU_NO"].ToString());
                    i++;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int getSubMenuLevel(string parentSubMenuNo)
        {
            int level = 0;

            if (parentSubMenuNo != "")
            {
                level = Convert.ToInt16(DatabaseUtility.ExecuteScalar("select SUBMENU_LEVEL from USER_SUBMENU where MENU_NO = @menuNo and SUBMENU_NO = @subMenuNo and STATUS = @subMenuStat",
                            new SqlParameter("menuNo", txtMenuNo.Text.Trim()), new SqlParameter("subMenuNo", parentSubMenuNo), new SqlParameter("subMenuStat", "A")).ToString()) + 1;
            }

            return level;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtMenuId.Enabled = true;
            }
            else
            {
                txtMenuId.Text = menuId;
                txtMenuId.Enabled = false;
            }
        }

        private void btnSubEdit_Click(object sender, EventArgs e)
        {
            if (btnSubEdit.Text == "Edit")
            {
                btnSubEdit.Text = "Ok";
                //-Change groupbox2 control property--\\
                txtSubName.Enabled = true;
                txtSubDesc.Enabled = true;
                cmbSubmenuType.Enabled = true;
                cmbSubStatus.Enabled = true;
                cmbParentSubMenu.Enabled = true;
                txtSubMenuSerial.Enabled = true;
                txtFormName.Enabled = false;
            }
            else
            {
                //--Check that modified Submenu name and ID are already in the database or not--\\
                DataTable dt14;
                try
                {
                    dt14 = DatabaseUtility.ExecuteDataTable("select * from USER_SUBMENU where MENU_NO = @menuNo and SUBMENU_NO <> @subMenuNo and SUBMENU_NAME_USER = @subMenuName",
                            new SqlParameter("menuNo", txtMenuNo.Text.Trim()), new SqlParameter("subMenuNo", subMenuNo), new SqlParameter("subMenuName", txtSubName.Text.Trim()));
                    if (dt14.Rows.Count == 0)
                    {
                        btnSubEdit.Text = "Edit";
                        cmbParentSubMenuNo.SelectedIndex = cmbParentSubMenu.SelectedIndex;
                        string parentNo;
                        int r = 0;
                        if (cmbParentSubMenuNo.Text.Trim() == "<null>")
                        {
                            parentNo = "";
                            
                        }
                        else
                        {
                            parentNo = cmbParentSubMenuNo.Text.Trim();
                        }

                        r = DatabaseUtility.ExecuteNonQuery("update USER_SUBMENU set " +
                                "SUBMENU_NAME_USER = @subMenuName, SUBMENU_TYPE = @subMenuType, STATUS = @subMenuStat, " +
                                "DESCR = @subMenuDesc, SL_NO = @subMenuSL, PARENT_SUBMENU_NO = @subMenuParentNo, SUBMENU_LEVEL = @subMenuLevel where SUBMENU_NO = @subMenuNo",
                                new SqlParameter("subMenuName", txtSubName.Text.Trim()),
                                new SqlParameter("subMenuType", cmbSubmenuType.Text.Trim()),
                                new SqlParameter("subMenuStat", cmbSubStatus.Text.Trim()),
                                DatabaseUtility.checkEmpty("subMenuDesc", txtSubDesc.Text.Trim()),
                                DatabaseUtility.checkEmpty("subMenuSL", txtSubMenuSerial.Text.Trim()),
                                DatabaseUtility.checkEmpty("subMenuParentNo", parentNo),
                                new SqlParameter("subMenuLevel", getSubMenuLevel(parentNo)),
                                new SqlParameter("subMenuNo", subMenuNo));
                                               
                        if (r == 1)
                        {
                            MessageBox.Show("Information saved successfully");
                            
                            treeMenu.Nodes.Clear();
                            loadMenu();
                            listView1.Items.Clear();
                            loadSubmenuInformation(txtMenuNo.Text.Trim());
                            dbu.clearCntrl(this, "groupBox2", "TextBox,ComboBox");
                            btnSubEdit.Enabled = false;
                            btnSubDelete.Enabled = false;
                            btnSubAddNew.Enabled = false;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Information not saved");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Submenu Name already exists");
                        txtSubName.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        
        public void deleteSubmenu()
        {
            //--code for delete menu information with the submenu together--\\
            DialogResult result;
            result = MessageBox.Show("Would you like to delete the selected item", "Clove Lakes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int n = DatabaseUtility.ExecuteNonQuery("delete from USER_SUBMENU where SUBMENU_NO = @subMenuNo",
                                    new SqlParameter("subMenuNo", subMenuNo));
                if (n == 1)
                {
                    MessageBox.Show("Information deleted");
                    dbu.clearCntrl(this, "groupBox2", "TextBox,ComboBox");
                    treeMenu.Nodes.Clear();
                    loadMenu();
                    listView1.Items.Clear();
                    loadSubmenuInformation(txtMenuNo.Text.Trim());
                    return;
                }
                else
                {
                    MessageBox.Show("Information not deleted");
                    return;
                }
            }
        }

        private void btnSubDelete_Click(object sender, EventArgs e)
        {
            deleteSubmenu();
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                deleteSubmenu();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

    }
}