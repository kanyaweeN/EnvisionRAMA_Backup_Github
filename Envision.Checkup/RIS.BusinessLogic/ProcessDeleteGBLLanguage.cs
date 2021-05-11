using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGBLLanguage:IBusinessLogic
    {
        #region IBusinessLogic Members

        private List<String> _delLang = new List<string>();

        #endregion

        public void Invoke()
        {
            foreach(string item in _delLang)
            {
                GBLLanguageDeleteData lang = new GBLLanguageDeleteData();
                lang.LangId = item;
                lang.Get();
            }
        }

        public List<String> DeleteItem
        {
            get { return _delLang; }
            set { _delLang = value; }
        }


    }
}
