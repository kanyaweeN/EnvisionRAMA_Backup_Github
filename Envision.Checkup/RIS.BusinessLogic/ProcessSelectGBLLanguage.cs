using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessSelectGBLLanguage : IBusinessLogic
    {
		private DataSet _resultset;

        public void Invoke()
        {
            GBLLanguageSelectData lang = new GBLLanguageSelectData();
            _resultset = lang.Get();
        }
        public void Invoke2()
        {
            GBLLanguageSelectData lang = new GBLLanguageSelectData();
            _resultset = lang.Get2();
        }
        public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}



        
    }
}
