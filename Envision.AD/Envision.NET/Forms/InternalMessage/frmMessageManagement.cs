using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Envision.NET.Forms.Dialog;
namespace Envision.NET.Forms.InternalMessage
{
    public partial class frmMessageManagement : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private GBLEnvVariable env;
        private MyMessageBox msg = new MyMessageBox();
        private string indexPage;

        private DataView _dv_message_list;
        private DataView dvMessageList
        {
            get
            {
                return _dv_message_list;
            }
            set
            {
                DataView _dv = value;

                if (_dv_message_list == null)
                {
                    DataColumn _dc = new DataColumn();
                    _dc.ColumnName = "IS_SELECTED";
                    _dc.DataType = typeof(bool);
                    _dc.DefaultValue = false;

                    _dv_message_list = _dv;

                    _dv_message_list.Table.Columns.Add(_dc);
                }
                else
                {
                    _dv_message_list = _dv;
                }

                viewMessage.DataSource = _dv_message_list;
            }
        }

        public frmMessageManagement()
        {
            InitializeComponent();
            env = new GBLEnvVariable();
            selectedPageChanged();
        }

        private void barControl_SelectedPageChanged(object sender, EventArgs e)
        {
            selectedPageChanged();
        }
        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showFromMessageDraft();
        }
        private void btnMarkRead_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (indexPage.ToUpper() == "INDEX")
            {
                foreach (DataRowView _item in _dv_message_list)
                {
                    if (_item["colCHECK"].ToString() == "Y") {
                        ProcessUpdateGBLMessageRecipient proc = new ProcessUpdateGBLMessageRecipient();
                        proc.Columns.MSG_ID = Convert.ToInt32(_item["MSG_ID"].ToString());
                        proc.Columns.SP_TYPE = 0;
                        proc.UpdateTime();
                    }
                }
                selectedPageChanged();
            }
        }
        private void btnTrash_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool flag = false;
            foreach (DataRowView _item in _dv_message_list)
                if (_item["colCHECK"].ToString() == "Y")
                {
                    flag = true;
                    break;
                }
            if (flag)
            {
                if (msg.ShowAlert("UID1306", env.CurrentLanguageID) == "1") return;
                if (indexPage.ToUpper() == "INDEX" || indexPage.ToUpper() == "SEND")
                {
                    foreach (DataRowView _item in _dv_message_list)
                    {
                        if (_item["colCHECK"].ToString() == "Y")
                        {
                            ProcessUpdateGBLMessageRecipient proc = new ProcessUpdateGBLMessageRecipient();
                            proc.Columns.MSG_ID = Convert.ToInt32(_item["MSG_ID"].ToString());
                            proc.Columns.LAST_MODIFIED_BY = env.UserID;
                            proc.Columns.IS_TRASHED = "Y";
                            proc.Columns.SP_TYPE = 1;
                            proc.UpdateTrash();
                        }
                    }
                    selectedPageChanged();
                }
            }
           
        }
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool flag = false;
            foreach (DataRowView _item in _dv_message_list)
                if (_item["colCHECK"].ToString() == "Y")
                {
                    flag = true;
                    break;
                }
            if (flag)
            {


                if (msg.ShowAlert("UID1025", env.CurrentLanguageID) == "1") return;
                if (indexPage.ToUpper() == "DRAFT")
                {
                    foreach (DataRowView _item in _dv_message_list)
                    {
                        if (_item["colCHECK"].ToString() == "Y")
                        {
                            ProcessUpdateGBLMessage proc = new ProcessUpdateGBLMessage();
                            proc.Columns.LAST_MODIFIED_BY = env.UserID;
                            proc.Columns.IS_DELETED = 'Y';
                            proc.Columns.MSG_ID = Convert.ToInt32(_item["MSG_ID"].ToString());
                            proc.InvokeTrash();
                        }
                    }
                    selectedPageChanged();
                }
                else if (indexPage.ToUpper() == "TRASH")
                {
                    foreach (DataRowView _item in _dv_message_list)
                    {
                        if (_item["colCHECK"].ToString() == "Y")
                        {
                            ProcessUpdateGBLMessageRecipient proc = new ProcessUpdateGBLMessageRecipient();
                            proc.Columns.MSG_ID = Convert.ToInt32(_item["MSG_ID"].ToString());
                            proc.Columns.LAST_MODIFIED_BY = env.UserID;
                            proc.Columns.IS_TRASHED = "Y";
                            proc.Columns.SP_TYPE = 2;
                            proc.UpdateTrash();
                        }
                    }
                    selectedPageChanged();
                }
            }
        }
        private void btnFavorite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (indexPage.ToUpper() == "INDEX" || indexPage.ToUpper() == "SEND" || indexPage.ToUpper() == "TRASH")
            {
                foreach (DataRowView _item in _dv_message_list)
                {
                    if (_item["colCHECK"].ToString() == "Y")
                    {
                        ProcessUpdateGBLMessageRecipient proc = new ProcessUpdateGBLMessageRecipient();
                        proc.Columns.MSG_ID = Convert.ToInt32(_item["MSG_ID"].ToString());
                        if (_item["colSTAR"].ToString() == "Y")
                            proc.Columns.IS_STARRED = 'N';
                        else
                            proc.Columns.IS_STARRED = 'Y';
                        proc.Columns.LAST_MODIFIED_BY = env.UserID;
                        proc.UpdateStar();
                    }
                }
                selectedPageChanged();
            }
        }
        private void btnRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool flag = false;
            foreach (DataRowView _item in _dv_message_list)
                if (_item["colCHECK"].ToString() == "Y")
                {
                    flag = true;
                    break;
                }
            if (flag)
            {
                if (msg.ShowAlert("UID1305", env.CurrentLanguageID) == "1") return;
                foreach (DataRowView _item in _dv_message_list)
                {
                    if (_item["colCHECK"].ToString() == "Y")
                    {
                        ProcessUpdateGBLMessageRecipient proc = new ProcessUpdateGBLMessageRecipient();
                        proc.Columns.MSG_ID = Convert.ToInt32(_item["MSG_ID"].ToString());
                        proc.Columns.LAST_MODIFIED_BY = env.UserID;
                        proc.Columns.IS_TRASHED = "N";
                        proc.Columns.SP_TYPE = 1;
                        proc.UpdateTrash();
                    }
                }
                selectedPageChanged();
            }
        }

        #region Refresh DataSource By Condition.
        private void reloadPage(string Page)
        {
            if (indexPage == Page)
            {
                switch (Page)
                {
                    case "SEND":
                        openPageIndex();
                        break;
                    case "DRAFT":
                        openPageDrafts();
                        break;
                }
                viewMessage.DataSource = dvMessageList.Table.DefaultView;
            }
        }
        private void selectedPageChanged()
        {
            switch (barControl.SelectedPage.Name)
            {
                case "pageIndex":
                    indexPage = "INDEX";
                    openPageIndex();
                    this.Text = "Inbox";
                    break;
                case "pageSent":
                    indexPage = "SEND";
                    openPageSent();
                    this.Text = "Sent";
                    break;
                case "pageDrafts":
                    indexPage = "DRAFT";
                    openPageDrafts();
                    this.Text = "Drafts";
                    break;
                case "pageTrash":
                    indexPage = "TRASH";
                    openPageTrash();
                    this.Text = "Trash";
                    break;
            }
            viewMessage.DataSource = dvMessageList.Table.DefaultView;
            setGridMessage();
        }
        private void openPageIndex()
        {
            dvMessageList = getGBLMessageRecipient();
        }
        private void openPageSent()
        {
            dvMessageList = getGBLMessageSend();
        }
        private void openPageDrafts()
        {
            dvMessageList = getGBLMessageDrafts();
        }
        private void openPageTrash()
        {
            dvMessageList = getGBLMessageTrash();
        }
        #endregion

        #region Open Send Message Form.
        private void showFromMessageDraft()
        {
            frmSend frm = new frmSend();
            frm.ShowDialog();
            selectedPageChanged();
            frm.Dispose();
        }
        private void showFromMessageDraft(int MsgID)
        {
            frmSend frm = new frmSend(MsgID);
            if (frm.ShowDialog() == DialogResult.OK)
                selectedPageChanged();
            frm.Dispose();
        }
        #endregion

        #region Get Data GBL_MESSAGE.
        private DataView getGBLMessageDrafts()
        {
            return getGBLMessage('D');
        }
        private DataView getGBLMessageSend()
        {
            return getGBLMessage('S');
        }
        private DataView getGBLMessage(char Status)
        {
            ProcessGetGBLMessage _prc = new ProcessGetGBLMessage();
            _prc.Columns.MSG_FROM = env.UserID;
            _prc.Columns.MSG_STATUS = Status;
            _prc.InvokeByStatus();

            return _prc.Result.Tables[0].DefaultView;
        }
        private DataView getGBLMessageTrash()
        {
            ProcessGetGBLMessage _prc = new ProcessGetGBLMessage();
            _prc.Columns.MSG_FROM = env.UserID;
            _prc.InvokeTrash();

            return _prc.Result.Tables[0].DefaultView;
        }
        #endregion

        #region Get Data GBL_MESSAGERECIPIENT.
        private DataView getGBLMessageRecipient()
        {
            ProcessGetGBLMessageRecipient _prc = new ProcessGetGBLMessageRecipient();
            _prc.Columns.CC_TO = env.UserID;
            _prc.Invoke();

            return _prc.Result.Tables[0].DefaultView;
        }
        #endregion

        private void setGridMessage() {
            viewMessage1.OptionsView.ShowAutoFilterRow = true;
            for (int i = 0; i < viewMessage1.Columns.Count; i++)
            {
                viewMessage1.Columns[i].Visible = false;
                viewMessage1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewMessage1.Columns["colCHECK"].Caption = " ";
            viewMessage1.Columns["colSTAR"].Caption = " ";
            viewMessage1.Columns["colREAD"].Caption = " ";
            viewMessage1.Columns["MSG_ID"].Caption = "";
            viewMessage1.Columns["MSG_PRIORITY"].Caption = " ";
            viewMessage1.Columns["MSG_FROM"].Caption = "From";
            viewMessage1.Columns["MSG_TO"].Caption = "To";
            viewMessage1.Columns["MSG_STATUS"].Caption = "";
            viewMessage1.Columns["PRIORITY_DESC"].Caption = "";
            viewMessage1.Columns["FROM_FULLNAME"].Caption = "From";
            viewMessage1.Columns["FROM_TONAME"].Caption = "To";
            viewMessage1.Columns["MSG_SUBJECT"].Caption = "Subject";
            viewMessage1.Columns["MSG_DT"].Caption = "Date";
            viewMessage1.Columns["IS_STARRED"].Caption = "";
            viewMessage1.Columns["ACK_ON"].Caption = "";

            viewMessage1.Columns["colSTAR"].ColVIndex = 2;
            viewMessage1.Columns["colCHECK"].ColVIndex = 1;
            viewMessage1.Columns["MSG_PRIORITY"].ColVIndex = 3;
            viewMessage1.Columns["colREAD"].ColVIndex = 4;
            viewMessage1.Columns["MSG_ID"].ColVIndex = 5;
            viewMessage1.Columns["MSG_FROM"].ColVIndex = 6;
            viewMessage1.Columns["MSG_TO"].ColVIndex = 7;

            viewMessage1.Columns["MSG_STATUS"].ColVIndex = 8;
            viewMessage1.Columns["PRIORITY_DESC"].ColVIndex = 9;
            viewMessage1.Columns["FROM_FULLNAME"].ColVIndex = 10;
            viewMessage1.Columns["FROM_TONAME"].ColVIndex = 11;
            viewMessage1.Columns["MSG_SUBJECT"].ColVIndex = 12;
            viewMessage1.Columns["MSG_DT"].ColVIndex = 13;
            viewMessage1.Columns["IS_STARRED"].ColVIndex = 14;
            viewMessage1.Columns["ACK_ON"].ColVIndex = 15;

            viewMessage1.Columns["colCHECK"].Visible = true;
            viewMessage1.Columns["MSG_ID"].Visible = false;
            viewMessage1.Columns["MSG_PRIORITY"].Visible = true;
            viewMessage1.Columns["MSG_FROM"].Visible = false;
            viewMessage1.Columns["MSG_TO"].Visible = false;
            viewMessage1.Columns["MSG_STATUS"].Visible = false;
            viewMessage1.Columns["PRIORITY_DESC"].Visible = false;
            viewMessage1.Columns["FROM_FULLNAME"].Visible = true;
            viewMessage1.Columns["FROM_TONAME"].Visible = true;
            viewMessage1.Columns["MSG_SUBJECT"].Visible = true;
            viewMessage1.Columns["MSG_DT"].Visible = true;
            viewMessage1.Columns["IS_STARRED"].Visible = false;
            viewMessage1.Columns["ACK_ON"].Visible = false;

            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            viewMessage1.Columns["colCHECK"].ColumnEdit = chk;
            viewMessage1.Columns["colCHECK"].BestFit();
            viewMessage1.Columns["colCHECK"].OptionsColumn.AllowEdit = true;

            RepositoryItemImageComboBox rImcbBPView = new RepositoryItemImageComboBox();
            rImcbBPView.SmallImages = this.imgWL;
            rImcbBPView.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "L", 0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "M", 1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "H", 2)});
            rImcbBPView.Buttons.Clear();
            RepositoryItemLookUpEdit repositoryItemLookUpEdit3 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit3.ImmediatePopup = true;
            repositoryItemLookUpEdit3.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit3.AutoHeight = false;
            repositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PRIORITY", "Priority", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit3.DisplayMember = "Name";
            repositoryItemLookUpEdit3.ValueMember = "Code";
            repositoryItemLookUpEdit3.DropDownRows = 5;
            repositoryItemLookUpEdit3.NullText = string.Empty;
            repositoryItemLookUpEdit3.DataSource = getPriority();
            viewMessage1.Columns["MSG_PRIORITY"].ColumnEdit = rImcbBPView;
            viewMessage1.Columns["MSG_PRIORITY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            //viewMessage1.Columns["MSG_PRIORITY"].OptionsColumn.ReadOnly = true;
            viewMessage1.Columns["MSG_PRIORITY"].Width = 10;


            RepositoryItemImageComboBox rImcbStar = new RepositoryItemImageComboBox();
            rImcbStar.SmallImages = this.imgWL;
            rImcbStar.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 5),});
            rImcbStar.Buttons.Clear();
            viewMessage1.Columns["colSTAR"].ColumnEdit = rImcbStar;
            viewMessage1.Columns["colSTAR"].Width = 10;
            //viewMessage1.Columns["colSTAR"].OptionsColumn.ReadOnly = true;
            viewMessage1.Columns["colSTAR"].Visible = true;

            RepositoryItemImageComboBox rImcbRead = new RepositoryItemImageComboBox();
            rImcbRead.SmallImages = this.imgWL;
            rImcbRead.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3),
            });
            rImcbRead.Buttons.Clear();
            viewMessage1.Columns["colREAD"].ColumnEdit = rImcbRead;
            viewMessage1.Columns["colREAD"].Width = 10;
            viewMessage1.Columns["colREAD"].Visible = true;
            //viewMessage1.Columns["colREAD"].OptionsColumn.ReadOnly = true;

            viewMessage1.Columns["FROM_FULLNAME"].Width = 150;
            //viewMessage1.Columns["FROM_FULLNAME"].OptionsColumn.ReadOnly = true;

            viewMessage1.Columns["FROM_TONAME"].Width = 150;
            //viewMessage1.Columns["FROM_TONAME"].OptionsColumn.ReadOnly = true;

            viewMessage1.Columns["MSG_SUBJECT"].Width = 190;
            //viewMessage1.Columns["MSG_SUBJECT"].OptionsColumn.ReadOnly = true;

            viewMessage1.Columns["MSG_DT"].Width = 110;
            //viewMessage1.Columns["MSG_DT"].OptionsColumn.ReadOnly = true;

            viewMessage1.Columns["colREAD"].Visible = true;
            //viewMessage1.Columns["colREAD"].OptionsColumn.ReadOnly = true;

            viewMessage1.Columns["MSG_DT"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            viewMessage1.Columns["MSG_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //viewMessage1.Columns["MSG_DT"].OptionsColumn.ReadOnly = true;

            if (indexPage == "INDEX" || indexPage == "TRASH")
            {
                viewMessage1.Columns["FROM_FULLNAME"].Visible = true;
                viewMessage1.Columns["FROM_TONAME"].Visible = false;
            }
            else if (indexPage == "SEND" || indexPage == "DRAFT") {
                viewMessage1.Columns["FROM_FULLNAME"].Visible = false;
                viewMessage1.Columns["colREAD"].Visible = false;

                viewMessage1.Columns["FROM_TONAME"].Visible = true;
            }
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (viewMessage1.FocusedRowHandle > -1) {
                DataRow dr = viewMessage1.GetDataRow(viewMessage1.FocusedRowHandle);
                if(dr["colCHECK"].ToString()=="N")
                    dr["colCHECK"] = "Y";
                else
                    dr["colCHECK"] = "N";
            }
        }

        private DataTable getPriority()
        {
            DataTable _dt;
            _dt = new DataTable();
            _dt.Columns.Add("Code");
            _dt.Columns.Add("Name");
            _dt.AcceptChanges();
            _dt.Rows.Add(new object[] { "L", "Low" });
            _dt.Rows.Add(new object[] { "M", "Medium" });
            _dt.Rows.Add(new object[] { "H", "High" });
            return _dt;
        }
        private void viewMessage_DoubleClick(object sender, EventArgs e)
        {
            if (viewMessage1.FocusedRowHandle > -1)
            {
                if (indexPage.ToUpper() == "DRAFT")
                {
                    int mid = Convert.ToInt32(viewMessage1.GetDataRow(viewMessage1.FocusedRowHandle)["MSG_ID"]);
                    showFromMessageDraft(mid);
                }
                if (indexPage.ToUpper() == "INDEX")
                {
                    int mid = Convert.ToInt32(viewMessage1.GetDataRow(viewMessage1.FocusedRowHandle)["MSG_ID"]);
                    frmOpen frm = new frmOpen(mid);
                    frm.ShowDialog();
                    frm.Dispose();
                    selectedPageChanged();
                }
                if (indexPage.ToUpper() == "SEND")
                {
                    int mid = Convert.ToInt32(viewMessage1.GetDataRow(viewMessage1.FocusedRowHandle)["MSG_ID"]);
                    string name = viewMessage1.GetDataRow(viewMessage1.FocusedRowHandle)["FROM_TONAME"].ToString().Trim();
                    frmSentDetail frm = new frmSentDetail(mid, name);
                    frm.ShowDialog();
                    frm.Dispose();
                }
            }
        }

        private void btnSelectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnSelectAll.Caption == "Select All")
            {
                btnSelectAll.Caption = "Unselect All";
                if (viewMessage1.FocusedRowHandle > -1)
                {
                    foreach (DataRowView _item in _dv_message_list)
                        _item["colCHECK"] = "Y";
                }
            }
            else
            {
                btnSelectAll.Caption = "Select All";
                if (viewMessage1.FocusedRowHandle > -1)
                {
                    foreach (DataRowView _item in _dv_message_list)
                        _item["colCHECK"] = "N";
                }
            }
        }

        private void btnShowFavorite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnShowFavorite.Caption == "Show Star")
            {
                btnShowFavorite.Caption = "Show All";
                _dv_message_list.RowFilter = "colSTAR ='Y' OR IS_STARRED = 'Y'";
            }
            else
            {
                btnShowFavorite.Caption = "Show Star";
                _dv_message_list.RowFilter = "";
            }
        }

      
    }
}
