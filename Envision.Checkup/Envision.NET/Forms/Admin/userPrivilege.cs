using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UUL.ControlFrame.Controls;
using RIS.Common.DBConnection;
using RIS.Common.UtilityClass;


namespace RIS.Forms.Admin
{
    public partial class userPrivilege : Form
    {
        //--Create object of dbConnection class for database interaction--\\
        dbConnection dc = new dbConnection();
        //--Create object of clearControl class to clear text and comboBox--\\
        DBUtility cc = new DBUtility();
       
        displayForm dspFrm = new displayForm();


        //--Variable for keep the selected employee's number--\\
        int empNumber = 0;
        
        private UUL.ControlFrame.Controls.TabControl CloseControl;
       
        public userPrivilege(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
        }

        //public userPrivilege()
        //{
        //    InitializeComponent();
        //    //UUL.ControlFrame.Controls.TabControl clsCtl = new UUL.ControlFrame.Controls.TabControl();
        //    //CloseControl = clsCtl;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            cc.CloseFrom(CloseControl, this);
            ////dspFrm.CloseFrom(this);
            ////CloseControl = dspFrm.test;
            //mainForm mf = new mainForm();
            //mf.CloseFrom(this);
        }

        private void SA_1009_Load(object sender, EventArgs e)
        {
            loadEmployeeInfo("");
            //loadMenuSubmenu();
        }

