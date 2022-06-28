namespace Envision.NET.Forms.Dialog
{
    partial class frmNextAppointment
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
            this.gcNextAppt = new DevExpress.XtraGrid.GridControl();
            this.gvNextAppt = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.gcNextAppt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNextAppt)).BeginInit();
            this.SuspendLayout();
            // 
            // gcNextAppt
            // 
            this.gcNextAppt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNextAppt.Location = new System.Drawing.Point(0, 0);
            this.gcNextAppt.MainView = this.gvNextAppt;
            this.gcNextAppt.Name = "gcNextAppt";
            this.gcNextAppt.Size = new System.Drawing.Size(584, 433);
            this.gcNextAppt.TabIndex = 0;
            this.gcNextAppt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNextAppt});
            // 
            // gvNextAppt
            // 
            this.gvNextAppt.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.gvNextAppt.GridControl = this.gcNextAppt;
            this.gvNextAppt.Name = "gvNextAppt";
            this.gvNextAppt.OptionsView.ColumnAutoWidth = true;
            this.gvNextAppt.OptionsView.ShowAutoFilterRow = true;
            this.gvNextAppt.OptionsView.ShowBands = false;
            this.gvNextAppt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvNextAppt.OptionsView.ShowGroupPanel = false;
            this.gvNextAppt.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvNextAppt_RowCellClick);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // frmNextAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 433);
            this.Controls.Add(this.gcNextAppt);
            this.Name = "frmNextAppointment";
            this.Text = "frmNextAppointment";
            this.Load += new System.EventHandler(this.frmNextAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcNextAppt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNextAppt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcNextAppt;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gvNextAppt;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
    }
}