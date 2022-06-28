namespace Envision.NET.Forms.Admin
{
	partial class frmIntegrationConfig
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
			this.groupInfomation = new DevExpress.XtraEditors.GroupControl();
			this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
			this.pnlServer = new System.Windows.Forms.Panel();
			this.cmbServer = new DevExpress.XtraEditors.ComboBoxEdit();
			this.lblServer = new DevExpress.XtraEditors.LabelControl();
			this.pnlWorkStation = new System.Windows.Forms.Panel();
			this.cmbWorkStation = new DevExpress.XtraEditors.ComboBoxEdit();
			this.lblWorkStation = new DevExpress.XtraEditors.LabelControl();
			this.chkUseSocket = new DevExpress.XtraEditors.CheckEdit();
			this.txtSenderIP = new DevExpress.XtraEditors.TextEdit();
			this.groupSender = new DevExpress.XtraEditors.GroupControl();
			this.pnlSenderIP = new System.Windows.Forms.Panel();
			this.lblSenderIP = new DevExpress.XtraEditors.LabelControl();
			this.groupControlReceiver = new DevExpress.XtraEditors.GroupControl();
			this.chkSendORUWhenOwner = new DevExpress.XtraEditors.CheckEdit();
			this.chkSendPrelim = new DevExpress.XtraEditors.CheckEdit();
			this.cmbResultType = new DevExpress.XtraEditors.ComboBoxEdit();
			this.pnlReceiverWebServiceURL = new System.Windows.Forms.Panel();
			this.txtReceiverWebServiceURL = new DevExpress.XtraEditors.TextEdit();
			this.lblReceiverWebServiceURL = new DevExpress.XtraEditors.LabelControl();
			this.pnlReceiverPort = new System.Windows.Forms.Panel();
			this.txtReceiverPort = new DevExpress.XtraEditors.TextEdit();
			this.lblReceiverPort = new DevExpress.XtraEditors.LabelControl();
			this.pnlReceiverIP = new System.Windows.Forms.Panel();
			this.txtReceiverIP = new DevExpress.XtraEditors.TextEdit();
			this.lblReceiverIP = new DevExpress.XtraEditors.LabelControl();
			this.chkSendORU = new DevExpress.XtraEditors.CheckEdit();
			this.chkSendORMMerge = new DevExpress.XtraEditors.CheckEdit();
			this.chkSendORMBidirectional = new DevExpress.XtraEditors.CheckEdit();
			this.chkSendORM = new DevExpress.XtraEditors.CheckEdit();
			this.chkSendADTReconcile = new DevExpress.XtraEditors.CheckEdit();
			this.chkSendADT = new DevExpress.XtraEditors.CheckEdit();
			this.btnSubmit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.groupInfomation)).BeginInit();
			this.groupInfomation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
			this.pnlServer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbServer.Properties)).BeginInit();
			this.pnlWorkStation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbWorkStation.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkUseSocket.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSenderIP.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupSender)).BeginInit();
			this.groupSender.SuspendLayout();
			this.pnlSenderIP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControlReceiver)).BeginInit();
			this.groupControlReceiver.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chkSendORUWhenOwner.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendPrelim.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbResultType.Properties)).BeginInit();
			this.pnlReceiverWebServiceURL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtReceiverWebServiceURL.Properties)).BeginInit();
			this.pnlReceiverPort.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtReceiverPort.Properties)).BeginInit();
			this.pnlReceiverIP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtReceiverIP.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendORU.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendORMMerge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendORMBidirectional.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendORM.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendADTReconcile.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendADT.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupInfomation
			// 
			this.groupInfomation.Controls.Add(this.chkIsActive);
			this.groupInfomation.Controls.Add(this.pnlServer);
			this.groupInfomation.Controls.Add(this.pnlWorkStation);
			this.groupInfomation.Location = new System.Drawing.Point(0, 0);
			this.groupInfomation.Name = "groupInfomation";
			this.groupInfomation.Size = new System.Drawing.Size(518, 66);
			this.groupInfomation.TabIndex = 0;
			this.groupInfomation.Text = "Infomation";
			// 
			// chkIsActive
			// 
			this.chkIsActive.Location = new System.Drawing.Point(6, 45);
			this.chkIsActive.Name = "chkIsActive";
			this.chkIsActive.Properties.Caption = "Active";
			this.chkIsActive.Size = new System.Drawing.Size(75, 19);
			this.chkIsActive.TabIndex = 2;
			// 
			// pnlServer
			// 
			this.pnlServer.Controls.Add(this.cmbServer);
			this.pnlServer.Controls.Add(this.lblServer);
			this.pnlServer.Location = new System.Drawing.Point(261, 23);
			this.pnlServer.Name = "pnlServer";
			this.pnlServer.Size = new System.Drawing.Size(250, 20);
			this.pnlServer.TabIndex = 1;
			// 
			// cmbServer
			// 
			this.cmbServer.Location = new System.Drawing.Point(100, 0);
			this.cmbServer.Name = "cmbServer";
			this.cmbServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbServer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.cmbServer.Size = new System.Drawing.Size(150, 20);
			this.cmbServer.TabIndex = 14;
			// 
			// lblServer
			// 
			this.lblServer.Location = new System.Drawing.Point(3, 3);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(32, 13);
			this.lblServer.TabIndex = 0;
			this.lblServer.Text = "Server";
			// 
			// pnlWorkStation
			// 
			this.pnlWorkStation.Controls.Add(this.cmbWorkStation);
			this.pnlWorkStation.Controls.Add(this.lblWorkStation);
			this.pnlWorkStation.Location = new System.Drawing.Point(5, 23);
			this.pnlWorkStation.Name = "pnlWorkStation";
			this.pnlWorkStation.Size = new System.Drawing.Size(250, 20);
			this.pnlWorkStation.TabIndex = 0;
			// 
			// cmbWorkStation
			// 
			this.cmbWorkStation.Location = new System.Drawing.Point(100, 0);
			this.cmbWorkStation.Name = "cmbWorkStation";
			this.cmbWorkStation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbWorkStation.Size = new System.Drawing.Size(150, 20);
			this.cmbWorkStation.TabIndex = 13;
			this.cmbWorkStation.SelectedIndexChanged += new System.EventHandler(this.cmbWorkStation_SelectedIndexChanged);
			// 
			// lblWorkStation
			// 
			this.lblWorkStation.Location = new System.Drawing.Point(3, 3);
			this.lblWorkStation.Name = "lblWorkStation";
			this.lblWorkStation.Size = new System.Drawing.Size(62, 13);
			this.lblWorkStation.TabIndex = 0;
			this.lblWorkStation.Text = "Work Station";
			// 
			// chkUseSocket
			// 
			this.chkUseSocket.Location = new System.Drawing.Point(6, 23);
			this.chkUseSocket.Name = "chkUseSocket";
			this.chkUseSocket.Properties.Caption = "Use Socket";
			this.chkUseSocket.Size = new System.Drawing.Size(75, 19);
			this.chkUseSocket.TabIndex = 0;
			this.chkUseSocket.CheckedChanged += new System.EventHandler(this.chkUseSocket_CheckedChanged);
			// 
			// txtSenderIP
			// 
			this.txtSenderIP.Location = new System.Drawing.Point(100, 0);
			this.txtSenderIP.Name = "txtSenderIP";
			this.txtSenderIP.Size = new System.Drawing.Size(150, 20);
			this.txtSenderIP.TabIndex = 1;
			// 
			// groupSender
			// 
			this.groupSender.Controls.Add(this.pnlSenderIP);
			this.groupSender.Location = new System.Drawing.Point(0, 72);
			this.groupSender.Name = "groupSender";
			this.groupSender.Size = new System.Drawing.Size(518, 46);
			this.groupSender.TabIndex = 1;
			this.groupSender.Text = "Sender";
			// 
			// pnlSenderIP
			// 
			this.pnlSenderIP.Controls.Add(this.txtSenderIP);
			this.pnlSenderIP.Controls.Add(this.lblSenderIP);
			this.pnlSenderIP.Location = new System.Drawing.Point(5, 23);
			this.pnlSenderIP.Name = "pnlSenderIP";
			this.pnlSenderIP.Size = new System.Drawing.Size(250, 20);
			this.pnlSenderIP.TabIndex = 0;
			// 
			// lblSenderIP
			// 
			this.lblSenderIP.Location = new System.Drawing.Point(3, 3);
			this.lblSenderIP.Name = "lblSenderIP";
			this.lblSenderIP.Size = new System.Drawing.Size(10, 13);
			this.lblSenderIP.TabIndex = 0;
			this.lblSenderIP.Text = "IP";
			// 
			// groupControlReceiver
			// 
			this.groupControlReceiver.Controls.Add(this.chkSendORUWhenOwner);
			this.groupControlReceiver.Controls.Add(this.chkSendPrelim);
			this.groupControlReceiver.Controls.Add(this.cmbResultType);
			this.groupControlReceiver.Controls.Add(this.pnlReceiverWebServiceURL);
			this.groupControlReceiver.Controls.Add(this.pnlReceiverPort);
			this.groupControlReceiver.Controls.Add(this.pnlReceiverIP);
			this.groupControlReceiver.Controls.Add(this.chkSendORU);
			this.groupControlReceiver.Controls.Add(this.chkSendORMMerge);
			this.groupControlReceiver.Controls.Add(this.chkSendORMBidirectional);
			this.groupControlReceiver.Controls.Add(this.chkSendORM);
			this.groupControlReceiver.Controls.Add(this.chkSendADTReconcile);
			this.groupControlReceiver.Controls.Add(this.chkSendADT);
			this.groupControlReceiver.Controls.Add(this.chkUseSocket);
			this.groupControlReceiver.Location = new System.Drawing.Point(0, 124);
			this.groupControlReceiver.Name = "groupControlReceiver";
			this.groupControlReceiver.Size = new System.Drawing.Size(518, 172);
			this.groupControlReceiver.TabIndex = 2;
			this.groupControlReceiver.Text = "Receiver";
			// 
			// chkSendORUWhenOwner
			// 
			this.chkSendORUWhenOwner.Location = new System.Drawing.Point(318, 126);
			this.chkSendORUWhenOwner.Name = "chkSendORUWhenOwner";
			this.chkSendORUWhenOwner.Properties.Caption = "Send ORU When Owner";
			this.chkSendORUWhenOwner.Size = new System.Drawing.Size(150, 19);
			this.chkSendORUWhenOwner.TabIndex = 11;
			// 
			// chkSendPrelim
			// 
			this.chkSendPrelim.Location = new System.Drawing.Point(318, 151);
			this.chkSendPrelim.Name = "chkSendPrelim";
			this.chkSendPrelim.Properties.Caption = "Send Prelim";
			this.chkSendPrelim.Size = new System.Drawing.Size(150, 19);
			this.chkSendPrelim.TabIndex = 12;
			// 
			// cmbResultType
			// 
			this.cmbResultType.Location = new System.Drawing.Point(396, 101);
			this.cmbResultType.Name = "cmbResultType";
			this.cmbResultType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbResultType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.cmbResultType.Size = new System.Drawing.Size(100, 20);
			this.cmbResultType.TabIndex = 10;
			// 
			// pnlReceiverWebServiceURL
			// 
			this.pnlReceiverWebServiceURL.Controls.Add(this.txtReceiverWebServiceURL);
			this.pnlReceiverWebServiceURL.Controls.Add(this.lblReceiverWebServiceURL);
			this.pnlReceiverWebServiceURL.Location = new System.Drawing.Point(5, 75);
			this.pnlReceiverWebServiceURL.Name = "pnlReceiverWebServiceURL";
			this.pnlReceiverWebServiceURL.Size = new System.Drawing.Size(506, 20);
			this.pnlReceiverWebServiceURL.TabIndex = 3;
			// 
			// txtReceiverWebServiceURL
			// 
			this.txtReceiverWebServiceURL.Location = new System.Drawing.Point(100, 0);
			this.txtReceiverWebServiceURL.Name = "txtReceiverWebServiceURL";
			this.txtReceiverWebServiceURL.Size = new System.Drawing.Size(406, 20);
			this.txtReceiverWebServiceURL.TabIndex = 1;
			// 
			// lblReceiverWebServiceURL
			// 
			this.lblReceiverWebServiceURL.Location = new System.Drawing.Point(3, 3);
			this.lblReceiverWebServiceURL.Name = "lblReceiverWebServiceURL";
			this.lblReceiverWebServiceURL.Size = new System.Drawing.Size(82, 13);
			this.lblReceiverWebServiceURL.TabIndex = 0;
			this.lblReceiverWebServiceURL.Text = "Web Service URL";
			// 
			// pnlReceiverPort
			// 
			this.pnlReceiverPort.Controls.Add(this.txtReceiverPort);
			this.pnlReceiverPort.Controls.Add(this.lblReceiverPort);
			this.pnlReceiverPort.Location = new System.Drawing.Point(261, 49);
			this.pnlReceiverPort.Name = "pnlReceiverPort";
			this.pnlReceiverPort.Size = new System.Drawing.Size(250, 20);
			this.pnlReceiverPort.TabIndex = 2;
			// 
			// txtReceiverPort
			// 
			this.txtReceiverPort.Location = new System.Drawing.Point(100, 0);
			this.txtReceiverPort.Name = "txtReceiverPort";
			this.txtReceiverPort.Size = new System.Drawing.Size(150, 20);
			this.txtReceiverPort.TabIndex = 1;
			// 
			// lblReceiverPort
			// 
			this.lblReceiverPort.Location = new System.Drawing.Point(3, 4);
			this.lblReceiverPort.Name = "lblReceiverPort";
			this.lblReceiverPort.Size = new System.Drawing.Size(20, 13);
			this.lblReceiverPort.TabIndex = 0;
			this.lblReceiverPort.Text = "Port";
			// 
			// pnlReceiverIP
			// 
			this.pnlReceiverIP.Controls.Add(this.txtReceiverIP);
			this.pnlReceiverIP.Controls.Add(this.lblReceiverIP);
			this.pnlReceiverIP.Location = new System.Drawing.Point(5, 49);
			this.pnlReceiverIP.Name = "pnlReceiverIP";
			this.pnlReceiverIP.Size = new System.Drawing.Size(250, 20);
			this.pnlReceiverIP.TabIndex = 1;
			// 
			// txtReceiverIP
			// 
			this.txtReceiverIP.Location = new System.Drawing.Point(100, 0);
			this.txtReceiverIP.Name = "txtReceiverIP";
			this.txtReceiverIP.Size = new System.Drawing.Size(150, 20);
			this.txtReceiverIP.TabIndex = 1;
			// 
			// lblReceiverIP
			// 
			this.lblReceiverIP.Location = new System.Drawing.Point(3, 3);
			this.lblReceiverIP.Name = "lblReceiverIP";
			this.lblReceiverIP.Size = new System.Drawing.Size(10, 13);
			this.lblReceiverIP.TabIndex = 0;
			this.lblReceiverIP.Text = "IP";
			// 
			// chkSendORU
			// 
			this.chkSendORU.Location = new System.Drawing.Point(318, 101);
			this.chkSendORU.Name = "chkSendORU";
			this.chkSendORU.Properties.Caption = "Send ORU";
			this.chkSendORU.Size = new System.Drawing.Size(72, 19);
			this.chkSendORU.TabIndex = 9;
			this.chkSendORU.CheckedChanged += new System.EventHandler(this.chkSendORU_CheckedChanged);
			// 
			// chkSendORMMerge
			// 
			this.chkSendORMMerge.Location = new System.Drawing.Point(162, 151);
			this.chkSendORMMerge.Name = "chkSendORMMerge";
			this.chkSendORMMerge.Properties.Caption = "Send ORM Merge";
			this.chkSendORMMerge.Size = new System.Drawing.Size(150, 19);
			this.chkSendORMMerge.TabIndex = 8;
			// 
			// chkSendORMBidirectional
			// 
			this.chkSendORMBidirectional.Location = new System.Drawing.Point(162, 126);
			this.chkSendORMBidirectional.Name = "chkSendORMBidirectional";
			this.chkSendORMBidirectional.Properties.Caption = "Send ORM Bidirectional";
			this.chkSendORMBidirectional.Size = new System.Drawing.Size(150, 19);
			this.chkSendORMBidirectional.TabIndex = 7;
			// 
			// chkSendORM
			// 
			this.chkSendORM.Location = new System.Drawing.Point(162, 101);
			this.chkSendORM.Name = "chkSendORM";
			this.chkSendORM.Properties.Caption = "Send ORM";
			this.chkSendORM.Size = new System.Drawing.Size(150, 19);
			this.chkSendORM.TabIndex = 6;
			// 
			// chkSendADTReconcile
			// 
			this.chkSendADTReconcile.Location = new System.Drawing.Point(6, 126);
			this.chkSendADTReconcile.Name = "chkSendADTReconcile";
			this.chkSendADTReconcile.Properties.Caption = "Send ADT Reconcile";
			this.chkSendADTReconcile.Size = new System.Drawing.Size(150, 19);
			this.chkSendADTReconcile.TabIndex = 5;
			// 
			// chkSendADT
			// 
			this.chkSendADT.Location = new System.Drawing.Point(6, 101);
			this.chkSendADT.Name = "chkSendADT";
			this.chkSendADT.Properties.Caption = "Send ADT";
			this.chkSendADT.Size = new System.Drawing.Size(150, 19);
			this.chkSendADT.TabIndex = 4;
			// 
			// btnSubmit
			// 
			this.btnSubmit.Location = new System.Drawing.Point(443, 302);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(75, 23);
			this.btnSubmit.TabIndex = 3;
			this.btnSubmit.Text = "Submit";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// frmIntegrationConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(826, 639);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.groupControlReceiver);
			this.Controls.Add(this.groupSender);
			this.Controls.Add(this.groupInfomation);
			this.Name = "frmIntegrationConfig";
			this.Text = "Integration Config";
			this.Load += new System.EventHandler(this.frmIntegrationConfig_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupInfomation)).EndInit();
			this.groupInfomation.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
			this.pnlServer.ResumeLayout(false);
			this.pnlServer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbServer.Properties)).EndInit();
			this.pnlWorkStation.ResumeLayout(false);
			this.pnlWorkStation.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbWorkStation.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkUseSocket.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSenderIP.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupSender)).EndInit();
			this.groupSender.ResumeLayout(false);
			this.pnlSenderIP.ResumeLayout(false);
			this.pnlSenderIP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControlReceiver)).EndInit();
			this.groupControlReceiver.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chkSendORUWhenOwner.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendPrelim.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbResultType.Properties)).EndInit();
			this.pnlReceiverWebServiceURL.ResumeLayout(false);
			this.pnlReceiverWebServiceURL.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtReceiverWebServiceURL.Properties)).EndInit();
			this.pnlReceiverPort.ResumeLayout(false);
			this.pnlReceiverPort.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtReceiverPort.Properties)).EndInit();
			this.pnlReceiverIP.ResumeLayout(false);
			this.pnlReceiverIP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtReceiverIP.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendORU.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendORMMerge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendORMBidirectional.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendORM.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendADTReconcile.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSendADT.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.GroupControl groupInfomation;
		private DevExpress.XtraEditors.LabelControl lblWorkStation;
		private DevExpress.XtraEditors.LabelControl lblServer;
		private DevExpress.XtraEditors.CheckEdit chkUseSocket;
		private DevExpress.XtraEditors.TextEdit txtSenderIP;
		private DevExpress.XtraEditors.GroupControl groupSender;
		private DevExpress.XtraEditors.LabelControl lblSenderIP;
		private DevExpress.XtraEditors.GroupControl groupControlReceiver;
		private DevExpress.XtraEditors.LabelControl lblReceiverPort;
		private DevExpress.XtraEditors.LabelControl lblReceiverIP;
		private DevExpress.XtraEditors.TextEdit txtReceiverIP;
		private DevExpress.XtraEditors.TextEdit txtReceiverWebServiceURL;
		private DevExpress.XtraEditors.LabelControl lblReceiverWebServiceURL;
		private DevExpress.XtraEditors.CheckEdit chkSendORMMerge;
		private DevExpress.XtraEditors.CheckEdit chkSendORMBidirectional;
		private DevExpress.XtraEditors.CheckEdit chkSendORM;
		private DevExpress.XtraEditors.CheckEdit chkSendADTReconcile;
		private DevExpress.XtraEditors.CheckEdit chkSendADT;
		private DevExpress.XtraEditors.ComboBoxEdit cmbResultType;
		private DevExpress.XtraEditors.CheckEdit chkSendPrelim;
		private DevExpress.XtraEditors.CheckEdit chkSendORUWhenOwner;
		private DevExpress.XtraEditors.CheckEdit chkSendORU;
		private System.Windows.Forms.Panel pnlWorkStation;
		private System.Windows.Forms.Panel pnlServer;
		private System.Windows.Forms.Panel pnlSenderIP;
		private System.Windows.Forms.Panel pnlReceiverWebServiceURL;
		private System.Windows.Forms.Panel pnlReceiverPort;
		private System.Windows.Forms.Panel pnlReceiverIP;
		private DevExpress.XtraEditors.ComboBoxEdit cmbServer;
		private DevExpress.XtraEditors.ComboBoxEdit cmbWorkStation;
		private System.Windows.Forms.Button btnSubmit;
		private DevExpress.XtraEditors.TextEdit txtReceiverPort;
		private DevExpress.XtraEditors.CheckEdit chkIsActive;
	}
}