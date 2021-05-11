namespace Envision.NET.Reports.ReportParameter
{
    partial class frmRSS_StatOnline
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.pnlGroup = new System.Windows.Forms.Panel();
            this.btnDirectPrint = new System.Windows.Forms.Button();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.cmbReportTypeSch = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTypeSch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateToSch = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRunReportSch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDateFromSch = new System.Windows.Forms.DateTimePicker();
            this.btnCancleSch = new System.Windows.Forms.Button();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.txtDateToWL = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRunReportWL = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDateFromWL = new System.Windows.Forms.DateTimePicker();
            this.btnCancleWL = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.pnlGroup.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xtraTabControl1);
            this.groupBox1.Location = new System.Drawing.Point(204, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 225);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistic Online";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 16);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(511, 206);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.pnlGroup);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(502, 176);
            this.xtraTabPage1.Text = "Online Requested";
            this.xtraTabPage1.Tooltip = "Online Requested";
            // 
            // pnlGroup
            // 
            this.pnlGroup.Controls.Add(this.btnDirectPrint);
            this.pnlGroup.Controls.Add(this.cmbReportType);
            this.pnlGroup.Controls.Add(this.label7);
            this.pnlGroup.Controls.Add(this.txtType);
            this.pnlGroup.Controls.Add(this.label1);
            this.pnlGroup.Controls.Add(this.txtDateTo);
            this.pnlGroup.Controls.Add(this.label5);
            this.pnlGroup.Controls.Add(this.btnRunReport);
            this.pnlGroup.Controls.Add(this.label2);
            this.pnlGroup.Controls.Add(this.txtDateFrom);
            this.pnlGroup.Controls.Add(this.btnCancel);
            this.pnlGroup.Location = new System.Drawing.Point(3, 8);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.Padding = new System.Windows.Forms.Padding(6);
            this.pnlGroup.Size = new System.Drawing.Size(491, 162);
            this.pnlGroup.TabIndex = 0;
            // 
            // btnDirectPrint
            // 
            this.btnDirectPrint.Location = new System.Drawing.Point(198, 122);
            this.btnDirectPrint.Name = "btnDirectPrint";
            this.btnDirectPrint.Size = new System.Drawing.Size(75, 23);
            this.btnDirectPrint.TabIndex = 25;
            this.btnDirectPrint.Text = "&Direct Print";
            this.btnDirectPrint.UseVisualStyleBackColor = true;
            this.btnDirectPrint.Visible = false;
            this.btnDirectPrint.Click += new System.EventHandler(this.btnDirectPrint_Click);
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(85, 14);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(121, 21);
            this.cmbReportType.TabIndex = 24;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Report Type :";
            // 
            // txtType
            // 
            this.txtType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtType.FormattingEnabled = true;
            this.txtType.Items.AddRange(new object[] {
            "Both",
            "Office hour (8:00 – 16:00)",
            "Special clinic (16:00 – 8:00)"});
            this.txtType.Location = new System.Drawing.Point(83, 73);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(290, 21);
            this.txtType.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Type :";
            // 
            // txtDateTo
            // 
            this.txtDateTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTo.Location = new System.Drawing.Point(289, 47);
            this.txtDateTo.Margin = new System.Windows.Forms.Padding(0);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(180, 20);
            this.txtDateTo.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Date :";
            // 
            // btnRunReport
            // 
            this.btnRunReport.Location = new System.Drawing.Point(289, 122);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(75, 23);
            this.btnRunReport.TabIndex = 2;
            this.btnRunReport.Text = "&Run Report";
            this.btnRunReport.UseVisualStyleBackColor = true;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "-";
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateFrom.Location = new System.Drawing.Point(83, 47);
            this.txtDateFrom.Margin = new System.Windows.Forms.Padding(0);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(180, 20);
            this.txtDateFrom.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(370, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.cmbReportTypeSch);
            this.xtraTabPage2.Controls.Add(this.label10);
            this.xtraTabPage2.Controls.Add(this.txtTypeSch);
            this.xtraTabPage2.Controls.Add(this.label3);
            this.xtraTabPage2.Controls.Add(this.txtDateToSch);
            this.xtraTabPage2.Controls.Add(this.label4);
            this.xtraTabPage2.Controls.Add(this.btnRunReportSch);
            this.xtraTabPage2.Controls.Add(this.label6);
            this.xtraTabPage2.Controls.Add(this.txtDateFromSch);
            this.xtraTabPage2.Controls.Add(this.btnCancleSch);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(502, 250);
            this.xtraTabPage2.Text = "Online Schedule";
            this.xtraTabPage2.Tooltip = "Online Schedule";
            // 
            // cmbReportTypeSch
            // 
            this.cmbReportTypeSch.FormattingEnabled = true;
            this.cmbReportTypeSch.Location = new System.Drawing.Point(84, 20);
            this.cmbReportTypeSch.Name = "cmbReportTypeSch";
            this.cmbReportTypeSch.Size = new System.Drawing.Size(121, 21);
            this.cmbReportTypeSch.TabIndex = 32;
            this.cmbReportTypeSch.SelectedIndexChanged += new System.EventHandler(this.cmbReportTypeSch_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Report Type :";
            // 
            // txtTypeSch
            // 
            this.txtTypeSch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeSch.FormattingEnabled = true;
            this.txtTypeSch.Items.AddRange(new object[] {
            "Both",
            "Office hour (8:00 – 16:00)",
            "Special clinic (16:00 – 8:00)"});
            this.txtTypeSch.Location = new System.Drawing.Point(87, 79);
            this.txtTypeSch.Name = "txtTypeSch";
            this.txtTypeSch.Size = new System.Drawing.Size(290, 21);
            this.txtTypeSch.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Group Type :";
            // 
            // txtDateToSch
            // 
            this.txtDateToSch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateToSch.Location = new System.Drawing.Point(285, 53);
            this.txtDateToSch.Margin = new System.Windows.Forms.Padding(0);
            this.txtDateToSch.Name = "txtDateToSch";
            this.txtDateToSch.Size = new System.Drawing.Size(180, 20);
            this.txtDateToSch.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Date :";
            // 
            // btnRunReportSch
            // 
            this.btnRunReportSch.Location = new System.Drawing.Point(285, 124);
            this.btnRunReportSch.Name = "btnRunReportSch";
            this.btnRunReportSch.Size = new System.Drawing.Size(75, 23);
            this.btnRunReportSch.TabIndex = 24;
            this.btnRunReportSch.Text = "&Run Report";
            this.btnRunReportSch.UseVisualStyleBackColor = true;
            this.btnRunReportSch.Click += new System.EventHandler(this.btnRunReportSch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(269, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "-";
            // 
            // txtDateFromSch
            // 
            this.txtDateFromSch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateFromSch.Location = new System.Drawing.Point(87, 53);
            this.txtDateFromSch.Margin = new System.Windows.Forms.Padding(0);
            this.txtDateFromSch.Name = "txtDateFromSch";
            this.txtDateFromSch.Size = new System.Drawing.Size(180, 20);
            this.txtDateFromSch.TabIndex = 28;
            // 
            // btnCancleSch
            // 
            this.btnCancleSch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancleSch.Location = new System.Drawing.Point(366, 124);
            this.btnCancleSch.Name = "btnCancleSch";
            this.btnCancleSch.Size = new System.Drawing.Size(75, 23);
            this.btnCancleSch.TabIndex = 25;
            this.btnCancleSch.Text = "&Cancel";
            this.btnCancleSch.UseVisualStyleBackColor = true;
            this.btnCancleSch.Click += new System.EventHandler(this.btnCancleSch_Click);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.txtDateToWL);
            this.xtraTabPage3.Controls.Add(this.label8);
            this.xtraTabPage3.Controls.Add(this.btnRunReportWL);
            this.xtraTabPage3.Controls.Add(this.label9);
            this.xtraTabPage3.Controls.Add(this.txtDateFromWL);
            this.xtraTabPage3.Controls.Add(this.btnCancleWL);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(502, 250);
            this.xtraTabPage3.Text = "Online Waiting List";
            this.xtraTabPage3.Tooltip = "Online Waiting List";
            // 
            // txtDateToWL
            // 
            this.txtDateToWL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateToWL.Location = new System.Drawing.Point(275, 46);
            this.txtDateToWL.Margin = new System.Windows.Forms.Padding(0);
            this.txtDateToWL.Name = "txtDateToWL";
            this.txtDateToWL.Size = new System.Drawing.Size(180, 20);
            this.txtDateToWL.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Date :";
            // 
            // btnRunReportWL
            // 
            this.btnRunReportWL.Location = new System.Drawing.Point(275, 101);
            this.btnRunReportWL.Name = "btnRunReportWL";
            this.btnRunReportWL.Size = new System.Drawing.Size(75, 23);
            this.btnRunReportWL.TabIndex = 32;
            this.btnRunReportWL.Text = "&Run Report";
            this.btnRunReportWL.UseVisualStyleBackColor = true;
            this.btnRunReportWL.Click += new System.EventHandler(this.btnRunReportWL_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(260, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 16);
            this.label9.TabIndex = 37;
            this.label9.Text = "-";
            // 
            // txtDateFromWL
            // 
            this.txtDateFromWL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateFromWL.Location = new System.Drawing.Point(76, 46);
            this.txtDateFromWL.Margin = new System.Windows.Forms.Padding(0);
            this.txtDateFromWL.Name = "txtDateFromWL";
            this.txtDateFromWL.Size = new System.Drawing.Size(180, 20);
            this.txtDateFromWL.TabIndex = 36;
            // 
            // btnCancleWL
            // 
            this.btnCancleWL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancleWL.Location = new System.Drawing.Point(356, 101);
            this.btnCancleWL.Name = "btnCancleWL";
            this.btnCancleWL.Size = new System.Drawing.Size(75, 23);
            this.btnCancleWL.TabIndex = 33;
            this.btnCancleWL.Text = "&Cancel";
            this.btnCancleWL.UseVisualStyleBackColor = true;
            this.btnCancleWL.Click += new System.EventHandler(this.btnCancleWL_Click);
            // 
            // frmRSS_StatOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRSS_StatOnline";
            this.Text = "frmRSS_StatOnline";
            this.Load += new System.EventHandler(this.frmRSS_StatOnline_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.pnlGroup.ResumeLayout(false);
            this.pnlGroup.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker txtDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDateFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.Panel pnlGroup;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.ComboBox txtTypeSch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDateToSch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRunReportSch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker txtDateFromSch;
        private System.Windows.Forms.Button btnCancleSch;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private System.Windows.Forms.DateTimePicker txtDateToWL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRunReportWL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker txtDateFromWL;
        private System.Windows.Forms.Button btnCancleWL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.ComboBox cmbReportTypeSch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDirectPrint;
        private System.Windows.Forms.ComboBox txtType;
    }
}