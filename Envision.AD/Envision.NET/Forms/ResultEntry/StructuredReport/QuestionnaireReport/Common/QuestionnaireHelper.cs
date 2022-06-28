using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.Common;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.Common
{
    public static class QuestionnaireHelper
    {
        public  const int NEWLINE_SPACE = 3;
        public  const int LEFT_SPACE = 3;
        public static int RightSide { get { return BaseWidth - 10; } }
        public static int BaseWidth { get; set; }

        public static bool IsLabelOverline(string text, bool isFontBold, bool isFontItalic, bool isFontUnderline)
        {
            CheckOverLine chk = new CheckOverLine();
            bool flag = chk.IsLabelOverline(text, isFontBold, isFontItalic, isFontUnderline);
            chk.Dispose();
            return flag;
        }
        public static bool IsLabelOverline(string text, bool isFontBold, bool isFontItalic, bool isFontUnderline,int left)
        {
            CheckOverLine chk = new CheckOverLine();
            bool flag = chk.IsLabelOverline(text, isFontBold, isFontItalic, isFontUnderline,left);
            chk.Dispose();
            return flag;
        }

        public static void AdjustSize(Control ctrl, int Width, int Height) {
            ctrl.Size = new Size(Width, Height);
        }
        public static void AdjustSize(Control ctrlMain, Control ctrlChild) {
            int w = ctrlMain.Right;
            int h = ctrlMain.Bottom;
            bool flag = false;
            if (ctrlMain.Right < ctrlChild.Right)
            {
                w = ctrlChild.Right;
                flag = true;
            }
            if (ctrlMain.Bottom < ctrlChild.Bottom)
            {
                h = ctrlChild.Bottom;
                flag = true;
            }
            if (flag)
                AdjustSize(ctrlMain, w, h);
        }
        
        public static int AddLabelControl(Control ctrl, string text, int left, ref int top, bool isFontBold, bool isFontItalic, bool isFontUnderline)
        {
            LabelControl lbl = new LabelControl();
            lbl.UseMnemonic = false;
            lbl.AutoSizeMode = LabelAutoSizeMode.Horizontal;
            lbl.Size = new Size(0, 0);
            lbl.Left = left;
            lbl.Top = top;
            lbl.Text = text;
            FontStyle fs = FontStyle.Regular;
            if (isFontBold) fs |= FontStyle.Bold;
            if (isFontItalic) fs |= FontStyle.Italic;
            if (isFontUnderline) fs |= FontStyle.Underline;
            Font font = new Font(lbl.Font, fs);
            lbl.Font = font;
            
            ctrl.Controls.Add(lbl);
            AdjustSize(ctrl, lbl);

            int right = lbl.Right + 3;
            if (isFontBold)
            {
                right += (text.Length / 6) * 5 + 5;
                ctrl.Size = new Size(right, ctrl.Height);
            }
            top = lbl.Bottom + 3;
            return right;
        }
        public static int AddLabelControl(Control ctrl, string text, int left, ref int top, bool isFontBold, bool isFontItalic, bool isFontUnderline,int width)
        {
            LabelControl lbl = new LabelControl();
            lbl.UseMnemonic = false;
            lbl.AutoSizeMode = LabelAutoSizeMode.Horizontal;
            lbl.Size = new Size(0, 0);
            lbl.Left = left;
            lbl.Top = top;
            lbl.Text = text;
            FontStyle fs = FontStyle.Regular;
            if (isFontBold) fs |= FontStyle.Bold;
            if (isFontItalic) fs |= FontStyle.Italic;
            if (isFontUnderline) fs |= FontStyle.Underline;
            Font font = new Font(lbl.Font, fs);
            lbl.Font = font;
            lbl.Width = width;
            ctrl.Controls.Add(lbl);
            AdjustSize(ctrl, lbl);

            int right = lbl.Right + 3;
            if (isFontBold) right += (text.Length / 6) * 5 + 5;
            top = lbl.Bottom + 3;
            return right;
        }
        public static int AddLabelControl(Control ctrl, string text, int left, ref int top, bool isFontBold, bool isFontItalic, bool isFontUnderline,QuestionnaireName name,int indexCtrl)
        {
            LabelControl lbl = new LabelControl();
            lbl.UseMnemonic = false;
            lbl.AutoSizeMode = LabelAutoSizeMode.Horizontal;
            lbl.Size = new Size(0, 0);
            lbl.Left = left;
            lbl.Top = top;
            lbl.Text = text;
            FontStyle fs = FontStyle.Regular;
            if (isFontBold) fs |= FontStyle.Bold;
            if (isFontItalic) fs |= FontStyle.Italic;
            if (isFontUnderline) fs |= FontStyle.Underline;
            Font font = new Font(lbl.Font, fs);
            lbl.Font = font;

            indexCtrl++;
            lbl.Name = "label" + indexCtrl;
            name.IsForce = false;
            name.Value = text;
            name.IsLabel = true;


            ctrl.Controls.Add(lbl);
            AdjustSize(ctrl, lbl);

            int right = lbl.Right + 3;
            if (isFontBold) right += (text.Length / 6) * 5 + 5;
            top = lbl.Bottom + 3;
            return right;
        }

        public static Image ConvertByteImage(Object obj) {
            Image img = null;
            try
            {
                ImageConverter imcon = new ImageConverter();
                img = (Image)imcon.ConvertFrom(obj);
            }
            catch
            {
                img = null;
            }
            return img;
        }
        public static int AddImageControl(Control ctrl, Image img, int left, int top, ref int bottom) {
            PictureEdit p = new PictureEdit();
            p.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            p.Left = left;
            p.Top = top;
            p.Image = img;
            p.Size = new Size(137, 96);
            ctrl.Controls.Add(p);
            bottom = p.Bottom;
            AdjustSize(ctrl, p);
            return p.Right;
        }

        public static QuestionnaireName AddQuestionnaireName(string name,string value)
        {
            QuestionnaireName qn = new QuestionnaireName();
            qn.Name = name;
            qn.Value = value;
            return qn;
        }
    }

    public class QuestionnaireName {
        public int QId { get; set; }
        public int QIdDtl { get; set; }
        public int QIdDtlChild { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsForce { get; set; }
        public bool IsLabel { get; set; }
        public List<QuestionnaireName> Child { get; set; }

        public QuestionnaireName() {
            Child = new List<QuestionnaireName>();
            IsForce = false;
            Name = string.Empty;
            Value = string.Empty;
            IsLabel = false;
            QId = QIdDtl = QIdDtlChild;
        }
    }
}
