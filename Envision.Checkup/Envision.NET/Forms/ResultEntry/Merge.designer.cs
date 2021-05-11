namespace RIS.Forms.ResultEntry
{
    partial class Merge
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Merge));
            this.groupDesc = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdHis = new DevExpress.XtraGrid.GridControl();
            this.viewHis = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnMerge = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPriority = new DevExpress.XtraEditors.TextEdit();
            this.txtAccNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtStatus = new DevExpress.XtraEditors.TextEdit();
            this.txtExamUID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtExamName = new DevExpress.XtraEditors.TextEdit();
            this.imgWL = new System.Windows.Forms.ImageList(this.components);
            this.imgHIS = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupDesc)).BeginInit();
            this.groupDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriority.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupDesc
            // 
            this.groupDesc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupDesc.Controls.Add(this.groupControl2);
            this.groupDesc.Controls.Add(this.btnCancel);
            this.groupDesc.Controls.Add(this.labelControl8);
            this.groupDesc.Controls.Add(this.btnMerge);
            this.groupDesc.Controls.Add(this.labelControl4);
            this.groupDesc.Controls.Add(this.txtPriority);
            this.groupDesc.Controls.Add(this.txtAccNo);
            this.groupDesc.Controls.Add(this.labelControl9);
            this.groupDesc.Controls.Add(this.labelControl6);
            this.groupDesc.Controls.Add(this.txtStatus);
            this.groupDesc.Controls.Add(this.txtExamUID);
            this.groupDesc.Controls.Add(this.labelControl7);
            this.groupDesc.Controls.Add(this.txtExamName);
            this.groupDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDesc.Location = new System.Drawing.Point(0, 0);
            this.groupDesc.Name = "groupDesc";
            this.groupDesc.Size = new System.Drawing.Size(720, 459);
            this.groupDesc.TabIndex = 0;
            this.groupDesc.Text = "Destination";
            // 
            // groupControl2
            // 
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl2.Controls.Add(this.grdHis);
            this.groupControl2.Location = new System.Drawing.Point(5, 89);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(703, 326);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Source";
            // 
            // grdHis
            // 
            this.grdHis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdHis.EmbeddedNavigator.Name = "";
            this.grdHis.FormsUseDefaultLookAndFeel = false;
            this.grdHis.Location = new System.Drawing.Point(5, 23);
            this.grdHis.MainView = this.viewHis;
            this.grdHis.Name = "grdHis";
            this.grdHis.Size = new System.Drawing.Size(693, 298);
            this.grdHis.TabIndex = 17;
            this.grdHis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewHis,
            this.gridView2});
            // 
            // viewHis
            // 
            this.viewHis.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.viewHis.GridControl = this.grdHis;
            this.viewHis.Name = "viewHis";
            this.viewHis.OptionsBehavior.Editable = false;
            this.viewHis.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewHis.OptionsView.ShowAutoFilterRow = true;
            this.viewHis.OptionsView.ShowBands = false;
            this.viewHis.OptionsView.ShowGroupPanel = false;
            this.viewHis.DoubleClick += new System.EventHandler(this.viewHis_DoubleClick);
            this.viewHis.Click += new System.EventHandler(this.viewHis_Click);
            this.viewHis.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.viewHis_RowStyle);
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Name = "gridBand2";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdHis;
            this.gridView2.Name = "gridView2";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(613, 421);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(58, 37);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 13);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Status";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(512, 421);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(95, 23);
            this.btnMerge.TabIndex = 15;
            this.btnMerge.Text = "Merge";
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(418, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Accession No";
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(312, 34);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Properties.ReadOnly = true;
            this.txtPriority.Size = new System.Drawing.Size(100, 20);
            this.txtPriority.TabIndex = 10;
            // 
            // txtAccNo
            // 
            this.txtAccNo.Location = new System.Drawing.Point(497, 34);
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Properties.ReadOnly = true;
            this.txtAccNo.Size = new System.Drawing.Size(150, 20);
            this.txtAccNo.TabIndex = 11;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(264, 37);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(42, 13);
            this.labelControl9.TabIndex = 8;
            this.labelControl9.Text = "Priority";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(33, 60);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(62, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Exam Code";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(101, 34);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Properties.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(129, 20);
            this.txtStatus.TabIndex = 9;
            // 
            // txtExamUID
            // 
            this.txtExamUID.Location = new System.Drawing.Point(101, 56);
            this.txtExamUID.Name = "txtExamUID";
            this.txtExamUID.Properties.ReadOnly = true;
            this.txtExamUID.Size = new System.Drawing.Size(129, 20);
            this.txtExamUID.TabIndex = 12;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(240, 60);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(66, 13);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Exam Name";
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(312, 56);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Properties.ReadOnly = true;
            this.txtExamName.Size = new System.Drawing.Size(335, 20);
            this.txtExamName.TabIndex = 13;
            // 
            // imgWL
            // 
            this.imgWL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgWL.ImageStream")));
            this.imgWL.TransparentColor = System.Drawing.Color.Magenta;
            this.imgWL.Images.SetKeyName(0, "");
            this.imgWL.Images.SetKeyName(1, "");
            this.imgWL.Images.SetKeyName(2, "");
            this.imgWL.Images.SetKeyName(3, "");
            this.imgWL.Images.SetKeyName(4, "");
            this.imgWL.Images.SetKeyName(5, "");
            this.imgWL.Images.SetKeyName(6, "");
            this.imgWL.Images.SetKeyName(7, "");
            this.imgWL.Images.SetKeyName(8, "");
            // 
            // imgHIS
            // 
            this.imgHIS.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgHIS.ImageStream")));
            this.imgHIS.TransparentColor = System.Drawing.Color.Transparent;
            this.imgHIS.Images.SetKeyName(0, "synapse24.gif");
            this.imgHIS.Images.SetKeyName(1, "synapselogo.bmp");
            this.imgHIS.Images.SetKeyName(2, "synDownLoad.gif");
            this.imgHIS.Images.SetKeyName(3, "TitleArea_Left.gif");
            this.imgHIS.Images.SetKeyName(4, "order_16.png");
            // 
            // Merge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 459);
            this.Controls.Add(this.groupDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Merge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Merge";
            ((System.ComponentModel.ISupportInitialize)(this.groupDesc)).EndInit();
            this.groupDesc.ResumeLayout(false);
            this.groupDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriority.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupDesc;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnMerge;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPriority;
        private DevExpress.XtraEditors.TextEdit txtAccNo;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtStatus;
        private DevExpress.XtraEditors.TextEdit txtExamUID;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtExamName;
        private DevExpress.XtraGrid.GridControl grdHis;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewHis;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.ImageList imgWL;
        private System.Windows.Forms.ImageList imgHIS;
    }
}