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
    public class ProcessGetFormAccess : IBusinessLogic
    {
        
        private DataSet _resultset;

        public ProcessGetFormAccess()
        {

        }

        public void Invoke()
        {
            FormAccessSelectData accessdata = new FormAccessSelectData();
            ResultSet = accessdata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        

    }
}
