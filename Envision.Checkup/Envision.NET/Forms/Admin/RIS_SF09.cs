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
//Exam Type
namespace RIS.Forms.Admin
{
    public partial class RIS_SF09 : Form
    {
        alertObjectCollection rvisticol = new alertObjectCollection();
        DBUtility dbu = new DBUtility();

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        ProcessGetRISSF09 alt = new ProcessGetRISSF09();
        DataTable dt2 = new DataTable();
        BindingSource bs = new BindingSource();
        Binding bd;
        public RIS_SF09(UUL.ControlFrame.Controls.TabControl clsCtl)
        //public RIS_SF09()
        {
            InitializeComponent();
            CloseControl = clsCtl;
        }

        private void MyLookup_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Load_DB()
        {
            //Load DB into Listview;
            try
            {

                //reset();
                nListActive.Items.Clear();
                nlsv_patien.Items.Clear();

                alt.Invoke();
                dt2 = alt.ResultSet.Tables[0];

                treeView1.ImageList = imageList1;
                bs.DataSource = dt2;
                //bd = ntxt_sUid.DataBindings.Add("Text", bs, "STATUS_UID");
                //bd = nTxt_sText.DataBindings.Add("Text", bs, "STATUS_TEXT");
                //bd = chkActive.DataBindings.Add("IsChecked", bs, "IS_ACTIVE");
                bindingNavigator1.BindingSource = bs;

                int k = 0;

                string[] colStr = new string[3];
                while (k < dt2.Rows.Count)
                {
                    colStr[0] = dt2.Rows[k][1].ToString();
                    colStr[1] = dt2.Rows[k][2].ToString();
                    colStr[2] = dt2.Rows[k][0].ToString();

                    ListViewItem lvi = new ListViewItem(colStr);
                    ListViewItem lvi2;
                    ListViewItem.ListViewSubItem lvs = new ListViewItem.ListViewSubItem();


                    if (dt2.Rows[k][3].ToString() == "Y")
                    {
                        lvs = new ListViewItem.ListViewSubItem(lvi, "R");
                        lvs.Font = new Font("Wingdings 2", 12);
                        lvi.SubItems.Add(lvs);
                        lvi2 = new ListViewItem("R");
                        lvi2.Font = new Font("Wingdings 2", 12);
                        lvi2.Checked = true;
                    }
                    else
                    {
                        lvs = new ListViewItem.ListViewSubItem(lvi, "p");
                        lvs.Font = new Font("Wingdings", 12);
                        lvi.SubItems.Add(lvs);
                        lvi2 = new ListViewItem("p");
                        lvi2.Font = new Font("Wingdings", 12);

                    }

                    nListActive.Items.Add(lvi2);
                    nlsv_patien.Items.Add(lvi);

                    k++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //End Load DB
        }

        private void RIS_SF09_Load(object sender, EventArgs e)
        {
            Load_DB();
            LoadTreeView(dt2);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "&Add")
                {
                    //nevigation("0");
                    //editable();
                    btnAdd.Text = "&Save";
                    btnRefresh.Text = "&Cancel";
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;

                    ntxt_sUid.Enabled = true;
                    nTxt_sText.Enabled = true;
            
                    ntxt_sUid.Focus();

                    //                    reset();
                    chkActive.Enabled = true;
                }

                else
                {
                    GBLEnvVariable patenv = new GBLEnvVariable();
                    ProcessAddRISSF09 processpat = new ProcessAddRISSF09();
                    RISSF09Data gblpat = new RISSF09Data();

                    if (ntxt_sUid.Text == "")
                    {
                        MessageBox.Show("Please Insert EXAM TYPE UID !!");
                        return;
                    }
                    if (nTxt_sText.Text == "")
                    {
                        MessageBox.Show("Please Insert EXAM TYPE Text !!");
                        return;
                    }
                    gblpat.EXAM_TYPE_UID  = ntxt_sUid.Text;
                    gblpat.EXAM_TYPE_TEXT = nTxt_sText.Text;
                    if (chkActive.Checked == true)
                    {
                        gblpat.IS_ACTIVE  = "Y";
                    }
                    else
                    {
                        gblpat.IS_ACTIVE  = "N";
                    }
                    gblpat.ORG_ID  = patenv.OrgID;
                    gblpat.CREATED_BY = patenv.UserID;


                    processpat.RISSF09Data  = gblpat;

                    try
                    {
                        processpat.Invoke();

                        btnAdd.Text = "&Add";
                        btnEdit.Text = "&Edit";
                        btnRefresh.Text = "&Refresh";
                        Load_DB();
                        reset();
                        LoadTreeView(dt2);
                        //nevigation("1");

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
                //if (nlsv_patien.Focused == false)
                //{
                //    MessageBox.Show("Please Select Data !!");
                //}
                //else
                //{

                    //nevigation("0");

                    btnEdit.Text = "&Update";
                    btnRefresh.Text = "&Cancel";
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    chkActive.Enabled = true;

                    ntxt_sUid.Enabled = true;
                    ntxt_sUid.Text = nlsv_patien.Items[bs.Position].Text.ToString();
                    nTxt_sText.Enabled = true;
                    nTxt_sText.Text = nlsv_patien.Items[bs.Position].SubItems[1].Text.ToString();
                    ntxt_sUid.Focus();
                    ntxtID.Text = nlsv_patien.Items[bs.Position].SubItems[2].Text.ToString();
                    chkActive.Checked = nListActive.Items[bs.Position].Checked;
                //}
            }
            else
            {


                GBLEnvVariable gblenv = new GBLEnvVariable();
                RISSF09Data gblpatient = new RISSF09Data();
                ProcessUpdateRISSF09 processpatstatus = new ProcessUpdateRISSF09();
                gblpatient.EXAM_TYPE_ID  = Convert.ToInt32(ntxtID.Text);
                gblpatient.EXAM_TYPE_UID = ntxt_sUid.Text.ToString();
                gblpatient.EXAM_TYPE_TEXT  = nTxt_sText.Text.ToString();
                if (chkActive.Checked == true)
                {
                    gblpatient.IS_ACTIVE  = "Y";
                }
                else
                {
                    gblpatient.IS_ACTIVE  = "N";
                }
                gblpatient.ORG_ID  = gblenv.OrgID;
                gblpatient.LASTMODIFIED_BY  = gblenv.UserID;
                processpatstatus.RISSF09Data  = gblpatient;

                try
                {
                    processpatstatus.Invoke();

                    btnAdd.Text = "&Add";
                    btnEdit.Text = "&Edit";
                    btnRefresh.Text = "&Refresh";
                    reset();
                    //nevigation("1");

                    Load_DB();
                    LoadTreeView(dt2);

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }

        }

        private void nlsv_patien_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.Position = nlsv_patien.FocusedItem.Index;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (nlsv_patien.Focused == false)
            //{
            //    MessageBox.Show("Please Select Data !!");
            //}
            //else
            //{

                RISSF09Data risobj = new RISSF09Data();
                ProcessDeleteSF09 processobj = new ProcessDeleteSF09();

                risobj.EXAM_TYPE_ID = Convert.ToInt32(nlsv_patien.Items[bs.Position].SubItems[2].Text.ToString());
                processobj.RISSF09Data = risobj;
            
                if(MessageBox.Show("Delete Data " + (bs.Position + 1) + ". ","Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                try
                {
                    processobj.Invoke();
                    Load_DB();
                    LoadTreeView(dt2);

                }
                catch (Exception EX) { }
            //}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reset();
            Load_DB();
            btnRefresh.Text = "&Refresh";
            LoadTreeView(dt2);
        }

        private void reset()
        {
            nTxt_sText.Text = "";
            nTxt_sText.Enabled = false;
            ntxt_sUid.Enabled = false;
            ntxt_sUid.Text = "";
            chkActive.Checked = false;
            chkActive.Enabled = false;
            btnAdd.Text = "&Add";
            btnAdd.Enabled = true;
            btnDelete.Text = "&Delete";
            btnDelete.Enabled = true;
            btnEdit.Text = "&Edit";
            btnEdit.Enabled = true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
            //nlsv_patien.Focus = true;
            nlsv_patien.Items[0].Selected = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
            nlsv_patien.Items[bs.Position].Focused = true;
            nlsv_patien.Items[bs.Position].Selected = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            nlsv_patien.Items[bs.Position].Focused = true;
            nlsv_patien.Items[bs.Position].Selected = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
            nlsv_patien.Items[bs.Position].Focused = true;
            nlsv_patien.Items[bs.Position].Selected = true;
        }

        private void nlsv_patien_Click(object sender, EventArgs e)
        {
            bs.Position = nlsv_patien.FocusedItem.Index;
        }

        //Modify at 2008 08 28
        private void LoadTreeView(DataTable table)
        {
            treeView1.Nodes.Clear();

            int k = 0;
            foreach(DataRow row in table.Rows)
            {
                string nodename = row["EXAM_TYPE_UID"].ToString() + " " + row["EXAM_TYPE_TEXT"].ToString();
                TreeNode tn = new TreeNode(nodename);
                tn.Tag = k;
                treeView1.Nodes.Add(tn);
                ++k;
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView sd = (TreeView)sender;

            if (e.Node.Tag != null)
            {
                bs.Position = (int)e.Node.Tag;
            }
        }
        //Modify

    }
}