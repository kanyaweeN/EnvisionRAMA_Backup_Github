using System;
using System.Data;
using System.Net.Sockets;
using EnvisionInterfaceEngine.Common;
using EnvisionInterfaceEngine.Common.Global;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Connection;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;
using EnvisionInterfaceEngine.Operational.HL7;
using EnvisionInterfaceEngine.Operational.MSMQ;
using EnvisionInterfaceEngine.WebService;

namespace EnvisionIEReceiver
{
	public class Receiver : IDisposable
	{
		private readonly string title_log;
		private bool disposed = false;

		private DataView dv_3rd_party;

		public Receiver() { title_log = ToString(); }
		~Receiver()
		{
			if (!disposed)
				Dispose();
		}

		public void Invoke()
		{
			Utilities.SaveLog(title_log, "Invoke()", "Begin", false);

			RISConnection ris = new RISConnection();
			dv_3rd_party = ris.selectDataIntegrationConfig().DefaultView;

			try
			{
				using (HL7SocketEngine socket_engine = new HL7SocketEngine(ConfigService.LocalIP, ConfigService.LocalPort))
				{
					socket_engine.ReceiveCompleted += new ReceiveSocketCompleted(onMessageReceiveCompleted);
					socket_engine.Listen();
				}
			}
			catch (Exception ex)
			{
				Utilities.SaveLog(title_log, "Invoke()", ex.Message, true);
			}
		}
		public void Dispose()
		{
			Utilities.SaveLog(title_log, "Invoke()", "End", false);

			disposed = true;
		}

		private void onMessageReceiveCompleted(object sender, ReceiveSocketEventArgs e)
		{
			if (e.SocketStatus == SocketError.Success && Utilities.HasData(e.Messages))
			{
				Socket socket = (Socket)sender;

				foreach (string item in e.Messages)
					HL7SocketEngine.Send(socket, GenerateACK.ConvertToHL7(SendMessageQueue(e.WorkStationId, e.WorkStationUid, e.ServerUid, item)));
			}
		}

