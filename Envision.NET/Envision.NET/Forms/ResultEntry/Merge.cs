using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Columns;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.NET.Forms.Technologist;
using Envision.NET.Forms.EMR;
namespace Envision.NET.Forms.ResultEntry
{
    public partial class Merge : DevExpress.XtraBars.Ribbon.RibbonForm//Form
    {
        private DataRow dr;
        private DataRow[] drSelect;
        private DataTable dttHis;
        private Envision.BusinessLogic.ResultEntry result;
        private GBLEnvVariable env;
        private MyMessageBox msg;
        private frmPopupOrderOrScheduleSummary _orderSummary;

        public Merge(DataRow data)
        {
            InitializeComponent();
            dr = data;
            dttHis = new DataTable();
            env = new GBLEnvVariable();
            msg = new MyMessageBox();
            result = new Envision.BusinessLogic.ResultEntry();
            initDesc();
            initSource();
            this._orderSummary = new frmPopupOrderOrScheduleSummary();
        }
        public Merge(DataRow data,DataRow[] _drSelect)
        {
            InitializeComponent();
            dr = data;
            drSelect = _drSelect;
            dttHis = new DataTable();
            env = new GBLEnvVariable();
            msg = new MyMessageBox();
            result = new Envision.BusinessLogic.ResultEntry();
            
            if (CheckHasMRRcase(drSelect))
                MoveDestCase();
            
            initDesc();
            initSource();
            this._orderSummary = new frmPopupOrderOrScheduleSummary();
        }
        
        private void initDesc() {
            txtStatus.Text = dr["STATUS"].ToString();
            switch (dr["PRIORITY"].ToString())
            {
                case "R":
                    txtPriority.Text = "Routine";
                    break;
                case "U":
                    txtPriority.Text = "Urgent";
                    break;
                case "S":
                    txtPriority.Text = "Stat";
                    break;
                default:
                    txtPriority.Text = "Routine";
                    break;
            }
        
            txtAccNo.Text = dr["ACCESSION_NO"].ToString();
            txtExamUID.Text = dr["EXAM_UID"].ToString();
            txtExamName.Text = dr["EXAM_NAME"].ToString();
            this.Text = dr["HN"].ToString() + " : " + dr["PatientName"].ToString();
        }
        private void initSource()
        {
            result = new Envision.BusinessLogic.ResultEntry();
            result.RISExamresult.ACCESSION_NO = txtAccNo.Text;
            result.RISExamresult.HN = dr["HN"].ToString();
            result.RISExamresult.EMP_ID = env.UserID;
            dttHis = result.GetHistory();
            setGridHistory();
            if (drSelect != null && drSelect.Length > 0)
            {
                StringBuilder sbSearch = new StringBuilder();
                sbSearch.Append("ACCESSION_NO = ''");

                for (int i = 0; i < drSelect.Length; i++)
                {
                    sbSearch.Append(" OR ACCESSION_NO = '" + drSelect[i]["ACCESSION_NO"].ToString() + "'");
                }
                viewHis.Columns["ACCESSION_NO"].FilterInfo = new ColumnFilterInfo(sbSearch.ToString(), "Filter");
            }
        }

