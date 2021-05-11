namespace RIS.Forms.Admin
{
    partial class frmMonitoringConfirm
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
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.memStrBill = new DevExpress.XtraEditors.MemoEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblShow = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.memStrBill.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(82, 278);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // memStrBill
            // 
            this.memStrBill.Location = new System.Drawing.Point(12, 12);
            this.memStrBill.Name = "memStrBill";
            this.memStrBill.Size = new System.Drawing.Size(542, 260);
            this.memStrBill.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(179, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblShow
            // 
            this.lblShow.Location = new System.Drawing.Point(321, 288);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(63, 13);
            this.lblShow.TabIndex = 3;
            this.lblShow.Text = "labelControl1";
            // 
            // frmMonitoringConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(566, 313);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.memStrBill);
            this.Controls.Add(this.btnSend);
            this.Name = "frmMonitoringConfirm";
            this.Text = "frmMonitoringConfirm";
            this.Load += new System.EventHandler(this.frmMonitoringConfirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memStrBill.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.MemoEdit memStrBill;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblShow;
    }
}