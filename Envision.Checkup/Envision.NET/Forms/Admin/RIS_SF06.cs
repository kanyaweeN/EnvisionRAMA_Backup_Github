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

using RIS.Forms.Lookup;

namespace RIS.Forms.Admin
{
    public partial class RIS_SF06 : Form
    {
        submenuObjectCollection rvisticol = new submenuObjectCollection();
        //ProcessGetGBLSubMenu rhabvisitlistm = new ProcessGetGBLSubMenu();
        ProcessGetRISExaminstructions  rhabvisitlistm = new ProcessGetRISExaminstructions();
        DBUtility dbu = new DBUtility();
        GBLEnvVariable env = new GBLEnvVariable();
        GBLExceptionLog elog = new GBLExceptionLog();
        int TreeLevel = 0;
        MyMessageBox msg = new MyMessageBox();
        private BindingSource bs;
        string Exam_id = "0";
        string INS_ID = "0";
        string Exam_Type = "0";

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

        public RIS_SF06(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            //LoadFormLanguage();
            //ChangeFormLanguage();
            loadTree("");

            //rvisticol = rhabvisitlistm.SelectData();
            

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
            //fl.FormID = 6;
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
                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkActive").ToUpper().Trim())
                    //    chkActive.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkView").ToUpper().Trim())
                    //    chkView.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkModify").ToUpper().Trim())
                    //    chkModify.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkRemove").ToUpper().Trim())
                    //    chkRemove.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkAddToHome").ToUpper().Trim())
                    //    chkAddToHome.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("chkCreate").ToUpper().Trim())
                    //    chkCreate.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    //
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

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubUID").ToUpper().Trim())
                    //    lblSubUID.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubName").ToUpper().Trim())
                    //    lblSubName.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubClass").ToUpper().Trim())
                    //    lblSubClass.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSubSys").ToUpper().Trim())
                    //    lblSubSys.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblParent").ToUpper().Trim())
                    //    lblParent.Text = dt.Rows[k]["LABEL"].ToString().Trim();

                    //if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblSerial").ToUpper().Trim())
                    //    lblSerial.Text = dt.Rows[k]["LABEL"].ToString().Trim();

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
                    //cmbLanguage.Items.Add(dt.Rows[k]["LANG_NAME"].ToString());
                    string lid = dt.Rows[k]["LANG_ID"].ToString();
                    k++;
                }

                //cmbLanguage.Text = new GBLEnvVariable().LangName;

            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }

        #endregion

        #region LoadTree
        #region oldCode
        //public void loadTree(string examuid)
        //{
        //    try
        //    {

        //        ProcessGetRISExaminstructions exminstr = new ProcessGetRISExaminstructions();
        //        if (examuid == "")
        //        {
        //            exminstr.GetAll_New();
        //            //exminstr.GetAll();
        //            exminstr.Invoke();
        //        }
        //        else
        //        {
        //            exminstr.GetbyExamUID(examuid);
        //            exminstr.Invoke();
        //        }
        //        DataSet ds7 = new DataSet();
        //        ds7 = exminstr.Result;
        //        DataTable dt2 = ds7.Tables[0];
        //        bs = new BindingSource();
        //        bs.DataSource = ds7.Tables[0];
        //        SetNavigator();
        //        treeView1.ImageList = imageList1;
        //        string[] auid = new string[2];

        //        treeView1.Nodes.Clear();

        //        if (dt2.Rows.Count > 0)
        //        {
        //            ArrayList UnitList = new ArrayList();
        //            ArrayList parentList = new ArrayList();
        //            ArrayList ExamTypeList = new ArrayList();
        //            TreeNode UnitNodes = new TreeNode();
        //            int m = 0;
        //            int k = 0;
        //            int i = 0;
        //            while (m < dt2.Rows.Count)
        //            {
        //                if (!UnitList.Contains(dt2.Rows[m]["UNIT_NAME"].ToString()))
        //                //if (!UnitList.Contains(dt2.Rows[m]["UNIT_UID"].ToString() + "|" + dt2.Rows[m]["UNIT_NAME"].ToString()))
        //                {
        //                    //UnitList.Add(dt2.Rows[m]["UNIT_UID"].ToString() + "|" + 
        //                    UnitList.Add(dt2.Rows[m]["UNIT_NAME"].ToString());
        //                    //ExamTypeList.Add(dt2.Rows[m]["EXAM_TYPE_UID"].ToString() + "|" + 
        //                    ExamTypeList.Add(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
        //                    treeView1.Nodes.Add(UnitList[i].ToString());

        //                    TreeNode newMasterNodes = new TreeNode(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
        //                    newMasterNodes.Tag = dt2.Rows[m]["EXAM_TYPE"].ToString();
        //                    newMasterNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
        //                    treeView1.Nodes[i].Nodes.Add(newMasterNodes);