        public void loadEmployeeInfo(string lastName)
        {
            try
            {
                string sql3;
                if (lastName.ToString() == "")
                {
                    sql3 = "select *from USER_INFORMATION order by LAST_NAME";
                }
                else
                {
                    sql3 = "select *from USER_INFORMATION where LAST_NAME like '%" + txtSearch.Text.Trim() + "%' order by LAST_NAME";
                }
                DataTable dt3 = new DataTable();
                dt3 = dc.SelectDs(sql3);

                if (dt3.Rows.Count == 0)
                {
                    //treeView1.Nodes.Add("No user information found");
                    //treeView1.Nodes[0].ImageIndex = 0;
                }
                else
                {
                    treeView2.Nodes.Add("Employee List");
                    int k = 0;
                    while (k < dt3.Rows.Count)
                    {
                        TreeNode newNode3 = new TreeNode(dt3.Rows[k]["USER_ID"].ToString() + ":   " + dt3.Rows[k]["FIRST_NAME"].ToString() + " " + dt3.Rows[k]["LAST_NAME"].ToString());
                        newNode3.Tag = dt3.Rows[k]["USER_NO"].ToString();
                        treeView2.Nodes[0].Nodes.Add(newNode3);
                        k++;
                    }
                }

                treeView2.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public void loadMenuSubmenu(int empNo)
        {
            try
            {
                treeView1.Nodes.Clear();
                //--Select all the menu from the menu table--\\
                string sql = "select *from USER_MENU where STATUS='A'";
                DataTable dt = new DataTable();
                dt = dc.SelectDs(sql);

                int i = 0;
                while (i < dt.Rows.Count)
                {
                    //--Add the menu name to the tree node--\\
                    TreeNode newNode = new TreeNode(dt.Rows[i]["MENU_NAME"].ToString());
                    newNode.Tag = dt.Rows[i]["MENU_NO"].ToString();
                    newNode.ForeColor = System.Drawing.Color.Chocolate;

                    treeView1.Nodes.Add(newNode);

                    //-Check that user previlize is already set set for this user or not
                    string sql6 = "SELECT *from USER_PRIVILEGE where USER_NO = '" + empNo + "'";
                    DataTable dt6 = new DataTable();
                    dt6 = dc.SelectDs(sql6);

                    
                        //--Find the submenu for this menu
                    string sql1 = "select *from USER_SUBMENU where MENU_NO='" + Convert.ToInt32(dt.Rows[i]["MENU_NO"]) + "' and status='A' and (submenu_type='F' or submenu_type='R')";
                        DataTable dt1 = new DataTable();
                        dt1 = dc.SelectDs(sql1);

                        int b = 0;
                        while (b < dt1.Rows.Count)
                        {
                            TreeNode newNode1 = new TreeNode(dt1.Rows[b]["SUBMENU_NAME_USER"].ToString());
                            newNode1.Tag = dt1.Rows[b]["SUBMENU_NO"].ToString();
                            if (dt6.Rows.Count == 0)   //--Previlize not set previously
                            {
                                newNode1.Checked = false;
                            }
                            else
                            {
                                string sql7 = "select FR_STATUS from USER_PRIVILEGE where FR_NO='" + Convert.ToInt32(dt1.Rows[b]["SUBMENU_NO"].ToString()) + "' and USER_NO = '" + empNo + "'";
                                DataTable dt7 = new DataTable();
                                dt7 = dc.SelectDs(sql7);
                                if (dt7.Rows.Count != 0)
                                {
                                    if (dt7.Rows[0]["FR_STATUS"].ToString().Trim() == "A")
                                    {
                                        newNode1.Checked = true;
                                    }
                                    else
                                    {
                                        newNode1.Checked = false;
                                    }
                                }
                                else
                                {
                                    newNode1.Checked = false;
                                }
                            }

                            treeView1.Nodes[i].Nodes.Add(newNode1);
                            b++;
                        }
                    
                    i++;
                }
                //treeView1.ExpandAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.LastNode == null)
                {
                }
                else
                {
                    if (treeView1.SelectedNode.Checked)
                    {
                        int temp = 0;
                        int ind = treeView1.SelectedNode.Index;
                        while (temp < treeView1.Nodes[ind].Nodes.Count)
                        {
                            treeView1.Nodes[ind].Nodes[temp].Checked = true;
                            temp++;
                        }
                    }
                    else
                    {
                        int temp = 0;
                        int ind = treeView1.SelectedNode.Index;
                        while (temp < treeView1.Nodes[ind].Nodes.Count)
                        {
                            treeView1.Nodes[ind].Nodes[temp].Checked = false;
                            temp++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //--Search for user--\\
            treeView2.Nodes.Clear();
            loadEmployeeInfo("" + txtSearch.Text + "");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            //--Show all the employee list--\\
            treeView2.Nodes.Clear();
            loadEmployeeInfo("");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.LastNode == null)
                {
                    empNumber = Convert.ToInt32(treeView2.SelectedNode.Tag.ToString());
                    loadMenuSubmenu(empNumber);
                }
                else
                {
                    empNumber = 0;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (empNumber == 0)
                {
                    MessageBox.Show("Currently no employee is selected !!!");
                    return;
                }

                //--Save/Update user previlege information
                //--Delete previously given information
                string sql4 = "delete from USER_PRIVILEGE where USER_NO='" + empNumber + "'";
                //DataTable dt4 = new DataTable();
                //dt4 = dc.SelectDs(sql4);
                dc.UpdateDataBase(sql4);

                //--Not created previously
                int x = 0;
                while (x < treeView1.Nodes.Count)
                {
                    int y = 0;
                    while (y < treeView1.Nodes[x].Nodes.Count)
                    {
                        string stat = "I";
                        if (treeView1.Nodes[x].Nodes[y].Checked)
                        {
                            stat = "A";
                        }
                        string sql5 = "insert into USER_PRIVILEGE(USERPRV_NO,USER_NO,FR_NO,FR_TYPE,FR_STATUS) " +
                                            "values('" + cc.createMaxNumber("USER_PRIVILEGE", "USERPRV_NO") + "','" + empNumber + "'," +
                                            "'" + Convert.ToInt32(treeView1.Nodes[x].Nodes[y].Tag.ToString()) + "'," +
                                            "'','" + stat + "')";
                        dc.UpdateDataBase(sql5);
                        y++;
                    }
                    x++;
                }

                MessageBox.Show("Information has been saved/updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

    }
}