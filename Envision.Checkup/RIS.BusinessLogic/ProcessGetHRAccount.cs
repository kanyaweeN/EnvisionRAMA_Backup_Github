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
    public class ProcessGetHRAccount : IBusinessLogic
    {

        private DataSet _resultset;
        private HRAccount _hracc;

        public ProcessGetHRAccount()
        {

        }

        public void Invoke()
        {
            HRAccountSelectData HRdata = new HRAccountSelectData();
            HRdata.HRAccount = HRAccount;
            ResultSet = HRdata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public HRAccount HRAccount
        {
            get { return _hracc; }
            set { _hracc = value; }
        }

    }
}