using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Common.UtilityClass;
using RIS.Forms.GBLMessage;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;

namespace RIS.Forms.Technologist
{
    public partial class OperatorNote : Form
    {
        private DBUtility dbu;
        private Graphics Grp;
        private Rectangle Rta; 
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataTable dtt, dsGbl;
        private MyMessageBox msg = new MyMessageBox();
        private string mode = "new";
        private string TempHN, TempName, TempID, TempAGE;
        private RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
        private bool PreItemflag = false, PreTemplateFlag = false, PostItemFlag = false, PostTemplateFlag = false,PostTemplateConFlag = false;
        private bool chkgrd = true;
        int i_pre = 0, i_post = 0, i_pre_temp = 0, i_post_temp = 0, i_post_temp_C = 0;

        public OperatorNote(int i)
        {
            InitializeComponent();
            ProcessGetGBLEnv gbl = new ProcessGetGBLEnv();
            gbl.Invoke();
            dsGbl = gbl.ResultSet.Tables[0];
            initControl();
            initBinding();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
        }
        public OperatorNote(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            this.CloseControl = clsCtl;
            ProcessGetGBLEnv gbl = new ProcessGetGBLEnv();
            gbl.Invoke();
            dsGbl = gbl.ResultSet.Tables[0];
            initControl();
            initBinding();

            //SelectDataToGrid(Convert.ToInt32(textUID.Tag.ToString()));
        }
        #region ToolStrip.
        #endregion

        #region KeyBoard Event.
        private void textUID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textHospital_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textAlias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        #endregion

