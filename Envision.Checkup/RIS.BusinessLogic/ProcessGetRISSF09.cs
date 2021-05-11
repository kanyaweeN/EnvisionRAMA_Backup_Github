/*
 * Project	: RIS
 *
 * Author   : Tossapol Anchaleechamaikorn
 * eMail    : yod.jim@gmail.com
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
    public class ProcessGetRISSF09 : IBusinessLogic
    {
        
        private DataSet _resultset;

        public ProcessGetRISSF09()
        {

        }

        public void Invoke()
        {
            RISSF09SelectData proddata = new RISSF09SelectData();
            ResultSet = proddata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

       

    }
}
