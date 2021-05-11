/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddTemplate : IBusinessLogic
    {
        public RIS_EXAMRESULTTEMPLATE RIS_EXAMRESULTTEMPLATE { get; set; }

        public ProcessAddTemplate()
        {
            RIS_EXAMRESULTTEMPLATE = new RIS_EXAMRESULTTEMPLATE();
        }

        public void Invoke()
        {
            TemplateInsertData templatedata = new TemplateInsertData();
            templatedata.RIS_EXAMRESULTTEMPLATE = this.RIS_EXAMRESULTTEMPLATE;
            templatedata.Add();

        }
    }
}
