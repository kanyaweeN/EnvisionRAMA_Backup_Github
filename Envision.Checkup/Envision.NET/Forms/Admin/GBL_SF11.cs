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
using RIS.Forms.Lookup;
using RIS.Forms.GBLMessage;

namespace RIS.Forms.Admin
{
    public partial class GBL_SF11 : Form
    {
        
        private List<string> _deleteItem = new List<string>();
        private DataSet _tempDataSet = new DataSet();
        DBUtility dbu = new DBUtility();
        string _empId = "";
        GBLEnvVariable env = new GBLEnvVariable();
        MyMessageBox msg = new MyMessageBox();

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public GBL_SF11(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            ChangeFormLanguage();
           // LoadFormLanguage();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //dbu.CloseFrom(CloseControl, this);
        }

  
        

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            grdGrantObject.CommitEdit(new DataGridViewDataErrorContexts());

            for (int i = 0; i < grdGrantObject.Rows.Count; i++)  //foreach (DataGridViewRow row in grdLang.Rows)
            {
                bool isDelete = false;
                try
                {
                    isDelete = (bool)grdGrantObject.Rows[i].Cells[0].Value;
                }
                catch (Exception ex)
                {
                }

                if (isDelete)
                {
                    if (grdGrantObject.Rows[i].Cells[1].Value.ToString() != "")
                        if (!_deleteItem.Contains(grdGrantObject.Rows[i].Cells[1].Value.ToString()))
                            _deleteItem.Add(grdGrantObject.Rows[i].Cells[1].Value.ToString());
                    _tempDataSet.Tables[0].Rows.RemoveAt(i);
                    i = -1;
                }
            }
            //foreach (string str in _deleteItem)
            //{
            //    MessageBox.Show(str);
            //}
        }
        
        private void GBL_SF11_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            grdGrantObject.CommitEdit(new DataGridViewDataErrorContexts());

            //if (MessageBox.Show("Are you sure you want to save the data? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            string ret = msg.ShowAlert("UID008", env.CurrentLanguageID);
            if (ret.ToString() == "2")
            {
                List<GBLGrantObject> insertGrantObject = new List<GBLGrantObject>();
                List<GBLGrantObject> updateGrantObject = new List<GBLGrantObject>();

                foreach (DataGridViewRow row in grdGrantObject.Rows)
                {
                    string tmpView = row.Cells[4].Value.ToString() == "Y" ? "Y" : "N";
                    string tmpCreate = row.Cells[5].Value.ToString() == "Y" ? "Y" : "N";
                    string tmpModify = row.Cells[6].Value.ToString() == "Y" ? "Y" : "N";
                    string tmpRemove = row.Cells[7].Value.ToString() == "Y" ? "Y" : "N";
                    if (row.Cells[1].Value.ToString().Trim() != "")
                        updateGrantObject.Add(new GBLGrantObject(Int32.Parse(row.Cells[1].Value.ToString()), Int32.Parse(row.Cells[2].Value.ToString()),Int32.Parse(_empId), tmpView,tmpCreate,tmpModify,tmpRemove));
                    else
                        insertGrantObject.Add(new GBLGrantObject(0, Int32.Parse(row.Cells[2].Value.ToString()), Int32.Parse(_empId), tmpView, tmpCreate, tmpModify, tmpRemove));
                }

                if (_deleteItem.Count > 0)
                {
                    ProcessDeleteGrantObject process = new ProcessDeleteGrantObject();
                    process.DeleteItem = _deleteItem;
                    process.Invoke();
                }

                if (insertGrantObject.Count > 0)
                {
                    ProcessInsertGrantObject process = new ProcessInsertGrantObject();
                    process.GrantItem = insertGrantObject;
                    process.Invoke();
                }

                if (updateGrantObject.Count > 0)
                {
                    ProcessUpdateGrantObject process = new ProcessUpdateGrantObject();
                    process.GrantItem = updateGrantObject;
                    process.Invoke();
                }



            }


