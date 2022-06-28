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
    public partial class frmOpen : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int msgID;
        private MyMessageBox msg = new MyMessageBox();

        public frmOpen()
        {
            InitializeComponent();
            msgID = 0;
        }
        public frmOpen(int MessageID)
        {
            InitializeComponent();
            msgID = MessageID;
        }
        
        private void frmOpen_Load(object sender, EventArgs e)
        {
            loadData();
            updateAckON();
        }
        private DataSet getGBLMessageByMsgID()
        {
            ProcessGetGBLMessage _prc = new ProcessGetGBLMessage();
            _prc.Columns.MSG_ID = msgID;
            _prc.InvokeByMsgID();
            return _prc.Result;
        }
        private void loadData() {
            DataSet ds = getGBLMessageByMsgID();
            txtFrom.Text = ds.Tables[0].Rows[0]["FROM_FULLNAME"].ToString().Trim();
            txtSubject.Text = ds.Tables[0].Rows[0]["MSG_SUBJECT"].ToString().Trim();
            txtBody.Text = ds.Tables[0].Rows[0]["MSG_BODY"].ToString().Trim();
            DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["MSG_DT"].ToString());
            txtOn.Text = dt.ToLongDateString() + " " + dt.ToLongTimeString();
        }
        private void updateAckON() {
            ProcessUpdateGBLMessageRecipient proc = new ProcessUpdateGBLMessageRecipient();
            proc.Columns.MSG_ID = msgID;
            proc.Columns.CC_TO = new GBLEnvVariable().UserID;
            proc.Columns.SP_TYPE = 1;
            proc.UpdateTime();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void barReply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSend frm = new frmSend(msgID, "R");
            frm.ShowDialog();
            frm.Dispose();
        }
        private void barReplyAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSend frm = new frmSend(msgID, "A");
            frm.ShowDialog();
            frm.Dispose();
        }
        private void barForword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSend frm = new frmSend(msgID, "F");
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
