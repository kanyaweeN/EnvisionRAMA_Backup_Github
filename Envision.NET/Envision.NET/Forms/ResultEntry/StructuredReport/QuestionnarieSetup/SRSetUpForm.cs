using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using Envision.BusinessLogic;
using DevExpress.XtraEditors;
using System.Collections;
using System.Linq;


using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.NET.Forms.Dialog;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.HeplerClasses;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls;

using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child;
//using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup
{
    public partial class SRSetUpForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private enum Moves
        {
            Up, Down
        }
        public const string MT_MASTER_ID = "ID";
        public const string MT_PART_NAME = "PART_NAME";
        public const string MT_QA = "QA";
        public const string MT_SL_NO = "SL_NO";

        public const string DT_PARENT_ID = "P_ID";
        public const string DT_DETAIL_ID = "ID";
        public const string DT_QUESTION_TEXT = "QUESTION_TEXT";
        public const string DT_CONTROL_TYPE = "CTR_TYPE";
        public const string DT_FONT_STYLE = "FONT_STYLE";
        public const string DT_SPACEING = "SP";
        public const string DT_IS_APPEND = "IS_APPEND";
        public const string DT_LAYOUT = "LAYOUT";
        public const string DT_SL_NO = "SL_NO";

        private const string DT_PARENT_NAME = "Master";
        private const string DT_CHILD_NAME = "Detail";

        private DataView dvExamType;
        private DataView dvExam;
        private DataView dvBody;

        private DevExpress.XtraGrid.Views.Grid.GridView gridViewChild;
        private DevExpress.XtraGrid.GridLevelNode gridLevel1;
        private RepositoryItemImageComboBox repImageCb;
        private DataSet dsGridData;
        private GridView _selectedGridView;
        private DataRow CurrentChildDataRow = null;
        private DataRow CurrentParentDataRow = null;
        private DataSet _bpDsGridData;
        private ItemMapperCollection _itemCollection;
        private SRSetUpManagement srManager;
        private int masterFocusRow = 0;
        private int detailFocusRow = 0;
        private int RowCount = -1;
        private int RowDetailCount = -1;
        private int templateId = 0;
        private bool isEditorValueChanged = false;
        private ItemMapperCollection _bpItemCollection;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private int OrgId = 0;
        private int UserId = 0;
        private List<int> deleteIdList = new List<int>();

        public bool IsDuplicateMode = false;

        public SRSetUpForm(int templateId)
        {
            InitializeComponent();
            this.templateId = templateId;
            this.OrgId = env.OrgID;
            this.UserId = env.UserID;
            this._itemCollection = new ItemMapperCollection();
            this.srManager = new SRSetUpManagement();

            this.Load += new EventHandler(MyForm_Load);
            this.ribbon.SelectedPageChanged += new EventHandler(ribbon_SelectedPageChanged);
            //Temple Setup
            this.grlExam.Validated += new EventHandler(grlExam_Validated);
        }

        public SRSetUpForm() : this(0) { }

        private void MyForm_Load(object sender, EventArgs e)
        {
            this.InitialDataGrid();
            this._selectedGridView = this.gridViewParent; //set first select view
            this.initializeControlFirst();
            this.dsGridData = this.BuildSchemaDataSet(); // Create DataSet
            if (templateId == 0)
            {
                this.InitialDataSet();
            }
            else
            {
                this.LoadTemplateData();
            }
            this.gridControl1.DataSource = this.dsGridData.Tables[DT_PARENT_NAME];
            this.InitialEditors();
            this.propertyGrid1.SelectedObject = null;
            this.SortSlNo();

            if (IsDuplicateMode)
            {
                txtTemplate.Text += " (Copy)";
                txtCreator.Text = env.FirstName + ' ' + env.LastName;
                txtDateCreate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            }
            
            this._selectedGridView.MoveFirst(); //set move first when sorted
            this.txtTemplate.Focus();
        }

        #region Templete SetUp
        private void initializeControlFirst()
        {
            txtCreator.Text = env.FirstName + " " + env.LastName;
           // txtCreator.Text = "charleomkiat munkong";
            txtDateCreate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            loadLanguage();
            loadExamType();
            loadExamName();
            loadBodySystem();
            //updateExamType();
            //updateBodyPart();
        }

        private void grlExam_Validated(object sender, EventArgs e)
        {
            if (templateId == 0)
            {
                updateExamType();
                updateBodyPart();
            }
        }

        private void updateBodyPart()
        {
            if (!string.IsNullOrEmpty(this.grlExam.EditValue.ToString()))
            {
                dvExam.RowFilter = "EXAM_ID=" + grlExam.EditValue.ToString();
                if (dvExam.ToTable().Rows.Count > 0)
                {
                    string bp_id = dvExam.ToTable().Rows[0]["BP_ID"].ToString();
                    if (!string.IsNullOrEmpty(bp_id))
                    {
                        bool flag = false;
                        dvBody.RowFilter = "IS_DELETED='N' and BP_ID=" + bp_id;
                        if (dvBody.ToTable().Rows.Count > 0)
                        {
                            DataTable dtt = dvBody.ToTable();
                            dvBody = new DataView(dtt);
                            flag = true;
                        }
                        else
                            loadBodySystem();
                        bindBodyPart();
                        if(flag)
                            grlBody.EditValue = dvBody.ToTable().Rows[0]["BP_ID"].ToString();
                    }
                }
                dvExam.RowFilter = "IS_ACTIVE='Y'";
                dvExam.Sort = "EXAM_UID asc";
            }
        }

        private void updateExamType()
        {
            if (!string.IsNullOrEmpty(this.grlExam.EditValue.ToString()))
            {
                dvExam.RowFilter = "EXAM_ID=" + grlExam.EditValue.ToString();
                if (dvExam.ToTable().Rows.Count > 0)
                {
                    string type_id = dvExam.ToTable().Rows[0]["EXAM_TYPE"].ToString();
                    txtExamType.Text = string.Empty;
                    if (!string.IsNullOrEmpty(type_id))
                    {
                        dvExamType.RowFilter = "EXAM_TYPE_ID=" + type_id;
                        if (dvExamType.ToTable().Rows.Count > 0)
                            txtExamType.Text = dvExamType.ToTable().Rows[0]["EXAM_TYPE_TEXT"].ToString().Trim();
                        dvExamType.RowFilter = string.Empty;
                    }
                }
                dvExam.RowFilter = "IS_ACTIVE='Y'";
                dvExam.Sort = "EXAM_UID asc";
            }
        }

        private void loadExamName()
        {
            DataTable dtt = RISBaseData.Ris_Exam();
            dtt.Columns.Add("EXAM", typeof(string));
            foreach (DataRow row in dtt.Rows)
                row["EXAM"] = row["EXAM_UID"].ToString() + " : " + row["EXAM_NAME"].ToString();
            dtt.AcceptChanges();
            dvExam = new DataView(dtt);
            //dvExam = new DataView(RISBaseData.Ris_Exam());

            dvExam.RowFilter = "IS_ACTIVE='Y'";
            dvExam.Sort = "EXAM_UID asc";
            grlExam.Properties.DisplayMember = "EXAM";//EXAM_NAME
            grlExam.Properties.ValueMember = "EXAM_ID";
            grlExam.Properties.DataSource = dvExam;
            for (int i = 0; i < dvExam.Table.Columns.Count; i++)
                grlExam.Properties.View.Columns[i].Visible = false;
            grlExam.Properties.View.Columns["EXAM_UID"].Visible = true;
            grlExam.Properties.View.Columns["EXAM_UID"].Caption = "Code";
            grlExam.Properties.View.Columns["EXAM_NAME"].Visible = true;
            grlExam.Properties.View.Columns["EXAM_NAME"].Caption = "Exam Name";
            grlExam.EditValue = string.Empty;
        }

        private void loadBodySystem()
        {

            dvBody = new DataView(srManager.GetBodySystem());
            //dvBody.RowFilter = "IS_DELETED='N'";
            bindBodyPart();
            grlBody.EditValue = string.Empty;
        }

        private void bindBodyPart()
        {
            grlBody.Properties.DisplayMember = "BP_DESC";
            grlBody.Properties.ValueMember = "BP_ID";
            grlBody.Properties.DataSource = dvBody;
            for (int i = 0; i < dvBody.Table.Columns.Count; i++)
                grlBody.Properties.View.Columns[i].Visible = false;
            grlBody.Properties.View.Columns["BP_DESC"].Visible = true;
            grlBody.Properties.View.Columns["BP_DESC"].Caption = "Body Part";
        }

        private void loadExamType()
        {
            dvExamType = new DataView(srManager.GetExamType());
        }

        private void loadLanguage()
        {
            DataTable dttLang = srManager.GetLanguage();
            DataView dvLang = new DataView(dttLang);
            grlLanguage.Properties.DisplayMember = "LANG_NAME";
            grlLanguage.Properties.ValueMember = "LANG_ID";
            grlLanguage.Properties.DataSource = dvLang;

            for (int i = 0; i < dttLang.Columns.Count; i++)
                grlLanguage.Properties.View.Columns[i].Visible = false;

            grlLanguage.Properties.View.Columns["LANG_UID"].Visible = true;
            grlLanguage.Properties.View.Columns["LANG_UID"].Caption = "Code";
            grlLanguage.Properties.View.Columns["LANG_NAME"].Visible = true;
            grlLanguage.Properties.View.Columns["LANG_NAME"].Caption = "Language";
            grlLanguage.EditValue = 1;
        }

        #endregion

        #region  Ribbon Toolsbar Event
        /// <summary>
        /// Select page change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            if (this.ribbon.SelectedPage == this.ribbonPage1)
            {
                this.tabControl1.SelectedTabPageIndex = 0;
            }
            else
                this.tabControl1.SelectedTabPageIndex = 1;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (IsDuplicateMode) templateId = 0;

            this._selectedGridView.CloseEditor();
            this._selectedGridView.UpdateCurrentRow();
            if (txtTemplate.Text.Trim().Length == 0)
            {
                ribbon.SelectedPage = this.ribbonPage1;
                txtTemplate.Focus();
                return;
            }
            if (string.IsNullOrEmpty(grlExam.EditValue.ToString()))
            {
                msg.ShowAlert("UID4007", env.CurrentLanguageID);
                return;
            }
            if (msg.ShowAlert("UID1405", env.CurrentLanguageID) == "1")
                return;
            
            Envision.Common.SR_TEMPLATE templeteCommon = new Envision.Common.SR_TEMPLATE();
            templeteCommon.BP_ID = string.IsNullOrEmpty(grlBody.EditValue.ToString()) ? 0 : Convert.ToInt32(grlBody.EditValue.ToString());
            templeteCommon.DESCRIPTION = txtDesc.Text.Trim();
            templeteCommon.EXAM_ID = Convert.ToInt32(grlExam.EditValue);
            templeteCommon.IS_ACTIVE = chkActive.Checked ? "Y" : "N";
            templeteCommon.LANG_ID = Convert.ToInt32(grlLanguage.EditValue.ToString());
            templeteCommon.ORG_ID = this.OrgId;
            templeteCommon.RSNA_URL = txtUrl.Text.Trim();
            templeteCommon.TEMPLATE_NAME = txtTemplate.Text;
            templeteCommon.USER_ID = this.UserId;
            if (this.templateId == 0)
            {
                bool result = srManager.SaveTemplate(ref templeteCommon, this.dsGridData, this._itemCollection);
                if (result)
                {
                    this.templateId = templeteCommon.TEMPLATE_ID;
                    if (chkActive.Checked)
                    {
                        string is_default = "N";
                        if (msg.ShowAlert("UID1410", env.CurrentLanguageID) == "2")
                            is_default = "Y";
                        DataTable dttEmp = RISBaseData.Ris_Radiologist();
                        int exam_id = Convert.ToInt32(grlExam.EditValue.ToString());
                        foreach (DataRow rowHandle in dttEmp.Rows)
                        {
                            ProcessAddSRUserPreference procUsr = new ProcessAddSRUserPreference();
                            procUsr.SR_USERPREFERENCE.EMP_ID = Convert.ToInt32(rowHandle["EMP_ID"].ToString());
                            procUsr.SR_USERPREFERENCE.EXAM_ID = exam_id;
                            if (procUsr.SR_USERPREFERENCE.EMP_ID == env.UserID)
                                procUsr.SR_USERPREFERENCE.IS_DEFAULT = is_default;
                            else
                                procUsr.SR_USERPREFERENCE.IS_DEFAULT = "N";
                            procUsr.SR_USERPREFERENCE.STATUS = "Y";
                            procUsr.SR_USERPREFERENCE.TEMPLATE_ID = templateId;
                            procUsr.AddDefault();
                        }
                    }
                }
            }
            else
            {
                templeteCommon.TEMPLATE_ID = this.templateId;
                bool result = srManager.UpdateTemplate(ref templeteCommon, this.dsGridData, this._itemCollection
                    , this._bpDsGridData, this._bpItemCollection, this.deleteIdList);
            }
            this.Close();
        }
        /// <summary>
        /// Button Close Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Move Row Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveDown_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.PrepareDataForMoveGridRow(Moves.Down);
        }

        /// <summary>
        /// Move Row Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.PrepareDataForMoveGridRow(Moves.Up);
        }

        /// <summary>
        /// Clear All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            if("2" != msg.ShowAlert("UID6053", env.CurrentLanguageID))
                return;
            this.grlExam.EditValue = dvExam.Table.Rows[0]["EXAM_ID"].ToString();
            this.grlLanguage.EditValue = 1;
            this.grlBody.EditValue = dvBody.ToTable().Rows[0]["BP_ID"].ToString();
            this.updateBodyPart();
            this.updateExamType();
            this.txtDesc.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
            this.txtTemplate.Text = string.Empty;
            this.chkActive.Checked = false;
            this.dsGridData = null;
            this.dsGridData = this.BuildSchemaDataSet();
            this.gridControl1.DataSource = this.dsGridData.Tables[DT_PARENT_NAME];
            this._itemCollection.Clear();
            this.InitialDataSet();
        }
        #endregion

        #region Initialize
        /// <summary>
        /// Initial Editors
        /// </summary>
        private void InitialEditors()
        {
            this.btnClose.ItemClick += new ItemClickEventHandler(btnClose_ItemClick);
            this.btnClearAll.ItemClick += new ItemClickEventHandler(btnClearAll_ItemClick);
            this.btnMoveUp.ItemClick += new ItemClickEventHandler(btnMoveUp_ItemClick);
            this.btnMoveDown.ItemClick += new ItemClickEventHandler(btnMoveDown_ItemClick);
            this.btnSave.ItemClick += new ItemClickEventHandler(btnSave_ItemClick);
            this.txtCreator.KeyDown += new KeyEventHandler(My_KeyDown);
            this.txtDateCreate.KeyDown += new KeyEventHandler(My_KeyDown);
            //this.txtDesc.KeyDown += new KeyEventHandler(My_KeyDown);
            this.txtExamType.KeyDown += new KeyEventHandler(My_KeyDown);
            this.txtTemplate.KeyDown += new KeyEventHandler(My_KeyDown);
            this.txtUrl.KeyDown += new KeyEventHandler(My_KeyDown);
            this.chkActive.KeyDown += new KeyEventHandler(My_KeyDown);
            this.grlBody.KeyDown += new KeyEventHandler(My_KeyDown);
            this.grlExam.KeyDown += new KeyEventHandler(My_KeyDown);
            this.grlLanguage.KeyDown += new KeyEventHandler(My_KeyDown);
            //this.grlExam.CloseUp += new CloseUpEventHandler(grlExam_CloseUp);
            this.grlExam.EditValueChanged += new EventHandler(grlExam_EditValueChanged);
            this.btnNext.Click += new EventHandler(btnNext_Click);
        }



        /// <summary>
        /// initial data to dataset
        /// </summary>
        private void InitialDataSet()
        {
            //Master
            DataRow dr = this.dsGridData.Tables[DT_PARENT_NAME].NewRow();
            dr["ID"] = 1;
            dr["PART_NAME"] = "PROCEDURE : ";
            dr["QA"] = 0;
            dr["SL_NO"] = 1;
            this.dsGridData.Tables[DT_PARENT_NAME].Rows.Add(dr);
            //add new datarow detail
            //this.AddNewRowToDetailDataTable(Convert.ToInt32(dr["ID"]));

            DataRow dr1 = this.dsGridData.Tables[DT_PARENT_NAME].NewRow();
            dr1["ID"] = 2;
            dr1["PART_NAME"] = "CLINICAL : ";
            dr1["QA"] = 0;
            dr1["SL_NO"] = 2;
            this.dsGridData.Tables[DT_PARENT_NAME].Rows.Add(dr1);
            //add new datarow detail
            //this.AddNewRowToDetailDataTable(Convert.ToInt32(dr1["ID"]));

            DataRow dr2 = this.dsGridData.Tables[DT_PARENT_NAME].NewRow();
            dr2["ID"] = 3;
            dr2["PART_NAME"] = "COMPARISON : ";
            dr2["QA"] = 0;
            dr2["SL_NO"] = 3;
            this.dsGridData.Tables[DT_PARENT_NAME].Rows.Add(dr2);
            //add new datarow detail
            //this.AddNewRowToDetailDataTable(Convert.ToInt32(dr2["ID"]));

            DataRow dr3 = this.dsGridData.Tables[DT_PARENT_NAME].NewRow();
            dr3["ID"] = 4;
            dr3["PART_NAME"] = "FINDINGS : ";
            dr3["QA"] = 0;
            dr3["SL_NO"] = 4;
            this.dsGridData.Tables[DT_PARENT_NAME].Rows.Add(dr3);
            //add new datarow detail
            //this.AddNewRowToDetailDataTable(Convert.ToInt32(dr3["ID"]));

            DataRow dr4 = this.dsGridData.Tables[DT_PARENT_NAME].NewRow();
            dr4["ID"] = 5;
            dr4["PART_NAME"] = "IMPRESSION : ";
            dr4["QA"] = 0;
            dr4["SL_NO"] = 5;
            this.dsGridData.Tables[DT_PARENT_NAME].Rows.Add(dr4);
            //add new datarow detail
            //this.AddNewRowToDetailDataTable(Convert.ToInt32(dr4["ID"]));
        }
        /// <summary>
        /// Add datarow detail
        /// </summary>
        /// <param name="p"></param>
        private void AddNewRowToDetailDataTable(int parentId)
        {
            //int lastId = dsGridData.Tables[DT_CHILD_NAME].Rows.Count;
            DataRow dr = this.dsGridData.Tables[DT_CHILD_NAME].NewRow();
            dr[DT_PARENT_ID] = parentId;
            dr[DT_DETAIL_ID] = RowDetailCount;
            dr[DT_QUESTION_TEXT] = string.Empty;
            dr[DT_CONTROL_TYPE] = 1;
            dr[DT_FONT_STYLE] = string.Empty;
            dr[DT_SPACEING] = 0;
            dr[DT_IS_APPEND] = "N";
            dr[DT_LAYOUT] = "Horizontal";
            dr[DT_SL_NO] = RowDetailCount;
            this.dsGridData.Tables[DT_CHILD_NAME].Rows.Add(dr);
            //this.UpdateQA(drParent, 1);
            this.MappingItem(dr, 1);
            RowCount--;
            RowDetailCount--;
        }
        /// <summary>
        /// this method use to create dataset schema
        /// </summary>
        /// <returns></returns>
        private DataSet BuildSchemaDataSet()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add(DT_PARENT_NAME);
            dt.Columns.Add(MT_MASTER_ID, typeof(int));
            dt.Columns.Add(MT_PART_NAME, typeof(string));
            dt.Columns.Add(MT_QA, typeof(int));
            dt.Columns.Add(MT_SL_NO, typeof(int));
            dt.AcceptChanges();

            DataTable dt2 = ds.Tables.Add(DT_CHILD_NAME);
            dt2.Columns.Add(DT_PARENT_ID, typeof(int));
            dt2.Columns.Add(DT_DETAIL_ID, typeof(int));
            dt2.Columns.Add(DT_QUESTION_TEXT, typeof(string));
            dt2.Columns.Add(DT_CONTROL_TYPE, typeof(int));
            dt2.Columns.Add(DT_FONT_STYLE, typeof(string));
            dt2.Columns.Add(DT_SPACEING, typeof(int));
            dt2.Columns.Add(DT_IS_APPEND, typeof(string));
            dt2.Columns.Add(DT_LAYOUT, typeof(string));
            dt2.Columns.Add(DT_SL_NO, typeof(int));
            dt2.AcceptChanges();

            ds.Relations.Add(new DataRelation("myRelation", dt.Columns[MT_MASTER_ID], dt2.Columns[DT_PARENT_ID]));
            return ds;
        }
        /// <summary>
        /// Initial DataGrid Column for Binding
        /// </summary>
        private void InitialDataGrid()
        {
            #region Grid Control
            this.gridControl1.FocusedViewChanged += new ViewFocusEventHandler(gridControl1_FocusedViewChanged);
            #endregion

            #region Parent Grid

            RepositoryItemTextEdit repTextbox_PN = new RepositoryItemTextEdit();
            repTextbox_PN.Name = "Part_TextBox";
            repTextbox_PN.KeyDown += new KeyEventHandler(repTextbox_PN_KeyDown);

            GridColumn cols_sl_no = new GridColumn();
            cols_sl_no.Name = "COLS_SL_NO";
            cols_sl_no.FieldName = "SL_NO";
            cols_sl_no.Visible = false;

            GridColumn cols_pn = new GridColumn();
            cols_pn.Name = "COLS_PART_NAME";
            cols_pn.FieldName = "PART_NAME";
            cols_pn.Caption = "Part Name";
            cols_pn.ColumnEdit = repTextbox_PN;
            cols_pn.Visible = true;
            cols_pn.VisibleIndex = 1;
            cols_pn.Width = 250;
            cols_pn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            GridColumn cols_qa = new GridColumn();
            cols_qa.Name = "COLS_QA";
            cols_qa.FieldName = "QA";
            cols_qa.Caption = "QA";
            cols_qa.Visible = true;
            cols_qa.VisibleIndex = 2;
            cols_qa.OptionsColumn.ReadOnly = true;
            cols_qa.OptionsColumn.AllowEdit = false;
            cols_qa.Width = 20;
            cols_qa.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            #region button column

            // Btn Del
            RepositoryItemButtonEdit repBtn_del = new RepositoryItemButtonEdit();
            repBtn_del.Name = "ButtonDelete";
            repBtn_del.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //repBtn_del.Buttons.Clear();
            repBtn_del.Buttons[0].Kind = ButtonPredefines.Delete;
            repBtn_del.ButtonClick += new ButtonPressedEventHandler(repBtn_del_ButtonClick);
            GridColumn cols_del = new GridColumn();
            cols_del.Name = "COLS_DEL";
            cols_del.ColumnEdit = repBtn_del;
            cols_del.VisibleIndex = 3;
            cols_del.Visible = true;
            cols_del.Width = 16;
            cols_del.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            #endregion

            this.gridViewParent.Columns.AddRange(new GridColumn[] { 
                cols_sl_no, cols_pn, cols_qa, cols_del
            });
            this.gridViewParent.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewParent.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gridViewParent.OptionsDetail.ShowDetailTabs = false; //hide tab form detail
            this.gridViewParent.OptionsDetail.SmartDetailExpand = true;
            this.gridViewParent.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewParent.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
            this.gridViewParent.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewParent.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gridViewParent_InitNewRow);
            this.gridViewParent.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridViewParent_ValidateRow);
            this.gridViewParent.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewParent_FocusedRowChanged);
            #endregion

            #region Child Grid
            this.gridViewChild = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridViewChild.Name = "gridViewChild";
            this.gridViewChild.OptionsView.ShowGroupPanel = false;
            this.gridViewChild.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewChild.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gridViewChild.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gridViewChild_InitNewRow);
            this.gridViewChild.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewChild.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewChild_FocusedRowChanged);
            this.gridViewChild.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridViewChild_CellValueChanging);
            this.gridViewChild.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridViewChild_ValidateRow);
            this.gridViewChild.GridControl = this.gridControl1;
            GridColumn cCols_Id = new GridColumn();
            cCols_Id.Name = "CCOLS_ID";
            cCols_Id.FieldName = "ID";

            GridColumn cCols_slNo = new GridColumn();
            cCols_slNo.FieldName = "SL_NO";
            cCols_Id.Name = "CCOLS_SL_NO";
            cCols_slNo.Visible = false;
            //cCols_slNo.VisibleIndex = 1;

            QuestionTypeCollection questionTypeCollection = this.srManager.GetQuestionTypes(1);
            this.repImageCb = new RepositoryItemImageComboBox();
            this.repImageCb.SmallImages = this.TypeSmallImages;
            //Add Item
            if (questionTypeCollection.Count > 0)
            {
                for (int i = 0; i < questionTypeCollection.Count; i++)
                    this.repImageCb.Items.Add(new ImageComboBoxItem(questionTypeCollection[i].Q_TYPE_DESC, i + 1, questionTypeCollection[i].Q_TPYE_ID));
            }

            this.repImageCb.SelectedIndexChanged += new EventHandler(repImageCb_SelectedIndexChanged);

            GridColumn cCols_ControlType = new GridColumn();
            cCols_ControlType.Name = "CCOLS_CONTROL_TYPE";
            cCols_ControlType.FieldName = "CTR_TYPE";
            cCols_ControlType.Caption = "Question Type";
            cCols_ControlType.ColumnEdit = repImageCb;
            cCols_ControlType.Visible = true;
            cCols_ControlType.VisibleIndex = 1;
            cCols_ControlType.Width = 100;
            cCols_ControlType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemTextEdit repTextbox_QT = new RepositoryItemTextEdit();
            repTextbox_QT.Name = "QuestionText_TextBox";
            repTextbox_QT.KeyDown += new KeyEventHandler(repTextbox_QT_KeyDown);

            GridColumn cCols_QT = new GridColumn();
            cCols_QT.Name = "CCOLS_QUESTION_TEXT";
            cCols_QT.ColumnEdit = repTextbox_QT;
            cCols_QT.FieldName = "QUESTION_TEXT";
            cCols_QT.Caption = "Question Text";
            cCols_QT.Visible = true;
            cCols_QT.VisibleIndex = 0;
            cCols_QT.Width = 180;
            cCols_QT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemCheckedComboBoxEdit repCheckCb_FontStyle = new RepositoryItemCheckedComboBoxEdit();
            repCheckCb_FontStyle.Name = "CheckComboBoxFontStyle";
            repCheckCb_FontStyle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repCheckCb_FontStyle.Items.Add("0", "Bold");
            repCheckCb_FontStyle.Items.Add("1", "Italic");
            repCheckCb_FontStyle.Items.Add("2", "Underline");

            GridColumn cCxols_fs = new GridColumn();
            cCxols_fs.Name = "COLS_FS";
            cCxols_fs.FieldName = "FONT_STYLE";
            cCxols_fs.Caption = "Text Style";
            cCxols_fs.ColumnEdit = repCheckCb_FontStyle;
            cCxols_fs.Visible = true;
            cCxols_fs.VisibleIndex = 2;
            cCxols_fs.Width = 50;
            cCxols_fs.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemSpinEdit repSpinEdit_Spacing = new RepositoryItemSpinEdit();
            repSpinEdit_Spacing.Name = "SpinEditSpacing";
            repSpinEdit_Spacing.MinValue = 0;
            repSpinEdit_Spacing.MaxValue = 50;

            GridColumn cCols_sp = new GridColumn();
            cCols_sp.Name = "COLS_SP";
            cCols_sp.FieldName = "SP";
            cCols_sp.Caption = "Space";
            cCols_sp.ColumnEdit = repSpinEdit_Spacing;
            cCols_sp.Visible = true;
            cCols_sp.VisibleIndex = 3;
            cCols_sp.Width = 40;
            cCols_sp.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemCheckEdit repCheckBox = new RepositoryItemCheckEdit();
            repCheckBox.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            repCheckBox.ValueChecked = "Y";
            repCheckBox.ValueUnchecked = "N";

            GridColumn cCols_ap = new GridColumn();
            cCols_ap.Name = "COLS_AP";
            cCols_ap.FieldName = "IS_APPEND";
            cCols_ap.ColumnEdit = repCheckBox;
            cCols_ap.Caption = "Append";
            cCols_ap.Visible = true;
            cCols_ap.VisibleIndex = 4;
            cCols_ap.Width = 40;
            cCols_ap.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemComboBox repCb = new RepositoryItemComboBox();
            repCb.Name = "LayoutCombobox";
            repCb.Items.Add("Horizontal");
            repCb.Items.Add("Vertical");

            GridColumn cCols_Layout = new GridColumn();
            cCols_Layout.Name = "COLS_LAYOUT";
            cCols_Layout.FieldName = "LAYOUT";
            cCols_Layout.Caption = "Layout";
            cCols_Layout.ColumnEdit = repCb;
            cCols_Layout.VisibleIndex = 5;
            cCols_Layout.Visible = true;
            cCols_Layout.Width = 50;
            cCols_Layout.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            // Btn Del
            RepositoryItemButtonEdit repBtn_cDel = new RepositoryItemButtonEdit();
            repBtn_cDel.Name = "ButtonCDelete";
            repBtn_cDel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //repBtn_cDel.Buttons.Clear();
            repBtn_cDel.Buttons[0].Kind = ButtonPredefines.Delete;
            repBtn_cDel.ButtonClick += new ButtonPressedEventHandler(repBtn_cDel_ButtonClick);
            GridColumn cols_cDel = new GridColumn();
            cols_cDel.Name = "COLS_DEL";
            cols_cDel.ColumnEdit = repBtn_cDel;
            cols_cDel.OptionsColumn.AllowEdit = true;
            cols_cDel.OptionsColumn.ReadOnly = false;
            cols_cDel.VisibleIndex = 6;
            cols_cDel.Visible = true;
            cols_cDel.Width = 16;
            cols_del.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            


            this.gridViewChild.Columns.AddRange(new GridColumn[]{
                cCols_slNo, cCols_Id, cCols_ControlType, cCols_QT, cCxols_fs, cCols_sp, cCols_ap, cCols_Layout, cols_cDel
            });

            this.gridLevel1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridLevel1.LevelTemplate = this.gridViewChild;
            this.gridLevel1.RelationName = "myRelation";

            this.gridControl1.LevelTree.Nodes.Add(this.gridLevel1);
            this.gridControl1.ViewCollection.Add(this.gridViewChild);

            #endregion
        }

        private void BackUpData()
        {
            //copy dataset
            this._bpDsGridData = this.dsGridData.Copy();
            //Copy collection
            this._bpItemCollection = new ItemMapperCollection();
            for (int i = 0; i < this._itemCollection.Count; i++)
            {
                this._bpItemCollection.Add(new ItemMapper()
                {
                    Control = this.CreateBackUpControl(this._itemCollection[i].Control, this._itemCollection[i].ControlType),
                    ControlType = this._itemCollection[i].ControlType,
                    Row = this._bpDsGridData.Tables[1].Rows[i]
                });
            }
        }

        private void LoadTemplateData()
        {
            //load data form database
            Envision.Common.SR_TEMPLATE _templateData = new Envision.Common.SR_TEMPLATE();
            this.srManager.LoadTemplateSetUp(this.templateId, ref _templateData, ref this.dsGridData, ref this._itemCollection);
            this.BackUpData(); //backup
            //set data to form
            // Fill Template
            this.txtTemplate.Text = _templateData.TEMPLATE_NAME;
            this.chkActive.Checked = _templateData.IS_ACTIVE == "Y" ? true : false;
            this.grlExam.EditValue = _templateData.EXAM_ID.ToString();
            this.grlBody.EditValue = _templateData.BP_ID.ToString();
            this.updateExamType();
            this.txtDesc.Text = _templateData.DESCRIPTION;
            this.txtUrl.Text = _templateData.RSNA_URL;
            this.grlLanguage.EditValue = _templateData.LANG_ID.ToString();
            this.txtCreator.Text = _templateData.CREATOR;
            this.txtDateCreate.Text = _templateData.CREATED_ON.ToString("dd/MM/yyyy hh:mm");
            //
        }
        #endregion

        #region Key Down
        private void repTextbox_PN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.gridViewParent.FocusedRowHandle = this.dsGridData.Tables[DT_PARENT_NAME].Rows.Count - 1;
                this.gridViewParent.MoveNext();
                this.gridViewParent.MoveNext();
                e.Handled = true;
            }
        }

        private void repTextbox_QT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.masterFocusRow >= 0)
                {
                    GridView gv = this.gridViewParent.GetDetailView(this.masterFocusRow, 0) as GridView;
                    //gv.MoveNext();
                    if (gv.FocusedRowHandle == 0)
                    {
                        gv.MoveNext();
                        gv.MovePrev();
                        gv.FocusedColumn = gv.VisibleColumns[1];
                    }
                    else
                    {
                        int fc = gv.FocusedRowHandle;
                        gv.FocusedRowHandle = -1;
                        gv.FocusedRowHandle = fc;
                        //gv.FocusedColumn = gv.VisibleColumns[0];
                        gv.MovePrev();
                        gv.FocusedColumn = gv.VisibleColumns[1];
                    }
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region Delete Row Event
        /// <summary>
        /// Master Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repBtn_del_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DataRow drParentRow = this._selectedGridView.GetFocusedDataRow();
            if (this._selectedGridView.FocusedRowHandle >= 0)
            {
                string parentId = drParentRow[MT_MASTER_ID].ToString();
                List<ItemMapper> tempList = new List<ItemMapper>();
                foreach (ItemMapper item in this._itemCollection)
                {
                    if (item.Row[DT_PARENT_ID].ToString() == parentId)
                        tempList.Add(item);
                }
                if (tempList.Count > 0)
                {
                    foreach (ItemMapper item2 in tempList)
                        this._itemCollection.Remove(item2);

                }
                tempList = null;
                int id = Convert.ToInt32(drParentRow[MT_MASTER_ID]);
                if (!this.deleteIdList.Contains(id))
                    this.deleteIdList.Add(id);
                drParentRow.Delete();
                this.UpdateSlNo(drParentRow, false);
            }
        }
        /// <summary>
        /// Detail Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repBtn_cDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this._selectedGridView.FocusedRowHandle >= 0)
            {
                DataRow dr = this._selectedGridView.GetFocusedDataRow();
                ItemMapper item = null;
                foreach (ItemMapper tmm in this._itemCollection)
                {
                    if (tmm.Row == dr)
                    {
                        item = tmm;
                        this._itemCollection.Remove(item);
                        DataRow drParent = this.gridViewParent.GetDataRow(this._selectedGridView.SourceRowHandle);
                        //if(dr[DT_QUESTION_TEXT].ToString() != string.Empty)
                        this.UpdateQA(drParent, -1);
                        dr.Delete();
                        this.UpdateSlNo(drParent, true);
                        //DataRow[] drParentRows = this.dsGridData.Tables[DT_CHILD_NAME].Select(DT_PARENT_ID + " = '" + drParent[MT_MASTER_ID].ToString() + "'");
                        //if (drParentRows.Length == 0)
                        //    drParent.Delete();
                        break;
                    }
                }
            }
        }

        private void UpdateSlNo(DataRow drParent, bool isDetailView)
        {
            if (isDetailView)
            {
                DataRow[] dtlRows = this.dsGridData.Tables[DT_CHILD_NAME].Select(DT_PARENT_ID + " = '" + drParent[MT_MASTER_ID] + "'", DT_SL_NO + " ASC");
                for (int i = 0; i < dtlRows.Length; i++)
                {
                    dtlRows[i]["SL_NO"] = i + 1;
                }
                this.SortSlNo();
            }
            else
            {
                dsGridData.AcceptChanges();

                for (int i = 0; i < dsGridData.Tables[DT_PARENT_NAME].Rows.Count; i++ )
                {
                    dsGridData.Tables[DT_PARENT_NAME].Rows[i][MT_SL_NO] = i + 1;
                }
                this.SortSlNo();
            }
        }
        #endregion

        #region Focus View Changed
        private void gridControl1_FocusedViewChanged(object sender, ViewFocusEventArgs e)
        {
            this._selectedGridView = e.View as GridView; //get selected grid view
            //Check null
            if (_selectedGridView == null)
                return;

            if (e.View.Name == "gridViewParent")
            {
                this.groupMoveRow.Visible = true;
                this.masterFocusRow = this._selectedGridView.FocusedRowHandle;
                this.propertyGrid1.SelectedObject = null;
            }

            else if (e.View.Name == "gridViewChild")
            {
                this.groupMoveRow.Visible = false;
                this.masterFocusRow = this._selectedGridView.SourceRowHandle;
                this.detailFocusRow = this._selectedGridView.FocusedRowHandle;
                DataRow dr = _selectedGridView.GetDataRow(_selectedGridView.FocusedRowHandle);
                if (dr == null)
                    return;
                foreach (ItemMapper _item in this._itemCollection)
                {
                    if (_item.Row == dr)
                    {
                        this.propertyGrid1.SelectedObject = _item.Control;
                        break;
                    }
                }
            }
        }
        #endregion

        #region Focus Row changed
        /// <summary>
        /// Grid Detail focusrowchange Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewChild_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.CurrentChildDataRow = (sender as GridView).GetFocusedDataRow();
            if (this.CurrentChildDataRow != null)
            {
                if (this.CurrentChildDataRow[DT_CONTROL_TYPE] != null && this.CurrentChildDataRow[DT_CONTROL_TYPE].ToString() != string.Empty)
                {
                    foreach (ItemMapper itemMapper in this._itemCollection)
                    {
                        if (itemMapper.Row == this.CurrentChildDataRow)
                        {
                            this.propertyGrid1.SelectedObject = itemMapper.Control;
                            break;
                        }
                    }
                }
            }
            else
            {
                this.propertyGrid1.SelectedObject = null;
            }
        }
        /// <summary>
        /// Grid parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewParent_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.CurrentParentDataRow = this.gridViewParent.GetFocusedDataRow();
            //if (e.FocusedRowHandle < 0)
            //{
            //    this.btnMoveDown.Enabled = false;
            //    this.btnMoveUp.Enabled = false;
            //}
            //else if (e.FocusedRowHandle == 0)
            //{
            //    this.btnMoveUp.Enabled = false;
            //    this.btnMoveDown.Enabled = true;
            //}
            //else if (e.FocusedRowHandle == this.dsGridData.Tables[DT_PARENT_NAME].Rows.Count - 1)
            //{
            //    this.btnMoveDown.Enabled = false;
            //    this.btnMoveUp.Enabled = true;
            //}
            //else if (e.FocusedRowHandle > 0 && e.FocusedRowHandle < this.dsGridData.Tables[DT_PARENT_NAME].Rows.Count)
            //{
            //    this.btnMoveDown.Enabled = true;
            //    this.btnMoveUp.Enabled = true;
            //}

        }
        #endregion

        #region Event
        private DataRow _currentDataRowByGridChildFocusRow = null;
        private int index;
        /// <summary>
        /// USe to get current focus row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewChild_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            _currentDataRowByGridChildFocusRow = (sender as GridView).GetFocusedDataRow();
            if (e.Value is int)
                index = Convert.ToInt32(e.Value);
        }

        /// <summary>
        /// Control Type Selection changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repImageCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.isEditorValueChanged = true;
            DevExpress.XtraEditors.ImageComboBoxEdit cb = (DevExpress.XtraEditors.ImageComboBoxEdit)sender;
            int _value = Convert.ToInt32(cb.EditValue.ToString());
            //this.TypePropertySelector(_value);

            if (_currentDataRowByGridChildFocusRow != null)
            {
                foreach (ItemMapper itemMapper in this._itemCollection)
                {
                    if (itemMapper.Row == _currentDataRowByGridChildFocusRow)
                    {
                        this.UpdateMappingItem(itemMapper, _value);
                        index = 1;
                        break;
                    }
                }
            }
        }


        private void grlExam_EditValueChanged(object sender, EventArgs e)
        {
            this.updateBodyPart();
            this.updateExamType();
        }

        private void My_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //move to next page
            this.ribbon.SelectedPage = this.ribbonPage2;
        }
        #endregion

        #region Initial & Validate New Row
        private DataRow _newParentDataRow;
        /// <summary>
        /// Initial New Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewParent_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            int lastId = this.dsGridData.Tables[DT_PARENT_NAME].Rows.Count;
            this._newParentDataRow = this.gridViewParent.GetDataRow(e.RowHandle);
            this._newParentDataRow[MT_MASTER_ID] = RowCount;
            //this._newParentDataRow["PART_NAME"] = e.;
            this._newParentDataRow[MT_QA] = 0;
            this._newParentDataRow[MT_SL_NO] = lastId + 1;
        }
        /// <summary>
        /// Validate New Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewParent_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (this.gridViewChild.IsNewItemRow(e.RowHandle))
            {
                this.dsGridData.Tables[DT_PARENT_NAME].Rows.Add(this._newParentDataRow);
                this.dsGridData.Tables[DT_PARENT_NAME].AcceptChanges();
                //this.AddNewRowToDetailDataTable(RowCount);
                RowCount--;
            }
        }
        /// <summary>
        /// Initial New Row For Child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewChild_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow drParent = this.gridViewParent.GetDataRow(this._selectedGridView.SourceRowHandle);
            int lastId = this.dsGridData.Tables[DT_CHILD_NAME].Select(DT_PARENT_ID + " = '" + drParent[MT_MASTER_ID] + "'").Length;
            DataRow dr = (sender as GridView).GetFocusedDataRow();
            if (dr == null)
                return;
            if (index == 0) { index = 1; }
            dr[DT_DETAIL_ID] = RowDetailCount;
            dr[DT_SPACEING] = 0;
            dr[DT_FONT_STYLE] = string.Empty;
            dr[DT_IS_APPEND] = "N";
            dr[DT_LAYOUT] = "Horizontal";
            dr[DT_CONTROL_TYPE] = index;
            dr[DT_SL_NO] = lastId + 1;
            //DataRow drParent = this.gridViewParent.GetDataRow(this._selectedGridView.SourceRowHandle);
            this.MappingItem(dr, index);
            this.UpdateQA(drParent, 1);
            index = 1;
            RowDetailCount--;
        }

        private void gridViewChild_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (!this.isEditorValueChanged)
            {
                DataRow dr = this._selectedGridView.GetDataRow(e.RowHandle);
                if (dr[DT_QUESTION_TEXT].ToString() != string.Empty)
                {
                    DataRow drParent = this.gridViewParent.GetDataRow(this._selectedGridView.SourceRowHandle);
                    //this.UpdateQA(drParent, 1);
                }
                else
                {
                    DataRow drParent = this.gridViewParent.GetDataRow(this._selectedGridView.SourceRowHandle);
                    //this.UpdateQA(drParent, -1);
                }
            }
            else
                this.isEditorValueChanged = false;
        }

        #endregion

        #region Move Data Row
        /// <summary>
        /// This method ues to prepare data for move row
        /// </summary>
        /// <param name="moves">move position</param>
        private void PrepareDataForMoveGridRow(Moves moves)
        {
            if (this._selectedGridView != null)
            {
                if (this._selectedGridView.IsDetailView)
                {
                    int focusRowIndex = this._selectedGridView.FocusedRowHandle;
                    if (moves == Moves.Down)
                    {
                        //Move next
                        DataRow drCurrent = this._selectedGridView.GetFocusedDataRow();
                        this._selectedGridView.MoveNext();
                        if (this._selectedGridView.FocusedRowHandle < 0)
                            this._selectedGridView.MovePrev();
                        DataRow drNext = this._selectedGridView.GetFocusedDataRow();
                        int temp_sl = Convert.ToInt32(drCurrent[DT_SL_NO]);
                        drCurrent[DT_SL_NO] = drNext[DT_SL_NO];
                        drNext[DT_SL_NO] = temp_sl;
                        this.SortSlNo();
                        this._selectedGridView.MoveNext();
                        if (this._selectedGridView.FocusedRowHandle < 0)
                            this._selectedGridView.MovePrev();
                    }
                    else
                    {
                        //Move Prev
                        DataRow drCurrent = this._selectedGridView.GetFocusedDataRow();
                        this._selectedGridView.MovePrev();
                        DataRow drPrev = this._selectedGridView.GetFocusedDataRow();
                        int temp_sl = Convert.ToInt32(drCurrent[DT_SL_NO]);
                        drCurrent[DT_SL_NO] = drPrev[DT_SL_NO];
                        drPrev[DT_SL_NO] = temp_sl;
                        this.SortSlNo();
                        this._selectedGridView.MovePrev();
                    }
                }
                else
                {
                    int focusRowIndex = this._selectedGridView.FocusedRowHandle;
                    if (moves == Moves.Down)
                    {
                        DataRow drCurrent = this._selectedGridView.GetFocusedDataRow();
                        this._selectedGridView.MoveNext();
                        if (this._selectedGridView.FocusedRowHandle < 0)
                            this._selectedGridView.MovePrev();
                        DataRow drNext = this._selectedGridView.GetFocusedDataRow();
                        int temp_sl = Convert.ToInt32(drCurrent[MT_SL_NO]);
                        drCurrent[MT_SL_NO] = drNext[MT_SL_NO];
                        drNext[MT_SL_NO] = temp_sl;
                        this.SortSlNo();
                        this._selectedGridView.MoveNext();
                        if (this._selectedGridView.FocusedRowHandle < 0)
                            this._selectedGridView.MovePrev();
                    }
                    else
                    {
                        //Move Prev
                        DataRow drCurrent = this._selectedGridView.GetFocusedDataRow();
                        this._selectedGridView.MovePrev();
                        DataRow drPrev = this._selectedGridView.GetFocusedDataRow();
                        int temp_sl = Convert.ToInt32(drCurrent[MT_SL_NO]);
                        drCurrent[DT_SL_NO] = drPrev[MT_SL_NO];
                        drPrev[MT_SL_NO] = temp_sl;
                        this.SortSlNo();
                        this._selectedGridView.MovePrev();
                    }
                }
            }
        }

        /// <summary>
        /// This method use to move data row by active data grid view
        /// </summary>
        /// <param name="_selectedDataTable">selected data table</param>
        /// <param name="_focusedRow">focused row</param>
        /// <param name="isParentGrid">is parent grid</param>
        /// <param name="moves">move row</param>
        private void MoveDataRow(DataTable _selectedDataTable, int _focusedRow, bool isParentGrid, Moves moves)
        {
            
        }
        //define temp datarow
        DataRow[] _tempDataRows;
        /// <summary>
        /// This method use to restore child datarow
        /// </summary>
        private void RestoreChildDataRow()
        {
            if (_tempDataRows != null)
            {
                if (_tempDataRows.Length > 0)
                {
                    foreach (DataRow dr in _tempDataRows)
                        this.dsGridData.Tables[DT_CHILD_NAME].Rows.Add(dr);
                }
            }
            _tempDataRows = null;//clear memory
        }
        /// <summary>
        /// This method need to save child data row
        /// </summary>
        /// <param name="parentId"></param>
        private void SaveChildDataRow(int parentId)
        {
            DataRow[] _tempRows = this.dsGridData.Tables[DT_CHILD_NAME].Select(string.Format(DT_PARENT_ID + " = '{0}'", parentId));
            _tempDataRows = new DataRow[_tempRows.Length];
            for (int i = 0; i < _tempRows.Length; i++)
            {
                _tempDataRows[i] = this.dsGridData.Tables[DT_CHILD_NAME].NewRow();
                _tempDataRows[i].ItemArray = _tempRows[i].ItemArray;
            }

        }
        #endregion

        #region Ultility
        private void SortSlNo()
        {
            this._selectedGridView.BeginSort();
            try
            {
                this._selectedGridView.Columns["SL_NO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }
            finally { this._selectedGridView.EndSort(); }
        }

        private void UpdateMappingItem(ItemMapper _item, int _value)
        {
            object _oldObj = _item.Control;
            object _newObj = null;
            Type newType = this.GetObjectType(_value);
            if (_oldObj.GetType() != newType)
            {
                _newObj = Activator.CreateInstance(newType, true);
                this.TransferId(ref _oldObj, ref _newObj);
                _item.Control = _newObj;//create new
                _item.ControlType = newType;
            }
            this.propertyGrid1.SelectedObject = _item.Control;
        }

        private void TransferId(ref object _oldObj, ref object _newObj)
        {
            ((ControlBase)_newObj).Id = ((ControlBase)_oldObj).Id;
            ((ControlBase)_newObj).DetailId = ((ControlBase)_oldObj).DetailId;
            //((ControlBase)_newObj).OldDetailId = ((ControlBase)_oldObj).DetailId;
        }

        private Type GetObjectType(int value)
        {
            switch (value)
            {
                case 1: return typeof(ExLabel);
                case 2: return typeof(ExTextBox);
                case 3: return typeof(ExCheckBox);
                case 4: return typeof(ExRadioButton);
                case 5: return typeof(ExDatePick);
                case 6: return typeof(ExMemoEdit);
                case 7: return typeof(ExSpinEdit);
                case 8: return typeof(ExGroup);
                case 9: return typeof(ExTable);
                default: return typeof(ExLabel);
            }
        }
        private object CreateBackUpControl(object control, Type type)
        {
            #region Label
            if (type == typeof(ExLabel))
            {
                ExLabel n_label = new ExLabel();
                ExLabel o_label = control as ExLabel;
                n_label.DetailId = o_label.DetailId;
                n_label.Id = o_label.Id;
                n_label.Text = o_label.Text;
                return n_label;
            }
            #endregion

            #region Muticolumn
            else if (type == typeof(ExTable))
            {
                ExTable n_table = new ExTable();
                ExTable o_table = control as ExTable;
                n_table.Column = new ExMultiColumnCollection();
                foreach (ExMultiColumn culumn in o_table.Column)
                {
                    ExMultiColumn cols = new ExMultiColumn();
                    cols.Id = culumn.Id;
                    cols.Column = new ExMultiColumnItemCollection();
                    foreach (ExMultiColumnItem row in culumn.Column)
                    {
                        ExMultiColumnItem mItem = new ExMultiColumnItem();
                        mItem.Default = row.Default;
                        mItem.Id = row.Id;
                        mItem.Text = row.Text;
                        mItem.Value = row.Value;
                        cols.Column.Add(mItem);
                    }
                    n_table.Column.Add(cols);
                }
                //ExMultiColumn column
                n_table.DetailId = o_table.DetailId;
                n_table.Id = o_table.Id;
                n_table.Selection = o_table.Selection;
                return n_table;
            }
            #endregion

            #region Radio Button
            else if (type == typeof(ExRadioButton))
            {
                ExRadioButton radiobutton = new ExRadioButton();
                ExRadioButton oldControl = control as ExRadioButton;
                radiobutton.DetailId = oldControl.DetailId;
                radiobutton.Id = oldControl.Id;
                radiobutton.Default = new List<CustomItem>();
                foreach (CustomItem ci in oldControl.Default)
                {
                    CustomItem _citem = new CustomItem();
                    _citem.Name = ci.Name;
                    _citem.Selected = ci.Selected;
                    radiobutton.Default.Add(_citem);
                }
                radiobutton.Items = new ExItemCollection();
                foreach (ExItem item in oldControl.Items)
                {
                    ExItem i = new ExItem();
                    i.Check = item.Check;
                    i.Id = item.Id;
                    i.Image = item.Image;
                    //i.Position = item.Position;
                    i.Text = item.Text;
                    i.Value = item.Value;
                    foreach (ExChild child in item.Child)
                    {
                        ExChild c = new ExChild();
                        c.DefaultText = child.DefaultText;
                        c.DefaultValue = child.DefaultValue;
                        c.ForceInput = child.ForceInput;
                        c.Id = child.Id;
                        //c.Image = child.Image;
                        //c.Layout = child.Layout;
                        c.Maximum = child.Maximum;
                        c.Minimum = child.Minimum;
                        //c.Position = child.Position;
                        c.Size = child.Size;
                        c.Text = child.Text;
                        c.Type = child.Type;
                        i.Child.Add(c);
                    }
                    radiobutton.Items.Add(i);
                }
                return radiobutton;
            }
            #endregion

            #region CheckBox
            else if (type == typeof(ExCheckBox))
            {
                ExCheckBox checkBox = new ExCheckBox();
                ExCheckBox oldControl = control as ExCheckBox;
                checkBox.DetailId = oldControl.DetailId;
                checkBox.Id = oldControl.Id;
                checkBox.Items = new ExItemCollection();
                foreach (ExItem item in oldControl.Items)
                {
                    ExItem i = new ExItem();
                    i.Check = item.Check;
                    i.Id = item.Id;
                    i.Image = item.Image;
                    //i.Position = item.Position;
                    i.Text = item.Text;
                    i.Value = item.Value;
                    foreach (ExChild child in item.Child)
                    {
                        ExChild c = new ExChild();
                        c.DefaultText = child.DefaultText;
                        c.DefaultValue = child.DefaultValue;
                        c.ForceInput = child.ForceInput;
                        c.Id = child.Id;
                        //c.Image = child.Image;
                        //c.Layout = child.Layout;
                        c.Maximum = child.Maximum;
                        c.Minimum = child.Minimum;
                        //c.Position = child.Position;
                        c.Size = child.Size;
                        c.Text = child.Text;
                        c.Type = child.Type;
                        i.Child.Add(c);
                    }
                    checkBox.Items.Add(i);
                }
                return checkBox;
            }
            #endregion

            #region Group
            else if (type == typeof(ExGroup))
            {
                ExGroup group = new ExGroup();
                ExGroup old = control as ExGroup;
                group.Id = old.Id;
                group.Items = new ExGroupItemCollection();
                foreach (ExGroupItem item in old.Items)
                {
                    ExGroupItem gi = new ExGroupItem();
                    gi.DefaultText = item.DefaultText;
                    gi.ForceInput = item.ForceInput;
                    gi.Id = item.Id;
                    gi.Image = item.Image;
                    gi.Maximum = item.Maximum;
                    gi.Minimum = item.Minimum;
                    gi.Position = item.Position;
                    gi.Size = item.Size;
                    gi.Text = item.Text;
                    gi.Type = item.Type;
                    gi.DefaultValue = item.DefaultValue;
                    group.Items.Add(gi);
                }
                return group;
            }
            #endregion

            else
                return control;
        }
        /// <summary>
        /// Update QA
        /// </summary>
        /// <param name="drParent"></param>
        /// <param name="p"></param>
        private void UpdateQA(DataRow drParent, int p)
        {
            if (drParent != null)
            {
                int qa = Convert.ToInt32(drParent[MT_QA]);
                drParent[MT_QA] = qa + p;
            }
        }

        /// <summary>
        /// Set mapping control and datarow
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="p"></param>
        private void MappingItem(DataRow dr, int p)
        {
            bool isExits = false;
            ItemMapper item = new ItemMapper();
            item.Row = dr;
            foreach (ItemMapper itemMapper in _itemCollection)
            {
                if (itemMapper.Row == dr)
                {
                    isExits = true;
                    break;
                }
            }
            if (!isExits)
            {
                switch (p)
                {
                    case 1: item.Control = new ExLabel(); break;
                    case 2: item.Control = new ExTextBox(); break;
                    case 3: item.Control = new ExCheckBox(); break;
                    case 4: item.Control = new ExRadioButton(); break;
                    case 5: item.Control = new ExDatePick(); break;
                    case 6: item.Control = new ExMemoEdit(); break;
                    case 7: item.Control = new ExSpinEdit(); break;
                    case 8: item.Control = new ExGroup(); break;
                    case 9: item.Control = new ExTable(); break;
                }
                item.ControlType = item.Control.GetType();
                this._itemCollection.Add(item);
            }
            this.propertyGrid1.SelectedObject = item.Control;
            //this.TypePropertySelector(1);
        }
        #region Convert to DataSource
        private const string _SrTemplateTableName = "SR_TEMPLATE";
        private const string _SrTemplatePartTableName = "SR_TEMPLATEPART";
        private const string _SrQuestionsTableName = "SR_QUESTIONS";
        private const string _SrQuestionsDtlTableName = "SR_QUESTIONSDTL";
        private const string _SrQuestionsDtlChildTableName = "SR_QUESTIONSDTLCHILD";
        /// <summary>
        /// this method use to get current dataset form set up form
        /// it have 5 tables in dataset
        /// -------------------------------
        /// 1) SR_TEMPLATE table
        /// 2) SR_TAMPLATEPART table
        /// 3) SR_QUESTIONS table
        /// 4) SR_QUESTIONSDTL table
        /// 5) SR_QUESTIONSDTLCHILD table
        /// </summary>
        /// <returns>Result DataSource</returns>
        public DataSet GetDataSource()
        {
            int _templateId = 1;
            int _questionDtlId = 1;
            int _questionChildId = 1;
            int seqQId = 1;
            DataSet dsDataSource = new DataSet();
            try
            {
                // Get Schema
                this.BuildDataSetSchema(ref dsDataSource);
                // Fill Data to Datatable
                // Fill SR_TEMPLATE
                DataRow drTemplateRow = dsDataSource.Tables[_SrTemplateTableName].NewRow();
                drTemplateRow["TEMPLATE_ID"] = _templateId;
                drTemplateRow["TEMPLATE_NAME"] = this.txtTemplate.Text.Trim();
                drTemplateRow["IS_ACTIVE"] = this.chkActive.Checked == true ? "Y" : "N";
                if (!string.IsNullOrEmpty(this.grlExam.EditValue.ToString().Trim()))
                    drTemplateRow["EXAM_ID"] = Convert.ToInt32(this.grlExam.EditValue.ToString());
                if (!string.IsNullOrEmpty(this.grlBody.EditValue.ToString().Trim()))
                    drTemplateRow["BP_ID"] = Convert.ToInt32(this.grlBody.EditValue.ToString());
                drTemplateRow["DESCRIPTION"] = this.txtDesc.Text.Trim();
                drTemplateRow["LANG_ID"] = Convert.ToInt32(this.grlLanguage.EditValue.ToString());
                drTemplateRow["RSNA_URL"] = this.txtUrl.Text.Trim();
                drTemplateRow["ORG_ID"] = this.OrgId;
                drTemplateRow["CREATED_BY"] = this.UserId;
                drTemplateRow["CREATED_ON"] = DateTime.Now;
                dsDataSource.Tables[_SrTemplateTableName].Rows.Add(drTemplateRow);
                // Fill SR_TEMPLATEPART
                if (this.dsGridData != null)
                {
                    if (this.dsGridData.Tables[DT_PARENT_NAME] != null)
                    {
                        foreach (DataRow drRow in this.dsGridData.Tables[DT_PARENT_NAME].Rows)
                        {
                            DataRow[] drQuestionRows = this.dsGridData.Tables[DT_CHILD_NAME].Select(DT_PARENT_ID + " = '" + drRow[MT_MASTER_ID] + "'");
                            DataRow drTemplatePartRow = dsDataSource.Tables[_SrTemplatePartTableName].NewRow();
                            drTemplatePartRow["PART_ID"] = drRow[MT_MASTER_ID];
                            drTemplatePartRow["PART_NAME"] = drRow[MT_PART_NAME];
                            drTemplatePartRow["TEMPLATE_ID"] = _templateId;
                            drTemplatePartRow["SL"] = drRow[MT_SL_NO];
                            drTemplatePartRow["ORG_ID"] = this.OrgId;
                            drTemplatePartRow["CREATED_BY"] = this.UserId;
                            drTemplatePartRow["CREATED_ON"] = DateTime.Now;
                            dsDataSource.Tables[_SrTemplatePartTableName].Rows.Add(drTemplatePartRow);
                            // Fill SR_QUESTION
                            if (drQuestionRows.Length > 0)
                            {
                                int partId = Convert.ToInt32(drRow[MT_MASTER_ID]);
                                
                                foreach (DataRow drQRow in drQuestionRows)
                                {
                                    ItemMapper itemControl = this.GetItemControl(drQRow[DT_DETAIL_ID].ToString());
                                    DataRow drQuestionRow = dsDataSource.Tables[_SrQuestionsTableName].NewRow();
                                    drQuestionRow["Q_ID"] = seqQId;
                                    drQuestionRow["Q_TYPE_ID"] = drQRow[DT_CONTROL_TYPE];
                                    drQuestionRow["PART_ID"] = partId;
                                    drQuestionRow["QUESTION_TEXT"] = drQRow[DT_QUESTION_TEXT];
                                    drQuestionRow["QUESTION_SIDE"] = drQRow[DT_LAYOUT].ToString()=="Horizontal" ? "H":"V";
                                    drQuestionRow["SPACE_BEGIN"] = drQRow[DT_SPACEING];
                                    SRSetUpManagement.FontStyle fontstyle = srManager.GetFontStyle(drQRow[DT_FONT_STYLE].ToString());
                                    drQuestionRow["IS_BOLD"] = fontstyle.Bold == true ? "Y" : "N";
                                    drQuestionRow["IS_ITALIC"] = fontstyle.Italic == true ? "Y" : "N";
                                    drQuestionRow["IS_UNDERLINE"] = fontstyle.UnderLine == true ? "Y" : "N";
                                    drQuestionRow["APPEND_NEXT"] = drQRow[DT_IS_APPEND].ToString();
                                    drQuestionRow["ORG_ID"] = this.OrgId;
                                    drQuestionRow["CREATED_BY"] = this.UserId;
                                    drQuestionRow["CREATED_ON"] = DateTime.Now;
                                    if (itemControl != null)
                                    {
                                        if (itemControl.ControlType == typeof(ExLabel))
                                        {
                                            ExLabel labelControl = itemControl.Control as ExLabel;
                                            drQuestionRow["DEFAULT_VALUE"] = labelControl.Text;
                                            dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with out question dtl
                                        }
                                        else if (itemControl.ControlType == typeof(ExTextBox))
                                        {
                                            ExTextBox textboxControl = itemControl.Control as ExTextBox;
                                            drQuestionRow["DEFAULT_VALUE"] = textboxControl.DefaultText;
                                            drQuestionRow["IS_DEFAULT"] = textboxControl.ForceInput == true ? "Y" : "N";
                                            dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with question dtl
                                            // Fill SR_QUESTIONSDTL FOR TEXTBOX
                                            DataRow drQuestionsDtlRow = dsDataSource.Tables[_SrQuestionsDtlTableName].NewRow();
                                            drQuestionsDtlRow["Q_ID"] = seqQId;
                                            drQuestionsDtlRow["Q_ID_DTL"] = _questionDtlId;
                                            drQuestionsDtlRow["TEXT_SIZE"] = srManager.GetTextSize(textboxControl.Size);
                                            if (textboxControl.Image != null)
                                            {
                                                drQuestionsDtlRow["IMG_DATA"] = srManager.GetImageData(textboxControl.Image);
                                                drQuestionsDtlRow["IMG_POSITION"] = srManager.GetImagePosition(textboxControl.Position);
                                            }
                                            drQuestionsDtlRow["ORG_ID"] = this.OrgId;
                                            drQuestionsDtlRow["CREATED_BY"] = this.UserId;
                                            drQuestionsDtlRow["CREATED_ON"] = DateTime.Now;
                                            dsDataSource.Tables[_SrQuestionsDtlTableName].Rows.Add(drQuestionsDtlRow); // add question dtl
                                        }
                                        else if (itemControl.ControlType == typeof(ExDatePick))
                                        {
                                            ExDatePick dateControl = itemControl.Control as ExDatePick;
                                            drQuestionRow["IS_DEFAULT"] = dateControl.ForceInput == true ? "Y" : "N";
                                            dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with question dtl
                                            // Fill SR_QUESTIONSDTL FOR DATE PICK

                                            if (dateControl.Image != null)
                                            {
                                                DataRow drQuestionsDtlRow = dsDataSource.Tables[_SrQuestionsDtlTableName].NewRow();
                                                drQuestionsDtlRow["Q_ID"] = seqQId;
                                                drQuestionsDtlRow["Q_ID_DTL"] = _questionDtlId;
                                                drQuestionsDtlRow["IMG_DATA"] = srManager.GetImageData(dateControl.Image);
                                                drQuestionsDtlRow["IMG_POSITION"] = srManager.GetImagePosition(dateControl.Position);
                                                drQuestionsDtlRow["ORG_ID"] = this.OrgId;
                                                drQuestionsDtlRow["CREATED_BY"] = this.UserId;
                                                drQuestionsDtlRow["CREATED_ON"] = DateTime.Now;
                                                dsDataSource.Tables[_SrQuestionsDtlTableName].Rows.Add(drQuestionsDtlRow); // add question dtl
                                            }
                                            
                                        }
                                        else if (itemControl.ControlType == typeof(ExMemoEdit))
                                        {
                                            ExMemoEdit memoControl = itemControl.Control as ExMemoEdit;
                                            drQuestionRow["DEFAULT_VALUE"] = memoControl.DefaultText;
                                            drQuestionRow["IS_DEFAULT"] = memoControl.ForceInput == true ? "Y" : "N";
                                            dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with question dtl
                                            // Fill SR_QUESTIONSDTL FOR MEMOEDIT
                                            DataRow drQuestionsDtlRow = dsDataSource.Tables[_SrQuestionsDtlTableName].NewRow();
                                            drQuestionsDtlRow["Q_ID"] = seqQId;
                                            drQuestionsDtlRow["Q_ID_DTL"] = _questionDtlId;
                                            drQuestionsDtlRow["TEXT_SIZE"] = srManager.GetTextSize(memoControl.Size);
                                            if (memoControl.Image != null)
                                            {
                                                drQuestionsDtlRow["IMG_DATA"] = srManager.GetImageData(memoControl.Image);
                                                drQuestionsDtlRow["IMG_POSITION"] = srManager.GetImagePosition(memoControl.Position);
                                            }
                                            drQuestionsDtlRow["ORG_ID"] = this.OrgId;
                                            drQuestionsDtlRow["CREATED_BY"] = this.UserId;
                                            drQuestionsDtlRow["CREATED_ON"] = DateTime.Now;
                                            dsDataSource.Tables[_SrQuestionsDtlTableName].Rows.Add(drQuestionsDtlRow); // add question dtl
                                        }
                                        else if (itemControl.ControlType == typeof(ExSpinEdit))
                                        {
                                            ExSpinEdit numberControl = itemControl.Control as ExSpinEdit;
                                            drQuestionRow["DEFAULT_VALUE"] = numberControl.DefaultValue;
                                            drQuestionRow["IS_DEFAULT"] = numberControl.ForceInput == true ? "Y" : "N";
                                            dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with question dtl
                                            // Fill SR_QUESTIONSDTL FOR SPIN EDIT
                                            DataRow drQuestionsDtlRow = dsDataSource.Tables[_SrQuestionsDtlTableName].NewRow();
                                            drQuestionsDtlRow["Q_ID"] = seqQId;
                                            drQuestionsDtlRow["Q_ID_DTL"] = _questionDtlId;
                                            drQuestionsDtlRow["TEXT_SIZE"] = numberControl.Maximum;
                                            drQuestionsDtlRow["PROP1"] = numberControl.Minimum;
                                            if (numberControl.Image != null)
                                            {
                                                drQuestionsDtlRow["IMG_DATA"] = srManager.GetImageData(numberControl.Image);
                                                drQuestionsDtlRow["IMG_POSITION"] = srManager.GetImagePosition(numberControl.Position);
                                            }
                                            drQuestionsDtlRow["ORG_ID"] = this.OrgId;
                                            drQuestionsDtlRow["CREATED_BY"] = this.UserId;
                                            drQuestionsDtlRow["CREATED_ON"] = DateTime.Now;
                                            dsDataSource.Tables[_SrQuestionsDtlTableName].Rows.Add(drQuestionsDtlRow); // add question dtl
                                        }
                                        else if (itemControl.ControlType == typeof(ExTable))
                                        {
                                            ExTable multiColumnControl = itemControl.Control as ExTable;
                                            drQuestionRow["DEFAULT_VALUE"] = multiColumnControl.Column.Count;
                                            drQuestionRow["IS_DEFAULT"] = multiColumnControl.Selection
                                                == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.SelectionTypes.Single ? "S" : "M";
                                            dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with question dtl
                                            int ColumnId = 1;
                                            foreach (ExMultiColumn column in multiColumnControl.Column)
                                            {
                                                foreach (ExMultiColumnItem colsItem in column.Column)
                                                {
                                                    DataRow drQuestionsDtlRow = dsDataSource.Tables[_SrQuestionsDtlTableName].NewRow();
                                                    drQuestionsDtlRow["Q_ID"] = seqQId;
                                                    drQuestionsDtlRow["Q_ID_DTL"] = _questionDtlId;
                                                    drQuestionsDtlRow["LABEL"] = colsItem.Text;
                                                    drQuestionsDtlRow["DEFAULT_VALUE"] = colsItem.Value;
                                                    drQuestionsDtlRow["IS_DEFAULT"] = colsItem.Default == true ? "Y" : "N";
                                                    drQuestionsDtlRow["PROP1"] = ColumnId;
                                                    drQuestionsDtlRow["ORG_ID"] = this.OrgId;
                                                    drQuestionsDtlRow["CREATED_BY"] = this.UserId;
                                                    drQuestionsDtlRow["CREATED_ON"] = DateTime.Now;
                                                    dsDataSource.Tables[_SrQuestionsDtlTableName].Rows.Add(drQuestionsDtlRow); // add question dtl
                                                    _questionDtlId++;
                                                }
                                                ColumnId++;
                                            }
                                        }
                                        else if (itemControl.ControlType == typeof(ExGroup))
                                        {
                                            ExGroup groupControl = itemControl.Control as ExGroup;
                                            dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with question dtl
                                            foreach (ExGroupItem groupItem in groupControl.Items)
                                            {
                                                DataRow drQuestionsDtlRow = dsDataSource.Tables[_SrQuestionsDtlTableName].NewRow();
                                                drQuestionsDtlRow["Q_ID"] = seqQId;
                                                drQuestionsDtlRow["Q_ID_DTL"] = _questionDtlId;
                                                if (groupItem.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.GroupChildControlType.Label)
                                                {
                                                    drQuestionsDtlRow["LABEL"] = "#@#1#@#";
                                                    drQuestionsDtlRow["DEFAULT_VALUE"] = groupItem.Text;
                                                }
                                                else if (groupItem.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.GroupChildControlType.TextBox)
                                                {
                                                    drQuestionsDtlRow["LABEL"] = "#@#2#@#";
                                                    drQuestionsDtlRow["TEXT_SIZE"] = srManager.GetTextSize(groupItem.Size);
                                                    drQuestionsDtlRow["DEFAULT_VALUE"] = groupItem.DefaultText;
                                                    drQuestionsDtlRow["IS_DEFAULT"] = groupItem.ForceInput == true ? "Y" : "N";
                                                }
                                                else if (groupItem.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.GroupChildControlType.Multiline)
                                                {
                                                    drQuestionsDtlRow["LABEL"] = "#@#6#@#";
                                                    drQuestionsDtlRow["TEXT_SIZE"] = srManager.GetTextSize(groupItem.Size);
                                                    drQuestionsDtlRow["DEFAULT_VALUE"] = groupItem.DefaultText;
                                                    drQuestionsDtlRow["IS_DEFAULT"] = groupItem.ForceInput == true ? "Y" : "N";
                                                }
                                                else if (groupItem.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.GroupChildControlType.Numeric)
                                                {
                                                    drQuestionsDtlRow["LABEL"] = "#@#7#@#";
                                                    drQuestionsDtlRow["TEXT_SIZE"] = groupItem.Maximum.ToString();
                                                    drQuestionsDtlRow["DEFAULT_VALUE"] = groupItem.DefaultValue.ToString();
                                                    drQuestionsDtlRow["PROP1"] = groupItem.Minimum.ToString();
                                                    drQuestionsDtlRow["IS_DEFAULT"] = groupItem.ForceInput == true ? "Y" : "N";
                                                }
                                                else if (groupItem.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.GroupChildControlType.Image)
                                                {
                                                    drQuestionsDtlRow["LABEL"] = "#@#-1#@#";
                                                    if (groupItem.Image != null)
                                                    {
                                                        drQuestionsDtlRow["IMG_POSITION"] = srManager.GetImagePosition(groupItem.Position);
                                                        drQuestionsDtlRow["IMG_DATA"] = srManager.GetImageData(groupItem.Image);
                                                    }
                                                }
                                                drQuestionsDtlRow["ORG_ID"] = this.OrgId;
                                                drQuestionsDtlRow["CREATED_BY"] = this.UserId;
                                                drQuestionsDtlRow["CREATED_ON"] = DateTime.Now;
                                                dsDataSource.Tables[_SrQuestionsDtlTableName].Rows.Add(drQuestionsDtlRow); // add question dtl
                                                _questionDtlId++;
                                            }
                                        }
                                        else if (itemControl.ControlType == typeof(ExCheckBox))
                                        {
                                            ExCheckBox checkBoxControl = itemControl.Control as ExCheckBox;
                                            dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with question dtl
                                            foreach (ExItem chkItem in checkBoxControl.Items)
                                            {
                                                DataRow drQuestionsDtlRow = dsDataSource.Tables[_SrQuestionsDtlTableName].NewRow();
                                                drQuestionsDtlRow["Q_ID"] = seqQId;
                                                drQuestionsDtlRow["Q_ID_DTL"] = _questionDtlId;
                                                if (chkItem.Child.Count > 0)
                                                    drQuestionsDtlRow["HAS_CHILD"] = "Y";
                                                else
                                                    drQuestionsDtlRow["HAS_CHILD"] = "N";
                                                drQuestionsDtlRow["DEFAULT_VALUE"] = chkItem.Value;
                                                drQuestionsDtlRow["LABEL"] = chkItem.Text;
                                                drQuestionsDtlRow["IS_DEFAULT"] = chkItem.Check == true ? "Y" : "N";
                                                if (chkItem.Image != null)
                                                    drQuestionsDtlRow["IMG_DATA"] = srManager.GetImageData(chkItem.Image);
                                                drQuestionsDtlRow["ORG_ID"] = this.OrgId;
                                                drQuestionsDtlRow["CREATED_BY"] = this.UserId;
                                                drQuestionsDtlRow["CREATED_ON"] = DateTime.Now;
                                                dsDataSource.Tables[_SrQuestionsDtlTableName].Rows.Add(drQuestionsDtlRow); // add question dtl
                                                // Fill SR_QUESTIONCHILD
                                                if (chkItem.Child.Count > 0)
                                                {
                                                    foreach (ExChild child in chkItem.Child)
                                                    {
                                                        DataRow drQuestionsDtlChildRow = dsDataSource.Tables[_SrQuestionsDtlChildTableName].NewRow();
                                                        drQuestionsDtlChildRow["Q_ID"] = seqQId;
                                                        drQuestionsDtlChildRow["Q_ID_DTL"] = _questionDtlId;
                                                        drQuestionsDtlChildRow["Q_ID_DTL_CHD"] = _questionChildId;
                                                        drQuestionsDtlChildRow["ORG_ID"] = this.OrgId;
                                                        drQuestionsDtlChildRow["CREATED_BY"] = this.UserId;
                                                        drQuestionsDtlChildRow["CREATED_ON"] = DateTime.Now;
                                                        if (child.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.ChildControlTypes.Label)
                                                        {
                                                            drQuestionsDtlChildRow["Q_TYPE_ID"] = 1;
                                                            drQuestionsDtlChildRow["DEFAULT_VALUE"] = child.Text;
                                                        }
                                                        else if (child.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.ChildControlTypes.TextBox)
                                                        {
                                                            drQuestionsDtlChildRow["Q_TYPE_ID"] = 2;
                                                            drQuestionsDtlChildRow["TEXT_SIZE"] = srManager.GetTextSize(child.Size);
                                                            drQuestionsDtlChildRow["DEFAULT_VALUE"] = child.DefaultText;
                                                            drQuestionsDtlChildRow["IS_DEFAULT"] = child.ForceInput == true ? "Y" : "N";
                                                        }
                                                        else if (child.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.ChildControlTypes.Numeric)
                                                        {
                                                            drQuestionsDtlChildRow["Q_TYPE_ID"] = 7;
                                                            drQuestionsDtlChildRow["TEXT_SIZE"] = child.Maximum.ToString();
                                                            drQuestionsDtlChildRow["DEFAULT_VALUE"] = child.DefaultValue.ToString();
                                                            drQuestionsDtlChildRow["PROP1"] = child.Minimum.ToString();
                                                            drQuestionsDtlChildRow["IS_DEFAULT"] = child.ForceInput == true ? "Y" : "N";
                                                        }
                                                        else if (child.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.ChildControlTypes.MemoEdit)
                                                        {
                                                            drQuestionsDtlChildRow["Q_TYPE_ID"] = 6;
                                                            drQuestionsDtlChildRow["TEXT_SIZE"] = srManager.GetTextSize(child.Size);
                                                            drQuestionsDtlChildRow["DEFAULT_VALUE"] = child.DefaultText;
                                                            drQuestionsDtlChildRow["IS_DEFAULT"] = child.ForceInput == true ? "Y" : "N";
                                                        }
                                                        dsDataSource.Tables[_SrQuestionsDtlChildTableName].Rows.Add(drQuestionsDtlChildRow);
                                                        _questionChildId++;
                                                    }
                                                }

                                                _questionDtlId++;
                                            }
                                        }
                                        else if (itemControl.ControlType == typeof(ExRadioButton))
                                        {
                                            ExRadioButton radioControl = itemControl.Control as ExRadioButton;
                                            dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with question dtl
                                            string defaultName = string.Empty;
                                            foreach (CustomItem cItem in radioControl.Default)
                                                if (cItem.Selected)
                                                {
                                                    defaultName = cItem.Name;
                                                    break;
                                                }
                                            foreach (ExItem chkItem in radioControl.Items)
                                            {
                                                DataRow drQuestionsDtlRow = dsDataSource.Tables[_SrQuestionsDtlTableName].NewRow();
                                                drQuestionsDtlRow["Q_ID"] = seqQId;
                                                drQuestionsDtlRow["Q_ID_DTL"] = _questionDtlId;
                                                if (chkItem.Child.Count > 0)
                                                    drQuestionsDtlRow["HAS_CHILD"] = "Y";
                                                else
                                                    drQuestionsDtlRow["HAS_CHILD"] = "N";
                                                drQuestionsDtlRow["DEFAULT_VALUE"] = chkItem.Value;
                                                drQuestionsDtlRow["LABEL"] = chkItem.Text;
                                                if (chkItem.Text == defaultName)
                                                    drQuestionsDtlRow["IS_DEFAULT"] = "Y";
                                                else
                                                    drQuestionsDtlRow["IS_DEFAULT"] = "N";

                                                if (chkItem.Image != null)
                                                    drQuestionsDtlRow["IMG_DATA"] = srManager.GetImageData(chkItem.Image);
                                                drQuestionsDtlRow["ORG_ID"] = this.OrgId;
                                                drQuestionsDtlRow["CREATED_BY"] = this.UserId;
                                                drQuestionsDtlRow["CREATED_ON"] = DateTime.Now;
                                                dsDataSource.Tables[_SrQuestionsDtlTableName].Rows.Add(drQuestionsDtlRow); // add question dtl
                                                // Fill SR_QUESTIONCHILD
                                                if (chkItem.Child.Count > 0)
                                                {
                                                    foreach (ExChild child in chkItem.Child)
                                                    {
                                                        DataRow drQuestionsDtlChildRow = dsDataSource.Tables[_SrQuestionsDtlChildTableName].NewRow();
                                                        drQuestionsDtlChildRow["Q_ID"] = seqQId;
                                                        drQuestionsDtlChildRow["Q_ID_DTL"] = _questionDtlId;
                                                        drQuestionsDtlChildRow["Q_ID_DTL_CHD"] = _questionChildId;
                                                        drQuestionsDtlChildRow["ORG_ID"] = this.OrgId;
                                                        drQuestionsDtlChildRow["CREATED_BY"] = this.UserId;
                                                        drQuestionsDtlChildRow["CREATED_ON"] = DateTime.Now;
                                                        if (child.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.ChildControlTypes.Label)
                                                        {
                                                            drQuestionsDtlChildRow["Q_TYPE_ID"] = 1;
                                                            drQuestionsDtlChildRow["DEFAULT_VALUE"] = child.Text;
                                                        }
                                                        else if (child.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.ChildControlTypes.TextBox)
                                                        {
                                                            drQuestionsDtlChildRow["Q_TYPE_ID"] = 2;
                                                            drQuestionsDtlChildRow["TEXT_SIZE"] = srManager.GetTextSize(child.Size);
                                                            drQuestionsDtlChildRow["DEFAULT_VALUE"] = child.DefaultText;
                                                            drQuestionsDtlChildRow["IS_DEFAULT"] = child.ForceInput == true ? "Y" : "N";
                                                        }
                                                        else if (child.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.ChildControlTypes.Numeric)
                                                        {
                                                            drQuestionsDtlChildRow["Q_TYPE_ID"] = 7;
                                                            drQuestionsDtlChildRow["TEXT_SIZE"] = child.Maximum.ToString();
                                                            drQuestionsDtlChildRow["DEFAULT_VALUE"] = child.DefaultValue.ToString();
                                                            drQuestionsDtlChildRow["PROP1"] = child.Minimum.ToString();
                                                            drQuestionsDtlChildRow["IS_DEFAULT"] = child.ForceInput == true ? "Y" : "N";
                                                        }
                                                        else if (child.Type == Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums.ChildControlTypes.MemoEdit)
                                                        {
                                                            drQuestionsDtlChildRow["Q_TYPE_ID"] = 6;
                                                            drQuestionsDtlChildRow["TEXT_SIZE"] = srManager.GetTextSize(child.Size);
                                                            drQuestionsDtlChildRow["DEFAULT_VALUE"] = child.DefaultText;
                                                            drQuestionsDtlChildRow["IS_DEFAULT"] = child.ForceInput == true ? "Y" : "N";
                                                        }
                                                        dsDataSource.Tables[_SrQuestionsDtlChildTableName].Rows.Add(drQuestionsDtlChildRow);
                                                        _questionChildId++;
                                                    }
                                                }
                                                _questionDtlId++;
                                            }
                                        }
                                    }
                                    else
                                        dsDataSource.Tables[_SrQuestionsTableName].Rows.Add(drQuestionRow); // add with out question dtl

                                    seqQId++; // update question id
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                //Clear memory
                _templateId = 0;
                //dsDataSource = null; 
            }

            return dsDataSource.Copy();
        }
        /// <summary>
        /// this method use to get itemcontrol by question id
        /// </summary>
        /// <param name="questionId">question id</param>
        /// <returns>item mapper</returns>
        private ItemMapper GetItemControl(string questionId)
        {
            foreach (ItemMapper itemMapper in this._itemCollection)
            {
                if (itemMapper.Row[DT_DETAIL_ID].ToString() == questionId)
                    return itemMapper;
            }

            return null;
        }
        /// <summary>
        /// this method use to get dataset schema follow by database table
        /// </summary>
        /// <param name="dsDataSource">taget dataset</param>
        private void BuildDataSetSchema(ref DataSet dsDataSource)
        {
           
            // Build Table Schema SR_TEMPLATE
            DataTable dtSrTemplate = dsDataSource.Tables.Add(_SrTemplateTableName);
            dtSrTemplate.Columns.Add("TEMPLATE_ID", typeof(int));
            dtSrTemplate.Columns.Add("TEMPLATE_NAME", typeof(string));
            dtSrTemplate.Columns.Add("IS_ACTIVE", typeof(string));
            dtSrTemplate.Columns.Add("EXAM_ID", typeof(int));
            dtSrTemplate.Columns.Add("BP_ID", typeof(int));
            dtSrTemplate.Columns.Add("DESCRIPTION", typeof(string));
            dtSrTemplate.Columns.Add("RSNA_URL", typeof(string));
            //dtSrTemplate.Columns.Add("RSNA_URL", typeof(string));
            dtSrTemplate.Columns.Add("LANG_ID", typeof(int));
            dtSrTemplate.Columns.Add("ORG_ID", typeof(int));
            dtSrTemplate.Columns.Add("CREATED_BY", typeof(int));
            dtSrTemplate.Columns.Add("CREATED_ON", typeof(DateTime));
            dtSrTemplate.Columns.Add("LAST_MODIFIED_BY", typeof(int));
            dtSrTemplate.Columns.Add("LAST_MODIFIED_ON", typeof(DateTime));
            dtSrTemplate.AcceptChanges();
            // Build Table schema SR_TEAMPLATEPART
            DataTable dtSrTemplatePart = dsDataSource.Tables.Add(_SrTemplatePartTableName);
            dtSrTemplatePart.Columns.Add("PART_ID", typeof(int));
            dtSrTemplatePart.Columns.Add("PART_NAME", typeof(string));
            dtSrTemplatePart.Columns.Add("TEMPLATE_ID", typeof(int));
            dtSrTemplatePart.Columns.Add("SL", typeof(int));
            dtSrTemplatePart.Columns.Add("ORG_ID", typeof(int));
            dtSrTemplatePart.Columns.Add("CREATED_BY", typeof(int));
            dtSrTemplatePart.Columns.Add("CREATED_ON", typeof(DateTime));
            dtSrTemplatePart.Columns.Add("LAST_MODIFIED_BY", typeof(int));
            dtSrTemplatePart.Columns.Add("LAST_MODIFIED_ON", typeof(DateTime));
            dtSrTemplatePart.AcceptChanges();
            // Build Table schema SR_QUESTIONS
            DataTable dtSrQuestions = dsDataSource.Tables.Add(_SrQuestionsTableName);
            dtSrQuestions.Columns.Add("Q_ID", typeof(int));
            dtSrQuestions.Columns.Add("Q_TYPE_ID", typeof(int));
            dtSrQuestions.Columns.Add("PART_ID", typeof(int));
            dtSrQuestions.Columns.Add("QUESTION_TEXT", typeof(string));
            dtSrQuestions.Columns.Add("QUESTION_SIDE", typeof(string));
            dtSrQuestions.Columns.Add("SPACE_BEGIN", typeof(int));
            dtSrQuestions.Columns.Add("IS_BOLD", typeof(string));
            dtSrQuestions.Columns.Add("IS_ITALIC", typeof(string));
            dtSrQuestions.Columns.Add("IS_UNDERLINE", typeof(string));
            dtSrQuestions.Columns.Add("LABEL", typeof(string));
            dtSrQuestions.Columns.Add("DEFAULT_VALUE", typeof(string));
            dtSrQuestions.Columns.Add("IS_DEFAULT", typeof(string));
            dtSrQuestions.Columns.Add("ORG_ID", typeof(int));
            dtSrQuestions.Columns.Add("CREATED_BY", typeof(int));
            dtSrQuestions.Columns.Add("CREATED_ON", typeof(DateTime));
            dtSrQuestions.Columns.Add("LAST_MODIFIED_BY", typeof(int));
            dtSrQuestions.Columns.Add("LAST_MODIFIED_ON", typeof(DateTime));
            dtSrQuestions.Columns.Add("APPEND_NEXT", typeof(string));
            dtSrQuestions.Columns.Add("ANSWER", typeof(string));
            dtSrQuestions.AcceptChanges();
            // Build Table Schema SR_QUESTIONSDTL
            DataTable dtSrQuestionsDtl = dsDataSource.Tables.Add(_SrQuestionsDtlTableName);
            dtSrQuestionsDtl.Columns.Add("Q_ID", typeof(int));
            dtSrQuestionsDtl.Columns.Add("Q_ID_DTL", typeof(int));
            dtSrQuestionsDtl.Columns.Add("LABEL", typeof(string));
            dtSrQuestionsDtl.Columns.Add("DEFAULT_VALUE", typeof(string));
            dtSrQuestionsDtl.Columns.Add("IS_DEFAULT", typeof(string));
            dtSrQuestionsDtl.Columns.Add("HAS_CHILD", typeof(string));
            dtSrQuestionsDtl.Columns.Add("IMG_POSITION", typeof(string));
            dtSrQuestionsDtl.Columns.Add("IMG_DATA", typeof(byte[]));
            dtSrQuestionsDtl.Columns.Add("ORG_ID", typeof(int));
            dtSrQuestionsDtl.Columns.Add("CREATED_BY", typeof(int));
            dtSrQuestionsDtl.Columns.Add("CREATED_ON", typeof(DateTime));
            dtSrQuestionsDtl.Columns.Add("LAST_MODIFIED_BY", typeof(int));
            dtSrQuestionsDtl.Columns.Add("LAST_MODIFIED_ON", typeof(DateTime));
            dtSrQuestionsDtl.Columns.Add("PROP1", typeof(string));
            dtSrQuestionsDtl.Columns.Add("TEXT_SIZE", typeof(string));
            dtSrQuestionsDtl.Columns.Add("ANSWER", typeof(string));
            dtSrQuestionsDtl.AcceptChanges();
            // Build Table Schema SR_QUESTIONDTLCHILD
            DataTable dtSrQuestionsChild = dsDataSource.Tables.Add(_SrQuestionsDtlChildTableName);
            dtSrQuestionsChild.Columns.Add("Q_ID", typeof(int));
            dtSrQuestionsChild.Columns.Add("Q_ID_DTL", typeof(int));
            dtSrQuestionsChild.Columns.Add("Q_ID_DTL_CHD", typeof(int));
            dtSrQuestionsChild.Columns.Add("Q_TYPE_ID", typeof(int));
            dtSrQuestionsChild.Columns.Add("LABEL", typeof(string));
            dtSrQuestionsChild.Columns.Add("DEFAULT_VALUE", typeof(string));
            dtSrQuestionsChild.Columns.Add("IS_DEFAULT", typeof(string));
            dtSrQuestionsChild.Columns.Add("IMG_POSITION", typeof(string));
            dtSrQuestionsChild.Columns.Add("IMG_DATA", typeof(byte[]));
            dtSrQuestionsChild.Columns.Add("QUESTION_SIDE", typeof(string));
            dtSrQuestionsChild.Columns.Add("PROP1", typeof(string));
            dtSrQuestionsChild.Columns.Add("TEXT_SIZE", typeof(string));
            dtSrQuestionsChild.Columns.Add("ORG_ID", typeof(int));
            dtSrQuestionsChild.Columns.Add("CREATED_BY", typeof(int));
            dtSrQuestionsChild.Columns.Add("CREATED_ON", typeof(DateTime));
            dtSrQuestionsChild.Columns.Add("LAST_MODIFIED_BY", typeof(int));
            dtSrQuestionsChild.Columns.Add("LAST_MODIFIED_ON", typeof(DateTime));
            dtSrQuestionsChild.Columns.Add("ANSWER", typeof(string));
            dtSrQuestionsChild.AcceptChanges();
        }
        #endregion

        private void btnPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._selectedGridView.CloseEditor();
            this._selectedGridView.UpdateCurrentRow();
            DataSet ds = GetDataSource();
            Envision.NET.Forms.ResultEntry.StructuredReport.QuesitonnairePreview prev = new QuesitonnairePreview(ds);
            prev.ShowDialog();
            prev.Dispose();
        }
        #endregion
    }
}