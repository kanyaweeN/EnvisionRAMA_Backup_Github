using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using Envision.BusinessLogic;
using Envision.NET.Forms.EMR;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Schedule;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using System.Linq;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessUpdate;
using Miracle.Util;
using DevExpress.XtraEditors.Controls;

namespace Envision.NET.Forms.Orders
{
    public partial class frmArrivalWorkListNew : Envision.NET.Forms.Main.MasterForm//: DevExpress.XtraEditors.XtraForm
    {
        private Envision.Common.GBLEnvVariable gblEnvVariable;
        private DataTable dtFilter;
        private DataTable dtExamTypeFilter;
        private DataTable dtDestination;
        private DataTable dtExamType;
        private DataTable dtCurrent;
        private bool isSetDataGrid = false;
        private DevExpress.Utils.WaitDialogForm waitDialog;
        private frmOnlineArrivalWorklist_Beep arrivalMessage;
        private frmPopupClinicalIndication clinicalIndicationDialog;
        private frmPopupOrderOrScheduleSummary orderOrScheduleSummary;
        private bool isAutoRefresh = true;
        private bool isShowAlert = true;
        private Dialog.MyMessageBox myMsg;
        private Timer tmAutoRefresh;
        private DataSet dtClinicalindicationtype = new DataSet();

        public enum SearchModes
        {
            SearchByHN = 1, SearchByDate = 2, SearchByNoExamDate = 3
                //, OnlyOnline = 4
        }
        private SearchModes searchModeBackUp = SearchModes.SearchByHN;
        private SearchModes searchMode = SearchModes.SearchByHN;        
        public SearchModes SearchMode
        {
            get { return searchMode; }
            set 
            {
                searchModeBackUp = searchMode; // backup
                searchMode = value;
                this.SetActiveSearchMode((int)searchMode);
                this.SetSearchMode((int)searchMode);
            }
        }
        public bool IsAutoRefresh
        {
            get { return isAutoRefresh; }
            set
            {
                isAutoRefresh = value;
                if (isAutoRefresh)
                {
                    if(this.tmAutoRefresh == null)
                        this.SetupTimer(); //set up timer
                    this.StartAutoRefresh();
                }
                else
                    this.StopAutoRefresh();
            }
        }
        public bool ShowAlert
        {
            get { return isShowAlert; }
            set { isShowAlert = value; }
        }

        public frmArrivalWorkListNew()
        {
            InitializeComponent();

        }
        private void frmArrivalWorkListNew_Load(object sender, EventArgs e)
        {
            this.gblEnvVariable = new Envision.Common.GBLEnvVariable();
            gblEnvVariable.ErrorForm = base.Menu_Name_Class;
            this.myMsg = new Envision.NET.Forms.Dialog.MyMessageBox();
            this.rgSeachMode.EditValue = (int)searchMode;
            this.SearchMode = SearchModes.SearchByHN;
            this.arrivalMessage = new frmOnlineArrivalWorklist_Beep();
            this.clinicalIndicationDialog = new frmPopupClinicalIndication();
            this.orderOrScheduleSummary = new frmPopupOrderOrScheduleSummary();
            this.SetupFilter();
            this.SetupArrivalDataGrid(); //set up data grid column
            this.tbHN.Text = ""; //4473504
            this.gridControlArrivalWorkList.DoubleClick += new EventHandler(gridControlArrivalWorkList_DoubleClick);
            // initial parameter
            // Set auto refresh
            // this.IsAutoRefresh = true;
            try
            {
                ProcessGetClinicalIndicationType processClinicalindicationtype = new ProcessGetClinicalIndicationType();
                dtClinicalindicationtype = processClinicalindicationtype.GetClinicalIndicationType(gblEnvVariable.OrgID, gblEnvVariable.UserID);
            }
            catch { }

            dtCurrent = new DataTable();
            dtCurrent = BindingArrivalWorkList(this.SearchMode);
            this.CloseWaitDialog();
        }

