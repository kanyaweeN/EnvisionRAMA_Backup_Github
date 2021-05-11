using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
namespace Envision.NET.Forms.InternalMessage
{
    public partial class frmSend : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private List<int> ccList;
        private List<int> toList;
        private DataTable dttEmp;
        private DataView dv_emp_CC;
        private DataView dv_emp_TO;
        private MyMessageBox msg = new MyMessageBox();
        public int MessageID { get; set; }

        public frmSend()
        {
            InitializeComponent();
            MessageID = 0;
            loadHREmp();
            dv_emp_CC = DataViewEmpCC;
            loadAutoComplete();
            loadPriority();
            //chkForced.Enabled = env.SUPPORT_USER == "N" ? false : true;
        }
        public frmSend(int mid)
        {
            InitializeComponent();
            MessageID = mid;
            loadHREmp();
            loadAutoComplete();
            loadPriority();
            //chkForced.Enabled = env.SUPPORT_USER == "N" ? false : true;
            loadMessageDraft();
        }
        public frmSend(int mid, string type) {
            InitializeComponent();
            MessageID = mid;
            loadHREmp();
            loadAutoComplete();
            loadPriority();
            //chkForced.Enabled = env.SUPPORT_USER == "N" ? false : true;
            DataSet ds = getGBLMessageByMsgID();
            if (type.ToUpper() == "R")//Reply
            {
                toList = new List<int>();
                toList.Add(Convert.ToInt32(ds.Tables[0].Rows[0]["MSG_FROM"].ToString()));
                txtTo.Text = ds.Tables[0].Rows[0]["FROM_FULLNAME"].ToString().Trim();
                grdLookupPriority.EditValue = ds.Tables[0].Rows[0]["MSG_PRIORITY"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["IS_FORCED"].ToString() == "N")
                    chkForced.Checked = false;
                else
                    chkForced.Checked = true;
                txtSubject.Text = "RE : " + ds.Tables[0].Rows[0]["MSG_SUBJECT"].ToString().Trim();
                txtBody.Text = "\r\n\r\n--------------------------------------------------\r\n";
                txtBody.Text += ds.Tables[0].Rows[0]["MSG_SUBJECT"].ToString().Trim();
                txtBody.Focus();
            }
            else if (type.ToUpper() == "A")//Reply All
            {
                toList = new List<int>();
                toList.Add(Convert.ToInt32(ds.Tables[0].Rows[0]["MSG_FROM"].ToString()));
                int id = toList[0];
                txtTo.Text = ds.Tables[0].Rows[0]["FROM_FULLNAME"].ToString().Trim();
                //find CC
                dv_emp_CC = DataViewEmpCC;
                ccList = new List<int>();
                DataView _dv = ds.Tables[1].DefaultView;
                foreach (DataRowView _item in _dv)
                {
                    if (_item["MSG_TO"].ToString().Trim() == id.ToString()) continue;
                    dv_emp_CC.RowFilter = "EMP_ID = " + _item["MSG_TO"].ToString();
                    if (dv_emp_CC.Count > 0)
                        dv_emp_CC[0]["IS_SELECTED"] = 1;
                }
                setDataFromCCList();
                //
                grdLookupPriority.EditValue = ds.Tables[0].Rows[0]["MSG_PRIORITY"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["IS_FORCED"].ToString() == "N")
                    chkForced.Checked = false;
                else
                    chkForced.Checked = true;
                txtSubject.Text = "RE : " + ds.Tables[0].Rows[0]["MSG_SUBJECT"].ToString().Trim();
                txtBody.Text = "\r\n\r\n--------------------------------------------------\r\n";
                txtBody.Text += ds.Tables[0].Rows[0]["MSG_SUBJECT"].ToString().Trim();
            }
            else //Forward
            {
                grdLookupPriority.EditValue = ds.Tables[0].Rows[0]["MSG_PRIORITY"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["IS_FORCED"].ToString() == "N")
                    chkForced.Checked = false;
                else
                    chkForced.Checked = true;
                txtSubject.Text = "FW : " + ds.Tables[0].Rows[0]["MSG_SUBJECT"].ToString().Trim();
                txtBody.Text = ds.Tables[0].Rows[0]["MSG_SUBJECT"].ToString().Trim();
            }
            MessageID = 0;
        }

