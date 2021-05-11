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
    public class ProcessGetGBLLookup : IBusinessLogic
    {
        private string _qry;
        private DataSet _resultset;

        public ProcessGetGBLLookup(string qry)
        {
            _qry = qry;
        }

        public void Invoke()
        {
            GBLLookupSelectData lookupdata = new GBLLookupSelectData();
            ResultSet = lookupdata.Get(_qry);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        

    }
}
