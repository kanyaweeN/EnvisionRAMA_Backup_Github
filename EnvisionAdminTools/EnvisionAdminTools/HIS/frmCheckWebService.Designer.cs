namespace EnvisionAdminTools.HIS
{
    partial class frmCheckWebService
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
            this.txtURL = new DevExpress.XtraEditors.TextEdit();
            this.btnGet = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnShowdata = new DevExpress.XtraEditors.SimpleButton();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lstParam = new DevExpress.XtraEditors.ListBoxControl();
            this.propMethod = new System.Windows.Forms.PropertyGrid();
            this.lstMethod = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMethod)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(101, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Adress";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(146, 16);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(636, 20);
            this.txtURL.TabIndex = 1;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(788, 14);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 3;
            this.btnGet.Text = "Invoke";
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 42);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(946, 404);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnShowdata);
            this.xtraTabPage1.Controls.Add(this.txtResult);
            this.xtraTabPage1.Controls.Add(this.btnTest);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.lstParam);
            this.xtraTabPage1.Controls.Add(this.propMethod);
            this.xtraTabPage1.Controls.Add(this.lstMethod);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(937, 373);
            this.xtraTabPage1.Text = "WSDL Details";
            // 
            // btnShowdata
            // 
            this.btnShowdata.Enabled = false;
            this.btnShowdata.Location = new System.Drawing.Point(773, 32);
            this.btnShowdata.Name = "btnShowdata";
            this.btnShowdata.Size = new System.Drawing.Size(161, 23);
            this.btnShowdata.TabIndex = 7;
            this.btnShowdata.Text = "show data";
            this.btnShowdata.Click += new System.EventHandler(this.btnShowdata_Click);
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.White;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtResult.Location = new System.Drawing.Point(423, 61);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(511, 309);
            this.txtResult.TabIndex = 6;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(423, 32);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "∑¥ Õ∫";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(231, 13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Parameter List";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(64, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Method List ";
            // 
            // lstParam
            // 
            this.lstParam.Location = new System.Drawing.Point(192, 32);
            this.lstParam.Name = "lstParam";
            this.lstParam.Size = new System.Drawing.Size(225, 136);
            this.lstParam.TabIndex = 2;
            this.lstParam.SelectedIndexChanged += new System.EventHandler(this.lstParam_SelectedIndexChanged);
            // 
            // propMethod
            // 
            this.propMethod.Location = new System.Drawing.Point(192, 174);
            this.propMethod.Name = "propMethod";
            this.propMethod.Size = new System.Drawing.Size(225, 196);
            this.propMethod.TabIndex = 1;
            // 
            // lstMethod
            // 
            this.lstMethod.Location = new System.Drawing.Point(5, 32);
            this.lstMethod.Name = "lstMethod";
            this.lstMethod.Size = new System.Drawing.Size(181, 338);
            this.lstMethod.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.lstMethod.TabIndex = 0;
            this.lstMethod.SelectedIndexChanged += new System.EventHandler(this.lstMethod_SelectedIndexChanged);
            // 
            // frmCheckWebService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(970, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmCheckWebService";
            this.Text = "WSDL Check";
            this.Load += new System.EventHandler(this.frmCheckWebService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMethod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtURL;
        private DevExpress.XtraEditors.SimpleButton btnGet;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.ListBoxControl lstMethod;
        private System.Windows.Forms.PropertyGrid propMethod;
        private DevExpress.XtraEditors.ListBoxControl lstParam;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private System.Windows.Forms.TextBox txtResult;
        private DevExpress.XtraEditors.SimpleButton btnShowdata;

    }
}