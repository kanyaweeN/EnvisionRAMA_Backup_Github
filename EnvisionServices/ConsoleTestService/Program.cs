using System;
using System.Configuration;
using EnvisionClearLog;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;

namespace ConsoleTestService
{
	static class Program
	{
		static void Main()
		{
			string[] configs = ConfigurationManager.AppSettings.AllKeys;

			Console.WriteLine(string.Empty.PadRight(79, '*'));
			foreach (string config in configs)
			{
				Console.WriteLine(string.Format("{0} {1}", config.PadRight(20, ' '), ConfigurationManager.AppSettings[config]));
			}
			Console.WriteLine(string.Empty.PadRight(79, '*'));

			//new ClearLog().Invoke();
			new testUDPClient();

			while (Console.ReadKey().Key != ConsoleKey.Escape) ;
		}
	}

	public class testUDPClient
	{
		private ManualResetEvent manual_event;

		public Socket client_socket;
		public Byte[] buffer = new Byte[1024];
		public EndPoint ip_server;

		public testUDPClient()
		{
			ip_server = (EndPoint)new IPEndPoint(IPAddress.Parse("10.9.1.101"), 1000);

			byte[] buffer = Encoding.UTF8.GetBytes("ทดสอบ");

			client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			client_socket.BeginSendTo(buffer, 0, buffer.Length, SocketFlags.None, ip_server,OnSend, null);

			buffer = new byte[1024];
			//Start listening to the data asynchronously
			client_socket.BeginReceiveFrom(buffer,
									   0, buffer.Length,
									   SocketFlags.None,
									   ref ip_server,
									   OnReceive,
									   null);
		}

		private void OnSend(IAsyncResult ar)
		{
			try
			{
				client_socket.EndSend(ar);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void OnReceive(IAsyncResult ar)
		{
			try
			{
				client_socket.EndReceive(ar);

				Console.WriteLine(Encoding.UTF8.GetString(buffer));

				buffer = new Byte[1024];

				client_socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ip_server,
									   new AsyncCallback(OnReceive), null);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public class UDPServer
		{
			ManualResetEvent manual_event;
			Socket server_socket;
			List<EndPoint> client_list;

			byte[] byte_buffer = new byte[1024];

			public UDPServer()
			{
				client_list = new List<EndPoint>();

				try
				{
					UdpClient udp = new UdpClient(1000);
					udp.BeginReceive(OnReceive, udp);

					server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
					server_socket.Bind(new IPEndPoint(IPAddress.Parse("10.9.1.101"), 1000));

					EndPoint epSender = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
					SocketError socket_error;

					do
					{
						manual_event.Reset();
						server_socket.BeginReceive(byte_buffer, 0, byte_buffer.Length, SocketFlags.None, out socket_error, OnReceive, server_socket);
						manual_event.WaitOne();
					}
					while (true);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			private void OnReceive(IAsyncResult ar)
			{
				try
				{
					//EndPoint sender = ((UdpClient)ar.AsyncState);
					//manual_event.Set();

					//server_socket.EndReceive(ar);

					//client_list.Add(sender);

					//foreach (EndPoint receiver in client_list)
					//{
					//    server_socket.BeginSend.BeginSendTo(byte_buffer, 0, byte_buffer.Length, SocketFlags.None, receiver, new AsyncCallback(OnSend), receiver);
					//}

					//server_socket.EndReceive(ar);
					//server_socket.BeginReceiveFrom(byte_buffer, 0, byte_buffer.Length, SocketFlags.None, ref sender, new AsyncCallback(OnReceive), sender);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			public void OnSend(IAsyncResult ar)
			{
				try
				{
					server_socket.EndSend(ar);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}