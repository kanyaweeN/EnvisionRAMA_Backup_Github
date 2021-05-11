using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Envision.NET.Mammogram.StructureReport
{
    public partial class BiradMarkListForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DataRow SelectionMark { get; set; }
        public BiradMarkListForm()
        {
            InitializeComponent();
            this.btnOK.ItemClick += new ItemClickEventHandler(btnOK_ItemClick);
            this.btnClose.ItemClick += new ItemClickEventHandler(btnClose_ItemClick);
            this.gMarkerListView.DoubleClick += new EventHandler(gMarkerListView_DoubleClick);
        }

        protected void gMarkerListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.gMarkerListView.FocusedRowHandle > -1)
            {
                this.SelectionMark = this.gMarkerListView.GetDataRow(this.gMarkerListView.FocusedRowHandle);
                this.DialogResult = DialogResult.OK;
            }
        }

        protected void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        protected void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gMarkerListView.FocusedRowHandle > -1)
            {
                this.SelectionMark = this.gMarkerListView.GetDataRow(this.gMarkerListView.FocusedRowHandle);
                this.DialogResult = DialogResult.OK;
            }
        }

        public DialogResult ShowDialog(DataSet dsMarker)
        {
            if (dsMarker != null)
            {
                if(dsMarker.Tables.Count > 0)
                    this.gMarkerListControl.DataSource = dsMarker.Tables[0];
            }
            return this.ShowDialog();
        }
    }
}