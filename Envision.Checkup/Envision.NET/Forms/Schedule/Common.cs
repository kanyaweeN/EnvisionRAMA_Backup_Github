using System;

namespace RIS.Forms.Schedule
{
	/// <summary>
	/// Helper class with constants used by the samples
	/// </summary>
	public class Common
	{
		#region Constructor
		private Common()
		{
		}
		#endregion //Constructor

		#region Constants

#if CLR2
		// HKCR path
		private const string DataRegistryKey = @"Infragistics\NetAdvantage\Net\Full\WinForms\CLR2x\Version" + Infragistics.Shared.AssemblyVersion.MajorMinor + @"\WinDataDir";
#else
		// HKCR path
		private const string DataRegistryKey = @"Infragistics\NetAdvantage\Net\Full\WinForms\CLR1x\Version" + Infragistics.Shared.AssemblyVersion.MajorMinor + @"\WinDataDir";
#endif

		#endregion //Constants

		#region DataPath
		/// <summary>
		/// Path to the data installed by the install.
		/// </summary>
		public static string DataPath
		{
			get
			{
				Microsoft.Win32.RegistryKey dataRegKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(DataRegistryKey);

				string path = null;

				if (dataRegKey != null)
				{
					path = dataRegKey.GetValue(null) as string;
					dataRegKey.Close();
				}

				return path;
			}
		}
		#endregion //DataPath
	}
}