        private void initControl()
        {
            
        }
        private void initBinding()
        {
            dtt = new DataTable();
            SelectItemToGrid();
        }
        private void SelectTemplateToGrid(int ExamID)
        {
            DataSet dsPreTemp = new DataSet();
            DataSet dsPostTemp = new DataSet();
            DataSet dsPostTempC = new DataSet();

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkTemplate.ValueChecked = "Y";
            chkTemplate.ValueUnchecked = "N";
            chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkTemplate.Click += new EventHandler(chkTemplate_Click);

            ProcessGetRISOpnoteitemtemplate process = new ProcessGetRISOpnoteitemtemplate();
            process.RISOpnoteitemtemplate = new RIS.Common.RISOpnoteitemtemplate();
            process.RISOpnoteitemtemplate.EXAM_ID = ExamID;
            process.RISOpnoteitemtemplate.LAST_MODIFIED_BY = Convert.ToInt32(TempID);

            #region Pre-Op
            process.RISOpnoteitemtemplate.OPNOTE_TYPE = "B";
            process.Invoke();
            dsPreTemp = process.Result.Copy();
            grdPreTemplate.DataSource = dsPreTemp.Tables[0];

            PreTemplate.OptionsView.ShowAutoFilterRow = false;
            PreTemplate.OptionsView.ShowBands = false;
            PreTemplate.OptionsSelection.EnableAppearanceFocusedCell = false;
            PreTemplate.OptionsSelection.EnableAppearanceFocusedRow = true;

            for (int i = 0; i < PreTemplate.Columns.Count; i++)
                PreTemplate.Columns[i].Visible = false;

            PreTemplate.Columns["CHK"].ColumnEdit = chkTemplate;
            PreTemplate.Columns["CHK"].BestFit();
            PreTemplate.Columns["CHK"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            PreTemplate.Columns["CHK"].Name = "CHK";
            PreTemplate.Columns["CHK"].Caption = string.Empty;
            PreTemplate.Columns["CHK"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            PreTemplate.Columns["CHK"].Visible = true;

            PreTemplate.Columns["OP_ITEM_ID"].Caption = "OP_ITEM_ID";
            PreTemplate.Columns["OP_ITEM_ID"].Visible = false;

            PreTemplate.Columns["OP_ITEM_UID"].Caption = "UID";
            PreTemplate.Columns["OP_ITEM_UID"].OptionsColumn.ReadOnly = true;
            PreTemplate.Columns["OP_ITEM_UID"].OptionsColumn.AllowEdit = false;
            PreTemplate.Columns["OP_ITEM_UID"].Visible = true;
            PreTemplate.Columns["OP_ITEM_UID"].Width = 50;

            PreTemplate.Columns["OP_ITEM_NAME"].Caption = "Item Name";
            PreTemplate.Columns["OP_ITEM_NAME"].OptionsColumn.ReadOnly = true;
            PreTemplate.Columns["OP_ITEM_NAME"].OptionsColumn.AllowEdit = false;
            PreTemplate.Columns["OP_ITEM_NAME"].Visible = true;
            PreTemplate.Columns["OP_ITEM_NAME"].Width = 140;

            PreTemplate.Columns["ITEM_VALUE"].Caption = "Value";
            PreTemplate.Columns["ITEM_VALUE"].Visible = true;
            PreTemplate.Columns["ITEM_VALUE"].Width = 100;

            PreTemplate.Columns["ITEM_UNIT"].Caption = "Item Unit";
            PreTemplate.Columns["ITEM_UNIT"].Visible = true;
            PreTemplate.Columns["ITEM_UNIT"].Width = 70;
            #endregion

            #region Post-Op
            process.RISOpnoteitemtemplate.OPNOTE_TYPE = "A";
            process.Invoke();
            dsPostTemp = process.Result.Copy();
            grdPostTemplate.DataSource = dsPostTemp.Tables[0];

            PostTemplate.OptionsView.ShowAutoFilterRow = false;
            PostTemplate.OptionsView.ShowBands = false;
            PostTemplate.OptionsSelection.EnableAppearanceFocusedCell = false;
            PostTemplate.OptionsSelection.EnableAppearanceFocusedRow = true;

            for (int i = 0; i < PostTemplate.Columns.Count; i++)
                PostTemplate.Columns[i].Visible = false;

            PostTemplate.Columns["CHK"].ColumnEdit = chkTemplate;
            PostTemplate.Columns["CHK"].BestFit();
            PostTemplate.Columns["CHK"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            PostTemplate.Columns["CHK"].Name = "CHK";
            PostTemplate.Columns["CHK"].Caption = string.Empty;
            PostTemplate.Columns["CHK"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            PostTemplate.Columns["CHK"].Visible = true;

            PostTemplate.Columns["OP_ITEM_ID"].Caption = "OP_ITEM_ID";
            PostTemplate.Columns["OP_ITEM_ID"].Visible = false;

            PostTemplate.Columns["OP_ITEM_UID"].Caption = "UID";
            PostTemplate.Columns["OP_ITEM_UID"].OptionsColumn.ReadOnly = true;
            PostTemplate.Columns["OP_ITEM_UID"].OptionsColumn.AllowEdit = false;
            PostTemplate.Columns["OP_ITEM_UID"].Visible = true;
            PostTemplate.Columns["OP_ITEM_UID"].Width = 50;

            PostTemplate.Columns["OP_ITEM_NAME"].Caption = "Item Name";
            PostTemplate.Columns["OP_ITEM_NAME"].OptionsColumn.ReadOnly = true;
            PostTemplate.Columns["OP_ITEM_NAME"].OptionsColumn.AllowEdit = false;
            PostTemplate.Columns["OP_ITEM_NAME"].Visible = true;
            PostTemplate.Columns["OP_ITEM_NAME"].Width = 140;

            PostTemplate.Columns["ITEM_VALUE"].Caption = "Value";
            PostTemplate.Columns["ITEM_VALUE"].Visible = true;
            PostTemplate.Columns["ITEM_VALUE"].Width = 100;

            PostTemplate.Columns["ITEM_UNIT"].Caption = "Item Unit";
            PostTemplate.Columns["ITEM_UNIT"].Visible = true;
            PostTemplate.Columns["ITEM_UNIT"].Width = 70;
            #endregion

            #region PostCon-Op
            process.RISOpnoteitemtemplate.OPNOTE_TYPE = "C";
            process.Invoke();
            dsPostTempC = process.Result.Copy();
            grdPostC.DataSource = dsPostTempC.Tables[0];

            PostTemplateC.OptionsView.ShowAutoFilterRow = false;
            PostTemplateC.OptionsView.ShowBands = false;
            PostTemplateC.OptionsSelection.EnableAppearanceFocusedCell = false;
            PostTemplateC.OptionsSelection.EnableAppearanceFocusedRow = true;

            for (int i = 0; i < PostTemplateC.Columns.Count; i++)
                PostTemplateC.Columns[i].Visible = false;

            PostTemplateC.Columns["CHK"].ColumnEdit = chkTemplate;
            PostTemplateC.Columns["CHK"].BestFit();
            PostTemplateC.Columns["CHK"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            PostTemplateC.Columns["CHK"].Name = "CHK";
            PostTemplateC.Columns["CHK"].Caption = string.Empty;
            PostTemplateC.Columns["CHK"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            PostTemplateC.Columns["CHK"].Visible = true;

            PostTemplateC.Columns["OP_ITEM_ID"].Caption = "OP_ITEM_ID";
            PostTemplateC.Columns["OP_ITEM_ID"].Visible = false;

            PostTemplateC.Columns["OP_ITEM_UID"].Caption = "UID";
            PostTemplateC.Columns["OP_ITEM_UID"].OptionsColumn.ReadOnly = true;
            PostTemplateC.Columns["OP_ITEM_UID"].OptionsColumn.AllowEdit = false;
            PostTemplateC.Columns["OP_ITEM_UID"].Visible = true;
            PostTemplateC.Columns["OP_ITEM_UID"].Width = 50;

            PostTemplateC.Columns["OP_ITEM_NAME"].Caption = "Item Name";
            PostTemplateC.Columns["OP_ITEM_NAME"].OptionsColumn.ReadOnly = true;
            PostTemplateC.Columns["OP_ITEM_NAME"].OptionsColumn.AllowEdit = false;
            PostTemplateC.Columns["OP_ITEM_NAME"].Visible = true;
            PostTemplateC.Columns["OP_ITEM_NAME"].Width = 140;

            PostTemplateC.Columns["ITEM_VALUE"].Caption = "Value";
            PostTemplateC.Columns["ITEM_VALUE"].Visible = true;
            PostTemplateC.Columns["ITEM_VALUE"].Width = 100;

            PostTemplateC.Columns["ITEM_UNIT"].Caption = "Item Unit";
            PostTemplateC.Columns["ITEM_UNIT"].Visible = true;
            PostTemplateC.Columns["ITEM_UNIT"].Width = 70;
            #endregion
        }
        private void SelectItemToGrid()
        {
            PreTemplate.OptionsView.ShowBands = false;
            PostTemplate.OptionsView.ShowBands = false;
            ProcessGetRISOpnoteitem process = new ProcessGetRISOpnoteitem();
            process.RISOpnoteitem = new RIS.Common.RISOpnoteitem();
            process.RISOpnoteitem.OP_ITEM_ID = -100;
            process.Invoke();

            #region Pre-Op
            DataSet dsPreItem = new DataSet();
            dsPreItem = process.Result.Copy();
            grdPreItem.DataSource = dsPreItem.Tables[0];

            ViewItem.OptionsView.ShowAutoFilterRow = true;
            ViewItem.OptionsView.ShowBands = false;
            ViewItem.OptionsSelection.EnableAppearanceFocusedCell = false;
            ViewItem.OptionsSelection.EnableAppearanceFocusedRow = true;

            for (int i = 0; i < ViewItem.Columns.Count; i++)
                ViewItem.Columns[i].Visible = false;
            
            //ViewItem.Columns["CHK"].Caption = string.Empty;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.Click += new EventHandler(chk_Click);
            ViewItem.Columns["CHK"].ColumnEdit = chk;
            ViewItem.Columns["CHK"].BestFit();
            ViewItem.Columns["CHK"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ViewItem.Columns["CHK"].Name = "CHK";
            ViewItem.Columns["CHK"].Caption = string.Empty;
            ViewItem.Columns["CHK"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            ViewItem.Columns["CHK"].Visible = true;

            ViewItem.Columns["OP_ITEM_ID"].Caption = "OP_ITEM_ID";
            ViewItem.Columns["OP_ITEM_ID"].Visible = false;

            ViewItem.Columns["OP_ITEM_UID"].Caption = "UID";
            ViewItem.Columns["OP_ITEM_UID"].OptionsColumn.ReadOnly = true;
            ViewItem.Columns["OP_ITEM_UID"].OptionsColumn.AllowEdit = false;
            ViewItem.Columns["OP_ITEM_UID"].Visible = true;
            ViewItem.Columns["OP_ITEM_UID"].Width = 50;

            ViewItem.Columns["OP_ITEM_NAME"].Caption = "Item Name";
            ViewItem.Columns["OP_ITEM_NAME"].OptionsColumn.ReadOnly = true;
            ViewItem.Columns["OP_ITEM_NAME"].OptionsColumn.AllowEdit = false;
            ViewItem.Columns["OP_ITEM_NAME"].Visible = true;
            ViewItem.Columns["OP_ITEM_NAME"].Width = 125;
            #endregion

            #region PostItem
            DataSet dsPostItem = new DataSet();
            dsPostItem = process.Result.Copy();
            grdPost.DataSource = dsPostItem.Tables[0];

            PostViewItem.OptionsView.ShowAutoFilterRow = true;
            PostViewItem.OptionsView.ShowBands = false;
            PostViewItem.OptionsSelection.EnableAppearanceFocusedCell = false;
            PostViewItem.OptionsSelection.EnableAppearanceFocusedRow = true;

            for (int i = 0; i < PostViewItem.Columns.Count; i++)
                PostViewItem.Columns[i].Visible = false;

            PostViewItem.Columns["CHK"].ColumnEdit = chk;
            PostViewItem.Columns["CHK"].BestFit();
            PostViewItem.Columns["CHK"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            PostViewItem.Columns["CHK"].Name = "CHK";
            PostViewItem.Columns["CHK"].Caption = string.Empty;
            PostViewItem.Columns["CHK"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            PostViewItem.Columns["CHK"].Visible = true;

            PostViewItem.Columns["OP_ITEM_ID"].Caption = "OP_ITEM_ID";
            PostViewItem.Columns["OP_ITEM_ID"].Visible = false;

            PostViewItem.Columns["OP_ITEM_UID"].Caption = "UID";
            PostViewItem.Columns["OP_ITEM_UID"].OptionsColumn.ReadOnly = true;
            PostViewItem.Columns["OP_ITEM_UID"].OptionsColumn.AllowEdit = false;
            PostViewItem.Columns["OP_ITEM_UID"].Visible = true;
            PostViewItem.Columns["OP_ITEM_UID"].Width = 50;

            PostViewItem.Columns["OP_ITEM_NAME"].Caption = "Item Name";
            PostViewItem.Columns["OP_ITEM_NAME"].OptionsColumn.ReadOnly = true;
            PostViewItem.Columns["OP_ITEM_NAME"].OptionsColumn.AllowEdit = false;
            PostViewItem.Columns["OP_ITEM_NAME"].Visible = true;
            PostViewItem.Columns["OP_ITEM_NAME"].Width = 125;
            #endregion
        }
        private void chk_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    DataTable dtPre = (DataTable)grdPreItem.DataSource;
                    if (ViewItem.FocusedRowHandle > 0)
                    {
                        dtPre.Rows[ViewItem.FocusedRowHandle]["CHK"] = chk.Checked ? "N" : "Y";
                        grdPreItem.DataSource = dtPre;
                        PreItemflag = false;
                    }
                    break;
                case 1:
                    DataTable dtPost = (DataTable)grdPost.DataSource;
                    if (PostViewItem.FocusedRowHandle > 0)
                    {
                        dtPost.Rows[PostViewItem.FocusedRowHandle]["CHK"] = chk.Checked ? "N" : "Y";
                        grdPost.DataSource = dtPost;
                        PostItemFlag = false;
                    }
                    break;
                default:
                    break;
            }
        }
        private void chkTemplate_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    DataTable dtPre = (DataTable)grdPreTemplate.DataSource;
                    if (PreTemplate.FocusedRowHandle > 0)
                    {
                        dtPre.Rows[PreTemplate.FocusedRowHandle]["CHK"] = chk.Checked ? "N" : "Y";
                        grdPreTemplate.DataSource = dtPre;
                        PreTemplateFlag = false;
                    }
                    break;
                case 1:
                    DataTable dtPost = (DataTable)grdPostTemplate.DataSource;
                    if (PostTemplate.FocusedRowHandle > 0)
                    {
                        dtPost.Rows[PostTemplate.FocusedRowHandle]["CHK"] = chk.Checked ? "N" : "Y";
                        grdPostTemplate.DataSource = dtPost;
                        PostTemplateFlag = false;
                    }
                    break;
                default:
                    break;
            }
        }
        void repostext_Leave(object sender, EventArgs e)
        {

        }
        private void btnLookUpHN_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(HN_ValueUpdated);
            string qry = @"SELECT  DISTINCT   HIS_REGISTRATION.HN, ISNULL(NULLIF (HIS_REGISTRATION.TITLE, ''), 'คุณ') + ISNULL(HIS_REGISTRATION.FNAME, 'ชาวไทยไม่ทราบชื่อ') 
                            + ISNULL(HIS_REGISTRATION.MNAME, '') + ' ' + ISNULL(HIS_REGISTRATION.LNAME, '') AS FullName, HIS_REGISTRATION.REG_ID
                            FROM         RIS_ORDER INNER JOIN
                                                  HIS_REGISTRATION ON RIS_ORDER.REG_ID = HIS_REGISTRATION.REG_ID
                            WHERE     (RIS_ORDER.IS_CANCELED = 'N') AND (HIS_REGISTRATION.HN LIKE '%%')
                        ";
            string fields = "HN, Name, ID";
            string con = "";
            lv.getData(qry, fields, con, "HN Search");
            lv.Show();
        }
        private void HN_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            TempHN = retValue[0];
            TempName = retValue[1];
            TempID = retValue[2];

            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Exam_ValueUpdated);
            string qry = @"SELECT  HIS_REGISTRATION.HN, RIS_EXAM.EXAM_NAME, HR_UNIT.UNIT_NAME, RIS_ORDERDTL.ACCESSION_NO, RIS_ORDER.ORDER_DT,RIS_EXAM.EXAM_ID
                            FROM         RIS_ORDER INNER JOIN
                            RIS_ORDERDTL ON RIS_ORDER.ORDER_ID = RIS_ORDERDTL.ORDER_ID INNER JOIN
                            RIS_EXAM ON RIS_ORDERDTL.EXAM_ID = RIS_EXAM.EXAM_ID INNER JOIN
                            HIS_REGISTRATION ON RIS_ORDER.REG_ID = HIS_REGISTRATION.REG_ID left JOIN
                            HR_UNIT ON RIS_ORDER.REF_UNIT = HR_UNIT.UNIT_ID
                            where RIS_ORDER.IS_CANCELED = 'N' AND RIS_ORDER.REG_ID = {0}
                            AND RIS_EXAM.EXAM_NAME like '%%'
                            order by RIS_ORDER.ORDER_DT desc
                        ";
            string fields = "HN, Exam Name, Ward, Accession No.,Order Date, ID";
            string con = "";
            qry = string.Format(qry, TempID);
            lv.getData(qry, fields, con, "Exam Name Search");
            lv.Show();
        }
        private void Exam_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            textHN.Text = TempHN;
            textName.Text = TempName;
            textHN.Tag = (object)TempID;

            textExamName.Text = retValue[1];
            textWard.Text = retValue[2];
            textAccessionNo.Text = retValue[3];
            textOrderDate.Text = retValue[4];
            textExamName.Tag = (object)retValue[5];

            SelectTemplateToGrid(Convert.ToInt32(retValue[5]));
        }
        private void xtraTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            int index = xtraTabControl1.TabIndex;
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string str = "";
        }
        private void DrawCheckBox(Graphics g, Rectangle r, bool chk)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;

            info = (DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)edit.CreateViewInfo();
            painter = (DevExpress.XtraEditors.Drawing.CheckEditPainter)edit.CreatePainter();
            info.EditValue = chk;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);

