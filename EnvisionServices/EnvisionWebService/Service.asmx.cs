using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Web.Services;

namespace EnvisionWebService
{
	[WebService(Namespace = "http://www.miracleadvance.com/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.None)]
	public class Service : WebService
	{
		[WebMethod]
		public string Welcome(string how)
		{
			return "Welcome " + how;
		}

		[WebMethod]
		public bool SavePicture(string fileName, byte[] fileIn)
		{
			if (string.IsNullOrEmpty(fileName) || fileIn == null) return false;

			try
			{
				FileInfo file = new FileInfo(fileName);

				if (!file.Directory.Exists) file.Directory.Create();

				using (Bitmap img = (Bitmap)Image.FromStream(new MemoryStream(fileIn)))
				{
					img.Save(file.FullName, ImageFormat.Jpeg);
				}
			}
			catch { return false; }

			return true;
		}

		[WebMethod]
		public int GetClientPort()
		{
			return ConfigService.ClientPort;
		}

		[WebMethod]
		public void KillClientSession(string hostName)
		{
			if (string.IsNullOrEmpty(hostName)) return;

			try
			{
				using (StreamWriter stream = new StreamWriter(new TcpClient(hostName, ConfigService.ClientPort).GetStream()))
				{
					stream.WriteLine("Your session has been killed!");
					stream.Flush();
					stream.Close();
				}
			}
			catch { }
		}
        [WebMethod]
        public void SentClientSession(string hostName,string msg)
        {
            if (string.IsNullOrEmpty(hostName)) return;

            try
            {
                using (StreamWriter stream = new StreamWriter(new TcpClient(hostName, ConfigService.ClientPort).GetStream()))
                {
                    stream.WriteLine(msg);
                    stream.Flush();
                    stream.Close();
                }
            }
            catch { }
        }

		[WebMethod]
		public string ThaiToEng(string textThai)
		{
			if (string.IsNullOrEmpty(textThai)) return string.Empty;

			return TransToEnglish.Trans(textThai);
		}

		[WebMethod]
		public string ThaiToEngSalutation(string textThai)
		{
			if (string.IsNullOrEmpty(textThai)) return string.Empty;

			try
			{
				PrefixNameElementCollection prefix_config = ((PrefixNameConfig)ConfigurationManager.GetSection("PrefixNameConfig")).Element;
				PrefixNameElement[] prefix_array = new PrefixNameElement[prefix_config.Count];
				prefix_config.CopyTo(prefix_array, 0);

				PrefixNameElement element = new List<PrefixNameElement>(prefix_array).Find(x => x.PrefixName == textThai);

				if (element != null)
				{
					return element.PrefixNameEng;
				}
			}
			catch { }

			return string.Empty;
		}

		[WebMethod]
		public bool SaveClientLog(string caption, string message)
		{
			try
			{
				string full_name = string.Format("{0}{1:yyyyMMdd}.txt", ConfigService.ClientLogPath, DateTime.Today);

				FileInfo file = new FileInfo(full_name);

				if (!file.Exists)
				{
					file.Directory.Create();
				}

				using (StreamWriter writing = new StreamWriter(file.FullName, true, Encoding.Default))
				{
					writing.WriteLine(string.Format("{0:HH:mm:ss} || [{1}] {2}\r\n{3}\r\n", DateTime.Now, caption, Context.Request.UserHostName, message));
					writing.Flush();
					writing.Close();
				}
			}
			catch { return false; }

			return true;
		}
	}
}