        //                    TreeNode newNodes = new TreeNode("(" + dt2.Rows[m]["EXAM_UID"].ToString() + ")" + dt2.Rows[m]["EXAM_NAME"].ToString());
        //                    newNodes.Tag = dt2.Rows[m]["EXAM_ID"].ToString();
        //                    newNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
        //                    treeView1.Nodes[m].Nodes[k].Nodes.Add(newNodes);
        //                    //treeView1.Nodes[i].Nodes.Add(ExamTypeList[k].ToString());
        //                    i++;
        //                    //k++;
        //                }
        //                else
        //                {
        //                    if (!ExamTypeList.Contains(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString()))
        //                    //if (!ExamTypeList.Contains(dt2.Rows[m]["EXAM_TYPE_UID"].ToString() + "|" + dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString()))
        //                    {
        //                        //MessageBox.Show(dt2.Rows[m]["EXAM_TYPE_UID"].ToString() + "|" + dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
        //                        //ExamTypeList.Add(dt2.Rows[m]["EXAM_TYPE_UID"].ToString() + "|" + dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
        //                        //TreeNode newNodes = new TreeNode(dt2.Rows[m]["EXAM_NAME"].ToString());

        //                        //TreeNode newMasterNodes = new TreeNode(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
        //                        //newMasterNodes.Tag = dt2.Rows[m]["EXAM_TYPE"].ToString();
        //                        //treeView1.Nodes[i-1].Nodes.Add(newMasterNodes);

        //                        ExamTypeList.Add(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
        //                        TreeNode newMasterNodes = new TreeNode(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
        //                        newMasterNodes.Tag = dt2.Rows[m]["EXAM_TYPE"].ToString();
        //                        newMasterNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
        //                        treeView1.Nodes[i-1].Nodes.Add(newMasterNodes);

        //                        //treeView1.Nodes[i-1].Nodes.Add(ExamTypeList[k].ToString());
        //                        TreeNode newNodes = new TreeNode("(" + dt2.Rows[m]["EXAM_UID"].ToString() + ")" + dt2.Rows[m]["EXAM_NAME"].ToString());
        //                        newNodes.Tag = dt2.Rows[m]["EXAM_ID"].ToString();
        //                        newNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
        //                        treeView1.Nodes[i].Nodes[0].Nodes.Add(newNodes);
        //                        k++;
        //                        i++;
        //                    }
        //                    else
        //                    {
        //                        TreeNode newNodes = new TreeNode("(" + dt2.Rows[m]["EXAM_UID"].ToString() + ")" + dt2.Rows[m]["EXAM_NAME"].ToString());
        //                        newNodes.Tag = dt2.Rows[m]["EXAM_ID"].ToString();
        //                        newNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
        //                        treeView1.Nodes[m].Nodes[k].Nodes.Add(newNodes);
        //                        //if (dt2.Rows[m]["EXAM_UID"].ToString() == "2105")
        //                        //{
        //                        //    string s = dt2.Rows[m]["EXAM_UID"].ToString();
        //                        k++;
        //                        i++;
        //                        //}
        //                    }
        //                }
        //                m++;
        //            }
        //        }