            painter.Draw(args);
            args.Cache.Dispose();
        }
        private void ViewItem_Click(object sender, EventArgs e)
        {
            GridHitInfo info;

            Point pt = ViewItem.GridControl.PointToClient(Control.MousePosition);
            info = ViewItem.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                //if (ds.Tables[0].Rows.Count == 0) return;
                if (info.Column.Name == "CHK")
                {
                    if (PreItemflag == false)
                    {
                        DataTable dtt = (DataTable)grdPreItem.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "Y";
                        }
                        grdPreItem.DataSource = dtt;
                        PreItemflag = true;
                    }
                    else
                    {
                        DataTable dtt = (DataTable)grdPreItem.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "N";
                        }
                        grdPreItem.DataSource = dtt;
                        PreItemflag = false;
                    }
                }
            }
        }
        private void ViewItem_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Name == "CHK")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, PreItemflag);
                e.Handled = true;
                Grp = e.Graphics;
                Rta = e.Bounds; 
            }
        }
        private void ViewItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
            {
                i_pre = e.FocusedRowHandle;
            }
        }
        private void PostViewItem_Click(object sender, EventArgs e)
        {
            GridHitInfo info;

            Point pt = PostViewItem.GridControl.PointToClient(Control.MousePosition);
            info = PostViewItem.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                //if (ds.Tables[0].Rows.Count == 0) return;
                if (info.Column.Name == "CHK")
                {
                    if (PostItemFlag == false)
                    {
                        DataTable dtt = (DataTable)grdPost.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "Y";
                        }
                        grdPost.DataSource = dtt;
                        PostItemFlag = true;
                    }
                    else
                    {
                        DataTable dtt = (DataTable)grdPost.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "N";
                        }
                        grdPost.DataSource = dtt;
                        PostItemFlag = false;
                    }
                }
            }
        }
        private void PostViewItem_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
            {
                i_post = e.FocusedRowHandle;
            }
        }
        private void PostViewItem_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Name == "CHK")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, PostItemFlag);
                e.Handled = true;
                Grp = e.Graphics;
                Rta = e.Bounds;
            }
        }
        private void PreTemplate_Click(object sender, EventArgs e)
        {
            GridHitInfo info;

            Point pt = PreTemplate.GridControl.PointToClient(Control.MousePosition);
            info = PreTemplate.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                //if (ds.Tables[0].Rows.Count == 0) return;
                if (info.Column.Name == "CHK")
                {
                    if (PreTemplateFlag == false)
                    {
                        DataTable dtt = (DataTable)grdPreTemplate.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "Y";
                        }
                        grdPreTemplate.DataSource = dtt;
                        PreTemplateFlag = true;
                    }
                    else
                    {
                        DataTable dtt = (DataTable)grdPreTemplate.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "N";
                        }
                        grdPreTemplate.DataSource = dtt;
                        PreTemplateFlag = false;
                    }
                }
            }
        }
        private void PreTemplate_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Name == "CHK")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, PreTemplateFlag);
                e.Handled = true;
                Grp = e.Graphics;
                Rta = e.Bounds;
            }
        }
        private void PreTemplate_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
            {
                i_pre_temp = e.FocusedRowHandle;
            }
        }
        private void PostTemplate_Click(object sender, EventArgs e)
        {
            GridHitInfo info;
            chkgrd = true;
            Point pt = PostTemplate.GridControl.PointToClient(Control.MousePosition);
            info = PostTemplate.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                //if (ds.Tables[0].Rows.Count == 0) return;
                if (info.Column.Name == "CHK")
                {
                    if (PostTemplateFlag == false)
                    {
                        DataTable dtt = (DataTable)grdPostTemplate.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "Y";
                        }
                        grdPostTemplate.DataSource = dtt;
                        PostTemplateFlag = true;
                    }
                    else
                    {
                        DataTable dtt = (DataTable)grdPostTemplate.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "N";
                        }
                        grdPostTemplate.DataSource = dtt;
                        PostTemplateFlag = false;
                    }
                }
            }
        }
        private void PostTemplate_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Name == "CHK")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, PostTemplateFlag);
                e.Handled = true;
                Grp = e.Graphics;
                Rta = e.Bounds;
            }
        }
        private void PostTemplate_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
            {
                i_post_temp = e.FocusedRowHandle;
            }
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (textHN.Text == "" || textExamName.Text == "")
            {
                msg.ShowAlert("UID5002", new GBLEnvVariable().CurrentLanguageID);
            }
            else
            {
                MoveRight(0);
            }
        }

        private void MoveRight(int grd)
        {
            // 0 = grdPreItem
            // 1 = grdPostTemplate
            // 2 = grdPostTemplateC

            if (textHN.Text.Length == 0) return;
            DataTable dtItem = null;
            DataTable dtTemplate = null;
            DataRow drHandle = null;

            switch (grd)
            {
                case 0:
                    dtItem = (DataTable)grdPreItem.DataSource;
                    dtTemplate = (DataTable)grdPreTemplate.DataSource;
                    if (ViewItem.FocusedRowHandle >= 0)
                        drHandle = ViewItem.GetDataRow(ViewItem.FocusedRowHandle);
                    break;
                case 1:
                    dtItem = (DataTable)grdPost.DataSource;
                    dtTemplate = (DataTable)grdPostTemplate.DataSource;
                    if (PostViewItem.FocusedRowHandle >= 0)
                        drHandle = PostViewItem.GetDataRow(PostViewItem.FocusedRowHandle);
                    break;
                case 2:
                    dtItem = (DataTable)grdPost.DataSource;
                    dtTemplate = (DataTable)grdPostC.DataSource;
                    if (PostViewItem.FocusedRowHandle >= 0)
                        drHandle = PostViewItem.GetDataRow(PostViewItem.FocusedRowHandle);
                    break;
                default:
                    break;
            }
            if (dtItem.Rows.Count > 0)
            {
                DataRow[] drCheck = dtItem.Select("CHK = 'Y'");
                if (drCheck.Length > 0)
                {
                    for (int i = 0; i < drCheck.Length; i++)
                    {
                        if (drCheck[i]["CHK"].ToString() == "Y")// dtItem.Rows[i]["CHK"].ToString() == "Y")
                        {
                            DataRow[] drchk = dtTemplate.Select("OP_ITEM_ID =" + drCheck[i]["OP_ITEM_ID"].ToString());
                            if (drchk.Length == 0)
                            {
                                DataRow dr = dtTemplate.NewRow();
                                //dr = 
                                dr["CHK"] = "N";
                                dr["OP_ITEM_ID"] = Convert.ToInt32(drCheck[i]["OP_ITEM_ID"].ToString());
                                dr["OP_ITEM_UID"] = drCheck[i]["OP_ITEM_UID"].ToString();
                                dr["OP_ITEM_NAME"] = drCheck[i]["OP_ITEM_NAME"].ToString();
                                dr["EXAM_ID"] = Convert.ToInt32(textExamName.Tag.ToString());
                                dr["ITEM_VALUE"] = "";
                                dr["ITEM_UNIT"] = "";
                                switch (grd)
                                {
                                    case 0:
                                        dr["OPNOTE_TYPE"] = "B";
                                        break;
                                    case 1:
                                        dr["OPNOTE_TYPE"] = "A";
                                        break;
                                    case 2:
                                        dr["OPNOTE_TYPE"] = "C";
                                        break;
                                    default:
                                        dr["OPNOTE_TYPE"] = "B";
                                        break;
                                }

                                dr["FullName"] = TempName;
                                dr["HN"] = TempHN;
                                dr["AGE"] = TempAGE;
                                dr["ORG_UID"] = dsGbl.Rows[0]["ORG_UID"];
                                dr["ORG_NAME"] = dsGbl.Rows[0]["ORG_NAME"];
                                dr["ORG_ADDR3"] = dsGbl.Rows[0]["ORG_ADDR3"];
                                dr["ORG_ADDR4"] = dsGbl.Rows[0]["ORG_ADDR4"];
                                dr["ORG_IMG"] = dsGbl.Rows[0]["ORG_IMG"];
                                dr["VENDOR_H1"] = dsGbl.Rows[0]["VENDOR_H1"];
                                dr["VENDOR_H2"] = dsGbl.Rows[0]["VENDOR_H2"];
                                dtTemplate.Rows.Add(dr);
                                dtTemplate.AcceptChanges();
                            }
                        }
                    }
                }
                else
                {
                    if (drHandle != null)
                    {
                        DataRow[] drchk = dtTemplate.Select("OP_ITEM_ID =" + drHandle["OP_ITEM_ID"].ToString());
                        if (drchk.Length == 0)
                        {
                            DataRow dr = dtTemplate.NewRow();
                            //dr = 
                            dr["CHK"] = "N";
                            dr["OP_ITEM_ID"] = Convert.ToInt32(drHandle["OP_ITEM_ID"].ToString());
                            dr["OP_ITEM_UID"] = drHandle["OP_ITEM_UID"].ToString();
                            dr["OP_ITEM_NAME"] = drHandle["OP_ITEM_NAME"].ToString();
                            dr["EXAM_ID"] = Convert.ToInt32(textExamName.Tag.ToString());
                            dr["ITEM_VALUE"] = "";
                            dr["ITEM_UNIT"] = "";
                            switch (grd)
                            {
                                case 0:
                                    dr["OPNOTE_TYPE"] = "B";
                                    break;
                                case 1:
                                    dr["OPNOTE_TYPE"] = "A";
                                    break;
                                case 2:
                                    dr["OPNOTE_TYPE"] = "C";
                                    break;
                                default:
                                    dr["OPNOTE_TYPE"] = "B";
                                    break;
                            }

                            dr["FullName"] = TempName;
                            dr["HN"] = TempHN;
                            dr["AGE"] = TempAGE;
                            dr["ORG_UID"] = dsGbl.Rows[0]["ORG_UID"];
                            dr["ORG_NAME"] = dsGbl.Rows[0]["ORG_NAME"];
                            dr["ORG_ADDR3"] = dsGbl.Rows[0]["ORG_ADDR3"];
                            dr["ORG_ADDR4"] = dsGbl.Rows[0]["ORG_ADDR4"];
                            dr["ORG_IMG"] = dsGbl.Rows[0]["ORG_IMG"];
                            dr["VENDOR_H1"] = dsGbl.Rows[0]["VENDOR_H1"];
                            dr["VENDOR_H2"] = dsGbl.Rows[0]["VENDOR_H2"];

                            dtTemplate.Rows.Add(dr);
                            dtTemplate.AcceptChanges();
                        }
                    }
                }
            }

            switch (grd)
            {
                case 0:
                    grdPreTemplate.DataSource = dtTemplate;
                    break;
                case 1:
                    grdPostTemplate.DataSource = dtTemplate;
                    break;
                case 2:
                    grdPostC.DataSource = dtTemplate;
                    break;
                default:
                    break;
            }
        }
        private void MoveRightAll()
        {
            if (textHN.Text.Length == 0) return;
            DataTable dtItem = null;
            DataTable dtTemplate = null;

            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    dtItem = (DataTable)grdPreItem.DataSource;
                    dtTemplate = (DataTable)grdPreTemplate.DataSource;
                    break;
                case 1:
                    dtItem = (DataTable)grdPost.DataSource;
                    dtTemplate = (DataTable)grdPostTemplate.DataSource;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < dtItem.Rows.Count; i++)
            {
                DataRow[] drchk = dtTemplate.Select("OP_ITEM_ID =" + dtItem.Rows[i]["OP_ITEM_ID"].ToString());
                if (drchk.Length == 0)
                {
                    DataRow dr = dtTemplate.NewRow();
                    //dr = 
                    dr["CHK"] = "N";
                    dr["OP_ITEM_ID"] = Convert.ToInt32(dtItem.Rows[i]["OP_ITEM_ID"].ToString());
                    dr["OP_ITEM_UID"] = dtItem.Rows[i]["OP_ITEM_UID"].ToString();
                    dr["OP_ITEM_NAME"] = dtItem.Rows[i]["OP_ITEM_NAME"].ToString();
                    dr["EXAM_ID"] = Convert.ToInt32(textExamName.Tag.ToString());
                    dr["ITEM_VALUE"] = "";
                    dr["ITEM_UNIT"] = "";
                    //switch (grd)
                    //{
                    //    case 0:
                    //        dr["OPNOTE_TYPE"] = "B";
                    //        break;
                    //    case 1:
                    //        dr["OPNOTE_TYPE"] = "A";
                    //        break;
                    //    case 2:
                    //        dr["OPNOTE_TYPE"] = "C";
                    //        break;
                    //    default:
                    //        dr["OPNOTE_TYPE"] = "B";
                    //        break;
                    //}
                    dr["FullName"] = dtTemplate.Rows[0]["FullName"];
                    dr["HN"] = dtTemplate.Rows[0]["HN"];
                    dr["AGE"] = dtTemplate.Rows[0]["AGE"];
                    dr["ORG_UID"] = dtTemplate.Rows[0]["ORG_UID"];
                    dr["ORG_NAME"] = dtTemplate.Rows[0]["ORG_NAME"];
                    dr["ORG_ADDR3"] = dtTemplate.Rows[0]["ORG_ADDR3"];
                    dr["ORG_ADDR4"] = dtTemplate.Rows[0]["ORG_ADDR4"];
                    dr["ORG_IMG"] = dtTemplate.Rows[0]["ORG_IMG"];
                    dr["VENDOR_H1"] = dtTemplate.Rows[0]["VENDOR_H1"];
                    dr["VENDOR_H2"] = dtTemplate.Rows[0]["VENDOR_H2"];

                    dtTemplate.Rows.Add(dr);
                    dtTemplate.AcceptChanges();

                    dtTemplate.Rows.Add(dr);
                    dtTemplate.AcceptChanges();
                }
            }
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    grdPreTemplate.DataSource = dtTemplate;
                    break;
                case 1:
                    grdPostTemplate.DataSource = dtTemplate;
                    break;
                default:
                    break;
            }
        }
        private void MoveLeft(int grd)
        {
            if (textHN.Text.Length == 0) return;
            DataTable dtItem = null;
            DataTable dtTemplate = null;
            DataRow drHandle = null;
            switch (grd)
            {
                case 0:
                    dtItem = (DataTable)grdPreItem.DataSource;
                    dtTemplate = (DataTable)grdPreTemplate.DataSource;
                    if (PreTemplate.FocusedRowHandle >= 0)
                        drHandle = PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle);
                    break;
                case 1:
                    dtItem = (DataTable)grdPost.DataSource;
                    dtTemplate = (DataTable)grdPostTemplate.DataSource;
                    if (PostTemplate.FocusedRowHandle >= 0)
                        drHandle = PostTemplate.GetDataRow(PostTemplate.FocusedRowHandle);
                    break;
                case 2: 
                    dtItem = (DataTable)grdPost.DataSource;
                    dtTemplate = (DataTable)grdPostC.DataSource;
                    if (PostTemplateC.FocusedRowHandle >= 0)
                        drHandle = PostTemplateC.GetDataRow(PostTemplateC.FocusedRowHandle);
                    break;
                default:
                    break;
            }
            if (dtTemplate.Rows.Count > 0)
            {
                DataRow[] drCheck = dtTemplate.Select("CHK = 'Y'");
                if (drCheck.Length > 0)
                {
                    for (int i = 0; i < drCheck.Length; i++)
                    {
                        if (drCheck[i]["CHK"].ToString() == "Y")
                        {
                            drCheck[i].Delete();
                        }
                    }
                }
                else
                {
                    if (drHandle != null)
                        drHandle.Delete();
                }
            }
            dtTemplate.AcceptChanges();
            switch (grd)
            {
                case 0:
                    grdPreTemplate.DataSource = dtTemplate;
                    break;
                case 1:
                    grdPostTemplate.DataSource = dtTemplate;
                    break;
                case 2:
                    grdPostC.DataSource = dtTemplate;
                    break;
                default:
                    break;
            }
        }
        private void MoveLeftAll()
        {
            if (textHN.Text.Length == 0) return;
            DataTable dtItem = null;
            DataTable dtTemplate = null;
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    dtItem = (DataTable)grdPreItem.DataSource;
                    dtTemplate = (DataTable)grdPreTemplate.DataSource;
                    break;
                case 1:
                    dtItem = (DataTable)grdPost.DataSource;
                    dtTemplate = (DataTable)grdPostTemplate.DataSource;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < dtTemplate.Rows.Count; i++)
            {
                dtTemplate.Rows[i].Delete();
            }
            dtTemplate.AcceptChanges();
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    grdPreTemplate.DataSource = dtTemplate;
                    break;
                case 1:
                    grdPostTemplate.DataSource = dtTemplate;
                    break;
                default:
                    break;
            }
        }
        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID) == "1")
                return;
            else
                Save();
        }
        private void Save()
        {
            SqlTransaction tran = null;
            SqlConnection con = null;
            try
            {
                DataAccess.DataAccessBase baseData = new RIS.DataAccess.DataAccessBase();
                con = baseData.GetSQLConnection();

                con.Open();
                tran = con.BeginTransaction();

                ProcessAddRISOpnoteitemtemplate prcAdd = new ProcessAddRISOpnoteitemtemplate(tran);
                ProcessDeleteRISOpnoteitemtemplate prcDel = new ProcessDeleteRISOpnoteitemtemplate(tran);



                switch (xtraTabControl1.SelectedTabPageIndex)
                {
                    case 0:
                        prcDel.RISOpnoteitemtemplate.OP_ITEM_ID = 0;
                        prcDel.RISOpnoteitemtemplate.EXAM_ID = Convert.ToInt32(textExamName.Tag.ToString());
                        prcDel.RISOpnoteitemtemplate.OPNOTE_TYPE = "B";
                        prcDel.RISOpnoteitemtemplate.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                        prcDel.Invoke();

                        DataTable dtPre = (DataTable)grdPreTemplate.DataSource;
                        foreach (DataRow dr in dtPre.Rows)
                        {
                            prcAdd.RISOpnoteitemtemplate.OP_ITEM_ID = Convert.ToInt32(dr["OP_ITEM_ID"].ToString());
                            prcAdd.RISOpnoteitemtemplate.EXAM_ID = Convert.ToInt32(textExamName.Tag.ToString());
                            prcAdd.RISOpnoteitemtemplate.ITEM_VALUE = dr["ITEM_VALUE"].ToString();
                            prcAdd.RISOpnoteitemtemplate.ITEM_UNIT = dr["ITEM_UNIT"].ToString();
                            prcAdd.RISOpnoteitemtemplate.OPNOTE_TYPE = "B";
                            prcAdd.RISOpnoteitemtemplate.CREATED_BY = new GBLEnvVariable().UserID;
                            prcAdd.RISOpnoteitemtemplate.LAST_MODIFIED_BY = prcAdd.RISOpnoteitemtemplate.CREATED_BY;

                            prcAdd.Invoke();
                        }
                        break;
                    case 1:
                        prcDel.RISOpnoteitemtemplate.OP_ITEM_ID = 0;
                        prcDel.RISOpnoteitemtemplate.EXAM_ID = Convert.ToInt32(textExamName.Tag.ToString());
                        prcDel.RISOpnoteitemtemplate.OPNOTE_TYPE = "A";
                        prcDel.RISOpnoteitemtemplate.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                        prcDel.Invoke();

                        DataTable dtPost = (DataTable)grdPostTemplate.DataSource;
                        foreach (DataRow dr in dtPost.Rows)
                        {
                            prcAdd.RISOpnoteitemtemplate.OP_ITEM_ID = Convert.ToInt32(dr["OP_ITEM_ID"].ToString());
                            prcAdd.RISOpnoteitemtemplate.EXAM_ID = Convert.ToInt32(textExamName.Tag.ToString());
                            prcAdd.RISOpnoteitemtemplate.ITEM_VALUE = dr["ITEM_VALUE"].ToString();
                            prcAdd.RISOpnoteitemtemplate.ITEM_UNIT = dr["ITEM_UNIT"].ToString();
                            prcAdd.RISOpnoteitemtemplate.OPNOTE_TYPE = "A";
                            prcAdd.RISOpnoteitemtemplate.CREATED_BY = new GBLEnvVariable().UserID;
                            prcAdd.RISOpnoteitemtemplate.LAST_MODIFIED_BY = prcAdd.RISOpnoteitemtemplate.CREATED_BY;

                            prcAdd.Invoke();
                        }

                        prcDel.RISOpnoteitemtemplate.OP_ITEM_ID = 0;
                        prcDel.RISOpnoteitemtemplate.EXAM_ID = Convert.ToInt32(textExamName.Tag.ToString());
                        prcDel.RISOpnoteitemtemplate.OPNOTE_TYPE = "C";
                        prcDel.RISOpnoteitemtemplate.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                        prcDel.Invoke();

                        DataTable dtPostC = (DataTable)grdPostC.DataSource;
                        foreach (DataRow dr in dtPostC.Rows)
                        {
                            prcAdd.RISOpnoteitemtemplate.OP_ITEM_ID = Convert.ToInt32(dr["OP_ITEM_ID"].ToString());
                            prcAdd.RISOpnoteitemtemplate.EXAM_ID = Convert.ToInt32(textExamName.Tag.ToString());
                            prcAdd.RISOpnoteitemtemplate.ITEM_VALUE = dr["ITEM_VALUE"].ToString();
                            prcAdd.RISOpnoteitemtemplate.ITEM_UNIT = dr["ITEM_UNIT"].ToString();
                            prcAdd.RISOpnoteitemtemplate.OPNOTE_TYPE = "C";
                            prcAdd.RISOpnoteitemtemplate.CREATED_BY = new GBLEnvVariable().UserID;
                            prcAdd.RISOpnoteitemtemplate.LAST_MODIFIED_BY = prcAdd.RISOpnoteitemtemplate.CREATED_BY;

                            prcAdd.Invoke();
                        }
                        break;
                    default:
                        break;
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //throw new Exception(ex.Message);
                //retFlag = false;//MessageBox.Show(ex.Message);

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                tran.Dispose();
            }
        }

        private void barItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Admin.RIS_OperatorNoteItem frm = new RIS.Forms.Admin.RIS_OperatorNoteItem();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            
            initBinding();
        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            //Get_lab_data
            //HIS_Patient HIS_p = new HIS_Patient();
            //if (textHN.Text.Length > 0)
            //{
            //    DataSet dsHIS = HIS_p.Get_lab_data(textHN.Text);

            //    RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            //    lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Lab_Clicks);              
            //    lv.Text = "Lab Detail List";

            //    lv.Data = dsHIS.Tables[0];
                
            //    Size ss = new Size(800, 600);
            //    lv.Size = ss;
            //    lv.PreviewFieldName = "report";
            //    lv.ShowDescription = true;
            //    lv.ShowBox();
            //}
        }
        private void Lab_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {

        }
        private void btnAlergy_Click(object sender, EventArgs e)
        {
            //Get_Adr
            HIS_Patient HIS_p = new HIS_Patient();
            if (textHN.Text.Length > 0)
            {
                DataSet dsHIS = null;// HIS_p.Get_Adr(textHN.Text);

                RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
                lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Adr_Clicks);
                lv.Text = "Alergy Detail List";
                lv.Data = dsHIS.Tables[0];

                Size ss = new Size(800, 600);
                lv.Size = ss;
                lv.ShowBox();
            }
        }
        private void Adr_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {

        }
        private void btnHistory_Click(object sender, EventArgs e)
        {

        }

        GridHitInfo hitInfo = null;

        private void grdPreItem_MouseDown(object sender, MouseEventArgs e)
        {
            hitInfo = ViewItem.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void grdPreItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle dragRect = new Rectangle(new Point(
                hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                if (hitInfo.InRowCell)
                {
                    grdPreItem.DoDragDrop((ViewItem.GetRowCellDisplayText(hitInfo.RowHandle, hitInfo.Column)), DragDropEffects.Copy);
                }
                if (hitInfo.HitTest == GridHitTest.RowIndicator)
                {
                    string data = DataRow(ViewItem.GetDataRow(hitInfo.RowHandle));
                    grdPreItem.DoDragDrop(data, DragDropEffects.Copy);
                }
            }
        }
        private string DataRow(DataRow dr)
        {
            string s = "";
            if (dr != null)
                foreach (object o in dr.ItemArray)
                    s = (s == "" ? "" : s + "; ") + o.ToString();
            return s;
        }
        private void grdPreTemplate_DragDrop(object sender, DragEventArgs e)
        {
            MoveRight(0);
        }

        private void grdPreTemplate_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 13)
            {
                if (textHN.Text.Trim().Length > 0)
                {
                    LookUpSelect prc = new LookUpSelect();
                    DataSet dsHN = prc.SelectOPNoteHN(textHN.Text);
                    if (dsHN.Tables[0].Rows.Count > 0)
                    {
                        TempHN = dsHN.Tables[0].Rows[0][0].ToString();
                        TempName = dsHN.Tables[0].Rows[0][1].ToString();
                        TempID = dsHN.Tables[0].Rows[0][2].ToString();
                        TempAGE = dsHN.Tables[0].Rows[0][3].ToString();

                        prc = new LookUpSelect();
                        RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
                        lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Exam_Clicks);
                        lv.Text = "Exam Detail List";
                        lv.Data = prc.SelectOPNoteExam(Convert.ToInt32(TempID)).Tables[0];

                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.ShowBox();
                    }
                }
            }
        }
        private void Exam_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            textHN.Text = TempHN;
            textName.Text = TempName;
            textHN.Tag = (object)TempID;

            textExamName.Text = retValue[1];
            textWard.Text = retValue[2];
            textAccessionNo.Text = retValue[3];
            textOrderDate.Text = retValue[4];
            textExamName.Tag = (object)retValue[5];

            SelectTemplateToGrid(Convert.ToInt32(retValue[5]));
        }

        private void grdPreTemplate_MouseDown(object sender, MouseEventArgs e)
        {
            hitInfo = ViewItem.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void grdPreTemplate_MouseMove(object sender, MouseEventArgs e)
        {
            if (hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle dragRect = new Rectangle(new Point(
                hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                if (hitInfo.InRowCell)
                {
                    grdPreItem.DoDragDrop((ViewItem.GetRowCellDisplayText(hitInfo.RowHandle, hitInfo.Column)), DragDropEffects.Copy);
                }
                if (hitInfo.HitTest == GridHitTest.RowIndicator)
                {
                    string data = DataRow(ViewItem.GetDataRow(hitInfo.RowHandle));
                    grdPreItem.DoDragDrop(data, DragDropEffects.Copy);
                }
            }
        }

        private void grdPreItem_DragDrop(object sender, DragEventArgs e)
        {
            MoveLeft(0);
        }

        private void grdPreItem_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (PreTemplate.FocusedRowHandle > 0)
            {
                DataTable _dt = (DataTable)grdPreTemplate.DataSource;
                DataTable dtt = new DataTable();
                dtt = _dt.Copy();

                DataRow dr_f = PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle);
                //dr_f[0] = PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle);
                DataRow dr_l = PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle - 1);
                //dr_l[0] = PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle - 1);
                int f = _dt.Rows.IndexOf(PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle));
                int l = _dt.Rows.IndexOf(PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle - 1));

                dtt.Rows[f].ItemArray = dr_l.ItemArray;
                dtt.Rows[l].ItemArray = dr_f.ItemArray;
                //dtt.Rows.CopyTo(dr_f.ItemArray,l);
                //dtt.Rows.CopyTo(dr_l.ItemArray, f);
                dtt.AcceptChanges();
                grdPreTemplate.DataSource = dtt;
                PreTemplate.FocusedRowHandle = l;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (PreTemplate.IsLastRow == false)
            {
                DataTable _dt = (DataTable)grdPreTemplate.DataSource;
                DataTable dtt = new DataTable();
                dtt = _dt.Copy();

                DataRow dr_f = PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle);
                //dr_f[0] = PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle);
                DataRow dr_l = PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle + 1);
                //dr_l[0] = PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle - 1);
                int f = _dt.Rows.IndexOf(PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle));
                int l = _dt.Rows.IndexOf(PreTemplate.GetDataRow(PreTemplate.FocusedRowHandle + 1));

                dtt.Rows[f].ItemArray = dr_l.ItemArray;
                dtt.Rows[l].ItemArray = dr_f.ItemArray;
                //dtt.Rows.CopyTo(dr_f.ItemArray,l);
                //dtt.Rows.CopyTo(dr_l.ItemArray, f);
                dtt.AcceptChanges();
                grdPreTemplate.DataSource = dtt;
                PreTemplate.FocusedRowHandle = l;
            }
        }

        private void btnUpPost_Click(object sender, EventArgs e)
        {
            if (chkgrd == true)
            {
                if (PostTemplate.FocusedRowHandle > 0)
                {
                    DataTable _dt = (DataTable)grdPostTemplate.DataSource;
                    DataTable dtt = new DataTable();
                    dtt = _dt.Copy();

                    DataRow dr_f = PostTemplate.GetDataRow(PostTemplate.FocusedRowHandle);
                    DataRow dr_l = PostTemplate.GetDataRow(PostTemplate.FocusedRowHandle - 1);

                    int f = _dt.Rows.IndexOf(PostTemplate.GetDataRow(PostTemplate.FocusedRowHandle));
                    int l = _dt.Rows.IndexOf(PostTemplate.GetDataRow(PostTemplate.FocusedRowHandle - 1));

                    dtt.Rows[f].ItemArray = dr_l.ItemArray;
                    dtt.Rows[l].ItemArray = dr_f.ItemArray;

                    dtt.AcceptChanges();
                    grdPostTemplate.DataSource = dtt;
                    PostTemplate.FocusedRowHandle = l;
                }
            }
            else
            {
                if (PostTemplateC.FocusedRowHandle > 0)
                {
                    DataTable _dt = (DataTable)grdPostC.DataSource;
                    DataTable dtt = new DataTable();
                    dtt = _dt.Copy();

                    DataRow dr_f = PostTemplateC.GetDataRow(PostTemplateC.FocusedRowHandle);
                    DataRow dr_l = PostTemplateC.GetDataRow(PostTemplateC.FocusedRowHandle - 1);

                    int f = _dt.Rows.IndexOf(PostTemplateC.GetDataRow(PostTemplateC.FocusedRowHandle));
                    int l = _dt.Rows.IndexOf(PostTemplateC.GetDataRow(PostTemplateC.FocusedRowHandle - 1));

                    dtt.Rows[f].ItemArray = dr_l.ItemArray;
                    dtt.Rows[l].ItemArray = dr_f.ItemArray;

                    dtt.AcceptChanges();
                    grdPostC.DataSource = dtt;
                    PostTemplateC.FocusedRowHandle = l;
                }
            }
        }

        private void btnDownPost_Click(object sender, EventArgs e)
        {
            if (chkgrd == true)
            {
                if (PostTemplate.IsLastRow == false)
                {
                    DataTable _dt = (DataTable)grdPostTemplate.DataSource;
                    DataTable dtt = new DataTable();
                    dtt = _dt.Copy();

                    DataRow dr_f = PostTemplate.GetDataRow(PostTemplate.FocusedRowHandle);
                    DataRow dr_l = PostTemplate.GetDataRow(PostTemplate.FocusedRowHandle + 1);

                    int f = _dt.Rows.IndexOf(PostTemplate.GetDataRow(PostTemplate.FocusedRowHandle));
                    int l = _dt.Rows.IndexOf(PostTemplate.GetDataRow(PostTemplate.FocusedRowHandle + 1));

                    dtt.Rows[f].ItemArray = dr_l.ItemArray;
                    dtt.Rows[l].ItemArray = dr_f.ItemArray;

                    dtt.AcceptChanges();
                    grdPostTemplate.DataSource = dtt;
                    PostTemplate.FocusedRowHandle = l;
                }
            }
            else
            {
                if (PostTemplateC.IsLastRow == false)
                {
                    DataTable _dt = (DataTable)grdPostC.DataSource;
                    DataTable dtt = new DataTable();
                    dtt = _dt.Copy();

                    DataRow dr_f = PostTemplateC.GetDataRow(PostTemplateC.FocusedRowHandle);
                    DataRow dr_l = PostTemplateC.GetDataRow(PostTemplateC.FocusedRowHandle + 1);

                    int f = _dt.Rows.IndexOf(PostTemplateC.GetDataRow(PostTemplateC.FocusedRowHandle));
                    int l = _dt.Rows.IndexOf(PostTemplateC.GetDataRow(PostTemplateC.FocusedRowHandle + 1));

                    dtt.Rows[f].ItemArray = dr_l.ItemArray;
                    dtt.Rows[l].ItemArray = dr_f.ItemArray;

                    dtt.AcceptChanges();
                    grdPostC.DataSource = dtt;
                    PostTemplateC.FocusedRowHandle = l;
                }
            }

        }

        private void PostTemplateC_Click(object sender, EventArgs e)
        {
            GridHitInfo info;
            chkgrd = false;
            Point pt = PostTemplateC.GridControl.PointToClient(Control.MousePosition);
            info = PostTemplateC.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                //if (ds.Tables[0].Rows.Count == 0) return;
                if (info.Column.Name == "CHK")
                {
                    if (PostTemplateConFlag == false)
                    {
                        DataTable dtt = (DataTable)grdPostC.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "Y";
                        }
                        grdPostC.DataSource = dtt;
                        PostTemplateConFlag = true;
                    }
                    else
                    {
                        DataTable dtt = (DataTable)grdPostC.DataSource;

                        for (int i = 0; i < dtt.Rows.Count; i++)
                        {
                            dtt.Rows[i]["CHK"] = "N";
                        }
                        grdPostC.DataSource = dtt;
                        PostTemplateConFlag = false;
                    }
                }
            }
        }

        private void PostTemplateC_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Name == "CHK")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, PostTemplateFlag);
                e.Handled = true;
                Grp = e.Graphics;
                Rta = e.Bounds;
            }
        }

        private void PostTemplateC_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
            {
                i_post_temp_C = e.FocusedRowHandle;
            }
        }

        private void grdPost_DragDrop(object sender, DragEventArgs e)
        {
            if (chkgrd == true)
            {
                MoveLeft(1);
            }
            else
            {
                MoveLeft(2);
            }
        }

        private void grdPost_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void grdPost_MouseDown(object sender, MouseEventArgs e)
        {
            hitInfo = ViewItem.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void grdPost_MouseMove(object sender, MouseEventArgs e)
        {
            if (hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle dragRect = new Rectangle(new Point(
                hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                if (hitInfo.InRowCell)
                {
                    grdPost.DoDragDrop((PostViewItem.GetRowCellDisplayText(hitInfo.RowHandle, hitInfo.Column)), DragDropEffects.Copy);
                }
                if (hitInfo.HitTest == GridHitTest.RowIndicator)
                {
                    string data = DataRow(PostViewItem.GetDataRow(hitInfo.RowHandle));
                    grdPost.DoDragDrop(data, DragDropEffects.Copy);
                }
            }
        }

        private void grdPostTemplate_DragDrop(object sender, DragEventArgs e)
        {
            MoveRight(1);
        }

        private void grdPostTemplate_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void grdPostTemplate_MouseDown(object sender, MouseEventArgs e)
        {
            hitInfo = ViewItem.CalcHitInfo(new Point(e.X, e.Y));
            chkgrd = true;
        }

        private void grdPostTemplate_MouseMove(object sender, MouseEventArgs e)
        {
            if (hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle dragRect = new Rectangle(new Point(
                hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                if (hitInfo.InRowCell)
                {
                    grdPost.DoDragDrop((PostViewItem.GetRowCellDisplayText(hitInfo.RowHandle, hitInfo.Column)), DragDropEffects.Copy);
                }
                if (hitInfo.HitTest == GridHitTest.RowIndicator)
                {
                    string data = DataRow(PostViewItem.GetDataRow(hitInfo.RowHandle));
                    grdPost.DoDragDrop(data, DragDropEffects.Copy);
                }
            }
        }

        private void grdPostC_DragDrop(object sender, DragEventArgs e)
        {
            MoveRight(2);
        }

        private void grdPostC_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void grdPostC_MouseDown(object sender, MouseEventArgs e)
        {
            hitInfo = ViewItem.CalcHitInfo(new Point(e.X, e.Y));
            chkgrd = false;
        }

        private void grdPostC_MouseMove(object sender, MouseEventArgs e)
        {
            if (hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle dragRect = new Rectangle(new Point(
                hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                if (hitInfo.InRowCell)
                {
                    grdPostC.DoDragDrop((PostViewItem.GetRowCellDisplayText(hitInfo.RowHandle, hitInfo.Column)), DragDropEffects.Copy);
                }
                if (hitInfo.HitTest == GridHitTest.RowIndicator)
                {
                    string data = DataRow(PostViewItem.GetDataRow(hitInfo.RowHandle));
                    grdPostC.DoDragDrop(data, DragDropEffects.Copy);
                }
            }
        }

        private void barPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print();
        }
        private void Print()
        {
            RIS.Operational.DirectPrint.DirectPrint Print = new RIS.Operational.DirectPrint.DirectPrint();
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    DataTable dtPreTemp = ((DataTable)grdPreTemplate.DataSource).Copy();
                    Print.PrintOpNote(dtPreTemp);
                    break;
                case 1:
                    DataTable dtPostTemp = ((DataTable)grdPostTemplate.DataSource).Copy();
                    DataTable dtPostTempC = (DataTable)grdPostC.DataSource;
                    foreach (DataRow dr in dtPostTempC.Rows)
                    {
                        DataRow dr_add = dtPostTemp.NewRow();
                        dr_add.ItemArray = dr.ItemArray;
                        dtPostTemp.Rows.Add(dr_add);
                        dtPostTemp.AcceptChanges();
                    }
                    Print.PrintOpNote(dtPostTemp);
                    break;
                default:
                    break;
            }

        }

        private void barSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID) == "1")
                return;
            else
            {
                Save();
                Print();
            }
        }

    }
}