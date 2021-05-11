using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using RIS.Common.DBConnection;

namespace RIS.Common.UtilityClass
{
    class displayForm
    {
        dbConnection dc = new dbConnection();

        ////Method for convert a string to a object type
        //public void loadForm(string formLocation, string objectName, int userNo, UUL.ControlFrame.Controls.TabControl formContainer)
        //{
        //    try
        //    {


        //        //Take a new object to keep the instance generate from the string
        //        object returnObj = new object();
        //        //Convert the string to object through its real path
        //        Type type = Assembly.GetExecutingAssembly().GetType(formLocation + objectName);

        //        if (type != null)
        //        {
        //            //Create and save the instance
        //            returnObj = Activator.CreateInstance(type);
        //        }

        //        //This part will perform only in case of open the editProfile form
        //        if (objectName.Trim() == "editProfile")
        //        {
        //            editProfile la1 = new editProfile(formContainer);
        //            //Pass the user number to the edit profile form
        //            la1.userID = userNo;
        //            DisplayForm(formContainer, la1);
        //        }
        //        else
        //        {
        //            //Convert the created instance as a form and show it in the container
        //            Form la1 = ((Form)returnObj);
        //            DisplayForm(formContainer, la1);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #region Show form
      /*  public void loadForm(string formName, UUL.ControlFrame.Controls.TabControl formContainer)
        {
            try
            {
                string n = formName;
                switch (n)
                {
                    #region Show form after double click on the submenu

                    case "employeeInformation":
                        employeeInformation la1 = new employeeInformation(formContainer);
                        DisplayForm(formContainer, la1);
                        break;

                    case "menuEntry":
                        menuEntry la2 = new menuEntry(formContainer);
                        DisplayForm(formContainer, la2);
                        break;

                    case "Admission":
                        Admission la3 = new Admission(formContainer);
                        DisplayForm(formContainer, la3);
                        break;

                    case "cl_Status":
                        cl_Status rform = new cl_Status();
                        DisplayForm(formContainer,rform);
                        break;
                    
                    case "cl_rom":
                        cl_rom rform1 = new cl_rom();
                        DisplayForm(formContainer,rform1);
                        break;
                    
                    case "cl_Reli":
                        cl_Reli rform2 = new cl_Reli();
                        DisplayForm(formContainer,rform2);
                        break;
                    
                    case "cl_Refa":
                        cl_Refa rform3 = new cl_Refa();
                        DisplayForm(formContainer,rform3);
                        break;
                    
                    case "cl_Race":
                        cl_Race rform4 = new cl_Race();
                        DisplayForm(formContainer,rform4);
                        break;
                    
                    //Add by rabbani
                    
                    case "cl_Aphys":
                        cl_Aphys rform5 = new cl_Aphys();
                        DisplayForm(rform5);
                        break;

                    case "cl_Fhom":
                        cl_Fhom rform6 = new cl_Fhom();
                        DisplayForm(rform6);
                        break;

                    case "cl_Finc":
                        cl_Finc rform7 = new cl_Finc();
                        DisplayForm(rform7);
                        break;

                    case "cl_Mari":
                        cl_Mari rform8 = new cl_Mari();
                        DisplayForm(rform8);
                        break;

                    case "cl_Phys":
                        cl_Phys rform9 = new cl_Phys();
                        DisplayForm(rform9);
                        break;

                    //Finish add 
                    
                    default:
                        MessageBox.Show("Form Not Created");
                        break;

                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        #endregion

        #region for show the form in the container

        public void DisplayForm(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rDisplayForm)
        {
            try
            {
                System.Windows.Forms.Form rDisplay;
                UUL.ControlFrame.Controls.TabPage page;
                rDisplay = setText(rDisplayForm);       //--Set text
                //page = new UUL.ControlFrame.Controls.TabPage(rDisplayForm.Text, rDisplayForm, rDisplayForm.Icon);
                page = new UUL.ControlFrame.Controls.TabPage(rDisplay.Text, rDisplay);
                page.Selected = true;
                rTabControl.TabPages.Add(page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisplayForm( System.Windows.Forms.Form rDisplayForm)
        {
            try
            {
                //Test
                setFormProperty(rDisplayForm);
                /////////////////////////////////
                rDisplayForm.StartPosition = FormStartPosition.CenterScreen;
                rDisplayForm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseFrom(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rCloseForm)
        {
            try
            {
                rCloseForm.Close();
                rTabControl.TabPages.Remove(rTabControl.SelectedTab);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private System.Windows.Forms.Form setText(System.Windows.Forms.Form rDisplayForm)
        {
            try
            {
                if ((rDisplayForm.GetType().Name.ToString().Trim()) != "ReportViewer")
                {
                    string sql = "select SUBMENU_NAME_USER from USER_SUBMENU where FORM_NAME='" + rDisplayForm.Name.ToString() + "'";
                    DataTable dt = new DataTable();
                    dt = dc.SelectDs(sql);
                    rDisplayForm.Text = dt.Rows[0]["SUBMENU_NAME_USER"].ToString();

                }
                return rDisplayForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void setFormProperty(Form displayForm)
        {
            try
            {
                displayForm.Font = new System.Drawing.Font("verdana", 10);
                displayForm.BackColor = System.Drawing.Color.Red;
                displayForm.MaximizeBox = false;
                displayForm.MinimizeBox = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
