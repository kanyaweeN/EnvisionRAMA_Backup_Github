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
    public partial class frmSentDetail : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int msgId;
        private string name;
        public frmSentDetail()
        {
            InitializeComponent();
            msgId = 0;
        }
        public frmSentDetail(int MessageID,string ReceiveName)
        {
            InitializeComponent();
            msgId = MessageID;
            name = ReceiveName;
        }

        private void frmSentDetail_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData() {
            DataSet ds = getGBLMessageByMsgID();
            txtSubject.Text = ds.Tables[0].Rows[0]["MSG_SUBJECT"].ToString();
            txtTo.Text = name;
            txtBody.Text=ds.Tables[0].Rows[0]["MSG_BODY"].ToString().Trim();
            switch (ds.Tables[0].Rows[0]["MSG_PRIORITY"].ToString())
            { 
                case "L" :
                    txtPriority.Text = "Low";
                    break;
                case "M" :
                    txtPriority.Text = "Medium";
                    break;
                case "H" :
                    txtPriority.Text = "High";
                    break;
            }
            grdData.DataSource = ds.Tables[1].Copy();
            for (int i = 0; i < ds.Tables[1].Columns.Count; i++)
            {
                view1.Columns[i].Visible = false;
                view1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            view1.Columns["TO_FULLNAME"].Caption = "To";
            view1.Columns["TO_FULLNAME"].Visible = true;
            view1.Columns["TO_FULLNAME"].ColVIndex = 1;
            view1.Columns["TO_FULLNAME"].Width = 250;

            view1.Columns["ACK_ON"].Caption = "Open On";
            view1.Columns["ACK_ON"].Visible = true;
            view1.Columns["ACK_ON"].ColVIndex = 2;
            view1.Columns["ACK_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            view1.Columns["ACK_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view1.Columns["ACK_ON"].Width = 120;
        }
        private DataSet getGBLMessageByMsgID()
        {
            ProcessGetGBLMessage _prc = new ProcessGetGBLMessage();
            _prc.Columns.MSG_ID = msgId; ;
            _prc.InvokeByMsgID();
            return _prc.Result;
        }
    }
}
