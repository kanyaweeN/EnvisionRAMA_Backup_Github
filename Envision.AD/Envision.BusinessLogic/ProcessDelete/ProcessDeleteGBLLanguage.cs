using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLLanguage:IBusinessLogic
    {
        public List<String> DeleteItem { get; set; }

        public ProcessDeleteGBLLanguage() {
            DeleteItem = new List<string>();
        }

        public void Invoke()
        {
            foreach (string item in DeleteItem)
            {
                GBLLanguageDeleteData lang = new GBLLanguageDeleteData();
                lang.LangId = item;
                lang.Get();
            }
        }
    }
}
