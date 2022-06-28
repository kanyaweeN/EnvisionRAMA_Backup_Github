using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics;
using Net.Sgoliver.NRtfTree.Core;
using Net.Sgoliver.NRtfTree.Util;
using Pruebas;

namespace Miracle.UserControls
{
    public partial class MiraRichTextbox : UserControl
    {
        private bool modified;
        private bool open;
        private const string docNameDefault = "document1.rtf";
        private string docName;
        private Cursor currentCursor;
        private ColorPopup cp;
        //string skinMask = "Skin: ";
        //bool skinProcessing = false;
        private   string _RTFText;

        public event MiraSignatureSaveEventHandler EventSave;
        public event MiraSignatureOpenEventHandler EventOpen;
        public string PlainText
        {
            get 
            { 
                return rtPad.Text; 
            }
            set
            {
                rtPad.Text = value;
            }
        }
        public string RTFText
        {
            set 
            {
                _RTFText = value;
                rtPad.Rtf = _RTFText;
            }
            get
            {
                _RTFText = rtPad.Rtf;
                return _RTFText;
            }
        }
        public MiraRichTextbox()
        {
            InitializeComponent();
            CreateColorPopup(popupControlContainer1);
        }
        public string GetHtmlText()
        {
            string RTFReturn;
            try
            {
                TraductorRtf t = new TraductorRtf(this.RTFText);
                RTFReturn = t.traducir();
                return RTFReturn;
            }
            catch (Exception ex) { return "Error"; }
            //textBox2.Text = t.traducir();
        }
        public bool visibleNew
        {
            get
            {
                if (this.iNew.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
                    return true;
                else
                    return false;
            }
            set 
            {
                if (value == true)
                    this.iNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                else
                    this.iNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        public bool visibleSave
        {
            get
            {
                if (this.iSave.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == true)
                    this.iSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                else
                    this.iSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        public bool visibleOpen
        {
            get
            {
                if (this.iOpen.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == true)
                    this.iOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                else
                    this.iOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        protected Font SelectFont
        {
            get
            {
                if (rtPad.SelectionFont != null)
                    return rtPad.SelectionFont;
                return rtPad.Font;
            }
        }
        protected void rtPadClear()
        {
            RefreshForm(true);
            rtPad.SelectionBullet = false;
            rtPad.SelectionProtected = false;
            rtPad.Clear();
            rtPad.ClearUndo();
            iUndo.Enabled = false;
            rtPad.Focus();
            rtPad_SelectionChanged(null, null);
            RefreshForm(false);
        }
    

        protected void RefreshForm(bool b)
        {
            if (b)
            {
                currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                Refresh();
            }
            else
            {
                Cursor.Current = currentCursor;
            }
        }
        private void CreateColorPopup(DevExpress.XtraBars.PopupControlContainer container)
        {
            cp = new ColorPopup(container, iFontColor, rtPad);
        }
        private FontStyle rtPadFontStyle()
        {
            FontStyle fs = new FontStyle();
            if (iBold.Down)
                fs |= FontStyle.Bold;
            if (iItalic.Down)
                fs |= FontStyle.Italic;
            if (iUnderline.Down)
                fs |= FontStyle.Underline;
            return fs;
        }
        protected string DocName
        {
            get { return docName; }
            set
            {
                if (value != docName)
                {
                    docName = value;
                    if (Open)
                        sDocName.Caption = docName;
                    else
                        sDocName.Caption = "";
                }
            }
        }
        protected bool Open
        {
            get { return open; }
            set
            {
                if (value != open)
                {
                    open = value;
                    InitOpen();
                    rtPad.HideSelection = !open;
                }
            }
        }

        protected bool Modified
        {
            get { return modified; }
            set
            {
                if (value != modified)
                {
                    modified = value;
                    iSave.Enabled = modified;
                    if (modified)
                        sModifier.Caption = "Modified";
                    else
                    {
                        sModifier.Caption = " ";
                        iUndo.Enabled = false;
                    }
                }
            }
        }
        protected void InitOpen()
        {
           // mEdit.Enabled = mFormat.Enabled = iSaveAs.Enabled = iClose.Enabled = iPrint.Enabled = Open;
           // BarManagerCategory cat = barManager1.Categories["Edit"];
            //foreach (BarItem item in barManager1.Items)
            //{
            //    if (item.Category == cat)
            //        item.Enabled = Open;
            //}
            //cat = barManager1.Categories["Format"];
            //foreach (BarItem item in barManager1.Items)
            //{
            //    if (item.Category == cat)
            //        item.Enabled = Open;
            //}
            //iEdit.Enabled = rtPad.Enabled = Open;
            //InitPaste();
        }

        protected void InitFormat()
        {
            iBold.Down = SelectFont.Bold;
            iItalic.Down = SelectFont.Italic;
            iUnderline.Down = SelectFont.Underline;
           
            switch (rtPad.SelectionAlignment)
            {
                case HorizontalAlignment.Left:
                    iAlignLeft.Down = true;
                    break;
                case HorizontalAlignment.Center:
                    iCenter.Down = true;
                    break;
                case HorizontalAlignment.Right:
                    iAlignRight.Down = true;
                    break;
            }
        }

        protected void InitPaste()
        {
            iPaste.Enabled = rtPad.CanPaste(DataFormats.GetFormat(0)) && Open;
        }
        protected bool SaveQuestion()
        {
            if (Modified)
            {
                switch (DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to save the changes you made to " + DocName + "?", "SimplePad Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.Yes:
                        iSaveAs_ItemClick(null, null);
                        break;
                }
            }
            return true;
        }
        private void iSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Files (*.rtf)|*.rtf";
            dlg.Title = "Save As";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RefreshForm(true);
                rtPad.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText);
                DocName = dlg.FileName;
                Modified = false;
                RefreshForm(false);
            }
        }
        protected void InitEdit(bool b)
        {
            iCut.Enabled = b;
            iCopy.Enabled = b;

            iUndo.Enabled = rtPad.CanUndo;

        }
        //private void ChangedController(object sender, EventArgs e)
        //{
        //   // if (skinProcessing) return;
        //    string paintStyleName = barManager1.GetController().PaintStyleName;
        //    if ("Office2000OfficeXPWindowsXP".IndexOf(paintStyleName) >= 0)
        //        barManager1.Images = imageList2;
        //    else barManager1.Images = imageList1;
        //    if ("DefaultSkin".IndexOf(paintStyleName) >= 0)
        //        DevExpress.Skins.SkinManager.EnableFormSkins();
        //    else DevExpress.Skins.SkinManager.DisableFormSkins();
        //  //  skinProcessing = true;
        //    DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
        //    //skinProcessing = false;
        //}

        //private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    FontDialog dlg = new FontDialog();
        //    dlg.Font = (Font)SelectFont.Clone();
        //    dlg.ShowColor = true;
        //    dlg.Color = rtPad.SelectionColor;
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        rtPad.SelectionFont = (Font)dlg.Font.Clone();
        //        rtPad.SelectionColor = dlg.Color;
        //    }
        //}

        private void iBold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.SelectionFont = new Font(SelectFont.FontFamily.Name, SelectFont.Size, rtPadFontStyle());
        }

        private void iItalic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.SelectionFont = new Font(SelectFont.FontFamily.Name, SelectFont.Size, rtPadFontStyle());
        }

        private void iUnderline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.SelectionFont = new Font(SelectFont.FontFamily.Name, SelectFont.Size, rtPadFontStyle());
        }

        private void iAlignLeft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (iAlignLeft.Down)
                rtPad.SelectionAlignment = HorizontalAlignment.Left;
            if (iCenter.Down)
                rtPad.SelectionAlignment = HorizontalAlignment.Center;
            if (iAlignRight.Down)
                rtPad.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void iCenter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (iAlignLeft.Down)
                rtPad.SelectionAlignment = HorizontalAlignment.Left;
            if (iCenter.Down)
                rtPad.SelectionAlignment = HorizontalAlignment.Center;
            if (iAlignRight.Down)
                rtPad.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void iAlignRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (iAlignLeft.Down)
                rtPad.SelectionAlignment = HorizontalAlignment.Left;
            if (iCenter.Down)
                rtPad.SelectionAlignment = HorizontalAlignment.Center;
            if (iAlignRight.Down)
                rtPad.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void iFont_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = (Font)SelectFont.Clone();
            dlg.ShowColor = true;
            dlg.Color = rtPad.SelectionColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                rtPad.SelectionFont = (Font)dlg.Font.Clone();
                rtPad.SelectionColor = dlg.Color;
            }
        }

