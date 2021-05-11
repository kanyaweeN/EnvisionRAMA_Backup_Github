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
    public class ProcessDeleteSF09 : IBusinessLogic
    {
        private RISSF09Data  _objdata;

        public ProcessDeleteSF09()
        {

        }

        public void Invoke()
        {
            RISSF09DeleteData objdata = new RISSF09DeleteData();
            objdata.RISSF09Data = this.RISSF09Data;
            objdata.Delete();

        }

        public RISSF09Data RISSF09Data
        {
            get { return _objdata; }
            set { _objdata = value; }
        }
    }
}