        //        treeView1.ExpandAll();
        //        //SetNavigator();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return;
        //    }
        //}
        #endregion
        public void loadTree(string examuid)
        {
            try
            {
                ProcessGetRISExaminstructions exminstr = new ProcessGetRISExaminstructions();
                if (examuid == "")
                {
                    exminstr.GetAll_New();
                    //exminstr.GetAll();
                    exminstr.Invoke();
                }
                else
                {
                    exminstr.GetbyExamUID(examuid);
                    exminstr.Invoke();
                }
                DataSet ds7 = new DataSet();
                ds7 = exminstr.Result;
                DataTable dt2 = ds7.Tables[0];
                bs = new BindingSource();
                bs.DataSource = ds7.Tables[0];
                SetNavigator();
                treeView1.ImageList = imageList1;
                string[] auid = new string[2];

                treeView1.Nodes.Clear();

                List<string> lst1 = new List<string>();
                List<string> lst2 = new List<string>();
                List<string> lst3 = new List<string>();
                foreach (DataRow dr1 in dt2.Rows)
                {
                    if (!lst1.Contains(dr1["UNIT_NAME"].ToString()))
                    {
                        lst1.Add(dr1["UNIT_NAME"].ToString());
                        TreeNode n1 = new TreeNode(dr1["UNIT_NAME"].ToString());
                        n1.Tag = dr1["UNIT_ID"].ToString();
                        treeView1.Nodes.Add(n1);
                    }
                }

                int k = 0;
                foreach (string str1 in lst1.ToArray())
                {
                    DataRow[] drs2 = dt2.Select("[UNIT_NAME]='" + str1 + "'");
                    foreach (DataRow dr2 in drs2)
                    {
                        if (!lst2.Contains(dr2["EXAM_TYPE_TEXT"].ToString()))
                        {
                            lst2.Add(dr2["EXAM_TYPE_TEXT"].ToString());
                            TreeNode n2 = new TreeNode(dr2["EXAM_TYPE_TEXT"].ToString());
                            n2.Tag = dr2["EXAM_TYPE"].ToString();
                            n2.ToolTipText = dr2["RowNO"].ToString();
                            treeView1.Nodes[k].Nodes.Add(n2);
                        }
                    }
                    lst2.Clear();
                    k++;
                }

                int m = 0;
                k = 0;
                foreach (TreeNode tn1 in treeView1.Nodes)
                {
                    foreach (TreeNode tn2 in treeView1.Nodes[m].Nodes)
                    {
                        DataRow[] drs3 = dt2.Select("UNIT_NAME='" + tn1.Text + "' AND EXAM_TYPE_TEXT='" + tn2.Text + "'");
                        foreach(DataRow dr3 in drs3)
                        {
                            TreeNode n3 = new TreeNode("(" + dr3["EXAM_UID"].ToString() + ")" + dr3["EXAM_NAME"].ToString());
                            n3.Tag = dr3["EXAM_ID"].ToString();
                            n3.ToolTipText = dr3["RowNO"].ToString();
                            treeView1.Nodes[m].Nodes[k].Nodes.Add(n3);
                        }
                        k++;
                    }
                    ++m;
                    k = 0;
                }

                treeView1.ExpandAll();

                //if (dt2.Rows.Count > 0)
                //{
                //    ArrayList UnitList = new ArrayList();
                //    ArrayList parentList = new ArrayList();
                //    ArrayList ExamTypeList = new ArrayList();
                //    TreeNode UnitNodes = new TreeNode();
                //    int m = 0;
                //    int k = 0;
                //    int i = 0;
                //    while (m < dt2.Rows.Count)
                //    {
                //        if (!UnitList.Contains(dt2.Rows[m]["UNIT_NAME"].ToString()))
                //        //if (!UnitList.Contains(dt2.Rows[m]["UNIT_UID"].ToString() + "|" + dt2.Rows[m]["UNIT_NAME"].ToString()))
                //        {
                //            //UnitList.Add(dt2.Rows[m]["UNIT_UID"].ToString() + "|" + 
                //            UnitList.Add(dt2.Rows[m]["UNIT_NAME"].ToString());
                //            //ExamTypeList.Add(dt2.Rows[m]["EXAM_TYPE_UID"].ToString() + "|" + 
                //            ExamTypeList.Add(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
                //            treeView1.Nodes.Add(UnitList[i].ToString());

                //            TreeNode newMasterNodes = new TreeNode(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
                //            newMasterNodes.Tag = dt2.Rows[m]["EXAM_TYPE"].ToString();
                //            newMasterNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
                //            treeView1.Nodes[i].Nodes.Add(newMasterNodes);

                //            TreeNode newNodes = new TreeNode("(" + dt2.Rows[m]["EXAM_UID"].ToString() + ")" + dt2.Rows[m]["EXAM_NAME"].ToString());
                //            newNodes.Tag = dt2.Rows[m]["EXAM_ID"].ToString();
                //            newNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
                //            treeView1.Nodes[m].Nodes[k].Nodes.Add(newNodes);
                //            //treeView1.Nodes[i].Nodes.Add(ExamTypeList[k].ToString());
                //            i++;
                //            //k++;
                //        }
                //        else
                //        {
                //            if (!ExamTypeList.Contains(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString()))
                //            //if (!ExamTypeList.Contains(dt2.Rows[m]["EXAM_TYPE_UID"].ToString() + "|" + dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString()))
                //            {
                //                //MessageBox.Show(dt2.Rows[m]["EXAM_TYPE_UID"].ToString() + "|" + dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
                //                //ExamTypeList.Add(dt2.Rows[m]["EXAM_TYPE_UID"].ToString() + "|" + dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
                //                //TreeNode newNodes = new TreeNode(dt2.Rows[m]["EXAM_NAME"].ToString());

                //                //TreeNode newMasterNodes = new TreeNode(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
                //                //newMasterNodes.Tag = dt2.Rows[m]["EXAM_TYPE"].ToString();
                //                //treeView1.Nodes[i-1].Nodes.Add(newMasterNodes);

                //                ExamTypeList.Add(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
                //                TreeNode newMasterNodes = new TreeNode(dt2.Rows[m]["EXAM_TYPE_TEXT"].ToString());
                //                newMasterNodes.Tag = dt2.Rows[m]["EXAM_TYPE"].ToString();
                //                newMasterNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
                //                treeView1.Nodes[i - 1].Nodes.Add(newMasterNodes);

                //                //treeView1.Nodes[i-1].Nodes.Add(ExamTypeList[k].ToString());
                //                TreeNode newNodes = new TreeNode("(" + dt2.Rows[m]["EXAM_UID"].ToString() + ")" + dt2.Rows[m]["EXAM_NAME"].ToString());
                //                newNodes.Tag = dt2.Rows[m]["EXAM_ID"].ToString();
                //                newNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
                //                treeView1.Nodes[i].Nodes[0].Nodes.Add(newNodes);
                //                k++;
                //                i++;
                //            }
                //            else
                //            {
                //                TreeNode newNodes = new TreeNode("(" + dt2.Rows[m]["EXAM_UID"].ToString() + ")" + dt2.Rows[m]["EXAM_NAME"].ToString());
                //                newNodes.Tag = dt2.Rows[m]["EXAM_ID"].ToString();
                //                newNodes.ToolTipText = dt2.Rows[m]["RowNO"].ToString();
                //                treeView1.Nodes[m].Nodes[k].Nodes.Add(newNodes);
                //                //if (dt2.Rows[m]["EXAM_UID"].ToString() == "2105")
                //                //{
                //                //    string s = dt2.Rows[m]["EXAM_UID"].ToString();
                //                k++;
                //                i++;
                //                //}
                //            }
                //        }
                //        m++;
                //    }
                //}

                //treeView1.ExpandAll();
                ////SetNavigator();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        #endregion
        private void ClearText()
        {
            dbu = new DBUtility();
            textBox1.DataBindings.Clear();
            txtUnitUID.DataBindings.Clear();
            txtExamTypeUID.DataBindings.Clear();
            txtExamUID.DataBindings.Clear();
            txtUnitName.DataBindings.Clear();
            txtExamType.DataBindings.Clear();
            txtExamName.DataBindings.Clear();
            //textBox2.DataBindings.Clear();
            //textBox4.DataBindings.Clear();
            rtbUnitDescr.DataBindings.Clear();
            rtbExamTypeDesc.DataBindings.Clear();
            rtbExamTypeKID.DataBindings.Clear();
            rtbExamDescr.DataBindings.Clear();

            textBox1.Text = string.Empty;
            txtUnitUID.Text = string.Empty;
            txtExamTypeUID.Text = string.Empty;
            txtExamUID.Text = string.Empty;
            txtUnitName.Text = string.Empty;
            txtExamType.Text = string.Empty;
            txtExamName.Text = string.Empty;
            //textBox2.Text = string.Empty;
            //textBox4.Text = string.Empty;
            rtbUnitDescr.Text = string.Empty;
            rtbExamTypeDesc.Text = string.Empty;
            rtbExamTypeKID.Text = string.Empty;
            rtbExamDescr.Text = string.Empty;

        }
        private void SetNavigator()
        {
            ClearText();
            
            //txtExamUID.DataBindings.Add("Text", bs, "UNIT_ID");
            //txtUnitCode.DataBindings.Add("Text", bs, "UNIT_ID");

            textBox1.DataBindings.Add("Text", bs, "EXAM_ID");//.Text = dt2.Rows[0]["EXAM_ID"].ToString();
            txtUnitUID.DataBindings.Add("Text", bs, "UNIT_UID");//.Text = dt2.Rows[0]["UNIT_UID"].ToString();
            txtExamTypeUID.DataBindings.Add("Text", bs, "EXAM_TYPE_UID");//.Text = dt2.Rows[0]["EXAM_TYPE_UID"].ToString();
            txtExamUID.DataBindings.Add("Text", bs, "EXAM_UID");//.Text = dt2.Rows[0]["EXAM_UID"].ToString();
            txtUnitName.DataBindings.Add("Text", bs, "UNIT_NAME");//.Text = dt2.Rows[0]["UNIT_NAME"].ToString();
            txtExamType.DataBindings.Add("Text", bs, "EXAM_TYPE_TEXT");//.Text = dt2.Rows[0]["EXAM_TYPE_TEXT"].ToString();
            txtExamName.DataBindings.Add("Text", bs, "EXAM_NAME");//.Text = dt2.Rows[0]["EXAM_NAME"].ToString();
           // textBox2.DataBindings.Add("Text", bs, "EXAM_ID");//.Text = dt2.Rows[0]["EXAM_ID"].ToString();
            //textBox4.DataBindings.Add("Text", bs, "EXAM_UID");//.Text = dt2.Rows[0]["EXAM_UID"].ToString();
            rtbUnitDescr.DataBindings.Add("Text", bs, "UNIT_INS");//.Text = dt2.Rows[0]["UNIT_INS"].ToString();
            rtbExamTypeDesc.DataBindings.Add("Text", bs, "EXAM_TYPE_INS");//.Text = dt2.Rows[0]["EXAM_TYPE_INS"].ToString();
            rtbExamTypeKID.DataBindings.Add("Text", bs, "EXAM_TYPE_INS_KID");            //EXAM_TYPE_INS_KID
            rtbExamDescr.DataBindings.Add("Text", bs, "INS_TEXT");//.Text = dt2.Rows[0]["INS_TEXT"].ToString();

            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            bindingNavigator1.BindingSource = bs;
        }
        private void bs_PositionChanged(object sender, EventArgs e)
        {
            DataTable dtt = (DataTable)bs.DataSource;
            DataRow dr = dtt.Rows[bs.Position];
            Exam_id = dr["EXAM_ID"].ToString();
            INS_ID = dr["INS_ID"].ToString();
            Exam_Type = dr["EXAM_TYPE"].ToString();
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
                ProcessGetRISExaminstructions exminstr = new ProcessGetRISExaminstructions();

                exminstr.GetByEXAM_ID_New(uid);
                //exminstr
                exminstr.Invoke();
                DataTable dt2 = exminstr.Result.Tables[0];
                int k = 0;

                while (k < dt2.Rows.Count)
                {
                    textBox1.Text = dt2.Rows[0]["EXAM_ID"].ToString();
                    txtUnitUID.Text = dt2.Rows[0]["UNIT_UID"].ToString();
                    txtExamTypeUID.Text = dt2.Rows[0]["EXAM_TYPE_UID"].ToString();
                    txtExamUID.Text = dt2.Rows[0]["EXAM_UID"].ToString();
                    txtUnitName.Text = dt2.Rows[0]["UNIT_NAME"].ToString();
                    txtExamType.Text = dt2.Rows[0]["EXAM_TYPE_TEXT"].ToString(); 
                    txtExamName.Text = dt2.Rows[0]["EXAM_NAME"].ToString();
                    textBox2.Text = dt2.Rows[0]["EXAM_ID"].ToString();
                    textBox4.Text = dt2.Rows[0]["EXAM_UID"].ToString();
                    rtbUnitDescr.Text = dt2.Rows[0]["UNIT_INS"].ToString();
                    rtbExamTypeDesc.Text = dt2.Rows[0]["EXAM_TYPE_INS"].ToString();
                    rtbExamTypeKID.Text = dt2.Rows[0]["EXAM_TYPE_INS_KID"].ToString();
                    rtbExamDescr.Text = dt2.Rows[0]["INS_TEXT"].ToString();
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

                    if (e.Node.LastNode == null)//Exam
                    {
                        TreeLevel = 2;
                        //string exam_uid = treeView1.SelectedNode.Text.ToString().Split(')')[0].ToString().TrimEnd(' ').ToString();
                        //exam_uid = exam_uid.Substring(1, exam_uid.Length-1);
        
                        //loadTree2(exam_uid);
                        int i = 0;
                        try { i = int.Parse(e.Node.ToolTipText.ToString()); }
                        catch { }
                        bs.Position = i-1;

                        //Eid = e.Node.Tag.ToString();
                    }
                    else
                    {
                        if (e.Node.Parent == null)//Unit
                        {
                            TreeLevel = 0;
                        }
                        else//ExamType
                        {
                            TreeLevel = 1;
                            int i = 0;
                            try { i = int.Parse(e.Node.ToolTipText.ToString()); }
                            catch { }
                            bs.Position = i - 1;
                            //rtbExamDescr.Text = "";
                        }
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
            txtExamUID.Text = "";
            txtUnitName.Text = "";
            //loadTree2(uid,pid);
        }

#region lookup click
        private void button2_Click(object sender, EventArgs e)
        {
            Lookup.Lookup lv = new Lookup.Lookup();
            lv.ValueUpdated += new ValueUpdatedEventHandler(childA_ValueUpdated);
            string qry = "SELECT UNIT_UID,UNIT_NAME from HR_UNIT where UNIT_UID like '%%'";
            string fields = "UNIT UID,UNIT NAME";
            string con = "";
            lv.getData(qry, fields, con, "UNIT LOOKUP");
            lv.Show();
            txtExamUID.Enabled = true;
            txtExamName.Enabled = true;
            btExam.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Lookup.Lookup lv = new Lookup.Lookup();
            lv.ValueUpdated += new ValueUpdatedEventHandler(childA_ValueUpdated);
            string qry = "SELECT EXAM_UID,EXAM_NAME from RIS_EXAM where EXAM_UID like '%%'";
            string fields = "EXAM UID,EXAM NAME";
            string con = "";
            lv.getData(qry, fields, con, "EXAM LOOKUP");
            lv.Show();
        }
#endregion

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
                txtUnitUID.Text = retValue[0].ToString();
                txtExamUID.Text = retValue[1].ToString();

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
            txtUnitUID.Enabled = true;
            btUnit.Enabled = true;
            txtExamUID.Enabled = true;

            txtExamName.Enabled = true;
            //txtSubClassName.Enabled = true;
            //txtSubNameUser.Enabled = true;
            //txtSubType.Enabled = true;
            //txtSubNameSys.Enabled = true;

            //txtDesc.Enabled = true;

            //cmbParent.Enabled = true;
            //txtSlno.Enabled = true;

            //chkActive.Checked = false;
            //chkActive.Enabled = true;

            //chkView.Checked = false;
            //chkView.Enabled = true;

            //chkRemove.Checked = false;
            //chkRemove.Enabled = true;

            //chkCreate.Checked = false;
            //chkCreate.Enabled = true;

            //chkModify.Checked = false;
            //chkModify.Enabled = true;

            //chkAddToHome.Checked = false;
            //chkAddToHome.Enabled = true;

        }
        #endregion

        #region reset
        public void reset()
        {
            txtUnitUID.Text = "";
            txtExamUID.Text = "";

            txtExamName.Text = "";
            //txtSubClassName.Text = "";
            //txtSubNameUser.Text = "";
            //txtSubType.Text = "";
            //txtSubNameSys.Text = "";

            //txtDesc.Text = "";

            //cmbParent.Text = "";
            //txtSlno.Text = "";
            //chkActive.Checked = false;
            //chkActive.Enabled = false;

            //chkView.Checked = false;
            //chkView.Enabled = false;
            //chkRemove.Checked = false;
            //chkRemove.Enabled = false;
            //chkCreate.Checked = false;
            //chkCreate.Enabled = false;
            //chkModify.Checked = false;
            //chkModify.Enabled = false;
            //chkAddToHome.Checked = false;
            //chkAddToHome.Enabled = false;
            
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            //chkActive.Checked = false;
            //chkActive.Enabled = false;

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
            int j = bs.Position;
            loadTree("");
            bs.Position = j;
            txtUnitUID.Enabled = false;
            txtUnitName.Enabled = false;
            //rtbUnitDescr.Enabled = false;
            btUnit.Enabled = false;
            txtExamTypeUID.Enabled = false;
            txtExamType.Enabled = false;
            //rtbExamTypeDesc.Enabled = false;
            btExamType.Enabled = false;
            txtExamUID.Enabled = false;
            txtExamName.Enabled = false;
            //rtbExamDescr.Enabled = false;
            btExam.Enabled = false;

            setControl(0);

          

            //txtSubClassName.Enabled = false;
            //txtSubNameUser.Enabled = false;
            //txtSubType.Enabled = false;
            //txtSubNameSys.Enabled = false;

            //txtDesc.Enabled = false;

            //cmbParent.Enabled = false;
            //txtSlno.Enabled = false;
            btnAdd.Text = "&Add";
            btnEdit.Text = "&Edit";
            this.BindingContext[rvisticol].Position = -1;
            bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (0), rvisticol.Count);
            reset();
            nevigation("1");
            

        }
        public void setControl(int mode)
        {
            switch (mode)
            {
                case(0):
                    treeView1.Enabled = true;
                    txtSearch.Enabled = true;

                    rtbExamDescr.ReadOnly = true;
                    rtbExamTypeDesc.ReadOnly = true;
                    rtbExamTypeKID.ReadOnly = true;
                    rtbUnitDescr.ReadOnly = true;

                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible=false;

                    rtbUnitDescr.BackColor = Color.WhiteSmoke;
                    rtbExamTypeDesc.BackColor = Color.WhiteSmoke;
                    rtbExamTypeKID.BackColor = Color.WhiteSmoke;
                    rtbExamDescr.BackColor = Color.WhiteSmoke;

                    lblMenuUID.StrokeInfo.Color = Color.DarkGray;
                    nEntryContainer3.StrokeInfo.Color = Color.DarkGray;
                    lblMenuName.StrokeInfo.Color = Color.DarkGray;

                    nEntryContainer1.StrokeInfo.Color = Color.DarkGray;
                    nEntryContainer2.StrokeInfo.Color = Color.DarkGray;
                    lblDesc.StrokeInfo.Color = Color.DarkGray;
                    //lblMenuUID.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
                    //nEntryContainer3.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
                    //lblMenuName.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
                    break;
                case(1):
                    treeView1.Enabled = true;
                    txtSearch.Enabled = true;

                    label3.Visible = true;
                    rtbUnitDescr.ReadOnly = false;
                    rtbUnitDescr.BackColor = Color.White;

                    label2.Visible = false;
                    rtbExamTypeDesc.ReadOnly = true;
                    rtbExamTypeKID.ReadOnly = true;

                    label1.Visible = false;
                    rtbExamDescr.ReadOnly = true;

                    lblMenuUID.StrokeInfo.Color = Color.Red;
                    nEntryContainer1.StrokeInfo.Color = Color.Red;
                    break;
                case(2):
                    treeView1.Enabled = true;
                    txtSearch.Enabled = true;

                    label3.Visible = false;
                    rtbUnitDescr.ReadOnly = true;

                    label2.Visible = true;
                    rtbExamTypeDesc.ReadOnly = false;
                    rtbExamTypeDesc.BackColor = Color.White;
                    rtbExamTypeKID.ReadOnly = false;
                    rtbExamTypeKID.BackColor = Color.White;

                    label1.Visible = false;
                    rtbExamDescr.ReadOnly = true;

                    nEntryContainer3.StrokeInfo.Color = Color.Red;
                    nEntryContainer2.StrokeInfo.Color = Color.Red;
                    break;
                case (3):
                    treeView1.Enabled = true;
                    txtSearch.Enabled = true;

                    label3.Visible = false;
                    rtbUnitDescr.ReadOnly = true;

                    label2.Visible = false;
                    rtbExamTypeDesc.ReadOnly = true;
                    rtbExamTypeKID.ReadOnly = true;

                    label1.Visible = true;
                    rtbExamDescr.ReadOnly = false;
                    rtbExamDescr.BackColor = Color.White;

                    lblMenuName.StrokeInfo.Color = Color.Red;
                    lblDesc.StrokeInfo.Color = Color.Red;
                    break;
                default:
                    treeView1.Enabled = true;
                    txtSearch.Enabled = true;

                    rtbExamDescr.ReadOnly = true;
                    rtbExamTypeDesc.ReadOnly = true;
                    rtbExamTypeKID.ReadOnly = true;
                    rtbUnitDescr.ReadOnly = true;

                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;

                    rtbUnitDescr.BackColor = Color.WhiteSmoke;
                    rtbExamTypeDesc.BackColor = Color.WhiteSmoke;
                    rtbExamTypeKID.BackColor = Color.WhiteSmoke;
                    rtbExamDescr.BackColor = Color.WhiteSmoke;

                    lblMenuUID.StrokeInfo.Color = Color.DarkGray;
                    nEntryContainer3.StrokeInfo.Color = Color.DarkGray;
                    lblMenuName.StrokeInfo.Color = Color.DarkGray;

                    nEntryContainer1.StrokeInfo.Color = Color.DarkGray;
                    nEntryContainer2.StrokeInfo.Color = Color.DarkGray;
                    lblDesc.StrokeInfo.Color = Color.DarkGray;
                    break;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //this.BindingContext[rvisticol].Position = 0;
            //txtExamUID.Text = textBox4.Text;
            bs.MoveFirst();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //if (this.BindingContext[rvisticol].Position > 0)
            //{
            //    this.BindingContext[rvisticol].Position--;
            //    txtExamUID.Text = textBox4.Text;
            //}
            bs.MovePrevious();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //if (this.BindingContext[rvisticol].Position < rvisticol.Count - 1)
            //{
            //    this.BindingContext[rvisticol].Position++;
            //    txtExamUID.Text = textBox4.Text;
            //}
            bs.MoveNext();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //this.BindingContext[rvisticol].Position = rvisticol.Count - 1;
            //txtExamUID.Text = textBox4.Text;
            bs.MoveLast();
            //bs.Position = 99;
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
                    //chkActive.Enabled = true;
                    //chkView.Enabled = true;
                    //chkRemove.Enabled = true;
                    //chkModify.Enabled = true;
                    //chkCreate.Enabled = true;
                    //chkAddToHome.Enabled = true;

                    int iCount = rvisticol.Count;
                    bindingNavigatorPositionItem.Text = String.Format("{0} of {1}", (iCount + 1), rvisticol.Count);
                }

                else
                {
                    ProcessAddRISExaminstructions processexaminstr = new ProcessAddRISExaminstructions();
                    RISExaminstructions examinstr = new RISExaminstructions();

                    //gblsubmenu.MenuUID = txtUnitUID.Text.ToString();
                    //gblsubmenu.SubMenuUID = txtExamUID.Text.ToString();

                    try
                    {
                        //examinstr.INS_ID = 0;
                        //examinstr.EXAM_ID = 0;
                        //examinstr.UNIT_ID = 0;
                        //examinstr.UNIT_INS = 0;
                        //examinstr.EXAM_TYPE_ID = 0;
                        //examinstr.EXAM_TYPE_INS = 0;
                        //examinstr.INS_UID = 0;
                        //examinstr.INS_TEXT = "";
                        //examinstr.INHERIT_GROUP = 0;
                        //examinstr.IS_UPDATED = "";
                        //examinstr.IS_DELETED = "";
                //                            new SqlParameter("@INS_ID",RISExaminstructions.INS_ID),
                //new SqlParameter("@EXAM_ID",RISExaminstructions.EXAM_ID),
                //new SqlParameter("@UNIT_ID",RISExaminstructions.UNIT_ID),
                ////new SqlParameter("@UNIT_INS",RISExaminstructions.UNIT_INS),
                //new SqlParameter("@EXAM_TYPE_ID",RISExaminstructions.EXAM_TYPE_ID),
                ////new SqlParameter("@EXAM_TYPE_INS",RISExaminstructions.EXAM_TYPE_INS),
                //new SqlParameter("@INS_UID",RISExaminstructions.INS_UID),
                //new SqlParameter("@INS_TEXT",RISExaminstructions.INS_TEXT),
                //new SqlParameter("@INHERIT_GROUP",RISExaminstructions.INHERIT_GROUP),
                //new SqlParameter("@IS_UPDATED",RISExaminstructions.IS_UPDATED),
                //new SqlParameter("@IS_DELETED",RISExaminstructions.IS_DELETED),
                        processexaminstr.Invoke();
                        treeView1.Nodes.Clear();
                        loadTree("");


                        txtUnitUID.Enabled = false;
                        btUnit.Enabled = false;
                        txtExamUID.Enabled = false;

                        txtExamName.Enabled = false;
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
                switch (TreeLevel)
                {
                    case (0):
                        //Unit
                        setControl(1);
                        break;
                    case (1):
                        //ExamType

                        setControl(2);
                        break;
                    case (2):
                        //Exam

                        setControl(3);
                        break;
                    default:
                        setControl(0);
                        break;
                }
                btnEdit.Text = "&Update";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                treeView1.Enabled = false;
                txtSearch.Enabled = false;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
            }
            else
            {
                string str=msg.ShowAlert("UID1020", env.CurrentLanguageID);
                if (str == "2")
                {
                    switch (TreeLevel)
                    {
                        case (0)://Unit
                            ProcessUpdateRISExaminstructions Update_Unit = new ProcessUpdateRISExaminstructions();
                            Update_Unit.RISExaminstructions = new RISExaminstructions();
                            Update_Unit.RISExaminstructions.SP_TYPE = 2;
                            Update_Unit.RISExaminstructions.UNIT_ID = Convert.ToInt32(treeView1.SelectedNode.Tag);
                            Update_Unit.RISExaminstructions.UNIT_INS = rtbUnitDescr.Text;
                            Update_Unit.Invoke();

                            setControl(0);
                            break;
                        case (1)://ExamType
                            ProcessUpdateRISExaminstructions Update_ExamType = new ProcessUpdateRISExaminstructions();
                            Update_ExamType.RISExaminstructions = new RISExaminstructions();
                            Update_ExamType.RISExaminstructions.SP_TYPE = 1;
                            Update_ExamType.RISExaminstructions.EXAM_TYPE_ID = Convert.ToInt32(Exam_Type);
                            Update_ExamType.RISExaminstructions.EXAM_TYPE_INS = rtbExamTypeDesc.Text;
                            Update_ExamType.RISExaminstructions.EXAM_TYPE_INS_KID = rtbExamTypeKID.Text;
                            Update_ExamType.Invoke();

                            setControl(0);
                            break;
                        case (2): //Exam
                            if (INS_ID == "0")
                            {
                                ProcessAddRISExaminstructions Add = new ProcessAddRISExaminstructions();
                                Add.RISExaminstructions = new RISExaminstructions();
                                Add.RISExaminstructions.EXAM_TYPE_ID = Convert.ToInt32(Exam_Type);
                                Add.RISExaminstructions.EXAM_ID = Convert.ToInt32(Exam_id);
                                Add.RISExaminstructions.INS_TEXT = rtbExamDescr.Text;
                                Add.Invoke();
                                //MessageBox.Show(Exam_id+ " " + INS_ID);
                            }
                            else
                            {
                                ProcessUpdateRISExaminstructions Update_Exam = new ProcessUpdateRISExaminstructions();
                                Update_Exam.RISExaminstructions = new RISExaminstructions();
                                Update_Exam.RISExaminstructions.SP_TYPE = 0;
                                Update_Exam.RISExaminstructions.INS_ID = Convert.ToInt32(INS_ID);
                                Update_Exam.RISExaminstructions.INS_TEXT = rtbExamDescr.Text;
                                Update_Exam.Invoke();
                                // MessageBox.Show(Exam_id + " " + INS_ID);
                            }

                            setControl(0);
                            break;
                        default:
                            setControl(0);
                            break;
                    }
                    int j = bs.Position;
                    loadTree("");
                    bs.Position = j;
                    btnEdit.Text = "&Edit";
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    treeView1.Enabled = true;
                    txtSearch.Enabled = true;
                    toolStripButton1.Enabled = true;
                    toolStripButton2.Enabled = true;
                    toolStripButton3.Enabled = true;
                    toolStripButton4.Enabled = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUnitUID.Text == "")
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
                        //loadTree("");

                        reset();
                    }
                    catch { }
                }
            }
        }

        private void GBL_SF06_Load(object sender, EventArgs e)
        {
            setControl(0);
            
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                rtbExamTypeDesc.Visible = true;
                rtbExamTypeKID.Visible = false;
            }
            else
            {
                rtbExamTypeDesc.Visible = false;
                rtbExamTypeKID.Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                rtbExamTypeDesc.Visible = false;
                rtbExamTypeKID.Visible = true;
            }
            else
            {
                rtbExamTypeDesc.Visible = true;
                rtbExamTypeKID.Visible = false;
            }
        }



    }
}