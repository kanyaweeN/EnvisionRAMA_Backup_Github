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

using RIS.Forms.Lookup;
using RIS.Forms.GBLMessage;
using System.Drawing.Drawing2D;

namespace RIS.Forms.Admin
{
    public partial class GBL_SF08 : Form
    {
        submenuobjectlabelObjectCollection rvisticol = new submenuobjectlabelObjectCollection();
        ProcessGetGBLSubMenuObjectLabel rhabvisitlistm = new ProcessGetGBLSubMenuObjectLabel();
        DBUtility dbu = new DBUtility();
        GBLEnvVariable env = new GBLEnvVariable();
        GBLExceptionLog elog = new GBLExceptionLog();

        MyMessageBox msg = new MyMessageBox();

        private UUL.ControlFrame.Controls.TabControl CloseControl;

        public DataSet _tempDataSet = new DataSet();

        List<GBLSubMenuObjectLabel> _deleteItem = new List<GBLSubMenuObjectLabel>();
        //private List<GBLSubMenuObjectLabel> _deleteItem = new List<GBLSubMenuObjectLabel>();

        public GBL_SF08(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();

            CloseControl = clsCtl;
            //LoadFormLanguage();
            ChangeFormLanguage();
            loadTree("");

            rvisticol = rhabvisitlistm.SelectData();

            //txtSubUID.DataBindings.Add("Text", rvisticol, "SubMenuUID");
            //txtUID.DataBindings.Add("Text", rvisticol, "MenuUID");

            // Get the BindingManagerBase for VisitList. 
            BindingManagerBase bmVisitList = this.BindingContext[rvisticol];

            // Add the delegate for the PositionChanged event.
            bmVisitList.PositionChanged += new EventHandler(submenu_PositionChanged);

            // Set up the initial text for the DATA VCR Panel
            //bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
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

                ProcessGetGBLSubMenuObjectLabel menu = new ProcessGetGBLSubMenuObjectLabel();
                if (uid == "")
                {
                    menu.SPType = 1;
                    menu.Invoke();
                    //MessageBox.Show("f");

                }
                else
                {

                    menu.UsID = "%" + uid.Trim() + "%";
                    menu.SPType = 0;
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
                    int c = -1;
                    int iLang = -1;
                    while (m < dt2.Rows.Count)
                    {
                        if (alist.Contains(dt2.Rows[m]["SUBMENU_UID"]))
                        {
                        }
                        else
                        {
                            alist.Add(dt2.Rows[m]["SUBMENU_UID"].ToString());
                            //parentList.Add(dt2.Rows[m]["PARENT"].ToString());
                            midList.Add(dt2.Rows[m]["SUBMENU_ID"].ToString());
                            c = -1;
                            treeView1.Nodes.Add(alist[i].ToString());
                            //treeView1.Nodes.Add(m.ToString(), alist[m].ToString());

                            k = 0;
                            while (k < dt2.Rows.Count)
                            {
                                if (midList[i].ToString() == dt2.Rows[k]["SUBMENU_ID"].ToString())
                                {
                                    TreeNode newNodes = new TreeNode(dt2.Rows[k]["OBJECT_NAME"].ToString());
                                    //newNodes.Tag = dt2.Rows[k]["SUBMENU_ID"].ToString();
                                    //newNodes.SelectedImageIndex = 1;
                                    //newNodes.ImageIndex = 1;

                                    if (!(k != 0 && dt2.Rows[k]["OBJECT_NAME"].ToString() == dt2.Rows[k - 1]["OBJECT_NAME"].ToString()))
                                    {
                                        iLang = -1;
                                        treeView1.Nodes[i].Nodes.Add(newNodes);
                                        c++;
                                    }

                                    if (!(k != 0 && dt2.Rows[k]["OBJECT_NAME"].ToString() == dt2.Rows[k - 1]["OBJECT_NAME"].ToString() && dt2.Rows[k]["LANG_NAME"].ToString() == dt2.Rows[k - 1]["LANG_NAME"].ToString()))
                                    {
                                        TreeNode idNodes = new TreeNode(dt2.Rows[k]["LANG_NAME"].ToString());
                                        //newNodes.Tag = dt2.Rows[k]["SUBMENU_ID"].ToString();
                                        idNodes.SelectedImageIndex = 1;
                                        idNodes.ImageIndex = 1;
                                        treeView1.Nodes[i].Nodes[c].Nodes.Add(idNodes);
                                        iLang++;
                                    }

                                    TreeNode iLangNodes = new TreeNode(dt2.Rows[k]["LABEL"].ToString());
                                    //newNodes.Tag = dt2.Rows[k]["SUBMENU_ID"].ToString();
                                    iLangNodes.SelectedImageIndex = 1;
                                    iLangNodes.ImageIndex = 1;
                                    treeView1.Nodes[i].Nodes[c].Nodes[iLang].Nodes.Add(iLangNodes);
                                    
                                    
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

                //treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        #endregion

        #region LoadTree2
        public void loadTree2(string uid, string pid)
        {
            try
            {

                ProcessGetGBLSubMenuObjectLabel menu = new ProcessGetGBLSubMenuObjectLabel();
                menu.UsID = uid.Trim();
                menu.PsID = Convert.ToInt32(pid);
                menu.SPType = 2;
                menu.Invoke();

                ProcessGetGBLSubMenuObjectLabel submenu = new ProcessGetGBLSubMenuObjectLabel();
                submenu.UsID = uid.Trim();
                submenu.PsID = Convert.ToInt32(pid);
                submenu.SPType = 3;
                submenu.Invoke();

                _tempDataSet = submenu.ResultSet;
                grdObjects.DataSource = _tempDataSet.Tables[0];

                ProcessGetGBLSubMenuObjectLabel objname = new ProcessGetGBLSubMenuObjectLabel();
                objname.UsID = uid.Trim();
                //menu.PsID = pid.Trim();
                objname.SPType = 4;
                objname.Invoke();

                if (grdObjects.Columns.Contains("Object_Name"))
                    grdObjects.Columns.Remove("Object_Name");

                if (grdObjects.Columns.Contains("Object Name"))
                    grdObjects.Columns.Remove("Object Name");

                DataGridViewComboBoxColumn grdCombo = new DataGridViewComboBoxColumn();
                grdCombo.Name = "Object_Name";
                grdCombo.DataSource = objname.ResultSet.Tables[0];
                grdCombo.ValueMember = "OBJECT_NAME";
                grdCombo.DisplayMember = "OBJECT_NAME";
                grdCombo.DataPropertyName = "OBJECT_NAME";
                grdObjects.Columns.Insert(2, grdCombo);

                DataTable dt2 = menu.ResultSet.Tables[0];

                int k = 0;
                while (k < dt2.Rows.Count)
                {
                    txtSubUID.Text = dt2.Rows[0]["SUBMENU_UID"].ToString();
                    txtSubNameUser.Text = dt2.Rows[0]["SUBMENU_NAME_USER"].ToString();

                    txtLangID.Text = dt2.Rows[0]["LANG_ID"].ToString();
                    txtLangName.Text = dt2.Rows[0]["LANG_NAME"].ToString();

                    //grdObjects.Rows[k].Cells["Object_Type"].Value = dt2.Rows[k]["OBJECT_TYPE"].ToString().Trim(); 

                    k++;
                    //break;
                    /*
                    DataRow myDataRow = dataTable.NewRow();
                    myDataRow["OBJECT_TYPE"] = dt2.Rows[k]["OBJECT_TYPE"].ToString();
                    myDataRow["OBJECT_NAME"] = dt2.Rows[k]["OBJECT_NAME"].ToString();
                    myDataRow["OBJECT_ID"] = Convert.ToInt32(dt2.Rows[k]["OBJECT_ID"].ToString());
                    dataTable.Rows.Add(myDataRow);
                     */
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


        private void button2_Click(object sender, EventArgs e)
        {
            Lookup.Lookup lv = new Lookup.Lookup();
            lv.ValueUpdated += new ValueUpdatedEventHandler(childA_ValueUpdated);
            string qry = "SELECT SUBMENU_UID,SUBMENU_NAME_USER from GBL_SUBMENU where SUBMENU_UID like '%%'";
            string fields = "SUBMENU UID,SUBMENU NAME";
            string con = "";
            lv.getData(qry, fields, con, "SURAJIT");
            lv.Show();

        }

        private void ChangeFormLanguage()
        {


            FormLanguage fl = new FormLanguage();
            fl.FormID = 16;
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
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnAdd").ToUpper().Trim())
                        btnAdd.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblObjectName").ToUpper().Trim())
                        Object_Name.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnDelete").ToUpper().Trim())
                        btnDelete.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnRefresh").ToUpper().Trim())
                        btnRefresh.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblLabel").ToUpper().Trim())
                        Label.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnClose").ToUpper().Trim())
                        btnClose.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubUID").ToUpper().Trim())
                        lblSubUID.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubName").ToUpper().Trim())
                        lblSubName.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblLangID").ToUpper().Trim())
                        lblLangID.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblLangName").ToUpper().Trim())
                        lblLangName.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnSave").ToUpper().Trim())
                        btnSave.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblObjects").ToUpper().Trim())
                        nGrouper1.HeaderItem.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    k++;
                }



            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

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
                txtSubUID.Text = retValue[0].ToString();
                txtSubNameUser.Text = retValue[1].ToString();

                //if (_tempDataSet > 0)
                //    grdObjects.Rows.Clear();

                //loadTree2(txtSubUID.Text, "");

            }
            else
            {
                //txtCpoName.Text = retValue[0].ToString();
                //cpoNo = Convert.ToInt32(retValue[1].ToString());
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            loadTree("" + txtSearch.Text.ToString().Trim() + "");
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void GBL_SF08_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Width.ToString()+this.Height.ToString());
            //MessageBox.Show(splitContainer1.Width.ToString() +"|"+ splitContainer1.Height.ToString());
            //splitContainer1.Width = this.Width - 10;
            //MessageBox.Show(splitContainer1.Panel1.Width.ToString()+"|"+treeView1.Width);
            splitContainer1.Height = this.Height;
            nEntryContainer10.Height = this.splitContainer1.Height - 50;
            treeView1.Height = nEntryContainer10.Height - 50;

            nEntryContainer10.Width = this.splitContainer1.Panel1.Width;
            treeView1.Width = nEntryContainer10.Width - 15;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {/*
            try
            {
                if (e.Node.Parent == null)
                {
                    string uid = treeView1.SelectedNode.Text.ToString();
                    //MessageBox.Show(treeView1.SelectedNode.ImageIndex.ToString());
                    //string pid = treeView1.SelectedNode.Parent.Text.ToString();
                    //MessageBox.Show (treeView1.SelectedNode.Parent.Text.ToString());

                    //string uid = treeView1.SelectedNode.Tag.ToString();
                    loadTree2(uid, "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                elog.LogException(ex.ToString(), env.CurrentFormID, "F");
                return;
            }
          */
        }

        private void submenu_PositionChanged(object sender, System.EventArgs e)
        {
            //bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (this.BindingContext[rvisticol].Position + 1), rvisticol.Count);
            /*string uid = txtSubUID.Text.ToString();
            string pid = txtUID.Text.ToString();
            txtSubUID.Text = "";
            txtUID.Text = "";
            loadTree2(uid, pid);
             */
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grdObjects.Enabled = true;
            button2.Enabled = true;
            button1.Enabled = true;

            if (txtSubUID.Text != "")
            {
                grdObjects.CommitEdit(new DataGridViewDataErrorContexts());
                _tempDataSet.Tables[0].Rows.Add(new object[2]);
            }
            
        }

        private void Binding()
        {
            _deleteItem.Clear();
            reset();

        }

        #region reset
        public void reset()
        {
            txtSubUID.Text = "";
            txtSubNameUser.Text = "";

            txtLangID.Text = "";
            txtLangName.Text = "";

            if (_tempDataSet.Tables.Count > 0)
                _tempDataSet.Tables[0].Clear();
            //grdObjects.DataSource = null;
            //grdObjects.Rows.Clear();

            btnAdd.Enabled = true;
            btnSave.Enabled = true;
            //btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            //chkActive.Checked = false;
            //chkActive.Enabled = false;

        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            grdObjects.CommitEdit(new DataGridViewDataErrorContexts());

            for (int i = 0; i < grdObjects.Rows.Count; i++)  //foreach (DataGridViewRow row in grdLang.Rows)
            {
                bool isDelete = false;
                try
                {
                    isDelete = (bool)grdObjects.Rows[i].Cells[0].Value;
                }
                catch 
                {
                }

                if (isDelete)
                {
                    if (grdObjects.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        GBLSubMenuObjectLabel item = new GBLSubMenuObjectLabel();
                        item.SubMenuUID = txtSubUID.Text;
                        item.LangID = Convert.ToInt32(txtLangID.Text);
                        item.ObjectID = Convert.ToInt32(grdObjects.Rows[i].Cells[1].Value.ToString());
                        _deleteItem.Add(item);
                    }
                    _tempDataSet.Tables[0].Rows.RemoveAt(i);
                    i = -1;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Binding();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            grdObjects.CommitEdit(new DataGridViewDataErrorContexts());

            //if (MessageBox.Show("Are you sure you want to save the data? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            string ret = msg.ShowAlert("UID008", env.CurrentLanguageID);
            if (ret.ToString() == "2")
            {
                List<GBLSubMenuObjectLabel> insertLanguage = new List<GBLSubMenuObjectLabel>();
                List<GBLSubMenuObjectLabel> updateLanguage = new List<GBLSubMenuObjectLabel>();

                foreach (DataGridViewRow row in grdObjects.Rows)
                {
                    if (row.Cells[1].Value.ToString() != "")
                    {
                        
                        DateTime yourdatetime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());
                        updateLanguage.Add(new GBLSubMenuObjectLabel(txtSubUID.Text, Int32.Parse(row.Cells["Object_ID"].Value.ToString()),
                            Convert.ToInt32(txtLangID.Text), row.Cells["Label"].Value.ToString(),
                            env.OrgID, env.UserID, "" + yourdatetime, row.Cells["Object_Name"].Value.ToString()));
                        
                    }
                    else
                    {
                        DateTime yourdatetime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());
                        insertLanguage.Add(new GBLSubMenuObjectLabel(txtSubUID.Text, 0,
                            Convert.ToInt32(txtLangID.Text), row.Cells["Label"].Value.ToString(),
                            env.OrgID, env.UserID, "" + yourdatetime, row.Cells["Object_Name"].Value.ToString()));
                    }
                }

                if (_deleteItem.Count > 0)
                {
                    ProcessDeleteGBLSubMenuObjectLabel process = new ProcessDeleteGBLSubMenuObjectLabel();
                    process.DeleteItem = _deleteItem;
                    //procees.GBLSubMenuObjectLabel = _deleteItem;
                    //process.DeleteItem = _deleteItem;
                    process.Invoke();
                }

                if (insertLanguage.Count > 0)
                {
                    ProcessAddGBLSubMenuObjectLabel process = new ProcessAddGBLSubMenuObjectLabel();
                    process.ObjectsItem = insertLanguage;
                    process.Invoke();
                }

                if (updateLanguage.Count > 0)
                {
                    ProcessUpdateGBLSubMenuObjectLabel process = new ProcessUpdateGBLSubMenuObjectLabel();
                    process.ObjectsItem = updateLanguage;
                    process.Invoke();
                }



            }
            Binding();
            treeView1.Nodes.Clear();
            loadTree("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lookup.Lookup lv = new Lookup.Lookup();
            lv.ValueUpdated += new ValueUpdatedEventHandler(ChildLang_ValueUpdated);
            string qry = "SELECT LANG_ID,LANG_NAME from GBL_LANGUAGE where LANG_ID like '%%'";
            string fields = "LANGUAGE ID,LANGUAGE NAME";
            string con = "";
            lv.getData(qry, fields, con, "SURAJIT");
            lv.Show();

        }

        private void ChildLang_ValueUpdated(object sender, ValueUpdatedEventArgs e)
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
                txtLangID.Text = retValue[0].ToString();
                txtLangName.Text = retValue[1].ToString();
                loadTree2(txtSubUID.Text, txtLangID.Text);

            }
            else
            {
                //txtCpoName.Text = retValue[0].ToString();
                //cpoNo = Convert.ToInt32(retValue[1].ToString());
            }
        }

        private void GBL_SF08_Load(object sender, EventArgs e)
        {

        }

    }
}