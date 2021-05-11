using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using RIS.Common.DBConnection;

namespace RIS.Common.UtilityClass
{
     class DBUtility
    {
        //create object of dbconnection class
        dbConnection dc = new dbConnection();



         //This will create the maximum nuber of the selected 
        public int createMaxNumber(string tabName, string fldName)
        {
            string sql = "select max(" + fldName + ") from " + tabName + "";
            DataTable dt = new DataTable();
            dt = dc.SelectDs(sql);
            if (dt.Rows[0][0].ToString() == "")
            {
                return 1;
            }
            else
            {
                int temp = Convert.ToInt32(dt.Rows[0][0].ToString());
                temp++;
                return temp;
            }
        }
        
        //This class will clear TextBox and ComboBox control's text under a specific panel/group
        public void clearCntrl(Form frmName, string cntrlName, string cntrlType)
        {
            string[] arr = cntrlName.Split(new Char[] { ',' });
            string[] arr1 = cntrlType.Split(new Char[] { ',' });

            int k = 0;
            while (k < arr.Length)
            {
                try
                {
                    int i = 0;
                    while (i < frmName.Controls.Count)
                    {
                        if (frmName.Controls[i].Name.ToString() == arr[k].ToString())
                        {
                            int j = 0;
                            while (j < frmName.Controls[i].Controls.Count)
                            {
                                int l = 0;
                                while (l < arr1.Length)
                                {
                                    if (frmName.Controls[i].Controls[j].GetType().Name.ToString() == arr1[l].ToString())
                                    {
                                        frmName.Controls[i].Controls[j].Text = "";
                                    }
                                    l++;
                                }
                                j++;
                            }
                        }
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                k++;
            }
        }

        //For clear text box  under a specific panel/groupbox
        public void ClearTextBox(Control cnt)
        {
            int i = 0;
            while (i < cnt.Controls.Count)
            {
                if (cnt.Controls[i].GetType().Name.ToString() == "TextBox")
                    cnt.Controls[i].Text = "";

                // Call recursively
                ClearTextBox(cnt.Controls[i]);
                i++;
            }
        }

        ////Create and return the maximum number for a database table field
        //public int createMaxNumber(string tabName, string fldName)
        //{
        //    string sql = "select max(" + fldName + ") from " + tabName + "";
        //    DataTable dt = new DataTable();
        //    dt = dc.Table(sql);
        //    if (dt.Rows[0][0].ToString() == "")
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        int temp = Convert.ToInt32(dt.Rows[0][0].ToString());
        //        temp++;
        //        return temp;
        //    }
        //}

        //Remove comma from a duoblu value
        public string removeComma(string str)
        {
            if (str == "") return "0";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ',')
                    str = str.Remove(i, 1);
            }
            return str;
        }

        //Remove the single cotetion from a string
        public string sCote(string str)
        {
            //newString for save the new string after replacing single cotetion
            string newString = "";

            //i for indexing the string got from parameter and loop for making thi newString
            //accessing every character in str
            int i = 0;
            while (i < str.Length)
            {
                if (str[i].ToString() == "'")
                {
                    //Perform when the position of single cotetion is in the begening of the string
                    if (i == 0)
                    {
                        int temp1 = i;
                        while (str[temp1].ToString() == "'")
                        {
                            temp1++;
                            i++;
                            if (temp1 == str.Length)
                                break;
                        }
                    }

                    //Perform when the position of single cotetion is in the ending of the string
                    else if (i + 1 == str.Length)
                    {
                        i++;
                    }

                    //Perform when the position of single cotetion is in the middle of the string
                    else
                    {
                        int temp = i;
                        while (str[temp].ToString() == "'")
                        {
                            temp++;
                            i++;
                            if (temp == str.Length)
                                break;

                        }
                        if (i == str.Length)
                        {
                            break;
                        }
                        else
                        {
                            if (str[i].ToString() != "")
                            {
                                newString = newString + "''";
                            }
                        }
                    }
                }
                else
                {
                    newString = newString + "" + str[i] + "";
                    i++;
                }
            }
            //returning the generated string from the string passed thrugh the parameter frm other function
            return newString;

        }


        #region for show the form in the container
        public void DisplayForm(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rDisplayForm, string formName)
        {
            System.Windows.Forms.Form rDisplay;
            UUL.ControlFrame.Controls.TabPage page;
            rDisplayForm.Text = formName;
            rDisplay = rDisplayForm;       //--Set text
            setFormProperty(rDisplayForm);
            //page = new UUL.ControlFrame.Controls.TabPage(rDisplayForm.Text, rDisplayForm, rDisplayForm.Icon);
            page = new UUL.ControlFrame.Controls.TabPage(rDisplay.Text, rDisplay);
            page.Selected = true;
            rTabControl.TabPages.Add(page);
        }

