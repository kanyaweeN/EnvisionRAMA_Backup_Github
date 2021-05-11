namespace RIS.Forms.Inventory
{
    partial class INV_TXN_PO_Autorization_Dialog
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.txtTOC = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer4 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer3 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.txtPOUID = new DevExpress.XtraEditors.TextEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.txtVendor = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
            this.ultraExpandableGroupBox1.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTOC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(110, 95);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(208, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nEntryContainer1
            // 
            this.nEntryContainer1.BackColor = System.Drawing.Color.Transparent;
            this.nEntryContainer1.Interactive = false;
            this.nEntryContainer1.Location = new System.Drawing.Point(29, 22);
            this.nEntryContainer1.Name = "nEntryContainer1";
            this.nEntryContainer1.ShadowInfo.Draw = false;
            this.nEntryContainer1.Size = new System.Drawing.Size(173, 26);
            this.nEntryContainer1.StrokeInfo.Rounding = 5;
            this.nEntryContainer1.TabIndex = 12;
            this.nEntryContainer1.Text = "PO No.";
            // 
            // ultraExpandableGroupBox1
            // 
            this.ultraExpandableGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rounded;
            this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(423, 165);
            this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(1, 2);
            this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
            this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(423, 165);
            this.ultraExpandableGroupBox1.TabIndex = 13;
            this.ultraExpandableGroupBox1.Text = "PO Generating";
            this.ultraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtVendor);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.btnCancel);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.btnOK);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtTOC);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.nEntryContainer4);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.nEntryContainer3);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtPOUID);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.nEntryContainer1);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 20);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(417, 142);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // txtTOC
            // 
            this.txtTOC.Location = new System.Drawing.Point(90, 54);
            this.txtTOC.Name = "txtTOC";
            this.txtTOC.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtTOC.Properties.Appearance.Options.UseBackColor = true;
            this.txtTOC.Size = new System.Drawing.Size(283, 20);
            this.txtTOC.TabIndex = 36;
            // 
            // nEntryContainer4
            // 
            this.nEntryContainer4.BackColor = System.Drawing.Color.Transparent;
            this.nEntryContainer4.Interactive = false;
            this.nEntryContainer4.Location = new System.Drawing.Point(29, 51);
            this.nEntryContainer4.Name = "nEntryContainer4";
            this.nEntryContainer4.ShadowInfo.Draw = false;
            this.nEntryContainer4.Size = new System.Drawing.Size(349, 26);
            this.nEntryContainer4.StrokeInfo.Rounding = 5;
            this.nEntryContainer4.TabIndex = 35;
            this.nEntryContainer4.Text = "Remark";
            // 
            // nEntryContainer3
            // 
            this.nEntryContainer3.BackColor = System.Drawing.Color.Transparent;
            this.nEntryContainer3.Interactive = false;
            this.nEntryContainer3.Location = new System.Drawing.Point(204, 22);
            this.nEntryContainer3.Name = "nEntryContainer3";
            this.nEntryContainer3.ShadowInfo.Draw = false;
            this.nEntryContainer3.Size = new System.Drawing.Size(174, 26);
            this.nEntryContainer3.StrokeInfo.Rounding = 5;
            this.nEntryContainer3.TabIndex = 33;
            this.nEntryContainer3.Text = "Vendor No.";
            // 
            // txtPOUID
            // 
            this.txtPOUID.EditValue = "AUTO";
            this.txtPOUID.Location = new System.Drawing.Point(90, 25);
            this.txtPOUID.Name = "txtPOUID";
            this.txtPOUID.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPOUID.Properties.Appearance.Options.UseBackColor = true;
            this.txtPOUID.Properties.ReadOnly = true;
            this.txtPOUID.Size = new System.Drawing.Size(108, 20);
            this.txtPOUID.TabIndex = 30;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // txtVendor
            // 
            this.txtVendor.Location = new System.Drawing.Point(273, 25);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtVendor.Size = new System.Drawing.Size(100, 20);
            this.txtVendor.TabIndex = 37;
            // 
            // INV_TXN_PO_Autorization_Dialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(425, 168);
            this.Controls.Add(this.ultraExpandableGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "INV_TXN_PO_Autorization_Dialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order Generating";
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
            this.ultraExpandableGroupBox1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTOC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private DevExpress.XtraEditors.TextEdit txtTOC;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer4;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer3;
        private DevExpress.XtraEditors.TextEdit txtPOUID;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.ComboBoxEdit txtVendor;
    }
}