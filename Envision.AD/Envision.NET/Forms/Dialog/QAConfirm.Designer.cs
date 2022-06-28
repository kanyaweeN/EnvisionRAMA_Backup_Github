namespace RIS.Forms.Technologist.Dialog
{
    partial class QAConfirm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConsumable = new System.Windows.Forms.TabPage();
            this.grdQA = new DevExpress.XtraGrid.GridControl();
            this.view1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.grdHistory = new DevExpress.XtraGrid.GridControl();
            this.viewHistory1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtNoOfImg = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rdoFail = new System.Windows.Forms.RadioButton();
            this.rdoPass = new System.Windows.Forms.RadioButton();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.viewHistoryDtl = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabConsumable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHistory1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoOfImg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHistoryDtl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tabControl1);
            this.panelControl1.Controls.Add(this.txtNoOfImg);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.txtComment);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.rdoFail);
            this.panelControl1.Controls.Add(this.rdoPass);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(505, 324);
            this.panelControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConsumable);
            this.tabControl1.Controls.Add(this.tabHistory);
            this.tabControl1.Location = new System.Drawing.Point(9, 111);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(491, 184);
            this.tabControl1.TabIndex = 9;
            // 
            // tabConsumable
            // 
            this.tabConsumable.Controls.Add(this.grdQA);
            this.tabConsumable.Location = new System.Drawing.Point(4, 22);
            this.tabConsumable.Name = "tabConsumable";
            this.tabConsumable.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsumable.Size = new System.Drawing.Size(483, 158);
            this.tabConsumable.TabIndex = 0;
            this.tabConsumable.Text = "Consumable";
            this.tabConsumable.UseVisualStyleBackColor = true;
            // 
            // grdQA
            // 
            this.grdQA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQA.EmbeddedNavigator.Name = "";
            this.grdQA.Location = new System.Drawing.Point(3, 3);
            this.grdQA.MainView = this.view1;
            this.grdQA.Name = "grdQA";
            this.grdQA.Size = new System.Drawing.Size(477, 152);
            this.grdQA.TabIndex = 6;
            this.grdQA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view1,
            this.gridView1});
            // 
            // view1
            // 
            this.view1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.view1.GridControl = this.grdQA;
            this.view1.Name = "view1";
            this.view1.OptionsView.ShowBands = false;
            this.view1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdQA;
            this.gridView1.Name = "gridView1";
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.grdHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 22);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(483, 158);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "History";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // grdHistory
            // 
            this.grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHistory.EmbeddedNavigator.Name = "";
            this.grdHistory.Location = new System.Drawing.Point(3, 3);
            this.grdHistory.MainView = this.viewHistory1;
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.Size = new System.Drawing.Size(477, 152);
            this.grdHistory.TabIndex = 0;
            this.grdHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewHistory1,
            this.gridView2,
            this.viewHistoryDtl});
            // 
            // viewHistory1
            // 
            this.viewHistory1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.viewHistory1.GridControl = this.grdHistory;
            this.viewHistory1.Name = "viewHistory1";
            this.viewHistory1.OptionsBehavior.Editable = false;
            this.viewHistory1.OptionsView.ShowBands = false;
            this.viewHistory1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Name = "gridBand2";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdHistory;
            this.gridView2.Name = "gridView2";
            // 
            // txtNoOfImg
            // 
            this.txtNoOfImg.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNoOfImg.Location = new System.Drawing.Point(317, 16);
            this.txtNoOfImg.Name = "txtNoOfImg";
            this.txtNoOfImg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtNoOfImg.Properties.IsFloatValue = false;
            this.txtNoOfImg.Properties.Mask.EditMask = "N00";
            this.txtNoOfImg.Properties.MaxValue = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.txtNoOfImg.Size = new System.Drawing.Size(74, 20);
            this.txtNoOfImg.TabIndex = 3;
            this.txtNoOfImg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoOfImg_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(246, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "No. Of Image";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 296);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "ตกลง";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(60, 40);
            this.txtComment.MaxLength = 250;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(440, 65);
            this.txtComment.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Comment";
            // 
            // rdoFail
            // 
            this.rdoFail.AutoSize = true;
            this.rdoFail.Location = new System.Drawing.Point(114, 17);
            this.rdoFail.Name = "rdoFail";
            this.rdoFail.Size = new System.Drawing.Size(41, 17);
            this.rdoFail.TabIndex = 1;
            this.rdoFail.Text = "Fail";
            this.rdoFail.UseVisualStyleBackColor = true;
            // 
            // rdoPass
            // 
            this.rdoPass.AutoSize = true;
            this.rdoPass.Checked = true;
            this.rdoPass.Location = new System.Drawing.Point(60, 17);
            this.rdoPass.Name = "rdoPass";
            this.rdoPass.Size = new System.Drawing.Size(48, 17);
            this.rdoPass.TabIndex = 0;
            this.rdoPass.TabStop = true;
            this.rdoPass.Text = "Pass";
            this.rdoPass.UseVisualStyleBackColor = true;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // viewHistoryDtl
            // 
            this.viewHistoryDtl.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3});
            this.viewHistoryDtl.GridControl = this.grdHistory;
            this.viewHistoryDtl.Name = "viewHistoryDtl";
            this.viewHistoryDtl.OptionsBehavior.Editable = false;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "gridBand3";
            this.gridBand3.Name = "gridBand3";
            // 
            // QAConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 324);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QAConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabConsumable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHistory1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoOfImg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHistoryDtl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RadioButton rdoFail;
        private System.Windows.Forms.RadioButton rdoPass;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.TextBox txtComment;
        private DevExpress.XtraEditors.SpinEdit txtNoOfImg;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grdQA;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConsumable;
        private System.Windows.Forms.TabPage tabHistory;
        private DevExpress.XtraGrid.GridControl grdHistory;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewHistory1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewHistoryDtl;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
    }
}