        private void barSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Require Check.
            if (txtTo.Text.Trim().Length == 0) {
                msg.ShowAlert("UID1301", env.CurrentLanguageID);
                txtTo.Focus();
                return;
            }
            if (txtBody.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1302", env.CurrentLanguageID);
                txtBody.Focus();
                return;
            }
            if (msg.ShowAlert("UID1303", env.CurrentLanguageID)=="2")
            {
                if (MessageID == 0)
                    addGBLMessage('S');
                else
                    updateGBLMessage('S');
                DialogResult = DialogResult.OK;
            }
            #endregion
           
        }
        private void barSaveDraft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Require Check.
            if (txtBody.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1302", env.CurrentLanguageID);
                txtBody.Focus();
                return;
            }
            #endregion
            if (msg.ShowAlert("UID1304", env.CurrentLanguageID) == "2")
                editGBLMessageDraft();
        }

        private void loadHREmp()
        {
            ProcessGetHREmp _prc = new ProcessGetHREmp();
            _prc.HR_EMP.ORG_ID = env.OrgID;
            _prc.InvokeLite();
            dttEmp = new DataTable();
            dttEmp = _prc.Result.Tables[0].Copy();
        }
        private void loadAutoComplete() {
            AutoCompleteStringCollection name = new AutoCompleteStringCollection();
            for (int i = 0; i < dttEmp.Rows.Count; i++)
                name.Add(dttEmp.Rows[i]["FULLNAME"].ToString());
            txtTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTo.AutoCompleteCustomSource = name;
        }
        private void loadPriority() {
            DataTable _dt;
            _dt = new DataTable();
            _dt.Columns.Add("Code");
            _dt.Columns.Add("Name");
            _dt.AcceptChanges();
            _dt.Rows.Add(new object[] { "L", "Low" });
            _dt.Rows.Add(new object[] { "M", "Medium" });
            _dt.Rows.Add(new object[] { "H", "High" });
           
            grdLookupPriority.Properties.DisplayMember = "Name";
            grdLookupPriority.Properties.ValueMember = "Code";
            grdLookupPriority.Properties.DataSource = _dt;
            grdLookupPriority.EditValue = "M";
            grdLookupPriority.Properties.View.Columns[0].Visible = false;
        }


        #region To Section.
        private void txtTo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void txtTo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTo.Text.Trim()))
            {
                e.Cancel = true;
                foreach (DataRow row in dttEmp.Rows)
                {
                    if (txtTo.Text.Trim() == row["FULLNAME"].ToString().Trim())
                    {
                        e.Cancel = false;
                        toList = new List<int>();
                        toList.Add(Convert.ToInt32(row["EMP_ID"].ToString()));
                        break;
                    }
                }
                if (e.Cancel) {
                    msg.ShowAlert("UID1301", env.CurrentLanguageID);
                }
            }
        }
        private void btnTo_Click(object sender, EventArgs e)
        {
            showToFromEmpList();
            grdLookupPriority.Focus();
        }

        private DataView getHREmpTO()
        {
            ProcessGetHREmp _prc = new ProcessGetHREmp();
            _prc.HR_EMP.ORG_ID = env.OrgID;
            _prc.InvokeLite();
            return _prc.Result.Tables[0].DefaultView;
        }
        public DataView DataViewEmpTo
        {
            get
            {
                if (dv_emp_TO == null)
                {
                    DataColumn _dc = new DataColumn()
                    {
                        ColumnName = "IS_SELECTED",
                        DataType = typeof(bool),
                        DefaultValue = false
                    };

                    dv_emp_TO = getHREmpCC();
                    dv_emp_TO.Table.Columns.Add(_dc);
                    dv_emp_TO.Table.AcceptChanges();
                }

                return dv_emp_TO;
            }
            set
            {
                dv_emp_TO = value;
            }
        }
        private void showToFromEmpList()
        {
            frmEmpList _frm = new frmEmpList();
            _frm.dvEmpList = DataViewEmpTo;
            _frm.IsOneClick = true;
            if (_frm.ShowDialog() == DialogResult.OK)
            {
                DataViewEmpTo = _frm.dvEmpList;
                setDataFromToList();
            }
        }
        private void setDataFromToList()
        {
            string _cc_list;
            toList = new List<int>();
            DataViewEmpTo.RowFilter = "IS_SELECTED = 1";
            _cc_list = "";
            foreach (DataRowView _item in DataViewEmpTo)
            {
                toList.Add(Convert.ToInt32(_item["EMP_ID"]));
                _cc_list += _item["FULLNAME"].ToString();
            }
            txtTo.Text = _cc_list;
            DataViewEmpTo.RowFilter = "";
            foreach (DataRowView _item in DataViewEmpTo)
                _item["IS_SELECTED"] = "False";
            DataViewEmpTo.Table.AcceptChanges();
        }
        #endregion

        #region CC Section.
        private void txtCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void txtCC_DoubleClick(object sender, EventArgs e)
        {
            showCCFromEmpList();
        }
        private void btnCC_Click(object sender, EventArgs e)
        {
            showCCFromEmpList();
        }
        private void chkCCAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCCAll.Checked)
            {
                foreach (DataRowView _item in DataViewEmpCC)
                    _item["IS_SELECTED"] = "True";
                setDataFromCCList();
            }
            else
            {
                foreach (DataRowView _item in DataViewEmpCC)
                    _item["IS_SELECTED"] = "False";
                txtCC.Text = string.Empty;
                ccList = new List<int>();
            }
        }

        private DataView getHREmpCC()
        {
            ProcessGetHREmp _prc = new ProcessGetHREmp();
            _prc.HR_EMP.ORG_ID = env.OrgID;
            _prc.InvokeLite();
            return _prc.Result.Tables[0].DefaultView;
        }
        public DataView DataViewEmpCC
        {
            get
            {
                if (dv_emp_CC == null)
                {
                    DataColumn _dc = new DataColumn()
                    {
                        ColumnName = "IS_SELECTED",
                        DataType = typeof(bool),
                        DefaultValue = false
                    };

                    dv_emp_CC = getHREmpCC();
                    dv_emp_CC.Table.Columns.Add(_dc);
                    dv_emp_CC.Table.AcceptChanges();
                }

                return dv_emp_CC;
            }
            set
            {
                dv_emp_CC = value;
            }
        }
        private void showCCFromEmpList()
        {
            frmEmpList _frm = new frmEmpList();
            _frm.dvEmpList = DataViewEmpCC;

            if (_frm.ShowDialog() == DialogResult.OK)
            {
                DataViewEmpCC = _frm.dvEmpList;
                setDataFromCCList();
            }
        }
        private void setDataFromCCList()
        {
            string _cc_list;
            ccList = new List<int>();
            DataViewEmpCC.RowFilter = "IS_SELECTED = 1";
            _cc_list = "";
            foreach (DataRowView _item in DataViewEmpCC)
            {
                ccList.Add(Convert.ToInt32(_item["EMP_ID"]));
                _cc_list += _item["FULLNAME"].ToString() + ";";
            }
            txtCC.Text = _cc_list;
            DataViewEmpCC.RowFilter = "";
        }
        #endregion

        #region KeyDown Events.
        private void txtSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBody.Focus();
        }
        private void grdLookupPriority_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        #endregion

        private void editGBLMessageDraft()
        {
            if (MessageID == 0)
                addGBLMessage('D');
            else
                updateGBLMessage('D');
        }

        private void addGBLMessage(char Status)
        {
            ProcessAddGBLMessage _prc = new ProcessAddGBLMessage();
            _prc.Columns.MSG_FROM = env.UserID;
            _prc.Columns.MSG_SUBJECT = txtSubject.Text.Trim();
            _prc.Columns.MSG_BODY = txtBody.Text.Trim();
            _prc.Columns.MSG_STATUS = Status;
            _prc.Columns.MSG_PRIORITY = grdLookupPriority.EditValue.ToString()[0];
            _prc.Columns.IS_FORCED = chkForced.Checked ? 'Y' : 'N';
            _prc.Columns.CREATED_BY = env.UserID;
            _prc.Invoke();
            MessageID = _prc.MsgID;
            //if(Status=='S')
                addGBLMessageRecipientSend(_prc.MsgID);
            
        }
        private void addGBLMessageRecipientSend(int MsgID)
        {
            ProcessAddGBLMessageRecipient _prc = new ProcessAddGBLMessageRecipient();
            _prc.Columns.MSG_ID = MsgID;
            _prc.Columns.CREATED_BY = env.UserID;
            //insert TO
            int id = 0;
            if (toList != null)
            {
                if (toList.Count > 0)
                {
                    _prc.Columns.CC_TO = toList[0];
                    id = _prc.Columns.CC_TO;
                    _prc.Columns.RECIPIENT_TYPE = "T";
                    _prc.InvokeSend();
                }
            }
            if (ccList != null)
            {
                if (ccList.Count > 0)
                {
                    ccList.Remove(id);
                    //insert CC
                    foreach (int _item in ccList)
                    {
                        _prc.Columns.CC_TO = _item;
                        _prc.Columns.RECIPIENT_TYPE = "C";
                        _prc.InvokeSend();
                    }
                }
            }
        }
        private void updateGBLMessage(char Status)
        {
            ProcessUpdateGBLMessage _prc = new ProcessUpdateGBLMessage();
            _prc.Columns.MSG_ID = this.MessageID;
            _prc.Columns.MSG_SUBJECT = txtSubject.Text;
            _prc.Columns.MSG_BODY = txtBody.Text;
            _prc.Columns.MSG_STATUS = Status;
            _prc.Columns.MSG_PRIORITY = grdLookupPriority.EditValue.ToString()[0];
            _prc.Columns.IS_FORCED = chkForced.Checked ? 'Y' : 'N';
            _prc.Columns.LAST_MODIFIED_BY = env.UserID;
            _prc.Invoke();
        }

        private int MSG_FROM { get; set; }
        private string MSG_SUBJECT
        {
            get { return txtSubject.Text; }
            set
            {
                txtSubject.Text = value;
            }
        }
        private string MSG_BODY
        {
            get { return txtBody.Text; }
            set
            {
                txtBody.Text = value;
            }
        }
        private char MSG_STATUS { get; set; }
        private char MSG_PRIORITY
        {
            get { return grdLookupPriority.EditValue.ToString()[0]; }
            set { grdLookupPriority.EditValue = value; }
        }
        private char IS_STARRED { get; set; }
        private char IS_FORCED { get; set; }
        private void loadMessageDraft() {
            DataSet ds = getGBLMessageByMsgID();
            DataRowView _drv;

            _drv = ds.Tables[0].DefaultView[0];
            MessageID = Convert.ToInt32(_drv["MSG_ID"].ToString());
            MSG_FROM = Convert.ToInt32(_drv["MSG_FROM"]);
            MSG_SUBJECT = _drv["MSG_SUBJECT"].ToString();
            MSG_BODY = _drv["MSG_BODY"].ToString();
            MSG_STATUS = Convert.ToChar(_drv["MSG_STATUS"]);
            MSG_PRIORITY = Convert.ToChar(_drv["MSG_PRIORITY"]);
            //To
            int id = 0;
            toList = new List<int>();
            DataRow[] drSend = ds.Tables[1].Select("RECIPIENT_TYPE='T'");
            if (drSend.Length > 0)
            {
                DataRow[] dr = dttEmp.Select("EMP_ID=" + drSend[0]["MSG_TO"].ToString());
                if (dr.Length > 0)
                {
                    toList.Add(Convert.ToInt32(dr[0]["EMP_ID"].ToString()));
                    id = toList[0];
                    txtTo.Text = dr[0]["FULLNAME"].ToString().Trim();
                }
            }
            //CC
            dv_emp_CC = DataViewEmpCC;
            ccList = new List<int>();
            DataView _dv = ds.Tables[1].DefaultView;
            foreach (DataRowView _item in _dv)
            {
                if (_item["MSG_TO"].ToString().Trim() == id.ToString()) continue;
                dv_emp_CC.RowFilter = "EMP_ID = " + _item["MSG_TO"].ToString();
                if (dv_emp_CC.Count > 0)
                    dv_emp_CC[0]["IS_SELECTED"] = 1;
            }
            setDataFromCCList();
        }
        private DataSet getGBLMessageByMsgID()
        {
            ProcessGetGBLMessage _prc = new ProcessGetGBLMessage();
            _prc.Columns.MSG_ID = this.MessageID;
            _prc.InvokeByMsgID();
            return _prc.Result;
        }
        public void SendMessage(int EmpId, string Name)
        {
            if (EmpId < 1) return;
            toList = new List<int>();
            toList.Add(EmpId);
            txtTo.Text = Name;
        }

        private void addGBLMessage(char Status, int EmpId)
        {
            ProcessAddGBLMessage _prc = new ProcessAddGBLMessage();
            _prc.Columns.MSG_FROM = 1;
            _prc.Columns.MSG_SUBJECT = txtSubject.Text.Trim();
            _prc.Columns.MSG_BODY = txtBody.Text.Trim();
            _prc.Columns.MSG_STATUS = Status;
            _prc.Columns.MSG_PRIORITY = 'M';
            _prc.Columns.IS_FORCED = 'N';
            _prc.Columns.CREATED_BY = env.UserID;
            _prc.Invoke();

            ProcessAddGBLMessageRecipient proc = new ProcessAddGBLMessageRecipient();
            proc.Columns.MSG_ID = _prc.MsgID; ;
            proc.Columns.CREATED_BY = env.UserID;
            proc.Columns.CC_TO = EmpId;
            proc.Columns.RECIPIENT_TYPE = "T";
            proc.InvokeSend();
        }
        public void SendAutoMessage(string RoleUId, string Subject, string Body)
        {
            toList = new List<int>();
            MSG_SUBJECT = Subject;
            MSG_BODY = Body;
            ProcessGetGBLRole proc = new ProcessGetGBLRole();
            proc.SPType = 4;
            proc.UsID = RoleUId;
            proc.Invoke();
            if (Miracle.Util.Utilities.IsHaveData(proc.ResultSet))
            {
                foreach (DataRow rowHandle in proc.ResultSet.Tables[0].Rows)
                    addGBLMessage('S', Convert.ToInt32(rowHandle["EMP_ID"].ToString()));
            }
        }
        /// <summary>
        /// Send Auto message for academic
        /// </summary>
        /// <param name="Status">status</param>
        /// <param name="EmpId">to</param>
        /// <param name="from">from</param>
        private void addGBLMessage(char Status, int EmpId, int from)
        {
            ProcessAddGBLMessage _prc = new ProcessAddGBLMessage();
            _prc.Columns.MSG_FROM = from;
            _prc.Columns.MSG_SUBJECT = txtSubject.Text.Trim();
            _prc.Columns.MSG_BODY = txtBody.Text.Trim();
            _prc.Columns.MSG_STATUS = Status;
            _prc.Columns.MSG_PRIORITY = 'M';
            _prc.Columns.IS_FORCED = 'N';
            _prc.Columns.CREATED_BY = env.UserID;
            _prc.Invoke();

            ProcessAddGBLMessageRecipient proc = new ProcessAddGBLMessageRecipient();
            proc.Columns.MSG_ID = _prc.MsgID; ;
            proc.Columns.CREATED_BY = env.UserID;
            proc.Columns.CC_TO = EmpId;
            proc.Columns.RECIPIENT_TYPE = "T";
            proc.InvokeSend();
        }

        /// <summary>
        /// Send Auto message for academic
        /// </summary>
        /// <param name="empIds">resident ids</param>
        /// <param name="Subject">subject</param>
        /// <param name="Message">message</param>
        public void SendAutoMessage(int[] empIds, string Subject, string Message, int from)
        {
            toList = new List<int>();
            MSG_SUBJECT = Subject;
            MSG_BODY = Message;
            foreach (int empId in empIds)
                addGBLMessage('S', Convert.ToInt32(empId), from);
        }
    }//
}
