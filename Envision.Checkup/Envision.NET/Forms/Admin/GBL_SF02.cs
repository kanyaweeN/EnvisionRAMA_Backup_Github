using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.UtilityClass;
using RIS.Common.DBConnection;
using RIS.BusinessLogic;
using RIS.Common;
using UUL.ControlFrame.Controls;
using System.Globalization;
using System.Threading;
using RIS.Common.Common;
using System.Collections;
using System.Drawing.Drawing2D;

namespace RIS.Forms.Admin
{
    public partial class GBL_SF02 : Form
    {
        alertObjectCollection rvisticol = new alertObjectCollection();
        ProcessGetAlert rhabvisitlistm = new ProcessGetAlert();
        DBUtility dbu = new DBUtility();
        
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public GBL_SF02(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            LoadFormLanguage();
            loadTree("");
            ChangeFormLanguage();
            rvisticol = rhabvisitlistm.SelectData();

            
            /*cmbUID.DataBindings.Add("Text", rvisticol, "AlertUID");
            cmbLanguage.DataBindings.Add("Text", rvisticol, "LangID");
            txtText.DataBindings.Add("Text", rvisticol, "AlertText");
            cmbAlertType.DataBindings.Add("Text", rvisticol, "AlertType");
            chkActive.DataBindings.Add("Text", rvisticol, "IsActive");
            txtTitle.DataBindings.Add("Text", rvisticol, "AlertTitle");
            cmbNoOfButton.DataBindings.Add("Text", rvisticol, "AlertButton");
            txtButton1Caption.DataBindings.Add("Text", rvisticol, "CaptionButton1");
            txtButton2Caption.DataBindings.Add("Text", rvisticol, "CaptionButton2");*/
            txtButton3Caption.DataBindings.Add("Text", rvisticol, "AlertID");
            

            // Get the BindingManagerBase for VisitList. 
            BindingManagerBase bmVisitList = this.BindingContext[rvisticol];

            // Add the delegate for the PositionChanged event.
            bmVisitList.PositionChanged += new EventHandler(alert_PositionChanged);

            // Set up the initial text for the DATA VCR Panel
            bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
            
            

        }

       
        private void ChangeFormLanguage()
        {
            //MessageBox.Show(""+new GBLEnvVariable().CurrentLanguageID);
           
            FormLanguage fl = new FormLanguage();
            fl.FormID = new GBLEnvVariable().CurrentFormID;

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

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblAlertUID").ToUpper().Trim())
                    {
                        lblAlertUID.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblLanguage").ToUpper().Trim())
                    {
                        lblLanguage.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblAlertType").ToUpper().Trim())
                    {
                        lblAlertType.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblText").ToUpper().Trim())
                    {
                        lblText.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblTitle").ToUpper().Trim())
                    {
                        lblTitle.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblNoOfButton").ToUpper().Trim())
                    {
                        lblNoOfButton.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblTimeInSec").ToUpper().Trim())
                    {
                        lblTimeInSec.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblDefaultButton").ToUpper().Trim())
                    {
                        lblDefaultButton.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblCaption1").ToUpper().Trim())
                    {
                        lblCaption1.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblCaption2").ToUpper().Trim())
                    {
                        lblCaption2.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblCaption3").ToUpper().Trim())
                    {
                        lblCaption3.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkActive").ToUpper().Trim())
                    {
                        chkActive.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnAdd").ToUpper().Trim())
                    {
                        btnAdd.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnEdit").ToUpper().Trim())
                    {
                        btnAdd.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnRefresh").ToUpper().Trim())
                    {
                        btnRefresh.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }

                    k++;
                }



            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }



        private void MyLookup_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);
        }



        private void alert_PositionChanged(object sender, System.EventArgs e)
        {
            bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
            string uid = txtButton3Caption.Text.ToString();
            txtButton3Caption.Text = "";
            loadTree2(uid);
           


           

        }


        #region reset
        public void reset()
        {
            txtButton1Caption.Text = "";
            txtButton2Caption.Text = "";
            txtButton3Caption.Text = "";
            txtText.Text = "";
            txtTitle.Text = "";
            txtTime.Text = "";
            //cmbUID.Text = "";
            cmbNoOfButton.Text = "1";
            cmbAlertType.Text = "Information";
            cmbLanguage.Text = new GBLEnvVariable().LangName;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            chkActive.Checked = false;
            chkActive.Enabled = false;
            
        }
        #endregion

        public void caption()
        {
            txtButton1Caption.Enabled = false;
            txtButton2Caption.Enabled = false;
            txtButton3Caption.Enabled = false;
        }
        
        public void nevigation(String nv)
        {
            if(nv == "1")
            {
                toolStripButton1.Enabled=true;
                toolStripButton2.Enabled=true;
                toolStripButton3.Enabled=true;
                toolStripButton4.Enabled = true;
            }
            else
            {
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
            }

        }

        #region Load Languages

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
                    cmbLanguage.Items.Add(dt.Rows[k]["LANG_NAME"].ToString());
                    string lid = dt.Rows[k]["LANG_ID"].ToString();
                    k++;
                }

                cmbLanguage.Text = new GBLEnvVariable().LangName;

            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }

 #endregion


        #region LoadTree
        
        public void loadTree(string uid)
        {
            
            try
            {
                FormLanguage fl = new FormLanguage();
                fl.FormID = 1;
                fl.LanguageID = 1;
                fl.ProcedureType =2;
            
                ProcessGetLanguage langs = new ProcessGetLanguage();
                langs.FormLanguage = fl;
                try
                {
                    langs.Invoke();
                }
                catch
                {
                }
               
         
                DataTable dt = langs.ResultSet.Tables[0];
                
                ProcessGetAlert alt = new ProcessGetAlert();
                if (uid == "")
                {
                    alt.Invoke();
                    //MessageBox.Show("f");


                }
                else
                {
                   
                    alt.UsID = "%"+uid.Trim()+"%";
                 
                    alt.Invoke();
                }

                DataTable dt2 = alt.ResultSet.Tables[0];
                treeView1.ImageList = imageList1;
                string[] auid = new string[2];
               
                if (dt2.Rows.Count == 0)
                {
                    //treeView1.Nodes.Add("No user information found");
                    //treeView1.Nodes[0].ImageIndex = 0;
                }
                else
                {
                   
                    ArrayList alist = new ArrayList();
                    int m=0;
                    while (m < dt2.Rows.Count)
                    {
                        if(alist.Contains(dt2.Rows[m]["ALT_UID"]))
                        {
                        }
                        else
                        {
                            alist.Add(dt2.Rows[m]["ALT_UID"].ToString());
                            cmbUID.Items.Remove(dt2.Rows[m]["ALT_UID"].ToString());
                            cmbUID.Items.Add(dt2.Rows[m]["ALT_UID"].ToString());
                        }
                        m++;
                    }

          
                   
                    //treeView1.Nodes[0].ImageIndex = 0;
                    int i = 0;
                    int k = 0;
                    int p = 0;
                    while (i < alist.Count)
                    {
                            
                      treeView1.Nodes.Add(alist[i].ToString());
                           
                               
                        p = 0;
                        while(p < dt.Rows.Count)
                        {
                                                
                            TreeNode newNode = new TreeNode(dt.Rows[p]["LANG_NAME"].ToString());
                            newNode.Tag = dt.Rows[p]["LANG_ID"].ToString();
                            treeView1.Nodes[i].Nodes.Add(newNode);
                            k=0;
                         
                            while (k < dt2.Rows.Count)
                            {
                                if ((dt.Rows[p]["LANG_ID"].ToString()) == (dt2.Rows[k]["LANG_ID"].ToString()) && ((alist[i].ToString()) == (dt2.Rows[k]["ALT_UID"].ToString())))
                                {
                                    
                                    //TreeNode newNode = new TreeNode(dt.Rows[p]["LANG_NAME"].ToString());
                                    //newNode.Tag = dt.Rows[p]["LANG_ID"].ToString();
                                    //treeView1.Nodes[i].Nodes.Add(newNode);
                                                                                                      
                                    TreeNode newNodes = new TreeNode(dt2.Rows[k]["ALT_TEXT"].ToString());
                                    newNodes.Tag = dt2.Rows[k]["ALT_DTL_ID"].ToString();

                                    if ((dt2.Rows[k]["ALT_TYPE"].ToString()) == ("I"))
                                    {
                                        newNodes.SelectedImageIndex = 1;
                                        newNodes.ImageIndex = 1;
                                    }
                                    else if ((dt2.Rows[k]["ALT_TYPE"].ToString()) == ("N"))
                                    {
                                        newNodes.SelectedImageIndex = 2;
                                        newNodes.ImageIndex = 2;
                                    }
                                    else if ((dt2.Rows[k]["ALT_TYPE"].ToString()) == ("C"))
                                    {
                                        newNodes.SelectedImageIndex = 3;
                                        newNodes.ImageIndex = 3;
                                    }
                                    else if ((dt2.Rows[k]["ALT_TYPE"].ToString()) == ("W"))
                                    {
                                        newNodes.SelectedImageIndex = 4;
                                        newNodes.ImageIndex = 4;
                                    }
                                    else
                                    {
                                        newNodes.SelectedImageIndex = 0;
                                        newNodes.ImageIndex = 0;
                                    }



                                    treeView1.Nodes[i].Nodes[p].Nodes.Add(newNodes);
                                   

                                }
                                k++;
                            }
                               
                            p++;
                                   
                            
                        }
                      
                       
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

        #endregion


        #region LoadTree2
        public void loadTree2(string uid)
        {
            try
            {

                ProcessGetAlert alt = new ProcessGetAlert();
                

                    alt.UsID =uid.Trim();

                    alt.Invoke2();
               
                DataTable dt2 = alt.ResultSet.Tables[0];
                //treeView1.ImageList = imageList1;


                //treeView1.Nodes[0].ImageIndex = 0;

                int k = 0;
                string atype = "";

                while (k < dt2.Rows.Count)
                {
                    textBox1.Text = dt2.Rows[0]["ALT_DTL_ID"].ToString();
                    cmbUID.Text = dt2.Rows[0]["ALT_UID"].ToString();
                    int a = Convert.ToInt32(dt2.Rows[0]["LANG_ID"].ToString());
                    cmbLanguage.SelectedIndex=a-1;
                    atype = dt2.Rows[0]["ALT_TYPE"].ToString();
                    if (atype == "I")
                    {
                        atype = "Information";
                    }
                    else if (atype == "C")
                    {
                        atype = "Caution";
                    }
                    else if (atype == "W")
                    {
                        atype = "Warning";
                    }
                    else
                    {
                        atype = "Confirmation";
                    }
                    cmbAlertType.Text = atype;
                    cmbNoOfButton.Text = dt2.Rows[0]["ALT_BUTTON"].ToString();
                    txtText.Text = dt2.Rows[0]["ALT_TEXT"].ToString();
                    txtTitle.Text = dt2.Rows[0]["ALT_TITLE"].ToString();
                    txtButton1Caption.Text = dt2.Rows[0]["CAPTION_BTN1"].ToString();
                    txtButton2Caption.Text = dt2.Rows[0]["CAPTION_BTN2"].ToString();
                    txtButton3Caption.Text = dt2.Rows[0]["CAPTION_BTN3"].ToString();
                    txtTime.Text = dt2.Rows[0]["TIME_SEC"].ToString();
                    cmbDefaultBtn.Text = dt2.Rows[0]["DEFAULT_BTN"].ToString();
                    string aa = dt2.Rows[0]["IS_ACTIVE"].ToString();
                    if (aa == "0")
                    {
                        chkActive.Checked = false;
                    }
                    else
                    {
                        chkActive.Checked = true;
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

        #endregion

        #region Editable
        public void editable()
        {
            txtButton1Caption.Enabled = true;
            txtButton2Caption.Enabled = true;
            txtButton3Caption.Enabled = true;
            txtText.Enabled = true;
            txtTitle.Enabled = true;
            txtTime.Enabled = true;
            cmbUID.Enabled = true;
            cmbDefaultBtn.Enabled = true;
            cmbAlertType.Enabled = true;
            cmbLanguage.Enabled = true;
            cmbNoOfButton.Enabled = true;
            chkActive.Checked = false;
            chkActive.Enabled = true;
        }
        #endregion


        public void ChangeObject(string a)
        {
            lblAlertUID.Text = a;
                    
        }
        

        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            loadTree(""+txtSearch.Text.ToString().Trim()+"");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.LastNode == null)
                {
                    string uid = treeView1.SelectedNode.Tag.ToString();
                    loadTree2(uid);
                    txtButton1Caption.Enabled = false;
                    txtButton2Caption.Enabled = false;
                    txtButton3Caption.Enabled = false;

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

            
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "&Add")
                {
                    nevigation("0");
                    editable();
                    btnAdd.Text = "&Save";
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    
                    reset();
                    chkActive.Enabled = true;
                }

                else
                {
                    GBLEnvVariable gblenv = new GBLEnvVariable();
                    ProcessAddGBLAlert processalert = new ProcessAddGBLAlert();
                    GBLAlert gblalert = new GBLAlert();
                    gblalert.AlertUID = cmbUID.Text.ToString();
                    gblalert.AlertText = txtText.Text.ToString();
                    gblalert.AlertTitle = txtTitle.Text.ToString();
                    string atype = cmbAlertType.Text.ToString();
                    if (atype == "Information")
                    {
                        atype = "I";
                    }
                    else if (atype == "Caution")
                    {
                        atype = "C";
                    }
                    else if (atype == "Warning")
                    {
                        atype = "W";
                    }
                    else
                    {
                        atype = "N";
                    }
                    gblalert.AlertType = atype;
                    gblalert.CaptionButton1 = txtButton1Caption.Text.ToString();
                    gblalert.CaptionButton2 = txtButton2Caption.Text.ToString();
                    gblalert.CaptionButton3 = txtButton3Caption.Text.ToString();
                    gblalert.AlertButton = Convert.ToInt32(cmbNoOfButton.Text.ToString().Trim());
                    gblalert.OrgID = gblenv.OrgID;
                    gblalert.CreatedBy = gblenv.UserID;
                    gblalert.DefaultBtn = Convert.ToInt32(cmbDefaultBtn.Text.ToString().Trim());
                    gblalert.TimeSec = Convert.ToInt32(txtTime.Text.ToString().Trim());
                    //CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                    DateTime yourdatetime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());
                    
                    gblalert.CreatedOn = ""+yourdatetime;
                    //gblalert.CreatedOn = yourdatetime;
                    if (chkActive.Checked == true)
                    {
                        gblalert.IsActive = "1";
                    }
                    else
                    {
                        gblalert.IsActive = "0";
                    }
                    gblalert.LangID = gblenv.CurrentLanguageID;
                    
                    processalert.GBLAlert = gblalert;

                    try
                    {
                        processalert.Invoke();
                        treeView1.Nodes.Clear();
                        loadTree("");


                        txtButton1Caption.Enabled = false;
                        txtButton2Caption.Enabled = false;
                        txtButton3Caption.Enabled = false;
                        txtText.Enabled = false;
                        txtTitle.Enabled = false;
                        txtTime.Enabled = false;
                        cmbDefaultBtn.Enabled = false;
                        cmbUID.Enabled = false;
                        cmbAlertType.Enabled = false;
                        cmbLanguage.Enabled = false;
                        cmbNoOfButton.Enabled = false;
                        btnAdd.Text = "&Add";
                        btnEdit.Text = "&Edit";
                        reset();
                        nevigation("1");

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnEdit_Click_2(object sender, EventArgs e)
        {
            if (btnEdit.Text == "&Edit")
            {
                if (cmbUID.Text == "")
                {
                    MessageBox.Show("Alert UID can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    nevigation("0");
                    //MessageBox.Show("edit");
                    txtButton1Caption.Enabled = true;
                    txtButton2Caption.Enabled = true;
                    txtButton3Caption.Enabled = true;
                    txtText.Enabled = true;
                    txtTitle.Enabled = true;
                    txtTime.Enabled = true;
                    cmbDefaultBtn.Enabled = true;
                    cmbUID.Enabled = true;
                    cmbAlertType.Enabled = true;
                    cmbLanguage.Enabled = true;
                    cmbNoOfButton.Enabled = true;
                    btnEdit.Text = "&Update";
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    chkActive.Enabled = true;
  

                }
            }
            else
            {


                GBLEnvVariable gblenv = new GBLEnvVariable();
                GBLAlert gblalert = new GBLAlert();
                ProcessUpdateGBLAlert processalert = new ProcessUpdateGBLAlert();
                gblalert.AlertUID = cmbUID.Text.ToString();
                gblalert.AlertText = txtText.Text.ToString();
                gblalert.AlertTitle = txtTitle.Text.ToString();
                string atype = cmbAlertType.Text.ToString();
                if (atype == "Information")
                {
                    atype = "I";
                }
                else if (atype == "Caution")
                {
                    atype = "C";
                }
                else if (atype == "Warning")
                {
                    atype = "W";
                }
                else
                {
                    atype = "N";
                }
                gblalert.AlertType = atype;
                gblalert.CaptionButton1 = txtButton1Caption.Text.ToString();
                gblalert.CaptionButton2 = txtButton2Caption.Text.ToString();
                gblalert.CaptionButton3 = txtButton3Caption.Text.ToString();
                gblalert.AlertButton = Convert.ToInt32(cmbNoOfButton.Text.ToString().Trim());
                gblalert.OrgID = gblenv.OrgID;
                gblalert.CreatedBy = gblenv.UserID;
                gblalert.DefaultBtn = Convert.ToInt32(cmbDefaultBtn.Text.ToString().Trim());
                gblalert.TimeSec = Convert.ToInt32(txtTime.Text.ToString().Trim());
                //CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                DateTime yourdatetime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());
               
                gblalert.CreatedOn = "" + yourdatetime;
                //MessageBox.Show("Date" + yourdatetime);
                //gblalert.CreatedOn = yourdatetime;
                if (chkActive.Checked == true)
                {
                   gblalert.IsActive = "1";
                }
                else
                {
                    gblalert.IsActive = "0";
                }
                gblalert.LangID = gblenv.CurrentLanguageID;
                gblalert.AlertID = Convert.ToInt32(textBox1.Text.ToString());
                processalert.GBLAlert = gblalert;

                try
                {
                    processalert.Invoke();
                    treeView1.Nodes.Clear();
                    loadTree("");


                    txtButton1Caption.Enabled = false;
                    txtButton2Caption.Enabled = false;
                    txtButton3Caption.Enabled = false;
                    txtText.Enabled = false;
                    txtTitle.Enabled = false;
                    txtTime.Enabled = false;
                    cmbDefaultBtn.Enabled = false;
                    cmbUID.Enabled = false;
                    cmbAlertType.Enabled = false;
                    cmbLanguage.Enabled = false;
                    cmbNoOfButton.Enabled = false;
                    btnAdd.Text = "&Add";
                    btnEdit.Text = "&Edit";
                    reset();
                    nevigation("1");


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtButton1Caption.Enabled = false;
            txtButton2Caption.Enabled = false;
            txtButton3Caption.Enabled = false;
            txtText.Enabled = false;
            txtTitle.Enabled = false;
            txtTime.Enabled = false;
            cmbDefaultBtn.Enabled = false;
            cmbUID.Enabled = false;
            chkActive.Enabled = false;
            cmbAlertType.Enabled = false;
            cmbLanguage.Enabled = false;
            cmbNoOfButton.Enabled = false;
            btnAdd.Text = "&Add";
            btnEdit.Text = "&Edit";
            reset();
            nevigation("1");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void cmbNoOfButton_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbNoOfButton.Text == "1")
            {
                txtButton1Caption.Enabled = true;
                txtButton2Caption.Enabled = false;
                txtButton3Caption.Enabled = false;


            }
            else if (cmbNoOfButton.Text == "2")
            {
                txtButton1Caption.Enabled = true;
                txtButton2Caption.Enabled = true;
                txtButton3Caption.Enabled = false;
            }
            else
            {
                txtButton1Caption.Enabled = true;
                txtButton2Caption.Enabled = true;
                txtButton3Caption.Enabled = true;
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            new GBLEnvVariable().CurrentLanguageID = cmbLanguage.SelectedIndex+1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void txtSearch_LostFocus(object sender, System.EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                //txtSearch.Text = "Search";
            }
            else
            {
            }

            

        }

        private void txtSearch_GotFocus(object sender, System.EventArgs e)
        {

            txtSearch.Text = "";

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (cmbUID.Text == "")
            {
                MessageBox.Show("UID can not blank !!");
            }
            else
            {

                GBLAlert gblalert = new GBLAlert();
                ProcessDeleteGBLAlert processalert = new ProcessDeleteGBLAlert();

                gblalert.AlertID = Convert.ToInt32(textBox1.Text.ToString());
                processalert.GBLAlert = gblalert;

                try
                {
                    processalert.Invoke();
                    treeView1.Nodes.Clear();
                    loadTree("");

                    reset();


                }
                catch (Exception EX) { }
            }
        }

        private void btnClose_Click_2(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            this.BindingContext[rvisticol].Position = rvisticol.Count - 1;

            caption();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (this.BindingContext[rvisticol].Position > 0)
            {
                this.BindingContext[rvisticol].Position--;
                
                caption();

            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            if (this.BindingContext[rvisticol].Position < rvisticol.Count - 1)
            {
                this.BindingContext[rvisticol].Position++;
                caption();
                
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.BindingContext[rvisticol].Position = 0;
          
          
             caption();
            
        }

       
        

        private void btnNewAlert_Click(object sender, EventArgs e)
        {
            cmbUID.Enabled = true;
            cmbLanguage.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

       

        

          


    }
}