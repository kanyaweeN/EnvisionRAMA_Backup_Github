using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using DevExpress.Utils;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmContrastManagement : Envision.NET.Forms.Main.MasterForm
    {
        private DataSet ds = new DataSet();
        public frmContrastManagement()
        {
            InitializeComponent();
        }

        private void frmContrastManagement_Load(object sender, EventArgs e)
        {
            dteFromdate.DateTime = DateTime.Now;
            dteTodate.DateTime = DateTime.Now;
            initModality();
            setDataGrid();
            base.CloseWaitDialog();
        }

        private void initModality()
        {
            ProcessGetFINPayment mod = new ProcessGetFINPayment();
            mod.FIN_PAYMENT.PAY_ID = -4;
            mod.Invoke();
            DataTable dtt = mod.Result.Tables[0];
            string modName = "";
            ccbModality.Properties.Items.Clear();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                ccbModality.Properties.Items.Add(dtt.Rows[i]["MODALITY_NAME"]);
                if (i == 0)
                    modName = dtt.Rows[i]["MODALITY_NAME"].ToString();
                else
                    modName += "," + dtt.Rows[i]["MODALITY_NAME"].ToString();
            }
            ccbModality.SetEditValue(modName);
        }
        private void setDataGrid()
        {
            base.LabelWaitDialog("Loading Data");

            DateTime dteFrom = new DateTime(dteFromdate.DateTime.Year, dteFromdate.DateTime.Month, dteFromdate.DateTime.Day, 0, 0, 0);
            DateTime dteTo = new DateTime(dteTodate.DateTime.Year, dteTodate.DateTime.Month, dteTodate.DateTime.Day, 23, 59, 59);
            LookUpSelect sel = new LookUpSelect();
            ds = sel.SelectContrastManagement(0, dteFrom, dteTo, "");
            ds.Relations.Add("ContrastData", ds.Tables[0].Columns["ORDER_ID"], ds.Tables[1].Columns["ORDER_ID"]);
            ds.AcceptChanges();
            grdData.DataSource = ds.Tables[0];
            setGrid();
            base.CloseWaitDialog();
        }
        private void setGrid()
        {
            viewMaster.OptionsDetail.ShowDetailTabs = false;
            grdData.ForceInitialize();
            DevExpress.XtraGrid.Views.Grid.GridView viewSub = new DevExpress.XtraGrid.Views.Grid.GridView(grdData);
            grdData.LevelTree.Nodes.Add("ContrastData", viewSub);
            viewSub.PopulateColumns(ds.Tables[1]);
            viewSub.OptionsView.ColumnAutoWidth = false;
            viewSub.OptionsView.ShowGroupPanel = false;
            viewSub.OptionsView.ShowIndicator = false;
            viewSub.OptionsView.ShowFooter = true;


            #region Master

            #region Edit Columns
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtOne = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit speOne = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            speOne.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            speOne.Buttons[0].Visible = false;
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnFillDtl = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnFillDtl.Buttons[0].Caption = "Fill Detail";
            btnFillDtl.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            btnFillDtl.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnFillDtl.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnFillDtl_ButtonClick);
            #endregion

            viewMaster.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["HN"].Visible = true;
            viewMaster.Columns["HN"].Caption = "HN";
            viewMaster.Columns["HN"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["HN"].Width = 100;
            viewMaster.Columns["HN"].ColVIndex = 0;

            viewMaster.Columns["PATIENT_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["PATIENT_NAME"].Visible = true;
            viewMaster.Columns["PATIENT_NAME"].Caption = "Patient Name";
            viewMaster.Columns["PATIENT_NAME"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["PATIENT_NAME"].ColVIndex = 1;

            viewMaster.Columns["ORDER_DT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["ORDER_DT"].Visible = true;
            viewMaster.Columns["ORDER_DT"].Caption = "Study Datetime";
            viewMaster.Columns["ORDER_DT"].ColumnEdit = txtOne;
            viewMaster.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["ORDER_DT"].ColVIndex = 2;

            viewMaster.Columns["ACTUAL_QUANITITY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["ACTUAL_QUANITITY"].Visible = true;
            viewMaster.Columns["ACTUAL_QUANITITY"].Caption = "Actual Quanitity";
            viewMaster.Columns["ACTUAL_QUANITITY"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["ACTUAL_QUANITITY"].ColVIndex = 3;

            viewMaster.Columns["CONTRAST_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["CONTRAST_NAME"].Visible = true;
            viewMaster.Columns["CONTRAST_NAME"].Caption = "Contrast Name";
            viewMaster.Columns["CONTRAST_NAME"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["CONTRAST_NAME"].ColVIndex = 4;

            viewMaster.Columns["DOSE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["DOSE"].Visible = true;
            viewMaster.Columns["DOSE"].Caption = "Dose";
            viewMaster.Columns["DOSE"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["DOSE"].ColVIndex = 5;
            viewMaster.Columns["LOT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["LOT"].Visible = true;
            viewMaster.Columns["LOT"].Caption = "Lot";
            viewMaster.Columns["LOT"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["LOT"].ColVIndex = 6;

            viewMaster.Columns["PATIENT_WEIGHT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["PATIENT_WEIGHT"].Visible = true;
            viewMaster.Columns["PATIENT_WEIGHT"].Caption = "Patient Weight";
            viewMaster.Columns["PATIENT_WEIGHT"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["PATIENT_WEIGHT"].ColVIndex = 7;

            viewMaster.Columns["ORDER_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["ORDER_ID"].Visible = true;
            viewMaster.Columns["ORDER_ID"].Caption = " ";
            viewMaster.Columns["ORDER_ID"].ColumnEdit = btnFillDtl;
            viewMaster.Columns["ORDER_ID"].OptionsColumn.ReadOnly = false;
            viewMaster.Columns["ORDER_ID"].Width = 70;
            viewMaster.Columns["ORDER_ID"].ColVIndex = 8;
            #endregion

            #region Sub
            viewSub.Columns["EXAM_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["EXAM_UID"].Visible = true;
            viewSub.Columns["EXAM_UID"].Caption = "Exam Code";
            viewSub.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["EXAM_UID"].Width = 50;
            viewSub.Columns["EXAM_UID"].VisibleIndex = 1;

            viewSub.Columns["EXAM_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["EXAM_NAME"].Visible = true;
            viewSub.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewSub.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["EXAM_NAME"].Width = 200;
            viewSub.Columns["EXAM_NAME"].VisibleIndex = 2;

            viewSub.Columns["ACCESSION_NO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["ACCESSION_NO"].Visible = true;
            viewSub.Columns["ACCESSION_NO"].Caption = "ACCESSION_NO";
            viewSub.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["ACCESSION_NO"].Width = 150;
            viewSub.Columns["ACCESSION_NO"].VisibleIndex = 3;

            viewSub.Columns["RATE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["RATE"].Visible = true;
            viewSub.Columns["RATE"].Caption = "Rate";
            viewSub.Columns["RATE"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["RATE"].Width = 100;
            viewSub.Columns["RATE"].VisibleIndex = 4;

            viewSub.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["QTY"].Visible = true;
            viewSub.Columns["QTY"].Caption = "QTY";
            viewSub.Columns["QTY"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["QTY"].Width = 100;
            viewSub.Columns["QTY"].VisibleIndex = 5;

            viewSub.Columns["ORDER_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["ORDER_ID"].Visible = false;
            viewSub.Columns["ORDER_ID"].Caption = "ORDER_ID";
            viewSub.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["ORDER_ID"].Width = 10;
            //viewSub.Columns["ORDER_ID"].VisibleIndex = 11;

            #endregion
        }

        private void btnFillDtl_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmContrastFillDetail frm = new frmContrastFillDetail(ds, Convert.ToInt32(viewMaster.GetDataRow(viewMaster.FocusedRowHandle)["ORDER_ID"]));
            frm.ShowDialog();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                pncHN.Visible = false;
                pncDatetime.Visible = true;
            }
            else
            {
                pncDatetime.Visible = false;
                pncHN.Visible = true;
            }
        }

    }
}
