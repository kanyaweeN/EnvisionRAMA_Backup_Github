using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.GraphicsCore.Text;

namespace RIS.Forms.Popup
{
    public partial class PopupNotify : Form
    {
        string text = "";
        public PopupNotify(string txt)
        {
            text=txt;
            InitializeComponent();
            InitOffice2003Popup(text);
            ShowPopup(m_Office2003Popup);
         
        }
        internal void ShowPopup(NPopupNotify popup)
        {
            PopupAnimation animation = PopupAnimation.None;
          
                animation |= PopupAnimation.Fade;
            
                animation |= PopupAnimation.Slide;

            popup.AutoHide = true;
            popup.VisibleSpan = 5000;
            popup.Opacity = 255;
            popup.Animation = animation;
            //popup.AnimationDirection = (PopupAnimationDirection)animationDirectionCombo.SelectedItem;
            popup.VisibleOnMouseOver = true;
            popup.FullOpacityOnMouseOver = true;
            popup.AnimationInterval = 20;
            popup.AnimationSteps = 20;

            popup.Palette.Copy(NUIManager.Palette);
            this.Hide();
            popup.Show();
        }

        internal void InitOffice2003Popup(string txt)
        {
            
            m_Office2003Popup.PredefinedStyle = PredefinedPopupStyle.Office2003;
            m_Office2003Popup.Font = new Font("Tahoma", 8.0f);

            NImageAndTextItem content = m_Office2003Popup.Content;
            content.Image = imageList1.Images[0];
            content.ImageSize = new Nevron.GraphicsCore.NSize(28, 28);

            content.TextMargins = new NPadding(0, 4, 0, 0);
            content.Text = txt;
            //content.Click += new EventHandler(OnContentClick);

            Nevron.UI.WinForm.Controls.NCommand comm;
            NCommandCollection coll = m_Office2003Popup.OptionsCommands;

            for (int i = 1; i < 6; i++)
            {
                comm = new Nevron.UI.WinForm.Controls.NCommand();
                comm.Properties.Text = "Options command " + i.ToString();
                coll.Add(comm);
            }
        }
    }
}