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
    public class ProcessAddAddendum : IBusinessLogic
    {
        private ExamAddendum _addendum;

        public ProcessAddAddendum()
        {

        }

        public void Invoke()
        {
            AddendumInsertData addendumdata = new AddendumInsertData();
            addendumdata.ExamAddendum = this.ExamAddendum;
            addendumdata.Add();

        }

        public ExamAddendum ExamAddendum
        {
            get { return _addendum; }
            set { _addendum = value; }
        }
    }
}
