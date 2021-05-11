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
using RIS.Forms.Lookup;

namespace RIS.Forms.Admin
{
    public partial class GBL_SF06 : Form
    {
        submenuObjectCollection rvisticol = new submenuObjectCollection();
        ProcessGetGBLSubMenu rhabvisitlistm = new ProcessGetGBLSubMenu();
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

        public GBL_SF06(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            //LoadFormLanguage();
            ChangeFormLanguage();
            loadTree("");

            rvisticol = rhabvisitlistm.SelectData();

            textBox4.DataBindings.Add("Text", rvisticol, "SubMenuUID");
            textBox3.DataBindings.Add("Text", rvisticol, "MenuUID");

            // Get the BindingManagerBase for VisitList. 
            BindingManagerBase bmVisitList = this.BindingContext[rvisticol];

            // Add the delegate for the PositionChanged event.
            bmVisitList.PositionChanged += new EventHandler(submenu_PositionChanged);

            // Set up the initial text for the DATA VCR Panel
            bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
            
        }

        private void ChangeFormLanguage()
        {


            FormLanguage fl = new FormLanguage();
            fl.FormID = 6;
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
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkActive").ToUpper().Trim())
                        chkActive.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkView").ToUpper().Trim())
                        chkView.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkModify").ToUpper().Trim())
                        chkModify.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkRemove").ToUpper().Trim())
                        chkRemove.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkAddToHome").ToUpper().Trim())
                        chkAddToHome.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkCreate").ToUpper().Trim())
                        chkCreate.Text = dt.Rows[k]["LABEL"].ToString().Trim();
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

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubUID").ToUpper().Trim())
                        lblSubUID.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubName").ToUpper().Trim())
                        lblSubName.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubClass").ToUpper().Trim())
                        lblSubClass.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubSys").ToUpper().Trim())
                        lblSubSys.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblParent").ToUpper().Trim())
                        lblParent.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSerial").ToUpper().Trim())
                        lblSerial.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblDesc").ToUpper().Trim())
                        lblDesc.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblObjects").ToUpper().Trim())
                        nGrouper1.HeaderItem.Text = dt.Rows[k]["LABEL"].ToString().Trim();

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

                ProcessGetGBLSubMenu menu = new ProcessGetGBLSubMenu();
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
                    int k = 0;
                    int i = 0;
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
                                cmbParent.Items.Add(new parentData(dt2.Rows[m]["MENU_UID"].ToString(),
                                    Convert.ToInt32(dt2.Rows[m]["MENU_ID"].ToString())));

                            treeView1.Nodes.Add(alist[i].ToString());
                            //treeView1.Nodes.Add(m.ToString(), alist[m].ToString());

                            k = 0;
                            while (k < dt2.Rows.Count)
                            {
                                if (midList[i].ToString() == dt2.Rows[k]["MENU_ID"].ToString())
                                {
                                    TreeNode newNodes = new TreeNode(dt2.Rows[k]["SUBMENU_UID"].ToString());
                                    newNodes.Tag = dt2.Rows[k]["SUBMENU_ID"].ToString();
                                    newNodes.SelectedImageIndex = 1;
                                    newNodes.ImageIndex = 1;
                                    treeView1.Nodes[i].Nodes.Add(newNodes);
                                }
                                k++;
                            }
                            i++;
                        }
                        m++;
                    }