        public void DisplayForm(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rDisplayForm)
        {
            try
            {
                System.Windows.Forms.Form rDisplay;
                UUL.ControlFrame.Controls.TabPage page;
                rDisplay = setText(rDisplayForm);       //--Set text
                page = new UUL.ControlFrame.Controls.TabPage(rDisplay.Text, rDisplay);
                page.Selected = true;
                rTabControl.TabPages.Add(page);
            }
            catch (Exception Err)
            {
                throw Err;
            }
        }
        public void DisplayForm( System.Windows.Forms.Form rDisplayForm)
        {
            try
            {
                rDisplayForm.StartPosition = FormStartPosition.CenterScreen;
                rDisplayForm.ShowDialog();
            }
            catch (Exception Err)
            {
                throw Err;
            }
        }

        public void CloseFrom(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rCloseForm)
        {
            rCloseForm.Close();
            rTabControl.TabPages.Remove(rTabControl.SelectedTab);

        }

        private System.Windows.Forms.Form setText(System.Windows.Forms.Form rDisplayForm)
        {
            if ((rDisplayForm.GetType().Name.ToString().Trim()) != "ReportViewer")
            {
                string sql = "select SUBMENU_NAME_USER from USER_SUBMENU where FORM_NAME='" + rDisplayForm.Name  + "'";
                DataTable dt = new DataTable();
                dt = dc.SelectDs(sql);
                rDisplayForm.Text = dt.Rows[0]["SUBMENU_NAME_USER"].ToString();

            }
            return rDisplayForm;
        }

        private void setFormProperty(Form displayForm)
        {
            try
            {
                //displayForm.Font = new System.Drawing.Font("verdana", 10);
                System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0x98, /* G */ 0xB8, /* B */ 0xE2);
                //displayForm.BackColor = System.Drawing.Color.Red;
                displayForm.BackColor = c;
                displayForm.MaximizeBox = false;
                displayForm.MinimizeBox = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public DataTable ComboValue(int SearchValue)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DataKey", SearchValue));

                return dc.DBControl.SPExecute("sp_RetriveDataforCombo", cmd);
            }
            catch (Exception Err)
            {
                throw Err;
            }
        }
        public void ComboValue(int SearchValue, ComboBox refCombo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DataKey", SearchValue));

                DataTable dt = dc.DBControl.SPExecute("sp_RetriveDataforCombo", cmd);
                refCombo.DataSource = dt;
                refCombo.DisplayMember = dt.Columns[0].ColumnName;
                refCombo.ValueMember = dt.Columns[1].ColumnName;
            }
            catch (Exception Err)
            {
                throw Err;
            }
        }
        public void ComboValue(int SearchValue,ComboBox refCombo,Boolean NullAdd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DataKey", SearchValue));

                DataTable dt = dc.DBControl.SPExecute("sp_RetriveDataforCombo", cmd);

                DataRow row = dt.NewRow();
            if(dt.Columns[0].DataType.FullName.ToString()=="System.Double")
                    row[0] =Convert.ToDouble("");else row[0] = "";
                
                row[1] = "";
                dt.Rows.InsertAt(row, 0);

                refCombo.DataSource = dt;
               
                    refCombo.DisplayMember = dt.Columns[0].ColumnName;
                    refCombo.ValueMember = dt.Columns[1].ColumnName;
              
            }
            catch (Exception Err)
            {
                throw Err;
            }
        }
        public void ComboValue(int SearchValue, System.Windows.Forms.DataGridViewComboBoxColumn refCombo, Boolean NullAdd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DataKey", SearchValue));

                DataTable dt = dc.DBControl.SPExecute("sp_RetriveDataforCombo", cmd);

                DataRow row = dt.NewRow();
                if (dt.Columns[0].DataType.FullName.ToString() == "System.Double")
                    row[0] = Convert.ToDouble("");
                else row[0] = "";

                row[1] = "";
                dt.Rows.InsertAt(row, 0);

                refCombo.DataSource = dt;

                refCombo.DisplayMember = dt.Columns[0].ColumnName;
                refCombo.ValueMember = dt.Columns[1].ColumnName;

            }
            catch (Exception Err)
            {
                throw Err;
            }
        }
        public void ComboValueDisplay(int SearchValue, ComboBox refCombo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DataKey", SearchValue));

                DataTable dt = dc.DBControl.SPExecute("sp_RetriveDataforCombo", cmd);

                DataRow row = dt.NewRow();
                if (dt.Columns[0].DataType.FullName.ToString() == "System.Double")
                    row[0] = Convert.ToDouble("");
                else row[0] = "";

               
                dt.Rows.InsertAt(row, 0);

                refCombo.DataSource = dt;

                refCombo.DisplayMember = dt.Columns[0].ColumnName;
                

            }
            catch (Exception Err)
            {
                throw Err;
            }
        }


    }
}
