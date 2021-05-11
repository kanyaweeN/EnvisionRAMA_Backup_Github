namespace Envision.NET.Forms.ResultEntry
{
    partial class frmZoom
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.spePercent = new DevExpress.XtraEditors.SpinEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spePercent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(126, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Zoom to ---------------------";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(33, 54);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Columns = 2;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "200%"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "150%"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "125%"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "100%"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "75%"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Other")});
            this.radioGroup1.Size = new System.Drawing.Size(337, 74);
            this.radioGroup1.TabIndex = 1;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // spePercent
            // 
            this.spePercent.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spePercent.Location = new System.Drawing.Point(33, 134);
            this.spePercent.Name = "spePercent";
            this.spePercent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spePercent.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.spePercent.Properties.Mask.EditMask = "P0";
            this.spePercent.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spePercent.Properties.MaxLength = 490;
            this.spePercent.Properties.MaxValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.spePercent.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spePercent.Properties.UseParentBackground = true;
            this.spePercent.Size = new System.Drawing.Size(112, 20);
            this.spePercent.TabIndex = 2;
            this.spePercent.EditValueChanged += new System.EventHandler(this.spePercent_EditValueChanged);
            this.spePercent.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.spePercent_EditValueChanging);
            this.spePercent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spePercent_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(199, 131);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(379, 28);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // frmZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 176);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.spePercent);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmZoom";
            this.Ribbon = this.ribbonControl1;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zoom";
            this.Load += new System.EventHandler(this.frmZoom_Load);
            this.AutoSizeChanged += new System.EventHandler(this.frmZoom_AutoSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spePercent.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SpinEdit spePercent;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    }
}