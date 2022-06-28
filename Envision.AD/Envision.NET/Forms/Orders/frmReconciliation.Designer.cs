namespace Envision.NET.Forms.Orders
{
    partial class frmReconciliation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdDataJohndoe = new DevExpress.XtraGrid.GridControl();
            this.View1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataJohndoe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDataJohndoe
            // 
            this.grdDataJohndoe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDataJohndoe.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdDataJohndoe.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdDataJohndoe.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdDataJohndoe.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdDataJohndoe.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.grdDataJohndoe.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.grdDataJohndoe.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grdDataJohndoe.Location = new System.Drawing.Point(0, 0);
            this.grdDataJohndoe.MainView = this.View1;
            this.grdDataJohndoe.Name = "grdDataJohndoe";
            this.grdDataJohndoe.Size = new System.Drawing.Size(617, 514);
            this.grdDataJohndoe.TabIndex = 0;
            this.grdDataJohndoe.UseEmbeddedNavigator = true;
            this.grdDataJohndoe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View1});
            // 
            // View1
            // 
            this.View1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.View1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.View1.GridControl = this.grdDataJohndoe;
            this.View1.Name = "View1";
            this.View1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.View1.OptionsView.ColumnAutoWidth = true;
            this.View1.OptionsView.ShowAutoFilterRow = true;
            this.View1.OptionsView.ShowBands = false;
            this.View1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.View1.OptionsView.ShowGroupPanel = false;
            this.View1.DoubleClick += new System.EventHandler(this.View1_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // frmReconciliation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 514);
            this.Controls.Add(this.grdDataJohndoe);
            this.Name = "frmReconciliation";
            this.Text = "frmReconciliation";
            this.Load += new System.EventHandler(this.frmReconciliation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataJohndoe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdDataJohndoe;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView View1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
    }
}