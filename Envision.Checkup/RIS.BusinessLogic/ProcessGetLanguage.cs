/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Select;
using System.Data;
using RIS.Common;

namespace RIS.BusinessLogic
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
