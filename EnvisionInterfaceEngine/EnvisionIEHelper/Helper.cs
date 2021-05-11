using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using EnvisionInterfaceEngine.Operational;
using EnvisionInterfaceEngine.Operational.Credentials;
using EnvisionInterfaceEngine.WebService;
using EnvisionInterfaceEngine.Common.Miracle;
using EnvisionInterfaceEngine.Common.Global;
using System.Text;
using EnvisionInterfaceEngine.Connection;

namespace EnvisionIEHelper
{
	public class Helper : IDisposable
	{
		private readonly string title_log;
		private bool disposed = false;

		private EnvisionIEGet3rdPartyData ws_3rdparty;
		private CredentialsUncPath identity;
        private EnvisionIEPreSyncParams ws_presync;

		public Helper()
		{
			title_log = ToString();

			ws_3rdparty = new EnvisionIEGet3rdPartyData(ConfigService.UrlWebService);
            ws_presync = new EnvisionIEPreSyncParams(ConfigService.UrlWebService);
		}
		~Helper()
		{
			if (!disposed)
				Dispose();
		}

		public void Invoke()
		{
			try
			{
                checkPoint();

				if (!string.IsNullOrEmpty(ConfigService.ThirdPartyUncPath))
				{
					identity = new CredentialsUncPath();

					if (!identity.NetUseWithCredentials(ConfigService.ThirdPartyUncPath, ConfigService.ThirdPartyUserDomainName, ConfigService.ThirdPartyUserName, ConfigService.ThirdPartyPassword))
					{
						Utilities.SaveLog(title_log, "Invoke()", "Credentials UNC path have last error is " + identity.LastError.ToString(), true);

						return;
					}
				}

				if (!string.IsNullOrEmpty(ConfigService.ThirdPartyDirectoryReceive)
					&& !Directory.Exists(ConfigService.ThirdPartyDirectoryReceive))
				{
					Utilities.SaveLog(title_log, "Invoke()", "Directory not found", true);

					return;
				}

				switch (ConfigService.HowAction.ToLower())
				{
					case "filesystemwatcher":
						Utilities.SaveLog(title_log, "Invoke()", "Begin", false);

						sweepDirectories();
						fileSystemWatcher();

						Utilities.SaveLog(title_log, "Invoke()", "End", false);
						break;
                    case "checkCrossSync":
                        ws_3rdparty.Check_Sync();
                        break;
                    case "sweephl7":
                        RISConnection ris = new RISConnection();
                        DataTable dtOrm = ris.selectDataSweepHL7ORM();
                        foreach (DataRow rowOrm in dtOrm.Rows)
                            ws_presync.Set_ORMByAccessionNoQueue(0, rowOrm["ACCESSION_NO"].ToString(), 1);
                        DataTable dtOru = ris.selectDataSweepHL7ORU();
                        foreach (DataRow rowOru in dtOru.Rows)
                            ws_presync.Set_ORUByAccessionNoQueue(0, rowOru["ACCESSION_NO"].ToString(), 1);

                        ris = new RISConnection();
                        DataTable dtCheckScheduleStatus = ris.selectDataScheduleNotUpdateStatus();
                        foreach (DataRow rowSch in dtCheckScheduleStatus.Rows)
                            ris.updateDataScheduleNotUpdateStatus(
                                rowSch["IS_CANCELED"].ToString() == "Y" ? "C" : "O"
                                , Convert.ToInt32(rowSch["SCHEDULE_ID"])
                                );

                        ris = new RISConnection();
                        DataTable dtCheckCommentScheduleID = ris.selectDataCommentFixScheduleID();
                        foreach (DataRow rowCom in dtCheckCommentScheduleID.Rows)
                            ris.updateDataCommentFixScheduleID(Convert.ToInt32(rowCom["ORDER_ID"]), Convert.ToInt32(rowCom["SCHEDULE_ID"]));

                        ris = new RISConnection();
                        DataTable dtCheckCommentOrderID = ris.selectDataCommentFixOrderIdAccession();
                        foreach (DataRow rowCom in dtCheckCommentOrderID.Rows)
                            ris.updateDataCommentFixOrderIdAccession(Convert.ToInt32(rowCom["EXAM_ID"]), Convert.ToInt32(rowCom["SCHEDULE_ID"]));
                        break;
					default:
						if (string.IsNullOrEmpty(ConfigService.ThirdPartyDirectoryReceive))
						{
							using (DataSet ds_result = ws_3rdparty.Get_Billing(new DataSet("EnvisionIE").Copy()))
							{
								if (!Utilities.HasData(ds_result))
									Utilities.SaveLog(title_log, "Invoke() : EnvisionIEGet3rdPartyData", "Data is null", true);
								else
								{
									int index_ack = ds_result.Tables.IndexOf("ACK");

									if (index_ack == -1)
										index_ack = 0;

									DataRow dr = ds_result.Tables[index_ack].Rows[0];

									if (dr["ACKNOWLEDGMENT_CODE"].ToString() != string.Empty)
										Utilities.SaveLog(title_log, "Invoke() : EnvisionIEGet3rdPartyData", string.Format("{0} {1}", dr["ACKNOWLEDGMENT_CODE"], dr["TEXT_MESSAGE"]), false);
								}
							}
						}
						else sweepDirectories();
						break;
				}
			}
			catch (Exception ex) { Utilities.SaveLog(title_log, "Invoke()", ex.Message, true); }
		}
		public void Dispose()
		{
			if (ws_3rdparty != null)
			{
				ws_3rdparty.Dispose();
				ws_3rdparty = null;
			}
			if (identity != null)
			{
				identity.Dispose();
				identity = null;
			}

			disposed = true;
		}
        private void checkPoint()
        {
            MIStringArray files_name = null;

            if (Directory.Exists(Config.LogPath))
                files_name = new MIStringArray(Directory.GetFiles(Config.LogPath, "*.checkpoint", SearchOption.TopDirectoryOnly));

            if (files_name == null || files_name.Values.Count == 0)
                Utilities.SaveTextFile(string.Format("{0}{1:yyyyMMdd HHmmss}.checkpoint", Config.LogPath, DateTime.Now), Encoding.Default, string.Empty, false);
            else
            {
                foreach (string file_name in files_name.Values)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            File.Move(file_name, string.Format("{0}{1:yyyyMMdd HHmmss}.checkpoint", Config.LogPath, DateTime.Now));

                            break;
                        }
                        catch (IOException) { Thread.Sleep(100); }
                        catch { break; }
                    }
                }
            }
        }
		
		private void sweepDirectories()
		{
			List<string> subdirectories = new List<string>();
			subdirectories.AddRange(ConfigService.ThirdPartySubdirectoriesReceive);

			if (subdirectories.Count == 0)
				subdirectories.Add(string.Empty);

			int flag_success = 0;
			int flag_fail = 0;

			foreach (string subdirectory in subdirectories)
			{
				string folder = subdirectory.Trim();
				string directory = ConfigService.ThirdPartyDirectoryReceive + (folder == string.Empty ? string.Empty : "\\" + folder);

				if (Directory.Exists(directory))
				{
					foreach (string extension in ConfigService.ThirdPartyFileExtensions)
					{
						string[] files = Directory.GetFiles(
							directory,
							extension.Trim(),
							ConfigService.ThirdPartyIncludeSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

						foreach (string file in files)
						{
							if (openTextFile(file, folder))
								flag_success++;
							else
								flag_fail++;
						}
					}
				}
			}

			if (flag_success + flag_fail > 0)
				Utilities.SaveLog(title_log, "sweepDirectories()", string.Format("Sweep files {0} success {1} fail", flag_success, flag_fail), false);
		}

		private void fileSystemWatcher()
		{
			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = ConfigService.ThirdPartyDirectoryReceive;
			watcher.IncludeSubdirectories = ConfigService.ThirdPartyIncludeSubdirectories;
			watcher.NotifyFilter = NotifyFilters.FileName;
			watcher.Created += new FileSystemEventHandler(FileWatcherCreated);
			watcher.EnableRaisingEvents = true;

			while (true)
				watcher.WaitForChanged(WatcherChangeTypes.Created, ConfigService.FileSystemWatcherTimeout);
		}

		private void FileWatcherCreated(object sender, FileSystemEventArgs e)
		{
            checkPoint();
			Thread.Sleep(100);

			openTextFile(e.FullPath, string.Empty);
		}

		private bool openTextFile(string fullName, string folderName)
		{
			string value = string.Empty;

			for (int i = 0; i < 10; i++)
			{
				try
				{
					value = Utilities.OpenTextFile(fullName, ConfigService.ThirdPartyEncoding);

					break;
				}
				catch (IOException) { Thread.Sleep(100); }
				catch { break; }
			}

			if (string.IsNullOrEmpty(value))
				Utilities.SaveLog(title_log, "openTextFile(string fullName)", string.Format("{0} empty text", fullName), false);
			else
			{
				DataSet ds = new DataSet("EnvisionIE");
				ds.Tables.Add("TextFile");

				ds.Tables["TextFile"].Columns.Add("FullName");
				ds.Tables["TextFile"].Columns.Add("Value");
				ds.Tables["TextFile"].Rows.Add(
					fullName,
					value);
				ds.AcceptChanges();

				using (DataSet ds_result = ws_3rdparty.Get_Billing(ds.Copy()))
				{
					if (!Utilities.HasData(ds_result))
						Utilities.SaveLog(title_log, "openTextFile(string fullName) : EnvisionIEGet3rdPartyData", "Data is null", true);
					else
					{
						int index_ack = ds_result.Tables.IndexOf("ACK");

						if (index_ack == -1)
							index_ack = 0;

						DataRow dr = ds_result.Tables[index_ack].Rows[0];

						if (dr["ACKNOWLEDGMENT_CODE"].ToString() != "AA")
							Utilities.SaveLog(title_log, "openTextFile(string fullName) : EnvisionIEGet3rdPartyData", string.Format("{0} {1}", dr["ACKNOWLEDGMENT_CODE"], dr["TEXT_MESSAGE"]), true);
					}
				}
			}

			FileInfo file = new FileInfo(fullName);

			if (file.Exists)
			{
				if (!string.IsNullOrEmpty(ConfigService.ThirdPartyDirectoryReceiveBackup))
				{
					Utilities.SaveTextFile(
						string.Format("{0}\\{1:yyyyMMdd}\\{2}{3}",
							ConfigService.ThirdPartyDirectoryReceiveBackup,
							DateTime.Today,
							(folderName == string.Empty ? string.Empty : folderName + "\\"),
							file.Name),
						ConfigService.ThirdPartyEncoding,
						value,
						false);
				}
				file.Delete();
			}

			return true;
		}
	}
}