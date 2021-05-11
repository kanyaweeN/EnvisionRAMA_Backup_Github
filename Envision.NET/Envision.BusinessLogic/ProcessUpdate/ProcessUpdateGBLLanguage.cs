using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLLanguage
    {
        public GBL_LANGUAGE GBL_LANGUAGE{get;set;}
        public List<GBL_LANGUAGE> _languageItem { get; set; }

        public ProcessUpdateGBLLanguage()
        {
            GBL_LANGUAGE = new GBL_LANGUAGE();
            _languageItem = new List<GBL_LANGUAGE>();
        }

        public void Invoke()
        {
            foreach (GBL_LANGUAGE item in _languageItem)
            {
                GBLLanguageUpdateData lang = new GBLLanguageUpdateData();
                lang.GBL_LANGUAGE = item;
                lang.Get();
            }
        }

    }
}