        private void iFontColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.SelectionColor = cp.ResultColor;
        }

        private void iCut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.Cut();
            InitPaste();
        }

        private void iCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.Copy();
            InitPaste();
        }

        private void iPaste_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.Paste();
        }

        private void iSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MiraSignatureSaveArgs SaveArgs = new MiraSignatureSaveArgs();
            EventSave(this, SaveArgs);
            string str = rtPad.Rtf.ToString();
            //rtPad.SelectedRtf
            //StreamReader sr = new StreamReader(
            //TextReader tr = rtPad.;
            //Stream st;
            //StringReader sr = new StringReader(
            //st.BeginRead(
            
        }

        private void iNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveQuestion())
            {
                //Open = true;
                //DocName = docNameDefault;
                rtPadClear();
                Modified = false;
                rtPad.SelectionLength = 0;
            }
        }

        private void iUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtPad.Undo();
            Modified = rtPad.CanUndo;
            iUndo.Enabled = rtPad.CanUndo;
            InitFormat();
        }

        private void rtPad_SelectionChanged(object sender, EventArgs e)
        {
            InitFormat();
            InitEdit(rtPad.SelectionLength > 0);
            int line = rtPad.GetLineFromCharIndex(rtPad.SelectionStart) + 1;
            int col = rtPad.SelectionStart + 1;

            sPosition.Caption = "Line: " + line.ToString() + "  Position: " + col.ToString();
        }

        private void iOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MiraSignatureOpenArgs OpenArgs = new MiraSignatureOpenArgs();
            EventOpen(this, OpenArgs);
            string str = rtPad.Rtf.ToString();
        }

        private void MiraRichTextbox_Load(object sender, EventArgs e)
        {
            rtPad.SelectionColor = Color.Black;
        }

    }
}
