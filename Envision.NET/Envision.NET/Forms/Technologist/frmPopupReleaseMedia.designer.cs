
namespace Envision.NET.Forms.Technologist
{
    partial class frmPopupReleaseMedia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPopupReleaseMedia));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblHn = new DevExpress.XtraEditors.LabelControl();
            this.lblAccession = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientName = new DevExpress.XtraEditors.LabelControl();
            this.lblAge = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtRequestBy = new System.Windows.Forms.TextBox();
            this.btnRequestBy = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtRecieve = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.memComment = new DevExpress.XtraEditors.MemoEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.speQTY = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtRequestDept = new DevExpress.XtraEditors.TextEdit();
            this.btnRequestDept = new DevExpress.XtraEditors.SimpleButton();
            this.luMediatype = new DevExpress.XtraEditors.LookUpEdit();
            this.luReason = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecieve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speQTY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luMediatype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luReason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(65, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "HN :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Accession No. :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(237, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Patient Name :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(282, 31);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Age :";
            // 
            // lblHn
            // 
            this.lblHn.Location = new System.Drawing.Point(98, 12);
            this.lblHn.Name = "lblHn";
            this.lblHn.Size = new System.Drawing.Size(63, 13);
            this.lblHn.TabIndex = 4;
            this.lblHn.Text = "labelControl5";
            // 
            // lblAccession
            // 
            this.lblAccession.Location = new System.Drawing.Point(98, 31);
            this.lblAccession.Name = "lblAccession";
            this.lblAccession.Size = new System.Drawing.Size(63, 13);
            this.lblAccession.TabIndex = 5;
            this.lblAccession.Text = "labelControl5";
            // 
            // lblPatientName
            // 
            this.lblPatientName.Location = new System.Drawing.Point(314, 12);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(63, 13);
            this.lblPatientName.TabIndex = 6;
            this.lblPatientName.Text = "labelControl5";
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(314, 31);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(63, 13);
            this.lblAge.TabIndex = 7;
            this.lblAge.Text = "labelControl5";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(90, 58);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Patient"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Clinician"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Nurse")});
            this.radioGroup1.Size = new System.Drawing.Size(180, 31);
            this.radioGroup1.TabIndex = 8;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(24, 98);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(62, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Request By :";
            // 
            // txtRequestBy
            // 
            this.txtRequestBy.Enabled = false;
            this.txtRequestBy.Location = new System.Drawing.Point(90, 95);
            this.txtRequestBy.Name = "txtRequestBy";
            this.txtRequestBy.ReadOnly = true;
            this.txtRequestBy.Size = new System.Drawing.Size(300, 20);
            this.txtRequestBy.TabIndex = 10;
            // 
            // btnRequestBy
            // 
            this.btnRequestBy.Enabled = false;
            this.btnRequestBy.Location = new System.Drawing.Point(398, 95);
            this.btnRequestBy.Name = "btnRequestBy";
            this.btnRequestBy.Size = new System.Drawing.Size(28, 23);
            this.btnRequestBy.TabIndex = 11;
            this.btnRequestBy.Text = "...";
            this.btnRequestBy.Click += new System.EventHandler(this.btnRequestBy_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(24, 178);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Recieve By :";
            // 
            // txtRecieve
            // 
            this.txtRecieve.Location = new System.Drawing.Point(90, 175);
            this.txtRecieve.Name = "txtRecieve";
            this.txtRecieve.Size = new System.Drawing.Size(218, 20);
            this.txtRecieve.TabIndex = 13;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(26, 150);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 13);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Media type :";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(334, 178);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(43, 13);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "Reason :";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(34, 204);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(52, 13);
            this.labelControl9.TabIndex = 18;
            this.labelControl9.Text = "Comment :";
            // 
            // memComment
            // 
            this.memComment.Location = new System.Drawing.Point(90, 201);
            this.memComment.Name = "memComment";
            this.memComment.Size = new System.Drawing.Size(485, 68);
            this.memComment.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(382, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(480, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(350, 150);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(27, 13);
            this.labelControl10.TabIndex = 22;
            this.labelControl10.Text = "QTY :";
            // 
            // speQTY
            // 
            this.speQTY.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speQTY.Location = new System.Drawing.Point(383, 147);
            this.speQTY.Name = "speQTY";
            this.speQTY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.speQTY.Properties.IsFloatValue = false;
            this.speQTY.Properties.Mask.EditMask = "N00";
            this.speQTY.Properties.MaxLength = 10;
            this.speQTY.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.speQTY.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speQTY.Size = new System.Drawing.Size(192, 20);
            this.speQTY.TabIndex = 23;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(7, 124);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(77, 13);
            this.labelControl11.TabIndex = 24;
            this.labelControl11.Text = "Request Dept. :";
            // 
            // txtRequestDept
            // 
            this.txtRequestDept.Enabled = false;
            this.txtRequestDept.Location = new System.Drawing.Point(90, 121);
            this.txtRequestDept.Name = "txtRequestDept";
            this.txtRequestDept.Properties.ReadOnly = true;
            this.txtRequestDept.Size = new System.Drawing.Size(300, 20);
            this.txtRequestDept.TabIndex = 25;
            // 
            // btnRequestDept
            // 
            this.btnRequestDept.Location = new System.Drawing.Point(398, 118);
            this.btnRequestDept.Name = "btnRequestDept";
            this.btnRequestDept.Size = new System.Drawing.Size(28, 23);
            this.btnRequestDept.TabIndex = 26;
            this.btnRequestDept.Text = "...";
            this.btnRequestDept.Click += new System.EventHandler(this.btnRequestDept_Click);
            // 
            // luMediatype
            // 
            this.luMediatype.Location = new System.Drawing.Point(90, 149);
            this.luMediatype.Name = "luMediatype";
            this.luMediatype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luMediatype.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEXT", "TEXT", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luMediatype.Properties.NullText = "";
            this.luMediatype.Properties.ShowFooter = false;
            this.luMediatype.Properties.ShowHeader = false;
            this.luMediatype.Properties.ShowLines = false;
            this.luMediatype.Size = new System.Drawing.Size(218, 20);
            this.luMediatype.TabIndex = 27;
            // 
            // luReason
            // 
            this.luReason.Location = new System.Drawing.Point(383, 175);
            this.luReason.Name = "luReason";
            this.luReason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luReason.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEXT", "TEXT", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luReason.Properties.NullText = "";
            this.luReason.Properties.ShowFooter = false;
            this.luReason.Properties.ShowHeader = false;
            this.luReason.Properties.ShowLines = false;
            this.luReason.Size = new System.Drawing.Size(192, 20);
            this.luReason.TabIndex = 28;
            // 
            // frmPopupReleaseMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 309);
            this.Controls.Add(this.luReason);
            this.Controls.Add(this.luMediatype);
            this.Controls.Add(this.btnRequestDept);
            this.Controls.Add(this.txtRequestDept);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.speQTY);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.memComment);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtRecieve);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.btnRequestBy);
            this.Controls.Add(this.txtRequestBy);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblAccession);
            this.Controls.Add(this.lblHn);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPopupReleaseMedia";
            this.Text = "Release Detail";
            this.Load += new System.EventHandler(this.frmPopupReleaseMedia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecieve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speQTY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luMediatype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luReason.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblHn;
        private DevExpress.XtraEditors.LabelControl lblAccession;
        private DevExpress.XtraEditors.LabelControl lblPatientName;
        private DevExpress.XtraEditors.LabelControl lblAge;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txtRequestBy;
        private DevExpress.XtraEditors.SimpleButton btnRequestBy;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtRecieve;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit memComment;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SpinEdit speQTY;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtRequestDept;
        private DevExpress.XtraEditors.SimpleButton btnRequestDept;
        private DevExpress.XtraEditors.LookUpEdit luMediatype;
        private DevExpress.XtraEditors.LookUpEdit luReason;
    }
}