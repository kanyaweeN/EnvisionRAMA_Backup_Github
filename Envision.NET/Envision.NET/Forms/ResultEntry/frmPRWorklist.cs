using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using Envision.NET.Forms.ResultEntry.ResultDialog;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmPRWorklist : Envision.NET.Forms.Main.MasterForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        public frmPRWorklist()
        {
            InitializeComponent();
        }

        private void frmPRWorklist_Load(object sender, EventArgs e)
        {
            getData();
            base.CloseWaitDialog();
        }
        private void getData()
        {
            ProcessGetRISPRStudies prcData = new ProcessGetRISPRStudies();
            prcData.RIS_PRSTUDIES.RAD_ID = env.UserID;
            prcData.Invoke();

            DataTable dtPr = prcData.ResultSet.Tables[0];
            grdData.DataSource = dtPr;
            setGridColumnWL();
        }
        private void setGridColumnWL()
        {
            #region column edit


                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
                    repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                repositoryItemImageComboBox2.AutoHeight = false;
                repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", "R", 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", "U", 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", "S", 8)});
                repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
                repositoryItemImageComboBox2.SmallImages = imgWL;
                repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;



                DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                    chkDF = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                chkDF.ValueChecked = "Y";
                chkDF.ValueUnchecked = "N";
                chkDF.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
                chkDF.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
                chkDF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox linkScanImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                linkScanImage.AutoHeight = false;
                linkScanImage.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,22),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",0,23)
            });
                linkScanImage.Name = "linkScanImage";
                linkScanImage.SmallImages = imgSmall;
                linkScanImage.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                linkScanImage.Buttons[0].Visible = false;
                linkScanImage.ShowDropDown = ShowDropDown.Never;
                linkScanImage.ShowPopupShadow = false;
                linkScanImage.DropDownRows = 0;
                linkScanImage.Click += new EventHandler(linkScanImage_Click);


                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repComment = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                repComment.AutoHeight = false;
                repComment.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","New",1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","Read",9)
            });
                repComment.Name = "repComment";
                repComment.SmallImages = imgWL;
                repComment.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repComment.Buttons[0].Visible = false;
                repComment.Click += new EventHandler(repComment_Click);

                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repFlag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                repFlag.AutoHeight = false;
                repFlag.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,10)
            });
                repFlag.Name = "repFlag";
                repFlag.SmallImages = imgWL;
                repFlag.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repFlag.Buttons[0].Visible = false;

                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repRead = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                repRead.AutoHeight = false;
                repRead.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","N",1),
                 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","R",9)
            });
                repRead.Name = "repRead";
                repRead.SmallImages = imgWL;
                repRead.Buttons[0].Visible = false;
                repRead.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            #endregion column edit

                for (int i = 0; i < viewData.Columns.Count; i++)
                    viewData.Columns[i].Visible = false;

                viewData.OptionsSelection.EnableAppearanceFocusedCell = false;


                viewData.Columns["PR_STATUS"].Caption = " ";
                viewData.Columns["PR_STATUS"].ColVIndex = 1;
                viewData.Columns["PR_STATUS"].OptionsColumn.ReadOnly = true;
                viewData.Columns["PR_STATUS"].OptionsColumn.AllowEdit = true;
                viewData.Columns["PR_STATUS"].OptionsFilter.AllowFilter = false;
                viewData.Columns["PR_STATUS"].ColumnEdit = repRead;
                viewData.Columns["PR_STATUS"].Width = -1;

                viewData.Columns["READER"].Caption = " ";
                viewData.Columns["READER"].ColVIndex = 2;
                viewData.Columns["READER"].OptionsColumn.ReadOnly = true;
                viewData.Columns["READER"].OptionsColumn.AllowEdit = true;
                viewData.Columns["READER"].OptionsFilter.AllowFilter = false;
                viewData.Columns["READER"].ColumnEdit = repComment;
                viewData.Columns["READER"].Width = -1;

                viewData.Columns["SCANIMAGES"].ColVIndex = 3;
                viewData.Columns["SCANIMAGES"].ColumnEdit = linkScanImage;
                viewData.Columns["SCANIMAGES"].Caption = " ";
                viewData.Columns["SCANIMAGES"].Width = -1;
                viewData.Columns["SCANIMAGES"].OptionsColumn.ReadOnly = false;
                viewData.Columns["SCANIMAGES"].OptionsColumn.AllowEdit = true;
                viewData.Columns["SCANIMAGES"].OptionsFilter.AllowFilter = false;

                viewData.Columns["PATIENT_ID_LABEL"].ColVIndex = 4;
                viewData.Columns["PATIENT_ID_LABEL"].Caption = " ";
                viewData.Columns["PATIENT_ID_LABEL"].OptionsColumn.ReadOnly = true;
                viewData.Columns["PATIENT_ID_LABEL"].OptionsColumn.AllowEdit = false;

                viewData.Columns["PRIORITY"].ColVIndex = 5;
                viewData.Columns["PRIORITY"].ColumnEdit = repositoryItemImageComboBox2;
                viewData.Columns["PRIORITY"].Caption = "Priority";
                viewData.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;
                viewData.Columns["PRIORITY"].OptionsColumn.AllowEdit = false;

                viewData.Columns["TIMEDIFF"].ColVIndex = 7;
                viewData.Columns["TIMEDIFF"].Caption = "Waiting Time";
                viewData.Columns["TIMEDIFF"].OptionsColumn.ReadOnly = true;
                viewData.Columns["TIMEDIFF"].OptionsColumn.AllowEdit = false;

                viewData.Columns["ORDER_DT"].ColVIndex = 8;
                viewData.Columns["ORDER_DT"].Caption = "Order Time";
                viewData.Columns["ORDER_DT"].DisplayFormat.FormatString = "G";
                viewData.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                viewData.Columns["ORDER_DT"].Width = 73;
                viewData.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
                viewData.Columns["ORDER_DT"].OptionsColumn.AllowEdit = false;

                viewData.Columns["HN"].ColVIndex = 9;
                viewData.Columns["HN"].Caption = "HN";
                viewData.Columns["HN"].OptionsColumn.ReadOnly = true;
                viewData.Columns["HN"].OptionsColumn.AllowEdit = false;
                //viewData.Columns["HN"].ToolTip = "HN";

                viewData.Columns["PATIENT_NAME"].ColVIndex = 10;
                viewData.Columns["PATIENT_NAME"].Caption = "Patient Name";
                //viewData.Columns["PatientName"].Visible = true;
                viewData.Columns["PATIENT_NAME"].OptionsColumn.ReadOnly = true;
                viewData.Columns["PATIENT_NAME"].OptionsColumn.AllowEdit = false;

                viewData.Columns["AGE"].ColVIndex = 11;
                viewData.Columns["AGE"].Caption = "Age";
                //viewData.Columns["AGE"].Visible = true;
                viewData.Columns["AGE"].OptionsColumn.ReadOnly = true;
                viewData.Columns["AGE"].OptionsColumn.AllowEdit = false;

                viewData.Columns["ACCESSION_NO"].ColVIndex = 12;
                viewData.Columns["ACCESSION_NO"].Caption = "Accession No";
                //viewData.Columns["ACCESSION_NO"].Visible = true;
                viewData.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;
                viewData.Columns["ACCESSION_NO"].OptionsColumn.AllowEdit = false;

                viewData.Columns["EXAM_NAME"].ColVIndex = 13;
                viewData.Columns["EXAM_NAME"].Caption = "Exam Name";
                //viewData.Columns["EXAM_NAME"].Visible = true;
                viewData.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
                viewData.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;

                viewData.Columns["BPVIEW_NAME"].ColVIndex = 14;
                viewData.Columns["BPVIEW_NAME"].Caption = "Side";
                viewData.Columns["BPVIEW_NAME"].Visible = true;
                viewData.Columns["BPVIEW_NAME"].OptionsColumn.ReadOnly = true;
                viewData.Columns["BPVIEW_NAME"].OptionsColumn.AllowEdit = false;

                viewData.Columns["Unit"].ColVIndex = 17;
                viewData.Columns["Unit"].Caption = "Ordering Dept.";
                //viewData.Columns["Unit"].Visible = true;
                viewData.Columns["Unit"].OptionsColumn.ReadOnly = true;
                viewData.Columns["Unit"].OptionsColumn.AllowEdit = false;

                viewData.Columns["CLINIC_TYPE_TEXT"].ColVIndex = 18;
                viewData.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
                //viewData.Columns["CLINIC_TYPE_TEXT"].Visible = true;
                viewData.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.ReadOnly = true;
                viewData.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.AllowEdit = false;

                viewData.Columns["EXAM_UID"].ColVIndex = 19;
                viewData.Columns["EXAM_UID"].Caption = "Exam Code";
                //viewData.Columns["EXAM_UID"].Visible = true;
                viewData.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
                viewData.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;

                viewData.Columns["FLAG_ICON"].ColVIndex = 21;
                viewData.Columns["FLAG_ICON"].Caption = " ";
                viewData.Columns["FLAG_ICON"].Width = -1;
                viewData.Columns["FLAG_ICON"].ColumnEdit = repFlag;
                viewData.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;
                viewData.Columns["FLAG_ICON"].OptionsColumn.AllowEdit = false;
                viewData.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;

                viewData.Columns["ORDER_ID"].Caption = "Order No";
                viewData.Columns["ORDER_ID"].Visible = false;
                viewData.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;
                viewData.Columns["ORDER_ID"].OptionsColumn.AllowEdit = false;

                viewData.Columns["EXAM_ID"].Caption = "EXAM_ID";
                viewData.Columns["EXAM_ID"].Visible = false;
                viewData.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;
                viewData.Columns["EXAM_ID"].OptionsColumn.AllowEdit = false;
        }
        private void repComment_Click(object sender, EventArgs e)
        {
        }
        private void linkScanImage_Click(object sender, EventArgs e)
        {
        }
        private void viewData_DoubleClick(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle >= 0)
            {
                DataRow row = viewData.GetDataRow(viewData.FocusedRowHandle);
                dlgPeerReview frm = new dlgPeerReview(row);
                frm.ShowDialog();

                base.ShowWaitDialog();
                getData();
                base.CloseWaitDialog();
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            ToolTipControlInfo info = null;
            try
            {
                if (e.SelectedControl == grdData)
                {
                    GridView view = grdData.GetViewAt(e.ControlMousePosition) as GridView;
                    if (view == null) return;
                    GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle >= 0)
                        {
                            DataRow rowDetail = view.GetDataRow(hi.RowHandle);

                            switch (hi.Column.FieldName)
                            {
                                case "PATIENT_ID_LABEL":
                                    if (!string.IsNullOrEmpty(rowDetail["PATIENT_ID_LABEL"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["PATIENT_ID_DETAIL"].ToString());
                                        return;
                                    }
                                    break;
                                case "READER":
                                    if (!string.IsNullOrEmpty(rowDetail["READER"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["READER"].ToString());
                                        return;
                                    }
                                    break;
                                case "SCANIMAGES":
                                    if (rowDetail["SCANIMAGES"].ToString() == "0")
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), "No document.");
                                        return;
                                    }
                                    break;
                                case "FLAG_ICON":
                                    if (rowDetail["FLAG_ICON"].ToString() == "1")
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["FLAG_DESC"].ToString());
                                        return;
                                    }
                                    break;
                            }
                        }
                    }
                    if (hi.HitTest == GridHitTest.GroupPanel)
                    {
                        info = new ToolTipControlInfo(hi.HitTest, "Group panel");
                        return;
                    }

                    if (hi.HitTest == GridHitTest.RowIndicator)
                    {
                        info = new ToolTipControlInfo(GridHitTest.RowIndicator.ToString() + hi.RowHandle.ToString(), "Row Handle: " + hi.RowHandle.ToString());
                        return;
                    }
                    if (hi.HitTest == GridHitTest.Column)
                    {
                        switch (hi.Column.FieldName)
                        {
                            case "SCANIMAGES": info = new ToolTipControlInfo(hi.HitTest, "Document"); break;
                            case "READER": info = new ToolTipControlInfo(hi.HitTest, "Comments"); break;
                            case "PATIENT_ID_LABEL": info = new ToolTipControlInfo(hi.HitTest, "Patient Detail"); break;
                            case "FLAG_ICON": info = new ToolTipControlInfo(hi.HitTest, "Exam Flag"); break;
                        }
                    }
                }
            }
            finally
            {
                e.Info = info;
            }
        }

        private void barbtnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        
    }
}
