using System;
using System.Data;
using System.Windows.Forms;
using RIS.Common;
using RIS.BusinessLogic;

namespace RIS.Forms.Admin
{
	public partial class frmIntegrationConfig : Form
	{
        private UUL.ControlFrame.Controls.TabControl CloseControl;
		private DataView dv_integration_config;
		private DataView dv_integration_servers;

		private int work_station_id;

        public frmIntegrationConfig(UUL.ControlFrame.Controls.TabControl Cls)
        {
            InitializeComponent();
            CloseControl = Cls;
            CloseControl.ClosePressed += new EventHandler(CloseControl_ClosePressed);
        }
        void CloseControl_ClosePressed(object sender, EventArgs e)
        {
            this.Close();
        }
        

		private void frmIntegrationConfig_Load(object sender, EventArgs e)
		{
			initForm();
		}

		public void initForm()
		{
			work_station_id = 0;

			loadDataResultType();
			loadDataRisIntegrationServers();
			loadDataRisIntegrationConfig();

			if (cmbWorkStation.Properties.Items.Count > 0)
				cmbWorkStation.SelectedIndex = 0;
		}

		private void cmbWorkStation_SelectedIndexChanged(object sender, EventArgs e) { selectWorkStation(); }
		private void chkUseSocket_CheckedChanged(object sender, EventArgs e) { checkUseSocket(); }
		private void chkSendORU_CheckedChanged(object sender, EventArgs e) { checkSendORU(); }
		private void btnSubmit_Click(object sender, EventArgs e) { saveWorkstation(); }

		private void selectWorkStation()
		{
			dv_integration_config.RowFilter = string.Format("WORK_STATION_UID = '{0}'", cmbWorkStation.Text);

			if (dv_integration_config.Count > 0)
			{
				DataRowView drv = dv_integration_config[0];

				work_station_id = Convert.ToInt32(drv["WORK_STATION_ID"]);

				dv_integration_servers.RowFilter = string.Format("SERVER_ID = {0}", drv["SERVER_ID"]);
				if (dv_integration_servers.Count > 0)
					cmbServer.Text = dv_integration_servers[0]["SERVER_UID"].ToString();
				else
					cmbServer.SelectedIndex = 0;

				chkUseSocket.Checked = Convert.ToBoolean(drv["USE_SOCKET"]);
				txtSenderIP.Text = drv["SENDER_IP"].ToString();

				txtReceiverIP.Text = drv["RECEIVER_IP"].ToString();
				txtReceiverPort.Text = drv["RECEIVER_PORT"].ToString();
				txtReceiverWebServiceURL.Text = drv["WEB_SERVICE_URL"].ToString();
				chkSendADT.Checked = Convert.ToBoolean(drv["SEND_ADT"]);
				chkSendADTReconcile.Checked = Convert.ToBoolean(drv["SEND_ADT_RECONCILE"]);
				chkSendORM.Checked = Convert.ToBoolean(drv["SEND_ORM"]);
				chkSendORMBidirectional.Checked = Convert.ToBoolean(drv["SEND_ORM_BIDIRECTIONAL"]);
				chkSendORMMerge.Checked = Convert.ToBoolean(drv["SEND_ORM_MERGE"]);
				chkSendORU.Checked = Convert.ToBoolean(drv["SEND_ORU"]);
				chkSendORUWhenOwner.Checked = Convert.ToBoolean(drv["SEND_ORU_WHEN_OWNER"]);
				chkSendPrelim.Checked = Convert.ToBoolean(drv["SEND_PRELIM"]);
				cmbResultType.Text = drv["RESULT_TYPE"].ToString();
				chkIsActive.Checked = Convert.ToBoolean(drv["IS_ACTIVE"]);
			}
		}
		private void checkUseSocket()
		{
			pnlReceiverIP.Enabled = false;
			pnlReceiverPort.Enabled = false;
			pnlReceiverWebServiceURL.Enabled = false;

			bool use_socket = chkUseSocket.Checked;

			if (use_socket)
			{
				pnlReceiverIP.Enabled = true;
				pnlReceiverPort.Enabled = true;
			}
			else
				pnlReceiverWebServiceURL.Enabled = true;
		}
		private void checkSendORU()
		{
			bool enable = chkSendORU.Checked;

			cmbResultType.Enabled = enable;

			chkSendORUWhenOwner.Enabled = enable;
			chkSendPrelim.Enabled = enable;
		}

