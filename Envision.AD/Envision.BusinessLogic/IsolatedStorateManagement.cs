using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO.IsolatedStorage;
using System.IO;

namespace Envision.BusinessLogic
{
    public class IsolatedStorateManagement
    {
        /// <summary>
        /// This method use to read xml file from datatable with isolated storage on
        /// user account 
        /// </summary>
        /// <param name="filename">filename</param>
        /// <param name="datatable">datatable</param>
        public static void XMLToDataTable(string filename, ref DataTable datatable)
        {
            try
            {
                using (IsolatedStorageFile _storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
                {
                    string[] fileNames = _storage.GetFileNames(filename);
                    if (fileNames.Length > 0)
                    {
                        using (IsolatedStorageFileStream _stream = new IsolatedStorageFileStream(fileNames[0], FileMode.Open, FileAccess.Read, _storage))
                        {
                            datatable.ReadXml(_stream);
                        }
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// This method use to save datatable to xml file with isolated storage on
        /// </summary>
        /// <param name="filename">filename</param>
        /// <param name="datatable">datatable</param>
        public static void DataTableToXML(string filename, DataTable datatable)
        {
            try
            {
                using (IsolatedStorageFile _storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
                {
                    using (IsolatedStorageFileStream _writeFile = new IsolatedStorageFileStream(filename, FileMode.Create, FileAccess.Write, _storage))
                    {
                        datatable.WriteXml(_writeFile);
                    }
                }
            }
            catch { }
        }
    }
}
