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
    public class ProcessUpdateRISSF02 : IBusinessLogic
    {
        private RISSF02Data _obj;

        public ProcessUpdateRISSF02()
        {

        }

        public void Invoke()
        {
            RISSF02UpdateData objdata = new RISSF02UpdateData();
            objdata.RISSF02Data = this.RISSF02Data;
            objdata.Add();

        }

        public RISSF02Data RISSF02Data
        {
            get { return _obj; }
            set { _obj = value; }
        }
    }
}