		private HL7ACK SendMessageQueue(int workStationId, string workStationUid, string serverUid, string hl7Text)
		{
			RIS_HL7IELOG log = new RIS_HL7IELOG();
			log.SENDER_ID = 0;
			log.RECEIVER_ID = 0;
			log.HL7_TEXT = hl7Text;

			RISConnection ris = new RISConnection();
			EnvisionIEPreSyncParams ws_params = new EnvisionIEPreSyncParams(Config.DomainWebService);

			string message_control_id = string.Empty;

			object[] result;

			if (serverUid.ToLower() == "synapse")
			{
				result = new object[3];

				result[0] = "AA";
				result[1] = "ORM_BDR";
				result[2] = GenerateORM.ConvertToObjectFromBidirectional(hl7Text);
			}
			else
				result = HL7Manager.ConvertHL7ToObject(hl7Text);

			if (result[0].ToString() == "AA")
			{
				switch (result[1].ToString())
				{
					case "ADT_A08":
					case "ADT_A18":
						using (HL7ADT hl7_adt = (HL7ADT)result[2])
						{
							dv_3rd_party.RowFilter = string.Format("WORK_STATION_UID = '{0}'", hl7_adt.MSH.SENDING_APPLICATION);
							if (Utilities.HasData(dv_3rd_party))
								workStationId = Utilities.ToInt(dv_3rd_party[0]["WORK_STATION_ID"].ToString());

							message_control_id = hl7_adt.MSH.MESSAGE_CONTROL_ID;

							hl7_adt.ORG.ORG_ID = ConfigService.DefaultOrgId;

							selectOrg(hl7_adt.ORG);

							dv_3rd_party.RowFilter = string.Format("WORK_STATION_UID = '{0}'", hl7_adt.MSH.SENDING_APPLICATION);

							log.SENDER_ID = workStationId; 
							log.MESSAGE_TYPE = "ADT";
							log.EVENT_TYPE = result[1].ToString().Substring(4);
							log.HN = hl7_adt.PATIENT.HN;
							log.COMPARE_VALUE = hl7_adt.OLD_PATIENT.HN;
							log.ORG_ID = hl7_adt.ORG.ORG_ID;
							log.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

							string reject_message = string.Empty;

							if ((reject_message = checkRequireDataPatient(hl7_adt)) != string.Empty)
							{
								log.ACKNOWLEDGMENT_CODE = "AR";
								log.TEXT_MESSAGE = reject_message;
							}
							else
							{
								log.ACKNOWLEDGMENT_CODE = "AA";
								log.TEXT_MESSAGE = "Message validated";

								log.LOG_ID = ris.addRisHL7IELog(log);

								if (!MSMQManager.Send(Config.HL7ADTQueuePath, log.LOG_ID.ToString(), hl7Text))
								{
									log.ACKNOWLEDGMENT_CODE = "AE";
									log.TEXT_MESSAGE = "Send message queue fail";
								}
							}

							ris.updateRisHL7IELog(log);
						}
						break;
					case "ORM_O01":
						using (HL7ORM hl7_orm = (HL7ORM)result[2])
						{
							dv_3rd_party.RowFilter = string.Format("WORK_STATION_UID = '{0}'", hl7_orm.MSH.SENDING_APPLICATION);
							if (Utilities.HasData(dv_3rd_party))
								workStationId = Utilities.ToInt(dv_3rd_party[0]["WORK_STATION_ID"].ToString());

							message_control_id = hl7_orm.MSH.MESSAGE_CONTROL_ID;

							hl7_orm.ORDER_DETAIL.WORK_STATION_ID = workStationId;
							hl7_orm.ORG.ORG_ID = ConfigService.DefaultOrgId;

							selectOrg(hl7_orm.ORG);

							log.SENDER_ID = workStationId;
							log.MESSAGE_TYPE = "ORM";
							log.EVENT_TYPE = "O01";
							log.HN = hl7_orm.PATIENT.HN;
							log.ACCESSION_NO = hl7_orm.ORDER_DETAIL.ACCESSION_NO;
							log.ORG_ID = hl7_orm.ORG.ORG_ID;
							log.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

							string reject_message = string.Empty;

							if ((reject_message = checkRequireDataOrder(hl7_orm)) != string.Empty)
							{
								log.ACKNOWLEDGMENT_CODE = "AR";
								log.TEXT_MESSAGE = reject_message;
							}
							else
							{
								log.ACKNOWLEDGMENT_CODE = "AA";
								log.TEXT_MESSAGE = "Message validated";

								log.LOG_ID = ris.addRisHL7IELog(log);

								if (!MSMQManager.Send(Config.HL7ORMQueuePath, log.LOG_ID.ToString(), hl7Text))
								{
									log.ACKNOWLEDGMENT_CODE = "AE";
									log.TEXT_MESSAGE = "Send message queue fail";
								}

								ris.updateRisHL7IELog(log);
							}
						}
						break;
					case "ORM_BDR":
						using (HL7ORM hl7_orm = (HL7ORM)result[2])
						{
							dv_3rd_party.RowFilter = string.Format("WORK_STATION_UID = '{0}'", hl7_orm.MSH.SENDING_APPLICATION);
							if (Utilities.HasData(dv_3rd_party))
								workStationId = Utilities.ToInt(dv_3rd_party[0]["WORK_STATION_ID"].ToString());

							message_control_id = hl7_orm.MSH.MESSAGE_CONTROL_ID;

							hl7_orm.ORG.ORG_ID = ConfigService.DefaultOrgId;

							selectOrg(hl7_orm.ORG);

							log.SENDER_ID = workStationId;
							log.MESSAGE_TYPE = "ORM";
							log.EVENT_TYPE = "BDR";
							log.HN = hl7_orm.PATIENT.HN;
							log.ACCESSION_NO = hl7_orm.ORDER_DETAIL.ACCESSION_NO;
							log.ORG_ID = hl7_orm.ORG.ORG_ID;
							log.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

							string reject_message = string.Empty;

							if ((reject_message = checkRequireDataOrder(hl7_orm)) != string.Empty)
							{
								log.ACKNOWLEDGMENT_CODE = "AR";
								log.TEXT_MESSAGE = reject_message;
							}
							else
							{
								log.ACKNOWLEDGMENT_CODE = "AA";
								log.TEXT_MESSAGE = "Message validated";

								log.LOG_ID = ris.addRisHL7IELog(log);

								if (!MSMQManager.Send(Config.HL7ORMBidirectionalQueuePath, log.LOG_ID.ToString(), hl7Text))
								{
									log.ACKNOWLEDGMENT_CODE = "AE";
									log.TEXT_MESSAGE = "Send message queue fail";
								}

								ris.updateRisHL7IELog(log);
							}
						}
						break;
				}
			}
			else
			{
				log.ACKNOWLEDGMENT_CODE = result[0].ToString();
				log.TEXT_MESSAGE = result[2].ToString();

				Utilities.SaveLog(title_log, "SendMessageQueue(string workStationUid, string universalID, string hl7Text)", string.Format("{0} {1} {2}", log.ACKNOWLEDGMENT_CODE, log.TEXT_MESSAGE, Utilities.ToCleanString(hl7Text)), true);
			}

			HL7ACK hl7_ack = new HL7ACK();
			hl7_ack.MSH.MESSAGE_CONTROL_ID = message_control_id;
			hl7_ack.MSA.ACKNOWLEDGMENT_CODE = log.ACKNOWLEDGMENT_CODE;
			hl7_ack.MSA.TEXT_MESSAGE = log.TEXT_MESSAGE;

			return hl7_ack;
		}

		private string checkRequireDataPatient(HL7ADT adt)
		{
			string flag = string.Empty;

			if (string.IsNullOrEmpty(adt.PATIENT.HN))
				flag = "Patient ID(Internal ID) is null";
			else if (adt.PATIENT.HN.Length > 30)
				flag = "Patient ID(Internal ID) length are over limited";

			return flag;
		}
		private string checkRequireDataOrder(HL7ORM orm)
		{
			string flag = string.Empty;

			if (orm.ORDER_DETAIL.IS_DELETED == 'N')
			{
				if (string.IsNullOrEmpty(orm.PATIENT.HN))
					flag = "Patient ID(Internal ID) is null";
				else if (orm.PATIENT.HN.Length > 30)
					flag = "Patient ID(Internal ID) length are over limited";
				else if (!string.IsNullOrEmpty(orm.ORDER_DETAIL.ACCESSION_NO)
					&& orm.ORDER_DETAIL.ACCESSION_NO.Length > 16)
					flag = "Accession Number length are over limited";
				else if (string.IsNullOrEmpty(orm.EXAM.EXAM_UID))
					flag = "Universal service ID is null";
			}
			else if (string.IsNullOrEmpty(orm.ORDER_DETAIL.ACCESSION_NO))
				flag = "Accession Number is null";

			return flag;
		}

		private void selectOrg(GBL_ENV org)
		{
			using (DataTable dtt = new RISConnection().selectDataExistsOrgByOrgAlias(org.ORG_ALIAS))
			{
				if (Utilities.HasData(dtt))
					org.ORG_ID = Convert.ToInt32(dtt.Rows[0]["ORG_ID"].ToString());
			}
		}
	}
}