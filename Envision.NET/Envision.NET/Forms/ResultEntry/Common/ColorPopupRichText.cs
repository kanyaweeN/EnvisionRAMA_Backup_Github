using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraTab;
using DevExpress.XtraBars;

namespace Envision.NET.Forms.ResultEntry.Common
{
    public class ColorPopupRichText
    {
        private XtraTabControl tabControl;
        private Color fResultColor;
        private BarItem itemFontColor;
        private PopupControlContainer container;
        private RichTextBox rtPad;
        private bool isBackground;

        public ColorPopupRichText(PopupControlContainer container, BarItem item, RichTextBox rtPad)
        {
            this.rtPad = rtPad;
            this.container = container;
            this.itemFontColor = item;
            this.fResultColor = Color.Empty;
            this.tabControl = createTabControl();
            this.tabControl.TabStop = false;
            this.tabControl.TabPages.AddRange(new XtraTabPage[] { new XtraTabPage(), new XtraTabPage(), new XtraTabPage() });
            for (int i = 0; i < tabControl.TabPages.Count; i++) setTabPageProperties(i);
            tabControl.Dock = DockStyle.Fill;
            this.container.Controls.AddRange(new System.Windows.Forms.Control[] { tabControl });
            this.container.Size = CalcFormSize();
            onEnterColor();
        }
        public ColorPopupRichText(PopupControlContainer container, BarItem item, RichTextBox rtPad, bool background)
        {
            this.rtPad = rtPad;
            this.container = container;
            this.itemFontColor = item;
            this.fResultColor = Color.Empty;
            this.tabControl = createTabControl();
            this.tabControl.TabStop = false;
            this.tabControl.TabPages.AddRange(new XtraTabPage[] { new XtraTabPage(), new XtraTabPage(), new XtraTabPage() });
            for (int i = 0; i < tabControl.TabPages.Count; i++) setTabPageProperties(i);
            tabControl.Dock = DockStyle.Fill;
            this.container.Controls.AddRange(new System.Windows.Forms.Control[] { tabControl });
            this.container.Size = CalcFormSize();
            isBackground = background;
            onEnterColor();
        }

        private XtraTabControl createTabControl()
        {
            return new XtraTabControl();
        }
        private ColorListBox createColorListBox()
        {
            return new ColorListBox();
        }
        private void setTabPageProperties(int pageIndex)
        {
            XtraTabPage tabPage = this.tabControl.TabPages[pageIndex];
            ColorListBox colorBox = null;
            BaseControl control = null;
            switch (pageIndex)
            {
                case 0:
                    tabPage.Text = Localizer.Active.GetLocalizedString(StringId.ColorTabCustom);
                    control = new ColorCellsControl(null);
                    DevExpress.XtraEditors.Repository.RepositoryItemColorEdit rItem = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
                    rItem.ShowColorDialog = false;
                    (control as ColorCellsControl).Properties = rItem;
                    (control as ColorCellsControl).EnterColor += new EnterColorEventHandler(onEnterColor);
                    control.Size = ColorCellsControlViewInfo.BestSize;
                    break;
                case 1:
                    tabPage.Text = Localizer.Active.GetLocalizedString(StringId.ColorTabWeb);
                    colorBox = createColorListBox();
                    colorBox.Items.AddRange(ColorListBoxViewInfo.WebColors);
                    colorBox.EnterColor += new EnterColorEventHandler(onEnterColor);
                    control = colorBox;
                    break;
                case 2:
                    tabPage.Text = Localizer.Active.GetLocalizedString(StringId.ColorTabSystem);
                    colorBox = createColorListBox();
                    colorBox.Items.AddRange(ColorListBoxViewInfo.SystemColors);
                    colorBox.EnterColor += new EnterColorEventHandler(onEnterColor);
                    control = colorBox;
                    break;
            }
            control.Dock = DockStyle.Fill;
            control.BorderStyle = BorderStyles.NoBorder;
            control.LookAndFeel.ParentLookAndFeel = itemFontColor.Manager.GetController().LookAndFeel;
            tabPage.Controls.Add(control);
        }
        private void onEnterColor()
        {
            if (isBackground)
                fResultColor = rtPad.SelectionBackColor;
            else
                fResultColor = rtPad.SelectionColor;
            onEnterColor(fResultColor);
        }
        private void onEnterColor(Color clr)
        {

            container.HidePopup();
            if (isBackground)
                rtPad.SelectionBackColor = clr;
            else
                rtPad.SelectionColor = clr;
            int imIndex = itemFontColor.ImageIndex;

            //DevExpress.Utils.ImageCollection iml = itemFontColor.Images as DevExpress.Utils.ImageCollection;
            //Bitmap im = (Bitmap)iml.Images[imIndex];

            //Graphics g = Graphics.FromImage(im);
            //Rectangle r = new Rectangle(7, 7, 8, 8);
            //g.FillRectangle(new SolidBrush(clr), r);
            //if (imIndex == iml.Images.Count - 1)
            //{
            //    iml.Images.RemoveAt(imIndex);
            //}
            //g.Dispose();
            //iml.Images.Add(im);
            //itemFontColor.ImageIndex = iml.Images.Count - 1;

        }
        private void onEnterColor(object sender, EnterColorEventArgs e)
        {
            fResultColor = e.Color;
            onEnterColor(e.Color);
        }

        private ColorCellsControl cellsControl
        {
            get { return ((ColorCellsControl)tabControl.TabPages[0].Controls[0]); }
        }
        private string customColorsName
        {
            get { return "CustomColors"; }
        }

        public Color ResultColor
        {
            get { return fResultColor; }
        }
        public Size CalcFormSize()
        {
            Size size = ColorCellsControlViewInfo.BestSize;
            size.Height = 113;
            return tabControl.CalcSizeByPageClient(size);
        }
    }
}
