namespace Envision.NET.Forms.Dialog
{
    partial class frmAddOnlineBlock
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.cbSession = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lbSession = new DevExpress.XtraEditors.LabelControl();
            this.cbModality = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lbModality = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbAlert = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cbSession.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbModality.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(197, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(109, 146);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "ตกลง";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbSession
            // 
            this.cbSession.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSession.Location = new System.Drawing.Point(72, 86);
            this.cbSession.Name = "cbSession";
            this.cbSession.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSession.Size = new System.Drawing.Size(200, 20);
            this.cbSession.TabIndex = 16;
            // 
            // lbSession
            // 
            this.lbSession.Location = new System.Drawing.Point(19, 89);
            this.lbSession.Name = "lbSession";
            this.lbSession.Size = new System.Drawing.Size(43, 13);
            this.lbSession.TabIndex = 15;
            this.lbSession.Text = "Session :";
            // 
            // cbModality
            // 
            this.cbModality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModality.Location = new System.Drawing.Point(72, 50);
            this.cbModality.Name = "cbModality";
            this.cbModality.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbModality.Size = new System.Drawing.Size(200, 20);
            this.cbModality.TabIndex = 14;
            // 
            // lbModality
            // 
            this.lbModality.Location = new System.Drawing.Point(15, 53);
            this.lbModality.Name = "lbModality";
            this.lbModality.Size = new System.Drawing.Size(47, 13);
            this.lbModality.TabIndex = 13;
            this.lbModality.Text = "Modality :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(32, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Date :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // lbAlert
            // 
            this.lbAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAlert.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbAlert.Appearance.Options.UseForeColor = true;
            this.lbAlert.Location = new System.Drawing.Point(72, 116);
            this.lbAlert.Name = "lbAlert";
            this.lbAlert.Size = new System.Drawing.Size(0, 13);
            this.lbAlert.TabIndex = 19;
            // 
            // frmAddOnlineBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 181);
            this.Controls.Add(this.lbAlert);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbSession);
            this.Controls.Add(this.lbSession);
            this.Controls.Add(this.cbModality);
            this.Controls.Add(this.lbModality);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dateTimePicker1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddOnlineBlock";
            this.ShowIcon = false;
            this.Text = "Add Online Block";
            ((System.ComponentModel.ISupportInitialize)(this.cbSession.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbModality.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbSession;
        private DevExpress.XtraEditors.LabelControl lbSession;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbModality;
        private DevExpress.XtraEditors.LabelControl lbModality;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.LabelControl lbAlert;
    }
}