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

using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateRISSF09 : IBusinessLogic
    {
        private RISSF09Data _obj;

        public ProcessUpdateRISSF09()
        {

        }

        public void Invoke()
        {
            RISSF09UpdateData objdata = new RISSF09UpdateData();
            objdata.RISSF09Data = this.RISSF09Data;
            objdata.Add();

        }

        public RISSF09Data RISSF09Data
        {
            get { return _obj; }
            set { _obj = value; }
        }
    }
}
