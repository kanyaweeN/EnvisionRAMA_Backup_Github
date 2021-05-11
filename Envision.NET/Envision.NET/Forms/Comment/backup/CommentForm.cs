using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.XtraBars;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.NET.Forms.Dialog;
using Envision.Common;

namespace Envision.NET.Comment
{
    public partial class CommentForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       public enum FormStates
        {
            Open, OpenAndAutoFill, Fill, Refresh
        }
        public enum ButtonFormState
        {
            AddNewComment, 
            MarkAsRead,
            Reply,
            MarkAsUnread, 
            Trash, 
            Restore, 
            DeleteTrash, 
            Send,
            DeleteDraft,
            None
        }
        public enum QueryFromMode
        {
            Order, Schedule, None
        }
        CommentManagement commentManager;
        private string _hn;
        private string _last_hn;
        private int _reg_id;
        private int _emp_id;
        private int order_id;
        private int schedule_id;
        private int exam_id;
        private string current_age;
        private QueryFromMode queryFromMode = QueryFromMode.None;
        private bool HasPatient { get; set; }
        private DataSet dsCommentThread;
        private DataSet dsCommentInTrash;
        private DataSet dsCommentSaveDraft;
        private CommentDialog commentDialog;
        private FormStates _formState;
        private FormStates FormState
        {
            set 
            {
                this._formState = value;
                if (this._formState == FormStates.Open)
                {
                    this._hn = string.Empty;
                    this.tbDraftCommentTo.Text = string.Empty;
                    this.tbDraftExam.Text = string.Empty;
                    this.tbDraftExamDate.Text = string.Empty;
                    this.tbExam.Text = string.Empty;
                    this.tbExamDate.Text = string.Empty;
                    this.tbCommentTo.Text = string.Empty;
                    this.tbTrashCommentTo.Text = string.Empty;
                    this.tbTrashExam.Text = string.Empty;
                    this.tbTrashExamDate.Text = string.Empty;
                    this.gridControl1.DataSource = null;
                    this.gridControl2.DataSource = null;
                    this.gridControl3.DataSource = null;
                    this.tbAge.Text = string.Empty;
                    this.tbDOB.Text = string.Empty;
                    this.tbGender.Text = string.Empty;
                    this.tbName.Text = string.Empty;
                }
                else if (this._formState == FormStates.Fill)
                {
                    this.btnAddNewComment.Enabled = true;
                }
            }
        }
        MyMessageBox msg = new MyMessageBox();

        public CommentForm()
            : this(string.Empty) { }
        public CommentForm(string HN)
        {
            this._hn = HN;
            
            //HN Test = 1779041
            InitializeComponent();
            InitialState();
            InitialEvents();
            InitialObjects();
            if (this._hn != string.Empty)
            {
                this.tbHN.Text = HN;
                this.tbHN.Properties.ReadOnly = true;
                this.tbHN_KeyDown(this, new KeyEventArgs(Keys.Enter));
            }
        }
        /// <summary>
        /// This method use to query automatically with Hn base on Order ID or Scheudel Id and exam
        /// </summary>
        /// <param name="HN">Hn</param>
        /// <param name="Id">Order Id or Schedule Id</param>
        /// <param name="Exam_Id">Exam Id</param>
        /// <param name="Mode">Query mode (order , schedule)</param>
        public CommentForm(string HN, int Id, int Exam_Id, QueryFromMode Mode)
        {
            this._hn = HN;
            this.exam_id = Exam_Id;
            this.queryFromMode = Mode;
            //HN Test = 1779041
            InitializeComponent();
            InitialState();
            InitialEvents();
            InitialObjects();
            if (Mode == QueryFromMode.Order)
                this.order_id = Id;
            else
                this.schedule_id = Id;
            if (this._hn != string.Empty)
            {
                this.tbHN.Text = HN;
                this.tbHN.Properties.ReadOnly = true;
                this.tbHN_KeyDown(this, new KeyEventArgs(Keys.Enter));
            }
        }

