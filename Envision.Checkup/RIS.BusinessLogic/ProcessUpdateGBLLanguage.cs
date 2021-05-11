using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLLanguage
    {
        private List<GBLLanguage> _languageItem = new List<GBLLanguage>();



        public void Invoke()
        {
            foreach (GBLLanguage item in _languageItem)
            {
                GBLLanguageUpdateData lang = new GBLLanguageUpdateData();
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
