using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Common.Miracle;
using EnvisionInterfaceEngine.Operational;
using EnvisionInterfaceEngine.Operational.HL7;

namespace EnvisionInterfaceEngine.Connection.Engine
{
	public class HL7SocketEngine : IDisposable
	{
		private readonly string title_log;
		private bool disposed = false;

		public event ReceiveSocketCompleted ReceiveCompleted;

		private ManualResetEvent manual_event;
		private Socket server_socket;
		private DataView dv_integration;

		private string address_host;
		private int address_port;

		public HL7SocketEngine(string host, int port)
		{
			title_log = ToString();

			address_host = host;
			address_port = port;

			server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}
		~HL7SocketEngine()
		{
			if (!disposed)
				Dispose();
		}

		public void Dispose()
		{
			if (dv_integration != null)
				dv_integration = null;

			if (server_socket != null)
			{
				server_socket.Close();
				server_socket = null;
			}

			disposed = true;
		}

		public void Connect() { server_socket.Connect(new IPEndPoint(Dns.GetHostAddresses(address_host)[0], address_port)); }

		/// <summary>
		/// Send socket double handshake.
		/// </summary>
		public HL7ACK Send(string message)
		{
			SocketError socket_error = Send(server_socket, message);
			HL7ACK hl7_ack = new HL7ACK();

			if (socket_error == SocketError.Success)
			{
				string[] message_receive;

				socket_error = Receive(server_socket, out message_receive);

				if (socket_error != SocketError.Success)
				{
					hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
					hl7_ack.MSA.TEXT_MESSAGE = string.Format("Receiver have error is {0}", socket_error);
				}
				else if (message_receive.Length > 0)
					hl7_ack = GenerateACK.ConvertToObject(message_receive[0]);
				else
				{
					hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
					hl7_ack.MSA.TEXT_MESSAGE = "Receiver not acknowledgment back";
				}
			}
			else
			{
				hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
				hl7_ack.MSA.TEXT_MESSAGE = string.Format("Sent have error {0}", socket_error);
			}

			if (hl7_ack.MSA.ACKNOWLEDGMENT_CODE != "AA")
				Utilities.SaveLog(title_log, "Send(string message)", string.Format("{0} : {1} {2}", hl7_ack.MSH.MESSAGE_CONTROL_ID, hl7_ack.MSA.ACKNOWLEDGMENT_CODE, hl7_ack.MSA.TEXT_MESSAGE), true);

			return hl7_ack;
		}

		/// <summary>
		/// Need to declare event ReceivedEvent first.
		/// </summary>
		public void Listen()
		{
			manual_event = new ManualResetEvent(false);

			//IPAddress address;

			//if (string.IsNullOrEmpty(address_host))
			//    address = IPAddress.Any;
			//else if (IPAddress.TryParse(address_host, out address)) { }
			//else
			//{
			//    IPAddress[] ips = Dns.GetHostAddresses(address_host);

			//    foreach (IPAddress item in ips)
			//    {
			//        if (item.AddressFamily == AddressFamily.InterNetwork)
			//        {
			//            address = item;
			//            break;
			//        }
			//    }
			//}

			server_socket.Bind(new IPEndPoint(string.IsNullOrEmpty(address_host) ? IPAddress.Any : Dns.GetHostAddresses(address_host)[0], address_port));
			server_socket.Listen(128);

			dv_integration = new RISConnection().selectDataIntegrationConfig().DefaultView;

			do
			{
				manual_event.Reset();
				server_socket.BeginAccept(AcceptAsyncResult, server_socket);
				manual_event.WaitOne();
			}
			while (true);
		}

