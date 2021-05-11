using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetLanguage : IBusinessLogic
    {
        private FormLanguage _flang;
		private DataSet _resultset;

        public ProcessGetLanguage()
		{

		}

		public void Invoke()
		{
			FormLanguageSelectData langdata = new FormLanguageSelectData();
            langdata.FormLanguage = this.FormLanguage;
            ResultSet = langdata.Get();
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}

        public FormLanguage FormLanguage
        {
            get { return _flang; }
            set { _flang = value; }
        }
        	

		
    }
}
