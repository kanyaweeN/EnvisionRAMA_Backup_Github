using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common.UtilityClass;
using RIS.Common.DBConnection;
using UUL.ControlFrame.Controls;


namespace RIS.Forms.Admin
{
    public partial class employeeInformation : Form
    {
        ////--Create object for setProperty class--\\
        //setFormProperty sfp = new setFormProperty();
        
        //--Create object of dbConnection class for database interaction--\\
        dbConnection dc = new dbConnection();
        //--Create object of dbConnection class for database interaction--\\
        DBUtility dbu = new DBUtility();

        ////--Create object of clearControl class to clear text and comboBox--\\
        //clearControl cc = new clearControl();
        ////--Create object of errorMsg class to return default project message--\\
        //errorMsg em = new errorMsg();


        string userID;
        int userNo;

        private UUL.ControlFrame.Controls.TabControl CloseControl;

        public employeeInformation(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
        }

        private void PM_1019_Load(object sender, EventArgs e)
        {
            ////--Set the form property by calling class setFormProperty--\\
            //sfp.setFormPro(this);

            //--Load user information tree--\\
            loadTree("");
        }
        public void loadTree(string lastName)
        {
            try
            {
                string sql;
                if (lastName.ToString() == "")
                {
                    sql = "select *from USER_INFORMATION order by LAST_NAME";
                }
                else
                {
                    sql = "select *from USER_INFORMATION where LAST_NAME like '%" + txtSearch.Text.Trim() + "%' order by LAST_NAME";
                }
                DataTable dt = new DataTable();
                dt = dc.SelectDs(sql);

                treeView1.ImageList = imageList1;
                if (dt.Rows.Count == 0)
                {
                    //treeView1.Nodes.Add("No user information found");
                    //treeView1.Nodes[0].ImageIndex = 0;
                }
                else
                {
                    treeView1.Nodes.Add("Employee List");
                    treeView1.Nodes[0].ImageIndex = 0;
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        TreeNode newNode = new TreeNode(dt.Rows[i]["FIRST_NAME"].ToString() + " " + dt.Rows[i]["LAST_NAME"].ToString());
                        newNode.Tag = dt.Rows[i]["USER_NO"].ToString();
                        newNode.ImageIndex = 1;
                        treeView1.Nodes[0].Nodes.Add(newNode);
                        i++;
                    }
                }

                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        public void createUserNo()
        {
            //--Pick the max User No --\\

            string sql2 = "select max(USER_NO) from USER_INFORMATION";
            DataTable dt2 = new DataTable();
            dt2 = dc.SelectDs(sql2);
            if (dt2.Rows[0][0].ToString() == "")
            {
                userNo = 1;
                txtUserNo.Text = userNo.ToString();
            }
            else
            {
                userNo = Convert.ToInt32(dt2.Rows[0][0].ToString());
                userNo++;
                txtUserNo.Text = userNo.ToString();
            }
        }

        public void createUserID()
        {
            //--Create User ID--\\
            //--Create month value of two character--\\
            string mnth;
            int mnth1 = Convert.ToInt32(dtpDOB.Value.Month.ToString());
            if (mnth1 < 10)
            {
                mnth = "0" + mnth1.ToString() + "";
            }
            else
            {
                mnth = dtpDOB.Value.Month.ToString();
            }
            //--Create year value of two character--\\
            string yr = dtpDOB.Value.Year.ToString().Substring(2, 2);

            //--Finally make the User id( U-yy-mm-01 )--\\
            int srl = 1;
            for (; ; srl++)
            {
                if (srl > 9)
                {
                    userID = "U" + yr + "" + mnth + "" + srl + "";
                }
                else
                {
                    userID = "U" + yr + "" + mnth + "0" + srl + "";
                }
                
                //--Check that the Id has been made is present in the database or not--\\
                string sql1 = "select USER_ID from USER_INFORMATION where USER_ID='" + userID + "'";
                DataTable dt1 = new DataTable();
                dt1 = dc.SelectDs(sql1);
                if (dt1.Rows.Count == 0)
                {
                    break;
                }
            }
            
            txtUserId.Text = userID;
        }
        
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAddNew.Text == "Add New")
                {
                    dbu.clearCntrl(this, "groupBox1", "TextBox,ComboBox");
                    dtpDOB.ResetText();
                    dtpDOJ.ResetText();
                    
                    //--Change Control Property--\\
                    txtLastName.ReadOnly = false;
                    txtFirstName.ReadOnly = false;
                    txtFather.ReadOnly = false;
                    txtMother.ReadOnly = false;
                    txtDesig.ReadOnly = false;
                    txtAddress.ReadOnly = false;
                    txtPhone.ReadOnly = false;
                    txtEmail.ReadOnly = false;
                    cmbGender.Enabled = true;
                    dtpDOB.Enabled = true;
                    dtpDOJ.Enabled = true;
                    //txtPlantInspected.Enabled = true;
                    cmbStatus.Enabled = true;

                    btnAddNew.Text = "Save";
                    btnAddNew.Enabled = true;
                    btnEdit.Text = "Edit";
                    btnEdit.Enabled = false;
                    //--Clear control--\\
                    
                    createUserID();
                    createUserNo();
                }
                else
                {
                    //--Check validation--\\
                    if (txtLastName.Text == "")
                    {
                        //MessageBox.Show("Last Name " + em.msgRet(5).ToString());
                        txtLastName.Focus();
                        return;
                    }
                    if (txtFirstName.Text == "")
                    {
                        //MessageBox.Show("First Name " + em.msgRet(5).ToString());
                        txtFirstName.Focus();
                        return;
                    }
                    if (txtDesig.Text == "")
                    {
                        //MessageBox.Show("Designation " + em.msgRet(5).ToString());
                        txtDesig.Focus();
                        return;
                    }
                    if (cmbStatus.Text == "")
                    {
                        //MessageBox.Show("Status " + em.msgRet(5).ToString());
                        cmbStatus.Focus();
                        return;
                    }


                    //--Save new user information--\\
                    string sql3 = "insert into USER_INFORMATION(USER_NO,USER_ID,LAST_NAME,FIRST_NAME,FATHER_NAME,MOTHER_NAME"+
                                        ",DESIGNATION,ADDRESS,PHONE,EMAIL,GENDER,DOB,DOJ,STATUS,pwd,oldpwd)"+
                                        " values('" + userNo + "','" + userID + "','" + txtLastName.Text + "'," +
                                        "'"+txtFirstName.Text+"','"+txtFather.Text+"','"+txtMother.Text+"','"+txtDesig.Text+"',"+
                                        "'"+txtAddress.Text+"','"+txtPhone.Text+"','"+txtEmail.Text+"','"+cmbGender.Text+"',"+
                                        "'" + dtpDOB.Text + "','" + dtpDOJ.Text + "','" + cmbStatus.Text.Substring(0, 1) + "','" + userID + "','" + userID + "')";
                   int i = 0;
                    i = dc.UpdateDataBase(sql3);
                    if (i == 0)
                    {
                        //MessageBox.Show(em.msgRet(2).ToString());
                        return;
                    }
                    else
                    {
                        //MessageBox.Show(em.msgRet(1).ToString());
                        treeView1.Nodes.Clear();
                        loadTree("");

                        //--Change Control Property--\\
                        txtLastName.ReadOnly = true;
                        txtFirstName.ReadOnly = true;
                        txtFather.ReadOnly = true;
                        txtMother.ReadOnly = true;
                        txtDesig.ReadOnly = true;
                        txtAddress.ReadOnly = true;
                        txtPhone.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        cmbGender.Enabled = false;
                        dtpDOB.Enabled = false;
                        dtpDOJ.Enabled = false;
                        //txtPlantInspected.Enabled = false;
                        cmbStatus.Enabled = false;

                        btnAddNew.Text = "Add New";
                        btnAddNew.Enabled = true;
                        btnEdit.Text = "Edit";
                        btnEdit.Enabled = true;

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
            treeView1.Nodes.Clear();
            loadTree(""+txtSearch.Text+"");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            //--Show all the employee list--\\
            treeView1.Nodes.Clear();
            loadTree("");
        }

        public void loadUserDetail(string un)
        {
            try
            {
                string sql4 = "select *from USER_INFORMATION where USER_NO='"+Convert.ToInt32(un.ToString())+"'";
                DataTable dt4 = new DataTable();
                dt4 = dc.SelectDs(sql4);

                //--Put value to the related field--\\
                txtUserNo.Text = dt4.Rows[0]["USER_NO"].ToString();
                txtUserId.Text = dt4.Rows[0]["USER_ID"].ToString();
                txtLastName.Text = dt4.Rows[0]["LAST_NAME"].ToString();
                txtFirstName.Text = dt4.Rows[0]["FIRST_NAME"].ToString();
                txtFather.Text = dt4.Rows[0]["FATHER_NAME"].ToString();
                txtMother.Text = dt4.Rows[0]["MOTHER_NAME"].ToString();
                txtDesig.Text = dt4.Rows[0]["DESIGNATION"].ToString();
                txtAddress.Text = dt4.Rows[0]["ADDRESS"].ToString();
                txtPhone.Text = dt4.Rows[0]["PHONE"].ToString();
                txtEmail.Text = dt4.Rows[0]["EMAIL"].ToString();
                cmbGender.Text = dt4.Rows[0]["GENDER"].ToString();
                dtpDOB.Text = dt4.Rows[0]["DOB"].ToString();
                dtpDOJ.Text = dt4.Rows[0]["DOJ"].ToString();
                //txtPlantInspected.Text = dt4.Rows[0]["PLANT_INPECTED"].ToString();
                if (dt4.Rows[0]["STATUS"].ToString() == "A")
                {
                    cmbStatus.Text = "Active";
                }
                else
                {
                    cmbStatus.Text = "Inactive";
                }
            }
            catch (Exception ex)
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
                    //--Change Control Property--\\
                    txtLastName.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtFather.ReadOnly = true;
                    txtMother.ReadOnly = true;
                    txtDesig.ReadOnly = true;
                    txtAddress.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    cmbGender.Enabled = false;
                    dtpDOB.Enabled = false;
                    dtpDOJ.Enabled = false;
                    //txtPlantInspected.Enabled = false;
                    cmbStatus.Enabled = false;

                    btnAddNew.Text = "Add New";
                    btnAddNew.Enabled = true;
                    btnEdit.Text = "Edit";
                    btnEdit.Enabled = true;

                    loadUserDetail(treeView1.SelectedNode.Tag.ToString());
                }
                else
                {
                    MessageBox.Show("No employee in the list");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEdit.Text == "Edit")
                {
                    //--Change Control Property--\\
                    txtLastName.ReadOnly = false;
                    txtFirstName.ReadOnly = false;
                    txtFather.ReadOnly = false;
                    txtMother.ReadOnly = false;
                    txtDesig.ReadOnly = false;
                    txtAddress.ReadOnly = false;
                    txtPhone.ReadOnly = false;
                    txtEmail.ReadOnly = false;
                    cmbGender.Enabled = true;
                    dtpDOB.Enabled = true;
                    dtpDOJ.Enabled = true;
                    cmbStatus.Enabled = true;

                    btnAddNew.Text = "Add New";
                    btnAddNew.Enabled = true;
                    btnEdit.Text = "Ok";
                    btnEdit.Enabled = true;
                }
                else
                {
                    //--Active when the button text=OK--\\
                    //--Check validation--\\
                    if (txtLastName.Text == "")
                    {
                        //MessageBox.Show("Last Name " + em.msgRet(5).ToString());
                        txtLastName.Focus();
                        return;
                    }
                    if (txtFirstName.Text == "")
                    {
                        //MessageBox.Show("First Name " + em.msgRet(5).ToString());
                        txtFirstName.Focus();
                        return;
                    }
                    if (txtDesig.Text == "")
                    {
                        //MessageBox.Show("Designation " + em.msgRet(5).ToString());
                        txtDesig.Focus();
                        return;
                    }
                    if (cmbStatus.Text == "")
                    {
                        //MessageBox.Show("Status " + em.msgRet(5).ToString());
                        cmbStatus.Focus();
                        return;
                    }

                    //--Update information--\\
                    string sql5 = "update USER_INFORMATION set LAST_NAME='"+txtLastName.Text+"',FIRST_NAME='"+txtFirstName.Text+"',"+
                                        "FATHER_NAME='"+txtFather.Text+"',MOTHER_NAME='"+txtMother.Text+"'" +
                                        ",DESIGNATION='"+txtDesig.Text+"',ADDRESS='"+txtAddress.Text+"',PHONE='"+txtPhone.Text+"',"+
                                        "EMAIL='"+txtEmail.Text+"',GENDER='"+cmbGender.Text+"',DOB='"+dtpDOB.Text+"',"+
                                        "DOJ='"+dtpDOJ.Text+"',STATUS='"+cmbStatus.Text.Substring(0,1)+"' "+
                                        "where USER_NO='"+Convert.ToInt32(txtUserNo.Text.Trim())+"'";
                    int m = 0;
                    m = dc.UpdateDataBase(sql5);
                    if (m == 0)
                    {
                        //MessageBox.Show(em.msgRet(4).ToString());
                        return;
                    }
                    else
                    {
                        //MessageBox.Show(em.msgRet(3).ToString());

                        //--Change Control Property--\\
                        txtLastName.ReadOnly = true;
                        txtFirstName.ReadOnly = true;
                        txtFather.ReadOnly = true;
                        txtMother.ReadOnly = true;
                        txtDesig.ReadOnly = true;
                        txtAddress.ReadOnly = true;
                        txtPhone.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        cmbGender.Enabled = false;
                        dtpDOB.Enabled = false;
                        dtpDOJ.Enabled = false;
                        cmbStatus.Enabled = false;

                        btnAddNew.Text = "Add New";
                        btnAddNew.Enabled = true;
                        btnEdit.Text = "Edit";
                        btnEdit.Enabled = true;

                        treeView1.Nodes.Clear();
                        loadTree("");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        //private void btnChangePass_Click(object sender, EventArgs e)
        //{
        //    if ((txtOldPass.Text == "") || (txtNewPass.Text == "") || (txtConfirmPass.Text == ""))
        //    {
        //        MessageBox.Show("Please insert all required field to change the password");
        //        return;
        //    }
        //    else
        //    {
        //        //check that the given old passwor is right or wrong        
        //        string sql6 = "select pwd from USER_INFORMATION where user_no='" + Convert.ToInt32(txtUserNo.Text.Trim()) + "'";
        //        DataTable pwdTab = new DataTable();
        //        pwdTab = dc.SelectDs(sql6);

        //        if (pwdTab.Rows[0]["pwd"].ToString() != txtOldPass.Text.Trim())
        //        {
        //            MessageBox.Show("Your given old password is wrong");
        //            txtOldPass.Focus();
        //            return;
        //        }
        //        else
        //        {
        //            //check that the given two new password is same r not
        //            if (txtNewPass.Text.Trim() != txtConfirmPass.Text.Trim())
        //            {
        //                MessageBox.Show("Your given two new password is not matching");
        //                txtNewPass.Focus();
        //                return;
        //            }
        //            else
        //            {
        //                //Update the change password
        //                dc.UpdateDataBase("update USER_INFORMATION set pwd='"+txtNewPass.Text.Trim()+"' where user_no='" + Convert.ToInt32(txtUserNo.Text.Trim()) + "'");
        //                MessageBox.Show("Your password has been updated successfully");
        //                txtOldPass.Text = "";
        //                txtNewPass.Text = "";
        //                txtConfirmPass.Text = "";
        //            }
        //        }
        //    }
        //}

    
    }
}