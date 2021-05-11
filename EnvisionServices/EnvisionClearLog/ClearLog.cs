using System;
using System.IO;

namespace EnvisionClearLog
{
	public class ClearLog
	{
		private const string title_log = "EnvisionClearLog.ClearLog";

		private int count_clear_files;
		private int count_clear_folders;

		public ClearLog() { }

		public void Invoke()
		{
			try
			{
				saveLog(title_log, "Invoke()", "Begin", false);

				count_clear_files = 0;
				count_clear_folders = 0;

				deleteFileOverDay();

				saveLog(title_log, "Invoke()", string.Format("Deleted {0} files {1} folders.", count_clear_files, count_clear_folders), false);
				saveLog(title_log, "Invoke()", "End", false);
			}
			catch (Exception ex)
			{
				saveLog(title_log, "Invoke()", ex.Message, true);
			}
		}

		private void deleteFileOverDay()
		{
			try
			{
				foreach (string directory_name in ConfigService.ClearDirectories)
				{
					DirectoryInfo directory = new DirectoryInfo(directory_name.Trim());

					if (directory.Exists)
					{
						foreach (string extension in ConfigService.ClearFileExtensions)
						{
							int counter = 0;
							FileInfo[] files = directory.GetFiles(extension.Trim(), SearchOption.AllDirectories);

							foreach (FileInfo item in files)
							{
								if ((DateTime.Today - item.LastWriteTime.Date).Days > ConfigService.ClearOverDays)
								{
									item.Delete();

									counter++;
								}
							}

							if (counter > 0)
							{
								count_clear_files += counter;

								deleteFolderEmpty(directory);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				saveLog(title_log, "deleteFileOverDay()", ex.Message, true);
			}
		}
		private void deleteFolderEmpty(DirectoryInfo directory)
		{
			try
			{
				DirectoryInfo[] directories = directory.GetDirectories();

				if (directories.Length > 0)
				{
					foreach (DirectoryInfo item in directories)
					{
						deleteFolderEmpty(item);
					}
				}

				if (directory.GetFiles("*.*", SearchOption.AllDirectories).Length == 0)
				{
					directory.Delete();

					count_clear_folders++;
				}
			}
			catch (Exception ex)
			{
				saveLog(title_log, "deleteFolderEmpty(DirectoryInfo dir)", ex.Message, true);
			}
		}

		public static bool saveLog(string function, string caption, string message, bool mistake)
		{
			try
			{
				string full_name = ConfigService.LogPath + function + "_" + DateTime.Now.ToString("yyyyMMdd") + (mistake ? "_Error" : "") + ".txt";

				new FileInfo(full_name).Directory.Create();

				File.AppendAllText(full_name, DateTime.Now.ToString("HH:mm:ss") + " || [" + caption + "] " + message + "\r\n");
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}