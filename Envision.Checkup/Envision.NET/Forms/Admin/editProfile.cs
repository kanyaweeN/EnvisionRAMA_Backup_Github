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
    public partial class editProfile : Form
    {
        //Create the dbconnection instance
        DBUtility dbu = new DBUtility();
        dbConnection dc = new dbConnection();

        int userNo;
        public int userID
        {
            get
            {
                return userNo;
            }
            set
            {
                userNo = value;
            }
        }

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public editProfile(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
        }
        public editProfile()
        {
            InitializeComponent();
        }

        private void editProfile_Load(object sender, EventArgs e)
        {
            loadProfile();
        }

        public void loadProfile()
        {
            try
            {
                //Build the qyery
                string selQry = "select * from USER_INFORMATION where USER_NO='"+userNo+"'";
                DataTable profileTab = new DataTable();
                profileTab = dc.SelectDs(selQry);

                if (profileTab.Rows.Count != 0)
                {
                    //Put the information to the related field
                    txtUserId.Text = profileTab.Rows[0]["USER_ID"].ToString();
                    txtLastName.Text = profileTab.Rows[0]["LAST_NAME"].ToString();
                    txtFirstName.Text = profileTab.Rows[0]["FIRST_NAME"].ToString();
                    txtFather.Text = profileTab.Rows[0]["FATHER_NAME"].ToString();
                    txtMother.Text = profileTab.Rows[0]["MOTHER_NAME"].ToString();
                    txtDesig.Text = profileTab.Rows[0]["DESIGNATION"].ToString();
                    txtAddress.Text = profileTab.Rows[0]["ADDRESS"].ToString();
                    txtPhone.Text = profileTab.Rows[0]["PHONE"].ToString();
                    txtEmail.Text = profileTab.Rows[0]["EMAIL"].ToString();
                    cmbGender.Text = profileTab.Rows[0]["GENDER"].ToString();
                    dtpDOB.Text = profileTab.Rows[0]["DOB"].ToString();
                    txtDOJ.Text = Convert.ToDateTime(profileTab.Rows[0]["DOJ"].ToString()).ToShortDateString();
                    txtStatus.Text = profileTab.Rows[0]["STATUS"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkChangePass_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkChangePass.Checked)
                {
                    txtOldPass.ReadOnly = false;
                    txtNewPass.ReadOnly = false;
                    txtConPass.ReadOnly = false;
                }
                else
                {
                    txtOldPass.ReadOnly = true;
                    txtNewPass.ReadOnly = true;
                    txtConPass.ReadOnly = true;
                    txtOldPass.Text = "";
                    txtNewPass.Text = "";
                    txtConPass.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation checking
                if (txtLastName.Text.Trim() == "")
                {
                    MessageBox.Show("Please insert your last name properly");
                    txtLastName.Focus();
                    return;
                }
                if (txtFirstName.Text.Trim() == "")
                {
                    MessageBox.Show("Please insert your first name properly");
                    txtFirstName.Focus();
                    return;
                }

                //Update information
                //Build the update query
                string updQuery = "update USER_INFORMATION set "+
                                             " LAST_NAME='"+txtLastName.Text.Trim()+"', "+
                                             " FIRST_NAME='" + txtFirstName.Text.Trim() + "', "+
                                             " FATHER_NAME='" + txtFather.Text.Trim() + "', "+
                                             " MOTHER_NAME='" + txtMother.Text.Trim() + "', "+
                                             " ADDRESS='" + txtAddress.Text.Trim() + "', "+
                                             " PHONE='" + txtPhone.Text.Trim() + "', "+
                                             " EMAIL='" + txtEmail.Text.Trim() + "', "+
                                             " GENDER='" + cmbGender.Text.Trim() + "', "+
                                             " DOB='" + dtpDOB.Text.Trim() + "'" +
                                             " where user_no='"+userNo+"'";
                //Execute the update query
                dc.UpdateDataBase(updQuery);

                //Change password if the checkbox is checked
                if (chkChangePass.Checked)
                {
                    //check that all necessary information are given
                    if ((txtOldPass.Text.Trim() == "") || (txtNewPass.Text.Trim() == "") || (txtConPass.Text.Trim() == ""))
                    {
                        MessageBox.Show("Please insert all three field properly to change your existing password");
                        return;
                    }
                    else
                    {
                        //check the old password given is correct or not
                        string selQry = "select * from USER_INFORMATION where user_no='" + userNo + "' and PWD='"+txtOldPass.Text.Trim()+"'";
                        DataTable passCheckTab = new DataTable();
                        passCheckTab = dc.SelectDs(selQry);
                        //Check any row found or not
                        if (passCheckTab.Rows.Count == 0)
                        {
                            MessageBox.Show("Given old password is not correct");
                            txtOldPass.Text = "";
                            return;
                        }
                        else
                        {
                            //Check the given two new and cofirm password is same or not
                            if (txtNewPass.Text.Trim() == txtConPass.Text.Trim())
                            {
                                //Update the new password for this user
                                string updQuery1 ="update USER_INFORMATION set " +
                                                            " PWD='" + txtNewPass.Text.Trim() + "'" +
                                                            " where user_no='" + userNo + "'";
                                //execute the update query
                                dc.UpdateDataBase(updQuery1);
                            }
                            else
                            {
                                MessageBox.Show("Your given new password and confirm password anr not matching");
                                txtNewPass.Text = "";
                                txtConPass.Text = "";
                                return;
                            }
                        }
                    }
                }

                MessageBox.Show("Information update successfully");
            }
            catch (Exception ex)
            {
                throw ex;     
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }
    }
}