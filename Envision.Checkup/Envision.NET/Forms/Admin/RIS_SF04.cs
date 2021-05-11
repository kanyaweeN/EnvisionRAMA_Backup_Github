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
    public partial class RIS_SF04 : Form
    {
        alertObjectCollection rvisticol = new alertObjectCollection();
        ProcessGetAlert rhabvisitlistm = new ProcessGetAlert();
        DBUtility dbu = new DBUtility();

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        ProcessGetRISPatstatus alt = new ProcessGetRISPatstatus();
        DataTable dt2 = new DataTable();
        BindingSource bs = new BindingSource();
        Binding bd;

        public RIS_SF04(UUL.ControlFrame.Controls.TabControl clsCtl)
        //public RIS_SF04()
        {
            InitializeComponent();
            CloseControl = clsCtl;
            LoadFormLanguage();
            //loadTree("");

            rvisticol = rhabvisitlistm.SelectData();

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


        #region reset
        public void reset()
        {
            cmbLanguage.Text = new GBLEnvVariable().LangName;
            btnAdd.Text = "&Add";
            btnAdd.Enabled = true;
            btnDelete.Text = "&Delete";
            btnDelete.Enabled = true;
            btnEdit.Text = "&Edit";
            btnEdit.Enabled = true;

            nTxt_sText.Text  = "";
            nTxt_sText.Enabled = false;
            ntxt_sUid.Text = "";
            ntxt_sUid.Enabled = false;
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

        #endregion


        #region LoadTree2
        #endregion

        #region Editable
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            new GBLEnvVariable().CurrentLanguageID = cmbLanguage.SelectedIndex + 1;
        }
        private void txtSearch_LostFocus(object sender, System.EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search";
            }
            else
            {
            }



        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "&Add")
                {
                    nevigation("0");
                    //editable();
                    btnAdd.Text = "&Save";
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;

                    ntxt_sUid.Enabled = true;
                    nTxt_sText.Enabled = true;
                    ntxt_sUid.Focus();

                    chkActive.Enabled = true;

                    btnRefresh.Text = "Cancel";
                }

                else
                {
                    if (ntxt_sUid.Text == "")
                    {
                        MessageBox.Show("Please Insert Status UID !!");
                        return;
                    }
                    if (nTxt_sText.Text == "")
                    {
                        MessageBox.Show("Please Insert Status Text !!");
                        return;
                    }
                    GBLEnvVariable patenv = new GBLEnvVariable();
                    ProcessAddRISPatstatus processpat = new ProcessAddRISPatstatus();
                    RISPatstatus gblpat = new RISPatstatus();
                    gblpat.STATUS_UID = ntxt_sUid.Text;
                    gblpat.STATUS_TEXT = nTxt_sText.Text;
                    if (chkActive.Checked == true)
                    {
                        gblpat.IsActive = "1";
                    }
                    else
                    {
                        gblpat.IsActive = "0";
                    }
                    gblpat.ORG_ID = patenv.OrgID;
                    gblpat.CREATED_BY = patenv.UserID;


                    processpat.RISPatstatus = gblpat;

                    try
                    {
                        processpat.Invoke();

                        btnAdd.Text = "&Add";
                        btnEdit.Text = "&Edit";
                        Load_DB();
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

        private void Load_DB()
        {
            //Load DB into Listview;
            try
            {

                reset();
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


                    if (dt2.Rows[k][3].ToString() == "1")
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

        private void RIS_SF04_Load(object sender, EventArgs e)
        {
            Load_DB();
        }

        private void nGrouper1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (btnRefresh.Text == "Cancel")
                btnRefresh.Text = "Refresh";

            reset();
            Load_DB();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (btnEdit.Text == "&Edit")
            {
                //if (nlsv_patien.Focused == false)
                //{
                //    MessageBox.Show("Please Select Data !!");
                //}
                //else
                //{

                    nevigation("0");

                    btnEdit.Text = "&Update";
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

                    btnRefresh.Text = "Cancel";
                //}
            }
            else
            {


                GBLEnvVariable gblenv = new GBLEnvVariable();
                RISPatstatus gblpatient = new RISPatstatus();
                ProcessUpdateRISPatstatus processpatstatus = new ProcessUpdateRISPatstatus();
                gblpatient.STATUS_ID = Convert.ToInt32(ntxtID.Text);
                gblpatient.STATUS_UID = ntxt_sUid.Text.ToString();
                gblpatient.STATUS_TEXT = nTxt_sText.Text.ToString();
                if (chkActive.Checked == true)
                {
                    gblpatient.IsActive = "1";
                }
                else
                {
                    gblpatient.IsActive = "0";
                }
                gblpatient.ORG_ID = gblenv.OrgID;
                gblpatient.LAST_MODIFIED_BY = gblenv.UserID;
                processpatstatus.RISPatstatus = gblpatient;

                try
                {
                    processpatstatus.Invoke();

                    btnAdd.Text = "&Add";
                    btnEdit.Text = "&Edit";
                    reset();
                    nevigation("1");
                    ntxt_sUid.Enabled = false;
                    ntxt_sUid.Text = "";
                    nTxt_sText.Enabled = false;
                    nTxt_sText.Text = "";
                    chkActive.Checked = false;

                    Load_DB();
                    reset();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }


        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (nlsv_patien.Focused == false)
            //{
            //    MessageBox.Show("Please Select Data !!");
            //}
            //else
            //{

                RISPatstatus patstatus = new RISPatstatus();
                ProcessDeletePatient processpatstatus = new ProcessDeletePatient();

                patstatus.STATUS_ID = Convert.ToInt32(nlsv_patien.Items[bs.Position].SubItems[2].Text.ToString());
                processpatstatus.RISPatstatus = patstatus;

                if (MessageBox.Show("Delete Data " + (bs.Position + 1) + ". ", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                try
                {
                    processpatstatus.Invoke();
                    Load_DB();
                    reset();


                }
                catch (Exception EX) { }
            //}
        }

        private void nlsv_patien_MouseClick(object sender, MouseEventArgs e)
        {
            //ntxtID.Text = nlsv_patien.FocusedItem.SubItems[2].Text.ToString();
            //nlsv_patien.FocusedItem.Checked = true;
            bs.Position = nlsv_patien.FocusedItem.Index;
        }

        private void nlsv_patien_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           
        }

        private void nlsv_patien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
            nlsv_patien.Items[0].Selected = true;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            nlsv_patien.Items[bs.Position].Selected = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
            nlsv_patien.Items[bs.Position].Selected = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
            nlsv_patien.Items[bs.Position].Selected = true;
        }

        private void nlsv_patien_Click(object sender, EventArgs e)
        {
            bs.Position = nlsv_patien.FocusedItem.Index;
        }


    }
}
