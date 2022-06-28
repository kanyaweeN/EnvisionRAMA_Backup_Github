namespace Envision.NET.Forms.InternalMessage
{
    partial class frmSend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSend));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barSend = new DevExpress.XtraBars.BarButtonItem();
            this.barSaveDraft = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnTo = new DevExpress.XtraEditors.SimpleButton();
            this.btnCC = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSubject = new DevExpress.XtraEditors.TextEdit();
            this.txtBody = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkForced = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grdLookupPriority = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkCCAll = new DevExpress.XtraEditors.CheckEdit();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBody.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkForced.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookupPriority.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCCAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbonControl1.Images = this.imageCollection1;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSend,
            this.barSaveDraft});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.Size = new System.Drawing.Size(627, 148);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "mail-reply-sender-3.png");
            this.imageCollection1.Images.SetKeyName(1, "mail-send-2.png");
            // 
            // barSend
            // 
            this.barSend.Caption = "Send";
            this.barSend.Id = 0;
            this.barSend.LargeImageIndex = 0;
            this.barSend.Name = "barSend";
            this.barSend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSend_ItemClick);
            // 
            // barSaveDraft
            // 
            this.barSaveDraft.Caption = "Save Draft";
            this.barSaveDraft.Id = 1;
            this.barSaveDraft.LargeImageIndex = 1;
            this.barSaveDraft.Name = "barSaveDraft";
            this.barSaveDraft.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSaveDraft_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Message";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barSend);
            this.ribbonPageGroup1.ItemLinks.Add(this.barSaveDraft);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // btnTo
            // 
            this.btnTo.Location = new System.Drawing.Point(5, 10);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(95, 23);
            this.btnTo.TabIndex = 18;
            this.btnTo.Text = "To...";
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // btnCC
            // 
            this.btnCC.Location = new System.Drawing.Point(5, 35);
            this.btnCC.Name = "btnCC";
            this.btnCC.Size = new System.Drawing.Size(51, 23);
            this.btnCC.TabIndex = 3;
            this.btnCC.Text = "CC...";
            this.btnCC.Click += new System.EventHandler(this.btnCC_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(57, 127);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Subject :";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(106, 124);
            this.txtSubject.MenuManager = this.ribbonControl1;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(503, 20);
            this.txtSubject.TabIndex = 6;
            this.txtSubject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubject_KeyDown);
            // 
            // txtBody
            // 
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.Location = new System.Drawing.Point(2, 2);
            this.txtBody.MenuManager = this.ribbonControl1;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(622, 226);
            this.txtBody.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(300, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Priority :";
            // 
            // chkForced
            // 
            this.chkForced.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chkForced.Location = new System.Drawing.Point(480, 14);
            this.chkForced.MenuManager = this.ribbonControl1;
            this.chkForced.Name = "chkForced";
            this.chkForced.Properties.Caption = "Forced";
            this.chkForced.Size = new System.Drawing.Size(75, 18);
            this.chkForced.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.grdLookupPriority);
            this.panelControl1.Controls.Add(this.chkCCAll);
            this.panelControl1.Controls.Add(this.txtCC);
            this.panelControl1.Controls.Add(this.txtTo);
            this.panelControl1.Controls.Add(this.btnTo);
            this.panelControl1.Controls.Add(this.chkForced);
            this.panelControl1.Controls.Add(this.btnCC);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtSubject);
            this.panelControl1.Location = new System.Drawing.Point(1, 146);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(626, 151);
            this.panelControl1.TabIndex = 0;
            // 
            // grdLookupPriority
            // 
            this.grdLookupPriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdLookupPriority.Location = new System.Drawing.Point(347, 13);
            this.grdLookupPriority.MenuManager = this.ribbonControl1;
            this.grdLookupPriority.Name = "grdLookupPriority";
            this.grdLookupPriority.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookupPriority.Properties.View = this.gridLookUpEdit1View;
            this.grdLookupPriority.Size = new System.Drawing.Size(127, 20);
            this.grdLookupPriority.TabIndex = 1;
            this.grdLookupPriority.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookupPriority_KeyDown);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // chkCCAll
            // 
            this.chkCCAll.Location = new System.Drawing.Point(60, 39);
            this.chkCCAll.MenuManager = this.ribbonControl1;
            this.chkCCAll.Name = "chkCCAll";
            this.chkCCAll.Properties.Caption = "All";
            this.chkCCAll.Size = new System.Drawing.Size(40, 18);
            this.chkCCAll.TabIndex = 4;
            this.chkCCAll.CheckedChanged += new System.EventHandler(this.chkCCAll_CheckedChanged);
            // 
            // txtCC
            // 
            this.txtCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCC.Location = new System.Drawing.Point(106, 35);
            this.txtCC.Multiline = true;
            this.txtCC.Name = "txtCC";
            this.txtCC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCC.Size = new System.Drawing.Size(503, 86);
            this.txtCC.TabIndex = 5;
            this.txtCC.DoubleClick += new System.EventHandler(this.txtCC_DoubleClick);
            this.txtCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCC_KeyPress);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(106, 12);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(188, 21);
            this.txtTo.TabIndex = 0;
            this.txtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTo_KeyDown_1);
            this.txtTo.Validating += new System.ComponentModel.CancelEventHandler(this.txtTo_Validating);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.txtBody);
            this.panelControl2.Location = new System.Drawing.Point(1, 299);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(626, 230);
            this.panelControl2.TabIndex = 7;
            // 
            // frmSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 530);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmSend";
            this.Ribbon = this.ribbonControl1;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compose News";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBody.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkForced.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookupPriority.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCCAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barSend;
        private DevExpress.XtraBars.BarButtonItem barSaveDraft;
        private DevExpress.XtraEditors.SimpleButton btnTo;
        private DevExpress.XtraEditors.SimpleButton btnCC;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSubject;
        private DevExpress.XtraEditors.MemoEdit txtBody;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkForced;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtCC;
        private DevExpress.XtraEditors.CheckEdit chkCCAll;
        private DevExpress.XtraEditors.GridLookUpEdit grdLookupPriority;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}