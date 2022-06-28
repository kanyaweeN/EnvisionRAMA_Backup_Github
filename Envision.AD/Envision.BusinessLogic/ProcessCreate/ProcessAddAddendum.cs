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
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddAddendum : IBusinessLogic
    {
        public RIS_EXAMRESULTNOTE RIS_EXAMRESULTNOTE { get; set; }

        public ProcessAddAddendum()
        {
            RIS_EXAMRESULTNOTE = new RIS_EXAMRESULTNOTE();
        }

        public void Invoke()
        {
            AddendumInsertData addendumdata = new AddendumInsertData();
            addendumdata.RIS_EXAMRESULTNOTE = RIS_EXAMRESULTNOTE;
            addendumdata.Add();

        }
    }
}
