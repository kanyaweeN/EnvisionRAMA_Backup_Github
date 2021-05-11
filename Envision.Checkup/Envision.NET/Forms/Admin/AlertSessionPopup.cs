using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Admin
{
    public partial class AlertSessionPopup : Form
    {
        public State state = State.OK;
        public enum State
        {
            None, OK, Cancel
        }
        private static AlertSessionPopup popup;
        private string reasonText = null;
        private AlertSessionPopup()
        {
            InitializeComponent();
        }
        public string ReasonText
        {
            get { return reasonText; }
            set { reasonText = value; }
        }
        public static AlertSessionPopup GetForm()
        {
            if (popup == null)
                return popup = new AlertSessionPopup();
            return popup;
        }

        private void bKill_Click(object sender, EventArgs e)
        {
            if (tbReason.Text == "" || tbReason.Text.Trim() == "")
                tbReason.Focus();
            else
            {
                state = State.OK;
                reasonText = tbReason.Text;
                this.Visible = false;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            state = State.Cancel;
            this.Visible = false;
        }

        private void AlertSessionPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            state = State.OK;
            this.Visible = false;
        }

        private void AlertSessionPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            state = State.OK;
            this.Visible = false;
        }
    }
}
