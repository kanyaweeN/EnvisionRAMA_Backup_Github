using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.Common;
using Envision.Common.Linq;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;

namespace Envision.NET.Forms.Dialog
{
    public partial class frmRejectPacsImage : Form
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private DataRow drData;
        DataTable dtRejectlog;
        private List<int> toList;
        private MyMessageBox msg;

        public frmRejectPacsImage()
        {
            InitializeComponent();
        }
        public frmRejectPacsImage(DataRow data)
        {
            InitializeComponent();

            drData = data;
        }
        private void frmRejectPacsImage_Load(object sender, EventArgs e)
        {
            msg = new MyMessageBox();
            clearData();
            if (drData != null)
            {
                initFirst();
                loadData();
            }
        }

        private void initFirst()
        {
            #region txtReason
            LookUpSelect lvS = new LookUpSelect();
            DataTable dttReasonReject = lvS.SelectReasonReject(env.CurrentLanguageID).Tables[0];

            txtReason.Properties.DataSource = dttReasonReject;
            txtReason.Properties.ValueMember = "GEN_DTL_ID";
            txtReason.Properties.DisplayMember = "GEN_TEXT";
            txtReasonView.OptionsView.ShowAutoFilterRow = true;
            txtReasonView.Columns["GEN_TITLE"].Caption = "Reason Code";
            txtReasonView.Columns["GEN_TEXT"].Caption = "Reason Desc";
            txtReasonView.Columns["GEN_DTL_ID"].Visible = false;
            txtReasonView.BestFitColumns();
            #endregion
        }
        private void clearData()
        {
            txtPhoneOfModality.Text = "";
            txtReason.Text = "";
            txtComment.Text = "";
            txtPhoneBack.Text = "";
        }
        private void loadData()
        {
            if (!string.IsNullOrEmpty(drData["ACCESSION_NO"].ToString()))
            {
                ProcessGetRISRejectcapturelog ProcessGet = new ProcessGetRISRejectcapturelog();
                ProcessGet.RIS_REJECTCAPTURELOG.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                dtRejectlog = ProcessGet.SelectByAccessionNo();

                if (dtRejectlog.Rows.Count <= 0) return;
                else
                {
                    txtReason.EditValue = dtRejectlog.Rows[0]["REASON_ID"] == null ? 0 : Convert.ToInt32(dtRejectlog.Rows[0]["REASON_ID"]);
                    txtComment.Text = string.IsNullOrEmpty(dtRejectlog.Rows[0]["COMMENTS"].ToString()) ? "" : dtRejectlog.Rows[0]["COMMENTS"].ToString();
                    txtPhoneBack.Text = string.IsNullOrEmpty(dtRejectlog.Rows[0]["PHONE_CALL_BACK"].ToString()) ? "" : dtRejectlog.Rows[0]["PHONE_CALL_BACK"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(drData["MODALITY_ID"].ToString()))
            {
                ProcessGetHRRoom pg = new ProcessGetHRRoom();
                DataTable dtRoom = pg.selectByModality(Convert.ToInt32(drData["MODALITY_ID"].ToString()));

                if (dtRoom.Rows.Count <= 0) return;
                else
                {
                    txtPhoneOfModality.Text = string.IsNullOrEmpty(dtRoom.Rows[0]["ROOM_TELEPHONE"].ToString()) ? "" : dtRoom.Rows[0]["ROOM_TELEPHONE"].ToString();
                }
            }

        }

        private void addGBLMessage()
        {
            ProcessAddGBLMessage _prc = new ProcessAddGBLMessage();
            _prc.Columns.MSG_FROM = env.UserID;
            _prc.Columns.MSG_SUBJECT = "Reject Pacs Image";
            _prc.Columns.MSG_BODY =
                "Phone of modality : " + txtPhoneOfModality.Text + "\r\n" +
                "Reason : " + txtReason.Text + "\r\n" +
                "Comnents : " + txtComment.Text.Trim() + "\r\n" +
                "Phone back : " + txtPhoneBack.Text.Trim();
            _prc.Columns.MSG_STATUS = 'S';
            _prc.Columns.MSG_PRIORITY = 'M';
            _prc.Columns.IS_FORCED = 'N';
            _prc.Columns.CREATED_BY = env.UserID;
            _prc.Invoke();
            checkToList();
            addGBLMessageRecipientSend(_prc.MsgID);
        }
        private void addGBLMessageRecipientSend(int MsgID)
        {
            ProcessAddGBLMessageRecipient _prc = new ProcessAddGBLMessageRecipient();
            _prc.Columns.MSG_ID = MsgID;
            _prc.Columns.CREATED_BY = env.UserID;
            
            #region insertTO
            if (toList != null)
            {
                if (toList.Count > 0)
                {
                    for (int i = 0; i < toList.Count; i++)
                    {
                        _prc.Columns.CC_TO = toList[i];
                        _prc.Columns.RECIPIENT_TYPE = "T";
                        _prc.InvokeSend();
                    }
                }
            }
            #endregion
        }
        private void addRejectcapturelog()
        {
            if (drData != null)
            {
                ProcessAddRISRejectcapturelog ProcessAdd = new ProcessAddRISRejectcapturelog();
                ProcessAdd.RIS_REJECTCAPTURELOG.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                ProcessAdd.RIS_REJECTCAPTURELOG.REASON_ID = string.IsNullOrEmpty(txtReason.Text) ? 0 : Convert.ToInt32(txtReason.EditValue);
                ProcessAdd.RIS_REJECTCAPTURELOG.COMMENTS = txtComment.Text.Trim();
                ProcessAdd.RIS_REJECTCAPTURELOG.PHONE_CALL_BACK = txtPhoneBack.Text.Trim();
                ProcessAdd.RIS_REJECTCAPTURELOG.SL_NO = dtRejectlog.Rows.Count + 1;
                ProcessAdd.RIS_REJECTCAPTURELOG.CREATED_BY = env.UserID;
                ProcessAdd.Invoke();
            }
        }
        private void checkToList()
        {
            ProcessGetRISTechworks ProcessGet = new ProcessGetRISTechworks();
            ProcessGet.RIS_TECHWORK.ACCESSION_ON = drData["ACCESSION_NO"].ToString();
            ProcessGet.RIS_TECHWORK.TAKE = 0;
            ProcessGet.SelectByAccessionNo();
            DataSet dsToList = ProcessGet.Result;

            if (dsToList.Tables.Count <= 0) return;
            if (dsToList.Tables[0].Rows.Count <= 0) return;

            DataTable dtToList = dsToList.Tables[0];
            toList = new List<int>();
            for (int i = 0; i < dtToList.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dtToList.Rows[i]["TECHNOLOGIST_ID"].ToString()))
                    toList.Add(Convert.ToInt32(dtToList.Rows[i]["TECHNOLOGIST_ID"].ToString()));
            }
        }
        private bool checkParameter()
        {
            bool flge = true;

            if (string.IsNullOrEmpty(txtReason.Text))
            {
                flge = false;
                msg.ShowAlert("UID1049", env.CurrentLanguageID);
            }

            return flge;
        }
        private void txtReason_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                txtReason.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkParameter())
            {
                addRejectcapturelog();
                addGBLMessage();

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnSaveAndBack_Click(object sender, EventArgs e)
        {
            if (checkParameter())
            {
                addRejectcapturelog();
                addGBLMessage();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