		private void AcceptAsyncResult(IAsyncResult obj)
		{
			SocketError socket_error;
			Socket running_socket = ((Socket)obj.AsyncState).EndAccept(obj);

			manual_event.Set();

			string sender_ip = ((IPEndPoint)running_socket.RemoteEndPoint).Address.ToString();
			string filter = "SENDER_IP = '{0}'";

			dv_integration.RowFilter = string.Format(filter, sender_ip);

			if (!Utilities.HasData(dv_integration))
			{
				IPHostEntry sender_host = Dns.GetHostEntry(sender_ip);

				dv_integration.RowFilter = string.Format(filter, sender_host.HostName);
			}

			if (Utilities.HasData(dv_integration))
			{
				DataRowView drv_3rd_party = dv_integration[0];

				switch (drv_3rd_party["SERVER_UID"].ToString().ToLower())
				{
					case "synapse":
						HL7ACK hl7_ack = new HL7ACK();
						hl7_ack.MSH.MESSAGE_CONTROL_ID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
						hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AA";
						hl7_ack.MSA.TEXT_MESSAGE = "Connected";

						socket_error = Send(running_socket, GenerateACK.ConvertToHL7(hl7_ack));

						if (socket_error != SocketError.Success)
						{
							Utilities.SaveLog(title_log, "AcceptAsyncResult(IAsyncResult obj) : Connecting", string.Format("Synapse connect but {0}", socket_error), true);
							return;
						}
						break;
				}

				do
				{
					string[] message;

					socket_error = Receive(running_socket, out message);

					if (message.Length < 1) break;

					OnMessageReceived(running_socket, new ReceiveSocketEventArgs()
					{
						SocketStatus = socket_error,
						SenderIP = sender_ip,
						WorkStationId = Convert.ToInt32(drv_3rd_party["WORK_STATION_ID"]),
						WorkStationUid = drv_3rd_party["WORK_STATION_UID"].ToString(),
						ServerUid = drv_3rd_party["SERVER_UID"].ToString(),
						Messages = message
					});
				}
				while (running_socket.Connected && socket_error == SocketError.Success);

				running_socket.Close();
			}
			else
			{
				Utilities.SaveLog(title_log, "AcceptAsyncResult(IAsyncResult obj) : Connecting", string.Format("{0} try connect", sender_ip), true);

				running_socket.Close();
			}
		}
		protected virtual void OnMessageReceived(object sender, ReceiveSocketEventArgs e) { if (ReceiveCompleted != null) ReceiveCompleted(sender, e); }

		public static SocketError Send(Socket socket, string message)
		{
			SocketError socket_error;

			Byte[] buffer = Encoding.GetEncoding(874).GetBytes(
					MISocket.StringStartMessage
					+ message
					+ MISocket.StringEndMessage);

			socket.Send(buffer, 0, buffer.Length, SocketFlags.None, out socket_error);

			return socket_error;
		}
		public static SocketError Receive(Socket socket, out string[] message)
		{
			SocketError socket_error;

			Byte[] buffer = new Byte[socket.ReceiveBufferSize];

			socket.Receive(buffer, 0, buffer.Length, SocketFlags.None, out socket_error);

			message = DecodeMessage(buffer);

			return socket_error;
		}

		public static HL7ACK Send(string ip, int port, string message)
		{
			HL7ACK result = new HL7ACK();

			using (HL7SocketEngine socket = new HL7SocketEngine(ip, port))
			{
				socket.Connect();

				result = socket.Send(message);
			}

			return result;
		}

		public static string StringStartMessage { get { return Convert.ToChar(0x0b).ToString(); } }
		public static string StringEndMessage { get { return Convert.ToChar(0x1c).ToString() + Convert.ToChar(0x0d).ToString(); } }
		public static string StringSegmentTerminator { get { return Convert.ToChar(0x0d).ToString(); } }
		public static string[] DecodeMessage(byte[] buffer)
		{
			string[] temp_split = Encoding.GetEncoding(874).GetString(buffer).Split(new string[] { StringStartMessage }, StringSplitOptions.RemoveEmptyEntries);

			List<string> result = new List<string>();

			foreach (string item in temp_split)
			{
				int pointer = item.IndexOf(StringEndMessage);

				if (pointer > -1)
					result.Add(
						item.Remove(pointer)
						.Replace(Convert.ToChar(0x0d).ToString() + Convert.ToChar(0x0a).ToString(), StringSegmentTerminator)
						.Replace(Convert.ToChar(0x00).ToString(), string.Empty)
						.Trim());
			}

			return result.ToArray();
		}
	}

	public delegate void ReceiveSocketCompleted(object sender, ReceiveSocketEventArgs e);

	public class ReceiveSocketEventArgs : EventArgs
	{
		public SocketError SocketStatus;
		public string SenderIP;
		public int WorkStationId;
		public string WorkStationUid;
		public string ServerUid;
		public string[] Messages;
	}
}