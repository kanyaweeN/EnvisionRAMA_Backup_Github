namespace RIS.Forms.Schedule
{
    partial class frmScheduleConfrim
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdControl = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnInsurance = new DevExpress.XtraEditors.SimpleButton();
            this.txtInsurance = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnOrderDoc = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtOrderDoc = new DevExpress.XtraEditors.TextEdit();
            this.btnOrderDept = new DevExpress.XtraEditors.SimpleButton();
            this.txtOrderDept = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCopies = new DevExpress.XtraEditors.SpinEdit();
            this.btnSaveprint = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtEngName = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtThaiName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtHN = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCopies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThaiName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdControl);
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(639, 329);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdControl
            // 
            this.grdControl.EmbeddedNavigator.Name = "";
            this.grdControl.FormsUseDefaultLookAndFeel = false;
            this.grdControl.Location = new System.Drawing.Point(10, 224);
            this.grdControl.MainView = this.view;
            this.grdControl.Name = "grdControl";
            this.grdControl.Size = new System.Drawing.Size(620, 96);
            this.grdControl.TabIndex = 5;
            this.grdControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // view
            // 
            this.view.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.view.GridControl = this.grdControl;
            this.view.Name = "view";
            this.view.OptionsView.ColumnAutoWidth = true;
            this.view.OptionsView.ShowBands = false;
            this.view.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl1.Controls.Add(this.btnInsurance);
            this.panelControl1.Controls.Add(this.txtInsurance);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.btnOrderDoc);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.txtOrderDoc);
            this.panelControl1.Controls.Add(this.btnOrderDept);
            this.panelControl1.Controls.Add(this.txtOrderDept);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.txtCopies);
            this.panelControl1.Controls.Add(this.btnSaveprint);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.txtEngName);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.txtThaiName);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtHN);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(10, 28);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(620, 161);
            this.panelControl1.TabIndex = 4;
            // 
            // btnInsurance
            // 
            this.btnInsurance.Location = new System.Drawing.Point(253, 132);
            this.btnInsurance.Name = "btnInsurance";
            this.btnInsurance.Size = new System.Drawing.Size(30, 23);
            this.btnInsurance.TabIndex = 16;
            this.btnInsurance.Text = "...";
            this.btnInsurance.Click += new System.EventHandler(this.btnInsurance_Click);
            // 
            // txtInsurance
            // 
            this.txtInsurance.Enabled = false;
            this.txtInsurance.Location = new System.Drawing.Point(94, 135);
            this.txtInsurance.Name = "txtInsurance";
            this.txtInsurance.Properties.ReadOnly = true;
            this.txtInsurance.Size = new System.Drawing.Size(153, 20);
            this.txtInsurance.TabIndex = 15;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(6, 138);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(82, 13);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "Insurance Type :";
            // 
            // btnOrderDoc
            // 
            this.btnOrderDoc.Location = new System.Drawing.Point(253, 106);
            this.btnOrderDoc.Name = "btnOrderDoc";
            this.btnOrderDoc.Size = new System.Drawing.Size(30, 23);
            this.btnOrderDoc.TabIndex = 13;
            this.btnOrderDoc.Text = "...";
            this.btnOrderDoc.Click += new System.EventHandler(this.btnOrderDoc_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(29, 112);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 13);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Order Doc. :";
            // 
            // txtOrderDoc
            // 
            this.txtOrderDoc.Enabled = false;
            this.txtOrderDoc.Location = new System.Drawing.Point(95, 109);
            this.txtOrderDoc.Name = "txtOrderDoc";
            this.txtOrderDoc.Properties.ReadOnly = true;
            this.txtOrderDoc.Size = new System.Drawing.Size(152, 20);
            this.txtOrderDoc.TabIndex = 11;
            // 
            // btnOrderDept
            // 
            this.btnOrderDept.Location = new System.Drawing.Point(253, 80);
            this.btnOrderDept.Name = "btnOrderDept";
            this.btnOrderDept.Size = new System.Drawing.Size(30, 23);
            this.btnOrderDept.TabIndex = 10;
            this.btnOrderDept.Text = "...";
            this.btnOrderDept.Click += new System.EventHandler(this.btnOrderDept_Click);
            // 
            // txtOrderDept
            // 
            this.txtOrderDept.Enabled = false;
            this.txtOrderDept.Location = new System.Drawing.Point(95, 83);
            this.txtOrderDept.Name = "txtOrderDept";
            this.txtOrderDept.Properties.ReadOnly = true;
            this.txtOrderDept.Size = new System.Drawing.Size(152, 20);
            this.txtOrderDept.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(24, 86);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(65, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Order Dept. :";
            // 
            // txtCopies
            // 
            this.txtCopies.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCopies.Location = new System.Drawing.Point(568, 36);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtCopies.Properties.Appearance.Options.UseFont = true;
            this.txtCopies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCopies.Size = new System.Drawing.Size(37, 24);
            this.txtCopies.TabIndex = 7;
            // 
            // btnSaveprint
            // 
            this.btnSaveprint.Location = new System.Drawing.Point(429, 35);
            this.btnSaveprint.Name = "btnSaveprint";
            this.btnSaveprint.Size = new System.Drawing.Size(134, 27);
            this.btnSaveprint.TabIndex = 6;
            this.btnSaveprint.Text = "[F3] Save and Print";
            this.btnSaveprint.Click += new System.EventHandler(this.btnSaveprint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(429, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(177, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(94, 57);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(251, 20);
            this.txtEngName.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(429, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "[F2] Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtThaiName
            // 
            this.txtThaiName.Location = new System.Drawing.Point(94, 31);
            this.txtThaiName.Name = "txtThaiName";
            this.txtThaiName.Size = new System.Drawing.Size(251, 20);
            this.txtThaiName.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 61);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Eng Name :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(32, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Thai Name :";
            // 
            // txtHN
            // 
            this.txtHN.Location = new System.Drawing.Point(94, 5);
            this.txtHN.Name = "txtHN";
            this.txtHN.Size = new System.Drawing.Size(153, 20);
            this.txtHN.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(68, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "HN :";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(639, 329);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.ExpandButtonVisible = true;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(637, 196);
            this.layoutControlGroup2.Text = "DemoGraphic";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(631, 172);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 196);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(637, 131);
            this.layoutControlGroup3.Text = "       Exam";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdControl;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(631, 107);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // frmScheduleConfrim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(639, 329);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmScheduleConfrim";
            this.Text = "frmScheduleConfrim";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCopies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThaiName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdControl;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtHN;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtEngName;
        private DevExpress.XtraEditors.TextEdit txtThaiName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnSaveprint;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.SpinEdit txtCopies;
        private DevExpress.XtraEditors.SimpleButton btnOrderDoc;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtOrderDoc;
        private DevExpress.XtraEditors.SimpleButton btnOrderDept;
        private DevExpress.XtraEditors.TextEdit txtOrderDept;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnInsurance;
        private DevExpress.XtraEditors.TextEdit txtInsurance;
    }
}