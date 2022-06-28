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
    public class ProcessAddOrderImages : IBusinessLogic
    {
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }

        public ProcessAddOrderImages()
        {
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
        }

        public void Invoke()
        {
            OrderImagesInsertData imagedata = new OrderImagesInsertData();
            imagedata.RIS_ORDERIMAGE = this.RIS_ORDERIMAGE;
            imagedata.Add();

        }
    }
}