		private void saveWorkstation()
		{
			int server_id = 0;

			dv_integration_servers.RowFilter = string.Format("SERVER_UID = '{0}'", cmbServer.Text);
			if (dv_integration_servers.Count > 0)
				server_id = Convert.ToInt32(dv_integration_servers[0]["SERVER_ID"]);

			RIS_INTEGRATIONCONFIG parameter = new RIS_INTEGRATIONCONFIG();
			parameter.WORK_STATION_ID = work_station_id;
			parameter.WORK_STATION_UID = cmbWorkStation.Text;
			parameter.SERVER_ID = server_id;
			parameter.USE_SOCKET = chkUseSocket.Checked;
			parameter.RECEIVER_IP = txtReceiverIP.Text;
			parameter.RECEIVER_PORT = string.IsNullOrEmpty(txtReceiverPort.Text) ? 0 : Convert.ToInt32(txtReceiverPort.Text);
			parameter.SENDER_IP = txtSenderIP.Text;
			parameter.WEB_SERVICE_URL = txtReceiverWebServiceURL.Text;
			parameter.SEND_ADT = chkSendADT.Checked;
			parameter.SEND_ADT_RECONCILE = chkSendADTReconcile.Checked;
			parameter.SEND_ORM = chkSendORM.Checked;
			parameter.SEND_ORM_BIDIRECTIONAL = chkSendORMBidirectional.Checked;
			parameter.SEND_ORM_MERGE = chkSendORMMerge.Checked;
			parameter.SEND_ORU = chkSendORU.Checked;
			parameter.SEND_ORU_WHEN_OWNER = chkSendORUWhenOwner.Checked;
			parameter.SEND_PRELIM = chkSendPrelim.Checked;
			parameter.RESULT_TYPE = cmbResultType.Text;
			parameter.IS_ACTIVE = chkIsActive.Checked;

			ProcessGetRISIntegrationConfig prc_select = new ProcessGetRISIntegrationConfig();
			prc_select.RIS_INTEGRATIONCONFIG = parameter;

			if (prc_select.InvokeCheckUnique())
			{
				ProcessUpdateRISIntegrationConfig prc_update = new ProcessUpdateRISIntegrationConfig();
				prc_update.RIS_INTEGRATIONCONFIG = parameter;
				prc_update.Invoke();

				MessageBox.Show("Update success");

				loadDataRisIntegrationConfig();

				cmbWorkStation.Text = parameter.WORK_STATION_UID;
			}
			else
				MessageBox.Show("Work Station Uid not unique");
		}

		private void loadDataResultType()
		{
			cmbResultType.Properties.Items.Clear();
			cmbResultType.Properties.Items.AddRange(new string[] {
				"PLAIN",
				"RTF",
				"HTML"
			});
		}
		private void loadDataRisIntegrationConfig()
		{
			cmbWorkStation.Properties.Items.Clear();

			ProcessGetRISIntegrationConfig prc = new ProcessGetRISIntegrationConfig();
			prc.Invoke();

			dv_integration_config = prc.Result.Tables[0].DefaultView;

			foreach (DataRowView drv in dv_integration_config)
				cmbWorkStation.Properties.Items.Add(drv["WORK_STATION_UID"].ToString());
		}
		private void loadDataRisIntegrationServers()
		{
			cmbServer.Properties.Items.Clear();

			ProcessGetRISIntegrationServers prc = new ProcessGetRISIntegrationServers();
			prc.Invoke();

			dv_integration_servers = prc.Result.Tables[0].DefaultView;

			foreach (DataRowView drv in dv_integration_servers)
				cmbServer.Properties.Items.Add(drv["SERVER_UID"].ToString());
		}
	}
}
