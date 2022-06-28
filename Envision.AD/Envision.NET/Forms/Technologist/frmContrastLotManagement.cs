using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Common;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmContrastLotManagement : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private int _lot_id,_selected_lot_id;
        private DataSet dsContrast;
        public frmContrastLotManagement()
        {
            InitializeComponent();
        }

        private void frmContrastLotManagement_Load(object sender, EventArgs e)
        {

            LookUpSelect sel = new LookUpSelect();
            dsContrast = sel.SelectContrastManagement(2, DateTime.Now, DateTime.Now, "");
            setDataContrast(0);

            clearData();
            setDataGrid();
            
        }
        private void clearData() {
            _lot_id = 0;
            txtLotCode.Text = "";
            txtLotText.Text = "";
            chkIsActive.Checked = false;
        }
        private void setDataGrid()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            ProcessGetRISContrastLot _prc = new ProcessGetRISContrastLot();
            _prc.Invoke();
            DataSet ds = _prc.ResultSet;


            grdLot.DataSource = ds.Tables[0];

            for (int i = 0; i < viewLot.Columns.Count; i++)
            {
                viewLot.Columns[i].Visible = false;
                viewLot.Columns[i].OptionsColumn.ReadOnly = true;
                viewLot.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewLot.Columns["LOT_UID"].ColVIndex = 1;
            viewLot.Columns["LOT_UID"].Caption = "Code";
            //viewLot.Columns["LOT_TEXT"].ColVIndex = 2;
            //viewLot.Columns["LOT_TEXT"].Caption = "Text";

            dlg.Close();
        }
        private void setDataContrast(int lotId)
        {
            _selected_lot_id = lotId;
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);
            ProcessGetRISContrastLot _prc = new ProcessGetRISContrastLot();
            DataSet ds = _prc.getMappingByLotId(lotId);

             DataTable dt = new DataTable();
             dt.Columns.Add("CHK");
             dt.Columns.Add("LOTMAPPING_ID");
             dt.Columns.Add("CONTRAST_ID");
             dt.Columns.Add("CONTRAST_NAME");

             foreach (DataRow row in dsContrast.Tables[0].Rows)
             {
                 DataRow[] rows = ds.Tables[0].Select("CONTRAST_ID=" + row["ID"].ToString());

                 DataRow add = dt.NewRow();
                 add["CHK"] = rows.Length > 0 ? "Y" : "N";
                 add["LOTMAPPING_ID"] = rows.Length > 0 ? Convert.ToInt32(rows[0]["LOTMAPPING_ID"]) : 0;
                 add["CONTRAST_ID"] = Convert.ToInt32(row["ID"]);
                 add["CONTRAST_NAME"] = row["CONTRAST_NAME"].ToString();

                 dt.Rows.Add(add);
                 dt.AcceptChanges();
             }

             grdContrast.DataSource = dt;

             for (int i = 0; i < viewContrast.Columns.Count; i++)
             {
                 viewContrast.Columns[i].Visible = false;
                 viewContrast.Columns[i].OptionsColumn.ReadOnly = true;
                 viewContrast.Columns[i].OptionsColumn.AllowEdit = false;
             }

             DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
             chkTemplate.ValueChecked = "Y";
             chkTemplate.ValueUnchecked = "N";
             chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
             chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
             chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
             chkTemplate.Click += new EventHandler(chk_Click);

             viewContrast.Columns["CHK"].Width = 30;
             viewContrast.Columns["CHK"].ColVIndex = 1;
             viewContrast.Columns["CHK"].Caption = " ";
             viewContrast.Columns["CHK"].OptionsColumn.ReadOnly = false;
             viewContrast.Columns["CHK"].OptionsColumn.AllowEdit = true;
             viewContrast.Columns["CHK"].ColumnEdit = chkTemplate;

             viewContrast.Columns["CONTRAST_NAME"].ColVIndex = 2;
             viewContrast.Columns["CONTRAST_NAME"].Caption = "Contrast Name";

 
            dlg.Close();

        }
        private void chk_Click(object sender, EventArgs e)
        {
            if (viewContrast.FocusedRowHandle > -1)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                DataRow drChk = viewContrast.GetDataRow(viewContrast.FocusedRowHandle);
                if (chk.Checked == false)
                {
                    ProcessAddRISContrastLot _add = new ProcessAddRISContrastLot();
                    _add.AddLotMapping(Convert.ToInt32(drChk["CONTRAST_ID"]), _selected_lot_id, env.UserID);
                    drChk["CHK"] = "Y";
                }
                else
                {
                    ProcessAddRISContrastLot _add = new ProcessAddRISContrastLot();
                    _add.deleteLotMapping(Convert.ToInt32(drChk["LOTMAPPING_ID"]));
                    drChk["CHK"] = "N";
                }
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_lot_id == 0)
            {
                if (!string.IsNullOrEmpty(txtLotCode.Text.Trim()))
                {
                    ProcessAddRISContrastLot _add = new ProcessAddRISContrastLot();
                    _add.RIS_CONTRASTLOT.LOT_UID = txtLotCode.Text;
                    _add.RIS_CONTRASTLOT.LOT_TEXT = txtLotText.Text;
                    _add.RIS_CONTRASTLOT.IS_ACTIVE = chkIsActive.Checked? "Y":"N";
                    _add.RIS_CONTRASTLOT.CREATED_BY = env.UserID;
                    _add.Invoke();
                }
            }
            else {
                ProcessUpdateRISContrastLot _update = new ProcessUpdateRISContrastLot();
                _update.RIS_CONTRASTLOT.LOT_ID = _lot_id;
                _update.RIS_CONTRASTLOT.LOT_UID = txtLotCode.Text;
                _update.RIS_CONTRASTLOT.LOT_TEXT = txtLotText.Text;
                _update.RIS_CONTRASTLOT.IS_ACTIVE = chkIsActive.Checked ? "Y" : "N";
                _update.RIS_CONTRASTLOT.LAST_MODIFIED_BY = env.UserID;
                _update.Invoke();
            }
            clearData();
            setDataGrid();
        }

        private void viewLot_DoubleClick(object sender, EventArgs e)
        {
            if (viewLot.FocusedRowHandle >= 0) {
                DataRow row = viewLot.GetDataRow(viewLot.FocusedRowHandle);
                _lot_id = Convert.ToInt32( row["LOT_ID"]);
                txtLotCode.Text = row["LOT_UID"].ToString();
                txtLotText.Text = row["LOT_TEXT"].ToString();
                chkIsActive.Checked = row["IS_ACTIVE"].ToString() == "Y" ? true : false;
            }
        }

        private void viewLot_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (viewLot.FocusedRowHandle >= 0) {
                DataRow row = viewLot.GetDataRow(viewLot.FocusedRowHandle);
                setDataContrast(Convert.ToInt32(row["LOT_ID"]));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewLot.FocusedRowHandle >= 0)
            {
                DataRow row = viewLot.GetDataRow(viewLot.FocusedRowHandle);
                
                ProcessUpdateRISContrastLot _update = new ProcessUpdateRISContrastLot();
                _update.RIS_CONTRASTLOT.LOT_ID = Convert.ToInt32(row["LOT_ID"]);
                _update.RIS_CONTRASTLOT.LOT_UID = row["LOT_UID"].ToString();
                _update.RIS_CONTRASTLOT.LOT_TEXT = row["LOT_TEXT"].ToString();
                _update.RIS_CONTRASTLOT.IS_ACTIVE = "N";
                _update.RIS_CONTRASTLOT.LAST_MODIFIED_BY = env.UserID;
                _update.Invoke();
                clearData();
                setDataGrid();
            }
        }
    }
}