        //Ribbon Menu Control
        private void barNewOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {
                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("New");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();
            }
        }
        private void barEditOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {
                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("Edit");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();
            }
        }
        private void barManaul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {
                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("Manual");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();
            }
        }
        private void barJohnDoe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {
                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("JohnDoe");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();

            }
        }
        private void barLastOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            if (!main.FormIsAlive(Envision.NET.Forms.Main.MasterForm.OrderSubMenuID))
            {

                DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
                DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmOrders'");
                Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders("Last");
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.txtHN.Focus();
                this.Close();
            }
        }
        private void barScan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmScanImage frm = new frmScanImage();
            frm.ShowDialog();
            frm.Dispose();
        }
        private void barComment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.IsAutoRefresh)
                this.PauseAutoRefresh(); // pause auto refresh

            DataRow drSelected = this.gridViewArrivalWorkList.GetFocusedDataRow();
            if (drSelected["IS_SCHEDULE"].ToString() == "N")
            {
                frmMessageConversation frm = new frmMessageConversation(Convert.ToInt32(drSelected["ORDER_ID"]),true);
                frm.ShowDialog();
            }
            else
            {
                frmMessageConversation frm = new frmMessageConversation(Convert.ToInt32(drSelected["IS_SCHEDULE"]));
                frm.ShowDialog();
            }
            dtCurrent = BindingArrivalWorkList(this.SearchMode);
            if (this.IsAutoRefresh)
                this.StartAutoRefresh(); //resume auto refresh
        }
        private void barReprint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmReprint' and MENU_ID=" + this.Menu_ID);

            if (rows.Length > 0)
            {
                int id = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                if (!main.FormIsAlive(id))
                {
                    Envision.NET.Forms.Orders.frmReprint frm = new Envision.NET.Forms.Orders.frmReprint();
                    frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                    frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                    frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                    frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                    frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                    frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                    frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                    frm.Text = frm.Menu_Name_User;
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    this.Close();
                }
            }
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void barArrivalWorklist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //Filter Control
        private void rgSeachMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)this.rgSeachMode.EditValue == (int)SearchModes.SearchByHN)
            {
                this.SearchMode = SearchModes.SearchByHN;
                this.tbHN.Text = string.Empty;
                this.tbHN.Focus();
            }
            else
            {
                this.SearchMode = SearchModes.SearchByDate;
                this.btnSearch.Focus();
            }
            //this.SaveFilter();
        }
        private void chkShowNoExamDate_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.chkShowNoExamDate.Checked)
            //    this.SearchMode = SearchModes.SearchByNoExamDate;
            //else
            //    this.SearchMode = _searchModeBackUp; // restore search mode
            //this.BindingArrivalWorkList(this.SearchMode);
        }
        private void rdgShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.chkOnlyOnline.Checked)
            //    this.SearchMode = SearchModes.OnlyOnline;
            //else
            //    this.SearchMode = _searchModeBackUp; // restore search mode
            dtCurrent = BindingArrivalWorkList(this.SearchMode);
            this.SaveFilter();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtCurrent = BindingArrivalWorkList(this.SearchMode);
        }
        private void tbHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtCurrent = BindingArrivalWorkList(this.SearchMode);
        }
        private void chcFilter_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            ////this.SaveFilter();
            //string value = e.Value.ToString();
            //string xmlFileName = string.Format("_{0}.xml", this.gblEnvVariable.UserID);
            //// ## SAVE TO STORAGE
            //try
            //{
            //    // Fill value to datatable
            //    string[] values = value.Split(',');
            //    this.dtFilter.Rows.Clear(); //clear old value
            //    // add new filter
            //    foreach (string eachValue in values)
            //    {
            //        if (!string.IsNullOrEmpty(eachValue.Trim()))
            //            this.dtFilter.Rows.Add(Convert.ToInt32(eachValue), 
            //                this.rgSeachMode.EditValue.ToString(), 
            //                this.chkUseAutoRefresh.Checked == true ? "Y" : "N",
            //                this.chkshowAlert.Checked == true ? "Y" : "N",
            //                this.rdgShowType.EditValue.ToString());
            //    }
            //    this.dtFilter.AcceptChanges();

            //    IsolatedStorateManagement.DataTableToXML(xmlFileName, this.dtFilter);
            //}
            //catch { }
            //finally { value = string.Empty; }
            string value = chcUnit.EditValue.ToString();
            string value2 = cbExamType.EditValue.ToString();
            string xmlFileName = string.Format("_{0}.xml", this.gblEnvVariable.UserID);
            string xmlFileNameForExamType = string.Format("_{0}_2.xml", this.gblEnvVariable.UserID);

            // ## SAVE TO STORAGE
            try
            {
                // Fill value to datatable
                string[] values = value.Split(',');
                this.dtFilter.Rows.Clear(); //clear old value
                // add new filter
                foreach (string eachValue in values)
                {
                    if (!string.IsNullOrEmpty(eachValue.Trim()))
                        this.dtFilter.Rows.Add(Convert.ToInt32(eachValue.Trim()),
                            this.rgSeachMode.EditValue.ToString(),
                            this.chkUseAutoRefresh.Checked == true ? "Y" : "N",
                            this.chkshowAlert.Checked == true ? "Y" : "N",
                            this.rdgShowType.EditValue.ToString());
                }
                this.dtFilter.AcceptChanges();

                IsolatedStorateManagement.DataTableToXML(xmlFileName, this.dtFilter);

                string[] values2 = value2.Split(',');
                this.dtExamTypeFilter.Rows.Clear(); //clear old value
                // add new filter
                foreach (string eachValue2 in values2)
                {
                    if (!string.IsNullOrEmpty(eachValue2.Trim()))
                        this.dtExamTypeFilter.Rows.Add(eachValue2.Trim());
                }
                this.dtExamTypeFilter.AcceptChanges();

                IsolatedStorateManagement.DataTableToXML(xmlFileNameForExamType, this.dtExamTypeFilter);
            }
            catch { }
            finally { value = string.Empty; }
        }
        private void chcFilter_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isSetDataGrid)
                dtCurrent = BindingArrivalWorkList(this.SearchMode);
        }
        private void chkUseAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUseAutoRefresh.Checked)
            {
                this.IsAutoRefresh = true;
                this.chkshowAlert.Enabled = true;
            }
            else
            {
                this.IsAutoRefresh = false;
                this.chkshowAlert.Enabled = false;
            }
        }
        private void chkshowAlert_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkshowAlert.Checked)
                this.ShowAlert = true;
            else
                this.ShowAlert = false;
        }

        private void SetActiveSearchMode(int value)
        {
            bool flag = true;
            if (value == 3 || value == 4)
                flag = false;
            if (value == 3)
            {
                this.dtFrom.Enabled = false;
                this.dtTo.Enabled = false;
                this.btnSearch.Enabled = false;
            }
            else
            {
                this.dtFrom.Enabled = true;
                this.dtTo.Enabled = true;
                this.btnSearch.Enabled = true;
            }
            this.tbHN.Enabled = flag;

            if (value == 4)
            {
                //this.chkOnlyOnline.Enabled = true;
                this.chcUnit.Enabled = false;
                this.cbExamType.Enabled = false;
            }
            else if (value == 1)
            {
                this.rdgShowType.Enabled = false;
                this.chcUnit.Enabled = false;
                this.cbExamType.Enabled = false;
            }
            else
            {
                this.rdgShowType.Enabled = true;
                this.chcUnit.Enabled = true;
                this.cbExamType.Enabled = true;
            }
        }
        
        //Load Grid Data
        private void SetupArrivalDataGrid()
        {
            this.gridViewArrivalWorkList.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewArrivalWorkList.Columns.Clear();
            // button add
            GridColumn gc_buttonAdd = new GridColumn();
            gc_buttonAdd.Caption = " ";
            gc_buttonAdd.Width = 25;
            gc_buttonAdd.VisibleIndex = 1;
            gc_buttonAdd.Name = "ADD";
            RepositoryItemButtonEdit repButtonEdit = new RepositoryItemButtonEdit();
            repButtonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus;
            repButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repButtonEdit.Click += new EventHandler(_repButtonEdit_Click);
            gc_buttonAdd.ColumnEdit = repButtonEdit;
            //gc_buttonAdd.OptionsColumn.AllowFocus = false;
            //gc_buttonAdd.Fixed = FixedStyle.Left;
            this.gridViewArrivalWorkList.Columns.Add(gc_buttonAdd);

            //icon
            GridColumn gc_icon = new GridColumn();
            gc_icon.Caption = " ";
            gc_icon.FieldName = "IS_TELEMED";
            gc_icon.Width = 25;
            RepositoryItemImageComboBox repImageComboBox = new RepositoryItemImageComboBox();
            repImageComboBox.SmallImages = this.imgIcon;
            repImageComboBox.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Y", 6));
            repImageComboBox.ReadOnly = true;
            repImageComboBox.Buttons[0].Visible = false;
            gc_icon.ColumnEdit = repImageComboBox;
            gc_icon.VisibleIndex = 2;
            gc_icon.Visible = true;
            this.gridViewArrivalWorkList.Columns.Add(gc_icon);

            // alert code
            GridColumn gc_alertcode = new GridColumn();
            gc_alertcode.Caption = " ";
            gc_alertcode.FieldName = "CLINICAL_INSTRUCTION_TAG";
            gc_alertcode.Width = 50;
            gc_alertcode.VisibleIndex = 3;
            this.gridViewArrivalWorkList.Columns.Add(gc_alertcode);

            // Comment
            GridColumn gc_comment = new GridColumn();
            gc_comment.Caption = "Comment";
            gc_comment.FieldName = "COMMENTS";
            gc_comment.Width = 65;
            RepositoryItemMemoExEdit repMemoEdit = new RepositoryItemMemoExEdit();
            repMemoEdit.ReadOnly = true;
            repMemoEdit.Buttons[0].Visible = false;
            repMemoEdit.AcceptsReturn = true;
            repMemoEdit.AutoHeight = true;
            repMemoEdit.ShowIcon = true;
            repMemoEdit.ShowPopupShadow = false;
            gc_comment.ColumnEdit = repMemoEdit;
            gc_comment.VisibleIndex = 4;
            this.gridViewArrivalWorkList.Columns.Add(gc_comment);

            //ordering department
            GridColumn gc_orderingDepartment = new GridColumn();
            gc_orderingDepartment.Caption = "Ordering Dept";
            gc_orderingDepartment.FieldName = "UNIT_UID";
            gc_orderingDepartment.Width = 90;
            gc_orderingDepartment.VisibleIndex = 5;
            this.gridViewArrivalWorkList.Columns.Add(gc_orderingDepartment);

            //ordering department
            GridColumn gc_priority = new GridColumn();
            gc_priority.Caption = "Priority";
            gc_priority.FieldName = "PRIORITY";
            gc_priority.Width = 55;
            gc_priority.VisibleIndex = 6;
            this.gridViewArrivalWorkList.Columns.Add(gc_priority);

            // HN
            GridColumn gc_hn= new GridColumn();
            gc_hn.Caption = "HN";
            gc_hn.FieldName = "HN";
            gc_hn.Width = 60;
            gc_hn.VisibleIndex = 7;
            this.gridViewArrivalWorkList.Columns.Add(gc_hn);

            // Patient Detail
            GridColumn gc_PatientIDDetail = new GridColumn();
            gc_PatientIDDetail.Caption = " ";
            gc_PatientIDDetail.FieldName = "PATIENT_ID_LABEL";
            gc_PatientIDDetail.Width = 25;
            gc_PatientIDDetail.VisibleIndex = 8;
            this.gridViewArrivalWorkList.Columns.Add(gc_PatientIDDetail);

            // Patient Name
            GridColumn gc_patientNamme = new GridColumn();
            gc_patientNamme.Caption = "Patient Name";
            gc_patientNamme.FieldName = "PATIENT_NAME";
            gc_patientNamme.Width = 120;
            gc_patientNamme.VisibleIndex = 9;
            this.gridViewArrivalWorkList.Columns.Add(gc_patientNamme);

            // Exam Code
            GridColumn gc_examCode = new GridColumn();
            gc_examCode.Caption = "Exam Code";
            gc_examCode.FieldName = "EXAM_UID";
            gc_examCode.Width = 75;
            gc_examCode.VisibleIndex = 10;
            this.gridViewArrivalWorkList.Columns.Add(gc_examCode);

            // Exam Name
            GridColumn gc_examName = new GridColumn();
            gc_examName.Caption = "Exam Name";
            gc_examName.FieldName = "EXAM_NAME";
            gc_examName.Width = 150;
            gc_examName.VisibleIndex = 11;
            this.gridViewArrivalWorkList.Columns.Add(gc_examName);

            // Online DateTime
            GridColumn gc_onlineDateTime = new GridColumn();
            gc_onlineDateTime.Caption = "Requested DateTime";
            gc_onlineDateTime.FieldName = "ONLINE_DATETIME";
            gc_onlineDateTime.DisplayFormat.FormatString = "d";
            gc_onlineDateTime.Width = 130;
            gc_onlineDateTime.VisibleIndex = 12;
            gc_onlineDateTime.OptionsFilter.AllowFilter = false;
            gc_onlineDateTime.OptionsFilter.AllowAutoFilter = false;
            this.gridViewArrivalWorkList.Columns.Add(gc_onlineDateTime);

            // Exam DateTime
            GridColumn gc_examDateTime = new GridColumn();
            gc_examDateTime.Caption = "Exam DateTime";
            gc_examDateTime.FieldName = "EXAM_DATETIME";
            gc_examDateTime.DisplayFormat.FormatString = "d";
            gc_examDateTime.Width = 130;
            gc_examDateTime.VisibleIndex = 13;
            gc_examDateTime.OptionsFilter.AllowFilter = false;
            gc_examDateTime.OptionsFilter.AllowAutoFilter = false;
            this.gridViewArrivalWorkList.Columns.Add(gc_examDateTime);

            // Modality
            GridColumn gc_modality = new GridColumn();
            gc_modality.Caption = "Modality";
            gc_modality.FieldName = "MODALITY_NAME";
            gc_modality.Width = 100;
            gc_modality.VisibleIndex = 14;
            this.gridViewArrivalWorkList.Columns.Add(gc_modality);

            // Unit
            GridColumn gc_unit = new GridColumn();
            gc_unit.Caption = "Unit";
            gc_unit.FieldName = "UNIT";
            gc_unit.Width = 70;
            gc_unit.VisibleIndex = 15;
            gc_unit.Visible = false;
            this.gridViewArrivalWorkList.Columns.Add(gc_unit);

            // Clinic
            GridColumn gc_clinic = new GridColumn();
            gc_clinic.Caption = "Encounter Type";
            gc_clinic.FieldName = "ENC_TYPE";
            gc_clinic.Width = 100;
            gc_clinic.VisibleIndex = 16;
            gc_clinic.Visible = true;
            this.gridViewArrivalWorkList.Columns.Add(gc_clinic);

            // Clinic
            GridColumn gc_encClinic = new GridColumn();
            gc_encClinic.Caption = "Encounter Clinic";
            gc_encClinic.FieldName = "ENC_CLINIC";
            gc_encClinic.Width = 100;
            gc_encClinic.VisibleIndex = 17;
            gc_encClinic.Visible = true;
            this.gridViewArrivalWorkList.Columns.Add(gc_encClinic);
            
            // Set Column can't edit mode
            foreach (GridColumn eachColumn in this.gridViewArrivalWorkList.Columns)
            {
                if (eachColumn.FieldName == "COMMENTS" || eachColumn.Name == "ADD")
                    continue;
                eachColumn.OptionsColumn.AllowEdit = false;
            }

            // Clinic
            GridColumn gc_btnDeleted = new GridColumn();
            gc_btnDeleted.Caption = "Delete";
            gc_btnDeleted.FieldName = "Delete";
            gc_btnDeleted.Width = 50;
            gc_btnDeleted.VisibleIndex = 17;
            gc_btnDeleted.Visible = true;
            RepositoryItemButtonEdit repButtonDelete = new RepositoryItemButtonEdit();
            repButtonDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            repButtonDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repButtonDelete.Click += new EventHandler(_repButtonDelete_Click);
            gc_btnDeleted.ColumnEdit = repButtonDelete;
            //gc_buttonAdd.OptionsColumn.AllowFocus = false;
            //gc_buttonAdd.Fixed = FixedStyle.Left;
            this.gridViewArrivalWorkList.Columns.Add(gc_btnDeleted);

            this.isSetDataGrid = true;
        }
        private void SetupFilter()
        {
            this.dtFrom.DateTime = DateTime.Today.AddDays(-1);
            this.dtTo.DateTime = DateTime.Today;
            //Create Modality filter datatable
            this.dtFilter = new DataTable("FILTER");
            this.dtFilter.Columns.Add("PAT_DEST_ID", typeof(int));
            this.dtFilter.Columns.Add("FILTER_MODE", typeof(int));
            this.dtFilter.Columns.Add("USE_AUTO_REFRESH", typeof(string));
            this.dtFilter.Columns.Add("SHOW_ALERT", typeof(string));
            this.dtFilter.Columns.Add("SHOW_MODE", typeof(string));
            this.dtFilter.AcceptChanges();
            //Create Exam Type Filter datatable
            this.dtExamTypeFilter = new DataTable("EXAM_FILTER");
            this.dtExamTypeFilter.Columns.Add("EXAM_TYPE_ID");
            this.dtExamTypeFilter.AcceptChanges();
            //## Read XML Storage
            string xmlFileName = string.Format("_{0}.xml", this.gblEnvVariable.UserID);

            string xmlFileNameForExamType = string.Format("_{0}_2.xml", this.gblEnvVariable.UserID);

            IsolatedStorateManagement.XMLToDataTable(xmlFileName, ref this.dtFilter);

            IsolatedStorateManagement.XMLToDataTable(xmlFileNameForExamType, ref this.dtExamTypeFilter);

            // Get all patient destination
            // DataTable dtModalitys = Envision.BusinessLogic.RISBaseData.Ris_Modality();
            ProcessGetRISPatientDestination processGetRISPatientDestination = new ProcessGetRISPatientDestination();
            processGetRISPatientDestination.RIS_PATIENTDESTINATION.ORG_ID = gblEnvVariable.OrgID;
            processGetRISPatientDestination.Invoke();
            // Get all exam type
            ProcessGetRISExamType _processGetRISExamType = new ProcessGetRISExamType();
            _processGetRISExamType.Invoke();

            if (Miracle.Util.Utilities.IsHaveData(processGetRISPatientDestination.Result) && Miracle.Util.Utilities.IsHaveData(_processGetRISExamType.Result))
            {
                DataTable dtPatientDest = processGetRISPatientDestination.Result.Tables[0];
                this.dtDestination = processGetRISPatientDestination.Result.Tables[0].Copy();
                // Set combobox patient destination item
                foreach (DataRow eachPatDest in dtPatientDest.Rows)
                {
                    if (dtFilter.Rows.Count > 0)
                    {
                        if (this.dtFilter.Select(string.Format("PAT_DEST_ID={0}", eachPatDest["PAT_DEST_ID"])).Length > 0)
                            this.chcUnit.Properties.Items.Add(eachPatDest["PAT_DEST_ID"], eachPatDest["LABEL"].ToString(), CheckState.Checked, true);
                        else
                            this.chcUnit.Properties.Items.Add(eachPatDest["PAT_DEST_ID"], eachPatDest["LABEL"].ToString(), CheckState.Unchecked, true);
                    }
                    else
                        this.chcUnit.Properties.Items.Add(eachPatDest["PAT_DEST_ID"], eachPatDest["LABEL"].ToString(), CheckState.Checked, true); // select all
                }

                DataTable dtExamType = _processGetRISExamType.Result.Tables[0];
                this.dtExamType = _processGetRISExamType.Result.Tables[0].Copy();
                //Set combobox exam type item
                foreach (DataRow eachExamType in dtExamType.Rows)
                {
                    if (this.dtExamTypeFilter.Rows.Count > 0)
                    {
                        if (this.dtExamTypeFilter.Select(string.Format("EXAM_TYPE_ID={0}", eachExamType["EXAM_TYPE_ID"].ToString())).Length > 0)
                            this.cbExamType.Properties.Items.Add(eachExamType["EXAM_TYPE_ID"], eachExamType["EXAM_TYPE_TEXT"].ToString(), CheckState.Checked, true);
                        else
                            this.cbExamType.Properties.Items.Add(eachExamType["EXAM_TYPE_ID"], eachExamType["EXAM_TYPE_TEXT"].ToString(), CheckState.Unchecked, true);
                    }
                    else
                        this.cbExamType.Properties.Items.Add(eachExamType["EXAM_TYPE_ID"], eachExamType["EXAM_TYPE_TEXT"].ToString(), CheckState.Checked, true); // select all
                }
                // set filter mode default
                try
                {
                    string _showAlert = dtFilter.Rows[0]["SHOW_ALERT"].ToString();
                    string _useAutoRefresh = dtFilter.Rows[0]["USE_AUTO_REFRESH"].ToString();
                    int mode = Convert.ToInt32(dtFilter.Rows[0]["FILTER_MODE"]);
                    // Filter mode
                    if (mode == 1)
                        this.SearchMode = SearchModes.SearchByHN;
                    else
                        this.SearchMode = SearchModes.SearchByDate;

                    this.rgSeachMode.EditValue = mode;
                    // Show alert 
                    if (_showAlert == "N")
                    {
                        this.ShowAlert = false;
                        this.chkshowAlert.Checked = false;
                    }
                    else
                    {
                        this.ShowAlert = true;
                        this.chkshowAlert.Checked = true;
                    }
                    // Use Auto Refresh
                    if (_useAutoRefresh == "N")
                    {
                        this.chkUseAutoRefresh.Checked = false;
                        this.chkshowAlert.Enabled = false;
                        this.IsAutoRefresh = false;
                    }
                    else
                    {
                        this.chkUseAutoRefresh.Checked = true;
                        this.chkshowAlert.Enabled = true;
                        this.IsAutoRefresh = true;
                    }
                    this.rdgShowType.EditValue = dtFilter.Rows[0]["SHOW_MODE"].ToString();
                    if (!string.IsNullOrEmpty(dtFilter.Rows[0]["SHOW_MODE"].ToString()))
                    {
                        switch (dtFilter.Rows[0]["SHOW_MODE"].ToString())
                        {
                            case "ALL": this.rdgShowType.SelectedIndex = 0; break;
                            case "ON": this.rdgShowType.SelectedIndex = 1; break;
                            case "OFF": this.rdgShowType.SelectedIndex = 2; break;
                            default: this.rdgShowType.SelectedIndex = 0; break;
                        }
                    }
                    else
                        this.rdgShowType.SelectedIndex = 0;
                }
                catch
                {
                    this.rgSeachMode.EditValue = 2;
                    this.SearchMode = SearchModes.SearchByDate;
                    this.chkshowAlert.Checked = true;
                    this.chkUseAutoRefresh.Checked = true;
                    this.rdgShowType.SelectedIndex = 0;//dtFilter.Rows[0]["SHOW_MODE"].ToString();
                }

                dtPatientDest = null;
                dtExamType = null;
            }
        }
        private DataTable BindingArrivalWorkList(SearchModes mode)
        {
            DataTable dtResult = new DataTable();
            ProcessGetXrayAndScheduleArrivalWorkList processGetXrayAndScheduleArrivalWorkList = new ProcessGetXrayAndScheduleArrivalWorkList();
            try
            {
                this.ShowLoadingDialog("Please wait...", 80, 50);
                processGetXrayAndScheduleArrivalWorkList.From = new DateTime(this.dtFrom.DateTime.Year, this.dtFrom.DateTime.Month, this.dtFrom.DateTime.Day, 0, 0, 0);
                processGetXrayAndScheduleArrivalWorkList.HN = this.tbHN.Text.Trim();
                processGetXrayAndScheduleArrivalWorkList.OrgId = this.gblEnvVariable.OrgID;
                // Select search mode
                switch (mode)
                {
                    //case SearchModes.OnlyOnline: _processGetXrayAndScheduleArrivalWorkList.SearchMode = ProcessGetXrayAndScheduleArrivalWorkList.SearchModes.OnlyOnline; break;
                    case SearchModes.SearchByDate: processGetXrayAndScheduleArrivalWorkList.SearchMode = ProcessGetXrayAndScheduleArrivalWorkList.SearchModes.ByExamDate; break;
                    case SearchModes.SearchByHN: processGetXrayAndScheduleArrivalWorkList.SearchMode = ProcessGetXrayAndScheduleArrivalWorkList.SearchModes.ByHN; break;
                    //case SearchModes.SearchByNoExamDate: _processGetXrayAndScheduleArrivalWorkList.SearchMode = ProcessGetXrayAndScheduleArrivalWorkList.SearchModes.NoExamDate; break;
                    default: processGetXrayAndScheduleArrivalWorkList.SearchMode = ProcessGetXrayAndScheduleArrivalWorkList.SearchModes.ByExamDate; break;
                }
                processGetXrayAndScheduleArrivalWorkList.To = new DateTime(this.dtTo.DateTime.Year, this.dtTo.DateTime.Month, this.dtTo.DateTime.Day, 23, 59, 59); ;
                processGetXrayAndScheduleArrivalWorkList.Filter = this.GetFilter();
                processGetXrayAndScheduleArrivalWorkList.ExamTypeFilter = this.GetExamTypeFilter();
                string showMode = this.rdgShowType.EditValue.ToString();
                switch (showMode)
                {
                    case "ALL": processGetXrayAndScheduleArrivalWorkList.ShowMode = 0; break;
                    case "ON": processGetXrayAndScheduleArrivalWorkList.ShowMode = 1; break;
                    case "OFF": processGetXrayAndScheduleArrivalWorkList.ShowMode = 2; break;
                    default: processGetXrayAndScheduleArrivalWorkList.ShowMode = 0; break;
                }

                if (dtFilter.Rows.Count == dtDestination.Rows.Count)
                    processGetXrayAndScheduleArrivalWorkList.isShowAll = true;
                else
                    processGetXrayAndScheduleArrivalWorkList.isShowAll = false;

                processGetXrayAndScheduleArrivalWorkList.Invoke();
                // Binding 
                this.gridControlArrivalWorkList.DataSource = dtResult = processGetXrayAndScheduleArrivalWorkList.Result.Tables[0];
            }
            finally
            {
                processGetXrayAndScheduleArrivalWorkList = null;
                this.CloseLoadingDialog();
            }
            return dtResult;
        }
        private string GetExamTypeFilter()
        {
            string filter = string.Empty;
            string[] filters = this.cbExamType.EditValue.ToString().Split(',');
            foreach (string eachfilter in filters)
            {
                filter += "," + eachfilter.Trim();
            }
            return filter.TrimStart(',') == string.Empty ? "0" : filter.TrimStart(',');
        }

        private string GetFilter()
        {
            string filter = string.Empty;
            string[] filters = this.chcUnit.EditValue.ToString().Split(',');
            foreach (string eachfilter in filters)
            {
                filter += "," + eachfilter.Trim();
            }
            return filter.TrimStart(',') == string.Empty ? "0" : filter.TrimStart(',');
        }
        private void CloseLoadingDialog()
        {
            this.waitDialog.Close();
        }
        private void ShowLoadingDialog(string message, int width, int height)
        {
            this.waitDialog = new DevExpress.Utils.WaitDialogForm(message, "Dialog", new Size(width, height));
        }
        private void SetSearchMode(int value)
        {
            if (value == 3 || value == 4)
                return;
            bool flag = false;
            if (value == 2)
                flag = true;
            this.txtFrom.Visible = flag;
            this.txtTo.Visible = flag;
            this.txdtHN.Visible = !flag;
            this.dtFrom.Visible = flag;
            this.dtTo.Visible = flag;
            this.tbHN.Visible = !flag;
            //this.chkShowNoExamDate.Visible = flag;
        }

        private void gridControlArrivalWorkList_DoubleClick(object sender, EventArgs e)
        {
            this.SelectCase();
        }
        private void _repButtonEdit_Click(object sender, EventArgs e)
        {
            this.SelectCase();
        }
        private void _repButtonDelete_Click(object sender, EventArgs e)
        {
            if (this.gridViewArrivalWorkList.FocusedRowHandle < 0)
                return;

            if (this.IsAutoRefresh)
                this.PauseAutoRefresh(); // pause auto refresh

            //DataRow row = this.gridViewArrivalWorkList.GetFocusedDataRow();
            //if (row["IS_SCHEDULE"].ToString() == "Y" && row["STATUS"].ToString().Trim() == "W")
            //{
            //    myMsg.ShowAlert("UID2124", gblEnvVariable.CurrentLanguageID);
            //    return;
            //}

            string strMsg = myMsg.ShowAlert("UID1025", gblEnvVariable.CurrentLanguageID);
            if (strMsg == "2")
            {
                DataRow row = this.gridViewArrivalWorkList.GetFocusedDataRow();
                if (row["IS_SCHEDULE"].ToString() == "N")
                {
                    string msgBox = "HN : " + row["HN"].ToString()
                        + "\r\nName : " + row["PATIENT_NAME"].ToString()
                        + "\r\nExam : " + row["EXAM_UID"].ToString() + "-" + row["EXAM_NAME"].ToString()
                        + "\r\nStudy Date : " + row["EXAM_DATETIME"].ToString();
                    DialogResult dlg = MessageBox.Show(msgBox, "Schedule Cancelling", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.Cancel)
                    {
                        if (this.IsAutoRefresh)
                            this.StartAutoRefresh();
                        return;
                    }

                    frmOrdersCancelForm frmCancel
                        = new frmOrdersCancelForm();
                    if (frmCancel.ShowDialog() != DialogResult.OK)
                    {
                        if (this.IsAutoRefresh)
                            this.StartAutoRefresh();
                        frmCancel.Dispose();
                        return;
                    }

                    DataRow rowCancel = frmCancel.SELECTED;
                    string strReason = rowCancel["CAN_NAME"].ToString();
                    frmCancel.Dispose();
                    string OrderID = row["ORDER_ID"].ToString();

                    ProcessDeleteXRAYREQDTL prc = new ProcessDeleteXRAYREQDTL();
                    prc.XRAYREQDTL.ORDER_ID = Convert.ToInt32(OrderID);
                    prc.XRAYREQDTL.EXAM_ID = Convert.ToInt32(row["EXAM_ID"]);
                    prc.XRAYREQDTL.REASON = strReason;
                    prc.XRAYREQDTL.IS_DELETED = "Y";
                    prc.XRAYREQDTL.LAST_MODIFIED_BY = gblEnvVariable.UserID;
                    prc.Invoke();

                    myMsg.ShowAlert("UID2125", gblEnvVariable.CurrentLanguageID);
                    dtCurrent = BindingArrivalWorkList(this.SearchMode);
                }
                else
                {
                    ConfirmDialog confrim = new ConfirmDialog(Convert.ToInt32(row["SCHEDULE_ID"].ToString()), row["MODALITY_ID"].ToString(), DateTime.Now, DateTime.Now);
                    confrim.Text = "ลบข้อมูล";
                    confrim.dtInsu = RISBaseData.Ris_InsuranceType();
                    confrim.dttBpview = RISBaseData.BP_View();
                    confrim.dttDoctor = RISBaseData.His_Doctor();
                    confrim.dttRadiologist = RISBaseData.Ris_Radiologist();

                    DialogResult dlg = confrim.ShowDialog();
                    if (dlg != DialogResult.OK)
                    {
                        confrim.Dispose();
                        if (this.IsAutoRefresh)
                            this.StartAutoRefresh();
                        return;
                    }
                    string strReason = confrim.REASON;
                    confrim.Dispose();
                    string ScheduleID = row["SCHEDULE_ID"].ToString();

                    ProcessDeleteRISSchedule process = new ProcessDeleteRISSchedule();
                    process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(row["SCHEDULE_ID"].ToString());
                    process.RIS_SCHEDULE.REASON_CHANGE = strReason;
                    process.RIS_SCHEDULE.REASON = strReason;
                    process.RIS_SCHEDULE.LAST_MODIFIED_BY = gblEnvVariable.UserID;
                    process.Invoke();

                    myMsg.ShowAlert("UID2125", gblEnvVariable.CurrentLanguageID);
                    dtCurrent = BindingArrivalWorkList(this.SearchMode);
                }
            }

            if (this.IsAutoRefresh)
                this.StartAutoRefresh();
        }
        private void SelectCase()
        {
            if (this.gridViewArrivalWorkList.FocusedRowHandle < 0)
                return;

            if (this.IsAutoRefresh)
                this.PauseAutoRefresh(); // pause auto refresh

            DataRow drSelected = this.gridViewArrivalWorkList.GetFocusedDataRow();

            if (drSelected["IS_SCHEDULE"].ToString() == "Y")
            {
                if (drSelected["STATUS"].ToString().Trim() == "W")
                {
                    myMsg.ShowAlert("UID2124", gblEnvVariable.CurrentLanguageID);
                    if (this.IsAutoRefresh)
                        this.StartAutoRefresh();
                    return;
                }
                else if (drSelected["STATUS"].ToString().Trim() == "P")
                {
                    myMsg.ShowAlert("UID2130", gblEnvVariable.CurrentLanguageID);
                    if (this.IsAutoRefresh)
                        this.StartAutoRefresh();
                    return;
                }
                else if (drSelected["STATUS"].ToString().Trim() == "V")
                {
                    string resultAlert = myMsg.ShowAlert("UID4054", gblEnvVariable.CurrentLanguageID);
                    if (resultAlert == "2")
                    {
                        bool checkBusy = getBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                            (int)drSelected["ORDER_ID"],
                            (int)drSelected["SCHEDULE_ID"]);

                        if (checkBusy)
                        {
                            myMsg.ShowAlert("UID1417", gblEnvVariable.CurrentLanguageID);
                            return;
                        }
                        else
                        {
                            updateBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                                (int)drSelected["ORDER_ID"],
                            (int)drSelected["SCHEDULE_ID"],
                            "Y"
                                );
                        }
                        frmConfirmArrivalWorkList comfirmArrivalWorkList;
                        if (drSelected["IS_SCHEDULE"].ToString() == "N")
                            comfirmArrivalWorkList = new frmConfirmArrivalWorkList((int)drSelected["ORDER_ID"], 0, this.gblEnvVariable.OrgID);
                        else
                            comfirmArrivalWorkList = new frmConfirmArrivalWorkList(0, (int)drSelected["SCHEDULE_ID"], this.gblEnvVariable.OrgID);
                        if (comfirmArrivalWorkList.ShowDialog() == DialogResult.OK)
                        {
                            updateBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                                (int)drSelected["ORDER_ID"],
                            (int)drSelected["SCHEDULE_ID"],
                            "N"
                                );
                            dtCurrent = BindingArrivalWorkList(this.SearchMode);

                        }
                        if (this.IsAutoRefresh)
                            this.StartAutoRefresh(); //resume auto refresh
                    }
                    return;
                }
                else
                {
                    bool checkBusy = getBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                            (int)drSelected["ORDER_ID"],
                            (int)drSelected["SCHEDULE_ID"]);

                    if (checkBusy)
                    {
                        myMsg.ShowAlert("UID1417", gblEnvVariable.CurrentLanguageID);
                        return;
                    }
                    else
                    {
                        updateBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                        (int)drSelected["ORDER_ID"],
                        (int)drSelected["SCHEDULE_ID"],
                        "Y");

                        if (DateTime.Compare(Convert.ToDateTime(drSelected["EXAM_DATETIME"]).Date, DateTime.Today.Date) == 0)
                        {
                            frmConfirmArrivalWorkList comfirmArrivalWorkList;
                            if (drSelected["IS_SCHEDULE"].ToString() == "N")
                                comfirmArrivalWorkList = new frmConfirmArrivalWorkList((int)drSelected["ORDER_ID"], 0, this.gblEnvVariable.OrgID);
                            else
                                comfirmArrivalWorkList = new frmConfirmArrivalWorkList(0, (int)drSelected["SCHEDULE_ID"], this.gblEnvVariable.OrgID);
                            comfirmArrivalWorkList.ShowDialog();
                            dtCurrent = BindingArrivalWorkList(this.SearchMode);
                            updateBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                                (int)drSelected["ORDER_ID"],
                                (int)drSelected["SCHEDULE_ID"],
                                "N" );
                        }
                        else
                        {
                            if (drSelected["LABEL"].ToString() == "AIMC" ||
                                drSelected["LABEL"].ToString() == "SDMC")
                            {
                                frmConfirmArrivalWorkList comfirmArrivalWorkList;
                                if (drSelected["IS_SCHEDULE"].ToString() == "N")
                                    comfirmArrivalWorkList = new frmConfirmArrivalWorkList((int)drSelected["ORDER_ID"], 0, this.gblEnvVariable.OrgID);
                                else
                                    comfirmArrivalWorkList = new frmConfirmArrivalWorkList(0, (int)drSelected["SCHEDULE_ID"], this.gblEnvVariable.OrgID);
                                comfirmArrivalWorkList.ShowDialog();
                                dtCurrent = BindingArrivalWorkList(this.SearchMode);
                                updateBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                                (int)drSelected["ORDER_ID"],
                                (int)drSelected["SCHEDULE_ID"],
                                "N");
                            }
                            else
                            {
                                updateBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                               (int)drSelected["ORDER_ID"],
                               (int)drSelected["SCHEDULE_ID"],
                               "N");
                                myMsg.ShowAlert("UID4055", gblEnvVariable.CurrentLanguageID);
                                return;
                            }
                        }
                    }

                    if (this.IsAutoRefresh)
                        this.StartAutoRefresh(); //resume auto refresh
                    return;
                }
            }
            string result = "";
            if (DateTime.Compare(Convert.ToDateTime(drSelected["EXAM_DATETIME"]).Date, DateTime.Today.Date) == 0)
                result = "2";
            else
                result = myMsg.ShowAlert("UID6127", gblEnvVariable.CurrentLanguageID);

            if (result == "2")
            {
                bool checkBusy = getBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                          (int)drSelected["ORDER_ID"],
                          (int)drSelected["SCHEDULE_ID"]);

                if (checkBusy)
                {
                    myMsg.ShowAlert("UID1417", gblEnvVariable.CurrentLanguageID);
                    return;
                }
                else
                {
                    updateBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                        (int)drSelected["ORDER_ID"],
                    (int)drSelected["SCHEDULE_ID"],
                    "Y"
                        );
                }

                frmConfirmArrivalWorkList comfirmArrivalWorkList;
                if (drSelected["IS_SCHEDULE"].ToString() == "N")
                    comfirmArrivalWorkList = new frmConfirmArrivalWorkList((int)drSelected["ORDER_ID"], 0, this.gblEnvVariable.OrgID);
                else
                    comfirmArrivalWorkList = new frmConfirmArrivalWorkList(0, (int)drSelected["SCHEDULE_ID"], this.gblEnvVariable.OrgID);
                comfirmArrivalWorkList.ShowDialog();
                dtCurrent = BindingArrivalWorkList(this.SearchMode);

                updateBusyCase(drSelected["IS_SCHEDULE"].ToString() == "N" ? "XRAYREQ" : "SCHEDULE",
                                (int)drSelected["ORDER_ID"],
                            (int)drSelected["SCHEDULE_ID"],
                            "N"
                                );
            }
            if (this.IsAutoRefresh)
                this.StartAutoRefresh(); //resume auto refresh
        }

        private void SaveFilter()
        {
            string value = chcUnit.EditValue.ToString();
            string value2 = cbExamType.EditValue.ToString();
            string xmlFileName = string.Format("_{0}.xml", this.gblEnvVariable.UserID);
            string xmlFileNameForExamType = string.Format("_{0}_2.xml", this.gblEnvVariable.UserID);

            // ## SAVE TO STORAGE
            try
            {
                // Fill value to datatable
                string[] values = value.Split(',');
                this.dtFilter.Rows.Clear(); //clear old value
                // add new filter
                foreach (string eachValue in values)
                {
                    if (!string.IsNullOrEmpty(eachValue.Trim()))
                        this.dtFilter.Rows.Add(Convert.ToInt32(eachValue.Trim()),
                            this.rgSeachMode.EditValue.ToString(),
                            this.chkUseAutoRefresh.Checked == true ? "Y" : "N",
                            this.chkshowAlert.Checked == true ? "Y" : "N",
                            this.rdgShowType.EditValue.ToString());
                }
                this.dtFilter.AcceptChanges();

                IsolatedStorateManagement.DataTableToXML(xmlFileName, this.dtFilter);

                string[] values2 = value2.Split(',');
                this.dtExamTypeFilter.Rows.Clear(); //clear old value
                // add new filter
                foreach (string eachValue2 in values2)
                {
                    if (!string.IsNullOrEmpty(eachValue2.Trim()))
                        this.dtExamTypeFilter.Rows.Add(eachValue2.Trim());
                }
                this.dtExamTypeFilter.AcceptChanges();

                IsolatedStorateManagement.DataTableToXML(xmlFileNameForExamType, this.dtExamTypeFilter);
            }
            catch { }
            finally { value = string.Empty; }
        }
        private void gridViewArrivalWorkList_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow drRow = this.gridViewArrivalWorkList.GetDataRow(e.RowHandle);
                if (drRow != null)
                {
                    if (drRow["IS_ALERT_CLINICAL_INSTRUCTION"].ToString() == "Y")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                        //e.Appearance.ForeColor = Color.White;
                    }else
                    if (drRow["IS_REQONLINE"].ToString() == "Y" && drRow["STATUS"].ToString() != "O")
                        if (drRow["STATUS"].ToString() == "V")
                            e.Appearance.BackColor = Color.MediumVioletRed;
                        else
                            e.Appearance.BackColor = Color.SkyBlue; // online case
                    else
                        e.Appearance.BackColor = Color.White;
                }
            }
        }
        private void clinicalIndicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gridViewArrivalWorkList.FocusedRowHandle >= 0)
            {
                if (this.IsAutoRefresh)
                    this.PauseAutoRefresh(); // pause auto refresh
                string clinicalInstruction = this.gridViewArrivalWorkList.GetFocusedDataRow()["CLINICAL_INSTRUCTION"].ToString();
                this.clinicalIndicationDialog.ShowDialog(clinicalInstruction);
                if (this.IsAutoRefresh)
                    this.StartAutoRefresh(); //resume auto refresh                
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.gridViewArrivalWorkList.FocusedRowHandle >= 0)
            {
                if (this.IsAutoRefresh)
                    this.PauseAutoRefresh(); // pause auto refresh
                DataRow drSelectedRow = this.gridViewArrivalWorkList.GetFocusedDataRow();
                if (drSelectedRow["IS_SCHEDULE"].ToString() == "Y")
                    this.orderOrScheduleSummary.ShowDialog(true, Convert.ToInt32(drSelectedRow["REG_ID"]), Convert.ToInt32(drSelectedRow["SCHEDULE_ID"]), Convert.ToInt32(drSelectedRow["EXAM_ID"]), frmPopupOrderOrScheduleSummary.PagesModes.Schedule);
                else
                    this.orderOrScheduleSummary.ShowDialog(true, Convert.ToInt32(drSelectedRow["REG_ID"]), Convert.ToInt32(drSelectedRow["ORDER_ID"]), Convert.ToInt32(drSelectedRow["EXAM_ID"]), frmPopupOrderOrScheduleSummary.PagesModes.Order, drSelectedRow["IS_REQONLINE"].ToString() == "Y" ? true : false);
                //this._orderOrScheduleSummary.ShowDialog("20101020XA0021");
                if (this.IsAutoRefresh)
                    this.StartAutoRefresh(); //resume auto refresh
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.IsAutoRefresh)
                this.PauseAutoRefresh(); // pause auto refresh

            DataRow drSelected = this.gridViewArrivalWorkList.GetFocusedDataRow();
            if (drSelected["IS_SCHEDULE"].ToString() == "N")
            {
                frmMessageConversation frm = new frmMessageConversation(Convert.ToInt32(drSelected["ORDER_ID"]), true);
                frm.ShowDialog();
            }
            else
            {
                frmMessageConversation frm = new frmMessageConversation(Convert.ToInt32(drSelected["SCHEDULE_ID"]));
                frm.ShowDialog();
            }
            dtCurrent = BindingArrivalWorkList(this.SearchMode);
            if (this.IsAutoRefresh)
                this.StartAutoRefresh(); //resume auto refresh
        }
        private void mergeRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridViewArrivalWorkList.FocusedRowHandle >= 0)
            {
                if (this.IsAutoRefresh)
                    this.PauseAutoRefresh(); // pause auto refresh

                DataRow rowData = gridViewArrivalWorkList.GetDataRow(gridViewArrivalWorkList.FocusedRowHandle);
                frmRequestMerge frmMerge = new frmRequestMerge(Convert.ToInt32(rowData["ORDER_ID"]));
                frmMerge.ShowDialog();
                dtCurrent = BindingArrivalWorkList(this.SearchMode);

                if (this.IsAutoRefresh)
                    this.StartAutoRefresh(); //resume auto refresh
            }
        }
        private void cbExamType_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isSetDataGrid)
                dtCurrent = BindingArrivalWorkList(this.SearchMode);
        }
        private void cbExamType_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            string value = chcUnit.EditValue.ToString();
            string value2 = cbExamType.EditValue.ToString();
            string xmlFileName = string.Format("_{0}.xml", this.gblEnvVariable.UserID);
            string xmlFileNameForExamType = string.Format("_{0}_2.xml", this.gblEnvVariable.UserID);

            // ## SAVE TO STORAGE
            try
            {
                // Fill value to datatable
                string[] values = value.Split(',');
                this.dtFilter.Rows.Clear(); //clear old value
                // add new filter
                foreach (string eachValue in values)
                {
                    if (!string.IsNullOrEmpty(eachValue.Trim()))
                        this.dtFilter.Rows.Add(Convert.ToInt32(eachValue.Trim()),
                            this.rgSeachMode.EditValue.ToString(),
                            this.chkUseAutoRefresh.Checked == true ? "Y" : "N",
                            this.chkshowAlert.Checked == true ? "Y" : "N",
                            this.rdgShowType.EditValue.ToString());
                }
                this.dtFilter.AcceptChanges();

                IsolatedStorateManagement.DataTableToXML(xmlFileName, this.dtFilter);

                string[] values2 = value2.Split(',');
                this.dtExamTypeFilter.Rows.Clear(); //clear old value
                // add new filter
                foreach (string eachValue2 in values2)
                {
                    if (!string.IsNullOrEmpty(eachValue2.Trim()))
                        this.dtExamTypeFilter.Rows.Add(eachValue2.Trim());
                }
                this.dtExamTypeFilter.AcceptChanges();

                IsolatedStorateManagement.DataTableToXML(xmlFileNameForExamType, this.dtExamTypeFilter);
            }
            catch { }
            finally { value = string.Empty; }
        }

        //Form Closing
        protected override void OnClosing(CancelEventArgs e)
        {
            this.StopAutoRefresh(); //stop auto refresh
            this.SaveFilter();
            base.OnClosing(e);
        }
        
        //Timer
        private void SetupTimer()
        {
            this.tmAutoRefresh = new Timer();
            this.tmAutoRefresh.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds; // 5 minute
            this.tmAutoRefresh.Tick += OnAutoRefreshTick;
        }
        private void OnAutoRefreshTick(object sender, EventArgs e)
        {
            string _filter = gridViewArrivalWorkList.ActiveFilterString;
            DataView dvCurrentFilter = dtCurrent.DefaultView;
            dvCurrentFilter.RowFilter = _filter;

            DataTable dt = BindingArrivalWorkList(this.SearchMode);
            DataTable dtTemp = dt.Copy();
            DataView dvDataFilter = dtTemp.DefaultView;
            dvDataFilter.RowFilter = _filter;

            DataTable dtCurrentCheck = dvCurrentFilter.ToTable();
            DataTable dtDataCheck = dvDataFilter.ToTable();

            IEnumerable<int> orderDataInA = dtCurrentCheck.AsEnumerable().Select(row => (int)row["ORDER_ID"]);
            IEnumerable<int> orderDataInB = dtDataCheck.AsEnumerable().Select(row => (int)row["ORDER_ID"]);
            IEnumerable<int> orderBnotA = orderDataInB.Except(orderDataInA);
            int OrderCompare = orderBnotA.Count();
            IEnumerable<int> scheduleDataInA = dtCurrentCheck.AsEnumerable().Select(row => (int)row["SCHEDULE_ID"]);
            IEnumerable<int> scheduleDataInB = dtDataCheck.AsEnumerable().Select(row => (int)row["SCHEDULE_ID"]);
            IEnumerable<int> scheduleBnotA = scheduleDataInB.Except(scheduleDataInA);
            int ScheduleCompare = scheduleBnotA.Count();
            if (OrderCompare > 0 || ScheduleCompare > 0)
            {
                if (this.ShowAlert)
                {
                    PauseAutoRefresh();
                    this.arrivalMessage.ShowDialog();
                    if (this.arrivalMessage.DialogResult == DialogResult.OK)
                    {
                        StartAutoRefresh();
                        // Nothing
                    }
                }
            }

            dtCurrent.BeginLoadData();
            dtCurrent = dt;
            dtCurrent.EndLoadData();

        }
        private void StartAutoRefresh() { this.tmAutoRefresh.Start(); }
        private void PauseAutoRefresh() { this.tmAutoRefresh.Stop(); }
        private void StopAutoRefresh()
        {
            if (this.tmAutoRefresh == null) return;
            this.tmAutoRefresh.Stop();
            this.tmAutoRefresh.Dispose();
            this.tmAutoRefresh = null; //destroy timer
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            ToolTipControlInfo info = null;
            if (e.SelectedControl == gridControlArrivalWorkList)
            {
                try
                {

                    GridView view = gridControlArrivalWorkList.GetViewAt(e.ControlMousePosition) as GridView;
                    if (view == null) return;
                    GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle >= 0)
                        {
                            DataRow rowPatientDetail = view.GetDataRow(hi.RowHandle);
                            switch (hi.Column.FieldName)
                            {
                                case "PATIENT_ID_LABEL":
                                    if (!string.IsNullOrEmpty(rowPatientDetail["PATIENT_ID_LABEL"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowPatientDetail["PATIENT_ID_DETAIL"].ToString());
                                        return;
                                    }
                                    break;
                                case "CLINICAL_INSTRUCTION_TAG":
                                    if (!string.IsNullOrEmpty(rowPatientDetail["CLINICAL_INSTRUCTION_TAG"].ToString()))
                                    {
                                        string strinfo = string.Empty;
                                        string[] tag = rowPatientDetail["CLINICAL_INSTRUCTION_TAG"].ToString().Split(',');
                                        DataTable dtCliType = dtClinicalindicationtype.Tables[0].Copy();

                                        foreach (string str in tag)
                                        {
                                            DataRow[] drClitype = dtCliType.Select("CI_TAG = '" + str + "'");
                                            if (drClitype.Length > 0)
                                            {
                                                if (strinfo == string.Empty)
                                                    strinfo = drClitype[0]["CI_DESC"].ToString();
                                                else
                                                    strinfo += "\r\n" + drClitype[0]["CI_DESC"].ToString();
                                            }
                                        }

                                        if (strinfo != string.Empty)
                                            info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), strinfo);

                                        return;
                                    }
                                    break;
                            }
                        }
                    }
                    if (hi.HitTest == GridHitTest.Column)
                    {
                        switch (hi.Column.FieldName)
                        {
                            case "SCANIMAGES": info = new ToolTipControlInfo(hi.HitTest, "Document"); break;
                            case "READER": info = new ToolTipControlInfo(hi.HitTest, "Comments"); break;
                            case "PATIENT_ID_LABEL": info = new ToolTipControlInfo(hi.HitTest, "Patient Detail"); break;
                            case "FLAG_ICON": info = new ToolTipControlInfo(hi.HitTest, "Exam Flag"); break;
                            case "CLINICAL_INSTRUCTION_TAG": info = new ToolTipControlInfo(hi.HitTest, "Alert Code"); break;
                            case "IS_TELEMED": info = new ToolTipControlInfo(hi.HitTest, "Tele Med."); break;
                            default: info = new ToolTipControlInfo(hi.HitTest, hi.Column.Caption); break;
                        }
                    }
                }
                finally
                {
                    e.Info = info;
                }
            }
        }

        private void gridViewArrivalWorkList_ColumnFilterChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            if (gridViewArrivalWorkList.FocusedRowHandle >= 0)
            {
                mergeRequestToolStripMenuItem.Visible = false;
                DataRow drRow = this.gridViewArrivalWorkList.GetDataRow(gridViewArrivalWorkList.FocusedRowHandle);
                if (drRow != null)
                {
                    if (drRow["IS_REQONLINE"].ToString() == "Y" && drRow["STATUS"].ToString() != "O")
                        if (drRow["STATUS"].ToString() == "R")
                            mergeRequestToolStripMenuItem.Visible = true;
                        
                }
            }
        }

        private bool getBusyCase(string mode, int orderId, int scheduleId)
        {
            bool flag = false;
            switch (mode)
            {
                case "SCHEDULE":
                    ProcessGetRISSchedule sch = new ProcessGetRISSchedule();
                    sch.RIS_SCHEDULE.SCHEDULE_ID = scheduleId;
                    DataTable dtSch = sch.GetBusyStatus();
                    if (Utilities.IsHaveData(dtSch))
                        if (dtSch.Rows[0]["IS_BUSY"].ToString() == "Y" && dtSch.Rows[0]["BUSY_BY"].ToString() != gblEnvVariable.UserID.ToString())
                            flag = true;
                    break;
                case "XRAYREQ":
                    ProcessGetXRAYREQ xryReq = new ProcessGetXRAYREQ();
                    DataTable dtxryReq = xryReq.GetBusyCase(orderId);
                    if (Utilities.IsHaveData(dtxryReq))
                        if (dtxryReq.Rows[0]["IS_BUSY"].ToString() == "Y" && dtxryReq.Rows[0]["BUSY_BY"].ToString() != gblEnvVariable.UserID.ToString())
                            flag = true;
                    break;
            }
            return flag;
        }
        private void updateBusyCase(string mode,int orderId,int scheduleId, string busy)
        {
            switch (mode)
            {
                case "SCHEDULE":
                    ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                    proc.RIS_SCHEDULE.SCHEDULE_ID = scheduleId;
                    proc.RIS_SCHEDULE.IS_BUSY = busy;
                    proc.RIS_SCHEDULE.LAST_MODIFIED_BY = gblEnvVariable.UserID;
                    proc.UpdateBusy();
                    break;
                case "XRAYREQ":
                    ProcessUpdateXRAYREQ xryReq = new ProcessUpdateXRAYREQ();
                    xryReq.updateLockCase(orderId, busy, gblEnvVariable.UserID);
                    break;
            }
            
        }
    }
}