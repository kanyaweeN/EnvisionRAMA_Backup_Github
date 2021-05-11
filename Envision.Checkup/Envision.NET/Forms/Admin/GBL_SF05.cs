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
using RIS.Operational;
using RIS.Forms.GBLMessage;
using System.Drawing.Drawing2D;

namespace RIS.Forms.Admin
{
    public partial class GBL_SF05 : Form
    {
        menuObjectCollection rvisticol = new menuObjectCollection();
        ProcessGetGBLMenu rhabvisitlistm = new ProcessGetGBLMenu();
        DBUtility dbu = new DBUtility();
        GBLEnvVariable env = new GBLEnvVariable();
        GBLExceptionLog elog = new GBLExceptionLog();
        MyMessageBox msg = new MyMessageBox();

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        
        class parentData
        {

            private int _value;
            private string _name;

            public int Value
            {

                get { return _value; }
                set { _value = value; }
            }

            public string Name
            {

                get { return _name; }

                set { _name = value; }
            }

            public parentData(string name, int value)
            {

                _name = name;

                _value = value;

            }

            public override string ToString()
            {

                return _name;
            }

        }
         


        public GBL_SF05(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            ChangeFormLanguage();
            loadTree("");

            rvisticol = rhabvisitlistm.SelectData();


            //textBox1.DataBindings.Add("Text", rvisticol, "MenuID");
            /*
            cmbLanguage.DataBindings.Add("Text", rvisticol, "LangID");
            txtText.DataBindings.Add("Text", rvisticol, "AlertText");
            cmbAlertType.DataBindings.Add("Text", rvisticol, "AlertType");
            chkActive.DataBindings.Add("Text", rvisticol, "IsActive");
            txtTitle.DataBindings.Add("Text", rvisticol, "AlertTitle");
            cmbNoOfButton.DataBindings.Add("Text", rvisticol, "AlertButton");
            txtButton1Caption.DataBindings.Add("Text", rvisticol, "CaptionButton1");
            txtButton2Caption.DataBindings.Add("Text", rvisticol, "CaptionButton2");*/
            textBox2.DataBindings.Add("Text", rvisticol, "MenuUID");


            // Get the BindingManagerBase for VisitList. 
            BindingManagerBase bmVisitList = this.BindingContext[rvisticol];

            // Add the delegate for the PositionChanged event.
            bmVisitList.PositionChanged += new EventHandler(menu_PositionChanged);

            // Set up the initial text for the DATA VCR Panel
            bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
            
        }

        #region Load Languages

        private void LoadFormLanguage()
        {

            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;
            fl.LanguageID = 1;
            fl.ProcedureType = 2;
            /*
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
            */

            return;

        }

        #endregion

