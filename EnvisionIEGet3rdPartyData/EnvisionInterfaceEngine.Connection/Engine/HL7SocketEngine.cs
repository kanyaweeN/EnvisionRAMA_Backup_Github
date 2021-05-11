using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Common.Miracle;
using EnvisionInterfaceEngine.Operational;
using EnvisionInterfaceEngine.Operational.HL7;

namespace EnvisionInterfaceEngine.Connection.Engine
{
	public class HL7SocketEngine : IDisposable
	{
		private const string title_log = "EnvisionInterfaceEngine.Connection.Engine.HL7SocketEngine";
		private bool disposed = false;

		private Socket server_socket;

		private string address_host;
		private int address_port;

		public HL7SocketEngine(string host, int port)
		{
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
				{
					hl7_ack = GenerateACK.ConvertToObject(message_receive[0]);
				}
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
			{
				Utilities.SaveLog(title_log, "Send(string message)", string.Format("{0} : {1} {2}", hl7_ack.MSH.MESSAGE_CONTROL_ID, hl7_ack.MSA.ACKNOWLEDGMENT_CODE, hl7_ack.MSA.TEXT_MESSAGE), true);
			}

			return hl7_ack;
		}

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
			HL7SocketEngine socket = new HL7SocketEngine(ip, port);
			socket.Connect();

			return socket.Send(message);
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
				{
					result.Add(
						item.Remove(pointer)
						.Replace(Convert.ToChar(0x0d).ToString() + Convert.ToChar(0x0a).ToString(), StringSegmentTerminator)
						.Replace(Convert.ToChar(0x00).ToString(), string.Empty)
						.Trim());
				}
			}

			return result.ToArray();
		}
	}

	public delegate void ReceiveSocketCompleted(object sender, ReceiveSocketEventArgs e);

	public class ReceiveSocketEventArgs : EventArgs
	{
		public SocketError SocketStatus;
		public string RemoteIP;
		public string NameSpaceID;
		public string UniversalID;
		public string[] Messages;
	}
}