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
    public class ProcessCheckSession : IBusinessLogic
    {

        private DataSet _resultset;

        public ProcessCheckSession()
        {

        }

        public void Invoke()
        {
            
        }

        public void Invoke(int userid, int sptype)
        {
            SessionSelectData sessiondata = new SessionSelectData();
            ResultSet = sessiondata.Get(userid, sptype);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