        #region Initialize
        private void InitialEvents()
        {
            this.tbHN.KeyDown += new KeyEventHandler(tbHN_KeyDown);
            this.advBandedGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(advBandedGridView1_FocusedRowChanged);
            this.advBandedGridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(advBandedGridView1_RowStyle);
            this.advBandedGridView1.DoubleClick += new EventHandler(advBandedGridView1_DoubleClick);
            this.advBandedGridView2.DoubleClick += new EventHandler(advBandedGridView2_DoubleClick);
            this.advBandedGridView3.DoubleClick += new EventHandler(advBandedGridView3_DoubleClick);
            this.contextMenuStrip1.Opening += new CancelEventHandler(contextMenuStrip1_Opening);
            this.btnAddNewComment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnAddNewComment_ItemClick);
            this.btnMarkAsRead.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnMarkAsRead_ItemClick);
            this.btnTrash.ItemClick +=new DevExpress.XtraBars.ItemClickEventHandler(btnTrash_ItemClick);
            this.btnDraftSend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnDraftSend_ItemClick);
            this.btnTrashDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnTrashDelete_ItemClick);
            this.btnDraftDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnDraftDelete_ItemClick);
            this.btnTrashRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnTrashRestore_ItemClick);
            this.btnReply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnReply_ItemClick);
            this.btnUnmark.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnUnmark_ItemClick);
            this.tbHN.LostFocus += new EventHandler(tbHN_LostFocus);
            this.tbHN.TextChanged += new EventHandler(tbHN_TextChanged);
            this.ribbon.SelectedPageChanged += new EventHandler(ribbon_SelectedPageChanged);
            this.repositoryItemCheckEdit1.CheckStateChanged += new EventHandler(repositoryItemCheckEdit1_CheckStateChanged);
            this.repositoryItemCheckEdit2.CheckStateChanged += new EventHandler(repositoryItemCheckEdit2_CheckStateChanged);
            this.repositoryItemCheckEdit3.CheckStateChanged += new EventHandler(repositoryItemCheckEdit3_CheckStateChanged);
        }

        #region Unmark As Read
        private void btnUnmark_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.CheckValidEvent(ButtonFormState.MarkAsUnread))
            {
                DataRow[] drUnmarkRows = this.dsCommentThread.Tables[0].Select("[IS_SELECTED] = 'Y'");
                foreach (DataRow drUnmarkRow in drUnmarkRows)
                {
                    drUnmarkRow["IS_SELECTED"] = null;
                    this.commentManager.SetUnmarkAsReadComment(Convert.ToInt32(drUnmarkRow["COMMENT_ID"]), this._emp_id);

                }
            }
        }
        #endregion

        #region Reply Comment
        private void btnReply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.CheckValidEvent(ButtonFormState.Reply))
            {
                DataRow[] drReplyRows = this.dsCommentThread.Tables[0].Select("[IS_SELECTED] = 'Y'");
                if (drReplyRows.Length == 1)
                {
                    this.commentDialog.EMP_ID = this._emp_id;
                    this.commentDialog.SetCommentDialog(this._hn, this._reg_id, drReplyRows[0], CommentDialog.ShowDialogMode.Reply);
                    this.commentDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถเลิกได้มากกว่า 1 เพื่อที่จะตอบกลับ", "Error reply comment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion

        #region Ribbon Selected Page Changed
        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            //if (this.ribbon.SelectedPage.PageIndex == 1)
            //{
            //    this.tabCommentSystem.SelectedTabPageIndex = 
            //}
            this.tabCommentSystem.SelectedTabPageIndex = this.ribbon.SelectedPage.PageIndex;
            if (this.ribbon.SelectedPage.PageIndex == 0)
            {
                this.tbAge2.Visible = false;
                this.tbAge3.Visible = false;
                this.tbAge.Visible = true;
            }
            else if (this.ribbon.SelectedPage.PageIndex == 1)
            {
                this.tbAge.Visible = false;
                this.tbAge3.Visible = false;
                this.tbAge2.Visible = true;
            }
            else if (this.ribbon.SelectedPage.PageIndex == 2)
            {
                this.tbAge.Visible = false;
                this.tbAge2.Visible = false;
                this.tbAge3.Visible = true;
            }
        }
        #endregion

        private void advBandedGridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = this.advBandedGridView1.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    ////Priority style
                    //if (dr["COMMENT_PRIORITY"].Equals("High"))
                    //    e.Appearance.BackColor = Color.Pink;
                    //else if (dr["COMMENT_PRIORITY"].Equals("Medium"))
                    //    e.Appearance.BackColor = Color.LightYellow;
                    //else if (dr["COMMENT_PRIORITY"].Equals("Low"))
                    //    e.Appearance.BackColor = Color.LightGreen;
                    //unread comment style
                    if (dr["IS_UNREAD"].Equals("N") || dr["MARK_AS_READ"].Equals("Y"))
                        e.Appearance.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                }
            }
        }

        private void InitialObjects()
        {
            this._emp_id = new GBLEnvVariable().UserID;//7460; //7178 ; 
            this.commentManager = CommentManagement.GetCommentManager();
            this.commentManager.OnUpdateCommentCompleted += new CommentManagement.onUpdateCommentCompleted(commentManager_OnUpdateCommentCompleted);
            this.commentDialog = CommentDialog.GetCommentDialog();
            this.commentDialog.OnDialogClosed += new CommentDialog.onDialogClosed(commentDialog_OnDialogClosed);
            this.commentDialog.EMP_ID = this._emp_id;
            this.tbAge2.Visible = false;
            this.tbAge3.Visible = false;
            this.tbAge.Visible = true;
        }

        #region Comment Manager Event
        private void commentManager_OnUpdateCommentCompleted(object Sender, bool isCompleted)
        {
            if (isCompleted)
            {
                this.RefreshDraftGrid();
                this.RefreshThreadGrid();
                this.RefreshTrashGrid();
                //this.commentDialog.Close();
                //MessageBox.Show("comment นี้ได้ถูกอัพเดตแล้ว", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                msg.ShowAlert("UID6014", new GBLEnvVariable().CurrentLanguageID);
                //MessageBox.Show("ขออภัย ระบบไม่สามารถลบ comment นี้ได้\r\nเนื่องจาก comment นี้ไม่ได้ส่งถึงคุณ หรือ comment นี้ได้มีการตอบกลับแล้ว", "Romove error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Comment Dialog Event
        private void commentDialog_OnDialogClosed(object Sender, CommentDialog.CloseDialogEventArgs args)
        {
            if (args.IsUpdate)
            {
                if (args.CloseWith == CommentDialog.CloseWith.Reply || args.CloseWith == CommentDialog.CloseWith.New)
                {
                    this.RefreshThreadGrid();
                    this.RefreshDraftGrid();
                    //msg.ShowAlert("UID6012", new GBLEnvVariable().CurrentLanguageID);
                    //MessageBox.Show("comment นี้ได้ถูกอัพเดตแล้ว", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (args.CloseWith == CommentDialog.CloseWith.Draft)
                {
                    this.RefreshThreadGrid();
                    this.RefreshDraftGrid();
                }
                this.commentDialog.Close();
            }
        }
        #endregion

        public void InitialState()
        {
            this.tbHN.Focus();
            if (this._hn == string.Empty)
                this.FormState = FormStates.Open;
            else
                this.FormState = FormStates.OpenAndAutoFill;
        }

        private void InitialPatientDemographic(string HN)
        {
            this._hn = HN;
            DataSet ds = this.commentManager.GetPatientDemographic(this._hn);
            try
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        this.tbDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToShortDateString();
                        this.tbGender.Text = ds.Tables[0].Rows[0]["GENDER"].ToString();
                        //this.tbAge.Text = ds.Tables[0].Rows[0]["AGE"].ToString();
                        this.current_age = ds.Tables[0].Rows[0]["AGE"].ToString();
                        this.tbName.Text = ds.Tables[0].Rows[0]["PATIENT_NAME"].ToString();
                        this._reg_id = Convert.ToInt32(ds.Tables[0].Rows[0]["REG_ID"]);
                        this.HasPatient = true;
                        this._last_hn = this._hn;
                    }
                    else
                        this.HasPatient = false;
                }
                else
                    this.HasPatient = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            //Initai Comment Thread
            if (this.HasPatient)
            {
                this.FormState = FormStates.Fill;
                this.InitialGridView();
                this.InitialCommentThread();
                this.InitialCommentInTrash();
                this.InitialCommentInDraft();
            }
        }

        private void InitialGridView()
        {
            #region Column Edit
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox1.AutoHeight = false;
            repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", 8),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Medium", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", 6)});
            repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            repositoryItemImageComboBox1.SmallImages = imgWL;
            repositoryItemImageComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            #endregion

            this.advBandedGridView1.Columns["COMMENT_PRIORITY"].ColumnEdit = repositoryItemImageComboBox1;
            this.advBandedGridView2.Columns["COMMENT_PRIORITY"].ColumnEdit = repositoryItemImageComboBox1;
            this.advBandedGridView3.Columns["COMMENT_PRIORITY"].ColumnEdit = repositoryItemImageComboBox1;

            #region Set Grid Column Readonly
            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cols in this.advBandedGridView1.Columns)
            {
                if(cols.FieldName != "IS_SELECTED")
                    cols.OptionsColumn.AllowEdit = false;
            }
            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cols in this.advBandedGridView2.Columns)
            {
                if (cols.FieldName != "IS_SELECTED")
                    cols.OptionsColumn.AllowEdit = false;
            }
            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cols in this.advBandedGridView3.Columns)
            {
                if (cols.FieldName != "IS_SELECTED")
                    cols.OptionsColumn.AllowEdit = false;
            }
            #endregion
        }
        /// <summary>
        /// This method use to initial Comment Thread
        /// </summary>
        private void InitialCommentThread()
        {
            this.dsCommentThread = this.commentManager.GetCommentInBox(this._hn, this._emp_id);
            //Comment Thread
            if (this.dsCommentThread.Tables.Count > 0)
            {
                if (this.dsCommentThread.Tables[0].Rows.Count > 0)
                {
                    //Set DataBinding
                    this.dsCommentThread.Tables[0].Columns.Add("IS_SELECTED", typeof(string), "");
                    this.dsCommentThread.Tables[0].Columns.Add("MARK_AS_READ", typeof(string), "");
                    this.dsCommentThread.Tables[0].AcceptChanges();
                    this.gridControl1.DataSource = this.dsCommentThread.Tables[0];
                    this.gridControl1.Refresh();

                    this.tbExam.DataBindings.Clear();
                    this.tbCommentTo.DataBindings.Clear();
                    this.tbExamDate.DataBindings.Clear();
                    this.tbAge.DataBindings.Clear();
                    this.tbExam.DataBindings.Add("TEXT", this.dsCommentThread.Tables[0], "EXAM");
                    this.tbCommentTo.DataBindings.Add("TEXT", this.dsCommentThread.Tables[0], "COMMENT_TO");
                    this.tbExamDate.DataBindings.Add("TEXT", this.dsCommentThread.Tables[0], "EXAM_DT");
                    this.tbAge.DataBindings.Add("TEXT", this.dsCommentThread.Tables[0], "AGE");
                }
                else
                {
                    this.gridControl1.DataSource = this.dsCommentThread.Tables[0];
                    this.tbCommentTo.Text = string.Empty;
                    this.tbExam.Text = string.Empty;
                    this.tbExamDate.Text = string.Empty;
                    this.tbAge.Text = this.current_age;
                }
            }
        }
        /// <summary>
        /// This method use to initial comment in trash
        /// </summary>
        private void InitialCommentInTrash()
        {
            this.dsCommentInTrash = this.commentManager.GetCommentInTrash(this._hn, this._emp_id);
            //Comment Trash
            if (this.dsCommentInTrash.Tables.Count > 0)
            {
                if (this.dsCommentInTrash.Tables[0].Rows.Count > 0)
                {
                    //Set DataBinding
                    this.dsCommentInTrash.Tables[0].Columns.Add("IS_SELECTED", typeof(string), "");
                    this.dsCommentInTrash.Tables[0].Columns["IS_SELECTED"].DefaultValue = "N";
                    this.dsCommentInTrash.Tables[0].AcceptChanges();
                    this.gridControl3.DataSource = this.dsCommentInTrash.Tables[0];

                    this.tbTrashCommentTo.DataBindings.Clear();
                    this.tbTrashExam.DataBindings.Clear();
                    this.tbTrashExamDate.DataBindings.Clear();
                    this.tbAge3.DataBindings.Clear();
                    this.tbTrashExam.DataBindings.Add("TEXT", this.dsCommentInTrash.Tables[0], "EXAM");
                    this.tbTrashCommentTo.DataBindings.Add("TEXT", this.dsCommentInTrash.Tables[0], "COMMENT_TO");
                    this.tbTrashExamDate.DataBindings.Add("TEXT", this.dsCommentInTrash.Tables[0], "EXAM_DT");
                    this.tbAge3.DataBindings.Add("TEXT", this.dsCommentInTrash.Tables[0], "AGE");
                }
                else
                {
                    this.gridControl3.DataSource = this.dsCommentInTrash.Tables[0];
                    this.tbTrashCommentTo.Text = string.Empty;
                    this.tbTrashExam.Text = string.Empty;
                    this.tbTrashExamDate.Text = string.Empty;
                    this.tbAge3.Text = this.current_age;
                }
            }
        }
        /// <summary>
        /// This method use to initial comment in draft
        /// </summary>
        private void InitialCommentInDraft()
        {
            this.dsCommentSaveDraft = this.commentManager.GetCommentSaveDraft(this._hn, this._emp_id);
            //Comment Draft
            if (this.dsCommentSaveDraft.Tables.Count > 0)
            {
                if (this.dsCommentSaveDraft.Tables[0].Rows.Count > 0)
                {
                    //Set DataBinding
                    this.dsCommentSaveDraft.Tables[0].Columns.Add("IS_SELECTED", typeof(string), "");
                    this.dsCommentSaveDraft.Tables[0].Columns["IS_SELECTED"].DefaultValue = "N";
                    this.dsCommentSaveDraft.Tables[0].AcceptChanges();
                    this.gridControl2.DataSource = this.dsCommentSaveDraft.Tables[0];

                    this.tbDraftCommentTo.DataBindings.Clear();
                    this.tbDraftExam.DataBindings.Clear();
                    this.tbDraftExamDate.DataBindings.Clear();
                    this.tbAge2.DataBindings.Clear();
                    this.tbDraftExam.DataBindings.Add("TEXT", this.dsCommentSaveDraft.Tables[0], "EXAM");
                    this.tbDraftCommentTo.DataBindings.Add("TEXT", this.dsCommentSaveDraft.Tables[0], "COMMENT_TO");
                    this.tbDraftExamDate.DataBindings.Add("TEXT", this.dsCommentSaveDraft.Tables[0], "EXAM_DT");
                    this.tbAge2.DataBindings.Add("TEXT", this.dsCommentSaveDraft.Tables[0], "AGE");
                }
                else
                {
                    this.gridControl2.DataSource = this.dsCommentSaveDraft.Tables[0];
                    this.tbDraftCommentTo.Text = string.Empty;
                    this.tbDraftExam.Text = string.Empty;
                    this.tbDraftExamDate.Text = string.Empty;
                    this.tbAge2.Text = this.current_age;
                }
            }
        }

        #endregion

        #region Key Event
        private void tbHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Initial patient demographic
                this.InitialPatientDemographic(tbHN.Text);
                if (!this.HasPatient)
                {
                    msg.ShowAlert("UID6011", new GBLEnvVariable().CurrentLanguageID);
                    //MessageBox.Show("ไม่พบคนไข้ HN นี้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //this.tbHN.Text = this._last_hn;
                    this.FormState = FormStates.Open;
                    this.tbHN.Text = string.Empty;
                    this.tbHN.Focus();
                }
            }
        }
        #endregion

        #region Grid Event
        private void advBandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
            {
               
            }
        }

        private void advBandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.advBandedGridView1.FocusedRowHandle > -1)
            {
                if (this.commentDialog.IsDisposed)
                {
                    this.commentDialog = CommentDialog.GetCommentDialog(true);
                    this.commentDialog.EMP_ID = this._emp_id;
                }
                this.commentDialog.SetCommentDialog(this._hn, this._reg_id, this.advBandedGridView1.GetDataRow(this.advBandedGridView1.FocusedRowHandle)
                    , CommentDialog.ShowDialogMode.Open);
                this.commentDialog.ShowDialog();
                
                DataRow drThreadRow = this.advBandedGridView1.GetDataRow(this.advBandedGridView1.FocusedRowHandle);
                if (drThreadRow["IS_UNREAD"].Equals("N"))
                {
                    //Set read comment
                    this.commentManager.SetToReadComment(Convert.ToInt32(drThreadRow["COMMENT_ID"]), this._emp_id);
                }
            }
        }

        private void advBandedGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (this.advBandedGridView2.FocusedRowHandle > -1)
            {
                if (this.commentDialog.IsDisposed)
                {
                    this.commentDialog = CommentDialog.GetCommentDialog(true);
                    this.commentDialog.EMP_ID = this._emp_id;
                }
                this.commentDialog.SetCommentDialog(this._hn, this._reg_id, this.advBandedGridView2.GetDataRow(this.advBandedGridView2.FocusedRowHandle)
                    , CommentDialog.ShowDialogMode.ReadOnly);
                this.commentDialog.ShowDialog();
            }
        }

        private void advBandedGridView3_DoubleClick(object sender, EventArgs e)
        {
            if (this.advBandedGridView3.FocusedRowHandle > -1)
            {
                if (this.commentDialog.IsDisposed)
                {
                    this.commentDialog = CommentDialog.GetCommentDialog(true);
                    this.commentDialog.EMP_ID = this._emp_id;
                }
                this.commentDialog.SetCommentDialog(this._hn, this._reg_id, this.advBandedGridView3.GetDataRow(this.advBandedGridView3.FocusedRowHandle)
                    , CommentDialog.ShowDialogMode.Draft);
                this.commentDialog.ShowDialog();
            }
        }
        #endregion

        #region Context Menu Strip Event
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        //    ContextMenuStrip ms = sender as ContextMenuStrip;
        //    DevExpress.XtraGrid.GridControl control = (DevExpress.XtraGrid.GridControl)ms.SourceControl;
        //    DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view = control.MainView as DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView;
        //    //bool select = view.row;
        //    //DevExpress.XtraGrid.Views.BandedGrid.GridBandRow parent = sender as DevExpress.XtraGrid.Views.BandedGrid.GridBandRow;

        //    if (this.advBandedGridView1.FocusedRowHandle < 0)
        //    {
        //        this.contextMenuStrip1.Items["tsmOpen"].Visible = false;
        //    }
        //    else
        //    {
        //        this.contextMenuStrip1.Items["tsmOpen"].Visible = true;
        //    }
        }
        #endregion

        #region Add New Comment
        /// <summary>
        /// Add New Comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewComment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.CheckValidEvent(ButtonFormState.AddNewComment))
            {
                if (this.commentDialog.IsDisposed)
                {
                    this.commentDialog = CommentDialog.GetCommentDialog(true);
                    this.commentDialog.EMP_ID = this._emp_id;
                }
                this.commentDialog.DialogMode = CommentDialog.ShowDialogMode.New;
                this.commentDialog.SetNewCommentDialog(this._hn, this._reg_id);
                this.commentDialog.ShowDialog();
            }
        }
        #endregion

        #region Set Mark as read
        private void btnMarkAsRead_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.CheckValidEvent(ButtonFormState.MarkAsRead))
            {
                DataRow[] drMarkAsReads = this.dsCommentThread.Tables[0].Select("[IS_SELECTED] = 'Y'");
                foreach (DataRow drMarkAsRead in drMarkAsReads)
                {
                    this.commentManager.SetMarkAsReadComment(drMarkAsRead, this._emp_id);
                    drMarkAsRead["IS_SELECTED"] = null;
                }
            }
        }
        #endregion

        #region Remove to trash
        private void btnTrash_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.CheckValidEvent(ButtonFormState.Trash))
            {
                string result = msg.ShowAlert("UID1306", new GBLEnvVariable().CurrentLanguageID);
                //DialogResult result = MessageBox.Show("คุณต้องการย้าย comment นี้ไปยัง trash หรือไม่", "move comment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == "2")
                {
                    DataRow[] drMarkAsReads = this.dsCommentThread.Tables[0].Select("[IS_SELECTED] = 'Y'");
                    foreach (DataRow drMarkAsRead in drMarkAsReads)
                    {
                        drMarkAsRead["IS_SELECTED"] = null;
                        this.commentManager.SetCommentToTrash(Convert.ToInt32(drMarkAsRead["COMMENT_ID"]), this._emp_id);
                    }
                }
            }
        }

        #endregion

        #region Delete Draft Comment
        private void btnDraftDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.CheckValidEvent(ButtonFormState.DeleteDraft))
            {
                 string result = msg.ShowAlert("UID6004", new GBLEnvVariable().CurrentLanguageID);
                 if (result == "2")
                 {
                     DataRow[] drDarftRowSelect = this.dsCommentSaveDraft.Tables[0].Select("[IS_SELECTED] = 'Y'");
                     foreach (DataRow drDraftRow in drDarftRowSelect)
                     {
                         drDraftRow["IS_SELECTED"] = null;
                         this.commentManager.RemoveComment(Convert.ToInt32(drDraftRow["COMMENT_ID"]), this._emp_id);
                     }
                 }
            }
        }
        #endregion

        #region Delete Comment In Trash
        private void btnTrashDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
              if (this.CheckValidEvent(ButtonFormState.DeleteTrash))
              {
                  string result = msg.ShowAlert("UID6004", new GBLEnvVariable().CurrentLanguageID);
                  if (result == "2")
                  {
                      DataRow[] drTrashRowSelect = this.dsCommentInTrash.Tables[0].Select("[IS_SELECTED] = 'Y'");
                      foreach (DataRow drTrashRow in drTrashRowSelect)
                      {
                          drTrashRow["IS_SELECTED"] = null;
                          this.commentManager.RemoveComment(Convert.ToInt32(drTrashRow["COMMENT_ID"]), this._emp_id);
                      }
                  }
              }
        }
        #endregion

        #region Send Draft comment
        private void btnDraftSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.CheckValidEvent(ButtonFormState.Send))
            {
                string mg = msg.ShowAlert("UID1303", new GBLEnvVariable().CurrentLanguageID);
                if (mg == "2")
                {
                    DataRow[] drDarftRowSelect = this.dsCommentSaveDraft.Tables[0].Select("[IS_SELECTED] = 'Y'");

                    foreach (DataRow drDraftRow in drDarftRowSelect)
                    {
                        if (drDraftRow["EXAM_ID"] != DBNull.Value)
                        {
                            drDraftRow["IS_SELECTED"] = null;
                            this.commentManager.SendCommentByDraft(Convert.ToInt32(drDraftRow["COMMENT_ID"]), this._emp_id);
                        }
                        else
                        {
                            msg.ShowAlert("UID6013", new GBLEnvVariable().CurrentLanguageID);
                        }
                    }
                }
            }
        }
        #endregion

        #region Restore Comment In Trash
        private void btnTrashRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.CheckValidEvent(ButtonFormState.Restore))
            {
                DataRow[] drTrashRowSelect = this.dsCommentInTrash.Tables[0].Select("[IS_SELECTED] = 'Y'");
                foreach (DataRow drTrashRow in drTrashRowSelect)
                {
                    drTrashRow["IS_SELECTED"] = null;
                    this.commentManager.RestoreCommentInTrash(Convert.ToInt32(drTrashRow["COMMENT_ID"]), this._emp_id);
                }
            }
        }
        #endregion

        #region TextBox HN Event
        private void tbHN_LostFocus(object sender, EventArgs e)
        {
            this.tbHN.Text = this._hn;
        }
        private void tbHN_TextChanged(object sender, EventArgs e)
        {
            //if (this.commentManager.GetPatientDemographic(this.tbHN.Text).Tables[0].Rows.Count > 0)
            //{
            //    this.InitialPatientDemographic(tbHN.Text);
            //}
        }
        #endregion

        #region Refresh
        /// <summary>
        /// This method use to refresh thread grid
        /// </summary>
        private void RefreshThreadGrid()
        {
            this.tbCommentTo.Text = string.Empty;
            this.tbExam.Text = string.Empty;
            this.tbExamDate.Text = string.Empty;
            this.dsCommentThread = this.commentManager.GetCommentInBox(this._hn, this._emp_id);
            this.dsCommentThread.Tables[0].Columns.Add("IS_SELECTED", typeof(string), "");
            this.dsCommentThread.Tables[0].Columns.Add("MARK_AS_READ", typeof(string), "");
            this.dsCommentThread.Tables[0].AcceptChanges();
            this.gridControl1.DataSource = this.dsCommentThread.Tables[0];
            this.tbExam.DataBindings.Clear();
            this.tbCommentTo.DataBindings.Clear();
            this.tbExamDate.DataBindings.Clear();
            this.tbAge.DataBindings.Clear();
            this.tbExam.DataBindings.Add("TEXT", this.dsCommentThread.Tables[0], "EXAM");
            this.tbCommentTo.DataBindings.Add("TEXT", this.dsCommentThread.Tables[0], "COMMENT_TO");
            this.tbExamDate.DataBindings.Add("TEXT", this.dsCommentThread.Tables[0], "EXAM_DT");
            this.tbAge.DataBindings.Add("TEXT", this.dsCommentThread.Tables[0], "AGE");
            this.gridControl1.Refresh();
        }
        /// <summary>
        /// This method use to refresh draft grid
        /// </summary>
        private void RefreshDraftGrid()
        {
            this.tbDraftCommentTo.Text = string.Empty;
            this.tbDraftExam.Text = string.Empty;
            this.tbDraftExamDate.Text = string.Empty;
            this.dsCommentSaveDraft = this.commentManager.GetCommentSaveDraft(this._hn, this._emp_id);
            this.dsCommentSaveDraft.Tables[0].Columns.Add("IS_SELECTED", typeof(string), "");
            this.dsCommentSaveDraft.Tables[0].Columns["IS_SELECTED"].DefaultValue = false;
            this.dsCommentSaveDraft.Tables[0].AcceptChanges();
            this.gridControl2.DataSource = this.dsCommentSaveDraft.Tables[0];
            this.tbDraftExam.DataBindings.Clear();
            this.tbDraftCommentTo.DataBindings.Clear();
            this.tbDraftExamDate.DataBindings.Clear();
            this.tbAge2.DataBindings.Clear();
            this.tbAge2.DataBindings.Add("TEXT", this.dsCommentSaveDraft.Tables[0], "AGE");
            this.tbDraftExam.DataBindings.Add("TEXT", this.dsCommentSaveDraft.Tables[0], "EXAM");
            this.tbDraftCommentTo.DataBindings.Add("TEXT", this.dsCommentSaveDraft.Tables[0], "COMMENT_TO");
            this.tbDraftExamDate.DataBindings.Add("TEXT", this.dsCommentSaveDraft.Tables[0], "EXAM_DT");
            this.gridControl2.Refresh();
        }
        /// <summary>
        /// This method use to refresh comment in trash
        /// </summary>
        private void RefreshTrashGrid()
        {
            this.tbTrashCommentTo.Text = string.Empty;
            this.tbTrashExam.Text = string.Empty;
            this.tbTrashExamDate.Text = string.Empty;
            this.dsCommentInTrash = this.commentManager.GetCommentInTrash(this._hn, this._emp_id);
            this.dsCommentInTrash.Tables[0].Columns.Add("IS_SELECTED", typeof(string), "");
            this.dsCommentInTrash.Tables[0].Columns["IS_SELECTED"].DefaultValue = "N";
            this.dsCommentInTrash.Tables[0].AcceptChanges();
            this.gridControl3.DataSource = this.dsCommentInTrash.Tables[0];
            this.tbTrashCommentTo.DataBindings.Clear();
            this.tbTrashExam.DataBindings.Clear();
            this.tbTrashExamDate.DataBindings.Clear();
            this.tbAge3.DataBindings.Clear();
            this.tbTrashExam.DataBindings.Add("TEXT", this.dsCommentInTrash.Tables[0], "EXAM");
            this.tbTrashCommentTo.DataBindings.Add("TEXT", this.dsCommentInTrash.Tables[0], "COMMENT_TO");
            this.tbTrashExamDate.DataBindings.Add("TEXT", this.dsCommentInTrash.Tables[0], "EXAM_DT");
            this.tbAge3.DataBindings.Add("TEXT", this.dsCommentInTrash.Tables[0], "AGE");
            this.gridControl3.Refresh();
        }
        #endregion

        #region Check Box In Grid Event
        private void repositoryItemCheckEdit3_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (chk.CheckState == CheckState.Checked)
                {
                    DataRow dr = this.advBandedGridView2.GetDataRow(this.advBandedGridView2.FocusedRowHandle);
                    dr["IS_SELECTED"] = "Y";
                }
                else
                {
                    DataRow dr = this.advBandedGridView2.GetDataRow(this.advBandedGridView2.FocusedRowHandle);
                    dr["IS_SELECTED"] = null;
                }
            }
            catch { }
        }

        private void repositoryItemCheckEdit2_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (chk.CheckState == CheckState.Checked)
                {
                    DataRow dr = this.advBandedGridView3.GetDataRow(this.advBandedGridView3.FocusedRowHandle);
                    dr["IS_SELECTED"] = "Y";
                }
                else
                {
                    DataRow dr = this.advBandedGridView3.GetDataRow(this.advBandedGridView3.FocusedRowHandle);
                    dr["IS_SELECTED"] = null;
                }
            }
            catch { }
        }


        private void repositoryItemCheckEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (chk.CheckState == CheckState.Checked)
                {
                    DataRow dr = this.advBandedGridView1.GetDataRow(this.advBandedGridView1.FocusedRowHandle);
                    dr["IS_SELECTED"] = "Y";
                }
                else
                {
                    DataRow dr = this.advBandedGridView1.GetDataRow(this.advBandedGridView1.FocusedRowHandle);
                    dr["IS_SELECTED"] = null;
                }
            }
            catch { }
        }

        public bool CheckValidEvent(ButtonFormState state)
        {
            if (this._hn == string.Empty)
            {
                string result = msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                //DialogResult result = MessageBox.Show("กรุณาป้อน HN เพื่อเริ่ม Comment", "ข้อระวัง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //if (result == DialogResult.OK)
                //{
                    this.tbHN.Focus();
                    return false;
                //}
            }
            else
            {
                if (state == ButtonFormState.Reply || state == ButtonFormState.MarkAsRead
                    || state == ButtonFormState.MarkAsUnread || state == ButtonFormState.Trash)
                {
                    if (this.dsCommentThread == null || this.dsCommentThread.Tables.Count == 0 || this.dsCommentThread.Tables[0].Rows.Count == 0)
                    {
                    //    DialogResult result = MessageBox.Show("ไม่มี comment ในรายการ", "ข้อระวัง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    if (result == DialogResult.OK)
                    //    {
                    //        return false;
                    //    }
                        string result = msg.ShowAlert("UID6007", new GBLEnvVariable().CurrentLanguageID);
                        return false;
                    }
                    else
                    {
                        DataRow[] InboxRows = this.dsCommentThread.Tables[0].Select("[IS_SELECTED] = 'Y'");
                        if (state == ButtonFormState.Reply)
                        {
                            if (InboxRows.Length < 1)
                            {
                            //    DialogResult result = MessageBox.Show("กรุณาเลือก comment ที่ต้องการตอบกลับด้วย", "ข้อระวัง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //    if (result == DialogResult.OK)
                            //    {
                            //        return false;
                            //    }
                                string result = msg.ShowAlert("UID6008", new GBLEnvVariable().CurrentLanguageID);
                                return false;
                            }
                            else if (InboxRows.Length > 1)
                            {
                                //DialogResult result = MessageBox.Show("ท่านสามารถเลือก comment ตอบกลับได้ทีละ 1 comment เท่านั้น", "ข้อระวัง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //if (result == DialogResult.OK)
                                //{
                                //    return false;
                                //}
                                string result = msg.ShowAlert("UID6009", new GBLEnvVariable().CurrentLanguageID);
                                return false;
                            }
                        }
                        else
                        {
                            if (InboxRows.Length < 1)
                            {
                                //DialogResult result = MessageBox.Show("กรุณาเลือก comment ที่ต้องการด้วย", "ข้อระวัง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //if (result == DialogResult.OK)
                                //{
                                //    return false;
                                //}
                                string result = msg.ShowAlert("UID6010", new GBLEnvVariable().CurrentLanguageID);
                                return false;
                            }
                        }
                    }
                }
                else if (state == ButtonFormState.Send || state == ButtonFormState.DeleteDraft)
                {
                    if (this.dsCommentSaveDraft == null || this.dsCommentSaveDraft.Tables.Count == 0 || this.dsCommentSaveDraft.Tables[0].Rows.Count == 0)
                    {
                        //DialogResult result = MessageBox.Show("ไม่มี comment ในรายการ", "ข้อระวัง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //if (result == DialogResult.OK)
                        //{
                        //    return false;
                        //}
                        string result = msg.ShowAlert("UID6007", new GBLEnvVariable().CurrentLanguageID);
                        return false;
                    }
                    else
                    {
                        DataRow[] DraftRows = this.dsCommentSaveDraft.Tables[0].Select("[IS_SELECTED] = 'Y'");
                        if (DraftRows.Length < 1)
                        {
                            //DialogResult result = MessageBox.Show("กรุณาเลือก comment ที่ต้องการด้วย", "ข้อระวัง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //if (result == DialogResult.OK)
                            //{
                            //    return false;
                            //}
                            string result = msg.ShowAlert("UID6010", new GBLEnvVariable().CurrentLanguageID);
                            return false;
                        }
                    }
                }
                else if (state == ButtonFormState.Restore || state == ButtonFormState.DeleteTrash)
                {

                    if (this.dsCommentInTrash == null || this.dsCommentInTrash.Tables.Count == 0 || this.dsCommentInTrash.Tables[0].Rows.Count == 0)
                    {
                        //DialogResult result = MessageBox.Show("ไม่มี comment ในรายการ", "ข้อระวัง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //if (result == DialogResult.OK)
                        //{
                        //    return false;
                        //}
                        string result = msg.ShowAlert("UID6010", new GBLEnvVariable().CurrentLanguageID);
                        return false;
                    }
                    else
                    {
                        DataRow[] TrashRows = this.dsCommentInTrash.Tables[0].Select("[IS_SELECTED] = 'Y'");
                        if (TrashRows.Length < 1)
                        {
                            
                        //    DialogResult result = MessageBox.Show("กรุณาเลือก comment ที่ต้องการด้วย", "ข้อระวัง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    if (result == DialogResult.OK)
                        //    {
                        //        return false;
                        //    }
                            string result = msg.ShowAlert("UID6010", new GBLEnvVariable().CurrentLanguageID);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        #endregion

        protected override void OnShown(EventArgs e)
        {
            if (this.queryFromMode != QueryFromMode.None)
            {
                this.commentDialog.DialogMode = CommentDialog.ShowDialogMode.New;
                if (this.queryFromMode == QueryFromMode.Order)
                    this.commentDialog.SetCommentBySourceId(this._hn, this._reg_id, this.order_id, this.exam_id);
                else
                    this.commentDialog.SetCommentBySourceId(this._hn, this._reg_id, this.schedule_id, this.exam_id);

                this.commentDialog.ShowDialog();
            }
            base.OnShown(e);
        }

        private void btnDraftSend_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }
    }
}