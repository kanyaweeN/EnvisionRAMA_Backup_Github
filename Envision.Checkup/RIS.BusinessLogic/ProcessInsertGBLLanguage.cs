using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessInsertGBLLanguage
    {

        private List<GBLLanguage> _languageItem = new List<GBLLanguage>();

        

        public void Invoke()
        {
            foreach (GBLLanguage item in _languageItem)
            {
                GBLLanguageInsertData lang = new GBLLanguageInsertData();
                lang.LangItem = item;
                lang.Get();
            }
        }

        public List<GBLLanguage> LanguageItem
        {
            get { return _languageItem; }
            set { _languageItem = value; }
        }

    }
}
