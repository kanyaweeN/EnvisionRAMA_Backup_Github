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
    public class ProcessAddRISSF02 : IBusinessLogic
    {
        private RISSF02Data _gbobj;

        public ProcessAddRISSF02()
        {

        }

        public void Invoke()
        {
            RISSF02InsertData indata = new RISSF02InsertData();
            indata.RISSF02Data = this.RISSF02Data;
            indata.Add();

        }

        public RISSF02Data RISSF02Data
        {
            get { return _gbobj; }
            set { _gbobj = value; }
        }
    }
}
