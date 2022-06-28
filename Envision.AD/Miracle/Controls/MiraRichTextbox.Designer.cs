namespace Miracle.UserControls
{
    partial class MiraRichTextbox
    {
        public delegate void MiraSignatureSaveEventHandler(object sender, MiraSignatureSaveArgs e);
        public class MiraSignatureSaveArgs : System.EventArgs
        {

        }
        public delegate void MiraSignatureOpenEventHandler(object sender, MiraSignatureOpenArgs e);
        public class MiraSignatureOpenArgs : System.EventArgs
        {

        }
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiraRichTextbox));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.iFont = new DevExpress.XtraBars.BarButtonItem();
            this.iFontColor = new DevExpress.XtraBars.BarButtonItem();
            this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.sPosition = new DevExpress.XtraBars.BarStaticItem();
            this.sModifier = new DevExpress.XtraBars.BarStaticItem();
            this.sDocName = new DevExpress.XtraBars.BarStaticItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.iBold = new DevExpress.XtraBars.BarButtonItem();
            this.iItalic = new DevExpress.XtraBars.BarButtonItem();
            this.iUnderline = new DevExpress.XtraBars.BarButtonItem();
            this.iAlignLeft = new DevExpress.XtraBars.BarButtonItem();
            this.iCenter = new DevExpress.XtraBars.BarButtonItem();
            this.iAlignRight = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.iNew = new DevExpress.XtraBars.BarButtonItem();
            this.iSave = new DevExpress.XtraBars.BarButtonItem();
            this.iOpen = new DevExpress.XtraBars.BarButtonItem();
            this.iCut = new DevExpress.XtraBars.BarButtonItem();
            this.iCopy = new DevExpress.XtraBars.BarButtonItem();
            this.iPaste = new DevExpress.XtraBars.BarButtonItem();
            this.iUndo = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.rtPad = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3,
            this.bar4,
            this.bar2});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.iBold,
            this.iFont,
            this.iItalic,
            this.iUnderline,
            this.iAlignLeft,
            this.iCenter,
            this.iAlignRight,
            this.iFontColor,
            this.iNew,
            this.iSave,
            this.barButtonItem3,
            this.barButtonItem4,
            this.iCut,
            this.iCopy,
            this.iPaste,
            this.iUndo,
            this.sPosition,
            this.sModifier,
            this.sDocName,
            this.iOpen});
            this.barManager1.MaxItemId = 19;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 1;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.iFont, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.iFontColor)});
            this.bar1.Text = "Tools";
            // 
            // iFont
            // 
            this.iFont.Caption = "&Font...";
            this.iFont.Description = "Changes the font and character spacing formats of the selected text.";
            this.iFont.Hint = "Font Dialog";
            this.iFont.Id = 0;
            this.iFont.ImageIndex = 4;
            this.iFont.Name = "iFont";
            this.iFont.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iFont_ItemClick);
            // 
            // iFontColor
            // 
            this.iFontColor.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.iFontColor.Caption = "Font &Color";
            this.iFontColor.Description = "Formats the selected text with the color you click.";
            this.iFontColor.DropDownControl = this.popupControlContainer1;
            this.iFontColor.Hint = "Font Color";
            this.iFontColor.Id = 11;
            this.iFontColor.ImageIndex = 5;
            this.iFontColor.Name = "iFontColor";
            this.iFontColor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iFontColor_ItemClick);
            // 
            // popupControlContainer1
            // 
            this.popupControlContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer1.Location = new System.Drawing.Point(312, 121);
            this.popupControlContainer1.Manager = this.barManager1;
            this.popupControlContainer1.Name = "popupControlContainer1";
            this.popupControlContainer1.Size = new System.Drawing.Size(44, 40);
            this.popupControlContainer1.TabIndex = 6;
            this.popupControlContainer1.Visible = false;
            // 
            // bar3
            // 
            this.bar3.BarName = "StatusBar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.FloatLocation = new System.Drawing.Point(86, 499);
            this.bar3.FloatSize = new System.Drawing.Size(48, 26);
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.sPosition),
            new DevExpress.XtraBars.LinkPersistInfo(this.sModifier),
            new DevExpress.XtraBars.LinkPersistInfo(this.sDocName)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.DrawSizeGrip = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "StatusBar";
            // 
            // sPosition
            // 
            this.sPosition.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
            this.sPosition.Caption = "Position";
            this.sPosition.CategoryGuid = new System.Guid("77795bb7-9bc5-4dd2-a297-cc758682e23d");
            this.sPosition.Id = 32;
            this.sPosition.Name = "sPosition";
            this.sPosition.RightIndent = 2;
            this.sPosition.TextAlignment = System.Drawing.StringAlignment.Center;
            this.sPosition.Width = 145;
            // 
            // sModifier
            // 
            this.sModifier.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
            this.sModifier.Caption = "Modifier";
            this.sModifier.CategoryGuid = new System.Guid("77795bb7-9bc5-4dd2-a297-cc758682e23d");
            this.sModifier.Id = 33;
            this.sModifier.Name = "sModifier";
            this.sModifier.RightIndent = 2;
            this.sModifier.TextAlignment = System.Drawing.StringAlignment.Center;
            this.sModifier.Width = 60;
            // 
            // sDocName
            // 
            this.sDocName.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.sDocName.Caption = "Name";
            this.sDocName.CategoryGuid = new System.Guid("77795bb7-9bc5-4dd2-a297-cc758682e23d");
            this.sDocName.Id = 34;
            this.sDocName.Name = "sDocName";
            this.sDocName.TextAlignment = System.Drawing.StringAlignment.Near;
            this.sDocName.Width = 245;
            // 
            // bar4
            // 
            this.bar4.BarName = "Format";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 1;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iBold, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iItalic),
            new DevExpress.XtraBars.LinkPersistInfo(this.iUnderline),
            new DevExpress.XtraBars.LinkPersistInfo(this.iAlignLeft, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iCenter),
            new DevExpress.XtraBars.LinkPersistInfo(this.iAlignRight)});
            this.bar4.Text = "Format";
            // 
            // iBold
            // 
            this.iBold.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iBold.Caption = "&Bold";
            this.iBold.Description = "Makes selected text and numbers bold. If the selection is already bold, clicking " +
                "button removes bold formatting.";
            this.iBold.Hint = "Bold";
            this.iBold.Id = 2;
            this.iBold.ImageIndex = 15;
            this.iBold.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B));
            this.iBold.Name = "iBold";
            this.iBold.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iBold_ItemClick);
            // 
            // iItalic
            // 
            this.iItalic.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iItalic.Caption = "&Italic";
            this.iItalic.Description = "Makes selected text and numbers italic. If the selection is already italic, click" +
                "ing button removes italic formatting.";
            this.iItalic.Hint = "Italic";
            this.iItalic.Id = 1;
            this.iItalic.ImageIndex = 16;
            this.iItalic.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.iItalic.Name = "iItalic";
            this.iItalic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iItalic_ItemClick);
            // 
            // iUnderline
            // 
            this.iUnderline.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iUnderline.Caption = "&Underline";
            this.iUnderline.Description = "Underlines selected text and numbers. If the selection is already underlined, cli" +
                "cking button removes underlining.";
            this.iUnderline.Hint = "Underline";
            this.iUnderline.Id = 3;
            this.iUnderline.ImageIndex = 17;
            this.iUnderline.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U));
            this.iUnderline.Name = "iUnderline";
            this.iUnderline.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iUnderline_ItemClick);
            // 
            // iAlignLeft
            // 
            this.iAlignLeft.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iAlignLeft.Caption = "Align &Left";
            this.iAlignLeft.Description = "Aligns the selected text to the left.";
            this.iAlignLeft.GroupIndex = 1;
            this.iAlignLeft.Hint = "Align Left";
            this.iAlignLeft.Id = 4;
            this.iAlignLeft.ImageIndex = 18;
            this.iAlignLeft.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L));
            this.iAlignLeft.Name = "iAlignLeft";
            this.iAlignLeft.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iAlignLeft_ItemClick);
            // 
            // iCenter
            // 
            this.iCenter.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iCenter.Caption = "&Center";
            this.iCenter.Description = "Centers the selected text.";
            this.iCenter.GroupIndex = 1;
            this.iCenter.Hint = "Center";
            this.iCenter.Id = 5;
            this.iCenter.ImageIndex = 19;
            this.iCenter.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.iCenter.Name = "iCenter";
            this.iCenter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCenter_ItemClick);
            // 
            // iAlignRight
            // 
            this.iAlignRight.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iAlignRight.Caption = "Align &Right";
            this.iAlignRight.Description = "Aligns the selected text to the right.";
            this.iAlignRight.GroupIndex = 1;
            this.iAlignRight.Hint = "Align Right";
            this.iAlignRight.Id = 6;
            this.iAlignRight.ImageIndex = 20;
            this.iAlignRight.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.iAlignRight.Name = "iAlignRight";
            this.iAlignRight.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iAlignRight_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "MainMenu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iNew, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.iOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.iCut, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.iPaste),
            new DevExpress.XtraBars.LinkPersistInfo(this.iUndo, true)});
            this.bar2.OptionsBar.AllowRename = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "MainMenu";
            // 
            // iNew
            // 
            this.iNew.Caption = "&New";
            this.iNew.Description = "Creates a new, blank file.";
            this.iNew.Hint = "New";
            this.iNew.Id = 13;
            this.iNew.ImageIndex = 6;
            this.iNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.iNew.Name = "iNew";
            this.iNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iNew_ItemClick);
            // 
            // iSave
            // 
            this.iSave.Caption = "&Save";
            this.iSave.Description = "Saves the active document with its current file name.";
            this.iSave.Hint = "Save";
            this.iSave.Id = 14;
            this.iSave.ImageIndex = 10;
            this.iSave.Name = "iSave";
            this.iSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSave_ItemClick);
            // 
            // iOpen
            // 
            this.iOpen.Caption = "&Open";
            this.iOpen.Description = "Opens  the active document with its current file name.";
            this.iOpen.Hint = "Open";
            this.iOpen.Id = 18;
            this.iOpen.ImageIndex = 7;
            this.iOpen.Name = "iOpen";
            this.iOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iOpen_ItemClick);
            // 
            // iCut
            // 
            this.iCut.Caption = "Cu&t";
            this.iCut.Description = "Removes the selection from the active document and places it on the Clipboard.";
            this.iCut.Hint = "Cut";
            this.iCut.Id = 98;
            this.iCut.ImageIndex = 2;
            this.iCut.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X));
            this.iCut.Name = "iCut";
            this.iCut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCut_ItemClick);
            // 
            // iCopy
            // 
            this.iCopy.Caption = "&Copy";
            this.iCopy.Description = "Copies the selection to the Clipboard.";
            this.iCopy.Hint = "Copy";
            this.iCopy.Id = 97;
            this.iCopy.ImageIndex = 1;
            this.iCopy.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C));
            this.iCopy.Name = "iCopy";
            this.iCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCopy_ItemClick);
            // 
            // iPaste
            // 
            this.iPaste.Caption = "&Paste";
            this.iPaste.Description = "Inserts the contents of the Clipboard at the insertion point, and replaces any se" +
                "lection. This command is available only if you have cut or copied a text.";
            this.iPaste.Hint = "Paste";
            this.iPaste.Id = 99;
            this.iPaste.ImageIndex = 8;
            this.iPaste.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V));
            this.iPaste.Name = "iPaste";
            this.iPaste.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iPaste_ItemClick);
            // 
            // iUndo
            // 
            this.iUndo.Caption = "&Undo";
            this.iUndo.Description = "Reverses the last command or deletes the last entry you typed.";
            this.iUndo.Hint = "Undo";
            this.iUndo.Id = 18;
            this.iUndo.ImageIndex = 11;
            this.iUndo.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z));
            this.iUndo.Name = "iUndo";
            this.iUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iUndo_ItemClick);
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "Skin";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            this.imageList1.Images.SetKeyName(24, "");
            this.imageList1.Images.SetKeyName(25, "");
            this.imageList1.Images.SetKeyName(26, "");
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 15;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 16;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            this.imageList2.Images.SetKeyName(14, "");
            this.imageList2.Images.SetKeyName(15, "");
            this.imageList2.Images.SetKeyName(16, "");
            this.imageList2.Images.SetKeyName(17, "");
            this.imageList2.Images.SetKeyName(18, "");
            this.imageList2.Images.SetKeyName(19, "");
            this.imageList2.Images.SetKeyName(20, "");
            this.imageList2.Images.SetKeyName(21, "");
            this.imageList2.Images.SetKeyName(22, "");
            this.imageList2.Images.SetKeyName(23, "");
            this.imageList2.Images.SetKeyName(24, "");
            this.imageList2.Images.SetKeyName(25, "");
            this.imageList2.Images.SetKeyName(26, "");
            // 
            // rtPad
            // 
            this.rtPad.AcceptsTab = true;
            this.rtPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtPad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtPad.Location = new System.Drawing.Point(0, 53);
            this.rtPad.Name = "rtPad";
            this.rtPad.Size = new System.Drawing.Size(547, 215);
            this.rtPad.TabIndex = 5;
            this.rtPad.Text = "";
            this.rtPad.SelectionChanged += new System.EventHandler(this.rtPad_SelectionChanged);
            // 
            // MiraRichTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupControlContainer1);
            this.Controls.Add(this.rtPad);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MiraRichTextbox";
            this.Size = new System.Drawing.Size(547, 291);
            this.Load += new System.EventHandler(this.MiraRichTextbox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem iFont;
        private DevExpress.XtraBars.Bar bar4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private DevExpress.XtraBars.BarButtonItem iItalic;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarButtonItem iBold;
        private DevExpress.XtraBars.BarButtonItem iUnderline;
        private DevExpress.XtraBars.BarButtonItem iAlignLeft;
        private DevExpress.XtraBars.BarButtonItem iCenter;
        private DevExpress.XtraBars.BarButtonItem iAlignRight;
        private System.Windows.Forms.RichTextBox rtPad;
        private DevExpress.XtraBars.BarButtonItem iFontColor;      
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private DevExpress.XtraBars.BarButtonItem iNew;
        private DevExpress.XtraBars.BarButtonItem iSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem iPaste;
        private DevExpress.XtraBars.BarButtonItem iCut;
        private DevExpress.XtraBars.BarButtonItem iCopy;
        private DevExpress.XtraBars.BarButtonItem iUndo;
        private DevExpress.XtraBars.BarStaticItem sDocName;
        private DevExpress.XtraBars.BarStaticItem sModifier;
        private DevExpress.XtraBars.BarStaticItem sPosition;
        private DevExpress.XtraBars.BarButtonItem iOpen;
    }
}