                    //ArrayList il = new ArrayList();
                    //setTreeView(alist, midList, parentList, 0, 0, il, 0);

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
        public void loadTree2(string uid, string pid)
        {
            try
            {

                ProcessGetGBLSubMenu menu = new ProcessGetGBLSubMenu();


                menu.UsID = uid.Trim();
                menu.PsID = pid.Trim();
                

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
                    textBox3.Text = dt2.Rows[0]["MENU_UID"].ToString();

                    txtName.Text = dt2.Rows[0]["MENU_NAME"].ToString();
                    textBox2.Text = dt2.Rows[0]["SUBMENU_ID"].ToString();

                    txtSubUID.Text = dt2.Rows[0]["SUBMENU_UID"].ToString();
                    textBox4.Text = dt2.Rows[0]["SUBMENU_UID"].ToString();

                    txtSubClassName.Text = dt2.Rows[0]["SUBMENU_CLASS_NAME"].ToString();
                    txtSubNameUser.Text = dt2.Rows[0]["SUBMENU_NAME_USER"].ToString();
                    txtSubType.Text = dt2.Rows[0]["SUBMENU_TYPE"].ToString();
                    txtSubNameSys.Text = dt2.Rows[0]["SUBMENU_NAME_SYS"].ToString();

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

                    aa = dt2.Rows[0]["CAN_VIEW"].ToString();
                    if (aa == "N")
                    {
                        chkView.Checked = false;
                    }
                    else
                    {
                        chkView.Checked = true;
                    }

                    aa = dt2.Rows[0]["CAN_REMOVE"].ToString();
                    if (aa == "N")
                    {
                        chkRemove.Checked = false;
                    }
                    else
                    {
                        chkRemove.Checked = true;
                    }

                    aa = dt2.Rows[0]["CAN_CREATE"].ToString();
                    if (aa == "N")
                    {
                        chkCreate.Checked = false;
                    }
                    else
                    {
                        chkCreate.Checked = true;
                    }

                    aa = dt2.Rows[0]["CAN_MODIFY"].ToString();
                    if (aa == "N")
                    {
                        chkModify.Checked = false;
                    }
                    else
                    {
                        chkModify.Checked = true;
                    }

                    aa = dt2.Rows[0]["ADD_TO_HOME"].ToString();
                    if (aa == "N")
                    {
                        chkAddToHome.Checked = false;
                    }
                    else
                    {
                        chkAddToHome.Checked = true;
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
                if (btnEdit.Text == "&Edit")
                {

                    if (e.Node.LastNode == null)
                    {
                        string uid = treeView1.SelectedNode.Text.ToString();
                        //MessageBox.Show(treeView1.SelectedNode.ImageIndex.ToString());
                        string pid = treeView1.SelectedNode.Parent.Text.ToString();
                        //MessageBox.Show (treeView1.SelectedNode.Parent.Text.ToString());
                        /*
                        this.BindingContext[rvisticol].Position = 0;
                        for (int i = 0; i < rvisticol.Count; i++)
                        {
                            if (rvisticol[i].MenuID.ToString() == textBox1.Text && rvisticol[i].SubMenuID.ToString() == textBox2.Text)
                                this.BindingContext[rvisticol].Position = i;
                        }

                        bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
                        */
                        //string uid = treeView1.SelectedNode.Tag.ToString();
                        loadTree2(uid, pid);
                    }
                }
                else
                {
                    msg.ShowAlert("UID009", env.CurrentLanguageID);
                    return;
                }

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

        private void submenu_PositionChanged(object sender, System.EventArgs e)
        {
            bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
            string uid = textBox4.Text.ToString();
            string pid = textBox3.Text.ToString();
            txtSubUID.Text = "";
            txtUID.Text = "";
            loadTree2(uid,pid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lookup.Lookup lv = new Lookup.Lookup();
            lv.ValueUpdated += new ValueUpdatedEventHandler(childA_ValueUpdated);
            string qry = "SELECT MENU_UID,MENU_NAME from GBL_MENU where MENU_UID like '%%'";
            string fields = "MENU UID,MENU NAME";
            string con = "";
            lv.getData(qry, fields, con, "SURAJIT");
            lv.Show();
        }

        private void childA_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            //You will get your required value through a string(e.NewValue)
            //And now you can utilize the string by split function
            //Split function will return you a array type string 
            //You will get the data in the sequence of tableField name you set previously          
            int lovNo = 1;
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            if (lovNo == 1)
            {
                //MessageBox.Show("" + retValue[0].ToString());
                txtUID.Text = retValue[0].ToString();
                txtName.Text = retValue[1].ToString();

                textBox3.Text = retValue[0].ToString();
                //disCode = Convert.ToInt32(retValue[1].ToString());
            }
            else
            {
                //txtCpoName.Text = retValue[0].ToString();
                //cpoNo = Convert.ToInt32(retValue[1].ToString());
            }
            //}
            //else if (lovNo == 2)
            //{
            //    txtPreparedBy.Text = "" + retValue[0].ToString() + " " + retValue[1].ToString() + "";
            //    txtDesignation.Text = retValue[2].ToString();
            //    userNo = Convert.ToInt32(retValue[3].ToString());
            //}
            //else if (lovNo == 3)
            //{
            //    txtCpoName.Text = retValue[0].ToString();
            //    cpoNo = Convert.ToInt32(retValue[1].ToString());
            //}
            //else if (lovNo == 4)
            //{
            //    txtCheckedBy.Text = "" + retValue[0].ToString() + " " + retValue[1].ToString() + "";
            //    txtDesigChecked.Text = retValue[2].ToString();
            //    cheByNo = Convert.ToInt32(retValue[3].ToString());
            //}
            //else
            //{
            //    proComNo = Convert.ToInt32(retValue[2].ToString());
            //    loadCopletedProjectInfo(Convert.ToInt32(retValue[2].ToString()), retValue[1].ToString());
            //}
        }
        #region Editable
        public void editable()
        {
            txtUID.Enabled = true;
            button2.Enabled = true;
            txtName.Enabled = true;

            txtSubUID.Enabled = true;
            txtSubClassName.Enabled = true;
            txtSubNameUser.Enabled = true;
            txtSubType.Enabled = true;
            txtSubNameSys.Enabled = true;

            txtDesc.Enabled = true;

            cmbParent.Enabled = true;
            txtSlno.Enabled = true;

            chkActive.Checked = false;
            chkActive.Enabled = true;

            chkView.Checked = false;
            chkView.Enabled = true;

            chkRemove.Checked = false;
            chkRemove.Enabled = true;

            chkCreate.Checked = false;
            chkCreate.Enabled = true;

            chkModify.Checked = false;
            chkModify.Enabled = true;

            chkAddToHome.Checked = false;
            chkAddToHome.Enabled = true;

        }
        #endregion

        #region reset
        public void reset()
        {
            txtUID.Text = "";
            txtName.Text = "";

            txtSubUID.Text = "";
            txtSubClassName.Text = "";
            txtSubNameUser.Text = "";
            txtSubType.Text = "";
            txtSubNameSys.Text = "";

            txtDesc.Text = "";

            cmbParent.Text = "";
            txtSlno.Text = "";
            chkActive.Checked = false;
            chkActive.Enabled = false;

            chkView.Checked = false;
            chkView.Enabled = false;
            chkRemove.Checked = false;
            chkRemove.Enabled = false;
            chkCreate.Checked = false;
            chkCreate.Enabled = false;
            chkModify.Checked = false;
            chkModify.Enabled = false;
            chkAddToHome.Checked = false;
            chkAddToHome.Enabled = false;
            
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtUID.Enabled = false;
            button2.Enabled = false;
            txtName.Enabled = false;

            txtSubUID.Enabled = false;
            txtSubClassName.Enabled = false;
            txtSubNameUser.Enabled = false;
            txtSubType.Enabled = false;
            txtSubNameSys.Enabled = false;

            txtDesc.Enabled = false;

            cmbParent.Enabled = false;
            txtSlno.Enabled = false;
            btnAdd.Text = "&Add";
            btnEdit.Text = "&Edit";
            this.BindingContext[rvisticol].Position = -1;
            bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (0), rvisticol.Count);
            reset();
            nevigation("1");
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.BindingContext[rvisticol].Position = 0;
            txtSubUID.Text = textBox4.Text;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.BindingContext[rvisticol].Position > 0)
            {
                this.BindingContext[rvisticol].Position--;
                txtSubUID.Text = textBox4.Text;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.BindingContext[rvisticol].Position < rvisticol.Count - 1)
            {
                this.BindingContext[rvisticol].Position++;
                txtSubUID.Text = textBox4.Text;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.BindingContext[rvisticol].Position = rvisticol.Count - 1;
            txtSubUID.Text = textBox4.Text;
        }

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
                    chkView.Enabled = true;
                    chkRemove.Enabled = true;
                    chkModify.Enabled = true;
                    chkCreate.Enabled = true;
                    chkAddToHome.Enabled = true;

                    int iCount = rvisticol.Count;
                    bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (iCount + 1), rvisticol.Count);
                }

