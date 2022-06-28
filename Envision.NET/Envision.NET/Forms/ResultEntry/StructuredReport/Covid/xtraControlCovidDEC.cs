using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Envision.BusinessLogic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.API.Native;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.Covid
{
    public partial class xtraControlCovidDEC : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable dtFinding = new DataTable();
        DataTable dtFindingDtl = new DataTable();
        DataTable dtFindingDtlItems = new DataTable();

        DataTable dttFinding = new DataTable();
        DataTable dttFindingDtl = new DataTable();

        DataTable dttImpression = new DataTable();
        DataTable dttImpressionDtl = new DataTable();

        DataTable dttSelectedFinding = new DataTable();
        DataTable dttSelectedImpression = new DataTable();

        public xtraControlCovidDEC()
        {
            InitializeComponent();
        }

        private void xtraControlCovidDEC_Load(object sender, EventArgs e)
        {
            LookUpSelect lv = new LookUpSelect();
            DataSet ds = lv.SelectRptFindingAll();
            dtFinding = ds.Tables[0].Copy();
            dtFindingDtl = ds.Tables[1].Copy();
            dtFindingDtlItems = ds.Tables[2].Copy();

            dttFinding.Columns.Add("CHK");
            dttFinding.Columns.Add("RPT_FINDING_ID",typeof(int));
            dttFinding.Columns.Add("FINDING_DISP_NAME");
            dttFinding.AcceptChanges();

            dttFindingDtl.Columns.Add("CHK");
            dttFindingDtl.Columns.Add("RPT_FINDING_ID", typeof(int));
            dttFindingDtl.Columns.Add("RPT_FINDING_DTL_ID", typeof(int));
            dttFindingDtl.Columns.Add("FINDINGDTL_DISP_NAME");
            dttFindingDtl.Columns.Add("RPT_FINDING_DTL_ITEM_ID", typeof(int));
            dttFindingDtl.Columns.Add("FINDING_DTL_ITEM_DISP_NAME");
            dttFindingDtl.Columns.Add("FINDING_DTL_ITEM_SUBID", typeof(int));
            dttFindingDtl.Columns.Add("SORT_ID", typeof(int));
            dttFindingDtl.AcceptChanges();

            dttImpression.Columns.Add("CHK");
            dttImpression.Columns.Add("RPT_FINDING_ID", typeof(int));
            dttImpression.Columns.Add("FINDING_DISP_NAME");
            dttImpression.AcceptChanges();

            dttImpressionDtl.Columns.Add("CHK");
            dttImpressionDtl.Columns.Add("RPT_FINDING_ID", typeof(int));
            dttImpressionDtl.Columns.Add("RPT_FINDING_DTL_ID", typeof(int));
            dttImpressionDtl.Columns.Add("FINDINGDTL_DISP_NAME");
            dttImpressionDtl.Columns.Add("RPT_FINDING_DTL_ITEM_ID", typeof(int));
            dttImpressionDtl.Columns.Add("FINDING_DTL_ITEM_DISP_NAME");
            dttImpressionDtl.Columns.Add("FINDING_DTL_ITEM_SUBID", typeof(int));
            dttImpressionDtl.Columns.Add("SORT_ID", typeof(int));
            dttImpressionDtl.AcceptChanges();

            dttSelectedFinding.Columns.Add("RPT_FINDING_ID", typeof(int));
            dttSelectedFinding.Columns.Add("RPT_FINDING_DTL_ID", typeof(int));
            dttSelectedFinding.Columns.Add("RPT_FINDING_DTL_ITEM_ID", typeof(int));
            dttSelectedFinding.AcceptChanges();
            dttSelectedImpression.Columns.Add("RPT_FINDING_ID", typeof(int));
            dttSelectedImpression.Columns.Add("RPT_FINDING_DTL_ID", typeof(int));
            dttSelectedImpression.Columns.Add("RPT_FINDING_DTL_ITEM_ID", typeof(int));
            dttSelectedImpression.AcceptChanges();

            DataRow[] rowsFinding = dtFinding.Select("DIAGNOSIS_TYPE = 'F' and IS_DISPLAY = 'Y'");
            preparingFindingData(rowsFinding);

            DataRow[] rowsImpression = dtFinding.Select("DIAGNOSIS_TYPE = 'I' and IS_DISPLAY = 'Y'");
            preparingImpressionData(rowsImpression);

            setSeverity();
            generateEditor();
        }

        private void preparingFindingData(DataRow[] rowsFinding)
        {
            foreach (DataRow rowFinding in rowsFinding)
            {
                if (dttFinding.Select("RPT_FINDING_ID=" + rowFinding["RPT_FINDING_ID"].ToString()).Length == 0)
                {
                    DataRow rowAdd = dttFinding.NewRow();
                    rowAdd["RPT_FINDING_ID"] = rowFinding["RPT_FINDING_ID"];
                    rowAdd["FINDING_DISP_NAME"] = rowFinding["DISP_NAME"];
                    dttFinding.Rows.Add(rowAdd);
                    dttFinding.AcceptChanges();
                }
            }

            grdFinding.DataSource = dttFinding;
            generateColumnsFinding();
        }
        private void generateColumnsFinding()
        {
            grdFinding.ForceInitialize();

            viewFinding.OptionsView.RowAutoHeight = true;
            viewFinding.OptionsView.ShowHorzLines = false;
            viewFinding.OptionsView.ColumnAutoWidth = true;

            for (int i = 0; i < viewFinding.Columns.Count; i++)
            {
                viewFinding.Columns[i].Visible = false;
            }

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkTemplate.ValueChecked = "Y";
            chkTemplate.ValueUnchecked = "N";
            chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkTemplate.Click += new EventHandler(chkFinding_Click);
            viewFinding.Columns["CHK"].Caption = "Chk";
            viewFinding.Columns["CHK"].Visible = true;
            viewFinding.Columns["CHK"].AppearanceCell.Options.UseTextOptions = true;
            //viewFinding.Columns["CHK"].OptionsColumn.ReadOnly = false;
            //viewFinding.Columns["CHK"].OptionsColumn.AllowEdit = true;
            //viewFinding.Columns["CHK"].OptionsColumn.AllowFocus = false;
            viewFinding.Columns["CHK"].ColumnEdit = chkTemplate;
            viewFinding.Columns["CHK"].OptionsColumn.FixedWidth = true;
            viewFinding.Columns["CHK"].VisibleIndex = 1;

            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit memOther = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            memOther.ScrollBars = ScrollBars.None;
            memOther.LinesCount = 0;
            viewFinding.Columns["FINDING_DISP_NAME"].Caption = "Display";
            viewFinding.Columns["FINDING_DISP_NAME"].Visible = true;
            viewFinding.Columns["FINDING_DISP_NAME"].OptionsColumn.ReadOnly = true;
            viewFinding.Columns["FINDING_DISP_NAME"].OptionsColumn.AllowEdit = false;
            viewFinding.Columns["FINDING_DISP_NAME"].OptionsColumn.AllowFocus = false;
            viewFinding.Columns["FINDING_DISP_NAME"].ColumnEdit = memOther;
            viewFinding.Columns["FINDING_DISP_NAME"].VisibleIndex = 2;
        }
        private void chkFinding_Click(object sender, EventArgs e)
        {
            if (viewFinding.FocusedRowHandle > -1)
            {
                DataRow row = viewFinding.GetDataRow(viewFinding.FocusedRowHandle);
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (!chk.Checked)
                {
                    DataRow[] rowsFindingDtl = dtFindingDtl.Select("IS_DISPLAY = 'Y' and RPT_FINDING_ID = " + row["RPT_FINDING_ID"].ToString());
                    preparingFindingDetailData(Convert.ToInt32(row["RPT_FINDING_ID"]), rowsFindingDtl);
                }
                else
                {
                    DataRow[] rowsClear = dttSelectedFinding.Select("RPT_FINDING_ID = " + row["RPT_FINDING_ID"].ToString());
                    foreach (DataRow rowClear in rowsClear)
                        dttSelectedFinding.Rows.Remove(rowClear);

                    DataRow[] rowsFindingDtl = dtFindingDtl.Select("IS_DISPLAY = 'Y' and RPT_FINDING_ID = " + row["RPT_FINDING_ID"].ToString());
                    preparingFindingDetailData(Convert.ToInt32(row["RPT_FINDING_ID"]), rowsFindingDtl);
                }
                generateEditor();
            }
        }
        private void viewFinding_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                if (e.Column.FieldName == "FINDING_DISP_NAME")
                {
                    DataRow row = viewFinding.GetDataRow(e.RowHandle);
                    DataRow[] rowsFindingDtl = dtFindingDtl.Select("IS_DISPLAY = 'Y' and RPT_FINDING_ID = " + row["RPT_FINDING_ID"].ToString());
                    preparingFindingDetailData(Convert.ToInt32(row["RPT_FINDING_ID"]),rowsFindingDtl);
                }
            }
        }

        private void preparingFindingDetailData(int rptFindingId,DataRow[] rowsFindingDtl)
        {
            dttFindingDtl = dttFindingDtl.Clone();
            foreach (DataRow rowFindingDtl in rowsFindingDtl)
            {
                DataRow[] rowsFindingDtlItem = dtFindingDtlItems.Select("RPT_FINDING_DTL_ID = " + rowFindingDtl["RPT_FINDING_DTL_ID"].ToString());

                foreach (DataRow rowFindingDtlItem in rowsFindingDtlItem)
                {
                    DataView dvChkSelected = dttSelectedFinding.DefaultView;
                    dvChkSelected.RowFilter = "RPT_FINDING_DTL_ITEM_ID = " + rowFindingDtlItem["RPT_FINDING_DTL_ITEM_ID"].ToString();

                    DataRow rowAdd = dttFindingDtl.NewRow();
                    rowAdd["CHK"] = dvChkSelected.Count > 0 ? "Y" : "N";
                    rowAdd["RPT_FINDING_ID"] = rptFindingId;
                    rowAdd["RPT_FINDING_DTL_ID"] = rowFindingDtl["RPT_FINDING_DTL_ID"];
                    rowAdd["FINDINGDTL_DISP_NAME"] = rowFindingDtl["DISP_NAME"];
                    rowAdd["RPT_FINDING_DTL_ITEM_ID"] = rowFindingDtlItem["RPT_FINDING_DTL_ITEM_ID"];
                    rowAdd["FINDING_DTL_ITEM_DISP_NAME"] = rowFindingDtlItem["DISP_NAME"];
                    rowAdd["SORT_ID"] = rowFindingDtlItem["SORT_ID"];
                    dttFindingDtl.Rows.Add(rowAdd);
                    dttFindingDtl.AcceptChanges();
                }
            }
            grdFindingDetail.DataSource = dttFindingDtl;
            grdFindingDetail.Refresh();
            generateColumnsFindingDetail();
        }
        private void generateColumnsFindingDetail()
        {
            grdFindingDetail.ForceInitialize();

            viewFindingDetail.OptionsView.RowAutoHeight = true;
            viewFindingDetail.OptionsView.ShowHorzLines = false;
            viewFindingDetail.OptionsView.ColumnAutoWidth = true;

            for (int i = 0; i < viewFindingDetail.Columns.Count; i++)
            {
                viewFindingDetail.Columns[i].Visible = false;
            }

            viewFindingDetail.Columns["FINDINGDTL_DISP_NAME"].GroupIndex = 1;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkTemplate.ValueChecked = "Y";
            chkTemplate.ValueUnchecked = "N";
            chkTemplate.ValueGrayed = "N";
            chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkTemplate.Click += new EventHandler(chkFindingDetail_Click);
            viewFindingDetail.Columns["CHK"].Caption = "Chk";
            viewFindingDetail.Columns["CHK"].Visible = true;
            viewFindingDetail.Columns["CHK"].AppearanceCell.Options.UseTextOptions = true;
            //viewFindingDetail.Columns["CHK"].OptionsColumn.ReadOnly = true;
            //viewFindingDetail.Columns["CHK"].OptionsColumn.AllowEdit = false;
            //viewFindingDetail.Columns["CHK"].OptionsColumn.AllowFocus = false;
            viewFindingDetail.Columns["CHK"].ColumnEdit = chkTemplate;
            viewFindingDetail.Columns["CHK"].OptionsColumn.FixedWidth = true;
            viewFindingDetail.Columns["CHK"].VisibleIndex = 1;

            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit memOther = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            memOther.ScrollBars = ScrollBars.None;
            memOther.LinesCount = 0;
            viewFindingDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].Caption = "Sender";
            viewFindingDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].Visible = true;
            viewFindingDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].OptionsColumn.ReadOnly = true;
            viewFindingDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].OptionsColumn.AllowEdit = false;
            viewFindingDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].OptionsColumn.AllowFocus = false;
            viewFindingDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].ColumnEdit = memOther;
            viewFindingDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].VisibleIndex = 2;
        }
        private void chkFindingDetail_Click(object sender, EventArgs e)
        {
            if (viewFindingDetail.FocusedRowHandle > -1)
            {
                DataRow rowSelected = viewFindingDetail.GetDataRow(viewFindingDetail.FocusedRowHandle);
                DataRow[] rowSelectData = dtFindingDtlItems.Select("RPT_FINDING_DTL_ITEM_ID =" + rowSelected["RPT_FINDING_DTL_ITEM_ID"].ToString());

                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (!chk.Checked)
                {
                    rowSelected["CHK"] = "Y";

                    #region Check Multiple
                    if (rowSelectData[0]["IS_MULTIPLE"].ToString() == "N")
                    {
                        DataRow[] rowClearCheckBox = dtFindingDtlItems.Select("RPT_FINDING_DTL_ID = " + rowSelectData[0]["RPT_FINDING_DTL_ID"].ToString());
                        foreach (DataRow rowClear in rowClearCheckBox)
                        {
                            DataRow[] rowClearTemp = dttFindingDtl.Select("RPT_FINDING_DTL_ITEM_ID  = " + rowClear["RPT_FINDING_DTL_ITEM_ID"].ToString());
                            if (rowClearTemp.Length > 0)
                                if (rowClear["RPT_FINDING_DTL_ITEM_ID"] == rowSelected["RPT_FINDING_DTL_ITEM_ID"])
                                    rowClearTemp[0]["CHK"] = "Y";
                                else
                                {
                                    rowClearTemp[0]["CHK"] = "N";
                                    DataRow[] rowRemove = dttSelectedFinding.Select("RPT_FINDING_DTL_ITEM_ID = " + rowClear["RPT_FINDING_DTL_ITEM_ID"].ToString());
                                    if (rowRemove.Length > 0)
                                        dttSelectedFinding.Rows.Remove(rowRemove[0]);
                                }
                        }
                    }
                    #endregion

                    #region Manual Selected
                    if (rowSelectData[0]["FINDINGS_DTL_UID"].ToString() == "SIGNIFICANT ABNORMALITIES")
                    {
                        DataRow[] rowsFinding = dtFinding.Select("DIAGNOSIS_TYPE = 'F' and IS_DISPLAY = 'N'");
                        preparingFindingData(rowsFinding);
                    }
                    #endregion

                    #region Check Next Tab
                    if (rowSelectData[0]["IS_MOVE"].ToString() == "Y")
                    {
                        DataRow[] rowChkCheckBoxFinding = dttFindingDtl.Select("RPT_FINDING_DTL_ITEM_ID = " + rowSelectData[0]["RPT_FINDING_DTL_ITEM_ID"].ToString());
                        rowChkCheckBoxFinding[0]["CHK"] = "Y";
                        grdFindingDetail.Refresh();

                        xtraTabResultControl.SelectedTabPageIndex = 1;
                        DataRow[] rowsImpCategory = dtFinding.Select("DIAGNOSIS_TYPE = 'I' and FINDINGS_UID = 'CATEGORY'");
                        if (rowsImpCategory.Length > 0)
                        {
                            DataRow[] rowChkCheckBoxImpression = dttImpression.Select("RPT_FINDING_ID = " + rowsImpCategory[0]["RPT_FINDING_ID"].ToString());
                            rowChkCheckBoxImpression[0]["CHK"] = "Y";
                            grdImpression.Refresh();

                            DataRow[] rowsFindingDtl = dtFindingDtl.Select("IS_DISPLAY = 'Y' and RPT_FINDING_ID = " + rowsImpCategory[0]["RPT_FINDING_ID"].ToString());
                            preparingImpressionDetailData(Convert.ToInt32(rowsImpCategory[0]["RPT_FINDING_ID"]), rowsFindingDtl);

                            if (rowSelectData[0]["NAME"].ToString() == "No")
                            {
                                DataRow[] rowCategory1 = dtFindingDtlItems.Select("FINDINGS_DTL_UID = 'CATEGORY_1'");
                                DataRow[] rowChkCheckBoxImpressDtl = dttImpressionDtl.Select("RPT_FINDING_DTL_ITEM_ID = " + rowCategory1[0]["RPT_FINDING_DTL_ITEM_ID"].ToString());
                                bindingDataImpressionDetail(rowChkCheckBoxImpressDtl[0], true);
                            }
                            else if (rowSelectData[0]["NAME"].ToString() == "Minor")
                            {
                                DataRow[] rowCategory2 = dtFindingDtlItems.Select("FINDINGS_DTL_UID = 'CATEGORY_2'");
                                DataRow[] rowChkCheckBoxImpressDtl = dttImpressionDtl.Select("RPT_FINDING_DTL_ITEM_ID = " + rowCategory2[0]["RPT_FINDING_DTL_ITEM_ID"].ToString());
                                bindingDataImpressionDetail(rowChkCheckBoxImpressDtl[0], true);
                            }
                        }

                    }
                    #endregion

                    DataRow rowAdd = dttSelectedFinding.NewRow();
                    rowAdd["RPT_FINDING_ID"] = rowSelected["RPT_FINDING_ID"];
                    rowAdd["RPT_FINDING_DTL_ID"] = rowSelectData[0]["RPT_FINDING_DTL_ID"];
                    rowAdd["RPT_FINDING_DTL_ITEM_ID"] = rowSelected["RPT_FINDING_DTL_ITEM_ID"];
                    dttSelectedFinding.Rows.Add(rowAdd);
                    dttSelectedFinding.AcceptChanges();
                }
                else {
                    rowSelected["CHK"] = "N";
                    DataRow[] rowRemove = dttSelectedFinding.Select("RPT_FINDING_DTL_ITEM_ID = " + rowSelected["RPT_FINDING_DTL_ITEM_ID"].ToString());
                    if (rowRemove.Length > 0)
                        dttSelectedFinding.Rows.Remove(rowRemove[0]);
                }


                foreach (DataRow rowFindingCheckBox in dttSelectedFinding.Rows)
                {
                    DataRow[] rowChkCheckBoxFinding = dttFinding.Select("RPT_FINDING_ID = " + rowFindingCheckBox["RPT_FINDING_ID"].ToString());
                    if (rowChkCheckBoxFinding.Length == 0)
                        rowChkCheckBoxFinding[0]["CHK"] = "N";
                    else
                        rowChkCheckBoxFinding[0]["CHK"] = "Y";
                }
                grdFinding.Refresh();

                generateEditor();
            }
        }

        private void preparingImpressionData(DataRow[] rowsImpression)
        {
            foreach (DataRow rowImpression in rowsImpression)
            {
                if (dttImpression.Select("RPT_FINDING_ID=" + rowImpression["RPT_FINDING_ID"].ToString()).Length == 0)
                {
                    DataRow rowAdd = dttImpression.NewRow();
                    rowAdd["RPT_FINDING_ID"] = rowImpression["RPT_FINDING_ID"];
                    rowAdd["FINDING_DISP_NAME"] = rowImpression["DISP_NAME"];
                    dttImpression.Rows.Add(rowAdd);
                    dttImpression.AcceptChanges();
                }
            }

            grdImpression.DataSource = dttImpression;
            generateColumnsImpresssion();
        }
        private void generateColumnsImpresssion()
        {
            grdImpression.ForceInitialize();

            viewImpression.OptionsView.RowAutoHeight = true;
            viewImpression.OptionsView.ShowHorzLines = false;
            viewImpression.OptionsView.ColumnAutoWidth = true;

            for (int i = 0; i < viewImpression.Columns.Count; i++)
            {
                viewImpression.Columns[i].Visible = false;
            }

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkTemplate.ValueChecked = "Y";
            chkTemplate.ValueUnchecked = "N";
            chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkTemplate.Click += new EventHandler(chkImpression_Click);
            viewImpression.Columns["CHK"].Caption = "Chk";
            viewImpression.Columns["CHK"].Visible = true;
            viewImpression.Columns["CHK"].AppearanceCell.Options.UseTextOptions = true;
            //viewFinding.Columns["CHK"].OptionsColumn.ReadOnly = false;
            //viewFinding.Columns["CHK"].OptionsColumn.AllowEdit = true;
            //viewFinding.Columns["CHK"].OptionsColumn.AllowFocus = false;
            viewImpression.Columns["CHK"].ColumnEdit = chkTemplate;
            viewImpression.Columns["CHK"].OptionsColumn.FixedWidth = true;
            viewImpression.Columns["CHK"].VisibleIndex = 1;

            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit memOther = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            memOther.ScrollBars = ScrollBars.None;
            memOther.LinesCount = 0;
            viewImpression.Columns["FINDING_DISP_NAME"].Caption = "Display";
            viewImpression.Columns["FINDING_DISP_NAME"].Visible = true;
            viewImpression.Columns["FINDING_DISP_NAME"].OptionsColumn.ReadOnly = true;
            viewImpression.Columns["FINDING_DISP_NAME"].OptionsColumn.AllowEdit = false;
            viewImpression.Columns["FINDING_DISP_NAME"].OptionsColumn.AllowFocus = false;
            viewImpression.Columns["FINDING_DISP_NAME"].ColumnEdit = memOther;
            viewImpression.Columns["FINDING_DISP_NAME"].VisibleIndex = 2;
        }
        private void chkImpression_Click(object sender, EventArgs e)
        {
            if (viewImpression.FocusedRowHandle > -1)
            {
                DataRow row = viewImpression.GetDataRow(viewImpression.FocusedRowHandle);
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (!chk.Checked)
                {
                    DataRow[] rowsFindingDtl = dtFindingDtl.Select("IS_DISPLAY = 'Y' and RPT_FINDING_ID = " + row["RPT_FINDING_ID"].ToString());
                    preparingImpressionDetailData(Convert.ToInt32(row["RPT_FINDING_ID"]), rowsFindingDtl);
                }
                else
                {
                    DataRow[] rowsClear = dttSelectedImpression.Select("RPT_FINDING_ID = " + row["RPT_FINDING_ID"].ToString());
                    foreach (DataRow rowClear in rowsClear)
                        dttSelectedImpression.Rows.Remove(rowClear);

                    DataRow[] rowsFindingDtl = dtFindingDtl.Select("IS_DISPLAY = 'Y' and RPT_FINDING_ID = " + row["RPT_FINDING_ID"].ToString());
                    preparingImpressionDetailData(Convert.ToInt32(row["RPT_FINDING_ID"]), rowsFindingDtl);
                }
                generateEditor();
            }
        }
        private void viewImpression_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                if (e.Column.FieldName == "FINDING_DISP_NAME")
                {
                    DataRow row = viewImpression.GetDataRow(e.RowHandle);
                    DataRow[] rowsFindingDtl = dtFindingDtl.Select("IS_DISPLAY = 'Y' and RPT_FINDING_ID = " + row["RPT_FINDING_ID"].ToString());
                    preparingImpressionDetailData(Convert.ToInt32(row["RPT_FINDING_ID"]), rowsFindingDtl);
                }
            }
        }
        
        private void preparingImpressionDetailData(int rptFindingId, DataRow[] rowsImpressionDtl)
        {
            dttImpressionDtl = dttImpressionDtl.Clone();
            foreach (DataRow rowImpressiongDtl in rowsImpressionDtl)
            {
                DataRow[] rowsImpressionDtlItem = dtFindingDtlItems.Select("ISNULL(PARENT_ID,0) = 0 and  RPT_FINDING_DTL_ID = " + rowImpressiongDtl["RPT_FINDING_DTL_ID"].ToString());

                foreach (DataRow rowImpressionDtlItem in rowsImpressionDtlItem)
                {
                    DataView dvChkSelected = dttSelectedImpression.DefaultView;
                    dvChkSelected.RowFilter = "RPT_FINDING_DTL_ITEM_ID = " + rowImpressionDtlItem["RPT_FINDING_DTL_ITEM_ID"].ToString();

                    DataRow rowAdd = dttImpressionDtl.NewRow();
                    rowAdd["CHK"] = dvChkSelected.Count > 0 ? "Y" : "N";
                    rowAdd["RPT_FINDING_ID"] = rptFindingId;
                    rowAdd["RPT_FINDING_DTL_ID"] = rowImpressiongDtl["RPT_FINDING_DTL_ID"];
                    rowAdd["FINDINGDTL_DISP_NAME"] = rowImpressiongDtl["DISP_NAME"];
                    rowAdd["RPT_FINDING_DTL_ITEM_ID"] = rowImpressionDtlItem["RPT_FINDING_DTL_ITEM_ID"];
                    rowAdd["FINDING_DTL_ITEM_DISP_NAME"] = rowImpressionDtlItem["DISP_NAME"];
                    rowAdd["SORT_ID"] = rowImpressionDtlItem["SORT_ID"];
                    dttImpressionDtl.Rows.Add(rowAdd);
                    dttImpressionDtl.AcceptChanges();
                }
            }
            grdImpressionDetail.DataSource = dttImpressionDtl;
            grdImpressionDetail.Refresh();
            generateColumnsImpressionDetail();
        }
        private void generateColumnsImpressionDetail()
        {
            grdImpressionDetail.ForceInitialize();

            viewImpressionDetail.OptionsView.RowAutoHeight = true;
            viewImpressionDetail.OptionsView.ShowHorzLines = false;
            viewImpressionDetail.OptionsView.ColumnAutoWidth = true;

            for (int i = 0; i < viewImpressionDetail.Columns.Count; i++)
            {
                viewImpressionDetail.Columns[i].Visible = false;
            }

            viewImpressionDetail.Columns["FINDINGDTL_DISP_NAME"].GroupIndex = 1;
            viewImpressionDetail.Columns["SORT_ID"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkTemplate.ValueChecked = "Y";
            chkTemplate.ValueUnchecked = "N";
            chkTemplate.ValueGrayed = "N";
            chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkTemplate.Click += new EventHandler(chkImpressionDetail_Click);
            viewImpressionDetail.Columns["CHK"].Caption = "Chk";
            viewImpressionDetail.Columns["CHK"].Visible = true;
            viewImpressionDetail.Columns["CHK"].AppearanceCell.Options.UseTextOptions = true;
            //viewFindingDetail.Columns["CHK"].OptionsColumn.ReadOnly = true;
            //viewFindingDetail.Columns["CHK"].OptionsColumn.AllowEdit = false;
            //viewFindingDetail.Columns["CHK"].OptionsColumn.AllowFocus = false;
            viewImpressionDetail.Columns["CHK"].ColumnEdit = chkTemplate;
            viewImpressionDetail.Columns["CHK"].OptionsColumn.FixedWidth = true;
            viewImpressionDetail.Columns["CHK"].VisibleIndex = 1;

            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit memOther = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            memOther.ScrollBars = ScrollBars.None;
            memOther.LinesCount = 0;
            viewImpressionDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].Caption = "Sender";
            viewImpressionDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].Visible = true;
            viewImpressionDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].OptionsColumn.ReadOnly = true;
            viewImpressionDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].OptionsColumn.AllowEdit = false;
            viewImpressionDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].OptionsColumn.AllowFocus = false;
            viewImpressionDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].ColumnEdit = memOther;
            viewImpressionDetail.Columns["FINDING_DTL_ITEM_DISP_NAME"].VisibleIndex = 2;
        }
        private void chkImpressionDetail_Click(object sender, EventArgs e)
        {
            if (viewImpressionDetail.FocusedRowHandle > -1)
            {
                DataRow rowSelected = viewImpressionDetail.GetDataRow(viewImpressionDetail.FocusedRowHandle);
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                bindingDataImpressionDetail(rowSelected, !chk.Checked);
                generateEditor();
            }
        }
        private void bindingDataImpressionDetail(DataRow rowSelected, bool isCheck)
        {
            DataRow[] rowSelectData = dtFindingDtlItems.Select("RPT_FINDING_DTL_ITEM_ID =" + rowSelected["RPT_FINDING_DTL_ITEM_ID"].ToString());
            if (isCheck)
            {
                rowSelected["CHK"] = "Y";

                #region Check Multiple
                if (rowSelectData[0]["IS_MULTIPLE"].ToString() == "N")
                {
                    DataRow[] rowClearCheckBox = dtFindingDtlItems.Select("RPT_FINDING_DTL_ID = " + rowSelectData[0]["RPT_FINDING_DTL_ID"].ToString());
                    foreach (DataRow rowClear in rowClearCheckBox)
                    {
                        DataRow[] rowClearTemp = dttImpressionDtl.Select("RPT_FINDING_DTL_ITEM_ID  = " + rowClear["RPT_FINDING_DTL_ITEM_ID"].ToString());
                        if (rowClearTemp.Length > 0)
                            if (rowClear["RPT_FINDING_DTL_ITEM_ID"] == rowSelected["RPT_FINDING_DTL_ITEM_ID"])
                                rowClearTemp[0]["CHK"] = "Y";
                            else
                            {
                                rowClearTemp[0]["CHK"] = "N";
                                DataRow[] rowRemove = dttSelectedImpression.Select("RPT_FINDING_DTL_ITEM_ID = " + rowClear["RPT_FINDING_DTL_ITEM_ID"].ToString());
                                if (rowRemove.Length > 0)
                                    dttSelectedImpression.Rows.Remove(rowRemove[0]);
                            }
                    }
                }
                #endregion

                #region Sub Items
                if (string.IsNullOrEmpty(rowSelected["FINDING_DTL_ITEM_SUBID"].ToString()))
                {
                    DataRow[] rowsClearSub = dttImpressionDtl.Select("ISNULL(FINDING_DTL_ITEM_SUBID,0) <> 0");
                    foreach (DataRow rowClearSub in rowsClearSub)
                    {
                        string _rptFindingDtlItemId = rowClearSub["RPT_FINDING_DTL_ITEM_ID"].ToString();

                        DataRow[] rowRemove = dttSelectedImpression.Select("RPT_FINDING_DTL_ITEM_ID = " + _rptFindingDtlItemId);
                        if (rowRemove.Length > 0)
                        {
                            dttSelectedImpression.Rows.Remove(rowRemove[0]);
                            dttSelectedImpression.AcceptChanges();
                        }

                        dttImpressionDtl.Rows.Remove(rowClearSub);
                    }
                    dttImpressionDtl.AcceptChanges();

                    if (!string.IsNullOrEmpty(rowSelectData[0]["SUBITEM_ID"].ToString()))
                    {
                        DataRow[] rowImpressionDtl = dtFindingDtl.Select("RPT_FINDING_DTL_ID = " + rowSelectData[0]["SUBITEM_ID"].ToString());
                        DataRow[] rowsImpressionDtlItem = dtFindingDtlItems.Select("RPT_FINDING_DTL_ID = " + rowSelectData[0]["SUBITEM_ID"].ToString());

                        foreach (DataRow rowImpressionDtlItem in rowsImpressionDtlItem)
                        {
                            DataView dvChkSelected = dttSelectedImpression.DefaultView;
                            dvChkSelected.RowFilter = "RPT_FINDING_DTL_ITEM_ID = " + rowImpressionDtlItem["RPT_FINDING_DTL_ITEM_ID"].ToString();

                            if (dttImpressionDtl.Select("RPT_FINDING_DTL_ITEM_ID = " + rowImpressionDtlItem["RPT_FINDING_DTL_ITEM_ID"].ToString()).Length == 0)
                            {
                                DataRow rowAddSub = dttImpressionDtl.NewRow();
                                rowAddSub["CHK"] = dvChkSelected.Count > 0 ? "Y" : "N";
                                rowAddSub["RPT_FINDING_ID"] = rowImpressionDtl[0]["RPT_FINDING_ID"];
                                rowAddSub["RPT_FINDING_DTL_ID"] = rowImpressionDtl[0]["RPT_FINDING_DTL_ID"];
                                rowAddSub["FINDINGDTL_DISP_NAME"] = rowImpressionDtl[0]["DISP_NAME"];
                                rowAddSub["RPT_FINDING_DTL_ITEM_ID"] = rowImpressionDtlItem["RPT_FINDING_DTL_ITEM_ID"];
                                rowAddSub["FINDING_DTL_ITEM_DISP_NAME"] = rowImpressionDtlItem["DISP_NAME"];
                                rowAddSub["FINDING_DTL_ITEM_SUBID"] = rowSelectData[0]["SUBITEM_ID"];
                                rowAddSub["SORT_ID"] = rowSelectData[0]["SORT_ID"];
                                dttImpressionDtl.Rows.Add(rowAddSub);
                                dttImpressionDtl.AcceptChanges();
                            }
                        }
                    }
                }
                dttImpressionDtl.Rows[dttImpressionDtl.Rows.IndexOf(rowSelected)]["CHK"] = "Y";
                grdImpressionDetail.DataSource = dttImpressionDtl;
                //grdImpressionDetail.Refresh();
                //generateColumnsImpressionDetail();
                #endregion


                DataRow rowAdd = dttSelectedImpression.NewRow();
                rowAdd["RPT_FINDING_ID"] = rowSelected["RPT_FINDING_ID"];
                rowAdd["RPT_FINDING_DTL_ID"] = rowSelectData[0]["RPT_FINDING_DTL_ID"];
                rowAdd["RPT_FINDING_DTL_ITEM_ID"] = rowSelected["RPT_FINDING_DTL_ITEM_ID"];
                dttSelectedImpression.Rows.Add(rowAdd);
                dttSelectedImpression.AcceptChanges();

            }
            else
            {
                rowSelected["CHK"] = "N";
                DataRow[] rowRemove = dttSelectedImpression.Select("RPT_FINDING_DTL_ITEM_ID = " + rowSelected["RPT_FINDING_DTL_ITEM_ID"].ToString());
                if (rowRemove.Length > 0)
                    dttSelectedImpression.Rows.Remove(rowRemove[0]);
            }

            foreach (DataRow rowFindingCheckBox in dttSelectedImpression.Rows)
            {
                DataRow[] rowChkCheckBoxFinding = dttImpression.Select("RPT_FINDING_ID = " + rowFindingCheckBox["RPT_FINDING_ID"].ToString());
                if (rowChkCheckBoxFinding.Length == 0)
                    rowChkCheckBoxFinding[0]["CHK"] = "N";
                else
                    rowChkCheckBoxFinding[0]["CHK"] = "Y";
            }
            grdImpression.Refresh();

            setSeverity();
        }

        private void setSeverity()
        {
            lblSeverity.Text = "NORMAL";
            lblSeverity.ForeColor = Color.Green;
            foreach (DataRow rowSelect in dttSelectedImpression.Rows)
            {
                DataRow[] rows = dtFindingDtlItems.Select("ISNULL(COLOR,'N') <> 'N' and RPT_FINDING_DTL_ITEM_ID = " + rowSelect["RPT_FINDING_DTL_ITEM_ID"].ToString());
                if (rows.Length > 0)
                {
                    switch (rows[0]["COLOR"].ToString())
                    {
                        case "orange":
                            lblSeverity.Text = "ABNORMAL";
                            lblSeverity.ForeColor = Color.Orange;
                            break;
                        case "red":
                            lblSeverity.Text = "ABNORMAL";
                            lblSeverity.ForeColor = Color.Red;
                            break;
                        default: lblSeverity.Text = "NORMAL";
                            lblSeverity.ForeColor = Color.Green;
                            break;
                    }
                    break;
                }

            }
        }
        private void generateEditor()
        {
            rtPreview.Text = "";
            genFinding();

            DocumentPosition pos1 = rtPreview.Document.Range.End; //rtPadN.Document.CaretPosition;
            newLine(pos1, rtPreview);
            newLine(pos1, rtPreview);

            genImpression();

            DocumentRange sel = rtPreview.Document.Selection;
            CharacterProperties charProperties = rtPreview.Document.BeginUpdateCharacters(sel);
            charProperties.FontName = "Microsoft Sans Serif";
            charProperties.FontSize = 10;
            rtPreview.Document.EndUpdateCharacters(charProperties);
        }
        private void genFinding()
        {
            addText( "Finding : ", true);
            DocumentPosition pos1 = rtPreview.Document.Range.End; //rtPadN.Document.CaretPosition;
            newLine(pos1, rtPreview);
            newLine(pos1, rtPreview);

            DataRow[] rowsFinding = dtFinding.Select("DIAGNOSIS_TYPE = 'F' and RPT_FINDING_ID <> 1");
            foreach (DataRow row in rowsFinding)
            {
                string _master = row["DISP_NAME"].ToString();
                string _master_text = _master + " : ";
                addText(_master_text, true);

                DataRow[] rowsDetail = dttSelectedFinding.Select("RPT_FINDING_ID = " + row["RPT_FINDING_ID"].ToString());
                if (rowsDetail.Length > 0)
                {
                    foreach (DataRow rowDtl in rowsDetail)
                    {
                        DataRow[] rowsFindingDtl = dtFindingDtl.Select("RPT_FINDING_DTL_ID = " + rowDtl["RPT_FINDING_DTL_ID"].ToString());
                        if (rowsFindingDtl[0]["DISP_NAME"].ToString() == _master)
                        {
                            DataRow[] rowsFindingItems = dtFindingDtlItems.Select("RPT_FINDING_DTL_ITEM_ID = " + rowDtl["RPT_FINDING_DTL_ITEM_ID"].ToString());
                            addText(rowsFindingItems[0]["DISP_NAME"].ToString() + ",", false);
                        }
                        else
                        {
                            DocumentPosition pos = rtPreview.Document.Range.End; //rtPadN.Document.CaretPosition;
                            newLine(pos, rtPreview);

                            addText(rowsFindingDtl[0]["DISP_NAME"].ToString() + " : ", true);

                            DataRow[] rowsFindingItems = dtFindingDtlItems.Select("RPT_FINDING_DTL_ITEM_ID = " + rowDtl["RPT_FINDING_DTL_ITEM_ID"].ToString());
                            addText(rowsFindingItems[0]["DISP_NAME"].ToString(), false);
                        }
                    }
                }
                else
                {
                    string _detail = "Normal";
                    addText(_detail, false);
                }
                DocumentPosition pos2 = rtPreview.Document.Range.End; //rtPadN.Document.CaretPosition;
                newLine(pos2, rtPreview);
            }
        }
        private void genImpression()
        {
            if (dttSelectedImpression.Rows.Count == 0)
                return;

            addText("Impression : ", true);
            DocumentPosition pos1 = rtPreview.Document.Range.End; //rtPadN.Document.CaretPosition;
            newLine(pos1, rtPreview);
            newLine(pos1, rtPreview);


            foreach (DataRow rowSelect in dttSelectedImpression.Rows)
            {
                DataRow[] rowsFindingSelected = dtFinding.Select("RPT_FINDING_ID = " + rowSelect["RPT_FINDING_ID"].ToString());
                string _master = rowsFindingSelected[0]["SINGULAR"].ToString();
                string _master_text = _master + " : ";
                //addText(_master_text, true);

                DataRow[] rowsFindingDtl = dtFindingDtl.Select("RPT_FINDING_DTL_ID = " + rowSelect["RPT_FINDING_DTL_ID"].ToString());
                if (rowsFindingDtl[0]["SINGULAR"].ToString() == _master)
                {
                    DataRow[] rowsFindingItems = dtFindingDtlItems.Select("RPT_FINDING_DTL_ITEM_ID = " + rowSelect["RPT_FINDING_DTL_ITEM_ID"].ToString());
                    addText(rowsFindingItems[0]["DISP_NAME"].ToString() + ",", false);
                }
                else
                {
                    DocumentPosition pos = rtPreview.Document.Range.End; //rtPadN.Document.CaretPosition;
                    newLine(pos, rtPreview);

                    addText(rowsFindingDtl[0]["DISP_NAME"].ToString() + " : ", true);
                    DataRow[] rowsFindingItems = dtFindingDtlItems.Select("RPT_FINDING_DTL_ITEM_ID = " + rowSelect["RPT_FINDING_DTL_ITEM_ID"].ToString());
                    addText(rowsFindingItems[0]["SINGULAR"].ToString() == "$" ? rowsFindingItems[0]["DISP_NAME"].ToString() : rowsFindingItems[0]["SINGULAR"].ToString(), false);
                }
            }
        }

        private void addText(string text, bool isBold)
        {
            DocumentPosition pos = rtPreview.Document.Range.End; //rtPadN.Document.CaretPosition;
            Document doc = rtPreview.Document;
            int index = pos.ToInt();
            if (index > 0)
                index--;
            rtPreview.Document.InsertText(pos, text);
            DocumentRange rr = rtPreview.Document.CreateRange(index, text.Length);
            CharacterProperties cc = doc.BeginUpdateCharacters(rr);
            cc.Bold = isBold;
            cc.Italic = false;
            cc.Underline = false ? UnderlineType.Single : UnderlineType.None;
            doc.EndUpdateCharacters(cc);
        }
        private void newLine(DocumentPosition pos, DevExpress.XtraRichEdit.RichEditControl rtPad)
        {
            rtPad.Document.InsertParagraph(pos);
        }

        private void viewFindingDetail_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            (e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).ButtonBounds = Rectangle.Empty;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info.Column.FieldName == "FINDINGDTL_DISP_NAME")
            {
                DataRow rowSelected = viewFindingDetail.GetDataRow(info.RowHandle);
                info.Appearance.ForeColor = Color.Black;
                info.Appearance.BackColor = Color.Transparent;
                info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                info.GroupText = rowSelected["FINDINGDTL_DISP_NAME"].ToString();

            }
        }
        private void viewFindingDetail_EndGrouping(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraGrid.Views.Grid.GridView).ExpandAllGroups();
        }
        private void viewFindingDetail_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            e.Allow = false;
        }

        private void viewImpressionDetail_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            (e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).ButtonBounds = Rectangle.Empty;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info.Column.FieldName == "FINDINGDTL_DISP_NAME")
            {
                DataRow rowSelected = viewImpressionDetail.GetDataRow(info.RowHandle);
                info.Appearance.ForeColor = Color.Black;
                info.Appearance.BackColor = Color.Transparent;
                info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                info.GroupText = rowSelected["FINDINGDTL_DISP_NAME"].ToString();

            }
        }
        private void viewImpressionDetail_EndGrouping(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraGrid.Views.Grid.GridView).ExpandAllGroups();
        }
        private void viewImpressionDetail_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            e.Allow = false;
        }

        private void viewImpressionDetail_EndSorting(object sender, EventArgs e)
        {
        }
    }
}
