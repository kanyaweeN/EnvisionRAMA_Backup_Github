using System;
using System.Runtime.InteropServices;
using BOOL = System.Boolean;
using DWORD = System.UInt32;
using LPWSTR = System.String;
using NET_API_STATUS = System.UInt32;

namespace EnvisionInterfaceEngine.Operational.Credentials
{
	/// <summary>
	/// Connect to a UNC Path with Credentials.
	/// Author  : hayes.adrian
	/// Licence : The Code Project Open License (CPOL) 1.02
	/// refer   : http://www.codeproject.com/Articles/43091/Connect-to-a-UNC-Path-with-Credentials
	/// </summary>
	public class CredentialsUncPath : IDisposable
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct USE_INFO_2
		{
			internal LPWSTR ui2_local;
			internal LPWSTR ui2_remote;
			internal LPWSTR ui2_password;
			internal DWORD ui2_status;
			internal DWORD ui2_asg_type;
			internal DWORD ui2_refcount;
			internal DWORD ui2_usecount;
			internal LPWSTR ui2_username;
			internal LPWSTR ui2_domainname;
		}
		[DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		internal static extern NET_API_STATUS NetUseAdd(LPWSTR UncServerName, DWORD Level, ref USE_INFO_2 Buf, out DWORD ParmError);
		[DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		internal static extern NET_API_STATUS NetUseDel(LPWSTR UncServerName, LPWSTR UseName, DWORD ForceCond);

		private bool disposed = false;
		private string remote;

		/// <summary>
		/// You can use the MSDN System Error Codes page at http://msdn.microsoft.com/en-us/library/ms681381%28VS.85%29.aspx.
		/// </summary>
		public int LastError { get; private set; }

		public CredentialsUncPath()
		{
			LastError = 0;
		}

		public bool NetUseWithCredentials(string uncPath, string domain, string user, string pass)
		{
			remote = uncPath;

			try
			{
				USE_INFO_2 use_info = new USE_INFO_2();
				use_info.ui2_remote = remote;
				use_info.ui2_username = user;
				use_info.ui2_domainname = domain;
				use_info.ui2_password = pass;
				use_info.ui2_asg_type = 0;
				use_info.ui2_usecount = 1;

				uint param_error;

				LastError = (int)NetUseAdd(null, 2, ref use_info, out param_error);
			}
			catch
			{
				LastError = Marshal.GetLastWin32Error();
			}

			return LastError == 0;
		}
		public bool NetUseDelete()
		{
			try
			{
				LastError = (int)NetUseDel(null, remote, 2);
			}
			catch
			{
				LastError = Marshal.GetLastWin32Error();
			}

			return LastError == 0;
		}
		public void Dispose()
		{
			if (!this.disposed)
			{
				NetUseDelete();
			}
			disposed = true;
			GC.SuppressFinalize(this);
		}

		~CredentialsUncPath()
		{
			Dispose();
		}
	}
}