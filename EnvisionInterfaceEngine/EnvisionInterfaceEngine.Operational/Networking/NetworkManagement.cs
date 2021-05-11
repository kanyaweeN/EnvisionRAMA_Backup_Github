using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace EnvisionInterfaceEngine.Operational.Networking
{
	public class NetworkManagement : IDisposable
	{
		//http://www.pinvoke.net/default.aspx/mpr.wnetaddconnection3
		public enum NetworkResourceScope
		{
			CONNECTED,
			GLOBALNET,
			REMEMBERED
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct NetworkResource
		{
			public NetworkResourceScope Scope;
			public int Type;
			public int DisplayType;
			public int Usage;
			public string LocalName;
			public string RemoteName;
			public string Comment;
			public string Provider;
		}

		[DllImport("mpr.dll")]
		private static extern int WNetAddConnection2A(ref NetworkResource resource, string password, string username, int flags);
		[DllImport("mpr.dll")]
		private static extern int WNetCancelConnection2A(string name, int flags, int force);

		private bool disposed = false;
		private string remote;

		/// <summary>
		/// You can use the MSDN System Error Codes page at http://msdn.microsoft.com/en-us/library/ms681381%28VS.85%29.aspx.
		/// </summary>
		public string ExceptionMessage { get; private set; }

		public NetworkManagement() { }
		~NetworkManagement()
		{
			Dispose();
		}
		public void Dispose()
		{
			if (!disposed)
			{
				NetUseDel();
			}
			disposed = true;
			GC.SuppressFinalize(this);
		}

		public bool NetUseAdd(string local, string remote, string username, string domainname, string password)
		{
			int error;

			try
			{

				error = (int)0;
			}
			catch
			{
				error = Marshal.GetLastWin32Error();
			}
			return error == 0;
		}
		public bool NetUseDel()
		{
			int error;

			try
			{
				error = (int)0;
			}
			catch
			{
				error = Marshal.GetLastWin32Error();
			}

			return error == 0;
		}

		private void setLastErrorMessaege(int error)
		{
			Win32Exception exception = new Win32Exception(error);

			ExceptionMessage = exception.Message;
		}
	}
}
