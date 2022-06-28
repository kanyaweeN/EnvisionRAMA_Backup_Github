using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessInsertGBLLanguage
    {
        public GBL_LANGUAGE GBL_LANGUAGE { get; set; }

        public List<GBL_LANGUAGE> _languageItem { get; set; }

        public ProcessInsertGBLLanguage()
        {
            GBL_LANGUAGE = new GBL_LANGUAGE();
            _languageItem = new List<GBL_LANGUAGE>();
        }

        public void Invoke()
        {
            foreach (GBL_LANGUAGE item in _languageItem)
            {
                GBLLanguageInsertData lang = new GBLLanguageInsertData();
                lang.GBL_LANGUAGE = item;
                lang.Get();
            }
        }


    }
}
