namespace Envision.NET.Forms.Orders
{
    partial class PatientRegistrationHISViewer
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
            this.gcHISData = new DevExpress.XtraGrid.GridControl();
            this.gvHISData = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.gcHISData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHISData)).BeginInit();
            this.SuspendLayout();
            // 
            // gcHISData
            // 
            this.gcHISData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHISData.Location = new System.Drawing.Point(0, 0);
            this.gcHISData.MainView = this.gvHISData;
            this.gcHISData.Name = "gcHISData";
            this.gcHISData.Size = new System.Drawing.Size(592, 373);
            this.gcHISData.TabIndex = 0;
            this.gcHISData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHISData});
            // 
            // gvHISData
            // 
            this.gvHISData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.gvHISData.GridControl = this.gcHISData;
            this.gvHISData.Name = "gvHISData";
            this.gvHISData.OptionsView.ShowAutoFilterRow = true;
            this.gvHISData.OptionsView.ShowBands = false;
            this.gvHISData.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // PatientRegistrationHISViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 373);
            this.Controls.Add(this.gcHISData);
            this.Name = "PatientRegistrationHISViewer";
            this.Text = "HIS HN Data Viewer";
            this.Load += new System.EventHandler(this.PatientRegistrationHISViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcHISData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHISData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcHISData;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gvHISData;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
    }
}