namespace Envision.NET.Forms.Comment
{
    partial class CommentDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentDialog));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSend = new DevExpress.XtraBars.BarButtonItem();
            this.btnReply = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveDraft = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.gSend = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gReply = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gDraft = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gCancel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdExam = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bteCommentTo = new DevExpress.XtraEditors.ButtonEdit();
            this.cbPriorityImage = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imgWL = new System.Windows.Forms.ImageList(this.components);
            this.mmComment = new System.Windows.Forms.RichTextBox();
            this.tbSubject = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btneee = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnSaveEdit = new DevExpress.XtraBars.BarButtonItem();
            this.gEdit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteCommentTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPriorityImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btneee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSend,
            this.btnReply,
            this.btnSaveDraft,
            this.btnCancel,
            this.btnSaveEdit});
            this.ribbon.LargeImages = this.imageCollection2;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(597, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnSend
            // 
            this.btnSend.Caption = "Send";
            this.btnSend.Id = 0;
            this.btnSend.LargeImageIndex = 13;
            this.btnSend.Name = "btnSend";
            // 
            // btnReply
            // 
            this.btnReply.Caption = "Reply";
            this.btnReply.Id = 1;
            this.btnReply.LargeImageIndex = 8;
            this.btnReply.Name = "btnReply";
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Caption = "Save Draft";
            this.btnSaveDraft.Id = 2;
            this.btnSaveDraft.LargeImageIndex = 14;
            this.btnSaveDraft.Name = "btnSaveDraft";
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Id = 3;
            this.btnCancel.LargeImageIndex = 3;
            this.btnCancel.Name = "btnCancel";
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "edit.png");
            this.imageCollection2.Images.SetKeyName(1, "favourite_48.png");
            this.imageCollection2.Images.SetKeyName(2, "trash_full.png");
            this.imageCollection2.Images.SetKeyName(3, "delete.png");
            this.imageCollection2.Images.SetKeyName(4, "icon_restore.png");
            this.imageCollection2.Images.SetKeyName(5, "left.png");
            this.imageCollection2.Images.SetKeyName(6, "cancel-icon.png");
            this.imageCollection2.Images.SetKeyName(7, "check mark.png");
            this.imageCollection2.Images.SetKeyName(8, "FaceSheet24.png");
            this.imageCollection2.Images.SetKeyName(9, "mail-delete-2.png");
            this.imageCollection2.Images.SetKeyName(10, "mail-mark-unread-new.png");
            this.imageCollection2.Images.SetKeyName(11, "mail-new.png");
            this.imageCollection2.Images.SetKeyName(12, "mail-read.png");
            this.imageCollection2.Images.SetKeyName(13, "mail-reply-sender-3.png");
            this.imageCollection2.Images.SetKeyName(14, "mail-send-2.png");
            this.imageCollection2.Images.SetKeyName(15, "Notes24.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.gSend,
            this.gReply,
            this.gDraft,
            this.gEdit,
            this.gCancel});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Comment";
            // 
            // gSend
            // 
            this.gSend.ItemLinks.Add(this.btnSend);
            this.gSend.Name = "gSend";
            this.gSend.ShowCaptionButton = false;
            // 
            // gReply
            // 
            this.gReply.ItemLinks.Add(this.btnReply);
            this.gReply.Name = "gReply";
            this.gReply.ShowCaptionButton = false;
            // 
            // gDraft
            // 
            this.gDraft.ItemLinks.Add(this.btnSaveDraft);
            this.gDraft.Name = "gDraft";
            this.gDraft.ShowCaptionButton = false;
            // 
            // gCancel
            // 
            this.gCancel.ItemLinks.Add(this.btnCancel);
            this.gCancel.Name = "gCancel";
            this.gCancel.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 447);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(597, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.layoutControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(597, 304);
            this.clientPanel.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.grdExam);
            this.layoutControl1.Controls.Add(this.bteCommentTo);
            this.layoutControl1.Controls.Add(this.cbPriorityImage);
            this.layoutControl1.Controls.Add(this.mmComment);
            this.layoutControl1.Controls.Add(this.tbSubject);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(597, 304);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdExam
            // 
            this.grdExam.Location = new System.Drawing.Point(58, 57);
            this.grdExam.MenuManager = this.ribbon;
            this.grdExam.Name = "grdExam";
            this.grdExam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdExam.Properties.NullText = "";
            this.grdExam.Properties.View = this.gridLookUpEdit1View;
            this.grdExam.Size = new System.Drawing.Size(533, 20);
            this.grdExam.StyleController = this.layoutControl1;
            this.grdExam.TabIndex = 19;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // bteCommentTo
            // 
            this.bteCommentTo.Location = new System.Drawing.Point(55, 29);
            this.bteCommentTo.MenuManager = this.ribbon;
            this.bteCommentTo.Name = "bteCommentTo";
            this.bteCommentTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteCommentTo.Size = new System.Drawing.Size(539, 20);
            this.bteCommentTo.StyleController = this.layoutControl1;
            this.bteCommentTo.TabIndex = 18;
            // 
            // cbPriorityImage
            // 
            this.cbPriorityImage.EditValue = "M";
            this.cbPriorityImage.Location = new System.Drawing.Point(497, 4);
            this.cbPriorityImage.MenuManager = this.ribbon;
            this.cbPriorityImage.Name = "cbPriorityImage";
            this.cbPriorityImage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPriorityImage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", "H", 8),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Medium", "M", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", "L", 6)});
            this.cbPriorityImage.Properties.SmallImages = this.imgWL;
            this.cbPriorityImage.Size = new System.Drawing.Size(97, 20);
            this.cbPriorityImage.StyleController = this.layoutControl1;
            this.cbPriorityImage.TabIndex = 17;
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
            // mmComment
            // 
            this.mmComment.Location = new System.Drawing.Point(4, 85);
            this.mmComment.Name = "mmComment";
            this.mmComment.Size = new System.Drawing.Size(590, 216);
            this.mmComment.TabIndex = 16;
            this.mmComment.Text = "";
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(55, 4);
            this.tbSubject.MenuManager = this.ribbon;
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(386, 20);
            this.tbSubject.StyleController = this.layoutControl1;
            this.tbSubject.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.btneee,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(597, 304);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tbSubject;
            this.layoutControlItem1.CustomizationFormText = "Subject : ";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(442, 25);
            this.layoutControlItem1.Text = "Subject : ";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.mmComment;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 81);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(595, 221);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cbPriorityImage;
            this.layoutControlItem5.CustomizationFormText = "Priority : ";
            this.layoutControlItem5.Location = new System.Drawing.Point(442, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Size = new System.Drawing.Size(153, 25);
            this.layoutControlItem5.Text = "Priority : ";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(46, 13);
            // 
            // btneee
            // 
            this.btneee.Control = this.bteCommentTo;
            this.btneee.CustomizationFormText = "To : ";
            this.btneee.Location = new System.Drawing.Point(0, 25);
            this.btneee.Name = "btneee";
            this.btneee.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.btneee.Size = new System.Drawing.Size(595, 25);
            this.btneee.Text = "To : ";
            this.btneee.TextLocation = DevExpress.Utils.Locations.Left;
            this.btneee.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdExam;
            this.layoutControlItem2.CustomizationFormText = "Exam :";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(595, 31);
            this.layoutControlItem2.Text = "Exam :";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(46, 13);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Caption = "Save Edit";
            this.btnSaveEdit.Id = 4;
            this.btnSaveEdit.LargeImageIndex = 15;
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveEdit_ItemClick);
            // 
            // gEdit
            // 
            this.gEdit.ItemLinks.Add(this.btnSaveEdit);
            this.gEdit.Name = "gEdit";
            this.gEdit.ShowCaptionButton = false;
            // 
            // CommentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 472);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "CommentDialog";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Comment Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteCommentTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPriorityImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btneee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gSend;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraBars.BarButtonItem btnSend;
        private DevExpress.XtraBars.BarButtonItem btnReply;
        private DevExpress.XtraBars.BarButtonItem btnSaveDraft;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gReply;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gDraft;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gCancel;
        private System.Windows.Forms.ImageList imgWL;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit tbSubject;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.RichTextBox mmComment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbPriorityImage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.ButtonEdit bteCommentTo;
        private DevExpress.XtraLayout.LayoutControlItem btneee;
        private DevExpress.XtraEditors.GridLookUpEdit grdExam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarButtonItem btnSaveEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup gEdit;
    }
}