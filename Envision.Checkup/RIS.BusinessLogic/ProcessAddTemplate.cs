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
    public class ProcessAddTemplate : IBusinessLogic
    {
        private ExamResultTemplate _template;

        public ProcessAddTemplate()
        {

        }

        public void Invoke()
        {
            TemplateInsertData templatedata = new TemplateInsertData();
            templatedata.ExamResultTemplate = this.ExamResultTemplate;
            templatedata.Add();

        }

        public ExamResultTemplate ExamResultTemplate
        {
            get { return _template; }
            set { _template = value; }
        }
    }
}
