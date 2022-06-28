using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.Orders
{
    public partial class frmReconciliation : Envision.NET.Forms.Main.MasterForm
    {
        public frmReconciliation()
        {
            InitializeComponent();
        }

        private void frmReconciliation_Load(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();
            DataTable dtJohn = lvS.ScheduleNotParameter("Johndoe").Tables[0];
            grdDataJohndoe.DataSource = dtJohn;
            SetGridJohndoe();
            base.CloseWaitDialog();
        }
        private void SetGridJohndoe()
        {
            View1.Columns["REG_ID"].Caption = "ID";
            View1.Columns["REG_ID"].Visible = true;
            View1.Columns["REG_ID"].OptionsColumn.ReadOnly = true;
            View1.Columns["REG_ID"].OptionsColumn.AllowEdit = false;

            View1.Columns["HN"].Caption = "HN";
            View1.Columns["HN"].Visible = true;
            View1.Columns["HN"].OptionsColumn.ReadOnly = true;
            View1.Columns["HN"].OptionsColumn.AllowEdit = false;

            View1.Columns["THAINAME"].Caption = "Thai Name";
            View1.Columns["THAINAME"].Visible = true;
            View1.Columns["THAINAME"].OptionsColumn.ReadOnly = true;
            View1.Columns["THAINAME"].OptionsColumn.AllowEdit = false;

            View1.Columns["ENGNAME"].Caption = "Eng Name";
            View1.Columns["ENGNAME"].Visible = true;
            View1.Columns["ENGNAME"].OptionsColumn.ReadOnly = true;
            View1.Columns["ENGNAME"].OptionsColumn.AllowEdit = false;

            View1.Columns["SSN"].Caption = "SSN";
            View1.Columns["SSN"].Visible = true;
            View1.Columns["SSN"].OptionsColumn.ReadOnly = true;
            View1.Columns["SSN"].OptionsColumn.AllowEdit = false;

            RepositoryItemTextEdit txtDob = new RepositoryItemTextEdit();
            View1.Columns["DOB"].ColumnEdit = txtDob;
            View1.Columns["DOB"].Caption = "DOB";
            View1.Columns["DOB"].Visible = true;
            View1.Columns["DOB"].OptionsColumn.ReadOnly = true;
            View1.Columns["DOB"].OptionsColumn.AllowEdit = false;


            View1.Columns["AGE"].Caption = "AGE";
            View1.Columns["AGE"].Visible = true;
            View1.Columns["AGE"].OptionsColumn.ReadOnly = true;
            View1.Columns["AGE"].OptionsColumn.AllowEdit = false;

            View1.Columns["ADDR1"].Caption = "Address";
            View1.Columns["ADDR1"].Visible = true;
            View1.Columns["ADDR1"].OptionsColumn.ReadOnly = true;
            View1.Columns["ADDR1"].OptionsColumn.AllowEdit = false;

            View1.Columns["PHONE1"].Caption = "Phone";
            View1.Columns["PHONE1"].Visible = true;
            View1.Columns["PHONE1"].OptionsColumn.ReadOnly = true;
            View1.Columns["PHONE1"].OptionsColumn.AllowEdit = false;

            View1.Columns["REG_DT"].Caption = "Date";
            View1.Columns["REG_DT"].Visible = true;
            View1.Columns["REG_DT"].OptionsColumn.ReadOnly = true;
            View1.Columns["REG_DT"].OptionsColumn.AllowEdit = false;

            View1.Columns["IS_JOHNDOE"].Caption = "";
            View1.Columns["IS_JOHNDOE"].Visible = false;
            View1.Columns["IS_JOHNDOE"].OptionsColumn.ReadOnly = true;
            View1.Columns["IS_JOHNDOE"].OptionsColumn.AllowEdit = false;

            View1.Columns["BUTTOM"].Caption = "";
            View1.Columns["BUTTOM"].Visible = true;
            View1.Columns["BUTTOM"].OptionsColumn.ReadOnly = true;
            View1.Columns["BUTTOM"].OptionsColumn.AllowEdit = true;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnView = new RepositoryItemButtonEdit();
            btnView.ButtonsStyle = BorderStyles.Office2003;
            btnView.Buttons[0].Caption = "View";
            btnView.Buttons[0].Kind = ButtonPredefines.Plus;
            btnView.TextEditStyle = TextEditStyles.HideTextEditor;
            btnView.ButtonClick += new ButtonPressedEventHandler(btnView_ButtonClick);

            View1.Columns["BUTTOM"].Width = 30;
            View1.Columns["BUTTOM"].ColumnEdit = btnView;
        }

        private void btnView_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow drJohn = View1.GetDataRow(View1.FocusedRowHandle);

            frmViewReconciliation frmView = new frmViewReconciliation(drJohn["HN"].ToString());
            frmView.MinimizeBox = false;
            frmView.MaximizeBox = false;
            frmView.StartPosition = FormStartPosition.CenterParent;
            frmView.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmView.Text = "Reconciliation";
            frmView.ShowDialog();

            if (frmView.DialogResult == DialogResult.OK)
            {
                LookUpSelect lvS = new LookUpSelect();
                DataTable dtJohn = lvS.ScheduleNotParameter("Johndoe").Tables[0];
                grdDataJohndoe.DataSource = dtJohn;
                SetGridJohndoe();
            }
        }

        private void View1_DoubleClick(object sender, EventArgs e)
        {
            DataRow drJohn = View1.GetDataRow(View1.FocusedRowHandle);

            frmViewReconciliation frmView = new frmViewReconciliation(drJohn["HN"].ToString());
            frmView.MinimizeBox = false;
            frmView.MaximizeBox = false;
            frmView.StartPosition = FormStartPosition.CenterParent;
            frmView.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmView.Text = "Reconciliation";
            frmView.ShowDialog();

            if (frmView.DialogResult == DialogResult.OK)
            {
                LookUpSelect lvS = new LookUpSelect();
                DataTable dtJohn = lvS.ScheduleNotParameter("Johndoe").Tables[0];
                grdDataJohndoe.DataSource = dtJohn;
                SetGridJohndoe();
            }
        }

    }
}