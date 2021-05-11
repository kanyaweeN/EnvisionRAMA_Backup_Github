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
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddRISSF09 : IBusinessLogic
    {
        private RISSF09Data _gbobj;

        public ProcessAddRISSF09()
        {

        }

        public void Invoke()
        {
            RISSF09InsertData indata = new RISSF09InsertData();
            indata.RISSF09Data = this.RISSF09Data;
            indata.Add();

        }

        public RISSF09Data RISSF09Data
        {
            get { return _gbobj; }
            set { _gbobj = value; }
        }
    }
}
