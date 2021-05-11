using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.Common
{
    public partial class CheckOverLine : UserControl
    {
        public CheckOverLine()
        {
            InitializeComponent();
        }

        private void CheckOverLine_Load(object sender, EventArgs e)
        {

        }

        public bool IsLabelOverline(string text,bool isFontBold,bool isFontItalic,bool isFontUnderline) {
            LabelControl lbl = new LabelControl();
            lbl.UseMnemonic = false;
            lbl.AutoSizeMode = LabelAutoSizeMode.Horizontal;
            lbl.Size = new Size(0, 0);
            lbl.Left = 0;
            lbl.Top = 0;
            lbl.Text = text;

            FontStyle fs = FontStyle.Regular;
            if (isFontBold) fs |= FontStyle.Bold;
            if (isFontItalic) fs |= FontStyle.Italic;
            if (isFontUnderline) fs |= FontStyle.Underline;
            Font font = new Font(lbl.Font, fs);
            lbl.Font = font;
            //if(isFontBold)
            //    QuestionnaireHelper.AdjustSize(this, QuestionnaireHelper.BaseWidth - 200, 100);
            //else
                QuestionnaireHelper.AdjustSize(this, QuestionnaireHelper.BaseWidth - 40, 100);
            this.Controls.Add(lbl);
            if (lbl.Right > this.Width)
                return true;
            else
                return false;
        }
        public bool IsLabelOverline(string text, bool isFontBold, bool isFontItalic, bool isFontUnderline,int left)
        {
            LabelControl lbl = new LabelControl();
            lbl.UseMnemonic = false;
            lbl.AutoSizeMode = LabelAutoSizeMode.Horizontal;
            lbl.Size = new Size(0, 0);
            lbl.Left = left;
            lbl.Top = 0;
            lbl.Text = text;

            FontStyle fs = FontStyle.Regular;
            if (isFontBold) fs |= FontStyle.Bold;
            if (isFontItalic) fs |= FontStyle.Italic;
            if (isFontUnderline) fs |= FontStyle.Underline;
            Font font = new Font(lbl.Font, fs);
            lbl.Font = font;
            //if(isFontBold)
            //    QuestionnaireHelper.AdjustSize(this, QuestionnaireHelper.BaseWidth - 200, 100);
            //else
            QuestionnaireHelper.AdjustSize(this, QuestionnaireHelper.BaseWidth - 40, 100);
            this.Controls.Add(lbl);
            if (lbl.Right > this.Width)
                return true;
            else
                return false;
        }
    }
}
