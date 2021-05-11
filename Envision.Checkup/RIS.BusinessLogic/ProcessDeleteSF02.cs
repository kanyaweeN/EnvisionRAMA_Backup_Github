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
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteSF02 : IBusinessLogic
    {
        private RISSF02Data  _objdata;

        public ProcessDeleteSF02()
        {

        }

        public void Invoke()
        {
            RISSF02DeleteData objdata = new RISSF02DeleteData();
            objdata.RISSF02Data = this.RISSF02Data;
            objdata.Delete();

        }

        public RISSF02Data RISSF02Data
        {
            get { return _objdata; }
            set { _objdata = value; }
        }
    }
}
