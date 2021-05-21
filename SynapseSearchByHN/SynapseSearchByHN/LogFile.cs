using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SynapseSearchByHN
{
    public class LogFile
    {
        private string pathFile = @"C:\Program Files\SynapseSearchByHN\LogFile.txt";

        public LogFile()
        {
        }

        public void SaveLogFile(string content, string header)
        {
            try
            {
                string errMsg = "";
                errMsg += DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ssss]") + " : ";
                errMsg += header + " - ";
                errMsg += content + ".";
                errMsg += Environment.NewLine;

                File.AppendAllText(pathFile, errMsg);
            }
            catch { }
        }
    }
}