        private void MyLookup_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);
        }


        #region LoadTree

        public void loadTree(string uid)
        {
            try
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
                DataTable dt = langs.ResultSet.Tables[0];

                ProcessGetGBLMenu menu = new ProcessGetGBLMenu();
                if (uid == "")
                {
                    menu.SPType = 1;
                    menu.Invoke();
                    //MessageBox.Show("f");

                }
                else
                {

                    menu.UsID = "%" + uid.Trim() + "%";
                    menu.SPType = 3;
                    menu.Invoke();
                }

                DataTable dt2 = menu.ResultSet.Tables[0];
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
                    ArrayList parentList = new ArrayList();
                    ArrayList midList = new ArrayList();
                    int m = 0;
                    while (m < dt2.Rows.Count)
                    {
                        if (alist.Contains(dt2.Rows[m]["MENU_UID"]))
                        {
                        }
                        else
                        {
                            alist.Add(dt2.Rows[m]["MENU_UID"].ToString());
                            parentList.Add(dt2.Rows[m]["PARENT"].ToString());
                            midList.Add(dt2.Rows[m]["MENU_ID"].ToString());

                            //cmbParent.Items.Remove(dt2.Rows[m]["MENU_UID"].ToString());
                            //cmbParent.Items.Add(dt2.Rows[m]["MENU_UID"].ToString());
                            
                            bool bRemove = true;
                            try
                            {
                                parentData par = (parentData)cmbParent.Items[m];
                                if (par.Name == dt2.Rows[m]["MENU_UID"].ToString())
                                    cmbParent.Items.Remove(cmbParent.Items[m]);
                                else
                                    bRemove = false;
                            }
                            catch
                            {
                            }

                            if (bRemove)
                                cmbParent.Items.Add(new parentData(dt2.Rows[m]["MENU_UID"].ToString() + "||" + dt2.Rows[m]["MENU_NAME"].ToString(),
                                Convert.ToInt32(dt2.Rows[m]["MENU_ID"].ToString())));
                        }
                        m++;
                    }

                    ArrayList il = new ArrayList();
                    setTreeView(alist, midList, parentList, 0, 0, il, 0);
                    //treeView1.Nodes[0].ImageIndex = 0;
  
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

        private void ChangeFormLanguage()
        {


            FormLanguage fl = new FormLanguage();
            fl.FormID = 5;
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
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblObjects").ToUpper().Trim())
                        nGrouper1.HeaderItem.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkActive").ToUpper().Trim())
                        chkActive.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    /*
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnAdd").ToUpper().Trim())
                        btnAdd.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnEdit").ToUpper().Trim())
                        btnEdit.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    */

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnDelete").ToUpper().Trim())
                        btnDelete.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnRefresh").ToUpper().Trim())
                        btnRefresh.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnClose").ToUpper().Trim())
                        btnClose.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblMenuUID").ToUpper().Trim())
                        lblMenuUID.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblMenuName").ToUpper().Trim())
                        lblMenuName.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblMenuNameSpace").ToUpper().Trim())
                        lblMenuNameSpace.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblParent").ToUpper().Trim())
                        lblParent.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSerial").ToUpper().Trim())
                        lblSerial.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblDesc").ToUpper().Trim())
                        lblDesc.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    
                    k++;
                }



            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }

        public void setTreeView(ArrayList alist, ArrayList mlist, ArrayList plist, int ilevel, int ichild, ArrayList il, int iParentNode)
        {
            int i = 0;
            //int ichild = 0;
            //ArrayList il = new ArrayList();
            
            while (i < alist.Count)
            {
                if (ilevel == 0)
                {
                    if (plist[i].ToString() == "" || plist[i].ToString() == "0")
                    {
                        treeView1.Nodes.Add(i.ToString(), alist[i].ToString());
                    }
                    else
                    {
                        ichild++;
                        il.Add(i.ToString());
                    }
                }
                else
                {
                    int j = 0;
                    while (j < plist.Count)
                    {
                        if (plist[j].ToString() == mlist[i].ToString())
                        {
                            //MessageBox.Show(treeView1.Nodes[i.ToString()].Text.ToString());
                            bool bLevel = false;
                            for (int x = 0; x < il.Count; x++)
                            {
                                if (i.ToString() == il[x].ToString())
                                {
                                    try
                                    {
                                        treeView1.Nodes[iParentNode].Nodes[i.ToString()].Nodes.Add(j.ToString(), alist[j].ToString());
                                    }
                                    catch
                                    {
                                    }
                                    bLevel = true;
                                }
                            }
                            if (bLevel == false)
                            {
                                treeView1.Nodes[i.ToString()].Nodes.Add(j.ToString(), alist[j].ToString());
                                iParentNode = i;
                            }
                            
                            ichild--;
                        }
                        j++;
                    }
                }

                i++;
            }

            if (ichild > 0)
                setTreeView(alist, mlist, plist, ++ilevel, ichild, il, iParentNode);
            
        }

        #region LoadTree2
        public void loadTree2(string uid)
        {
            try
            {

                ProcessGetGBLMenu menu = new ProcessGetGBLMenu();


                menu.UsID = uid.Trim();

                menu.SPType = 2;
                menu.Invoke();

                DataTable dt2 = menu.ResultSet.Tables[0];
                //treeView1.ImageList = imageList1;


                //treeView1.Nodes[0].ImageIndex = 0;

                int k = 0;

                while (k < dt2.Rows.Count)
                {
                    textBox1.Text = dt2.Rows[0]["MENU_ID"].ToString();
                    txtUID.Text = dt2.Rows[0]["MENU_UID"].ToString();
                    textBox2.Text = dt2.Rows[0]["MENU_UID"].ToString();
                    
                    txtName.Text = dt2.Rows[0]["MENU_NAME"].ToString();
                    txtNameSpace.Text = dt2.Rows[0]["MENU_NAMESPACE"].ToString();
                    txtDesc.Text = dt2.Rows[0]["DESCR"].ToString();

                    parentData par;
                    cmbParent.Text = "";
                    for (int i = 0; i < cmbParent.Items.Count; i++)
                    {
                        par = (parentData)cmbParent.Items[i];
                        if (par.Value == Convert.ToInt32(dt2.Rows[0]["PARENT"].ToString()))
                        {
                            cmbParent.Text = par.Name;
                            break;
                        }
                    }

                    txtSlno.Text = dt2.Rows[0]["SL_NO"].ToString();
                    
                    string aa = dt2.Rows[0]["IS_ACTIVE"].ToString();
                    if (aa == "N")
                    {
                        chkActive.Checked = false;
                    }
                    else
                    {
                        chkActive.Checked = true;
                    }

                    try
                    {
                        ImageConverter imcon = new ImageConverter();
                        pictureBox1.Image = (Image)imcon.ConvertFrom(dt2.Rows[0]["MENU_ICON"]);
                    }
                    catch (Exception ex)
                    {
                        pictureBox1.Image = null;
                    }

                    k++;

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                elog.LogException(ex.ToString(), env.CurrentFormID, "F");
                return;
            }
        }

        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            loadTree("" + txtSearch.Text.ToString().Trim() + "");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                //if (e.Node.LastNode == null)
                //{
                if (btnEdit.Text == "&Edit")
                {
                    string uid = treeView1.SelectedNode.Text.ToString();

                    
                    //string uid = treeView1.SelectedNode.Tag.ToString();
                    loadTree2(uid);

                    //textBox1.Visible = true;
                    //this.BindingContext[rvisticol].Position = 0;
                    /*
                    for (int i = 0; i < rvisticol.Count; i++)
                    {
                        if (rvisticol[i].MenuUID.ToString() == uid)
                        {
                            this.BindingContext[rvisticol].Position = i;
                            break;
                        }
                    }

                    bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
                    */
                }
                else
                {
                    msg.ShowAlert("UID009", env.CurrentLanguageID);
                    return;
                }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                elog.LogException(ex.ToString(), env.CurrentFormID, "F");
                return;
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.BindingContext[rvisticol].Position < rvisticol.Count - 1)
            {
                this.BindingContext[rvisticol].Position++;
                txtUID.Text = textBox2.Text;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.BindingContext[rvisticol].Position = rvisticol.Count - 1;
            txtUID.Text = textBox2.Text;

            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.BindingContext[rvisticol].Position > 0)
            {
                this.BindingContext[rvisticol].Position--;
                txtUID.Text = textBox2.Text;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.BindingContext[rvisticol].Position = 0;
            txtUID.Text = textBox2.Text;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbParent.SelectedValue.ToString());
                    
            txtUID.Enabled = false;
            
            txtName.Enabled = false;
            txtNameSpace.Enabled = false;
            txtDesc.Enabled = false;
            cmbParent.Enabled = false;
            txtSlno.Enabled = false;
            
            chkActive.Enabled = false;
            btnAdd.Text = "&Add";
            btnEdit.Text = "&Edit";
            reset();
            nevigation("1");

            this.BindingContext[rvisticol].Position = 0;
            bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (0), rvisticol.Count);
            
        }

        #region reset
        public void reset()
        {
            txtUID.Text = "";

            txtName.Text = "";
            txtNameSpace.Text = "";
            txtDesc.Text = "";
            cmbParent.Text = "";
            txtSlno.Text = "";
            //txtButton3Caption.Text = "";

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            chkActive.Checked = false;
            chkActive.Enabled = false;

        }
        #endregion

        public void nevigation(String nv)
        {
            if (nv == "1")
            {
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void menu_PositionChanged(object sender, System.EventArgs e)
        {
            bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
            string uid = textBox2.Text.ToString();
            txtUID.Text = "";
            loadTree2(uid);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "&Edit")
            {
                if (txtUID.Text == "")
                {
                    msg.ShowAlert("UID005", env.CurrentLanguageID);
                    //MessageBox.Show("Menu UID can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    nevigation("0");

                    //txtUID.Enabled = true;

                    txtName.Enabled = true;
                    txtNameSpace.Enabled = true;
                    txtDesc.Enabled = true;
                    cmbParent.Enabled = true;
                    txtSlno.Enabled = true;

                    chkActive.Enabled = true;
                    btnEdit.Text = "&Update";
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                GBLMenu gblmenu = new GBLMenu();
                ProcessUpdateGBLMenu processmenu = new ProcessUpdateGBLMenu();
                gblmenu.MenuUID = txtUID.Text.ToString();
                //gblmenu.MenuUID = textBox2.Text.ToString();
                gblmenu.MenuName = txtName.Text.ToString();
                gblmenu.MenuNameSpace = txtNameSpace.Text.ToString();
                gblmenu.MenuDesc = txtDesc.Text.ToString();

                parentData selectedData = (parentData)cmbParent.SelectedItem;
                //MessageBox.Show(selectedData.Name + ":" + selectedData.Value); 

                if (cmbParent.Text == "")
                    gblmenu.MenuParent = 0;
                else
                    gblmenu.MenuParent = selectedData.Value;

                gblmenu.MenuSLNo = Convert.ToInt32(txtSlno.Text.ToString());

                gblmenu.OrgID = env.OrgID;
                gblmenu.CreatedBy = env.UserID;
                
                //CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                DateTime yourdatetime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());

                gblmenu.CreatedOn = "" + yourdatetime;
                //MessageBox.Show("Date" + yourdatetime);
                //gblalert.CreatedOn = yourdatetime;
                if (chkActive.Checked == true)
                {
                    gblmenu.MenuIsActive = "Y";
                }
                else
                {
                    gblmenu.MenuIsActive = "N";
                }
                
                gblmenu.MenuID = Convert.ToInt32(textBox1.Text.ToString());
                try
                {
                    ImageConverter imcon = new ImageConverter();
                    gblmenu.MenuICon = (byte[])imcon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                processmenu.GBLMenu = gblmenu;

                try
                {
                    processmenu.Invoke();
                    treeView1.Nodes.Clear();
                    loadTree("");

                    txtUID.Enabled = false;
                    txtName.Enabled = false;
                    txtNameSpace.Enabled = false;
                    txtDesc.Enabled = false;
                    cmbParent.Enabled = false;
                    txtSlno.Enabled = false;
                    chkActive.Enabled = false;
                    
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUID.Text == "")
            {
                msg.ShowAlert("UID005", env.CurrentLanguageID);
                //MessageBox.Show("UID can not blank !!");
            }
            else
            {
                //DialogResult ret = MessageBox.Show("Do you want to delete "+textBox1.Text.ToString()+"?","Delete Menu",MessageBoxButtons.YesNo);
                string ret = msg.ShowAlert("UID006", env.CurrentLanguageID);
                //msg.ToString()
                //MessageBox.Show(ret.ToString());
                //if (ret.ToString() == "Yes")
                if (ret.ToString() == "2")
                {
                    GBLMenu gblmenu = new GBLMenu();
                    ProcessDeleteGBLMenu processmenu = new ProcessDeleteGBLMenu();

                    gblmenu.MenuID = Convert.ToInt32(textBox1.Text.ToString());
                    processmenu.GBLMenu = gblmenu;

                    try
                    {
                        processmenu.Invoke();
                        treeView1.Nodes.Clear();
                        loadTree("");

                        reset();
                    }
                    catch { }
                }
            }
        }

        #region Editable
        public void editable()
        {

            txtUID.Enabled = true;

            txtName.Enabled = true;
            txtNameSpace.Enabled = true;
            txtDesc.Enabled = true;
            cmbParent.Enabled = true;
            txtSlno.Enabled = true;

            chkActive.Checked = false;
            chkActive.Enabled = true;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
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

                    int iCount = rvisticol.Count;
                    bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (iCount + 1), rvisticol.Count);

                }

                else
                {
                    ProcessAddGBLMenu processmenu = new ProcessAddGBLMenu();
                    GBLMenu gblmenu = new GBLMenu();

                    gblmenu.MenuUID = txtUID.Text.ToString();
                    //gblmenu.MenuUID = textBox2.Text.ToString();
                    gblmenu.MenuName = txtName.Text.ToString();
                    gblmenu.MenuNameSpace = txtNameSpace.Text.ToString();
                    gblmenu.MenuDesc = txtDesc.Text.ToString();

                    if (cmbParent.Text == "")
                        gblmenu.MenuParent = 0;
                    else
                    {
                        parentData selectedData = (parentData)cmbParent.SelectedItem;
                        //MessageBox.Show(selectedData.Name + ":" + selectedData.Value); 
                        gblmenu.MenuParent = selectedData.Value;
                        //gblmenu.MenuParent = Convert.ToInt32(cmbParent.Text.ToString());
                    }

                    gblmenu.MenuSLNo = Convert.ToInt32(txtSlno.Text.ToString());

                    gblmenu.OrgID = env.OrgID;
                    gblmenu.CreatedBy = env.UserID;

                    //CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                    DateTime yourdatetime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());

                    gblmenu.CreatedOn = "" + yourdatetime;
                    //MessageBox.Show("Date" + yourdatetime);
                    //gblalert.CreatedOn = yourdatetime;
                    if (chkActive.Checked == true)
                    {
                        gblmenu.MenuIsActive = "Y";
                    }
                    else
                    {
                        gblmenu.MenuIsActive = "N";
                    }

                    //gblmenu.MenuID = Convert.ToInt32(textBox1.Text.ToString());
                    gblmenu.MenuID = 0;
                    try
                    {
                        ImageConverter imcon = new ImageConverter();
                        gblmenu.MenuICon = (byte[])imcon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    processmenu.GBLMenu = gblmenu;

                    try
                    {
                        processmenu.Invoke();
                        treeView1.Nodes.Clear();
                        loadTree("");


                        txtUID.Enabled = false;

                        txtName.Enabled = false;
                        txtNameSpace.Enabled = false;
                        txtDesc.Enabled = false;
                        cmbParent.Enabled = false;
                        txtSlno.Enabled = false;

                        chkActive.Enabled = false;

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

        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //parentData selectedData = (parentData)cmbParent.SelectedItem; 
            //MessageBox.Show(selectedData.Name + ":" + selectedData.Value); 
        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }

        private void GBL_SF05_Load(object sender, EventArgs e)
        {

        }

        private void GBL_SF05_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Width.ToString()+this.Height.ToString());
            //MessageBox.Show(splitContainer1.Width.ToString() + splitContainer1.Height.ToString());
            splitContainer1.Width = this.Width-10;
            splitContainer1.Height = this.Height;
            nEntryContainer10.Height = this.splitContainer1.Height-50;
            treeView1.Height = nEntryContainer10.Height-50;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Trim() != "")
            { 
                using(Image im = Image.FromFile(openFileDialog1.FileName))
                {
                    pictureBox1.Image = (Image)im.Clone();
                }
            }
        }

    }
}