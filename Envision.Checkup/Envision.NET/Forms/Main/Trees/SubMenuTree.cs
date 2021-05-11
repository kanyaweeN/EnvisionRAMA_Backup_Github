/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using RIS.Forms.Admin;
using RIS.Common.UtilityClass;
using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Common;



namespace RIS.Forms.Main.Trees
{
    public partial class SubMenuTree : UserControl
    {
        
        UUL.ControlFrame.Controls.TabControl formContainer;

        int userNo;
        string menuName;
        string menuNo;
        

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
        public SubMenuTree(UUL.ControlFrame.Controls.TabControl formContainer)
        {
            this.formContainer = formContainer;
        }
        public SubMenuTree(string menuName, string menuNo, UUL.ControlFrame.Controls.TabControl formContainer,int userNo)
        {
            InitializeComponent();
            System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xdc, /* G */ 0xeb, /* B */ 0xff);
            this.BackColor = c;
            this.userID = userNo;
            this.menuName = menuName;
            this.menuNo = menuNo;
            //load_tree(menuName, menuNo);
            this.formContainer = formContainer;
        }

        public void load_tree()
        {
            load_tree(this.menuName, this.menuNo);
        }
        
        public void load_tree(string buttonName, string menuNo)
        {
            
            //--Clear the subMenu item from the tree--\\
            treeSubMenu.Nodes.Clear();
            treeSubMenu.BorderStyle = BorderStyle.None;
            //--Creating a new Node--\\
            //TreeNode newNode = new TreeNode("" + buttonName.Trim() + "");
            //treeSubMenu.Nodes.Add(newNode);
                        
            //--Select the subMenu details through the menuId--\\
            
            DataTable dt;
            try
            {
                ////create object of dbconnection class
                //dt = DatabaseUtility.ExecuteDataTable("select SUBMENU_NO as subMenuNo, " +
                //        "SUBMENU_NAME_USER as subMenuName, FORM_NAME as formName, " +
                //        "PARENT_SUBMENU_NO as parentSubMenuNo, SUBMENU_LEVEL as subMenuLevel " +
                //        "from USER_SUBMENU where MENU_NO = @menuNo " +
                //        "and STATUS = @menuStatus Order By SUBMENU_LEVEL, SL_NO ",
                //        new SqlParameter("menuNo", menuNo), new SqlParameter("menuStatus", "A"));

                //dt = DatabaseUtility.ExecuteDataTable("SELECT SUBMENU_CLASS_NAME,MENU_ID,MENU_NAMESPACE,SUBMENU_ID,SUBMENU_NAME_USER,SUBMENU_SL_NO,SUBMENU_TYPE,ROLE_ID FROM GBLV_SETMENU where SUBMENU_TYPE in ('F','R') AND " +
                //                                        "EMP_ID = @userNo AND ROLE_IS_ACTIVE = @menuStatus AND SUBMENU_IS_ACTIVE	= 'Y' ORDER BY SUBMENU_SL_NO", new SqlParameter("menuStatus", "Y"), new SqlParameter("userNo", userNo));
               
                dt = DatabaseUtility.ExecuteDataTable("SELECT SUBMENU_CLASS_NAME,MENU_ID,MENU_NAMESPACE,SUBMENU_ID,SUBMENU_NAME_USER,SUBMENU_SL_NO,SUBMENU_TYPE,ROLE_ID " +
                                                      "FROM GBLV_SETMENU " +
                                                      "where SUBMENU_TYPE in ('F','R') AND EMP_ID = @userNo "+
                                                      "AND ROLE_IS_ACTIVE = @menuStatus AND SUBMENU_IS_ACTIVE	= 'Y' " +
                                                      "AND ISNULL(IS_DELETED,'N') <> 'Y' AND ISNULL(IS_UPDATED,'N') <> 'Y' "+
                                                      //"ORDER BY SUBMENU_SL_NO", new SqlParameter("menuStatus", "Y"), new SqlParameter("userNo", userNo));
                                                      "ORDER BY SUBMENU_NAME_USER", new SqlParameter("menuStatus", "Y"), new SqlParameter("userNo", userNo));
                TreeNode newNode;
                //--Inserting the subMenu in the submenuTree--\\
                int i = 0;
                
                while (i < dt.Rows.Count)
                {
                   string parentSubMenuNo = "" + dt.Rows[i]["MENU_ID"].ToString().Trim() + "";
                   int mno = Convert.ToInt32(parentSubMenuNo);
                   int mno2 = Convert.ToInt32(menuNo); 
                   if (mno == mno2)
                   {
                       string name = "" + dt.Rows[i]["SUBMENU_NAME_USER"].ToString() + "";
                       string formName = "" + dt.Rows[i]["MENU_NAMESPACE"].ToString() + "." + dt.Rows[i]["SUBMENU_CLASS_NAME"].ToString();
                       int level = 2;
                       string subMenuNo = "" + dt.Rows[i]["SUBMENU_ID"].ToString() + "";

                       if (level > 0)
                       {
                           newNode = new TreeNode(name);
                           newNode.Tag = formName;

                           //newNode = draw_detailTree(newNode, dt, subMenuNo);

                           treeSubMenu.Nodes.Add(newNode);
                       }
                   }                   
                        i++;
                }
                treeSubMenu.ExpandAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private TreeNode draw_detailTree(TreeNode currentNode, DataTable dt, string currentSubMenuNo)
        {
            TreeNode newNode;
            int i = 0;

            while (i < dt.Rows.Count)
            {
                string parentSubMenuNo = "" + dt.Rows[i]["MENU_ID"].ToString() + "";
                if (parentSubMenuNo.Equals(currentSubMenuNo))
                {
                    string name = "" + dt.Rows[i]["SUBMENU_NAME_USER"].ToString() + "";
                    string formName = "" + dt.Rows[i]["MENU_NAMESPACE"].ToString() + "";
                    int level = 1;
                    string subMenuNo = "" + dt.Rows[i]["MENU_ID"].ToString() + "";

                    newNode = new TreeNode(name);
                    newNode.Tag = formName;
                    
                    // Recursive call
                    newNode = draw_detailTree(newNode, dt, subMenuNo); 

                    currentNode.Nodes.Add(newNode);
                }
                i++;
            }
            return currentNode;
        }

        //--Load form according to submenu--\\
        public void form(string subMenuId, string nodeText)
        {
            try
            {
                if (subMenuId=="") 
                {
                    MessageBox.Show("Form Not Created");
                }
                else {
                    int k;
                    DataTable dtabl=DatabaseUtility.ExecuteDataTable("select SUBMENU_ID FROM GBL_SUBMENU WHERE SUBMENU_NAME_USER='"+nodeText+"'");
                    //MessageBox.Show(nodeText);
                    int x=0;
                    if(x<dtabl.Rows.Count)
                    {
                        new GBLEnvVariable().CurrentFormID = Convert.ToInt32(dtabl.Rows[x]["SUBMENU_ID"].ToString());
                        new GBLEnvVariable().FormTitle = nodeText;

                        //For session log for each submenu

                        GBLSessionLog slog = new GBLSessionLog();
                        slog.SPType = 1;
                        slog.SessionGUID = new GBLEnvVariable().CurrentFormGUID;
                        slog.SubmenuID = new GBLEnvVariable().CurrentFormID;
                        slog.OrgID = new GBLEnvVariable().OrgID;
                        slog.CreatedBy = new GBLEnvVariable().UserID;

                        ProcessAddSessionLog pslog= new ProcessAddSessionLog();
                        pslog.GBLSessionLog = slog;
                        pslog.Invoke();


                    }
                    
                    
                    k = checkOpenForm(subMenuId, nodeText);      //--check that the form is already open or not
                    if (k == 0)
                    {
                        return;
                    }
                    else
                    {

#region comment old report if clause
                        //if (subMenuId.Contains("Report"))
                        //{
                        //   // ReportMangager reportprovider = new ReportMangager();

                        //    #region Report for addmission section
                        //    if (subMenuId.Contains("Admission"))
                        //    {
                        //        if (subMenuId.Contains("emptyBed"))
                        //        {
                        //            //direct show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.emptyBed, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("residentRoster"))
                        //        {
                        //            //Direct show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.residentRoster, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("onBedHoldPass"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.onBedHoldPass, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptAlphabiticalRoster"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.rptAlphabiticalRoster, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptJewishResidentList"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.rptJewishResidentList, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptprotestantReport"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.rptprotestantReport, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("ON_BH_PASS_TODAY"))
                        //        {
                        //            //Parameterized
                        //           // ON_BH_PASS_TODAY RForm = new ON_BH_PASS_TODAY(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptParmAdmission"))
                        //        {
                        //            //Parameterized
                        //           // rptParmAdmission RForm = new rptParmAdmission(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("dischExpired"))
                        //        {
                        //            //frmReportViewer RForm = new frmReportViewer(reportprovider.dischExpired, formContainer);
                        //            //DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptParmRoomChanges"))
                        //        {
                        //            //Parameterized
                        //           // rptParmRoomChanges RForm = new rptParmRoomChanges(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptReturnBhPass"))
                        //        {
                        //            //Parameterized
                        //            //rptParmReturnBhPass RForm = new rptParmReturnBhPass(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptFloorAlphabeticalRoster"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptFloorAlphabeticalRoster , formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptCatholicResidentList"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptCatholicResidentList, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptUnitTotalByFinClass"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptUnitTotalByFinClass, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptGT"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptGT, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptPrimary_Financial_Class_List"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptPrimary_Financial_Class_List, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptLong_Term_Resident_List_with_Insurances_by_Room"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.rptLong_Term_Resident_List_with_Insurances_by_Room, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptParmResidentBarcode"))
                        //        {
                        //            //Parameterized
                        //           // rptParmResidentBarcode RForm = new rptParmResidentBarcode(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptParmAutoResidentBarcode"))
                        //        {
                        //            //Parameterized
                        //           // rptParmResidentBarcodeAuto RForm = new rptParmResidentBarcodeAuto(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptResidentListbyPrimaryIns"))
                        //        {
                        //            //Parameterized
                        //           // rptParmResidentListbyPrimaryIns RForm = new rptParmResidentListbyPrimaryIns(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptMidnightCensus"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptMidnightCensus, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptReligion"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.rptReligion, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptRaceFinancialClass"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptRaceFinancialClass, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //        else if (subMenuId.Contains("rptEVERCARE_REPORT"))
                        //        {
                        //            //Parameterized
                        //          //  rptPramEVERCARE_REPORT RForm = new rptPramEVERCARE_REPORT(formContainer);
                        //          //  DisplayForm(RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptShort_Term_Resident_List"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.rptShort_Term_Resident_List, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptMultiracialRooms"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.rptMultiracialRooms, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptUnder_Age_55"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptUnder_Age_55, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }
                        //    }
                        //    #endregion

                        //    #region report for nursing module
                        //    if (subMenuId.Contains("Nursing"))
                        //    {
                        //        if (subMenuId.Contains("rptLowRiskAssessment"))
                        //        {
                        //            //Parameterized
                        //           // rptParmLowRiskAssessment RForm = new rptParmLowRiskAssessment(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptBarcodesAllResidents"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptBarcodesAllResidents, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptBarcodesMedicareResidents"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptBarcodesMedicareResidents, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptBarcodesDates"))
                        //        {
                        //            //Parameterized
                        //           // rptParmBarcodesDates RForm = new rptParmBarcodesDates(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptResidentsWithWanderguardCensor"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptResidentsWithWanderguardCensor, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptResidentsWithWanderguardAlpha"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptResidentsWithWanderguardAlpha, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptResidentsWithWanderguardRoom"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptResidentsWithWanderguardRoom, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptNursingEmergencyPlan"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptNursingEmergencyPlan, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptParmNursingLetter"))
                        //        {
                        //            //Parameterized
                        //          //  rptParmNursingLetter RForm = new rptParmNursingLetter(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptPersonalEffectsWorksheet"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.rptPersonalEffectsWorksheet, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptWheelchair_Tags_Full_House"))
                        //        {
                        //            //Parameterized
                        //           // rptPramWheelchair_Tags_Full_House RForm = new rptPramWheelchair_Tags_Full_House(formContainer);
                        //           // DisplayForm(RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptMDS_REPORT_by_UNIT"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptMDS_REPORT_by_UNIT, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptMDS_REPORT_Alphabetical"))
                        //        {
                        //            //Direct Show
                        //          //  frmReportViewer RForm = new frmReportViewer(reportprovider.rptMDS_REPORT_Alphabetical, formContainer);
                        //          //  DisplayForm(formContainer, RForm, nodeText);
                        //        }

                        //        else if (subMenuId.Contains("rptResident_With_Hemodialysis"))
                        //        {
                        //            //Direct Show
                        //           // frmReportViewer RForm = new frmReportViewer(reportprovider.rptResident_With_Hemodialysis, formContainer);
                        //           // DisplayForm(formContainer, RForm, nodeText);
                        //        }               

                        //    }
                        //    #endregion
                        //}
                        //else
                        //{
#endregion report if clause

                        // Load the assembly.
                        Assembly asy = null;

                        asy = Assembly.Load("Envision.NET");

                        object[] paramsForm = new object[1] { formContainer };
                       
                        // Create the actual type.
                        Type form = asy.GetType(subMenuId);
                       
                        
                        if (form == null)
                        {
                           
                            MessageBox.Show("Form Not Created");
                            return;
                        }

                        if (subMenuId.Contains("BasicSetup"))
                        {
                            object obj = Activator.CreateInstance(form);
                            DisplayForm((Form)obj, nodeText);
                        }
                        else
                        {
                            if (nodeText == "My Profile")
                            {
                                 editProfile la1 = new editProfile(formContainer);
                                //Pass the user number to the edit profile form
                                la1.userID = userNo;
                                object obj = Activator.CreateInstance(form, paramsForm);
                                DisplayForm(formContainer, (Form)la1, nodeText);
                            }
                            else
                            {
                                object obj = Activator.CreateInstance(form, paramsForm);
                                DisplayForm(formContainer, (Form)obj, nodeText);
                            }
                        }
                        //}
                    }
                }
                
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DisplayForm(System.Windows.Forms.Form rDisplayForm, string formName)
        {
            try
            {
                //Test
                setFormProperty(rDisplayForm, formName);
                /////////////////////////////////
                rDisplayForm.StartPosition = FormStartPosition.CenterScreen;
                rDisplayForm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setFormProperty(Form displayForm, string formName)
        {
            try
            {
                //displayForm.Font = new System.Drawing.Font("verdana", 10);
                System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
                //displayForm.BackColor = System.Drawing.Color.Red;
                displayForm.BackColor = c;
                displayForm.MaximizeBox = false;
                displayForm.MinimizeBox = false;
                displayForm.Text = formName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //--Chek that selected form is already open in the tabPage--\\
        public int checkOpenForm(string formName, string name)
        {
            
            
            
            try
            {
                int temp = 1;
                int i = 0;
                while (i < this.formContainer.TabPages.Count)
                {
                    
                    if (formContainer.TabPages[i].Title.ToString().Trim() == "" + name + "")
                    {
                        temp = 0;
                        //formContainer.TabPages[i].TabIndex;
                        formContainer.TabPages[i].Selected = true;
                        break;
                    }
                    i++;
                }
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void treeMailBox_AfterSelect(object sender, TreeViewEventArgs e)
        {
           //MessageBox.Show(this.treeSubMenu.SelectedNode.Text);
        }

        private void treeMailBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.treeSubMenu.SelectedNode.LastNode == null)
            {
                try
                {
                    //MessageBox.Show(this.subMenuTree.SelectedNode.Tag.ToString());
                    //--Call this function to open the related form to the submenu--\\
                    new GBLEnvVariable().CurrentTag = this.treeSubMenu.SelectedNode.Tag.ToString();
                    new GBLEnvVariable().CurrentText = this.treeSubMenu.SelectedNode.Text.ToString();
                    form(this.treeSubMenu.SelectedNode.Tag.ToString(), this.treeSubMenu.SelectedNode.Text.ToString());
                    formContainer.SelectedTab.Tag = this.treeSubMenu.SelectedNode.Tag.ToString();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No");
            }
        }

        private void DisplayForm(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rDisplayForm, string formName)
        {
            System.Windows.Forms.Form rDisplay;
            UUL.ControlFrame.Controls.TabPage page;
            //rDisplayForm.Text = formName;
            rDisplay = rDisplayForm;       //--Set text
            
            //setFormProperty(rDisplayForm, formName);
            //page = new UUL.ControlFrame.Controls.TabPage(rDisplayForm.Text, rDisplayForm, rDisplayForm.Icon);
            page = new UUL.ControlFrame.Controls.TabPage(rDisplay.Text, rDisplay);
            page.Selected = true;
            rTabControl.TabPages.Add(page);
            
        }

        //private void DisplayReport(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rDisplayForm, string formName)
        //{
        //    System.Windows.Forms.Form rDisplay;
        //    UUL.ControlFrame.Controls.TabPage page;
        //    rDisplayForm.Text = formName;
        //    rDisplay = rDisplayForm;       //--Set text
        //    //page = new UUL.ControlFrame.Controls.TabPage(rDisplayForm.Text, rDisplayForm, rDisplayForm.Icon);
        //    page = new UUL.ControlFrame.Controls.TabPage(rDisplay.Text, rDisplay);
        //    page.Selected = true;
        //    rTabControl.TabPages.Add(page);
        //}

    }
}