        private void setGridHistory()
        {
            DataRow[] drs = dttHis.Select("ACCESSION_NO ='" + txtAccNo.Text + "' ");
            
            if (drs.Length > 0)
            {
                foreach (DataRow drR in drs)
                {
                    dttHis.Rows.Remove(drR);
                }
                dttHis.AcceptChanges();
            }
            if (drSelect != null)
            {
                if (drSelect.Length > 0)
                {
                    for (int i = 0; i < drSelect.Length; i++)
                    {
                        DataRow[] drS = dttHis.Select("ACCESSION_NO ='" + drSelect[i]["ACCESSION_NO"].ToString() + "' ");
                        if (drS.Length > 0)
                            drS[0]["chkCol"] = "Y";
                    }
                    dttHis.AcceptChanges();
                }
            }

            grdHis.DataSource = dttHis;

            for (int i = 0; i < dttHis.Columns.Count; i++)
                viewHis.Columns[i].Visible = false;

            #region column edit
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 3, 8)});
            repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            repositoryItemImageComboBox2.SmallImages = imgWL;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit link = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            link.Image = imgHIS.Images[3];

            DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkOrder = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            linkOrder.Image = imgHIS.Images[4];
            //linkOrder.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            #endregion column edit

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            viewHis.Columns["chkCol"].ColumnEdit = chk;
            viewHis.Columns["chkCol"].Caption = " ";
            viewHis.Columns["chkCol"].Visible = true;
            viewHis.Columns["chkCol"].BestFit();
            viewHis.Columns["chkCol"].ColVIndex = 1;

            viewHis.Columns["PRIORITY_ID"].ColumnEdit = repositoryItemImageComboBox2;
            viewHis.Columns["PRIORITY_ID"].Caption = "Priority";
            viewHis.Columns["PRIORITY_ID"].Visible = true;
            viewHis.Columns["PRIORITY_ID"].BestFit();
            viewHis.Columns["PRIORITY_ID"].ColVIndex = 2;
            //viewHis.Columns["PRIORITY_ID"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["STATUS"].Caption = "Status";
            viewHis.Columns["STATUS"].Visible = true;
            viewHis.Columns["STATUS"].BestFit();
            viewHis.Columns["STATUS"].ColVIndex = 3;
            //viewHis.Columns["STATUS"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["TIMEDIFF"].Caption = "Timer";
            viewHis.Columns["TIMEDIFF"].Visible = true;
            viewHis.Columns["TIMEDIFF"].BestFit();
            viewHis.Columns["TIMEDIFF"].ColVIndex = 4;
            //viewHis.Columns["TIMEDIFF"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["ORDER_DT"].Caption = "Order Time";
            viewHis.Columns["ORDER_DT"].Visible = true;
            viewHis.Columns["ORDER_DT"].ColVIndex = 5;
            viewHis.Columns["ORDER_DT"].DisplayFormat.FormatString = "G";
            viewHis.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewHis.Columns["ORDER_DT"].Width = 73;
            // viewHis.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["PacsImg"].Caption = "Pacs Image";
            viewHis.Columns["PacsImg"].Visible = true;
            viewHis.Columns["PacsImg"].BestFit();
            viewHis.Columns["PacsImg"].ColVIndex = 6;
            viewHis.Columns["PacsImg"].ColumnEdit = link;
            //viewHis.Columns["PacsImg"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["OrderImg"].Caption = "Order Image";
            viewHis.Columns["OrderImg"].Visible = true;
            viewHis.Columns["OrderImg"].ColumnEdit = linkOrder;
            viewHis.Columns["OrderImg"].BestFit();
            viewHis.Columns["OrderImg"].ColVIndex = 7;
            // viewHis.Columns["OrderImg"].OptionsColumn.ReadOnly = true;
            viewHis.Columns["OrderImg"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            viewHis.Columns["ACCESSION_NO"].Caption = "Accession No";
            viewHis.Columns["ACCESSION_NO"].Visible = true;
            viewHis.Columns["ACCESSION_NO"].BestFit();
            viewHis.Columns["ACCESSION_NO"].ColVIndex = 8;
            //viewHis.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewHis.Columns["EXAM_NAME"].Visible = true;
            viewHis.Columns["EXAM_NAME"].BestFit();
            viewHis.Columns["EXAM_NAME"].ColVIndex = 9;
            // viewHis.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["Radiologist"].Caption = "Radiologist";
            viewHis.Columns["Radiologist"].Visible = true;
            viewHis.Columns["Radiologist"].BestFit();
            viewHis.Columns["Radiologist"].ColVIndex = 10;
            //viewHis.Columns["Radiologist"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["Unit"].Caption = "Unit";
            viewHis.Columns["Unit"].Visible = true;
            viewHis.Columns["Unit"].BestFit();
            viewHis.Columns["Unit"].ColVIndex = 11;
            //viewHis.Columns["Unit"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["EXAM_UID"].Caption = "Exam Code";
            viewHis.Columns["EXAM_UID"].Visible = true;
            viewHis.Columns["EXAM_UID"].BestFit();
            viewHis.Columns["EXAM_UID"].ColVIndex = 12;
            // viewHis.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;

            viewHis.Columns["ORDER_ID"].Caption = "Order No";
            viewHis.Columns["ORDER_ID"].Visible = true;
            viewHis.Columns["ORDER_ID"].BestFit();
            viewHis.Columns["ORDER_ID"].ColVIndex = 13;
            // viewHis.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;


            #region Set font style.
            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "Finalize");
            stylCon5.Appearance.ForeColor = Color.Green;

            viewHis.FormatConditions.Clear();
            viewHis.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });
            #endregion
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnMerge_Click(object sender, EventArgs e)
        {
            #region Require Check.
            DataView dv = (DataView)viewHis.DataSource;
            bool flag = true;
            foreach (DataRow dr in dv.Table.Rows)
            {
                if (dr["chkCol"].ToString() == "Y")
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                msg.ShowAlert("UID018", env.CurrentLanguageID);
                return;
            }
            
            #endregion

            if (msg.ShowAlert("UID1125", env.CurrentLanguageID) == "2")
            {
                //set merger

                if (CheckIsLock(txtAccNo.Text) == -1)
                {
                    msg.ShowAlert("UID5005", env.CurrentLanguageID);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                result.RISExamresult.MERGE = "MRR";
                result.RISExamresult.MERGE_WITH = string.Empty;
                result.RISExamresult.ACCESSION_NO = txtAccNo.Text;
                result.MergeSplit();
                //set mergee
                foreach (DataRow dr in dv.Table.Rows)
                {
                    if (dr["chkCol"].ToString() == "Y")
                    {
                        result.RISExamresult.MERGE = "MGR";
                        result.RISExamresult.MERGE_WITH = txtAccNo.Text;
                        result.RISExamresult.ACCESSION_NO = dr["ACCESSION_NO"].ToString();

                        if (CheckIsLock(result.RISExamresult.ACCESSION_NO) == -1)
                        {
                            result.RISExamresult.MERGE = "SPT";
                            result.MergeSplit();
                            msg.ShowAlert("UID5005", env.CurrentLanguageID);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            result.MergeSplit();
                        }
                    }
                    
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void viewHis_Click(object sender, EventArgs e)
        {
            if (viewHis.FocusedRowHandle > -1)
            {
                if (viewHis.FocusedColumn != null)
                {
                    if (viewHis.FocusedColumn.FieldName == "chkCol")
                    {
                        DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                        string chk = dr["S"].ToString();
                        if (chk != "P" && chk != "F")
                        {
                            chk = dr["ACCESSION_NO"].ToString();
                            if (chk == txtAccNo.Text) return;
                            chk = dr["chkCol"].ToString();
                            dr["chkCol"] = chk == "N" ? "Y" : "N";
                        }
                    }
                }
                if (viewHis.FocusedColumn.FieldName == "PacsImg")
                {
                    DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                    System.Diagnostics.Process.Start(env.PacsUrl + dr["ACCESSION_NO"].ToString().Trim());
                }
                if (viewHis.FocusedColumn.FieldName == "OrderImg")
                {
                    DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                    //frmPatientData ordimg = new frmPatientData(dr["ACCESSION_NO"].ToString());
                    //ordimg.Text = "Order Summary";
                    //ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                    //ordimg.StartPosition = FormStartPosition.CenterScreen;
                    //ordimg.MaximizeBox = false;
                    //ordimg.MinimizeBox = false;
                    //ordimg.ShowDialog();
                    this._orderSummary.ShowDialog(true, dr["ACCESSION_NO"].ToString());
                }
            }
        }
        private void viewHis_DoubleClick(object sender, EventArgs e)
        {
            if (viewHis.FocusedRowHandle > -1)
            {
                if (viewHis.FocusedColumn != null)
                {
                    if (viewHis.FocusedColumn.FieldName == "PacsImg")
                    {
                        if (viewHis.FocusedRowHandle > -1)
                        {
                            DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                            System.Diagnostics.Process.Start(env.PacsUrl + dr["ACCESSION_NO"].ToString().Trim());
                        }
                    }
                    if (viewHis.FocusedColumn.FieldName == "OrderImg")
                    {
                        if (viewHis.FocusedRowHandle > -1)
                        {
                            //DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                            //frmPatientData ordimg = new frmPatientData(dr["ACCESSION_NO"].ToString());
                            //ordimg.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                            //ordimg.StartPosition = FormStartPosition.CenterParent;
                            //ordimg.ShowDialog();
                            this._orderSummary.ShowDialog(true, dr["ACCESSION_NO"].ToString());
                        }
                    }
                }
            }
        }

        private void viewHis_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow drMerge = viewHis.GetDataRow(e.RowHandle);
                if (drMerge["MERGE"].ToString() != string.Empty)
                {
                    if (drMerge["MERGE_WITH"].ToString() == txtAccNo.Text)
                    {
                            e.Appearance.BackColor = Color.LightPink;
                    }
                    else
                    {
                        if (dr["MERGE_WITH"].ToString() != string.Empty)
                        {
                            if (drMerge["ACCESSION_NO"].ToString() == dr["MERGE_WITH"].ToString())
                            {
                                e.Appearance.BackColor = Color.LightPink;
                            }
                            else
                            {
                                if (drMerge["MERGE_WITH"].ToString() == dr["MERGE_WITH"].ToString())
                                {
                                    e.Appearance.BackColor = Color.LightPink;
                                }
                            }
                        }
                    }
                }
                else
                {
                    e.Appearance.BackColor = SystemColors.Window;
                }
            }
        }
        private int CheckIsLock(string AccessionNO)
        {
            LookUpSelect ls = new LookUpSelect();
            DataSet dsLock = ls.SelectExamResultLock(AccessionNO, env.UserID);
            if (dsLock.Tables[1].Rows.Count > 0)
            {
                if (dsLock.Tables[1].Rows[0]["WORKING_RAD"].ToString() == env.UserID.ToString())
                {
                    return env.UserID; //true
                }
            }
            else
            {
                return env.UserID; //true
            }
            return -1; // false,This case can't select
        }

        private bool CheckHasMRRcase(DataRow[] DRows)
        {
            bool hasMRRCase = false;

            foreach (DataRow row in DRows)
            {
                if (row["MERGE"].ToString() == "MRR")
                {
                    hasMRRCase = true;
                    break;
                }
            }

            return hasMRRCase;
        }
        private void MoveDestCase()
        {
            foreach (DataRow row in drSelect)
            {
                if (row["MERGE"].ToString() == "MRR")
                {
                    dr = row;
                    break;
                }
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (viewHis.FocusedRowHandle < -1) return;

            //string ACCESSION_NO = "";

            //DataRow rowDest = dr;
            //DataRow[] rowSour = drSelect;
            //DataTable tbTemp = rowDest.Table.Clone();
            
            //foreach(DataRow drTemp in rowSour)    
            //    tbTemp.Rows.Add(drTemp.ItemArray);

            //dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);

            //ACCESSION_NO = dr["ACCESSION_NO"].ToString();
            //rowSour[0] = rowDest;

            //foreach (DataRow drTemp in tbTemp.Rows)
            //{
            //    if (drTemp["ACCESSION_NO"].ToString() == ACCESSION_NO)
            //    {
            //        tbTemp.Rows.Remove(drTemp);
            //        break;
            //    }
            //}

            //for (int i = 1; i < rowSour.Length; i++)
            //{
            //    rowSour[i] = tbTemp.Rows[i - 1];
            //}

            //drSelect = rowSour;

            dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);

            initDesc();
            initSource();
        }
    }
}