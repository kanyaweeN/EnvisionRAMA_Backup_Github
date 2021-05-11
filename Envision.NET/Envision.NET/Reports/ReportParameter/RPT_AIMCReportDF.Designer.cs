namespace Envision.NET.Reports.ReportParameter
{
    partial class RPT_AIMCReportDF
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoSelectRadiologist = new DevExpress.XtraEditors.RadioGroup();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.chkcmbModality = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblModality = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbRadiologist = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.lblRadiologist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoSelectRadiologist.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbModality.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRadiologist.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraTabControl1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.xtraTabControl1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            this.xtraTabControl1.Appearance.Options.UseBorderColor = true;
            this.xtraTabControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.Location = new System.Drawing.Point(205, 157);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.ShowToolTips = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.Size = new System.Drawing.Size(401, 183);
            this.xtraTabControl1.TabIndex = 9;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.White;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.label3);
            this.xtraTabPage1.Controls.Add(this.rdoSelectRadiologist);
            this.xtraTabPage1.Controls.Add(this.btnLoadData);
            this.xtraTabPage1.Controls.Add(this.dtFromdate);
            this.xtraTabPage1.Controls.Add(this.label5);
            this.xtraTabPage1.Controls.Add(this.dtToDate);
            this.xtraTabPage1.Controls.Add(this.label2);
            this.xtraTabPage1.Controls.Add(this.button2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(392, 174);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // label3
            // 
            this.label3.Image = global::Envision.NET.Properties.Resources.Help;
            this.label3.Location = new System.Drawing.Point(23, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 39);
            this.label3.TabIndex = 5;
            // 
            // rdoSelectRadiologist
            // 
            this.rdoSelectRadiologist.Location = new System.Drawing.Point(88, 39);
            this.rdoSelectRadiologist.Name = "rdoSelectRadiologist";
            this.rdoSelectRadiologist.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Radiologist 1"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Radiologist 2")});
            this.rdoSelectRadiologist.Size = new System.Drawing.Size(290, 30);
            this.rdoSelectRadiologist.TabIndex = 25;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(216, 113);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 22;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd/MM/yyyy";
            this.dtFromdate.Location = new System.Drawing.Point(88, 13);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(131, 20);
            this.dtFromdate.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Date :";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd/MM/yyyy";
            this.dtToDate.Location = new System.Drawing.Point(243, 13);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(135, 20);
            this.dtToDate.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(225, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "-";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(297, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.chkcmbModality);
            this.xtraTabPage2.Controls.Add(this.lblModality);
            this.xtraTabPage2.Controls.Add(this.btnBack);
            this.xtraTabPage2.Controls.Add(this.cmbRadiologist);
            this.xtraTabPage2.Controls.Add(this.button1);
            this.xtraTabPage2.Controls.Add(this.lblRadiologist);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(392, 174);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // chkcmbModality
            // 
            this.chkcmbModality.Location = new System.Drawing.Point(99, 38);
            this.chkcmbModality.Name = "chkcmbModality";
            this.chkcmbModality.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkcmbModality.Properties.DropDownRows = 10;
            this.chkcmbModality.Size = new System.Drawing.Size(290, 20);
            this.chkcmbModality.TabIndex = 28;
            // 
            // lblModality
            // 
            this.lblModality.AutoSize = true;
            this.lblModality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModality.Location = new System.Drawing.Point(14, 39);
            this.lblModality.Name = "lblModality";
            this.lblModality.Size = new System.Drawing.Size(68, 16);
            this.lblModality.TabIndex = 27;
            this.lblModality.Text = "Modality ; ";
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Location = new System.Drawing.Point(17, 139);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cmbRadiologist
            // 
            this.cmbRadiologist.Location = new System.Drawing.Point(99, 64);
            this.cmbRadiologist.Name = "cmbRadiologist";
            this.cmbRadiologist.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRadiologist.Properties.DropDownRows = 10;
            this.cmbRadiologist.Size = new System.Drawing.Size(290, 20);
            this.cmbRadiologist.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Run Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRadiologist
            // 
            this.lblRadiologist.AutoSize = true;
            this.lblRadiologist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadiologist.Location = new System.Drawing.Point(14, 65);
            this.lblRadiologist.Name = "lblRadiologist";
            this.lblRadiologist.Size = new System.Drawing.Size(83, 16);
            this.lblRadiologist.TabIndex = 0;
            this.lblRadiologist.Text = "Radiologist :";
            // 
            // RPT_AIMCReportDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(799, 592);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RPT_AIMCReportDF";
            this.Text = "RPT_AIMCReportDF";
            this.Load += new System.EventHandler(this.RPT_AIMCReportDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoSelectRadiologist.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbModality.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRadiologist.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRadiologist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cmbRadiologist;
        private DevExpress.XtraEditors.RadioGroup rdoSelectRadiologist;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLoadData;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkcmbModality;
        private System.Windows.Forms.Label lblModality;
    }
}