            Binding(_empId);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nGrouper1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grdGrantObject.CommitEdit(new DataGridViewDataErrorContexts());
            if (_empId != "")
            {
                string _tmp = "";
                foreach (DataGridViewRow row in grdGrantObject.Rows)
                {
                    if(_tmp == "")
                        _tmp = row.Cells[2].Value.ToString();
                    else
                        _tmp += "," + row.Cells[2].Value.ToString();
                }
                if (_tmp != "") _tmp = " where SUBMENU_ID NOT IN(" + _tmp + ")";

                Lookup.Lookup lv = new Lookup.Lookup();
                lv.ValueUpdated += new ValueUpdatedEventHandler(addSubMenu);
                string qry = "SELECT SUBMENU_ID,SUBMENU_NAME_USER from dbo.GBL_SUBMENU " + _tmp;
                string fields = "SUBMENU UID,SUBMENU NAME";
                string con = "";
                lv.getData(qry, fields, con, "Pond");
                lv.Show();
            }
           
        }

        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_empId != "") 
                Binding(_empId);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void nButton2_Click(object sender, EventArgs e)
        {
            if (_empId != "")
            {
                Inherit(_empId, 1);
            }

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            
            Lookup.Lookup lv = new Lookup.Lookup();
            lv.ValueUpdated += new ValueUpdatedEventHandler(getEmpDetail);
            string qry = "SELECT EMP_ID,USER_NAME from HR_EMP where EMP_UID like '%%'";
            string fields = "EMP UID,USERNAME";
            string con = "";
            lv.getData(qry, fields, con, "Pond");
            lv.Show();
        }

        private void getEmpDetail(object sender, ValueUpdatedEventArgs e)
        {         
            int lovNo = 1;
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            if (retValue.Length > 0)
            {
                //MessageBox.Show("" + retValue[0].ToString());
                txtEmpID.Text = retValue[0].ToString();
                txtEmpName.Text = retValue[1].ToString();
                this._empId = txtEmpID.Text;
                //disCode = Convert.ToInt32(retValue[1].ToString());
                Binding(txtEmpID.Text);
            }

        }
        private void addSubMenu(object sender, ValueUpdatedEventArgs e)
        {
            int lovNo = 1;
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            if (retValue.Length > 0)
            {
                //_tempDataSet.Tables[0].Rows.Add(new object[7] { new Object(), retValue[0].ToString(), retValue[1].ToString(), "N", "N", "N", "N" });
                _tempDataSet.Tables[0].Rows.Add(new object[7]);
                _tempDataSet.Tables[0].Rows[_tempDataSet.Tables[0].Rows.Count - 1][1] = retValue[0].ToString();
                _tempDataSet.Tables[0].Rows[_tempDataSet.Tables[0].Rows.Count - 1][2] = retValue[1].ToString();
                _tempDataSet.Tables[0].Rows[_tempDataSet.Tables[0].Rows.Count - 1][3] = "N";
                _tempDataSet.Tables[0].Rows[_tempDataSet.Tables[0].Rows.Count - 1][4] = "N";
                _tempDataSet.Tables[0].Rows[_tempDataSet.Tables[0].Rows.Count - 1][5] = "N";
                _tempDataSet.Tables[0].Rows[_tempDataSet.Tables[0].Rows.Count - 1][6] = "N";
            }

        }

        private void nButton3_Click(object sender, EventArgs e)
        {
            if (_empId != "")
            {
                Inherit(_empId, 0);
            }
        }

        private void Binding(string uuid)
        {
            _deleteItem.Clear();
            ProcessGetGrantObject process = new ProcessGetGrantObject();
            process.UUID = uuid;
            process.Invoke();
            _tempDataSet = process.ResultSet;
            grdGrantObject.DataSource = _tempDataSet.Tables[0];
        }

        private void Inherit(string uuid, int type)
        {
            _deleteItem.Clear();

            for (int i = 0; i < grdGrantObject.Rows.Count; i++)  //foreach (DataGridViewRow row in grdLang.Rows)
            {
                if (grdGrantObject.Rows[i].Cells[1].Value.ToString() != "")
                {
                    if (!_deleteItem.Contains(grdGrantObject.Rows[i].Cells[1].Value.ToString()))
                        _deleteItem.Add(grdGrantObject.Rows[i].Cells[1].Value.ToString());
                }
            }

            ProcessGetInherit process = new ProcessGetInherit();
            process.UUID = uuid;
            process.Type = type;
            process.Invoke();
            _tempDataSet = process.ResultSet;
            grdGrantObject.DataSource = _tempDataSet.Tables[0];
        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void ChangeFormLanguage()
        {


            FormLanguage fl = new FormLanguage();
            fl.FormID = 22;
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
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblHeader").ToUpper().Trim())
                    {
                        this.nGrouper1.HeaderItem.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUnitId").ToUpper().Trim())
                    {
                        this.lblUnitId.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUnitName").ToUpper().Trim())
                    {
                        this.lblUnitName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblJobId").ToUpper().Trim())
                    {
                        this.lblJobId.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblJobName").ToUpper().Trim())
                    {
                        this.lblJobName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }

                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblHeader").ToUpper().Trim())
                    {
                        this.nGrouper1.HeaderItem.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUnitId").ToUpper().Trim())
                    {
                        this.lblUnitId.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUnitName").ToUpper().Trim())
                    {
                        this.lblUnitName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblJobId").ToUpper().Trim())
                    {
                        this.lblJobId.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblJobName").ToUpper().Trim())
                    {
                        this.lblJobName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblHeader").ToUpper().Trim())
                    {
                        this.nGrouper1.HeaderItem.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUnitId").ToUpper().Trim())
                    {
                        this.lblUnitId.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUnitName").ToUpper().Trim())
                    {
                        this.lblUnitName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblJobId").ToUpper().Trim())
                    {
                        this.lblJobId.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblJobName").ToUpper().Trim())
                    {
                        this.lblJobName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblEmpId").ToUpper().Trim())
                    {
                        this.lblEmpId.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblEmpName").ToUpper().Trim())
                    {
                        this.lblEmpName.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnLookUp").ToUpper().Trim())
                    {
                        this.btnLookUp.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnObject").ToUpper().Trim())
                    {
                        this.btnObject.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("btnRole").ToUpper().Trim())
                    {
                        this.btnRole.Text = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblDelete").ToUpper().Trim())
                    {
                        this.Delete.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblId").ToUpper().Trim())
                    {
                        this.ID.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblUid").ToUpper().Trim())
                    {
                        this.UID.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblName").ToUpper().Trim())
                    {
                        this.NAME.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblView").ToUpper().Trim())
                    {
                        this.VIEW.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblCreate").ToUpper().Trim())
                    {
                        this.CREATE.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblModify").ToUpper().Trim())
                    {
                        this.MODIFY.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
                    }
                    else
                    if ((dt.Rows[k]["OBJECT_NAME"].ToString().ToUpper().Trim()) == ("lblRemove").ToUpper().Trim())
                    {
                        this.REMOVE.HeaderText = dt.Rows[k]["LABEL"].ToString().Trim();
                    }


                    k++;
                }



            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }


            return;

        }

    }
}