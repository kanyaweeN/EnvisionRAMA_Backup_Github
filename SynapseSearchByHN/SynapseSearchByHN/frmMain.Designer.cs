namespace SynapseSearchByHN
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtHN = new System.Windows.Forms.TextBox();
            this.txtSuggestion = new System.Windows.Forms.Label();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.linkURL = new System.Windows.Forms.LinkLabel();
            this.txtFooter = new System.Windows.Forms.Label();
            this.cmbHos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHN
            // 
            this.txtHN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHN.Location = new System.Drawing.Point(67, 29);
            this.txtHN.Name = "txtHN";
            this.txtHN.Size = new System.Drawing.Size(183, 22);
            this.txtHN.TabIndex = 0;
            this.txtHN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHN.TextChanged += new System.EventHandler(this.txtHN_TextChanged);
            this.txtHN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHN_KeyPress);
            // 
            // txtSuggestion
            // 
            this.txtSuggestion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSuggestion.ForeColor = System.Drawing.Color.Red;
            this.txtSuggestion.Location = new System.Drawing.Point(69, 53);
            this.txtSuggestion.Name = "txtSuggestion";
            this.txtSuggestion.Size = new System.Drawing.Size(183, 15);
            this.txtSuggestion.TabIndex = 6;
            this.txtSuggestion.Text = "กรุณาใส่ HN และกด Enter";
            this.txtSuggestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgLogo
            // 
            this.imgLogo.Image = global::SynapseSearchByHN.Properties.Resources.MiracleLogo;
            this.imgLogo.Location = new System.Drawing.Point(3, 3);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(60, 60);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 3;
            this.imgLogo.TabStop = false;
            this.imgLogo.DoubleClick += new System.EventHandler(this.imgLogo_DoubleClick);
            // 
            // linkURL
            // 
            this.linkURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkURL.AutoSize = true;
            this.linkURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkURL.Location = new System.Drawing.Point(0, 65);
            this.linkURL.Name = "linkURL";
            this.linkURL.Size = new System.Drawing.Size(23, 13);
            this.linkURL.TabIndex = 7;
            this.linkURL.TabStop = true;
            this.linkURL.Text = "link";
            this.linkURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkURL_LinkClicked);
            // 
            // txtFooter
            // 
            this.txtFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFooter.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtFooter.Location = new System.Drawing.Point(101, 68);
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.Size = new System.Drawing.Size(151, 10);
            this.txtFooter.TabIndex = 8;
            this.txtFooter.Text = "Copyright © 2015 JF Advance Med.";
            this.txtFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbHos
            // 
            this.cmbHos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHos.FormattingEnabled = true;
            this.cmbHos.Location = new System.Drawing.Point(67, 3);
            this.cmbHos.Name = "cmbHos";
            this.cmbHos.Size = new System.Drawing.Size(183, 24);
            this.cmbHos.TabIndex = 10;
            this.cmbHos.SelectedIndexChanged += new System.EventHandler(this.cmbHos_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(254, 81);
            this.Controls.Add(this.cmbHos);
            this.Controls.Add(this.linkURL);
            this.Controls.Add(this.txtHN);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.txtFooter);
            this.Controls.Add(this.txtSuggestion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ชื่อโรงพยาบาล";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSynapseSearchByHN_Load);
            this.Activated += new System.EventHandler(this.frmSynapseSearchByHN_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSynapseSearchByHN_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHN;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Label txtSuggestion;
        private System.Windows.Forms.LinkLabel linkURL;
        private System.Windows.Forms.Label txtFooter;
        private System.Windows.Forms.ComboBox cmbHos;
    }
}

