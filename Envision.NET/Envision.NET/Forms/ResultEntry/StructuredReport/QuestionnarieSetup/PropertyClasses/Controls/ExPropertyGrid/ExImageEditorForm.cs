using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid
{
    public partial class ExImageEditorForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Image _imageSource = null;
        /// <summary>
        /// Get or Set Image Source
        /// </summary>
        public Image ImageSource
        {
            get { return _imageSource; }
            set 
            { 
                _imageSource = value;
                this.pictureEdit1.Image = _imageSource;
            }
        }
        public ExImageEditorForm()
        {
            InitializeComponent();
            this.btnBrowse.ItemClick += new ItemClickEventHandler(btnBrowse_ItemClick);
            this.btnCancel.ItemClick += new ItemClickEventHandler(btnCancel_ItemClick);
            this.btnOK.ItemClick += new ItemClickEventHandler(btnOK_ItemClick);
            this.btnClear.ItemClick += new ItemClickEventHandler(btnClear_ItemClick);
        }

        #region Editor Event
        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.pictureEdit1.Image = null;
            this.ImageSource = null;
        }
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ImageSource = null;
            this.Close();
        }
        /// <summary>
        /// Browse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFileDialog1.Filter = "(.png)|*.png|(.jpg)|*.jpg|(.jpeg)|*.jpeg|(.bmp)|*.bmp";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(this.openFileDialog1.FileName);
                this.pictureEdit1.Image = img;
                this.ImageSource = img;
            }
        }
        #endregion
    }
}