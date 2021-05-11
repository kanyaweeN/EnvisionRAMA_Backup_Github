using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.NET.Mammogram.ResultEntry.BIRAD.Common;
using EnvisionBreastControl.Lib;

namespace Envision.NET.Mammogram.StructureReport
{
    public partial class BiradDominantCystList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public enum DominantTypes
        {
            Mass, Cyst
        }
        private DominantTypes dominantType = DominantTypes.Mass;
        private DataSet dsDominantList;
        private List<MarkStruct> markerList;
        
        //private bool IsReadOnly = false;
        public BiradDominantCystList()
        {
            InitializeComponent();
            //this.repCbMassNo.SelectedIndexChanged += new EventHandler(repCbMassNo_SelectedIndexChanged);
            this.repBtnDelete.Click += new EventHandler(repBtnDelete_Click);
            this.btnCancel.ItemClick += new ItemClickEventHandler(btnCancel_ItemClick);
            this.repDetele2.Click += new EventHandler(repDetele2_Click);
            this.btnOK.ItemClick += new ItemClickEventHandler(btnOK_ItemClick);

            this.gvDominantCyst.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvDominantMass.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            //this.gvDominantMass.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gvDominantMass_InitNewRow);
            //this.gvDominantCyst.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(gvDominantCyst_InitNewRow);
            this.gvDominantMass.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvDominantMass_ValidateRow);
            this.gvDominantCyst.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gvDominantCyst_ValidateRow);
        }


        #region Initial New Row
        /// <summary>
        /// Dominant Cyst Initial new Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvDominantCyst_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Row;
            if (dr != null)
            {
                DataRow row = dr.Row;
                foreach (MarkStruct ms in markerList)
                {
                    if (ms.MassUSDetail.MASS_NO.ToString() == row["MASS_NO"].ToString())
                    {
                        CShapeControl cShapeControl = ms.MarkObject as CShapeControl;
                        row["BREAST_VIEW"] = ms.MassUSDetail.BREAST_TYPE == "L" ? "Left" : "Right";
                        row["LOCATION"] = ms.MassUSDetail.MASS_LOCATION_CLOCK;
                        row["SIZE"] = cShapeControl.Diameter.ToString();
                        //this.repCombobox2.Items.Remove(ms.MassUSDetail.MASS_NO.ToString());
                        this.AddComboboxItem(this.dsDominantList);
                        this.removeRow(dr.Row);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Dominant Mass Initial new Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvDominantMass_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Row;
            if (dr != null)
            {
                DataRow row = dr.Row;
                foreach (MarkStruct ms in markerList)
                {
                    if (ms.MassDetail.MASS_NO.ToString() == row["MASS_NO"].ToString())
                    {
                        CShapeControl cShapeControl = ms.MarkObject as CShapeControl;
                        row["BREAST_VIEW"] = ms.MassDetail.BREAST_TYPE == "L" ? "Left" : "Right";
                        row["LOCATION"] = ms.MassDetail.MASS_LOCATION_CLOCK;
                        row["SIZE"] = cShapeControl.Diameter.ToString();
                        //this.repCbMassNo.Items.Remove(ms.MassDetail.MASS_NO.ToString());
                        this.AddComboboxItem(this.dsDominantList);
                        this.removeRow(dr.Row);
                        break;
                    }
                }
            }
        }

      

        #endregion

        /// <summary>
        /// OK tools bar item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Close tools bar item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Delete Btn Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repBtnDelete_Click(object sender, EventArgs e)
        {
            if (this.gvDominantMass.FocusedRowHandle >= 0)
            {
                //if (this.gvDominantMass.FocusedRowHandle + 1 > this.gvDominantMass.RowCount)
                //    return;
                DataRow dr = this.gvDominantMass.GetDataRow(this.gvDominantMass.FocusedRowHandle);
                if (dr != null)
                {
                    string mass_no = dr["MASS_NO"].ToString();
                    if (mass_no.Length > 0)
                    {
                        //this.repCbMassNo.Items.Add(mass_no);
                        this.dsDominantList.Tables[0].Rows.Remove(dr);
                        this.AddComboboxItem(this.dsDominantList);
                        //this.gvDominantMass.RefreshData();
                    }
                }
            }
        }

        private void repDetele2_Click(object sender, EventArgs e)
        {
            if (this.gvDominantCyst.FocusedRowHandle >= 0)
            {
                //if (this.gvDominantMass.FocusedRowHandle + 1 > this.gvDominantMass.RowCount)
                //    return;
                DataRow dr = this.gvDominantCyst.GetDataRow(this.gvDominantMass.FocusedRowHandle);
                if (dr != null)
                {
                    string mass_no = dr["MASS_NO"].ToString();
                    if (mass_no.Length > 0)
                    {
                        //this.repCbMassNo.Items.Add(mass_no);
                        this.dsDominantList.Tables[1].Rows.Remove(dr);
                        this.AddComboboxItem(this.dsDominantList);
                        //this.gvDominantCyst.RefreshData();
                    }
                }
            }
        }

     

        /// <summary>
        /// Show Dialog by mark list
        /// </summary>
        /// <param name="markerList"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(List<MarkStruct> markerList, bool isReadOnly, DominantTypes type)
        {
            //Create DataSet from Mark list
            this.markerList = markerList;
            if (type == DominantTypes.Mass)
                this.tabControl.SelectedTabPageIndex = 0;
            else
                this.tabControl.SelectedTabPageIndex = 1;
            this.dsDominantList = this.CreateMarkForDominantDataSet();
            this.AddComboboxItem();
            this.gcDominantMassList.DataSource = this.dsDominantList.Tables[0];
            this.gcBreast.OptionsColumn.AllowEdit = !isReadOnly;
            this.gcDelete.OptionsColumn.AllowEdit = !isReadOnly;
            return this.ShowDialog();
        }

        /// <summary>
        /// Show Dialog by mark list and old dominant list dataset
        /// </summary>
        /// <param name="markerList"></param>
        /// <param name="oldDsDominantList"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(List<MarkStruct> markerList, DataSet oldDsDominantList, bool isReadOnly, DominantTypes type)
        {
            if (type == DominantTypes.Mass)
                this.tabControl.SelectedTabPageIndex = 0;
            else
                this.tabControl.SelectedTabPageIndex = 1;
            this.markerList = markerList;
            if (oldDsDominantList == null)
                oldDsDominantList = this.CreateMarkForDominantDataSet();
            this.dsDominantList = oldDsDominantList;
            this.AddComboboxItem(oldDsDominantList);
            if (oldDsDominantList != null)
            {
                this.gcDominantMassList.DataSource = this.dsDominantList.Tables[0];
                this.gcDominantCystList.DataSource = this.dsDominantList.Tables[1];
            }
            this.gcMassNo.OptionsColumn.AllowEdit = !isReadOnly;
            this.gcDelete.OptionsColumn.AllowEdit = !isReadOnly;
            this.gcDelete2.OptionsColumn.AllowEdit = !isReadOnly;
            this.gcMassNo2.OptionsColumn.AllowEdit = !isReadOnly;
            return this.ShowDialog();
        }

        /// <summary>
        /// Create MarkDataSet for Dominant
        /// </summary>
        /// <param name="markerList"></param>
        public DataSet CreateMarkForDominantDataSet()
        {
            DataSet ds = new DataSet();
            DataTable dtDl = ds.Tables.Add("DOMINANT_MASS_TALBE");
            dtDl.Columns.Add("MASS_NO", typeof(string));
            dtDl.Columns.Add("BREAST_VIEW", typeof(string));
            dtDl.Columns.Add("LOCATION", typeof(string));
            dtDl.Columns.Add("SIZE", typeof(string));
            dtDl.AcceptChanges();

            DataTable dtDl2 = ds.Tables.Add("DOMINANT_CYST_TALBE");
            dtDl2.Columns.Add("MASS_NO", typeof(string));
            dtDl2.Columns.Add("BREAST_VIEW", typeof(string));
            dtDl2.Columns.Add("LOCATION", typeof(string));
            dtDl2.Columns.Add("SIZE", typeof(string));
            dtDl2.AcceptChanges();
            //dtDl.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty);
            return ds;
        }
        /// <summary>
        /// Add item to combobox
        /// </summary>
        /// <param name="markerList"></param>
        private void AddComboboxItem()
        {
            if (markerList != null)
            {
                this.repCbMassNo.Items.Clear();
                this.repCombobox2.Items.Clear();
                foreach (MarkStruct ms in markerList)
                {
                    if (ms.IsUsMassDetail == "N")
                    {
                        this.repCbMassNo.Items.Add(ms.MassDetail.MASS_NO.ToString());
                        //this.repCombobox2.Items.Add(ms.MassDetail.MASS_NO.ToString());
                    }
                    else
                    {
                        //this.repCbMassNo.Items.Add(ms.MassUSDetail.MASS_NO.ToString());
                        this.repCombobox2.Items.Add(ms.MassUSDetail.MASS_NO.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Add item to combobox with old dominant list dataset
        /// </summary>
        /// <param name="oldDsDominantList"></param>
        private void AddComboboxItem(DataSet oldDsDominantList)
        {

            this.AddComboboxItem();
            this.removeComboboxItem(oldDsDominantList);
        }

        /// <summary>
        /// Romove Combobox Item by old dominant dataset
        /// </summary>
        /// <param name="oldDsDominantList"></param>
        private void removeComboboxItem(DataSet oldDsDominantList)
        {
            if (oldDsDominantList != null)
            {
                if (oldDsDominantList.Tables.Count > 0)
                {
                    foreach (DataRow dr in oldDsDominantList.Tables[0].Rows)
                    {
                        if (this.repCbMassNo.Items.Contains(dr["MASS_NO"].ToString()))
                            this.repCbMassNo.Items.Remove(dr["MASS_NO"].ToString());
                    }
                    foreach (DataRow dr in oldDsDominantList.Tables[1].Rows)
                    {
                        if (this.repCombobox2.Items.Contains(dr["MASS_NO"].ToString()))
                            this.repCombobox2.Items.Remove(dr["MASS_NO"].ToString());
                    }
                }
            }
        }

        private void removeRow(DataRow dataRow)
        {
            if (this.repCbMassNo.Items.Contains(dataRow["MASS_NO"].ToString()))
                this.repCbMassNo.Items.Remove(dataRow["MASS_NO"].ToString());
            if (this.repCombobox2.Items.Contains(dataRow["MASS_NO"].ToString()))
                this.repCombobox2.Items.Remove(dataRow["MASS_NO"].ToString());
        }

        /// <summary>
        /// This method use to get dataset
        /// </summary>
        /// <returns></returns>
        public DataSet GetDominantDataSet()
        {
            return this.dsDominantList;
        }
    }
}