                else
                {
                    ProcessAddGBLSubMenu processmenu = new ProcessAddGBLSubMenu();
                    GBLSubMenu gblsubmenu = new GBLSubMenu();

                    gblsubmenu.MenuUID = txtUID.Text.ToString();
                    gblsubmenu.SubMenuUID = txtSubUID.Text.ToString();

                    //gblsubmenu.MenuUID = textBox3.Text.ToString();
                    //gblsubmenu.SubMenuUID = textBox4.Text.ToString();

                    gblsubmenu.SubMenuClassName = txtSubClassName.Text.ToString();
                    gblsubmenu.SubMenuNameUser = txtSubNameUser.Text.ToString();
                    gblsubmenu.SubMenuType = txtSubType.Text.ToString();
                    gblsubmenu.SubMenuNameSys = txtSubNameSys.Text.ToString();
                    gblsubmenu.SubMenuDesc = txtDesc.Text.ToString();

                    if (cmbParent.Text == "")
                        gblsubmenu.SubMenuParent = 0;
                    else
                    {
                        parentData selectedData = (parentData)cmbParent.SelectedItem;
                        //MessageBox.Show(selectedData.Name + ":" + selectedData.Value); 
                        gblsubmenu.SubMenuParent = selectedData.Value;
                        //gblmenu.MenuParent = Convert.ToInt32(cmbParent.Text.ToString());
                    }

                    if (txtSlno.Text == "")
                        gblsubmenu.SubMenuSlNo = Convert.ToInt32(null);
                    else
                        gblsubmenu.SubMenuSlNo = Convert.ToInt32(txtSlno.Text.ToString());

                    gblsubmenu.OrgID = env.OrgID;
                    gblsubmenu.CreatedBy = env.UserID;

                    //CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                    DateTime yourdatetime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());

                    gblsubmenu.CreatedOn = "" + yourdatetime;
                    //MessageBox.Show("Date" + yourdatetime);
                    //gblalert.CreatedOn = yourdatetime;
                    if (chkActive.Checked == true)
                    {
                        gblsubmenu.SubMenuIsActive = "Y";
                    }
                    else
                    {
                        gblsubmenu.SubMenuIsActive = "N";
                    }

                    if (chkCreate.Checked == true)
                    {
                        gblsubmenu.SubMenuCanCreate = "Y";
                    }
                    else
                    {
                        gblsubmenu.SubMenuCanCreate = "N";
                    }

                    if (chkModify.Checked == true)
                    {
                        gblsubmenu.SubMenuCanModify = "Y";
                    }
                    else
                    {
                        gblsubmenu.SubMenuCanModify = "N";
                    }

                    if (chkRemove.Checked == true)
                    {
                        gblsubmenu.SubMenuCanRemove = "Y";
                    }
                    else
                    {
                        gblsubmenu.SubMenuCanRemove = "N";
                    }

                    if (chkView.Checked == true)
                    {
                        gblsubmenu.SubMenuCanView = "Y";
                    }
                    else
                    {
                        gblsubmenu.SubMenuCanView = "N";
                    }

                    if (chkAddToHome.Checked == true)
                    {
                        gblsubmenu.SubMenuAddToHome = "Y";
                    }
                    else
                    {
                        gblsubmenu.SubMenuAddToHome = "N";
                    }

                    

                    //gblmenu.MenuID = Convert.ToInt32(textBox1.Text.ToString());
                    //gblsubmenu.MenuID = 0;

                    processmenu.GBLSubMenu = gblsubmenu;

                    try
                    {
                        processmenu.Invoke();
                        treeView1.Nodes.Clear();
                        loadTree("");


                        txtUID.Enabled = false;
                        button2.Enabled = false;
                        txtName.Enabled = false;

                        txtSubUID.Enabled = false;
                        txtSubClassName.Enabled = false;
                        txtSubNameUser.Enabled = false;
                        txtSubType.Enabled = false;
                        txtSubNameSys.Enabled = false;

                        txtDesc.Enabled = false;

                        cmbParent.Enabled = false;
                        txtSlno.Enabled = false;

                        chkActive.Enabled = false;
                        chkView.Enabled = false;
                        chkRemove.Enabled = false;
                        chkModify.Enabled = false;
                        chkCreate.Enabled = false;
                        chkAddToHome.Enabled = false;

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "&Edit")
            {
                if (txtSubUID.Text == "")
                {
                    msg.ShowAlert("UID007", env.CurrentLanguageID);
                    //MessageBox.Show("Sub Menu UID can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    nevigation("0");

                    //txtUID.Enabled = true;


                    txtUID.Enabled = true;
                    button2.Enabled = true;
                    txtName.Enabled = true;

                    txtSubUID.Enabled = true;
                    txtSubClassName.Enabled = true;
                    txtSubNameUser.Enabled = true;
                    txtSubType.Enabled = true;
                    txtSubNameSys.Enabled = true;

                    txtDesc.Enabled = true;

                    cmbParent.Enabled = true;
                    txtSlno.Enabled = true;

                    chkActive.Enabled = true;
                    chkView.Enabled = true;
                    chkRemove.Enabled = true;
                    chkModify.Enabled = true;
                    chkCreate.Enabled = true;
                    chkAddToHome.Enabled = true;

                    btnEdit.Text = "&Update";
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                GBLSubMenu gblsubmenu = new GBLSubMenu();
                ProcessUpdateGBLSubMenu processmenu = new ProcessUpdateGBLSubMenu();

                gblsubmenu.MenuUID = txtUID.Text.ToString();
                gblsubmenu.SubMenuUID = txtSubUID.Text.ToString();

                //gblsubmenu.MenuUID = textBox3.Text.ToString();
                //gblsubmenu.SubMenuUID = textBox4.Text.ToString();

                gblsubmenu.SubMenuClassName = txtSubClassName.Text.ToString();
                gblsubmenu.SubMenuNameUser = txtSubNameUser.Text.ToString();
                gblsubmenu.SubMenuType = txtSubType.Text.ToString();
                gblsubmenu.SubMenuNameSys = txtSubNameSys.Text.ToString();
                gblsubmenu.SubMenuDesc = txtDesc.Text.ToString();

                if (cmbParent.Text == "")
                    gblsubmenu.SubMenuParent = 0;
                else
                {
                    parentData selectedData = (parentData)cmbParent.SelectedItem;
                    //MessageBox.Show(selectedData.Name + ":" + selectedData.Value); 
                    gblsubmenu.SubMenuParent = selectedData.Value;
                    //gblmenu.MenuParent = Convert.ToInt32(cmbParent.Text.ToString());
                }

                if (txtSlno.Text == "")
                    gblsubmenu.SubMenuSlNo = Convert.ToInt32(null);
                else
                    gblsubmenu.SubMenuSlNo = Convert.ToInt32(txtSlno.Text.ToString());

                gblsubmenu.OrgID = env.OrgID;
                gblsubmenu.CreatedBy = env.UserID;

                //CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                DateTime yourdatetime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());

                gblsubmenu.CreatedOn = "" + yourdatetime;
                //MessageBox.Show("Date" + yourdatetime);
                //gblalert.CreatedOn = yourdatetime;
                if (chkActive.Checked == true)
                {
                    gblsubmenu.SubMenuIsActive = "Y";
                }
                else
                {
                    gblsubmenu.SubMenuIsActive = "N";
                }

                if (chkCreate.Checked == true)
                {
                    gblsubmenu.SubMenuCanCreate = "Y";
                }
                else
                {
                    gblsubmenu.SubMenuCanCreate = "N";
                }

                if (chkModify.Checked == true)
                {
                    gblsubmenu.SubMenuCanModify = "Y";
                }
                else
                {
                    gblsubmenu.SubMenuCanModify = "N";
                }

                if (chkRemove.Checked == true)
                {
                    gblsubmenu.SubMenuCanRemove = "Y";
                }
                else
                {
                    gblsubmenu.SubMenuCanRemove = "N";
                }

                if (chkView.Checked == true)
                {
                    gblsubmenu.SubMenuCanView = "Y";
                }
                else
                {
                    gblsubmenu.SubMenuCanView = "N";
                }

                if (chkAddToHome.Checked == true)
                {
                    gblsubmenu.SubMenuAddToHome = "Y";
                }
                else
                {
                    gblsubmenu.SubMenuAddToHome = "N";
                }

                gblsubmenu.SubMenuID = Convert.ToInt32(textBox2.Text.ToString());
                processmenu.GBLSubMenu = gblsubmenu;

                try
                {
                    processmenu.Invoke();
                    treeView1.Nodes.Clear();
                    loadTree("");


                    txtUID.Enabled = false;
                    button2.Enabled = false;
                    txtName.Enabled = false;

                    txtSubUID.Enabled = false;
                    txtSubClassName.Enabled = false;
                    txtSubNameUser.Enabled = false;
                    txtSubType.Enabled = false;
                    txtSubNameSys.Enabled = false;

                    txtDesc.Enabled = false;

                    cmbParent.Enabled = false;
                    txtSlno.Enabled = false;

                    chkActive.Enabled = false;
                    chkView.Enabled = false;
                    chkRemove.Enabled = false;
                    chkModify.Enabled = false;
                    chkCreate.Enabled = false;
                    chkAddToHome.Enabled = false;

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
                //MessageBox.Show("UID can not blank !!");
                msg.ShowAlert("UID007", env.CurrentLanguageID);
            }
            else
            {
                //DialogResult ret = MessageBox.Show("Do you want to delete " + txtSubUID.Text.ToString() + "?", "Delete Menu", MessageBoxButtons.YesNo);
                //MessageBox.Show(ret.ToString());
                string ret = msg.ShowAlert("UID011", env.CurrentLanguageID);
                //if (ret.ToString() == "Yes")
                if (ret.ToString() == "2")
                {
                    GBLSubMenu gblsubmenu = new GBLSubMenu();
                    ProcessDeleteGBLSubMenu processmenu = new ProcessDeleteGBLSubMenu();

                    gblsubmenu.SubMenuID = Convert.ToInt32(textBox2.Text.ToString());
                    gblsubmenu.MenuID = Convert.ToInt32(textBox1.Text.ToString());
                    processmenu.GBLSubMenu = gblsubmenu;

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

        private void GBL_SF06_Load(object sender, EventArgs e)
        {

        }

        private void GBL_SF06_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Width.ToString()+this.Height.ToString());
            //MessageBox.Show(splitContainer1.Width.ToString() + splitContainer1.Height.ToString());
            splitContainer1.Width = this.Width - 10;
            splitContainer1.Height = this.Height;
            nEntryContainer10.Height = this.splitContainer1.Height - 50;
            treeView1.Height = nEntryContainer10.Height - 50;
        }
    }
}