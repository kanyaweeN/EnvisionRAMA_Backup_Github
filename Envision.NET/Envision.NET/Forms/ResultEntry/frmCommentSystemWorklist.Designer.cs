namespace Envision.NET.Forms.ResultEntry
{
    partial class frmCommentSystemWorklist
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtHN = new DevExpress.XtraEditors.ButtonEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtStudyDate = new DevExpress.XtraScheduler.DateNavigator();
            this.txtModality = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.gcCommentList = new DevExpress.XtraGrid.GridControl();
            this.txtPopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.orderSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderSummaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gvCommentList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtCommentList = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudyDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModality.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCommentList)).BeginInit();
            this.txtPopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCommentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommentList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.txtHN);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.txtStudyDate);
            this.layoutControl1.Controls.Add(this.txtModality);
            this.layoutControl1.Controls.Add(this.gcCommentList);
            this.layoutControl1.Controls.Add(this.txtCommentList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(826, 639);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(274, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(111, 200);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Remark : Empty HN  for all case searching.";
            // 
            // txtHN
            // 
            this.txtHN.Location = new System.Drawing.Point(76, 59);
            this.txtHN.Name = "txtHN";
            this.txtHN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)});
            this.txtHN.Size = new System.Drawing.Size(187, 21);
            this.txtHN.StyleController = this.layoutControl1;
            this.txtHN.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(274, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 22);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            // 
            // txtStudyDate
            // 
            this.txtStudyDate.DateTime = new System.DateTime(2014, 5, 14, 0, 0, 0, 0);
            this.txtStudyDate.Location = new System.Drawing.Point(76, 91);
            this.txtStudyDate.Name = "txtStudyDate";
            this.txtStudyDate.Size = new System.Drawing.Size(187, 170);
            this.txtStudyDate.TabIndex = 8;
            // 
            // txtModality
            // 
            this.txtModality.EditValue = "CTER, USER, CRER";
            this.txtModality.Location = new System.Drawing.Point(76, 28);
            this.txtModality.Name = "txtModality";
            this.txtModality.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtModality.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("CTER", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("USER", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("CRER", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Ultrasound")});
            this.txtModality.Size = new System.Drawing.Size(187, 20);
            this.txtModality.StyleController = this.layoutControl1;
            this.txtModality.TabIndex = 6;
            // 
            // gcCommentList
            // 
            this.gcCommentList.ContextMenuStrip = this.txtPopMenu;
            this.gcCommentList.Location = new System.Drawing.Point(7, 275);
            this.gcCommentList.MainView = this.gvCommentList;
            this.gcCommentList.Name = "gcCommentList";
            this.gcCommentList.Size = new System.Drawing.Size(381, 358);
            this.gcCommentList.TabIndex = 5;
            this.gcCommentList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCommentList});
            // 
            // txtPopMenu
            // 
            this.txtPopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderSummaryToolStripMenuItem,
            this.orderSummaryToolStripMenuItem1});
            this.txtPopMenu.Name = "txtPopMenu";
            this.txtPopMenu.Size = new System.Drawing.Size(150, 48);
            // 
            // orderSummaryToolStripMenuItem
            // 
            this.orderSummaryToolStripMenuItem.Name = "orderSummaryToolStripMenuItem";
            this.orderSummaryToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.orderSummaryToolStripMenuItem.Text = "Start Comment";
            this.orderSummaryToolStripMenuItem.Click += new System.EventHandler(this.orderSummaryToolStripMenuItem_Click);
            // 
            // orderSummaryToolStripMenuItem1
            // 
            this.orderSummaryToolStripMenuItem1.Name = "orderSummaryToolStripMenuItem1";
            this.orderSummaryToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.orderSummaryToolStripMenuItem1.Text = "Order Summary";
            this.orderSummaryToolStripMenuItem1.Click += new System.EventHandler(this.orderSummaryToolStripMenuItem1_Click);
            // 
            // gvCommentList
            // 
            this.gvCommentList.GridControl = this.gcCommentList;
            this.gvCommentList.Name = "gvCommentList";
            this.gvCommentList.OptionsView.ShowGroupPanel = false;
            this.gvCommentList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCommentList_FocusedRowChanged);
            // 
            // txtCommentList
            // 
            this.txtCommentList.Location = new System.Drawing.Point(408, 28);
            this.txtCommentList.Name = "txtCommentList";
            this.txtCommentList.Size = new System.Drawing.Size(409, 602);
            this.txtCommentList.StyleController = this.layoutControl1;
            this.txtCommentList.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.splitterItem1,
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(826, 639);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcCommentList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 268);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(392, 369);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(392, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(6, 637);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Comment List";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(398, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(426, 637);
            this.layoutControlGroup2.Text = "Comment List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCommentList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(420, 613);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Search Criteria";
            this.layoutControlGroup3.ExpandButtonVisible = true;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem7});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(392, 268);
            this.layoutControlGroup3.Text = "Search Criteria";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtModality;
            this.layoutControlItem3.CustomizationFormText = "Modality : ";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(264, 31);
            this.layoutControlItem3.Text = "Modality : ";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtStudyDate;
            this.layoutControlItem5.CustomizationFormText = "Study Date :";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 63);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(264, 181);
            this.layoutControlItem5.Text = "Study Date :";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSearch;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(264, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(122, 33);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtHN;
            this.layoutControlItem4.CustomizationFormText = "HN : ";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(264, 32);
            this.layoutControlItem4.Text = "HN : ";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.labelControl1;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(264, 33);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 211);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(21, 211);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(122, 211);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // frmCommentSystemWorklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 639);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmCommentSystemWorklist";
            this.Text = "frmCommentSystemWorklist";
            this.Load += new System.EventHandler(this.frmCommentSystemWorklist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudyDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModality.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCommentList)).EndInit();
            this.txtPopMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCommentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommentList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.MemoEdit txtCommentList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit txtModality;
        private DevExpress.XtraGrid.GridControl gcCommentList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCommentList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraScheduler.DateNavigator txtStudyDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.ButtonEdit txtHN;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.ContextMenuStrip txtPopMenu;
        private System.Windows.Forms.ToolStripMenuItem orderSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderSummaryToolStripMenuItem1;
    }
}