using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.UtilityClass;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Common;

namespace RIS.Forms.Admin
{
    public partial class RIS_SF02 : Form
    {
        //alertObjectCollection rvisticol = new alertObjectCollection();
        //ProcessGetAlert rhabvisitlistm = new ProcessGetAlert();
        DBUtility dbu = new DBUtility();

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        ProcessGetRISSF02 alt = new ProcessGetRISSF02();
        DataTable dt2 = new DataTable();
        BindingSource bs = new BindingSource();
        Binding bd;

        public RIS_SF02(UUL.ControlFrame.Controls.TabControl clsCtl)
        //public RIS_SF02()
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
                nlsv_SF02.Items.Clear();

                alt.Invoke();
                dt2 = alt.ResultSet.Tables[0];

                treeView1.ImageList = imageList1;
                bs.DataSource = dt2;
                //bd = ntxt_sUid.DataBindings.Add("Text", bs, "STATUS_UID");
                //bd = nTxt_sText.DataBindings.Add("Text", bs, "STATUS_TEXT");
                //bd = chkActive.DataBindings.Add("IsChecked", bs, "IS_ACTIVE");
                nevigation.BindingSource = bs;


                int k = 0;

                string[] colStr = new string[4];
                while (k < dt2.Rows.Count)
                {
                    colStr[0] = dt2.Rows[k][1].ToString();
                    colStr[1] = dt2.Rows[k][2].ToString();
                    colStr[2] = dt2.Rows[k][3].ToString();
                    colStr[3] = dt2.Rows[k][0].ToString();

                    ListViewItem lvi = new ListViewItem(colStr);
                    //ListViewItem lvi2;
                    ListViewItem.ListViewSubItem lvs = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem lvs2 = new ListViewItem.ListViewSubItem();

                    if (dt2.Rows[k][4].ToString() == "1")
                    {
                        lvs = new ListViewItem.ListViewSubItem(lvi, "R");
                        lvs.Font = new Font("Wingdings 2", 12);
                        lvi.SubItems.Add(lvs);
                    }
                    else
                    {
                        lvs = new ListViewItem.ListViewSubItem(lvi, "p");
                        lvs.Font = new Font("Wingdings", 12);
                        lvi.SubItems.Add(lvs);
                    }
                    if (dt2.Rows[k][5].ToString() == "1")
                    {
                        lvs2 = new ListViewItem.ListViewSubItem(lvi, "R");
                        lvs2.Font = new Font("Wingdings 2", 12);
                        lvi.SubItems.Add(lvs2);
                    }
                    else
                    {
                        lvs2 = new ListViewItem.ListViewSubItem(lvi, "p");
                        lvs2.Font = new Font("Wingdings", 12);
                        lvi.SubItems.Add(lvs2);
                    }
                    //nListActive.Items.Add(lvi2);
                    nlsv_SF02.Items.Add(lvi);

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

        private void RIS_SF02_Load(object sender, EventArgs e)
        {
            Load_DB();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
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
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;

                    ntxt_sUid.Enabled = true;
                    nTxt_sText.Enabled = true;
                    nTxtVer.Enabled = true;
                    ntxt_sUid.Focus();

                    //                    reset();
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                }

                else
                {
                    if (ntxt_sUid.Text == "")
                    {
                        MessageBox.Show("Please Insert ICD UID !!");
                        return;
                    }
                    if (nTxt_sText.Text == "")
                    {
                        MessageBox.Show("Please Insert ICD Text !!");
                        return;
                    }
                    if (nTxtVer.Text == "")
                    {
                        MessageBox.Show("Please Insert ICD Version !!");
                        return;
                    }
                    GBLEnvVariable gbenv = new GBLEnvVariable();
                    ProcessAddRISSF02 processSF02 = new ProcessAddRISSF02();
                    RISSF02Data gblsf02 = new RISSF02Data();
                    gblsf02.ICD_UID = ntxt_sUid.Text;
                    gblsf02.ICD_DESC = nTxt_sText.Text;
                    gblsf02.ICD_VERSION = nTxtVer.Text;
                    if (checkBox1.Checked == true)
                    {
                        gblsf02.IS_UPDATE = "1";
                    }
                    else
                    {
                        gblsf02.IS_UPDATE = "0";
                    }
                    if (checkBox2.Checked == true)
                    {
                        gblsf02.IS_DELETED = "1";
                    }
                    else
                    {
                        gblsf02.IS_DELETED = "0";
                    }
                    gblsf02.ORG_ID = gbenv.OrgID;
                    gblsf02.CREATED_BY = gbenv.UserID;


                    processSF02.RISSF02Data  = gblsf02;

                    try
                    {
                        processSF02.Invoke();

                        btnAdd.Text = "&Add";
                        btnEdit.Text = "&Edit";
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        Load_DB();
                        reset();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
            nlsv_SF02.Items[0].Selected = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            nlsv_SF02.Items[bs.Position].Selected = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
            nlsv_SF02.Items[bs.Position].Selected = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
            nlsv_SF02.Items[bs.Position].Selected = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (nlsv_SF02.Focused == false)
            //{
            //    MessageBox.Show("Please Select Data !!");
            //}
            //else
            //{

                RISSF02Data risobj = new RISSF02Data();
                ProcessDeleteSF02 processobj = new ProcessDeleteSF02();

                risobj.ICD_ID = Convert.ToInt32(nlsv_SF02.Items[bs.Position].SubItems[3].Text.ToString());
                processobj.RISSF02Data = risobj;
                if (MessageBox.Show("Delete Data " + (bs.Position + 1) + ". ", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                try
                {
                    processobj.Invoke();
                    Load_DB();

                }
                catch (Exception EX) { }
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "&Edit")
            {
                //if (nlsv_SF02.Focused == false)
                //{
                //    MessageBox.Show("Please Select Data !!");
                //}
                //else
                //{

                    //nevigation("0");

                    btnEdit.Text = "&Update";
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;

                    ntxt_sUid.Enabled = true;
                    ntxt_sUid.Text = nlsv_SF02.Items[bs.Position].Text.ToString();
                    nTxt_sText.Enabled = true;
                    nTxt_sText.Text = nlsv_SF02.Items[bs.Position].SubItems[1].Text.ToString();
                    nTxtVer.Text = nlsv_SF02.Items[bs.Position].SubItems[2].Text;
                    nTxtVer.Enabled = true;
                    ntxtID.Text = nlsv_SF02.Items[bs.Position].SubItems[3].Text;
                    //ntxtID.Enabled = true;
                    ntxt_sUid.Focus();
                    if (nlsv_SF02.Items[bs.Position].SubItems[4].Text == "R")
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    if (nlsv_SF02.Items[bs.Position].SubItems[5].Text == "R")
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }
                //}
            }
            else
            {


                GBLEnvVariable gblenv = new GBLEnvVariable();
                RISSF02Data inobj = new RISSF02Data();
                ProcessUpdateRISSF02 processobj = new ProcessUpdateRISSF02();
                
                inobj.ICD_ID = Convert.ToInt32(ntxtID.Text.ToString());
                inobj.ICD_UID = ntxt_sUid.Text.ToString();
                inobj.ICD_DESC = nTxt_sText.Text.ToString();
                inobj.ICD_VERSION = nTxtVer.Text.ToString();
                if (checkBox1.Checked == true)
                {
                    inobj.IS_UPDATE = "1";
                }
                else
                {
                    inobj.IS_UPDATE = "0";
                }
                if (checkBox2.Checked == true)
                {
                    inobj.IS_DELETED = "1";
                }
                else
                {
                    inobj.IS_DELETED = "0";
                }
                inobj.ORG_ID = gblenv.OrgID;
                inobj.LASTMODIFIED_BY = gblenv.UserID;
                processobj.RISSF02Data  =  inobj;

                try
                {
                    processobj.Invoke();

                    btnAdd.Text = "&Add";
                    btnEdit.Text = "&Edit";
                    //reset();
                    //nevigation("1");
                    ntxt_sUid.Enabled = false;
                    ntxt_sUid.Text = "";
                    nTxt_sText.Enabled = false;
                    nTxt_sText.Text = "";
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    nTxtVer.Text = "";
                    nTxtVer.Enabled = false;
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;

                    Load_DB();
                    reset();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }
        }

        private void reset()
        {
            nTxt_sText.Text = "";
            nTxt_sText.Enabled = false;
            ntxt_sUid.Enabled = false;
            ntxt_sUid.Text = "";
            nTxtVer.Text = "";
            nTxtVer.Enabled = false;
            checkBox2.Checked = false;
            checkBox2.Enabled = false;
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            btnAdd.Text = "&Add";
            btnAdd.Enabled = true;
            btnDelete.Text = "&Delete";
            btnDelete.Enabled = true;
            btnEdit.Text = "&Edit";
            btnEdit.Enabled = true;

        }
        private void nlsv_SF02_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reset();
            Load_DB();
        }

        private void nlsv_SF02_Click(object sender, EventArgs e)
        {
            bs.Position = nlsv_SF02.FocusedItem.Index;
        }

    }
}