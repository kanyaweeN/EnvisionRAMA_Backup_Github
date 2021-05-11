using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using System.Reflection;

using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using System.Drawing.Drawing2D;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmPopupKeyimage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string ACCESSION;
        private GBLEnvVariable env = new GBLEnvVariable();
        public frmPopupKeyimage()
        {
            InitializeComponent();
        }
        public frmPopupKeyimage(string Accession)
        {
            InitializeComponent();
            ACCESSION = Accession;
        }
        private void btnSavePic_Click(object sender, EventArgs e)
        {
            if (picImageEdit.Image == null) return;
            
            DataTable dtSelect = new DataTable();
            int sl_no = 0;
            #region resize image
            ImageConverter imcon = new ImageConverter();
            Size si = new Size();
            si.Height = 300;
            si.Width = 300;

            Image im  = picImageEdit.Image;
            if (picImageEdit.Image.Height > 300)
                im = resizeImage(picImageEdit.Image, si);
                
            Byte[] keyIm = (byte[])imcon.ConvertTo(im, typeof(byte[]));
            if (keyIm.Length <= 0)
                keyIm = null; 
            #endregion

            ProcessGetRISExamresultKeyimage get = new ProcessGetRISExamresultKeyimage();
            get.RIS_EXAMRESULTKEYIMAGES.ACCESSION_NO = ACCESSION;
            get.Invoke();
            dtSelect = get.Result.Tables[0];
            foreach (DataRow dr in dtSelect.Rows)
	{
                if(Convert.ToInt32(dr["SL_NO"])>sl_no)
                    sl_no = Convert.ToInt32(dr["SL_NO"]);
	}
            ProcessAddRISExamresultKeyimage add = new ProcessAddRISExamresultKeyimage();
            add.RIS_EXAMRESULTKEYIMAGES.ACCESSION_NO = ACCESSION;
            add.RIS_EXAMRESULTKEYIMAGES.SL_NO = Convert.ToByte(sl_no + 1);
            add.RIS_EXAMRESULTKEYIMAGES.ORG_ID = 1;
            add.RIS_EXAMRESULTKEYIMAGES.KEY_IMAGE = keyIm;
            add.RIS_EXAMRESULTKEYIMAGES.CREATED_BY = env.UserID;
            add.Invoke();
            this.DialogResult = DialogResult.OK;
        }
        private Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPopupKeyimage_Load(object sender, EventArgs e)
        {

        }
        DXPopupMenu menu = null;
        private void picImageEdit_MouseUp(object sender, MouseEventArgs e)
        {
            PictureEdit edit = sender as PictureEdit;
            if (menu == null)
            {
                PropertyInfo info = typeof(PictureEdit).GetProperty("Menu", BindingFlags.NonPublic | BindingFlags.Instance);
                menu = info.GetValue(edit, null) as DXPopupMenu;
                menu.Items[0].Visible = false;
                menu.Items[1].Visible = false;
                menu.Items[3].Visible = false;
                menu.Items[5].Visible = false;
            }
        }
    }
}