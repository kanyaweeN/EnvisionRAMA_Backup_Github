namespace RIS.Forms.Popup
{
    partial class PopupNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupNotify));
            this.m_Office2003Popup = new Nevron.UI.WinForm.Controls.NPopupNotify();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // m_Office2003Popup
            // 
            this.m_Office2003Popup.Caption.ButtonsAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_Office2003Popup.Caption.ButtonSize = new Nevron.GraphicsCore.NSize(15, 15);
            this.m_Office2003Popup.Caption.ButtonsMargins = new Nevron.UI.NPadding(0, 0, 0, 0);
            this.m_Office2003Popup.Caption.ButtonSpacing = 1;
            this.m_Office2003Popup.Caption.CaptionStyle = Nevron.UI.CaptionStyle.Standard;
            this.m_Office2003Popup.Caption.Content.AutoSizeMask = Nevron.UI.AutoSizeMask.None;
            this.m_Office2003Popup.Caption.Content.KeyboardInputEnabled = false;
            this.m_Office2003Popup.Caption.Content.MouseInputEnabled = false;
            this.m_Office2003Popup.Caption.Content.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((byte)(255)), ((byte)(255)), ((byte)(255)), ((byte)(255))));
            this.m_Office2003Popup.Caption.Content.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_Office2003Popup.Caption.Content.TreatAsOneEntity = false;
            this.m_Office2003Popup.Caption.DefaultItemStyle = Nevron.UI.ItemStyle.ImageAndText;
            this.m_Office2003Popup.Caption.ItemLayout = Nevron.UI.ToolStrips.ItemLayout.HorizontalFlow;
            this.m_Office2003Popup.Caption.ItemSize = new Nevron.GraphicsCore.NSize(0, 0);
            this.m_Office2003Popup.Content.Padding = new Nevron.UI.NPadding(4);
            this.m_Office2003Popup.EnableSkinning = true;
            this.m_Office2003Popup.ShapeTransparentColor = System.Drawing.Color.Empty;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Help1.png");
            // 
            // PopupNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 248);
            this.Name = "PopupNotify";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NPopupNotify m_Office2003Popup;
        private System.Windows.Forms.ImageList imageList1;
    }
}

